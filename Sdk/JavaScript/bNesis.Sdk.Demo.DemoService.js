DemoService = function (bNesisApi) {
    this.bNesisToken = null;
    var _bNesisApi = bNesisApi;

    /**
     * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
	 * or Attach to bNesis session with exists bNesis token
     * @return {string} bNesisToken value | true if bNesisToken is valid
	 */
    this.Auth = function (bNesisDevId,redirectUrl) {
		if(arguments.length !== 1){
			var bNesisToken = _bNesisApi.Auth("DemoService", "",bNesisDevId,redirectUrl,"","",null,"","",false,"");
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
		var result = _bNesisApi.LogoffService("DemoService", this.bNesisToken);
		if (result) this.bNesisToken = "";
		return result;             
    }
	
	/**
	 *  Getting last exception for current provider 	
	 * @return {ErrorInfo} 
	 */
    this.GetLastError = function () {
        var result = _bNesisApi.Call("DemoService", this.bNesisToken, "GetLastError");
        return result;
    }

	/**
	 *  Getting arrays of error info 	
	 * @return {ErrorInfo[]} 
	 */
    this.GetErrorLog = function () {
        var result = _bNesisApi.Call("DemoService", this.bNesisToken, "GetErrorLog");
        return result;
    }

	/**
	 *  Checks the token in the service. 	
	 * @return {Boolean} if token valid return true, if token not valid return false
	 */
    this.ValidateToken = function () {
        var result = _bNesisApi.Call("DemoService", this.bNesisToken, "ValidateToken");
        return result;
    }

	/**
	 *  Disables the access token used to authenticate the call. 	
	 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false
	 */
    this.Logoff = function () {
        var result = _bNesisApi.Call("DemoService", this.bNesisToken, "Logoff");
        return result;
    }

	/**
	 *  Start an acquaintance with bNesis. Just click the execute button. 	
	 * @return {string} This simple example returns the string "Hello world".
	 */
    this.A01HelloWorld = function () {
        var result = _bNesisApi.Call("DemoService", this.bNesisToken, "A01HelloWorld");
        return result;
    }

	/**
	 *  The following example demonstrates how to obtain the mathematical constant "pi". 	
	 * @return {string} This example returns the string with the constant "pi".
	 */
    this.A02GetPi = function () {
        var result = _bNesisApi.Call("DemoService", this.bNesisToken, "A02GetPi");
        return result;
    }

	/**
	 *  This example demonstrates the process of translating a text string to upper case. To do it, you must type the word in small letters as a API parameter. 	
	 * @param text Word in lower case.
	 * @return {string} Uppercase word.
	 */
    this.A03TranslationTextToUppercase = function (text) {
        var result = _bNesisApi.Call("DemoService", this.bNesisToken, "A03TranslationTextToUppercase", text);
        return result;
    }

	/**
	 *  This method returns the air temperature in London. The unit of measurement is the degree of Celsius.
	 * To obtain this information, bNesis uses the service https://openweathermap.org/ 	
	 * @return {Double} The air temperature.
	 */
    this.A04GetCurrentAirTemperatureInLondon = function () {
        var result = _bNesisApi.Call("DemoService", this.bNesisToken, "A04GetCurrentAirTemperatureInLondon");
        return result;
    }

	/**
	 *  This method makes a request to the openweathermap server and obtains a full response about the current weather in the specified city.
	 * https://openweathermap.org/ 	
	 * @param cityName The name of the city. For example - London
	 * @param countryCode The country code. For example - uk. Use ISO 3166 country codes.
	 * @return {Object} The full response with the current weather in the exact city.
	 */
    this.B01GetCurrentWeatherInAnyCity = function (cityName, countryCode) {
        var result = _bNesisApi.Call("DemoService", this.bNesisToken, "B01GetCurrentWeatherInAnyCity", cityName, countryCode);
        return result;
    }

	/**
	 *  This method allows you to get a link to the Astronomy Picture of the Day and its description for exact dates from service https://api.nasa.gov/.
	 * https://api.nasa.gov/api.html#apod 	
	 * @param date The date. Format YYYY.MM.DD. Example - 2018.02.21.
	 * @param hd Type the word "true" to retrieve the URL in the high resolution.
	 * @return {Object} A link to the Astronomy Picture of the Day and its description.
	 */
    this.B02GetAstronomyPictureOfDayFromNASA = function (date, hd) {
        var result = _bNesisApi.Call("DemoService", this.bNesisToken, "B02GetAstronomyPictureOfDayFromNASA", date, hd);
        return result;
    }

	/**
	 *  This method allows you to get a list of all countries in the world.To obtain this information, bNesis refers to the service https://vk.com/. 
	 * https://vk.com/dev/database.getCountries 	
	 * @return {DemoServiceCountries} class DemoServiceCountries which contains the long all countries list.
	 */
    this.C01GetAllCountries = function () {
        var result = _bNesisApi.Call("DemoService", this.bNesisToken, "C01GetAllCountries");
        return result;
    }

	/**
	 *  This method allows you to obtain a list of the nearest asteroids to the earth during the specified period for exact dates. 
	 * To use this method, you need to get an api key on the site https://api.nasa.gov/index.html#apply-for-an-api-key (Example bNesis Api Key - wS7KymT798xKNq0CPxxzPdunh8oATuRjUt2EKTvZ) and specify it as a parameter.
	 * You get the api key  very easy, without e-mail, password etc. This method can return a large response.
	 * https://api.nasa.gov/api.html#NeoWS 	
	 * @param start_date Starting date. Format YYYY.MM.DD. Example - 2018.01.21.
	 * @param end_date Ending date. Format YYYY.MM.DD. Example - 2018.01.22.
	 * @param api_key API key. Example - wS7KymT798xKNq0CPxxzPdunh8oATuRjUt2EKTvZ
	 * @return {Object} List of asteroids
	 */
    this.C02GetaListOfAsteroidsFromNASA = function (start_date, end_date, api_key) {
        var result = _bNesisApi.Call("DemoService", this.bNesisToken, "C02GetaListOfAsteroidsFromNASA", start_date, end_date, api_key);
        return result;
    }

	/**
	 *  This method allows you to get a list of all countries in the world. To obtain information, bNesis refers you to the service https://vk.com/. The answer comes in a large deployed format with all data from the server.
	 * https://vk.com/dev/database.getCountries 	
	 * @return {Response} List of countries.
	 */
    this.C03GetAllCountriesWithFullResponseFromServer = function () {
        var result = _bNesisApi.Call("DemoService", this.bNesisToken, "C03GetAllCountriesWithFullResponseFromServer");
        return result;
    }
}
/**
 * Class with data about countries. 
 * @typedef {Object} DemoServiceCountriesItems
 */
 DemoServiceCountriesItems = function () { 
	/**
	 * Country ID.
	 * @type {Int32}
	 */
	this.id = 0;

	/**
	 * Country name.
	 * @type {string}
	 */
	this.title = "";

}

/**
 * Response with data about countries. 
 * @typedef {Object} DemoServiceCountriesResponse
 */
 DemoServiceCountriesResponse = function () { 
	/**
	 * Count of countries.
	 * @type {Int32}
	 */
	this.count = 0;

	/**
	 * Contain id and title of countries.
	 * @type {DemoServiceCountriesItems[]}
	 */
	this.items = new Array();

}

/**
 * Class for demonstrate methods getting list of countries. 
 * @typedef {Object} DemoServiceCountries
 */
 DemoServiceCountries = function () { 
	/**
	 * Contains the response.
	 * @type {DemoServiceCountriesResponse}
	 */
	this.response = new DemoServiceCountriesResponse();

}

