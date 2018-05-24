package bNesis.Sdk.Social.GooglePlus;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of GooglePlusActivityCollection. 
 * @typedef {Object} GooglePlusActivityCollection
 */
public class GooglePlusActivityCollection
{
	public GooglePlusActivityCollection(){}
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
	 * Link to this resource.
	 * @type {String}
	 */
	public String selfLink;

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
	 * When update
	 * @type {String}
	 */
	public String updated;

	/**
	 * The identifier of collection.
	 * @type {String}
	 */
	public String id;

	/**
	 * The array of GooglePlusActivity.
	 * @type {GooglePlusActivity[]}
	 */
	public GooglePlusActivity[] items;

	}

