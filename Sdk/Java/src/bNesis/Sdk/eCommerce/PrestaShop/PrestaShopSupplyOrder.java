package bNesis.Sdk.eCommerce.PrestaShop;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


public class PrestaShopSupplyOrder
{
	public PrestaShopSupplyOrder(){}
	public Integer id;

	public Integer id_supplier;

	public String supplier_name;

	public Integer id_lang;

	public Integer id_warehouse;

	public Integer id_supply_order_state;

	public Integer id_currency;

	public Integer id_ref_currency;

	public String reference;

	public String date_add;

	public String date_upd;

	public String date_delivery_expected;

	public Short total_te;

	public Short total_with_discount_te;

	public Short total_ti;

	public Short total_tax;

	public Short discount_rate;

	public Short discount_value_te;

	public Boolean is_template;

	}

