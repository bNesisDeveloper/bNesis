package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * A list of filters that can be applied to the News Feed edge
 *     https://developers.facebook.com/docs/graph-api/reference/user/stream_filters/ 
 * @typedef {Object} FacebookUserStreamFilters
 */
public class FacebookUserStreamFilters
{
	public FacebookUserStreamFilters(){}
	/**
	 * A list of StreamFilter nodes.
	 * @type {FacebookStreamFilter[]}
	 */
	public FacebookStreamFilter[] data;

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

