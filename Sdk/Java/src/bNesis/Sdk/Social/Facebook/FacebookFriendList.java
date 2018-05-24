package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * This represents a user's friend list on Facebook
 *     https://developers.facebook.com/docs/graph-api/reference/friend-list/
 *     Permissions
 *     A user access token with read_custom_friendlists permission is required. 
 * @typedef {Object} FacebookFriendList
 */
public class FacebookFriendList
{
	public FacebookFriendList(){}
	/**
	 * The friend list ID
	 * @type {String}
	 */
	public String id;

	/**
	 * The type of the friend list
	 * @type {String}
	 */
	public String list_type;

	/**
	 * The name of the friend list
	 * @type {String}
	 */
	public String name;

	/**
	 * The owner of the friend list
	 * @type {String}
	 */
	public String owner;

	}

