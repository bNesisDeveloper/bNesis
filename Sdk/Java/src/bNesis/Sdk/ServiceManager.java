package bNesis.Sdk;

import java.util.List;
import java.util.ArrayList;
import java.util.Arrays;

import bNesis.Api.bNesisApi;
import bNesis.Common.ExceptionTypes.HttpRequestException;

//import 
import bNesis.Sdk.Analytics.GoogleAnalytics.*;
import bNesis.Sdk.Other.IISSEO.*;
import bNesis.Sdk.Delivery.UkrPoshta.*;
import bNesis.Sdk.eCommerce.Allegro.*;
import bNesis.Sdk.eCommerce.Amazon.*;
import bNesis.Sdk.eCommerce.BigCommerce.*;
import bNesis.Sdk.eCommerce.OpenCart.*;
import bNesis.Sdk.eCommerce.PrestaShop.*;
import bNesis.Sdk.eCommerce.Shopify.*;
import bNesis.Sdk.FileStorages.BaiduBCS.*;
import bNesis.Sdk.FileStorages.Box.*;
import bNesis.Sdk.FileStorages.Dropbox.*;
import bNesis.Sdk.FileStorages.GoogleDrive.*;
import bNesis.Sdk.FileStorages.Mega.*;
import bNesis.Sdk.FileStorages.SugarSync.*;
import bNesis.Sdk.GovRegistry.Prozzoro.*;
import bNesis.Sdk.Payment.LiqPay.*;
import bNesis.Sdk.Payment.PayPal.*;
import bNesis.Sdk.Payment.Stripe.*;
import bNesis.Sdk.Social.Facebook.*;
import bNesis.Sdk.Social.GooglePlus.*;
import bNesis.Sdk.Social.LinkedIn.*;
import bNesis.Sdk.Social.VKontakte.*;
import bNesis.Sdk.Test.bNesisTestService.*;
import bNesis.Sdk.Demo.DemoService.*;

	/**
	 * @class 
	 * @classdesc Class to manage services 
	 */
	public class ServiceManager
	{
        /**
        * No error code constant  
        */
        public static final int errorCodeNoError = 0;
        
        /**
        * No error code  description  
        */
        public static final String errorCodeNoErrorDesctiption = "no error";

        /**
        *
        */
        public static final int errorCodeBadUrl = 1;

        /**
        * Description of bad Url error 
        */
        public static final String errorCodeBadUrlDescription = "sorry, bad service URL, missed HTTP protocol URL syntax, please check URL.";

        /**
         * Not connected error constant  
         */
        public static final int errorCodeNotConnected = 2;

        /**
         * Description of not connected error  
         */
        public static final String errorCodeNotConnectedDesctiption = "sorry, could't connect to bNesis API server, please check URL, with system message: ";

        /**
         * Library location error  constant  
         */
        public static final int errorCodeLibraryLocation = 3;

        /**
         * Description of library location error   
         */
        public static final String errorCodeLibraryLocationDesctiption = "sorry, bad library location,  please check path to library location.";

        /**
         * Not library is loaded error constant  
         */
        public static final int errorCodeNotLibraryIsLoaded = 4;

        /**
         * Description of not library is loaded error   
         */
        public static final String errorCodeNotLibraryIsLoadedDesctiption = "sorry, library is not loaded,  please check library location.";

        /**
         * No slash error constant  
         */
        public static final int errorCodeNotSlash = 5;

        /**
         * Description of provider no slash error   
         */
        public static final String errorCodeNotSlashDesctiption = "sorry, no simbol slash '/' in end of Url address";

        /**
         * Provider does not exist error constant 
         */
        public static final int errorCodeProviderDoesNotExist = 6;

        /**
         * Description of provider does not exist error 
         */
        public static final String errorCodeProviderDoesNotExistDescription = "sorry, the provider does not exist, please, check API location";

        /**
         * Service does not exist error constant
         */
        public static final int errorCodeServiceDoesNotExist = 7;

        /**
         * Description of service does not exist error 
         */
        public static final String errorCodeServiceDoesNotExistDescription = "sorry, the service does not exist, please, check API location";

        /**
         * Bad server name error constant  
         */
        public static final int errorCodeBadServerName = 8;

        /**
         * Description of bad server name error  
         */
        public static final String errorCodeBadServerNameDescription = "sorry, bad server name, please check it";

        /**
         * Unknown server connection error constant 
         */
        public static final int errorCodeUnknownServerConnection = 9;

        /**
         * Description of unknown server connection error   
         */
        public static final String errorCodeUnknownServerConnectionDescription = "sorry, unknown Server connection error";

        /**
         * Mode not supported error constant 
         */
        public static final int errorCodeModeNotSupported = 10;

        /**
         * Description of Mode not supported error   
         */
        public static final String errorCodeModeNotSupportedDescription = "sorry, this mode not supported";        

        /**
        * System Error  description message  
        */
        private String lastSystemErrorMessage = "";

		/**
        * List of providers
        */
        List<String> providers;

        private bNesisApi _bNesisApi;
		  
		/**
        * Constuctor for Thin/Rich client with no parameters
        */
        public ServiceManager()
		{
			_bNesisApi = new bNesisApi();
		}

        /**
        * Constuctor for Thin/Rich client with parameters
        * @param client Rich mode equals 1, Thin equals 2
        * @param apiLocation Connection parameter:  bNesis API HTTP server internet address for thin client, bNesis  library location for rich client
		* @throws Exception 
		*/
        public ServiceManager(ClientMode client, String apiLocation) throws Exception
		{
			this();
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

        /**
        * Method for Initialize the Thin/Rich client 
        * @param client Rich mode equals 1,  Thin equals 2
        * @param apiLocation Connection parameter:  bNesis API HTTP server internet address for thin client, bNesis  library location for rich client
		*/
        public int Initialize(ClientMode client, String apiLocation)
		{
		    switch(client)
			{
				case Thin:
                    return InitializeThin(apiLocation);                    
				case Rich:
					return InitializeRich(apiLocation);					
		    }

            return ServiceManager.errorCodeNoError;
        }

        /**
        *  Method for Initialize the Thin client 
        * @param apiLocation Connection parameter. bNesis API HTTP server internet address
        * @return bNesis SDK errorCode
		*/
        public int InitializeThin(String apiLocation)
        {
            lastSystemErrorMessage = "";
            providers = new ArrayList<String>();

            if ( (apiLocation == null) || apiLocation.isEmpty() ) return ServiceManager.errorCodeBadUrl;

            //There is no protocol name in serverURL
            if ( !apiLocation.startsWith("http") ) return ServiceManager.errorCodeBadUrl; // "Missed protocol name (http:// or https://) in serverURL"
            try
            {
                _bNesisApi.InitializeRemote(apiLocation);
				providers.addAll( Arrays.asList( _bNesisApi.SessionsManager.AuthProvidersManager.GetProviderIds()) );
            }
            catch (Exception e)
            {

				Throwable InnerException = e.getCause();
                if (InnerException != null)
                {
            
                    if (InnerException instanceof HttpRequestException)
                    {
                        lastSystemErrorMessage = e.getMessage();
                        return ServiceManager.errorCodeBadServerName;
                    }
                    else
                    {
                        lastSystemErrorMessage = e.getMessage();
                        return ServiceManager.errorCodeUnknownServerConnection;
                    }
                }
                else
                {
                    lastSystemErrorMessage = e.getMessage();
                    return ServiceManager.errorCodeNotConnected;
                }
            }

            return ServiceManager.errorCodeNoError;

        }

        /**
        * Method for Initialize the Rich client 
        * @param libraryLocation Connection parameter. bNesis DLL library location for rich client 
        * @return bNesis SDK errorCode
		*/
        public int InitializeRich(String libraryLocation)
        {
			lastSystemErrorMessage = "";
			return ServiceManager.errorCodeModeNotSupported;
			/*
            providers = new ArrayList<String>();

            if (libraryLocation == null) return ServiceManager.errorCodeLibraryLocation;
            try
            {
                _bNesisApi.InitializeLocal(libraryLocation, libraryLocation);
            }
            catch (Exception e)
            {
               if (e.HResult == 0x80070003)
                { 
                    lastSystemErrorMessage = e.getMessage();
                    return ServiceManager.errorCodeLibraryLocation;
                }
                else
                {
                    lastSystemErrorMessage = e.getMessage();
                    return ServiceManager.errorCodeNotLibraryIsLoaded;
                }
            }

            return ServiceManager.errorCodeNoError;
			*/
        }

        /**
        * Get last manager error description
        * @return error description
		*/
        public String GetLastError()
        {
            return lastSystemErrorMessage;
        }

        /**
        * Core level get last error method (Exception analize variant)
        * each service has an GetLastError API for handling errors at the top level, but there is the same Core level API 
        * for make analysis and handling Core level errors. 
        * This implementation of the method allows you to analyze exception - check  the bNesis exception class, or system
        * exception. If bNesis - get error code and information
        * @param exception exception object (from catch(Exception))
        * @return if is bNesis exception type - return string with exception message, like - service not available.
        * Return empty string if not bNesis exception
		*/
        public String GetLastError(Exception exception)
        {
            return _bNesisApi.GetLastError(exception);
        }

        /**
        * Core level get last error code method, see GetLastError for more information
        * @param exception exception object (from catch(Exception))
        * @return if is bNesis exception type - return bNesis core error code. Else return 0 (bNesisNoError)
		*/
        public String GetLastErrorCode(Exception exception)
        {
            return _bNesisApi.GetLastError(exception);
        }

        /**
        * Return error description text by error code 
        * @param errorCode manager error code value
		*/
        public String GetErrorDescription(int errorCode)
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
        public String GetKey(String key)
        {
            //return Config.GetKey(key);
			return "";
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
        public String GetKey(String key, String defaultValue)
        {
            //return Config.GetKey(key, defaultValue);
			return "";
        }

        /// <summary>
        /// Create file with name of the key and store key value to the file 
        /// We strongly don't recommend using this method in your software products
        /// Use this method only for testing and demonstration applications
        /// The use of this method does not protect your data        
        /// </summary>
        /// <param name="key">file and key name</param>
        /// <param name="value">value to store to the "key" file</param>
        public void SetKey(String key, String value)
        {
            //Config.SetKey(key, value);
        }
		
		/**
		 * Create new instance of GoogleAnalytics 
		 * @return {GoogleAnalytics} Return new GoogleAnalytics instance
		 * @throws Exception
		*/
		public GoogleAnalytics CreateInstanceGoogleAnalytics(String bNesisDevId,String clientId,String clientSecret,String redirectUrl,String[] scopes) throws Exception
		{
		    lastSystemErrorMessage = "";
			GoogleAnalytics resultService = CreateInstanceGoogleAnalytics();
			try
              {
			    resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl,scopes);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.getMessage();
             }
			return resultService;
		}

		/**
		 * Create new instance of GoogleAnalytics 
		 * @return {GoogleAnalytics} Return new GoogleAnalytics instance
		 * @throws Exception
		*/
		public GoogleAnalytics CreateInstanceGoogleAnalytics() throws Exception
		{
			if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("GoogleAnalytics")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new GoogleAnalytics(_bNesisApi);
		}
		/**
		 * Create new instance of IISSEO 
		 * @return {IISSEO} Return new IISSEO instance
		 * @throws Exception
		*/
		public IISSEO CreateInstanceIISSEO(String bNesisDevId,String redirectUrl) throws Exception
		{
		    lastSystemErrorMessage = "";
			IISSEO resultService = CreateInstanceIISSEO();
			try
              {
			    resultService.Auth(bNesisDevId,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.getMessage();
             }
			return resultService;
		}

		/**
		 * Create new instance of IISSEO 
		 * @return {IISSEO} Return new IISSEO instance
		 * @throws Exception
		*/
		public IISSEO CreateInstanceIISSEO() throws Exception
		{
			if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("IISSEO")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new IISSEO(_bNesisApi);
		}
		/**
		 * Create new instance of UkrPoshta 
		 * @return {UkrPoshta} Return new UkrPoshta instance
		 * @throws Exception
		*/
		public UkrPoshta CreateInstanceUkrPoshta(String bNesisDevId,String clientId,String clientSecret,String redirectUrl) throws Exception
		{
		    lastSystemErrorMessage = "";
			UkrPoshta resultService = CreateInstanceUkrPoshta();
			try
              {
			    resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.getMessage();
             }
			return resultService;
		}

		/**
		 * Create new instance of UkrPoshta 
		 * @return {UkrPoshta} Return new UkrPoshta instance
		 * @throws Exception
		*/
		public UkrPoshta CreateInstanceUkrPoshta() throws Exception
		{
			if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("UkrPoshta")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new UkrPoshta(_bNesisApi);
		}
		/**
		 * Create new instance of Allegro 
		 * @return {Allegro} Return new Allegro instance
		 * @throws Exception
		*/
		public Allegro CreateInstanceAllegro(String bNesisDevId,String clientId,String clientSecret,String redirectUrl,String[] scopes,Boolean isSandbox,String data) throws Exception
		{
		    lastSystemErrorMessage = "";
			Allegro resultService = CreateInstanceAllegro();
			try
              {
			    resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl,scopes,isSandbox,data);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.getMessage();
             }
			return resultService;
		}

		/**
		 * Create new instance of Allegro 
		 * @return {Allegro} Return new Allegro instance
		 * @throws Exception
		*/
		public Allegro CreateInstanceAllegro() throws Exception
		{
			if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("Allegro")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new Allegro(_bNesisApi);
		}
		/**
		 * Create new instance of Amazon 
		 * @return {Amazon} Return new Amazon instance
		 * @throws Exception
		*/
		public Amazon CreateInstanceAmazon(String bNesisDevId,String clientId,String clientSecret,String redirectUrl) throws Exception
		{
		    lastSystemErrorMessage = "";
			Amazon resultService = CreateInstanceAmazon();
			try
              {
			    resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.getMessage();
             }
			return resultService;
		}

		/**
		 * Create new instance of Amazon 
		 * @return {Amazon} Return new Amazon instance
		 * @throws Exception
		*/
		public Amazon CreateInstanceAmazon() throws Exception
		{
			if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("Amazon")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new Amazon(_bNesisApi);
		}
		/**
		 * Create new instance of BigCommerce 
		 * @return {BigCommerce} Return new BigCommerce instance
		 * @throws Exception
		*/
		public BigCommerce CreateInstanceBigCommerce(String bNesisDevId,String redirectUrl,String login,String password,String data) throws Exception
		{
		    lastSystemErrorMessage = "";
			BigCommerce resultService = CreateInstanceBigCommerce();
			try
              {
			    resultService.Auth(bNesisDevId,redirectUrl,login,password,data);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.getMessage();
             }
			return resultService;
		}

		/**
		 * Create new instance of BigCommerce 
		 * @return {BigCommerce} Return new BigCommerce instance
		 * @throws Exception
		*/
		public BigCommerce CreateInstanceBigCommerce() throws Exception
		{
			if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("BigCommerce")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new BigCommerce(_bNesisApi);
		}
		/**
		 * Create new instance of OpenCart 
		 * @return {OpenCart} Return new OpenCart instance
		 * @throws Exception
		*/
		public OpenCart CreateInstanceOpenCart(String bNesisDevId,String clientId,String clientSecret,String redirectUrl,String serviceUrl) throws Exception
		{
		    lastSystemErrorMessage = "";
			OpenCart resultService = CreateInstanceOpenCart();
			try
              {
			    resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl,serviceUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.getMessage();
             }
			return resultService;
		}

		/**
		 * Create new instance of OpenCart 
		 * @return {OpenCart} Return new OpenCart instance
		 * @throws Exception
		*/
		public OpenCart CreateInstanceOpenCart() throws Exception
		{
			if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("OpenCart")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new OpenCart(_bNesisApi);
		}
		/**
		 * Create new instance of PrestaShop 
		 * @return {PrestaShop} Return new PrestaShop instance
		 * @throws Exception
		*/
		public PrestaShop CreateInstancePrestaShop(String bNesisDevId,String redirectUrl,String login,String serviceUrl) throws Exception
		{
		    lastSystemErrorMessage = "";
			PrestaShop resultService = CreateInstancePrestaShop();
			try
              {
			    resultService.Auth(bNesisDevId,redirectUrl,login,serviceUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.getMessage();
             }
			return resultService;
		}

		/**
		 * Create new instance of PrestaShop 
		 * @return {PrestaShop} Return new PrestaShop instance
		 * @throws Exception
		*/
		public PrestaShop CreateInstancePrestaShop() throws Exception
		{
			if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("PrestaShop")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new PrestaShop(_bNesisApi);
		}
		/**
		 * Create new instance of Shopify 
		 * @return {Shopify} Return new Shopify instance
		 * @throws Exception
		*/
		public Shopify CreateInstanceShopify(String bNesisDevId,String clientId,String clientSecret,String redirectUrl,String[] scopes) throws Exception
		{
		    lastSystemErrorMessage = "";
			Shopify resultService = CreateInstanceShopify();
			try
              {
			    resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl,scopes);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.getMessage();
             }
			return resultService;
		}

		/**
		 * Create new instance of Shopify 
		 * @return {Shopify} Return new Shopify instance
		 * @throws Exception
		*/
		public Shopify CreateInstanceShopify() throws Exception
		{
			if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("Shopify")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new Shopify(_bNesisApi);
		}
		/**
		 * Create new instance of BaiduBCS 
		 * @return {BaiduBCS} Return new BaiduBCS instance
		 * @throws Exception
		*/
		public BaiduBCS CreateInstanceBaiduBCS(String bNesisDevId,String clientId,String clientSecret,String redirectUrl) throws Exception
		{
		    lastSystemErrorMessage = "";
			BaiduBCS resultService = CreateInstanceBaiduBCS();
			try
              {
			    resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.getMessage();
             }
			return resultService;
		}

		/**
		 * Create new instance of BaiduBCS 
		 * @return {BaiduBCS} Return new BaiduBCS instance
		 * @throws Exception
		*/
		public BaiduBCS CreateInstanceBaiduBCS() throws Exception
		{
			if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("BaiduBCS")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new BaiduBCS(_bNesisApi);
		}
		/**
		 * Create new instance of Box 
		 * @return {Box} Return new Box instance
		 * @throws Exception
		*/
		public Box CreateInstanceBox(String bNesisDevId,String clientId,String clientSecret,String redirectUrl) throws Exception
		{
		    lastSystemErrorMessage = "";
			Box resultService = CreateInstanceBox();
			try
              {
			    resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.getMessage();
             }
			return resultService;
		}

		/**
		 * Create new instance of Box 
		 * @return {Box} Return new Box instance
		 * @throws Exception
		*/
		public Box CreateInstanceBox() throws Exception
		{
			if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("Box")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new Box(_bNesisApi);
		}
		/**
		 * Create new instance of Dropbox 
		 * @return {Dropbox} Return new Dropbox instance
		 * @throws Exception
		*/
		public Dropbox CreateInstanceDropbox(String bNesisDevId,String clientId,String clientSecret,String redirectUrl) throws Exception
		{
		    lastSystemErrorMessage = "";
			Dropbox resultService = CreateInstanceDropbox();
			try
              {
			    resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.getMessage();
             }
			return resultService;
		}

		/**
		 * Create new instance of Dropbox 
		 * @return {Dropbox} Return new Dropbox instance
		 * @throws Exception
		*/
		public Dropbox CreateInstanceDropbox() throws Exception
		{
			if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("Dropbox")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new Dropbox(_bNesisApi);
		}
		/**
		 * Create new instance of GoogleDrive 
		 * @return {GoogleDrive} Return new GoogleDrive instance
		 * @throws Exception
		*/
		public GoogleDrive CreateInstanceGoogleDrive(String bNesisDevId,String clientId,String clientSecret,String redirectUrl,String[] scopes) throws Exception
		{
		    lastSystemErrorMessage = "";
			GoogleDrive resultService = CreateInstanceGoogleDrive();
			try
              {
			    resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl,scopes);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.getMessage();
             }
			return resultService;
		}

		/**
		 * Create new instance of GoogleDrive 
		 * @return {GoogleDrive} Return new GoogleDrive instance
		 * @throws Exception
		*/
		public GoogleDrive CreateInstanceGoogleDrive() throws Exception
		{
			if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("GoogleDrive")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new GoogleDrive(_bNesisApi);
		}
		/**
		 * Create new instance of Mega 
		 * @return {Mega} Return new Mega instance
		 * @throws Exception
		*/
		public Mega CreateInstanceMega(String bNesisDevId,String clientSecret,String redirectUrl,String login,String password) throws Exception
		{
		    lastSystemErrorMessage = "";
			Mega resultService = CreateInstanceMega();
			try
              {
			    resultService.Auth(bNesisDevId,clientSecret,redirectUrl,login,password);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.getMessage();
             }
			return resultService;
		}

		/**
		 * Create new instance of Mega 
		 * @return {Mega} Return new Mega instance
		 * @throws Exception
		*/
		public Mega CreateInstanceMega() throws Exception
		{
			if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("Mega")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new Mega(_bNesisApi);
		}
		/**
		 * Create new instance of SugarSync 
		 * @return {SugarSync} Return new SugarSync instance
		 * @throws Exception
		*/
		public SugarSync CreateInstanceSugarSync(String bNesisDevId,String clientId,String clientSecret,String redirectUrl,String login,String password,String data) throws Exception
		{
		    lastSystemErrorMessage = "";
			SugarSync resultService = CreateInstanceSugarSync();
			try
              {
			    resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl,login,password,data);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.getMessage();
             }
			return resultService;
		}

		/**
		 * Create new instance of SugarSync 
		 * @return {SugarSync} Return new SugarSync instance
		 * @throws Exception
		*/
		public SugarSync CreateInstanceSugarSync() throws Exception
		{
			if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("SugarSync")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new SugarSync(_bNesisApi);
		}
		/**
		 * Create new instance of Prozzoro 
		 * @return {Prozzoro} Return new Prozzoro instance
		 * @throws Exception
		*/
		public Prozzoro CreateInstanceProzzoro(String bNesisDevId,String redirectUrl) throws Exception
		{
		    lastSystemErrorMessage = "";
			Prozzoro resultService = CreateInstanceProzzoro();
			try
              {
			    resultService.Auth(bNesisDevId,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.getMessage();
             }
			return resultService;
		}

		/**
		 * Create new instance of Prozzoro 
		 * @return {Prozzoro} Return new Prozzoro instance
		 * @throws Exception
		*/
		public Prozzoro CreateInstanceProzzoro() throws Exception
		{
			if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("Prozzoro")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new Prozzoro(_bNesisApi);
		}
		/**
		 * Create new instance of LiqPay 
		 * @return {LiqPay} Return new LiqPay instance
		 * @throws Exception
		*/
		public LiqPay CreateInstanceLiqPay(String bNesisDevId,String clientId,String clientSecret,String redirectUrl,String login) throws Exception
		{
		    lastSystemErrorMessage = "";
			LiqPay resultService = CreateInstanceLiqPay();
			try
              {
			    resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl,login);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.getMessage();
             }
			return resultService;
		}

		/**
		 * Create new instance of LiqPay 
		 * @return {LiqPay} Return new LiqPay instance
		 * @throws Exception
		*/
		public LiqPay CreateInstanceLiqPay() throws Exception
		{
			if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("LiqPay")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new LiqPay(_bNesisApi);
		}
		/**
		 * Create new instance of PayPal 
		 * @return {PayPal} Return new PayPal instance
		 * @throws Exception
		*/
		public PayPal CreateInstancePayPal(String bNesisDevId,String clientId,String clientSecret,String redirectUrl) throws Exception
		{
		    lastSystemErrorMessage = "";
			PayPal resultService = CreateInstancePayPal();
			try
              {
			    resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.getMessage();
             }
			return resultService;
		}

		/**
		 * Create new instance of PayPal 
		 * @return {PayPal} Return new PayPal instance
		 * @throws Exception
		*/
		public PayPal CreateInstancePayPal() throws Exception
		{
			if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("PayPal")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new PayPal(_bNesisApi);
		}
		/**
		 * Create new instance of Stripe 
		 * @return {Stripe} Return new Stripe instance
		 * @throws Exception
		*/
		public Stripe CreateInstanceStripe(String bNesisDevId,String clientId,String clientSecret,String redirectUrl,String[] scopes) throws Exception
		{
		    lastSystemErrorMessage = "";
			Stripe resultService = CreateInstanceStripe();
			try
              {
			    resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl,scopes);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.getMessage();
             }
			return resultService;
		}

		/**
		 * Create new instance of Stripe 
		 * @return {Stripe} Return new Stripe instance
		 * @throws Exception
		*/
		public Stripe CreateInstanceStripe() throws Exception
		{
			if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("Stripe")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new Stripe(_bNesisApi);
		}
		/**
		 * Create new instance of Facebook 
		 * @return {Facebook} Return new Facebook instance
		 * @throws Exception
		*/
		public Facebook CreateInstanceFacebook(String bNesisDevId,String clientId,String clientSecret,String redirectUrl,String[] scopes) throws Exception
		{
		    lastSystemErrorMessage = "";
			Facebook resultService = CreateInstanceFacebook();
			try
              {
			    resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl,scopes);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.getMessage();
             }
			return resultService;
		}

		/**
		 * Create new instance of Facebook 
		 * @return {Facebook} Return new Facebook instance
		 * @throws Exception
		*/
		public Facebook CreateInstanceFacebook() throws Exception
		{
			if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("Facebook")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new Facebook(_bNesisApi);
		}
		/**
		 * Create new instance of GooglePlus 
		 * @return {GooglePlus} Return new GooglePlus instance
		 * @throws Exception
		*/
		public GooglePlus CreateInstanceGooglePlus(String bNesisDevId,String clientId,String clientSecret,String redirectUrl,String[] scopes,String data) throws Exception
		{
		    lastSystemErrorMessage = "";
			GooglePlus resultService = CreateInstanceGooglePlus();
			try
              {
			    resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl,scopes,data);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.getMessage();
             }
			return resultService;
		}

		/**
		 * Create new instance of GooglePlus 
		 * @return {GooglePlus} Return new GooglePlus instance
		 * @throws Exception
		*/
		public GooglePlus CreateInstanceGooglePlus() throws Exception
		{
			if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("GooglePlus")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new GooglePlus(_bNesisApi);
		}
		/**
		 * Create new instance of LinkedIn 
		 * @return {LinkedIn} Return new LinkedIn instance
		 * @throws Exception
		*/
		public LinkedIn CreateInstanceLinkedIn(String bNesisDevId,String clientId,String clientSecret,String redirectUrl,String[] scopes) throws Exception
		{
		    lastSystemErrorMessage = "";
			LinkedIn resultService = CreateInstanceLinkedIn();
			try
              {
			    resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl,scopes);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.getMessage();
             }
			return resultService;
		}

		/**
		 * Create new instance of LinkedIn 
		 * @return {LinkedIn} Return new LinkedIn instance
		 * @throws Exception
		*/
		public LinkedIn CreateInstanceLinkedIn() throws Exception
		{
			if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("LinkedIn")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new LinkedIn(_bNesisApi);
		}
		/**
		 * Create new instance of VKontakte 
		 * @return {VKontakte} Return new VKontakte instance
		 * @throws Exception
		*/
		public VKontakte CreateInstanceVKontakte(String bNesisDevId,String clientId,String clientSecret,String redirectUrl) throws Exception
		{
		    lastSystemErrorMessage = "";
			VKontakte resultService = CreateInstanceVKontakte();
			try
              {
			    resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.getMessage();
             }
			return resultService;
		}

		/**
		 * Create new instance of VKontakte 
		 * @return {VKontakte} Return new VKontakte instance
		 * @throws Exception
		*/
		public VKontakte CreateInstanceVKontakte() throws Exception
		{
			if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("VKontakte")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new VKontakte(_bNesisApi);
		}
		/**
		 * Create new instance of bNesisTestService 
		 * @return {bNesisTestService} Return new bNesisTestService instance
		 * @throws Exception
		*/
		public bNesisTestService CreateInstancebNesisTestService(String bNesisDevId,String clientId,String clientSecret,String redirectUrl) throws Exception
		{
		    lastSystemErrorMessage = "";
			bNesisTestService resultService = CreateInstancebNesisTestService();
			try
              {
			    resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.getMessage();
             }
			return resultService;
		}

		/**
		 * Create new instance of bNesisTestService 
		 * @return {bNesisTestService} Return new bNesisTestService instance
		 * @throws Exception
		*/
		public bNesisTestService CreateInstancebNesisTestService() throws Exception
		{
			if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("bNesisTestService")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new bNesisTestService(_bNesisApi);
		}
		/**
		 * Create new instance of DemoService 
		 * @return {DemoService} Return new DemoService instance
		 * @throws Exception
		*/
		public DemoService CreateInstanceDemoService(String bNesisDevId,String redirectUrl) throws Exception
		{
		    lastSystemErrorMessage = "";
			DemoService resultService = CreateInstanceDemoService();
			try
              {
			    resultService.Auth(bNesisDevId,redirectUrl);
			  } 
            catch (Exception e)
              {
                lastSystemErrorMessage = e.getMessage();
             }
			return resultService;
		}

		/**
		 * Create new instance of DemoService 
		 * @return {DemoService} Return new DemoService instance
		 * @throws Exception
		*/
		public DemoService CreateInstanceDemoService() throws Exception
		{
			if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("DemoService")) throw new Exception(ServiceManager.errorCodeServiceDoesNotExistDescription);
			return new DemoService(_bNesisApi);
		}
	}

