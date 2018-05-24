package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * A list of rich media documents belonging to Pages that the user has advertiser permissions on
 *     https://developers.facebook.com/docs/graph-api/reference/user/rich_media_documents/ 
 * @typedef {Object} FacebookUserRichMediaDocuments
 */
public class FacebookUserRichMediaDocuments
{
	public FacebookUserRichMediaDocuments(){}
	/**
	 * A list of Canvas nodes.
	 * @type {FacebookCanvas[]}
	 */
	public FacebookCanvas[] data;

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

