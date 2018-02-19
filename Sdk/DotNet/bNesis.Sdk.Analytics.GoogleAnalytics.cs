using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;
using bNesis.Api.Desktop;
using bNesis.Sdk.Common;

namespace bNesis.Sdk.Analytics.GoogleAnalytics
{
	public class GoogleAnalytics  
	{
		public string bNesisToken {get; private set;}
		private DesktopbNesisApi bNesisApi;

		public GoogleAnalytics(DesktopbNesisApi bNesisApi)
		{
			this.bNesisApi = bNesisApi;
		}

		public string Auth(string bNesisDevId,string redirectUrl,string clientId,string clientSecret,string[] scopes)
		{

			bNesisToken = bNesisApi.Auth("Google", string.Empty,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,string.Empty,string.Empty,false,string.Empty);

			return bNesisToken;
		}

		///<summary>
		/// Displays a list of all user accounts 
		/// </summary>
		/// <returns>list of all user accounts</returns>
		public Response GetManagementAccounts()
		{
			return bNesisApi.Call<Response>("GoogleAnalytics", bNesisToken, "GetManagementAccounts");
		}

		///<summary>
		/// Getting last exception for current provider 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo GetLastError()
		{
			return bNesisApi.Call<ErrorInfo>("GoogleAnalytics", bNesisToken, "GetLastError");
		}

		///<summary>
		/// Getting arrays of error info 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo[] GetErrorLog()
		{
			return bNesisApi.Call<ErrorInfo[]>("GoogleAnalytics", bNesisToken, "GetErrorLog");
		}

		///<summary>
		/// Checks the token in the service. 
		/// </summary>
		/// <returns>if token valid return true, if token not valid return false</returns>
		public Boolean ValidateToken()
		{
			return bNesisApi.Call<Boolean>("GoogleAnalytics", bNesisToken, "ValidateToken");
		}

		///<summary>
		/// Disables the access token used to authenticate the call. 
		/// </summary>
		/// <returns>if token revoked method returns true 
		/// if token doesn't support token revocation or token is revoked method returns false</returns>
		public Boolean Logoff()
		{
			return bNesisApi.Call<Boolean>("GoogleAnalytics", bNesisToken, "Logoff");
		}
	}
}