package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


public class FacebookEducationExperience
{
	public FacebookEducationExperience(){}
	/**
	 * numeric string
	 * @type {String}
	 */
	public String id;

	/**
	 * Classes taken
	 * @type {FacebookExperience}
	 */
	public FacebookExperience classes;

	/**
	 * Facebook Pages representing subjects studied
	 * @type {FacebookPage[]}
	 */
	public FacebookPage[] concentration;

	/**
	 * The Facebook Page for the degree obtained
	 * @type {FacebookPage}
	 */
	public FacebookPage degree;

	/**
	 * The Facebook Page for this school
	 * @type {FacebookPage}
	 */
	public FacebookPage school;

	/**
	 * The type of educational institution
	 * @type {String}
	 */
	public String type;

	/**
	 * People tagged who went to school with this person
	 * @type {FacebookUser[]}
	 */
	public FacebookUser[] with;

	/**
	 * Facebook Page for the year this person graduated
	 * @type {FacebookPage}
	 */
	public FacebookPage year;

	}

