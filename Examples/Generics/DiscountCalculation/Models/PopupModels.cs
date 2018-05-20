using bNesis.Sdk;
using bNesis.Sdk.Common;
using bNesis.Sdk.Social.Facebook;
using bNesis.Examples.DiscountCalculationApp.DAL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using bNesis.Sdk.FileStorages.GoogleDrive;
//using bNesis.Sdk.Social.GooglePlus;
using bNesis.Sdk.Social.LinkedIn;
using bNesis.Sdk.FileStorages.Box;
using bNesis.Sdk.FileStorages.Dropbox;
using bNesis.Sdk.Payment.Stripe;
using bNesis.Sdk.Payment.PayPal;
using bNesis.Sdk.eCommerce.Shopify;
using bNesis.Sdk.FileStorages.BaiduBCS;
using bNesis.Sdk.FileStorages.SugarSync;
using bNesis.Sdk.Payment.LiqPay;
using bNesis.Sdk.Social.VKontakte;
using bNesis.Sdk.eCommerce.PrestaShop;
using bNesis.Sdk.Analytics.GoogleAnalytics;
using bNesis.Sdk.Social.GooglePlus;

namespace bNesis.Examples.DiscountCalculationApp.Models
{
    /// <summary>
    /// Representation the methods in which can get user(member) profile data from Facebook/LinkedIn/GoogleDrive/etc service.
    /// </summary>
    public class PopupModel
    {
        /// <summary>
        /// For Thin Client mode, you need access to bNesis API Server. Address of the avaliable demo bNesis API Servers see higher
        /// </summary>
        private string bNesisAPIEndPoint = "https://server2.bnesis.com/";
        
        /// <summary>
        /// For this example simple data store used Users public profice at drive C:
        /// this can be not worked at some "non standard" setuped systems
        /// also see IIS User rights to access to this folder at you server
        /// </summary>
        private string dataStoreFolder = @"c:\Users\Public\bNesisDiscountCalculator\";

        /// <summary>
        /// Used for lock async operation.
        /// </summary>
        private object locker = new object();

        /// <summary>
        /// PopupModel constructor
        /// </summary>
        public PopupModel()
        {
            //create bNesis store folder if not
            Directory.CreateDirectory(dataStoreFolder);
        }

        /// <summary>
        /// write service user data to local file storage
        /// </summary>
        /// <param name="fileName">unical file name for current user data store</param>
        /// <param name="text">data to store</param>
        private void WriteFile(string fileName, string text)
        {
            //Create new thread and start it.
            new Thread(() =>
            {
                //Create local variables
                string dateTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
                string formatedText = $"[{dateTime}] {text} \n";

                //If thread enter to lock section is be lock for other threads, 
                //it means if then all other threads which enter after to locked section 
                //must wait while thread which entered before done the operation in lock section.
                lock (locker)
                {
                    //write data to file
                    using (StreamWriter file = System.IO.File.AppendText(dataStoreFolder + fileName))
                    {
                        file.Write(formatedText);

                    }
                }
            }).Start();
        }

        /// <summary>
        /// this method called if facebook authorization complet success
        /// the bNesis API server return bNesisToken to this method (is not Facebook service token, it located at bNesis API Server)
        /// this method do something data extraction method to demonstrate how using bNesis SDK API to get user data from Facebook
        /// </summary>
        /// <param name="token">bNesis token</param>
        /// <param name="service">Facebook service name</param>
        /// <returns>Return the status code.</returns>
        public string Facebook(string token, string service)
        {
            //start and setup bNesis thin SDK
            ServiceManager manager = new ServiceManager();
            //connect to bNesis server
            int SDKInitializeResult = manager.InitializeThin(bNesisAPIEndPoint);
            //Check if have some problem with connection to bNesis server.
            if (SDKInitializeResult != ServiceManager.errorCodeNoError)
            {

                WriteFile(@"Facebook_error", "can't initialize bNesis at: " + bNesisAPIEndPoint + "\n Reason:" + manager.GetLastError());
                return "BAD";
            }

            bool databasIsAvaible = Repository.Instance.IsAvaible();
            //Check if database is not avaible
            if (!databasIsAvaible)
            {
                WriteFile(@"Facebook_error", "Can't access to DataBase.");
                return "BAD";
            }
            //Check if token or service is empty or null
            if (string.IsNullOrEmpty(token)
                || string.IsNullOrEmpty(service))
            {
                WriteFile(@"Facebook_error", "Bad token or service name.");
                return "BAD";
            }

            //Create instance of service
            Facebook facebook = manager.CreateInstanceFacebook();
            string errorMessage = manager.GetLastError();
            //Check if have errorMessage
            if (!string.IsNullOrEmpty(errorMessage))
            {
                WriteFile(@"Facebook_error", "Authorization problem:" + errorMessage);
                return "BAD";
            }

            //Attach to bNesis session the input token and checks if token is valid.
            if (!facebook.Auth(token))
            {
                WriteFile(@"Facebook_error", "The token is not valid.");
                return "BAD";
            }

            new Thread(() =>
            {
                try
                {
                    //Gets user profile 
                    Response userProfile = facebook.GetFieldsUserRaw("me");
                    //Getting last error
                    ErrorInfo errorInfo = facebook.GetLastError();
                    //Stop authorization session with service and clears the value bNesis token.
                    facebook.LogoffService();

                    //Check if errorInfo code does not equal noError
                    if (errorInfo.Code != ServiceManager.errorCodeNoError)
                    {
                        WriteFile("Facebook_error", "Can't receive profile, error code: " + errorInfo.Code +
                                                    "\nReason:" + errorInfo.Description);
                        return;
                    }


                    //Convert member profile to JObject
                    JObject userObject = JsonConvert.DeserializeObject<JObject>(userProfile.Content);

                    //Convert JsonString Response to XML document
                    XDocument xml = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(
                        Encoding.ASCII.GetBytes(userProfile.Content), new XmlDictionaryReaderQuotas()));

                    //Gets identifier and convert to string.
                    string id = userObject["id"].ToString();
                    //Sets dateTime
                    string dateTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
                    //Writting xml document to the file in 
                    xml.Save($"{dataStoreFolder}/Facebook_{id}_{dateTime}.xml", SaveOptions.None);
                    //Add data to database
                    Repository.Instance.AddApiResponse("Facebook", "Facebook",
                        xml.ToString()).Wait();
                }
                catch (Exception e)
                {
                    WriteFile(@"Facebook_error", $"Error message: \n{e.Message} \n Stack trace: {e.StackTrace}");
                }
            }).Start();

            return "OK";
        }

