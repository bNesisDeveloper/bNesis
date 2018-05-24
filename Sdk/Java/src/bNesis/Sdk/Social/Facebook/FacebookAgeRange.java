package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * An age range 
 * @typedef {Object} FacebookAgeRange
 */
public class FacebookAgeRange
{
	public FacebookAgeRange(){}
	/**
	 * The upper bounds of the range for this person's age.
	 * @type {Integer}
	 */
	public Integer max;

	/**
	 * The lower bounds of the range for this person's age.
	 * @type {Integer}
	 */
	public Integer min;

	}

