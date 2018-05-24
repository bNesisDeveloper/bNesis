package bNesis.Sdk.Social.VKontakte;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Information about user's phone numbers. 
 * @typedef {Object} VKontakteContacts
 */
public class VKontakteContacts
{
	public VKontakteContacts(){}
	/**
	 * user's mobile phone number (only for standalone applications)
	 * @type {String}
	 */
	public String mobile_phone;

	/**
	 * user's additional phone number
	 * @type {String}
	 */
	public String home_phone;

	}

