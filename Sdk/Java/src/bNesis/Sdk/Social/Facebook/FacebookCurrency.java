package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * A currency 
 * @typedef {Object} FacebookCurrency
 */
public class FacebookCurrency
{
	public FacebookCurrency(){}
	/**
	 * Will return a number that describes the number of additional decimal places to include when displaying the person's currency. For example, the API will return 100 because USD is usually displayed with two decimal places.
	 * JPY does not use decimal places, so the API will return 1.
	 * @type {Integer}
	 */
	public Integer currency_offset;

	/**
	 * The exchange rate between the person's preferred currency and US Dollars
	 * @type {Short}
	 */
	public Short usd_exchange;

	/**
	 * The inverse of usd_exchange
	 * @type {Short}
	 */
	public Short usd_exchange_inverse;

	/**
	 * The ISO-4217-3 code for the person's preferred currency (defaulting to USD if the person hasn't set one)
	 * @type {String}
	 */
	public String user_currency;

	}

