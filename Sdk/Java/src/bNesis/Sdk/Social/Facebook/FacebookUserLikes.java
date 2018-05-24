package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * All the Pages this person has liked
 *     https://developers.facebook.com/docs/graph-api/reference/user/likes/
 *     Permissions
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     No data
 *     Page management Apps
 *     No data
 *     Other Apps
 *     user_likes 
 * @typedef {Object} FacebookUserLikes
 */
public class FacebookUserLikes
{
	public FacebookUserLikes(){}
	/**
	 * A list of Page nodes.
	 * @type {FacebookPage[]}
	 */
	public FacebookPage[] data;

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	/**
	 * Aggregated information about the edge, such as counts.
	 * @type {FacebookSummary}
	 */
	public FacebookSummary summary;

	}

