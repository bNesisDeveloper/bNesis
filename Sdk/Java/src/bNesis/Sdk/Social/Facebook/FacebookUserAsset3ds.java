package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * The 3D assets owned by this user.
 *     https://developers.facebook.com/docs/graph-api/reference/user/asset3ds/ 
 * @typedef {Object} FacebookUserAsset3ds
 */
public class FacebookUserAsset3ds
{
	public FacebookUserAsset3ds(){}
	/**
	 * A list of WithAsset3D nodes.
	 * @type {FacebookWithAsset3D[]}
	 */
	public FacebookWithAsset3D[] data;

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

