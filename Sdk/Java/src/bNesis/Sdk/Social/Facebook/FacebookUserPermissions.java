package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Returns a list of granted and declined permissions.
 *     https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 
 * @typedef {Object} FacebookUserPermissions
 */
public class FacebookUserPermissions
{
	public FacebookUserPermissions(){}
	/**
	 * A list of Permission nodes.
	 * @type {FacebookPermission[]}
	 */
	public FacebookPermission[] data;

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

