package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * A lift study object
 *     https://developers.facebook.com/docs/marketing-api/reference/ad-study/ 
 * @typedef {Object} FacebookAdStudy
 */
public class FacebookAdStudy
{
	public FacebookAdStudy(){}
	/**
	 * Time stamp when study was canceled
	 * @type {Date}
	 */
	public Date canceled_time;

	/**
	 * Who Lift study was created by
	 * @type {FacebookUser}
	 */
	public FacebookUser created_by;

	/**
	 * The time the object was created
	 * @type {Date}
	 */
	public Date created_time;

	/**
	 * Description
	 * @type {String}
	 */
	public String description;

	/**
	 * End time
	 * @type {Date}
	 */
	public Date end_time;

	/**
	 * ID of the Lift study
	 * @type {String}
	 */
	public String id;

	/**
	 * Cooldown start time
	 * @type {Date}
	 */
	public Date cooldown_start_time;

	/**
	 * Name of the Lift study
	 * @type {String}
	 */
	public String name;

	/**
	 * Observation end time
	 * @type {Date}
	 */
	public Date observation_end_time;

	/**
	 * Start time
	 * @type {Date}
	 */
	public Date start_time;

	/**
	 * The type of study, either audience segmentation or lift
	 * @type {String}
	 */
	public String type;

	/**
	 * Updated by
	 * @type {FacebookUser}
	 */
	public FacebookUser updated_by;

	/**
	 * Updated time
	 * @type {Date}
	 */
	public Date updated_time;

	}

