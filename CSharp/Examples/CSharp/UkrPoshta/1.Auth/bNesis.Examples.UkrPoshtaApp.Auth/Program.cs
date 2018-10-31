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
    /// This console example shows how to use bNesis SDK initialization and authentication:
    /// <para/>bNesis ServiceManager class
    /// <para/>bNesis ServiceManager methods: InitializeRich and InitializeThin
    /// <para/>bNesis ServiceManager CreateInstanceUkrPoshta method
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
        private static string bNesisDeveloperId = "COh/gdRp5YJESejPJrJGCY2c6li9Al42KyZ7kf4+Z6ZshMmwFPz5xQn1Vz5r/ODx/XUpQUW3QXMttycIjINjnnHccrRISIKoIAofFYfsQjHktRfP3iqTjNPF7/5yI5Pq";

        /// <summary>
        /// UkrPoshta service authentication bearer, please contact with the UkrPoshta administration to get the keys
        /// </summary>
        private static string UkrPoshtaBearer = "asdasd";

        /// <summary>
        /// UkrPoshta service counterparty token, please contact with the UkrPoshta administration to get the keys
        /// </summary>
        private static string UkrPoshtaCounterPartyToken = "asdasd";

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
        /// If you use the Thin Client mode, you need an access to the bNesis API Server. Address of the available demo bNesis API Servers see above
        /// </summary>
        private static string bNesisAPIEndPoint = "https://server2.bnesis.com";

        /// <summary>
        /// The client will be redirected to the specified address after performing of the authentication operation.
        /// </summary>
        private static string redirectUrl = "http://localhost:809/";

        /// <summary>
        /// Entry point for Console application.
        /// </summary>
        /// <param name="args">Input arguments when application starts. (Command line options)</param>
        static void Main(string[] args)
        {
            Console.WriteLine("bNesis SDK - UkrPoshta authentication example.\n");

            //bNesisSDK Initialization 
            ServiceManager manager = new ServiceManager();

#if (ExampleMode)
            /// Use this method only for testing and demonstration applications
            /// Using of this method does not protect your data
            bNesisDeveloperId = manager.GetKey("exampleDeveloperId", bNesisDeveloperId);
            UkrPoshtaBearer = manager.GetKey("exampleUkrPoshtaBearer", UkrPoshtaBearer);
            UkrPoshtaCounterPartyToken = manager.GetKey("exampleUkrPoshtaCounterPartyToken", UkrPoshtaCounterPartyToken);
#endif

            //Check a bNesisDeveloperID
            if (string.IsNullOrEmpty(bNesisDeveloperId))
            {
                Console.WriteLine("For using this example, you need a bNesis Developer Id. You can get it from https://api.bnesis.com site - free of charge.\n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Check UkrPoshta authentication keys
            if (string.IsNullOrEmpty(UkrPoshtaBearer) || string.IsNullOrEmpty(UkrPoshtaCounterPartyToken))
            {
                Console.WriteLine("For using this example you need UkrPoshta authentication keys. Please contact with the UkrPoshta administration to get these keys.\n");
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
                //Successful Initializing 
                Console.WriteLine("bNesis SDK initialization status: Success.\n");

                try
                {
                    Console.WriteLine("UkrPoshta service Authorization, please wait...");
                    // this method authorizes UkrPoshta service, returns instance.
                    UkrPoshta ukrPoshta = manager.CreateInstanceUkrPoshta(bNesisDeveloperId, UkrPoshtaBearer,
                        UkrPoshtaCounterPartyToken, redirectUrl);
                    //If authorization has failed, the bNesisToken is empty/null.
                    if (string.IsNullOrEmpty(ukrPoshta.bNesisToken))
                    {
                        //if bNesisToken is empty. use GetLastError method to get error description
                        if (!string.IsNullOrEmpty(manager.GetLastError())) Console.WriteLine("Authorization problem: " + manager.GetLastError());
                        else Console.WriteLine("Authorization problem. Please check parameters.\n");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                    }

                    //Authorization at UkrPoshta is successful
                    //Now you can use UkrPoshta APIs
                    Console.WriteLine("Authorization is successful! UkrPoshta instance is created.\n");
                }
                catch (Exception ex)
                {
                    //If you have some exception you can see a Console.
                    Console.WriteLine("Creating of instance 'UkrPoshta' has failed, reason: " + ex.Message);
                }
            }

            //Wating for a pressed key...
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
    