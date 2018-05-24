package bNesis.Sdk.Delivery.UkrPoshta;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * CustomerOut used when get information about customer. 
 * @typedef {Object} UkrPoshtaCustomerOut
 */
public class UkrPoshtaCustomerOut
{
	public UkrPoshtaCustomerOut(){}
	/**
	 * Identificator.
	 * @type {String}
	 */
	public String uuid;

	/**
	 * Name of customer, formated from parameters: firstName, middleName, lastName.
	 * @type {String}
	 */
	public String name;

	/**
	 * First name of customer.
	 * @type {String}
	 */
	public String firstName;

	/**
	 * Middle name of customer.
	 * @type {String}
	 */
	public String middleName;

	/**
	 * Last name of customer.
	 * @type {String}
	 */
	public String lastName;

	/**
	 * Name of customer, formated from parameters: firstNameEn, lastNameEn.
	 * @type {String}
	 */
	public String nameEn;

	/**
	 * First name an english of customer.
	 * @type {String}
	 */
	public String firstNameEn;

	/**
	 * Last name an english of customer.
	 * @type {String}
	 */
	public String lastNameEn;

	/**
	 * Unique customer ID provided by "Ukrposhta".
	 * @type {String}
	 */
	public String postId;

	/**
	 * External Customer ID in counterparty base.
	 * @type {String}
	 */
	public String externalId;

	/**
	 * Unique reqistration number.
	 * @type {String}
	 */
	public String uniqueRegistrationNumber;

	/**
	 * Counterparty identificator.
	 * @type {String}
	 */
	public String counterpartyUuid;

	/**
	 * Address ID, indicates the Id of the pre-created address.
	 * @type {Integer}
	 */
	public Integer addressId;

	/**
	 * If the customer has specified multiple addresses, it will be used only the one with 'main' setted true.
	 * @type {UkrPoshtaCustomerAddress[]}
	 */
	public UkrPoshtaCustomerAddress[] addresses;

	/**
	 * Phone number of customer.
	 * @type {String}
	 */
	public String phoneNumber;

	/**
	 * If the customer has specified multiple phones, it will be used only the one with 'main' setted true.
	 * @type {UkrPoshtaCustomerPhone[]}
	 */
	public UkrPoshtaCustomerPhone[] phones;

	/**
	 * E-mail customer.
	 * @type {String}
	 */
	public String email;

	/**
	 * If the customer has specified multiple emails, it will be used only the one with 'main' setted true.
	 * @type {UkrPoshtaCustomerEmail[]}
	 */
	public UkrPoshtaCustomerEmail[] emails;

	/**
	 * A variable that indicates whether the customer is a entity or an individual.
	 * @type {Boolean}
	 */
	public Boolean individual;

	/**
	 * EDRPOU entity.
	 * @type {String}
	 */
	public String edrpou;

	/**
	 * Bank Code.
	 * @type {String}
	 */
	public String bankCode;

	/**
	 * Recipient account.
	 * @type {String}
	 */
	public String bankAccount;

	/**
	 * Individual tax number for entities.
	 * @type {String}
	 */
	public String tin;

	/**
	 * Contact name.
	 * @type {String}
	 */
	public String contactPersonName;

	/**
	 * Resident of Ukraine. If resident is true, customer is a resident of Ukraine.
	 * @type {Boolean}
	 */
	public Boolean resident;

	}

