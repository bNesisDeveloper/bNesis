using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using bNesis.Common;
using bNesis.Api.Desktop;
using bNesis.Sdk.Analytics.GoogleAnalytics;
using bNesis.Sdk.Other.IISSEO;
using bNesis.Sdk.Delivery.UkrPoshta;
using bNesis.Sdk.Demo.DemoService;
using bNesis.Sdk.eCommerce.Allegro;
using bNesis.Sdk.eCommerce.Amazon;
using bNesis.Sdk.eCommerce.BigCommerce;
using bNesis.Sdk.eCommerce.OpenCart;
using bNesis.Sdk.eCommerce.PrestaShop;
using bNesis.Sdk.eCommerce.Shopify;
using bNesis.Sdk.FileStorages.BaiduBCS;
using bNesis.Sdk.FileStorages.Box;
using bNesis.Sdk.FileStorages.Dropbox;
using bNesis.Sdk.FileStorages.GoogleDrive;
using bNesis.Sdk.FileStorages.Mega;
using bNesis.Sdk.FileStorages.SugarSync;
using bNesis.Sdk.GovRegistry.Prozzoro;
using bNesis.Sdk.Payment.LiqPay;
using bNesis.Sdk.Payment.PayPal;
using bNesis.Sdk.Payment.Stripe;
using bNesis.Sdk.Social.Facebook;
using bNesis.Sdk.Social.GooglePlus;
using bNesis.Sdk.Social.LinkedIn;
using bNesis.Sdk.Social.VKontakte;
using bNesis.Sdk.Test.bNesisTestService;

namespace bNesis.Sdk
{
		///<summary>
	/// Client mode constants  
	/// </summary>
	public enum ClientMode
    { 
       /// <summary>
       /// set bNesis Rich client
       /// </summary>
	   Rich = 1,
	  
	  /// <summary>
      /// set bNesis Thin client
      /// </summary>
	  Thin = 2
    }

	///<summary>
	/// Class to manage services 
	/// </summary>
	public class ServiceManager
	{
        ///<summary>
        /// No error code constant  
        /// </summary>
        public const int errorCodeNoError = 0;
        
        ///<summary>
        /// No error code  description  
        /// </summary>
        public const string errorCodeNoErrorDesctiption = "no error";

        ///<summary>
        /// Bad Url error constant  
        /// </summary>
        public const int errorCodeBadUrl = 1;

        ///<summary>
        /// Description of bad Url error 
        /// </summary>
        public const string errorCodeBadUrlDescription = "sorry, bad service URL, missed HTTP protocol URL syntax, please check URL.";

        ///<summary>
        /// Not connected error constant  
        /// </summary>
        public const int errorCodeNotConnected = 2;

        ///<summary>
        /// Description of not connected error  
        /// </summary>
        public const string errorCodeNotConnectedDesctiption = "sorry, could't connect to bNesis API server, please check URL, with system message: ";

        ///<summary>
        /// Library location error  constant  
        /// </summary>
        public const int errorCodeLibraryLocation = 3;

        ///<summary>
        /// Description of library location error   
        /// </summary>
        public const string errorCodeLibraryLocationDesctiption = "sorry, bad library location,  please check path to library location.";

        ///<summary>
        /// Not library is loaded error constant  
        /// </summary>
        public const int errorCodeNotLibraryIsLoaded = 4;

        ///<summary>
        /// Description of not library is loaded error   
        /// </summary>
        public const string errorCodeNotLibraryIsLoadedDesctiption = "sorry, library is not loaded,  please check library location.";

        ///<summary>
        /// No slash error constant  
        /// </summary>
        public const int errorCodeNotSlash = 5;

        ///<summary>
        /// Description of provider no slash error   
        /// </summary>
        public const string errorCodeNotSlashDesctiption = "sorry, no simbol slash '/' in end of Url address";

        ///<summary>
        ///Provider does not exist error constant 
        /// </summary>
        public const int errorCodeProviderDoesNotExist = 6;

        ///<summary>
        /// Description of provider does not exist error 
        /// </summary>
        public const string errorCodeProviderDoesNotExistDescription = "sorry, the provider does not exist, please, check API location";

        ///<summary>
        /// Service does not exist error constant
        /// </summary>
        public const int errorCodeServiceDoesNotExist = 7;

