package bNesis.Sdk.Common;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * bNesis unified Coutry item for services unified API call 
 * @typedef {Object} CountryItem
 */
public class CountryItem
{
	public CountryItem(){}
	/**
	 * Country data block (record) unical Id
	 * @type {String}
	 */
	public String Id;

	/**
	 * The Name of the Country
	 * @type {String}
	 */
	public String Name;

	/**
	 * Coutry Code
	 * https://en.wikipedia.org/wiki/Country_code
	 * ISO
	 * @type {String}
	 */
	public String Code;

	/**
	 * https://en.wikipedia.org/wiki/List_of_countries_by_tax_rates
	 * @type {String}
	 */
	public String Tax;

	}

