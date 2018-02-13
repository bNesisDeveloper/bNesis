/**
 * Represents type of a file storage entry (like folder, file, link, etc.) 
 * @typedef {Object} FileStorageItemType
 */
	FileStorageItemType =
{ 
	/**
	 * The entry is folder.
	 * @type {Int32}
	 */
		Folder: 0,

	/**
	 * The entry is file.
	 * @type {Int32}
	 */
		File: 1,

	}

/**
 * Class for holding info about a file storage entry. 
 * @typedef {Object} FileStorageItem
	 * @property {string}  Id - The unique identifier of the storage item.
	 * @property {string}  Name - The name of the storage item.
	 * @property {FileStorageItemType}  ItemType - The type of the item entry.
	 * @property {Int64}  Size - The size of the storage item in bytes or zero.
	 * @property {string}  ContentLink - The content link to the storage item.
	 * @property {string}  Parent - The parent.
 */
 FileStorageItem = function () { 
	/**
	 * Gets or sets unique identifier of the storage item.
	 * @type {string}
	 */
	this.Id = "";

	/**
	 * Gets or sets name of the storage item.
	 * @type {string}
	 */
	this.Name = "";

	/**
	 * Gets or sets the type of the item entry.
	 * @type {FileStorageItemType}
	 */
	this.ItemType = new FileStorageItemType();

	/**
	 * Gets or sets size of the storage item if available.
	 * @type {Int64}
	 */
	this.Size = 0;

	/**
	 * Gets or sets link to content of the storage item if available..
	 * @type {string}
	 */
	this.ContentLink = "";

	/**
	 * Gets or sets the parent item ID.
	 * @type {string}
	 */
	this.Parent = "";

}