        /// <summary>
        /// see Facebook
        /// </summary>
        /// <param name="token"></param>
        /// <param name="service"></param>
        public string LinkedIn(string token, string service)
        {
            //start and setup bNesis thin SDK
            ServiceManager manager = new ServiceManager();
            //connect to bNesis server
            int SDKInitializeResult = manager.InitializeThin(bNesisAPIEndPoint);
            //Check if have some problem with connection to bNesis server.
            if (SDKInitializeResult != ServiceManager.errorCodeNoError)
            {

                WriteFile("LinkedIn_error", "can't initialize bNesis at: " + bNesisAPIEndPoint + "\n Reason:" + manager.GetLastError());
                return "BAD";
            }

            bool databasIsAvaible = Repository.Instance.IsAvaible();
            //Check if database is not avaible
            if (!databasIsAvaible)
            {
                WriteFile(@"LinkedIn_error", "Can't access to DataBase.");
                return "BAD";
            }
            //Check if token or service is empty or null
            if (string.IsNullOrEmpty(token)
                || string.IsNullOrEmpty(service))
            {
                WriteFile(@"LinkedIn_error", "Bad token or service name.");
                return "BAD";
            }

            //Create instance of service
            LinkedIn linkedIn = manager.CreateInstanceLinkedIn();
            string errorMessage = manager.GetLastError();
            //Check if have errorMessage
            if (!string.IsNullOrEmpty(errorMessage))
            {
                WriteFile(@"LinkedIn_error", "Authorization problem:" + errorMessage);
                return "BAD";
            }
            //Attach to bNesis session the input token and checks if token is valid.
            if (!linkedIn.Auth(token))
            {
                WriteFile(@"LinkedIn_error", "The token is not valid.");
                return "BAD";
            }

            new Thread(() =>
            {

                try
                {
                    //Gets member profile 
                    Response memberProfile = linkedIn.GetMemberProfileV1Raw();
                    //Getting last error
                    ErrorInfo errorInfo = linkedIn.GetLastError();
                    //Stop authorization session with service and clears the value bNesis token.
                    linkedIn.LogoffService();

                    //Check if errorInfo code does not equal noError
                    if (errorInfo.Code != ServiceManager.errorCodeNoError)
                    {
                        WriteFile("LinkedIn_error", "Can't receive profile, error code: " + errorInfo.Code +
                                                    "\nReason:" + errorInfo.Description);
                        return;
                    }


                    //Convert member profile to JObject
                    JObject memberJObject = JsonConvert.DeserializeObject<JObject>(memberProfile.Content);

                    //Convert JsonString Response to XML document
                    XDocument xml = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(
                        Encoding.ASCII.GetBytes(memberProfile.Content), new XmlDictionaryReaderQuotas()));

                    //Gets identifier and convert to string.
                    string id = memberJObject["id"].ToString();
                    //Sets dateTime
                    string dateTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
                    //Writting xml document to the file in 
                    xml.Save($"{dataStoreFolder}/LinkedIn_{id}_{dateTime}.xml", SaveOptions.None);
                    //Add data to database
                    Repository.Instance.AddApiResponse("LinkedIn", "LinkedIn",
                        xml.ToString()).Wait();
                }
                catch (Exception e)
                {
                    WriteFile(@"LinkedIn_error",
                        $"Error message, reason: \n{e.Message} \n Stack trace: {e.StackTrace}");
                }
            }).Start();

