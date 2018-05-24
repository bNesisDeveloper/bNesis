package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * App requests
 *     Permissions
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     No data
 *     Page management Apps
 *     No data
 *     Other Apps
 *     user_friends
 *     https://developers.facebook.com/docs/graph-api/reference/user/apprequestformerrecipients/ 
 * @typedef {Object} FacebookApprequestformerrecipients
 */
public class FacebookApprequestformerrecipients
{
	public FacebookApprequestformerrecipients(){}
	/**
	 * Gets or sets the data.
	 * @type {FacebookAppRequestFormerRecipient[]}
	 */
	public FacebookAppRequestFormerRecipient[] data;

	/**
	 * Gets or sets the paging.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

