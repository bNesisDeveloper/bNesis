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

		public GoogleAnalytics(DesktopbNesisApi bNesisApi)
		{
			this.bNesisApi = bNesisApi;
		}

		/// <summary>
		/// The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		/// </summary>
		/// <returns>bNesisToken value</returns>	
		public string Auth(string bNesisDevId,string clientId,string clientSecret,string redirectUrl,string[] scopes)
		{
			bNesisToken = bNesisApi.Auth("Google", string.Empty,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,string.Empty,string.Empty,false,string.Empty);
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
			bool result = bNesisApi.LogoffService("Google", bNesisToken);
			if (result) bNesisToken = string.Empty;
			return result;             
		}


		///<summary>
		/// Gets a list of all user accounts. 
		/// </summary>
		/// <returns>Response.</returns>
		public Response GetManagementAccounts()
		{
			return bNesisApi.Call<Response>("GoogleAnalytics", bNesisToken, "GetManagementAccounts");
		}

		///<summary>
		/// Gets list of webproperties to which user have access. 
		/// </summary>
		/// <param name="accountId">Account identifier.</param>
		/// <returns>Response.</returns>
		public Response GetWebProperties(string accountId)
		{
			return bNesisApi.Call<Response>("GoogleAnalytics", bNesisToken, "GetWebProperties", accountId);
		}

		///<summary>
		/// Gets a webproperty information. 
		/// </summary>
		/// <param name="accountId">Account identifier.</param>
		/// <param name="webpropertyId">Web property identifier. (Format:code-XXXXX-YY)</param>
		/// <returns>Response.</returns>
		public Response GetWebProperty(string accountId, string webpropertyId)
		{
			return bNesisApi.Call<Response>("GoogleAnalytics", bNesisToken, "GetWebProperty", accountId, webpropertyId);
		}

		///<summary>
		/// Gets a view profiles to which the user have access. 
		/// </summary>
		/// <param name="accountId">Account identifier.</param>
		/// <param name="webpropertyId">Web property identifier. (Format:code-XXXXX-YY)</param>
		/// <returns>Response.</returns>
		public Response GetWebPropertyProfiles(string accountId, string webpropertyId)
		{
			return bNesisApi.Call<Response>("GoogleAnalytics", bNesisToken, "GetWebPropertyProfiles", accountId, webpropertyId);
		}

		///<summary>
		/// Gets analytics data. 
		/// </summary>
		/// <param name="reportRequest">The report request.</param>
		/// <returns>Return in response.</returns>
		public Response GetReportsBatchRaw(string reportRequest)
		{
			return bNesisApi.Call<Response>("GoogleAnalytics", bNesisToken, "GetReportsBatchRaw", reportRequest);
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