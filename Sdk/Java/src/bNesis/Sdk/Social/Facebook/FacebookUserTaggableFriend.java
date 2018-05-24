package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Taggable friend of current user
 *     https://developers.facebook.com/docs/graph-api/reference/user-taggable-friend/ 
 * @typedef {Object} FacebookUserTaggableFriend
 */
public class FacebookUserTaggableFriend
{
	public FacebookUserTaggableFriend(){}
	/**
	 * First name
	 * @type {String}
	 */
	public String first_name;

	/**
	 * ID
	 * @type {String}
	 */
	public String id;

	/**
	 * Last name
	 * @type {String}
	 */
	public String last_name;

	/**
	 * Middle name
	 * @type {String}
	 */
	public String middle_name;

	/**
	 * Name
	 * @type {String}
	 */
	public String name;

	/**
	 * Profile picture link
	 * @type {FacebookUserTaggableFriendPicture}
	 */
	public FacebookUserTaggableFriendPicture picture;

	}

