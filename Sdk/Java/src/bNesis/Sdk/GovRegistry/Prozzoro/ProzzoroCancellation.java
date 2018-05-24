package bNesis.Sdk.GovRegistry.Prozzoro;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of Cancellation. Used when need get information about tender/lot cancellation. 
 * @typedef {Object} ProzzoroCancellation
 */
public class ProzzoroCancellation
{
	public ProzzoroCancellation(){}
	/**
	 * The main cancellation identifier.
	 * @type {String}
	 */
	public String id;

	/**
	 * Possible status values are:
	 *  pending:	Default.The request is being prepared.
	 *  active:	Cancellation activated.
	 * @type {String}
	 */
	public String status;

	/**
	 * Protocol of Tender Committee with decision to cancel the Tender.
	 * @type {ProzzoroDocument[]}
	 */
	public ProzzoroDocument[] documents;

	/**
	 * The reason, why Tender is being cancelled.
	 * @type {String}
	 */
	public String reason;

	/**
	 * The reason type.
	 * @type {String}
	 */
	public String reasonType;

	/**
	 * Cancellation date.
	 * @type {String}
	 */
	public String date;

	/**
	 * The cancellation of possible values are:
	 *  tender, lot.
	 * @type {String}
	 */
	public String cancellationOf;

	/**
	 * The identifier of related Lot.
	 * @type {String}
	 */
	public String relatedLot;

	}

