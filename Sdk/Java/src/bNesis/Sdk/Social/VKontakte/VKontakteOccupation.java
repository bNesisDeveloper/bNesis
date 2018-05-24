package bNesis.Sdk.Social.VKontakte;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * User's occupation. 
 * @typedef {Object} VKontakteOccupation
 */
public class VKontakteOccupation
{
	public VKontakteOccupation(){}
	/**
	 * type. Possible values: work, school, university
	 * @type {String}
	 */
	public String type;

	/**
	 * ID of school, university, company group (the one a user works in)
	 * @type {String}
	 */
	public String id;

	/**
	 * name of school, university or work place
	 * @type {String}
	 */
	public String name;

	}

