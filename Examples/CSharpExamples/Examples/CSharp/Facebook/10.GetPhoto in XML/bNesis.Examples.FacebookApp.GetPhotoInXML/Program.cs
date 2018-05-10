using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using bNesis.Sdk;
using bNesis.Sdk.Common;
using bNesis.Sdk.Social.Facebook;
using System.Xml.Linq;
using System.Xml;
using Newtonsoft.Json;

/// <summary>
/// bNesis SDK Facebook sample.
/// Please see ReadMe file for more information about using and registration
/// </summary> 
namespace bNesis.Examples.FacebookApp.GetPhotoInXML
{
    /// <summary>
    /// This console example shows how to use bNesis SDK initialization, authentication and how to get photos including likes and comments. Use scope "user_photos"
    /// All data will be wroten to XML file to folder \container\ in the application folder. Photos save to the folder \container\photos
    /// <para/>bNesis ServiceManager class
    /// <para/>bNesis ServiceManager methods: InitializeRich and InitializeThin
    /// <para/>bNesis ServiceManager CreateInstanceCreateInstanceFacebook method
    /// <para/>
    /// <para/>Also this example demonstrates methods of getting bNesis SDK status information, error handling and service control. 
    /// </summary>
    internal class Program
    {
        /// <summary>
        ///  To use the bNesis SDK in your applications, you must have the bNesis Developer ID - the key, that signs your copy of the bNesis SDK. 
        ///  To study bNesis SDK, tests and demonstrations, you can get the key from https://api.bnesis.com site, free of charge.
        ///  Please, put your bNesis Developer ID here
        /// </summary>
        private static string bNesisDeveloperId = string.Empty;

        /// <summary>
        /// Facebook service Client ID. You can receive it in the settings of the Facebook application from https://developers.facebook.com/apps/ site.
        /// </summary>
        private static string FacebookClientId = string.Empty;

        /// <summary>
        /// Facebook service Client Secret. You can receive it in the settings of the Facebook application from https://developers.facebook.com/apps/ site.
        /// </summary>
        private static string FacebookClientSecret = string.Empty;

        /// <summary>
        /// Your application requests a delimited list of member permissions on behalf of the user.
        /// </summary>
        private static string[] Scope = new string[] { "user_photos" };

        /// <summary>
        /// If you use a Thin Client mode, you need an access to a bNesis API Server. Addresses of the demo bNesis API servers:
        /// https://server2.bnesis.com
        /// https://bnesisserver1.azurewebsites.net
        /// https://bnesisserver2.azurewebsites.net
        /// https://bnesisserver3.azurewebsites.net
        /// 
        /// Please don't forget to setup your Facebook application Redirect URIs at the settings of Facebook App https://developers.facebook.com/
        /// 
        /// In a Thin client mode add two redirectURIs to tab "Authentication" at Application Settings. The first redirectURI relates what a bNesis API server you use:
        /// https://server2.bnesis.com/api/authprovider/signin
        /// https://bnesisserver1.azurewebsites.net/api/authprovider/signin        
        /// https://bnesisserver2.azurewebsites.net/api/authprovider/signin
        /// https://bnesisserver3.azurewebsites.net/api/authprovider/signin
        ///The second redirectURI is a default host and port where bNesis Thin client will be redirected to the specified address after the authentication 
        /// operation is performed. For example  http://localhost:809/ 
        ///
        /// Rich client:
        /// http://localhost:809/  
        /// (To know a default bNesis Rich client redirect host and port, see redirectUrl property)
        /// (if you change the redirectUrl property at this example app, change the RedirectURIs at the Settings of Facebook App https://developers.facebook.com/
        /// </summary>

        /// <summary>
        /// If you use a Thin Client mode, you need an access to a bNesis API Server. Addresses of the available demo bNesis API Servers see above
        /// </summary>
        private static string bNesisAPIEndPoint = "https://server2.bnesis.com";
        //private static string bNesisAPIEndPoint = "http://localhost/bNesisApiServer/";
        //private static string bNesisAPIEndPoint = "https://socialpilot.bnesis.com";


        /// <summary>
        /// The client will be redirected to the specified address after performing of the authentication operation.
        /// </summary>
        private static string redirectUrl = "http://localhost:809/";

        /// <summary>
        /// The identifier of the user. It can be "me"
        /// </summary>
        private static string id = "me";

