package bNesis.Sdk.Delivery.UkrPoshta;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * ShipmentGroupOut used when get information about shipment group. 
 * @typedef {Object} UkrPoshtaShipmentGroupOut
 */
public class UkrPoshtaShipmentGroupOut
{
	public UkrPoshtaShipmentGroupOut(){}
	/**
	 * Identificator shipment group.
	 * @type {String}
	 */
	public String uuid;

	/**
	 * Name of shipment group.
	 * @type {String}
	 */
	public String name;

	/**
	 * Customer identificator.
	 * @type {String}
	 */
	public String clientUuid;

	/**
	 * Consignment(for international shipments).
	 * @type {String}
	 */
	public String consignment;

	/**
	 * Registered group.
	 * @type {Boolean}
	 */
	public Boolean approved;

	/**
	 * Type group parcel.
	 * @type {String}
	 */
	public String type;

	}

