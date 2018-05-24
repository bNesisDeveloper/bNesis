package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * This reference describes the /comments edge that is common to multiple Graph API nodes. 
 * @typedef {Object} FacebookComments
 */
public class FacebookComments
{
	public FacebookComments(){}
	/**
	 * The data.
	 * @type {FacebookComment[]}
	 */
	public FacebookComment[] data;

	/**
	 * Paging.
	 * @type {FacebookPaging}
	 */
	public FacebookPaging paging;

	}

