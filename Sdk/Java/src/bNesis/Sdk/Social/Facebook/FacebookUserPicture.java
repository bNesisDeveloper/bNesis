package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * A Picture for a Facebook User.
 *     https://developers.facebook.com/docs/graph-api/reference/user/picture/ 
 * @typedef {Object} FacebookUserPicture
 */
public class FacebookUserPicture
{
	public FacebookUserPicture(){}
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

