using System;
using System.IO;
using bNesis.Sdk;
using bNesis.Sdk.Common;

/// <summary>
/// bNesis SDK Dropbox sample.
/// Please see ReadMe file for more information about using and registration
/// </summary>
namespace bNesis.Examples.DropboxApp.DownloadUpload
{
    /// <summary>
    /// This console example shows how to use the  bNesis SDK initialization and authentication:
    /// <para/>bNesis ServiceManager class
    /// <para/>bNesis ServiceManager methods: InitializeRich and InitializeThin
    /// <para/>bNesis ServiceManager CreateInstanceDropbox method
    /// <para/>bNesis Dropbox UploadFile method
    /// <para/>bNesis Dropbox DownloadFile method
    /// <para/>
    /// <para/>Also this example demonstrates methods of getting bNesis SDK status information, error handling and service control. 
    ///
    /// Before start
    /// Dropbox setup. Your application has to be registrated at the Dropbox developers console https://www.dropbox.com/developers/
    /// Dropbox client_secret and client_secret will be obtained after registration.
    /// Add a RedirectURI on a "Setting" tab of your application page at the Dropbox developers console https://www.dropbox.com/developers/
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
        /// The Dropbox appKey. It is obtained after the registration your app in the Dropbox service
        /// Please don't forget to register you app at the Dropbox developers console https://www.dropbox.com/developers/
        /// Put the appKey here
        /// </summary>
        private static string appKey = string.Empty;

        /// <summary>
        /// The Dropbox appSecret. It is obtained after the registration your app in the Dropbox service
        /// Please don't forget to register you app at the Dropbox developers console https://www.dropbox.com/developers/
        /// Put the appSecret here
        /// </summary>
        private static string appSecret = string.Empty;


        /// <summary>
        /// If you use a Thin Client mode, you need an access to a bNesis API Server. Addresses of the demo bNesis API servers:
        /// https://server2.bnesis.com
        /// https://bnesisserver1.azurewebsites.net
        /// https://bnesisserver2.azurewebsites.net
        /// https://bnesisserver3.azurewebsites.net
        /// 
        /// Please don't forget to setup your Dropbox application Redirect URIs at the Dropbox developers console https://www.dropbox.com/developers/
        /// 
        /// In the Thin client mode add two redirectURIs to the tab "Setting" at the Dropbox developers console. The first redirectURI relates what the bNesis API server you use:
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
        /// (if you change the redirectUrl property at this example app, change the RedirectURIs at the Dropbox developers console
        /// </summary>

        // <summary>
        /// If you use the Thin Client mode, you need an access to the bNesis API Server. Address of the available demo bNesis API Servers see above
        /// </summary>
        private static string bNesisAPIEndPoint = "https://server2.bnesis.com";

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
            Console.WriteLine("bNesis SDK - the Dropbox download and upload file example\n");

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
            if (selectMode.Key == ConsoleKey.R) //if user has pressed 'R' key for a Rich client mode
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

            //Check if initialization result does not equal zero(noError)
            if (SDKInitializeResult != ServiceManager.errorCodeNoError)
            {
                //Show error message
                Console.WriteLine("bNesis SDK initialization problem, code: " + SDKInitializeResult + ", \nerror message:" + manager.GetErrorDescription(SDKInitializeResult));
            }
            else
            {
                //Initialization Succes 
                Console.WriteLine("bNesis SDK initialization status: Success\n");

                try
                {
                    Console.WriteLine("Authorization at the Dropbox service, please wait...");

                    //Create an instance of the dropbox service
                    Sdk.FileStorages.Dropbox.Dropbox dropbox = manager.CreateInstanceDropbox(bNesisDeveloperId, appKey, appSecret, redirectUrl);

                    //If authorization is failed, the access_token will be empty/null.
                    if (string.IsNullOrEmpty(dropbox.bNesisToken))
                    {
                        //if a bNesisToken is empty, use the GetLastError method to get an error description
                        if (!string.IsNullOrEmpty(manager.GetLastError())) Console.WriteLine("Authorization problem: " + manager.GetLastError());
                        else Console.WriteLine("Authorization problem, please check parameters.\n");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                    }

                    //Authorization at the Dropbox service is successful
                    //Now you can use Dropbox API
                    Console.WriteLine("The authorization success! The Dropbox instance is created.\n");

                    string fileName = string.Empty;
                    while (true)
                    {
                        Console.Write("Enter the path to the file for uploading to the Dropbox root folder (example - C:\\SomeFolder\\somefile.txt).\nFile name: ");
                        fileName = Console.ReadLine();
                        if (File.Exists(fileName)) break;
                        Console.WriteLine("\nThe file '" + fileName + "' is not exist, please try again or press Ctrl+C to exit.\n");
                    }

                    //for a clearance we use separate Strem objects for a demonstration of upload and download processes
                    System.IO.Stream uploadStream = File.OpenRead(@fileName);

                    //cut a path from a fileName, uploading the file to the Dropbox root folder
                    string destinationFileName = Path.GetFileName(fileName);

                    //Upload File
                    string uploadResult = dropbox.UploadFile(uploadStream, destinationFileName);
                    //check a Dropbox service error reporting 
                    ErrorInfo errorInfo = dropbox.GetLastError();
                    //if an uploading problem is, report about it and exit
                    if ((!string.IsNullOrEmpty(uploadResult)) || (errorInfo.Code != ServiceManager.errorCodeNoError))
                    {
                        Console.WriteLine("Upload file problem: " + uploadResult + " " + errorInfo.Description);
                    }
                    else //begin downloading of the uploaded file back to local drive
                    {
                        Console.WriteLine("File is uploaded - OK.");
                        Console.WriteLine("Now the file is downloading from Dropbox and saving as the new file: " + fileName + "_dropbox");

                        //download the file from Dropbox                        
                        Stream downloadStream = dropbox.DownloadFile(destinationFileName);
                        errorInfo = dropbox.GetLastError();
                        //check a Dropbox service download file error
                        if ((downloadStream == null) || (errorInfo.Code != ServiceManager.errorCodeNoError))
                        {
                            Console.WriteLine("Download file problem: " + errorInfo.Description);
                        }
                        else //store a downloaded file from a stream to a local drive 
                        {
                            fileName += "_dropbox";
                            if (File.Exists(fileName))
                            {
                                //Remove an exist file.
                                File.Delete(fileName);
                            }

                            //Creating a new file on a destination path
                            using (var file = File.Create(fileName))
                            {
                                //Copy bytes to the file.
                                downloadStream.CopyTo(file);
                            }

                        }
                        Console.WriteLine("File '{0}' is downloaded - OK", fileName);
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