package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * A live video
 *     https://developers.facebook.com/docs/graph-api/reference/live-video/
 *     Permissions:
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     manage_pages
 *     pages_show_list
 *     business_management
 *     Page management Apps
 *     manage_pages
 *     pages_show_list
 *     Other Apps
 *     Permissions are not usually requested.
 *     A Page access token can read all videos posted to or posted by that Page.
 *     A User access token can read any video your application created on behalf of that user.
 *     A User's videos can be read if the owner has granted the user_videos or user_posts permission.
 *     A User access token may read a video that a user is tagged in if the user granted the user_videos or user_posts permission. However, in some cases the video's owner's privacy settings may not allow your application to access it.
 *     A User access token for an Admin of a Group can read Group-owned Live Videos.
 *     A User access token for an Admin of an Event can read Event-owned Live Videos. 
 * @typedef {Object} FacebookLiveVideo
 */
public class FacebookLiveVideo
{
	public FacebookLiveVideo(){}
	/**
	 * The time the video was initially published
	 * @type {Date}
	 */
	public Date broadcast_start_time;

	/**
	 * The live video ID
	 * @type {String}
	 */
	public String id;

	/**
	 * The description of the live video
	 * @type {String}
	 */
	public String description;

	/**
	 * The title of the live video
	 * @type {String}
	 */
	public String title;

	/**
	 * The inside video of live video - only visible when the live video has ended.
	 * @type {FacebookVideo}
	 */
	public FacebookVideo video;

	}

