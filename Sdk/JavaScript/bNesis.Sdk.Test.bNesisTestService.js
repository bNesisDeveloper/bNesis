bNesisTestService = function (bNesisApi) {
    this.bNesisToken = null;
    var _bNesisApi = bNesisApi;

    this.Auth = function (data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl) {
        var bNesisToken = _bNesisApi.Auth("bNesisTestProvider", data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl);
        return bNesisToken;
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
