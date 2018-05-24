package bNesis.Sdk.Social.GooglePlus;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of GooglePlusActivityContent. 
 * @typedef {Object} GooglePlusActivityContent
 */
public class GooglePlusActivityContent
{
	public GooglePlusActivityContent(){}
	/**
	 * The identifier of this content.
	 * @type {String}
	 */
	public String id;

	/**
	 * The type of the content.
	 *   Possible values are:
	 *   note - textual content.
	 *   activity - A Google+ activity.
	 * @type {String}
	 */
	public String objectType;

	/**
	 * If this activity's object is itself another activity, such as when a person reshares an activity,
	 *  this property specifies the original activity's actor.
	 * @type {GooglePlusActor}
	 */
	public GooglePlusActor actor;

	/**
	 * The HTML-formatted content.
	 * @type {String}
	 */
	public String content;

	/**
	 * The content(text) without HTML.
	 * @type {String}
	 */
	public String originalContent;

	/**
	 * The URL to the resource.
	 * @type {String}
	 */
	public String url;

	/**
	 * Total number of comments on this activity.
	 *  ( - number of comments)
	 * @type {GooglePlusAboutItem}
	 */
	public GooglePlusAboutItem replies;

	/**
	 * People who +1'd this activity.
	 *   ( - number of people)
	 * @type {GooglePlusAboutItem}
	 */
	public GooglePlusAboutItem plusoners;

	/**
	 * People who reshared this activity.
	 *   ( - number of people)
	 * @type {GooglePlusAboutItem}
	 */
	public GooglePlusAboutItem resharers;

	/**
	 * The media objects attached to this activity.
	 * @type {GooglePlusAttachment[]}
	 */
	public GooglePlusAttachment[] attachments;

	}

