VKontakte = function (bNesisApi) {
    this.bNesisToken = null;
    var _bNesisApi = bNesisApi;

    /**
     * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
	 * or Attach to bNesis session with exists bNesis token
     * @return {string} bNesisToken value | true if bNesisToken is valid
	 */
    this.Auth = function (bNesisDevId,clientId,clientSecret,redirectUrl) {
		if(arguments.length !== 1){
			var bNesisToken = _bNesisApi.Auth("VKontakte", "",bNesisDevId,redirectUrl,clientId,clientSecret,null,"","",false,"");
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
		var result = _bNesisApi.LogoffService("VKontakte", this.bNesisToken);
		if (result) this.bNesisToken = "";
		return result;             
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
	 *  Returns detailed information on current user.
	 * https://vk.com/dev/users.get 	
	 * @return {VKontakteUsersGet} Returns a list of user objects.
	 */
    this.GetUser = function () {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "GetUser");
        return result;
    }

	/**
	 *  Returns detailed information on users.
	 * https://vk.com/dev/users.get 	
	 * @param user_ids User IDs or screen names (screen_name). 
	 * By default, current user ID. list of comma-separated words, the maximum number of elements allowed is 1000
	 * @param fields Profile fields to return. 
	 * Sample values: nickname, screen_name, sex, bdate (birthdate), city, country, timezone, photo, photo_medium, photo_big, has_mobile, contacts, education, online, counters, relation, last_seen, activity, can_write_private_message, can_see_all_posts, can_post, universities 
	 * Click here for the full list of supported parameters.
	 * list of comma-separated words
	 * @param name_case Case for declension of user name and surname: 
	 * nom — nominative(default)
	 * gen — genitive
	 * dat — dative
	 * acc — accusative
	 * ins — instrumental
	 * abl — prepositional
	 * @return {VKontakteUsersGet} Returns a list of user objects.
	 */
    this.GetUserParams = function (user_ids, fields, name_case) {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "GetUserParams", user_ids, fields, name_case);
        return result;
    }

	/**
	 *  Gets frends of the user
	 * https://vk.com/dev/friends.get 	
	 * @return {VKontakteResponse2} Returns a list of user IDs or detailed information about a user's friends.
	 */
    this.GetFriends = function () {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "GetFriends");
        return result;
    }

	/**
	 *  Returns detailed information on current user.
	 * https://vk.com/dev/users.get 	
	 * @return {Response} Returns a list of user objects.
	 */
    this.GetUserRaw = function () {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "GetUserRaw");
        return result;
    }

	/**
	 *  Returns detailed information on users.
	 * https://vk.com/dev/users.get 	
	 * @param user_ids User IDs or screen names (screen_name). 
	 * By default, current user ID. list of comma-separated words, the maximum number of elements allowed is 1000
	 * @param fields Profile fields to return. 
	 * Sample values: nickname, screen_name, sex, bdate (birthdate), city, country, timezone, photo, photo_medium, photo_big, has_mobile, contacts, education, online, counters, relation, last_seen, activity, can_write_private_message, can_see_all_posts, can_post, universities 
	 * Click here for the full list of supported parameters.
	 * list of comma-separated words
	 * @param name_case Case for declension of user name and surname: 
	 * nom — nominative(default)
	 * gen — genitive
	 * dat — dative
	 * acc — accusative
	 * ins — instrumental
	 * abl — prepositional
	 * @return {Response} Returns a list of user objects.
	 */
    this.GetUserParamsRaw = function (user_ids, fields, name_case) {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "GetUserParamsRaw", user_ids, fields, name_case);
        return result;
    }

	/**
	 *  Gets frends of the user
	 * https://vk.com/dev/friends.get 	
	 * @return {Response} Returns a list of user IDs or detailed information about a user's friends.
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

	/**
	 *  Returns detailed information on current user.
	 * https://vk.com/dev/users.get 	
	 * @return {VKontakteResponse} Returns a list of user objects.
	 */
    this.GetUserFullData = function () {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "GetUserFullData");
        return result;
    }

	/**
	 *  Returns detailed information on users.
	 * https://vk.com/dev/users.get 	
	 * @param user_ids User IDs or screen names (screen_name). 
	 * By default, current user ID. list of comma-separated words, the maximum number of elements allowed is 1000
	 * @param fields Profile fields to return. 
	 * Sample values: nickname, screen_name, sex, bdate (birthdate), city, country, timezone, photo, photo_medium, photo_big, has_mobile, contacts, education, online, counters, relation, last_seen, activity, can_write_private_message, can_see_all_posts, can_post, universities 
	 * Click here for the full list of supported parameters.
	 * list of comma-separated words
	 * @param name_case Case for declension of user name and surname: 
	 * nom — nominative(default)
	 * gen — genitive
	 * dat — dative
	 * acc — accusative
	 * ins — instrumental
	 * abl — prepositional
	 * @return {VKontakteResponse} Returns a list of user objects.
	 */
    this.GetUsers = function (user_ids, fields, name_case) {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "GetUsers", user_ids, fields, name_case);
        return result;
    }

	/**
	 *  Returns a list of IDs of followers of the user in question, sorted by date added, most recent first.
	 * This method can be called by a service token.Only public data is returned.
	 * This method can be called with a user token.
	 * https://vk.com/dev/users.getFollowers 	
	 * @param user_id User ID. positive number, current user id is used by default
	 * @param offset Offset needed to return a specific subset of followers. 
	 * positive number
	 * @param count Number of followers to return. 
	 * positive number, default 100, maximum value 1000
	 * @param fields Profile fields to return. Sample values: nickname, screen_name, sex, bdate (birthdate), city, country, timezone, photo, photo_medium, photo_big, has_mobile, rate, contacts, education, online. 
	 * Click here for the full list of supported parameters.
	 * list of comma-separated words
	 * @param name_case Case for declension of user name and surname: 
	 * nom — nominative(default)
	 * gen — genitive
	 * dat — dative
	 * acc — accusative
	 * ins — instrumental
	 * abl — prepositional
	 * string
	 * @return {VKontakteResponse2} Returns a list of user objects.
	 */
    this.GetFollowersUsers = function (user_id, offset, count, fields, name_case) {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "GetFollowersUsers", user_id, offset, count, fields, name_case);
        return result;
    }

	/**
	 *  Returns detailed information on current user.
	 * https://vk.com/dev/users.get 	
	 * @return {Response} Returns a list of user objects.
	 */
    this.GetUserFullDataRaw = function () {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "GetUserFullDataRaw");
        return result;
    }

	/**
	 *  Returns detailed information on users.
	 * https://vk.com/dev/users.get 	
	 * @param user_ids User IDs or screen names (screen_name). 
	 * By default, current user ID. list of comma-separated words, the maximum number of elements allowed is 1000
	 * @param fields Profile fields to return. 
	 * Sample values: nickname, screen_name, sex, bdate (birthdate), city, country, timezone, photo, photo_medium, photo_big, has_mobile, contacts, education, online, counters, relation, last_seen, activity, can_write_private_message, can_see_all_posts, can_post, universities 
	 * Click here for the full list of supported parameters.
	 * list of comma-separated words
	 * @param name_case Case for declension of user name and surname: 
	 * nom — nominative(default)
	 * gen — genitive
	 * dat — dative
	 * acc — accusative
	 * ins — instrumental
	 * abl — prepositional
	 * @return {Response} Returns a list of user objects.
	 */
    this.GetUsersRaw = function (user_ids, fields, name_case) {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "GetUsersRaw", user_ids, fields, name_case);
        return result;
    }

	/**
	 *  Returns a list of IDs of followers of the user in question, sorted by date added, most recent first.
	 * This method can be called by a service token.Only public data is returned.
	 * This method can be called with a user token.
	 * https://vk.com/dev/users.getFollowers 	
	 * @param user_id User ID. positive number, current user id is used by default
	 * @param offset Offset needed to return a specific subset of followers. 
	 * positive number
	 * @param count Number of followers to return. 
	 * positive number, default 100, maximum value 1000
	 * @param fields Profile fields to return. Sample values: nickname, screen_name, sex, bdate (birthdate), city, country, timezone, photo, photo_medium, photo_big, has_mobile, rate, contacts, education, online. 
	 * Click here for the full list of supported parameters.
	 * list of comma-separated words
	 * @param name_case Case for declension of user name and surname: 
	 * nom — nominative(default)
	 * gen — genitive
	 * dat — dative
	 * acc — accusative
	 * ins — instrumental
	 * abl — prepositional
	 * string
	 * @return {Response} Returns a list of user objects.
	 */
    this.GetFollowersUsersRaw = function (user_id, offset, count, fields, name_case) {
        var result = _bNesisApi.Call("VKontakte", this.bNesisToken, "GetFollowersUsersRaw", user_id, offset, count, fields, name_case);
        return result;
    }
}
/**
 * information about user's career. 
 * @typedef {Object} VKontakteCareer
 */
 VKontakteCareer = function () { 
	/**
	 * community ID(if available, otherwise company)
	 * @type {string}
	 */
	this.group_id = "";

	/**
	 * company name(if available, otherwise group_id)
	 * @type {string}
	 */
	this.company = "";

	/**
	 * country ID
	 * @type {string}
	 */
	this.country_id = "";

	/**
	 * city ID(if available, otherwise city_name)
	 * @type {string}
	 */
	this.city_id = "";

	/**
	 * city name(if available, otherwise city_id)
	 * @type {string}
	 */
	this.city_name = "";

	/**
	 * career beginning year
	 * @type {string}
	 */
	this.from = "";

	/**
	 * career ending year
	 * @type {string}
	 */
	this.until = "";

	/**
	 * position
	 * @type {string}
	 */
	this.position = "";

}

