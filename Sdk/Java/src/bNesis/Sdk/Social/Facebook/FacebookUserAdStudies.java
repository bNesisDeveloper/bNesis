package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Ad studies that this person can view 
 *      https://developers.facebook.com/docs/graph-api/reference/user/ad_studies/ 
 * @typedef {Object} FacebookUserAdStudies
 */
public class FacebookUserAdStudies
{
	public FacebookUserAdStudies(){}
	/**
	 * A list of AdStudy nodes
	 * @type {FacebookAdStudy[]}
	 */
	public FacebookAdStudy[] data;

	/**
	 * For more details about pagination, see the Graph API guide
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	/**
	 * Aggregated information about the edge, such as counts. 
	 * Specify the fields to fetch in the summary param (like summary=total_count).
	 * @type {FacebookPaging}
	 */
	public FacebookPaging summary;

	}

