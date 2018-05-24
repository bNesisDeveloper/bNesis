package bNesis.Sdk.eCommerce.PrestaShop;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


public class PrestaShopOrderSlipIn
{
	public PrestaShopOrderSlipIn(){}
	public Integer id_customer;

	public Integer id_order;

	public Short conversion_rate;

	public Short total_products_tax_excl;

	public Short total_products_tax_incl;

	public Short total_shipping_tax_excl;

	public Short total_shipping_tax_incl;

	public Integer amount;

	public Integer shipping_cost;

	public Integer shipping_cost_amount;

	public Integer partial;

	public String date_add;

	public String date_upd;

	public Integer order_slip_type;

	}

