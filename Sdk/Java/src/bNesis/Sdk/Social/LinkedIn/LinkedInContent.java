package bNesis.Sdk.Social.LinkedIn;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of Content. 
 * @typedef {Object} LinkedInContent
 */
public class LinkedInContent
{
	public LinkedInContent(){}
	/**
	 * The content title.
	 * @type {String}
	 */
	public String title;

	/**
	 * Some description.
	 * @type {String}
	 */
	public String description;

	/**
	 * A fully qualified URL for the content being shared.
	 * @type {String}
	 */
	public String submittedUrl;

	/**
	 * A fully qualified URL to a thumbnail image to accompany the shared content. (Image should be at least 80 x 150px)
	 * @type {String}
	 */
	public String submittedImageUrl;

	}

