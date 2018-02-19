OpenCart = function (bNesisApi) {
    this.bNesisToken = null;
    var _bNesisApi = bNesisApi;

    this.Auth = function (data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl) {
        var bNesisToken = _bNesisApi.Auth("OpenCart", data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl);
        return bNesisToken;
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
