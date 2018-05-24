package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * An EntLiveEncoder is for the live encoders that can be associated withvideo broadcasts. This is part of the reference live encoder API.
 *     https://developers.facebook.com/docs/graph-api/reference/live-encoder/ 
 * @typedef {Object} FacebookLiveEncoder
 */
public class FacebookLiveEncoder
{
	public FacebookLiveEncoder(){}
	/**
	 * The id of the object
	 * @type {String}
	 */
	public String id;

	/**
	 * The live encoder brand (eg: Wowza)
	 * @type {String}
	 */
	public String brand;

	/**
	 * Creation time
	 * @type {Date}
	 */
	public Date creation_time;

	}

