package bNesis.Sdk.Delivery.UkrPoshta;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * AddressIn used for add or edit address. 
 * @typedef {Object} UkrPoshtaAddressIn
 */
public class UkrPoshtaAddressIn
{
	public UkrPoshtaAddressIn(){}
	/**
	 * Post index. (Only numbers 5 characters)
	 * @type {String}
	 */
	public String postcode;

	/**
	 * The name region. (Max characters is 45)
	 * @type {String}
	 */
	public String region;

	/**
	 * The name district. (Max characters is 45)
	 * @type {String}
	 */
	public String district;

	/**
	 * The name settlement. (Max characters is 45)
	 * @type {String}
	 */
	public String city;

	/**
	 * The name street. (Max characters is 255)
	 * @type {String}
	 */
	public String street;

	/**
	 * The number house. (Max characters is 15)
	 * @type {String}
	 */
	public String houseNumber;

	/**
	 * The number aprtment. (Max characters is 15)
	 * @type {String}
	 */
	public String apartmentNumber;

	/**
	 * Description or comments. (Max characters is 255)
	 * @type {String}
	 */
	public String description;

	/**
	 * An intimation of the true/false. Used for calculation of billing is assigned automatically to based on index.
	 * @type {Boolean}
	 */
	public Boolean countryside;

	/**
	 * Part of the collected addresses, separated by commas.
	 * @type {String}
	 */
	public String detailedInfo;

	/**
	 * The country is on the default UA.
	 * @type {String}
	 */
	public String country;

	}

