package bNesis.Sdk.Delivery.UkrPoshta;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Customer E-mail 
 * @typedef {Object} UkrPoshtaCustomerEmail
 */
public class UkrPoshtaCustomerEmail
{
	public UkrPoshtaCustomerEmail(){}
	/**
	 * Identificator.
	 * @type {String}
	 */
	public String uuid;

	/**
	 * E-mail
	 * @type {String}
	 */
	public String email;

	/**
	 * It is e-mail main or not
	 * @type {Boolean}
	 */
	public Boolean main;

	}

