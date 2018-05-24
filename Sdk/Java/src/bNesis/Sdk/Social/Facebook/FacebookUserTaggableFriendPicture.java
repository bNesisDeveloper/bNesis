package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Profile picture link
 *     https://developers.facebook.com/docs/graph-api/reference/user-taggable-friend/picture/ 
 * @typedef {Object} FacebookUserTaggableFriendPicture
 */
public class FacebookUserTaggableFriendPicture
{
	public FacebookUserTaggableFriendPicture(){}
	/**
	 * A single ProfilePictureSource node.
	 * @type {FacebookProfilePictureSource}
	 */
	public FacebookProfilePictureSource data;

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

