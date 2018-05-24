package bNesis.Sdk.Social.GooglePlus;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of GooglePlusCommentContent. 
 * @typedef {Object} GooglePlusCommentContent
 */
public class GooglePlusCommentContent
{
	public GooglePlusCommentContent(){}
	/**
	 * The object type.
	 *  Possible values are:
	 * comment - A comment in reply to an activity.
	 * @type {String}
	 */
	public String objectType;

	/**
	 * The HTML-formatted content.
	 * @type {String}
	 */
	public String content;

	/**
	 * The content without HTML-formatted.
	 * @type {String}
	 */
	public String originalContent;

	}

