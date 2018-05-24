
/**
 * Client mode constants  
 * @readonly
 * @enum {number}
 */
ClientMode =
{ 
	/** 
	* set bNesis Rich client
	* @type{number} 
	*/
    Rich: 1,
	  
	/** 
	* set bNesis Thin client
	* @type{number} 
	*/
    Thin: 2
}


/**
 * @class 
 * @classdesc Class to manage services 
 * @param {ClientMode} client Rich mode equals 1, Thin equals 2
 * @param {string} apiLocation Connection parameter:  bNesis API HTTP server internet address for thin client, bNesis  library location for rich client
 * @property {number} this.errorCodeNoError - No error code constant
 * @property {string} this.errorCodeNoErrorDesctiption - No error code  description
 * @property {number} this.errorCodeBadUrl - Bad Url error constant
 * @property {string} this.errorCodeBadUrlDescription - Description of bad Url error
 * @property {number} this.errorCodeNotConnected - Not connected error constant
 * @property {string} this.errorCodeNotConnectedDesctiption - Description of not connected error
 */
function ServiceManager(client, apiLocation) {
	if (!(this instanceof ServiceManager))
		return new ServiceManager(client, apiLocation);

	/**
     * No error code constant
	 * @const
     * @type {Number}
     */
    this.errorCodeNoError = 0;
        
    /**
     * No error code  description
     * @const
     * @type {String}
     */
    this.errorCodeNoErrorDesctiption = "no error";

	/**
     * Bad Url error constant  
	 * @const
     * @type {Number}
     */
    this.errorCodeBadUrl = 1;

    /**
     * Description of bad Url error
     * @const
     * @type {String}
     */
    this.errorCodeBadUrlDescription = "sorry, bad service URL, missed HTTP protocol URL syntax, please check URL.";

	/**
     * Not connected error constant
	 * @const
     * @type {Number}
     */
    this.errorCodeNotConnected = 2;

    /**
     * Description of not connected error
     * @const
     * @type {String}
     */
    this.errorCodeNotConnectedDesctiption = "sorry, could't connect to bNesis API server, please check URL, with system message: ";

	/**
     * Library location error constant
	 * @const
     * @type {Number}
     */
    this.errorCodeLibraryLocation = 3;

    /**
     * Description of library location error
     * @const
     * @type {String}
     */
    this.errorCodeLibraryLocationDesctiption = "sorry, bad library location,  please check path to library location.";

	/**
     * Not library is loaded error constant
	 * @const
     * @type {Number}
     */
    this.errorCodeNotLibraryIsLoaded = 4;

	/**
     * Description of not library is loaded error
     * @const
     * @type {String}
     */
    this.errorCodeNotLibraryIsLoadedDesctiption = "sorry, library is not loaded,  please check library location.";

	/**
     * No slash error constant
	 * @const
     * @type {Number}
     */
    this.errorCodeNotSlash = 5;

	/**
     * Description of provider no slash error
     * @const
     * @type {String}
     */
    this.errorCodeNotSlashDesctiption = "sorry, no symbol slash '/' in end of Url address";

	/**
     * Provider does not exist error constant
	 * @const
     * @type {Number}
     */
    this.errorCodeProviderDoesNotExist = 6;

	/**
     * Description of provider does not exist error
     * @const
     * @type {String}
     */
    this.errorCodeProviderDoesNotExistDescription = "sorry, the provider does not exist, please, check API location";

	/**
     * Service does not exist error constant
	 * @const
     * @type {Number}
     */
    this.errorCodeServiceDoesNotExist = 7;

	/**
     * Description of service does not exist error
     * @const
     * @type {String}
     */
    this.errorCodeServiceDoesNotExistDescription = "sorry, the service does not exist, please, check API location";

	/**
     * Bad server name error constant
	 * @const
     * @type {Number}
     */
    this.errorCodeBadServerName = 8;

	/**
     * Description of bad server name error
     * @const
     * @type {String}
     */
    this.errorCodeBadServerNameDescription = "sorry, bad server name, please check it";

	/**
     * Unknown server connection error constant
	 * @const
     * @type {Number}
     */
    this.errorCodeUnknownServerConnection = 9;

	/**
     * Description of unknown server connection error
     * @const
     * @type {String}
     */
    this.errorCodeUnknownServerConnectionDescription = "sorry, unknown Server connection error";

	/**
     * System Error  description message
     * @type {String}
     */
    var lastSystemErrorMessage = "";

	/**
     * List of providers
     * @type {String}
     */
    var providers = null;

	var _bNesisApi = new bNesisApi();

	/**
	 *  Method for Initialize the Thin/Rich client 
	 * @param {ClientMode} clientMode - Rich mode equals 1,  Thin equals 2
	 * @param {String} apiLocation - Connection parameter:  bNesis API HTTP server internet address for thin client, bNesis  library location for rich client
	 * @return {number} bNesis SDK errorCode
	*/
    this.Initialize = function (clientMode, apiLocation) {
        switch (clientMode) {
            case ClientMode.Rich:
                //return this.InitializeRich(apiLocation);
                break;
            case ClientMode.Thin:
                return this.InitializeThin(apiLocation);
        }
        return this.errorCodeNoError;
    }

	/**
	 * Method for Initialize the Thin client 
	 * @param {String} apiLocation - Connection parameter. bNesis API HTTP server internet address
	 * @return {number} bNesis SDK errorCode
	*/
    this.InitializeThin = function (apiLocation) {
		
		lastSystemErrorMessage = "";

		if ((apiLocation === null) || (typeof apiLocation !== "string") || (apiLocation.length === 0)) return this.errorCodeBadUrl;

		//There is no protocol name in serverURL
		if (apiLocation.indexOf("http") === -1 ) return this.errorCodeBadUrl; // "Missed protocol name (http:// or https://) in serverURL"
		//The symbol "/" is missed in the end of serverURL
		if (apiLocation.substring(apiLocation.length - 1).indexOf("/") ===-1) return this.errorCodeNotSlash; // "Missed symbol / in the end of serverURL";
		//providers = [];  // FFR
		try{
			_bNesisApi.InitializeRemote(apiLocation);			
 			providers = _bNesisApi.SessionsManager.AuthProvidersManager.GetProviderIds();
            if(!Array.isArray(providers)){
                if (providers instanceof DOMException)
                {
                    var error = providers;
                    providers = null;
                    return this.errorCodeNotConnected;
                }		
			}
		}
		catch(e){
            if (e.message !== null && e.message !== undefined) {
                console.log(e.message);
                lastSystemErrorMessage = e.message;
            }
          return this.errorCodeNotConnected;
		}
        return this.errorCodeNoError;
    }

	/**
	 * Method for Initialize the Rich client 
	 * @param {String} apiLocation - Connection parameter. bNesis DLL library location for rich client
	 * @return {number} bNesis SDK errorCode
	*/
    this.InitializeRich = function (apiLocation) {
		lastSystemErrorMessage = "";

        return "Rich mode is not supported";
    }

    /**
     * Get last manager error description | Get LastError from service
     * @param {exception} exception exception object (from catch(Exception))
     * @return error description | bNesis ErrorInfo with error code and message
	 */
    this.GetLastError = function (errorParameter) {
		if (arguments.length === 0)
			return lastSystemErrorMessage;	
		if(arguments.length === 1){
			if(errorParameter !== null && errorParameter !== undefined){
				if(errorParameter.stack && errorParameter.message 
					&& typeof errorParameter.stack === "string" && typeof errorParameter.message === "string" ){
					var exception = errorParameter;
					return _bNesisApi.GetLastError(exception);
				}
			}
		}
		else 
			return "Wrong GetLastError number of parameters";
        return "Wrong GetLastError parameter";
    }

    /**
     * Core level get last error code method, see GetLastError for more information
     * @param {exception} exception exception object (from catch(Exception))
     * @return error if is bNesis exception type - return bNesis core error code. Else return 0 (bNesisNoError)
	 */
    this.GetLastErrorCode = function (providerId, errorParameter) {
		if(arguments.length === 1){
			if(errorParameter !== null && errorParameter !== undefined){
				if(errorParameter.stack && errorParameter.message 
					&& typeof errorParameter.stack === "string" && typeof errorParameter.message === "string" ){
					var exception = errorParameter;
					return _bNesisApi.GetLastError(exception);
				}
			}
		}
		else 
			return "Wrong GetLastError number of parameters";
        return "Wrong GetLastError parameter";
    }

    /**
     * Return error description text by error code 
     * @param {number} errorCode manager error code value
     * @return manager error code value
	 */
    this.GetErrorDescription = function (errorCode) {
            switch (errorCode)
            {
                case ServiceManager.errorCodeBadUrl:
                    return ServiceManager.errorCodeBadUrlDescription;
                case ServiceManager.errorCodeNotConnected:
                    return ServiceManager.errorCodeNotConnectedDesctiption +": " + lastSystemErrorMessage;
                case ServiceManager.errorCodeLibraryLocation:
                    return ServiceManager.errorCodeLibraryLocationDesctiption;
                case ServiceManager.errorCodeNotSlash:
                    return ServiceManager.errorCodeNotSlashDesctiption;
                case ServiceManager.errorCodeNotLibraryIsLoaded:
                    return ServiceManager.errorCodeNotLibraryIsLoadedDesctiption + ": " + lastSystemErrorMessage;
                case ServiceManager.errorCodeBadServerName:
                    return ServiceManager.errorCodeBadServerNameDescription;
                case ServiceManager.errorCodeProviderDoesNotExist:
                    return ServiceManager.errorCodeProviderDoesNotExistDescription;
                case ServiceManager.errorCodeServiceDoesNotExist:
                    return ServiceManager.errorCodeServiceDoesNotExistDescription;
                case ServiceManager.errorCodeUnknownServerConnection:
                    return ServiceManager.errorCodeUnknownServerConnectionDescription + ": " + lastSystemErrorMessage;
                default:
                    return ServiceManager.errorCodeNoErrorDesctiption;
            }
    }    

	/**
	 * Create new instance of GoogleAnalytics 
	 * @return {GoogleAnalytics} Return new GoogleAnalytics instance
	*/
	this.CreateInstanceGoogleAnalytics = function (bNesisDevId,clientId,clientSecret,redirectUrl,scopes) {
		if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("GoogleAnalytics"))
			 throw this.errorCodeServiceDoesNotExistDescription;
		lastSystemErrorMessage = "";
		var resultService = new GoogleAnalytics(_bNesisApi);
		if (arguments.length > 0)
			try {
				resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl,scopes);
			}
			catch (e) {
				lastSystemErrorMessage = e.Message;
			}
		return resultService;
	}
	/**
	 * Create new instance of IISSEO 
	 * @return {IISSEO} Return new IISSEO instance
	*/
	this.CreateInstanceIISSEO = function (bNesisDevId,redirectUrl) {
		if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("IISSEO"))
			 throw this.errorCodeServiceDoesNotExistDescription;
		lastSystemErrorMessage = "";
		var resultService = new IISSEO(_bNesisApi);
		if (arguments.length > 0)
			try {
				resultService.Auth(bNesisDevId,redirectUrl);
			}
			catch (e) {
				lastSystemErrorMessage = e.Message;
			}
		return resultService;
	}
	/**
	 * Create new instance of UkrPoshta 
	 * @return {UkrPoshta} Return new UkrPoshta instance
	*/
	this.CreateInstanceUkrPoshta = function (bNesisDevId,clientId,clientSecret,redirectUrl) {
		if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("UkrPoshta"))
			 throw this.errorCodeServiceDoesNotExistDescription;
		lastSystemErrorMessage = "";
		var resultService = new UkrPoshta(_bNesisApi);
		if (arguments.length > 0)
			try {
				resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl);
			}
			catch (e) {
				lastSystemErrorMessage = e.Message;
			}
		return resultService;
	}
	/**
	 * Create new instance of DemoService 
	 * @return {DemoService} Return new DemoService instance
	*/
	this.CreateInstanceDemoService = function (bNesisDevId,redirectUrl) {
		if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("DemoService"))
			 throw this.errorCodeServiceDoesNotExistDescription;
		lastSystemErrorMessage = "";
		var resultService = new DemoService(_bNesisApi);
		if (arguments.length > 0)
			try {
				resultService.Auth(bNesisDevId,redirectUrl);
			}
			catch (e) {
				lastSystemErrorMessage = e.Message;
			}
		return resultService;
	}
	/**
	 * Create new instance of Allegro 
	 * @return {Allegro} Return new Allegro instance
	*/
	this.CreateInstanceAllegro = function (bNesisDevId,clientId,clientSecret,redirectUrl,scopes,isSandbox,data) {
		if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("Allegro"))
			 throw this.errorCodeServiceDoesNotExistDescription;
		lastSystemErrorMessage = "";
		var resultService = new Allegro(_bNesisApi);
		if (arguments.length > 0)
			try {
				resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl,scopes,isSandbox,data);
			}
			catch (e) {
				lastSystemErrorMessage = e.Message;
			}
		return resultService;
	}
	/**
	 * Create new instance of Amazon 
	 * @return {Amazon} Return new Amazon instance
	*/
	this.CreateInstanceAmazon = function (bNesisDevId,clientId,clientSecret,redirectUrl) {
		if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("Amazon"))
			 throw this.errorCodeServiceDoesNotExistDescription;
		lastSystemErrorMessage = "";
		var resultService = new Amazon(_bNesisApi);
		if (arguments.length > 0)
			try {
				resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl);
			}
			catch (e) {
				lastSystemErrorMessage = e.Message;
			}
		return resultService;
	}
	/**
	 * Create new instance of BigCommerce 
	 * @return {BigCommerce} Return new BigCommerce instance
	*/
	this.CreateInstanceBigCommerce = function (bNesisDevId,redirectUrl,login,password,data) {
		if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("BigCommerce"))
			 throw this.errorCodeServiceDoesNotExistDescription;
		lastSystemErrorMessage = "";
		var resultService = new BigCommerce(_bNesisApi);
		if (arguments.length > 0)
			try {
				resultService.Auth(bNesisDevId,redirectUrl,login,password,data);
			}
			catch (e) {
				lastSystemErrorMessage = e.Message;
			}
		return resultService;
	}
	/**
	 * Create new instance of OpenCart 
	 * @return {OpenCart} Return new OpenCart instance
	*/
	this.CreateInstanceOpenCart = function (bNesisDevId,clientId,clientSecret,redirectUrl,serviceUrl) {
		if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("OpenCart"))
			 throw this.errorCodeServiceDoesNotExistDescription;
		lastSystemErrorMessage = "";
		var resultService = new OpenCart(_bNesisApi);
		if (arguments.length > 0)
			try {
				resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl,serviceUrl);
			}
			catch (e) {
				lastSystemErrorMessage = e.Message;
			}
		return resultService;
	}
	/**
	 * Create new instance of PrestaShop 
	 * @return {PrestaShop} Return new PrestaShop instance
	*/
	this.CreateInstancePrestaShop = function (bNesisDevId,redirectUrl,login,serviceUrl) {
		if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("PrestaShop"))
			 throw this.errorCodeServiceDoesNotExistDescription;
		lastSystemErrorMessage = "";
		var resultService = new PrestaShop(_bNesisApi);
		if (arguments.length > 0)
			try {
				resultService.Auth(bNesisDevId,redirectUrl,login,serviceUrl);
			}
			catch (e) {
				lastSystemErrorMessage = e.Message;
			}
		return resultService;
	}
	/**
	 * Create new instance of Shopify 
	 * @return {Shopify} Return new Shopify instance
	*/
	this.CreateInstanceShopify = function (bNesisDevId,clientId,clientSecret,redirectUrl,scopes,data) {
		if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("Shopify"))
			 throw this.errorCodeServiceDoesNotExistDescription;
		lastSystemErrorMessage = "";
		var resultService = new Shopify(_bNesisApi);
		if (arguments.length > 0)
			try {
				resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl,scopes,data);
			}
			catch (e) {
				lastSystemErrorMessage = e.Message;
			}
		return resultService;
	}
	/**
	 * Create new instance of BaiduBCS 
	 * @return {BaiduBCS} Return new BaiduBCS instance
	*/
	this.CreateInstanceBaiduBCS = function (bNesisDevId,clientId,clientSecret,redirectUrl) {
		if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("BaiduBCS"))
			 throw this.errorCodeServiceDoesNotExistDescription;
		lastSystemErrorMessage = "";
		var resultService = new BaiduBCS(_bNesisApi);
		if (arguments.length > 0)
			try {
				resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl);
			}
			catch (e) {
				lastSystemErrorMessage = e.Message;
			}
		return resultService;
	}
	/**
	 * Create new instance of Box 
	 * @return {Box} Return new Box instance
	*/
	this.CreateInstanceBox = function (bNesisDevId,clientId,clientSecret,redirectUrl) {
		if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("Box"))
			 throw this.errorCodeServiceDoesNotExistDescription;
		lastSystemErrorMessage = "";
		var resultService = new Box(_bNesisApi);
		if (arguments.length > 0)
			try {
				resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl);
			}
			catch (e) {
				lastSystemErrorMessage = e.Message;
			}
		return resultService;
	}
	/**
	 * Create new instance of Dropbox 
	 * @return {Dropbox} Return new Dropbox instance
	*/
	this.CreateInstanceDropbox = function (bNesisDevId,clientId,clientSecret,redirectUrl) {
		if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("Dropbox"))
			 throw this.errorCodeServiceDoesNotExistDescription;
		lastSystemErrorMessage = "";
		var resultService = new Dropbox(_bNesisApi);
		if (arguments.length > 0)
			try {
				resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl);
			}
			catch (e) {
				lastSystemErrorMessage = e.Message;
			}
		return resultService;
	}
	/**
	 * Create new instance of GoogleDrive 
	 * @return {GoogleDrive} Return new GoogleDrive instance
	*/
	this.CreateInstanceGoogleDrive = function (bNesisDevId,clientId,clientSecret,redirectUrl,scopes) {
		if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("GoogleDrive"))
			 throw this.errorCodeServiceDoesNotExistDescription;
		lastSystemErrorMessage = "";
		var resultService = new GoogleDrive(_bNesisApi);
		if (arguments.length > 0)
			try {
				resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl,scopes);
			}
			catch (e) {
				lastSystemErrorMessage = e.Message;
			}
		return resultService;
	}
	/**
	 * Create new instance of Mega 
	 * @return {Mega} Return new Mega instance
	*/
	this.CreateInstanceMega = function (bNesisDevId,clientSecret,redirectUrl,login,password) {
		if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("Mega"))
			 throw this.errorCodeServiceDoesNotExistDescription;
		lastSystemErrorMessage = "";
		var resultService = new Mega(_bNesisApi);
		if (arguments.length > 0)
			try {
				resultService.Auth(bNesisDevId,clientSecret,redirectUrl,login,password);
			}
			catch (e) {
				lastSystemErrorMessage = e.Message;
			}
		return resultService;
	}
	/**
	 * Create new instance of SugarSync 
	 * @return {SugarSync} Return new SugarSync instance
	*/
	this.CreateInstanceSugarSync = function (bNesisDevId,clientId,clientSecret,redirectUrl,login,password,data) {
		if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("SugarSync"))
			 throw this.errorCodeServiceDoesNotExistDescription;
		lastSystemErrorMessage = "";
		var resultService = new SugarSync(_bNesisApi);
		if (arguments.length > 0)
			try {
				resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl,login,password,data);
			}
			catch (e) {
				lastSystemErrorMessage = e.Message;
			}
		return resultService;
	}
	/**
	 * Create new instance of Prozzoro 
	 * @return {Prozzoro} Return new Prozzoro instance
	*/
	this.CreateInstanceProzzoro = function (bNesisDevId,redirectUrl) {
		if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("Prozzoro"))
			 throw this.errorCodeServiceDoesNotExistDescription;
		lastSystemErrorMessage = "";
		var resultService = new Prozzoro(_bNesisApi);
		if (arguments.length > 0)
			try {
				resultService.Auth(bNesisDevId,redirectUrl);
			}
			catch (e) {
				lastSystemErrorMessage = e.Message;
			}
		return resultService;
	}
	/**
	 * Create new instance of LiqPay 
	 * @return {LiqPay} Return new LiqPay instance
	*/
	this.CreateInstanceLiqPay = function (bNesisDevId,clientId,clientSecret,redirectUrl,login) {
		if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("LiqPay"))
			 throw this.errorCodeServiceDoesNotExistDescription;
		lastSystemErrorMessage = "";
		var resultService = new LiqPay(_bNesisApi);
		if (arguments.length > 0)
			try {
				resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl,login);
			}
			catch (e) {
				lastSystemErrorMessage = e.Message;
			}
		return resultService;
	}
	/**
	 * Create new instance of PayPal 
	 * @return {PayPal} Return new PayPal instance
	*/
	this.CreateInstancePayPal = function (bNesisDevId,clientId,clientSecret,redirectUrl) {
		if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("PayPal"))
			 throw this.errorCodeServiceDoesNotExistDescription;
		lastSystemErrorMessage = "";
		var resultService = new PayPal(_bNesisApi);
		if (arguments.length > 0)
			try {
				resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl);
			}
			catch (e) {
				lastSystemErrorMessage = e.Message;
			}
		return resultService;
	}
	/**
	 * Create new instance of Stripe 
	 * @return {Stripe} Return new Stripe instance
	*/
	this.CreateInstanceStripe = function (bNesisDevId,clientId,clientSecret,redirectUrl,scopes) {
		if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("Stripe"))
			 throw this.errorCodeServiceDoesNotExistDescription;
		lastSystemErrorMessage = "";
		var resultService = new Stripe(_bNesisApi);
		if (arguments.length > 0)
			try {
				resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl,scopes);
			}
			catch (e) {
				lastSystemErrorMessage = e.Message;
			}
		return resultService;
	}
	/**
	 * Create new instance of Facebook 
	 * @return {Facebook} Return new Facebook instance
	*/
	this.CreateInstanceFacebook = function (bNesisDevId,clientId,clientSecret,redirectUrl,scopes) {
		if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("Facebook"))
			 throw this.errorCodeServiceDoesNotExistDescription;
		lastSystemErrorMessage = "";
		var resultService = new Facebook(_bNesisApi);
		if (arguments.length > 0)
			try {
				resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl,scopes);
			}
			catch (e) {
				lastSystemErrorMessage = e.Message;
			}
		return resultService;
	}
	/**
	 * Create new instance of GooglePlus 
	 * @return {GooglePlus} Return new GooglePlus instance
	*/
	this.CreateInstanceGooglePlus = function (bNesisDevId,clientId,clientSecret,redirectUrl,scopes,data) {
		if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("GooglePlus"))
			 throw this.errorCodeServiceDoesNotExistDescription;
		lastSystemErrorMessage = "";
		var resultService = new GooglePlus(_bNesisApi);
		if (arguments.length > 0)
			try {
				resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl,scopes,data);
			}
			catch (e) {
				lastSystemErrorMessage = e.Message;
			}
		return resultService;
	}
	/**
	 * Create new instance of LinkedIn 
	 * @return {LinkedIn} Return new LinkedIn instance
	*/
	this.CreateInstanceLinkedIn = function (bNesisDevId,clientId,clientSecret,redirectUrl,scopes) {
		if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("LinkedIn"))
			 throw this.errorCodeServiceDoesNotExistDescription;
		lastSystemErrorMessage = "";
		var resultService = new LinkedIn(_bNesisApi);
		if (arguments.length > 0)
			try {
				resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl,scopes);
			}
			catch (e) {
				lastSystemErrorMessage = e.Message;
			}
		return resultService;
	}
	/**
	 * Create new instance of VKontakte 
	 * @return {VKontakte} Return new VKontakte instance
	*/
	this.CreateInstanceVKontakte = function (bNesisDevId,clientId,clientSecret,redirectUrl) {
		if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("VKontakte"))
			 throw this.errorCodeServiceDoesNotExistDescription;
		lastSystemErrorMessage = "";
		var resultService = new VKontakte(_bNesisApi);
		if (arguments.length > 0)
			try {
				resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl);
			}
			catch (e) {
				lastSystemErrorMessage = e.Message;
			}
		return resultService;
	}
	/**
	 * Create new instance of bNesisTestService 
	 * @return {bNesisTestService} Return new bNesisTestService instance
	*/
	this.CreateInstancebNesisTestService = function (bNesisDevId,clientId,clientSecret,redirectUrl) {
		if (!_bNesisApi.SessionsManager.ClientsManager.ClientExists("bNesisTestService"))
			 throw this.errorCodeServiceDoesNotExistDescription;
		lastSystemErrorMessage = "";
		var resultService = new bNesisTestService(_bNesisApi);
		if (arguments.length > 0)
			try {
				resultService.Auth(bNesisDevId,clientId,clientSecret,redirectUrl);
			}
			catch (e) {
				lastSystemErrorMessage = e.Message;
			}
		return resultService;
	}

    var initResult = this.Initialize(client, apiLocation);

    switch (initResult)
    {
        case this.errorCodeBadUrl:                
            throw this.errorCodeBadUrlDescription;
        case this.errorCodeNotConnected:                
            throw this.errorCodeNotConnectedDesctiption + ": " + lastSystemErrorMessage;
        case this.errorCodeLibraryLocation:
            throw this.errorCodeLibraryLocationDesctiption;
        case this.errorCodeNotSlash:
            throw this.errorCodeNotSlashDesctiption;
        case this.errorCodeNotLibraryIsLoaded:
            throw this.errorCodeNotLibraryIsLoadedDesctiption + ": " + lastSystemErrorMessage;
        case this.errorCodeBadServerName:
            throw this.errorCodeBadServerNameDescription;
        case this.errorCodeProviderDoesNotExist:
            throw this.errorCodeProviderDoesNotExistDescription;
        case this.errorCodeServiceDoesNotExist:
            throw this.errorCodeServiceDoesNotExistDescription;
        case this.errorCodeUnknownServerConnection:
            throw this.errorCodeUnknownServerConnectionDescription + ": " + lastSystemErrorMessage;
    }
}
