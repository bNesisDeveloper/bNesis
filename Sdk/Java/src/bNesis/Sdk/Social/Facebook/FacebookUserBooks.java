package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Books listed in someone's Facebook profile.
 *     https://developers.facebook.com/docs/graph-api/reference/user/books/ 
 *      Permissions
 *      Developers usually request these permissions for this endpoint:
 *      Marketing Apps
 *      No data
 *      Page management Apps
 *      No data
 *      Other Apps
 *      user_likes 
 * @typedef {Object} FacebookUserBooks
 */
public class FacebookUserBooks
{
	public FacebookUserBooks(){}
	/**
	 * Gets or sets the data.
	 * @type {FacebookPage[]}
	 */
	public FacebookPage[] data;

	/**
	 * Gets or sets the paging.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	/**
	 * Gets or sets the summary.
	 * @type {FacebookSummary}
	 */
	public FacebookSummary summary;

	}

