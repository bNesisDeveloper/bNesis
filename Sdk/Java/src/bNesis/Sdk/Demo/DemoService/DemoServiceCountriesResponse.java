package bNesis.Sdk.Demo.DemoService;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Response with data about countries. 
 * @typedef {Object} DemoServiceCountriesResponse
 */
public class DemoServiceCountriesResponse
{
	public DemoServiceCountriesResponse(){}
	/**
	 * Count of countries.
	 * @type {Integer}
	 */
	public Integer count;

	/**
	 * Contain id and title of countries.
	 * @type {DemoServiceCountriesItems[]}
	 */
	public DemoServiceCountriesItems[] items;

	}

