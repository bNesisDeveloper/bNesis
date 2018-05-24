package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * This person's pending requests from an app 
 *      https://developers.facebook.com/docs/graph-api/reference/user/apprequests/ 
 * @typedef {Object} FacebookUserApprequests
 */
public class FacebookUserApprequests
{
	public FacebookUserApprequests(){}
	/**
	 * A list of AppRequest nodes.
	 * @type {FacebookAppRequest[]}
	 */
	public FacebookAppRequest[] data;

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