/**
 * City specified on user's page in "Contacts" section. 
 * @typedef {Object} VKontakteCity
 */
 VKontakteCity = function () { 
	/**
	 * id(integer) — city ID;
	 * @type {Int32}
	 */
	this.id = 0;

	/**
	 * title(string) — city name.
	 * @type {string}
	 */
	this.title = "";

}

/**
 * Information about user's phone numbers. 
 * @typedef {Object} VKontakteContacts
 */
 VKontakteContacts = function () { 
	/**
	 * user's mobile phone number (only for standalone applications)
	 * @type {string}
	 */
	this.mobile_phone = "";

	/**
	 * user's additional phone number
	 * @type {string}
	 */
	this.home_phone = "";

}

/**
 * Number of various objects the user has.  Can be used in users.get method only when requesting information about a user. 
 *     Returns only in users.get method when only one user information is requested and access_token is passed. 
 * @typedef {Object} VKontakteCounters
 */
 VKontakteCounters = function () { 
	/**
	 * number of photo albums
	 * @type {string}
	 */
	this.albums = "";

	/**
	 * number of videos
	 * @type {string}
	 */
	this.videos = "";

	/**
	 * number of audios
	 * @type {string}
	 */
	this.audios = "";

	/**
	 * number of photos
	 * @type {string}
	 */
	this.photos = "";

	/**
	 * number of photo albums
	 * @type {string}
	 */
	this.notes = "";

	/**
	 * number of friends
	 * @type {string}
	 */
	this.friends = "";

	/**
	 * number of communities
	 * @type {string}
	 */
	this.groups = "";

	/**
	 * number of online friends
	 * @type {string}
	 */
	this.online_friends = "";

	/**
	 * number of mutual friends
	 * @type {string}
	 */
	this.mutual_friends = "";

	/**
	 * number of videos the user is tagged on
	 * @type {string}
	 */
	this.user_videos = "";

	/**
	 * number of followers
	 * @type {string}
	 */
	this.followers = "";

	/**
	 * number of subscriptions(users only)
	 * @type {string}
	 */
	this.pages = "";

}

