package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Games a person likes.
 *     https://developers.facebook.com/docs/graph-api/reference/user/games/
 *     Permission 
 *     user_likes 
 * @typedef {Object} FacebookUserGames
 */
public class FacebookUserGames
{
	public FacebookUserGames(){}
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

