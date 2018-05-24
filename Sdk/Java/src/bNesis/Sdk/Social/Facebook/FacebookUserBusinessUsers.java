package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Get business users that a personal user has.
 *     https://developers.facebook.com/docs/graph-api/reference/user/business_users/ 
 * @typedef {Object} FacebookUserBusinessUsers
 */
public class FacebookUserBusinessUsers
{
	public FacebookUserBusinessUsers(){}
	/**
	 * A list of BusinessUser nodes.
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

