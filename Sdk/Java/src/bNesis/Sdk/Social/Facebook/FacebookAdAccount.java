package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Represents a business, person or other entity who creates and manage ads on Facebook. 
 *     Multiple people can manage an account, and each person can have one or more levels of access to an account, by specifying roles, see Ad User. 
 *     Permissions
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     ads_read 
 * @typedef {Object} FacebookAdAccount
 */
public class FacebookAdAccount
{
	public FacebookAdAccount(){}
	/**
	 * The string act_{ad_account_id}
	 * @type {String}
	 */
	public String account_id;

	/**
	 * The ID of the ad account
	 * @type {String}
	 */
	public String id;

	}

