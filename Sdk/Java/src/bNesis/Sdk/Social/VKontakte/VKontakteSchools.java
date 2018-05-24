package bNesis.Sdk.Social.VKontakte;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * List of schools where user studied. 
 * @typedef {Object} VKontakteSchools
 */
public class VKontakteSchools
{
	public VKontakteSchools(){}
	/**
	 * school ID
	 * @type {String}
	 */
	public String id;

	/**
	 * ID of the country the school is located in
	 * @type {String}
	 */
	public String country;

	/**
	 * ID of the city the school is located in
	 * @type {String}
	 */
	public String city;

	/**
	 * school name
	 * @type {String}
	 */
	public String name;

	/**
	 * year the user started to study
	 * @type {String}
	 */
	public String year_from;

	/**
	 * year the user finished to study
	 * @type {String}
	 */
	public String year_to;

	/**
	 * graduation year
	 * @type {String}
	 */
	public String year_graduated;

	/**
	 * school class letter
	 * @type {String}
	 */
	public String class_;

	/**
	 * speciality
	 * @type {String}
	 */
	public String speciality;

	/**
	 * type ID
	 * @type {String}
	 */
	public String type;

	/**
	 * type name. Possible values for pairs type-typeStr: 
	 * 0 — "school";
	 * 1 — "gymnasium";
	 * 2 —"lyceum";
	 * 3 — "boarding school";
	 * 4 — "evening school";
	 * 5 — "music school";
	 * 6 — "sport school";
	 * 7 — "artistic school";
	 * 8 — "college";
	 * 9 — "professional lyceum";
	 * 10 — "technical college";
	 * 11 — "vocational";
	 * 12 — "specialized school";
	 * 13 — "art school".
	 * @type {String}
	 */
	public String type_str;

	}

