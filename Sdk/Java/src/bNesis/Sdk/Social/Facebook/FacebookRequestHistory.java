package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * A Graph API past request object
 *     https://developers.facebook.com/docs/graph-api/reference/request-history/ 
 * @typedef {Object} FacebookRequestHistory
 */
public class FacebookRequestHistory
{
	public FacebookRequestHistory(){}
	/**
	 * Gets or sets the API version.
	 * @type {String}
	 */
	public String api_version;

	/**
	 * Graph API version of the stored request
	 * @type {Date}
	 */
	public Date created_time;

	/**
	 * Error code of the past request
	 * @type {Integer}
	 */
	public Integer error_code;

	/**
	 * Graph path of the stored request
	 * @type {String}
	 */
	public String graph_path;

	/**
	 * HTTP method of the stored request.
	 * @type {String}
	 */
	public String http_method;

	}

