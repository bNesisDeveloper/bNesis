package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * The domains the user admins
 *     https://developers.facebook.com/docs/graph-api/reference/user/domains/ 
 * @typedef {Object} FacebookUserDomains
 */
public class FacebookUserDomains
{
	public FacebookUserDomains(){}
	/**
	 * A list of Domain nodes.
	 * @type {FacebookDomain[]}
	 */
	public FacebookDomain[] data;

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

