GoogleDrive = function (bNesisApi) {
    this.bNesisToken = null;
    var _bNesisApi = bNesisApi;

    /**
     * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
	 * or Attach to bNesis session with exists bNesis token
     * @return {string} bNesisToken value | true if bNesisToken is valid
	 */
    this.Auth = function (bNesisDevId,redirectUrl,clientId,clientSecret,scopes) {
		if(arguments.length !== 1){
			var bNesisToken = _bNesisApi.Auth("Google", "",bNesisDevId,redirectUrl,clientId,clientSecret,scopes,"","",false,"");
			return bNesisToken;
		}
		else{
		    this.bNesisToken = arguments[0];			
			return ValidateToken();		
		}		
    }

    /**
     * The method stops the authorization session with the service and clears the value of bNesisToken.
     * @return {Boolean} true - if service logoff is successful
	 */
    this.LogoffService = function () {
		var result = _bNesisApi.LogoffService("Google", this.bNesisToken);
		if (result) this.bNesisToken = "";
		return result;             
    }
	
	/**
	 *  Getting last exception for current provider 	
	 * @return {ErrorInfo} 
	 */
    this.GetLastError = function () {
        var result = _bNesisApi.Call("GoogleDrive", this.bNesisToken, "GetLastError");
        return result;
    }

	/**
	 *  Getting arrays of error info 	
	 * @return {ErrorInfo[]} 
	 */
    this.GetErrorLog = function () {
        var result = _bNesisApi.Call("GoogleDrive", this.bNesisToken, "GetErrorLog");
        return result;
    }

	/**
	 *  Checks the token in the service. 	
	 * @return {Boolean} if token valid return true, if token not valid return false
	 */
    this.ValidateToken = function () {
        var result = _bNesisApi.Call("GoogleDrive", this.bNesisToken, "ValidateToken");
        return result;
    }

	/**
	 *  Disables the access token used to authenticate the call. 	
	 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false
	 */
    this.Logoff = function () {
        var result = _bNesisApi.Call("GoogleDrive", this.bNesisToken, "Logoff");
        return result;
    }

	/**
	 *  Normalizes folder and file paths using current file storage rules. 	
	 * @param path The path to folder or file.
	 * @return {string} String with normalized path.
	 */
    this.NormalizePath = function (path) {
        var result = _bNesisApi.Call("GoogleDrive", this.bNesisToken, "NormalizePath", path);
        return result;
    }

	/**
	 *  Gets file entries for a folder. 	
	 * @param path The path to folder.
	 * @return {FileStorageItem[]} Array of IFileStorageItem.
	 */
    this.GetFiles = function (path) {
        var result = _bNesisApi.Call("GoogleDrive", this.bNesisToken, "GetFiles", path);
        return result;
    }

	/**
	 *  Gets sub folder entries for a folder. 	
	 * @param path The path to root folder.
	 * @return {FileStorageItem[]} Array of IFileStorageItem.
	 */
    this.GetFolders = function (path) {
        var result = _bNesisApi.Call("GoogleDrive", this.bNesisToken, "GetFolders", path);
        return result;
    }

	/**
	 *  Create folder entry for a folder. 	
	 * @param path The path to the created folder.
	 * @param name The name of the new created folder.
	 * @return {string} Empty string if OK or an error description otherwise.
	 */
    this.CreateFolder = function (path, name) {
        var result = _bNesisApi.Call("GoogleDrive", this.bNesisToken, "CreateFolder", path, name);
        return result;
    }

	/**
	 *  Delete entry (folder or file). 	
	 * @param path The path to deleted entry.
	 * @return {string} Empty string if OK or an error description otherwise.
	 */
    this.Delete = function (path) {
        var result = _bNesisApi.Call("GoogleDrive", this.bNesisToken, "Delete", path);
        return result;
    }

	/**
	 *  Download file. 	
	 * @param path The path to file.
	 * @return {Stream} Stream with file or null if error.
	 */
    this.DownloadFile = function (path) {
        var result = _bNesisApi.Call("GoogleDrive", this.bNesisToken, "DownloadFile", path);
        return result;
    }

	/**
	 *  Upload file. 	
	 * @param destinationStream Stream with file data.
	 * @param name Name of new file.
	 * @return {string} Empty string if OK or an error description otherwise.
	 */
    this.UploadFile = function (destinationStream, name) {
        var result = _bNesisApi.Call("GoogleDrive", this.bNesisToken, "UploadFile", destinationStream, name);
        return result;
    }

	/**
	 *  Gets the Google Drive files fields (https://developers.google.com/drive/v3/reference/files) 	
	 * @param path The folder path.
	 * @param fileFields List of Google Drive file fields to be retrived.
	 * @return {Object[]} IEnumerable of ExpandoObject.
	 */
    this.GetFilesFields = function (path, fileFields) {
        var result = _bNesisApi.Call("GoogleDrive", this.bNesisToken, "GetFilesFields", path, fileFields);
        return result;
    }

	/**
	 *  Copies the specified file. (https://developers.google.com/drive/v3/reference/files/copy) 	
	 * @param path The file identifier or path.
	 * @param toPath To path.
	 * @return {Object} metadata
	 */
    this.copy = function (path, toPath) {
        var result = _bNesisApi.Call("GoogleDrive", this.bNesisToken, "copy", path, toPath);
        return result;
    }

	/**
	 *  Gets the metadata. 	
	 * @param path The file identifier or path.
	 * @param fields The fields.
	 * @return {Object} 
	 */
    this.get_metadata = function (path, fields) {
        var result = _bNesisApi.Call("GoogleDrive", this.bNesisToken, "get_metadata", path, fields);
        return result;
    }

	/**
	 *  Exports the specified file identifier. (https://developers.google.com/drive/v3/reference/files/export) 	
	 * @param path The file identifier or path.
	 * @param mimeType Type of the MIME.
	 * @return {Object} 
	 */
    this.export = function (path, mimeType) {
        var result = _bNesisApi.Call("GoogleDrive", this.bNesisToken, "export", path, mimeType);
        return result;
    }

	/**
	 *  Permanently deletes all of the user's trashed files. 	
	 * @return {Object} If successful, this method returns an empty response body.
	 */
    this.emptyTrash = function () {
        var result = _bNesisApi.Call("GoogleDrive", this.bNesisToken, "emptyTrash");
        return result;
    }

	/**
	 *  Searching files.(https://developers.google.com/drive/v3/reference/files/list) 	
	 * @param fileName The order by.
	 * @return {Object} 
	 */
    this.search = function (fileName) {
        var result = _bNesisApi.Call("GoogleDrive", this.bNesisToken, "search", fileName);
        return result;
    }

	/**
	 *  Updates the specified file identifier.(https://developers.google.com/drive/v3/reference/files/update) 	
	 * @param path The file identifier or path.
	 * @param addParents The add parents.
	 * @return {Object} 
	 */
    this.update = function (path, addParents) {
        var result = _bNesisApi.Call("GoogleDrive", this.bNesisToken, "update", path, addParents);
        return result;
    }

	/**
	 *  Watches the specified file identifier.(https://developers.google.com/drive/v3/reference/files/watch) 	
	 * @param path The file identifier or path.
	 * @param address The address where notifications are delivered for this channel.
	 * @return {Object} 
	 */
    this.watch = function (path, address) {
        var result = _bNesisApi.Call("GoogleDrive", this.bNesisToken, "watch", path, address);
        return result;
    }

	/**
	 *  Generates the ids. 	
	 * @param count The count.
	 * @param space The space.
	 * @return {Object} 
	 */
    this.generateIds = function (count, space) {
        var result = _bNesisApi.Call("GoogleDrive", this.bNesisToken, "generateIds", count, space);
        return result;
    }

	/**
	 *  Gets the information about the current user along with Drive API settings. 	
	 * @param includeSubscribed When calculating the number of remaining change IDs, whether to include public files the user has opened and shared files. When set to false, this counts only change IDs for owned files and any shared or public files that the user has explicitly added to a folder they own. (Default: true)
	 * @param maxChangeIdCount Maximum number of remaining change IDs to count
	 * @param startChangeId Change ID to start counting from when calculating number of remaining change IDs
	 * @return {Response} If successful, this method returns an About resource in the response body.
	 */
    this.AboutRaw = function (includeSubscribed, maxChangeIdCount, startChangeId) {
        var result = _bNesisApi.Call("GoogleDrive", this.bNesisToken, "AboutRaw", includeSubscribed, maxChangeIdCount, startChangeId);
        return result;
    }
}
