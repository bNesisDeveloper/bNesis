package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Any session keys that the app knows the user by
 *     https://developers.facebook.com/docs/graph-api/reference/user/session_keys/ 
 * @typedef {Object} FacebookUserSessionKeys
 */
public class FacebookUserSessionKeys
{
	public FacebookUserSessionKeys(){}
	/**
	 * A list of PlatformSessionKey nodes.
	 * @type {FacebookPage[]}
	 */
	public FacebookPage[] data;

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

