package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Video broadcasts from this person 
 * @typedef {Object} FacebookUserVideoBroadcasts
 */
public class FacebookUserVideoBroadcasts
{
	public FacebookUserVideoBroadcasts(){}
	/**
	 * A list of LiveVideo nodes.
	 * @type {FacebookLiveVideo[]}
	 */
	public FacebookLiveVideo[] data;

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

