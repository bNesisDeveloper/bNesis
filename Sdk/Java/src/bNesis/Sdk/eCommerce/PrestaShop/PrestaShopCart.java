package bNesis.Sdk.eCommerce.PrestaShop;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class for PrestaShop 'cart'. Used when need get information about customer cart. 
 * @typedef {Object} PrestaShopCart
 */
public class PrestaShopCart
{
	public PrestaShopCart(){}
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
	 * The shop group identifier.
	 * @type {Integer}
	 */
	public Integer id_shop_group;

	/**
	 * The shop identifier.
	 * @type {Integer}
	 */
	public Integer id_shop;

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

	/**
	 * The delivery option.
	 * @type {String}
	 */
	public String delivery_option;

	/**
	 * When cart added.
	 * @type {String}
	 */
	public String date_add;

	/**
	 * When cart updated.
	 * @type {String}
	 */
	public String date_upd;

	}

