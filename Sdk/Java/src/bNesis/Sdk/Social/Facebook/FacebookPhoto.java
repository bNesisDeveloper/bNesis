package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Represents an individual photo on Facebook.
 *     https://developers.facebook.com/docs/graph-api/reference/photo
 *     Permissions
 *     Any valid access token can read photos on a public Page.
 *     A page access token can read all photos posted to or posted by that Page.
 *     A user access token can read any photo your application created on behalf of that user.
 *     A user's photos can be read if the owner has granted the user_photos or user_posts permission.
 *     A user access token may read a photo that user is tagged in if they have granted the user_photos or user_posts permission. However, in some cases the photo's owner's privacy settings may not allow your application to access it.
 *     A User access token for an Admin of a Group can read Group-owned Photos.
 *     A User access token for an Admin of an Event can read Event-owned Photos. 
 * @typedef {Object} FacebookPhoto
 */
public class FacebookPhoto
{
	public FacebookPhoto(){}
	/**
	 * The photo ID
	 * @type {String}
	 */
	public String id;

	/**
	 * The album this photo is in
	 * @type {FacebookAlbum}
	 */
	public FacebookAlbum album;

	/**
	 * The time this photo was published.
	 * @type {Date}
	 */
	public Date created_time;

	/**
	 * If this object has a place, the event associated with the place.
	 * @type {FacebookEvent}
	 */
	public FacebookEvent event_;

	/**
	 * The icon that Facebook displays when photos are published to News Feed
	 * @type {String}
	 */
	public String icon;

	/**
	 * The different stored representations of the photo. Can vary in number based upon the size of the original photo.
	 * @type {FacebookPlatformImageSource[]}
	 */
	public FacebookPlatformImageSource[] images;

	/**
	 * A link to the photo on Facebook.
	 * @type {String}
	 */
	public String link;

	/**
	 * The user-provided caption given to this photo. Corresponds to caption when creating photos
	 * @type {String}
	 */
	public String name;

	/**
	 * Link to the 100px wide representation of this photo
	 * @type {String}
	 */
	public String picture;

	/**
	 * Gets or sets the place.
	 * @type {FacebookPlace}
	 */
	public FacebookPlace place;

	/**
	 * The last time the photo was updated
	 * @type {Date}
	 */
	public Date updated_time;

	/**
	 * People who like this
	 * @type {FacebookUserLikes}
	 */
	public FacebookUserLikes likes;

	/**
	 * Comments on an object
	 * @type {FacebookComments}
	 */
	public FacebookComments comments;

	}

