package bNesis.Sdk.Social.GooglePlus;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of GooglePlusCover 
 * @typedef {Object} GooglePlusCover
 */
public class GooglePlusCover
{
	public GooglePlusCover(){}
	/**
	 * The layout of the cover art.
	 *   Possible values are:
	 *   banner - One large image banner.
	 *   See also: https://developers.google.com/+/web/api/rest/latest/people#cover.layout
	 * @type {String}
	 */
	public String layout;

	/**
	 * The person's primary cover image.
	 * @type {GooglePlusCoverPhoto}
	 */
	public GooglePlusCoverPhoto coverPhoto;

	/**
	 * Extra information about the cover photo.
	 * @type {GooglePlusCoverInfo}
	 */
	public GooglePlusCoverInfo coverInfo;

	}

