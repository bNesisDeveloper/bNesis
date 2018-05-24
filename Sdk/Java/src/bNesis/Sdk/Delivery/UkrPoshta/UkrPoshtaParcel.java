package bNesis.Sdk.Delivery.UkrPoshta;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Parameters of the parcel. 
 *     When creating a parcel, you need to specify the main fields: weight - the maximum weight of sending 30000 grams. Weight of departure must be greater than zero.length - largest side of the departure, indicates the length in inches, length of departure must be greater than zero.declaredPrice - The stated price is sending filled in UAH 
 * @typedef {Object} UkrPoshtaParcel
 */
public class UkrPoshtaParcel
{
	public UkrPoshtaParcel(){}
	/**
	 * Shipping weight.
	 * @type {Integer}
	 */
	public Integer weight;

	/**
	 * Shipping length.
	 * @type {Integer}
	 */
	public Integer length;

	/**
	 * Shipping width.
	 * @type {Integer}
	 */
	public Integer width;

	/**
	 * Shipping height.
	 * @type {Integer}
	 */
	public Integer height;

	/**
	 * Shipping declared price.
	 * @type {Long}
	 */
	public Long declaredPrice;

	}

