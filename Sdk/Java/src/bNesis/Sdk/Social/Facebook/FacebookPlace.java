package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * A place
 *      https://developers.facebook.com/docs/graph-api/reference/place/ 
 * @typedef {Object} FacebookPlace
 */
public class FacebookPlace
{
	public FacebookPlace(){}
	/**
	 * ID
	 * @type {String}
	 */
	public String id;

	/**
	 * Location of Place
	 * @type {FacebookLocation}
	 */
	public FacebookLocation location;

	/**
	 * Name
	 * @type {String}
	 */
	public String name;

	/**
	 * Overall Rating of Place, on a 5-star scale. 0 means not enough data to get a combined rating.
	 * @type {Short}
	 */
	public Short overall_rating;

	}

