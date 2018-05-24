package bNesis.Sdk.FileStorages.Common;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Class for holding info about a file storage entry. 
 * @typedef {Object} FileStorageItem
	 * @property {String}  Id - The unique identifier of the storage item.
	 * @property {String}  Name - The name of the storage item.
	 * @property {FileStorageItemType}  ItemType - The type of the item entry.
	 * @property {Long}  Size - The size of the storage item in bytes or zero.
	 * @property {String}  ContentLink - The content link to the storage item.
	 * @property {String}  Parent - The parent.
 */
public class FileStorageItem
{
	public FileStorageItem(){}
	/**
	 * Gets or sets unique identifier of the storage item.
	 * @type {String}
	 */
	public String Id;

	/**
	 * Gets or sets name of the storage item.
	 * @type {String}
	 */
	public String Name;

	/**
	 * Gets or sets the type of the item entry.
	 * @type {FileStorageItemType}
	 */
	public FileStorageItemType ItemType;

	/**
	 * Gets or sets size of the storage item if available.
	 * @type {Long}
	 */
	public Long Size;

	/**
	 * Gets or sets link to content of the storage item if available..
	 * @type {String}
	 */
	public String ContentLink;

	/**
	 * Gets or sets the parent item ID.
	 * @type {String}
	 */
	public String Parent;

	}

