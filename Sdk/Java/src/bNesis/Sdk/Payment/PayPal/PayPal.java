package bNesis.Sdk.Payment.PayPal;

import java.io.*;
import java.util.List;
import java.util.Date;
import java.util.Map.Entry;
import bNesis.Api.*;

import bNesis.Sdk.Common.*;
import java.net.URI.*;

	public class PayPal  
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

		public PayPal(bNesisApi bnesisApi)
		{
			this._bNesisApi = bnesisApi;
		}

		/**
		 * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		 * @return {String} bNesisToken value
		 */
		public String Auth(String bNesisDevId,String clientId,String clientSecret,String redirectUrl) throws Exception
		{
			bNesisToken = _bNesisApi.Auth("PayPal", "",bNesisDevId,redirectUrl,clientId,clientSecret,null,"","",false,"");
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
			Boolean result = _bNesisApi.LogoffService("PayPal", bNesisToken);
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
			return _bNesisApi.<ErrorInfo>Call(ErrorInfo.class, "PayPal", bNesisToken, "GetLastError");
		}

		/**
		 *  Getting arrays of error info 	
		 * @return {ErrorInfo[]}  
		 * @throws Exception
		 */
		public ErrorInfo[] GetErrorLog() throws Exception
		{
			return _bNesisApi.<ErrorInfo[]>Call(ErrorInfo[].class, "PayPal", bNesisToken, "GetErrorLog");
		}

		/**
		 *  Checks the token in the service. 	
		 * @return {Boolean} if token valid return true, if token not valid return false 
		 * @throws Exception
		 */
		public Boolean ValidateToken() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PayPal", bNesisToken, "ValidateToken");
		}

		/**
		 *  Disables the access token used to authenticate the call. 	
		 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false 
		 * @throws Exception
		 */
		public Boolean Logoff() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PayPal", bNesisToken, "Logoff");
		}

		/**
		 *  sale 	
		 * @param sale_id sale_id.
	 * @return {Object} Returns ExpandoObject. 
		 * @throws Exception
		 */
		public Object sale(String sale_id) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "PayPal", bNesisToken, "sale", sale_id);
		}

		/**
		 *  get_credit_cards 	
		 * @return {Object} Returns ExpandoObject. 
		 * @throws Exception
		 */
		public Object get_credit_cards() throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "PayPal", bNesisToken, "get_credit_cards");
		}

		/**
		 *  get_user_info 	
		 * @return {Response} Returns Response. 
		 * @throws Exception
		 */
		public Response get_user_infoRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PayPal", bNesisToken, "get_user_infoRaw");
		}
}