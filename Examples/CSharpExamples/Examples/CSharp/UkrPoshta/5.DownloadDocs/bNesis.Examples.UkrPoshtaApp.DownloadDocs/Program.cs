using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;
using bNesis.Sdk;
using bNesis.Sdk.Delivery.UkrPoshta;


/// <summary>
/// bNesis SDK UkrPoshta sample.
/// Please see ReadMe file for more information about using and registration
/// </summary>
namespace bNesis.Examples.UkrPoshtaApp.DownloadDocs
{
    /// <summary>
    /// This console example shows how to use bNesis SDK initialization, authentication and downloads any documents from UkrPoshta:
    /// <para/>bNesis ServiceManager class
    /// <para/>bNesis ServiceManager methods: InitializeRich and InitializeThin
    /// <para/>bNesis ServiceManager CreateInstanceUkrPoshta method
    /// <para/>bNesis UkrPoshta GetShipmentSticker method
    /// <para/>bNesis UkrPoshta GetShipmentLabel method
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
        /// UkrPoshta service authentication bearer.
        /// </summary>
        private static string UkrPoshtaBearer = string.Empty;

        /// <summary>
        /// UkrPoshta service counterparty token.
        /// </summary>
        private static string UkrPoshtaCounterPartyToken = string.Empty;

        /// <summary>
        /// UkrPoshta shipment identifier.
        /// </summary>
        private static string ShipmentUUID = string.Empty;

        /// <summary>
        /// If you use Thin Client mode, you need an access to bNesis API Server. Address of the demo bNesis API server:
        /// https://server2.bnesis.com
        /// https://bnesisserver1.azurewebsites.net
        /// https://bnesisserver2.azurewebsites.net
        /// https://bnesisserver3.azurewebsites.net
        ///The second redirectURI is default host and port where bNesis Thin client will be redirected to the specified address after the authentication 
        /// operation is performed. For example  http://localhost:809/ 
        ///
        /// Rich client:
        /// http://localhost:809/  
        /// (as a default bNesis Rich client redirects host and port, see redirectUrl property)
        /// </summary>

        /// <summary>
        /// If you use Thin Client mode, you need access to bNesis API Server. Address of the available demo bNesis API Servers see above
        /// </summary>
        private static string bNesisAPIEndPoint = "https://server2.bnesis.com";

        /// <summary>
        /// The client will be redirected to the specified address after the authentication operation is performed.
        /// </summary>
        private static string redirectUrl = "http://localhost:809/";

