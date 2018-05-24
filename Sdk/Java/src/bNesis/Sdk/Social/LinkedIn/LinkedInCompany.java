package bNesis.Sdk.Social.LinkedIn;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of Company. 
 * @typedef {Object} LinkedInCompany
 */
public class LinkedInCompany
{
	public LinkedInCompany(){}
	/**
	 * The company identifier.
	 * @type {Integer}
	 */
	public Integer id;

	/**
	 * The company industry name.
	 * @type {String}
	 */
	public String industry;

	/**
	 * The company name.
	 * @type {String}
	 */
	public String name;

	/**
	 * The company size.
	 * @type {String}
	 */
	public String size;

	/**
	 * The company type.
	 * @type {String}
	 */
	public String type;

	}

