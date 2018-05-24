package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Open graph actions taken by the user 
 * @typedef {Object} FacebookUserAchievements
 */
public class FacebookUserAchievements
{
	public FacebookUserAchievements(){}
	/**
	 * A list of OpenGraphAction:generic nodes.
	 * @type {FacebookOGOGeneric[]}
	 */
	public FacebookOGOGeneric[] data;

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

