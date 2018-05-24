package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * FacebookPaging
 *      https://developers.facebook.com/docs/graph-api/using-graph-api/#paging 
 * @typedef {Object} FacebookPaging
 */
public class FacebookPaging
{
	public FacebookPaging(){}
	/**
	 * Gets or sets the cursors.
	 * @type {FacebookCursors}
	 */
	public FacebookCursors cursors;

	/**
	 * The Graph API endpoint that will return the previous page of data. If not included, this is the first page of data.
	 * @type {String}
	 */
	public String previous;

	/**
	 * The Graph API endpoint that will return the next page of data. 
	 * If not included, this is the last page of data. 
	 * Due to how pagination works with visibility and privacy, it is possible that a page may be empty but contain a 'next' paging link. 
	 * Stop paging when the 'next' link no longer appears.
	 * @type {String}
	 */
	public String next;

	}

