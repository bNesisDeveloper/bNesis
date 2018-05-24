package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * An experience 
 * @typedef {Object} FacebookExperience
 */
public class FacebookExperience
{
	public FacebookExperience(){}
	/**
	 * ID
	 * @type {String}
	 */
	public String id;

	/**
	 * Description
	 * @type {String}
	 */
	public String description;

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
	 * Tagged users
	 * @type {FacebookUser[]}
	 */
	public FacebookUser[] with;

	}

