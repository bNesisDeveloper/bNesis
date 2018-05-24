package bNesis.Sdk.Social.GooglePlus;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of GooglePlusProfileCollection. 
 * @typedef {Object} GooglePlusProfileCollection
 */
public class GooglePlusProfileCollection
{
	public GooglePlusProfileCollection(){}
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
	 * The total items.
	 * @type {Integer}
	 */
	public Integer totalItems;

	/**
	 * The array of GooglePlusProfile.
	 * @type {GooglePlusProfile[]}
	 */
	public GooglePlusProfile[] items;

	}

