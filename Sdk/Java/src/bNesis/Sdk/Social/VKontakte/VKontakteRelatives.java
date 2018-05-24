package bNesis.Sdk.Social.VKontakte;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Current user's relatives list.
 *     Returns a list of objects with id and type fields (name instead of id if a relative is not a VK user). 
 * @typedef {Object} VKontakteRelatives
 */
public class VKontakteRelatives
{
	public VKontakteRelatives(){}
	/**
	 * ID
	 * @type {String}
	 */
	public String id;

	/**
	 * name instead of id if a relative is not a VK user
	 * @type {String}
	 */
	public String name;

	/**
	 * type – relationship type. Possible values:
	 * sibling
	 * parent
	 * child
	 * grandparent
	 * grandchild
	 * @type {String}
	 */
	public String type;

	}

