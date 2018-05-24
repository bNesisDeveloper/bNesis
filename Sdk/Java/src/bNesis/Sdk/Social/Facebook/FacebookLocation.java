package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Location node used with other objects in the Graph API. 
 * @typedef {Object} FacebookLocation
 */
public class FacebookLocation
{
	public FacebookLocation(){}
	/**
	 * Gets or sets the city.
	 * @type {String}
	 */
	public String city;

	/**
	 * City ID. Any city identified is also a city you can use for targeting ads.
	 * @type {String}
	 */
	public String city_id;

	/**
	 * Country
	 * @type {String}
	 */
	public String country;

	/**
	 * Country code
	 * @type {String}
	 */
	public String country_code;

	/**
	 * Latitude
	 * @type {Short}
	 */
	public Short latitude;

	/**
	 * The parent location if this location is located within another location
	 * @type {String}
	 */
	public String located_in;

	/**
	 * Longitude
	 * @type {Short}
	 */
	public Short longitude;

	/**
	 * Longitude
	 * @type {String}
	 */
	public String name;

	/**
	 * Region
	 * @type {String}
	 */
	public String region;

	/**
	 * Region ID. Specifies a geographic region, such as California. An identified region is the same as one you can use to target ads.
	 * @type {String}
	 */
	public String region_id;

	/**
	 * State
	 * @type {String}
	 */
	public String state;

	/**
	 * Street
	 * @type {String}
	 */
	public String street;

	/**
	 * Zip code
	 * @type {String}
	 */
	public String zip;

	}

