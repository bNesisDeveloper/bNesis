package bNesis.Sdk.Common;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Information about error 
 * @typedef {Object} ErrorInfo
 */
public class ErrorInfo
{
	public ErrorInfo(){}
	/**
	 * Error code
	 * @type {Integer}
	 */
	public Integer Code;

	/**
	 * When ErrorInfo was created
	 * @type {String}
	 */
	public String DateTime;

	/**
	 * Service name
	 * @type {String}
	 */
	public String Service;

	/**
	 * Describes important error information
	 * @type {String}
	 */
	public String Description;

	/**
	 * All information about error
	 * @type {String}
	 */
	public String BasicDescription;

	}

