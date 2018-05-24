package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * A payment pricepoint 
 * @typedef {Object} FacebookPaymentPricepoint
	 * @property {Short}  credits - The credits.
	 * @property {String}  local_currency - The local currency.
	 * @property {String}  user_price - The user price.
 */
public class FacebookPaymentPricepoint
{
	public FacebookPaymentPricepoint(){}
	/**
	 * Gets or sets the credits.
	 * @type {Short}
	 */
	public Short credits;

	/**
	 * Gets or sets the local currency.
	 * @type {String}
	 */
	public String local_currency;

	/**
	 * Gets or sets the user price.
	 * @type {String}
	 */
	public String user_price;

	}

