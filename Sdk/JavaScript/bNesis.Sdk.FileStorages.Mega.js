Mega = function (bNesisApi) {
    this.bNesisToken = null;
    var _bNesisApi = bNesisApi;

    this.Auth = function (data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl) {
        var bNesisToken = _bNesisApi.Auth("Mega", data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl);
        return bNesisToken;
    }
	
	/**
	 *  Getting last exception for current provider 	
	 * @return {ErrorInfo} 
	 */
    this.GetLastError = function () {
        var result = _bNesisApi.Call("Mega", this.bNesisToken, "GetLastError");
        return result;
    }

	/**
	 *  Getting arrays of error info 	
	 * @return {ErrorInfo[]} 
	 */
    this.GetErrorLog = function () {
        var result = _bNesisApi.Call("Mega", this.bNesisToken, "GetErrorLog");
        return result;
    }

	/**
	 *  Checks the token in the service. 	
	 * @return {Boolean} if token valid return true, if token not valid return false
	 */
    this.ValidationTokenUnified = function () {
        var result = _bNesisApi.Call("Mega", this.bNesisToken, "ValidationTokenUnified");
        return result;
    }

	/**
	 *  Normalizes folder and file paths using current file storage rules. 	
	 * @param path The path to folder or file.
	 * @return {string} String with normalized path.
	 */
    this.NormalizePath = function (path) {
        var result = _bNesisApi.Call("Mega", this.bNesisToken, "NormalizePath", path);
        return result;
    }

	/**
	 *  Gets file entries for a folder. 	
	 * @param path The path to folder.
	 * @return {FileStorageItem[]} Array of IFileStorageItem.
	 */
    this.GetFiles = function (path) {
        var result = _bNesisApi.Call("Mega", this.bNesisToken, "GetFiles", path);
        return result;
    }

	/**
	 *  Gets sub folder entries for a folder. 	
	 * @param path The path to root folder.
	 * @return {FileStorageItem[]} Array of IFileStorageItem.
	 */
    this.GetFolders = function (path) {
        var result = _bNesisApi.Call("Mega", this.bNesisToken, "GetFolders", path);
        return result;
    }

	/**
	 *  Create folder entry for a folder. 	
	 * @param path The path to the created folder.
	 * @param name The name of the new created folder.
	 * @return {string} Empty string if OK or an error description otherwise.
	 */
    this.CreateFolder = function (path, name) {
        var result = _bNesisApi.Call("Mega", this.bNesisToken, "CreateFolder", path, name);
        return result;
    }

	/**
	 *  Delete entry (folder or file). 	
	 * @param path The path to deleted entry.
	 * @return {string} Empty string if OK or an error description otherwise.
	 */
    this.Delete = function (path) {
        var result = _bNesisApi.Call("Mega", this.bNesisToken, "Delete", path);
        return result;
    }

	/**
	 *  Download file. 	
	 * @param path The path to file.
	 * @return {Stream} Stream with file or null if error.
	 */
    this.DownloadFile = function (path) {
        var result = _bNesisApi.Call("Mega", this.bNesisToken, "DownloadFile", path);
        return result;
    }

	/**
	 *  Upload file. 	
	 * @param destinationStream Stream with file data.
	 * @param name Name of new file.
	 * @return {string} Empty string if OK or an error description otherwise.
	 */
    this.UploadFile = function (destinationStream, name) {
        var result = _bNesisApi.Call("Mega", this.bNesisToken, "UploadFile", destinationStream, name);
        return result;
    }
}
