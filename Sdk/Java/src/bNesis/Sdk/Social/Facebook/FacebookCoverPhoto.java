package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * A cover photo for objects in the Graph API. Cover photos are used with Events, Groups, Pages and People. 
 * @typedef {Object} FacebookCoverPhoto
 */
public class FacebookCoverPhoto
{
	public FacebookCoverPhoto(){}
	/**
	 * The ID of the cover photo
	 * @type {String}
	 */
	public String id;

	/**
	 * Deprecated. Please use the id field instead
	 * @type {String}
	 */
	public String cover_id;

	/**
	 * When greater than 0% but less than 100%, the cover photo overflows horizontally. 
	 * The value represents the horizontal manual offset (the amount the user dragged the photo horizontally to show the part of interest) as a percentage of the offset necessary to make the photo fit the space.
	 * @type {Short}
	 */
	public Short offset_x;

	/**
	 * When greater than 0% but less than 100%, the cover photo overflows vertically. 
	 * The value represents the vertical manual offset (the amount the user dragged the photo vertically to show the part of interest) as a percentage of the offset necessary to make the photo fit the space.
	 * @type {Short}
	 */
	public Short offset_y;

	/**
	 * Direct URL for the person's cover photo image
	 * @type {String}
	 */
	public String source;

	}

