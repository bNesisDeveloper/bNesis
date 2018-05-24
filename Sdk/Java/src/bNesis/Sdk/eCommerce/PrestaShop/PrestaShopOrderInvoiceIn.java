package bNesis.Sdk.eCommerce.PrestaShop;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


public class PrestaShopOrderInvoiceIn
{
	public PrestaShopOrderInvoiceIn(){}
	public Integer id_order;

	public Integer number;

	public Integer delivery_number;

	public String delivery_date;

	public Short total_discount_tax_excl;

	public Short total_discount_tax_incl;

	public Short total_paid_tax_excl;

	public Short total_paid_tax_incl;

	public Short total_products;

	public Short total_products_wt;

	public Short total_shipping_tax_excl;

	public Short total_shipping_tax_incl;

	public Short shipping_tax_computation_method;

	public Short total_wrapping_tax_excl;

	public Short total_wrapping_tax_incl;

	public String shop_address;

	public String note;

	public String date_add;

	}

