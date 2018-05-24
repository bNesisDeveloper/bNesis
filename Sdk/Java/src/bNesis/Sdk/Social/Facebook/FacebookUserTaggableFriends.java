package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Friends that can be tagged in content published via the Graph API
 *     https://developers.facebook.com/docs/graph-api/reference/user/taggable_friends/
 *     Permissions
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     No data
 *     Page management Apps
 *     No data
 *     Other Apps
 *     user_friends 
 * @typedef {Object} FacebookUserTaggableFriends
 */
public class FacebookUserTaggableFriends
{
	public FacebookUserTaggableFriends(){}
	/**
	 * A list of UserTaggableFriend nodes.
	 * @type {FacebookUserTaggableFriend[]}
	 */
	public FacebookUserTaggableFriend[] data;

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

