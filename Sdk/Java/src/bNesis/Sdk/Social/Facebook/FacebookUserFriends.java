package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * This edge allows you to:
 *     get the User's friends who have installed the app making the query
 *     get the User's total number of friends (including those who have not installed the app making the query)
 *     The person's friends 
 * @typedef {Object} FacebookUserFriends
 */
public class FacebookUserFriends
{
	public FacebookUserFriends(){}
	/**
	 * A list of User nodes.
	 * @type {FacebookUser[]}
	 */
	public FacebookUser[] data;

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	/**
	 * Aggregated information about the edge, such as counts. 
	 * Specify the fields to fetch in the summary param (like summary=total_count).
	 * @type {FacebookSummary}
	 */
	public FacebookSummary summary;

	}

