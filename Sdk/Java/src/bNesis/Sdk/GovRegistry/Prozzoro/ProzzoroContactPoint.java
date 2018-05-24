package bNesis.Sdk.GovRegistry.Prozzoro;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of ContactPoint. 
 * @typedef {Object} ProzzoroContactPoint
 */
public class ProzzoroContactPoint
{
	public ProzzoroContactPoint(){}
	/**
	 * The telephone number of the contact point/person
	 * @type {String}
	 */
	public String telephone;

	/**
	 * The fax number of the contact point/person.
	 * @type {String}
	 */
	public String faxNumber;

	/**
	 * The name of the contact person, department, or contact point, for correspondence relating to this contracting process.
	 * @type {String}
	 */
	public String name;

	/**
	 * The e-mail address of person.
	 * @type {String}
	 */
	public String email;

	/**
	 * A web address for the contact point/person.
	 * @type {String}
	 */
	public String url;

	}

