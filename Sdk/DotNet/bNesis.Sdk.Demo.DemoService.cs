using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;
using bNesis.Api.Desktop;
using bNesis.Sdk.Common;

namespace bNesis.Sdk.Demo.DemoService
{
	public class DemoService  
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

		public DemoService(DesktopbNesisApi bNesisApi)
		{
			this.bNesisApi = bNesisApi;
		}

		/// <summary>
		/// The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		/// </summary>
		/// <returns>bNesisToken value</returns>	
		public string Auth(string bNesisDevId,string redirectUrl)
		{
			bNesisToken = bNesisApi.Auth("DemoService", string.Empty,bNesisDevId,redirectUrl,string.Empty,string.Empty,null,string.Empty,string.Empty,false,string.Empty);
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
			bool result = bNesisApi.LogoffService("DemoService", bNesisToken);
			if (result) bNesisToken = string.Empty;
			return result;             
		}


		///<summary>
		/// Getting last exception for current provider 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo GetLastError()
		{
			return bNesisApi.Call<ErrorInfo>("DemoService", bNesisToken, "GetLastError");
		}

		///<summary>
		/// Getting arrays of error info 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo[] GetErrorLog()
		{
			return bNesisApi.Call<ErrorInfo[]>("DemoService", bNesisToken, "GetErrorLog");
		}

		///<summary>
		/// Checks the token in the service. 
		/// </summary>
		/// <returns>if token valid return true, if token not valid return false</returns>
		public Boolean ValidateToken()
		{
			return bNesisApi.Call<Boolean>("DemoService", bNesisToken, "ValidateToken");
		}

		///<summary>
		/// Disables the access token used to authenticate the call. 
		/// </summary>
		/// <returns>if token revoked method returns true 
		/// if token doesn't support token revocation or token is revoked method returns false</returns>
		public Boolean Logoff()
		{
			return bNesisApi.Call<Boolean>("DemoService", bNesisToken, "Logoff");
		}

		///<summary>
		/// Start an acquaintance with bNesis. Just click the execute button. 
		/// </summary>
		/// <returns>This simple example returns the string "Hello world".</returns>
		public string A01HelloWorld()
		{
			return bNesisApi.Call<string>("DemoService", bNesisToken, "A01HelloWorld");
		}

		///<summary>
		/// The following example demonstrates how to obtain the mathematical constant "pi". 
		/// </summary>
		/// <returns>This example returns the string with the constant "pi".</returns>
		public string A02GetPi()
		{
			return bNesisApi.Call<string>("DemoService", bNesisToken, "A02GetPi");
		}

		///<summary>
		/// This example demonstrates the process of translating a text string to upper case. To do it, you must type the word in small letters as a API parameter. 
		/// </summary>
		/// <param name="text">Word in lower case.</param>
		/// <returns>Uppercase word.</returns>
		public string A03TranslationTextToUppercase(string text)
		{
			return bNesisApi.Call<string>("DemoService", bNesisToken, "A03TranslationTextToUppercase", text);
		}

		///<summary>
		/// This method returns the air temperature in London. The unit of measurement is the degree of Celsius.
		/// To obtain this information, bNesis uses the service https://openweathermap.org/ 
		/// </summary>
		/// <returns>The air temperature.</returns>
		public Double A04GetCurrentAirTemperatureInLondon()
		{
			return bNesisApi.Call<Double>("DemoService", bNesisToken, "A04GetCurrentAirTemperatureInLondon");
		}

		///<summary>
		/// This method makes a request to the openweathermap server and obtains a full response about the current weather in the specified city.
		/// https://openweathermap.org/ 
		/// </summary>
		/// <param name="cityName">The name of the city. For example - London</param>
		/// <param name="countryCode">The country code. For example - uk. Use ISO 3166 country codes.</param>
		/// <returns>The full response with the current weather in the exact city.</returns>
		public Object B01GetCurrentWeatherInAnyCity(string cityName, string countryCode)
		{
			return bNesisApi.Call<Object>("DemoService", bNesisToken, "B01GetCurrentWeatherInAnyCity", cityName, countryCode);
		}

