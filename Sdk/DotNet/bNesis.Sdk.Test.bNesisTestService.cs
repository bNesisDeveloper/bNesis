using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;
using bNesis.Api.Desktop;
using bNesis.Sdk.Common;

namespace bNesis.Sdk.Test.bNesisTestService
{
	public class bNesisTestService  
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

		public bNesisTestService(DesktopbNesisApi bNesisApi)
		{
			this.bNesisApi = bNesisApi;
		}

		/// <summary>
		/// The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		/// </summary>
		/// <returns>bNesisToken value</returns>	
		public string Auth(string bNesisDevId,string clientId,string clientSecret,string redirectUrl)
		{
			bNesisToken = bNesisApi.Auth("bNesisTestProvider", string.Empty,bNesisDevId,redirectUrl,clientId,clientSecret,null,string.Empty,string.Empty,false,string.Empty);
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
			bool result = bNesisApi.LogoffService("bNesisTestProvider", bNesisToken);
			if (result) bNesisToken = string.Empty;
			return result;             
		}


		///<summary>
		/// Getting last exception for current provider 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo GetLastError()
		{
			return bNesisApi.Call<ErrorInfo>("bNesisTestService", bNesisToken, "GetLastError");
		}

		///<summary>
		/// Getting arrays of error info 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo[] GetErrorLog()
		{
			return bNesisApi.Call<ErrorInfo[]>("bNesisTestService", bNesisToken, "GetErrorLog");
		}

		///<summary>
		/// Checks the token in the service. 
		/// </summary>
		/// <returns>if token valid return true, if token not valid return false</returns>
		public Boolean ValidateToken()
		{
			return bNesisApi.Call<Boolean>("bNesisTestService", bNesisToken, "ValidateToken");
		}

