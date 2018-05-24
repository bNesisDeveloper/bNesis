package bNesis.Sdk.Social.VKontakte;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * last visit date. 
 * @typedef {Object} VKontakteLastSeen
 */
public class VKontakteLastSeen
{
	public VKontakteLastSeen(){}
	/**
	 * last visit date (in Unixtime)
	 * @type {String}
	 */
	public String time;

	/**
	 * — type of the platform that used for the last authorization. Possible values:
	 *  1 — m.vk.com;
	 *  2 — iPhone app;
	 *  3 — iPad app;
	 *  4 — Android app;
	 *  5 —Windows Phone app;
	 *  6 — Windows 8 app;
	 *  7 — web(vk.com);
	 *  8 — VK Mobile.
	 * @type {String}
	 */
	public String platform;

	}

