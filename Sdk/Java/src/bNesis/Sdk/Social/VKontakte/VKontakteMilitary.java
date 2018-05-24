package bNesis.Sdk.Social.VKontakte;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Information about user's military service. 
 * @typedef {Object} VKontakteMilitary
 */
public class VKontakteMilitary
{
	public VKontakteMilitary(){}
	/**
	 * unit number
	 * @type {String}
	 */
	public String unit_id;

	/**
	 * country ID
	 * @type {String}
	 */
	public String country_id;

	/**
	 * service starting year
	 * @type {String}
	 */
	public String from;

	/**
	 * service ending year
	 * @type {String}
	 */
	public String until;

	}

