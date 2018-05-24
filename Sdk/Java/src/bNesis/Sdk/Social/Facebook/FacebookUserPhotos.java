package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Photos for a person.
 *     https://developers.facebook.com/docs/graph-api/reference/user/photos/
 *     Permissions
 *     Any valid access token for any photo with public privacy settings.
 *     For any photos uploaded by someone, and any photos in which they have been tagged - A user access token for that person with user_photos permission. 
 * @typedef {Object} FacebookUserPhotos
 */
public class FacebookUserPhotos
{
	public FacebookUserPhotos(){}
	/**
	 * A list of Photo nodes.
	 * @type {FacebookPhoto[]}
	 */
	public FacebookPhoto[] data;

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

