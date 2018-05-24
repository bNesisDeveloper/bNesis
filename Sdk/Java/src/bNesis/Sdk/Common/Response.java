package bNesis.Sdk.Common;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * A generic class that defines the HTTP result of the API call in bNesse
 *     Each bNesis services RAW API must return this class (used as data structure) to Client 
 * @typedef {Object} Response
 */
public class Response
{
	public Response(){}
	/**
	 * HTTP response status code
	 * @type {HttpStatus}
	 */
	public HttpStatus StatusCode;

	/**
	 * HTTP response status code text description
	 * @type {String}
	 */
	public String StatusDescription;

	/**
	 * String representation of response content
	 * @type {String}
	 */
	public String Content;

	/**
	 * Encoding of the response content
	 * @type {String}
	 */
	public String ContentEncoding;

	/**
	 * Length in bytes of the response content
	 * @type {Long}
	 */
	public Long ContentLength;

	/**
	 * MIME content type of response
	 * @type {String}
	 */
	public String ContentType;

	/**
	 * Bytes
	 * @type {Byte[]}
	 */
	public Byte[] RawBytes;

	/**
	 * Headers at JSON temporary solution
	 * @type {String}
	 */
	public String Headers;

	/**
	 * message with error information
	 * @type {String}
	 */
	public String ErrorMessage;

	/**
	 * Status of the request. Will return Error for transport errors. HTTP errors will
	 * still return ResponseStatus.Completed, check StatusCode instead
	 * @type {String}
	 */
	public String ResponseStatus;

	/**
	 * The URL that actually responded to the content (different from request if redirected)
	 * @type {URI}
	 */
	public URI ResponseUri;

	/**
	 * HttpWebResponse.Server
	 * @type {String}
	 */
	public String Server;

	}

