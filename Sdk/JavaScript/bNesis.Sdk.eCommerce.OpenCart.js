OpenCart = function (bNesisApi) {
    this.bNesisToken = null;
    var _bNesisApi = bNesisApi;

    /**
     * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
	 * or Attach to bNesis session with exists bNesis token
     * @return {string} bNesisToken value | true if bNesisToken is valid
	 */
    this.Auth = function (bNesisDevId,clientId,clientSecret,redirectUrl,serviceUrl) {
		if(arguments.length !== 1){
			var bNesisToken = _bNesisApi.Auth("OpenCart", "",bNesisDevId,redirectUrl,clientId,clientSecret,null,"","",false,serviceUrl);
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
		var result = _bNesisApi.LogoffService("OpenCart", this.bNesisToken);
		if (result) this.bNesisToken = "";
		return result;             
    }
	
	/**
	 *  Getting last exception for current provider 	
	 * @return {ErrorInfo} 
	 */
    this.GetLastError = function () {
        var result = _bNesisApi.Call("OpenCart", this.bNesisToken, "GetLastError");
        return result;
    }

	/**
	 *  Getting arrays of error info 	
	 * @return {ErrorInfo[]} 
	 */
    this.GetErrorLog = function () {
        var result = _bNesisApi.Call("OpenCart", this.bNesisToken, "GetErrorLog");
        return result;
    }

	/**
	 *  Checks the token in the service. 	
	 * @return {Boolean} if token valid return true, if token not valid return false
	 */
    this.ValidateToken = function () {
        var result = _bNesisApi.Call("OpenCart", this.bNesisToken, "ValidateToken");
        return result;
    }

	/**
	 *  Disables the access token used to authenticate the call. 	
	 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false
	 */
    this.Logoff = function () {
        var result = _bNesisApi.Call("OpenCart", this.bNesisToken, "Logoff");
        return result;
    }

	/**
	 *   	
	 * @param contactItem 
	 * @return {Boolean} 
	 */
    this.CreateCustomerUnified = function (contactItem) {
        var result = _bNesisApi.Call("OpenCart", this.bNesisToken, "CreateCustomerUnified", contactItem);
        return result;
    }

	/**
	 *   	
	 * @return {ContactItem[]} 
	 */
    this.GetCustomersUnified = function () {
        var result = _bNesisApi.Call("OpenCart", this.bNesisToken, "GetCustomersUnified");
        return result;
    }

	/**
	 *   	
	 * @param productItem 
	 * @return {Boolean} 
	 */
    this.AddProductUnified = function (productItem) {
        var result = _bNesisApi.Call("OpenCart", this.bNesisToken, "AddProductUnified", productItem);
        return result;
    }

	/**
	 *   	
	 * @return {ProductItem[]} 
	 */
    this.GetProductsUnified = function () {
        var result = _bNesisApi.Call("OpenCart", this.bNesisToken, "GetProductsUnified");
        return result;
    }

	/**
	 *   	
	 * @param IdProduct 
	 * @return {Boolean} 
	 */
    this.DeleteProductUnified = function (IdProduct) {
        var result = _bNesisApi.Call("OpenCart", this.bNesisToken, "DeleteProductUnified", IdProduct);
        return result;
    }

	/**
	 *   	
	 * @return {CountryItem[]} 
	 */
    this.GetCountriesUnified = function () {
        var result = _bNesisApi.Call("OpenCart", this.bNesisToken, "GetCountriesUnified");
        return result;
    }

	/**
	 *   	
	 * @return {Int32} 
	 */
    this.GetCountCountriesUnified = function () {
        var result = _bNesisApi.Call("OpenCart", this.bNesisToken, "GetCountCountriesUnified");
        return result;
    }

	/**
	 *   	
	 * @param IdCountry 
	 * @return {CountryItem} 
	 */
    this.ReceiveCountryUnified = function (IdCountry) {
        var result = _bNesisApi.Call("OpenCart", this.bNesisToken, "ReceiveCountryUnified", IdCountry);
        return result;
    }

	/**
	 *   	
	 * @param IdCountry 
	 * @return {Boolean} 
	 */
    this.DeleteCountryUnified = function (IdCountry) {
        var result = _bNesisApi.Call("OpenCart", this.bNesisToken, "DeleteCountryUnified", IdCountry);
        return result;
    }

	/**
	 *   	
	 * @param countryItem 
	 * @return {CountryItem} 
	 */
    this.CreateCountryUnified = function (countryItem) {
        var result = _bNesisApi.Call("OpenCart", this.bNesisToken, "CreateCountryUnified", countryItem);
        return result;
    }

	/**
	 *   	
	 * @param countryItem 
	 * @return {CountryItem} 
	 */
    this.UpdateCountryUnified = function (countryItem) {
        var result = _bNesisApi.Call("OpenCart", this.bNesisToken, "UpdateCountryUnified", countryItem);
        return result;
    }

	/**
	 *   	
	 * @param IdCustomer 
	 * @return {ContactItem} 
	 */
    this.ReceiveCustomerUnified = function (IdCustomer) {
        var result = _bNesisApi.Call("OpenCart", this.bNesisToken, "ReceiveCustomerUnified", IdCustomer);
        return result;
    }

	/**
	 *  Get list of stores. 	
	 * @return {Response} list of stores
	 */
    this.GetStores = function () {
        var result = _bNesisApi.Call("OpenCart", this.bNesisToken, "GetStores");
        return result;
    }
}
