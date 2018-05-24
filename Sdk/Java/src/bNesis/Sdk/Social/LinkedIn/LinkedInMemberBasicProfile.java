package bNesis.Sdk.Social.LinkedIn;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of BasicProfile. 
 *     Contains information of member LinkedIn. 
 * @typedef {Object} LinkedInMemberBasicProfile
 */
public class LinkedInMemberBasicProfile
{
	public LinkedInMemberBasicProfile(){}
	/**
	 * The member contact e-mail.
	 * @type {String}
	 */
	public String emailAddress;

	/**
	 * The member first name.
	 * @type {String}
	 */
	public String firstName;

	/**
	 * The member formated name.
	 * @type {String}
	 */
	public String formattedName;

	/**
	 * The member last name.
	 * @type {String}
	 */
	public String headline;

	/**
	 * The member identifier.
	 * @type {String}
	 */
	public String id;

	/**
	 * The industry the member belongs to.
	 * @type {String}
	 */
	public String industry;

	/**
	 * The member last name.
	 * @type {String}
	 */
	public String lastName;

	/**
	 * Contains information about member location.
	 * @type {LinkedInLocation}
	 */
	public LinkedInLocation location;

	/**
	 * The number of connections to LinkedIn.
	 * @type {Integer}
	 */
	public Integer numConnections;

	/**
	 * If true, the member has count connections capped.
	 * @type {Boolean}
	 */
	public Boolean numConnectionsCapped;

	/**
	 * The picture url.
	 * @type {String}
	 */
	public String pictureUrl;

	/**
	 * Represents member current position.
	 * @type {LinkedInPositions}
	 */
	public LinkedInPositions positions;

	/**
	 * The member public profile url.
	 * @type {String}
	 */
	public String publicProfileUrl;

	/**
	 * The member site standart profile request.
	 * @type {LinkedInSiteStandardProfileRequest}
	 */
	public LinkedInSiteStandardProfileRequest siteStandardProfileRequest;

	}

