VKontakte = function (bNesisApi) {
    this.bNesisToken = null;
    var _bNesisApi = bNesisApi;

    this.Auth = function (data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl) {
        var bNesisToken = _bNesisApi.Auth("VKontakte", data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl);
        return bNesisToken;
    }
	
	/**
	 *  Getting last exception for current provider 	
	 * @return {ErrorInfo} 
	 */
    this.GetLastError = function () {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "GetLastError");
        return result;
    }

	/**
	 *  Getting arrays of error info 	
	 * @return {ErrorInfo[]} 
	 */
    this.GetErrorLog = function () {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "GetErrorLog");
        return result;
    }

	/**
	 *  Checks the token in the service. 	
	 * @return {Boolean} if token valid return true, if token not valid return false
	 */
    this.ValidateToken = function () {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "ValidateToken");
        return result;
    }

	/**
	 *  Disables the access token used to authenticate the call. 	
	 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false
	 */
    this.Logoff = function () {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "Logoff");
        return result;
    }

	/**
	 *   	
	 * @param id 
	 * @return {ContactItem} 
	 */
    this.GetFieldsUserUnified = function (id) {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "GetFieldsUserUnified", id);
        return result;
    }

	/**
	 *   	
	 * @param id 
	 * @param field 
	 * @return {ContactItem} 
	 */
    this.GetFieldUserUnified = function (id, field) {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "GetFieldUserUnified", id, field);
        return result;
    }

	/**
	 *   	
	 * @param id 
	 * @return {ContactItem} 
	 */
    this.GetUserAboutUnified = function (id) {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "GetUserAboutUnified", id);
        return result;
    }

	/**
	 *  Gets the user identifier. 	
	 * @return {Response} response with user ID
	 */
    this.GetUserIdRaw = function () {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "GetUserIdRaw");
        return result;
    }

	/**
	 *  Gets ID frends of the user 	
	 * @return {Response} frends of the user
	 */
    this.GetFriendsRaw = function () {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "GetFriendsRaw");
        return result;
    }

	/**
	 *  Gets ID frends of the user 	
	 * @param userId user ID
	 * @return {Response} Id, nickname, photo, status frends of the user
	 */
    this.GetFriendsIdRaw = function (userId) {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "GetFriendsIdRaw", userId);
        return result;
    }

	/**
	 *  Get VK messages, TEST MODE METHOD, needed VK documents sign 	
	 * @return {Response} 
	 */
    this.GetMessagesRaw = function () {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "GetMessagesRaw");
        return result;
    }

	/**
	 *  Bans the user. 	
	 * @param userId The user identifier.
	 * @return {Response} 
	 */
    this.AccountBanUserRaw = function (userId) {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "AccountBanUserRaw", userId);
        return result;
    }

	/**
	 *  Gets App Permissions 	
	 * @param userId 
	 * @return {Response} Returns a bit mask of the user's settings in this application
	 */
    this.AccountGetAppPermissionsRaw = function (userId) {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "AccountGetAppPermissionsRaw", userId);
        return result;
    }

	/**
	 *  Returns a user's blacklist 	
	 * @param offset Offset needed to return a specific subset of results. positive number
	 * @param count Number of results to return. positive number, default 20, maximum value 200
	 * @return {Response} Returns a user's blacklist
	 */
    this.AccountGetBannedRaw = function (offset, count) {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "AccountGetBannedRaw", offset, count);
        return result;
    }

	/**
	 *  Current account info 	
	 * @return {Response} Returns current account info
	 */
    this.AccountGetInfoRaw = function () {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "AccountGetInfoRaw");
        return result;
    }

	/**
	 *  current account info 	
	 * @return {Response} Returns the current account info
	 */
    this.AccountGetProfileInfoRaw = function () {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "AccountGetProfileInfoRaw");
        return result;
    }

	/**
	 *  Creates an empty photo album 	
	 * @param title Album title
	 * @return {Response} Returns an object containing the following fields: aid — ID of the created album. 
	 * thumb_id — ID of the album cover photo. owner_id — ID of the user or community that owns the album.
	 * title — Album title.description — Album description. created — Date (in Unix time) when the album was created.
	 * updated — Date(in Unix time) the album was last updated. size — Number of photos in the album.
	 * privacy — Privacy settings for viewing the album.comment_privacy — Privacy settings for commenting on the album.
	 */
    this.PhotosCreateAlbumRaw = function (title) {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "PhotosCreateAlbumRaw", title);
        return result;
    }

	/**
	 *  Collection of images for community app widgets. 	
	 * @return {Response} Returns total results count in count (integer) and items (array) array with objects describing images
	 */
    this.AppWidgetsGetAppImages = function () {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "AppWidgetsGetAppImages");
        return result;
    }

	/**
	 *  Returns a URL for uploading a photo to the community collection for community app widgets 	
	 * @return {Response} Returns an object with the only upload_url field. To upload an image, generate POST-request to upload_url with a file in photo field. Then call appWidgets.saveAppImage method
	 */
    this.AppWidgetsGetGroupImageUploadServer = function () {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "AppWidgetsGetGroupImageUploadServer");
        return result;
    }

	/**
	 *  Marks a current user as offline 	
	 * @return {Response} In case of success returns 1
	 */
    this.AccountSetOfflineRaw = function () {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "AccountSetOfflineRaw");
        return result;
    }

	/**
	 *  Deletes a photo 	
	 * @param ownerId ID of the user or community that owns the photo. current user id is used by default
	 * @param photoId Photo ID. positive number, required parameter
	 * @return {Response} Returns 1
	 */
    this.PhotosDeleteRaw = function (ownerId, photoId) {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "PhotosDeleteRaw", ownerId, photoId);
        return result;
    }

	/**
	 *  Returns the server address for photo upload. When uploaded successfully, the photo can be saved with the photos.save method 	
	 * @param albumId Album ID
	 * @param groupId ID of community that owns the album (if the photo will be uploaded to a community album)
	 * @return {Response} 
	 */
    this.PhotosGetUploadServerRaw = function (albumId, groupId) {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "PhotosGetUploadServerRaw", albumId, groupId);
        return result;
    }

	/**
	 *  Gets the service token. 	
	 * @return {Response} Service Token
	 */
    this.GetServiceTokenRaw = function () {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "GetServiceTokenRaw");
        return result;
    }
}
