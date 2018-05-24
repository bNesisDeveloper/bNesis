package bNesis.Sdk.Social.GooglePlus;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of GooglePlusName. 
 * @typedef {Object} GooglePlusName
 */
public class GooglePlusName
{
	public GooglePlusName(){}
	/**
	 * The full name of person.
	 * @type {String}
	 */
	public String formatted;

	/**
	 * The family(last) name of person.
	 * @type {String}
	 */
	public String familyName;

	/**
	 * The given(first) name of person.
	 * @type {String}
	 */
	public String givenName;

	/**
	 * The middle name of person.
	 * @type {String}
	 */
	public String middleName;

	/**
	 * The honorific prefixes (such as "Dr." or "Mrs.") for person.
	 * @type {String}
	 */
	public String honorificPrefix;

	/**
	 * The honorific suffixes (such as "Jr.") for person.
	 * @type {String}
	 */
	public String honorificSuffix;

	}

