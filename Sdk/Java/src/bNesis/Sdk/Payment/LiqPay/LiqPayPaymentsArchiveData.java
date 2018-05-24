package bNesis.Sdk.Payment.LiqPay;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


public class LiqPayPaymentsArchiveData
{
	public LiqPayPaymentsArchiveData(){}
	public String action;

	public Long payment_id;

	public String status;

	public Double version;

	public String type;

	public String public_key;

	public Long acq_id;

	public String order_id;

	public String liqpay_order_id;

	public String description;

	public String sender_phone;

	public String sender_first_name;

	public String sender_last_name;

	public String sender_card_mask2;

	public String sender_card_bank;

	public String sender_card_type;

	public Integer sender_card_country;

	public Double amount;

	public String currency;

	public Double sender_commission;

	public Double receiver_commission;

	public Double agent_commission;

	public Double amount_debit;

	public Double amount_credit;

	public Double commission_debit;

	public Double commission_credit;

	public String currency_debit;

	public String currency_credit;

	public Double sender_bonus;

	public Double amount_bonus;

	public Long authcode_debit;

	public Long authcode_credit;

	public Long rrn_debit;

	public Long rrn_credit;

	public Integer mpi_eci;

	public Boolean is_3ds;

	public Long create_date;

	public Long end_date;

	public Long transaction_id;

	}

