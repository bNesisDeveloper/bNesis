MaxUrlParamLength = 100;
MaxUrlLength = 8 * 1024; // 8 Kb

function bNesisApi()
{
    if (!(this instanceof bNesisApi))
        return new bNesisApi();

    var _bNesisToken = null;

    /**
     * Checks initialization of the API. All sub objects like SessionsManager,
     * ClientsManager, AuthProvidersManager must be properly initialized.
     */
    var CheckInitialization = function () {
        if (!this.SessionsManager || this.SessionsManager.ClientsManager === null || this.SessionsManager.AuthProvidersManager === null)
        {
            throw this.toString() + " is not initialized.";
        }
    }

    /**
     * Initializes the API to use proxy for remote service clients and auth providers call.
     * @param {string} bNesisApiUrl - URL of bNesis API web service.
     */
    this.InitializeRemote = function (bNesisApiUrl) {
        this.bNesisApiUrl = bNesisApiUrl;
        this.SessionsManager = new RemoteApiServiceSessionsManager(bNesisApiUrl);
    }

    /**
     * Authenticates to specified provider using current auth provider.
     * @param {string} providerId - The provider identifier (f.e. Google).
     * @param {string} data - Additional data for the provider.
     * @param {string} bNesisDevId - The bNesis developer identifier.
     * @param {string} redirectUrl - URL which will be redirected to after authentication.
     * @param {string} clientId - The client identifier of the provider account.
     * @param {string} clientSecret - The client secret of the provider account.
     * @param {string} scopes - The list of Provider API access scopes.
     * @param {string} login - The user login for basic auth.
     * @param {string} password - The user password for basic auth.
     * @param {bool} isSandbox - If set to <c>true</c> Sandbox mode is used.
     * @param {string} serviceUrl - The service base URL.
     * @return {string} bNesis token.
     */
    this.Auth = function (providerId, data, bNesisDevId, redirectUrl, clientId, clientSecret, scopes, login, password, isSandbox, serviceUrl) {
        CheckInitialization.call(this);

        //var str = jQuery.validator.format("test Provider '{providerId}'  is not supported.", providerId);
        if (!this.SessionsManager.AuthProvidersManager.ProviderExists(providerId)) {

            throw "Provider '" + providerId +"' is not supported.";
        }

        var authUrl = this.bNesisApiUrl + "api/AuthProvider/Auth?" +
                      "providerId=" + encodeURIComponent(providerId) +
                      "&data=" + encodeURIComponent(data) +
                      "&bNesisDevId=" + encodeURIComponent(bNesisDevId) +
                      "&redirectUrl=" + encodeURIComponent(redirectUrl) +
                      "&clientId=" + encodeURIComponent(clientId) +
                      "&clientSecret=" + encodeURIComponent(clientSecret) +
                      "&scopes=" + encodeURIComponent(scopes) +
                      "&login=" + encodeURIComponent(login) +
                      "&password=" + encodeURIComponent(password) +
                      "&isSandbox=" + encodeURIComponent(isSandbox) +
                      "&serviceUrl=" + encodeURIComponent(serviceUrl);
        window.location.replace(authUrl);
    }

    /**
     * Calls the specified method of the specified service client.
     * @param {string} serviceId - The service identifier (f.e. GoogleDrive).
     * @param {string} bNesisToken - The bNesis token.
     * @param {string} methodName - Name of the called method.
     * @param {objects} methodParameters - The called method parameters.
     * @return {TResult} Result of the method call.
     */
    this.Call = function (serviceId, bNesisToken, methodName)
    {
        CheckInitialization.call(this);

        if(arguments.length < 3)
            return "Wrong number of parameters";
        var methodParameters = null;
        if (arguments.length === 4) {
            methodParameters = arguments[3];
        }
        else if (arguments.length > 4) {
                methodParameters = new Array(arguments.length -3);
                for(i = 3; i < arguments.length; i++)
                    methodParameters[i-3]= arguments[i];
                    }
        var serviceClient = this.SessionsManager.GetSessionClient(bNesisToken, serviceId);
        var result = serviceClient.Call(methodName, methodParameters);
        return result;
    }

    /**
     * The method stops the authorization session with the service and clears the value of bNesisToken
     * @param {string} serviceId - The service identifier (f.e. GoogleDrive).
     * @param {string} bNesisToken - The bNesis token.
     * @return {bool} if token revoked returns true
     */
    this.LogoffService = function (serviceId, bNesisToken)
    {
        CheckInitialization.call(this);

        var client = this.SessionsManager.GetSessionClient(bNesisToken, serviceId);
        client.LogoffService(); //???
        this.SessionsManager.RemoveSessionLocal(bNesisToken);

        if (_bNesisToken !== null && _bNesisToken !== undefined && _bNesisToken.length > 0 && _bNesisToken === bNesisToken)
            _bNesisToken = null;

        return true;
    }
}