/**
 * Country specified on user's page in "Contacts" section. 
 * @typedef {Object} VKontakteCountry
 */
 VKontakteCountry = function () { 
	/**
	 * id(integer) — country ID;
	 * @type {Int32}
	 */
	this.id = 0;

	/**
	 * title(string) — country name.
	 * @type {string}
	 */
	this.title = "";

}

/**
 * Object describes photo.
 *     https://vk.com/dev/objects/photo 
 * @typedef {Object} VKontaktePhoto
 */
 VKontaktePhoto = function () { 
	/**
	 * Photo ID.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * Photo album ID.
	 * @type {string}
	 */
	this.album_id = "";

	/**
	 * Photo owner ID.
	 * @type {string}
	 */
	this.owner_id = "";

	/**
	 * Photo owner ID.
	 * @type {string}
	 */
	this.user_id = "";

	/**
	 * Description text.
	 * @type {string}
	 */
	this.text = "";

	/**
	 * Date when the photo has been added in Unixtime.
	 * @type {string}
	 */
	this.date = "";

	/**
	 * URL of the copy with maximum size of 75x75px.
	 * @type {string}
	 */
	this.photo_75 = "";

	/**
	 * URL of the copy with maximum size of 130x130px.
	 * @type {string}
	 */
	this.photo_130 = "";

	/**
	 * URL of the copy with maximum size of 604x604px
	 * @type {string}
	 */
	this.photo_604 = "";

	/**
	 * URL of the copy with maximum size of 807x807px.
	 * @type {string}
	 */
	this.photo_807 = "";

	/**
	 * URL of the copy with maximum size of 1280x1024px.
	 * @type {string}
	 */
	this.photo_1280 = "";

	/**
	 * URL of the copy with maximum size of 2560x2048px.
	 * @type {string}
	 */
	this.photo_2560 = "";

	/**
	 * Width of the original photo in px.
	 * @type {string}
	 */
	this.width = "";

	/**
	 * Height of the original photo in px.
	 * @type {string}
	 */
	this.height = "";

	/**
	 * The post identifier.
	 * @type {string}
	 */
	this.post_id = "";

}

