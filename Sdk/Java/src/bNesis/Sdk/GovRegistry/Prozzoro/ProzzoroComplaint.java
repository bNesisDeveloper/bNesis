package bNesis.Sdk.GovRegistry.Prozzoro;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of Complain. Used when need get information about tender complaint. 
 * @typedef {Object} ProzzoroComplaint
 */
public class ProzzoroComplaint
{
	public ProzzoroComplaint(){}
	/**
	 * The main complain identifier.
	 * @type {String}
	 */
	public String id;

	/**
	 * The complain status.
	 *  Possible values are:
	 *  draft, claim, answered, pending, invalid, declined, resolved, cancelled
	 * @type {String}
	 */
	public String status;

	/**
	 * The array of document.
	 * @type {ProzzoroDocument[]}
	 */
	public ProzzoroDocument[] documents;

	/**
	 * Description of the issue.
	 * @type {String}
	 */
	public String description;

	/**
	 * Organization filing a complaint.
	 * @type {ProzzoroOrganization}
	 */
	public ProzzoroOrganization author;

	/**
	 * The resotion type.
	 * Possible values of resolution type are:
	 * invalid,declined,resolved
	 * @type {String}
	 */
	public String resolutionType;

	/**
	 * Resolution of Procuring entity.
	 * @type {String}
	 */
	public String resolution;

	/**
	 * Title of the complaint.
	 * @type {String}
	 */
	public String title;

	/**
	 * Date when Procuring entity answered the claim.
	 * @type {String}
	 */
	public String dateAnswered;

	/**
	 * Date of claim to complaint escalation.
	 * @type {String}
	 */
	public String dateEscalated;

	/**
	 * Date of complaint decision.
	 * @type {String}
	 */
	public String dateDecision;

	/**
	 * Date of cancelling.
	 * @type {String}
	 */
	public String dateCanceled;

	/**
	 * Date when claim was submitted.
	 * @type {String}
	 */
	public String dateSubmitted;

	/**
	 * The secondary complaint identifier.
	 * @type {String}
	 */
	public String complaintID;

	/**
	 * Date of posting.
	 * @type {String}
	 */
	public String date;

	/**
	 * The complaint type.
	 *   Possible values of type are:
	 *  claim, complaint.
	 * @type {String}
	 */
	public String type;

	}

