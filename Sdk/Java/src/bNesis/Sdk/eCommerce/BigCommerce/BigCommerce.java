package bNesis.Sdk.eCommerce.BigCommerce;

import java.io.*;
import java.util.List;
import java.util.Date;
import java.util.Map.Entry;
import bNesis.Api.*;

import bNesis.Sdk.Common.*;
import java.net.URI.*;

	public class BigCommerce  
	{
		/**
		 * bNesisToken is a unique identifier of the current service work session
		 * bNesisToken is relevant only after successful authorization in the service.
		 * The Auth() method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		 * The LogoffService() method stops the authorization session with the service and clears the value of bNesisToken.
		 */
		public String bNesisToken= "";

		/**
		 * bNesis Core object
		 */
		private bNesisApi _bNesisApi;

		public BigCommerce(bNesisApi bnesisApi)
		{
			this._bNesisApi = bnesisApi;
		}

		/**
		 * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		 * @return {String} bNesisToken value
		 */
		public String Auth(String bNesisDevId,String redirectUrl,String login,String password,String data) throws Exception
		{
			bNesisToken = _bNesisApi.Auth("BigCommerce", data,bNesisDevId,redirectUrl,"","",null,login,password,false,"");
			return bNesisToken;
		}

		/**
		 * Attach to bNesis session with exists bNesis token
		 * @return {Boolean} true if bNesisToken is valid
		 */
		public Boolean Auth(String bNesisToken) throws Exception
		{
		    this.bNesisToken = bNesisToken;			
			return ValidateToken();
		}

		/**
		 * The method stops the authorization session with the service and clears the value of bNesisToken.
		 * @return {Boolean} true - if service logoff is successful
		 */
		public Boolean LogoffService()
		{
			Boolean result = _bNesisApi.LogoffService("BigCommerce", bNesisToken);
			if (result) bNesisToken = "";
			return result;             
		}


		/**
		 *  Getting last exception for current provider 	
		 * @return {ErrorInfo}  
		 * @throws Exception
		 */
		public ErrorInfo GetLastError() throws Exception
		{
			return _bNesisApi.<ErrorInfo>Call(ErrorInfo.class, "BigCommerce", bNesisToken, "GetLastError");
		}

		/**
		 *  Getting arrays of error info 	
		 * @return {ErrorInfo[]}  
		 * @throws Exception
		 */
		public ErrorInfo[] GetErrorLog() throws Exception
		{
			return _bNesisApi.<ErrorInfo[]>Call(ErrorInfo[].class, "BigCommerce", bNesisToken, "GetErrorLog");
		}

		/**
		 *  Checks the token in the service. 	
		 * @return {Boolean} if token valid return true, if token not valid return false 
		 * @throws Exception
		 */
		public Boolean ValidateToken() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "BigCommerce", bNesisToken, "ValidateToken");
		}

		/**
		 *  Disables the access token used to authenticate the call. 	
		 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false 
		 * @throws Exception
		 */
		public Boolean Logoff() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "BigCommerce", bNesisToken, "Logoff");
		}

		/**
		 *   	
		 * @param contactItem 
	 * @return {Boolean}  
		 * @throws Exception
		 */
		public Boolean CreateCustomerUnified(ContactItem contactItem) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "BigCommerce", bNesisToken, "CreateCustomerUnified", contactItem);
		}

		/**
		 *   	
		 * @return {ContactItem[]}  
		 * @throws Exception
		 */
		public ContactItem[] GetCustomersUnified() throws Exception
		{
			return _bNesisApi.<ContactItem[]>Call(ContactItem[].class, "BigCommerce", bNesisToken, "GetCustomersUnified");
		}

		/**
		 *   	
		 * @param productItem 
	 * @return {Boolean}  
		 * @throws Exception
		 */
		public Boolean AddProductUnified(ProductItem productItem) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "BigCommerce", bNesisToken, "AddProductUnified", productItem);
		}

		/**
		 *   	
		 * @return {ProductItem[]}  
		 * @throws Exception
		 */
		public ProductItem[] GetProductsUnified() throws Exception
		{
			return _bNesisApi.<ProductItem[]>Call(ProductItem[].class, "BigCommerce", bNesisToken, "GetProductsUnified");
		}

		/**
		 *   	
		 * @param IdProduct 
	 * @return {Boolean}  
		 * @throws Exception
		 */
		public Boolean DeleteProductUnified(String IdProduct) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "BigCommerce", bNesisToken, "DeleteProductUnified", IdProduct);
		}

		/**
		 *   	
		 * @return {CountryItem[]}  
		 * @throws Exception
		 */
		public CountryItem[] GetCountriesUnified() throws Exception
		{
			return _bNesisApi.<CountryItem[]>Call(CountryItem[].class, "BigCommerce", bNesisToken, "GetCountriesUnified");
		}

		/**
		 *   	
		 * @return {Integer}  
		 * @throws Exception
		 */
		public Integer GetCountCountriesUnified() throws Exception
		{
			return _bNesisApi.<Integer>Call(Integer.class, "BigCommerce", bNesisToken, "GetCountCountriesUnified");
		}

		/**
		 *   	
		 * @param IdCountry 
	 * @return {CountryItem}  
		 * @throws Exception
		 */
		public CountryItem ReceiveCountryUnified(String IdCountry) throws Exception
		{
			return _bNesisApi.<CountryItem>Call(CountryItem.class, "BigCommerce", bNesisToken, "ReceiveCountryUnified", IdCountry);
		}

		/**
		 *   	
		 * @param IdCountry 
	 * @return {Boolean}  
		 * @throws Exception
		 */
		public Boolean DeleteCountryUnified(String IdCountry) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "BigCommerce", bNesisToken, "DeleteCountryUnified", IdCountry);
		}

		/**
		 *   	
		 * @param countryItem 
	 * @return {CountryItem}  
		 * @throws Exception
		 */
		public CountryItem CreateCountryUnified(CountryItem countryItem) throws Exception
		{
			return _bNesisApi.<CountryItem>Call(CountryItem.class, "BigCommerce", bNesisToken, "CreateCountryUnified", countryItem);
		}

		/**
		 *   	
		 * @param countryItem 
	 * @return {CountryItem}  
		 * @throws Exception
		 */
		public CountryItem UpdateCountryUnified(CountryItem countryItem) throws Exception
		{
			return _bNesisApi.<CountryItem>Call(CountryItem.class, "BigCommerce", bNesisToken, "UpdateCountryUnified", countryItem);
		}

		/**
		 *   	
		 * @param IdCustomer 
	 * @return {ContactItem}  
		 * @throws Exception
		 */
		public ContactItem ReceiveCustomerUnified(String IdCustomer) throws Exception
		{
			return _bNesisApi.<ContactItem>Call(ContactItem.class, "BigCommerce", bNesisToken, "ReceiveCustomerUnified", IdCustomer);
		}

		/**
		 *  Gets the catalog products. 	
		 * @return {Response} Returns a paginated collection of Product objects from the BigCommerce Catalog 
		 * @throws Exception
		 */
		public Response GetCatalogProductsRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "BigCommerce", bNesisToken, "GetCatalogProductsRaw");
		}
}