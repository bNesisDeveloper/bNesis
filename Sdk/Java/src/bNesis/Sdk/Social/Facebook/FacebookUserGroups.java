package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * The Facebook Groups of which the person is an Admin.
 *     https://developers.facebook.com/docs/graph-api/reference/user/groups/
 *     Permissions
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     manage_pages
 *     business_management
 *     user_managed_groups
 *     user_events
 *     user_photos
 *     Page management Apps
 *     manage_pages
 *     user_managed_groups
 *     user_events
 *     user_photos
 *     Other Apps
 *     user_managed_groups 
 * @typedef {Object} FacebookUserGroups
 */
public class FacebookUserGroups
{
	public FacebookUserGroups(){}
	/**
	 * A list of Group nodes.
	 * @type {FacebookGroup[]}
	 */
	public FacebookGroup[] data;

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

