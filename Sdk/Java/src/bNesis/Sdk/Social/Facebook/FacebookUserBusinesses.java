package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Businesses associated with the user
 *     https://developers.facebook.com/docs/graph-api/reference/user/businesses/
 *     Permissions
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     ads_management
 *     ads_read
 *     manage_pages
 *     business_management
 *     Page management Apps
 *     No data
 *     Other Apps
 *     No data 
 * @typedef {Object} FacebookUserBusinesses
 */
public class FacebookUserBusinesses
{
	public FacebookUserBusinesses(){}
	/**
	 * A list of Business nodes.
	 * @type {FacebookPage[]}
	 */
	public FacebookPage[] data;

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

