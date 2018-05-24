package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Information about users that received app requests from the viewer in the past
 *     https://developers.facebook.com/docs/graph-api/reference/app-request-former-recipient/ 
 * @typedef {Object} FacebookAppRequestFormerRecipient
 */
public class FacebookAppRequestFormerRecipient
{
	public FacebookAppRequestFormerRecipient(){}
	/**
	 * Viewer ID
	 * @type {String}
	 */
	public String id;

	/**
	 * Recipient ID
	 * @type {String}
	 */
	public String recipient_id;

	}

