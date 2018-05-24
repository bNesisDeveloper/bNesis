package bNesis.Sdk.eCommerce.Shopify;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Shopify customer item 
 * @typedef {Object} ShopifyProductItemOut
 */
public class ShopifyProductItemOut
{
	public ShopifyProductItemOut(){}
	public Date updated_at;

	public String vendor;

	public String product_type;

	public Date published_at;

	public String published_scope;

	public Boolean published;

	public String tags;

	public String template_suffix;

	public String title;

	public String metafields_global_description_tag;

	public String metafields_global_title_tag;

	public String body_html;

	public Date created_at;

	public String handle;

	public String id;

	public ShopifyImage image;

	public ShopifyImage[] images;

	public ShopifyMetafields[] metafields;

	public ShopifyOptions[] options;

	public ShopifyVariants[] variants;

	}

