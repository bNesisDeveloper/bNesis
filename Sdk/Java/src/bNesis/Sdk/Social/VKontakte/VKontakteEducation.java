package bNesis.Sdk.Social.VKontakte;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Information about user's higher education institution. 
 * @typedef {Object} VKontakteEducation
 */
public class VKontakteEducation
{
	public VKontakteEducation(){}
	/**
	 * university ID
	 * @type {String}
	 */
	public String university;

	/**
	 * university name
	 * @type {String}
	 */
	public String university_name;

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
	 * graduation year
	 * @type {String}
	 */
	public String graduation;

	}

