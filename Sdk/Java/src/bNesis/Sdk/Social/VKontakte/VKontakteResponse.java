package bNesis.Sdk.Social.VKontakte;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Response 
 * @typedef {Object} VKontakteResponse
 */
public class VKontakteResponse
{
	public VKontakteResponse(){}
	/**
	 * object describes a user profile
	 * https://vk.com/dev/objects/user
	 * Object contains information about users. Fields set may vary depending on called method and passed parameters.
	 * @type {VKontakteUser[]}
	 */
	public VKontakteUser[] response;

	}

