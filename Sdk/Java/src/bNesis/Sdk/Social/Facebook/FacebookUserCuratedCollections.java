package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * The curated collections created by this user.
 *     https://developers.facebook.com/docs/graph-api/reference/user/curated_collections/ 
 * @typedef {Object} FacebookUserCuratedCollections
 */
public class FacebookUserCuratedCollections
{
	public FacebookUserCuratedCollections(){}
	/**
	 * A list of CuratedCollection nodes.
	 * @type {FacebookPage[]}
	 */
	public FacebookPage[] data;

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

