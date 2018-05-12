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

namespace bNesis.Sdk.FileStorages.Dropbox
{
	public class Dropbox  
	{
		/// <summary>
		/// bNesisToken is a unique identifier of the current service work session
		/// bNesisToken is relevant only after successful authorization in the service.
		/// The Auth() method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		/// The LogoffService() method stops the authorization session with the service and clears the value of bNesisToken.
		/// </summary>		
		public string bNesisToken {get; private set;}

		/// <summary>
		/// bNesis Core object
		/// </summary>
		private DesktopbNesisApi bNesisApi;

		public Dropbox(DesktopbNesisApi bNesisApi)
		{
			this.bNesisApi = bNesisApi;
		}

		/// <summary>
		/// The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		/// </summary>
		/// <returns>bNesisToken value</returns>	
		public string Auth(string bNesisDevId,string clientId,string clientSecret,string redirectUrl)
		{
			bNesisToken = bNesisApi.Auth("Dropbox", string.Empty,bNesisDevId,redirectUrl,clientId,clientSecret,null,string.Empty,string.Empty,false,string.Empty);
			return bNesisToken;
		}

		/// <summary>
		/// Attach to bNesis session with exists bNesis token
		/// </summary>		
		/// <returns>true if bNesisToken is valid</returns>	
		public bool Auth(string bNesisToken)
		{
		    this.bNesisToken = bNesisToken;			
			return ValidateToken();
		}

		/// <summary>
		/// The method stops the authorization session with the service and clears the value of bNesisToken.
		/// </summary>
		/// <returns>true - if service logoff is successful</returns>
		public bool LogoffService()
		{
			bool result = bNesisApi.LogoffService("Dropbox", bNesisToken);
			if (result) bNesisToken = string.Empty;
			return result;             
		}


		///<summary>
		/// Getting last exception for current provider 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo GetLastError()
		{
			return bNesisApi.Call<ErrorInfo>("Dropbox", bNesisToken, "GetLastError");
		}

		///<summary>
		/// Getting arrays of error info 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo[] GetErrorLog()
		{
			return bNesisApi.Call<ErrorInfo[]>("Dropbox", bNesisToken, "GetErrorLog");
		}

		///<summary>
		/// Checks the token in the service. 
		/// </summary>
		/// <returns>if token valid return true, if token not valid return false</returns>
		public Boolean ValidateToken()
		{
			return bNesisApi.Call<Boolean>("Dropbox", bNesisToken, "ValidateToken");
		}

		///<summary>
		/// Disables the access token used to authenticate the call. 
		/// </summary>
		/// <returns>if token revoked method returns true 
		/// if token doesn't support token revocation or token is revoked method returns false</returns>
		public Boolean Logoff()
		{
			return bNesisApi.Call<Boolean>("Dropbox", bNesisToken, "Logoff");
		}

		///<summary>
		/// Normalizes folder and file paths using current file storage rules. 
		/// </summary>
		/// <param name="path">The path to folder or file.</param>
		/// <returns>String with normalized path.</returns>
		public string NormalizePath(string path)
		{
			return bNesisApi.Call<string>("Dropbox", bNesisToken, "NormalizePath", path);
		}

		///<summary>
		/// Gets file entries for a folder. 
		/// </summary>
		/// <param name="path">The path to folder.</param>
		/// <returns>Array of IFileStorageItem.</returns>
		public FileStorageItem[] GetFiles(string path)
		{
			return bNesisApi.Call<FileStorageItem[]>("Dropbox", bNesisToken, "GetFiles", path);
		}

		///<summary>
		/// Gets sub folder entries for a folder. 
		/// </summary>
		/// <param name="path">The path to root folder.</param>
		/// <returns>Array of IFileStorageItem.</returns>
		public FileStorageItem[] GetFolders(string path)
		{
			return bNesisApi.Call<FileStorageItem[]>("Dropbox", bNesisToken, "GetFolders", path);
		}

		///<summary>
		/// Create folder entry for a folder. 
		/// </summary>
		/// <param name="path">The path to the created folder.</param>
		/// <param name="name">The name of the new created folder.</param>
		/// <returns>Empty string if OK or an error description otherwise.</returns>
		public string CreateFolder(string path, string name)
		{
			return bNesisApi.Call<string>("Dropbox", bNesisToken, "CreateFolder", path, name);
		}

		///<summary>
		/// Delete entry (folder or file). 
		/// </summary>
		/// <param name="path">The path to deleted entry.</param>
		/// <returns>Empty string if OK or an error description otherwise.</returns>
		public string Delete(string path)
		{
			return bNesisApi.Call<string>("Dropbox", bNesisToken, "Delete", path);
		}

		///<summary>
		/// Download file. 
		/// </summary>
		/// <param name="path">The path to file.</param>
		/// <returns>Stream with file or null if error.</returns>
		public Stream DownloadFile(string path)
		{
			return bNesisApi.Call<Stream>("Dropbox", bNesisToken, "DownloadFile", path);
		}

