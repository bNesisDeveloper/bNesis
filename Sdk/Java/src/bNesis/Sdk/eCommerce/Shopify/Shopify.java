package bNesis.Sdk.eCommerce.Shopify;

import java.io.*;
import java.util.List;
import java.util.Date;
import java.util.Map.Entry;
import bNesis.Api.*;

import bNesis.Sdk.Common.*;
import java.util.Date.*;
import bNesis.Sdk.eCommerce.Shopify.*;
import java.net.URI.*;

	public class Shopify  
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

		public Shopify(bNesisApi bnesisApi)
		{
			this._bNesisApi = bnesisApi;
		}

		/**
		 * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		 * @return {String} bNesisToken value
		 */
		public String Auth(String bNesisDevId,String clientId,String clientSecret,String redirectUrl,String[] scopes) throws Exception
		{
			bNesisToken = _bNesisApi.Auth("Shopify", "",bNesisDevId,redirectUrl,clientId,clientSecret,scopes,"","",false,"");
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
			Boolean result = _bNesisApi.LogoffService("Shopify", bNesisToken);
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
			return _bNesisApi.<ErrorInfo>Call(ErrorInfo.class, "Shopify", bNesisToken, "GetLastError");
		}

		/**
		 *  Getting arrays of error info 	
		 * @return {ErrorInfo[]}  
		 * @throws Exception
		 */
		public ErrorInfo[] GetErrorLog() throws Exception
		{
			return _bNesisApi.<ErrorInfo[]>Call(ErrorInfo[].class, "Shopify", bNesisToken, "GetErrorLog");
		}

		/**
		 *  Checks the token in the service. 	
		 * @return {Boolean} if token valid return true, if token not valid return false 
		 * @throws Exception
		 */
		public Boolean ValidateToken() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "Shopify", bNesisToken, "ValidateToken");
		}

		/**
		 *  Disables the access token used to authenticate the call. 	
		 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false 
		 * @throws Exception
		 */
		public Boolean Logoff() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "Shopify", bNesisToken, "Logoff");
		}

		/**
		 *   	
		 * @param contactItem 
	 * @return {Boolean}  
		 * @throws Exception
		 */
		public Boolean CreateCustomerUnified(ContactItem contactItem) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "Shopify", bNesisToken, "CreateCustomerUnified", contactItem);
		}

		/**
		 *   	
		 * @return {ContactItem[]}  
		 * @throws Exception
		 */
		public ContactItem[] GetCustomersUnified() throws Exception
		{
			return _bNesisApi.<ContactItem[]>Call(ContactItem[].class, "Shopify", bNesisToken, "GetCustomersUnified");
		}

		/**
		 *   	
		 * @param productItem 
	 * @return {Boolean}  
		 * @throws Exception
		 */
		public Boolean AddProductUnified(ProductItem productItem) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "Shopify", bNesisToken, "AddProductUnified", productItem);
		}

		/**
		 *   	
		 * @return {ProductItem[]}  
		 * @throws Exception
		 */
		public ProductItem[] GetProductsUnified() throws Exception
		{
			return _bNesisApi.<ProductItem[]>Call(ProductItem[].class, "Shopify", bNesisToken, "GetProductsUnified");
		}

		/**
		 *   	
		 * @param IdProduct 
	 * @return {Boolean}  
		 * @throws Exception
		 */
		public Boolean DeleteProductUnified(String IdProduct) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "Shopify", bNesisToken, "DeleteProductUnified", IdProduct);
		}

		/**
		 *   	
		 * @return {CountryItem[]}  
		 * @throws Exception
		 */
		public CountryItem[] GetCountriesUnified() throws Exception
		{
			return _bNesisApi.<CountryItem[]>Call(CountryItem[].class, "Shopify", bNesisToken, "GetCountriesUnified");
		}

		/**
		 *   	
		 * @return {Integer}  
		 * @throws Exception
		 */
		public Integer GetCountCountriesUnified() throws Exception
		{
			return _bNesisApi.<Integer>Call(Integer.class, "Shopify", bNesisToken, "GetCountCountriesUnified");
		}

		/**
		 *   	
		 * @param IdCountry 
	 * @return {CountryItem}  
		 * @throws Exception
		 */
		public CountryItem ReceiveCountryUnified(String IdCountry) throws Exception
		{
			return _bNesisApi.<CountryItem>Call(CountryItem.class, "Shopify", bNesisToken, "ReceiveCountryUnified", IdCountry);
		}

		/**
		 *   	
		 * @param IdCountry 
	 * @return {Boolean}  
		 * @throws Exception
		 */
		public Boolean DeleteCountryUnified(String IdCountry) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "Shopify", bNesisToken, "DeleteCountryUnified", IdCountry);
		}

		/**
		 *   	
		 * @param countryItem 
	 * @return {CountryItem}  
		 * @throws Exception
		 */
		public CountryItem CreateCountryUnified(CountryItem countryItem) throws Exception
		{
			return _bNesisApi.<CountryItem>Call(CountryItem.class, "Shopify", bNesisToken, "CreateCountryUnified", countryItem);
		}

		/**
		 *   	
		 * @param countryItem 
	 * @return {CountryItem}  
		 * @throws Exception
		 */
		public CountryItem UpdateCountryUnified(CountryItem countryItem) throws Exception
		{
			return _bNesisApi.<CountryItem>Call(CountryItem.class, "Shopify", bNesisToken, "UpdateCountryUnified", countryItem);
		}

		/**
		 *   	
		 * @param IdCustomer 
	 * @return {ContactItem}  
		 * @throws Exception
		 */
		public ContactItem ReceiveCustomerUnified(String IdCustomer) throws Exception
		{
			return _bNesisApi.<ContactItem>Call(ContactItem.class, "Shopify", bNesisToken, "ReceiveCustomerUnified", IdCustomer);
		}

		/**
		 *  Create a new customer by ShopifyCustomerIn structure 	
		 * @param shopifyCustomerIn bNesis ShopifyCustomerIn
	 * @return {ShopifyCustomerOut} created customer 
		 * @throws Exception
		 */
		public ShopifyCustomerOut CreateCustomer(ShopifyCustomerIn shopifyCustomerIn) throws Exception
		{
			return _bNesisApi.<ShopifyCustomerOut>Call(ShopifyCustomerOut.class, "Shopify", bNesisToken, "CreateCustomer", shopifyCustomerIn);
		}

		/**
		 *  Create a new customer by JSON parameter 	
		 * @param shopifyCustomerInObject Shopify customer JSON
	 * @return {Response} added contact in JSON 
		 * @throws Exception
		 */
		public Response CreateCustomerRaw(Object shopifyCustomerInObject) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Shopify", bNesisToken, "CreateCustomerRaw", shopifyCustomerInObject);
		}

		/**
		 *  Receive a list of all customers as ShopifyCustomersOut 	
		 * @return {ShopifyCustomersOut} list of all customers at JSON 
		 * @throws Exception
		 */
		public ShopifyCustomersOut GetCustomers() throws Exception
		{
			return _bNesisApi.<ShopifyCustomersOut>Call(ShopifyCustomersOut.class, "Shopify", bNesisToken, "GetCustomers");
		}

		/**
		 *  Get all customers as JSON 	
		 * @return {Response} list of all contacts in JSON 
		 * @throws Exception
		 */
		public Response GetCustomersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Shopify", bNesisToken, "GetCustomersRaw");
		}

		/**
		 *  Adds product 	
		 * @param shopifyProductIn 
	 * @return {ShopifyProductOut} added product 
		 * @throws Exception
		 */
		public ShopifyProductOut AddProduct(ShopifyProductIn shopifyProductIn) throws Exception
		{
			return _bNesisApi.<ShopifyProductOut>Call(ShopifyProductOut.class, "Shopify", bNesisToken, "AddProduct", shopifyProductIn);
		}

		/**
		 *  Adds product 	
		 * @param ProductItem Product item
	 * @return {Response} added product 
		 * @throws Exception
		 */
		public Response AddProductRaw(Object ProductItem) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Shopify", bNesisToken, "AddProductRaw", ProductItem);
		}

		/**
		 *   	
		 * @return {ShopifyProductsOut}  
		 * @throws Exception
		 */
		public ShopifyProductsOut GetProducts() throws Exception
		{
			return _bNesisApi.<ShopifyProductsOut>Call(ShopifyProductsOut.class, "Shopify", bNesisToken, "GetProducts");
		}

		/**
		 *  Gets products 	
		 * @return {Response} list of all products 
		 * @throws Exception
		 */
		public Response GetProductsRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Shopify", bNesisToken, "GetProductsRaw");
		}

		/**
		 *   	
		 * @param IdProduct 
	 * @return {Boolean}  
		 * @throws Exception
		 */
		public Boolean DeleteProduct(String IdProduct) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "Shopify", bNesisToken, "DeleteProduct", IdProduct);
		}

		/**
		 *  Removes a product from the shop 	
		 * @param IdProduct The product identifier.
	 * @return {Response} status 
		 * @throws Exception
		 */
		public Response DeleteProductRaw(String IdProduct) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Shopify", bNesisToken, "DeleteProductRaw", IdProduct);
		}

		/**
		 *   	
		 * @return {ShopifyCountriesOut}  
		 * @throws Exception
		 */
		public ShopifyCountriesOut GetCountries() throws Exception
		{
			return _bNesisApi.<ShopifyCountriesOut>Call(ShopifyCountriesOut.class, "Shopify", bNesisToken, "GetCountries");
		}

		/**
		 *  Get a list of all countries 	
		 * @return {Response} list of all countries 
		 * @throws Exception
		 */
		public Response GetCountriesRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Shopify", bNesisToken, "GetCountriesRaw");
		}

		/**
		 *  Gets a count of all countries. 	
		 * @return {Integer} count of all countries. 
		 * @throws Exception
		 */
		public Integer GetCountCountries() throws Exception
		{
			return _bNesisApi.<Integer>Call(Integer.class, "Shopify", bNesisToken, "GetCountCountries");
		}

		/**
		 *  Get a count of all countries. 	
		 * @return {Response} count of all countries. 
		 * @throws Exception
		 */
		public Response GetCountCountriesRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Shopify", bNesisToken, "GetCountCountriesRaw");
		}

		/**
		 *   	
		 * @param IdCountry 
	 * @return {ShopifyCountryOut}  
		 * @throws Exception
		 */
		public ShopifyCountryOut ReceiveCountry(String IdCountry) throws Exception
		{
			return _bNesisApi.<ShopifyCountryOut>Call(ShopifyCountryOut.class, "Shopify", bNesisToken, "ReceiveCountry", IdCountry);
		}

		/**
		 *  Receive a single Country 	
		 * @param IdCountry The identifier.
	 * @return {Response} a single Country 
		 * @throws Exception
		 */
		public Response ReceiveCountryRaw(String IdCountry) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Shopify", bNesisToken, "ReceiveCountryRaw", IdCountry);
		}

		/**
		 *  Deletes a single Country 	
		 * @param IdCountry 
	 * @return {Boolean} result 
		 * @throws Exception
		 */
		public Boolean DeleteCountry(String IdCountry) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "Shopify", bNesisToken, "DeleteCountry", IdCountry);
		}

		/**
		 *  Deletes a single Country 	
		 * @param IdCountry 
	 * @return {Response} status 
		 * @throws Exception
		 */
		public Response DeleteCountryRaw(String IdCountry) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Shopify", bNesisToken, "DeleteCountryRaw", IdCountry);
		}

		/**
		 *  Create a country 	
		 * @param shopifyCountryIn The country.
	 * @return {ShopifyCountryOut} result 
		 * @throws Exception
		 */
		public ShopifyCountryOut CreateCountry(ShopifyCountryIn shopifyCountryIn) throws Exception
		{
			return _bNesisApi.<ShopifyCountryOut>Call(ShopifyCountryOut.class, "Shopify", bNesisToken, "CreateCountry", shopifyCountryIn);
		}

		/**
		 *  Create a country 	
		 * @param shopifyCountryInObject The country.
	 * @return {Response} result 
		 * @throws Exception
		 */
		public Response CreateCountryRaw(Object shopifyCountryInObject) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Shopify", bNesisToken, "CreateCountryRaw", shopifyCountryInObject);
		}

		/**
		 *   	
		 * @param shopifyCountryIn 
	 * @return {ShopifyCountryOut}  
		 * @throws Exception
		 */
		public ShopifyCountryOut UpdateCountry(ShopifyCountryIn shopifyCountryIn) throws Exception
		{
			return _bNesisApi.<ShopifyCountryOut>Call(ShopifyCountryOut.class, "Shopify", bNesisToken, "UpdateCountry", shopifyCountryIn);
		}

		/**
		 *  Update a country 	
		 * @param shopifyCountryInObject The country.
	 * @return {Response} result 
		 * @throws Exception
		 */
		public Response UpdateCountryRaw(Object shopifyCountryInObject) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Shopify", bNesisToken, "UpdateCountryRaw", shopifyCountryInObject);
		}

		/**
		 *  Receive a list of all customers as ShopifyCustomersOut 	
		 * @param IdCustomer 
	 * @return {ShopifyCustomerOut} list of all customers at JSON 
		 * @throws Exception
		 */
		public ShopifyCustomerOut ReceiveCustomer(String IdCustomer) throws Exception
		{
			return _bNesisApi.<ShopifyCustomerOut>Call(ShopifyCustomerOut.class, "Shopify", bNesisToken, "ReceiveCustomer", IdCustomer);
		}

		/**
		 *  Receives a single Customer 	
		 * @param IdCustomer The identifier.
	 * @return {Response} a single Customer 
		 * @throws Exception
		 */
		public Response ReceiveCustomerRaw(String IdCustomer) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Shopify", bNesisToken, "ReceiveCustomerRaw", IdCustomer);
		}

		/**
		 *  Send an account invite for the customer 	
		 * @param IdCustomer result
	 * @return {Response}  
		 * @throws Exception
		 */
		public Response SendDefaultInviteRaw(String IdCustomer) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Shopify", bNesisToken, "SendDefaultInviteRaw", IdCustomer);
		}

		/**
		 *  Sends a customized invite 	
		 * @param Invite invite.
	 * @return {Response} Invite 
		 * @throws Exception
		 */
		public Response SendCustomizedInviteRaw(Object Invite) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Shopify", bNesisToken, "SendCustomizedInviteRaw", Invite);
		}

		/**
		 *   	
		 * @param IdCustomer 
	 * @return {Response}  
		 * @throws Exception
		 */
		public Response CreateAccountActivationUrlRaw(String IdCustomer) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Shopify", bNesisToken, "CreateAccountActivationUrlRaw", IdCustomer);
		}

		/**
		 *  Receive a single Shop 	
		 * @return {Response} Details of current shop 
		 * @throws Exception
		 */
		public Response Shop() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Shopify", bNesisToken, "Shop");
		}
}