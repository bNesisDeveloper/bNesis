package bNesis.Sdk.GovRegistry.Prozzoro;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of Tenderer. 
 * @typedef {Object} ProzzoroTenderer
 */
public class ProzzoroTenderer
{
	public ProzzoroTenderer(){}
	/**
	 * The contact point.
	 * @type {ProzzoroContactPoint}
	 */
	public ProzzoroContactPoint contactPoint;

	/**
	 * The name en.
	 * @type {String}
	 */
	public String name_en;

	/**
	 * The identifier.
	 * @type {ProzzoroIdentifier}
	 */
	public ProzzoroIdentifier identifier;

	/**
	 * The name.
	 * @type {String}
	 */
	public String name;

	/**
	 * The address.
	 * @type {ProzzoroAddress}
	 */
	public ProzzoroAddress address;

	}

