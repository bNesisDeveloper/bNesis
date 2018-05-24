package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * A canvas document.
 *     https://developers.facebook.com/docs/graph-api/reference/canvas/ 
 * @typedef {Object} FacebookCanvas
 */
public class FacebookCanvas
{
	public FacebookCanvas(){}
	/**
	 * Gets or sets the identifier.
	 * @type {String}
	 */
	public String id;

	/**
	 * The canvas link for the canvas
	 * @type {String}
	 */
	public String canvas_link;

	/**
	 * The canvas is hidden or not
	 * @type {String}
	 */
	public String is_hidden;

	/**
	 * Publish status of the canvas
	 * @type {String}
	 */
	public String is_published;

	/**
	 * User who last edited this canvas
	 * @type {FacebookUser}
	 */
	public FacebookUser last_editor;

	/**
	 * Name used to label the canvas
	 * @type {String}
	 */
	public String name;

	/**
	 * Page that owns this canvas
	 * @type {FacebookPage}
	 */
	public FacebookPage owner;

	/**
	 * Last updated time of the canvas
	 * @type {Integer}
	 */
	public Integer update_time;

	}

