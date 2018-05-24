package bNesis.Sdk.Social.VKontakte;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Information from the "Personal views" section. 
 * @typedef {Object} VKontaktePersonal
 */
public class VKontaktePersonal
{
	public VKontaktePersonal(){}
	/**
	 * political views. Possible values:
	 * 1 – Communist;
	 * 2 – Socialist;
	 * 3 – Moderate;
	 * 4 – Liberal;
	 * 5 – Conservative;
	 * 6 – Monarchist;
	 * 7 – Ultraconservative;
	 * 8 – Apathetic;
	 * 9 – Libertarian.
	 * @type {String}
	 */
	public String political;

	/**
	 * languages
	 * @type {String[]}
	 */
	public String[] langs;

	/**
	 * world view
	 * @type {String}
	 */
	public String religion;

	/**
	 * inspired by
	 * @type {String}
	 */
	public String inspired_by;

	/**
	 * improtant in others. Possible values:
	 *  1 – intellect and creativity;
	 *  2 – kindness and honesty;
	 *  3 – health and beauty;
	 *  4 – wealth and power;
	 *  5 – courage and persistance;
	 *  6 – humor and love for life.
	 * @type {String}
	 */
	public String people_main;

	/**
	 * personal priority. Possible values:
	 *  1 – family and children;
	 *  2 – career and money;
	 *  3 – entertainment and leisure;
	 *  4 – science and research;
	 *  5 – improving the world;
	 *  6 – personal development;
	 *  7 – beauty and art ;
	 *  8 – fame and influence;
	 * @type {String}
	 */
	public String life_main;

	/**
	 * views on smoking. Possible values:
	 *  1 – very negative;
	 *  2 – negative;
	 *  3 – neutral;
	 *  4 – compromisable;
	 *  5 – positive.
	 * @type {String}
	 */
	public String smoking;

	/**
	 * views on alcohol. Possible values:
	 *  1 – very negative;
	 *  2 – negative;
	 *  3 – neutral;
	 *  4 – compromisable;
	 *  5 – positive.
	 * @type {String}
	 */
	public String alcohol;

	}

