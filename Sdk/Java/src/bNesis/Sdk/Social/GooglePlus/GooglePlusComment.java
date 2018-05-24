package bNesis.Sdk.Social.GooglePlus;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of GooglePlusComment 
 * @typedef {Object} GooglePlusComment
 */
public class GooglePlusComment
{
	public GooglePlusComment(){}
	/**
	 * Identifier this resources as a comment.
	 * @type {String}
	 */
	public String kind;

	/**
	 * The identifier.
	 * @type {String}
	 */
	public String id;

	/**
	 * ETag of this response for caching purposes
	 * @type {String}
	 */
	public String etag;

	/**
	 * This comment's verb, indicating what action was performed.
	 *   Possible values are:
	 *   post - Publish content to the stream.
	 * @type {String}
	 */
	public String verb;

	/**
	 * When comment created.
	 * @type {String}
	 */
	public String published;

	/**
	 * When comment updated.
	 * @type {String}
	 */
	public String updated;

	/**
	 * Actor who write comment.
	 * @type {GooglePlusActor}
	 */
	public GooglePlusActor actor;

	/**
	 * Content contain some information about of comment.
	 * @type {GooglePlusCommentContent}
	 */
	public GooglePlusCommentContent content;

	/**
	 * Link to this comment resource.
	 * @type {String}
	 */
	public String selfLink;

	/**
	 * The activity this comment replied to.
	 * @type {GooglePlusInReplyTo[]}
	 */
	public GooglePlusInReplyTo[] inReplyTo;

	/**
	 * People who +1'd this comment ''.
	 * @type {GooglePlusAboutItem}
	 */
	public GooglePlusAboutItem plusoners;

	}

