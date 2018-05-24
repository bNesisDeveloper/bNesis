package bNesis.Sdk.Social.VKontakte;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * information about user's career. 
 * @typedef {Object} VKontakteCareer
 */
public class VKontakteCareer
{
	public VKontakteCareer(){}
	/**
	 * community ID(if available, otherwise company)
	 * @type {String}
	 */
	public String group_id;

	/**
	 * company name(if available, otherwise group_id)
	 * @type {String}
	 */
	public String company;

	/**
	 * country ID
	 * @type {String}
	 */
	public String country_id;

	/**
	 * city ID(if available, otherwise city_name)
	 * @type {String}
	 */
	public String city_id;

	/**
	 * city name(if available, otherwise city_id)
	 * @type {String}
	 */
	public String city_name;

	/**
	 * career beginning year
	 * @type {String}
	 */
	public String from;

	/**
	 * career ending year
	 * @type {String}
	 */
	public String until;

	/**
	 * position
	 * @type {String}
	 */
	public String position;

	}

