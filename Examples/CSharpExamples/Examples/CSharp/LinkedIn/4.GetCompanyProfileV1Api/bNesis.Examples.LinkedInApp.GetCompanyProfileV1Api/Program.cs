using System;
using bNesis.Sdk;
using bNesis.Sdk.Common;
using bNesis.Sdk.Social.LinkedIn;

/// <summary>
/// bNesis SDK LinkedIn sample.
/// Please see ReadMe file for more information about using and registration
/// </summary>
namespace bNesis.Examples.LinkedInApp.GetCompanyProfileV1Api
{
    /// <summary>
    /// This console example shows how to use bNesis SDK initialization, authentication and calls some method from LinkedIn:
    /// <para/>bNesis ServiceManager class
    /// <para/>bNesis ServiceManager methods: InitializeRich and InitializeThin
    /// <para/>bNesis ServiceManager CreateInstanceLinkedIn method
    /// <para/>bNesis LinkedIn GetCompanyProfileV1 method
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
        /// LinkedIn service Client ID. You can receive it in the settings of the LinkedIn application from https://www.linkedin.com/developer/apps site.
        /// </summary>
        private static string LinkedInClientId = string.Empty;

        /// <summary>
        /// LinkedIn service Client Secret. You can receive it in the settings of the LinkedIn application from https://www.linkedin.com/developer/apps site.
        /// </summary>
        private static string LinkedInClientSecret = string.Empty;

        /// <summary>
        /// Delimited list of member permissions your application is requesting on behalf of the user.
        /// </summary>
        /// "rw_company_admin"
        private static string[] Scope = new string[] { "rw_company_admin" };

        /// <summary>
        /// If you use a Thin Client mode, you need an access to a bNesis API Server. Addresses of the demo bNesis API servers:
        /// https://server2.bnesis.com
        /// https://bnesisserver1.azurewebsites.net
        /// https://bnesisserver2.azurewebsites.net
        /// https://bnesisserver3.azurewebsites.net
        /// 
        /// Please don't forget to setup your LinkedIn application Redirect URIs at the settings of LinkedIn App https://developer.linkedin.com/
        /// 
        /// In a Thin client mode add two redirectURIs to tab "Authentication" at Application Settings. The first redirectURI relates what bNesis API server you use:
        /// https://server2.bnesis.com/api/authprovider/signin
        /// https://bnesisserver1.azurewebsites.net/api/authprovider/signin        
        /// https://bnesisserver2.azurewebsites.net/api/authprovider/signin
        /// https://bnesisserver3.azurewebsites.net/api/authprovider/signin
        ///The second redirectURI is a default host and a port where the bNesis Thin client will be redirected to the specified address after the authentication 
        /// operation is performed. For example  http://localhost:809/ 
        ///
        /// Rich client:
        /// http://localhost:809/  
        /// (To know a  default bNesis Rich client redirect host and port, see redirectUrl property)
        /// (if you change the redirectUrl property at this example app, change the RedirectURIs at the Settings of LinkedIn App https://developer.linkedin.com/
        /// </summary>

        ///<summary>
        /// Company identifier. The member must be administrator of this company. Use your own value.
        /// </summary>
        private static int companyId = 0;

        /// <summary>
        /// If you use a Thin Client mode, you need an access to a bNesis API Server. Addresses of the available demo bNesis API Servers see above
        /// </summary>
        private static string bNesisAPIEndPoint = "https://server2.bnesis.com";

        /// <summary>
        /// The client will be redirected to the specified address after performing of the authentication operation.
        /// </summary>
        private static string redirectUrl = "http://localhost:809/";

        /// <summary>
        /// Entry point for a Console application.
        /// </summary>
        /// <param name="args">Input arguments when application starts. (Command line options)</param>
        static void Main(string[] args)
        {
            Console.WriteLine("bNesis SDK - LinkedIn SharePostApi example.\n");

            //bNesisSDK Initialization 
            ServiceManager manager = new ServiceManager();

#if (ExampleMode)
            /// Use this method only for testing and demonstration applications
            /// Using of this method does not protect your data
            bNesisDeveloperId = manager.GetKey("exampleDeveloperId", bNesisDeveloperId);
            LinkedInClientId = manager.GetKey("exampleClientIdLinkedIn", LinkedInClientId);
            LinkedInClientSecret = manager.GetKey("exampleClientSecretLinkedIn", LinkedInClientSecret);
#endif

            //Check bNesisDeveloperID
            if (string.IsNullOrEmpty(bNesisDeveloperId))
            {
                Console.WriteLine("For using this example you need a bNesis Developer Id. You can get it from https://api.bnesis.com site - free of charge.\n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Check LinkedIn authentication keys
            if (string.IsNullOrEmpty(LinkedInClientId) || string.IsNullOrEmpty(LinkedInClientSecret))
            {
                Console.WriteLine("For using this example you need a LinkedIn Client ID and a LinkedIn Client Secret. You can get keys from https://www.linkedin.com/developer/apps .\n");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            //Select a Rich client mode or a Thin client mode 
            Console.Write("Please select a Thin client mode or a Rich client mode.\nPress 'R' for the Rich client mode or any other key for the Thin client mode: ");
            //Waiting for a pressed key. If the key is not 'R', you will use a Thin client as a default mode.
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
                    Console.WriteLine("LinkedIn service Authorization, please wait...");
                    // this method authorizes LinkedIn service, returns instance.
                    LinkedIn linkedIn = manager.CreateInstanceLinkedIn(null, bNesisDeveloperId, redirectUrl,
                        LinkedInClientId, LinkedInClientSecret, Scope, null, null, false, null);
                    //If authorization has failed, the bNesisToken is empty/null.
                    if (string.IsNullOrEmpty(linkedIn.bNesisToken))
                    {
                        //if bNesisToken is empty. use GetLastError method to get error description
                        if (!string.IsNullOrEmpty(manager.GetLastError()))
                            Console.WriteLine("Authorization problem: " + manager.GetLastError());
                        else Console.WriteLine("Authorization problem. Please check parameters.\n");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                    }

                    //Authorization at LinkedIn is successful
                    //Now you can use LinkedIn APIs

                    //Get company profile by identifier
                    LinkedInCompany companyProfile = linkedIn.GetCompanyProfileV1(companyId);
                    //Getting last error
                    ErrorInfo errorInfo = linkedIn.GetLastError();
                    //Check if errorInfo code does not equal noError
                    if (errorInfo.Code != ServiceManager.errorCodeNoError)
                    {
                        Console.WriteLine("Can't share message, error code: " + errorInfo.Code +
                                          "\nReason:" + errorInfo.Description);
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                    }

                    Console.WriteLine("Success! Here is some information about company:");
                    Console.WriteLine("Name:" + companyProfile.name +
                                      "Size:" + companyProfile.size +
                                      "Industry:" + companyProfile.industry +
                                      "Type:" + companyProfile.type);
                }
                catch (Exception ex)
                {
                    //If you have some exception you can see a Console.
                    Console.WriteLine("Creating of instance 'LinkedIn' has failed, reason: " + ex.Message);
                }
            }

            //Waiting for a pressed key...
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
