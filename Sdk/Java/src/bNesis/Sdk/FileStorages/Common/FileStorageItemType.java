package bNesis.Sdk.FileStorages.Common;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Represents type of a file storage entry (like folder, file, link, etc.) 
 * @typedef {Object} FileStorageItemType
 */
	public enum FileStorageItemType
	{
	/**
	 * The entry is folder.
	 * @type {Int32}
	 */
		Folder,

	/**
	 * The entry is file.
	 * @type {Int32}
	 */
		File,

	}

