package bNesis.Sdk.eCommerce.PrestaShop;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class for PrestaShop 'category'. Can be used when add new category. 
 * @typedef {Object} PrestaShopCategoryIn
 */
public class PrestaShopCategoryIn
{
	public PrestaShopCategoryIn(){}
	/**
	 * The category parent identfier. (Set zero if no parent)
	 * @type {Integer}
	 */
	public Integer id_parent;

	/**
	 * Parents number.
	 * @type {Integer}
	 */
	public Integer level_depth;

	/**
	 * True display category.
	 * @type {Boolean}
	 */
	public Boolean active;

	/**
	 * The identifier default shop.
	 * @type {Integer}
	 */
	public Integer id_shop_default;

	/**
	 * True set category to root.
	 * @type {Boolean}
	 */
	public Boolean is_root_category;

	/**
	 * Category position.
	 * @type {Integer}
	 */
	public Integer position;

	/**
	 * The name of category. (Max: 128 characters.)
	 * @type {String}
	 */
	public String name;

	/**
	 * Used in rewrited URL. (Max: 128 characters.)
	 * @type {String}
	 */
	public String link_rewrite;

	/**
	 * The description of category.
	 * @type {String}
	 */
	public String description;

	/**
	 * The category meta title. (Max: 128 characters.)
	 * @type {String}
	 */
	public String meta_title;

	/**
	 * The category meta description. (Max: 255 characters.)
	 * @type {String}
	 */
	public String meta_description;

	/**
	 * The category meta keywords. (Max: 255 characters.)
	 * @type {String}
	 */
	public String meta_keywords;

	}

