package bNesis.Sdk.Social.GooglePlus;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of GooglePlusActor. 
 * @typedef {Object} GooglePlusActor
 */
public class GooglePlusActor
{
	public GooglePlusActor(){}
	/**
	 * The identifier of the actor.
	 * @type {String}
	 */
	public String id;

	/**
	 * The formated name of the actor.
	 * @type {String}
	 */
	public String displayName;

	/**
	 * The representation of actor name.
	 * @type {GooglePlusName}
	 */
	public GooglePlusName name;

	/**
	 * A link to the Person for this actor.
	 * @type {String}
	 */
	public String url;

	/**
	 * The image representation for this actor.
	 * @type {GooglePlusImage}
	 */
	public GooglePlusImage image;

	}

