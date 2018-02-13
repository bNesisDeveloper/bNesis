using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;
using bNesis.Api.Desktop;
using bNesis.Sdk.Common;
using bNesis.Sdk.FileStorages.Common;

namespace bNesis.Sdk.FileStorages.GoogleDrive
{
	public class GoogleDrive  
	{
		public string bNesisToken {get; private set;}
		private DesktopbNesisApi bNesisApi;

		public GoogleDrive(DesktopbNesisApi bNesisApi)
		{
			this.bNesisApi = bNesisApi;
		}

		public string Auth(string bNesisDevId,string redirectUrl,string clientId,string clientSecret,string[] scopes)
		{

			bNesisToken = bNesisApi.Auth("Google", string.Empty,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,string.Empty,string.Empty,false,string.Empty);

			return bNesisToken;
		}

		///<summary>
		/// Getting last exception for current provider 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo GetLastError()
		{
			return bNesisApi.Call<ErrorInfo>("GoogleDrive", bNesisToken, "GetLastError");
		}

		///<summary>
		/// Getting arrays of error info 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo[] GetErrorLog()
		{
			return bNesisApi.Call<ErrorInfo[]>("GoogleDrive", bNesisToken, "GetErrorLog");
		}

		///<summary>
		/// Checks the token in the service. 
		/// </summary>
		/// <returns>if token valid return true, if token not valid return false</returns>
		public Boolean ValidationTokenUnified()
		{
			return bNesisApi.Call<Boolean>("GoogleDrive", bNesisToken, "ValidationTokenUnified");
		}

		///<summary>
		/// Normalizes folder and file paths using current file storage rules. 
		/// </summary>
		/// <param name="path">The path to folder or file.</param>
		/// <returns>String with normalized path.</returns>
		public string NormalizePath(string path)
		{
			return bNesisApi.Call<string>("GoogleDrive", bNesisToken, "NormalizePath", path);
		}

		///<summary>
		/// Gets file entries for a folder. 
		/// </summary>
		/// <param name="path">The path to folder.</param>
		/// <returns>Array of IFileStorageItem.</returns>
		public FileStorageItem[] GetFiles(string path)
		{
			return bNesisApi.Call<FileStorageItem[]>("GoogleDrive", bNesisToken, "GetFiles", path);
		}

		///<summary>
		/// Gets sub folder entries for a folder. 
		/// </summary>
		/// <param name="path">The path to root folder.</param>
		/// <returns>Array of IFileStorageItem.</returns>
		public FileStorageItem[] GetFolders(string path)
		{
			return bNesisApi.Call<FileStorageItem[]>("GoogleDrive", bNesisToken, "GetFolders", path);
		}

		///<summary>
		/// Create folder entry for a folder. 
		/// </summary>
		/// <param name="path">The path to the created folder.</param>
		/// <param name="name">The name of the new created folder.</param>
		/// <returns>Empty string if OK or an error description otherwise.</returns>
		public string CreateFolder(string path, string name)
		{
			return bNesisApi.Call<string>("GoogleDrive", bNesisToken, "CreateFolder", path, name);
		}

		///<summary>
		/// Delete entry (folder or file). 
		/// </summary>
		/// <param name="path">The path to deleted entry.</param>
		/// <returns>Empty string if OK or an error description otherwise.</returns>
		public string Delete(string path)
		{
			return bNesisApi.Call<string>("GoogleDrive", bNesisToken, "Delete", path);
		}

		///<summary>
		/// Download file. 
		/// </summary>
		/// <param name="path">The path to file.</param>
		/// <returns>Stream with file or null if error.</returns>
		public Stream DownloadFile(string path)
		{
			return bNesisApi.Call<Stream>("GoogleDrive", bNesisToken, "DownloadFile", path);
		}

		///<summary>
		/// Upload file. 
		/// </summary>
		/// <param name="destinationStream">Stream with file data.</param>
		/// <param name="name">Name of new file.</param>
		/// <returns>Empty string if OK or an error description otherwise.</returns>
		public string UploadFile(Stream destinationStream, string name)
		{
			return bNesisApi.Call<string>("GoogleDrive", bNesisToken, "UploadFile", destinationStream, name);
		}

