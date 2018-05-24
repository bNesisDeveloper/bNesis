package bNesis.Sdk.Social.VKontakte;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Object describes photo.
 *     https://vk.com/dev/objects/photo 
 * @typedef {Object} VKontaktePhoto
 */
public class VKontaktePhoto
{
	public VKontaktePhoto(){}
	/**
	 * Photo ID.
	 * @type {String}
	 */
	public String id;

	/**
	 * Photo album ID.
	 * @type {String}
	 */
	public String album_id;

	/**
	 * Photo owner ID.
	 * @type {String}
	 */
	public String owner_id;

	/**
	 * Photo owner ID.
	 * @type {String}
	 */
	public String user_id;

	/**
	 * Description text.
	 * @type {String}
	 */
	public String text;

	/**
	 * Date when the photo has been added in Unixtime.
	 * @type {String}
	 */
	public String date;

	/**
	 * URL of the copy with maximum size of 75x75px.
	 * @type {String}
	 */
	public String photo_75;

	/**
	 * URL of the copy with maximum size of 130x130px.
	 * @type {String}
	 */
	public String photo_130;

	/**
	 * URL of the copy with maximum size of 604x604px
	 * @type {String}
	 */
	public String photo_604;

	/**
	 * URL of the copy with maximum size of 807x807px.
	 * @type {String}
	 */
	public String photo_807;

	/**
	 * URL of the copy with maximum size of 1280x1024px.
	 * @type {String}
	 */
	public String photo_1280;

	/**
	 * URL of the copy with maximum size of 2560x2048px.
	 * @type {String}
	 */
	public String photo_2560;

	/**
	 * Width of the original photo in px.
	 * @type {String}
	 */
	public String width;

	/**
	 * Height of the original photo in px.
	 * @type {String}
	 */
	public String height;

	/**
	 * The post identifier.
	 * @type {String}
	 */
	public String post_id;

	}

