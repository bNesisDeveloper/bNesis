﻿using System;
using bNesis.Sdk;
using bNesis.Sdk.Common;
using bNesis.Sdk.FileStorages.Common;

/// <summary>
/// bNesis SDK Dropbox sample.
/// Please see ReadMe file for more information about using and registration
/// </summary>
namespace bNesis.Examples.DropboxApp.FilesList
{
    /// <summary>
    /// This console example shows how to use bNesis SDK initialization and authentication:
    /// <para/>bNesis ServiceManager class
    /// <para/>bNesis ServiceManager methods: InitializeRich and InitializeThin
    /// <para/>bNesis ServiceManager CreateInstanceDropbox method
    /// <para/>bNesis Dropbox GetFiles method
    /// <para/>
    /// <para/>Also this example demonstrates methods of getting bNesis SDK status information, error handling and service control. 
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
        /// Dropbox client_secret.
        /// </summary>        
        private static string appSecret = string.Empty;

        /// <summary>
        /// Dropbox client_id
        /// </summary>
        private static string appKey = string.Empty;

        /// <summary>
        /// If you use a Thin Client mode, you need an access to bNesis API Server. Addresses of the demo bNesis API servers:
        /// https://server2.bnesis.com
        /// https://bnesisserver1.azurewebsites.net
        /// https://bnesisserver2.azurewebsites.net
        /// https://bnesisserver3.azurewebsites.net
        /// 
        /// Please don't forget to setup your Dropbox application Redirect URIs at Dropbox developers console https://www.dropbox.com/developers/
        /// 
        /// bNesis Thin client (relates what bNesis API server you use):
        /// https://server2.bnesis.com/api/authprovider/signin
        /// https://bnesisserver1.azurewebsites.net/api/authprovider/signin        
        /// https://bnesisserver2.azurewebsites.net/api/authprovider/signin
        /// https://bnesisserver3.azurewebsites.net/api/authprovider/signin
        /// 
        /// Rich client:
        /// http://localhost:809/ 
        /// (To know default bNesis Rich client redirect host and port, see redirectUrl property)
        /// (if you change the redirectUrl property at this example app, change RedirectURIs at a Dropbox developers console
        /// </summary>
        private static string bNesisAPIEndPoint = "https://server2.bnesis.com";

        /// <summary>
        /// The client will be redirected to the specified address after the authentication operation is performed.
        /// </summary>
        private static string redirectUrl = "http://localhost:809/";

        /// <summary>
        /// Entry point for a Console application.
        /// </summary>
        /// <param name="args">Input arguments when application starts. (Command line options)</param>
        static void Main(string[] args)
        {
            Console.WriteLine("bNesis SDK - Dropbox download and upload file example\n");

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
                Console.WriteLine("For using this example, you need the bNesis Developer Id. You can get it from https://api.bnesis.com site - free of charge\n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Check Dropbox authentication keys
            if (string.IsNullOrEmpty(appKey) || string.IsNullOrEmpty(appSecret))
            {
                Console.WriteLine("For using this example you need the Dropbox authentication keys. Please setup your Dropbox Developer account and create application\n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Select a Rich client mode or a Thin client mode 
            Console.Write("Please select a Thin client mode or a Rich client mode.\nPress 'R' for the Rich client mode or any other key for the Thin client mode: ");
            //Waiting for an pressed key. If key is not 'R', using a default Thin client mode.
            ConsoleKeyInfo selectMode = Console.ReadKey();
            //Escape line
            Console.WriteLine();

            //Initialize result code
            int SDKInitializeResult;

            //Initialize client mode
            if (selectMode.Key == ConsoleKey.R) //if user has pressed 'R' key for Rich client mode
            {
                Console.WriteLine("Initialization of the Rich client mode.");
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
                Console.WriteLine("bNesis SDK initialization problem, code: " + SDKInitializeResult + ", \nerror message:" + manager.GetErrorDescription(SDKInitializeResult));
            }
            else
            {
                //Succes of Initialization 
                Console.WriteLine("bNesis SDK initialization status: Success\n");

                try
                {
                    Console.WriteLine("Authorization at the Dropbox service, please wait...");

                    //Create an instance of the dropbox service
                    Sdk.FileStorages.Dropbox.Dropbox dropbox = manager.CreateInstanceDropbox(bNesisDeveloperId, appKey, appSecret, redirectUrl);

                    //If an authorization is failed, the access_token will be empty/null.
                    if (string.IsNullOrEmpty(dropbox.bNesisToken))
                    {
                        //if a bNesisToken is empty, use the GetLastError method to get an error description
                        if (!string.IsNullOrEmpty(manager.GetLastError())) Console.WriteLine("Authorization problem: " + manager.GetLastError());
                        else Console.WriteLine("Authorization problem, please check parameters.\n");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                    }

                    //Authorization at Dropbox is successful
                    //Now you can use Dropbox API
                    Console.WriteLine("Authorization success! Dropbox instance is created.\n");

                    // Add an array for a files list 
                    FileStorageItem[] filesArray = null;

                    //Reciving the files list from a root folder at Dropbox
                    //Use Dropbox API - GetFiles with a parameter "\\" which means path to the root folder
                    filesArray = dropbox.GetFiles("\\");

                    //Getting last error
                    ErrorInfo errorInfo = dropbox.GetLastError();

                    //Check if an errorInfo code does not equal noError
                    if (errorInfo.Code != ServiceManager.errorCodeNoError)
                    {
                        //Show error message
                        Console.WriteLine("Receiving file list from the root folder is Failed, error code:" + errorInfo.Code +
                                          ",\nReason:" + errorInfo.Description);
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                    }


                    //Check exiting of files in the root folder. If a case of files exists, output the files list 
                    if (filesArray.Length == 0)
                    {
                        //Show error message
                        Console.WriteLine("There is no files in the root folder");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("A list of files in the root folder:");
                        for (int i=0; i<filesArray.Length; i++)
                        {
                            Console.WriteLine("{0}. {1}", i+1, filesArray[i].Name);
                        }

                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                    }



                }
                catch (Exception e)
                {
                    Console.WriteLine(string.Format("Problem: {0}", e.Message));
                }
            }
            //Wating for a pressed key...
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}