package bNesis.Sdk.Delivery.UkrPoshta;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * AddressOut used when need get information about address. 
 * @typedef {Object} UkrPoshtaAddressOut
 */
public class UkrPoshtaAddressOut
{
	public UkrPoshtaAddressOut(){}
	/**
	 * A unique address identifier is assigned automatically when you create it.
	 * @type {Integer}
	 */
	public Integer id;

	/**
	 * Post index.
	 * @type {String}
	 */
	public String postcode;

	/**
	 * The name of region.
	 * @type {String}
	 */
	public String region;

	/**
	 * The name of district.
	 * @type {String}
	 */
	public String district;

	/**
	 * The name of settlement.
	 * @type {String}
	 */
	public String city;

	/**
	 * The name of street.
	 * @type {String}
	 */
	public String street;

	/**
	 * The number of house.
	 * @type {String}
	 */
	public String houseNumber;

	/**
	 * The number of aprtment.
	 * @type {String}
	 */
	public String apartmentNumber;

	/**
	 * Description or comments.
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