/**
 * Data about points used for cropping of profile and preview user photos. 
 * @typedef {Object} VKontakteCrop
 */
 VKontakteCrop = function () { 
	/**
	 * X coordinate for the left upper corner
	 * @type {string}
	 */
	this.x = "";

	/**
	 * Y coordinate for the left upper corner
	 * @type {string}
	 */
	this.y = "";

	/**
	 * X coordinate for the right bottom corner
	 * @type {string}
	 */
	this.x2 = "";

	/**
	 * Y coordinate for the right bottom corner
	 * @type {string}
	 */
	this.y2 = "";

}

/**
 * preview square photo cropped from crop photo 
 * @typedef {Object} VKontakteRect
 */
 VKontakteRect = function () { 
	/**
	 * X coordinate for the left upper corner
	 * @type {string}
	 */
	this.x = "";

	/**
	 * Y coordinate for the left upper corner
	 * @type {string}
	 */
	this.y = "";

	/**
	 * X coordinate for the right bottom corner
	 * @type {string}
	 */
	this.x2 = "";

	/**
	 * Y coordinate for the right bottom corner
	 * @type {string}
	 */
	this.y2 = "";

}

/**
 * Data about points used for cropping of profile and preview user photos. 
 * @typedef {Object} VKontakteCropPhoto
 */
 VKontakteCropPhoto = function () { 
	/**
	 * Photo object with user photo used for cropping main profile photo.
	 * @type {VKontaktePhoto}
	 */
	this.photo = new VKontaktePhoto();

	/**
	 * cropped user photo. Contains following fields:
	 *  x(number) — X coordinate for the left upper corner, %;
	 *  y(number) — Y coordinate for the left upper corner, %;
	 *  x2(number) — X coordinate for the right bottom corner, %;
	 *  y2(number) —Y coordinate for the right bottom corner, %.
	 * @type {VKontakteCrop}
	 */
	this.crop = new VKontakteCrop();

	/**
	 * preview square photo cropped from crop photo. Contains the same fields set as crop object.
	 * @type {VKontakteRect}
	 */
	this.rect = new VKontakteRect();

}

/**
 * Information about user's higher education institution. 
 * @typedef {Object} VKontakteEducation
 */
 VKontakteEducation = function () { 
	/**
	 * university ID
	 * @type {string}
	 */
	this.university = "";

	/**
	 * university name
	 * @type {string}
	 */
	this.university_name = "";

	/**
	 * faculty ID
	 * @type {string}
	 */
	this.faculty = "";

	/**
	 * faculty name
	 * @type {string}
	 */
	this.faculty_name = "";

	/**
	 * graduation year
	 * @type {string}
	 */
	this.graduation = "";

}

/**
 * last visit date. 
 * @typedef {Object} VKontakteLastSeen
 */
 VKontakteLastSeen = function () { 
	/**
	 * last visit date (in Unixtime)
	 * @type {string}
	 */
	this.time = "";

	/**
	 * — type of the platform that used for the last authorization. Possible values:
	 *  1 — m.vk.com;
	 *  2 — iPhone app;
	 *  3 — iPad app;
	 *  4 — Android app;
	 *  5 —Windows Phone app;
	 *  6 — Windows 8 app;
	 *  7 — web(vk.com);
	 *  8 — VK Mobile.
	 * @type {string}
	 */
	this.platform = "";

}

/**
 * Information about user's military service. 
 * @typedef {Object} VKontakteMilitary
 */
 VKontakteMilitary = function () { 
	/**
	 * unit number
	 * @type {string}
	 */
	this.unit_id = "";

	/**
	 * country ID
	 * @type {string}
	 */
	this.country_id = "";

	/**
	 * service starting year
	 * @type {string}
	 */
	this.from = "";

	/**
	 * service ending year
	 * @type {string}
	 */
	this.until = "";

}

/**
 * User's occupation. 
 * @typedef {Object} VKontakteOccupation
 */
 VKontakteOccupation = function () { 
	/**
	 * type. Possible values: work, school, university
	 * @type {string}
	 */
	this.type = "";

	/**
	 * ID of school, university, company group (the one a user works in)
	 * @type {string}
	 */
	this.id = "";

	/**
	 * name of school, university or work place
	 * @type {string}
	 */
	this.name = "";

}

