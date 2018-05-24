package bNesis.Sdk.GovRegistry.Prozzoro;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of ProcuringEntity. 
 * @typedef {Object} ProcuringEntity
 */
public class ProcuringEntity
{
	public ProcuringEntity(){}
	/**
	 * The contact point.
	 * @type {ProzzoroContactPoint}
	 */
	public ProzzoroContactPoint contactPoint;

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

