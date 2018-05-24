package bNesis.Sdk.Social.VKontakte;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Country specified on user's page in "Contacts" section. 
 * @typedef {Object} VKontakteCountry
 */
public class VKontakteCountry
{
	public VKontakteCountry(){}
	/**
	 * id(integer) — country ID;
	 * @type {Integer}
	 */
	public Integer id;

	/**
	 * title(string) — country name.
	 * @type {String}
	 */
	public String title;

	}

