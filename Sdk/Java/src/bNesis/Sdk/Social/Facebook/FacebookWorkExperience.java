package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Information about a user's work 
 * @typedef {Object} FacebookWorkExperience
 */
public class FacebookWorkExperience
{
	public FacebookWorkExperience(){}
	/**
	 * Identifier
	 * @type {String}
	 */
	public String id;

	/**
	 * Description
	 * @type {String}
	 */
	public String description;

	/**
	 * Employer
	 * @type {FacebookPage}
	 */
	public FacebookPage employer;

	/**
	 * End date
	 * @type {String}
	 */
	public String end_date;

	/**
	 * Tagged by
	 * @type {String}
	 */
	public String from;

	/**
	 * Location
	 * @type {FacebookPage}
	 */
	public FacebookPage location;

	/**
	 * Position
	 * @type {FacebookPage}
	 */
	public FacebookPage position;

	/**
	 * Projects
	 * @type {FacebookPrjectExperience[]}
	 */
	public FacebookPrjectExperience[] projects;

	/**
	 * Start date
	 * @type {String}
	 */
	public String start_date;

	/**
	 * Tagged users
	 * @type {FacebookUser[]}
	 */
	public FacebookUser[] with;

	}

