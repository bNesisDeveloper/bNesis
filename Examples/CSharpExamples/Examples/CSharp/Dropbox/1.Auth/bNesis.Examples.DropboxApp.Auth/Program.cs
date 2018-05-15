using System;
using bNesis.Sdk;

namespace bNesis.Examples.DropboxApp.Auth
{
    /// <summary>
    /// This console example shows how to use bNesis SDK initialization and authentication:
    /// <para/>bNesis ServiceManager class
    /// <para/>bNesis ServiceManager methods: InitializeRich and InitializeThin
    /// <para/>bNesis ServiceManager CreateInstanceDropbox method
    /// <para/>
    /// <para/>Also this example demonstrates methods of getting bNesis SDK status information, error handling and service control. 
    ///
    /// Before start
    /// Dropbox setup. Your application has to be registrated at the Dropbox developers console https://www.dropbox.com/developers/
    /// Dropbox API_key and client_secret will be obtained after registration.
    /// Add RedirectURI on "Setting" tab of your application page at the Dropbox developers console https://www.dropbox.com/developers/
    /// </summary>


    internal class Program
    {
        /// <summary>
        ///  To use the bNesis SDK in your applications, you must have the bNesis Developer ID - the key that signs your copy of the bNesis SDK. 
        ///  To study bNesis SDK, tests and demonstrations, you can get the key from https://api.bnesis.com site, free of charge.
        ///  Please, put your bNesis Developer ID here
        /// </summary>
        private static string bNesisDeveloperId = string.Empty;

        /// <summary>
        /// Dropbox appKey. It is obtained after registration of your app in the Dropbox service
        /// Please don't forget to register you app at the Dropbox developers console https://www.dropbox.com/developers/
        /// Put the appKey here
        /// </summary>
        private static string appKey = string.Empty;

        /// <summary>
        /// Dropbox appSecret. It is obtained after registration of your app in the Dropbox service
        /// Please don't forget to register you app at the Dropbox developers console https://www.dropbox.com/developers/
        /// Put a appSecret  here
        /// </summary>
        private static string appSecret = string.Empty;


        /// <summary>
        /// If you use the Thin Client mode, you need an access to the bNesis API Server. Addresses of the demo bNesis API servers:
        /// https://server2.bnesis.com
        /// https://bnesisserver1.azurewebsites.net
        /// https://bnesisserver2.azurewebsites.net
        /// https://bnesisserver3.azurewebsites.net
        /// 
        /// Please don't forget to setup your Dropbox application Redirect URIs at the Dropbox developers console https://www.dropbox.com/developers/
        /// 
        /// In the Thin client mode add two redirectURIs to tab "Setting" at the Dropbox developers console. The first redirectURI relates what bNesis API server you use:
        /// https://server2.bnesis.com/api/authprovider/signin
        /// https://bnesisserver1.azurewebsites.net/api/authprovider/signin        
        /// https://bnesisserver2.azurewebsites.net/api/authprovider/signin
        /// https://bnesisserver3.azurewebsites.net/api/authprovider/signin
        ///The second redirectURI is a default host and port where the bNesis Thin client will be redirected to the specified address after the authentication 
        /// operation is performed. For example  http://localhost:809/ 
        ///
        /// Rich client:
        /// http://localhost:809/  
        /// (To know a default bNesis Rich client redirects host and port, see redirectUrl property)
        /// (if you change the redirectUrl property at this example app, change the RedirectURIs at the Dropbox developers console
        /// </summary>

        // <summary>
        /// If you use a Thin Client mode, you need an access to the bNesis API Server. Address of the available demo bNesis API Servers see above
        /// </summary>
        private static string bNesisAPIEndPoint = "https://server2.bnesis.com/";

        /// <summary>
        /// The client will be redirected to the specified address after the authentication operation is performed.
        /// Please don't forget to add Redirect URIs on the "Settings" tab of your application in the Dropbox developers console https://www.dropbox.com/developers/
        /// </summary>
        private static string redirectUrl = "http://localhost:809/";

