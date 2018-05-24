package bNesis.Sdk.eCommerce.PrestaShop;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class for PrestaShop 'combination'. Used when get information about combination. 
 * @typedef {Object} PrestaShopCombination
 */
public class PrestaShopCombination
{
	public PrestaShopCombination(){}
	/**
	 * The combination identifier.
	 * @type {Integer}
	 */
	public Integer id;

	/**
	 * The product identifier. (Required)
	 * @type {Integer}
	 */
	public Integer id_product;

	/**
	 * The location. (Max: 64 characters.)
	 * @type {String}
	 */
	public String location;

	/**
	 * The ean13 product code. (Max: 13 characters.)
	 * @type {String}
	 */
	public String ean13;

	/**
	 * The isbn product code. (Max: 32 characters.)
	 * @type {String}
	 */
	public String isbn;

	/**
	 * The upc product code. (Max: 12 characters.)
	 * @type {String}
	 */
	public String upc;

	/**
	 * The reference to product. (Max: 32 characters.)
	 * @type {String}
	 */
	public String reference;

	/**
	 * The reference to supplier. (Max: 32 characters.)
	 * @type {String}
	 */
	public String supplier_reference;

	/**
	 * The wholesale price.(Max: 27 characters.)
	 * @type {Short}
	 */
	public Short wholesale_price;

	/**
	 * The product price.(Max: 20 characters.)
	 * @type {Short}
	 */
	public Short price;

	/**
	 * The eco-tax.(Max: 20 characters.)
	 * @type {Short}
	 */
	public Short ecotax;

	/**
	 * Product weight.
	 * @type {Short}
	 */
	public Short weight;

	/**
	 * Unit price impact. (Max: 20 characters.)
	 * @type {Short}
	 */
	public Short unit_price_impact;

	/**
	 * The minimal quantity. (Required)
	 * @type {Integer}
	 */
	public Integer minimal_quantity;

	/**
	 * True combination default on.
	 * @type {Boolean}
	 */
	public Boolean default_on;

	/**
	 * When product avaible. (Format: Y-m-d)
	 * @type {String}
	 */
	public String available_date;

	/**
	 * The product which is associated with the category.
	 * @type {PrestaShopAssociations}
	 */
	public PrestaShopAssociations associations;

	}

