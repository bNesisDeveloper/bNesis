package bNesis.Sdk.eCommerce.Shopify;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Shopify customer item 
 * @typedef {Object} ShopifyCountryItemOut
 */
public class ShopifyCountryItemOut
{
	public ShopifyCountryItemOut(){}
	public String code;

	public Long id;

	public String name;

	public ShopifyProvinces[] provinces;

	public Double tax;

	public String tax_name;

	}

