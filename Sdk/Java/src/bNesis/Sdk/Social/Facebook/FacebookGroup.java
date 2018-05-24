package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * A Group.
 *     Returns information about a single Group object. To get a list of Groups a User belongs to, use the /user/groups edge instead.
 *     Permissions
 *     For Public and Closed Groups
 *     A User access token.
 *     For Secret Groups
 *     A User access token for an Admin of the Group with the following permissions:
 *     user_managed_groups 
 * @typedef {Object} FacebookGroup
 */
public class FacebookGroup
{
	public FacebookGroup(){}
	/**
	 * The group ID
	 * @type {String}
	 */
	public String id;

	/**
	 * Information about the group's cover photo.
	 * @type {FacebookCoverPhoto}
	 */
	public FacebookCoverPhoto cover;

	/**
	 * A brief description of the group.
	 * @type {String}
	 */
	public String description;

	/**
	 * The email address to upload content to the group. Only current members of the group can use this.
	 * @type {String}
	 */
	public String email;

	}

