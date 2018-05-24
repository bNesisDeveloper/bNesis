package bNesis.Sdk.Social.GooglePlus;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of GooglePlusAccess. 
 * @typedef {Object} GooglePlusAccess
 */
public class GooglePlusAccess
{
	public GooglePlusAccess(){}
	/**
	 * The identifier of entry for circle or person .
	 * @type {String}
	 */
	public String id;

	/**
	 * The type of entry for whom have access is granted.
	 *   Possible values are:
	 *   person - Access to an individual.
	 *   circle - Access to members of a circle.
	 *   "myCircles - Access to members of all the person's circles.
	 *   extendedCircles - Access to members of all the person's circles, plus all of the people in their circles.
	 *   domain - Access to members of the person's Google Apps domain.
	 *   public - Access to anyone on the web.
	 * @type {String}
	 */
	public String type;

	/**
	 * A descriptive name for this entry.
	 * @type {String}
	 */
	public String displayName;

	}

