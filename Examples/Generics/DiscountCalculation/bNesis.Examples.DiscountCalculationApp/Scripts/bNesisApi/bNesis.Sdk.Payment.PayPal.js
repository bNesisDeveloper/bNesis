PayPal = function (bNesisApi) {
    this.bNesisToken = null;
    var _bNesisApi = bNesisApi;

    /**
     * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
	 * or Attach to bNesis session with exists bNesis token
     * @return {string} bNesisToken value | true if bNesisToken is valid
	 */
    this.Auth = function (bNesisDevId,clientId,clientSecret,redirectUrl) {
		if(arguments.length !== 1){
			var bNesisToken = _bNesisApi.Auth("PayPal", "",bNesisDevId,redirectUrl,clientId,clientSecret,null,"","",false,"");
			return bNesisToken;
		}
		else{
		    this.bNesisToken = arguments[0];			
			return ValidateToken();		
		}		
    }

    /**
     * The method stops the authorization session with the service and clears the value of bNesisToken.
     * @return {Boolean} true - if service logoff is successful
	 */
    this.LogoffService = function () {
		var result = _bNesisApi.LogoffService("PayPal", this.bNesisToken);
		if (result) this.bNesisToken = "";
		return result;             
    }
	
	/**
	 *  Getting last exception for current provider 	
	 * @return {ErrorInfo} 
	 */
    this.GetLastError = function () {
        var result = _bNesisApi.Call("PayPal", this.bNesisToken, "GetLastError");
        return result;
    }

	/**
	 *  Getting arrays of error info 	
	 * @return {ErrorInfo[]} 
	 */
    this.GetErrorLog = function () {
        var result = _bNesisApi.Call("PayPal", this.bNesisToken, "GetErrorLog");
        return result;
    }

	/**
	 *  Checks the token in the service. 	
	 * @return {Boolean} if token valid return true, if token not valid return false
	 */
    this.ValidateToken = function () {
        var result = _bNesisApi.Call("PayPal", this.bNesisToken, "ValidateToken");
        return result;
    }

	/**
	 *  Disables the access token used to authenticate the call. 	
	 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false
	 */
    this.Logoff = function () {
        var result = _bNesisApi.Call("PayPal", this.bNesisToken, "Logoff");
        return result;
    }

	/**
	 *  sale 	
	 * @param sale_id sale_id.
	 * @return {ExpandoObject} Returns ExpandoObject.
	 */
    this.sale = function (sale_id) {
        var result = _bNesisApi.Call("PayPal", this.bNesisToken, "sale", sale_id);
        return result;
    }

	/**
	 *  get_credit_cards 	
	 * @return {ExpandoObject} Returns ExpandoObject.
	 */
    this.get_credit_cards = function () {
        var result = _bNesisApi.Call("PayPal", this.bNesisToken, "get_credit_cards");
        return result;
    }

	/**
	 *  get_user_info 	
	 * @return {Response} Returns Response.
	 */
    this.get_user_infoRaw = function () {
        var result = _bNesisApi.Call("PayPal", this.bNesisToken, "get_user_infoRaw");
        return result;
    }
}
