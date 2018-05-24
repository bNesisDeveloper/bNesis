package bNesis.Sdk.Delivery.UkrPoshta;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * ShipmentOut used when get information about shipment. 
 * @typedef {Object} UkrPoshtaShipmentOut
 */
public class UkrPoshtaShipmentOut
{
	public UkrPoshtaShipmentOut(){}
	/**
	 * Identificator.
	 * @type {String}
	 */
	public String uuid;

	/**
	 * Information about sender.
	 * @type {UkrPoshtaCustomerOut}
	 */
	public UkrPoshtaCustomerOut sender;

	/**
	 * Information about recipient.
	 * @type {UkrPoshtaCustomerOut}
	 */
	public UkrPoshtaCustomerOut recipient;

	/**
	 * Recipient phone.
	 * @type {String}
	 */
	public String recipientPhone;

	/**
	 * Recipient email.
	 * @type {String}
	 */
	public String recipientEmail;

	/**
	 * Recipient address identifier.
	 * @type {String}
	 */
	public String recipientAddressId;

	/**
	 * Return address identifier.
	 * @type {String}
	 */
	public String returnAddressId;

	/**
	 * Shipment group identifier.
	 * @type {String}
	 */
	public String shipmentGroupUuid;

	/**
	 * External identifier.
	 * @type {String}
	 */
	public String externalId;

	/**
	 * Delivery type.
	 *  RETURN - return to the sender.RETURN_AFTER_F REE_STORAGE - return after the expiration of free storage.PROCESS_AS_REF USAL - destroy the parcel.By default RETURN.
	 * @type {String}
	 */
	public String deliveryType;

	/**
	 * Package type.
	 * @type {String}
	 */
	public String packageType;

	/**
	 * Actions with shipment in case the recipient did not take it.
	 * @type {String}
	 */
	public String onFailReceiveType;

	/**
	 * Parcel barcode.
	 * @type {String}
	 */
	public String barcode;

	/**
	 * Parcels.
	 * @type {UkrPoshtaParcel[]}
	 */
	public UkrPoshtaParcel[] parcels;

	/**
	 * Delivery price.
	 * @type {Long}
	 */
	public Long deliveryPrice;

	/**
	 * Post pay.
	 * @type {Long}
	 */
	public Long postPay;

	/**
	 * Currency code.
	 * @type {String}
	 */
	public String currencyCode;

	/**
	 * Post pay currency code.
	 * @type {String}
	 */
	public String postPayCurrencyCode;

	/**
	 * Currency exchange rate.
	 * @type {String}
	 */
	public String currencyExchangeRate;

	/**
	 * Discount per customer.
	 * @type {UkrPoshtaDiscountPerCustomer}
	 */
	public UkrPoshtaDiscountPerCustomer discountPerClient;

	/**
	 * Date of making the latest changes in the shipment. Date and time in the format "2017-06- 12T12: 31: 56"
	 * @type {String}
	 */
	public String lastModified;

	/**
	 * Description or comments.
	 * @type {String}
	 */
	public String description;

	/**
	 * Tracking departure.
	 * @type {Object[]}
	 */
	public Object[] statusTrackings;

	/**
	 * Payment for the shipment upon receipt. 
	 *  true - payment by the recipient.false - payment sender.By default, false.
	 * @type {Boolean}
	 */
	public Boolean paidByRecipient;

	/**
	 * Payment by cashless payment.
	 *  true - non-cash.false - cash.By default, true.
	 * @type {Boolean}
	 */
	public Boolean nonCashPayment;

	/**
	 * The note is a bulky parcel.
	 *  true - cumbersomefalse - not cumbersomeBy default false
	 * @type {Boolean}
	 */
	public Boolean bulky;

	/**
	 * The note is a fragile parcel.
	 *  true - brittle.false - not fragile.By default false.
	 * @type {Boolean}
	 */
	public Boolean fragile;

	/**
	 * Bee pointing.
	 *  By default false.
	 * @type {Boolean}
	 */
	public Boolean bees;

	/**
	 * Sending from a receipt.
	 *  If true when receiving a shipment (Service for which an additional price is charged. Details on the site ukrposhta.ua), the sender receives a letter stating that the shipment has been received.By default false.
	 * @type {Boolean}
	 */
	public Boolean recommended;

	/**
	 * Sms message about the arrival of the parcel.
	 *  If the true recipient receives the message (Service for which an additional price is charged. Details on the site ukrposhta.ua).By default false.
	 * @type {Boolean}
	 */
	public Boolean sms;

	/**
	 * International shipping
	 *  By default false.
	 * @type {Boolean}
	 */
	public Boolean international;

	/**
	 * Shipping price.
	 * @type {String}
	 */
	public String postPayDeliveryPrice;

	/**
	 * The party who pays the postpay billing fee.
	 *  true - the amount is paid by the recipient.false - is paid by the sender.By default true.
	 * @type {Boolean}
	 */
	public Boolean postPayPaidByRecipient;

	/**
	 * A description of the costing that describes how the cost of mail is generated.
	 * @type {String}
	 */
	public String calculationDescription;

	/**
	 * Return shipping documentation.
	 *  By default false.
	 * @type {Boolean}
	 */
	public Boolean documentBack;

	/**
	 * Review at handed.
	 *  By default false.
	 * @type {Boolean}
	 */
	public Boolean checkOnDelivery;

	/**
	 * Display information about the sender's bank account on the address bar.
	 *  By default false. Only if there is postpay.
	 * @type {Boolean}
	 */
	public Boolean transferPostPayToBankAccount;

	/**
	 * The shipping charge has been paid.
	 * @type {Boolean}
	 */
	public Boolean deliveryPricePaid;

	/**
	 * Postpay paid.
	 * @type {Boolean}
	 */
	public Boolean postPayPaid;

	/**
	 * The shipping charge has been paid.
	 * @type {Boolean}
	 */
	public Boolean postPayDeliveryPricePaid;

	/**
	 * Type shipment.
	 *  EXPRESS - Ukrposhta Express.STANDARD - Ukrposhta standard.For more detail see:http://ukrposhta.ua/ By default EXPRESS.
	 * @type {String}
	 */
	public String type;

	/**
	 * After the creation of the sending status changes to CREATED, after the registration of the shipment in the communications branch status changes to REGISTERED.
	 * @type {String}
	 */
	public String status;

	}

