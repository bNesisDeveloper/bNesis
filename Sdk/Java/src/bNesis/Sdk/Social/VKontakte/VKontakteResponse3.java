package bNesis.Sdk.Social.VKontakte;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * The response 
 * @typedef {Object} VKontakteResponse3
 */
public class VKontakteResponse3
{
	public VKontakteResponse3(){}
	/**
	 * array of objects describing users
	 * https://vk.com/dev/objects/user
	 * Object contains information about user. Fields set may vary depending on called method and passed parameters.
	 * @type {VKontakteUser[]}
	 */
	public VKontakteUser[] items;

	/**
	 * the total results number
	 * @type {String}
	 */
	public String count;

	}

