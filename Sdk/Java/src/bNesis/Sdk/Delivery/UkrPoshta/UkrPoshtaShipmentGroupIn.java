package bNesis.Sdk.Delivery.UkrPoshta;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * ShipmentGroupIn used for add or edit information about shipmentGroup. 
 * @typedef {Object} UkrPoshtaShipmentGroupIn
 */
public class UkrPoshtaShipmentGroupIn
{
	public UkrPoshtaShipmentGroupIn(){}
	/**
	 * Name of shipment group.
	 * @type {String}
	 */
	public String name;

	/**
	 * Identificator client.
	 * @type {String}
	 */
	public String clientUuid;

	/**
	 * Type group parcel.
	 *  EXPRESS - Ukrposhta Express.STANDARD - Ukrposhta standard.For more detail see:http://ukrposhta.ua/ By default EXPRESS.
	 * @type {String}
	 */
	public String type;

	}