		///<summary>
		/// Disables the access token used to authenticate the call. 
		/// </summary>
		/// <returns>if token revoked method returns true 
		/// if token doesn't support token revocation or token is revoked method returns false</returns>
		public Boolean Logoff()
		{
			return bNesisApi.Call<Boolean>("bNesisTestService", bNesisToken, "Logoff");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfSimple"></param>
		/// <returns></returns>
		public Object testE10null(Int32[] isArrayOfSimple)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testE10null", isArrayOfSimple);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfObject"></param>
		/// <returns></returns>
		public Object testE11(Object[] isArrayOfObject)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testE11", isArrayOfObject);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfObject"></param>
		/// <returns></returns>
		public Object testE11null(Object[] isArrayOfObject)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testE11null", isArrayOfObject);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfFormalized"></param>
		/// <returns></returns>
		public Object testE12(ShipmentIn[] isArrayOfFormalized)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testE12", isArrayOfFormalized);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfFormalized"></param>
		/// <returns></returns>
		public Object testE12null(ShipmentIn[] isArrayOfFormalized)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testE12null", isArrayOfFormalized);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfNulls"></param>
		/// <returns></returns>
		public Object testE13(Object[] isArrayOfNulls)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testE13", isArrayOfNulls);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfNulls"></param>
		/// <returns></returns>
		public Object testE13null(Object[] isArrayOfNulls)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testE13null", isArrayOfNulls);
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public string testF3()
		{
			return bNesisApi.Call<string>("bNesisTestService", bNesisToken, "testF3");
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public string testF3null()
		{
			return bNesisApi.Call<string>("bNesisTestService", bNesisToken, "testF3null");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isNull"></param>
		/// <returns></returns>
		public string testF4(Object isNull)
		{
			return bNesisApi.Call<string>("bNesisTestService", bNesisToken, "testF4", isNull);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isNull"></param>
		/// <returns></returns>
		public string testF4null(Object isNull)
		{
			return bNesisApi.Call<string>("bNesisTestService", bNesisToken, "testF4null", isNull);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isString"></param>
		/// <returns></returns>
		public string testF5(string isString)
		{
			return bNesisApi.Call<string>("bNesisTestService", bNesisToken, "testF5", isString);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isString"></param>
		/// <returns></returns>
		public string testF5null(string isString)
		{
			return bNesisApi.Call<string>("bNesisTestService", bNesisToken, "testF5null", isString);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isSimple"></param>
		/// <returns></returns>
		public string testF6(Int32 isSimple)
		{
			return bNesisApi.Call<string>("bNesisTestService", bNesisToken, "testF6", isSimple);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isSimple"></param>
		/// <returns></returns>
		public string testF6null(Int32 isSimple)
		{
			return bNesisApi.Call<string>("bNesisTestService", bNesisToken, "testF6null", isSimple);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isObject"></param>
		/// <returns></returns>
		public string testF7(Object isObject)
		{
			return bNesisApi.Call<string>("bNesisTestService", bNesisToken, "testF7", isObject);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isObject"></param>
		/// <returns></returns>
		public string testF7null(Object isObject)
		{
			return bNesisApi.Call<string>("bNesisTestService", bNesisToken, "testF7null", isObject);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isFormalized"></param>
		/// <returns></returns>
		public string testF8(ShipmentIn isFormalized)
		{
			return bNesisApi.Call<string>("bNesisTestService", bNesisToken, "testF8", isFormalized);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isFormalized"></param>
		/// <returns></returns>
		public string testF8null(ShipmentIn isFormalized)
		{
			return bNesisApi.Call<string>("bNesisTestService", bNesisToken, "testF8null", isFormalized);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfString"></param>
		/// <returns></returns>
		public string testF9(string[] isArrayOfString)
		{
			return bNesisApi.Call<string>("bNesisTestService", bNesisToken, "testF9", isArrayOfString);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfString"></param>
		/// <returns></returns>
		public string testF9null(string[] isArrayOfString)
		{
			return bNesisApi.Call<string>("bNesisTestService", bNesisToken, "testF9null", isArrayOfString);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfSimple"></param>
		/// <returns></returns>
		public string testF10(Int32[] isArrayOfSimple)
		{
			return bNesisApi.Call<string>("bNesisTestService", bNesisToken, "testF10", isArrayOfSimple);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfSimple"></param>
		/// <returns></returns>
		public string testF10null(Int32[] isArrayOfSimple)
		{
			return bNesisApi.Call<string>("bNesisTestService", bNesisToken, "testF10null", isArrayOfSimple);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfObject"></param>
		/// <returns></returns>
		public string testF11(Object[] isArrayOfObject)
		{
			return bNesisApi.Call<string>("bNesisTestService", bNesisToken, "testF11", isArrayOfObject);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfObject"></param>
		/// <returns></returns>
		public string testF11null(Object[] isArrayOfObject)
		{
			return bNesisApi.Call<string>("bNesisTestService", bNesisToken, "testF11null", isArrayOfObject);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfFormalized"></param>
		/// <returns></returns>
		public string testF12(ShipmentIn[] isArrayOfFormalized)
		{
			return bNesisApi.Call<string>("bNesisTestService", bNesisToken, "testF12", isArrayOfFormalized);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfFormalized"></param>
		/// <returns></returns>
		public string testF12null(ShipmentIn[] isArrayOfFormalized)
		{
			return bNesisApi.Call<string>("bNesisTestService", bNesisToken, "testF12null", isArrayOfFormalized);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfNulls"></param>
		/// <returns></returns>
		public string testF13(Object[] isArrayOfNulls)
		{
			return bNesisApi.Call<string>("bNesisTestService", bNesisToken, "testF13", isArrayOfNulls);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfNulls"></param>
		/// <returns></returns>
		public string testF13null(Object[] isArrayOfNulls)
		{
			return bNesisApi.Call<string>("bNesisTestService", bNesisToken, "testF13null", isArrayOfNulls);
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public ShipmentOut testG3()
		{
			return bNesisApi.Call<ShipmentOut>("bNesisTestService", bNesisToken, "testG3");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isNull"></param>
		/// <returns></returns>
		public ShipmentOut testG4(Object isNull)
		{
			return bNesisApi.Call<ShipmentOut>("bNesisTestService", bNesisToken, "testG4", isNull);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isNull"></param>
		/// <returns></returns>
		public ShipmentOut testG4null(Object isNull)
		{
			return bNesisApi.Call<ShipmentOut>("bNesisTestService", bNesisToken, "testG4null", isNull);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isString"></param>
		/// <returns></returns>
		public ShipmentOut testG5(string isString)
		{
			return bNesisApi.Call<ShipmentOut>("bNesisTestService", bNesisToken, "testG5", isString);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isString"></param>
		/// <returns></returns>
		public ShipmentOut testG5null(string isString)
		{
			return bNesisApi.Call<ShipmentOut>("bNesisTestService", bNesisToken, "testG5null", isString);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isSimple"></param>
		/// <returns></returns>
		public ShipmentOut testG6(Int32 isSimple)
		{
			return bNesisApi.Call<ShipmentOut>("bNesisTestService", bNesisToken, "testG6", isSimple);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isSimple"></param>
		/// <returns></returns>
		public ShipmentOut testG6null(Int32 isSimple)
		{
			return bNesisApi.Call<ShipmentOut>("bNesisTestService", bNesisToken, "testG6null", isSimple);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isObject"></param>
		/// <returns></returns>
		public ShipmentOut testG7(Object isObject)
		{
			return bNesisApi.Call<ShipmentOut>("bNesisTestService", bNesisToken, "testG7", isObject);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isObject"></param>
		/// <returns></returns>
		public ShipmentOut testG7null(Object isObject)
		{
			return bNesisApi.Call<ShipmentOut>("bNesisTestService", bNesisToken, "testG7null", isObject);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isFormalized"></param>
		/// <returns></returns>
		public ShipmentOut testG8(ShipmentIn isFormalized)
		{
			return bNesisApi.Call<ShipmentOut>("bNesisTestService", bNesisToken, "testG8", isFormalized);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isFormalized"></param>
		/// <returns></returns>
		public ShipmentOut testG8null(ShipmentIn isFormalized)
		{
			return bNesisApi.Call<ShipmentOut>("bNesisTestService", bNesisToken, "testG8null", isFormalized);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfString"></param>
		/// <returns></returns>
		public ShipmentOut testG9(string[] isArrayOfString)
		{
			return bNesisApi.Call<ShipmentOut>("bNesisTestService", bNesisToken, "testG9", isArrayOfString);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfString"></param>
		/// <returns></returns>
		public ShipmentOut testG9null(string[] isArrayOfString)
		{
			return bNesisApi.Call<ShipmentOut>("bNesisTestService", bNesisToken, "testG9null", isArrayOfString);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfSimple"></param>
		/// <returns></returns>
		public ShipmentOut testG10(Int32[] isArrayOfSimple)
		{
			return bNesisApi.Call<ShipmentOut>("bNesisTestService", bNesisToken, "testG10", isArrayOfSimple);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfSimple"></param>
		/// <returns></returns>
		public ShipmentOut testG10null(Int32[] isArrayOfSimple)
		{
			return bNesisApi.Call<ShipmentOut>("bNesisTestService", bNesisToken, "testG10null", isArrayOfSimple);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfObject"></param>
		/// <returns></returns>
		public ShipmentOut testG11(Object[] isArrayOfObject)
		{
			return bNesisApi.Call<ShipmentOut>("bNesisTestService", bNesisToken, "testG11", isArrayOfObject);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfObject"></param>
		/// <returns></returns>
		public ShipmentOut testG11null(Object[] isArrayOfObject)
		{
			return bNesisApi.Call<ShipmentOut>("bNesisTestService", bNesisToken, "testG11null", isArrayOfObject);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfFormalized"></param>
		/// <returns></returns>
		public ShipmentOut testG12(ShipmentIn[] isArrayOfFormalized)
		{
			return bNesisApi.Call<ShipmentOut>("bNesisTestService", bNesisToken, "testG12", isArrayOfFormalized);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfFormalized"></param>
		/// <returns></returns>
		public ShipmentOut testG12null(ShipmentIn[] isArrayOfFormalized)
		{
			return bNesisApi.Call<ShipmentOut>("bNesisTestService", bNesisToken, "testG12null", isArrayOfFormalized);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfNulls"></param>
		/// <returns></returns>
		public ShipmentOut testG13(Object[] isArrayOfNulls)
		{
			return bNesisApi.Call<ShipmentOut>("bNesisTestService", bNesisToken, "testG13", isArrayOfNulls);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfNulls"></param>
		/// <returns></returns>
		public ShipmentOut testG13null(Object[] isArrayOfNulls)
		{
			return bNesisApi.Call<ShipmentOut>("bNesisTestService", bNesisToken, "testG13null", isArrayOfNulls);
		}

		///<summary>
		/// All B methods returns void 
		/// </summary>
		/// <returns></returns>
		public void testB3()
		{
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isNULL"></param>
		/// <returns></returns>
		public void testB4(Object isNULL)
		{
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isString"></param>
		/// <returns></returns>
		public void testB5(string isString)
		{
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isSimple"></param>
		/// <returns></returns>
		public void testB6(Int32 isSimple)
		{
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isObject"></param>
		/// <returns></returns>
		public void testB7(Object isObject)
		{
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isFormalized"></param>
		/// <returns></returns>
		public void testB8(ShipmentIn isFormalized)
		{
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfString"></param>
		/// <returns></returns>
		public void testB9(string[] isArrayOfString)
		{
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfSimple"></param>
		/// <returns></returns>
		public void testB10(Int32[] isArrayOfSimple)
		{
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfObject"></param>
		/// <returns></returns>
		public void testB11(Object[] isArrayOfObject)
		{
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfFormalized"></param>
		/// <returns></returns>
		public void testB12(ShipmentIn[] isArrayOfFormalized)
		{
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfNulls"></param>
		/// <returns></returns>
		public void testB13(Object[] isArrayOfNulls)
		{
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public Object testC3()
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testC3");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isNULL"></param>
		/// <returns></returns>
		public Object testC4(Object isNULL)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testC4", isNULL);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isString"></param>
		/// <returns></returns>
		public Object testC5(string isString)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testC5", isString);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isSimple"></param>
		/// <returns></returns>
		public Object testC6(Int32 isSimple)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testC6", isSimple);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isObject"></param>
		/// <returns></returns>
		public Object testC7(Object isObject)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testC7", isObject);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isFormalized"></param>
		/// <returns></returns>
		public Object testC8(ShipmentIn isFormalized)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testC8", isFormalized);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfString"></param>
		/// <returns></returns>
		public Object testC9(string[] isArrayOfString)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testC9", isArrayOfString);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfSimple"></param>
		/// <returns></returns>
		public Object testC10(Int32[] isArrayOfSimple)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testC10", isArrayOfSimple);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfObject"></param>
		/// <returns></returns>
		public Object testC11(Object[] isArrayOfObject)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testC11", isArrayOfObject);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfFormalized"></param>
		/// <returns></returns>
		public Object testC12(ShipmentIn[] isArrayOfFormalized)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testC12", isArrayOfFormalized);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfNulls"></param>
		/// <returns></returns>
		public Object testC13(Object[] isArrayOfNulls)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testC13", isArrayOfNulls);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="param1"></param>
		/// <param name="param2"></param>
		/// <param name="param3"></param>
		/// <returns></returns>
		public Object testC14(Object param1, Object param2, Object param3)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testC14", param1, param2, param3);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="param1"></param>
		/// <param name="param2"></param>
		/// <param name="param3"></param>
		/// <returns></returns>
		public Object testC15(Object param1, string param2, Int32 param3)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testC15", param1, param2, param3);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="shipment1"></param>
		/// <param name="shipment2"></param>
		/// <param name="shipment3"></param>
		/// <returns></returns>
		public Object testC16(ShipmentIn shipment1, ShipmentIn shipment2, ShipmentIn shipment3)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testC16", shipment1, shipment2, shipment3);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="shipment1"></param>
		/// <param name="param1"></param>
		/// <param name="param2"></param>
		/// <returns></returns>
		public Object testC17(ShipmentIn shipment1, Object param1, Int32 param2)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testC17", shipment1, param1, param2);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="shipment1"></param>
		/// <param name="param1"></param>
		/// <param name="param2"></param>
		/// <param name="param3"></param>
		/// <returns></returns>
		public Object testC18(ShipmentIn[] shipment1, Object[] param1, string[] param2, Int32[] param3)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testC18", shipment1, param1, param2, param3);
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public Int32 testD3()
		{
			return bNesisApi.Call<Int32>("bNesisTestService", bNesisToken, "testD3");
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public Int32 testD3null()
		{
			return bNesisApi.Call<Int32>("bNesisTestService", bNesisToken, "testD3null");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isNull"></param>
		/// <returns></returns>
		public Int32 testD4(Object isNull)
		{
			return bNesisApi.Call<Int32>("bNesisTestService", bNesisToken, "testD4", isNull);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isNull"></param>
		/// <returns></returns>
		public Int32 testD4null(Object isNull)
		{
			return bNesisApi.Call<Int32>("bNesisTestService", bNesisToken, "testD4null", isNull);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isString"></param>
		/// <returns></returns>
		public Int32 testD5(string isString)
		{
			return bNesisApi.Call<Int32>("bNesisTestService", bNesisToken, "testD5", isString);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isString"></param>
		/// <returns></returns>
		public Int32 testD5null(string isString)
		{
			return bNesisApi.Call<Int32>("bNesisTestService", bNesisToken, "testD5null", isString);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isSimple"></param>
		/// <returns></returns>
		public Int32 testD6(Int32 isSimple)
		{
			return bNesisApi.Call<Int32>("bNesisTestService", bNesisToken, "testD6", isSimple);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isSimple"></param>
		/// <returns></returns>
		public Int32 testD6null(Int32 isSimple)
		{
			return bNesisApi.Call<Int32>("bNesisTestService", bNesisToken, "testD6null", isSimple);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isObject"></param>
		/// <returns></returns>
		public Int32 testD7(Object isObject)
		{
			return bNesisApi.Call<Int32>("bNesisTestService", bNesisToken, "testD7", isObject);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isObject"></param>
		/// <returns></returns>
		public Int32 testD7null(Object isObject)
		{
			return bNesisApi.Call<Int32>("bNesisTestService", bNesisToken, "testD7null", isObject);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isFormalized"></param>
		/// <returns></returns>
		public Int32 testD8(ShipmentIn isFormalized)
		{
			return bNesisApi.Call<Int32>("bNesisTestService", bNesisToken, "testD8", isFormalized);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isFormalized"></param>
		/// <returns></returns>
		public Int32 testD8null(ShipmentIn isFormalized)
		{
			return bNesisApi.Call<Int32>("bNesisTestService", bNesisToken, "testD8null", isFormalized);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfString"></param>
		/// <returns></returns>
		public Int32 testD9(string[] isArrayOfString)
		{
			return bNesisApi.Call<Int32>("bNesisTestService", bNesisToken, "testD9", isArrayOfString);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfString"></param>
		/// <returns></returns>
		public Int32 testD9null(string[] isArrayOfString)
		{
			return bNesisApi.Call<Int32>("bNesisTestService", bNesisToken, "testD9null", isArrayOfString);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfSimple"></param>
		/// <returns></returns>
		public Int32 testD10(Int32[] isArrayOfSimple)
		{
			return bNesisApi.Call<Int32>("bNesisTestService", bNesisToken, "testD10", isArrayOfSimple);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfSimple"></param>
		/// <returns></returns>
		public Int32 testD10null(Int32[] isArrayOfSimple)
		{
			return bNesisApi.Call<Int32>("bNesisTestService", bNesisToken, "testD10null", isArrayOfSimple);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfObject"></param>
		/// <returns></returns>
		public Int32 testD11(Object[] isArrayOfObject)
		{
			return bNesisApi.Call<Int32>("bNesisTestService", bNesisToken, "testD11", isArrayOfObject);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfObject"></param>
		/// <returns></returns>
		public Int32 testD11null(Object[] isArrayOfObject)
		{
			return bNesisApi.Call<Int32>("bNesisTestService", bNesisToken, "testD11null", isArrayOfObject);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfFormalized"></param>
		/// <returns></returns>
		public Int32 testD12(ShipmentIn[] isArrayOfFormalized)
		{
			return bNesisApi.Call<Int32>("bNesisTestService", bNesisToken, "testD12", isArrayOfFormalized);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfFormalized"></param>
		/// <returns></returns>
		public Int32 testD12null(ShipmentIn[] isArrayOfFormalized)
		{
			return bNesisApi.Call<Int32>("bNesisTestService", bNesisToken, "testD12null", isArrayOfFormalized);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfNulls"></param>
		/// <returns></returns>
		public Int32 testD13(Object[] isArrayOfNulls)
		{
			return bNesisApi.Call<Int32>("bNesisTestService", bNesisToken, "testD13", isArrayOfNulls);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfNulls"></param>
		/// <returns></returns>
		public Int32 testD13null(Object[] isArrayOfNulls)
		{
			return bNesisApi.Call<Int32>("bNesisTestService", bNesisToken, "testD13null", isArrayOfNulls);
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public Object testE3()
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testE3");
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public Object testE3null()
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testE3null");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isNull"></param>
		/// <returns></returns>
		public Object testE4(Object isNull)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testE4", isNull);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isNull"></param>
		/// <returns></returns>
		public Object testE4null(Object isNull)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testE4null", isNull);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isString"></param>
		/// <returns></returns>
		public Object testE5(string isString)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testE5", isString);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isString"></param>
		/// <returns></returns>
		public Object testE5null(string isString)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testE5null", isString);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isSimple"></param>
		/// <returns></returns>
		public Object testE6(Int32 isSimple)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testE6", isSimple);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isSimple"></param>
		/// <returns></returns>
		public Object testE6null(Int32 isSimple)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testE6null", isSimple);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isObject"></param>
		/// <returns></returns>
		public Object testE7(Object isObject)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testE7", isObject);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isObject"></param>
		/// <returns></returns>
		public Object testE7null(Object isObject)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testE7null", isObject);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isFormalized"></param>
		/// <returns></returns>
		public Object testE8(ShipmentIn isFormalized)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testE8", isFormalized);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isFormalized"></param>
		/// <returns></returns>
		public Object testE8null(ShipmentIn isFormalized)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testE8null", isFormalized);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfString"></param>
		/// <returns></returns>
		public Object testE9(string[] isArrayOfString)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testE9", isArrayOfString);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfString"></param>
		/// <returns></returns>
		public Object testE9null(string[] isArrayOfString)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testE9null", isArrayOfString);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="isArrayOfSimple"></param>
		/// <returns></returns>
		public Object testE10(Int32[] isArrayOfSimple)
		{
			return bNesisApi.Call<Object>("bNesisTestService", bNesisToken, "testE10", isArrayOfSimple);
		}
}
	public class ShipmentIn
	{
		/// <summary>
		/// Repient phone. 
		/// </summary>
		public string recipientPhone { get; set; }

		/// <summary>
		/// Recipient email. 
		/// </summary>
		public string recipientEmail { get; set; }

		/// <summary>
		/// Recipient address id. 
		/// </summary>
		public string recipientAddressId { get; set; }

		/// <summary>
		/// Return address id, may be specified additionally, if not specified will used main address where 'main' is true. 
		/// </summary>
		public string returnAddressId { get; set; }

		/// <summary>
		/// Identificator of shipment group, if sending is a group. 
		/// </summary>
		public string shipmentGroupUuid { get; set; }

		/// <summary>
		/// External ID of departure at the base counterparty. 
		/// </summary>
		public string externalId { get; set; }

		/// <summary>
		/// Delivery type(for international shippment). 
		/// </summary>
		public string deliveryType { get; set; }

		/// <summary>
		/// Actions with shipment in case the recipient did not take it.
		///  RETURN - return to the sender.RETURN_AFTER_F REE_STORAGE - return after the expiration of free storage.PROCESS_AS_REF USAL - destroy the parcel.By default RETURN. 
		/// </summary>
		public string onFailReceiveType { get; set; }

		/// <summary>
		/// Postpay in UAH may not be higher than the stated price. 
		/// </summary>
		public Int64 postPay { get; set; }

		/// <summary>
		/// Description or comments (max 255 characters). 
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// Payment for the shipment upon receipt. 
		///  true - payment by the recipient.false - payment sender.By default, false. 
		/// </summary>
		public Boolean paidByRecipient { get; set; }

		/// <summary>
		/// Payment by cashless payment.
		///  true - non-cash.false - cash.By default, true. 
		/// </summary>
		public Boolean nonCashPayment { get; set; }

		/// <summary>
		/// The note is a bulky parcel.
		///  true - cumbersomefalse - not cumbersomeBy default false 
		/// </summary>
		public Boolean bulky { get; set; }

		/// <summary>
		/// The note is a fragile parcel.
		///  true - brittle.false - not fragile.By default false. 
		/// </summary>
		public Boolean fragile { get; set; }

		/// <summary>
		/// Bee pointing.
		///  By default false. 
		/// </summary>
		public Boolean bees { get; set; }

		/// <summary>
		/// Sending from a receipt.
		///  If true when receiving a shipment (Service for which an additional price is charged. Details on the site ukrposhta.ua), the sender receives a letter stating that the shipment has been received.By default false. 
		/// </summary>
		public Boolean recommended { get; set; }

		/// <summary>
		/// Sms message about the arrival of the parcel.
		///  If the true recipient receives the message (Service for which an additional price is charged. Details on the site ukrposhta.ua).By default false. 
		/// </summary>
		public Boolean sms { get; set; }

		/// <summary>
		/// Return shipping documentation
		///  By default false. 
		/// </summary>
		public Boolean documentBack { get; set; }

		/// <summary>
		/// Review at handed.
		///  By default false. 
		/// </summary>
		public Boolean checkOnDelivery { get; set; }

		/// <summary>
		/// Display information about the sender's bank account on the address bar.
		///  By default false. Only if there is postpay. 
		/// </summary>
		public Boolean transferPostPayToBankAccount { get; set; }

		/// <summary>
		/// Type shipment.
		///  EXPRESS - Ukrposhta Express.STANDARD - Ukrposhta standard.For more detail see:http://ukrposhta.ua/ By default EXPRESS. 
		/// </summary>
		public string type { get; set; }

		/// <summary>
		/// The party who pays the postpay billing fee.
		///  true - the amount is paid by the recipient.false - is paid by the sender.By default true. 
		/// </summary>
		public Boolean postPayPaidByRecipient { get; set; }

	}

	public class ShipmentOut
	{
		/// <summary>
		/// Identificator. 
		/// </summary>
		public string uuid { get; set; }

		/// <summary>
		/// Recipient phone. 
		/// </summary>
		public string recipientPhone { get; set; }

		/// <summary>
		/// Recipient email. 
		/// </summary>
		public string recipientEmail { get; set; }

		/// <summary>
		/// Recipient address identifier. 
		/// </summary>
		public string recipientAddressId { get; set; }

		/// <summary>
		/// Return address identifier. 
		/// </summary>
		public string returnAddressId { get; set; }

		/// <summary>
		/// Shipment group identifier. 
		/// </summary>
		public string shipmentGroupUuid { get; set; }

		/// <summary>
		/// External identifier. 
		/// </summary>
		public string externalId { get; set; }

		/// <summary>
		/// Delivery type.
		///  RETURN - return to the sender.RETURN_AFTER_F REE_STORAGE - return after the expiration of free storage.PROCESS_AS_REF USAL - destroy the parcel.By default RETURN. 
		/// </summary>
		public string deliveryType { get; set; }

		/// <summary>
		/// Package type. 
		/// </summary>
		public string packageType { get; set; }

		/// <summary>
		/// Actions with shipment in case the recipient did not take it. 
		/// </summary>
		public string onFailReceiveType { get; set; }

		/// <summary>
		/// Parcel barcode. 
		/// </summary>
		public string barcode { get; set; }

		/// <summary>
		/// Delivery price. 
		/// </summary>
		public Int64 deliveryPrice { get; set; }

		/// <summary>
		/// Post pay. 
		/// </summary>
		public Int64 postPay { get; set; }

		/// <summary>
		/// Currency code. 
		/// </summary>
		public string currencyCode { get; set; }

		/// <summary>
		/// Post pay currency code. 
		/// </summary>
		public string postPayCurrencyCode { get; set; }

		/// <summary>
		/// Currency exchange rate. 
		/// </summary>
		public string currencyExchangeRate { get; set; }

		/// <summary>
		/// Date of making the latest changes in the shipment. Date and time in the format "2017-06- 12T12: 31: 56" 
		/// </summary>
		public string lastModified { get; set; }

		/// <summary>
		/// Description or comments. 
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// Tracking departure. 
		/// </summary>
		public Object[] statusTrackings { get; set; }

		/// <summary>
		/// Payment for the shipment upon receipt. 
		///  true - payment by the recipient.false - payment sender.By default, false. 
		/// </summary>
		public Boolean paidByRecipient { get; set; }

		/// <summary>
		/// Payment by cashless payment.
		///  true - non-cash.false - cash.By default, true. 
		/// </summary>
		public Boolean nonCashPayment { get; set; }

		/// <summary>
		/// The note is a bulky parcel.
		///  true - cumbersomefalse - not cumbersomeBy default false 
		/// </summary>
		public Boolean bulky { get; set; }

		/// <summary>
		/// The note is a fragile parcel.
		///  true - brittle.false - not fragile.By default false. 
		/// </summary>
		public Boolean fragile { get; set; }

		/// <summary>
		/// Bee pointing.
		///  By default false. 
		/// </summary>
		public Boolean bees { get; set; }

		/// <summary>
		/// Sending from a receipt.
		///  If true when receiving a shipment (Service for which an additional price is charged. Details on the site ukrposhta.ua), the sender receives a letter stating that the shipment has been received.By default false. 
		/// </summary>
		public Boolean recommended { get; set; }

		/// <summary>
		/// Sms message about the arrival of the parcel.
		///  If the true recipient receives the message (Service for which an additional price is charged. Details on the site ukrposhta.ua).By default false. 
		/// </summary>
		public Boolean sms { get; set; }

		/// <summary>
		/// International shipping
		///  By default false. 
		/// </summary>
		public Boolean international { get; set; }

		/// <summary>
		/// Shipping price. 
		/// </summary>
		public string postPayDeliveryPrice { get; set; }

		/// <summary>
		/// The party who pays the postpay billing fee.
		///  true - the amount is paid by the recipient.false - is paid by the sender.By default true. 
		/// </summary>
		public Boolean postPayPaidByRecipient { get; set; }

		/// <summary>
		/// A description of the costing that describes how the cost of mail is generated. 
		/// </summary>
		public string calculationDescription { get; set; }

		/// <summary>
		/// Return shipping documentation.
		///  By default false. 
		/// </summary>
		public Boolean documentBack { get; set; }

		/// <summary>
		/// Review at handed.
		///  By default false. 
		/// </summary>
		public Boolean checkOnDelivery { get; set; }

		/// <summary>
		/// Display information about the sender's bank account on the address bar.
		///  By default false. Only if there is postpay. 
		/// </summary>
		public Boolean transferPostPayToBankAccount { get; set; }

		/// <summary>
		/// The shipping charge has been paid. 
		/// </summary>
		public Boolean deliveryPricePaid { get; set; }

		/// <summary>
		/// Postpay paid. 
		/// </summary>
		public Boolean postPayPaid { get; set; }

		/// <summary>
		/// The shipping charge has been paid. 
		/// </summary>
		public Boolean postPayDeliveryPricePaid { get; set; }

		/// <summary>
		/// Type shipment.
		///  EXPRESS - Ukrposhta Express.STANDARD - Ukrposhta standard.For more detail see:http://ukrposhta.ua/ By default EXPRESS. 
		/// </summary>
		public string type { get; set; }

		/// <summary>
		/// After the creation of the sending status changes to CREATED, after the registration of the shipment in the communications branch status changes to REGISTERED. 
		/// </summary>
		public string status { get; set; }

	}

}