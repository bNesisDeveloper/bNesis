package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Album
 *     https://developers.facebook.com/docs/graph-api/reference/v2.12/album 
 * @typedef {Object} FacebookAlbum
 */
public class FacebookAlbum
{
	public FacebookAlbum(){}
	/**
	 * The album ID
	 * @type {String}
	 */
	public String id;

	/**
	 * Whether the viewer can upload photos to this album
	 * Type: bool
	 * @type {String}
	 */
	public String can_upload;

	/**
	 * The approximate number of photos in the album. This is not necessarily an exact count
	 * @type {Integer}
	 */
	public Integer count;

	/**
	 * The ID of the album's cover photo.
	 * @type {FacebookPhoto}
	 */
	public FacebookPhoto cover_photo;

	/**
	 * The time the album was initially created.
	 * @type {Date}
	 */
	public Date created_time;

	/**
	 * The description of the album.
	 * @type {String}
	 */
	public String description;

	/**
	 * The event associated with this album.
	 * @type {FacebookEvent}
	 */
	public FacebookEvent event_;

	/**
	 * The profile that created the album.
	 * @type {FacebookUser}
	 */
	public FacebookUser from;

	/**
	 * A link to this album on Facebook.
	 * @type {String}
	 */
	public String link;

	/**
	 * The textual location of the album.
	 * @type {String}
	 */
	public String location;

	/**
	 * The title of the album.
	 * @type {String}
	 */
	public String name;

	/**
	 * The place associated with this album.
	 * @type {FacebookPage}
	 */
	public FacebookPage place;

	/**
	 * The privacy settings for the album.
	 * @type {String}
	 */
	public String privacy;

	/**
	 * The type of the album.
	 * @type {String}
	 */
	public String type;

	/**
	 * The last time the album was updated.
	 * @type {Date}
	 */
	public Date updated_time;

	}