        /// <summary>
        /// Entry point for a Console application.
        /// </summary>
        /// <param name="args">Input arguments when application starts. (Command line options)</param>
        static void Main(string[] args)
        {
            Console.WriteLine("bNesis SDK - Facebook authentication example.\n");

            //bNesisSDK Initialization 
            ServiceManager manager = new ServiceManager();

#if (ExampleMode)
            /// Use this method only for testing and demonstration applications
            /// Using of this method does not protect your data
            bNesisDeveloperId = manager.GetKey("exampleDeveloperId", bNesisDeveloperId);
            FacebookClientId = manager.GetKey("exampleFacebookClientId", FacebookClientId);
            FacebookClientSecret = manager.GetKey("exampleFacebookClientSecret", FacebookClientSecret);
#endif
            #region Validation Creeds
            //Check bNesisDeveloperID
            if (string.IsNullOrEmpty(bNesisDeveloperId))
            {
                Console.WriteLine("For using this example, you need bNesis Developer Id. You can get it from https://api.bnesis.com site - free of charge.\n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Check Facebook authentication keys
            if (string.IsNullOrEmpty(FacebookClientId) || string.IsNullOrEmpty(FacebookClientSecret))
            {
                Console.WriteLine("For using this example you need Facebook authentication keys. Please contact with the Facebook administration to get these keys.\n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }
            #endregion

            //Select a Rich client mode or a Thin client mode 
            Console.Write("Please select a Thin client mode or a Rich client mode.\nPress 'R' to choose the Rich client mode or any other key to choose the Thin client mode: ");
            //Waiting for a pressed key. If key is not 'R', you will use a Thin client as a default mode.
            ConsoleKeyInfo selectMode = Console.ReadKey();
            //Escape line
            Console.WriteLine();

            //Initialize result code
            int SDKInitializeResult;

            //Initialize client mode
            if (selectMode.Key == ConsoleKey.R) //if user presses 'R' key for the Rich client mode
            {
                Console.WriteLine("Rich client mode initialization...");
                //successful initialization returns zero code(noError)
                SDKInitializeResult = manager.InitializeRich(string.Empty);
            }
            else //default Thin client mode
            {
                Console.WriteLine("Thin client mode initialization...");
                //successful initialization returns zero code(noError)
                SDKInitializeResult = manager.InitializeThin(bNesisAPIEndPoint);
            }

            //Check, that initialization result does not equal zero(noError)
            if (SDKInitializeResult != ServiceManager.errorCodeNoError)
            {
                //Show error message
                Console.WriteLine("bNesis SDK initialization problem, code: " + SDKInitializeResult + ", \nerror message:" + manager.GetErrorDescription(SDKInitializeResult));
            }
            else
            {
                //Successful Initializing 
                Console.WriteLine("bNesis SDK initialization status: Success.\n");

                try
                {
                    Console.WriteLine("Facebook service Authorization, please wait...");
                    // this method authorizes Facebook service, returns instance.
                    Facebook facebook = manager.CreateInstanceFacebook(
                        null, bNesisDeveloperId, redirectUrl, FacebookClientId, FacebookClientSecret, Scope, null, null, false, null);
                    //If authorization has failed, the bNesisToken is empty/null.
                    if (string.IsNullOrEmpty(facebook.bNesisToken))
                    {
                        //if bNesisToken is empty. use GetLastError method to get error description
                        if (!string.IsNullOrEmpty(manager.GetLastError())) Console.WriteLine("Authorization problem: " + manager.GetLastError());
                        else Console.WriteLine("Authorization problem. Please check parameters.\n");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                    }

                    //Authorization at Facebook is successful
                    //Now you can use Facebook APIs
                    Console.WriteLine("Authorization is successful! Facebook instance is created.\n");

                    //Getting photos
                    Response photos = facebook.GetUserPhotosRaw("me");

                    //Getting last error
                    ErrorInfo errorInfo = facebook.GetLastError();
                    //Check if errorInfo code does not equal noError
                    if (errorInfo.Code != ServiceManager.errorCodeNoError)
                    {
                        //Show error message
                        Console.WriteLine("Getting the data of photos is Failed, error code:" + errorInfo.Code +
                                          ",\nReason:" + errorInfo.Description);
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                    }

                    Console.WriteLine("Success! The data of photos are received\n");

                    //Convert JsonString Response to XML document
                    XDocument xml = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(
                        Encoding.ASCII.GetBytes(photos.Content), new XmlDictionaryReaderQuotas()));

                    //Writing xml document to the file 
                    Directory.CreateDirectory("container");
                    xml.Save("container/data.xml", SaveOptions.None);

                    Console.WriteLine("Data about photos are saved to the folder \"container\" in the application folder.\n");

                    
                    Console.WriteLine("Downloading photos to the folder \"container\\photos\" in the application folder...");

                    //Convert Response from the server to the class FacebookUserPhotos
                    FacebookUserPhotos photosFacebook = JsonConvert.DeserializeObject<FacebookUserPhotos>(photos.Content);
                    
                    //Downloading photos
                    int count = 0;
                    foreach (FacebookPhoto item in photosFacebook.data)
                    {
                        count++;
                        string link = item.images[0].source;

                        Directory.CreateDirectory("container/photos");
                        WebClient webClient = new WebClient();
                        webClient.DownloadFile(link, $"container/photos/{count}.jpg");

                    }

                    Console.WriteLine($"Downloading is completed.\n\nAll are saved {count} photos.\n");

                }
                catch (Exception ex)
                {
                    //If you have some exception you can see a Console.
                    Console.WriteLine("Error message: " + ex.Message);
                }
            }

            //Wating for a pressed key...
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}