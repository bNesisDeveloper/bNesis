package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Information about a project experience 
 * @typedef {Object} FacebookPrjectExperience
 */
public class FacebookPrjectExperience
{
	public FacebookPrjectExperience(){}
	/**
	 * ID
	 * @type {String}
	 */
	public String id;

	/**
	 * Description.
	 * @type {String}
	 */
	public String description;

	/**
	 * End date
	 * @type {String}
	 */
	public String end_date;

	/**
	 * From
	 * @type {FacebookUser}
	 */
	public FacebookUser from;

	/**
	 * Name
	 * @type {String}
	 */
	public String name;

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

