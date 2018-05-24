package bNesis.Sdk.GovRegistry.Prozzoro;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of Value. 
 * @typedef {Object} ProzzoroValue
 */
public class ProzzoroValue
{
	public ProzzoroValue(){}
	/**
	 * The currency in 3-letter ISO 4217 format.
	 * @type {String}
	 */
	public String currency;

	/**
	 * The amount.
	 * @type {Short}
	 */
	public Short amount;

	/**
	 * A value indicating whether value-added tax include.
	 * @type {Boolean}
	 */
	public Boolean valueAddedTaxIncluded;

	}

