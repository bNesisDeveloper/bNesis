using System;
using bNesis.Sdk;
using bNesis.Sdk.Common;
using bNesis.Sdk.Delivery.UkrPoshta;

/// <summary>
/// bNesis SDK UkrPoshta sample.
/// Please see ReadMe file for more information about using and registration
/// </summary>
namespace bNesis.Examples.UkrPoshtaApp.Simple
{
    /// <summary>
    /// This console example shows how to use bNesis SDK initialization, authentication and calls some method from UkrPoshta:
    /// <para/>bNesis ServiceManager class
    /// <para/>bNesis ServiceManager methods: InitializeRich and InitializeThin
    /// <para/>bNesis ServiceManager CreateInstanceUkrPoshta method
    /// <para/>bNesis UkrPoshta AddAddress method
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
        /// UkrPoshta service authentication bearer.
        /// </summary>
        private static string UkrPoshtaBearer = string.Empty;

        /// <summary>
        /// UkrPoshta service conter party token.
        /// </summary>
        private static string UkrPoshtaCounterPartyToken = string.Empty;

        //These properties are used for creating of a class Address. We need it for working with the UkrPoshta service
        //We cite it for example, use your own values.
        /// <summary>
        /// Country name for address. (Example: UA)
        /// </summary>
        private static string country = "UA";
        /// <summary>
        /// City name for address. 
        /// </summary>
        private static string city = "Kyiw";
        /// <summary>
        /// Region name for address.
        /// </summary>
        private static string region = "Obolon";
        /// <summary>
        /// Street name for address.
        /// </summary>
        private static string street = "Obolonskiy prospekt";
        /// <summary>
        /// House number for address.
        /// </summary>
        private static string houseNumber = "3";
        /// <summary>
        /// Apartment number for address.
        /// </summary>
        private static string apartmentNumber = "36";
        /// <summary>
        /// Post code for address.
        /// </summary>
        private static string postcode = "04073";

        /// <summary>
        /// If you use Thin Client mode, you need an access to bNesis API Server. Address of the demo bNesis API server:
        /// https://server2.bnesis.com
        /// https://bnesisserver1.azurewebsites.net
        /// https://bnesisserver2.azurewebsites.net
        /// https://bnesisserver3.azurewebsites.net
        /// 
        /// Please don't forget to setup your Dropbox application Redirect URIs at the Dropbox developers console https://www.dropbox.com/developers/
        /// 
        /// In Thin client mode add two redirectURIs to tab "Setting" at Dropbox developers console. The first redirectURI relates, what bNesis API server you use:
        /// https://server2.bnesis.com/api/authprovider/signin
        /// https://bnesisserver1.azurewebsites.net/api/authprovider/signin        
        /// https://bnesisserver2.azurewebsites.net/api/authprovider/signin
        /// https://bnesisserver3.azurewebsites.net/api/authprovider/signin
        ///The second redirectURI is default host and port where bNesis Thin client will be redirected to the specified address after the authentication 
        /// operation is performed. For example  http://localhost:809/ 
        ///
        /// Rich client:
        /// http://localhost:809/  
        /// (as a default bNesis Rich client redirects host and port, see redirectUrl property)
        /// (if you change the redirectUrl property at this example app, change the RedirectURIs at the Dropbox developers console
        /// </summary>

        /// <summary>
        /// If you use Thin Client mode, you need access to bNesis API Server. Addresses of the available demo bNesis API Servers see above
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
            Console.WriteLine("bNesis SDK - UkrPoshta simple example\n");

            //Initialize bNesisSDK
            ServiceManager manager = new ServiceManager();

#if (ExampleMode)
            /// Use this method only for testing and demonstration applications
            /// The use of this method does not protect your data
            bNesisDeveloperId = manager.GetKey("exampleDeveloperId");
            UkrPoshtaBearer = manager.GetKey("exampleUkrPoshtaBearer");
            UkrPoshtaCounterPartyToken = manager.GetKey("exampleUkrPoshtaCounterPartyToken");
#endif

