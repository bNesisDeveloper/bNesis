PayPal = function (bNesisApi) {
    this.bNesisToken = null;
    var _bNesisApi = bNesisApi;

    this.Auth = function (data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl) {
        var bNesisToken = _bNesisApi.Auth("PayPal", data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl);
        return bNesisToken;
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
    this.ValidationTokenUnified = function () {
        var result = _bNesisApi.Call("PayPal", this.bNesisToken, "ValidationTokenUnified");
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
