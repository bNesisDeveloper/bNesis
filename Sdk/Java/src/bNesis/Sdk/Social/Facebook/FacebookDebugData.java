package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Inspecting Access Tokens
 *      https://developers.facebook.com/docs/facebook-login/manually-build-a-login-flow 
 * @typedef {Object} FacebookDebugData
 */
public class FacebookDebugData
{
	public FacebookDebugData(){}
	/**
	 * The application identifier.
	 * @type {String}
	 */
	public String app_id;

	/**
	 * The type.
	 * @type {String}
	 */
	public String type;

	/**
	 * The application.
	 * @type {String}
	 */
	public String application;

	/**
	 * The expires at.
	 * @type {String}
	 */
	public String expires_at;

	/**
	 * The is valid.
	 * @type {String}
	 */
	public String is_valid;

	/**
	 * The issued at.
	 * @type {String}
	 */
	public String issued_at;

	/**
	 * The metadata.
	 * @type {FacebookDebugMetadata}
	 */
	public FacebookDebugMetadata metadata;

	/**
	 * The scopes.
	 * @type {String[]}
	 */
	public String[] scopes;

	/**
	 * The user identifier.
	 * @type {String}
	 */
	public String user_id;

	}

