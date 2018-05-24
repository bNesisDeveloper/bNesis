package bNesis.Sdk.Payment.Stripe;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


public class RetrieveBalance
{
	public RetrieveBalance(){}
	public String id;

	public String objectStripe;

	public Double amount;

	public String available_on;

	public String created;

	public String currency;

	public String description;

	public Double fee;

	public StripeFee_details[] fee_details;

	public String net;

	public String source;

	public String status;

	public String type;

	}

