package bNesis.Sdk.Delivery.UkrPoshta;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * CustomerIn used when add or edit customer.
 *     If the customer is an individual, the value of the individual should be true. In this case, you must specify the first name, last name and middle name (in parameters: firstName, lastName and middleName) of the customer. The 'name' parameter is generated automatically. If the customer is a entity, the value of the individual must be false. In this case, the API accepts only the 'name' parameter. 
 * @typedef {Object} UkrPoshtaCustomerIn
 */
public class UkrPoshtaCustomerIn
{
	public UkrPoshtaCustomerIn(){}
	/**
	 * Name of the customer. (Maximum number of characters 250, is mandatory for a entity, for an individual is formed from the parameters: firstName, middleName, lastName)
	 * @type {String}
	 */
	public String name;

	/**
	 * First name of the individual. (Maximum number of characters is 250, the minimum 2)
	 * @type {String}
	 */
	public String firstName;

	/**
	 * Middle name of an individual. (the maximum number of characters is 250, the minimum is 2)
	 * @type {String}
	 */
	public String middleName;

	/**
	 * Last name of an individual. (the maximum number of characters is 250, the minimum is 2)
	 * @type {String}
	 */
	public String lastName;

	/**
	 * External Customer ID in the counterparty's base.
	 * @type {String}
	 */
	public String externalId;

	/**
	 * Unique registration number.
	 * @type {String}
	 */
	public String uniqueRegistrationNumber;

	/**
	 * Address ID, indicates the Id of the pre-created address.
	 * @type {Integer}
	 */
	public Integer addressId;

	/**
	 * Customer phone number (only numbers, maximum 25 characters)
	 * @type {String}
	 */
	public String phoneNumber;

	/**
	 * E-mail customer
	 * @type {String}
	 */
	public String email;

	/**
	 * A variable that indicates whether the customer is entity or an individual. The entity of the individual must be-false, in physical-true. (Can not be changed after creation)
	 * @type {Boolean}
	 */
	public Boolean individual;

	/**
	 * EDRPOU entity (only numbers 5-8 characters). Only the valid EDRPOU can be saved. 
	 *  Before the creation is validated according to the algorithm:Site with algorithm validation 'http://1cinfo.com.ua/Articles/Proverka_koda_po_EDRPOU.aspx'.
	 * @type {String}
	 */
	public String edrpou;

	/**
	 * Bank Code.(Only numbers, maximum characters 6)
	 * @type {String}
	 */
	public String bankCode;

	/**
	 * Recipient account.(Only numbers, maximum characters 14)
	 * @type {String}
	 */
	public String bankAccount;

	/**
	 * Individual tax number for entities. (Only numbers, maximum characters 32)
	 * @type {String}
	 */
	public String tin;

	/**
	 * Contact name.
	 * @type {String}
	 */
	public String contactPersonName;

	/**
	 * Resident of Ukraine. If resident is true, customer is a resident of Ukraine. By default, when creating a resident, it is true.
	 * @type {Boolean}
	 */
	public Boolean resident;

	}

