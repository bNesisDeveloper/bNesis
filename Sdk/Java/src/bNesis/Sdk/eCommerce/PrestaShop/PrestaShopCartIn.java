package bNesis.Sdk.eCommerce.PrestaShop;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class for PrestaShop 'carts'.  Can be used when add new cart for customer. 
 * @typedef {Object} PrestaShopCartIn
 */
public class PrestaShopCartIn
{
	public PrestaShopCartIn(){}
	/**
	 * Customer delivery address identifier.
	 * @type {Integer}
	 */
	public Integer id_address_delivery;

	/**
	 * Customer invoicing address identifier.
	 * @type {Integer}
	 */
	public Integer id_address_invoice;

	/**
	 * Customer currency identifier.
	 * @type {Integer}
	 */
	public Integer id_currency;

	/**
	 * Customer identifier.
	 * @type {Integer}
	 */
	public Integer id_customer;

	/**
	 * Guest identifier.
	 * @type {Integer}
	 */
	public Integer id_guest;

	/**
	 * Language identifier.
	 * @type {Integer}
	 */
	public Integer id_lang;

	/**
	 * Carrier identifier.
	 * @type {Integer}
	 */
	public Integer id_carrier;

	/**
	 * True if the customer wants a recycled package.
	 * @type {Boolean}
	 */
	public Boolean recyclable;

	/**
	 * True if the customer wants a gift wrapping.
	 * @type {Boolean}
	 */
	public Boolean gift;

	/**
	 * Gift message if specified.
	 * @type {String}
	 */
	public String gift_message;

	/**
	 * True if use mobile theme.
	 * @type {Boolean}
	 */
	public Boolean mobile_theme;

	/**
	 * The secure key. (Max:32 characters.)
	 * @type {String}
	 */
	public String secure_key;

	/**
	 * True if allow seperated package.
	 * @type {Boolean}
	 */
	public Boolean allow_seperated_package;

	}

