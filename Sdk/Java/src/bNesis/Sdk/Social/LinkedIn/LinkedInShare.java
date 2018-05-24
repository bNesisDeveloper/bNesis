package bNesis.Sdk.Social.LinkedIn;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of Share. 
 * @typedef {Object} LinkedInShare
 */
public class LinkedInShare
{
	public LinkedInShare(){}
	/**
	 * The commentary.
	 * @type {String}
	 */
	public String comment;

	/**
	 * The content.
	 * @type {LinkedInContent}
	 */
	public LinkedInContent content;

	/**
	 * Who can see this post.
	 * @type {LinkedInVisibility}
	 */
	public LinkedInVisibility visibility;

	}

