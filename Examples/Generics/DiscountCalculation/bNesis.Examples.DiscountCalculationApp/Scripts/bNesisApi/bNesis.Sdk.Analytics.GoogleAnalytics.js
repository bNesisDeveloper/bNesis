GoogleAnalytics = function(bNesisApi) {
    this.bNesisToken = null;
    var _bNesisApi = bNesisApi;

    /**
     * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
     * or Attach to bNesis session with exists bNesis token
     * @return {string} bNesisToken value | true if bNesisToken is valid
     */
    this.Auth = function(bNesisDevId, clientId, clientSecret, redirectUrl, scopes) {
        if (arguments.length !== 1) {
            var bNesisToken = _bNesisApi.Auth("Google", "", bNesisDevId, redirectUrl, clientId, clientSecret, scopes, "", "", false, "");
            return bNesisToken;
        } else {
            this.bNesisToken = arguments[0];
            return ValidateToken();
        }
    }

    /**
     * The method stops the authorization session with the service and clears the value of bNesisToken.
     * @return {Boolean} true - if service logoff is successful
     */
    this.LogoffService = function() {
        var result = _bNesisApi.LogoffService("Google", this.bNesisToken);
        if (result) this.bNesisToken = "";
        return result;
    }

    /**
     *  Gets a list of all user accounts. 	
     * @return {Response} Response.
     */
    this.GetManagementAccounts = function() {
        var result = _bNesisApi.Call("GoogleAnalytics", this.bNesisToken, "GetManagementAccounts");
        return result;
    }

    /**
     *  Getting last exception for current provider 	
     * @return {ErrorInfo} 
     */
    this.GetLastError = function() {
        var result = _bNesisApi.Call("GoogleAnalytics", this.bNesisToken, "GetLastError");
        return result;
    }

    /**
     *  Getting arrays of error info 	
     * @return {ErrorInfo[]} 
     */
    this.GetErrorLog = function() {
        var result = _bNesisApi.Call("GoogleAnalytics", this.bNesisToken, "GetErrorLog");
        return result;
    }

    /**
     *  Checks the token in the service. 	
     * @return {Boolean} if token valid return true, if token not valid return false
     */
    this.ValidateToken = function() {
        var result = _bNesisApi.Call("GoogleAnalytics", this.bNesisToken, "ValidateToken");
        return result;
    }

    /**
     *  Disables the access token used to authenticate the call. 	
     * @return {Boolean} if token revoked method returns true 
     * if token doesn't support token revocation or token is revoked method returns false
     */
    this.Logoff = function() {
        var result = _bNesisApi.Call("GoogleAnalytics", this.bNesisToken, "Logoff");
        return result;
    }

    /**
     *  Gets list of webproperties to which user have access. 	
     * @param accountId Account identifier.
     * @return {Response} Response.
     */
    this.GetWebProperties = function(accountId) {
        var result = _bNesisApi.Call("GoogleAnalytics", this.bNesisToken, "GetWebProperties", accountId);
        return result;
    }

    /**
     *  Gets a webproperty information. 	
     * @param accountId Account identifier.
     * @param webpropertyId Web property identifier. (Format:code-XXXXX-YY)
     * @return {Response} Response.
     */
    this.GetWebProperty = function(accountId, webpropertyId) {
        var result = _bNesisApi.Call("GoogleAnalytics", this.bNesisToken, "GetWebProperty", accountId, webpropertyId);
        return result;
    }

    /**
     *  Gets a view profiles to which the user have access. 	
     * @param accountId Account identifier.
     * @param webpropertyId Web property identifier. (Format:code-XXXXX-YY)
     * @return {Response} Response.
     */
    this.GetWebPropertyProfiles = function(accountId, webpropertyId) {
        var result = _bNesisApi.Call("GoogleAnalytics", this.bNesisToken, "GetWebPropertyProfiles", accountId, webpropertyId);
        return result;
    }

    /**
     *  Gets analytics data. 	
     * @param reportRequest The report request.
     * @return {Response} Return in response.
     */
    this.GetReportsBatchRaw = function(reportRequest) {
        var result = _bNesisApi.Call("GoogleAnalytics", this.bNesisToken, "GetReportsBatchRaw", reportRequest);
        return result;
    }
}