package bNesis.Sdk.Social.LinkedIn;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of Visibility. 
 * @typedef {Object} LinkedInVisibility
 */
public class LinkedInVisibility
{
	public LinkedInVisibility(){}
	/**
	 * A collection of visibility information about the share..
	 *  Possible values are:
	 *  anyone:  Share will be visible to all members.
	 *  connections-only:  Share will only be visible to connections of the member performing the share.
	 * @type {String}
	 */
	public String code;

	}