/**
 * Get last manager error description | Get LastError from service
 * @param {string} providerId select service provider Id
 * @param {string|exception} errorParameter bNesisToken|exception bNesis access token|exception object (from catch(Exception))
 * @return{string|Error} error description | bNesis ErrorInfo with error code and message
 */
bNesisApi.prototype.GetLastError = function (providerId, errorParameter) {
    if (typeof errorParameter === "string") {
        //any service class must implement GetLastError method (API)
        var bNesisToken = errorParameter;
        var error = this.Call(providerId, bNesisToken, "GetLastError");
        return error;
    }
    if(errorParameter && errorParameter.stack && errorParameter.message 
					&& typeof errorParameter.stack === "string" && typeof errorParameter.message === "string") {
        var errorInfo = new ErrorInfo(ErrorCode.NobNesisException, "No bNesisException", "", providerId);
        /// TODO: Exception (or Error) classes proecessing should be here
        //if(errorParameter.)
    }
}

/**
 * Get errors log from selected service
 * @param {string} providerId - select service provider Id
 * @param {string} bNesisToken - bNesis access token
 * @return {Array} array with service errorLog history
 */
bNesisApi.prototype.GetErrorLog = function (providerId, bNesisToken) {
    if (typeof bNesisToken === "string") {
        var errorLog = this.Call(providerId, bNesisToken, "GetErrorLog");
        return errorLog;
    }
    return "Wrong GetErrorLog parameter";
}

/**
 * @class
 * @classdesc Class which represents implementation of IRemoteApiServiceSessionsManager.
 * It behaves as proxy to bNesis API web service.
 * @param {string} bNesisApiUrl - URL of bNesis API web service.
 */
function RemoteApiServiceSessionsManager(bNesisApiUrl) {
    if (!(this instanceof RemoteApiServiceSessionsManager))
        return new RemoteApiServiceSessionsManager(bNesisApiUrl);
    var _sessions = {};
    var _providerAuthInfos = {};
    var _authProviders = {};

    this.AuthProvidersManager = new RemoteApiAuthProvidersManager(bNesisApiUrl);
    this.ClientsManager = new RemoteApiServiceClientsManager(bNesisApiUrl);

    var GetSessionClientWithoutAuth = function(sessionKey, serviceId)
    {
        if (this.ClientsManager === null)
        {
            throw "ClientsManager is not assigned.";
        }

        var result = null;

        result = _sessions[sessionKey];

        if(_sessions && result !== undefined){
            if (result.ServiceId !== serviceId) {
                throw "Session '" + sessionKey + "' contains client to '" + result.ServiceId + "' when '" + serviceId  + "' is requested.";
            }
            return result;
        }
        result = this.ClientsManager.CreateClient(serviceId);
        if (result === null){
            throw "Client for the session '" + sessionKey + "' is not created.";
        }

        _sessions[sessionKey] =  result;

        return result;
    }

    this.GetSessionClient =  function(sessionKey, serviceId){
        var remoteApiClient = GetSessionClientWithoutAuth.call(this, sessionKey, serviceId);
        if (remoteApiClient === null)
        {
            throw "{GetType().Name} supports only {nameof(IRemoteApiServiceClient)} clients.";
        }

        remoteApiClient.bNesisToken = sessionKey;
        return remoteApiClient;
    }

    this.RemoveSessionLocal = function (bNesisToken) {
        try
        {
            var client = null;
                
            if (_sessions && _sessions !== undefined && _sessions[bNesisToken])
                client = _sessions[bNesisToken];

            if (_providerAuthInfos && _providerAuthInfos !== undefined)
                delete _providerAuthInfos[bNesisToken];

            if (_sessions && _sessions !== undefined)
                delete _sessions[bNesisToken];

            if (_authProviders && client !== undefined && client !== null) {
                delete _authProviders[client.ServiceId];
            }

            return true;
        }
        catch (e)
        {
            return false;
        }
    }
}

/**
 * @class
 * @classdesc Default implementation of <see cref="IRemoteApiProvidersManager{T}"/> which is responsible for
 * passing calls to bNesis API web service.
 * @param {string} bNesisApiUrl - URL of bNesis API web service.
 */
