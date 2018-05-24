package bNesis.Sdk.eCommerce.PrestaShop;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


public class PrestaShopOrder
{
	public PrestaShopOrder(){}
	public Integer id;

	public Integer id_address_delivery;

	public Integer id_address_invoice;

	public Integer id_cart;

	public Integer id_currency;

	public Integer id_lang;

	public Integer id_customer;

	public Integer id_carrier;

	public Integer current_state;

	public String module;

	public Integer invoice_number;

	public String invoice_date;

	public Integer delivery_number;

	public String delivery_date;

	public Boolean valid;

	public String date_add;

	public String date_upd;

	public String shipping_number;

	public Integer id_shop_group;

	public Integer id_shop;

	public String secure_key;

	public String payment;

	public Boolean recyclable;

	public Boolean gift;

	public String gift_message;

	public Boolean mobile_theme;

	public Short total_discounts;

	public Short total_discounts_tax_incl;

	public Short total_discounts_tax_excl;

	public Short total_paid;

	public Short total_paid_tax_incl;

	public Short total_paid_tax_excl;

	public Short total_paid_real;

	public Short total_products;

	public Short total_products_wt;

	public Short total_shipping;

	public Short total_shipping_tax_incl;

	public Short total_shipping_tax_excl;

	public Short carrier_tax_rate;

	public Short total_wrapping;

	public Short total_wrapping_tax_incl;

	public Short total_wrapping_tax_excl;

	public Integer round_mode;

	public Integer round_type;

	public Short conversion_rate;

	public String reference;

	public PrestaShopAssociations associations;

	}

