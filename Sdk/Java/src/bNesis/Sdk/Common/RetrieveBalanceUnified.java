package bNesis.Sdk.Common;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * bNesis balance result unified class 
 * @typedef {Object} RetrieveBalanceUnified
 */
public class RetrieveBalanceUnified
{
	public RetrieveBalanceUnified(){}
	/**
	 * this record Id - define data block at service
	 * @type {String}
	 */
	public String Id;

	/**
	 * Amount value
	 * @type {Double}
	 */
	public Double Amount;

	/**
	 * Currency type flag
	 * @type {String}
	 */
	public String Currency;

	/**
	 * data block (record) creation date time
	 * @type {String}
	 */
	public String Created;

	}

