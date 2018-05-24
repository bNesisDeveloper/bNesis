package bNesis.Sdk.Social.GooglePlus;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of GooglePlusUrl 
 * @typedef {Object} GooglePlusUrl
 */
public class GooglePlusUrl
{
	public GooglePlusUrl(){}
	/**
	 * The type of URL.
	 *   Possible values are:
	 *   otherProfile - URL for another profile.
	 *   contributor - URL to a site for which this person is a contributor.
	 *   website - URL for this Google+ Page's primary website.
	 *   other - Other URL.
	 * @type {String}
	 */
	public String value;

	/**
	 * The URL value.
	 * @type {String}
	 */
	public String type;

	/**
	 * The label of the URL.
	 * @type {String}
	 */
	public String label;

	}

