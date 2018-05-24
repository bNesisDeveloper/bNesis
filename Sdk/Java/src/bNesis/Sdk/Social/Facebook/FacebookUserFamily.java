package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * A person's family relationships.
 *     https://developers.facebook.com/docs/graph-api/reference/user/family 
 * @typedef {Object} FacebookUserFamily
 */
public class FacebookUserFamily
{
	public FacebookUserFamily(){}
	/**
	 * A list of User nodes.
	 * @type {FacebookUser[]}
	 */
	public FacebookUser[] data;

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

