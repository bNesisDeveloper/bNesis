package bNesis.Sdk.GovRegistry.Prozzoro;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of Item. 
 * @typedef {Object} ProzzoroItem
 */
public class ProzzoroItem
{
	public ProzzoroItem(){}
	/**
	 * The item identifier.
	 * @type {String}
	 */
	public String id;

	/**
	 * The description about item.
	 * @type {String}
	 */
	public String description;

	/**
	 * The item classfication.
	 * @type {ProzzoroClassification}
	 */
	public ProzzoroClassification classification;

	/**
	 * The array of item additional classification.
	 * @type {ProzzoroClassification[]}
	 */
	public ProzzoroClassification[] additionalClassifications;

	/**
	 * The customer address.
	 * @type {ProzzoroAddress}
	 */
	public ProzzoroAddress deliveryAddress;

	/**
	 * The delivery date.
	 * @type {ProzzoroPeriod}
	 */
	public ProzzoroPeriod deliveryDate;

	/**
	 * The unit.
	 * @type {ProzzoroUnit}
	 */
	public ProzzoroUnit unit;

	/**
	 * The quantity.
	 * @type {Integer}
	 */
	public Integer quantity;

	}

