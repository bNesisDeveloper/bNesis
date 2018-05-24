package bNesis.Sdk.GovRegistry.Prozzoro;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of Bid. Used when need get information about tender bid. 
 * @typedef {Object} ProzzoroBid
 */
public class ProzzoroBid
{
	public ProzzoroBid(){}
	/**
	 * The main bid identifier.
	 * @type {String}
	 */
	public String id;

	/**
	 * Possible status values are:
	 * draft,active
	 * @type {String}
	 */
	public String status;

	/**
	 * The array of document.
	 * @type {ProzzoroDocument[]}
	 */
	public ProzzoroDocument[] documents;

	/**
	 * A value of whether bid self-eligible.
	 * true - bid self-eigible.
	 * false - bid not self-eigible.
	 * @type {Boolean}
	 */
	public Boolean selfEligible;

	/**
	 * The cost of bid.
	 * @type {ProzzoroValue}
	 */
	public ProzzoroValue value;

	/**
	 * A value indicating whether bid self-qualified.
	 * true - bid self-qualified.
	 * false - bid not self-qualified.
	 * @type {Boolean}
	 */
	public Boolean selfQualified;

	/**
	 * The array of tenderer.
	 * @type {ProzzoroTenderer[]}
	 */
	public ProzzoroTenderer[] tenderers;

	/**
	 * The date.
	 * @type {String}
	 */
	public String date;

	/**
	 * The participation URL.
	 * @type {String}
	 */
	public String participationUrl;

	}

