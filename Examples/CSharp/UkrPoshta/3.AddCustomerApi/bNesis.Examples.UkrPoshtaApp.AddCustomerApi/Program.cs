using System;
using System.Diagnostics.Eventing;
using bNesis.Sdk;
using bNesis.Sdk.Common;
using bNesis.Sdk.Delivery.UkrPoshta;

/// <summary>
/// bNesis SDK UkrPoshta sample.
/// Please see ReadMe file for more information about using and registration
/// </summary>
namespace bNesis.Examples.UkrPoshtaApp.AddCustomerApi
{
    /// <summary>
    /// This console example shows how to use bNesis SDK initialization, authentication and how to call some method from UkrPoshta:
    /// <para/>bNesis ServiceManager class
    /// <para/>bNesis ServiceManager methods: InitializeRich and InitializeThin
    /// <para/>bNesis ServiceManager CreateInstanceUkrPoshta method
    /// <para/>bNesis UkrPoshta AddClient method
    /// <para/>
    /// <para/>Also this example demonstrates any methods of getting bNesis SDK status information, error handling and service control. 
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
        /// UkrPoshta service counterparty token.
        /// </summary>
        private static string UkrPoshtaCounterPartyToken = string.Empty;

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
        /// <param name="args">Input arguments when application starts. (Command line options)</param>
        static void Main(string[] args)
        {
            Console.WriteLine("bNesis SDK - UkrPoshta customer API using example\n");

            //Initialize bNesisSDK
            ServiceManager manager = new ServiceManager();

#if (ExampleMode)
            /// Use this method only for testing and demonstration applications
            /// The use of this method does not protects your data
            bNesisDeveloperId = manager.GetKey("exampleDeveloperId", bNesisDeveloperId);
            UkrPoshtaBearer = manager.GetKey("exampleUkrPoshtaBearer", UkrPoshtaBearer);
            UkrPoshtaCounterPartyToken = manager.GetKey("exampleUkrPoshtaCounterPartyToken", UkrPoshtaCounterPartyToken);
#endif

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
                    "For using this example you need UkrPoshta authentication keys, please contact with the UkrPoshta administration to get the keys\n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Select Rich mode or Thin mode 
            Console.Write(
                "Please select Thin mode or Rich mode.\nPress 'R' for Rich client mode or any other key for Thin client mode: ");
            //Waiting for pressed key. If key is not 'R', using default Thin client mode.
            ConsoleKeyInfo selectMode = Console.ReadKey();
            //Escape line
            Console.WriteLine();

            //Initialize result code
            int SDKInitializeResult;

            //Initialize client mode
            if (selectMode.Key == ConsoleKey.R) //if user has pressed 'R' key for Rich client mode
            {
                Console.WriteLine("Rich mode initialization ...");
                //If initialization successful is, zero code (noError) will be returned 
                SDKInitializeResult = manager.InitializeRich(string.Empty);
            }
            else //default Thin client
            {
                Console.WriteLine("Thin mode Initialization...");
                //If success, initialization returns zero code(noError)
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
                //Succesful Initialization 
                Console.WriteLine("bNesis SDK initialization status: Success\n");

                try
                {
                    Console.WriteLine("Authorization at UkrPoshta service, please wait...");
                    // this UkrPoshta authorization method returns instance.
                    UkrPoshta ukrPoshta = manager.CreateInstanceUkrPoshta(bNesisDeveloperId, redirectUrl,
                        UkrPoshtaBearer, UkrPoshtaCounterPartyToken, true);
                    //If authorization has failed, the bNesisToken will be empty/null.
                    if (string.IsNullOrEmpty(ukrPoshta.bNesisToken))
                    {
                        //if bNesisToken empty is, use GetLastError method to get error description
                        if (!string.IsNullOrEmpty(manager.GetLastError()))
                            Console.WriteLine("Authorization problem: " + manager.GetLastError());
                        else Console.WriteLine("Authorization problem, please check parameters.\n");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                    }

                    //Authorization at UkrPoshta is successful
                    //Now you can use UkrPoshta
                    Console.WriteLine("Authorization success! UkrPoshta instance is created.\n");

                    //Adding new client for UkrPoshta
                    Console.WriteLine("Adding customer to UkrPoshta...");
                    //Creating new customer class
                    CustomerIn customerIn = new CustomerIn();

                    //Next values will be used for example. Use your own values.

                    //Set email
                    customerIn.email = "GrigoriyBoyko@mail.com";
                    //Set address identifier
                    customerIn.addressId = 19113;
                    //Set first name
                    customerIn.firstName = "Grigoriy";
                    //Set middle name
                    customerIn.middleName = "Boyko";
                    //Set last name
                    customerIn.lastName = "Bogdanovich";
                    //Set individual
                    customerIn.individual = true;
                    //Set resident
                    customerIn.resident = true;
                    //Add new customer
                    CustomerOut customer = ukrPoshta.AddClient(customerIn);
                    //Getting last error
                    ErrorInfo errorInfo = ukrPoshta.GetLastError();
                    //Check if errorInfo code does not equal noError
                    if (errorInfo.Code != ServiceManager.errorCodeNoError)
                    {
                        //Show error message
                        Console.WriteLine("Failed customer adding, error code:" + errorInfo.Code +
                                          ",\nReason:" + errorInfo.Description);
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                    }
                    //Show success message
                    Console.WriteLine("Success. Customer uuid:" + customer.uuid);
                }
                catch (Exception ex)
                {
                    //If you have some exception you can see it in Console.
                    Console.WriteLine("Error message: " + ex.Message);
                }
            }

            //Wating for pressed key...
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
