using System;
using bNesis.Sdk;
using bNesis.Sdk.Demo.DemoService;

namespace bNesis.Examples.DS.Simple
{
    /// <summary>
    /// This console example shows how to use bNesis SDK Demo Service:
    /// <para/>bNesis ServiceManager class
    /// <para/>bNesis ServiceManager CreateInstanceDemoService method
    /// <para/>    
    ///    
    /// We selected the most accessible public services for demonstrating APIs:
    /// 
    /// OpenWeatherMap
    /// Current weather and forecasts in your city.
    /// https://openweathermap.org/
    /// 
    /// NASA APIs
    /// The objective of this site is to make NASA data, including imagery, eminently accessible to application developers.
    /// https://api.nasa.gov/
    /// 
    /// VKontakte
    /// A universal service for communication and finding friends and classmates, who are daily used by tens of millions of people.
    /// https://vk.com/
    /// </summary>

    class Program
    {
        /// <summary>
        ///  To use the bNesis SDK in your applications, you must have the bNesis Developer ID - the key that signs your copy of the bNesis SDK. 
        ///  To study bNesis SDK, tests and demonstrations, you can get the key from https://api.bnesis.com site, free of charge.
        ///  Please, put your bNesis Developer ID here
        /// </summary>
        private static string bNesisDeveloperId = "KRyUI28oU0YCw839HdFds/mOSgm4WjwXeV2vFDUjBKF9ZijkXFDR0hHYfLxWl5w1XpviACadrPz4cOCGp74r/w==";

        /// <summary>
        /// Addresses of the free bNesis API server, for demonstration and study, the free copies are available completely free and free of 
        /// charge (under the "AS IS" agreement). You need an access to the bNesis API Server to use bNesis Demo Service.
        /// </summary>
        private static string bNesisAPIEndPoint = "https://server2.bnesis.com/";

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
            Console.WriteLine("bNesis SDK - Demo Service simple example\n");

            //Initialize bNesis SDK Section -------------------------------------------------------------------------------------------
            //At this stage, you can skip this section and go directly to the API Call Section
            #region initialize
            //Create bNesis SDK Service Manager
            ServiceManager manager = new ServiceManager();

            //Check a bNesisDeveloperID
            if (string.IsNullOrEmpty(bNesisDeveloperId))
            {
                Console.WriteLine("For using this example, you need an bNesis Developer Id.\r\nYou can get it from https://api.bnesis.com site - free of charge\r\nPress any key to exit...");
                Console.ReadKey();
                return;
            }

            //Initialize bNesis SDK client
            manager.InitializeThin(bNesisAPIEndPoint);

            //Create Demo Service instance
            Console.WriteLine("Create bNesis Demo Service instance, please wait...\n");
            DemoService demoService = manager.CreateInstanceDemoService(bNesisDeveloperId, redirectUrl);
            #endregion

            // API Call Section --------------------------------------------------------------------------------------------------------

            //Now we demonstrate the call of three simple APIs from the bNesis SDK:
            //  1) The API returns 'Hello World'                    (this API is without a parameter)
            //  2) API returns the number of 'Pi'                   (this API without a parameter)
            //  3) API returns the specified string in upper case   (this API uses one parameter)

            Console.Write("Call API 'A01HelloWorld' result: ");
            string a01HelloWorldResult = demoService.A01HelloWorld(); //This API return 'Hello World'
            Console.WriteLine(a01HelloWorldResult);
            
            Console.Write("Call API 'A02GetPi' result: ");
            string a02GetPiResult = demoService.A02GetPi();           //This API return the number of 'Pi' 
            Console.WriteLine(a02GetPiResult);

            //For call next API we ask user to input API parameter from the keyboard and press enter
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Now please enter parameter for 'A03TranslationTextToUppercase' API: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            string a03TranslationTextToUppercaseParameter = Console.ReadLine();
            Console.Write("Call API 'A03TranslationTextToUppercase' result: ");
            //This API return string at upper case
            string a03TranslationTextToUppercaseResult = demoService.A03TranslationTextToUppercase(a03TranslationTextToUppercaseParameter);
            Console.WriteLine(a03TranslationTextToUppercaseResult);

            //Get weather in London            
            Console.WriteLine("Call API 'B01GetCurrentWeatherInAnyCity' to get weather in London: ");
            Console.WriteLine(demoService.B01GetCurrentWeatherInAnyCity("London", "UK"));
            Console.WriteLine("");

            //Get weather in Warsaw
            Console.WriteLine("Call API 'B01GetCurrentWeatherInAnyCity' to get weather in Warsaw: ");
            Console.WriteLine(demoService.B01GetCurrentWeatherInAnyCity("Warsaw", "PL"));
            Console.WriteLine("");

            //----------------------------------------------------------------------------------------------------------------------------
            //Now - independently call the API 'C01GetAllCountries' to get a list of all the countries of the world
            //----------------------------------------------------------------------------------------------------------------------------

            Console.WriteLine("\nThank you for your first step with bNesis, press any key to exit...");
            Console.ReadKey();
        }

    }
}
