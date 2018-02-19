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
        /// If you use Thin Client mode, you need an access to bNesis API Server. Address of the demo bNesis API server: https://server2.bnesis.com
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


            //Getting executionPath
            string executionPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path = Path.Combine(executionPath, "Temp");
            //Creating new directory, if directory does not exist.
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //Check bNesisDeveloperID
            if (string.IsNullOrEmpty(bNesisDeveloperId))
            {
                Console.WriteLine(
                    "For using this example, you need bNesis Developer Id. You can get it from https://api.bnesis.com site - free of charge\n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Check UkrPoshta authentication keys
            if (string.IsNullOrEmpty(UkrPoshtaBearer) || string.IsNullOrEmpty(UkrPoshtaCounterPartyToken))
            {
                Console.WriteLine(
                    "For using this example you need UkrPoshta authentication keys, please contact with the UkrPoshta administration to get these keys\n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Check UkrPoshta shipment uuid(identifier)
            if (string.IsNullOrEmpty(ShipmentUUID))
            {
                Console.WriteLine(
                    "For using this example you need UkrPoshta shipment uuid (identifier). You can get it in response after adding shipment in UkrPoshta. \n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Select Rich mode or Thin mode 
            Console.Write(
                "Please select Thin mode or Rich mode.\nPress 'R' for Rich client mode or press some other key for Thin client mode: ");
            //Waiting for pressed key. If key is not 'R', using default Thin client mode.
            ConsoleKeyInfo selectMode = Console.ReadKey();
            //Escape line
            Console.WriteLine();

            //Initialize result code
            int SDKInitializeResult;

            //Initialize client mode
            if (selectMode.Key == ConsoleKey.R) //if user has pressed 'R' key for Rich client mode
            {
                Console.WriteLine("Rich mode initialization...");
                //successful initialization returns zero code(noError)
                SDKInitializeResult = manager.InitializeRich(string.Empty);
            }
            else //default Thin client mode
            {
                Console.WriteLine("Thin Client mode Initialization...");
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
                //Successful Initialization 
                Console.WriteLine("bNesis SDK initialization status: Success\n");

                try
                {
                    Console.WriteLine("Authorization at UkrPoshta service, please wait...");
                    // this authorization method at UkrPoshta returns instance.
                    UkrPoshta ukrPoshta = manager.CreateInstanceUkrPoshta(bNesisDeveloperId, redirectUrl,
                        UkrPoshtaBearer, UkrPoshtaCounterPartyToken, true);
                    //If authorization is failed, the bNesisToken will be empty/null.
                    if (string.IsNullOrEmpty(ukrPoshta.bNesisToken))
                    {
                        //if bNesisToken is empty, use GetLastError method to get error description
                        if (!string.IsNullOrEmpty(manager.GetLastError()))
                            Console.WriteLine("Authorization problem: " + manager.GetLastError());
                        else Console.WriteLine("Authorization problem, please check parameters.\n");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                    }

                    //Authorization at UkrPoshta is successful
                    //Now you can use UkrPoshta API
                    Console.WriteLine("Authorizational success! UkrPoshta instance is created.\n");

                    //Getting documents by shipment identifier
                    Console.WriteLine("Select what document do you want to download: \n1. Sticker \n2. Label");
                    Console.Write("Press 1 or 2 on keyboard to select one of type or some other key to cancel: ");
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
                            //Set name and extension for file and combine with path.
                            filePath = Path.Combine(path, "Shipment=" + ShipmentUUID + "=Label.pdf");
                            //Download 'Label' document.
                            stream = ukrPoshta.GetShipmentLabel(ShipmentUUID, 0);
                        }
                        catch { }
                    }

                    if (!string.IsNullOrEmpty(filePath))
                    {
                        //Create file in destination path.
                        CreateFile(stream, filePath);

                        //Check if file exists on destination path.
                        if (File.Exists(filePath))
                        {
                            //Show success message.
                            Console.WriteLine("File is downloaded.");
                            Console.WriteLine("File(s) was saved on: " + path);
                            //Show message box, then Console application is waiting while they will be opened.
                            MessageBoxResult messageBoxResult = MessageBox.Show("Show folder?", "File(s) is downloaded.", MessageBoxButton.YesNo);
                            //Check if message box result equals 'yes'
                            if (messageBoxResult == MessageBoxResult.Yes)
                            {
                                //Open file explorer with destination path.
                                Process.Start(path);
                            }

                        }
                        else
                        {
                            //If file does not exist, use GetLastError from instance UkrPoshta to see description.
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
        /// Custom method for creating file.
        /// </summary>
        /// <param name="stream">Input stream.</param>
        /// <param name="path">Created file path.</param>
        private static void CreateFile(Stream stream, string path)
        {
            //Return, if stream is null 
            if (stream == null) { return; }
            //Check if file exists
            if (File.Exists(path))
            {
                //Remove exist file.
                File.Delete(path);
            }

            //Creating new file on destination path.
            using (var file = File.Create(path))
            {
                //Copy bytes to file.
                stream.CopyTo(file);
            }

        }
    }
}
