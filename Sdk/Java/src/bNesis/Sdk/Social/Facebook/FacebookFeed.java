package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * The feed of posts 
 * @typedef {Object} FacebookFeed
 */
public class FacebookFeed
{
	public FacebookFeed(){}
	/**
	 * Data
	 * @type {FacebookPost[]}
	 */
	public FacebookPost[] data;

	/**
	 * Gets or sets the paging.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

