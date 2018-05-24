package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Tagged Places for a Facebook User.
 *     https://developers.facebook.com/docs/graph-api/reference/user/tagged_places/
 *     Permissions
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     No data
 *     Page management Apps
 *     No data
 *     Other Apps
 *     user_tagged_places 
 * @typedef {Object} FacebookUserTaggedPlaces
 */
public class FacebookUserTaggedPlaces
{
	public FacebookUserTaggedPlaces(){}
	/**
	 * A list of PlaceTag nodes.
	 * @type {FacebookPlaceTag[]}
	 */
	public FacebookPlaceTag[] data;

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