		///<summary>
		/// Upload file. 
		/// </summary>
		/// <param name="destinationStream">Stream with file data.</param>
		/// <param name="name">Name of new file.</param>
		/// <returns>Empty string if OK or an error description otherwise.</returns>
		public string UploadFile(Stream destinationStream, string name)
		{
			return bNesisApi.Call<string>("Dropbox", bNesisToken, "UploadFile", destinationStream, name);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="path"></param>
		/// <param name="include_media_info"></param>
		/// <param name="include_deleted"></param>
		/// <param name="include_has_explicit_shared_members"></param>
		/// <param name="include_property_templates"></param>
		/// <returns></returns>
		public Response get_metadataRaw(string path, Nullable<Boolean> include_media_info, Nullable<Boolean> include_deleted, Nullable<Boolean> include_has_explicit_shared_members, string include_property_templates)
		{
			return bNesisApi.Call<Response>("Dropbox", bNesisToken, "get_metadataRaw", path, include_media_info, include_deleted, include_has_explicit_shared_members, include_property_templates);
		}

		///<summary>
		/// Get a preview for a file.
		/// Currently, PDF previews are generated for files with the following extensions: .ai, .doc, .docm, .docx, .eps, .odp, .odt, .pps, .ppsm, .ppsx, .ppt, .pptm, .pptx, .rtf.
		/// HTML previews are generated for files with the following extensions: .csv, .ods, .xls, .xlsm, .xlsx.
		/// Other formats will return an unsupported extension error. 
		/// </summary>
		/// <param name="path">String(pattern="(/(.|[\r\n])*|id:.*)|(rev:[0-9a-f]{9,})|(ns:[0-9]+(/.*)?)") The path of the file to preview.</param>
		/// <param name="rev">String(min_length=9, pattern="[0-9a-f]+")? Deprecated. Please specify revision in path instead. This field is optional.</param>
		/// <returns>https://www.dropbox.com/developers/documentation/http/documentation#files-get_preview</returns>
		public Tuple<string,ExpandoObject> get_preview(string path, string rev)
		{
			return bNesisApi.Call<Tuple<string,ExpandoObject>>("Dropbox", bNesisToken, "get_preview", path, rev);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="from_path"></param>
		/// <param name="to_path"></param>
		/// <param name="allow_shared_folder"></param>
		/// <param name="autorename"></param>
		/// <returns></returns>
		public string copy(string from_path, string to_path, Nullable<Boolean> allow_shared_folder, Nullable<Boolean> autorename)
		{
			return bNesisApi.Call<string>("Dropbox", bNesisToken, "copy", from_path, to_path, allow_shared_folder, autorename);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="from_path"></param>
		/// <param name="to_path"></param>
		/// <param name="allow_shared_folder"></param>
		/// <param name="autorename"></param>
		/// <param name="allow_ownership_transfer"></param>
		/// <returns></returns>
		public string move(string from_path, string to_path, Nullable<Boolean> allow_shared_folder, Nullable<Boolean> autorename, Nullable<Boolean> allow_ownership_transfer)
		{
			return bNesisApi.Call<string>("Dropbox", bNesisToken, "move", from_path, to_path, allow_shared_folder, autorename, allow_ownership_transfer);
		}

		///<summary>
		/// Get information about the current user's account. 
		/// </summary>
		/// <returns>https://www.dropbox.com/developers/documentation/http/documentation#users-get_current_account</returns>
		public Response get_current_accountRaw()
		{
			return bNesisApi.Call<Response>("Dropbox", bNesisToken, "get_current_accountRaw");
		}

		///<summary>
		/// Get a temporary link to stream content of a file. This link will expire in four hours and afterwards you will get 410 Gone. Content-Type of the link is determined automatically by the file's mime type. 
		/// </summary>
		/// <param name="path">The path.</param>
		/// <returns></returns>
		public ExpandoObject get_temporary_link(string path)
		{
			return bNesisApi.Call<ExpandoObject>("Dropbox", bNesisToken, "get_temporary_link", path);
		}

		///<summary>
		/// Get the space usage information for the current user's account. 
		/// </summary>
		/// <returns>SpaceUsage. Information about a user's space usage and quota. used UInt64 The user's total space usage (bytes). allocation SpaceAllocation The user's space allocation.</returns>
		public ExpandoObject get_space_usage()
		{
			return bNesisApi.Call<ExpandoObject>("Dropbox", bNesisToken, "get_space_usage");
		}

		///<summary>
		/// Get information about a user's account. 
		/// </summary>
		/// <param name="account_id">account_id String(min_length=40, max_length=40) A user's account identifier.</param>
		/// <returns>BasicAccount Basic information about any account. account_id String(min_length= 40, max_length= 40) The user's unique Dropbox ID. name Name Details of a user's name. email String The user's e-mail address. Do not rely on this without checking the email_verified field. Even then, it's possible that the user has since lost access to their e-mail. email_verified Boolean Whether the user has verified their e-mail address. disabled Boolean Whether the user has been disabled. is_teammate Boolean Whether this user is a teammate of the current user. If this account is the current user's account, then this will be true. profile_photo_url String? URL for the photo representing the user, if one is set.This field is optional. team_member_id String? The user's unique team member id. This field will only be present if the user is part of a team and is_teammate is true. This field is optional.</returns>
		public ExpandoObject get_account(string account_id)
		{
			return bNesisApi.Call<ExpandoObject>("Dropbox", bNesisToken, "get_account", account_id);
		}

		///<summary>
		/// Get a thumbnail for an image. This method currently supports files with the following file extensions: jpg, jpeg, png, tiff, tif, gif and bmp.Photos that are larger than 20MB in size won't be converted to a thumbnail. 
		/// </summary>
		/// <param name="path">String(pattern="(/(.|[\r\n])*|id:.*)|(rev:[0-9a-f]{9,})|(ns:[0-9]+(/.*)?)") The path to the image file you want to thumbnail.</param>
		/// <param name="format">ThumbnailFormat The format for the thumbnail image, jpeg (default) or png. For images that are photos, jpeg should be preferred, while png is better for screenshots and digital arts. The default for this union is jpeg.</param>
		/// <param name="size">ThumbnailSize The size for the thumbnail image. The default for this union is w64h64.</param>
		/// <returns></returns>
		public Tuple<string,ExpandoObject> get_thumbnail(string path, string format, string size)
		{
			return bNesisApi.Call<Tuple<string,ExpandoObject>>("Dropbox", bNesisToken, "get_thumbnail", path, format, size);
		}

		///<summary>
		/// Get a copy reference to a file or folder. This reference string can be used to save that file or folder to another user's Dropbox by passing it to copy_reference/save. 
		/// </summary>
		/// <param name="path">path String(pattern="(/(.|[\r\n])*|id:.*)|(rev:[0-9a-f]{9,})|(ns:[0-9]+(/.*)?)") The path to the file or folder you want to get a copy reference to.</param>
		/// <returns>metadata Metadata Metadata of the file or folder. copy_reference String A copy reference to the file or folder. expires Timestamp(format= "%Y-%m-%dT%H:%M:%SZ") The expiration date of the copy reference.This value is currently set to be far enough in the future so that expiration is effectively not an issue.</returns>
		public ExpandoObject copy_reference_get(string path)
		{
			return bNesisApi.Call<ExpandoObject>("Dropbox", bNesisToken, "copy_reference_get", path);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="paths"></param>
		/// <returns></returns>
		public ExpandoObject delete_batch(List<string> paths)
		{
			return bNesisApi.Call<ExpandoObject>("Dropbox", bNesisToken, "delete_batch", paths);
		}

		///<summary>
		/// Save a specified URL into a file in user's Dropbox. If the given path already exists, the file will be renamed to avoid the conflict (e.g. myfile (1).txt). 
		/// </summary>
		/// <param name="path">path String(pattern="/(.|[\r\n])*") The path in Dropbox where the URL will be saved to.</param>
		/// <param name="url">url String The URL to be saved.</param>
		/// <returns>SaveUrlResult (union) The value will be one of the following datatypes: async_job_id String(min_length= 1) This response indicates that the processing is asynchronous.The string is an id that can be used to obtain the status of the asynchronous job.complete FileMetadata Metadata of the file where the URL is saved to.</returns>
		public ExpandoObject save_url(string path, string url)
		{
			return bNesisApi.Call<ExpandoObject>("Dropbox", bNesisToken, "save_url", path, url);
		}

		///<summary>
		/// Check the status of a save_url job. 
		/// </summary>
		/// <param name="async_job_id">TPollArg Arguments for methods that poll the status of an asynchronous job.This datatype comes from an imported namespace originally defined in the async namespace. async_job_id String(min_length=1) Id of the asynchronous job.This is the value of a response returned from the method that launched the job.</param>
		/// <returns>SaveUrlJobStatus (union) The value will be one of the following datatypes: in_progress Void The asynchronous job is still in progress. complete FileMetadata Metadata of the file where the URL is saved to. failed SaveUrlError</returns>
		public ExpandoObject save_url_check_job_status(string async_job_id)
		{
			return bNesisApi.Call<ExpandoObject>("Dropbox", bNesisToken, "save_url_check_job_status", async_job_id);
		}

		///<summary>
		/// Searches for files and folders. Note: Recent changes may not immediately be reflected in search results due to a short delay in indexing. 
		/// </summary>
		/// <param name="path">path String(pattern="(/(.|[\r\n])*)?|(ns:[0-9]+(/.*)?)") The path in the user's Dropbox to search. Should probably be a folder.</param>
		/// <param name="query">query String The string to search for. The search string is split on spaces into multiple tokens. For file name searching, the last token is used for prefix matching (i.e. "bat c" matches "bat cave" but not "batman car").</param>
		/// <returns>mode SearchMode The search mode (filename, filename_and_content, or deleted_filename). Note that searching file content is only available for Dropbox Business accounts. The default for this union is filename.</returns>
		public ExpandoObject search(string path, string query)
		{
			return bNesisApi.Call<ExpandoObject>("Dropbox", bNesisToken, "search", path, query);
		}
}
}