using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;
using bNesis.Api.Desktop;
using bNesis.Sdk.Common;

namespace bNesis.Sdk.Social.Facebook
{
	public class Facebook  
	{
		public string bNesisToken {get; private set;}
		private DesktopbNesisApi bNesisApi;

		public Facebook(DesktopbNesisApi bNesisApi)
		{
			this.bNesisApi = bNesisApi;
		}

		public string Auth(string data,string bNesisDevId,string redirectUrl,string clientId,string clientSecret,string[] scopes,string login,string password,bool isSandbox,string serviceUrl)
		{

			bNesisToken = bNesisApi.Auth("Facebook", data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl);

			return bNesisToken;
		}

		///<summary>
		/// Getting last exception for current provider 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo GetLastError()
		{
			return bNesisApi.Call<ErrorInfo>("Facebook", bNesisToken, "GetLastError");
		}

		///<summary>
		/// Getting arrays of error info 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo[] GetErrorLog()
		{
			return bNesisApi.Call<ErrorInfo[]>("Facebook", bNesisToken, "GetErrorLog");
		}

		///<summary>
		/// Checks the token in the service. 
		/// </summary>
		/// <returns>if token valid return true, if token not valid return false</returns>
		public Boolean ValidateToken()
		{
			return bNesisApi.Call<Boolean>("Facebook", bNesisToken, "ValidateToken");
		}

		///<summary>
		/// Disables the access token used to authenticate the call. 
		/// </summary>
		/// <returns>if token revoked method returns true 
		/// if token doesn't support token revocation or token is revoked method returns false</returns>
		public Boolean Logoff()
		{
			return bNesisApi.Call<Boolean>("Facebook", bNesisToken, "Logoff");
		}

		///<summary>
		/// Gets the user identifier. 
		/// </summary>
		/// <returns>response with user ID</returns>
		public Response GetUserIdRaw()
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserIdRaw");
		}

		///<summary>
		/// Checks the token in the service. 
		/// </summary>
		/// <returns>data with information about the token</returns>
		public Response ValidationTokenRaw()
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "ValidationTokenRaw");
		}

		///<summary>
		/// Generates an App Access Token 
		/// </summary>
		/// <returns>app Access Token</returns>
		public Response GetAppAccessTokenRaw()
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetAppAccessTokenRaw");
		}

		///<summary>
		/// Gets the user Friendlists. 
		/// </summary>
		/// <returns>user Friendlists</returns>
		public Response GetUserFriendlists()
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserFriendlists");
		}
	}
}