        ///<summary>
        /// Description of service does not exist error 
        /// </summary>
        public const string errorCodeServiceDoesNotExistDescription = "sorry, the service does not exist, please, check API location";

        ///<summary>
        ///Bad server name error constant  
        /// </summary>
        public const int errorCodeBadServerName = 8;

        ///<summary>
        /// Description of bad server name error  
        /// </summary>
        public const string errorCodeBadServerNameDescription = "sorry, bad server name, please check it";

        ///<summary>
        /// Unknown server connection error constant 
        /// </summary>
        public const int errorCodeUnknownServerConnection = 9;

        ///<summary>
        /// Description of unknown server connection error   
        /// </summary>
        public const string errorCodeUnknownServerConnectionDescription = "sorry, unknown Server connection error";


        ///<summary>
        /// System Error  description message  
        /// </summary>
        private string lastSystemErrorMessage = string.Empty;

		///<summary>
        /// List of providers
        /// </summary>
        List<object> providers;

        private DesktopbNesisApi bNesisApi { get; set;}
		  
		///<summary>
        /// Constuctor for Thin/Rich client with no parameters
        /// </summary>
        public ServiceManager()
		{
			bNesisApi = new DesktopbNesisApi();
		}

        ///<summary>
        /// Constuctor for Thin/Rich client with parameters
        /// </summary>
        /// <param name="client">Rich mode equals 1, Thin equals 2</param>
        /// <param name="apiLocation">Connection parameter:  bNesis API HTTP server internet address for thin client, bNesis  library location for rich client</param>
        public ServiceManager(ClientMode client, string apiLocation): this()
		{
            int initResult = Initialize(client, apiLocation);

            switch (initResult)
            {
                case ServiceManager.errorCodeBadUrl:                
                    throw new Exception(ServiceManager.errorCodeBadUrlDescription);
                case ServiceManager.errorCodeNotConnected:                
                    throw new Exception(ServiceManager.errorCodeNotConnected + lastSystemErrorMessage);
                case ServiceManager.errorCodeLibraryLocation:
                    throw new Exception(ServiceManager.errorCodeLibraryLocationDesctiption);
                case ServiceManager.errorCodeNotSlash:
                    throw new Exception(ServiceManager.errorCodeNotSlashDesctiption);
                case ServiceManager.errorCodeNotLibraryIsLoaded:
                     throw new Exception(ServiceManager.errorCodeNotLibraryIsLoaded + lastSystemErrorMessage);
                case ServiceManager.errorCodeBadServerName:
                    throw new Exception(ServiceManager.errorCodeBadServerNameDescription);
                case ServiceManager.errorCodeProviderDoesNotExist:
                    throw new Exception(ServiceManager.errorCodeProviderDoesNotExistDescription);
                case ServiceManager.errorCodeServiceDoesNotExist:
                    throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
                case ServiceManager.errorCodeUnknownServerConnection:
                    throw new Exception(ServiceManager.errorCodeUnknownServerConnectionDescription + lastSystemErrorMessage);
            }
		}

        ///<summary>
        /// Method for Initialize the Thin/Rich client 
        /// </summary>
        /// <param name="client">Rich mode equals 1,  Thin equals 2</param>
        /// <param name="apiLocation">Connection parameter:  bNesis API HTTP server internet address for thin client, bNesis  library location for rich client</param>
        public int Initialize(ClientMode client, string apiLocation)
		{
		    switch(client)
			{
				case ClientMode.Thin:
                    return InitializeThin(apiLocation);                    
				case ClientMode.Rich:
					return InitializeRich(apiLocation);					
		    }

            return ServiceManager.errorCodeNoError;
        }

