package bNesis.Sdk.Social.VKontakte;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Number of various objects the user has.  Can be used in users.get method only when requesting information about a user. 
 *     Returns only in users.get method when only one user information is requested and access_token is passed. 
 * @typedef {Object} VKontakteCounters
 */
public class VKontakteCounters
{
	public VKontakteCounters(){}
	/**
	 * number of photo albums
	 * @type {String}
	 */
	public String albums;

	/**
	 * number of videos
	 * @type {String}
	 */
	public String videos;

	/**
	 * number of audios
	 * @type {String}
	 */
	public String audios;

	/**
	 * number of photos
	 * @type {String}
	 */
	public String photos;

	/**
	 * number of photo albums
	 * @type {String}
	 */
	public String notes;

	/**
	 * number of friends
	 * @type {String}
	 */
	public String friends;

	/**
	 * number of communities
	 * @type {String}
	 */
	public String groups;

	/**
	 * number of online friends
	 * @type {String}
	 */
	public String online_friends;

	/**
	 * number of mutual friends
	 * @type {String}
	 */
	public String mutual_friends;

	/**
	 * number of videos the user is tagged on
	 * @type {String}
	 */
	public String user_videos;

	/**
	 * number of followers
	 * @type {String}
	 */
	public String followers;

	/**
	 * number of subscriptions(users only)
	 * @type {String}
	 */
	public String pages;

	}

