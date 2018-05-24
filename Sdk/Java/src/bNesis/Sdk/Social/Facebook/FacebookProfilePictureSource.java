package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Profile Picture
 *     https://developers.facebook.com/docs/graph-api/reference/profile-picture-source/ 
 * @typedef {Object} FacebookProfilePictureSource
 */
public class FacebookProfilePictureSource
{
	public FacebookProfilePictureSource(){}
	/**
	 * A key to identify the profile picture for the purpose of invalidating the image cache
	 * @type {String}
	 */
	public String cache_key;

	/**
	 * Picture height in pixels. Only returned when specified as a modifier
	 * @type {Integer}
	 */
	public Integer height;

	/**
	 * True if the profile picture is the default 'silhouette' picture
	 * @type {String}
	 */
	public String is_silhouette;

	/**
	 * URL of the profile picture
	 * @type {String}
	 */
	public String url;

	/**
	 * Picture width in pixels. Only returned when specified as a modifier
	 * @type {Integer}
	 */
	public Integer width;

	}

