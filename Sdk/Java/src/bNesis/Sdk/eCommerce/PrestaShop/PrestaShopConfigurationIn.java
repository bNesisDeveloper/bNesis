package bNesis.Sdk.eCommerce.PrestaShop;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implemention class for PrestaShop 'configuration'. Can be used when add new configuration. 
 * @typedef {Object} PrestaShopConfigurationIn
 */
public class PrestaShopConfigurationIn
{
	public PrestaShopConfigurationIn(){}
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

	}

