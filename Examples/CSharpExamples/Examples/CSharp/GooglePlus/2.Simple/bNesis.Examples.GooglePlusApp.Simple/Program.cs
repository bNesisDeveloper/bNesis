﻿using System;
using bNesis.Sdk;
using bNesis.Sdk.Common;
using bNesis.Sdk.Social.GooglePlus;

/// <summary>
/// bNesis SDK GooglePlus sample.
/// Please see ReadMe file for more information about using and registration
/// </summary>
namespace bNesis.Examples.GooglePlusApp.Simple
{
    /// <summary>
    /// This console example shows how to use bNesis SDK initialization, authentication and calls some method from GooglePlus:
    /// <para/>bNesis ServiceManager class
    /// <para/>bNesis ServiceManager methods: InitializeRich and InitializeThin
    /// <para/>bNesis ServiceManager CreateInstanceGooglePlus method
    /// <para/>bNesis GooglePlus GetAboutMe method
    /// <para/>
    /// <para/>Also this example demonstrates methods of getting bNesis SDK status information, error handling and service control. 
    ///
    /// Before start
    /// GooglePlus setup.
    /// You must activate Google+ API in the https://console.developers.google.com/
    /// Then create credentials "OAuth Client ID" and 'API Key' in the https://console.developers.google.com/apis/credentials
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
        /// Google clientSecret. It is obtained after registration of your app in the Google service
        /// Please don't forget to create your OAuth credentials at the Google developers console https://console.developers.google.com/apis/credentials
        /// Put the client_secret here
        /// </summary>
        private static string clientSecret = string.Empty;

        /// <summary>
        /// Google clientId. It is obtained after registration of your app in the Google service
        /// Please don't forget to create your credentials OAuth at the Google developers console https://console.developers.google.com/apis/credentials
        /// Put a client_id here
        /// </summary>
        private static string clientId = string.Empty;

        /// <summary>
        /// Google ApiKey. It is obtained after registration of your app in the Google service
        /// Please don't forget to create your API key key at the Google developers console https://console.developers.google.com/apis/credentials
        /// Put the API key here
        /// </summary>
        private static string additionalData = string.Empty;

        /// <summary>
        /// Your application requests a delimited list of member permissions on behalf of the user.
        /// Scope: https://www.googleapis.com/auth/plus.login
        /// </summary>
        private static string[] scopes = new string[] { "https://www.googleapis.com/auth/plus.login" };

        /// <summary>
        /// If you use a Thin Client mode, you need an access to a bNesis API Server. Addresses of the demo bNesis API servers:
        /// https://server2.bnesis.com
        /// https://bnesisserver1.azurewebsites.net
        /// https://bnesisserver2.azurewebsites.net
        /// https://bnesisserver3.azurewebsites.net
        /// 
        /// Please don't forget to setup it in https://console.developers.google.com/apis/credentials
        /// 
        /// In the Thin client mode add two redirectURIs to you created web app credentials OAuth
        /// The first redirectURI relates what bNesis API server you use:
        /// https://server2.bnesis.com/api/authprovider/signin
        /// https://bnesisserver1.azurewebsites.net/api/authprovider/signin        
        /// https://bnesisserver2.azurewebsites.net/api/authprovider/signin
        /// https://bnesisserver3.azurewebsites.net/api/authprovider/signin
        ///The second redirectURI is a default host and port where the bNesis Thin client will be redirected to the specified address after the authentication 
        /// operation is performed. For example  http://localhost:809/ 
        ///
        /// Rich client:
        /// http://localhost:809/  
        /// (To know a  default bNesis Rich client redirect host and port, see redirectUrl property)
        /// (if you change the redirectUrl property at this example app, change the RedirectURIs at the Google Console credentials web app)
        /// </summary>

        /// <summary>
        /// If you use a Thin Client mode, you need an access to a bNesis API Server. Addresses of the available demo bNesis API Servers see above
        /// </summary>
        private static string bNesisAPIEndPoint = "http://localhost";

        /// <summary>
        /// The client will be redirected to the specified address after the authentication operation is performed.
        /// Please don't forget to add Redirect URIs on the created OAuth credential in the Google developers console https://console.developers.google.com/apis/credentials
        /// </summary>
        private static string redirectUrl = "http://localhost:809/";

        /// <summary>
        /// Entry point for Console application.
        /// </summary>
        /// <param name="args">Input arguments when application starts. (Command line options)</param>
        static void Main(string[] args)
        {
            Console.WriteLine("bNesis SDK - GooglePlus simple example.\n");

            //bNesisSDK Initialization 
            ServiceManager manager = new ServiceManager();

#if (ExampleMode)
            /// Use this method only for testing and demonstration applications
            /// Using of this method does not protect your data
            bNesisDeveloperId = manager.GetKey("exampleDeveloperId", bNesisDeveloperId);
            clientId = manager.GetKey("exampleGoogleClientId", clientId);
            clientSecret = manager.GetKey("exampleGoogleClientSecret", clientSecret);
            
#endif

            //Check bNesisDeveloperID
            if (string.IsNullOrEmpty(bNesisDeveloperId))
            {
                Console.WriteLine("For using this example, you need a bNesis Developer Id. You can get it from https://api.bnesis.com site - free of charge.\n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Check GooglePlus authentication keys
            if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret))
            {
                Console.WriteLine("For using this example you need Google authentication keys, please setup your Google Developer account and create OAuth credentials in https://console.developers.google.com/apis/credentials \n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Select a Rich client mode or a Thin client mode 
            Console.Write("Please select a Thin client mode or a Rich client mode.\nPress 'R' for the Rich client mode or any other key for the Thin client mode: ");
            //Waiting for a pressed key. If the key is not 'R', you will use a Thin client as a default mode.
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
                    Console.WriteLine("GooglePlus service Authorization, please wait...");
                    // this method authorizes GooglePlus service, returns instance.
                    GooglePlus googlePlus = manager.CreateInstanceGooglePlus(bNesisDeveloperId, clientId, clientSecret, redirectUrl, scopes, string.Empty);
                    //If authorization has failed, the bNesisToken is empty/null.
                    if (string.IsNullOrEmpty(googlePlus.bNesisToken))
                    {
                        //if bNesisToken is empty. use GetLastError method to get error description
                        if (!string.IsNullOrEmpty(manager.GetLastError())) Console.WriteLine("Authorization problem: " + manager.GetLastError());
                        else Console.WriteLine("Authorization problem. Please check parameters.\n");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                    }
                    //Authorization at GooglePlus is successful
                    //Now you can use GooglePlus APIs
                    Console.WriteLine("Authorization is successful! GooglePlus instance is created.\n");

                    Console.WriteLine("Getting member profile information from GooglePlus...");
                    //Get member profile from GooglePlus V1 API 
                    GooglePlusProfile profile = googlePlus.GetAboutMe();
                    //Getting last error
                    ErrorInfo errorInfo = googlePlus.GetLastError();
                    //Check if errorInfo code does not equal noError
                    if (errorInfo.Code != ServiceManager.errorCodeNoError)
                    {
                        Console.WriteLine("Can't get member profile, error code: " + errorInfo.Code +
                                          "\nReason:" + errorInfo.Description);
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                    }

                    Console.WriteLine("Success! Received information about user profile.");
                    Console.WriteLine("Some information about member:" +
                                      "\n ID:" + profile.id +
                                      "\n FirstName:" + profile.name.givenName +
                                      "\n LastName:" + profile.name.familyName);
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