		///<summary>
		/// Gets the Google Drive files fields (https://developers.google.com/drive/v3/reference/files) 
		/// </summary>
		/// <param name="path">The folder path.</param>
		/// <param name="fileFields">List of Google Drive file fields to be retrived.</param>
		/// <returns>IEnumerable of ExpandoObject.</returns>
		public Object[] GetFilesFields(string path, string fileFields)
		{
			return bNesisApi.Call<Object[]>("GoogleDrive", bNesisToken, "GetFilesFields", path, fileFields);
		}

		///<summary>
		/// Copies the specified file. (https://developers.google.com/drive/v3/reference/files/copy) 
		/// </summary>
		/// <param name="path">The file identifier or path.</param>
		/// <param name="toPath">To path.</param>
		/// <returns>metadata</returns>
		public Object copy(string path, string toPath)
		{
			return bNesisApi.Call<Object>("GoogleDrive", bNesisToken, "copy", path, toPath);
		}

		///<summary>
		/// Gets the metadata. 
		/// </summary>
		/// <param name="path">The file identifier or path.</param>
		/// <param name="fields">The fields.</param>
		/// <returns></returns>
		public Object get_metadata(string path, string fields)
		{
			return bNesisApi.Call<Object>("GoogleDrive", bNesisToken, "get_metadata", path, fields);
		}

		///<summary>
		/// Exports the specified file identifier. (https://developers.google.com/drive/v3/reference/files/export) 
		/// </summary>
		/// <param name="path">The file identifier or path.</param>
		/// <param name="mimeType">Type of the MIME.</param>
		/// <returns></returns>
		public Object export(string path, string mimeType)
		{
			return bNesisApi.Call<Object>("GoogleDrive", bNesisToken, "export", path, mimeType);
		}

		///<summary>
		/// Permanently deletes all of the user's trashed files. 
		/// </summary>
		/// <returns>If successful, this method returns an empty response body.</returns>
		public Object emptyTrash()
		{
			return bNesisApi.Call<Object>("GoogleDrive", bNesisToken, "emptyTrash");
		}

		///<summary>
		/// Searching files.(https://developers.google.com/drive/v3/reference/files/list) 
		/// </summary>
		/// <param name="fileName">The order by.</param>
		/// <returns></returns>
		public Object search(string fileName)
		{
			return bNesisApi.Call<Object>("GoogleDrive", bNesisToken, "search", fileName);
		}

		///<summary>
		/// Updates the specified file identifier.(https://developers.google.com/drive/v3/reference/files/update) 
		/// </summary>
		/// <param name="path">The file identifier or path.</param>
		/// <param name="addParents">The add parents.</param>
		/// <returns></returns>
		public Object update(string path, string addParents)
		{
			return bNesisApi.Call<Object>("GoogleDrive", bNesisToken, "update", path, addParents);
		}

		///<summary>
		/// Watches the specified file identifier.(https://developers.google.com/drive/v3/reference/files/watch) 
		/// </summary>
		/// <param name="path">The file identifier or path.</param>
		/// <param name="address">The address where notifications are delivered for this channel.</param>
		/// <returns></returns>
		public Object watch(string path, string address)
		{
			return bNesisApi.Call<Object>("GoogleDrive", bNesisToken, "watch", path, address);
		}

		///<summary>
		/// Generates the ids. 
		/// </summary>
		/// <param name="count">The count.</param>
		/// <param name="space">The space.</param>
		/// <returns></returns>
		public Object generateIds(Int32 count, string space)
		{
			return bNesisApi.Call<Object>("GoogleDrive", bNesisToken, "generateIds", count, space);
		}

		///<summary>
		/// Gets the information about the current user along with Drive API settings. 
		/// </summary>
		/// <param name="includeSubscribed">When calculating the number of remaining change IDs, whether to include public files the user has opened and shared files. When set to false, this counts only change IDs for owned files and any shared or public files that the user has explicitly added to a folder they own. (Default: true)</param>
		/// <param name="maxChangeIdCount">Maximum number of remaining change IDs to count</param>
		/// <param name="startChangeId">Change ID to start counting from when calculating number of remaining change IDs</param>
		/// <returns>If successful, this method returns an About resource in the response body.</returns>
		public Response AboutRaw(Boolean includeSubscribed, Int64 maxChangeIdCount, Int64 startChangeId)
		{
			return bNesisApi.Call<Response>("GoogleDrive", bNesisToken, "AboutRaw", includeSubscribed, maxChangeIdCount, startChangeId);
		}
	}
}