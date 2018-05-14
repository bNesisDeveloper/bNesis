using System;
using System.IO;
using bNesis.Sdk;
using bNesis.Sdk.Common;
using bNesis.Sdk.FileStorages.GoogleDrive;

/// <summary>
/// bNesis SDK GoogleDrive sample.
/// Please see ReadMe file for more information about using and registration
/// </summary>
namespace bNesis.Examples.GoogleDriveApp.DownloadUpload
{
    /// <summary>
    /// This console example shows how to use bNesis SDK initialization and authentication:
    /// <para/>bNesis ServiceManager class
    /// <para/>bNesis ServiceManager methods: InitializeRich and InitializeThin
    /// <para/>bNesis ServiceManager CreateInstanceGoogle method
    /// <para/>bNesis GoogleDrive UploadFile method
    /// <para/>bNesis GoogleDrive DownloadFile method
    /// <para/>
    /// <para/>Also this example demonstrates methods of getting bNesis SDK status information, error handling and service control. 
    ///
    /// Before start
    /// GoogleDrive setup.
    /// You must activate GoogleDrive API, Google+ API in the https://console.developers.google.com/
    /// (Google+ APIs are required at an authorization for all Google services)
    /// Then create credentials "OAuth Client ID" in the https://console.developers.google.com/apis/credentials
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
        /// Please don't forget to create your credentials OAuth at the Google developers console https://console.developers.google.com/apis/credentials
        /// Put the client_secret here
        /// </summary>
        private static string clientSecret = string.Empty;

        /// <summary>
        /// GoogleDrive clientId. It is obtained after registration of your app in the Google service
        /// Please don't forget to create your credentials OAuth at the Google developers console https://console.developers.google.com/apis/credentials
        /// Put the client_id here
        /// </summary>
        private static string clientId = string.Empty;

        /// <summary>
        /// Your application requests a delimited list of member permissions on behalf of the user.
        /// Scope: https://www.googleapis.com/auth/drive
        /// </summary>
        private static string[] scopes = new string[] { "https://www.googleapis.com/auth/drive" };

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
        private static string bNesisAPIEndPoint = "https://server2.bnesis.com";

        /// <summary>
        /// The client will be redirected to the specified address after the authentication operation is performed.
        /// Please don't forget to add Redirect URIs on the created credential OAuth in the Google developers console https://console.developers.google.com/apis/credentials
        /// </summary>
        private static string redirectUrl = "http://localhost:809/";

        /// <summary>
        /// Entry point for a Console application.
        /// </summary>
        /// <param name="args">Input arguments when application starts. (Command line options)</param>
        static void Main(string[] args)
        {
            Console.WriteLine("bNesis SDK - GoogleDrive DownloadUpload example\n");

            //Initialize bNesisSDK
            ServiceManager manager = new ServiceManager();

#if (ExampleMode)
/// Use this method only for testing and demonstration applications
/// Using of this method does not protect your data
            bNesisDeveloperId = manager.GetKey("exampleDeveloperId", bNesisDeveloperId);
            clientId = manager.GetKey("exampleGoogleClientId", clientId);
            clientSecret = manager.GetKey("exampleGoogleClientSecret", clientSecret);
#endif

            //Check a bNesisDeveloperID
            if (string.IsNullOrEmpty(bNesisDeveloperId))
            {
                Console.WriteLine(
                    "For using this example, you need an bNesis Developer Id. You can get it from https://api.bnesis.com site - free of charge\n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Check a Google credential OAuth keys
            if (string.IsNullOrEmpty(clientSecret) || string.IsNullOrEmpty(clientId))
            {
                Console.WriteLine(
                    "For using this example you need Google authentication keys, please setup your Google Developer account and create OAuth credentials in https://console.developers.google.com/apis/credentials \n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Select a Rich client mode or a Thin client mode 
            Console.Write(
                "Please select a Thin client mode or a Rich client mode.\nPress 'R' for the Rich client mode or any other key for the Thin client mode: ");
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
                Console.WriteLine("The bNesis SDK initialization problem, code: " + SDKInitializeResult +
                                  ", \nerror message:" + manager.GetErrorDescription(SDKInitializeResult));
            }
            else
            {
                //Succesful Initialization 
                Console.WriteLine("The bNesis SDK initialization status: Success\n");

                try
                {
                    Console.WriteLine("Authorization at the GoogleDrive service, please wait...");
                    GoogleDrive googleDrive =
                        manager.CreateInstanceGoogleDrive(bNesisDeveloperId, redirectUrl, clientId, clientSecret, scopes);


                    //If the authorization is failed, the bNesisToken will be empty/null.
                    if (string.IsNullOrEmpty(googleDrive.bNesisToken))
                    {
                        //if the bNesisToken is empty, use the GetLastError method to get an error description
                        if (!string.IsNullOrEmpty(manager.GetLastError()))
                            Console.WriteLine("Authorization problem: " + manager.GetLastError());
                        else Console.WriteLine("An Authorization problem, please check parameters.\n");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                    }

                    //An authorization at the GoogleDrive service is successful
                    //Now you can use GoogleDrive APIs
                    Console.WriteLine("An authorization success! The GoogleDrive instance is created.\n");


                    string fileName = string.Empty;
                    while (true)
                    {
                        Console.Write("Enter the path to the file for uploading to the GoogleDrive root folder (example - C:\\SomeFolder\\somefile.txt).\nFile name: ");
                        fileName = Console.ReadLine();
                        if (File.Exists(fileName)) break;
                        Console.WriteLine("\nThe file '" + fileName + "' does not exist, please try again or press Ctrl+C to exit.\n");
                    }

                    //for a clearance we use separate Stream objects for a demonstration of upload and download processes
                    System.IO.Stream uploadStream = File.OpenRead(@fileName);

                    //cut a path from a fileName, upload the file to the Dropbox root folder
                    string destinationFileName = Path.GetFileName(fileName);

                    //Upload File
                    string uploadResult = googleDrive.UploadFile(uploadStream, destinationFileName);
                    //check a GoogleDrive service error reporting 
                    ErrorInfo errorInfo = googleDrive.GetLastError();
                    //if an uploading problem is, report about it and exit
                    if ((!string.IsNullOrEmpty(uploadResult)) || (errorInfo.Code != ServiceManager.errorCodeNoError))
                    {
                        Console.WriteLine("Upload file problem: " + uploadResult + " " + errorInfo.Description);
                    }
                    else //begin to download the uploaded file back to the local drive
                    {
                        Console.WriteLine("File is uploaded - OK.");
                        Console.WriteLine("Now we download the file from GoogleDrive and save it as a new file: " + fileName + "_googleDrive");

                        //download the file from GoogleDrive                        
                        Stream downloadStream = googleDrive.DownloadFile(destinationFileName);
                        errorInfo = googleDrive.GetLastError();
                        //check a GoogleDrive service download file error
                        if ((downloadStream == null) || (errorInfo.Code != ServiceManager.errorCodeNoError))
                        {
                            Console.WriteLine("Download file problem: " + errorInfo.Description);
                        }
                        else //store a downloaded file from a stream to a local drive 
                        {
                            fileName += "_googleDrive";
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
                catch (Exception ex)
                {
                    //If you have some exception you can see it in a Console.
                    Console.WriteLine("Error message: " + ex.Message);
                }
            }

            //Wating for a pressed key...
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
