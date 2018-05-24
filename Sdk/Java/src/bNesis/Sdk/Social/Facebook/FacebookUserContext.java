package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Social context for a person 
 * @typedef {Object} FacebookUserContext
	 * @property {FacebookAllMutualFriends}  all_mutual_friends - Returns a list of all the Facebook friends that the session user and the request user have in common. 
	 * This includes friends who use the app as well as non-app-using mutual friends.
 */
public class FacebookUserContext
{
	public FacebookUserContext(){}
	/**
	 * The token representing the social context
	 * @type {String}
	 */
	public String id;

	/**
	 * All friends that the viewer and the target person have in common. This includes the friends who do not use your app
	 * @type {FacebookAllMutualFriends}
	 */
	public FacebookAllMutualFriends all_mutual_friends;

	/**
	 * Social context edge providing a list of Facebook friends that have logged into the app that the viewer and the target person have in common
	 * @type {FacebookMutualFriends}
	 */
	public FacebookMutualFriends mutual_friends;

	/**
	 * Social context edge providing a list of the liked Pages that the calling person and the target person have in common
	 * @type {FacebookMutualLikes}
	 */
	public FacebookMutualLikes mutual_likes;

	/**
	 * Friends of the viewer who are mutual friends with the target and have the app installed
	 * @type {FacebookthreeDegreeMutualFriends}
	 */
	public FacebookthreeDegreeMutualFriends three_degree_mutual_friends;

	}

