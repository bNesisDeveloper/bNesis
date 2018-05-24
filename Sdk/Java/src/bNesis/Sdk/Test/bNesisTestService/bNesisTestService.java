package bNesis.Sdk.Test.bNesisTestService;

import java.io.*;
import java.util.List;
import java.util.Date;
import java.util.Map.Entry;
import bNesis.Api.*;

import bNesis.Sdk.Common.*;
import bNesis.Sdk.Test.bNesisTestService.*;

	public class bNesisTestService  
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

		public bNesisTestService(bNesisApi bnesisApi)
		{
			this._bNesisApi = bnesisApi;
		}

		/**
		 * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		 * @return {String} bNesisToken value
		 */
		public String Auth(String bNesisDevId,String clientId,String clientSecret,String redirectUrl) throws Exception
		{
			bNesisToken = _bNesisApi.Auth("bNesisTestProvider", "",bNesisDevId,redirectUrl,clientId,clientSecret,null,"","",false,"");
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
			Boolean result = _bNesisApi.LogoffService("bNesisTestProvider", bNesisToken);
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
			return _bNesisApi.<ErrorInfo>Call(ErrorInfo.class, "bNesisTestService", bNesisToken, "GetLastError");
		}

		/**
		 *  Getting arrays of error info 	
		 * @return {ErrorInfo[]}  
		 * @throws Exception
		 */
		public ErrorInfo[] GetErrorLog() throws Exception
		{
			return _bNesisApi.<ErrorInfo[]>Call(ErrorInfo[].class, "bNesisTestService", bNesisToken, "GetErrorLog");
		}

		/**
		 *  Checks the token in the service. 	
		 * @return {Boolean} if token valid return true, if token not valid return false 
		 * @throws Exception
		 */
		public Boolean ValidateToken() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "bNesisTestService", bNesisToken, "ValidateToken");
		}

		/**
		 *  Disables the access token used to authenticate the call. 	
		 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false 
		 * @throws Exception
		 */
		public Boolean Logoff() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "bNesisTestService", bNesisToken, "Logoff");
		}

		/**
		 *   	
		 * @param isArrayOfSimple 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testE10null(Integer[] isArrayOfSimple) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testE10null", isArrayOfSimple);
		}

		/**
		 *   	
		 * @param isArrayOfObject 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testE11(Object[] isArrayOfObject) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testE11", isArrayOfObject);
		}

		/**
		 *   	
		 * @param isArrayOfObject 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testE11null(Object[] isArrayOfObject) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testE11null", isArrayOfObject);
		}

		/**
		 *   	
		 * @param isArrayOfFormalized 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testE12(ShipmentIn[] isArrayOfFormalized) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testE12", isArrayOfFormalized);
		}

		/**
		 *   	
		 * @param isArrayOfFormalized 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testE12null(ShipmentIn[] isArrayOfFormalized) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testE12null", isArrayOfFormalized);
		}

		/**
		 *   	
		 * @param isArrayOfNulls 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testE13(Object[] isArrayOfNulls) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testE13", isArrayOfNulls);
		}

		/**
		 *   	
		 * @param isArrayOfNulls 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testE13null(Object[] isArrayOfNulls) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testE13null", isArrayOfNulls);
		}

		/**
		 *   	
		 * @return {String}  
		 * @throws Exception
		 */
		public String testF3() throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "bNesisTestService", bNesisToken, "testF3");
		}

		/**
		 *   	
		 * @return {String}  
		 * @throws Exception
		 */
		public String testF3null() throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "bNesisTestService", bNesisToken, "testF3null");
		}

		/**
		 *   	
		 * @param isNull 
	 * @return {String}  
		 * @throws Exception
		 */
		public String testF4(Object isNull) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "bNesisTestService", bNesisToken, "testF4", isNull);
		}

		/**
		 *   	
		 * @param isNull 
	 * @return {String}  
		 * @throws Exception
		 */
		public String testF4null(Object isNull) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "bNesisTestService", bNesisToken, "testF4null", isNull);
		}

		/**
		 *   	
		 * @param isString 
	 * @return {String}  
		 * @throws Exception
		 */
		public String testF5(String isString) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "bNesisTestService", bNesisToken, "testF5", isString);
		}

		/**
		 *   	
		 * @param isString 
	 * @return {String}  
		 * @throws Exception
		 */
		public String testF5null(String isString) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "bNesisTestService", bNesisToken, "testF5null", isString);
		}

		/**
		 *   	
		 * @param isSimple 
	 * @return {String}  
		 * @throws Exception
		 */
		public String testF6(Integer isSimple) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "bNesisTestService", bNesisToken, "testF6", isSimple);
		}

		/**
		 *   	
		 * @param isSimple 
	 * @return {String}  
		 * @throws Exception
		 */
		public String testF6null(Integer isSimple) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "bNesisTestService", bNesisToken, "testF6null", isSimple);
		}

		/**
		 *   	
		 * @param isObject 
	 * @return {String}  
		 * @throws Exception
		 */
		public String testF7(Object isObject) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "bNesisTestService", bNesisToken, "testF7", isObject);
		}

		/**
		 *   	
		 * @param isObject 
	 * @return {String}  
		 * @throws Exception
		 */
		public String testF7null(Object isObject) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "bNesisTestService", bNesisToken, "testF7null", isObject);
		}

		/**
		 *   	
		 * @param isFormalized 
	 * @return {String}  
		 * @throws Exception
		 */
		public String testF8(ShipmentIn isFormalized) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "bNesisTestService", bNesisToken, "testF8", isFormalized);
		}

		/**
		 *   	
		 * @param isFormalized 
	 * @return {String}  
		 * @throws Exception
		 */
		public String testF8null(ShipmentIn isFormalized) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "bNesisTestService", bNesisToken, "testF8null", isFormalized);
		}

		/**
		 *   	
		 * @param isArrayOfString 
	 * @return {String}  
		 * @throws Exception
		 */
		public String testF9(String[] isArrayOfString) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "bNesisTestService", bNesisToken, "testF9", isArrayOfString);
		}

		/**
		 *   	
		 * @param isArrayOfString 
	 * @return {String}  
		 * @throws Exception
		 */
		public String testF9null(String[] isArrayOfString) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "bNesisTestService", bNesisToken, "testF9null", isArrayOfString);
		}

		/**
		 *   	
		 * @param isArrayOfSimple 
	 * @return {String}  
		 * @throws Exception
		 */
		public String testF10(Integer[] isArrayOfSimple) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "bNesisTestService", bNesisToken, "testF10", isArrayOfSimple);
		}

		/**
		 *   	
		 * @param isArrayOfSimple 
	 * @return {String}  
		 * @throws Exception
		 */
		public String testF10null(Integer[] isArrayOfSimple) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "bNesisTestService", bNesisToken, "testF10null", isArrayOfSimple);
		}

		/**
		 *   	
		 * @param isArrayOfObject 
	 * @return {String}  
		 * @throws Exception
		 */
		public String testF11(Object[] isArrayOfObject) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "bNesisTestService", bNesisToken, "testF11", isArrayOfObject);
		}

		/**
		 *   	
		 * @param isArrayOfObject 
	 * @return {String}  
		 * @throws Exception
		 */
		public String testF11null(Object[] isArrayOfObject) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "bNesisTestService", bNesisToken, "testF11null", isArrayOfObject);
		}

		/**
		 *   	
		 * @param isArrayOfFormalized 
	 * @return {String}  
		 * @throws Exception
		 */
		public String testF12(ShipmentIn[] isArrayOfFormalized) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "bNesisTestService", bNesisToken, "testF12", isArrayOfFormalized);
		}

		/**
		 *   	
		 * @param isArrayOfFormalized 
	 * @return {String}  
		 * @throws Exception
		 */
		public String testF12null(ShipmentIn[] isArrayOfFormalized) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "bNesisTestService", bNesisToken, "testF12null", isArrayOfFormalized);
		}

		/**
		 *   	
		 * @param isArrayOfNulls 
	 * @return {String}  
		 * @throws Exception
		 */
		public String testF13(Object[] isArrayOfNulls) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "bNesisTestService", bNesisToken, "testF13", isArrayOfNulls);
		}

		/**
		 *   	
		 * @param isArrayOfNulls 
	 * @return {String}  
		 * @throws Exception
		 */
		public String testF13null(Object[] isArrayOfNulls) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "bNesisTestService", bNesisToken, "testF13null", isArrayOfNulls);
		}

		/**
		 *   	
		 * @return {ShipmentOut}  
		 * @throws Exception
		 */
		public ShipmentOut testG3() throws Exception
		{
			return _bNesisApi.<ShipmentOut>Call(ShipmentOut.class, "bNesisTestService", bNesisToken, "testG3");
		}

		/**
		 *   	
		 * @param isNull 
	 * @return {ShipmentOut}  
		 * @throws Exception
		 */
		public ShipmentOut testG4(Object isNull) throws Exception
		{
			return _bNesisApi.<ShipmentOut>Call(ShipmentOut.class, "bNesisTestService", bNesisToken, "testG4", isNull);
		}

		/**
		 *   	
		 * @param isNull 
	 * @return {ShipmentOut}  
		 * @throws Exception
		 */
		public ShipmentOut testG4null(Object isNull) throws Exception
		{
			return _bNesisApi.<ShipmentOut>Call(ShipmentOut.class, "bNesisTestService", bNesisToken, "testG4null", isNull);
		}

		/**
		 *   	
		 * @param isString 
	 * @return {ShipmentOut}  
		 * @throws Exception
		 */
		public ShipmentOut testG5(String isString) throws Exception
		{
			return _bNesisApi.<ShipmentOut>Call(ShipmentOut.class, "bNesisTestService", bNesisToken, "testG5", isString);
		}

		/**
		 *   	
		 * @param isString 
	 * @return {ShipmentOut}  
		 * @throws Exception
		 */
		public ShipmentOut testG5null(String isString) throws Exception
		{
			return _bNesisApi.<ShipmentOut>Call(ShipmentOut.class, "bNesisTestService", bNesisToken, "testG5null", isString);
		}

		/**
		 *   	
		 * @param isSimple 
	 * @return {ShipmentOut}  
		 * @throws Exception
		 */
		public ShipmentOut testG6(Integer isSimple) throws Exception
		{
			return _bNesisApi.<ShipmentOut>Call(ShipmentOut.class, "bNesisTestService", bNesisToken, "testG6", isSimple);
		}

		/**
		 *   	
		 * @param isSimple 
	 * @return {ShipmentOut}  
		 * @throws Exception
		 */
		public ShipmentOut testG6null(Integer isSimple) throws Exception
		{
			return _bNesisApi.<ShipmentOut>Call(ShipmentOut.class, "bNesisTestService", bNesisToken, "testG6null", isSimple);
		}

		/**
		 *   	
		 * @param isObject 
	 * @return {ShipmentOut}  
		 * @throws Exception
		 */
		public ShipmentOut testG7(Object isObject) throws Exception
		{
			return _bNesisApi.<ShipmentOut>Call(ShipmentOut.class, "bNesisTestService", bNesisToken, "testG7", isObject);
		}

		/**
		 *   	
		 * @param isObject 
	 * @return {ShipmentOut}  
		 * @throws Exception
		 */
		public ShipmentOut testG7null(Object isObject) throws Exception
		{
			return _bNesisApi.<ShipmentOut>Call(ShipmentOut.class, "bNesisTestService", bNesisToken, "testG7null", isObject);
		}

		/**
		 *   	
		 * @param isFormalized 
	 * @return {ShipmentOut}  
		 * @throws Exception
		 */
		public ShipmentOut testG8(ShipmentIn isFormalized) throws Exception
		{
			return _bNesisApi.<ShipmentOut>Call(ShipmentOut.class, "bNesisTestService", bNesisToken, "testG8", isFormalized);
		}

		/**
		 *   	
		 * @param isFormalized 
	 * @return {ShipmentOut}  
		 * @throws Exception
		 */
		public ShipmentOut testG8null(ShipmentIn isFormalized) throws Exception
		{
			return _bNesisApi.<ShipmentOut>Call(ShipmentOut.class, "bNesisTestService", bNesisToken, "testG8null", isFormalized);
		}

		/**
		 *   	
		 * @param isArrayOfString 
	 * @return {ShipmentOut}  
		 * @throws Exception
		 */
		public ShipmentOut testG9(String[] isArrayOfString) throws Exception
		{
			return _bNesisApi.<ShipmentOut>Call(ShipmentOut.class, "bNesisTestService", bNesisToken, "testG9", isArrayOfString);
		}

		/**
		 *   	
		 * @param isArrayOfString 
	 * @return {ShipmentOut}  
		 * @throws Exception
		 */
		public ShipmentOut testG9null(String[] isArrayOfString) throws Exception
		{
			return _bNesisApi.<ShipmentOut>Call(ShipmentOut.class, "bNesisTestService", bNesisToken, "testG9null", isArrayOfString);
		}

		/**
		 *   	
		 * @param isArrayOfSimple 
	 * @return {ShipmentOut}  
		 * @throws Exception
		 */
		public ShipmentOut testG10(Integer[] isArrayOfSimple) throws Exception
		{
			return _bNesisApi.<ShipmentOut>Call(ShipmentOut.class, "bNesisTestService", bNesisToken, "testG10", isArrayOfSimple);
		}

		/**
		 *   	
		 * @param isArrayOfSimple 
	 * @return {ShipmentOut}  
		 * @throws Exception
		 */
		public ShipmentOut testG10null(Integer[] isArrayOfSimple) throws Exception
		{
			return _bNesisApi.<ShipmentOut>Call(ShipmentOut.class, "bNesisTestService", bNesisToken, "testG10null", isArrayOfSimple);
		}

		/**
		 *   	
		 * @param isArrayOfObject 
	 * @return {ShipmentOut}  
		 * @throws Exception
		 */
		public ShipmentOut testG11(Object[] isArrayOfObject) throws Exception
		{
			return _bNesisApi.<ShipmentOut>Call(ShipmentOut.class, "bNesisTestService", bNesisToken, "testG11", isArrayOfObject);
		}

		/**
		 *   	
		 * @param isArrayOfObject 
	 * @return {ShipmentOut}  
		 * @throws Exception
		 */
		public ShipmentOut testG11null(Object[] isArrayOfObject) throws Exception
		{
			return _bNesisApi.<ShipmentOut>Call(ShipmentOut.class, "bNesisTestService", bNesisToken, "testG11null", isArrayOfObject);
		}

		/**
		 *   	
		 * @param isArrayOfFormalized 
	 * @return {ShipmentOut}  
		 * @throws Exception
		 */
		public ShipmentOut testG12(ShipmentIn[] isArrayOfFormalized) throws Exception
		{
			return _bNesisApi.<ShipmentOut>Call(ShipmentOut.class, "bNesisTestService", bNesisToken, "testG12", isArrayOfFormalized);
		}

		/**
		 *   	
		 * @param isArrayOfFormalized 
	 * @return {ShipmentOut}  
		 * @throws Exception
		 */
		public ShipmentOut testG12null(ShipmentIn[] isArrayOfFormalized) throws Exception
		{
			return _bNesisApi.<ShipmentOut>Call(ShipmentOut.class, "bNesisTestService", bNesisToken, "testG12null", isArrayOfFormalized);
		}

		/**
		 *   	
		 * @param isArrayOfNulls 
	 * @return {ShipmentOut}  
		 * @throws Exception
		 */
		public ShipmentOut testG13(Object[] isArrayOfNulls) throws Exception
		{
			return _bNesisApi.<ShipmentOut>Call(ShipmentOut.class, "bNesisTestService", bNesisToken, "testG13", isArrayOfNulls);
		}

		/**
		 *   	
		 * @param isArrayOfNulls 
	 * @return {ShipmentOut}  
		 * @throws Exception
		 */
		public ShipmentOut testG13null(Object[] isArrayOfNulls) throws Exception
		{
			return _bNesisApi.<ShipmentOut>Call(ShipmentOut.class, "bNesisTestService", bNesisToken, "testG13null", isArrayOfNulls);
		}

		/**
		 *  All B methods returns void 	
		 
		 */
		public void testB3()
		{
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
		}

		/**
		 *   	
		 * @param isNULL 
	 
		 */
		public void testB4(Object isNULL)
		{
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
		}

		/**
		 *   	
		 * @param isString 
	 
		 */
		public void testB5(String isString)
		{
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
		}

		/**
		 *   	
		 * @param isSimple 
	 
		 */
		public void testB6(Integer isSimple)
		{
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
		}

		/**
		 *   	
		 * @param isObject 
	 
		 */
		public void testB7(Object isObject)
		{
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
		}

		/**
		 *   	
		 * @param isFormalized 
	 
		 */
		public void testB8(ShipmentIn isFormalized)
		{
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
		}

		/**
		 *   	
		 * @param isArrayOfString 
	 
		 */
		public void testB9(String[] isArrayOfString)
		{
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
		}

		/**
		 *   	
		 * @param isArrayOfSimple 
	 
		 */
		public void testB10(Integer[] isArrayOfSimple)
		{
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
		}

		/**
		 *   	
		 * @param isArrayOfObject 
	 
		 */
		public void testB11(Object[] isArrayOfObject)
		{
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
		}

		/**
		 *   	
		 * @param isArrayOfFormalized 
	 
		 */
		public void testB12(ShipmentIn[] isArrayOfFormalized)
		{
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
		}

		/**
		 *   	
		 * @param isArrayOfNulls 
	 
		 */
		public void testB13(Object[] isArrayOfNulls)
		{
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
		}

		/**
		 *   	
		 * @return {Object}  
		 * @throws Exception
		 */
		public Object testC3() throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testC3");
		}

		/**
		 *   	
		 * @param isNULL 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testC4(Object isNULL) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testC4", isNULL);
		}

		/**
		 *   	
		 * @param isString 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testC5(String isString) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testC5", isString);
		}

		/**
		 *   	
		 * @param isSimple 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testC6(Integer isSimple) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testC6", isSimple);
		}

		/**
		 *   	
		 * @param isObject 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testC7(Object isObject) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testC7", isObject);
		}

		/**
		 *   	
		 * @param isFormalized 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testC8(ShipmentIn isFormalized) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testC8", isFormalized);
		}

		/**
		 *   	
		 * @param isArrayOfString 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testC9(String[] isArrayOfString) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testC9", isArrayOfString);
		}

		/**
		 *   	
		 * @param isArrayOfSimple 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testC10(Integer[] isArrayOfSimple) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testC10", isArrayOfSimple);
		}

		/**
		 *   	
		 * @param isArrayOfObject 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testC11(Object[] isArrayOfObject) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testC11", isArrayOfObject);
		}

		/**
		 *   	
		 * @param isArrayOfFormalized 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testC12(ShipmentIn[] isArrayOfFormalized) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testC12", isArrayOfFormalized);
		}

		/**
		 *   	
		 * @param isArrayOfNulls 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testC13(Object[] isArrayOfNulls) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testC13", isArrayOfNulls);
		}

		/**
		 *   	
		 * @param param1 
	 * @param param2 
	 * @param param3 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testC14(Object param1, Object param2, Object param3) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testC14", param1, param2, param3);
		}

		/**
		 *   	
		 * @param param1 
	 * @param param2 
	 * @param param3 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testC15(Object param1, String param2, Integer param3) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testC15", param1, param2, param3);
		}

		/**
		 *   	
		 * @param shipment1 
	 * @param shipment2 
	 * @param shipment3 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testC16(ShipmentIn shipment1, ShipmentIn shipment2, ShipmentIn shipment3) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testC16", shipment1, shipment2, shipment3);
		}

		/**
		 *   	
		 * @param shipment1 
	 * @param param1 
	 * @param param2 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testC17(ShipmentIn shipment1, Object param1, Integer param2) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testC17", shipment1, param1, param2);
		}

		/**
		 *   	
		 * @param shipment1 
	 * @param param1 
	 * @param param2 
	 * @param param3 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testC18(ShipmentIn[] shipment1, Object[] param1, String[] param2, Integer[] param3) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testC18", shipment1, param1, param2, param3);
		}

		/**
		 *   	
		 * @return {Integer}  
		 * @throws Exception
		 */
		public Integer testD3() throws Exception
		{
			return _bNesisApi.<Integer>Call(Integer.class, "bNesisTestService", bNesisToken, "testD3");
		}

		/**
		 *   	
		 * @return {Integer}  
		 * @throws Exception
		 */
		public Integer testD3null() throws Exception
		{
			return _bNesisApi.<Integer>Call(Integer.class, "bNesisTestService", bNesisToken, "testD3null");
		}

		/**
		 *   	
		 * @param isNull 
	 * @return {Integer}  
		 * @throws Exception
		 */
		public Integer testD4(Object isNull) throws Exception
		{
			return _bNesisApi.<Integer>Call(Integer.class, "bNesisTestService", bNesisToken, "testD4", isNull);
		}

		/**
		 *   	
		 * @param isNull 
	 * @return {Integer}  
		 * @throws Exception
		 */
		public Integer testD4null(Object isNull) throws Exception
		{
			return _bNesisApi.<Integer>Call(Integer.class, "bNesisTestService", bNesisToken, "testD4null", isNull);
		}

		/**
		 *   	
		 * @param isString 
	 * @return {Integer}  
		 * @throws Exception
		 */
		public Integer testD5(String isString) throws Exception
		{
			return _bNesisApi.<Integer>Call(Integer.class, "bNesisTestService", bNesisToken, "testD5", isString);
		}

		/**
		 *   	
		 * @param isString 
	 * @return {Integer}  
		 * @throws Exception
		 */
		public Integer testD5null(String isString) throws Exception
		{
			return _bNesisApi.<Integer>Call(Integer.class, "bNesisTestService", bNesisToken, "testD5null", isString);
		}

		/**
		 *   	
		 * @param isSimple 
	 * @return {Integer}  
		 * @throws Exception
		 */
		public Integer testD6(Integer isSimple) throws Exception
		{
			return _bNesisApi.<Integer>Call(Integer.class, "bNesisTestService", bNesisToken, "testD6", isSimple);
		}

		/**
		 *   	
		 * @param isSimple 
	 * @return {Integer}  
		 * @throws Exception
		 */
		public Integer testD6null(Integer isSimple) throws Exception
		{
			return _bNesisApi.<Integer>Call(Integer.class, "bNesisTestService", bNesisToken, "testD6null", isSimple);
		}

		/**
		 *   	
		 * @param isObject 
	 * @return {Integer}  
		 * @throws Exception
		 */
		public Integer testD7(Object isObject) throws Exception
		{
			return _bNesisApi.<Integer>Call(Integer.class, "bNesisTestService", bNesisToken, "testD7", isObject);
		}

		/**
		 *   	
		 * @param isObject 
	 * @return {Integer}  
		 * @throws Exception
		 */
		public Integer testD7null(Object isObject) throws Exception
		{
			return _bNesisApi.<Integer>Call(Integer.class, "bNesisTestService", bNesisToken, "testD7null", isObject);
		}

		/**
		 *   	
		 * @param isFormalized 
	 * @return {Integer}  
		 * @throws Exception
		 */
		public Integer testD8(ShipmentIn isFormalized) throws Exception
		{
			return _bNesisApi.<Integer>Call(Integer.class, "bNesisTestService", bNesisToken, "testD8", isFormalized);
		}

		/**
		 *   	
		 * @param isFormalized 
	 * @return {Integer}  
		 * @throws Exception
		 */
		public Integer testD8null(ShipmentIn isFormalized) throws Exception
		{
			return _bNesisApi.<Integer>Call(Integer.class, "bNesisTestService", bNesisToken, "testD8null", isFormalized);
		}

		/**
		 *   	
		 * @param isArrayOfString 
	 * @return {Integer}  
		 * @throws Exception
		 */
		public Integer testD9(String[] isArrayOfString) throws Exception
		{
			return _bNesisApi.<Integer>Call(Integer.class, "bNesisTestService", bNesisToken, "testD9", isArrayOfString);
		}

		/**
		 *   	
		 * @param isArrayOfString 
	 * @return {Integer}  
		 * @throws Exception
		 */
		public Integer testD9null(String[] isArrayOfString) throws Exception
		{
			return _bNesisApi.<Integer>Call(Integer.class, "bNesisTestService", bNesisToken, "testD9null", isArrayOfString);
		}

		/**
		 *   	
		 * @param isArrayOfSimple 
	 * @return {Integer}  
		 * @throws Exception
		 */
		public Integer testD10(Integer[] isArrayOfSimple) throws Exception
		{
			return _bNesisApi.<Integer>Call(Integer.class, "bNesisTestService", bNesisToken, "testD10", isArrayOfSimple);
		}

		/**
		 *   	
		 * @param isArrayOfSimple 
	 * @return {Integer}  
		 * @throws Exception
		 */
		public Integer testD10null(Integer[] isArrayOfSimple) throws Exception
		{
			return _bNesisApi.<Integer>Call(Integer.class, "bNesisTestService", bNesisToken, "testD10null", isArrayOfSimple);
		}

		/**
		 *   	
		 * @param isArrayOfObject 
	 * @return {Integer}  
		 * @throws Exception
		 */
		public Integer testD11(Object[] isArrayOfObject) throws Exception
		{
			return _bNesisApi.<Integer>Call(Integer.class, "bNesisTestService", bNesisToken, "testD11", isArrayOfObject);
		}

		/**
		 *   	
		 * @param isArrayOfObject 
	 * @return {Integer}  
		 * @throws Exception
		 */
		public Integer testD11null(Object[] isArrayOfObject) throws Exception
		{
			return _bNesisApi.<Integer>Call(Integer.class, "bNesisTestService", bNesisToken, "testD11null", isArrayOfObject);
		}

		/**
		 *   	
		 * @param isArrayOfFormalized 
	 * @return {Integer}  
		 * @throws Exception
		 */
		public Integer testD12(ShipmentIn[] isArrayOfFormalized) throws Exception
		{
			return _bNesisApi.<Integer>Call(Integer.class, "bNesisTestService", bNesisToken, "testD12", isArrayOfFormalized);
		}

		/**
		 *   	
		 * @param isArrayOfFormalized 
	 * @return {Integer}  
		 * @throws Exception
		 */
		public Integer testD12null(ShipmentIn[] isArrayOfFormalized) throws Exception
		{
			return _bNesisApi.<Integer>Call(Integer.class, "bNesisTestService", bNesisToken, "testD12null", isArrayOfFormalized);
		}

		/**
		 *   	
		 * @param isArrayOfNulls 
	 * @return {Integer}  
		 * @throws Exception
		 */
		public Integer testD13(Object[] isArrayOfNulls) throws Exception
		{
			return _bNesisApi.<Integer>Call(Integer.class, "bNesisTestService", bNesisToken, "testD13", isArrayOfNulls);
		}

		/**
		 *   	
		 * @param isArrayOfNulls 
	 * @return {Integer}  
		 * @throws Exception
		 */
		public Integer testD13null(Object[] isArrayOfNulls) throws Exception
		{
			return _bNesisApi.<Integer>Call(Integer.class, "bNesisTestService", bNesisToken, "testD13null", isArrayOfNulls);
		}

		/**
		 *   	
		 * @return {Object}  
		 * @throws Exception
		 */
		public Object testE3() throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testE3");
		}

		/**
		 *   	
		 * @return {Object}  
		 * @throws Exception
		 */
		public Object testE3null() throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testE3null");
		}

		/**
		 *   	
		 * @param isNull 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testE4(Object isNull) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testE4", isNull);
		}

		/**
		 *   	
		 * @param isNull 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testE4null(Object isNull) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testE4null", isNull);
		}

		/**
		 *   	
		 * @param isString 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testE5(String isString) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testE5", isString);
		}

		/**
		 *   	
		 * @param isString 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testE5null(String isString) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testE5null", isString);
		}

		/**
		 *   	
		 * @param isSimple 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testE6(Integer isSimple) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testE6", isSimple);
		}

		/**
		 *   	
		 * @param isSimple 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testE6null(Integer isSimple) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testE6null", isSimple);
		}

		/**
		 *   	
		 * @param isObject 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testE7(Object isObject) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testE7", isObject);
		}

		/**
		 *   	
		 * @param isObject 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testE7null(Object isObject) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testE7null", isObject);
		}

		/**
		 *   	
		 * @param isFormalized 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testE8(ShipmentIn isFormalized) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testE8", isFormalized);
		}

		/**
		 *   	
		 * @param isFormalized 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testE8null(ShipmentIn isFormalized) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testE8null", isFormalized);
		}

		/**
		 *   	
		 * @param isArrayOfString 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testE9(String[] isArrayOfString) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testE9", isArrayOfString);
		}

		/**
		 *   	
		 * @param isArrayOfString 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testE9null(String[] isArrayOfString) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testE9null", isArrayOfString);
		}

		/**
		 *   	
		 * @param isArrayOfSimple 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object testE10(Integer[] isArrayOfSimple) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "bNesisTestService", bNesisToken, "testE10", isArrayOfSimple);
		}
}