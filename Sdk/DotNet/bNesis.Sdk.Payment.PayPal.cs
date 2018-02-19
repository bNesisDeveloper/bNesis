using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;
using bNesis.Api.Desktop;
using bNesis.Sdk.Common;

namespace bNesis.Sdk.Payment.PayPal
{
	public class PayPal  
	{
		public string bNesisToken {get; private set;}
		private DesktopbNesisApi bNesisApi;

		public PayPal(DesktopbNesisApi bNesisApi)
		{
			this.bNesisApi = bNesisApi;
		}

		public string Auth(string data,string bNesisDevId,string redirectUrl,string clientId,string clientSecret,string[] scopes,string login,string password,bool isSandbox,string serviceUrl)
		{

			bNesisToken = bNesisApi.Auth("PayPal", data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl);

			return bNesisToken;
		}

		///<summary>
		/// Getting last exception for current provider 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo GetLastError()
		{
			return bNesisApi.Call<ErrorInfo>("PayPal", bNesisToken, "GetLastError");
		}

		///<summary>
		/// Getting arrays of error info 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo[] GetErrorLog()
		{
			return bNesisApi.Call<ErrorInfo[]>("PayPal", bNesisToken, "GetErrorLog");
		}

		///<summary>
		/// Checks the token in the service. 
		/// </summary>
		/// <returns>if token valid return true, if token not valid return false</returns>
		public Boolean ValidateToken()
		{
			return bNesisApi.Call<Boolean>("PayPal", bNesisToken, "ValidateToken");
		}

		///<summary>
		/// Disables the access token used to authenticate the call. 
		/// </summary>
		/// <returns>if token revoked method returns true 
		/// if token doesn't support token revocation or token is revoked method returns false</returns>
		public Boolean Logoff()
		{
			return bNesisApi.Call<Boolean>("PayPal", bNesisToken, "Logoff");
		}

		///<summary>
		/// sale 
		/// </summary>
		/// <param name="sale_id">sale_id.</param>
		/// <returns>Returns ExpandoObject.</returns>
		public ExpandoObject sale(string sale_id)
		{
			return bNesisApi.Call<ExpandoObject>("PayPal", bNesisToken, "sale", sale_id);
		}

		///<summary>
		/// get_credit_cards 
		/// </summary>
		/// <returns>Returns ExpandoObject.</returns>
		public ExpandoObject get_credit_cards()
		{
			return bNesisApi.Call<ExpandoObject>("PayPal", bNesisToken, "get_credit_cards");
		}

		///<summary>
		/// get_user_info 
		/// </summary>
		/// <returns>Returns Response.</returns>
		public Response get_user_infoRaw()
		{
			return bNesisApi.Call<Response>("PayPal", bNesisToken, "get_user_infoRaw");
		}
	}
}