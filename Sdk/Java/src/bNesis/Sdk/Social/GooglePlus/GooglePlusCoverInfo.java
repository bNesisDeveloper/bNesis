package bNesis.Sdk.Social.GooglePlus;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of GooglePlusCoverInfo. 
 * @typedef {Object} GooglePlusCoverInfo
 */
public class GooglePlusCoverInfo
{
	public GooglePlusCoverInfo(){}
	/**
	 * The difference between the top position of the cover image and the actual displayed cover image. 
	 *   Only valid for banner layout.
	 * @type {Integer}
	 */
	public Integer topImageOffset;

	/**
	 * The difference between the left position of the cover image and the actual displayed cover image
	 *   Only valid for banner layout.
	 * @type {Integer}
	 */
	public Integer leftImageOffset;

	}

