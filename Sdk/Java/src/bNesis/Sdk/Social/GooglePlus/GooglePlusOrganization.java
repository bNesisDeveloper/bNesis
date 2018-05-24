package bNesis.Sdk.Social.GooglePlus;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of GooglePlusOrganization. 
 * @typedef {Object} GooglePlusOrganization
 */
public class GooglePlusOrganization
{
	public GooglePlusOrganization(){}
	/**
	 * The organization name.
	 * @type {String}
	 */
	public String name;

	/**
	 * The department within the organization.
	 * @type {String}
	 */
	public String department;

	/**
	 * The person's job title or role of this organization.
	 * @type {String}
	 */
	public String title;

	/**
	 * The type of organization.
	 *  Possible values are:
	 *   work - Work.
	 *   school - School.
	 * @type {String}
	 */
	public String type;

	/**
	 * The date that the person joined this organization.
	 * @type {String}
	 */
	public String startDate;

	/**
	 * The date that the person left this organization.
	 * @type {String}
	 */
	public String endDate;

	/**
	 * The location of this organization.
	 * @type {String}
	 */
	public String location;

	/**
	 * The short description of the person's role of this organization.
	 * @type {String}
	 */
	public String description;

	/**
	 * If true this organization is the current one.
	 * @type {Boolean}
	 */
	public Boolean primary;

	}