            #region Validation Creeds
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
                    "For using this example you need UkrPoshta authentication keys, please contact the UkrPoshta administration to get these keys\n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Check Country
            if (string.IsNullOrEmpty(country))
            {
                Console.WriteLine(
                    "For using this example you need set 'Country'.\n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Check City
            if (string.IsNullOrEmpty(city))
            {
                Console.WriteLine(
                    "For using this example you need set 'City'.\n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Check Region
            if (string.IsNullOrEmpty(region))
            {
                Console.WriteLine(
                    "For using this example you need set 'Region'.\n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Check Street
            if (string.IsNullOrEmpty(street))
            {
                Console.WriteLine(
                    "For using this example you need set 'Street'.\n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Check HouseNumber
            if (string.IsNullOrEmpty(houseNumber))
            {
                Console.WriteLine(
                    "For using this example you need set 'HouseNumber'.\n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Check ApartmentNumber
            if (string.IsNullOrEmpty(apartmentNumber))
            {
                Console.WriteLine(
                    "For using this example you need set 'ApartmentNumber'.\n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Check Postcode
            if (string.IsNullOrEmpty(postcode))
            {
                Console.WriteLine(
                    "For using this example you need set 'Postcode'.\n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            #endregion

            //Select Rich client mode or Thin client mode 
            Console.Write(
                "Please select Thin client mode or Rich client mode.\nPress 'R' for Rich client mode or press any other key for Thin client mode: ");
            //Waiting for a pressed key. If key is not 'R', using the Thin client mode as a default.
            ConsoleKeyInfo selectMode = Console.ReadKey();
            //Escape line
            Console.WriteLine();

            //Initilize result code
            int SDKInitializeResult;

            //Initialize client mode
            if (selectMode.Key == ConsoleKey.R) //if user has pressed 'R' key for Rich client
            {
                Console.WriteLine("Rich client mode initialization.");
                //successful initialization returns zero code(noError)
                SDKInitializeResult = manager.InitializeRich(string.Empty);
            }
            else //default Thin client mode
            {
                Console.WriteLine("Thin client mode initialization.");
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
                    Console.WriteLine("Authorization at the UkrPoshta service, please wait...");
                    // this method returns instance for the UkrPoshta service.
                    UkrPoshta ukrPoshta = manager.CreateInstanceUkrPoshta(bNesisDeveloperId, redirectUrl,
                        UkrPoshtaBearer, UkrPoshtaCounterPartyToken, true);
                    //If authorization is failed, the bNesisToken will be empty/null.
                    if (string.IsNullOrEmpty(ukrPoshta.bNesisToken))
                    {
                        //if bNesisToken is empty - use GetLastError method to get error description
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

                    //Adding a new address for the UkrPoshta service
                    Console.WriteLine("Adding of a new address to the UkrPoshta service...");
                    UkrPoshtaAddressIn addressIn = new UkrPoshtaAddressIn();  
                    //Set properties
                    addressIn.country = country;
                    addressIn.city = city;
                    addressIn.region = region;
                    addressIn.street = street;
                    addressIn.houseNumber = houseNumber;
                    addressIn.apartmentNumber = apartmentNumber;
                    addressIn.postcode = postcode;
                    //Add a new address
                    UkrPoshtaAddressOut address = ukrPoshta.AddAddress(addressIn);   
                    //Getting last error
                    ErrorInfo errorInfo = ukrPoshta.GetLastError();
                    //Check if errorInfo code does not equal noError
                    if (errorInfo.Code != ServiceManager.errorCodeNoError)
                    {
                        //Show error message
                        Console.WriteLine("address adding is Failed, error code:" + errorInfo.Code +
                                          ",\nReason:" + errorInfo.Description);
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                    }

                    Console.WriteLine("Success! New address is added.");
                    Console.WriteLine("Address ID:" + address.id);
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
