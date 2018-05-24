package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Albums for a Facebook User
 *     https://developers.facebook.com/docs/graph-api/reference/user/albums/ 
 * @typedef {Object} FacebookUserAlbums
 */
public class FacebookUserAlbums
{
	public FacebookUserAlbums(){}
	/**
	 * A list of Album nodes
	 * @type {FacebookAlbum[]}
	 */
	public FacebookAlbum[] data;

	/**
	 * For more details about pagination, see the Graph API guide
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

