package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * A Facebook page
 *     https://developers.facebook.com/docs/graph-api/reference/page/
 *     Permissions:
 *     For pages that are published, you need:
 *     An App or User access token to view fields from fully public pages.
 *     A User access token to view fields from restricted pages that this person is able to view (such as those restrict to certain demographics like location or age, or those only viewable by Page admins).
 *     A Page access token can also be used to view those restricted fields. A Page access token is required to view any User information for any objects owned by a Page.
 *     You need to be the Admin of the root page for child pages in order to read the global_brand_children edge for a page.
 *     For pages that are not published, you need:
 *     To have the Admin role for the page
 *     A Page access token 
 * @typedef {Object} FacebookPage
 */
public class FacebookPage
{
	public FacebookPage(){}
	/**
	 * Page ID. No access token is required to access this field
	 * @type {String}
	 */
	public String id;

	/**
	 * The Page's access token. Only returned if the User making the request has a role (other than Live Contributor) on the Page.
	 * If your business requires two-factor authentication, the User must also be authenticated.
	 * @type {String}
	 */
	public String access_token;

	/**
	 * The Business associated with this Page. Visible only with a page access token or a user access token that has admin rights on the page.
	 * @type {FacebookPage}
	 */
	public FacebookPage business;

	/**
	 * The Page's category. e.g. Product/Service, Computers/Technology
	 * @type {String}
	 */
	public String category;

	/**
	 * Time the object liked the page
	 * @type {Date}
	 */
	public Date created_time;

	/**
	 * The name of the Page
	 * @type {String}
	 */
	public String name;

	/**
	 * Gets or sets the perms.
	 * @type {String[]}
	 */
	public String[] perms;

	}

