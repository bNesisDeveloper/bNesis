package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Live encoders owned by this person
 *     https://developers.facebook.com/docs/graph-api/reference/user/live_videos/ 
 * @typedef {Object} FacebookUserLiveEncoders
 */
public class FacebookUserLiveEncoders
{
	public FacebookUserLiveEncoders(){}
	/**
	 * A list of LiveEncoder nodes.
	 * @type {FacebookLiveEncoder[]}
	 */
	public FacebookLiveEncoder[] data;

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

