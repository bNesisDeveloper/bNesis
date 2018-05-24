package bNesis.Sdk.GovRegistry.Prozzoro;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of Organization. 
 * @typedef {Object} ProzzoroOrganization
 */
public class ProzzoroOrganization
{
	public ProzzoroOrganization(){}
	/**
	 * The contact point.
	 * @type {ProzzoroContactPoint}
	 */
	public ProzzoroContactPoint contactPoint;

	/**
	 * The primary identifier for this organization
	 * @type {ProzzoroIdentifier}
	 */
	public ProzzoroIdentifier identifier;

	/**
	 * The common name of the organization.
	 * @type {String}
	 */
	public String name;

	/**
	 * The address.
	 * @type {ProzzoroAddress}
	 */
	public ProzzoroAddress address;

	}

