package bNesis.Sdk.Social.VKontakte;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * List of higher education institutions where user studied. 
 * @typedef {Object} VKontakteUniversities
 */
public class VKontakteUniversities
{
	public VKontakteUniversities(){}
	/**
	 * university ID
	 * @type {String}
	 */
	public String id;

	/**
	 * ID of the country the university is located in
	 * @type {String}
	 */
	public String country;

	/**
	 * ID of the city the university is located in
	 * @type {String}
	 */
	public String city;

	/**
	 * university name
	 * @type {String}
	 */
	public String name;

	/**
	 * faculty ID
	 * @type {String}
	 */
	public String faculty;

	/**
	 * faculty name
	 * @type {String}
	 */
	public String faculty_name;

	/**
	 * university chair ID
	 * @type {String}
	 */
	public String chair;

	/**
	 * chair name
	 * @type {String}
	 */
	public String chair_name;

	/**
	 * graduation year
	 * @type {String}
	 */
	public String graduation;

	/**
	 * education form
	 * @type {String}
	 */
	public String education_form;

	/**
	 * status
	 * @type {String}
	 */
	public String education_status;

	}

