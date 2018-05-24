package bNesis.Sdk.Delivery.UkrPoshta;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Customer phone. 
 * @typedef {Object} UkrPoshtaCustomerPhone
 */
public class UkrPoshtaCustomerPhone
{
	public UkrPoshtaCustomerPhone(){}
	/**
	 * Identificator.
	 * @type {String}
	 */
	public String uuid;

	/**
	 * Phone number.
	 * @type {String}
	 */
	public String phoneNumber;

	/**
	 * Type phone number of customer (WORK, PERSONAL).
	 * @type {String}
	 */
	public String type;

	/**
	 * It is phone number main or not
	 * @type {Boolean}
	 */
	public Boolean main;

	}

