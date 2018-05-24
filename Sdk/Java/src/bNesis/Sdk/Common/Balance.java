package bNesis.Sdk.Common;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * bNesis balance class for unified API 
 * @typedef {Object} Balance
 */
public class Balance
{
	public Balance(){}
	/**
	 * currency type flag
	 * @type {String}
	 */
	public String Currency;

	/**
	 * Currency ammount value
	 * @type {Double}
	 */
	public Double Amount;

	}

