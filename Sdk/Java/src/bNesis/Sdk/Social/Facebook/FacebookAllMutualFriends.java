package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * All friends that the viewer and the target person have in common. This includes the friends who do not use your app
 *     Returns a list of all the Facebook friends that the session user and the request user have in common.This includes friends who use the app as well as non-app-using mutual friends. 
 * @typedef {Object} FacebookAllMutualFriends
 */
public class FacebookAllMutualFriends
{
	public FacebookAllMutualFriends(){}
	/**
	 * A list of User nodes.
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

