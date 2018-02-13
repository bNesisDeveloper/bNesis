using System;
using bNesis.Sdk;
using bNesis.Sdk.Delivery.UkrPoshta;

/// <summary>
/// bNesis SDK UkrPoshta sample.
/// Please see ReadMe file for more information about using and registration
/// </summary>
namespace bNesis.Examples.UkrPoshtaApp.Auth
{
    /// <summary>
    /// This console example show how to used bNesis SDK initialization and authentication:
    /// <para/>bNesis ServiceManager class
    /// <para/>bNesis ServiceManager methods: InitializeRich and InitializeThin methods
    /// <para/>bNesis ServiceManager CreateInstanceUkrPoshta method
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
            Console.WriteLine("bNesis SDK - UkrPoshta authentication example\n");

            //Initialize bNesisSDK
            ServiceManager manager = new ServiceManager();

            //Check bNesisDeveloperID
            if (string.IsNullOrEmpty(bNesisDeveloperId))
            {
                Console.WriteLine("For using this example, you need bNesis Developer Id. You can get it from https://api.bnesis.com site - free of charge\n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Check UkrPoshta authentication keys
            if (string.IsNullOrEmpty(UkrPoshtaBearer) || string.IsNullOrEmpty(UkrPoshtaConterPartyToken))
            {
                Console.WriteLine("For using this example you need UkrPoshta authentication keys, please contact the UkrPoshta administration to get the keys\n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Select mode Rich or Thin mode 
            Console.Write("Please select Thin or Rich mode.\nPress 'R' for Rich client mode or press any other key for Thin client mode: ");
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
                Console.WriteLine("bNesis SDK initialization problem, code: " + SDKInitializeResult + ", \nerror message:" + manager.GetLastError());
            }
            else
            {
                //Succes Initiliaze 
                Console.WriteLine("bNesis SDK initialization status: Success\n");

                try
                {
                    Console.WriteLine("Authorize at UkrPoshta service, please wait...");
                    // this method authorize at UkrPoshta, return instance.
                    UkrPoshta ukrPoshta = manager.CreateInstanceUkrPoshta(bNesisDeveloperId, redirectUrl, UkrPoshtaBearer, UkrPoshtaConterPartyToken, true);
                    //If authorization failed, the bNesisToken be empty/null.
                    if (string.IsNullOrEmpty(ukrPoshta.bNesisToken))
                    {
                        //if bNesisToken empty - use GetLastError method to get error description
                        if (!string.IsNullOrEmpty(manager.GetLastError())) Console.WriteLine("Authorize problem: " + manager.GetLastError());
                        else Console.WriteLine("Authorize problem, please check parameters.\n");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                    }

                    //Authorization at UkrPoshta Success
                    //Now you can use UkrPoshta API
                    Console.WriteLine("Authorization success! UkrPoshta instance created.\n");
                }
                catch (Exception ex)
                {
                    //If you have some exception you can see in Console.
                    Console.WriteLine("Creating instance 'UkrPoshta' failed, reason: " + ex.Message);
                }
            }

            //Wating for pressed key...
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
