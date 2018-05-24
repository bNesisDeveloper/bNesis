package bNesis.Sdk.Social.GooglePlus;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of GooglePlusThumbnail. 
 * @typedef {Object} GooglePlusThumbnail
 */
public class GooglePlusThumbnail
{
	public GooglePlusThumbnail(){}
	/**
	 * The URL to album.
	 * @type {String}
	 */
	public String url;

	/**
	 * The description of album.
	 * @type {String}
	 */
	public String description;

	/**
	 * Image resource.
	 * @type {GooglePlusImage}
	 */
	public GooglePlusImage image;

	}

