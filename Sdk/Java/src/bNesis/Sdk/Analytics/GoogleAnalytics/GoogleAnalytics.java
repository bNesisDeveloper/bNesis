package bNesis.Sdk.Analytics.GoogleAnalytics;

import java.io.*;
import java.util.List;
import java.util.Date;
import java.util.Map.Entry;
import bNesis.Api.*;

import java.net.URI.*;
import bNesis.Sdk.Common.*;

	public class GoogleAnalytics  
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

		public GoogleAnalytics(bNesisApi bnesisApi)
		{
			this._bNesisApi = bnesisApi;
		}

		/**
		 * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		 * @return {String} bNesisToken value
		 */
		public String Auth(String bNesisDevId,String clientId,String clientSecret,String redirectUrl,String[] scopes) throws Exception
		{
			bNesisToken = _bNesisApi.Auth("Google", "",bNesisDevId,redirectUrl,clientId,clientSecret,scopes,"","",false,"");
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
			Boolean result = _bNesisApi.LogoffService("Google", bNesisToken);
			if (result) bNesisToken = "";
			return result;             
		}


		/**
		 *  Gets a list of all user accounts. 	
		 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetManagementAccounts() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "GoogleAnalytics", bNesisToken, "GetManagementAccounts");
		}

		/**
		 *  Gets list of webproperties to which user have access. 	
		 * @param accountId Account identifier.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetWebProperties(String accountId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "GoogleAnalytics", bNesisToken, "GetWebProperties", accountId);
		}

		/**
		 *  Gets a webproperty information. 	
		 * @param accountId Account identifier.
	 * @param webpropertyId Web property identifier. (Format:code-XXXXX-YY)
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetWebProperty(String accountId, String webpropertyId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "GoogleAnalytics", bNesisToken, "GetWebProperty", accountId, webpropertyId);
		}

		/**
		 *  Gets a view profiles to which the user have access. 	
		 * @param accountId Account identifier.
	 * @param webpropertyId Web property identifier. (Format:code-XXXXX-YY)
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetWebPropertyProfiles(String accountId, String webpropertyId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "GoogleAnalytics", bNesisToken, "GetWebPropertyProfiles", accountId, webpropertyId);
		}

		/**
		 *  Gets analytics data. 	
		 * @param reportRequest The report request.
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response GetReportsBatchRaw(String reportRequest) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "GoogleAnalytics", bNesisToken, "GetReportsBatchRaw", reportRequest);
		}

		/**
		 *  Getting last exception for current provider 	
		 * @return {ErrorInfo}  
		 * @throws Exception
		 */
		public ErrorInfo GetLastError() throws Exception
		{
			return _bNesisApi.<ErrorInfo>Call(ErrorInfo.class, "GoogleAnalytics", bNesisToken, "GetLastError");
		}

		/**
		 *  Getting arrays of error info 	
		 * @return {ErrorInfo[]}  
		 * @throws Exception
		 */
		public ErrorInfo[] GetErrorLog() throws Exception
		{
			return _bNesisApi.<ErrorInfo[]>Call(ErrorInfo[].class, "GoogleAnalytics", bNesisToken, "GetErrorLog");
		}

		/**
		 *  Checks the token in the service. 	
		 * @return {Boolean} if token valid return true, if token not valid return false 
		 * @throws Exception
		 */
		public Boolean ValidateToken() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "GoogleAnalytics", bNesisToken, "ValidateToken");
		}

		/**
		 *  Disables the access token used to authenticate the call. 	
		 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false 
		 * @throws Exception
		 */
		public Boolean Logoff() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "GoogleAnalytics", bNesisToken, "Logoff");
		}
}