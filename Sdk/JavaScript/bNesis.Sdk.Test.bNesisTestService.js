bNesisTestService = function (bNesisApi) {
    this.bNesisToken = null;
    var _bNesisApi = bNesisApi;

    /**
     * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
	 * or Attach to bNesis session with exists bNesis token
     * @return {string} bNesisToken value | true if bNesisToken is valid
	 */
    this.Auth = function (data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl) {
		if(arguments.length !== 1){
			var bNesisToken = _bNesisApi.Auth("bNesisTestProvider", data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl);
			return bNesisToken;
		}
		else{
		    this.bNesisToken = arguments[0];			
			return ValidateToken();		
		}		
    }

    /**
     * The method stops the authorization session with the service and clears the value of bNesisToken.
     * @return {Boolean} true - if service logoff is successful
	 */
    this.LogoffService = function () {
		var result = _bNesisApi.LogoffService("bNesisTestProvider", this.bNesisToken);
		if (result) this.bNesisToken = "";
		return result;             
    }
	
	/**
	 *  Getting last exception for current provider 	
	 * @return {ErrorInfo} 
	 */
    this.GetLastError = function () {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "GetLastError");
        return result;
    }

	/**
	 *  Getting arrays of error info 	
	 * @return {ErrorInfo[]} 
	 */
    this.GetErrorLog = function () {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "GetErrorLog");
        return result;
    }

	/**
	 *  Checks the token in the service. 	
	 * @return {Boolean} if token valid return true, if token not valid return false
	 */
    this.ValidateToken = function () {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "ValidateToken");
        return result;
    }

	/**
	 *  Disables the access token used to authenticate the call. 	
	 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false
	 */
    this.Logoff = function () {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "Logoff");
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfSimple 
	 * @return {Object} 
	 */
    this.testE10null = function (isArrayOfSimple) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testE10null", isArrayOfSimple);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfObject 
	 * @return {Object} 
	 */
    this.testE11 = function (isArrayOfObject) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testE11", isArrayOfObject);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfObject 
	 * @return {Object} 
	 */
    this.testE11null = function (isArrayOfObject) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testE11null", isArrayOfObject);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfFormalized 
	 * @return {Object} 
	 */
    this.testE12 = function (isArrayOfFormalized) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testE12", isArrayOfFormalized);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfFormalized 
	 * @return {Object} 
	 */
    this.testE12null = function (isArrayOfFormalized) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testE12null", isArrayOfFormalized);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfNulls 
	 * @return {Object} 
	 */
    this.testE13 = function (isArrayOfNulls) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testE13", isArrayOfNulls);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfNulls 
	 * @return {Object} 
	 */
    this.testE13null = function (isArrayOfNulls) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testE13null", isArrayOfNulls);
        return result;
    }

	/**
	 *   	
	 * @return {string} 
	 */
    this.testF3 = function () {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testF3");
        return result;
    }

	/**
	 *   	
	 * @return {string} 
	 */
    this.testF3null = function () {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testF3null");
        return result;
    }

	/**
	 *   	
	 * @param isNull 
	 * @return {string} 
	 */
    this.testF4 = function (isNull) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testF4", isNull);
        return result;
    }

	/**
	 *   	
	 * @param isNull 
	 * @return {string} 
	 */
    this.testF4null = function (isNull) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testF4null", isNull);
        return result;
    }

	/**
	 *   	
	 * @param isString 
	 * @return {string} 
	 */
    this.testF5 = function (isString) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testF5", isString);
        return result;
    }

	/**
	 *   	
	 * @param isString 
	 * @return {string} 
	 */
    this.testF5null = function (isString) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testF5null", isString);
        return result;
    }

	/**
	 *   	
	 * @param isSimple 
	 * @return {string} 
	 */
    this.testF6 = function (isSimple) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testF6", isSimple);
        return result;
    }

	/**
	 *   	
	 * @param isSimple 
	 * @return {string} 
	 */
    this.testF6null = function (isSimple) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testF6null", isSimple);
        return result;
    }

	/**
	 *   	
	 * @param isObject 
	 * @return {string} 
	 */
    this.testF7 = function (isObject) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testF7", isObject);
        return result;
    }

	/**
	 *   	
	 * @param isObject 
	 * @return {string} 
	 */
    this.testF7null = function (isObject) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testF7null", isObject);
        return result;
    }

	/**
	 *   	
	 * @param isFormalized 
	 * @return {string} 
	 */
    this.testF8 = function (isFormalized) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testF8", isFormalized);
        return result;
    }

	/**
	 *   	
	 * @param isFormalized 
	 * @return {string} 
	 */
    this.testF8null = function (isFormalized) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testF8null", isFormalized);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfString 
	 * @return {string} 
	 */
    this.testF9 = function (isArrayOfString) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testF9", isArrayOfString);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfString 
	 * @return {string} 
	 */
    this.testF9null = function (isArrayOfString) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testF9null", isArrayOfString);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfSimple 
	 * @return {string} 
	 */
    this.testF10 = function (isArrayOfSimple) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testF10", isArrayOfSimple);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfSimple 
	 * @return {string} 
	 */
    this.testF10null = function (isArrayOfSimple) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testF10null", isArrayOfSimple);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfObject 
	 * @return {string} 
	 */
    this.testF11 = function (isArrayOfObject) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testF11", isArrayOfObject);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfObject 
	 * @return {string} 
	 */
    this.testF11null = function (isArrayOfObject) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testF11null", isArrayOfObject);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfFormalized 
	 * @return {string} 
	 */
    this.testF12 = function (isArrayOfFormalized) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testF12", isArrayOfFormalized);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfFormalized 
	 * @return {string} 
	 */
    this.testF12null = function (isArrayOfFormalized) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testF12null", isArrayOfFormalized);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfNulls 
	 * @return {string} 
	 */
    this.testF13 = function (isArrayOfNulls) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testF13", isArrayOfNulls);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfNulls 
	 * @return {string} 
	 */
    this.testF13null = function (isArrayOfNulls) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testF13null", isArrayOfNulls);
        return result;
    }

	/**
	 *   	
	 * @return {ShipmentOut} 
	 */
    this.testG3 = function () {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testG3");
        return result;
    }

	/**
	 *   	
	 * @param isNull 
	 * @return {ShipmentOut} 
	 */
    this.testG4 = function (isNull) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testG4", isNull);
        return result;
    }

	/**
	 *   	
	 * @param isNull 
	 * @return {ShipmentOut} 
	 */
    this.testG4null = function (isNull) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testG4null", isNull);
        return result;
    }

	/**
	 *   	
	 * @param isString 
	 * @return {ShipmentOut} 
	 */
    this.testG5 = function (isString) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testG5", isString);
        return result;
    }

	/**
	 *   	
	 * @param isString 
	 * @return {ShipmentOut} 
	 */
    this.testG5null = function (isString) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testG5null", isString);
        return result;
    }

	/**
	 *   	
	 * @param isSimple 
	 * @return {ShipmentOut} 
	 */
    this.testG6 = function (isSimple) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testG6", isSimple);
        return result;
    }

	/**
	 *   	
	 * @param isSimple 
	 * @return {ShipmentOut} 
	 */
    this.testG6null = function (isSimple) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testG6null", isSimple);
        return result;
    }

	/**
	 *   	
	 * @param isObject 
	 * @return {ShipmentOut} 
	 */
    this.testG7 = function (isObject) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testG7", isObject);
        return result;
    }

	/**
	 *   	
	 * @param isObject 
	 * @return {ShipmentOut} 
	 */
    this.testG7null = function (isObject) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testG7null", isObject);
        return result;
    }

	/**
	 *   	
	 * @param isFormalized 
	 * @return {ShipmentOut} 
	 */
    this.testG8 = function (isFormalized) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testG8", isFormalized);
        return result;
    }

	/**
	 *   	
	 * @param isFormalized 
	 * @return {ShipmentOut} 
	 */
    this.testG8null = function (isFormalized) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testG8null", isFormalized);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfString 
	 * @return {ShipmentOut} 
	 */
    this.testG9 = function (isArrayOfString) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testG9", isArrayOfString);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfString 
	 * @return {ShipmentOut} 
	 */
    this.testG9null = function (isArrayOfString) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testG9null", isArrayOfString);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfSimple 
	 * @return {ShipmentOut} 
	 */
    this.testG10 = function (isArrayOfSimple) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testG10", isArrayOfSimple);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfSimple 
	 * @return {ShipmentOut} 
	 */
    this.testG10null = function (isArrayOfSimple) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testG10null", isArrayOfSimple);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfObject 
	 * @return {ShipmentOut} 
	 */
    this.testG11 = function (isArrayOfObject) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testG11", isArrayOfObject);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfObject 
	 * @return {ShipmentOut} 
	 */
    this.testG11null = function (isArrayOfObject) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testG11null", isArrayOfObject);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfFormalized 
	 * @return {ShipmentOut} 
	 */
    this.testG12 = function (isArrayOfFormalized) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testG12", isArrayOfFormalized);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfFormalized 
	 * @return {ShipmentOut} 
	 */
    this.testG12null = function (isArrayOfFormalized) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testG12null", isArrayOfFormalized);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfNulls 
	 * @return {ShipmentOut} 
	 */
    this.testG13 = function (isArrayOfNulls) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testG13", isArrayOfNulls);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfNulls 
	 * @return {ShipmentOut} 
	 */
    this.testG13null = function (isArrayOfNulls) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testG13null", isArrayOfNulls);
        return result;
    }

	///<summary>
	/// All B methods returns void 
	/// </summary>
		/// <returns></returns>
    this.testB3 = function () {
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
    }

	///<summary>
	///  
	/// </summary>
	 * @param isNULL 
		/// <returns></returns>
    this.testB4 = function (isNULL) {
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
    }

	///<summary>
	///  
	/// </summary>
	 * @param isString 
		/// <returns></returns>
    this.testB5 = function (isString) {
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
    }

	///<summary>
	///  
	/// </summary>
	 * @param isSimple 
		/// <returns></returns>
    this.testB6 = function (isSimple) {
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
    }

	///<summary>
	///  
	/// </summary>
	 * @param isObject 
		/// <returns></returns>
    this.testB7 = function (isObject) {
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
    }

	///<summary>
	///  
	/// </summary>
	 * @param isFormalized 
		/// <returns></returns>
    this.testB8 = function (isFormalized) {
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
    }

	///<summary>
	///  
	/// </summary>
	 * @param isArrayOfString 
		/// <returns></returns>
    this.testB9 = function (isArrayOfString) {
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
    }

	///<summary>
	///  
	/// </summary>
	 * @param isArrayOfSimple 
		/// <returns></returns>
    this.testB10 = function (isArrayOfSimple) {
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
    }

	///<summary>
	///  
	/// </summary>
	 * @param isArrayOfObject 
		/// <returns></returns>
    this.testB11 = function (isArrayOfObject) {
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
    }

	///<summary>
	///  
	/// </summary>
	 * @param isArrayOfFormalized 
		/// <returns></returns>
    this.testB12 = function (isArrayOfFormalized) {
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
    }

	///<summary>
	///  
	/// </summary>
	 * @param isArrayOfNulls 
		/// <returns></returns>
    this.testB13 = function (isArrayOfNulls) {
			//bNesisApi.Call Can't be used with VOID return type, please connect with this API developer to fix this
			return; 
    }

	/**
	 *   	
	 * @return {Object} 
	 */
    this.testC3 = function () {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testC3");
        return result;
    }

	/**
	 *   	
	 * @param isNULL 
	 * @return {Object} 
	 */
    this.testC4 = function (isNULL) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testC4", isNULL);
        return result;
    }

	/**
	 *   	
	 * @param isString 
	 * @return {Object} 
	 */
    this.testC5 = function (isString) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testC5", isString);
        return result;
    }

	/**
	 *   	
	 * @param isSimple 
	 * @return {Object} 
	 */
    this.testC6 = function (isSimple) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testC6", isSimple);
        return result;
    }

	/**
	 *   	
	 * @param isObject 
	 * @return {Object} 
	 */
    this.testC7 = function (isObject) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testC7", isObject);
        return result;
    }

	/**
	 *   	
	 * @param isFormalized 
	 * @return {Object} 
	 */
    this.testC8 = function (isFormalized) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testC8", isFormalized);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfString 
	 * @return {Object} 
	 */
    this.testC9 = function (isArrayOfString) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testC9", isArrayOfString);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfSimple 
	 * @return {Object} 
	 */
    this.testC10 = function (isArrayOfSimple) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testC10", isArrayOfSimple);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfObject 
	 * @return {Object} 
	 */
    this.testC11 = function (isArrayOfObject) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testC11", isArrayOfObject);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfFormalized 
	 * @return {Object} 
	 */
    this.testC12 = function (isArrayOfFormalized) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testC12", isArrayOfFormalized);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfNulls 
	 * @return {Object} 
	 */
    this.testC13 = function (isArrayOfNulls) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testC13", isArrayOfNulls);
        return result;
    }

	/**
	 *   	
	 * @param param1 
	 * @param param2 
	 * @param param3 
	 * @return {Object} 
	 */
    this.testC14 = function (param1, param2, param3) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testC14", param1, param2, param3);
        return result;
    }

	/**
	 *   	
	 * @param param1 
	 * @param param2 
	 * @param param3 
	 * @return {Object} 
	 */
    this.testC15 = function (param1, param2, param3) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testC15", param1, param2, param3);
        return result;
    }

	/**
	 *   	
	 * @param shipment1 
	 * @param shipment2 
	 * @param shipment3 
	 * @return {Object} 
	 */
    this.testC16 = function (shipment1, shipment2, shipment3) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testC16", shipment1, shipment2, shipment3);
        return result;
    }

	/**
	 *   	
	 * @param shipment1 
	 * @param param1 
	 * @param param2 
	 * @return {Object} 
	 */
    this.testC17 = function (shipment1, param1, param2) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testC17", shipment1, param1, param2);
        return result;
    }

	/**
	 *   	
	 * @param shipment1 
	 * @param param1 
	 * @param param2 
	 * @param param3 
	 * @return {Object} 
	 */
    this.testC18 = function (shipment1, param1, param2, param3) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testC18", shipment1, param1, param2, param3);
        return result;
    }

	/**
	 *   	
	 * @return {Int32} 
	 */
    this.testD3 = function () {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testD3");
        return result;
    }

	/**
	 *   	
	 * @return {Int32} 
	 */
    this.testD3null = function () {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testD3null");
        return result;
    }

	/**
	 *   	
	 * @param isNull 
	 * @return {Int32} 
	 */
    this.testD4 = function (isNull) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testD4", isNull);
        return result;
    }

	/**
	 *   	
	 * @param isNull 
	 * @return {Int32} 
	 */
    this.testD4null = function (isNull) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testD4null", isNull);
        return result;
    }

	/**
	 *   	
	 * @param isString 
	 * @return {Int32} 
	 */
    this.testD5 = function (isString) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testD5", isString);
        return result;
    }

	/**
	 *   	
	 * @param isString 
	 * @return {Int32} 
	 */
    this.testD5null = function (isString) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testD5null", isString);
        return result;
    }

	/**
	 *   	
	 * @param isSimple 
	 * @return {Int32} 
	 */
    this.testD6 = function (isSimple) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testD6", isSimple);
        return result;
    }

	/**
	 *   	
	 * @param isSimple 
	 * @return {Int32} 
	 */
    this.testD6null = function (isSimple) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testD6null", isSimple);
        return result;
    }

	/**
	 *   	
	 * @param isObject 
	 * @return {Int32} 
	 */
    this.testD7 = function (isObject) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testD7", isObject);
        return result;
    }

	/**
	 *   	
	 * @param isObject 
	 * @return {Int32} 
	 */
    this.testD7null = function (isObject) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testD7null", isObject);
        return result;
    }

	/**
	 *   	
	 * @param isFormalized 
	 * @return {Int32} 
	 */
    this.testD8 = function (isFormalized) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testD8", isFormalized);
        return result;
    }

	/**
	 *   	
	 * @param isFormalized 
	 * @return {Int32} 
	 */
    this.testD8null = function (isFormalized) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testD8null", isFormalized);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfString 
	 * @return {Int32} 
	 */
    this.testD9 = function (isArrayOfString) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testD9", isArrayOfString);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfString 
	 * @return {Int32} 
	 */
    this.testD9null = function (isArrayOfString) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testD9null", isArrayOfString);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfSimple 
	 * @return {Int32} 
	 */
    this.testD10 = function (isArrayOfSimple) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testD10", isArrayOfSimple);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfSimple 
	 * @return {Int32} 
	 */
    this.testD10null = function (isArrayOfSimple) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testD10null", isArrayOfSimple);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfObject 
	 * @return {Int32} 
	 */
    this.testD11 = function (isArrayOfObject) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testD11", isArrayOfObject);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfObject 
	 * @return {Int32} 
	 */
    this.testD11null = function (isArrayOfObject) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testD11null", isArrayOfObject);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfFormalized 
	 * @return {Int32} 
	 */
    this.testD12 = function (isArrayOfFormalized) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testD12", isArrayOfFormalized);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfFormalized 
	 * @return {Int32} 
	 */
    this.testD12null = function (isArrayOfFormalized) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testD12null", isArrayOfFormalized);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfNulls 
	 * @return {Int32} 
	 */
    this.testD13 = function (isArrayOfNulls) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testD13", isArrayOfNulls);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfNulls 
	 * @return {Int32} 
	 */
    this.testD13null = function (isArrayOfNulls) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testD13null", isArrayOfNulls);
        return result;
    }

	/**
	 *   	
	 * @return {Object} 
	 */
    this.testE3 = function () {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testE3");
        return result;
    }

	/**
	 *   	
	 * @return {Object} 
	 */
    this.testE3null = function () {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testE3null");
        return result;
    }

	/**
	 *   	
	 * @param isNull 
	 * @return {Object} 
	 */
    this.testE4 = function (isNull) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testE4", isNull);
        return result;
    }

	/**
	 *   	
	 * @param isNull 
	 * @return {Object} 
	 */
    this.testE4null = function (isNull) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testE4null", isNull);
        return result;
    }

	/**
	 *   	
	 * @param isString 
	 * @return {Object} 
	 */
    this.testE5 = function (isString) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testE5", isString);
        return result;
    }

	/**
	 *   	
	 * @param isString 
	 * @return {Object} 
	 */
    this.testE5null = function (isString) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testE5null", isString);
        return result;
    }

	/**
	 *   	
	 * @param isSimple 
	 * @return {Object} 
	 */
    this.testE6 = function (isSimple) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testE6", isSimple);
        return result;
    }

	/**
	 *   	
	 * @param isSimple 
	 * @return {Object} 
	 */
    this.testE6null = function (isSimple) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testE6null", isSimple);
        return result;
    }

	/**
	 *   	
	 * @param isObject 
	 * @return {Object} 
	 */
    this.testE7 = function (isObject) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testE7", isObject);
        return result;
    }

	/**
	 *   	
	 * @param isObject 
	 * @return {Object} 
	 */
    this.testE7null = function (isObject) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testE7null", isObject);
        return result;
    }

	/**
	 *   	
	 * @param isFormalized 
	 * @return {Object} 
	 */
    this.testE8 = function (isFormalized) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testE8", isFormalized);
        return result;
    }

	/**
	 *   	
	 * @param isFormalized 
	 * @return {Object} 
	 */
    this.testE8null = function (isFormalized) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testE8null", isFormalized);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfString 
	 * @return {Object} 
	 */
    this.testE9 = function (isArrayOfString) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testE9", isArrayOfString);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfString 
	 * @return {Object} 
	 */
    this.testE9null = function (isArrayOfString) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testE9null", isArrayOfString);
        return result;
    }

	/**
	 *   	
	 * @param isArrayOfSimple 
	 * @return {Object} 
	 */
    this.testE10 = function (isArrayOfSimple) {
        var result = _bNesisApi.Call("bNesisTestService", this.bNesisToken, "testE10", isArrayOfSimple);
        return result;
    }
}
 ShipmentIn = function () { 
	/**
	 * Repient phone.
	 * @type {string}
	 */
	this.recipientPhone = "";

	/**
	 * Recipient email.
	 * @type {string}
	 */
	this.recipientEmail = "";

	/**
	 * Recipient address id.
	 * @type {string}
	 */
	this.recipientAddressId = "";

	/**
	 * Return address id, may be specified additionally, if not specified will used main address where 'main' is true.
	 * @type {string}
	 */
	this.returnAddressId = "";

	/**
	 * Identificator of shipment group, if sending is a group.
	 * @type {string}
	 */
	this.shipmentGroupUuid = "";

	/**
	 * External ID of departure at the base counterparty.
	 * @type {string}
	 */
	this.externalId = "";

	/**
	 * Delivery type(for international shippment).
	 * @type {string}
	 */
	this.deliveryType = "";

	/**
	 * Actions with shipment in case the recipient did not take it.
	 *  RETURN - return to the sender.RETURN_AFTER_F REE_STORAGE - return after the expiration of free storage.PROCESS_AS_REF USAL - destroy the parcel.By default RETURN.
	 * @type {string}
	 */
	this.onFailReceiveType = "RETURN";

	/**
	 * Postpay in UAH may not be higher than the stated price.
	 * @type {Int64}
	 */
	this.postPay = 0;

	/**
	 * Description or comments (max 255 characters).
	 * @type {string}
	 */
	this.description = "";

	/**
	 * Payment for the shipment upon receipt. 
	 *  true - payment by the recipient.false - payment sender.By default, false.
	 * @type {Boolean}
	 */
	this.paidByRecipient = false;

	/**
	 * Payment by cashless payment.
	 *  true - non-cash.false - cash.By default, true.
	 * @type {Boolean}
	 */
	this.nonCashPayment = true;

	/**
	 * The note is a bulky parcel.
	 *  true - cumbersomefalse - not cumbersomeBy default false
	 * @type {Boolean}
	 */
	this.bulky = false;

	/**
	 * The note is a fragile parcel.
	 *  true - brittle.false - not fragile.By default false.
	 * @type {Boolean}
	 */
	this.fragile = false;

	/**
	 * Bee pointing.
	 *  By default false.
	 * @type {Boolean}
	 */
	this.bees = false;

	/**
	 * Sending from a receipt.
	 *  If true when receiving a shipment (Service for which an additional price is charged. Details on the site ukrposhta.ua), the sender receives a letter stating that the shipment has been received.By default false.
	 * @type {Boolean}
	 */
	this.recommended = false;

	/**
	 * Sms message about the arrival of the parcel.
	 *  If the true recipient receives the message (Service for which an additional price is charged. Details on the site ukrposhta.ua).By default false.
	 * @type {Boolean}
	 */
	this.sms = false;

	/**
	 * Return shipping documentation
	 *  By default false.
	 * @type {Boolean}
	 */
	this.documentBack = false;

	/**
	 * Review at handed.
	 *  By default false.
	 * @type {Boolean}
	 */
	this.checkOnDelivery = false;

	/**
	 * Display information about the sender's bank account on the address bar.
	 *  By default false. Only if there is postpay.
	 * @type {Boolean}
	 */
	this.transferPostPayToBankAccount = false;

	/**
	 * Type shipment.
	 *  EXPRESS - Ukrposhta Express.STANDARD - Ukrposhta standard.For more detail see:http://ukrposhta.ua/ By default EXPRESS.
	 * @type {string}
	 */
	this.type = "EXPRESS";

	/**
	 * The party who pays the postpay billing fee.
	 *  true - the amount is paid by the recipient.false - is paid by the sender.By default true.
	 * @type {Boolean}
	 */
	this.postPayPaidByRecipient = true;

}

 ShipmentOut = function () { 
	/**
	 * Identificator.
	 * @type {string}
	 */
	this.uuid = "";

	/**
	 * Recipient phone.
	 * @type {string}
	 */
	this.recipientPhone = "";

	/**
	 * Recipient email.
	 * @type {string}
	 */
	this.recipientEmail = "";

	/**
	 * Recipient address identifier.
	 * @type {string}
	 */
	this.recipientAddressId = "";

	/**
	 * Return address identifier.
	 * @type {string}
	 */
	this.returnAddressId = "";

	/**
	 * Shipment group identifier.
	 * @type {string}
	 */
	this.shipmentGroupUuid = "";

	/**
	 * External identifier.
	 * @type {string}
	 */
	this.externalId = "";

	/**
	 * Delivery type.
	 *  RETURN - return to the sender.RETURN_AFTER_F REE_STORAGE - return after the expiration of free storage.PROCESS_AS_REF USAL - destroy the parcel.By default RETURN.
	 * @type {string}
	 */
	this.deliveryType = "RETURN";

	/**
	 * Package type.
	 * @type {string}
	 */
	this.packageType = "";

	/**
	 * Actions with shipment in case the recipient did not take it.
	 * @type {string}
	 */
	this.onFailReceiveType = "";

	/**
	 * Parcel barcode.
	 * @type {string}
	 */
	this.barcode = "";

	/**
	 * Delivery price.
	 * @type {Int64}
	 */
	this.deliveryPrice = 0;

	/**
	 * Post pay.
	 * @type {Int64}
	 */
	this.postPay = 0;

	/**
	 * Currency code.
	 * @type {string}
	 */
	this.currencyCode = "";

	/**
	 * Post pay currency code.
	 * @type {string}
	 */
	this.postPayCurrencyCode = "";

	/**
	 * Currency exchange rate.
	 * @type {string}
	 */
	this.currencyExchangeRate = "";

	/**
	 * Date of making the latest changes in the shipment. Date and time in the format "2017-06- 12T12: 31: 56"
	 * @type {string}
	 */
	this.lastModified = "";

	/**
	 * Description or comments.
	 * @type {string}
	 */
	this.description = "";

	/**
	 * Tracking departure.
	 * @type {Object[]}
	 */
	this.statusTrackings = new Array();

	/**
	 * Payment for the shipment upon receipt. 
	 *  true - payment by the recipient.false - payment sender.By default, false.
	 * @type {Boolean}
	 */
	this.paidByRecipient = false;

	/**
	 * Payment by cashless payment.
	 *  true - non-cash.false - cash.By default, true.
	 * @type {Boolean}
	 */
	this.nonCashPayment = true;

	/**
	 * The note is a bulky parcel.
	 *  true - cumbersomefalse - not cumbersomeBy default false
	 * @type {Boolean}
	 */
	this.bulky = false;

	/**
	 * The note is a fragile parcel.
	 *  true - brittle.false - not fragile.By default false.
	 * @type {Boolean}
	 */
	this.fragile = false;

	/**
	 * Bee pointing.
	 *  By default false.
	 * @type {Boolean}
	 */
	this.bees = false;

	/**
	 * Sending from a receipt.
	 *  If true when receiving a shipment (Service for which an additional price is charged. Details on the site ukrposhta.ua), the sender receives a letter stating that the shipment has been received.By default false.
	 * @type {Boolean}
	 */
	this.recommended = false;

	/**
	 * Sms message about the arrival of the parcel.
	 *  If the true recipient receives the message (Service for which an additional price is charged. Details on the site ukrposhta.ua).By default false.
	 * @type {Boolean}
	 */
	this.sms = false;

	/**
	 * International shipping
	 *  By default false.
	 * @type {Boolean}
	 */
	this.international = false;

	/**
	 * Shipping price.
	 * @type {string}
	 */
	this.postPayDeliveryPrice = "";

	/**
	 * The party who pays the postpay billing fee.
	 *  true - the amount is paid by the recipient.false - is paid by the sender.By default true.
	 * @type {Boolean}
	 */
	this.postPayPaidByRecipient = true;

	/**
	 * A description of the costing that describes how the cost of mail is generated.
	 * @type {string}
	 */
	this.calculationDescription = "";

	/**
	 * Return shipping documentation.
	 *  By default false.
	 * @type {Boolean}
	 */
	this.documentBack = false;

	/**
	 * Review at handed.
	 *  By default false.
	 * @type {Boolean}
	 */
	this.checkOnDelivery = false;

	/**
	 * Display information about the sender's bank account on the address bar.
	 *  By default false. Only if there is postpay.
	 * @type {Boolean}
	 */
	this.transferPostPayToBankAccount = false;

	/**
	 * The shipping charge has been paid.
	 * @type {Boolean}
	 */
	this.deliveryPricePaid = false;

	/**
	 * Postpay paid.
	 * @type {Boolean}
	 */
	this.postPayPaid = false;

	/**
	 * The shipping charge has been paid.
	 * @type {Boolean}
	 */
	this.postPayDeliveryPricePaid = false;

	/**
	 * Type shipment.
	 *  EXPRESS - Ukrposhta Express.STANDARD - Ukrposhta standard.For more detail see:http://ukrposhta.ua/ By default EXPRESS.
	 * @type {string}
	 */
	this.type = "EXPRESS";

	/**
	 * After the creation of the sending status changes to CREATED, after the registration of the shipment in the communications branch status changes to REGISTERED.
	 * @type {string}
	 */
	this.status = "";

}

