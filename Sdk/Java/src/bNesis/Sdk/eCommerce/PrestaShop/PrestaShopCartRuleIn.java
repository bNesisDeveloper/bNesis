package bNesis.Sdk.eCommerce.PrestaShop;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class for PrestaShop 'cart rules'. Can be used when add new cart rule (voucher). 
 * @typedef {Object} PrestaShopCartRuleIn
 */
public class PrestaShopCartRuleIn
{
	public PrestaShopCartRuleIn(){}
	/**
	 * The name of cart rule.
	 * @type {String}
	 */
	public String name;

	/**
	 * The customer identifier. (Limit for single customer, set zero if doesn't need.)
	 * @type {Integer}
	 */
	public Integer id_customer;

	/**
	 * When cart rule is valid from date. (Format: Y-m-d 00:00:00)
	 * @type {String}
	 */
	public String date_from;

	/**
	 * When cart rule is valid to date. (Format: Y-m-d 00:00:00)
	 * @type {String}
	 */
	public String date_to;

	/**
	 * Description about cart rule. (Max:65534 characters.)
	 * @type {String}
	 */
	public String description;

	/**
	 * The count of avaibles voucher for customer.
	 * @type {Integer}
	 */
	public Integer quantity;

	/**
	 * The count of avaibles voucher for every customer.
	 * @type {Integer}
	 */
	public Integer quantity_per_user;

	/**
	 * If applied higher number, the voucher will applied after vouchers with lower number.
	 * @type {Integer}
	 */
	public Integer priority;

	/**
	 * If true voucher can be used once.
	 * @type {Boolean}
	 */
	public Boolean partial_use;

	/**
	 * The code for applying the voucher to customers when ordering process. (Max:254 characters.)
	 * @type {String}
	 */
	public String code;

	/**
	 * The minimum order amount(with tax included) from which voucher is applicable.
	 * @type {Short}
	 */
	public Short minimum_amount;

	/**
	 * If true, tax will included.
	 * @type {Boolean}
	 */
	public Boolean minimum_amount_tax;

	/**
	 * The currency identifier.
	 * @type {Integer}
	 */
	public Integer minimum_amount_currency;

	/**
	 * If true, the shipping will used.
	 * @type {Boolean}
	 */
	public Boolean minimum_amount_shipping;

	/**
	 * If true voucher applicable to customers from a specific country who not restricted.
	 * @type {Boolean}
	 */
	public Boolean country_restriction;

	/**
	 * If true voucher applicable for a specific carrier who not restricted.
	 * @type {Boolean}
	 */
	public Boolean carrier_restriction;

	/**
	 * If true voucher applicable to customers with a specific group who not restricted.
	 * @type {Boolean}
	 */
	public Boolean group_restriction;

	/**
	 * If true voucher applicable for a specific cart rule who not restricted.
	 * @type {Boolean}
	 */
	public Boolean cart_rule_restriction;

	/**
	 * If true voucher applicable for a specific product who not restricted.
	 * @type {Boolean}
	 */
	public Boolean product_restriction;

	/**
	 * If true voucher applicable for a specific shop who not restricted.
	 * @type {Boolean}
	 */
	public Boolean shop_restriction;

	/**
	 * If true, free shipping for benefiting customers.
	 * @type {Boolean}
	 */
	public Boolean free_shipping;

	/**
	 * A percentage of the order total.
	 * @type {Short}
	 */
	public Short reduction_percent;

	/**
	 * A monetary discount on the order total.
	 * @type {Short}
	 */
	public Short reduction_amount;

	/**
	 * If true, will tax will included.
	 * @type {Boolean}
	 */
	public Boolean reduction_tax;

	/**
	 * The currency identifier.
	 * @type {Integer}
	 */
	public Integer reduction_currency;

	/**
	 * The product identifier for which apply reduction.
	 * @type {Integer}
	 */
	public Integer reduction_product;

	/**
	 * If true, exclude special reduction.
	 * @type {Boolean}
	 */
	public Boolean reduction_exclude_special;

	/**
	 * The product identifier.
	 * @type {Integer}
	 */
	public Integer gift_product;

	/**
	 * The product attribute identifier.
	 * @type {Integer}
	 */
	public Integer gift_product_attribute;

	/**
	 * If true, it will let the user know that a voucher is available.
	 * @type {Boolean}
	 */
	public Boolean highlight;

	/**
	 * True activate cart rule.
	 * @type {Boolean}
	 */
	public Boolean active;

	}

