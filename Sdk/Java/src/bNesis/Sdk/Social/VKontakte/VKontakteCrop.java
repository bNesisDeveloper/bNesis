package bNesis.Sdk.Social.VKontakte;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Data about points used for cropping of profile and preview user photos. 
 * @typedef {Object} VKontakteCrop
 */
public class VKontakteCrop
{
	public VKontakteCrop(){}
	/**
	 * X coordinate for the left upper corner
	 * @type {String}
	 */
	public String x;

	/**
	 * Y coordinate for the left upper corner
	 * @type {String}
	 */
	public String y;

	/**
	 * X coordinate for the right bottom corner
	 * @type {String}
	 */
	public String x2;

	/**
	 * Y coordinate for the right bottom corner
	 * @type {String}
	 */
	public String y2;

	}

