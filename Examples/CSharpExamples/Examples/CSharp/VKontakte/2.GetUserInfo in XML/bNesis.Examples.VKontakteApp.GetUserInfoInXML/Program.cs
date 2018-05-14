using System;
using System.IO;
using System.Text;
using System.Xml.Linq;
using bNesis.Sdk;
using bNesis.Sdk.Common;
using bNesis.Sdk.Social.VKontakte;
using System.Runtime.Serialization.Json;
using System.Xml;

/// <summary>
/// bNesis SDK VKontakte sample.
/// Please see ReadMe file for more information about using and registration
/// </summary>

namespace bNesis.Examples.VKontakteApp.GetUserInfoInXML
{
    /// <summary>
    /// This console example shows how to use bNesis SDK initialization and authentication and to receive 
    /// data of an authorized user. 
    /// All data will be wroten to XML file in the folder \"container\" in the application folder.
    /// <para/>bNesis ServiceManager class
    /// <para/>bNesis ServiceManager methods: InitializeRich and InitializeThin
    /// <para/>bNesis ServiceManager CreateInstanceVKontakte method
    /// <para/>
    /// <para/>Also this example demonstrates methods of getting bNesis SDK status information, error handling and service control. 
    /// </summary>
    internal class Program
    {
        /// <summary>
        ///  To use the bNesis SDK in your applications, you must have a bNesis Developer ID - the key, that signs your copy of the bNesis SDK. 
        ///  To study bNesis SDK, tests and demonstrations, you can get the key from https://api.bnesis.com site, free of charge.
        ///  Please, put your bNesis Developer ID here
        /// </summary>
        private static string bNesisDeveloperId = string.Empty;

        /// <summary>
        /// VKontakte Application ID. You can receive it in the settings of the VKontakte application from https://vk.com/dev site.
        /// </summary>
        private static string VKontakteClientId = string.Empty;

        /// <summary>
        /// VKontakte Secure key. You can receive it in the settings of the VKontakte application from https://vk.com/dev site.
        /// </summary>
        private static string VKontakteClientSecret = string.Empty;

        /// <summary>
        /// Your application requests a delimited list of member permissions on behalf of the user.
        /// </summary>
        private static string[] Scope = new string[] { "email", "friends", "video", "groups" };

        /// <summary>
        /// If you use a Thin Client mode, you need an access to a bNesis API Server. Addresses of the demo bNesis API servers:
        /// https://server2.bnesis.com
        /// https://bnesisserver1.azurewebsites.net
        /// https://bnesisserver2.azurewebsites.net
        /// https://bnesisserver3.azurewebsites.net
        /// 
        /// Please don't forget to setup your VKontakte application Redirect URIs at the settings of VKontakte App https://vk.com/dev
        /// 
        /// In the Thin client mode add two redirectURIs to tab "Authentication" at Application Settings. The first redirectURI relates what bNesis API server you use:
        /// https://server2.bnesis.com/api/authprovider/signin
        /// https://bnesisserver1.azurewebsites.net/api/authprovider/signin        
        /// https://bnesisserver2.azurewebsites.net/api/authprovider/signin
        /// https://bnesisserver3.azurewebsites.net/api/authprovider/signin
        ///The second redirectURI is a default host and port where bNesis Thin client will be redirected to the specified address after authentication 
        /// operation is performed. For example  http://localhost:809/ 
        ///
        /// Rich client:
        /// http://localhost:809/  
        /// (To know default bNesis Rich client redirect host and port, see redirectUrl property)
        /// (if you change the redirectUrl property at this example app, change RedirectURIs at the Settings of VKontakte App https://vk.com/dev
        /// </summary>

        /// <summary>
        /// If you use a Thin Client mode, you need an access to a bNesis API Server. Address of the available demo bNesis API Servers see above
        /// </summary>
        //private static string bNesisAPIEndPoint = "https://server2.bnesis.com";
        private static string bNesisAPIEndPoint = "http://localhost";

        /// <summary>
        /// A client will be redirected to the specified address after performing of the authentication operation.
        /// </summary>
        private static string redirectUrl = "http://localhost:809/";

