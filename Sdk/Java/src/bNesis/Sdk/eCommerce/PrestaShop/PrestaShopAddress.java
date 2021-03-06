package bNesis.Sdk.eCommerce.PrestaShop;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class for PrestaShop 'address'. Used when need get information about address. 
 * @typedef {Object} PrestaShopAddress
 */
public class PrestaShopAddress
{
	public PrestaShopAddress(){}
	/**
	 * The address identifier.
	 * @type {Integer}
	 */
	public Integer id;

	/**
	 * The identifier manufacturer wich belongs to.
	 * @type {Integer}
	 */
	public Integer id_manufacturer;

	/**
	 * The identifier supplier wich belongs to.
	 * @type {Integer}
	 */
	public Integer id_supplier;

	/**
	 * The identifier warehouse wich belongs to.
	 * @type {Integer}
	 */
	public Integer id_warehouse;

	/**
	 * The identifier country wich belongs to.
	 * @type {Integer}
	 */
	public Integer id_country;

	/**
	 * The identifier state wich belongs to.
	 * @type {Integer}
	 */
	public Integer id_state;

	/**
	 * The alias. (eg. Home, Work...)
	 * @type {String}
	 */
	public String alias;

	/**
	 * The company. (Optional)
	 * @type {String}
	 */
	public String company;

	/**
	 * The last name.
	 * @type {String}
	 */
	public String lastname;

	/**
	 * The first name.
	 * @type {String}
	 */
	public String firstname;

	/**
	 * The vat number.
	 * @type {String}
	 */
	public String vat_number;

	/**
	 * The first address.
	 * @type {String}
	 */
	public String address1;

	/**
	 * The second address. (Optional)
	 * @type {String}
	 */
	public String address2;

	/**
	 * The postal code.
	 * @type {Integer}
	 */
	public Integer postcode;

	/**
	 * The city name.
	 * @type {String}
	 */
	public String city;

	/**
	 * Other useful information.
	 * @type {String}
	 */
	public String other;

	/**
	 * The phone number.
	 * @type {String}
	 */
	public String phone;

	/**
	 * The mobile phone number.
	 * @type {String}
	 */
	public String phone_mobile;

	/**
	 * The dni number.
	 * @type {String}
	 */
	public String dni;

	/**
	 * True if address has been deleted (staying in database as deleted).
	 * @type {Boolean}
	 */
	public Boolean deleted;

	/**
	 * When address was added.
	 * @type {String}
	 */
	public String date_add;

	/**
	 * When address was updated.
	 * @type {String}
	 */
	public String date_upd;

	}

