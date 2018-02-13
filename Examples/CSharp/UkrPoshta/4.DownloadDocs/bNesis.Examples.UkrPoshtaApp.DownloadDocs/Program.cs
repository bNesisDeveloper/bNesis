using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using bNesis.Sdk;
using bNesis.Sdk.Delivery.UkrPoshta;
using System.Windows;

/// <summary>
/// bNesis SDK UkrPoshta sample.
/// Please see ReadMe file for more information about using and registration
/// </summary>
namespace bNesis.Examples.UkrPoshtaApp.DownloadDocs
{
    /// <summary>
    /// This console example show how to used bNesis SDK initialization, authentication and download some documents from UkrPoshta:
    /// <para/>bNesis ServiceManager class
    /// <para/>bNesis ServiceManager methods: InitializeRich and InitializeThin methods
    /// <para/>bNesis ServiceManager CreateInstanceUkrPoshta method
    /// <para/>bNesis UkrPoshta GetShipmentSticker method
    /// <para/>bNesis UkrPoshta GetShipmentLabel method
    /// <para/>
    /// <para/>Also this example demonstrate methods of getting bNesis SDK status information, error handling and service control. 
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
        /// UkrPoshta service authentication bearer.
        /// </summary>
        private static string UkrPoshtaBearer = string.Empty;

        /// <summary>
        /// UkrPoshta service conter party token.
        /// </summary>
        private static string UkrPoshtaConterPartyToken = string.Empty;

        /// <summary>
        /// UkrPoshta shipment identifier.
        /// </summary>
        private static string ShipmentUUID = string.Empty;

        /// <summary>
        /// If you use Thin Client mode, you need access to bNesis API Server. Address of the demo bNesis API server https://server2.bnesis.com
        /// </summary>
        private static string bNesisAPIEndPoint = "https://server2.bnesis.com";

        /// <summary>
        /// The client will be redirected to the specified address after the authentication operation is performed.
        /// </summary>
        private static string redirectUrl = "http://localhost:809/";

