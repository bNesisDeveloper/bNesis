package bNesis.Sdk.eCommerce.PrestaShop;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation for PrestaShop 'associations'. 
 * @typedef {Object} PrestaShopAssociations
 */
public class PrestaShopAssociations
{
	public PrestaShopAssociations(){}
	/**
	 * The array of identifier for categories.
	 * @type {PrestaShopIdentifier[]}
	 */
	public PrestaShopIdentifier[] categories;

	/**
	 * The array of identifier for groups.
	 * @type {PrestaShopIdentifier[]}
	 */
	public PrestaShopIdentifier[] groups;

	/**
	 * The array of identifier for product option values.
	 * @type {PrestaShopIdentifier[]}
	 */
	public PrestaShopIdentifier[] product_option_values;

	/**
	 * The array of identifier for images.
	 * @type {PrestaShopIdentifier[]}
	 */
	public PrestaShopIdentifier[] images;

	/**
	 * The array of identifier for customer messages.
	 * @type {PrestaShopIdentifier[]}
	 */
	public PrestaShopIdentifier[] customer_messages;

	/**
	 * The array of identifier for addresses.
	 * @type {PrestaShopIdentifier[]}
	 */
	public PrestaShopIdentifier[] addresses;

	/**
	 * The array of identifier for combinations.
	 * @type {PrestaShopIdentifier[]}
	 */
	public PrestaShopIdentifier[] combinations;

	/**
	 * The array of identifier for order rows.
	 * @type {PrestaShopOrderRow[]}
	 */
	public PrestaShopOrderRow[] order_rows;

	/**
	 * The array of identifier for product features.
	 * @type {PrestaShopIdentifier[]}
	 */
	public PrestaShopIdentifier[] product_features;

	/**
	 * The array of identifier for stock avaibles.
	 * @type {PrestaShopIdentifier[]}
	 */
	public PrestaShopIdentifier[] stock_avaibles;

	}

