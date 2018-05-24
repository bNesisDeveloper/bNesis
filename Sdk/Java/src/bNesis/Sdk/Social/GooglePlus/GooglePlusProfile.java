package bNesis.Sdk.Social.GooglePlus;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of GooglePlusProfile. 
 * @typedef {Object} GooglePlusProfile
 */
public class GooglePlusProfile
{
	public GooglePlusProfile(){}
	/**
	 * Identifies this resource.
	 * @type {String}
	 */
	public String kind;

	/**
	 * The identifier of this profile.
	 * @type {String}
	 */
	public String id;

	/**
	 * ETag of this profile.
	 * @type {String}
	 */
	public String etag;

	/**
	 * The nickname of this profile.
	 * @type {String}
	 */
	public String nickname;

	/**
	 * The occupation of this profile.
	 * @type {String}
	 */
	public String occupation;

	/**
	 * The person's skills.
	 * @type {String}
	 */
	public String skills;

	/**
	 * The person's date of birth. (Format: YYYY-MM-DD)
	 * @type {String}
	 */
	public String birthday;

	/**
	 * The person's gender.
	 *   Possible values are:
	 *   male - Male gender.
	 *   female - Female gender.
	 *   other - Other.
	 * @type {String}
	 */
	public String gender;

	/**
	 * The array of email which has in this profile.
	 * @type {GooglePlusEmail[]}
	 */
	public GooglePlusEmail[] emails;

	/**
	 * The array of url which has in this profile.
	 * @type {GooglePlusUrl[]}
	 */
	public GooglePlusUrl[] urls;

	/**
	 * The type of this profile .
	 *   Possible values are:
	 *   person - represents an actual person.
	 *   page - represents a page.
	 * @type {String}
	 */
	public String objectType;

	/**
	 * The person name, which is displayed.
	 * @type {String}
	 */
	public String displayName;

	/**
	 * An object representation of the individual components of a person's name.
	 * @type {GooglePlusName}
	 */
	public GooglePlusName name;

	/**
	 * The brief description (tagline) in this profile.
	 * @type {String}
	 */
	public String tagline;

	/**
	 * The "bragging rights" line in this profile.
	 * @type {String}
	 */
	public String braggingRights;

	/**
	 * A short biography.
	 * @type {String}
	 */
	public String aboutMe;

	/**
	 * The person's relationship status.
	 *   Possible values are:
	 *   single - Person is single.
	 *   in_a_relationship - Person is in a relationship.
	 *   engaged - Person is engaged.
	 *   married - Person is married.
	 *   See also: https://developers.google.com/+/web/api/rest/latest/people#relationshipStatus
	 * @type {String}
	 */
	public String relationshipStatus;

	/**
	 * The url to person's profile.
	 * @type {String}
	 */
	public String url;

	/**
	 * The representation of person's profile photo.
	 * @type {GooglePlusImage}
	 */
	public GooglePlusImage image;

	/**
	 * The array of orgainzation with which person is associated.
	 * @type {GooglePlusOrganization[]}
	 */
	public GooglePlusOrganization[] organizations;

	/**
	 * The array of place where person is lived.
	 * @type {GooglePlusPlaceLived[]}
	 */
	public GooglePlusPlaceLived[] placesLived;

	/**
	 * Whether this user has signed up for Google+.
	 * @type {Boolean}
	 */
	public Boolean isPlusUser;

	/**
	 * The person's preferred language.
	 * @type {String}
	 */
	public String language;

	/**
	 * The age range of the person.
	 * @type {GooglePlusAgeRange}
	 */
	public GooglePlusAgeRange ageRange;

	/**
	 * If a Google+ Page, the number of people who have +1'd this page.
	 * @type {Integer}
	 */
	public Integer plusOneCount;

	/**
	 * Followers who are visible, the number of people who have added this person or page to a circle.
	 * @type {Integer}
	 */
	public Integer circledByCount;

	/**
	 * Whether the person or Google+ Page has been verified. This is used only for pages with a higher risk of being impersonated or similar.
	 *   This flag will not be present on most profiles, so is can be null.
	 * @type {Boolean}
	 */
	public Boolean verified;

	/**
	 * The cover photo content.
	 * @type {GooglePlusCover}
	 */
	public GooglePlusCover cover;

	/**
	 * The hosted domain name for the user's Google Apps account.
	 * @type {String}
	 */
	public String domain;

	}

