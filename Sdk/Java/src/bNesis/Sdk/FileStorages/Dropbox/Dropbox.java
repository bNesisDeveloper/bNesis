package bNesis.Sdk.FileStorages.Dropbox;

import java.io.*;
import java.util.List;
import java.util.Date;
import java.util.Map.Entry;
import bNesis.Api.*;

import bNesis.Sdk.Common.*;
import bNesis.Sdk.FileStorages.Common.*;
import java.net.URI.*;

	public class Dropbox  
	{
		/**
		 * bNesisToken is a unique identifier of the current service work session
		 * bNesisToken is relevant only after successful authorization in the service.
		 * The Auth() method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		 * The LogoffService() method stops the authorization session with the service and clears the value of bNesisToken.
		 */
		public String bNesisToken= "";

		/**
		 * bNesis Core object
		 */
		private bNesisApi _bNesisApi;

		public Dropbox(bNesisApi bnesisApi)
		{
			this._bNesisApi = bnesisApi;
		}

		/**
		 * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		 * @return {String} bNesisToken value
		 */
		public String Auth(String bNesisDevId,String clientId,String clientSecret,String redirectUrl) throws Exception
		{
			bNesisToken = _bNesisApi.Auth("Dropbox", "",bNesisDevId,redirectUrl,clientId,clientSecret,null,"","",false,"");
			return bNesisToken;
		}

		/**
		 * Attach to bNesis session with exists bNesis token
		 * @return {Boolean} true if bNesisToken is valid
		 */
		public Boolean Auth(String bNesisToken) throws Exception
		{
		    this.bNesisToken = bNesisToken;			
			return ValidateToken();
		}

		/**
		 * The method stops the authorization session with the service and clears the value of bNesisToken.
		 * @return {Boolean} true - if service logoff is successful
		 */
		public Boolean LogoffService()
		{
			Boolean result = _bNesisApi.LogoffService("Dropbox", bNesisToken);
			if (result) bNesisToken = "";
			return result;             
		}


		/**
		 *  Getting last exception for current provider 	
		 * @return {ErrorInfo}  
		 * @throws Exception
		 */
		public ErrorInfo GetLastError() throws Exception
		{
			return _bNesisApi.<ErrorInfo>Call(ErrorInfo.class, "Dropbox", bNesisToken, "GetLastError");
		}

		/**
		 *  Getting arrays of error info 	
		 * @return {ErrorInfo[]}  
		 * @throws Exception
		 */
		public ErrorInfo[] GetErrorLog() throws Exception
		{
			return _bNesisApi.<ErrorInfo[]>Call(ErrorInfo[].class, "Dropbox", bNesisToken, "GetErrorLog");
		}

		/**
		 *  Checks the token in the service. 	
		 * @return {Boolean} if token valid return true, if token not valid return false 
		 * @throws Exception
		 */
		public Boolean ValidateToken() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "Dropbox", bNesisToken, "ValidateToken");
		}

		/**
		 *  Disables the access token used to authenticate the call. 	
		 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false 
		 * @throws Exception
		 */
		public Boolean Logoff() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "Dropbox", bNesisToken, "Logoff");
		}

		/**
		 *  Normalizes folder and file paths using current file storage rules. 	
		 * @param path The path to folder or file.
	 * @return {String} String with normalized path. 
		 * @throws Exception
		 */
		public String NormalizePath(String path) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "Dropbox", bNesisToken, "NormalizePath", path);
		}

		/**
		 *  Gets file entries for a folder. 	
		 * @param path The path to folder.
	 * @return {FileStorageItem[]} Array of IFileStorageItem. 
		 * @throws Exception
		 */
		public FileStorageItem[] GetFiles(String path) throws Exception
		{
			return _bNesisApi.<FileStorageItem[]>Call(FileStorageItem[].class, "Dropbox", bNesisToken, "GetFiles", path);
		}

		/**
		 *  Gets sub folder entries for a folder. 	
		 * @param path The path to root folder.
	 * @return {FileStorageItem[]} Array of IFileStorageItem. 
		 * @throws Exception
		 */
		public FileStorageItem[] GetFolders(String path) throws Exception
		{
			return _bNesisApi.<FileStorageItem[]>Call(FileStorageItem[].class, "Dropbox", bNesisToken, "GetFolders", path);
		}

		/**
		 *  Create folder entry for a folder. 	
		 * @param path The path to the created folder.
	 * @param name The name of the new created folder.
	 * @return {String} Empty string if OK or an error description otherwise. 
		 * @throws Exception
		 */
		public String CreateFolder(String path, String name) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "Dropbox", bNesisToken, "CreateFolder", path, name);
		}

		/**
		 *  Delete entry (folder or file). 	
		 * @param path The path to deleted entry.
	 * @return {String} Empty string if OK or an error description otherwise. 
		 * @throws Exception
		 */
		public String Delete(String path) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "Dropbox", bNesisToken, "Delete", path);
		}

		/**
		 *  Download file. 	
		 * @param path The path to file.
	 * @return {OutputStream} Stream with file or null if error. 
		 * @throws Exception
		 */
		public OutputStream DownloadFile(String path) throws Exception
		{
			return _bNesisApi.<OutputStream>Call(OutputStream.class, "Dropbox", bNesisToken, "DownloadFile", path);
		}

		/**
		 *  Upload file. 	
		 * @param destinationStream Stream with file data.
	 * @param name Name of new file.
	 * @return {String} Empty string if OK or an error description otherwise. 
		 * @throws Exception
		 */
		public String UploadFile(OutputStream destinationStream, String name) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "Dropbox", bNesisToken, "UploadFile", destinationStream, name);
		}

		/**
		 *   	
		 * @param path 
	 * @param include_media_info 
	 * @param include_deleted 
	 * @param include_has_explicit_shared_members 
	 * @param include_property_templates 
	 * @return {Response}  
		 * @throws Exception
		 */
		public Response get_metadataRaw(String path, Boolean include_media_info, Boolean include_deleted, Boolean include_has_explicit_shared_members, String include_property_templates) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Dropbox", bNesisToken, "get_metadataRaw", path, include_media_info, include_deleted, include_has_explicit_shared_members, include_property_templates);
		}

		/**
		 *  Get a preview for a file.
	 * Currently, PDF previews are generated for files with the following extensions: .ai, .doc, .docm, .docx, .eps, .odp, .odt, .pps, .ppsm, .ppsx, .ppt, .pptm, .pptx, .rtf.
	 * HTML previews are generated for files with the following extensions: .csv, .ods, .xls, .xlsm, .xlsx.
	 * Other formats will return an unsupported extension error. 	
		 * @param path String(pattern="(/(.|[\r\n])*|id:.*)|(rev:[0-9a-f]{9,})|(ns:[0-9]+(/.*)?)") The path of the file to preview.
	 * @param rev String(min_length=9, pattern="[0-9a-f]+")? Deprecated. Please specify revision in path instead. This field is optional.
	 * @return {Entry<String,Object>} https://www.dropbox.com/developers/documentation/http/documentation#files-get_preview 
		 * @throws Exception
		 */
		public Entry<String,Object> get_preview(String path, String rev) throws Exception
		{
			return _bNesisApi.<Entry<String,Object>>Call((Class<Entry<String,Object>>)(Object)Entry.class, "Dropbox", bNesisToken, "get_preview", path, rev);
		}

		/**
		 *   	
		 * @param from_path 
	 * @param to_path 
	 * @param allow_shared_folder 
	 * @param autorename 
	 * @return {String}  
		 * @throws Exception
		 */
		public String copy(String from_path, String to_path, Boolean allow_shared_folder, Boolean autorename) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "Dropbox", bNesisToken, "copy", from_path, to_path, allow_shared_folder, autorename);
		}

		/**
		 *   	
		 * @param from_path 
	 * @param to_path 
	 * @param allow_shared_folder 
	 * @param autorename 
	 * @param allow_ownership_transfer 
	 * @return {String}  
		 * @throws Exception
		 */
		public String move(String from_path, String to_path, Boolean allow_shared_folder, Boolean autorename, Boolean allow_ownership_transfer) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "Dropbox", bNesisToken, "move", from_path, to_path, allow_shared_folder, autorename, allow_ownership_transfer);
		}

		/**
		 *  Get information about the current user's account. 	
		 * @return {Response} https://www.dropbox.com/developers/documentation/http/documentation#users-get_current_account 
		 * @throws Exception
		 */
		public Response get_current_accountRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Dropbox", bNesisToken, "get_current_accountRaw");
		}

		/**
		 *  Get a temporary link to stream content of a file. This link will expire in four hours and afterwards you will get 410 Gone. Content-Type of the link is determined automatically by the file's mime type. 	
		 * @param path The path.
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object get_temporary_link(String path) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "Dropbox", bNesisToken, "get_temporary_link", path);
		}

		/**
		 *  Get the space usage information for the current user's account. 	
		 * @return {Object} SpaceUsage. Information about a user's space usage and quota. used UInt64 The user's total space usage (bytes). allocation SpaceAllocation The user's space allocation. 
		 * @throws Exception
		 */
		public Object get_space_usage() throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "Dropbox", bNesisToken, "get_space_usage");
		}

		/**
		 *  Get information about a user's account. 	
		 * @param account_id account_id String(min_length=40, max_length=40) A user's account identifier.
	 * @return {Object} BasicAccount Basic information about any account. account_id String(min_length= 40, max_length= 40) The user's unique Dropbox ID. name Name Details of a user's name. email String The user's e-mail address. Do not rely on this without checking the email_verified field. Even then, it's possible that the user has since lost access to their e-mail. email_verified Boolean Whether the user has verified their e-mail address. disabled Boolean Whether the user has been disabled. is_teammate Boolean Whether this user is a teammate of the current user. If this account is the current user's account, then this will be true. profile_photo_url String? URL for the photo representing the user, if one is set.This field is optional. team_member_id String? The user's unique team member id. This field will only be present if the user is part of a team and is_teammate is true. This field is optional. 
		 * @throws Exception
		 */
		public Object get_account(String account_id) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "Dropbox", bNesisToken, "get_account", account_id);
		}

		/**
		 *  Get a thumbnail for an image. This method currently supports files with the following file extensions: jpg, jpeg, png, tiff, tif, gif and bmp.Photos that are larger than 20MB in size won't be converted to a thumbnail. 	
		 * @param path String(pattern="(/(.|[\r\n])*|id:.*)|(rev:[0-9a-f]{9,})|(ns:[0-9]+(/.*)?)") The path to the image file you want to thumbnail.
	 * @param format ThumbnailFormat The format for the thumbnail image, jpeg (default) or png. For images that are photos, jpeg should be preferred, while png is better for screenshots and digital arts. The default for this union is jpeg.
	 * @param size ThumbnailSize The size for the thumbnail image. The default for this union is w64h64.
	 * @return {Entry<String,Object>}  
		 * @throws Exception
		 */
		public Entry<String,Object> get_thumbnail(String path, String format, String size) throws Exception
		{
			return _bNesisApi.<Entry<String,Object>>Call((Class<Entry<String,Object>>)(Object)Entry.class, "Dropbox", bNesisToken, "get_thumbnail", path, format, size);
		}

		/**
		 *  Get a copy reference to a file or folder. This reference string can be used to save that file or folder to another user's Dropbox by passing it to copy_reference/save. 	
		 * @param path path String(pattern="(/(.|[\r\n])*|id:.*)|(rev:[0-9a-f]{9,})|(ns:[0-9]+(/.*)?)") The path to the file or folder you want to get a copy reference to.
	 * @return {Object} metadata Metadata Metadata of the file or folder. copy_reference String A copy reference to the file or folder. expires Timestamp(format= "%Y-%m-%dT%H:%M:%SZ") The expiration date of the copy reference.This value is currently set to be far enough in the future so that expiration is effectively not an issue. 
		 * @throws Exception
		 */
		public Object copy_reference_get(String path) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "Dropbox", bNesisToken, "copy_reference_get", path);
		}

		/**
		 *   	
		 * @param paths 
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object delete_batch(List<String> paths) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "Dropbox", bNesisToken, "delete_batch", paths);
		}

		/**
		 *  Save a specified URL into a file in user's Dropbox. If the given path already exists, the file will be renamed to avoid the conflict (e.g. myfile (1).txt). 	
		 * @param path path String(pattern="/(.|[\r\n])*") The path in Dropbox where the URL will be saved to.
	 * @param url url String The URL to be saved.
	 * @return {Object} SaveUrlResult (union) The value will be one of the following datatypes: async_job_id String(min_length= 1) This response indicates that the processing is asynchronous.The string is an id that can be used to obtain the status of the asynchronous job.complete FileMetadata Metadata of the file where the URL is saved to. 
		 * @throws Exception
		 */
		public Object save_url(String path, String url) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "Dropbox", bNesisToken, "save_url", path, url);
		}

		/**
		 *  Check the status of a save_url job. 	
		 * @param async_job_id TPollArg Arguments for methods that poll the status of an asynchronous job.This datatype comes from an imported namespace originally defined in the async namespace. async_job_id String(min_length=1) Id of the asynchronous job.This is the value of a response returned from the method that launched the job.
	 * @return {Object} SaveUrlJobStatus (union) The value will be one of the following datatypes: in_progress Void The asynchronous job is still in progress. complete FileMetadata Metadata of the file where the URL is saved to. failed SaveUrlError 
		 * @throws Exception
		 */
		public Object save_url_check_job_status(String async_job_id) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "Dropbox", bNesisToken, "save_url_check_job_status", async_job_id);
		}

		/**
		 *  Searches for files and folders. Note: Recent changes may not immediately be reflected in search results due to a short delay in indexing. 	
		 * @param path path String(pattern="(/(.|[\r\n])*)?|(ns:[0-9]+(/.*)?)") The path in the user's Dropbox to search. Should probably be a folder.
	 * @param query query String The string to search for. The search string is split on spaces into multiple tokens. For file name searching, the last token is used for prefix matching (i.e. "bat c" matches "bat cave" but not "batman car").
	 * @return {Object} mode SearchMode The search mode (filename, filename_and_content, or deleted_filename). Note that searching file content is only available for Dropbox Business accounts. The default for this union is filename. 
		 * @throws Exception
		 */
		public Object search(String path, String query) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "Dropbox", bNesisToken, "search", path, query);
		}
}