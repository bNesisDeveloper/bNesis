package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * A permission requested from a user by an application
 *     https://developers.facebook.com/docs/graph-api/reference/permission/ 
 * @typedef {Object} FacebookPermission
 */
public class FacebookPermission
{
	public FacebookPermission(){}
	/**
	 * Name of the permission
	 * @type {String}
	 */
	public String permission;

	/**
	 * Permission status
	 * @type {String}
	 */
	public String status;

	}

