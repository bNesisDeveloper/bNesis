package bNesis.Sdk.Social.GooglePlus;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of GooglePlusAttachment. 
 * @typedef {Object} GooglePlusAttachment
 */
public class GooglePlusAttachment
{
	public GooglePlusAttachment(){}
	/**
	 * The identifier of attachment.
	 * @type {String}
	 */
	public String id;

	/**
	 * The type of media object.
	 *   Possible values are:
	 *   photo - A photo.
	 *   album - A photo album.
	 *   video - A video.
	 *   article - An article, specified by a link.
	 * @type {String}
	 */
	public String objectType;

	/**
	 * The title of attachment.
	 * @type {String}
	 */
	public String displayName;

	/**
	 * Contain description for .
	 * @type {String}
	 */
	public String content;

	/**
	 * The link to attachment.
	 * @type {String}
	 */
	public String url;

	/**
	 * Preview for photos or videos.
	 * @type {GooglePlusImage}
	 */
	public GooglePlusImage image;

	/**
	 * The full image URL for attachment.
	 * @type {GooglePlusImage}
	 */
	public GooglePlusImage fullImage;

	/**
	 * If attachment is video, the emdedable link.
	 * @type {GooglePlusEmbed}
	 */
	public GooglePlusEmbed embed;

	/**
	 * If attachment is album contain list of potential additional thumbnails from the album.
	 * @type {GooglePlusThumbnail[]}
	 */
	public GooglePlusThumbnail[] thumbnails;

	}