/**
 * Information from the "Personal views" section. 
 * @typedef {Object} VKontaktePersonal
 */
 VKontaktePersonal = function () { 
	/**
	 * political views. Possible values:
	 * 1 – Communist;
	 * 2 – Socialist;
	 * 3 – Moderate;
	 * 4 – Liberal;
	 * 5 – Conservative;
	 * 6 – Monarchist;
	 * 7 – Ultraconservative;
	 * 8 – Apathetic;
	 * 9 – Libertarian.
	 * @type {string}
	 */
	this.political = "";

	/**
	 * languages
	 * @type {string[]}
	 */
	this.langs = new Array();

	/**
	 * world view
	 * @type {string}
	 */
	this.religion = "";

	/**
	 * inspired by
	 * @type {string}
	 */
	this.inspired_by = "";

	/**
	 * improtant in others. Possible values:
	 *  1 – intellect and creativity;
	 *  2 – kindness and honesty;
	 *  3 – health and beauty;
	 *  4 – wealth and power;
	 *  5 – courage and persistance;
	 *  6 – humor and love for life.
	 * @type {string}
	 */
	this.people_main = "";

	/**
	 * personal priority. Possible values:
	 *  1 – family and children;
	 *  2 – career and money;
	 *  3 – entertainment and leisure;
	 *  4 – science and research;
	 *  5 – improving the world;
	 *  6 – personal development;
	 *  7 – beauty and art ;
	 *  8 – fame and influence;
	 * @type {string}
	 */
	this.life_main = "";

	/**
	 * views on smoking. Possible values:
	 *  1 – very negative;
	 *  2 – negative;
	 *  3 – neutral;
	 *  4 – compromisable;
	 *  5 – positive.
	 * @type {string}
	 */
	this.smoking = "";

	/**
	 * views on alcohol. Possible values:
	 *  1 – very negative;
	 *  2 – negative;
	 *  3 – neutral;
	 *  4 – compromisable;
	 *  5 – positive.
	 * @type {string}
	 */
	this.alcohol = "";

}

/**
 * Current user's relatives list.
 *     Returns a list of objects with id and type fields (name instead of id if a relative is not a VK user). 
 * @typedef {Object} VKontakteRelatives
 */
 VKontakteRelatives = function () { 
	/**
	 * ID
	 * @type {string}
	 */
	this.id = "";

	/**
	 * name instead of id if a relative is not a VK user
	 * @type {string}
	 */
	this.name = "";

	/**
	 * type – relationship type. Possible values:
	 * sibling
	 * parent
	 * child
	 * grandparent
	 * grandchild
	 * @type {string}
	 */
	this.type = "";

}

/**
 * List of schools where user studied. 
 * @typedef {Object} VKontakteSchools
 */
 VKontakteSchools = function () { 
	/**
	 * school ID
	 * @type {string}
	 */
	this.id = "";

	/**
	 * ID of the country the school is located in
	 * @type {string}
	 */
	this.country = "";

	/**
	 * ID of the city the school is located in
	 * @type {string}
	 */
	this.city = "";

	/**
	 * school name
	 * @type {string}
	 */
	this.name = "";

	/**
	 * year the user started to study
	 * @type {string}
	 */
	this.year_from = "";

	/**
	 * year the user finished to study
	 * @type {string}
	 */
	this.year_to = "";

	/**
	 * graduation year
	 * @type {string}
	 */
	this.year_graduated = "";

	/**
	 * school class letter
	 * @type {string}
	 */
	this.class_ = "";

	/**
	 * speciality
	 * @type {string}
	 */
	this.speciality = "";

	/**
	 * type ID
	 * @type {string}
	 */
	this.type = "";

	/**
	 * type name. Possible values for pairs type-typeStr: 
	 * 0 — "school";
	 * 1 — "gymnasium";
	 * 2 —"lyceum";
	 * 3 — "boarding school";
	 * 4 — "evening school";
	 * 5 — "music school";
	 * 6 — "sport school";
	 * 7 — "artistic school";
	 * 8 — "college";
	 * 9 — "professional lyceum";
	 * 10 — "technical college";
	 * 11 — "vocational";
	 * 12 — "specialized school";
	 * 13 — "art school".
	 * @type {string}
	 */
	this.type_str = "";

}

/**
 * List of higher education institutions where user studied. 
 * @typedef {Object} VKontakteUniversities
 */
 VKontakteUniversities = function () { 
	/**
	 * university ID
	 * @type {string}
	 */
	this.id = "";

	/**
	 * ID of the country the university is located in
	 * @type {string}
	 */
	this.country = "";

	/**
	 * ID of the city the university is located in
	 * @type {string}
	 */
	this.city = "";

	/**
	 * university name
	 * @type {string}
	 */
	this.name = "";

	/**
	 * faculty ID
	 * @type {string}
	 */
	this.faculty = "";

	/**
	 * faculty name
	 * @type {string}
	 */
	this.faculty_name = "";

	/**
	 * university chair ID
	 * @type {string}
	 */
	this.chair = "";

	/**
	 * chair name
	 * @type {string}
	 */
	this.chair_name = "";

	/**
	 * graduation year
	 * @type {string}
	 */
	this.graduation = "";

	/**
	 * education form
	 * @type {string}
	 */
	this.education_form = "";

	/**
	 * status
	 * @type {string}
	 */
	this.education_status = "";

}

