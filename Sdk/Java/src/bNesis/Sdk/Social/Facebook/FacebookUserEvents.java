package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Events for this person. By default this does not include events the person has declined or not replied to
 *     https://developers.facebook.com/docs/graph-api/reference/user/events/
 *     Permissions
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     No data
 *     Page management Apps
 *     manage_pages
 *     pages_show_list
 *     user_events
 *     Other Apps
 *     user_events 
 * @typedef {Object} FacebookUserEvents
 */
public class FacebookUserEvents
{
	public FacebookUserEvents(){}
	/**
	 * A list of Event nodes.
	 * @type {FacebookEvent[]}
	 */
	public FacebookEvent[] data;

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

