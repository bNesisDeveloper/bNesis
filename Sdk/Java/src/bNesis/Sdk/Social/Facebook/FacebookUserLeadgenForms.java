package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * A list of lead generation forms belonging to Pages that the user has advertiser permissions on
 *     https://developers.facebook.com/docs/graph-api/reference/user/leadgen_forms/ 
 * @typedef {Object} FacebookUserLeadgenForms
 */
public class FacebookUserLeadgenForms
{
	public FacebookUserLeadgenForms(){}
	/**
	 * A list of LeadGenData nodes.
	 * @type {FacebookPage[]}
	 */
	public FacebookPage[] data;

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

