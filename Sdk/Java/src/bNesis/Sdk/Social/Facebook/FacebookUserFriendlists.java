package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * A person's custom friend lists.
 *     https://developers.facebook.com/docs/graph-api/reference/user/friendlists/
 *     Permissions
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     ads_management
 *     manage_pages
 *     pages_show_list
 *     read_custom_friendlists
 *     user_location
 *     user_education_history
 *     Page management Apps
 *     No data
 *     Other Apps
 *     read_custom_friendlists 
 * @typedef {Object} FacebookUserFriendlists
 */
public class FacebookUserFriendlists
{
	public FacebookUserFriendlists(){}
	/**
	 * A list of FriendList nodes.
	 * @type {FacebookFriendList[]}
	 */
	public FacebookFriendList[] data;

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

