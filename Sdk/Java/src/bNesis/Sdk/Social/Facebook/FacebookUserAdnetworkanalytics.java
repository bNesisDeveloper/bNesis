package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Insights for all of this user's Audience Network apps. 
 * @typedef {Object} FacebookUserAdnetworkanalytics
 */
public class FacebookUserAdnetworkanalytics
{
	public FacebookUserAdnetworkanalytics(){}
	/**
	 * A list of InsightsQueryResult nodes
	 * @type {FacebookInsightsQueryResult[]}
	 */
	public FacebookInsightsQueryResult[] data;

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