        /// <summary>
        /// Entry point for Console application.
        /// </summary>
        /// <param name="args">Input arguments when application start. (Command line options)</param>
        static void Main(string[] args)
        {
            Console.WriteLine("bNesis SDK - UkrPoshta download documents example\n");

            //Initialize bNesisSDK
            ServiceManager manager = new ServiceManager();

            //Getting executionPath
            string executionPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path = Path.Combine(executionPath, "Temp");
            //Creating new directory on path, if directory not exist.
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
            if (string.IsNullOrEmpty(UkrPoshtaBearer) || string.IsNullOrEmpty(UkrPoshtaConterPartyToken))
            {
                Console.WriteLine(
                    "For using this example you need UkrPoshta authentication keys, please contact the UkrPoshta administration to get the keys\n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Check UkrPoshta shipment uuid(identifier)
            if (string.IsNullOrEmpty(ShipmentUUID))
            {
                Console.WriteLine(
                    "For using this example you need UkrPoshta shipment uuid(identifier), you can get it in response after added shipment in UkrPoshta. \n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Select mode Rich or Thin mode 
            Console.Write(
                "Please select Thin or Rich mode.\nPress 'R' for Rich client mode or press any other key for Thin client mode: ");
            //Waiting for pressed key, if key is not 'R' using default Thin client.
            ConsoleKeyInfo selectMode = Console.ReadKey();
            //Escape line
            Console.WriteLine();

            //Initilize result code
            int SDKInitializeResult;

            //Initialize client mode
            if (selectMode.Key == ConsoleKey.R) //if user press 'R' key for Rich client
            {
                Console.WriteLine("Initialize Rich mode.");
                //If success initialize return zero code(noError)
                SDKInitializeResult = manager.InitializeRich(string.Empty);
            }
            else //default Thin client
            {
                Console.WriteLine("Initialize Thin mode.");
                //If success initialize return zero code(noError)
                SDKInitializeResult = manager.InitializeThin(bNesisAPIEndPoint);
            }

            //Check if initialize result not equal zero(noError)
            if (SDKInitializeResult != ServiceManager.errorCodeNoError)
            {
                //Show error message
                Console.WriteLine("bNesis SDK initialization problem, code: " + SDKInitializeResult +
                                  ", \nerror message:" + manager.GetLastError());
            }
            else
            {
                //Succes Initiliaze 
                Console.WriteLine("bNesis SDK initialization status: Success\n");

                try
                {
                    Console.WriteLine("Authorize at UkrPoshta service, please wait...");
                    // this method authorize at UkrPoshta, return instance.
                    UkrPoshta ukrPoshta = manager.CreateInstanceUkrPoshta(bNesisDeveloperId, redirectUrl,
                        UkrPoshtaBearer, UkrPoshtaConterPartyToken, true);
                    //If authorization failed, the bNesisToken be empty/null.
                    if (string.IsNullOrEmpty(ukrPoshta.bNesisToken))
                    {
                        //if bNesisToken empty - use GetLastError method to get error description
                        if (!string.IsNullOrEmpty(manager.GetLastError()))
                            Console.WriteLine("Authorize problem: " + manager.GetLastError());
                        else Console.WriteLine("Authorize problem, please check parameters.\n");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                    }

                    //Authorization at UkrPoshta Success
                    //Now you can use UkrPoshta API
                    Console.WriteLine("Authorization success! UkrPoshta instance created.\n");

                    //Getting documents by shipment identifier
                    Console.WriteLine("Select what document you want download: \n1. Sticker \n2. Label\n3. Both");
                    Console.Write("Press 1-3 on keyboard to select one of type or any other key to cancel:");
                    ConsoleKey downloadDocType = Console.ReadKey().Key;
                    //Escape line
                    Console.WriteLine();

                    //Check if you pressed 1-3 on keyboard.
                    if (downloadDocType == ConsoleKey.D1
                        || downloadDocType == ConsoleKey.D2
                        || downloadDocType == ConsoleKey.D3
                        || downloadDocType == ConsoleKey.NumPad1
                        || downloadDocType == ConsoleKey.NumPad2
                        || downloadDocType == ConsoleKey.NumPad3)
                    {
                        //Creating local variables.
                        Stream stream;
                        string filePath; //Name file with full path.

                        //Check if you pressed 1 or 3 on keyboard.
                        if (downloadDocType == ConsoleKey.D1
                            || downloadDocType == ConsoleKey.D3
                            || downloadDocType == ConsoleKey.NumPad1
                            || downloadDocType == ConsoleKey.NumPad3)
                        {
                            //Show message about what you downloading.
                            Console.WriteLine("Downloading document file Sticker...");

                            //Download 'Sticker' document.
                            stream = ukrPoshta.GetShipmentSticker(ShipmentUUID);
                            //Setting name and extension for file and combine with path.
                            filePath = Path.Combine(path, "Shipment=" + ShipmentUUID + "=Sticker.pdf");
                            //Create file in destination path.
                            CreateFile(stream, filePath);

                            //Check if file exist on destination path.
                            if (File.Exists(filePath))
                            {
                                //Show success message.
                                Console.WriteLine("Done. File was created.");
                            }
                            else
                            {
                                //If file not exist use from instance UkrPoshta GetLastError, to see description.
                                Console.WriteLine("File not created! Reason: " + ukrPoshta.GetLastError().Description);

                                //Wating for pressed key...
                                Console.WriteLine("Press any key to exit...");
                                Console.ReadKey();
                                return;
                            }
                        }
                        //Check if you pressed 2 or 3 on keyboard.
                        if (downloadDocType == ConsoleKey.D2
                            || downloadDocType == ConsoleKey.D3
                            || downloadDocType == ConsoleKey.NumPad1
                            || downloadDocType == ConsoleKey.NumPad3)
                        {
                            Console.WriteLine("Downloading document file Label...");
                            //Download 'Label' document.
                            stream = ukrPoshta.GetShipmentLabel(ShipmentUUID, 0);
                            //Setting name and extension for file and combine with path.
                            filePath = Path.Combine(path, "Shipment=" + ShipmentUUID + "=Label.pdf");
                            //Create file in destination path.
                            CreateFile(stream, filePath);

                            //Check if file exist on destination path.
                            if (File.Exists(filePath))
                            {
                                //Show success message.
                                Console.WriteLine("Done. File was created.");
                            }
                            else
                            {
                                //If file not exist use from instance UkrPoshta GetLastError, to see description.
                                Console.WriteLine("File not created! Reason: " + ukrPoshta.GetLastError().Description);

                                //Wating for pressed key...
                                Console.WriteLine("Press any key to exit...");
                                Console.ReadKey();
                                return;
                            }
                        }

                        //Show message about files downloding.
                        Console.WriteLine("File(s) downloaded.");

                        //Show message where files saved.
                        Console.WriteLine("File(s) was saved on: " + path);

                        //Show message box, then Console application waiting while they open.
                        MessageBoxResult messageBoxResult = MessageBox.Show("Show folder?", "File(s) downloaded.", MessageBoxButton.YesNo);
                        //Check if message box result equal yes
                        if (messageBoxResult == MessageBoxResult.Yes)
                        {
                            //Open file explorer with destination path.
                            Process.Start(path);
                        }
                    }
                }
                catch (Exception ex)
                {
                    //If you have some exception you can see in Console.
                    Console.WriteLine("Error message: " + ex.Message);
                }
            }

            //Wating for pressed key...
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Custom method for creating file.
        /// </summary>
        /// <param name="stream">Input stream.</param>
        /// <param name="path">Path where be created file.</param>
        private static void CreateFile(Stream stream, string path)
        {
            //Stream null return
            if (stream == null) { return; }
            //Check if file exist
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
