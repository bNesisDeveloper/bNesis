package bNesis.Sdk.GovRegistry.Prozzoro;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of Address. 
 * @typedef {Object} ProzzoroAddress
 */
public class ProzzoroAddress
{
	public ProzzoroAddress(){}
	/**
	 * The postal code.
	 * @type {String}
	 */
	public String postalCode;

	/**
	 * The name of the country.
	 * @type {String}
	 */
	public String countryName;

	/**
	 * The street address.
	 * @type {String}
	 */
	public String streetAddress;

	/**
	 * The region.
	 * @type {String}
	 */
	public String region;

	/**
	 * The locality.
	 * @type {String}
	 */
	public String locality;

	}

