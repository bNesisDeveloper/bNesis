Dropbox = function (bNesisApi) {
    this.bNesisToken = null;
    var _bNesisApi = bNesisApi;

    /**
     * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
	 * or Attach to bNesis session with exists bNesis token
     * @return {string} bNesisToken value | true if bNesisToken is valid
	 */
    this.Auth = function (bNesisDevId,redirectUrl,clientId,clientSecret) {
		if(arguments.length !== 1){
			var bNesisToken = _bNesisApi.Auth("Dropbox", "",bNesisDevId,redirectUrl,clientId,clientSecret,null,"","",false,"");
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
		var result = _bNesisApi.LogoffService("Dropbox", this.bNesisToken);
		if (result) this.bNesisToken = "";
		return result;             
    }
	
	/**
	 *  Getting last exception for current provider 	
	 * @return {ErrorInfo} 
	 */
    this.GetLastError = function () {
        var result = _bNesisApi.Call("Dropbox", this.bNesisToken, "GetLastError");
        return result;
    }

	/**
	 *  Getting arrays of error info 	
	 * @return {ErrorInfo[]} 
	 */
    this.GetErrorLog = function () {
        var result = _bNesisApi.Call("Dropbox", this.bNesisToken, "GetErrorLog");
        return result;
    }

	/**
	 *  Checks the token in the service. 	
	 * @return {Boolean} if token valid return true, if token not valid return false
	 */
    this.ValidateToken = function () {
        var result = _bNesisApi.Call("Dropbox", this.bNesisToken, "ValidateToken");
        return result;
    }

	/**
	 *  Disables the access token used to authenticate the call. 	
	 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false
	 */
    this.Logoff = function () {
        var result = _bNesisApi.Call("Dropbox", this.bNesisToken, "Logoff");
        return result;
    }

	/**
	 *  Normalizes folder and file paths using current file storage rules. 	
	 * @param path The path to folder or file.
	 * @return {string} String with normalized path.
	 */
    this.NormalizePath = function (path) {
        var result = _bNesisApi.Call("Dropbox", this.bNesisToken, "NormalizePath", path);
        return result;
    }

	/**
	 *  Gets file entries for a folder. 	
	 * @param path The path to folder.
	 * @return {FileStorageItem[]} Array of IFileStorageItem.
	 */
    this.GetFiles = function (path) {
        var result = _bNesisApi.Call("Dropbox", this.bNesisToken, "GetFiles", path);
        return result;
    }

	/**
	 *  Gets sub folder entries for a folder. 	
	 * @param path The path to root folder.
	 * @return {FileStorageItem[]} Array of IFileStorageItem.
	 */
    this.GetFolders = function (path) {
        var result = _bNesisApi.Call("Dropbox", this.bNesisToken, "GetFolders", path);
        return result;
    }

	/**
	 *  Create folder entry for a folder. 	
	 * @param path The path to the created folder.
	 * @param name The name of the new created folder.
	 * @return {string} Empty string if OK or an error description otherwise.
	 */
    this.CreateFolder = function (path, name) {
        var result = _bNesisApi.Call("Dropbox", this.bNesisToken, "CreateFolder", path, name);
        return result;
    }

	/**
	 *  Delete entry (folder or file). 	
	 * @param path The path to deleted entry.
	 * @return {string} Empty string if OK or an error description otherwise.
	 */
    this.Delete = function (path) {
        var result = _bNesisApi.Call("Dropbox", this.bNesisToken, "Delete", path);
        return result;
    }

	/**
	 *  Download file. 	
	 * @param path The path to file.
	 * @return {Stream} Stream with file or null if error.
	 */
    this.DownloadFile = function (path) {
        var result = _bNesisApi.Call("Dropbox", this.bNesisToken, "DownloadFile", path);
        return result;
    }

	/**
	 *  Upload file. 	
	 * @param destinationStream Stream with file data.
	 * @param name Name of new file.
	 * @return {string} Empty string if OK or an error description otherwise.
	 */
    this.UploadFile = function (destinationStream, name) {
        var result = _bNesisApi.Call("Dropbox", this.bNesisToken, "UploadFile", destinationStream, name);
        return result;
    }

	/**
	 *   	
	 * @param path 
	 * @param include_media_info 
	 * @param include_deleted 
	 * @param include_has_explicit_shared_members 
	 * @param include_property_templates 
	 * @return {Response} 
	 */
    this.get_metadataRaw = function (path, include_media_info, include_deleted, include_has_explicit_shared_members, include_property_templates) {
        var result = _bNesisApi.Call("Dropbox", this.bNesisToken, "get_metadataRaw", path, include_media_info, include_deleted, include_has_explicit_shared_members, include_property_templates);
        return result;
    }

	/**
	 *  Get a preview for a file.
	 * Currently, PDF previews are generated for files with the following extensions: .ai, .doc, .docm, .docx, .eps, .odp, .odt, .pps, .ppsm, .ppsx, .ppt, .pptm, .pptx, .rtf.
	 * HTML previews are generated for files with the following extensions: .csv, .ods, .xls, .xlsm, .xlsx.
	 * Other formats will return an unsupported extension error. 	
	 * @param path String(pattern="(/(.|[\r\n])*|id:.*)|(rev:[0-9a-f]{9,})|(ns:[0-9]+(/.*)?)") The path of the file to preview.
	 * @param rev String(min_length=9, pattern="[0-9a-f]+")? Deprecated. Please specify revision in path instead. This field is optional.
	 * @return {Tuple<String,ExpandoObject>} https://www.dropbox.com/developers/documentation/http/documentation#files-get_preview
	 */
    this.get_preview = function (path, rev) {
        var result = _bNesisApi.Call("Dropbox", this.bNesisToken, "get_preview", path, rev);
        return result;
    }

	/**
	 *   	
	 * @param from_path 
	 * @param to_path 
	 * @param allow_shared_folder 
	 * @param autorename 
	 * @return {string} 
	 */
    this.copy = function (from_path, to_path, allow_shared_folder, autorename) {
        var result = _bNesisApi.Call("Dropbox", this.bNesisToken, "copy", from_path, to_path, allow_shared_folder, autorename);
        return result;
    }

	/**
	 *   	
	 * @param from_path 
	 * @param to_path 
	 * @param allow_shared_folder 
	 * @param autorename 
	 * @param allow_ownership_transfer 
	 * @return {string} 
	 */
    this.move = function (from_path, to_path, allow_shared_folder, autorename, allow_ownership_transfer) {
        var result = _bNesisApi.Call("Dropbox", this.bNesisToken, "move", from_path, to_path, allow_shared_folder, autorename, allow_ownership_transfer);
        return result;
    }

	/**
	 *  Get information about the current user's account. 	
	 * @return {Response} https://www.dropbox.com/developers/documentation/http/documentation#users-get_current_account
	 */
    this.get_current_accountRaw = function () {
        var result = _bNesisApi.Call("Dropbox", this.bNesisToken, "get_current_accountRaw");
        return result;
    }

	/**
	 *  Get a temporary link to stream content of a file. This link will expire in four hours and afterwards you will get 410 Gone. Content-Type of the link is determined automatically by the file's mime type. 	
	 * @param path The path.
	 * @return {ExpandoObject} 
	 */
    this.get_temporary_link = function (path) {
        var result = _bNesisApi.Call("Dropbox", this.bNesisToken, "get_temporary_link", path);
        return result;
    }

	/**
	 *  Get the space usage information for the current user's account. 	
	 * @return {ExpandoObject} SpaceUsage. Information about a user's space usage and quota. used UInt64 The user's total space usage (bytes). allocation SpaceAllocation The user's space allocation.
	 */
    this.get_space_usage = function () {
        var result = _bNesisApi.Call("Dropbox", this.bNesisToken, "get_space_usage");
        return result;
    }

	/**
	 *  Get information about a user's account. 	
	 * @param account_id account_id String(min_length=40, max_length=40) A user's account identifier.
	 * @return {ExpandoObject} BasicAccount Basic information about any account. account_id String(min_length= 40, max_length= 40) The user's unique Dropbox ID. name Name Details of a user's name. email String The user's e-mail address. Do not rely on this without checking the email_verified field. Even then, it's possible that the user has since lost access to their e-mail. email_verified Boolean Whether the user has verified their e-mail address. disabled Boolean Whether the user has been disabled. is_teammate Boolean Whether this user is a teammate of the current user. If this account is the current user's account, then this will be true. profile_photo_url String? URL for the photo representing the user, if one is set.This field is optional. team_member_id String? The user's unique team member id. This field will only be present if the user is part of a team and is_teammate is true. This field is optional.
	 */
    this.get_account = function (account_id) {
        var result = _bNesisApi.Call("Dropbox", this.bNesisToken, "get_account", account_id);
        return result;
    }

	/**
	 *  Get a thumbnail for an image. This method currently supports files with the following file extensions: jpg, jpeg, png, tiff, tif, gif and bmp.Photos that are larger than 20MB in size won't be converted to a thumbnail. 	
	 * @param path String(pattern="(/(.|[\r\n])*|id:.*)|(rev:[0-9a-f]{9,})|(ns:[0-9]+(/.*)?)") The path to the image file you want to thumbnail.
	 * @param format ThumbnailFormat The format for the thumbnail image, jpeg (default) or png. For images that are photos, jpeg should be preferred, while png is better for screenshots and digital arts. The default for this union is jpeg.
	 * @param size ThumbnailSize The size for the thumbnail image. The default for this union is w64h64.
	 * @return {Tuple<String,ExpandoObject>} 
	 */
    this.get_thumbnail = function (path, format, size) {
        var result = _bNesisApi.Call("Dropbox", this.bNesisToken, "get_thumbnail", path, format, size);
        return result;
    }

	/**
	 *  Get a copy reference to a file or folder. This reference string can be used to save that file or folder to another user's Dropbox by passing it to copy_reference/save. 	
	 * @param path path String(pattern="(/(.|[\r\n])*|id:.*)|(rev:[0-9a-f]{9,})|(ns:[0-9]+(/.*)?)") The path to the file or folder you want to get a copy reference to.
	 * @return {ExpandoObject} metadata Metadata Metadata of the file or folder. copy_reference String A copy reference to the file or folder. expires Timestamp(format= "%Y-%m-%dT%H:%M:%SZ") The expiration date of the copy reference.This value is currently set to be far enough in the future so that expiration is effectively not an issue.
	 */
    this.copy_reference_get = function (path) {
        var result = _bNesisApi.Call("Dropbox", this.bNesisToken, "copy_reference_get", path);
        return result;
    }

	/**
	 *   	
	 * @param paths 
	 * @return {ExpandoObject} 
	 */
    this.delete_batch = function (paths) {
        var result = _bNesisApi.Call("Dropbox", this.bNesisToken, "delete_batch", paths);
        return result;
    }

	/**
	 *  Save a specified URL into a file in user's Dropbox. If the given path already exists, the file will be renamed to avoid the conflict (e.g. myfile (1).txt). 	
	 * @param path path String(pattern="/(.|[\r\n])*") The path in Dropbox where the URL will be saved to.
	 * @param url url String The URL to be saved.
	 * @return {ExpandoObject} SaveUrlResult (union) The value will be one of the following datatypes: async_job_id String(min_length= 1) This response indicates that the processing is asynchronous.The string is an id that can be used to obtain the status of the asynchronous job.complete FileMetadata Metadata of the file where the URL is saved to.
	 */
    this.save_url = function (path, url) {
        var result = _bNesisApi.Call("Dropbox", this.bNesisToken, "save_url", path, url);
        return result;
    }

	/**
	 *  Check the status of a save_url job. 	
	 * @param async_job_id TPollArg Arguments for methods that poll the status of an asynchronous job.This datatype comes from an imported namespace originally defined in the async namespace. async_job_id String(min_length=1) Id of the asynchronous job.This is the value of a response returned from the method that launched the job.
	 * @return {ExpandoObject} SaveUrlJobStatus (union) The value will be one of the following datatypes: in_progress Void The asynchronous job is still in progress. complete FileMetadata Metadata of the file where the URL is saved to. failed SaveUrlError
	 */
    this.save_url_check_job_status = function (async_job_id) {
        var result = _bNesisApi.Call("Dropbox", this.bNesisToken, "save_url_check_job_status", async_job_id);
        return result;
    }

	/**
	 *  Searches for files and folders. Note: Recent changes may not immediately be reflected in search results due to a short delay in indexing. 	
	 * @param path path String(pattern="(/(.|[\r\n])*)?|(ns:[0-9]+(/.*)?)") The path in the user's Dropbox to search. Should probably be a folder.
	 * @param query query String The string to search for. The search string is split on spaces into multiple tokens. For file name searching, the last token is used for prefix matching (i.e. "bat c" matches "bat cave" but not "batman car").
	 * @return {ExpandoObject} mode SearchMode The search mode (filename, filename_and_content, or deleted_filename). Note that searching file content is only available for Dropbox Business accounts. The default for this union is filename.
	 */
    this.search = function (path, query) {
        var result = _bNesisApi.Call("Dropbox", this.bNesisToken, "search", path, query);
        return result;
    }
}
