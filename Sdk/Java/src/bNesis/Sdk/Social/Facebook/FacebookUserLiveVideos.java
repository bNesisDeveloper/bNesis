package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Live videos from this person
 *     https://developers.facebook.com/docs/graph-api/reference/user/live_videos/
 *     Permissions
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     No data
 *     Page management Apps
 *     No data
 *     Other Apps
 *     publish_actions 
 * @typedef {Object} FacebookUserLiveVideos
 */
public class FacebookUserLiveVideos
{
	public FacebookUserLiveVideos(){}
	/**
	 * A list of LiveVideo nodes.
	 * @type {FacebookLiveVideo[]}
	 */
	public FacebookLiveVideo[] data;

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

