package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Social context edge providing a list of Facebook friends that have logged into the app that the viewer and the target person have in common 
 * @typedef {Object} FacebookMutualFriends
 */
public class FacebookMutualFriends
{
	public FacebookMutualFriends(){}
	/**
	 * A list of User nodes.
	 * @type {FacebookPage[]}
	 */
	public FacebookPage[] data;

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	/**
	 * Aggregated information about the edge, such as counts.
	 * @type {FacebookSummary}
	 */
	public FacebookSummary summary;

	}

