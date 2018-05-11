using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;
using bNesis.Api.Desktop;
using bNesis.Sdk.Common;

namespace bNesis.Sdk.eCommerce.Shopify
{
	public class Shopify  
	{
		/// <summary>
		/// bNesisToken is a unique identifier of the current service work session
		/// bNesisToken is relevant only after successful authorization in the service.
		/// The Auth() method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		/// The LogoffService() method stops the authorization session with the service and clears the value of bNesisToken.
		/// </summary>		
		public string bNesisToken {get; private set;}

		/// <summary>
		/// bNesis Core object
		/// </summary>
		private DesktopbNesisApi bNesisApi;

		public Shopify(DesktopbNesisApi bNesisApi)
		{
			this.bNesisApi = bNesisApi;
		}

		/// <summary>
		/// The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		/// </summary>
		/// <returns>bNesisToken value</returns>	
		public string Auth(string bNesisDevId,string redirectUrl)
		{
			bNesisToken = bNesisApi.Auth("Shopify", string.Empty,bNesisDevId,redirectUrl,string.Empty,string.Empty,null,string.Empty,string.Empty,false,string.Empty);
			return bNesisToken;
		}

		/// <summary>
		/// Attach to bNesis session with exists bNesis token
		/// </summary>		
		/// <returns>true if bNesisToken is valid</returns>	
		public bool Auth(string bNesisToken)
		{
		    this.bNesisToken = bNesisToken;			
			return ValidateToken();
		}

		/// <summary>
		/// The method stops the authorization session with the service and clears the value of bNesisToken.
		/// </summary>
		/// <returns>true - if service logoff is successful</returns>
		public bool LogoffService()
		{
			bool result = bNesisApi.LogoffService("Shopify", bNesisToken);
			if (result) bNesisToken = string.Empty;
			return result;             
		}


		///<summary>
		/// Getting last exception for current provider 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo GetLastError()
		{
			return bNesisApi.Call<ErrorInfo>("Shopify", bNesisToken, "GetLastError");
		}

		///<summary>
		/// Getting arrays of error info 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo[] GetErrorLog()
		{
			return bNesisApi.Call<ErrorInfo[]>("Shopify", bNesisToken, "GetErrorLog");
		}

		///<summary>
		/// Checks the token in the service. 
		/// </summary>
		/// <returns>if token valid return true, if token not valid return false</returns>
		public Boolean ValidateToken()
		{
			return bNesisApi.Call<Boolean>("Shopify", bNesisToken, "ValidateToken");
		}

