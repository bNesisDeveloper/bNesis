package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * The IDs that apps owned by the business know the user as
 *     https://developers.facebook.com/docs/graph-api/reference/user/ids_for_business/ 
 * @typedef {Object} FacebookUserIDsForBusiness
 */
public class FacebookUserIDsForBusiness
{
	public FacebookUserIDsForBusiness(){}
	/**
	 * A list of UserIDForApp nodes.
	 * @type {FacebookUserIdForApp[]}
	 */
	public FacebookUserIdForApp[] data;

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

