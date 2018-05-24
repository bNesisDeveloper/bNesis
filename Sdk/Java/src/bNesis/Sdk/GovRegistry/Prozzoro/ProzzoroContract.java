package bNesis.Sdk.GovRegistry.Prozzoro;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of Contract. Used when need get information about tender contract. 
 * @typedef {Object} ProzzoroContract
 */
public class ProzzoroContract
{
	public ProzzoroContract(){}
	/**
	 * The main contract identifier.
	 * @type {String}
	 */
	public String id;

	/**
	 * The contact status.
	 *   Possible values are:
	 *   pending - this contract has been proposed, but is not yet in force. It may be awaiting signature.
	 *   active - this contract has been signed by all the parties, and is now legally in force.
	 *   cancelled - this contract has been cancelled prior to being signed.
	 * @type {String}
	 */
	public String status;

	/**
	 * All documents and attachments related to the contract, including any notices.
	 * @type {ProzzoroDocument[]}
	 */
	public ProzzoroDocument[] documents;

	/**
	 * Array of item in this contract.
	 * @type {ProzzoroItem[]}
	 */
	public ProzzoroItem[] items;

	/**
	 * The array of supplier.
	 * @type {ProzzoroSupplier[]}
	 */
	public ProzzoroSupplier[] suppliers;

	/**
	 * The number of contracts.
	 * @type {String}
	 */
	public String contractNumber;

	/**
	 * The start and end date for the contract.
	 * @type {ProzzoroPeriod}
	 */
	public ProzzoroPeriod period;

	/**
	 * The date when the contract was signed.
	 * @type {String}
	 */
	public String dateSigned;

	/**
	 * The total value of this contract.
	 * @type {ProzzoroValue}
	 */
	public ProzzoroValue value;

	/**
	 * The date when the contract was changed or activated.
	 * @type {String}
	 */
	public String date;

	/**
	 * The awardId against which this contract is being issued.
	 * @type {String}
	 */
	public String awardID;

	/**
	 * The secondary contract identifiery.
	 * @type {String}
	 */
	public String contractID;

	}

