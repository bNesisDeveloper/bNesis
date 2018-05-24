package bNesis.Sdk.Social.GooglePlus;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of GooglePlusImage. 
 * @typedef {Object} GooglePlusImage
 */
public class GooglePlusImage
{
	public GooglePlusImage(){}
	/**
	 * The URL of the image.
	 * @type {String}
	 */
	public String url;

	/**
	 * Media type of the link.
	 * @type {String}
	 */
	public String type;

	/**
	 * Image height. (Can be unspecified)
	 * @type {Integer}
	 */
	public Integer height;

	/**
	 * Image width. (Can be unspecified)
	 * @type {Integer}
	 */
	public Integer width;

	}

