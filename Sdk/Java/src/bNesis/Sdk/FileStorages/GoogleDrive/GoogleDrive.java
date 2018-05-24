package bNesis.Sdk.FileStorages.GoogleDrive;

import java.io.*;
import java.util.List;
import java.util.Date;
import java.util.Map.Entry;
import bNesis.Api.*;

import bNesis.Sdk.Common.*;
import bNesis.Sdk.FileStorages.Common.*;
import java.net.URI.*;

	public class GoogleDrive  
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

		public GoogleDrive(bNesisApi bnesisApi)
		{
			this._bNesisApi = bnesisApi;
		}

		/**
		 * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		 * @return {String} bNesisToken value
		 */
		public String Auth(String bNesisDevId,String clientId,String clientSecret,String redirectUrl,String[] scopes) throws Exception
		{
			bNesisToken = _bNesisApi.Auth("Google", "",bNesisDevId,redirectUrl,clientId,clientSecret,scopes,"","",false,"");
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
			Boolean result = _bNesisApi.LogoffService("Google", bNesisToken);
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
			return _bNesisApi.<ErrorInfo>Call(ErrorInfo.class, "GoogleDrive", bNesisToken, "GetLastError");
		}

		/**
		 *  Getting arrays of error info 	
		 * @return {ErrorInfo[]}  
		 * @throws Exception
		 */
		public ErrorInfo[] GetErrorLog() throws Exception
		{
			return _bNesisApi.<ErrorInfo[]>Call(ErrorInfo[].class, "GoogleDrive", bNesisToken, "GetErrorLog");
		}

		/**
		 *  Checks the token in the service. 	
		 * @return {Boolean} if token valid return true, if token not valid return false 
		 * @throws Exception
		 */
		public Boolean ValidateToken() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "GoogleDrive", bNesisToken, "ValidateToken");
		}

		/**
		 *  Disables the access token used to authenticate the call. 	
		 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false 
		 * @throws Exception
		 */
		public Boolean Logoff() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "GoogleDrive", bNesisToken, "Logoff");
		}

		/**
		 *  Normalizes folder and file paths using current file storage rules. 	
		 * @param path The path to folder or file.
	 * @return {String} String with normalized path. 
		 * @throws Exception
		 */
		public String NormalizePath(String path) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "GoogleDrive", bNesisToken, "NormalizePath", path);
		}

		/**
		 *  Gets file entries for a folder. 	
		 * @param path The path to folder.
	 * @return {FileStorageItem[]} Array of IFileStorageItem. 
		 * @throws Exception
		 */
		public FileStorageItem[] GetFiles(String path) throws Exception
		{
			return _bNesisApi.<FileStorageItem[]>Call(FileStorageItem[].class, "GoogleDrive", bNesisToken, "GetFiles", path);
		}

		/**
		 *  Gets sub folder entries for a folder. 	
		 * @param path The path to root folder.
	 * @return {FileStorageItem[]} Array of IFileStorageItem. 
		 * @throws Exception
		 */
		public FileStorageItem[] GetFolders(String path) throws Exception
		{
			return _bNesisApi.<FileStorageItem[]>Call(FileStorageItem[].class, "GoogleDrive", bNesisToken, "GetFolders", path);
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
			return _bNesisApi.<String>Call(String.class, "GoogleDrive", bNesisToken, "CreateFolder", path, name);
		}

		/**
		 *  Delete entry (folder or file). 	
		 * @param path The path to deleted entry.
	 * @return {String} Empty string if OK or an error description otherwise. 
		 * @throws Exception
		 */
		public String Delete(String path) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "GoogleDrive", bNesisToken, "Delete", path);
		}

		/**
		 *  Download file. 	
		 * @param path The path to file.
	 * @return {OutputStream} Stream with file or null if error. 
		 * @throws Exception
		 */
		public OutputStream DownloadFile(String path) throws Exception
		{
			return _bNesisApi.<OutputStream>Call(OutputStream.class, "GoogleDrive", bNesisToken, "DownloadFile", path);
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
			return _bNesisApi.<String>Call(String.class, "GoogleDrive", bNesisToken, "UploadFile", destinationStream, name);
		}

		/**
		 *  Gets the Google Drive files fields (https://developers.google.com/drive/v3/reference/files) 	
		 * @param path The folder path.
	 * @param fileFields List of Google Drive file fields to be retrived.
	 * @return {Object[]} IEnumerable of ExpandoObject. 
		 * @throws Exception
		 */
		public Object[] GetFilesFields(String path, String fileFields) throws Exception
		{
			return _bNesisApi.<Object[]>Call(Object[].class, "GoogleDrive", bNesisToken, "GetFilesFields", path, fileFields);
		}

		/**
		 *  Copies the specified file. (https://developers.google.com/drive/v3/reference/files/copy) 	
		 * @param path The file identifier or path.
	 * @param toPath To path.
	 * @return {Object} metadata 
		 * @throws Exception
		 */
		public Object copy(String path, String toPath) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "GoogleDrive", bNesisToken, "copy", path, toPath);
		}

		/**
		 *  Gets the metadata. 	
		 * @param path The file identifier or path.
	 * @param fields The fields.
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object get_metadata(String path, String fields) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "GoogleDrive", bNesisToken, "get_metadata", path, fields);
		}

		/**
		 *  Exports the specified file identifier. (https://developers.google.com/drive/v3/reference/files/export) 	
		 * @param path The file identifier or path.
	 * @param mimeType Type of the MIME.
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object export(String path, String mimeType) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "GoogleDrive", bNesisToken, "export", path, mimeType);
		}

		/**
		 *  Permanently deletes all of the user's trashed files. 	
		 * @return {Object} If successful, this method returns an empty response body. 
		 * @throws Exception
		 */
		public Object emptyTrash() throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "GoogleDrive", bNesisToken, "emptyTrash");
		}

		/**
		 *  Searching files.(https://developers.google.com/drive/v3/reference/files/list) 	
		 * @param fileName The order by.
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object search(String fileName) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "GoogleDrive", bNesisToken, "search", fileName);
		}

		/**
		 *  Updates the specified file identifier.(https://developers.google.com/drive/v3/reference/files/update) 	
		 * @param path The file identifier or path.
	 * @param addParents The add parents.
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object update(String path, String addParents) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "GoogleDrive", bNesisToken, "update", path, addParents);
		}

		/**
		 *  Watches the specified file identifier.(https://developers.google.com/drive/v3/reference/files/watch) 	
		 * @param path The file identifier or path.
	 * @param address The address where notifications are delivered for this channel.
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object watch(String path, String address) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "GoogleDrive", bNesisToken, "watch", path, address);
		}

		/**
		 *  Generates the ids. 	
		 * @param count The count.
	 * @param space The space.
	 * @return {Object}  
		 * @throws Exception
		 */
		public Object generateIds(Integer count, String space) throws Exception
		{
			return _bNesisApi.<Object>Call(Object.class, "GoogleDrive", bNesisToken, "generateIds", count, space);
		}

		/**
		 *  Gets the information about the current user along with Drive API settings. 	
		 * @param includeSubscribed When calculating the number of remaining change IDs, whether to include public files the user has opened and shared files. When set to false, this counts only change IDs for owned files and any shared or public files that the user has explicitly added to a folder they own. (Default: true)
	 * @param maxChangeIdCount Maximum number of remaining change IDs to count
	 * @param startChangeId Change ID to start counting from when calculating number of remaining change IDs
	 * @return {Response} If successful, this method returns an About resource in the response body. 
		 * @throws Exception
		 */
		public Response AboutRaw(Boolean includeSubscribed, Long maxChangeIdCount, Long startChangeId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "GoogleDrive", bNesisToken, "AboutRaw", includeSubscribed, maxChangeIdCount, startChangeId);
		}
}