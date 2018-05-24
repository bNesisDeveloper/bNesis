package bNesis.Sdk.Common;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * bNesis unified contact item for services unified API call 
 * @typedef {Object} ContactItem
 */
public class ContactItem
{
	public ContactItem(){}
	/**
	 * contact address at free format - just string
	 * @type {String}
	 */
	public String Address;

	/**
	 * contact email, is class is not check are the email typed at right email format
	 * @type {String}
	 */
	public String Email;

	/**
	 * contact data block (record) Id - is unical for all service contact
	 * @type {String}
	 */
	public String Id;

	/**
	 * this is test property for formalised Address - street, home, post code
	 * @type {AddressTest}
	 */
	public AddressTest AddressTestProp;

	/**
	 * Contact name - it maybe single name or FNAMEspaceLNAME
	 * @type {String}
	 */
	public String Name;

	/**
	 * contact phone at free format, this class is not checkid it
	 * @type {String}
	 */
	public String Phone;

	}

