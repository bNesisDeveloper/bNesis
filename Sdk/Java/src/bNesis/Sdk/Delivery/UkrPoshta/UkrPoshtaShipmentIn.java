package bNesis.Sdk.Delivery.UkrPoshta;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * ShipmentIn used when add or edit information shipment. 
 * @typedef {Object} UkrPoshtaShipmentIn
 */
public class UkrPoshtaShipmentIn
{
	public UkrPoshtaShipmentIn(){}
	/**
	 * Identificator sender customer.
	 * @type {UkrPoshtaCustomerUuid}
	 */
	public UkrPoshtaCustomerUuid sender;

	/**
	 * Identificator recipient customer.
	 * @type {UkrPoshtaCustomerUuid}
	 */
	public UkrPoshtaCustomerUuid recipient;

	/**
	 * Repient phone.
	 * @type {String}
	 */
	public String recipientPhone;

	/**
	 * Recipient email.
	 * @type {String}
	 */
	public String recipientEmail;

	/**
	 * Recipient address id.
	 * @type {String}
	 */
	public String recipientAddressId;

	/**
	 * Return address id, may be specified additionally, if not specified will used main address where 'main' is true.
	 * @type {String}
	 */
	public String returnAddressId;

	/**
	 * Identificator of shipment group, if sending is a group.
	 * @type {String}
	 */
	public String shipmentGroupUuid;

	/**
	 * External ID of departure at the base counterparty.
	 * @type {String}
	 */
	public String externalId;

	/**
	 * Delivery type(for international shippment).
	 *  Have mostly 4 types:W2D warehouse-door 
	 *  W2W warehouse-warehouse 
	 *  D2W door-warehouse
	 *  D2D door-door
	 * @type {String}
	 */
	public String deliveryType;

	/**
	 * Actions with shipment in case the recipient did not take it.
	 *  RETURN - return to the sender.RETURN_AFTER_F REE_STORAGE - return after the expiration of free storage.PROCESS_AS_REF USAL - destroy the parcel.By default RETURN.
	 * @type {String}
	 */
	public String onFailReceiveType;

	/**
	 * Parcels.
	 * @type {UkrPoshtaParcel[]}
	 */
	public UkrPoshtaParcel[] parcels;

	/**
	 * Postpay in UAH may not be higher than the stated price.
	 * @type {Long}
	 */
	public Long postPay;

	/**
	 * Description or comments (max 255 characters).
	 * @type {String}
	 */
	public String description;

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
	 * Return shipping documentation
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
	 * Type shipment.
	 *  EXPRESS - Ukrposhta Express.STANDARD - Ukrposhta standard.For more detail see:http://ukrposhta.ua/ By default EXPRESS.
	 * @type {String}
	 */
	public String type;

	/**
	 * The party who pays the postpay billing fee.
	 *  true - the amount is paid by the recipient.false - is paid by the sender.By default true.
	 * @type {Boolean}
	 */
	public Boolean postPayPaidByRecipient;

	}

