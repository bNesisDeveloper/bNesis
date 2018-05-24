package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * This represents a News Feed filter
 *     https://developers.facebook.com/docs/graph-api/reference/stream-filter/ 
 * @typedef {Object} FacebookStreamFilter
 */
public class FacebookStreamFilter
{
	public FacebookStreamFilter(){}
	/**
	 * The filter key used by the News Feed
	 * @type {String}
	 */
	public String filter_key;

	/**
	 * The name of the filter
	 * @type {String}
	 */
	public String name;

	/**
	 * The type of the filter
	 * @type {String}
	 */
	public String Type;

	}

