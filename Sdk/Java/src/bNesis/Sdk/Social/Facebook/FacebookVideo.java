package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Represents an individual video on Facebook.
 *     https://developers.facebook.com/docs/graph-api/reference/video/
 *     Permissions
 *     Any valid access token can read videos on a public Page.
 *     A page access token can read all videos posted to or posted by that Page.
 *     A user access token can read any video your application created on behalf of that user.
 *     A user's videos can be read if the owner has granted the user_videos or user_posts permission.
 *     A user access token may read a video that user is tagged in if they user granted the user_videos or user_posts permission. However, in some cases the video's owner's privacy settings may not allow your application to access it.
 *     The source field will not be returned for Page-owned videos unless the User making the request has a role on the owning Page. 
 * @typedef {Object} FacebookVideo
 */
public class FacebookVideo
{
	public FacebookVideo(){}
	/**
	 * The time the video was initially published.
	 * @type {Date}
	 */
	public Date created_time;

	/**
	 * The video ID.
	 * @type {String}
	 */
	public String id;

	/**
	 * The description of the video.
	 * @type {String}
	 */
	public String description;

	/**
	 * Location associated with the video, if any.
	 * @type {FacebookPlace}
	 */
	public FacebookPlace place;

	}