        /// <summary>
        ///  Method for Initialize the Thin client 
        /// </summary>
        /// <param name="apiLocation">Connection parameter. bNesis API HTTP server internet address</param>
        /// <returns>bNesis SDK errorCode</returns>                	
        public int InitializeThin(string apiLocation)
        {
            lastSystemErrorMessage = string.Empty;
            providers = new List<object>();

            if ((apiLocation == null) || (String.IsNullOrEmpty(apiLocation))) return ServiceManager.errorCodeBadUrl;

            //There is no protocol name in serverURL
            if (apiLocation.IndexOf("http") != 0) return ServiceManager.errorCodeBadUrl; // "Missed protocol name (http:// or https://) in serverURL"
            try
            {
                bNesisApi.InitializeRemote(apiLocation);
                providers.AddRange(bNesisApi.SessionsManager.AuthProvidersManager.GetProviderIds().Cast<object>().ToArray());
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
            
                    if (e.InnerException is HttpRequestException)
                    {
                        lastSystemErrorMessage = e.Message;
                        return ServiceManager.errorCodeBadServerName;
                    }
                    else
                    {
                        lastSystemErrorMessage = e.Message;
                        return ServiceManager.errorCodeUnknownServerConnection;
                    }
                }
                else
                {
                    lastSystemErrorMessage = e.Message;
                    return ServiceManager.errorCodeNotConnected;
                }
            }

            return ServiceManager.errorCodeNoError;

        }

        /// <summary>
        ///  Method for Initialize the Rich client 
        /// </summary>
        /// <param name="libraryLocation">Connection parameter. bNesis DLL library location for rich client</param>
        /// <returns>bNesis SDK errorCode</returns>   
        public int InitializeRich(string libraryLocation)
        {
			lastSystemErrorMessage = string.Empty;

            providers = new List<object>();

            if (libraryLocation == null) return ServiceManager.errorCodeLibraryLocation;
            try
            {
                bNesisApi.InitializeLocal(libraryLocation, libraryLocation);
            }
            catch (Exception e)
            {
               if (e.HResult == 0x80070003)
                { 
                    lastSystemErrorMessage = e.Message;
                    return ServiceManager.errorCodeLibraryLocation;
                }
                else
                {
                    lastSystemErrorMessage = e.Message;
                    return ServiceManager.errorCodeNotLibraryIsLoaded;
                }
            }

            return ServiceManager.errorCodeNoError;

        }

        /// <summary>
        /// Get last manager error description
        /// </summary>
        /// <returns>error description</returns>
        public string GetLastError()
        {
            return lastSystemErrorMessage;
        }

        /// <summary>
        /// Core level get last error method (Exception analize variant)
        /// each service has an GetLastError API for handling errors at the top level, but there is the same Core level API 
        /// for make analysis and handling Core level errors. 
        /// This implementation of the method allows you to analyze exception - check  the bNesis exception class, or system
        /// exception. If bNesis - get error code and information
        /// </summary>        
        /// <param name="exception">exception object (from catch(Exception))</param>
        /// <returns>if is bNesis exception type - return string with exception message, like - service not available.
        /// Return empty string if not bNesis exception</returns>
        public string GetLastError(Exception exception)
        {
            return bNesisApi.GetLastError(exception);
        }

        /// <summary>
        /// Core level get last error code method, see GetLastError for more information
        /// </summary>        
        /// <param name="exception">exception object (from catch(Exception))</param>
        /// <returns>if is bNesis exception type - return bNesis core error code. Else return 0 (bNesisNoError)</returns>
        public string GetLastErrorCode(Exception exception)
        {
            return bNesisApi.GetLastError(exception);
        }

       ///<summary>
        /// Return error description text by error code 
        /// </summary>        
        /// <param name="errorCode">manager error code value</param>
        public string GetErrorDescription(int errorCode)
        {
            switch (errorCode)
            {
                case ServiceManager.errorCodeBadUrl:
                    return ServiceManager.errorCodeBadUrlDescription;
                case ServiceManager.errorCodeNotConnected:
                    return ServiceManager.errorCodeNotConnected + lastSystemErrorMessage;
                case ServiceManager.errorCodeLibraryLocation:
                    return ServiceManager.errorCodeLibraryLocationDesctiption;
                case ServiceManager.errorCodeNotSlash:
                    return ServiceManager.errorCodeNotSlashDesctiption;
                case ServiceManager.errorCodeNotLibraryIsLoaded:
                    return ServiceManager.errorCodeNotLibraryIsLoaded + lastSystemErrorMessage;
                case ServiceManager.errorCodeBadServerName:
                    return ServiceManager.errorCodeBadServerNameDescription;
                case ServiceManager.errorCodeProviderDoesNotExist:
                    return ServiceManager.errorCodeProviderDoesNotExistDescription;
                case ServiceManager.errorCodeServiceDoesNotExist:
                    return ServiceManager.errorCodeServiceDoesNotExistDescription;
                case ServiceManager.errorCodeUnknownServerConnection:
                    return ServiceManager.errorCodeUnknownServerConnectionDescription + lastSystemErrorMessage;
                default:
                    return ServiceManager.errorCodeNoErrorDesctiption;
            }
        }