            return "OK";
        }

        /// <summary>
        /// this method called if facebook authorization complet success
        /// the bNesis API server return bNesisToken to this method (is not Facebook service token, it located at bNesis API Server)
        /// this method do something data extraction method to demonstrate how using bNesis SDK API to get user data from Facebook
        /// </summary>
        /// <param name="token">bNesis token</param>
        /// <param name="service">VKontakte service name</param>
        /// <returns>Return the status code.</returns>
        public string VKontakte(string token, string service)
        {
            //start and setup bNesis thin SDK
            ServiceManager manager = new ServiceManager();
            //connect to bNesis server
            int SDKInitializeResult = manager.InitializeThin(bNesisAPIEndPoint);
            //Check if have some problem with connection to bNesis server.
            if (SDKInitializeResult != ServiceManager.errorCodeNoError)
            {

                WriteFile(@"VKontakte_error", "can't initialize bNesis at: " + bNesisAPIEndPoint + "\n Reason:" + manager.GetLastError());
                return "BAD";
            }

            bool databasIsAvaible = Repository.Instance.IsAvaible();
            //Check if database is not avaible
            if (!databasIsAvaible)
            {
                WriteFile(@"VKontakte_error", "Can't access to DataBase.");
                return "BAD";
            }
            //Check if token or service is empty or null
            if (string.IsNullOrEmpty(token)
                || string.IsNullOrEmpty(service))
            {
                WriteFile(@"VKontakte_error", "Bad token or service name.");
                return "BAD";
            }

            //Create instance of service
            VKontakte vKontakte = manager.CreateInstanceVKontakte();
            string errorMessage = manager.GetLastError();
            //Check if have errorMessage
            if (!string.IsNullOrEmpty(errorMessage))
            {
                WriteFile(@"VKontakte_error", "Authorization problem:" + errorMessage);
                return "BAD";
            }
            //Attach to bNesis session the input token and checks if token is valid.
            if (!vKontakte.Auth(token))
            {
                WriteFile(@"VKontakte_error", "The token is not valid.");
                return "BAD";
            }

            new Thread(() =>
            {
                try
                {
                    //Gets user profile 
                    Response userProfile = vKontakte.GetUserFullDataRaw();
                    //Getting last error
                    ErrorInfo errorInfo = vKontakte.GetLastError();
                    //Stop authorization session with service and clears the value bNesis token.
                    vKontakte.LogoffService();

                    //Check if errorInfo code does not equal noError
                    if (errorInfo.Code != ServiceManager.errorCodeNoError)
                    {
                        WriteFile("VKontakte_error", "Can't receive profile, error code: " + errorInfo.Code +
                                                    "\nReason:" + errorInfo.Description);
                        return;
                    }


                    //Convert member profile to JObject
                    JObject userObject = JsonConvert.DeserializeObject<JObject>(userProfile.Content);

                    //Convert JsonString Response to XML document
                    XDocument xml = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(
                        Encoding.ASCII.GetBytes(userProfile.Content), new XmlDictionaryReaderQuotas()));

                    //Gets identifier and convert to string.
                    string id = userObject["id"].ToString();
                    //Sets dateTime
                    string dateTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
                    //Writting xml document to the file in 
                    xml.Save($"{dataStoreFolder}/VKontakte_{id}_{dateTime}.xml", SaveOptions.None);
                    //Add data to database
                    Repository.Instance.AddApiResponse("Social", "VKontakte",
                        xml.ToString()).Wait();
                }
                catch (Exception e)
                {
                    WriteFile(@"VKontakte_error", $"Error message: \n{e.Message} \n Stack trace: {e.StackTrace}");
                }
            }).Start();

            return "OK";
        }


        /// <summary>
        /// see Facebook
        /// </summary>
        /// <param name="token"></param>
        /// <param name="service"></param>
        public string GoogleDrive(string token, string service)
        {
            //start and setup bNesis thin SDK
            ServiceManager manager = new ServiceManager();
            //connect to bNesis server
            int SDKInitializeResult = manager.InitializeThin(bNesisAPIEndPoint);
            //Check if have some problem with connection to bNesis server.
            if (SDKInitializeResult != ServiceManager.errorCodeNoError)
            {

                WriteFile(@"GoogleDrive_error", "can't initialize bNesis at: " + bNesisAPIEndPoint + "\n Reason:" + manager.GetLastError());
                return "BAD";
            }

            bool databasIsAvaible = Repository.Instance.IsAvaible();
            //Check if database is not avaible
            if (!databasIsAvaible)
            {
                WriteFile(@"GoogleDrive_error", "Can't access to DataBase.");
                return "BAD";
            }
            //Check if token or service is empty or null
            if (string.IsNullOrEmpty(token)
                || string.IsNullOrEmpty(service))
            {
                WriteFile(@"GoogleDrive_error", "Bad token or service name.");
                return "BAD";
            }

            //Create instance of service
            GoogleDrive googleDrive = manager.CreateInstanceGoogleDrive();
            string errorMessage = manager.GetLastError();
            //Check if have errorMessage
            if (!string.IsNullOrEmpty(errorMessage))
            {
                WriteFile(@"GoogleDrive_error", "Authorization problem:" + errorMessage);
                return "BAD";
            }
            //Attach to bNesis session the input token and checks if token is valid.
            try
            {
                if (!googleDrive.Auth(token))
                {
                    WriteFile(@"GoogleDrive_error", "The token is not valid.");
                    return "BAD";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            new Thread(() =>
            {
                try
                {
                    //Gets user profile 
                    Response userProfile = googleDrive.AboutRaw(true, 1, 1);
                    //Getting last error
                    ErrorInfo errorInfo = googleDrive.GetLastError();
                    //Stop authorization session with service and clears the value bNesis token.
                    googleDrive.LogoffService();

                    //Check if errorInfo code does not equal noError
                    if (errorInfo.Code != ServiceManager.errorCodeNoError)
                    {
                        WriteFile("GoogleDrive_error", "Can't receive profile, error code: " + errorInfo.Code +
                                                       "\nReason:" + errorInfo.Description);
                        return;
                    }

                    //Convert user profile to JObject
                    JObject userJObject = JsonConvert.DeserializeObject<JObject>(userProfile.Content);

                    //Convert JsonString Response to XML document
                    XDocument xml = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(
                        Encoding.ASCII.GetBytes(userProfile.Content), new XmlDictionaryReaderQuotas()));

                    //Gets user nickname and convert to string.
                    string nickname = userJObject["name"].ToString();
                    //Sets dateTime
                    string dateTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
                    //Writting xml document to the file in 
                    xml.Save($"{dataStoreFolder}/GoogleDrive_{nickname}_{dateTime}.xml", SaveOptions.None);
                    //Add data to database
                    Repository.Instance.AddApiResponse("Google", "GoogleDrive",
                        xml.ToString()).Wait();
                }
                catch (Exception e)
                {
                    WriteFile(@"GoogleDrive_error", $"Error message: \n{e.Message} \n Stack trace: {e.StackTrace}");
                }
            }).Start();
            return "OK";
        }

        /// <summary>
        /// see Facebook
        /// </summary>
        /// <param name="token"></param>
        /// <param name="service"></param>
        public string GoogleAnalytics(string token, string service)
        {
            //start and setup bNesis thin SDK
            ServiceManager manager = new ServiceManager();
            //connect to bNesis server
            int SDKInitializeResult = manager.InitializeThin(bNesisAPIEndPoint);
            //Check if have some problem with connection to bNesis server.
            if (SDKInitializeResult != ServiceManager.errorCodeNoError)
            {

                WriteFile(@"GoogleAnalytics_error", "can't initialize bNesis at: " + bNesisAPIEndPoint + "\n Reason:" + manager.GetLastError());
                return "BAD";
            }

            bool databasIsAvaible = Repository.Instance.IsAvaible();
            //Check if database is not avaible
            if (!databasIsAvaible)
            {
                WriteFile(@"GoogleAnalytics_error", "Can't access to DataBase.");
                return "BAD";
            }
            //Check if token or service is empty or null
            if (string.IsNullOrEmpty(token)
                || string.IsNullOrEmpty(service))
            {
                WriteFile(@"GoogleAnalytics_error", "Bad token or service name.");
                return "BAD";
            }

            //Create instance of service
            GoogleAnalytics googleAnalytics = manager.CreateInstanceGoogleAnalytics();
            string errorMessage = manager.GetLastError();
            //Check if have errorMessage
            if (!string.IsNullOrEmpty(errorMessage))
            {
                WriteFile(@"GoogleAnalytics_error", "Authorization problem:" + errorMessage);
                return "BAD";
            }
            //Attach to bNesis session the input token and checks if token is valid.
            try
            {
                if (!googleAnalytics.Auth(token))
                {
                    WriteFile(@"GoogleAnalytics_error", "The token is not valid.");
                    return "BAD";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            new Thread(() =>
            {
                try
                {
                    //Gets user profile 
                    Response userProfile = googleAnalytics.GetManagementAccounts();
                    //Getting last error
                    ErrorInfo errorInfo = googleAnalytics.GetLastError();
                    //Stop authorization session with service and clears the value bNesis token.
                    googleAnalytics.LogoffService();

                    //Check if errorInfo code does not equal noError
                    if (errorInfo.Code != ServiceManager.errorCodeNoError)
                    {
                        WriteFile("GoogleAnalytics_error", "Can't receive profile, error code: " + errorInfo.Code +
                                                       "\nReason:" + errorInfo.Description);
                        return;
                    }

                    //Convert user profile to JObject
                    JObject userJObject = JsonConvert.DeserializeObject<JObject>(userProfile.Content);

                    //Convert JsonString Response to XML document
                    XDocument xml = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(
                        Encoding.ASCII.GetBytes(userProfile.Content), new XmlDictionaryReaderQuotas()));

                    //Gets user nickname and convert to string.
                    string nickname = userJObject["name"].ToString();
                    //Sets dateTime
                    string dateTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
                    //Writting xml document to the file in 
                    xml.Save($"{dataStoreFolder}/GoogleAnalytics_{nickname}_{dateTime}.xml", SaveOptions.None);
                    //Add data to database
                    Repository.Instance.AddApiResponse("Analytics", "GoogleAnalytics",
                        xml.ToString()).Wait();
                }
                catch (Exception e)
                {
                    WriteFile(@"GoogleAnalytics_error", $"Error message: \n{e.Message} \n Stack trace: {e.StackTrace}");
                }
            }).Start();
            return "OK";
        }

        /// <summary>
        /// see Facebook
        /// </summary>
        /// <param name="token"></param>
        /// <param name="service"></param>
        public string GooglePlus(string token, string service)
        {
            //start and setup bNesis thin SDK
            ServiceManager manager = new ServiceManager();
        //    //connect to bNesis server
            int SDKInitializeResult = manager.InitializeThin(bNesisAPIEndPoint);
        //    //Check if have some problem with connection to bNesis server.
            if (SDKInitializeResult != ServiceManager.errorCodeNoError)
            {

                WriteFile(@"GooglePlus_error", "can't initialize bNesis at: " + bNesisAPIEndPoint + "\n Reason:" + manager.GetLastError());
                return "BAD";
            }

            bool databasIsAvaible = Repository.Instance.IsAvaible();
        //    //Check if database is not avaible
            if (!databasIsAvaible)
            {
                WriteFile(@"GooglePlus_error", "Can't access to DataBase.");
                return "BAD";
            }
        //    //Check if token or service is empty or null
            if (string.IsNullOrEmpty(token)
                || string.IsNullOrEmpty(service))
            {
                WriteFile(@"GooglePlus_error", "Bad token or service name.");
                return "BAD";
            }

            //Create instance of service
            GooglePlus googlePlus = manager.CreateInstanceGooglePlus();
            string errorMessage = manager.GetLastError();
            //Check if have errorMessage
            if (!string.IsNullOrEmpty(errorMessage))
            {
                WriteFile(@"GooglePlus_error", "Authorization problem:" + errorMessage);
                return "BAD";
            }
            //Attach to bNesis session the input token and checks if token is valid.
            try
            {
                if (!googlePlus.Auth(token))
                {
                    WriteFile(@"GooglePlus_error", "The token is not valid.");
                    return "BAD";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            new Thread(() =>
            {
                try
                {

                    //Gets user profile 
                    Response userProfile = googlePlus.GetAboutMeRaw();
                        //Getting last error
                        ErrorInfo errorInfo = googlePlus.GetLastError();
                        //Stop authorization session with service and clears the value bNesis token.
                        googlePlus.LogoffService();

                        //Check if errorInfo code does not equal noError
                        if (errorInfo.Code != ServiceManager.errorCodeNoError)
                    {
                        WriteFile("GooglePlus_error", "Can't receive profile, error code: " + errorInfo.Code +
                                                       "\nReason:" + errorInfo.Description);
                        return;
                    }

                        //Convert user profile to JObject
                        JObject userJObject = JsonConvert.DeserializeObject<JObject>(userProfile.Content);

                        //Convert JsonString Response to XML document
                        XDocument xml = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(
                        Encoding.ASCII.GetBytes(userProfile.Content), new XmlDictionaryReaderQuotas()));

                        //Gets user nickname and convert to string.
                        string nickname = userJObject["id"].ToString();
                        //Sets dateTime
                        string dateTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
                        //Writting xml document to the file in 
                        xml.Save($"{dataStoreFolder}/GooglePlus_{nickname}_{dateTime}.xml", SaveOptions.None);
                        //Add data to database
                        Repository.Instance.AddApiResponse("Analytics", "GooglePlus",
                        xml.ToString()).Wait();
                }
                catch (Exception e)
                {
                    WriteFile(@"GooglePlus_error", $"Error message: \n{e.Message} \n Stack trace: {e.StackTrace}");
                }
            }).Start();
            return "OK";
        }


        /// <summary>
        /// see Facebook
        /// </summary>
        /// <param name="token"></param>
        /// <param name="service"></param>
        public string Box(string token, string service)
        {
            //start and setup bNesis thin SDK
            ServiceManager manager = new ServiceManager();
            //connect to bNesis server
            int SDKInitializeResult = manager.InitializeThin(bNesisAPIEndPoint);
            //Check if have some problem with connection to bNesis server.
            if (SDKInitializeResult != ServiceManager.errorCodeNoError)
            {

                WriteFile(@"Box_error", "can't initialize bNesis at: " + bNesisAPIEndPoint + "\n Reason:" + manager.GetLastError());
                return "BAD";
            }

            bool databasIsAvaible = Repository.Instance.IsAvaible();
            //Check if database is not avaible
            if (!databasIsAvaible)
            {
                WriteFile(@"Box_error", "Can't access to DataBase.");
                return "BAD";
            }
            //Check if token or service is empty or null
            if (string.IsNullOrEmpty(token)
                || string.IsNullOrEmpty(service))
            {
                WriteFile(@"Box_error", "Bad token or service name.");
                return "BAD";
            }

            //Create instance of service
            Box box = manager.CreateInstanceBox();
            string errorMessage = manager.GetLastError();
            //Check if have errorMessage
            if (!string.IsNullOrEmpty(errorMessage))
            {
                WriteFile(@"Box_error", "Authorization problem:" + errorMessage);
                return "BAD";
            }
            //Attach to bNesis session the input token and checks if token is valid.
            try
            {
                if (!box.Auth(token))
                {
                    WriteFile(@"Box_error", "The token is not valid.");
                    return "BAD";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            new Thread(() =>
            {
                try
                {
                    //Gets user profile 
                    Response userProfile = box.GetCurrentUserRaw();
                    //Getting last error
                    ErrorInfo errorInfo = box.GetLastError();
                    //Stop authorization session with service and clears the value bNesis token.
                    box.LogoffService();

                    //Check if errorInfo code does not equal noError
                    if (errorInfo.Code != ServiceManager.errorCodeNoError)
                    {
                        WriteFile("Box_error", "Can't receive profile, error code: " + errorInfo.Code +
                                                       "\nReason:" + errorInfo.Description);
                        return;
                    }

                    //Convert user profile to JObject
                    JObject userJObject = JsonConvert.DeserializeObject<JObject>(userProfile.Content);

                    //Convert JsonString Response to XML document
                    XDocument xml = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(
                        Encoding.ASCII.GetBytes(userProfile.Content), new XmlDictionaryReaderQuotas()));

                    //Gets user nickname and convert to string.
                    string nickname = userJObject["name"].ToString();
                    //Sets dateTime
                    string dateTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
                    //Writting xml document to the file in 
                    xml.Save($"{dataStoreFolder}/Box_{nickname}_{dateTime}.xml", SaveOptions.None);
                    //Add data to database
                    Repository.Instance.AddApiResponse("FileStorages", "Box",
                        xml.ToString()).Wait();
                }
                catch (Exception e)
                {
                    WriteFile(@"Box_error", $"Error message: \n{e.Message} \n Stack trace: {e.StackTrace}");
                }
            }).Start();
            return "OK";
        }

        /// <summary>
        /// see Facebook
        /// </summary>
        /// <param name="token"></param>
        /// <param name="service"></param>
        public string LiqPay(string token, string service)
        {
            //start and setup bNesis thin SDK
            ServiceManager manager = new ServiceManager();
            //connect to bNesis server
            int SDKInitializeResult = manager.InitializeThin(bNesisAPIEndPoint);
            //Check if have some problem with connection to bNesis server.
            if (SDKInitializeResult != ServiceManager.errorCodeNoError)
            {

                WriteFile(@"LiqPay_error", "can't initialize bNesis at: " + bNesisAPIEndPoint + "\n Reason:" + manager.GetLastError());
                return "BAD";
            }

            bool databasIsAvaible = Repository.Instance.IsAvaible();
            //Check if database is not avaible
            if (!databasIsAvaible)
            {
                WriteFile(@"LiqPay_error", "Can't access to DataBase.");
                return "BAD";
            }
            //Check if token or service is empty or null
            if (string.IsNullOrEmpty(token)
                || string.IsNullOrEmpty(service))
            {
                WriteFile(@"LiqPay_error", "Bad token or service name.");
                return "BAD";
            }

            //Create instance of service
            LiqPay liqPay = manager.CreateInstanceLiqPay();
            string errorMessage = manager.GetLastError();
            //Check if have errorMessage
            if (!string.IsNullOrEmpty(errorMessage))
            {
                WriteFile(@"LiqPay_error", "Authorization problem:" + errorMessage);
                return "BAD";
            }
            //Attach to bNesis session the input token and checks if token is valid.
            try
            {
                if (!liqPay.Auth(token))
                {
                    WriteFile(@"LiqPay_error", "The token is not valid.");
                    return "BAD";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            new Thread(() =>
            {
                try
                {
                    string startTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
                    string endTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
                    
                    //Gets user profile 
                    Response userProfile = liqPay.GetPaymentHistoryRaw(startTime, endTime, "xml");
                    //Getting last error
                    ErrorInfo errorInfo = liqPay.GetLastError();
                    //Stop authorization session with service and clears the value bNesis token.
                    liqPay.LogoffService();

                    //Check if errorInfo code does not equal noError
                    if (errorInfo.Code != ServiceManager.errorCodeNoError)
                    {
                        WriteFile("LiqPay_error", "Can't receive profile, error code: " + errorInfo.Code +
                                                       "\nReason:" + errorInfo.Description);
                        return;
                    }

                    //Convert user profile to JObject
                    JObject userJObject = JsonConvert.DeserializeObject<JObject>(userProfile.Content);

                    //Convert JsonString Response to XML document
                    XDocument xml = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(
                        Encoding.ASCII.GetBytes(userProfile.Content), new XmlDictionaryReaderQuotas()));

                    //Gets user nickname and convert to string.
                    string nickname = userJObject["name"].ToString();
                    //Sets dateTime
                    string dateTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
                    //Writting xml document to the file in 
                    xml.Save($"{dataStoreFolder}/LiqPay_{nickname}_{dateTime}.xml", SaveOptions.None);
                    //Add data to database
                    Repository.Instance.AddApiResponse("Payment", "LiqPay",
                        xml.ToString()).Wait();
                }
                catch (Exception e)
                {
                    WriteFile(@"LiqPay_error", $"Error message: \n{e.Message} \n Stack trace: {e.StackTrace}");
                }
            }).Start();
            return "OK";
        }

        /// <summary>
        /// see Facebook
        /// </summary>
        /// <param name="token"></param>
        /// <param name="service"></param>
        public string Dropbox(string token, string service)
        {
            //start and setup bNesis thin SDK
            ServiceManager manager = new ServiceManager();
            //connect to bNesis server
            int SDKInitializeResult = manager.InitializeThin(bNesisAPIEndPoint);
            //Check if have some problem with connection to bNesis server.
            if (SDKInitializeResult != ServiceManager.errorCodeNoError)
            {

                WriteFile(@"Dropbox_error", "can't initialize bNesis at: " + bNesisAPIEndPoint + "\n Reason:" + manager.GetLastError());
                return "BAD";
            }

            bool databasIsAvaible = Repository.Instance.IsAvaible();
            //Check if database is not avaible
            if (!databasIsAvaible)
            {
                WriteFile(@"Dropbox_error", "Can't access to DataBase.");
                return "BAD";
            }
            //Check if token or service is empty or null
            if (string.IsNullOrEmpty(token)
                || string.IsNullOrEmpty(service))
            {
                WriteFile(@"Dropbox_error", "Bad token or service name.");
                return "BAD";
            }

            //Create instance of service
            Dropbox dropBox = manager.CreateInstanceDropbox();
            string errorMessage = manager.GetLastError();
            //Check if have errorMessage
            if (!string.IsNullOrEmpty(errorMessage))
            {
                WriteFile(@"Dropbox_error", "Authorization problem:" + errorMessage);
                return "BAD";
            }
            //Attach to bNesis session the input token and checks if token is valid.
            try
            {
                if (!dropBox.Auth(token))
                {
                    WriteFile(@"Dropbox_error", "The token is not valid.");
                    return "BAD";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            new Thread(() =>
            {
                try
                {
                    //Gets user profile 
                    Response userProfile = dropBox.get_current_accountRaw();
                    //Getting last error
                    ErrorInfo errorInfo = dropBox.GetLastError(); //WRONG ERROR CODE GET (NOERROR WRONG)
                    //Stop authorization session with service and clears the value bNesis token.
                    dropBox.LogoffService();

                    //Check if errorInfo code does not equal noError
                    
                    if (userProfile == null)
                    {
                        WriteFile("Dropbox_error", "Can't receive profile, error code: " + errorInfo.Code +
                                                       "\nReason:" + errorInfo.Description);
                        return;
                    }

                    //Convert user profile to JObject
                    JObject userJObject = JsonConvert.DeserializeObject<JObject>(userProfile.Content);

                    //Convert JsonString Response to XML document
                    XDocument xml = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(
                        Encoding.ASCII.GetBytes(userProfile.Content), new XmlDictionaryReaderQuotas()));

                    //Gets user nickname and convert to string.
                    string nickname = userJObject["email"].ToString();
                    //Sets dateTime
                    string dateTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
                    //Writting xml document to the file in 
                    xml.Save($"{dataStoreFolder}/Dropbox_{nickname}_{dateTime}.xml", SaveOptions.None);
                    //Add data to database
                    Repository.Instance.AddApiResponse("FileStorages", "Dropbox",
                        xml.ToString()).Wait();
                }
                catch (Exception e)
                {
                    WriteFile(@"Dropbox_error", $"Error message: \n{e.Message} \n Stack trace: {e.StackTrace}");
                }
            }).Start();
            return "OK";
        }

        /// <summary>
        /// see Facebook
        /// </summary>
        /// <param name="token"></param>
        /// <param name="service"></param>
        public string Stripe(string token, string service)
        {
            //start and setup bNesis thin SDK
            ServiceManager manager = new ServiceManager();
            //connect to bNesis server
            int SDKInitializeResult = manager.InitializeThin(bNesisAPIEndPoint);
            //Check if have some problem with connection to bNesis server.
            if (SDKInitializeResult != ServiceManager.errorCodeNoError)
            {

                WriteFile(@"Stripe_error", "can't initialize bNesis at: " + bNesisAPIEndPoint + "\n Reason:" + manager.GetLastError());
                return "BAD";
            }

            bool databasIsAvaible = Repository.Instance.IsAvaible();
            //Check if database is not avaible
            if (!databasIsAvaible)
            {
                WriteFile(@"Stripe_error", "Can't access to DataBase.");
                return "BAD";
            }
            //Check if token or service is empty or null
            if (string.IsNullOrEmpty(token)
                || string.IsNullOrEmpty(service))
            {
                WriteFile(@"Stripe_error", "Bad token or service name.");
                return "BAD";
            }

            //Create instance of service
            Stripe stripe = manager.CreateInstanceStripe();
            string errorMessage = manager.GetLastError();
            //Check if have errorMessage
            if (!string.IsNullOrEmpty(errorMessage))
            {
                WriteFile(@"Stripe_error", "Authorization problem:" + errorMessage);
                return "BAD";
            }
            //Attach to bNesis session the input token and checks if token is valid.
            try
            {
                if (!stripe.Auth(token))
                {
                    WriteFile(@"Stripe_error", "The token is not valid.");
                    return "BAD";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            new Thread(() =>
            {
                try
                {
                    //Gets user profile 
                    Response userProfile = stripe.ListBalanceHistoryRaw();
                    //Getting last error
                    ErrorInfo errorInfo = stripe.GetLastError();
                    //Stop authorization session with service and clears the value bNesis token.
                    stripe.LogoffService();

                    //Check if errorInfo code does not equal noError
                    if (errorInfo.Code != ServiceManager.errorCodeNoError)
                    {
                        WriteFile("Stripe_error", "Can't receive profile, error code: " + errorInfo.Code +
                                                       "\nReason:" + errorInfo.Description);
                        return;
                    }

                    //Convert user profile to JObject
                    JObject userJObject = JsonConvert.DeserializeObject<JObject>(userProfile.Content);

                    //Convert JsonString Response to XML document
                    XDocument xml = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(
                        Encoding.ASCII.GetBytes(userProfile.Content), new XmlDictionaryReaderQuotas()));

                    //Gets user nickname and convert to string.
                    string nickname = userJObject["name"].ToString();
                    //Sets dateTime
                    string dateTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
                    //Writting xml document to the file in 
                    xml.Save($"{dataStoreFolder}/Stripe_{nickname}_{dateTime}.xml", SaveOptions.None);
                    //Add data to database
                    Repository.Instance.AddApiResponse("Payment", "Stripe",
                        xml.ToString()).Wait();
                }
                catch (Exception e)
                {
                    WriteFile(@"Stripe_error", $"Error message: \n{e.Message} \n Stack trace: {e.StackTrace}");
                }
            }).Start();
            return "OK";
        }

        /// <summary>
        /// see Facebook
        /// </summary>
        /// <param name="token"></param>
        /// <param name="service"></param>
        public string PayPal(string token, string service)
        {
            //start and setup bNesis thin SDK
            ServiceManager manager = new ServiceManager();
            //connect to bNesis server
            int SDKInitializeResult = manager.InitializeThin(bNesisAPIEndPoint);
            //Check if have some problem with connection to bNesis server.
            if (SDKInitializeResult != ServiceManager.errorCodeNoError)
            {

                WriteFile(@"PayPal_error", "can't initialize bNesis at: " + bNesisAPIEndPoint + "\n Reason:" + manager.GetLastError());
                return "BAD";
            }

            bool databasIsAvaible = Repository.Instance.IsAvaible();
            //Check if database is not avaible
            if (!databasIsAvaible)
            {
                WriteFile(@"PayPal_error", "Can't access to DataBase.");
                return "BAD";
            }
            //Check if token or service is empty or null
            if (string.IsNullOrEmpty(token)
                || string.IsNullOrEmpty(service))
            {
                WriteFile(@"PayPal_error", "Bad token or service name.");
                return "BAD";
            }

            //Create instance of service
            PayPal payPal = manager.CreateInstancePayPal();
            string errorMessage = manager.GetLastError();
            //Check if have errorMessage
            if (!string.IsNullOrEmpty(errorMessage))
            {
                WriteFile(@"PayPal_error", "Authorization problem:" + errorMessage);
                return "BAD";
            }
            //Attach to bNesis session the input token and checks if token is valid.
            try
            {
                if (!payPal.Auth(token))
                {
                    WriteFile(@"PayPal_error", "The token is not valid.");
                    return "BAD";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            new Thread(() =>
            {
                try
                {
                    //Gets user profile 
                    
                    var userProfile = payPal.get_user_infoRaw();
                    //Getting last error
                    ErrorInfo errorInfo = payPal.GetLastError();
                    //Stop authorization session with service and clears the value bNesis token.
                    payPal.LogoffService();

                    //Check if errorInfo code does not equal noError
                    if (errorInfo.Code != ServiceManager.errorCodeNoError)
                    {
                        WriteFile("PayPal_error", "Can't receive profile, error code: " + errorInfo.Code +
                                                       "\nReason:" + errorInfo.Description);
                        return;
                    }

                    //Convert user profile to JObject
                    

                    //Convert JsonString Response to XML document
                    XDocument xml = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(
                        Encoding.ASCII.GetBytes(userProfile.Content), new XmlDictionaryReaderQuotas()));

                    //Gets user nickname and convert to string.
                    string nickname = token.Substring(1,20);
                    //Sets dateTime
                    string dateTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
                    //Writting xml document to the file in 
                    xml.Save($"{dataStoreFolder}/PayPal_{nickname}_{dateTime}.xml", SaveOptions.None);
                    //Add data to database
                    Repository.Instance.AddApiResponse("Payment", "PayPal",
                        xml.ToString()).Wait();
                }
                catch (Exception e)
                {
                    WriteFile(@"PayPal_error", $"Error message: \n{e.Message} \n Stack trace: {e.StackTrace}");
                }
            }).Start();
            return "OK";
        }

        /// <summary>
        /// see Facebook
        /// </summary>
        /// <param name="token"></param>
        /// <param name="service"></param>
        public string Shopify(string token, string service)
        {
            //start and setup bNesis thin SDK
            ServiceManager manager = new ServiceManager();
            //connect to bNesis server
            int SDKInitializeResult = manager.InitializeThin(bNesisAPIEndPoint);
            //Check if have some problem with connection to bNesis server.
            if (SDKInitializeResult != ServiceManager.errorCodeNoError)
            {

                WriteFile(@"Shopify_error", "can't initialize bNesis at: " + bNesisAPIEndPoint + "\n Reason:" + manager.GetLastError());
                return "BAD";
            }

            bool databasIsAvaible = Repository.Instance.IsAvaible();
            //Check if database is not avaible
            if (!databasIsAvaible)
            {
                WriteFile(@"Shopify_error", "Can't access to DataBase.");
                return "BAD";
            }
            //Check if token or service is empty or null
            if (string.IsNullOrEmpty(token)
                || string.IsNullOrEmpty(service))
            {
                WriteFile(@"Shopify_error", "Bad token or service name.");
                return "BAD";
            }

            //Create instance of service
            Shopify shopify = manager.CreateInstanceShopify();
            string errorMessage = manager.GetLastError();
            //Check if have errorMessage
            if (!string.IsNullOrEmpty(errorMessage))
            {
                WriteFile(@"Shopify_error", "Authorization problem:" + errorMessage);
                return "BAD";
            }
            //Attach to bNesis session the input token and checks if token is valid.
            try
            {
                if (!shopify.Auth(token))
                {
                    WriteFile(@"Shopify_error", "The token is not valid.");
                    return "BAD";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            new Thread(() =>
            {
                try
                {
                    //Gets user profile 
                    Response userProfile = shopify.GetCustomersRaw();
                    //Getting last error
                    ErrorInfo errorInfo = shopify.GetLastError();
                    //Stop authorization session with service and clears the value bNesis token.
                    shopify.LogoffService();

                    //Check if errorInfo code does not equal noError
                    if (errorInfo.Code != ServiceManager.errorCodeNoError)
                    {
                        WriteFile("Shopify_error", "Can't receive profile, error code: " + errorInfo.Code +
                                                       "\nReason:" + errorInfo.Description);
                        return;
                    }

                    //Convert user profile to JObject
                    JObject userJObject = JsonConvert.DeserializeObject<JObject>(userProfile.Content);

                    //Convert JsonString Response to XML document
                    XDocument xml = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(
                        Encoding.ASCII.GetBytes(userProfile.Content), new XmlDictionaryReaderQuotas()));

                    //Gets user nickname and convert to string.
                    string nickname = userJObject["name"].ToString();
                    //Sets dateTime
                    string dateTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
                    //Writting xml document to the file in 
                    xml.Save($"{dataStoreFolder}/Shopify_{nickname}_{dateTime}.xml", SaveOptions.None);
                    //Add data to database
                    Repository.Instance.AddApiResponse("Payment", "Shopify",
                        xml.ToString()).Wait();
                }
                catch (Exception e)
                {
                    WriteFile(@"Shopify_error", $"Error message: \n{e.Message} \n Stack trace: {e.StackTrace}");
                }
            }).Start();
            return "OK";
        }

        /// <summary>
        /// see Facebook
        /// </summary>
        /// <param name="token"></param>
        /// <param name="service"></param>
        public string BaiduBCS(string token, string service)
        {
            //start and setup bNesis thin SDK
            ServiceManager manager = new ServiceManager();
            //connect to bNesis server
            int SDKInitializeResult = manager.InitializeThin(bNesisAPIEndPoint);
            //Check if have some problem with connection to bNesis server.
            if (SDKInitializeResult != ServiceManager.errorCodeNoError)
            {

                WriteFile(@"BaiduBCS_error", "can't initialize bNesis at: " + bNesisAPIEndPoint + "\n Reason:" + manager.GetLastError());
                return "BAD";
            }

            bool databasIsAvaible = Repository.Instance.IsAvaible();
            //Check if database is not avaible
            if (!databasIsAvaible)
            {
                WriteFile(@"BaiduBCS_error", "Can't access to DataBase.");
                return "BAD";
            }
            //Check if token or service is empty or null
            if (string.IsNullOrEmpty(token)
                || string.IsNullOrEmpty(service))
            {
                WriteFile(@"BaiduBCS_error", "Bad token or service name.");
                return "BAD";
            }

            //Create instance of service
            BaiduBCS baiduBCS = manager.CreateInstanceBaiduBCS();
            string errorMessage = manager.GetLastError();
            //Check if have errorMessage
            if (!string.IsNullOrEmpty(errorMessage))
            {
                WriteFile(@"BaiduBCS_error", "Authorization problem:" + errorMessage);
                return "BAD";
            }
            //Attach to bNesis session the input token and checks if token is valid.
            try
            {
                if (!baiduBCS.Auth(token))
                {
                    WriteFile(@"BaiduBCS_error", "The token is not valid.");
                    return "BAD";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            new Thread(() =>
            {
                try
                {
                    //Gets user profile 
                    Response userProfile = baiduBCS.GetLoggedInUserRaw();
                    //Getting last error
                    ErrorInfo errorInfo = baiduBCS.GetLastError();
                    //Stop authorization session with service and clears the value bNesis token.
                    baiduBCS.LogoffService();

                    //Check if errorInfo code does not equal noError
                    if (errorInfo.Code != ServiceManager.errorCodeNoError)
                    {
                        WriteFile("BaiduBCS_error", "Can't receive profile, error code: " + errorInfo.Code +
                                                       "\nReason:" + errorInfo.Description);
                        return;
                    }

                    //Convert user profile to JObject
                    JObject userJObject = JsonConvert.DeserializeObject<JObject>(userProfile.Content);

                    //Convert JsonString Response to XML document
                    XDocument xml = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(
                        Encoding.ASCII.GetBytes(userProfile.Content), new XmlDictionaryReaderQuotas()));

                    //Gets user nickname and convert to string.
                    string nickname = userJObject["name"].ToString();
                    //Sets dateTime
                    string dateTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
                    //Writting xml document to the file in 
                    xml.Save($"{dataStoreFolder}/BaiduBCS_{nickname}_{dateTime}.xml", SaveOptions.None);
                    //Add data to database
                    Repository.Instance.AddApiResponse("FileStorages", "BaiduBCS",
                        xml.ToString()).Wait();
                }
                catch (Exception e)
                {
                    WriteFile(@"BaiduBCS_error", $"Error message: \n{e.Message} \n Stack trace: {e.StackTrace}");
                }
            }).Start();
            return "OK";
        }

        /// <summary>
        /// see Facebook
        /// </summary>
        /// <param name="token"></param>
        /// <param name="service"></param>
        public string PrestaShop(string token, string service)
        {
            //start and setup bNesis thin SDK
            ServiceManager manager = new ServiceManager();
            //connect to bNesis server
            int SDKInitializeResult = manager.InitializeThin(bNesisAPIEndPoint);
            //Check if have some problem with connection to bNesis server.
            if (SDKInitializeResult != ServiceManager.errorCodeNoError)
            {

                WriteFile(@"PrestaShop_error", "can't initialize bNesis at: " + bNesisAPIEndPoint + "\n Reason:" + manager.GetLastError());
                return "BAD";
            }

            bool databasIsAvaible = Repository.Instance.IsAvaible();
            //Check if database is not avaible
            if (!databasIsAvaible)
            {
                WriteFile(@"PrestaShop_error", "Can't access to DataBase.");
                return "BAD";
            }
            //Check if token or service is empty or null
            if (string.IsNullOrEmpty(token)
                || string.IsNullOrEmpty(service))
            {
                WriteFile(@"PrestaShop_error", "Bad token or service name.");
                return "BAD";
            }

            //Create instance of service
            PrestaShop prestaShop = manager.CreateInstancePrestaShop();
            string errorMessage = manager.GetLastError();
            //Check if have errorMessage
            if (!string.IsNullOrEmpty(errorMessage))
            {
                WriteFile(@"PrestaShop_error", "Authorization problem:" + errorMessage);
                return "BAD";
            }
            //Attach to bNesis session the input token and checks if token is valid.
            try
            {
                if (!prestaShop.Auth(token))
                {
                    WriteFile(@"PrestaShop_error", "The token is not valid.");
                    return "BAD";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            new Thread(() =>
            {
                try
                {
                    //Gets user profile 
                    Response userProfile = prestaShop.GetOrderHistoriesIdentifiersRaw();
                    //Getting last error
                    ErrorInfo errorInfo = prestaShop.GetLastError();
                    //Stop authorization session with service and clears the value bNesis token.
                    prestaShop.LogoffService();

                    //Check if errorInfo code does not equal noError
                    if (errorInfo.Code != ServiceManager.errorCodeNoError)
                    {
                        WriteFile("PrestaShop_error", "Can't receive profile, error code: " + errorInfo.Code +
                                                       "\nReason:" + errorInfo.Description);
                        return;
                    }

                    //Convert user profile to JObject
                    JObject userJObject = JsonConvert.DeserializeObject<JObject>(userProfile.Content);

                    //Convert JsonString Response to XML document
                    XDocument xml = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(
                        Encoding.ASCII.GetBytes(userProfile.Content), new XmlDictionaryReaderQuotas()));

                    //Gets user nickname and convert to string.
                    string nickname = token.Substring(1, 20);
                    //Sets dateTime
                    string dateTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
                    //Writting xml document to the file in 
                    xml.Save($"{dataStoreFolder}/PrestaShop_{nickname}_{dateTime}.xml", SaveOptions.None);
                    //Add data to database
                    Repository.Instance.AddApiResponse("eCommerce", "PrestaShop",
                        xml.ToString()).Wait();
                }
                catch (Exception e)
                {
                    WriteFile(@"PrestaShop_error", $"Error message: \n{e.Message} \n Stack trace: {e.StackTrace}");
                }
            }).Start();
            return "OK";
        }

        /// <summary>
        /// see Facebook
        /// </summary>
        /// <param name="token"></param>
        /// <param name="service"></param>
        public string SugarSync(string token, string service)
        {
            //start and setup bNesis thin SDK
            ServiceManager manager = new ServiceManager();
            //connect to bNesis server
            int SDKInitializeResult = manager.InitializeThin(bNesisAPIEndPoint);
            //Check if have some problem with connection to bNesis server.
            if (SDKInitializeResult != ServiceManager.errorCodeNoError)
            {

                WriteFile(@"SugarSync_error", "can't initialize bNesis at: " + bNesisAPIEndPoint + "\n Reason:" + manager.GetLastError());
                return "BAD";
            }

            bool databasIsAvaible = Repository.Instance.IsAvaible();
            //Check if database is not avaible
            if (!databasIsAvaible)
            {
                WriteFile(@"SugarSync_error", "Can't access to DataBase.");
                return "BAD";
            }
            //Check if token or service is empty or null
            if (string.IsNullOrEmpty(token)
                || string.IsNullOrEmpty(service))
            {
                WriteFile(@"SugarSync_error", "Bad token or service name.");
                return "BAD";
            }

            //Create instance of service
            SugarSync sugarSync = manager.CreateInstanceSugarSync();
            string errorMessage = manager.GetLastError();
            //Check if have errorMessage
            if (!string.IsNullOrEmpty(errorMessage))
            {
                WriteFile(@"SugarSync_error", "Authorization problem:" + errorMessage);
                return "BAD";
            }
            //Attach to bNesis session the input token and checks if token is valid.
            try
            {
                if (!sugarSync.Auth(token))
                {
                    WriteFile(@"SugarSync_error", "The token is not valid.");
                    return "BAD";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            new Thread(() =>
            {
                try
                {
                    //Gets user profile 
                    Response userProfile = sugarSync.GetUserRaw();
                    //Getting last error
                    ErrorInfo errorInfo = sugarSync.GetLastError();
                    //Stop authorization session with service and clears the value bNesis token.
                    sugarSync.LogoffService();

                    //Check if errorInfo code does not equal noError
                    if (errorInfo.Code != ServiceManager.errorCodeNoError)
                    {
                        WriteFile("SugarSync_error", "Can't receive profile, error code: " + errorInfo.Code +
                                                       "\nReason:" + errorInfo.Description);
                        return;
                    }

                    //Convert user profile to JObject
                    JObject userJObject = JsonConvert.DeserializeObject<JObject>(userProfile.Content);

                    //Convert JsonString Response to XML document
                    XDocument xml = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(
                        Encoding.ASCII.GetBytes(userProfile.Content), new XmlDictionaryReaderQuotas()));

                    //Gets user nickname and convert to string.
                    string nickname = userJObject["name"].ToString();
                    //Sets dateTime
                    string dateTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
                    //Writting xml document to the file in 
                    xml.Save($"{dataStoreFolder}/SugarSync_{nickname}_{dateTime}.xml", SaveOptions.None);
                    //Add data to database
                    Repository.Instance.AddApiResponse("FileStorages", "SugarSync",
                        xml.ToString()).Wait();
                }
                catch (Exception e)
                {
                    WriteFile(@"SugarSync_error", $"Error message: \n{e.Message} \n Stack trace: {e.StackTrace}");
                }
            }).Start();
            return "OK";
        }
    }
}