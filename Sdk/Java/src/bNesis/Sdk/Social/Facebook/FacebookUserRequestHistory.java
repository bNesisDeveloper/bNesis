package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Developers' Graph API request history
 *     https://developers.facebook.com/docs/graph-api/reference/user/request_history/ 
 * @typedef {Object} FacebookUserRequestHistory
 */
public class FacebookUserRequestHistory
{
	public FacebookUserRequestHistory(){}
	/**
	 * A list of RequestHistory nodes.
	 * @type {FacebookRequestHistory[]}
	 */
	public FacebookRequestHistory[] data;

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

