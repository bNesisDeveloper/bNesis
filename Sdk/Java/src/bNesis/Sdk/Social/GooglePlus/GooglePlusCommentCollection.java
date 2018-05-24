package bNesis.Sdk.Social.GooglePlus;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of GooglePlusCommentCollection. 
 * @typedef {Object} GooglePlusCommentCollection
 */
public class GooglePlusCommentCollection
{
	public GooglePlusCommentCollection(){}
	/**
	 * Identifier the resource.
	 * @type {String}
	 */
	public String kind;

	/**
	 * ETag of this response for caching purposes.
	 * @type {String}
	 */
	public String etag;

	/**
	 * Link to next page.
	 * @type {String}
	 */
	public String nextLink;

	/**
	 * The title of collection.
	 * @type {String}
	 */
	public String title;

	/**
	 * The next page token to collection.
	 * @type {String}
	 */
	public String nextPageToken;

	/**
	 * When updated.
	 * @type {String}
	 */
	public String updated;

	/**
	 * The identifier of collection.
	 * @type {String}
	 */
	public String id;

	/**
	 * Some description.
	 * @type {String}
	 */
	public String description;

	/**
	 * The array of GooglePlusComment.
	 * @type {GooglePlusComment[]}
	 */
	public GooglePlusComment[] items;

	}

