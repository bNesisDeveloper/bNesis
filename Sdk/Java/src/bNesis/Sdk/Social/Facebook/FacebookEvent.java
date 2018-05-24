package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Represents a Facebook event. The /{event-id} node returns a single event.
 *     https://developers.facebook.com/docs/graph-api/reference/event/
 *     Permissions
 *     Any access token can be used to retrieve events with privacy set to OPEN.
 *     A user access token with user_events permission can be used to retrieve any events that are visible to that person.
 *     An app or page token can be used to retrieve any events that were created by that app or page.
 *     Login Review: user_events
 *     To use the user_events permission you need to submit your app for review. 
 * @typedef {Object} FacebookEvent
 */
public class FacebookEvent
{
	public FacebookEvent(){}
	/**
	 * The event ID
	 * @type {String}
	 */
	public String id;

	/**
	 * The category of the event
	 * @type {String}
	 */
	public String category;

	/**
	 * Long-form description
	 * @type {String}
	 */
	public String description;

	/**
	 * Event name
	 * @type {String}
	 */
	public String name;

	/**
	 * Event Place information.
	 * @type {FacebookPlace}
	 */
	public FacebookPlace place;

	/**
	 * Start time
	 * @type {String}
	 */
	public String start_time;

	/**
	 * Gets or sets the RSVP status.
	 * @type {String}
	 */
	public String rsvp_status;

	}