function RemoteApiAuthProvidersManager(bNesisApiUrl) {
    if (!(this instanceof RemoteApiAuthProvidersManager))
        return new RemoteApiAuthProvidersManager(bNesisApiUrl);
    this.bNesisApiUrl = bNesisApiUrl;
    var AuthProvidersManagerContollerPath = "api/AuthProvidersManager/";

    /**
     * Gets information about presence of a provider with given ID.
     * @param {string} providerId - The unique identifier of the provider.
     * @return {boolean} <c>true</c> if the provider exists, <c>false</c> otherwise.
     */
    this.ProviderExists = function (providerId) {
        var callUrl = AuthProvidersManagerContollerPath + "ProviderExists?providerId=" + encodeURIComponent(providerId);
        return RESTCallWithNoParameters(this.bNesisApiUrl + callUrl);
    }

    /**
     * Enumerates all provider IDs available for the manager.
     * @return {Array} Set of string IDs.
     */
    this.GetProviderIds = function () {
        var callUrl = AuthProvidersManagerContollerPath + "GetProviderIds";
        return RESTCallWithNoParameters(this.bNesisApiUrl + callUrl);
    }
}

/**
 * @class 
 * @classdesc Default implementation of IRemoteApiServiceClientsManager which is responsible for
 * providing access to RemoteApiServiceClient and getting information
 * what clients are available on the bNesis API service.
 * @param {string} bNesisApiUrl - URL of bNesis API web service.
 */
function RemoteApiServiceClientsManager(bNesisApiUrl) {
    if (!(this instanceof RemoteApiServiceClientsManager))
        return new RemoteApiServiceClientsManager(bNesisApiUrl);
    this.bNesisApiUrl = bNesisApiUrl;
    var ServiceClientsManagerContollerPath = "api/ServiceClientsManager/";

    /**
     * Gets information about presence of a client with given service ID.
     * @param {string} serviceId - The unique identifier of the client.
     * @returns {boolean} <c>true</c> if the client exists, <c>false</c>
     */
    this.ClientExists = function (serviceId) {
        var callUrl = ServiceClientsManagerContollerPath + "ClientExists?serviceId=" + encodeURIComponent(serviceId);
        return RESTCallWithNoParameters(this.bNesisApiUrl + callUrl);
    }

    /**
     * Creates new instance of RemoteApiServiceClient which will call remote API on a local call.
     * @param {string} serviceId - ID of the service client to which should be created.
     * @returns {IServiceClient} Instance which implements IServiceClient.
     */
    this.CreateClient = function (serviceId) {
        var result = new RemoteApiServiceClient();
        result.ServiceId = serviceId;
        result.bNesisApiUrl = this.bNesisApiUrl;
        return result;
    }

    /**
     * Enumerate all client service IDs available for the manager.
     * @param {string} providerId - The provider identifier.
     * If specified method returns client IDs only for the provider.
     * If null or empty all client IDs will be returned.
     * @returns {Array} Set of string IDs.
     */
    this.GetClientIds = function (providerId) {
        providerId = providerId || null;
        var callUrl = ServiceClientsManagerContollerPath + "GetClientIds?providerId=" + encodeURIComponent(providerId);
        return RESTCallWithNoParameters(this.bNesisApiUrl + callUrl);
    }
}

/**
 * @class
 * @classdesc Generic service client which can represent any kind of service client and
 * transfer local calls to remote bNesis API service.
 */
function RemoteApiServiceClient() {
    if (!(this instanceof RemoteApiServiceClient))
        return new RemoteApiServiceClient();
    this.ServiceId = ""
    this.bNesisApiUrl = "";
    this.bNesisToken = "";
}

/**
 * Calls specified method remotely.
 * @param {string} methodName - Name of the method.
 * @param {objects} methodParameters - Parameters for the method call.
 * @returns {object} Object returned from the method or null if method returns void.
 */
RemoteApiServiceClient.prototype.Call = function (methodName, methodParameters)
{
    var asyncData = null;
    var callUrl = "api/ServiceClient/Call?" +
                  "serviceId=" + encodeURIComponent(this.ServiceId) +
                  "&bNesisToken=" + encodeURIComponent(this.bNesisToken) +
                  "&methodName=" + encodeURIComponent(methodName);

    var _parameters = null;
    if(methodParameters instanceof Array)
    {
        _parameters = methodParameters;
    }
    else
        if(methodParameters !==null && methodParameters !== undefined)
        {
            _parameters = new Array(1);
            _parameters[0] = methodParameters;
        }

    var parameterUri = "";
    var formData = new FormData();
    var allParametersAreSimple = true;
    if (_parameters !==null && _parameters instanceof Array) {
        for (var parameterIndex in _parameters) {
            var parameter = _parameters[parameterIndex]
            if (typeof parameter === "string") {
                var escapedValue = encodeURIComponent(parameter);
                if(escapedValue.length <= MaxUrlParamLength){
                    var parameterValue = "&p" + parameterIndex + "=" + escapedValue;
                    if (this.bNesisApiUrl.length + callUrl.length + parameterValue.length <= MaxUrlLength)
                        parameterUri += parameterValue;
                }
            }
            else
                if (typeof parameter === "object") {
                    allParametersAreSimple = false;
                    var parameterValue = null;
                    var contentType = null;
                    if (parameter instanceof File) {
                        parameterValue = parameter;
                        //contentType = "application/octet-stream";
                    }
                    else {
                        //parameterValue = JSON.stringify(methodParameter);
                        contentType = "application/json";
                        parameterValue = new Blob([JSON.stringify(parameter)], { type: contentType });
                    }
                    formData.append('p' + parameterIndex, parameterValue);
                }
                else
                    return "Parameters type not supported";
        }
    }

    callUrl += parameterUri;

    //if (methodParameters === null || methodParameters === "") {
    if (allParametersAreSimple)
    {
        return RESTCallWithNoParameters(this.bNesisApiUrl + callUrl);
    }
    else 
    {        
        return RESTCallWithParameters(this.bNesisApiUrl + callUrl, formData);
    }

    //return "Parameters type not supported";
}

