package bNesis.Sdk.eCommerce.PrestaShop;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation for PrestaShop 'orderRow'. 
 * @typedef {Object} PrestaShopOrderRow
 */
public class PrestaShopOrderRow
{
	public PrestaShopOrderRow(){}
	/**
	 * The order row identifier.
	 * @type {Integer}
	 */
	public Integer id;

	/**
	 * The product identifier.
	 * @type {Integer}
	 */
	public Integer product_id;

	/**
	 * The product attribute identifier.
	 * @type {Integer}
	 */
	public Integer product_attribute_id;

	/**
	 * The product quantity.
	 * @type {Integer}
	 */
	public Integer product_quantity;

	/**
	 * The name of the product.
	 * @type {String}
	 */
	public String product_name;

	/**
	 * The product reference.
	 * @type {String}
	 */
	public String product_reference;

	/**
	 * The product ean13.
	 * @type {String}
	 */
	public String product_ean13;

	/**
	 * The product isbn.
	 * @type {String}
	 */
	public String product_isbn;

	/**
	 * The product upc.
	 * @type {String}
	 */
	public String product_upc;

	/**
	 * The product price.
	 * @type {Short}
	 */
	public Short product_price;

	/**
	 * The unit price tax incl.
	 * @type {Short}
	 */
	public Short unit_price_tax_incl;

	/**
	 * The unit price tax excl.
	 * @type {Short}
	 */
	public Short unit_price_tax_excl;

	}