        /// <summary>
        /// Entry point for a Console application.
        /// </summary>
        /// <param name="args">Input arguments when application starts. (Command line options)</param>
        static void Main(string[] args)
        {
            Console.WriteLine("bNesis SDK - VKontakte authentication example.\n");

            //bNesisSDK Initialization 
            ServiceManager manager = new ServiceManager();

#if (ExampleMode)
            /// Use this method only for testing and demonstration applications
            /// Using of this method does not protect your data
            bNesisDeveloperId = manager.GetKey("exampleDeveloperId", bNesisDeveloperId);
            VKontakteClientId = manager.GetKey("exampleVKontakteClientId", VKontakteClientId);
            VKontakteClientSecret = manager.GetKey("exampleVKontakteClientSecret", VKontakteClientSecret);
#endif

            //Check bNesisDeveloperID
            if (string.IsNullOrEmpty(bNesisDeveloperId))
            {
                Console.WriteLine("For using this example, you need a bNesis Developer Id. You can get it from https://api.bnesis.com site - free of charge.\n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Check VKontakte authentication keys
            if (string.IsNullOrEmpty(VKontakteClientId) || string.IsNullOrEmpty(VKontakteClientSecret))
            {
                Console.WriteLine("For using this example you need VKontakte authentication keys. Please get authentication keys in the VKontakte application settings on the site https://vk.com/dev \n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Select a Rich client mode or a Thin client mode 
            Console.Write("Please select a Thin client mode or a Rich client mode.\nPress 'R' for the Rich client mode or any other key for the Thin client mode: ");
            //Waiting for a pressed key. If key is not 'R', you will use the Thin client mode as a default mode.
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
                //Successful Initialization 
                Console.WriteLine("bNesis SDK initialization status: Success.\n");

                try
                {
                    Console.WriteLine("VKontakte service Authorization, please wait...");
                    // this method authorizes a VKontakte service, returns an instance.
                    VKontakte vkontakte = manager.CreateInstanceVKontakte(bNesisDeveloperId, VKontakteClientId, VKontakteClientSecret, redirectUrl);
                    //If authorization has failed, the bNesisToken is empty/null.
                    if (string.IsNullOrEmpty(vkontakte.bNesisToken))
                    {
                        //if bNesisToken is empty. use GetLastError method to get error description
                        if (!string.IsNullOrEmpty(manager.GetLastError())) Console.WriteLine("Authorization problem: " + manager.GetLastError());
                        else Console.WriteLine("Authorization problem. Please check parameters.\n");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                    }

                    //Authorization at VKontakte is successful
                    //Now you can use VKontakte  APIs
                    Console.WriteLine("Authorization is successful! VKontakte instance is created.\n");

                    //Get info about current user  
                    Response userInfo = vkontakte.GetUserRaw();


                    //Getting a last error
                    ErrorInfo errorInfo = vkontakte.GetLastError();
                    ////Check if errorInfo code does not equal noError
                    if (errorInfo.Code != ServiceManager.errorCodeNoError)
                    {
                        //Show error message
                        Console.WriteLine("getting an user info is Failed, error code:" + errorInfo.Code +
                                          ",\nReason:" + errorInfo.Description);
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                    }

                    Console.WriteLine("Success! Information is received.");


                    Console.WriteLine("Data will be saved to an XML file...");

                    //Convert JsonString Response to XML document
                    XDocument xml = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(
                        Encoding.ASCII.GetBytes(userInfo.Content), new XmlDictionaryReaderQuotas()));

                    //Writing an xml document to the file
                    Directory.CreateDirectory("container");
                    xml.Save("container/data.xml", SaveOptions.None);

                    Console.WriteLine("User's Info is saved to a folder \"container\" in the application folder.");

                }
                catch (Exception ex)
                {
                    //If you have some exception you can see a Console.
                    Console.WriteLine("Creating of instance \"VKontakte\" has failed, reason: " + ex.Message);
                }
            }

            //Waiting for a pressed key...
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
