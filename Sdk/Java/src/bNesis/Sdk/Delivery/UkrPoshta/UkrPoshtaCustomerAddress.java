package bNesis.Sdk.Delivery.UkrPoshta;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Customer address 
 * @typedef {Object} UkrPoshtaCustomerAddress
 */
public class UkrPoshtaCustomerAddress
{
	public UkrPoshtaCustomerAddress(){}
	/**
	 * Identificator.
	 * @type {String}
	 */
	public String uuid;

	/**
	 * Address identificator.
	 * @type {Integer}
	 */
	public Integer addressId;

	/**
	 * Type phone number of customer (PHYSICAL, LEGAL).
	 * @type {String}
	 */
	public String type;

	/**
	 * It is address main or not
	 * @type {Boolean}
	 */
	public Boolean main;

	}

