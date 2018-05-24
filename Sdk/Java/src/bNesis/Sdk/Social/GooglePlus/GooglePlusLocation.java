package bNesis.Sdk.Social.GooglePlus;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of GooglePlusLocation. 
 * @typedef {Object} GooglePlusLocation
 */
public class GooglePlusLocation
{
	public GooglePlusLocation(){}
	/**
	 * Identifies this resource as a place.
	 * @type {String}
	 */
	public String kind;

	/**
	 * The identifier of the location.
	 * @type {String}
	 */
	public String id;

	/**
	 * The name of the place
	 * @type {String}
	 */
	public String displayName;

	/**
	 * The position of the place.
	 * @type {GooglePlusPosition}
	 */
	public GooglePlusPosition position;

	/**
	 * The physical address of the place.
	 * @type {GooglePlusAddress}
	 */
	public GooglePlusAddress address;

	}

