package bNesis.Sdk.Social.LinkedIn;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of Company. 
 * @typedef {Object} LinkedInCompanyInfo
 */
public class LinkedInCompanyInfo
{
	public LinkedInCompanyInfo(){}
	/**
	 * The company.
	 * @type {LinkedInCompany}
	 */
	public LinkedInCompany company;

	/**
	 * The identifier of company info.
	 * @type {Integer}
	 */
	public Integer id;

	/**
	 * The member is now at this company.
	 * @type {Boolean}
	 */
	public Boolean isCurrent;

	/**
	 * Company location.
	 * @type {LinkedInLocation}
	 */
	public LinkedInLocation location;

	/**
	 * The title.
	 * @type {String}
	 */
	public String title;

	}

