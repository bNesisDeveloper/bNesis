package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * An Open Graph object
 *     https://developers.facebook.com/docs/graph-api/reference/open-graph-object--generic/ 
 * @typedef {Object} FacebookOGOGeneric
 */
public class FacebookOGOGeneric
{
	public FacebookOGOGeneric(){}
	/**
	 * The Open Graph object ID
	 * @type {String}
	 */
	public String id;

	/**
	 * The time the object was created
	 * @type {Date}
	 */
	public Date created_time;

	/**
	 * A short description of the object
	 * @type {String}
	 */
	public String description;

	/**
	 * The word that appears before the object's title
	 * @type {String}
	 */
	public String determiner;

	/**
	 * Whether the object has been scraped
	 * Type: bool
	 * @type {String}
	 */
	public String is_scraped;

	/**
	 * The location inherited from Place
	 * @type {FacebookLocation}
	 */
	public FacebookLocation location;

	/**
	 * The action ID that created this object
	 * @type {String}
	 */
	public String post_action_id;

	/**
	 * An array of URLs of related resources
	 * @type {String[]}
	 */
	public String[] see_also;

	/**
	 * The name of the web site upon which the object resides
	 * @type {String}
	 */
	public String site_name;

	/**
	 * The title of the object as it should appear in the graph
	 * @type {String}
	 */
	public String title;

	/**
	 * The type of the object
	 * @type {String}
	 */
	public String type;

	/**
	 * The last time the object was updated
	 * @type {Date}
	 */
	public Date updated_time;

	}

