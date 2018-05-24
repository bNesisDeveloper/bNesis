package bNesis.Sdk.Delivery.UkrPoshta;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Information about discount per customer. 
 * @typedef {Object} UkrPoshtaDiscountPerCustomer
 */
public class UkrPoshtaDiscountPerCustomer
{
	public UkrPoshtaDiscountPerCustomer(){}
	/**
	 * Identifier.
	 * @type {String}
	 */
	public String uuid;

	/**
	 * Customer identifier.
	 * @type {String}
	 */
	public String clientUuid;

	/**
	 * Discount identifier.
	 * @type {String}
	 */
	public String discountUuid;

	/**
	 * Value of discount.
	 * @type {Short}
	 */
	public Short value;

	/**
	 * Discount available from date.
	 * @type {String}
	 */
	public String fromDate;

	/**
	 * Discount available to date.
	 * @type {String}
	 */
	public String toDate;

	/**
	 * Shipment type.
	 * @type {String}
	 */
	public String shipmentType;

	}

