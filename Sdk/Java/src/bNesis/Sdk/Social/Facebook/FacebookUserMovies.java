package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Movies this person likes
 *     https://developers.facebook.com/docs/graph-api/reference/user/movies/
 *     Permissions
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     ads_management
 *     manage_pages
 *     pages_show_list
 *     user_likes
 *     Page management Apps
 *     No data
 *     Other Apps
 *     user_likes 
 * @typedef {Object} FacebookUserMovies
 */
public class FacebookUserMovies
{
	public FacebookUserMovies(){}
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

