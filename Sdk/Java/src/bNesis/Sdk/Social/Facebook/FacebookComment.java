package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * A comment can be made on various types of content on Facebook. 
 *     Most Graph API nodes have a /comments edge that lists all the comments on that object. 
 *     The /{comment-id} node returns a single comment. 
 * @typedef {Object} FacebookComment
 */
public class FacebookComment
{
	public FacebookComment(){}
	/**
	 * The comment ID
	 * @type {String}
	 */
	public String id;

	/**
	 * The time this comment was made
	 * @type {Date}
	 */
	public Date created_time;

	/**
	 * The person that made this comment
	 * @type {FacebookUser}
	 */
	public FacebookUser from;

	/**
	 * The comment text.
	 * @type {String}
	 */
	public String message;

	/**
	 * Whether the viewer has liked this comment.
	 * @type {String}
	 */
	public String user_likes;

	}