/**
 * object describes a user profile
 *     https://vk.com/dev/objects/user
 *     Object contains information about user. Fields set may vary depending on called method and passed parameters. 
 * @typedef {Object} VKontakteUser
 */
 VKontakteUser = function () { 
	/**
	 * "About me"
	 * @type {string}
	 */
	this.about = "";

	/**
	 * Activities.
	 * @type {string}
	 */
	this.activities = "";

	/**
	 * user's date of birth.  
	 * Returned as DD.MM.YYYY or DD.MM (if birth year is hidden). If the whole date is hidden, no field is returned.
	 * @type {string}
	 */
	this.bdate = "";

	/**
	 * Returns 1 if a current user is in the requested user's blacklist.
	 * @type {string}
	 */
	this.blacklisted = "";

	/**
	 * Returns 1 if a user is in the current user's blacklist.
	 * @type {string}
	 */
	this.blacklisted_by_me = "";

	/**
	 * Favorite books.
	 * @type {string}
	 */
	this.books = "";

	/**
	 * Information whether current user can post on the wall: 1 – allowed, 0 — not allowed.
	 * @type {string}
	 */
	this.can_post = "";

	/**
	 * Information whether current user can see other users' posts on the wall: 1 – allowed, 0 – not allowed.
	 * @type {string}
	 */
	this.can_see_all_posts = "";

	/**
	 * Information whether current user can see users' audio: 1 – allowed, 0 – not allowed.
	 * @type {string}
	 */
	this.can_see_audio = "";

	/**
	 * Information whether current user can send friend request to a user: 1 – allowed, 0 – not allowed.
	 * @type {string}
	 */
	this.can_send_friend_request = "";

	/**
	 * Information whether current user can write private messages to a user: 1 – allowed, 0 – not allowed.
	 * @type {string}
	 */
	this.can_write_private_message = "";

	/**
	 * information about user's career. Object with following fileds:
	 *  group_id(integer) — community ID(if available, otherwise company);
	 *  company(string) — company name(if available, otherwise group_id);
	 *  country_id(integer) — country ID;
	 *  city_id(integer) — city ID(if available, otherwise city_name);
	 *  city_name(string) — city name(if available, otherwise city_id);
	 *  from(integer) — career beginning year;
	 *  until(integer) — career ending year;
	 *  position(string) — position.
	 * @type {VKontakteCareer[]}
	 */
	this.career = new Array();

	/**
	 * City specified on user's page in "Contacts" section. Contains following fields:
	 *  id(integer) — city ID;
	 *  title(string) — city name.
	 * @type {VKontakteCity}
	 */
	this.city = new VKontakteCity();

	/**
	 * Number of common friends with current user.
	 * @type {string}
	 */
	this.common_count = "";

	/**
	 * Returns specified services such as: skype, facebook, twitter, livejournal, instagram.
	 * @type {string}
	 */
	this.connections = "";

	/**
	 * Information about user's phone numbers. 
	 * If data are available and not hidden in privacy settings, the following fields are returned:
	 *  mobile_phone(string) — user's mobile phone number (only for standalone applications);
	 *  home_phone(string) — user's additional phone number.
	 * @type {VKontakteContacts}
	 */
	this.contacts = new VKontakteContacts();

	/**
	 * Number of various objects the user has.  Can be used in users.get method only when requesting information about a user.
	 * @type {VKontakteCounters}
	 */
	this.counters = new VKontakteCounters();

	/**
	 * Country specified on user's page in "Contacts" section. Contains following fields:
	 * id(integer) — country ID;
	 * title(string) — country name.
	 * @type {VKontakteCountry}
	 */
	this.country = new VKontakteCountry();

	/**
	 * Data about points used for cropping of profile and preview user photos. Contains following fields:
	 *  photo(object) — Photo object with user photo used for cropping main profile photo.
	 *  crop(object) — cropped user photo.Contains following fields:
	 *  x(number) — X coordinate for the left upper corner, %;
	 *  y(number) — Y coordinate for the left upper corner, %;
	 *  x2(number) — X coordinate for the right bottom corner, %;
	 *  y2(number) —Y coordinate for the right bottom corner, %.
	 *  rect(object) — preview square photo cropped from crop photo.Contains the same fields set as crop object..
	 * @type {VKontakteCropPhoto}
	 */
	this.crop_photo = new VKontakteCropPhoto();

	/**
	 * page screen name.  Returns a string with a page screen name (only subdomain is returned, like andrew). 
	 *  If not set, "id'+uid is returned, e.g. id35828305.
	 * @type {string}
	 */
	this.domain = "";

	/**
	 * Information about user's higher education institution.
	 * @type {VKontakteEducation}
	 */
	this.education = new VKontakteEducation();

	/**
	 * first name
	 * @type {string}
	 */
	this.first_name = "";

	/**
	 * Number of followers
	 * @type {string}
	 */
	this.followers_count = "";

	/**
	 * Friend status with a current user. Possible values:
	 *  0 — not a friend;
	 *  1 — outcome request has been sent;
	 *  2 — incoming request has been sent;,
	 *  3 — friend.
	 * @type {string}
	 */
	this.friend_status = "";

	/**
	 * Favorite games.
	 * @type {string}
	 */
	this.games = "";

	/**
	 * Information whether the user's mobile phone number is available.  
	 * Returned values: 1 — available, 0 — not available.  
	 * We recommend you to use it prior to call of secure.sendSMSNotification method. 
	 * flag, can be 1 or 0
	 * @type {string}
	 */
	this.has_mobile = "";

	/**
	 * Information whether the user has profile photo.
	 * @type {string}
	 */
	this.has_photo = "";

	/**
	 * User's home town name.
	 * @type {string}
	 */
	this.home_town = "";

	/**
	 * Interests.
	 * @type {string}
	 */
	this.interests = "";

	/**
	 * Information whether the user is in faves of current user.
	 * @type {string}
	 */
	this.is_favorite = "";

	/**
	 * Information whether the user is a friend of current user.
	 * @type {string}
	 */
	this.is_friend = "";

	/**
	 * Information whether the user is hidden from current user's feed.
	 * @type {string}
	 */
	this.is_hidden_from_feed = "";

	/**
	 * last name
	 * @type {string}
	 */
	this.last_name = "";

	/**
	 * last visit date.  Returns last_seen object with the following fields:
	 *  time(integer) — last visit date(in Unixtime). 
	 *  platform(integer) — type of the platform that used for the last authorization.Possible values:
	 *  1 — m.vk.com;
	 *  2 — iPhone app;
	 *  3 — iPad app;
	 *  4 — Android app;
	 *  5 —Windows Phone app;
	 *  6 — Windows 8 app;
	 *  7 — web(vk.com);
	 *  8 — VK Mobile.
	 * @type {VKontakteLastSeen}
	 */
	this.last_seen = new VKontakteLastSeen();

	/**
	 * Comma-separated friend lists IDs the user is included to. Field is available for friends.get method only.
	 * @type {string[]}
	 */
	this.lists = new Array();

	/**
	 * Maiden name.
	 * @type {string}
	 */
	this.maiden_name = "";

	/**
	 * Information about user's military service.
	 * @type {VKontakteMilitary[]}
	 */
	this.military = new Array();

	/**
	 * Favorite movies.
	 * @type {string}
	 */
	this.movies = "";

	/**
	 * Favorite music.
	 * @type {string}
	 */
	this.music = "";

	/**
	 * User nickname
	 * @type {string}
	 */
	this.nickname = "";

	/**
	 * User's occupation.
	 * @type {VKontakteOccupation}
	 */
	this.occupation = new VKontakteOccupation();

	/**
	 * Information whether the user is online.  
	 *  Returned values: 1 — online, 0 — offline.  
	 *  If user utilizes a mobile application or site mobile version, it returns online_mobile additional field that includes 1.
	 *  With that, in case of application, online_app additional field is returned with application ID.
	 * @type {string}
	 */
	this.online = "";

	/**
	 * Information from the "Personal views" section.
	 * @type {VKontaktePersonal}
	 */
	this.personal = new VKontaktePersonal();

	/**
	 * returns URL of square photo of the user with 50 pixels in width.  
	 *  In case user does not have a photo, http://vk.com/images/camera_c.gif is returned.
	 * @type {string}
	 */
	this.photo_50 = "";

	/**
	 * returns URL of square photo of the user with 100 pixels in width.  
	 * In case user does not have a photo, http://vk.com/images/camera_b.gif is returned.
	 * @type {string}
	 */
	this.photo_100 = "";

	/**
	 * returns URL of user's photo with 200 pixels in width.  
	 * In case user does not have a photo, http://vk.com/images/camera_a.gif is returned.
	 * @type {string}
	 */
	this.photo_200_orig = "";

	/**
	 * returns URL of square photo of the user with 200 pixels in width.  
	 * If the photo was uploaded long time ago, there can be no image of such size and in this case the reply will not include this field.
	 * @type {string}
	 */
	this.photo_200 = "";

	/**
	 * returns URL of user's photo with 400 pixels in width.
	 * If user does not have a photo of such size, reply will not include this field.
	 * @type {string}
	 */
	this.photo_400_orig = "";

	/**
	 * String ID of the main profile photo in format {user_id}_{photo_id}, e.g., 6492_192164258. 
	 * Note that this field can be absent.
	 * @type {string}
	 */
	this.photo_id = "";

	/**
	 * returns URL of square photo of the user with maximum width. 
	 * Can be returned a photo both 200 and 100 pixels in width.  
	 * In case user does not have a photo, http://vk.com/images/camera_b.gif is returned.
	 * @type {string}
	 */
	this.photo_max = "";

	/**
	 * returns URL of square photo of the user with maximum width.
	 * Can be returned a photo both 200 and 100 pixels in width.
	 * In case user does not have a photo, http://vk.com/images/camera_b.gif is returned.
	 * @type {string}
	 */
	this.photo_max_orig = "";

	/**
	 * Favorite quotes.
	 * @type {string}
	 */
	this.quotes = "";

	/**
	 * Current user's relatives list. 
	 * Returns a list of objects with id and type fields (name instead of id if a relative is not a VK user).
	 * @type {VKontakteRelatives[]}
	 */
	this.relatives = new Array();

	/**
	 * User relationship status. Returned values:
	 *  1 – single;
	 *  2 – in a relationship;
	 *  3 – engaged;
	 *  4 – married;
	 *  5 – it's complicated;
	 *  6 – actively searching;
	 *  7 – in love;
	 *  8 — in a civil union;
	 *  0 — not specified.
	 * @type {string}
	 */
	this.relation = "";

	/**
	 * List of schools where user studied.
	 * @type {VKontakteSchools[]}
	 */
	this.schools = new Array();

	/**
	 * user page's screen name (subdomain).
	 * @type {string}
	 */
	this.screen_name = "";

	/**
	 * user sex.  One of three values is returned:
	 *  1 — female;
	 *  2 — male;
	 *  0 — not specified.
	 * @type {string}
	 */
	this.sex = "";

	/**
	 * Returns a website address from a user profile.
	 * @type {string}
	 */
	this.site = "";

	/**
	 * User status. If the audio broadcast is enabled, contains additional status_audio field with an audio object.
	 * @type {string}
	 */
	this.status = "";

	/**
	 * user time zone. Retuns only while requesting current user info.
	 * @type {string}
	 */
	this.timezone = "";

	/**
	 * Information whether the user a "fire" pictogram.
	 * @type {string}
	 */
	this.trending = "";

	/**
	 * Favorite TV shows.
	 * @type {string}
	 */
	this.tv = "";

	/**
	 * List of higher education institutions where user studied.
	 * @type {VKontakteUniversities[]}
	 */
	this.universities = new Array();

	/**
	 * Returns 1 if the profile is verified, 0 if not.
	 * @type {string}
	 */
	this.verified = "";

	/**
	 * Wall comments allowed (1 — allowed, 0 — not allowed).
	 * @type {string}
	 */
	this.wall_comments = "";

	/**
	 * user ID.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * skype
	 * @type {string}
	 */
	this.skype = "";

	/**
	 * university
	 * @type {string}
	 */
	this.university = "";

	/**
	 * university name
	 * @type {string}
	 */
	this.university_name = "";

	/**
	 * faculty
	 * @type {string}
	 */
	this.faculty = "";

	/**
	 * faculty name
	 * @type {string}
	 */
	this.faculty_name = "";

	/**
	 * graduation
	 * @type {string}
	 */
	this.graduation = "";

}

