using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bNesis.Sdk;
using bNesis.Sdk.Delivery.UkrPoshta;
using bNesis.Sdk.Social.Facebook;

/// <summary>
/// bNesis SDK UkrPoshta sample.
/// Please see ReadMe file for more information about using and registration
/// </summary>
namespace bNesis.Examples.FacebookApp.Auth
{
    /// <summary>
    /// This console example shows how to use bNesis SDK initialization and authentication:
    /// <para/>bNesis ServiceManager class
    /// <para/>bNesis ServiceManager methods: InitializeRich and InitializeThin
    /// <para/>bNesis ServiceManager CreateInstanceLinkedIn method
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
        /// Facebook service Client ID. You can receive it in the settings of the Facebook application from https://developers.facebook.com/apps/ site.
        /// </summary>
        private static string FacebookClientId = string.Empty;

        /// <summary>
        /// Facebook service Client Secret. You can receive it in the settings of the Facebook application from https://developers.facebook.com/apps/ site.
        /// </summary>
        private static string FacebookClientSecret = string.Empty;

        /// <summary>
        /// Delimited list of member permissions your application is requesting on behalf of the user.
        /// </summary>
        private static string[] Scope = new string[] { "user_friends", "user_about_me", "user_location", "user_birthday",
            "user_likes", "user_education_history", "user_relationship_details", "user_relationships", "user_religion_politics",
            "user_status", "manage_pages", "pages_show_list", "ads_read", "ads_management", "business_management", "user_events",
            "read_custom_friendlists", "user_likes", "user_posts", "publish_actions" };

        /// <summary>
        /// If you use Thin Client mode, you need an access to bNesis API Server. Address of the demo bNesis API server:
        /// https://server2.bnesis.com
        /// https://bnesisserver1.azurewebsites.net
        /// https://bnesisserver2.azurewebsites.net
        /// https://bnesisserver3.azurewebsites.net
        /// 
        /// Please don't forget setup your Facebook application Redirect URIs at the settings of Facebook App https://developers.facebook.com/
        /// 
        /// In Thin client mode add two redirectURIs to tab "Authentication" at Application Settings. The first redirectURI related what bNesis API server you use:
        /// https://server2.bnesis.com/api/authprovider/signin
        /// https://bnesisserver1.azurewebsites.net/api/authprovider/signin        
        /// https://bnesisserver2.azurewebsites.net/api/authprovider/signin
        /// https://bnesisserver3.azurewebsites.net/api/authprovider/signin
        ///The second redirectURI is default host and port where bNesis Thin client will be redirected to the specified address after the authentication 
        /// operation is performed. For example  http://localhost:809/ 
        ///
        /// Rich client:
        /// http://localhost:809/  
        /// (is default bNesis Rich client redirect host and port, see redirectUrl property)
        /// (if you change the redirectUrl property at this example app, change the RedirectURIs at the Settings of Facebook App https://developers.facebook.com/
        /// </summary>

        /// <summary>
        /// If you use Thin Client mode, you need access to bNesis API Server. Address of the avaliable demo bNesis API Servers see higher
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
            Console.WriteLine("bNesis SDK - Facebook authentication example.\n");

            //bNesisSDK Initialization 
            ServiceManager manager = new ServiceManager();

#if (ExampleMode)
            /// Use this method only for testing and demonstration applications
            /// Using of this method does not protect your data
            bNesisDeveloperId = manager.GetKey("exampleDeveloperId", bNesisDeveloperId);
            FacebookClientId = manager.GetKey("exampleFacebookClientId", FacebookClientId);
            FacebookClientSecret = manager.GetKey("exampleFacebookClientSecret", FacebookClientSecret);
#endif

            //Check bNesisDeveloperID
            if (string.IsNullOrEmpty(bNesisDeveloperId))
            {
                Console.WriteLine("For using this example, you need bNesis Developer Id. You can get it from https://api.bnesis.com site - free of charge.\n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Check Facebook authentication keys
            if (string.IsNullOrEmpty(FacebookClientId) || string.IsNullOrEmpty(FacebookClientSecret))
            {
                Console.WriteLine("For using this example you need Facebook authentication keys. Please contact with the Facebook administration to get these keys.\n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Select Rich client mode or Thin client mode 
            Console.Write("Please select Thin client mode or Rich client mode.\nPress 'R' for Rich client mode or press any other key for Thin client mode: ");
            //Waiting for pressed key. If key is not 'R', you will use Thin client as a default mode.
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
                    Console.WriteLine("Facebook service Authorization, please wait...");
                    // this method authorizes Facebook service, returns instance.
                    Facebook facebook = manager.CreateInstanceFacebook(
                        null, bNesisDeveloperId, redirectUrl, FacebookClientId, FacebookClientSecret, Scope, null, null, false, null);
                    //If authorization has failed, the bNesisToken is empty/null.
                    if (string.IsNullOrEmpty(facebook.bNesisToken))
                    {
                        //if bNesisToken is empty. use GetLastError method to get error description
                        if (!string.IsNullOrEmpty(manager.GetLastError())) Console.WriteLine("Authorization problem: " + manager.GetLastError());
                        else Console.WriteLine("Authorization problem. Please check parameters.\n");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                    }

                    //Authorization at Facebook is successful
                    //Now you can use Facebook APIs
                    Console.WriteLine("Authorization is successful! Facebook instance is created.\n");
                }
                catch (Exception ex)
                {
                    //If you have some exception you can see a Console.
                    Console.WriteLine("Creating of instance 'Facebook' has failed, reason: " + ex.Message);
                }
            }

            //Wating for a pressed key...
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
