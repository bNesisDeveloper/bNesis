package bNesis.Sdk.Social.GooglePlus;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of GooglePlusActivity. 
 * @typedef {Object} GooglePlusActivity
 */
public class GooglePlusActivity
{
	public GooglePlusActivity(){}
	/**
	 * The identifier of this activity.
	 * @type {String}
	 */
	public String id;

	/**
	 * Identifies this resource as an activity
	 * @type {String}
	 */
	public String kind;

	/**
	 * ETag of this response for caching purposes
	 * @type {String}
	 */
	public String etag;

	/**
	 * The title of this activity.
	 * @type {String}
	 */
	public String title;

	/**
	 * The time when this activity initially published.
	 * @type {String}
	 */
	public String published;

	/**
	 * The time when this activity was updated.
	 * @type {String}
	 */
	public String updated;

	/**
	 * The link to this activity.
	 * @type {String}
	 */
	public String url;

	/**
	 * The person who perfomed this activity.
	 * @type {GooglePlusActor}
	 */
	public GooglePlusActor actor;

	/**
	 * This activity's verb, which indicates the action that was performed.
	 *   Possible values are:
	 *   post - Publish content to the stream.
	 *   share - Reshare an activity.
	 * @type {String}
	 */
	public String verb;

	/**
	 * The content of this activity.
	 * @type {GooglePlusActivityContent}
	 */
	public GooglePlusActivityContent activityContent;

	/**
	 * Additional content added by the person who shared this activity, applicable only when resharing an activity.
	 * @type {String}
	 */
	public String annotation;

	/**
	 * If this activity is a crosspost from another system, this property specifies the ID of the original activity.
	 * @type {String}
	 */
	public String crosspostSource;

	/**
	 * The service provider who published this activity.
	 * @type {GooglePlusProvider}
	 */
	public GooglePlusProvider provider;

	/**
	 * Identifies who has access to see this activity.
	 * @type {GooglePlusAccess}
	 */
	public GooglePlusAccess access;

	/**
	 * Latitude and longitude where this activity occurred. Format is latitude followed by longitude, space separated.
	 * @type {String}
	 */
	public String geocode;

	/**
	 * Street address where this activity occurred.
	 * @type {String}
	 */
	public String address;

	/**
	 * Radius, in meters, of the region where this activity occurred, centered at the latitude and longitude identified in .
	 * @type {String}
	 */
	public String radius;

	/**
	 * The identifier of the place where this activity occurred.
	 * @type {String}
	 */
	public String placeId;

	/**
	 * Name of the place where this activity occurred.
	 * @type {String}
	 */
	public String placeName;

	/**
	 * The location where this activity occurred.
	 * @type {GooglePlusLocation}
	 */
	public GooglePlusLocation location;

	}