		///<summary>
		/// Disables the access token used to authenticate the call. 
		/// </summary>
		/// <returns>if token revoked method returns true 
		/// if token doesn't support token revocation or token is revoked method returns false</returns>
		public Boolean Logoff()
		{
			return bNesisApi.Call<Boolean>("Shopify", bNesisToken, "Logoff");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="contactItem"></param>
		/// <returns></returns>
		public Boolean CreateCustomerUnified(ContactItem contactItem)
		{
			return bNesisApi.Call<Boolean>("Shopify", bNesisToken, "CreateCustomerUnified", contactItem);
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public ContactItem[] GetCustomersUnified()
		{
			return bNesisApi.Call<ContactItem[]>("Shopify", bNesisToken, "GetCustomersUnified");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="productItem"></param>
		/// <returns></returns>
		public Boolean AddProductUnified(ProductItem productItem)
		{
			return bNesisApi.Call<Boolean>("Shopify", bNesisToken, "AddProductUnified", productItem);
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public ProductItem[] GetProductsUnified()
		{
			return bNesisApi.Call<ProductItem[]>("Shopify", bNesisToken, "GetProductsUnified");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="IdProduct"></param>
		/// <returns></returns>
		public Boolean DeleteProductUnified(string IdProduct)
		{
			return bNesisApi.Call<Boolean>("Shopify", bNesisToken, "DeleteProductUnified", IdProduct);
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public CountryItem[] GetCountriesUnified()
		{
			return bNesisApi.Call<CountryItem[]>("Shopify", bNesisToken, "GetCountriesUnified");
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public Int32 GetCountCountriesUnified()
		{
			return bNesisApi.Call<Int32>("Shopify", bNesisToken, "GetCountCountriesUnified");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="IdCountry"></param>
		/// <returns></returns>
		public CountryItem ReceiveCountryUnified(string IdCountry)
		{
			return bNesisApi.Call<CountryItem>("Shopify", bNesisToken, "ReceiveCountryUnified", IdCountry);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="IdCountry"></param>
		/// <returns></returns>
		public Boolean DeleteCountryUnified(string IdCountry)
		{
			return bNesisApi.Call<Boolean>("Shopify", bNesisToken, "DeleteCountryUnified", IdCountry);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="countryItem"></param>
		/// <returns></returns>
		public CountryItem CreateCountryUnified(CountryItem countryItem)
		{
			return bNesisApi.Call<CountryItem>("Shopify", bNesisToken, "CreateCountryUnified", countryItem);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="countryItem"></param>
		/// <returns></returns>
		public CountryItem UpdateCountryUnified(CountryItem countryItem)
		{
			return bNesisApi.Call<CountryItem>("Shopify", bNesisToken, "UpdateCountryUnified", countryItem);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="IdCustomer"></param>
		/// <returns></returns>
		public ContactItem ReceiveCustomerUnified(string IdCustomer)
		{
			return bNesisApi.Call<ContactItem>("Shopify", bNesisToken, "ReceiveCustomerUnified", IdCustomer);
		}

		///<summary>
		/// Create a new customer by ShopifyCustomerIn structure 
		/// </summary>
		/// <param name="shopifyCustomerIn">bNesis ShopifyCustomerIn</param>
		/// <returns>created customer</returns>
		public ShopifyCustomerOut CreateCustomer(ShopifyCustomerIn shopifyCustomerIn)
		{
			return bNesisApi.Call<ShopifyCustomerOut>("Shopify", bNesisToken, "CreateCustomer", shopifyCustomerIn);
		}

		///<summary>
		/// Create a new customer by JSON parameter 
		/// </summary>
		/// <param name="shopifyCustomerInObject">Shopify customer JSON</param>
		/// <returns>added contact in JSON</returns>
		public Response CreateCustomerRaw(Object shopifyCustomerInObject)
		{
			return bNesisApi.Call<Response>("Shopify", bNesisToken, "CreateCustomerRaw", shopifyCustomerInObject);
		}

		///<summary>
		/// Receive a list of all customers as ShopifyCustomersOut 
		/// </summary>
		/// <returns>list of all customers at JSON</returns>
		public ShopifyCustomersOut GetCustomers()
		{
			return bNesisApi.Call<ShopifyCustomersOut>("Shopify", bNesisToken, "GetCustomers");
		}

		///<summary>
		/// Get all customers as JSON 
		/// </summary>
		/// <returns>list of all contacts in JSON</returns>
		public Response GetCustomersRaw()
		{
			return bNesisApi.Call<Response>("Shopify", bNesisToken, "GetCustomersRaw");
		}

		///<summary>
		/// Adds product 
		/// </summary>
		/// <param name="shopifyProductIn"></param>
		/// <returns>added product</returns>
		public ShopifyProductOut AddProduct(ShopifyProductIn shopifyProductIn)
		{
			return bNesisApi.Call<ShopifyProductOut>("Shopify", bNesisToken, "AddProduct", shopifyProductIn);
		}

		///<summary>
		/// Adds product 
		/// </summary>
		/// <param name="ProductItem">Product item</param>
		/// <returns>added product</returns>
		public Response AddProductRaw(Object ProductItem)
		{
			return bNesisApi.Call<Response>("Shopify", bNesisToken, "AddProductRaw", ProductItem);
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public ShopifyProductsOut GetProducts()
		{
			return bNesisApi.Call<ShopifyProductsOut>("Shopify", bNesisToken, "GetProducts");
		}

		///<summary>
		/// Gets products 
		/// </summary>
		/// <returns>list of all products</returns>
		public Response GetProductsRaw()
		{
			return bNesisApi.Call<Response>("Shopify", bNesisToken, "GetProductsRaw");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="IdProduct"></param>
		/// <returns></returns>
		public Boolean DeleteProduct(string IdProduct)
		{
			return bNesisApi.Call<Boolean>("Shopify", bNesisToken, "DeleteProduct", IdProduct);
		}

		///<summary>
		/// Removes a product from the shop 
		/// </summary>
		/// <param name="IdProduct">The product identifier.</param>
		/// <returns>status</returns>
		public Response DeleteProductRaw(string IdProduct)
		{
			return bNesisApi.Call<Response>("Shopify", bNesisToken, "DeleteProductRaw", IdProduct);
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public ShopifyCountriesOut GetCountries()
		{
			return bNesisApi.Call<ShopifyCountriesOut>("Shopify", bNesisToken, "GetCountries");
		}

		///<summary>
		/// Get a list of all countries 
		/// </summary>
		/// <returns>list of all countries</returns>
		public Response GetCountriesRaw()
		{
			return bNesisApi.Call<Response>("Shopify", bNesisToken, "GetCountriesRaw");
		}

		///<summary>
		/// Gets a count of all countries. 
		/// </summary>
		/// <returns>count of all countries.</returns>
		public Int32 GetCountCountries()
		{
			return bNesisApi.Call<Int32>("Shopify", bNesisToken, "GetCountCountries");
		}

		///<summary>
		/// Get a count of all countries. 
		/// </summary>
		/// <returns>count of all countries.</returns>
		public Response GetCountCountriesRaw()
		{
			return bNesisApi.Call<Response>("Shopify", bNesisToken, "GetCountCountriesRaw");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="IdCountry"></param>
		/// <returns></returns>
		public ShopifyCountryOut ReceiveCountry(string IdCountry)
		{
			return bNesisApi.Call<ShopifyCountryOut>("Shopify", bNesisToken, "ReceiveCountry", IdCountry);
		}

		///<summary>
		/// Receive a single Country 
		/// </summary>
		/// <param name="IdCountry">The identifier.</param>
		/// <returns>a single Country</returns>
		public Response ReceiveCountryRaw(string IdCountry)
		{
			return bNesisApi.Call<Response>("Shopify", bNesisToken, "ReceiveCountryRaw", IdCountry);
		}

		///<summary>
		/// Deletes a single Country 
		/// </summary>
		/// <param name="IdCountry"></param>
		/// <returns>result</returns>
		public Boolean DeleteCountry(string IdCountry)
		{
			return bNesisApi.Call<Boolean>("Shopify", bNesisToken, "DeleteCountry", IdCountry);
		}

		///<summary>
		/// Deletes a single Country 
		/// </summary>
		/// <param name="IdCountry"></param>
		/// <returns>status</returns>
		public Response DeleteCountryRaw(string IdCountry)
		{
			return bNesisApi.Call<Response>("Shopify", bNesisToken, "DeleteCountryRaw", IdCountry);
		}

		///<summary>
		/// Create a country 
		/// </summary>
		/// <param name="shopifyCountryIn">The country.</param>
		/// <returns>result</returns>
		public ShopifyCountryOut CreateCountry(ShopifyCountryIn shopifyCountryIn)
		{
			return bNesisApi.Call<ShopifyCountryOut>("Shopify", bNesisToken, "CreateCountry", shopifyCountryIn);
		}

		///<summary>
		/// Create a country 
		/// </summary>
		/// <param name="shopifyCountryInObject">The country.</param>
		/// <returns>result</returns>
		public Response CreateCountryRaw(Object shopifyCountryInObject)
		{
			return bNesisApi.Call<Response>("Shopify", bNesisToken, "CreateCountryRaw", shopifyCountryInObject);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="shopifyCountryIn"></param>
		/// <returns></returns>
		public ShopifyCountryOut UpdateCountry(ShopifyCountryIn shopifyCountryIn)
		{
			return bNesisApi.Call<ShopifyCountryOut>("Shopify", bNesisToken, "UpdateCountry", shopifyCountryIn);
		}

		///<summary>
		/// Update a country 
		/// </summary>
		/// <param name="shopifyCountryInObject">The country.</param>
		/// <returns>result</returns>
		public Response UpdateCountryRaw(Object shopifyCountryInObject)
		{
			return bNesisApi.Call<Response>("Shopify", bNesisToken, "UpdateCountryRaw", shopifyCountryInObject);
		}

		///<summary>
		/// Receive a list of all customers as ShopifyCustomersOut 
		/// </summary>
		/// <param name="IdCustomer"></param>
		/// <returns>list of all customers at JSON</returns>
		public ShopifyCustomerOut ReceiveCustomer(string IdCustomer)
		{
			return bNesisApi.Call<ShopifyCustomerOut>("Shopify", bNesisToken, "ReceiveCustomer", IdCustomer);
		}

		///<summary>
		/// Receives a single Customer 
		/// </summary>
		/// <param name="IdCustomer">The identifier.</param>
		/// <returns>a single Customer</returns>
		public Response ReceiveCustomerRaw(string IdCustomer)
		{
			return bNesisApi.Call<Response>("Shopify", bNesisToken, "ReceiveCustomerRaw", IdCustomer);
		}

		///<summary>
		/// Send an account invite for the customer 
		/// </summary>
		/// <param name="IdCustomer">result</param>
		/// <returns></returns>
		public Response SendDefaultInviteRaw(string IdCustomer)
		{
			return bNesisApi.Call<Response>("Shopify", bNesisToken, "SendDefaultInviteRaw", IdCustomer);
		}

		///<summary>
		/// Sends a customized invite 
		/// </summary>
		/// <param name="Invite">invite.</param>
		/// <returns>Invite</returns>
		public Response SendCustomizedInviteRaw(Object Invite)
		{
			return bNesisApi.Call<Response>("Shopify", bNesisToken, "SendCustomizedInviteRaw", Invite);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="IdCustomer"></param>
		/// <returns></returns>
		public Response CreateAccountActivationUrlRaw(string IdCustomer)
		{
			return bNesisApi.Call<Response>("Shopify", bNesisToken, "CreateAccountActivationUrlRaw", IdCustomer);
		}

		///<summary>
		/// Receive a single Shop 
		/// </summary>
		/// <returns>Details of current shop</returns>
		public Response Shop()
		{
			return bNesisApi.Call<Response>("Shopify", bNesisToken, "Shop");
		}
}
	public class ShopifyAddressOut
	{
		public string id { get; set; }

		public string address1 { get; set; }

		public string address2 { get; set; }

		public string city { get; set; }

		public string name { get; set; }

		public string company { get; set; }

		public string country { get; set; }

		public string country_code { get; set; }

		public Double latitude { get; set; }

		public Double longitude { get; set; }

		public string first_name { get; set; }

		public string last_name { get; set; }

		public string phone { get; set; }

		public string province { get; set; }

		public string province_code { get; set; }

		public string zip { get; set; }

	}

	public class ShopifyCustomerItemOut
	{
		public Int64 id { get; set; }

		public string email { get; set; }

		public Boolean accepts_marketing { get; set; }

		public DateTime created_at { get; set; }

		public DateTime updated_at { get; set; }

		public string first_name { get; set; }

		public string last_name { get; set; }

		public Int64 orders_count { get; set; }

		public string state { get; set; }

		public string total_spent { get; set; }

		public Int64 last_order_id { get; set; }

		public string note { get; set; }

		public Boolean verified_email { get; set; }

		public string multipass_identifier { get; set; }

		public Boolean tax_exempt { get; set; }

		public string phone { get; set; }

		public string tags { get; set; }

		public string last_order_name { get; set; }

		public ShopifyAddressOut[] addresses { get; set; }

		public ShopifyAddressOut default_address { get; set; }

	}

	public class ShopifyCustomerOut
	{
		public ShopifyCustomerItemOut customer { get; set; }

	}

	public class ShopifyAddressIn
	{
		public string address1 { get; set; }

		public string address2 { get; set; }

		public string city { get; set; }

		public string name { get; set; }

		public string company { get; set; }

		public string country { get; set; }

		public string country_code { get; set; }

		public Double latitude { get; set; }

		public Double longitude { get; set; }

		public string first_name { get; set; }

		public string last_name { get; set; }

		public string phone { get; set; }

		public string province { get; set; }

		public string province_code { get; set; }

		public string zip { get; set; }

	}

	public class ShopifyMetafields
	{
		public string key { get; set; }

		public string namespace_ { get; set; }

		public string value { get; set; }

		public string value_type { get; set; }

	}

	///<summary>
	/// Shopify customer item 
	/// </summary>
	public class ShopifyCustomerItemIn
	{
		/// <summary>
		/// customet id 
		/// </summary>
		public Int32 id { get; set; }

		/// <summary>
		/// customer email 
		/// </summary>
		public string email { get; set; }

		public Boolean accepts_marketing { get; set; }

		public DateTime created_at { get; set; }

		public DateTime updated_at { get; set; }

		public string first_name { get; set; }

		public string last_name { get; set; }

		public Int32 orders_count { get; set; }

		public string state { get; set; }

		public string total_spent { get; set; }

		public Int32 last_order_id { get; set; }

		public string note { get; set; }

		public Boolean verified_email { get; set; }

		public string multipass_identifier { get; set; }

		public Boolean tax_exempt { get; set; }

		public string phone { get; set; }

		public string tags { get; set; }

		public string last_order_name { get; set; }

		public ShopifyAddressIn[] addresses { get; set; }

		public string password { get; set; }

		public string password_confirmation { get; set; }

		public Boolean send_email_invite { get; set; }

		public Boolean send_email_welcome { get; set; }

		public ShopifyMetafields[] metafields { get; set; }

	}

	public class ShopifyCustomerIn
	{
		public ShopifyCustomerItemIn customer { get; set; }

	}

	public class ShopifyCustomersOut
	{
		public ShopifyCustomerItemOut[] customers { get; set; }

	}

	public class ShopifyImage
	{
		public string attachment { get; set; }

		public string src { get; set; }

	}

	public class ShopifyOptions
	{
		public string name { get; set; }

	}

	public class ShopifyVariants
	{
		public string barcode { get; set; }

		public string compare_at_price { get; set; }

		public Nullable<DateTime> created_at { get; set; }

		public string fulfillment_service { get; set; }

		public Nullable<Int64> grams { get; set; }

		public Nullable<Int64> id { get; set; }

		public Nullable<Int64> image_id { get; set; }

		public string inventory_management { get; set; }

		public string inventory_policy { get; set; }

		public Nullable<Int64> inventory_quantity { get; set; }

		public string inventory_quantity_adjustment { get; set; }

		public ShopifyMetafields[] metafields { get; set; }

		public Nullable<Int64> old_inventory_quantity { get; set; }

		public string option1 { get; set; }

		public string option2 { get; set; }

		public string option3 { get; set; }

		public Nullable<Int64> position { get; set; }

		public string price { get; set; }

		public Nullable<Int64> product_id { get; set; }

		public Nullable<Boolean> requires_shipping { get; set; }

		public string sku { get; set; }

		public Nullable<Boolean> taxable { get; set; }

		public string title { get; set; }

		public Nullable<DateTime> updated_at { get; set; }

		public Nullable<Int64> weight { get; set; }

		public string weight_unit { get; set; }

	}

	///<summary>
	/// Shopify customer item 
	/// </summary>
	public class ShopifyProductItemOut
	{
		public Nullable<DateTime> updated_at { get; set; }

		public string vendor { get; set; }

		public string product_type { get; set; }

		public Nullable<DateTime> published_at { get; set; }

		public string published_scope { get; set; }

		public Nullable<Boolean> published { get; set; }

		public string tags { get; set; }

		public string template_suffix { get; set; }

		public string title { get; set; }

		public string metafields_global_description_tag { get; set; }

		public string metafields_global_title_tag { get; set; }

		public string body_html { get; set; }

		public Nullable<DateTime> created_at { get; set; }

		public string handle { get; set; }

		public string id { get; set; }

		public ShopifyImage image { get; set; }

		public ShopifyImage[] images { get; set; }

		public ShopifyMetafields[] metafields { get; set; }

		public ShopifyOptions[] options { get; set; }

		public ShopifyVariants[] variants { get; set; }

	}

	public class ShopifyProductOut
	{
		public ShopifyProductItemOut product { get; set; }

	}

	///<summary>
	/// Shopify customer item 
	/// </summary>
	public class ShopifyProductItemIn
	{
		public Nullable<DateTime> updated_at { get; set; }

		public string vendor { get; set; }

		public string product_type { get; set; }

		public Nullable<DateTime> published_at { get; set; }

		public string published_scope { get; set; }

		public Nullable<Boolean> published { get; set; }

		public string tags { get; set; }

		public string template_suffix { get; set; }

		public string title { get; set; }

		public string metafields_global_description_tag { get; set; }

		public string metafields_global_title_tag { get; set; }

		public string body_html { get; set; }

		public Nullable<DateTime> created_at { get; set; }

		public string handle { get; set; }

		public string id { get; set; }

		public ShopifyImage image { get; set; }

		public ShopifyImage[] images { get; set; }

		public ShopifyMetafields[] metafields { get; set; }

		public ShopifyOptions[] options { get; set; }

		public ShopifyVariants[] variants { get; set; }

	}

	public class ShopifyProductIn
	{
		public ShopifyProductItemIn product { get; set; }

	}

	public class ShopifyProductsOut
	{
		public ShopifyProductItemOut[] products { get; set; }

	}

	public class ShopifyProvinces
	{
		public string code { get; set; }

		public Nullable<Int64> country_id { get; set; }

		public Nullable<Int64> id { get; set; }

		public string name { get; set; }

		public Nullable<Int64> shipping_zone_id { get; set; }

		public Nullable<Double> tax { get; set; }

		public string tax_name { get; set; }

		public Nullable<Double> tax_percentage { get; set; }

	}

	///<summary>
	/// Shopify customer item 
	/// </summary>
	public class ShopifyCountryItemOut
	{
		public string code { get; set; }

		public Nullable<Int64> id { get; set; }

		public string name { get; set; }

		public ShopifyProvinces[] provinces { get; set; }

		public Nullable<Double> tax { get; set; }

		public string tax_name { get; set; }

	}

	public class ShopifyCountriesOut
	{
		public ShopifyCountryItemOut[] countries { get; set; }

	}

	public class ShopifyCountryOut
	{
		public ShopifyCountryItemOut country { get; set; }

	}

	public class ShopifyCountryItemIn
	{
		public string code { get; set; }

		public Nullable<Int64> id { get; set; }

		public string name { get; set; }

		public ShopifyProvinces[] provinces { get; set; }

		public Nullable<Double> tax { get; set; }

		public string tax_name { get; set; }

	}

	public class ShopifyCountryIn
	{
		public ShopifyCountryItemIn country { get; set; }

	}

}