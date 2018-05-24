package bNesis.Sdk.Social.GooglePlus;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of GooglePlusEmails. 
 * @typedef {Object} GooglePlusEmail
 */
public class GooglePlusEmail
{
	public GooglePlusEmail(){}
	/**
	 * The email address.
	 * @type {String}
	 */
	public String value;

	/**
	 * The type address.
	 *   Possible values are:
	 *   account - Google account email address.
	 *   home - Home email address.
	 *   work - Work email address.
	 *   other - Other.
	 * @type {String}
	 */
	public String type;

	}

