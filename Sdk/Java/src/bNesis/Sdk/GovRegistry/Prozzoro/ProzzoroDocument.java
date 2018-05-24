package bNesis.Sdk.GovRegistry.Prozzoro;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of Document. 
 * @typedef {Object} ProzzoroDocument
 */
public class ProzzoroDocument
{
	public ProzzoroDocument(){}
	/**
	 * The main document identifier.
	 * @type {String}
	 */
	public String id;

	/**
	 * The document hash.
	 * @type {String}
	 */
	public String hash;

	/**
	 * The document author.
	 * @type {String}
	 */
	public String author;

	/**
	 * The format of the document taken from the IANA Media Types code list,
	 * with the addition of one extra value for 'offline/print', 
	 * used when this document entry is being used to describe the offline publication of a document
	 * @type {String}
	 */
	public String format;

	/**
	 * Direct link to the document or attachment.
	 * @type {String}
	 */
	public String url;

	/**
	 * The document title.
	 * @type {String}
	 */
	public String title;

	/**
	 * The document of one of the possible values are: 
	 * tender, item, lot
	 * @type {String}
	 */
	public String documentOf;

	/**
	 * The date on which the document was first published.
	 * @type {String}
	 */
	public String datePublished;

	/**
	 * The type of the document.
	 * See possible values on:http://api-docs.openprocurement.org/en/latest/standard/document.html#schema
	 * @type {String}
	 */
	public String documentType;

	/**
	 * Date that the document was last modified.
	 * @type {String}
	 */
	public String dateModified;

	/**
	 * The identifier of related Lot or Item.
	 * @type {String}
	 */
	public String relatedItem;

	/**
	 * A short description of the document.
	 * @type {String}
	 */
	public String description;

	}