        /// <summary>
        /// Get value from configuration file with name "key"
        /// We strongly don't recommend using this method in your software products
        /// Use this method only for testing and demonstration applications
        /// The use of this method does not protect your data
        /// </summary>
        /// <param name="key">name of file and key</param>
        /// <returns>String value.</returns>
        public string GetKey(string key)
        {
            return Config.GetKey(key);
        }

        /// <summary>
        /// Get value from configuration file with name "key"
        /// We strongly don't recommend using this method in your software products
        /// Use this method only for testing and demonstration applications
        /// The use of this method does not protect your data
        /// </summary>
        /// <param name="key">name of file and key</param>
        /// <param name="defaultValue">The value will be used if no value with the key.</param>
        /// <returns>String value.</returns>
        public string GetKey(string key, string defaultValue)
        {
            return Config.GetKey(key, defaultValue);
        }

        /// <summary>
        /// Create file with name of the key and store key value to the file 
        /// We strongly don't recommend using this method in your software products
        /// Use this method only for testing and demonstration applications
        /// The use of this method does not protect your data        
        /// </summary>
        /// <param name="key">file and key name</param>
        /// <param name="value">value to store to the "key" file</param>
        public void SetKey(string key, string value)
        {
            Config.SetKey(key, value);
        }
		
	    ///<summary>
		///  Create new instance of GoogleAnalytics
		/// </summary>
		/// <returns>Return new GoogleAnalytics instance</returns>
		public GoogleAnalytics CreateInstanceGoogleAnalytics(string bNesisDevId,string redirectUrl)
		{
		    lastSystemErrorMessage = string.Empty;
			GoogleAnalytics resultService = CreateInstanceGoogleAnalytics();
			try
              {
			    resultService.Auth(bNesisDevId,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.Message;
             }
			return resultService;
		}

		///<summary>
		///  Create new instance of GoogleAnalytics
		/// </summary>
		/// <returns>Return new GoogleAnalytics instance</returns>
		public GoogleAnalytics CreateInstanceGoogleAnalytics()
		{
			if (!bNesisApi.SessionsManager.ClientsManager.ClientExists("GoogleAnalytics")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new GoogleAnalytics(bNesisApi);
		}

	    ///<summary>
		///  Create new instance of IISSEO
		/// </summary>
		/// <returns>Return new IISSEO instance</returns>
		public IISSEO CreateInstanceIISSEO(string bNesisDevId,string redirectUrl)
		{
		    lastSystemErrorMessage = string.Empty;
			IISSEO resultService = CreateInstanceIISSEO();
			try
              {
			    resultService.Auth(bNesisDevId,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.Message;
             }
			return resultService;
		}

		///<summary>
		///  Create new instance of IISSEO
		/// </summary>
		/// <returns>Return new IISSEO instance</returns>
		public IISSEO CreateInstanceIISSEO()
		{
			if (!bNesisApi.SessionsManager.ClientsManager.ClientExists("IISSEO")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new IISSEO(bNesisApi);
		}

	    ///<summary>
		///  Create new instance of UkrPoshta
		/// </summary>
		/// <returns>Return new UkrPoshta instance</returns>
		public UkrPoshta CreateInstanceUkrPoshta(string bNesisDevId,string redirectUrl)
		{
		    lastSystemErrorMessage = string.Empty;
			UkrPoshta resultService = CreateInstanceUkrPoshta();
			try
              {
			    resultService.Auth(bNesisDevId,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.Message;
             }
			return resultService;
		}

		///<summary>
		///  Create new instance of UkrPoshta
		/// </summary>
		/// <returns>Return new UkrPoshta instance</returns>
		public UkrPoshta CreateInstanceUkrPoshta()
		{
			if (!bNesisApi.SessionsManager.ClientsManager.ClientExists("UkrPoshta")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new UkrPoshta(bNesisApi);
		}

	    ///<summary>
		///  Create new instance of DemoService
		/// </summary>
		/// <returns>Return new DemoService instance</returns>
		public DemoService CreateInstanceDemoService(string bNesisDevId,string redirectUrl)
		{
		    lastSystemErrorMessage = string.Empty;
			DemoService resultService = CreateInstanceDemoService();
			try
              {
			    resultService.Auth(bNesisDevId,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.Message;
             }
			return resultService;
		}

		///<summary>
		///  Create new instance of DemoService
		/// </summary>
		/// <returns>Return new DemoService instance</returns>
		public DemoService CreateInstanceDemoService()
		{
			if (!bNesisApi.SessionsManager.ClientsManager.ClientExists("DemoService")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new DemoService(bNesisApi);
		}

	    ///<summary>
		///  Create new instance of Allegro
		/// </summary>
		/// <returns>Return new Allegro instance</returns>
		public Allegro CreateInstanceAllegro(string bNesisDevId,string redirectUrl)
		{
		    lastSystemErrorMessage = string.Empty;
			Allegro resultService = CreateInstanceAllegro();
			try
              {
			    resultService.Auth(bNesisDevId,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.Message;
             }
			return resultService;
		}

		///<summary>
		///  Create new instance of Allegro
		/// </summary>
		/// <returns>Return new Allegro instance</returns>
		public Allegro CreateInstanceAllegro()
		{
			if (!bNesisApi.SessionsManager.ClientsManager.ClientExists("Allegro")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new Allegro(bNesisApi);
		}

	    ///<summary>
		///  Create new instance of Amazon
		/// </summary>
		/// <returns>Return new Amazon instance</returns>
		public Amazon CreateInstanceAmazon(string bNesisDevId,string redirectUrl)
		{
		    lastSystemErrorMessage = string.Empty;
			Amazon resultService = CreateInstanceAmazon();
			try
              {
			    resultService.Auth(bNesisDevId,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.Message;
             }
			return resultService;
		}

		///<summary>
		///  Create new instance of Amazon
		/// </summary>
		/// <returns>Return new Amazon instance</returns>
		public Amazon CreateInstanceAmazon()
		{
			if (!bNesisApi.SessionsManager.ClientsManager.ClientExists("Amazon")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new Amazon(bNesisApi);
		}

	    ///<summary>
		///  Create new instance of BigCommerce
		/// </summary>
		/// <returns>Return new BigCommerce instance</returns>
		public BigCommerce CreateInstanceBigCommerce(string bNesisDevId,string redirectUrl)
		{
		    lastSystemErrorMessage = string.Empty;
			BigCommerce resultService = CreateInstanceBigCommerce();
			try
              {
			    resultService.Auth(bNesisDevId,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.Message;
             }
			return resultService;
		}

		///<summary>
		///  Create new instance of BigCommerce
		/// </summary>
		/// <returns>Return new BigCommerce instance</returns>
		public BigCommerce CreateInstanceBigCommerce()
		{
			if (!bNesisApi.SessionsManager.ClientsManager.ClientExists("BigCommerce")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new BigCommerce(bNesisApi);
		}

	    ///<summary>
		///  Create new instance of OpenCart
		/// </summary>
		/// <returns>Return new OpenCart instance</returns>
		public OpenCart CreateInstanceOpenCart(string bNesisDevId,string redirectUrl)
		{
		    lastSystemErrorMessage = string.Empty;
			OpenCart resultService = CreateInstanceOpenCart();
			try
              {
			    resultService.Auth(bNesisDevId,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.Message;
             }
			return resultService;
		}

		///<summary>
		///  Create new instance of OpenCart
		/// </summary>
		/// <returns>Return new OpenCart instance</returns>
		public OpenCart CreateInstanceOpenCart()
		{
			if (!bNesisApi.SessionsManager.ClientsManager.ClientExists("OpenCart")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new OpenCart(bNesisApi);
		}

	    ///<summary>
		///  Create new instance of PrestaShop
		/// </summary>
		/// <returns>Return new PrestaShop instance</returns>
		public PrestaShop CreateInstancePrestaShop(string bNesisDevId,string redirectUrl)
		{
		    lastSystemErrorMessage = string.Empty;
			PrestaShop resultService = CreateInstancePrestaShop();
			try
              {
			    resultService.Auth(bNesisDevId,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.Message;
             }
			return resultService;
		}

		///<summary>
		///  Create new instance of PrestaShop
		/// </summary>
		/// <returns>Return new PrestaShop instance</returns>
		public PrestaShop CreateInstancePrestaShop()
		{
			if (!bNesisApi.SessionsManager.ClientsManager.ClientExists("PrestaShop")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new PrestaShop(bNesisApi);
		}

	    ///<summary>
		///  Create new instance of Shopify
		/// </summary>
		/// <returns>Return new Shopify instance</returns>
		public Shopify CreateInstanceShopify(string bNesisDevId,string redirectUrl)
		{
		    lastSystemErrorMessage = string.Empty;
			Shopify resultService = CreateInstanceShopify();
			try
              {
			    resultService.Auth(bNesisDevId,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.Message;
             }
			return resultService;
		}

		///<summary>
		///  Create new instance of Shopify
		/// </summary>
		/// <returns>Return new Shopify instance</returns>
		public Shopify CreateInstanceShopify()
		{
			if (!bNesisApi.SessionsManager.ClientsManager.ClientExists("Shopify")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new Shopify(bNesisApi);
		}

	    ///<summary>
		///  Create new instance of BaiduBCS
		/// </summary>
		/// <returns>Return new BaiduBCS instance</returns>
		public BaiduBCS CreateInstanceBaiduBCS(string bNesisDevId,string redirectUrl)
		{
		    lastSystemErrorMessage = string.Empty;
			BaiduBCS resultService = CreateInstanceBaiduBCS();
			try
              {
			    resultService.Auth(bNesisDevId,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.Message;
             }
			return resultService;
		}

		///<summary>
		///  Create new instance of BaiduBCS
		/// </summary>
		/// <returns>Return new BaiduBCS instance</returns>
		public BaiduBCS CreateInstanceBaiduBCS()
		{
			if (!bNesisApi.SessionsManager.ClientsManager.ClientExists("BaiduBCS")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new BaiduBCS(bNesisApi);
		}

	    ///<summary>
		///  Create new instance of Box
		/// </summary>
		/// <returns>Return new Box instance</returns>
		public Box CreateInstanceBox(string bNesisDevId,string redirectUrl)
		{
		    lastSystemErrorMessage = string.Empty;
			Box resultService = CreateInstanceBox();
			try
              {
			    resultService.Auth(bNesisDevId,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.Message;
             }
			return resultService;
		}

		///<summary>
		///  Create new instance of Box
		/// </summary>
		/// <returns>Return new Box instance</returns>
		public Box CreateInstanceBox()
		{
			if (!bNesisApi.SessionsManager.ClientsManager.ClientExists("Box")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new Box(bNesisApi);
		}

	    ///<summary>
		///  Create new instance of Dropbox
		/// </summary>
		/// <returns>Return new Dropbox instance</returns>
		public Dropbox CreateInstanceDropbox(string bNesisDevId,string redirectUrl)
		{
		    lastSystemErrorMessage = string.Empty;
			Dropbox resultService = CreateInstanceDropbox();
			try
              {
			    resultService.Auth(bNesisDevId,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.Message;
             }
			return resultService;
		}

		///<summary>
		///  Create new instance of Dropbox
		/// </summary>
		/// <returns>Return new Dropbox instance</returns>
		public Dropbox CreateInstanceDropbox()
		{
			if (!bNesisApi.SessionsManager.ClientsManager.ClientExists("Dropbox")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new Dropbox(bNesisApi);
		}

	    ///<summary>
		///  Create new instance of GoogleDrive
		/// </summary>
		/// <returns>Return new GoogleDrive instance</returns>
		public GoogleDrive CreateInstanceGoogleDrive(string bNesisDevId,string redirectUrl)
		{
		    lastSystemErrorMessage = string.Empty;
			GoogleDrive resultService = CreateInstanceGoogleDrive();
			try
              {
			    resultService.Auth(bNesisDevId,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.Message;
             }
			return resultService;
		}

		///<summary>
		///  Create new instance of GoogleDrive
		/// </summary>
		/// <returns>Return new GoogleDrive instance</returns>
		public GoogleDrive CreateInstanceGoogleDrive()
		{
			if (!bNesisApi.SessionsManager.ClientsManager.ClientExists("GoogleDrive")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new GoogleDrive(bNesisApi);
		}

	    ///<summary>
		///  Create new instance of Mega
		/// </summary>
		/// <returns>Return new Mega instance</returns>
		public Mega CreateInstanceMega(string bNesisDevId,string redirectUrl)
		{
		    lastSystemErrorMessage = string.Empty;
			Mega resultService = CreateInstanceMega();
			try
              {
			    resultService.Auth(bNesisDevId,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.Message;
             }
			return resultService;
		}

		///<summary>
		///  Create new instance of Mega
		/// </summary>
		/// <returns>Return new Mega instance</returns>
		public Mega CreateInstanceMega()
		{
			if (!bNesisApi.SessionsManager.ClientsManager.ClientExists("Mega")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new Mega(bNesisApi);
		}

	    ///<summary>
		///  Create new instance of SugarSync
		/// </summary>
		/// <returns>Return new SugarSync instance</returns>
		public SugarSync CreateInstanceSugarSync(string bNesisDevId,string redirectUrl)
		{
		    lastSystemErrorMessage = string.Empty;
			SugarSync resultService = CreateInstanceSugarSync();
			try
              {
			    resultService.Auth(bNesisDevId,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.Message;
             }
			return resultService;
		}

		///<summary>
		///  Create new instance of SugarSync
		/// </summary>
		/// <returns>Return new SugarSync instance</returns>
		public SugarSync CreateInstanceSugarSync()
		{
			if (!bNesisApi.SessionsManager.ClientsManager.ClientExists("SugarSync")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new SugarSync(bNesisApi);
		}

	    ///<summary>
		///  Create new instance of Prozzoro
		/// </summary>
		/// <returns>Return new Prozzoro instance</returns>
		public Prozzoro CreateInstanceProzzoro(string bNesisDevId,string redirectUrl)
		{
		    lastSystemErrorMessage = string.Empty;
			Prozzoro resultService = CreateInstanceProzzoro();
			try
              {
			    resultService.Auth(bNesisDevId,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.Message;
             }
			return resultService;
		}

		///<summary>
		///  Create new instance of Prozzoro
		/// </summary>
		/// <returns>Return new Prozzoro instance</returns>
		public Prozzoro CreateInstanceProzzoro()
		{
			if (!bNesisApi.SessionsManager.ClientsManager.ClientExists("Prozzoro")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new Prozzoro(bNesisApi);
		}

	    ///<summary>
		///  Create new instance of LiqPay
		/// </summary>
		/// <returns>Return new LiqPay instance</returns>
		public LiqPay CreateInstanceLiqPay(string bNesisDevId,string redirectUrl)
		{
		    lastSystemErrorMessage = string.Empty;
			LiqPay resultService = CreateInstanceLiqPay();
			try
              {
			    resultService.Auth(bNesisDevId,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.Message;
             }
			return resultService;
		}

		///<summary>
		///  Create new instance of LiqPay
		/// </summary>
		/// <returns>Return new LiqPay instance</returns>
		public LiqPay CreateInstanceLiqPay()
		{
			if (!bNesisApi.SessionsManager.ClientsManager.ClientExists("LiqPay")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new LiqPay(bNesisApi);
		}

	    ///<summary>
		///  Create new instance of PayPal
		/// </summary>
		/// <returns>Return new PayPal instance</returns>
		public PayPal CreateInstancePayPal(string bNesisDevId,string redirectUrl)
		{
		    lastSystemErrorMessage = string.Empty;
			PayPal resultService = CreateInstancePayPal();
			try
              {
			    resultService.Auth(bNesisDevId,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.Message;
             }
			return resultService;
		}

		///<summary>
		///  Create new instance of PayPal
		/// </summary>
		/// <returns>Return new PayPal instance</returns>
		public PayPal CreateInstancePayPal()
		{
			if (!bNesisApi.SessionsManager.ClientsManager.ClientExists("PayPal")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new PayPal(bNesisApi);
		}

	    ///<summary>
		///  Create new instance of Stripe
		/// </summary>
		/// <returns>Return new Stripe instance</returns>
		public Stripe CreateInstanceStripe(string bNesisDevId,string redirectUrl)
		{
		    lastSystemErrorMessage = string.Empty;
			Stripe resultService = CreateInstanceStripe();
			try
              {
			    resultService.Auth(bNesisDevId,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.Message;
             }
			return resultService;
		}

		///<summary>
		///  Create new instance of Stripe
		/// </summary>
		/// <returns>Return new Stripe instance</returns>
		public Stripe CreateInstanceStripe()
		{
			if (!bNesisApi.SessionsManager.ClientsManager.ClientExists("Stripe")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new Stripe(bNesisApi);
		}

	    ///<summary>
		///  Create new instance of Facebook
		/// </summary>
		/// <returns>Return new Facebook instance</returns>
		public Facebook CreateInstanceFacebook(string bNesisDevId,string redirectUrl)
		{
		    lastSystemErrorMessage = string.Empty;
			Facebook resultService = CreateInstanceFacebook();
			try
              {
			    resultService.Auth(bNesisDevId,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.Message;
             }
			return resultService;
		}

		///<summary>
		///  Create new instance of Facebook
		/// </summary>
		/// <returns>Return new Facebook instance</returns>
		public Facebook CreateInstanceFacebook()
		{
			if (!bNesisApi.SessionsManager.ClientsManager.ClientExists("Facebook")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new Facebook(bNesisApi);
		}

	    ///<summary>
		///  Create new instance of GooglePlus
		/// </summary>
		/// <returns>Return new GooglePlus instance</returns>
		public GooglePlus CreateInstanceGooglePlus(string bNesisDevId,string redirectUrl)
		{
		    lastSystemErrorMessage = string.Empty;
			GooglePlus resultService = CreateInstanceGooglePlus();
			try
              {
			    resultService.Auth(bNesisDevId,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.Message;
             }
			return resultService;
		}

		///<summary>
		///  Create new instance of GooglePlus
		/// </summary>
		/// <returns>Return new GooglePlus instance</returns>
		public GooglePlus CreateInstanceGooglePlus()
		{
			if (!bNesisApi.SessionsManager.ClientsManager.ClientExists("GooglePlus")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new GooglePlus(bNesisApi);
		}

	    ///<summary>
		///  Create new instance of LinkedIn
		/// </summary>
		/// <returns>Return new LinkedIn instance</returns>
		public LinkedIn CreateInstanceLinkedIn(string bNesisDevId,string redirectUrl)
		{
		    lastSystemErrorMessage = string.Empty;
			LinkedIn resultService = CreateInstanceLinkedIn();
			try
              {
			    resultService.Auth(bNesisDevId,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.Message;
             }
			return resultService;
		}

		///<summary>
		///  Create new instance of LinkedIn
		/// </summary>
		/// <returns>Return new LinkedIn instance</returns>
		public LinkedIn CreateInstanceLinkedIn()
		{
			if (!bNesisApi.SessionsManager.ClientsManager.ClientExists("LinkedIn")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new LinkedIn(bNesisApi);
		}

	    ///<summary>
		///  Create new instance of VKontakte
		/// </summary>
		/// <returns>Return new VKontakte instance</returns>
		public VKontakte CreateInstanceVKontakte(string bNesisDevId,string redirectUrl)
		{
		    lastSystemErrorMessage = string.Empty;
			VKontakte resultService = CreateInstanceVKontakte();
			try
              {
			    resultService.Auth(bNesisDevId,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.Message;
             }
			return resultService;
		}

		///<summary>
		///  Create new instance of VKontakte
		/// </summary>
		/// <returns>Return new VKontakte instance</returns>
		public VKontakte CreateInstanceVKontakte()
		{
			if (!bNesisApi.SessionsManager.ClientsManager.ClientExists("VKontakte")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new VKontakte(bNesisApi);
		}

	    ///<summary>
		///  Create new instance of bNesisTestService
		/// </summary>
		/// <returns>Return new bNesisTestService instance</returns>
		public bNesisTestService CreateInstancebNesisTestService(string bNesisDevId,string redirectUrl)
		{
		    lastSystemErrorMessage = string.Empty;
			bNesisTestService resultService = CreateInstancebNesisTestService();
			try
              {
			    resultService.Auth(bNesisDevId,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.Message;
             }
			return resultService;
		}

		///<summary>
		///  Create new instance of bNesisTestService
		/// </summary>
		/// <returns>Return new bNesisTestService instance</returns>
		public bNesisTestService CreateInstancebNesisTestService()
		{
			if (!bNesisApi.SessionsManager.ClientsManager.ClientExists("bNesisTestService")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new bNesisTestService(bNesisApi);
		}

	}
}
