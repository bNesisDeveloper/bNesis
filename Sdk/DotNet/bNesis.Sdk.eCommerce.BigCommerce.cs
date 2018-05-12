using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;
using bNesis.Api.Desktop;
using bNesis.Sdk.Common;

namespace bNesis.Sdk.eCommerce.BigCommerce
{
	public class BigCommerce  
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

		public BigCommerce(DesktopbNesisApi bNesisApi)
		{
			this.bNesisApi = bNesisApi;
		}

		/// <summary>
		/// The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		/// </summary>
		/// <returns>bNesisToken value</returns>	
		public string Auth(string bNesisDevId,string redirectUrl,string login,string password,string data)
		{
			bNesisToken = bNesisApi.Auth("BigCommerce", data,bNesisDevId,redirectUrl,string.Empty,string.Empty,null,login,password,false,string.Empty);
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
			bool result = bNesisApi.LogoffService("BigCommerce", bNesisToken);
			if (result) bNesisToken = string.Empty;
			return result;             
		}


		///<summary>
		/// Getting last exception for current provider 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo GetLastError()
		{
			return bNesisApi.Call<ErrorInfo>("BigCommerce", bNesisToken, "GetLastError");
		}

		///<summary>
		/// Getting arrays of error info 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo[] GetErrorLog()
		{
			return bNesisApi.Call<ErrorInfo[]>("BigCommerce", bNesisToken, "GetErrorLog");
		}

		///<summary>
		/// Checks the token in the service. 
		/// </summary>
		/// <returns>if token valid return true, if token not valid return false</returns>
		public Boolean ValidateToken()
		{
			return bNesisApi.Call<Boolean>("BigCommerce", bNesisToken, "ValidateToken");
		}

		///<summary>
		/// Disables the access token used to authenticate the call. 
		/// </summary>
		/// <returns>if token revoked method returns true 
		/// if token doesn't support token revocation or token is revoked method returns false</returns>
		public Boolean Logoff()
		{
			return bNesisApi.Call<Boolean>("BigCommerce", bNesisToken, "Logoff");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="contactItem"></param>
		/// <returns></returns>
		public Boolean CreateCustomerUnified(ContactItem contactItem)
		{
			return bNesisApi.Call<Boolean>("BigCommerce", bNesisToken, "CreateCustomerUnified", contactItem);
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public ContactItem[] GetCustomersUnified()
		{
			return bNesisApi.Call<ContactItem[]>("BigCommerce", bNesisToken, "GetCustomersUnified");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="productItem"></param>
		/// <returns></returns>
		public Boolean AddProductUnified(ProductItem productItem)
		{
			return bNesisApi.Call<Boolean>("BigCommerce", bNesisToken, "AddProductUnified", productItem);
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public ProductItem[] GetProductsUnified()
		{
			return bNesisApi.Call<ProductItem[]>("BigCommerce", bNesisToken, "GetProductsUnified");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="IdProduct"></param>
		/// <returns></returns>
		public Boolean DeleteProductUnified(string IdProduct)
		{
			return bNesisApi.Call<Boolean>("BigCommerce", bNesisToken, "DeleteProductUnified", IdProduct);
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public CountryItem[] GetCountriesUnified()
		{
			return bNesisApi.Call<CountryItem[]>("BigCommerce", bNesisToken, "GetCountriesUnified");
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public Int32 GetCountCountriesUnified()
		{
			return bNesisApi.Call<Int32>("BigCommerce", bNesisToken, "GetCountCountriesUnified");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="IdCountry"></param>
		/// <returns></returns>
		public CountryItem ReceiveCountryUnified(string IdCountry)
		{
			return bNesisApi.Call<CountryItem>("BigCommerce", bNesisToken, "ReceiveCountryUnified", IdCountry);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="IdCountry"></param>
		/// <returns></returns>
		public Boolean DeleteCountryUnified(string IdCountry)
		{
			return bNesisApi.Call<Boolean>("BigCommerce", bNesisToken, "DeleteCountryUnified", IdCountry);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="countryItem"></param>
		/// <returns></returns>
		public CountryItem CreateCountryUnified(CountryItem countryItem)
		{
			return bNesisApi.Call<CountryItem>("BigCommerce", bNesisToken, "CreateCountryUnified", countryItem);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="countryItem"></param>
		/// <returns></returns>
		public CountryItem UpdateCountryUnified(CountryItem countryItem)
		{
			return bNesisApi.Call<CountryItem>("BigCommerce", bNesisToken, "UpdateCountryUnified", countryItem);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="IdCustomer"></param>
		/// <returns></returns>
		public ContactItem ReceiveCustomerUnified(string IdCustomer)
		{
			return bNesisApi.Call<ContactItem>("BigCommerce", bNesisToken, "ReceiveCustomerUnified", IdCustomer);
		}

		///<summary>
		/// Gets the catalog products. 
		/// </summary>
		/// <returns>Returns a paginated collection of Product objects from the BigCommerce Catalog</returns>
		public Response GetCatalogProductsRaw()
		{
			return bNesisApi.Call<Response>("BigCommerce", bNesisToken, "GetCatalogProductsRaw");
		}
}
}