		///<summary>
		/// This method allows you to get a link to the Astronomy Picture of the Day and its description for exact dates from service https://api.nasa.gov/.
		/// https://api.nasa.gov/api.html#apod 
		/// </summary>
		/// <param name="date">The date. Format YYYY.MM.DD. Example - 2018.02.21.</param>
		/// <param name="hd">Type the word "true" to retrieve the URL in the high resolution.</param>
		/// <returns>A link to the Astronomy Picture of the Day and its description.</returns>
		public Object B02GetAstronomyPictureOfDayFromNASA(DateTime date, Boolean hd)
		{
			return bNesisApi.Call<Object>("DemoService", bNesisToken, "B02GetAstronomyPictureOfDayFromNASA", date, hd);
		}

		///<summary>
		/// This method allows you to get a list of all countries in the world.To obtain this information, bNesis refers to the service https://vk.com/. 
		/// https://vk.com/dev/database.getCountries 
		/// </summary>
		/// <returns>class DemoServiceCountries which contains the long all countries list.</returns>
		public DemoServiceCountries C01GetAllCountries()
		{
			return bNesisApi.Call<DemoServiceCountries>("DemoService", bNesisToken, "C01GetAllCountries");
		}

		///<summary>
		/// This method allows you to obtain a list of the nearest asteroids to the earth during the specified period for exact dates. 
		/// To use this method, you need to get an api key on the site https://api.nasa.gov/index.html#apply-for-an-api-key (Example bNesis Api Key - wS7KymT798xKNq0CPxxzPdunh8oATuRjUt2EKTvZ) and specify it as a parameter.
		/// You get the api key  very easy, without e-mail, password etc. This method can return a large response.
		/// https://api.nasa.gov/api.html#NeoWS 
		/// </summary>
		/// <param name="start_date">Starting date. Format YYYY.MM.DD. Example - 2018.01.21.</param>
		/// <param name="end_date">Ending date. Format YYYY.MM.DD. Example - 2018.01.22.</param>
		/// <param name="api_key">API key. Example - wS7KymT798xKNq0CPxxzPdunh8oATuRjUt2EKTvZ</param>
		/// <returns>List of asteroids</returns>
		public Object C02GetaListOfAsteroidsFromNASA(DateTime start_date, DateTime end_date, string api_key)
		{
			return bNesisApi.Call<Object>("DemoService", bNesisToken, "C02GetaListOfAsteroidsFromNASA", start_date, end_date, api_key);
		}

		///<summary>
		/// This method allows you to get a list of all countries in the world. To obtain information, bNesis refers you to the service https://vk.com/. The answer comes in a large deployed format with all data from the server.
		/// https://vk.com/dev/database.getCountries 
		/// </summary>
		/// <returns>List of countries.</returns>
		public Response C03GetAllCountriesWithFullResponseFromServer()
		{
			return bNesisApi.Call<Response>("DemoService", bNesisToken, "C03GetAllCountriesWithFullResponseFromServer");
		}
}
	///<summary>
	/// Class with data about countries. 
	/// </summary>
	public class DemoServiceCountriesItems
	{
		/// <summary>
		/// Country ID. 
		/// </summary>
		public Int32 id { get; set; }

		/// <summary>
		/// Country name. 
		/// </summary>
		public string title { get; set; }

	}

	///<summary>
	/// Response with data about countries. 
	/// </summary>
	public class DemoServiceCountriesResponse
	{
		/// <summary>
		/// Count of countries. 
		/// </summary>
		public Int32 count { get; set; }

		/// <summary>
		/// Contain id and title of countries. 
		/// </summary>
		public DemoServiceCountriesItems[] items { get; set; }

	}

	///<summary>
	/// Class for demonstrate methods getting list of countries. 
	/// </summary>
	public class DemoServiceCountries
	{
		/// <summary>
		/// Contains the response. 
		/// </summary>
		public DemoServiceCountriesResponse response { get; set; }

	}

}