RemoteApiServiceClient.prototype.LogoffService = function () {
    var result = this.Call("Logoff");

    var AuthProviderControllerPath = "api/AuthProvider/"
    var url = AuthProviderControllerPath + "Logoff?serviceId=" + encodeURIComponent(this.ServiceId) + "&bNesisToken=" + encodeURIComponent(this.bNesisToken);
    var response = RESTCallWithNoParameters(this.bNesisApiUrl + url);

    if (response.IsSuccessStatusCode)
    {
        // IMPORTANT! Do not dispose the response with stream - this will dispose the stream which is needed upper.
        //if (response.Content.Headers.ContentDisposition?.DispositionType == "attachment")
        //{
        //    return await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        //}

    //using (response)
    //{
    //    return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
    //}
    }
/**
using (response)
{
    var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
    //see ServiceClientController::Call method to understand HttpStatusCodes processing 
    switch (response.StatusCode)
    {
        case HttpStatusCode.MethodNotAllowed:
            throw new ServiceOperationFailedException(content); //if in service client throw exception
        case HttpStatusCode.Unauthorized:
            throw new NotAuthenticatedSessionException(content);//if not auth in bNesis server
        case HttpStatusCode.ServiceUnavailable:
            throw new UnavailableServerException("bNesis server unavailable.");
        case HttpStatusCode.GatewayTimeout | HttpStatusCode.RequestTimeout:
            throw new TimeoutException("bNesis server timeout");
        default:
            throw new Exception($"Remote call error. ReasonPhrase: {response.ReasonPhrase}. Content: {content}."); //else exception
    }
}*/

}

/**
 * Creating new information about error
 * @param {number} code - Error code
 * @param {string} description - Describes important error information
 * @param {string} basicDescription - All information about error
 * @param {string} service - Service name
 * @param {string} dateTime - When error created
 * @returns {ErrorInfo} instance of ErrorInfo Class
 */
function ErrorInfo(code, description, basicDescription, service, dateTime) {
    if (!(this instanceof ErrorInfo))
        return new ErrorInfo(code, description, basicDescription, service, dateTime);
    /** 
	* Error code
	* @type{number} 
	*/
    Object.defineProperty(this, "Code", {
        value: code,
        enumerable: false
    });
    /** 
	* When ErrorInfo was created
	* @type{string} 
	*/
    Object.defineProperty(this, "DateTime", {
        value: dateTime || null,
        enumerable: false
    });
    /** 
	* Service name
	* @type{string} 
	*/
    Object.defineProperty(this, "Service", {
        value: service,
        enumerable: false
    });
    /** 
	* Describes important error information
	* @type{string} 
	*/
    Object.defineProperty(this, "Description", {
        value: description,
        enumerable: false
    });
    /** 
	* All information about error
	* @type{string} 
	*/
    Object.defineProperty(this, "BasicDescription", {
        value: basicDescription,
        enumerable: false
    });
}

/*
 * Error code   
 */
ErrorCode = {
    /**
     * No errors
     */
    NoError: 0,
    /**
     * No error in bNesis
     */
    NobNesisException: 1,
    /**
     * Abstract error of invoke method
     */
    InvokeMethodFailed: 0x58DA19,
    /**
     * Service can't auth, because bad token
     */
    BadServiceToken: 0x5898D9,
    /**
     * Service not implemented some functions
     */
    NotImplemented: 0x589836,
    /**
     * Waiting time is exhausted
     */
    Timeout: 0x5898DD,
    /**
     * Unable to authenticate
     */
    NotAuthenticatedSession: 0x55,
    /**
     * Service was unable to perform the operation
     */
    ServiceOperationFailed: 0x45,
    /**
     * bNesis server unavailable
     */
    UnavailableServer: 0x23
}
