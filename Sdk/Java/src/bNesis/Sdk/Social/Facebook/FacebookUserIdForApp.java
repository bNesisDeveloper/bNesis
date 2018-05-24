package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * A users's ID for an app 
 * @typedef {Object} FacebookUserIdForApp
 */
public class FacebookUserIdForApp
{
	public FacebookUserIdForApp(){}
	/**
	 * ID.
	 * @type {String}
	 */
	public String id;

	/**
	 * App.
	 * @type {FacebookApplication}
	 */
	public FacebookApplication app;

	}

