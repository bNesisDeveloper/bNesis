Facebook = function (bNesisApi) {
    this.bNesisToken = null;
    var _bNesisApi = bNesisApi;

    this.Auth = function (data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl) {
        var bNesisToken = _bNesisApi.Auth("Facebook", data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl);
        return bNesisToken;
    }
	
	/**
	 *  Getting last exception for current provider 	
	 * @return {ErrorInfo} 
	 */
    this.GetLastError = function () {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetLastError");
        return result;
    }

	/**
	 *  Getting arrays of error info 	
	 * @return {ErrorInfo[]} 
	 */
    this.GetErrorLog = function () {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetErrorLog");
        return result;
    }

	/**
	 *  Checks the token in the service. 	
	 * @return {Boolean} if token valid return true, if token not valid return false
	 */
    this.ValidateToken = function () {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "ValidateToken");
        return result;
    }

	/**
	 *  Disables the access token used to authenticate the call. 	
	 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false
	 */
    this.Logoff = function () {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "Logoff");
        return result;
    }

	/**
	 *  Gets the user identifier. 	
	 * @return {Response} response with user ID
	 */
    this.GetUserIdRaw = function () {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserIdRaw");
        return result;
    }

	/**
	 *  Checks the token in the service. 	
	 * @return {Response} data with information about the token
	 */
    this.ValidationTokenRaw = function () {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "ValidationTokenRaw");
        return result;
    }

	/**
	 *  Generates an App Access Token 	
	 * @return {Response} app Access Token
	 */
    this.GetAppAccessTokenRaw = function () {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetAppAccessTokenRaw");
        return result;
    }

	/**
	 *  Gets the user Friendlists. 	
	 * @return {Response} user Friendlists
	 */
    this.GetUserFriendlists = function () {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserFriendlists");
        return result;
    }
}
