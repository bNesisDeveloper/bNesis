package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Videos for a Facebook User.
 *     https://developers.facebook.com/docs/graph-api/reference/user/videos/
 *     Permissions
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     No data
 *     Page management Apps
 *      No data
 *     Other Apps
 *      user_videos 
 * @typedef {Object} FacebookUserVideos
 */
public class FacebookUserVideos
{
	public FacebookUserVideos(){}
	/**
	 * A list of Video nodes.
	 * @type {FacebookVideo[]}
	 */
	public FacebookVideo[] data;

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

