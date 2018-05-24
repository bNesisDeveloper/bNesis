package bNesis.Sdk.GovRegistry.Prozzoro;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of Tender. 
 * @typedef {Object} ProzzoroTender
 */
public class ProzzoroTender
{
	public ProzzoroTender(){}
	/**
	 * The main tender identifier.
	 * @type {String}
	 */
	public String id;

	/**
	 * The procurement method.
	 * @type {String}
	 */
	public String procurementMethod;

	/**
	 * The number of bid.
	 * @type {Integer}
	 */
	public Integer numberOfBids;

	/**
	 * The  awarding process period.
	 * @type {ProzzoroPeriod}
	 */
	public ProzzoroPeriod awardPeriod;

	/**
	 * The complaint period.
	 * @type {ProzzoroPeriod}
	 */
	public ProzzoroPeriod complaintPeriod;

	/**
	 * The auction URL.
	 * @type {String}
	 */
	public String auctionUrl;

	/**
	 * The period when questions are allowed. At least endDate has to be provided.
	 * @type {ProzzoroPeriod}
	 */
	public ProzzoroPeriod enquiryPeriod;

	/**
	 * The submission method.
	 * @type {String}
	 */
	public String submissionMethod;

	/**
	 * The organization conducting the tender.
	 * @type {ProcuringEntity}
	 */
	public ProcuringEntity procuringEntity;

	/**
	 * The owner of tender.
	 * @type {String}
	 */
	public String owner;

	/**
	 * The description about tender.
	 * @type {String}
	 */
	public String description;

	/**
	 * All documents and attachments related to the tender.
	 * @type {ProzzoroDocument[]}
	 */
	public ProzzoroDocument[] document;

	/**
	 * Complaints to tender conditions and their resolutions.
	 * @type {ProzzoroComplaint[]}
	 */
	public ProzzoroComplaint[] complaints;

	/**
	 * Can contain all tender lots.
	 * @type {ProzzoroLot[]}
	 */
	public ProzzoroLot[] lots;

	/**
	 * The name of the tender.
	 * @type {String}
	 */
	public String title;

	/**
	 * The tender identifier to refer tender to in "paper" documentation.
	 * @type {String}
	 */
	public String tenderID;

	/**
	 * The bid guarantee.
	 * @type {ProzzoroGuarantee}
	 */
	public ProzzoroGuarantee guarantee;

	/**
	 * Date modified when tender was modified.
	 * @type {String}
	 */
	public String dateModified;

	/**
	 * The status of the tender.
	 *  Here is some value can be returned:
	 *  active.enquiries:Enquiries period(enquiries)
	 *  active.tendering: Tendering period(tendering)
	 *  active.auction:	Auction period(auction)
	 *  active.qualification: Winner qualification(qualification)
	 *  active.awarded:	Standstill period (standstill)
	 *  unsuccessful:	Unsuccessful tender(unsuccessful)
	 *  complete:	Complete tender(complete)
	 *  cancelled:	Cancelled tender(cancelled)
	 * @type {String}
	 */
	public String status;

	/**
	 * Period when bids can be submitted. At least endDate has to be provided.
	 * @type {ProzzoroPeriod}
	 */
	public ProzzoroPeriod tenderPeriod;

	/**
	 * Period when auction is conducted.
	 * @type {ProzzoroPeriod}
	 */
	public ProzzoroPeriod auctionPeriod;

	/**
	 * The type of the procurement method.
	 * @type {String}
	 */
	public String procurementMethodType;

	/**
	 * The all qualifications (disqualifications and awards)..
	 * @type {ProzzoroAward[]}
	 */
	public ProzzoroAward[] awards;

	/**
	 * The date.
	 * @type {String}
	 */
	public String date;

	/**
	 * The minimal step of auction (reduction).
	 * @type {ProzzoroValue}
	 */
	public ProzzoroValue minimalStep;

	/**
	 * The list that contains single item being procured.
	 * @type {ProzzoroItem[]}
	 */
	public ProzzoroItem[] items;

	/**
	 * A list of all bid placed in the tender with information about tenderers, 
	 * their proposal and other qualification documentation.
	 * @type {ProzzoroBid[]}
	 */
	public ProzzoroBid[] bids;

	/**
	 * The array of contract.
	 * @type {ProzzoroContract[]}
	 */
	public ProzzoroContract[] contracts;

	/**
	 * The Cancellation object describes the reason of tender cancellation contains accompanying documents if any.
	 * @type {ProzzoroCancellation[]}
	 */
	public ProzzoroCancellation[] cancellations;

	/**
	 * The total available tender budget.
	 * @type {ProzzoroValue}
	 */
	public ProzzoroValue budget;

	/**
	 * The award criteria.
	 * @type {String}
	 */
	public String awardCriteria;

	}

