package bNesis.Sdk.Demo.DemoService;

import java.io.*;
import java.util.List;
import java.util.Date;
import java.util.Map.Entry;
import bNesis.Api.*;

import bNesis.Sdk.Common.*;
import java.util.Date.*;
import bNesis.Sdk.Demo.DemoService.*;
import java.net.URI.*;

	public class DemoService  
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

		public DemoService(bNesisApi bnesisApi)
		{
			this._bNesisApi = bnesisApi;
		}

		/**
		 * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		 * @return {String} bNesisToken value
		 */
		public String Auth(String bNesisDevId,String redirectUrl) throws Exception
		{
			bNesisToken = _bNesisApi.Auth("DemoService", "",bNesisDevId,redirectUrl,"","",null,"","",false,"");
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
			Boolean result = _bNesisApi.LogoffService("DemoService", bNesisToken);
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
			return _bNesisApi.<ErrorInfo>Call(ErrorInfo.class, "DemoService", bNesisToken, "GetLastError");
		}

		/**
		 *  Getting arrays of error info 	
		 * @return {ErrorInfo[]}  
		 * @throws Exception
		 */
		public ErrorInfo[] GetErrorLog() throws Exception
		{
			return _bNesisApi.<ErrorInfo[]>Call(ErrorInfo[].class, "DemoService", bNesisToken, "GetErrorLog");
		}

		/**
		 *  Checks the token in the service. 	
		 * @return {Boolean} if token valid return true, if token not valid return false 
		 * @throws Exception
		 */
		public Boolean ValidateToken() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "DemoService", bNesisToken, "ValidateToken");
		}

		/**
		 *  Disables the access token used to authenticate the call. 	
		 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false 
		 * @throws Exception
		 */
		public Boolean Logoff() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "DemoService", bNesisToken, "Logoff");
		}

		/**
		 *  Start an acquaintance with bNesis. Just click the execute button. 	
		 * @return {String} This simple example returns the string "Hello world". 
		 * @throws Exception
		 */
		public String A01HelloWorld() throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "DemoService", bNesisToken, "A01HelloWorld");
		}

		/**
		 *  The following example demonstrates how to obtain the mathematical constant "pi". 	
		 * @return {String} This example returns the string with the constant "pi". 
		 * @throws Exception
		 */
		public String A02GetPi() throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "DemoService", bNesisToken, "A02GetPi");
		}

		/**
		 *  This example demonstrates the process of translating a text string to upper case. To do it, you must type the word in small letters as a API parameter. 	
		 * @param text Word in lower case.
	 * @return {String} Uppercase word. 
		 * @throws Exception
		 */
		public String A03TranslationTextToUppercase(String text) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "DemoService", bNesisToken, "A03TranslationTextToUppercase", text);
		}

		/**
		 *  This method returns the air temperature in London. The unit of measurement is the degree of Celsius.
	 * To obtain this information, bNesis uses the service https://openweathermap.org/ 	
		 * @return {Double} The air temperature. 
		 * @throws Exception
		 */
		public Double A04GetCurrentAirTemperatureInLondon() throws Exception
		{
			return _bNesisApi.<Double>Call(Double.class, "DemoService", bNesisToken, "A04GetCurrentAirTemperatureInLondon");
		}

		/**
		 *  This method makes a request to the openweathermap server and obtains a full response about the current weather in the specified city.
	 * https://openweathermap.org/ 	
		 * @param cityName The name of the city. For example - London
	 * @param countryCode The country code. For example - uk. Use ISO 3166 country codes.
	 * @return {Object} The full response with the current weather in the exact city. 
		 * @throws Exception
		 */
		public Object B01GetCurrentWeatherInAnyCity(String cityName, String countryCode) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "DemoService", bNesisToken, "B01GetCurrentWeatherInAnyCity", cityName, countryCode);
		}

		/**
		 *  This method allows you to get a link to the Astronomy Picture of the Day and its description for exact dates from service https://api.nasa.gov/.
	 * https://api.nasa.gov/api.html#apod 	
		 * @param date The date. Format YYYY.MM.DD. Example - 2018.02.21.
	 * @param hd Type the word "true" to retrieve the URL in the high resolution.
	 * @return {Object} A link to the Astronomy Picture of the Day and its description. 
		 * @throws Exception
		 */
		public Object B02GetAstronomyPictureOfDayFromNASA(Date date, Boolean hd) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "DemoService", bNesisToken, "B02GetAstronomyPictureOfDayFromNASA", date, hd);
		}

		/**
		 *  This method allows you to get a list of all countries in the world.To obtain this information, bNesis refers to the service https://vk.com/. 
	 * https://vk.com/dev/database.getCountries 	
		 * @return {DemoServiceCountries} class DemoServiceCountries which contains the long all countries list. 
		 * @throws Exception
		 */
		public DemoServiceCountries C01GetAllCountries() throws Exception
		{
			return _bNesisApi.<DemoServiceCountries>Call(DemoServiceCountries.class, "DemoService", bNesisToken, "C01GetAllCountries");
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
		 * @throws Exception
		 */
		public Object C02GetaListOfAsteroidsFromNASA(Date start_date, Date end_date, String api_key) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "DemoService", bNesisToken, "C02GetaListOfAsteroidsFromNASA", start_date, end_date, api_key);
		}

		/**
		 *  This method allows you to get a list of all countries in the world. To obtain information, bNesis refers you to the service https://vk.com/. The answer comes in a large deployed format with all data from the server.
	 * https://vk.com/dev/database.getCountries 	
		 * @return {Response} List of countries. 
		 * @throws Exception
		 */
		public Response C03GetAllCountriesWithFullResponseFromServer() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "DemoService", bNesisToken, "C03GetAllCountriesWithFullResponseFromServer");
		}
}