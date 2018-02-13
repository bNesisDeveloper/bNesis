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

namespace bNesis.Sdk.FileStorages.Box
{
	public class Box  
	{
		public string bNesisToken {get; private set;}
		private DesktopbNesisApi bNesisApi;

		public Box(DesktopbNesisApi bNesisApi)
		{
			this.bNesisApi = bNesisApi;
		}

		public string Auth(string data,string bNesisDevId,string redirectUrl,string clientId,string clientSecret,string[] scopes,string login,string password,bool isSandbox,string serviceUrl)
		{

			bNesisToken = bNesisApi.Auth("Box", data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl);

			return bNesisToken;
		}

		///<summary>
		/// Getting last exception for current provider 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo GetLastError()
		{
			return bNesisApi.Call<ErrorInfo>("Box", bNesisToken, "GetLastError");
		}

		///<summary>
		/// Getting arrays of error info 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo[] GetErrorLog()
		{
			return bNesisApi.Call<ErrorInfo[]>("Box", bNesisToken, "GetErrorLog");
		}

		///<summary>
		/// Checks the token in the service. 
		/// </summary>
		/// <returns>if token valid return true, if token not valid return false</returns>
		public Boolean ValidationTokenUnified()
		{
			return bNesisApi.Call<Boolean>("Box", bNesisToken, "ValidationTokenUnified");
		}

		///<summary>
		/// Normalizes folder and file paths using current file storage rules. 
		/// </summary>
		/// <param name="path">The path to folder or file.</param>
		/// <returns>String with normalized path.</returns>
		public string NormalizePath(string path)
		{
			return bNesisApi.Call<string>("Box", bNesisToken, "NormalizePath", path);
		}

		///<summary>
		/// Gets file entries for a folder. 
		/// </summary>
		/// <param name="path">The path to folder.</param>
		/// <returns>Array of IFileStorageItem.</returns>
		public FileStorageItem[] GetFiles(string path)
		{
			return bNesisApi.Call<FileStorageItem[]>("Box", bNesisToken, "GetFiles", path);
		}

		///<summary>
		/// Gets sub folder entries for a folder. 
		/// </summary>
		/// <param name="path">The path to root folder.</param>
		/// <returns>Array of IFileStorageItem.</returns>
		public FileStorageItem[] GetFolders(string path)
		{
			return bNesisApi.Call<FileStorageItem[]>("Box", bNesisToken, "GetFolders", path);
		}

		///<summary>
		/// Create folder entry for a folder. 
		/// </summary>
		/// <param name="path">The path to the created folder.</param>
		/// <param name="name">The name of the new created folder.</param>
		/// <returns>Empty string if OK or an error description otherwise.</returns>
		public string CreateFolder(string path, string name)
		{
			return bNesisApi.Call<string>("Box", bNesisToken, "CreateFolder", path, name);
		}

		///<summary>
		/// Delete entry (folder or file). 
		/// </summary>
		/// <param name="path">The path to deleted entry.</param>
		/// <returns>Empty string if OK or an error description otherwise.</returns>
		public string Delete(string path)
		{
			return bNesisApi.Call<string>("Box", bNesisToken, "Delete", path);
		}

		///<summary>
		/// Download file. 
		/// </summary>
		/// <param name="path">The path to file.</param>
		/// <returns>Stream with file or null if error.</returns>
		public Stream DownloadFile(string path)
		{
			return bNesisApi.Call<Stream>("Box", bNesisToken, "DownloadFile", path);
		}

		///<summary>
		/// Upload file. 
		/// </summary>
		/// <param name="destinationStream">Stream with file data.</param>
		/// <param name="name">Name of new file.</param>
		/// <returns>Empty string if OK or an error description otherwise.</returns>
		public string UploadFile(Stream destinationStream, string name)
		{
			return bNesisApi.Call<string>("Box", bNesisToken, "UploadFile", destinationStream, name);
		}

		///<summary>
		/// Get information about the user who is currently logged in (i.e. the user for whom this auth token was generated). 
		/// </summary>
		/// <returns>Returns a single complete user object.</returns>
		public Response GetCurrentUserRaw()
		{
			return bNesisApi.Call<Response>("Box", bNesisToken, "GetCurrentUserRaw");
		}
	}
}