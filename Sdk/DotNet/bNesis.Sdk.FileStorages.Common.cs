using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace bNesis.Sdk.FileStorages.Common
{
	///<summary>
	/// Represents type of a file storage entry (like folder, file, link, etc.) 
	/// </summary>
	public enum FileStorageItemType
	{
		/// <summary>
		/// The entry is folder. 
		/// </summary>
		Folder = 0,

		/// <summary>
		/// The entry is file. 
		/// </summary>
		File = 1,

	}

	///<summary>
	/// Class for holding info about a file storage entry. 
	/// </summary>
	public class FileStorageItem
	{
		/// <summary>
		/// Gets or sets unique identifier of the storage item. 
		/// </summary>
		/// <value>The unique identifier of the storage item.</value>
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets name of the storage item. 
		/// </summary>
		/// <value>The name of the storage item.</value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the type of the item entry. 
		/// </summary>
		/// <value>The type of the item entry.</value>
		public FileStorageItemType ItemType { get; set; }

		/// <summary>
		/// Gets or sets size of the storage item if available. 
		/// </summary>
		/// <value>The size of the storage item in bytes or zero.</value>
		public Int64 Size { get; set; }

		/// <summary>
		/// Gets or sets link to content of the storage item if available.. 
		/// </summary>
		/// <value>The content link to the storage item.</value>
		public string ContentLink { get; set; }

		/// <summary>
		/// Gets or sets the parent item ID. 
		/// </summary>
		/// <value>The parent.</value>
		public string Parent { get; set; }

	}

}