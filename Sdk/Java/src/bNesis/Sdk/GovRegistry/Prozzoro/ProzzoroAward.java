package bNesis.Sdk.GovRegistry.Prozzoro;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of Award. Used when need get information about tender award. 
 * @typedef {Object} ProzzoroAward
 */
public class ProzzoroAward
{
	public ProzzoroAward(){}
	/**
	 * The main award identifier.
	 * @type {String}
	 */
	public String id;

	/**
	 * The status.
	 * @type {String}
	 */
	public String status;

	/**
	 * All documents and attachments related to the award, including any notices.
	 * @type {ProzzoroDocument[]}
	 */
	public ProzzoroDocument[] documents;

	/**
	 * The timeframe when complaints can be submitted.
	 * @type {ProzzoroPeriod}
	 */
	public ProzzoroPeriod complaintPeriod;

	/**
	 * The suppliers awarded with this award.
	 * @type {ProzzoroSupplier[]}
	 */
	public ProzzoroSupplier[] suppliers;

	/**
	 * A value indicating whether award is eligible.
	 * true - the award is eligible.false - the award is not eligible.
	 * @type {Boolean}
	 */
	public Boolean eligible;

	/**
	 * The Id of a bid that the award relates to.
	 * @type {String}
	 */
	public String bid_id;

	/**
	 * The total value of this award.
	 * @type {ProzzoroValue}
	 */
	public ProzzoroValue value;

	/**
	 * A value indicating whether the award is qualified.
	 * true - the award is qualified.false - the award is not qualified.
	 * @type {Boolean}
	 */
	public Boolean qualified;

	/**
	 * The date of the contract award.
	 * @type {String}
	 */
	public String date;

	}

