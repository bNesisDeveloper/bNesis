package bNesis.Sdk.eCommerce.Shopify;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Shopify customer item 
 * @typedef {Object} ShopifyCustomerItemIn
 */
public class ShopifyCustomerItemIn
{
	public ShopifyCustomerItemIn(){}
	/**
	 * customet id
	 * @type {Integer}
	 */
	public Integer id;

	/**
	 * customer email
	 * @type {String}
	 */
	public String email;

	public Boolean accepts_marketing;

	public Date created_at;

	public Date updated_at;

	public String first_name;

	public String last_name;

	public Integer orders_count;

	public String state;

	public String total_spent;

	public Integer last_order_id;

	public String note;

	public Boolean verified_email;

	public String multipass_identifier;

	public Boolean tax_exempt;

	public String phone;

	public String tags;

	public String last_order_name;

	public ShopifyAddressIn[] addresses;

	public String password;

	public String password_confirmation;

	public Boolean send_email_invite;

	public Boolean send_email_welcome;

	public ShopifyMetafields[] metafields;

	}

