package bNesis.Sdk.eCommerce.PrestaShop;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implemention class for PrestaShop 'configuration'. 
 * @typedef {Object} PrestaShopConfiguration
 */
public class PrestaShopConfiguration
{
	public PrestaShopConfiguration(){}
	public Integer id;

	/**
	 * The value.
	 * @type {String}
	 */
	public String value;

	/**
	 * The name of configuration.
	 * @type {String}
	 */
	public String name;

	/**
	 * The identifier of shop group
	 * @type {Integer}
	 */
	public Integer id_shop_group;

	/**
	 * The identifier of shop.
	 * @type {Integer}
	 */
	public Integer id_shop;

	/**
	 * When added.
	 * @type {String}
	 */
	public String date_add;

	/**
	 * When updated.
	 * @type {String}
	 */
	public String date_upd;

	}

