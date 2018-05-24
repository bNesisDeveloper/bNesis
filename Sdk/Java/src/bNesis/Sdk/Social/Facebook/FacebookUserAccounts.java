package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Accounts for a Facebook User. 
 *     Pages this User has a role on.
 *      https://developers.facebook.com/docs/graph-api/reference/user/accounts/
 *      A Page access token for a User with a role (other than Live Contributor) on the Page and the following permissions:
 *      manage_pages or pages_show_list 
 * @typedef {Object} FacebookUserAccounts
 */
public class FacebookUserAccounts
{
	public FacebookUserAccounts(){}
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

