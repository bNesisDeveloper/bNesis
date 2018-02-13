GoogleAnalytics = function (bNesisApi) {
    this.bNesisToken = null;
    var _bNesisApi = bNesisApi;

    this.Auth = function (bNesisDevId,redirectUrl,clientId,clientSecret,scopes) {
        var bNesisToken = _bNesisApi.Auth("Google", "",bNesisDevId,redirectUrl,clientId,clientSecret,scopes,"","",false,"");
        return bNesisToken;
    }
	
	/**
	 *  Getting last exception for current provider 	
	 * @return {ErrorInfo} 
	 */
    this.GetLastError = function () {
        var result = _bNesisApi.Call("GoogleAnalytics", this.bNesisToken, "GetLastError");
        return result;
    }

	/**
	 *  Getting arrays of error info 	
	 * @return {ErrorInfo[]} 
	 */
    this.GetErrorLog = function () {
        var result = _bNesisApi.Call("GoogleAnalytics", this.bNesisToken, "GetErrorLog");
        return result;
    }

	/**
	 *  Checks the token in the service. 	
	 * @return {Boolean} if token valid return true, if token not valid return false
	 */
    this.ValidationTokenUnified = function () {
        var result = _bNesisApi.Call("GoogleAnalytics", this.bNesisToken, "ValidationTokenUnified");
        return result;
    }
}
