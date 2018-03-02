using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;
using bNesis.Api.Desktop;
using bNesis.Sdk.Common;

namespace bNesis.Sdk.eCommerce.OpenCart
{
	public class OpenCart  
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

		public OpenCart(DesktopbNesisApi bNesisApi)
		{
			this.bNesisApi = bNesisApi;
		}

		/// <summary>
		/// The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		/// </summary>
		/// <returns>bNesisToken value</returns>	
		public string Auth(string data,string bNesisDevId,string redirectUrl,string clientId,string clientSecret,string[] scopes,string login,string password,bool isSandbox,string serviceUrl)
		{
			bNesisToken = bNesisApi.Auth("OpenCart", data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl);
			return bNesisToken;
		}

		/// <summary>
		/// The method stops the authorization session with the service and clears the value of bNesisToken.
		/// </summary>
		/// <returns>true - if service logoff is successful</returns>
		public bool LogoffService()
		{
			bool result = bNesisApi.LogoffService("OpenCart", bNesisToken);
			if (result) bNesisToken = string.Empty;
			return result;             
		}


		///<summary>
		/// Getting last exception for current provider 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo GetLastError()
		{
			return bNesisApi.Call<ErrorInfo>("OpenCart", bNesisToken, "GetLastError");
		}

		///<summary>
		/// Getting arrays of error info 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo[] GetErrorLog()
		{
			return bNesisApi.Call<ErrorInfo[]>("OpenCart", bNesisToken, "GetErrorLog");
		}

		///<summary>
		/// Checks the token in the service. 
		/// </summary>
		/// <returns>if token valid return true, if token not valid return false</returns>
		public Boolean ValidateToken()
		{
			return bNesisApi.Call<Boolean>("OpenCart", bNesisToken, "ValidateToken");
		}

		///<summary>
		/// Disables the access token used to authenticate the call. 
		/// </summary>
		/// <returns>if token revoked method returns true 
		/// if token doesn't support token revocation or token is revoked method returns false</returns>
		public Boolean Logoff()
		{
			return bNesisApi.Call<Boolean>("OpenCart", bNesisToken, "Logoff");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="contactItem"></param>
		/// <returns></returns>
		public Boolean CreateCustomerUnified(ContactItem contactItem)
		{
			return bNesisApi.Call<Boolean>("OpenCart", bNesisToken, "CreateCustomerUnified", contactItem);
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public ContactItem[] GetCustomersUnified()
		{
			return bNesisApi.Call<ContactItem[]>("OpenCart", bNesisToken, "GetCustomersUnified");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="productItem"></param>
		/// <returns></returns>
		public Boolean AddProductUnified(ProductItem productItem)
		{
			return bNesisApi.Call<Boolean>("OpenCart", bNesisToken, "AddProductUnified", productItem);
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public ProductItem[] GetProductsUnified()
		{
			return bNesisApi.Call<ProductItem[]>("OpenCart", bNesisToken, "GetProductsUnified");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="IdProduct"></param>
		/// <returns></returns>
		public Boolean DeleteProductUnified(string IdProduct)
		{
			return bNesisApi.Call<Boolean>("OpenCart", bNesisToken, "DeleteProductUnified", IdProduct);
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public CountryItem[] GetCountriesUnified()
		{
			return bNesisApi.Call<CountryItem[]>("OpenCart", bNesisToken, "GetCountriesUnified");
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public Int32 GetCountCountriesUnified()
		{
			return bNesisApi.Call<Int32>("OpenCart", bNesisToken, "GetCountCountriesUnified");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="IdCountry"></param>
		/// <returns></returns>
		public CountryItem ReceiveCountryUnified(string IdCountry)
		{
			return bNesisApi.Call<CountryItem>("OpenCart", bNesisToken, "ReceiveCountryUnified", IdCountry);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="IdCountry"></param>
		/// <returns></returns>
		public Boolean DeleteCountryUnified(string IdCountry)
		{
			return bNesisApi.Call<Boolean>("OpenCart", bNesisToken, "DeleteCountryUnified", IdCountry);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="countryItem"></param>
		/// <returns></returns>
		public CountryItem CreateCountryUnified(CountryItem countryItem)
		{
			return bNesisApi.Call<CountryItem>("OpenCart", bNesisToken, "CreateCountryUnified", countryItem);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="countryItem"></param>
		/// <returns></returns>
		public CountryItem UpdateCountryUnified(CountryItem countryItem)
		{
			return bNesisApi.Call<CountryItem>("OpenCart", bNesisToken, "UpdateCountryUnified", countryItem);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="IdCustomer"></param>
		/// <returns></returns>
		public ContactItem ReceiveCustomerUnified(string IdCustomer)
		{
			return bNesisApi.Call<ContactItem>("OpenCart", bNesisToken, "ReceiveCustomerUnified", IdCustomer);
		}

		///<summary>
		/// Get list of stores. 
		/// </summary>
		/// <returns>list of stores</returns>
		public Response GetStores()
		{
			return bNesisApi.Call<Response>("OpenCart", bNesisToken, "GetStores");
		}
}
}