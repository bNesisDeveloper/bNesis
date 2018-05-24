package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Results from an insights query. Please see our documentation on the app_insights edge for more information. 
 *     Data of Insights Query
 *     https://developers.facebook.com/docs/graph-api/reference/insights-query-result/ 
 * @typedef {Object} FacebookInsightsQueryResult
 */
public class FacebookInsightsQueryResult
{
	public FacebookInsightsQueryResult(){}
	/**
	 * Gets or sets the time.
	 * @type {Date}
	 */
	public Date time;

	/**
	 * Gets or sets the value.
	 * @type {String}
	 */
	public String value;

	}

