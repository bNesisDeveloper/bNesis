package bNesis.Sdk.eCommerce.Shopify;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


public class ShopifyCustomerItemOut
{
	public ShopifyCustomerItemOut(){}
	public Long id;

	public String email;

	public Boolean accepts_marketing;

	public Date created_at;

	public Date updated_at;

	public String first_name;

	public String last_name;

	public Long orders_count;

	public String state;

	public String total_spent;

	public Long last_order_id;

	public String note;

	public Boolean verified_email;

	public String multipass_identifier;

	public Boolean tax_exempt;

	public String phone;

	public String tags;

	public String last_order_name;

	public ShopifyAddressOut[] addresses;

	public ShopifyAddressOut default_address;

	}