        /// <summary>
        /// Entry point for a Console application.
        /// </summary>
        /// <param name="args">Input arguments when application starts. (Command line options)</param>
        static void Main(string[] args)
        {
            Console.WriteLine("bNesis SDK - Dropbox authentication example\n");

            //Initialize bNesisSDK
            ServiceManager manager = new ServiceManager();

#if (ExampleMode)
            /// Use this method only for testing and demonstration applications
            /// Using of this method does not protect your data
            bNesisDeveloperId = manager.GetKey("exampleDeveloperId", bNesisDeveloperId);
            appKey = manager.GetKey("exampleDropboxAppKey", appKey);
            appSecret = manager.GetKey("exampleDropboxAppSecret", appSecret);
#endif

            //Check a bNesisDeveloperID
            if (string.IsNullOrEmpty(bNesisDeveloperId))
            {
                Console.WriteLine("For using this example, you need an bNesis Developer Id. You can get it from https://api.bnesis.com site - free of charge\n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Check Dropbox authentication keys
            if (string.IsNullOrEmpty(appKey) || string.IsNullOrEmpty(appSecret))
            {
                Console.WriteLine("For using this example you need Dropbox authentication keys, please setup your Dropbox Developer account and create an application\n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Select a Rich client mode or a Thin client mode 
            Console.Write("Please select a Thin client mode or a Rich client mode.\nPress 'R' for the Rich client mode or any other key for the Thin client mode: ");
            //Waiting for a pressed key. If key is not 'R', using the default Thin client mode.
            ConsoleKeyInfo selectMode = Console.ReadKey();
            //Escape line
            Console.WriteLine();

            //Initialize result code
            int SDKInitializeResult;

            //Initialize client mode
            if (selectMode.Key == ConsoleKey.R) //if user has pressed 'R' key for Rich client mode
            {
                Console.WriteLine("Initialization of the Rich Client mode.");
                //successful initialization returns zero code(noError)
                SDKInitializeResult = manager.InitializeRich(string.Empty);
            }
            else //default Thin client mode
            {
                Console.WriteLine("Initialization of the Thin client mode.");
                //successful initialization returns zero code(noError)
                SDKInitializeResult = manager.InitializeThin(bNesisAPIEndPoint);
            }

            //Check if an initialization result does not equal zero(noError)
            if (SDKInitializeResult != ServiceManager.errorCodeNoError)
            {
                //Show error message
                Console.WriteLine("The bNesis SDK initialization problem, code: " + SDKInitializeResult + ", \nerror message:" + manager.GetErrorDescription(SDKInitializeResult));
            }
            else
            {
                //Succesful Initialization 
                Console.WriteLine("The bNesis SDK initialization status: Success\n");

                try
                {                    
                    Console.WriteLine("Authorization at the Dropbox service, please wait...");
                    Sdk.FileStorages.Dropbox.Dropbox dropbox = manager.CreateInstanceDropbox(bNesisDeveloperId, appKey, appSecret, redirectUrl);
                    

                    //If the authorization is failed, the bNesisToken will be empty/null.
                    if (string.IsNullOrEmpty(dropbox.bNesisToken))
                    {
                        //if the bNesisToken is empty, use the GetLastError method to get an error description
                        if (!string.IsNullOrEmpty(manager.GetLastError())) Console.WriteLine("Authorization problem: " + manager.GetLastError());
                        else Console.WriteLine("An Authorization problem, please check parameters.\n");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                    }

                    //An authorization at the Dropbox service is successful
                    //Now you can use a Dropbox API
                    Console.WriteLine("An authorization success! The Dropbox instance is created.\n");
                    
                }
                catch (Exception ex)
                {
                    //If you have some exception you can see it in a Console.
                    Console.WriteLine("Creating of the instance 'Dropbox' is failed, reason: " + ex.Message);
                }
            }

            //Wating for a pressed key...
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}