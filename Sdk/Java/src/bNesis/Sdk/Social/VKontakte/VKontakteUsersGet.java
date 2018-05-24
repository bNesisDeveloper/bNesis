package bNesis.Sdk.Social.VKontakte;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * a list of user objects 
 * @typedef {Object} VKontakteUsersGet
 */
public class VKontakteUsersGet
{
	public VKontakteUsersGet(){}
	/**
	 * object describes a user profile
	 * https://vk.com/dev/objects/user
	 * Object contains information about user. Fields set may vary depending on called method and passed parameters.
	 * @type {VKontakteUser[]}
	 */
	public VKontakteUser[] response;

	}

