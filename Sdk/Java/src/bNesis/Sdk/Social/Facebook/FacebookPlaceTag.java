package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * A Place Tag
 *     https://developers.facebook.com/docs/graph-api/reference/place-tag/ 
 * @typedef {Object} FacebookPlaceTag
 */
public class FacebookPlaceTag
{
	public FacebookPlaceTag(){}
	/**
	 * ID
	 * @type {String}
	 */
	public String id;

	/**
	 * Time when the place was visited
	 * @type {Date}
	 */
	public Date created_time;

	/**
	 * The place that was visited
	 * @type {FacebookPage}
	 */
	public FacebookPage place;

	}

