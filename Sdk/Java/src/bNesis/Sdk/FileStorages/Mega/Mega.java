package bNesis.Sdk.FileStorages.Mega;

import java.io.*;
import java.util.List;
import java.util.Date;
import java.util.Map.Entry;
import bNesis.Api.*;

import bNesis.Sdk.Common.*;
import bNesis.Sdk.FileStorages.Common.*;

	public class Mega  
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

		public Mega(bNesisApi bnesisApi)
		{
			this._bNesisApi = bnesisApi;
		}

		/**
		 * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		 * @return {String} bNesisToken value
		 */
		public String Auth(String bNesisDevId,String clientSecret,String redirectUrl,String login,String password) throws Exception
		{
			bNesisToken = _bNesisApi.Auth("Mega", "",bNesisDevId,redirectUrl,"",clientSecret,null,login,password,false,"");
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
			Boolean result = _bNesisApi.LogoffService("Mega", bNesisToken);
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
			return _bNesisApi.<ErrorInfo>Call(ErrorInfo.class, "Mega", bNesisToken, "GetLastError");
		}

		/**
		 *  Getting arrays of error info 	
		 * @return {ErrorInfo[]}  
		 * @throws Exception
		 */
		public ErrorInfo[] GetErrorLog() throws Exception
		{
			return _bNesisApi.<ErrorInfo[]>Call(ErrorInfo[].class, "Mega", bNesisToken, "GetErrorLog");
		}

		/**
		 *  Checks the token in the service. 	
		 * @return {Boolean} if token valid return true, if token not valid return false 
		 * @throws Exception
		 */
		public Boolean ValidateToken() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "Mega", bNesisToken, "ValidateToken");
		}

		/**
		 *  Disables the access token used to authenticate the call. 	
		 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false 
		 * @throws Exception
		 */
		public Boolean Logoff() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "Mega", bNesisToken, "Logoff");
		}

		/**
		 *  Normalizes folder and file paths using current file storage rules. 	
		 * @param path The path to folder or file.
	 * @return {String} String with normalized path. 
		 * @throws Exception
		 */
		public String NormalizePath(String path) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "Mega", bNesisToken, "NormalizePath", path);
		}

		/**
		 *  Gets file entries for a folder. 	
		 * @param path The path to folder.
	 * @return {FileStorageItem[]} Array of IFileStorageItem. 
		 * @throws Exception
		 */
		public FileStorageItem[] GetFiles(String path) throws Exception
		{
			return _bNesisApi.<FileStorageItem[]>Call(FileStorageItem[].class, "Mega", bNesisToken, "GetFiles", path);
		}

		/**
		 *  Gets sub folder entries for a folder. 	
		 * @param path The path to root folder.
	 * @return {FileStorageItem[]} Array of IFileStorageItem. 
		 * @throws Exception
		 */
		public FileStorageItem[] GetFolders(String path) throws Exception
		{
			return _bNesisApi.<FileStorageItem[]>Call(FileStorageItem[].class, "Mega", bNesisToken, "GetFolders", path);
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
			return _bNesisApi.<String>Call(String.class, "Mega", bNesisToken, "CreateFolder", path, name);
		}

		/**
		 *  Delete entry (folder or file). 	
		 * @param path The path to deleted entry.
	 * @return {String} Empty string if OK or an error description otherwise. 
		 * @throws Exception
		 */
		public String Delete(String path) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "Mega", bNesisToken, "Delete", path);
		}

		/**
		 *  Download file. 	
		 * @param path The path to file.
	 * @return {OutputStream} Stream with file or null if error. 
		 * @throws Exception
		 */
		public OutputStream DownloadFile(String path) throws Exception
		{
			return _bNesisApi.<OutputStream>Call(OutputStream.class, "Mega", bNesisToken, "DownloadFile", path);
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
			return _bNesisApi.<String>Call(String.class, "Mega", bNesisToken, "UploadFile", destinationStream, name);
		}
}