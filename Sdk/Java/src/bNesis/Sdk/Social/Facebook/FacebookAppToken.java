package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * App access tokens are used to make requests to Facebook APIs on behalf of an app rather than a user. This can be used to modify the parameters of your app, create and manage test users, or read your apps's insights.
 *      https://developers.facebook.com/docs/facebook-login/access-tokens#apptokens 
 * @typedef {Object} FacebookAppToken
 */
public class FacebookAppToken
{
	public FacebookAppToken(){}
	/**
	 * App Token
	 * @type {String}
	 */
	public String access_token;

	/**
	 * Token Type
	 * @type {String}
	 */
	public String token_type;

	}

