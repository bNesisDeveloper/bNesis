package bNesis.Sdk.eCommerce.PrestaShop;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation for PrestaShop rendering options. 
 * @typedef {Object} PrestaShopRenderingOptions
 */
public class PrestaShopRenderingOptions
{
	public PrestaShopRenderingOptions(){}
	/**
	 * Gets or sets the display.
	 * @type {String}
	 */
	public String Display;

	/**
	 * Gets or sets the filter.
	 * @type {PrestaShopFilter[]}
	 */
	public PrestaShopFilter[] Filter;

	}

