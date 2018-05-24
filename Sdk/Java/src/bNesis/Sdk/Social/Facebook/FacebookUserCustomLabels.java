package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * https://developers.facebook.com/docs/graph-api/reference/user/custom_labels/
 *     Permissions
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     No data
 *     Page management Apps
 *     manage_pages
 *     pages_show_list
 *     pages_messaging
 *     Other Apps
 *     No data 
 * @typedef {Object} FacebookUserCustomLabels
 */
public class FacebookUserCustomLabels
{
	public FacebookUserCustomLabels(){}
	/**
	 * A list of PageUserMessageThreadLabel nodes.
	 * @type {FacebookPage[]}
	 */
	public FacebookPage[] data;

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

