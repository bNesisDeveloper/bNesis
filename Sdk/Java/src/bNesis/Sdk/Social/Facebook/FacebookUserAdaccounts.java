package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * The advertising accounts to which this person has access.
 *      Developers usually request these permissions for this endpoint:
 *      Marketing Apps ads_management. 
 * @typedef {Object} FacebookUserAdaccounts
 */
public class FacebookUserAdaccounts
{
	public FacebookUserAdaccounts(){}
	/**
	 * A list of AdAccount nodes.
	 * @type {FacebookAdAccount[]}
	 */
	public FacebookAdAccount[] data;

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

