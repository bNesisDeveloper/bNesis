using System;
using bNesis.Sdk;
using bNesis.Sdk.Common;
using bNesis.Sdk.Delivery.UkrPoshta;
using bNesis.Sdk.eCommerce.PrestaShop;

/// <summary>
/// bNesis SDK UkrPoshta sample.
/// Please see ReadMe file for more information about using and registration
/// </summary>
namespace bNesis.Examples.UkrPoshtaApp.AddShipmentApi
{
    /// <summary>
    /// This console example shows how to use bNesis SDK initialization, authentication and calls some method from UkrPoshta service:
    /// <para/>bNesis ServiceManager class
    /// <para/>bNesis ServiceManager methods: InitializeRich and InitializeThin
    /// <para/>bNesis ServiceManager CreateInstanceUkrPoshta method
    /// <para/>bNesis UkrPoshta AddShipment method
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
        /// If you use Thin Client mode, you need an access to bNesis API Server. Address of the demo bNesis API server:
        /// https://server2.bnesis.com
        /// https://bnesisserver1.azurewebsites.net
        /// https://bnesisserver2.azurewebsites.net
        /// https://bnesisserver3.azurewebsites.net
        /// 
        /// Please don't forget to setup your Dropbox application Redirect URIs at Dropbox developers console https://www.dropbox.com/developers/
        /// 
        /// In Thin client mode add two redirectURIs to tab "Setting" at Dropbox developers console. The first redirectURI relates what bNesis API server you use:
        /// https://server2.bnesis.com/api/authprovider/signin
        /// https://bnesisserver1.azurewebsites.net/api/authprovider/signin        
        /// https://bnesisserver2.azurewebsites.net/api/authprovider/signin
        /// https://bnesisserver3.azurewebsites.net/api/authprovider/signin
        ///The second redirectURI is a default host and a port where bNesis Thin client will be redirected to the specified address after the authentication 
        /// operation is performed. For example  http://localhost:809/ 
        ///
        /// Rich client:
        /// http://localhost:809/  
        /// (as a default bNesis Rich client redirects host and port, see redirectUrl property)
        /// (if you change the redirectUrl property at this example app, change the RedirectURIs at Dropbox developers console
        /// </summary>

        /// <summary>
        /// If you use Thin Client mode, you need access to the bNesis API Server. Address of the available demo bNesis API Servers see above
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
            Console.WriteLine("bNesis SDK - UkrPoshta AddShipmentApi example\n");

            //Initialize bNesisSDK
            ServiceManager manager = new ServiceManager();

#if (ExampleMode)
            /// Use this method only for testing and demonstration applications
            /// The use of this method does not protect your data
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
                    "For using this example you need UkrPoshta authentication keys. Please contact with the UkrPoshta administration to get these keys\n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Select Rich client mode or Thin client mode 
            Console.Write(
                "Please select Thin client mode or Rich client mode.\nPress 'R' for Rich client mode or any other key for Thin client mode: ");
            //Waiting for a pressed key, if key is not 'R', using the default Thin client mode.
            ConsoleKeyInfo selectMode = Console.ReadKey();
            //Escape line
            Console.WriteLine();

            //Initialize result code
            int SDKInitializeResult;

            //Initialize client mode
            if (selectMode.Key == ConsoleKey.R) //if user has pressed 'R' key for Rich client mode
            {
                Console.WriteLine("Rich client mode Initialization...");
                //If success is, initialization returns zero code(noError)
                SDKInitializeResult = manager.InitializeRich(string.Empty);
            }
            else //default Thin client mode
            {
                Console.WriteLine("Thin client mode Initialization...");
                //If success is, initialization returns zero code(noError)
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
                    //Now you can use UkrPoshta service
                    Console.WriteLine("Authorization success! UkrPoshta instance is created.\n");

                    Console.WriteLine("Adding a shippment to the UkrPoshta service...");
                    UkrPoshtaShipmentIn shipmentIn = new UkrPoshtaShipmentIn();
                    UkrPoshtaCustomerUuid recipient = new UkrPoshtaCustomerUuid();
                    //Set an uuid
                    recipient.uuid = "780e309c-3003-41a3-828f-57540005d6dd";
                    //Set a recipient
                    shipmentIn.recipient = recipient;
                    UkrPoshtaCustomerUuid sender = new UkrPoshtaCustomerUuid();
                    //Set an uuid
                    sender.uuid = "201d8152-d281-4464-a275-b857ab62c940";
                    //Set a sender
                    shipmentIn.sender = sender;
                    //Set a return address identifier
                    shipmentIn.returnAddressId = "19113";
                    //Set a recipient address identifier
                    shipmentIn.recipientAddressId = "191133";
                    //Set a recipient email
                    shipmentIn.recipientEmail = "test@mail.com";
                    //Set a recipient phone
                    shipmentIn.recipientPhone = "+380997777777";
                    UkrPoshtaParcel[] parcels = new UkrPoshtaParcel[1];
                    UkrPoshtaParcel parcel = new UkrPoshtaParcel();
                    //Set a declared price
                    parcel.declaredPrice = 100;
                    //Set a height
                    parcel.height = 25;
                    //Set a length
                    parcel.length = 25;
                    //Set a weight
                    parcel.weight = 500;
                    //Set a width
                    parcel.width = 5;
                    //Set an element
                    parcels[0] = parcel;
                    //Set an array of parcel
                    shipmentIn.parcels = parcels;
                    //Set a post pay
                    shipmentIn.postPay = 25;
                    //Set a post pay paid by recipient
                    shipmentIn.postPayPaidByRecipient = true;
                    //Set a delivery type
                    shipmentIn.deliveryType = "W2D";
                    //Set a type
                    shipmentIn.type = "EXPRESS";
                    //Set on the fail a receive type
                    shipmentIn.onFailReceiveType = "RETURN";
                    //Set a description
                    shipmentIn.description = "For example.";
                    UkrPoshtaShipmentOut shipment = ukrPoshta.AddShipment(shipmentIn);
                    //Getting last error
                    ErrorInfo errorInfo = ukrPoshta.GetLastError();
                    //Check if errorInfo code does not equal noError
                    if (errorInfo.Code != ServiceManager.errorCodeNoError)
                    {
                        //Show error message
                        Console.WriteLine("Failed shipment adding, error code:" + errorInfo.Code +
                                          ",\nReason:" + errorInfo.Description);
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                    }
                    //Show success message
                    Console.WriteLine("Success. Shipment uuid:" + shipment.uuid);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("                       ^^^ store this Shipment uuid for using at a download document example");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                catch (Exception ex)
                {
                    //If you have some exception, you can see it in Console.
                    Console.WriteLine("Error message: " + ex.Message);
                }
            }
            //Waiting for a pressed key...
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
                