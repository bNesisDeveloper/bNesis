package bNesis.Sdk.eCommerce.PrestaShop;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation for PrestaShop 'carriers'. Used when need get information about carrier. 
 * @typedef {Object} PrestaShopCarrier
 */
public class PrestaShopCarrier
{
	public PrestaShopCarrier(){}
	/**
	 * The carrier identifier.
	 * @type {Integer}
	 */
	public Integer id;

	/**
	 * True if carrier has been deleted (staying in database as deleted)
	 * @type {Boolean}
	 */
	public Boolean deleted;

	/**
	 * The identifier tax rules group.
	 * @type {Integer}
	 */
	public Integer id_tax_rules_group;

	/**
	 * Common id for carrier historization.
	 * @type {Integer}
	 */
	public Integer id_reference;

	/**
	 * The carrier name.
	 * @type {String}
	 */
	public String name;

	/**
	 * Carrier module.
	 * @type {Boolean}
	 */
	public Boolean is_module;

	/**
	 * Carrier statuts.
	 * @type {Boolean}
	 */
	public Boolean active;

	/**
	 * Free carrier.
	 * @type {Boolean}
	 */
	public Boolean is_free;

	/**
	 * URL with a '@'.
	 * @type {String}
	 */
	public String url;

	/**
	 * Active or not the shipping handling
	 * @type {Integer}
	 */
	public Integer shipping_handling;

	/**
	 * Shipping external.
	 * @type {Integer}
	 */
	public Integer shipping_external;

	/**
	 * Behavior taken for unknown range.
	 * @type {Integer}
	 */
	public Integer range_behavior;

	/**
	 * Shipping behavior: 0 - by weight or 1 - by price.
	 * @type {Integer}
	 */
	public Integer shipping_method;

	/**
	 * The maximum package width managed by the transporter.
	 * @type {Integer}
	 */
	public Integer max_width;

	/**
	 * The maximum package height managed by the transporter.
	 * @type {Integer}
	 */
	public Integer max_height;

	/**
	 * The maximum package deep managed by the transporter.
	 * @type {Integer}
	 */
	public Integer max_depth;

	/**
	 * The maximum package weight managed by the transporter.
	 * @type {Short}
	 */
	public Short max_weight;

	/**
	 * Grade of the shipping delay (0 for longest, 9 for shortest).
	 * @type {Integer}
	 */
	public Integer grade;

	/**
	 * The name of the external module.
	 * @type {String}
	 */
	public String external_module_name;

	/**
	 * Need range.
	 * @type {Integer}
	 */
	public Integer need_range;

	/**
	 * The position.
	 * @type {Integer}
	 */
	public Integer position;

	/**
	 * Delay needed to deliver customer.
	 * @type {String}
	 */
	public String delay;

	}

