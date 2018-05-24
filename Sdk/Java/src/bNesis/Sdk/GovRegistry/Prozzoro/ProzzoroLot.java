package bNesis.Sdk.GovRegistry.Prozzoro;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of Lot. Used when need get information about tender lot. 
 * @typedef {Object} ProzzoroLot
 */
public class ProzzoroLot
{
	public ProzzoroLot(){}
	/**
	 * The main lot identifier.
	 * @type {String}
	 */
	public String id;

	/**
	 * The status of lot.
	 *  Possible values are:active:	Active tender lot (active)
	 *  unsuccessful:	Unsuccessful tender lot(unsuccessful)
	 *  complete:	Complete tender lot(complete)
	 *  cancelled:	Cancelled tender lot(cancelled)
	 * @type {String}
	 */
	public String status;

	/**
	 * Detailed description of tender lot.
	 * @type {String}
	 */
	public String description;

	/**
	 * Array of document.
	 * @type {ProzzoroDocument[]}
	 */
	public ProzzoroDocument[] documents;

	/**
	 * The name of tender lot.
	 * @type {String}
	 */
	public String title;

	/**
	 * The minimal step of auction.
	 * @type {ProzzoroValue}
	 */
	public ProzzoroValue minimalStep;

	/**
	 * Total available tender lot budget.
	 * @type {ProzzoroValue}
	 */
	public ProzzoroValue value;

	/**
	 * When created.
	 * @type {String}
	 */
	public String date;

	/**
	 * Bid guarantee.
	 * @type {ProzzoroGuarantee}
	 */
	public ProzzoroGuarantee guarantee;

	/**
	 * The Cancellation object describes the reason of lot cancellation contains accompanying documents if any.
	 * @type {ProzzoroCancellation[]}
	 */
	public ProzzoroCancellation[] cancellations;

	}

