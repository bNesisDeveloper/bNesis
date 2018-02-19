using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;
using bNesis.Api.Desktop;
using bNesis.Sdk.Common;

namespace bNesis.Sdk.eCommerce.Amazon
{
	public class Amazon  
	{
		public string bNesisToken {get; private set;}
		private DesktopbNesisApi bNesisApi;

		public Amazon(DesktopbNesisApi bNesisApi)
		{
			this.bNesisApi = bNesisApi;
		}

		public string Auth(string data,string bNesisDevId,string redirectUrl,string clientId,string clientSecret,string[] scopes,string login,string password,bool isSandbox,string serviceUrl)
		{

			bNesisToken = bNesisApi.Auth("Amazon", data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl);

			return bNesisToken;
		}

		///<summary>
		/// Getting last exception for current provider 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo GetLastError()
		{
			return bNesisApi.Call<ErrorInfo>("Amazon", bNesisToken, "GetLastError");
		}

		///<summary>
		/// Getting arrays of error info 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo[] GetErrorLog()
		{
			return bNesisApi.Call<ErrorInfo[]>("Amazon", bNesisToken, "GetErrorLog");
		}

		///<summary>
		/// Checks the token in the service. 
		/// </summary>
		/// <returns>if token valid return true, if token not valid return false</returns>
		public Boolean ValidateToken()
		{
			return bNesisApi.Call<Boolean>("Amazon", bNesisToken, "ValidateToken");
		}

		///<summary>
		/// Disables the access token used to authenticate the call. 
		/// </summary>
		/// <returns>if token revoked method returns true 
		/// if token doesn't support token revocation or token is revoked method returns false</returns>
		public Boolean Logoff()
		{
			return bNesisApi.Call<Boolean>("Amazon", bNesisToken, "Logoff");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="contactItem"></param>
		/// <returns></returns>
		public Boolean CreateCustomerUnified(ContactItem contactItem)
		{
			return bNesisApi.Call<Boolean>("Amazon", bNesisToken, "CreateCustomerUnified", contactItem);
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public ContactItem[] GetCustomersUnified()
		{
			return bNesisApi.Call<ContactItem[]>("Amazon", bNesisToken, "GetCustomersUnified");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="productItem"></param>
		/// <returns></returns>
		public Boolean AddProductUnified(ProductItem productItem)
		{
			return bNesisApi.Call<Boolean>("Amazon", bNesisToken, "AddProductUnified", productItem);
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public ProductItem[] GetProductsUnified()
		{
			return bNesisApi.Call<ProductItem[]>("Amazon", bNesisToken, "GetProductsUnified");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="IdProduct"></param>
		/// <returns></returns>
		public Boolean DeleteProductUnified(string IdProduct)
		{
			return bNesisApi.Call<Boolean>("Amazon", bNesisToken, "DeleteProductUnified", IdProduct);
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public CountryItem[] GetCountriesUnified()
		{
			return bNesisApi.Call<CountryItem[]>("Amazon", bNesisToken, "GetCountriesUnified");
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public Int32 GetCountCountriesUnified()
		{
			return bNesisApi.Call<Int32>("Amazon", bNesisToken, "GetCountCountriesUnified");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="IdCountry"></param>
		/// <returns></returns>
		public CountryItem ReceiveCountryUnified(string IdCountry)
		{
			return bNesisApi.Call<CountryItem>("Amazon", bNesisToken, "ReceiveCountryUnified", IdCountry);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="IdCountry"></param>
		/// <returns></returns>
		public Boolean DeleteCountryUnified(string IdCountry)
		{
			return bNesisApi.Call<Boolean>("Amazon", bNesisToken, "DeleteCountryUnified", IdCountry);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="countryItem"></param>
		/// <returns></returns>
		public CountryItem CreateCountryUnified(CountryItem countryItem)
		{
			return bNesisApi.Call<CountryItem>("Amazon", bNesisToken, "CreateCountryUnified", countryItem);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="countryItem"></param>
		/// <returns></returns>
		public CountryItem UpdateCountryUnified(CountryItem countryItem)
		{
			return bNesisApi.Call<CountryItem>("Amazon", bNesisToken, "UpdateCountryUnified", countryItem);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="IdCustomer"></param>
		/// <returns></returns>
		public ContactItem ReceiveCustomerUnified(string IdCustomer)
		{
			return bNesisApi.Call<ContactItem>("Amazon", bNesisToken, "ReceiveCustomerUnified", IdCustomer);
		}

		///<summary>
		/// Gets the user profile. 
		/// </summary>
		/// <returns>Data with info about user</returns>
		public Response GetUserProfileRaw()
		{
			return bNesisApi.Call<Response>("Amazon", bNesisToken, "GetUserProfileRaw");
		}
	}
}