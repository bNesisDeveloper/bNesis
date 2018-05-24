package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Developers' favorite requests to the Graph API
 *     https://developers.facebook.com/docs/graph-api/reference/user/favorite_requests/ 
 * @typedef {Object} FacebookUserFavoriteRequests
 */
public class FacebookUserFavoriteRequests
{
	public FacebookUserFavoriteRequests(){}
	/**
	 * A list of FavoriteRequest nodes.
	 * @type {FacebookPage[]}
	 */
	public FacebookPage[] data;

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