/**
 * a list of user objects 
 * @typedef {Object} VKontakteUsersGet
 */
 VKontakteUsersGet = function () { 
	/**
	 * object describes a user profile
	 * https://vk.com/dev/objects/user
	 * Object contains information about user. Fields set may vary depending on called method and passed parameters.
	 * @type {VKontakteUser[]}
	 */
	this.response = new Array();

}

/**
 * The response 
 * @typedef {Object} VKontakteResponse3
 */
 VKontakteResponse3 = function () { 
	/**
	 * array of objects describing users
	 * https://vk.com/dev/objects/user
	 * Object contains information about user. Fields set may vary depending on called method and passed parameters.
	 * @type {VKontakteUser[]}
	 */
	this.items = new Array();

	/**
	 * the total results number
	 * @type {string}
	 */
	this.count = "";

}

/**
 * Response. 
 * @typedef {Object} VKontakteResponse2
 */
 VKontakteResponse2 = function () { 
	/**
	 * the response.
	 * @type {VKontakteResponse3}
	 */
	this.response = new VKontakteResponse3();

}

/**
 * Response 
 * @typedef {Object} VKontakteResponse
 */
 VKontakteResponse = function () { 
	/**
	 * object describes a user profile
	 * https://vk.com/dev/objects/user
	 * Object contains information about users. Fields set may vary depending on called method and passed parameters.
	 * @type {VKontakteUser[]}
	 */
	this.response = new Array();

}

