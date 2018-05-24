package bNesis.Sdk.Payment.Stripe;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


public class StripeBalanceItemOut
{
	public StripeBalanceItemOut(){}
	public String objectStripe;

	public StripeAvailable[] available;

	public StripeConnect_reserved[] connect_reserved;

	public Boolean livemode;

	public StripeSource_types[] pending;

	}

