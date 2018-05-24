package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Friends of the viewer who are mutual friends with the target and have the app installed. 
 * @typedef {Object} FacebookthreeDegreeMutualFriends
 */
public class FacebookthreeDegreeMutualFriends
{
	public FacebookthreeDegreeMutualFriends(){}
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

	}