        /// <summary>
        /// Entry point for Console application.
        /// </summary>
        /// <param name="args">Input arguments when application starts. (Command line options)</param>
        static void Main(string[] args)
        {
            Console.WriteLine("bNesis SDK - UkrPoshta downloaded documents example\n");

            //Initialize bNesisSDK
            ServiceManager manager = new ServiceManager();

#if (ExampleMode)
            /// Use this method only for testing and demonstration applications
            /// The use of this method does not protect your data
            bNesisDeveloperId = manager.GetKey("exampleDeveloperId", bNesisDeveloperId);
            UkrPoshtaBearer = manager.GetKey("exampleUkrPoshtaBearer", UkrPoshtaBearer);
            UkrPoshtaCounterPartyToken = manager.GetKey("exampleUkrPoshtaCounterPartyToken", UkrPoshtaCounterPartyToken);
            ShipmentUUID = manager.GetKey("exampleShipmentUUID", ShipmentUUID);
#endif


            //Getting an executionPath
            string executionPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path = Path.Combine(executionPath, "Temp");
            //Creating a new directory, if the directory does not exist.
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //Check bNesisDeveloperID
            if (string.IsNullOrEmpty(bNesisDeveloperId))
            {
                Console.WriteLine(
                    "For using this example, you need the bNesis Developer Id. You can get it from https://api.bnesis.com site - free of charge\n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Check UkrPoshta authentication keys
            if (string.IsNullOrEmpty(UkrPoshtaBearer) || string.IsNullOrEmpty(UkrPoshtaCounterPartyToken))
            {
                Console.WriteLine(
                    "For using this example you need the UkrPoshta authentication keys, please contact with the UkrPoshta administration to get these keys\n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Check a UkrPoshta shipment uuid(identifier)
            if (string.IsNullOrEmpty(ShipmentUUID))
            {
                Console.WriteLine(
                    "For using this example you need the UkrPoshta shipment uuid (identifier). You can get it in a response after adding a shipment in UkrPoshta service. \n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Select Rich client mode or Thin client mode 
            Console.Write(
                "Please select The Thin client mode or the Rich client mode.\nPress 'R' for the Rich client mode or some other key for the Thin client mode: ");
            //Waiting for a pressed key. If the key is not 'R', using the default Thin client mode.
            ConsoleKeyInfo selectMode = Console.ReadKey();
            //Escape line
            Console.WriteLine();

            //Initialize result code
            int SDKInitializeResult;

            //Initialize client mode
            if (selectMode.Key == ConsoleKey.R) //if user has pressed 'R' key for the Rich client mode
            {
                Console.WriteLine("The Rich client mode initialization...");
                //successful initialization returns zero code(noError)
                SDKInitializeResult = manager.InitializeRich(string.Empty);
            }
            else //default Thin client mode
            {
                Console.WriteLine("The Thin Client mode Initialization...");
                //successful initialization returns zero code(noError)
                SDKInitializeResult = manager.InitializeThin(bNesisAPIEndPoint);
            }

            //Check if the initialization result does not equal zero(noError)
            if (SDKInitializeResult != ServiceManager.errorCodeNoError)
            {
                //Show error message
                Console.WriteLine("bNesis SDK initialization problem, code: " + SDKInitializeResult + ", \nerror message:" + manager.GetErrorDescription(SDKInitializeResult));
            }
            else
            {
                //Successful Initialization 
                Console.WriteLine("bNesis SDK initialization status: Success\n");

                try
                {
                    Console.WriteLine("Authorization at the UkrPoshta service, please wait...");
                    // this authorization method at the UkrPoshta service returns instance.
                    UkrPoshta ukrPoshta = manager.CreateInstanceUkrPoshta(bNesisDeveloperId, redirectUrl,
                        UkrPoshtaBearer, UkrPoshtaCounterPartyToken, true);
                    //If the authorization is failed, the bNesisToken will be empty/null.
                    if (string.IsNullOrEmpty(ukrPoshta.bNesisToken))
                    {
                        //if the bNesisToken is empty, use the GetLastError method to get the error description
                        if (!string.IsNullOrEmpty(manager.GetLastError()))
                            Console.WriteLine("Authorization problem: " + manager.GetLastError());
                        else Console.WriteLine("Authorization problem, please check the parameters.\n");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                    }

                    //Authorization at the UkrPoshta service is successful
                    //Now you can use The UkrPoshta API
                    Console.WriteLine("The Authorizational success! An UkrPoshta instance is created.\n");

                    //Getting documents by a shipment identifier
                    Console.WriteLine("Select what a document do you want to download: \n1. Sticker \n2. Label");
                    Console.Write("Press 1 or 2 on the keyboard to select one of a type or some other key to cancel: ");
                    ConsoleKey downloadDocType = Console.ReadKey().Key;
                    //Escape line
                    Console.WriteLine();


                    //Creating local variables.
                    Stream stream = null;
                    string filePath = string.Empty; //Name file with full path.

                    //Check if you have pressed 1 - Sticker
                    if (downloadDocType == ConsoleKey.D1 || downloadDocType == ConsoleKey.NumPad1)
                    {
                        //Show message about your downloading.
                        Console.WriteLine("Document file Sticker downloading ...");
                        try
                        {
                            //Set name and extension for file and combine with path.
                            filePath = Path.Combine(path, "Shipment=" + ShipmentUUID + "=Sticker.pdf");
                            //Download 'Sticker' document.
                            stream = ukrPoshta.GetShipmentSticker(ShipmentUUID);
                        }
                        catch { }

                    }
                    else  //Check if you have pressed 2 Label
                    if (downloadDocType == ConsoleKey.D2 || downloadDocType == ConsoleKey.NumPad2)
                    {
                        Console.WriteLine("Document file Label downloading...");
                        try
                        {
                            //Set a name and an extension for a file and a combine with a path.
                            filePath = Path.Combine(path, "Shipment=" + ShipmentUUID + "=Label.pdf");
                            //Download 'Label' document.
                            stream = ukrPoshta.GetShipmentLabel(ShipmentUUID, 0);
                        }
                        catch { }
                    }

                    if (!string.IsNullOrEmpty(filePath))
                    {
                        //Create a file in a destination path.
                        CreateFile(stream, filePath);

                        //Check if the file exists on the destination path.
                        if (File.Exists(filePath))
                        {
                            //Show a success message.
                            Console.WriteLine("The file is downloaded.");
                            Console.WriteLine("The file(s) was saved on: " + path);
                            //Show a message box, then a Console application is waiting while they will be opened.
                            MessageBoxResult messageBoxResult = MessageBox.Show("Show folder?", "File(s) is downloaded.", MessageBoxButton.YesNo);
                            //Check if a message box result equals 'yes'
                            if (messageBoxResult == MessageBoxResult.Yes)
                            {
                                //Open file explorer with the destination path.
                                Process.Start(path);
                            }

                        }
                        else
                        {
                            //If the file does not exist, use GetLastError from the UkrPoshta instance to see a description.
                            Console.WriteLine("File downloading problem: " + ukrPoshta.GetLastError().Description);
                            Console.WriteLine("Press any key to exit...");
                            Console.ReadKey(); //Wating for pressed key...
                            return;
                        }
                    } 
                }
                catch (Exception ex)
                {
                    //If you have some exception, you can see it in Console.
                    Console.WriteLine("Error message: " + ex.Message);
                }
            }

            //Wating for a pressed key...
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// A Custom method for a creating file.
        /// </summary>
        /// <param name="stream">Input stream.</param>
        /// <param name="path">Created file path.</param>
        private static void CreateFile(Stream stream, string path)
        {
            //Return, if stream is null 
            if (stream == null) { return; }
            //Check if the file exists
            if (File.Exists(path))
            {
                //Remove exist file.
                File.Delete(path);
            }

            //Creating a new file on a destination path.
            using (var file = File.Create(path))
            {
                //Copy bytes to the file.
                stream.CopyTo(file);
            }

        }
    }
}
