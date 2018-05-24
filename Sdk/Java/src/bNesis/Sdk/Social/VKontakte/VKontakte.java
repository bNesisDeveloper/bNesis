package bNesis.Sdk.Social.VKontakte;

import java.io.*;
import java.util.List;
import java.util.Date;
import java.util.Map.Entry;
import bNesis.Api.*;

import bNesis.Sdk.Common.*;
import bNesis.Sdk.Social.VKontakte.*;
import java.net.URI.*;

	public class VKontakte  
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

		public VKontakte(bNesisApi bnesisApi)
		{
			this._bNesisApi = bnesisApi;
		}

		/**
		 * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		 * @return {String} bNesisToken value
		 */
		public String Auth(String bNesisDevId,String clientId,String clientSecret,String redirectUrl) throws Exception
		{
			bNesisToken = _bNesisApi.Auth("VKontakte", "",bNesisDevId,redirectUrl,clientId,clientSecret,null,"","",false,"");
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
			Boolean result = _bNesisApi.LogoffService("VKontakte", bNesisToken);
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
			return _bNesisApi.<ErrorInfo>Call(ErrorInfo.class, "VKontakte", bNesisToken, "GetLastError");
		}

		/**
		 *  Getting arrays of error info 	
		 * @return {ErrorInfo[]}  
		 * @throws Exception
		 */
		public ErrorInfo[] GetErrorLog() throws Exception
		{
			return _bNesisApi.<ErrorInfo[]>Call(ErrorInfo[].class, "VKontakte", bNesisToken, "GetErrorLog");
		}

		/**
		 *  Checks the token in the service. 	
		 * @return {Boolean} if token valid return true, if token not valid return false 
		 * @throws Exception
		 */
		public Boolean ValidateToken() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "VKontakte", bNesisToken, "ValidateToken");
		}

		/**
		 *  Disables the access token used to authenticate the call. 	
		 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false 
		 * @throws Exception
		 */
		public Boolean Logoff() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "VKontakte", bNesisToken, "Logoff");
		}

		/**
		 *   	
		 * @param id 
	 * @return {ContactItem}  
		 * @throws Exception
		 */
		public ContactItem GetFieldsUserUnified(String id) throws Exception
		{
			return _bNesisApi.<ContactItem>Call(ContactItem.class, "VKontakte", bNesisToken, "GetFieldsUserUnified", id);
		}

		/**
		 *   	
		 * @param id 
	 * @param field 
	 * @return {ContactItem}  
		 * @throws Exception
		 */
		public ContactItem GetFieldUserUnified(String id, String field) throws Exception
		{
			return _bNesisApi.<ContactItem>Call(ContactItem.class, "VKontakte", bNesisToken, "GetFieldUserUnified", id, field);
		}

		/**
		 *   	
		 * @param id 
	 * @return {ContactItem}  
		 * @throws Exception
		 */
		public ContactItem GetUserAboutUnified(String id) throws Exception
		{
			return _bNesisApi.<ContactItem>Call(ContactItem.class, "VKontakte", bNesisToken, "GetUserAboutUnified", id);
		}

		/**
		 *  Returns detailed information on current user.
	 * https://vk.com/dev/users.get 	
		 * @return {VKontakteUsersGet} Returns a list of user objects. 
		 * @throws Exception
		 */
		public VKontakteUsersGet GetUser() throws Exception
		{
			return _bNesisApi.<VKontakteUsersGet>Call(VKontakteUsersGet.class, "VKontakte", bNesisToken, "GetUser");
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
		 * @throws Exception
		 */
		public VKontakteUsersGet GetUserParams(String user_ids, String fields, String name_case) throws Exception
		{
			return _bNesisApi.<VKontakteUsersGet>Call(VKontakteUsersGet.class, "VKontakte", bNesisToken, "GetUserParams", user_ids, fields, name_case);
		}

		/**
		 *  Gets frends of the user
	 * https://vk.com/dev/friends.get 	
		 * @return {VKontakteResponse2} Returns a list of user IDs or detailed information about a user's friends. 
		 * @throws Exception
		 */
		public VKontakteResponse2 GetFriends() throws Exception
		{
			return _bNesisApi.<VKontakteResponse2>Call(VKontakteResponse2.class, "VKontakte", bNesisToken, "GetFriends");
		}

		/**
		 *  Returns detailed information on current user.
	 * https://vk.com/dev/users.get 	
		 * @return {Response} Returns a list of user objects. 
		 * @throws Exception
		 */
		public Response GetUserRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "VKontakte", bNesisToken, "GetUserRaw");
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
		 * @throws Exception
		 */
		public Response GetUserParamsRaw(String user_ids, String fields, String name_case) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "VKontakte", bNesisToken, "GetUserParamsRaw", user_ids, fields, name_case);
		}

		/**
		 *  Gets frends of the user
	 * https://vk.com/dev/friends.get 	
		 * @return {Response} Returns a list of user IDs or detailed information about a user's friends. 
		 * @throws Exception
		 */
		public Response GetFriendsRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "VKontakte", bNesisToken, "GetFriendsRaw");
		}

		/**
		 *  Gets ID frends of the user 	
		 * @param userId user ID
	 * @return {Response} Id, nickname, photo, status frends of the user 
		 * @throws Exception
		 */
		public Response GetFriendsIdRaw(Integer userId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "VKontakte", bNesisToken, "GetFriendsIdRaw", userId);
		}

		/**
		 *  Get VK messages, TEST MODE METHOD, needed VK documents sign 	
		 * @return {Response}  
		 * @throws Exception
		 */
		public Response GetMessagesRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "VKontakte", bNesisToken, "GetMessagesRaw");
		}

		/**
		 *  Bans the user. 	
		 * @param userId The user identifier.
	 * @return {Response}  
		 * @throws Exception
		 */
		public Response AccountBanUserRaw(Integer userId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "VKontakte", bNesisToken, "AccountBanUserRaw", userId);
		}

		/**
		 *  Gets App Permissions 	
		 * @param userId 
	 * @return {Response} Returns a bit mask of the user's settings in this application 
		 * @throws Exception
		 */
		public Response AccountGetAppPermissionsRaw(Integer userId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "VKontakte", bNesisToken, "AccountGetAppPermissionsRaw", userId);
		}

		/**
		 *  Returns a user's blacklist 	
		 * @param offset Offset needed to return a specific subset of results. positive number
	 * @param count Number of results to return. positive number, default 20, maximum value 200
	 * @return {Response} Returns a user's blacklist 
		 * @throws Exception
		 */
		public Response AccountGetBannedRaw(Integer offset, Integer count) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "VKontakte", bNesisToken, "AccountGetBannedRaw", offset, count);
		}

		/**
		 *  Current account info 	
		 * @return {Response} Returns current account info 
		 * @throws Exception
		 */
		public Response AccountGetInfoRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "VKontakte", bNesisToken, "AccountGetInfoRaw");
		}

		/**
		 *  current account info 	
		 * @return {Response} Returns the current account info 
		 * @throws Exception
		 */
		public Response AccountGetProfileInfoRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "VKontakte", bNesisToken, "AccountGetProfileInfoRaw");
		}

		/**
		 *  Creates an empty photo album 	
		 * @param title Album title
	 * @return {Response} Returns an object containing the following fields: aid — ID of the created album. 
	 * thumb_id — ID of the album cover photo. owner_id — ID of the user or community that owns the album.
	 * title — Album title.description — Album description. created — Date (in Unix time) when the album was created.
	 * updated — Date(in Unix time) the album was last updated. size — Number of photos in the album.
	 * privacy — Privacy settings for viewing the album.comment_privacy — Privacy settings for commenting on the album. 
		 * @throws Exception
		 */
		public Response PhotosCreateAlbumRaw(String title) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "VKontakte", bNesisToken, "PhotosCreateAlbumRaw", title);
		}

		/**
		 *  Collection of images for community app widgets. 	
		 * @return {Response} Returns total results count in count (integer) and items (array) array with objects describing images 
		 * @throws Exception
		 */
		public Response AppWidgetsGetAppImages() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "VKontakte", bNesisToken, "AppWidgetsGetAppImages");
		}

		/**
		 *  Returns a URL for uploading a photo to the community collection for community app widgets 	
		 * @return {Response} Returns an object with the only upload_url field. To upload an image, generate POST-request to upload_url with a file in photo field. Then call appWidgets.saveAppImage method 
		 * @throws Exception
		 */
		public Response AppWidgetsGetGroupImageUploadServer() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "VKontakte", bNesisToken, "AppWidgetsGetGroupImageUploadServer");
		}

		/**
		 *  Marks a current user as offline 	
		 * @return {Response} In case of success returns 1 
		 * @throws Exception
		 */
		public Response AccountSetOfflineRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "VKontakte", bNesisToken, "AccountSetOfflineRaw");
		}

		/**
		 *  Deletes a photo 	
		 * @param ownerId ID of the user or community that owns the photo. current user id is used by default
	 * @param photoId Photo ID. positive number, required parameter
	 * @return {Response} Returns 1 
		 * @throws Exception
		 */
		public Response PhotosDeleteRaw(Integer ownerId, Integer photoId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "VKontakte", bNesisToken, "PhotosDeleteRaw", ownerId, photoId);
		}

		/**
		 *  Returns the server address for photo upload. When uploaded successfully, the photo can be saved with the photos.save method 	
		 * @param albumId Album ID
	 * @param groupId ID of community that owns the album (if the photo will be uploaded to a community album)
	 * @return {Response}  
		 * @throws Exception
		 */
		public Response PhotosGetUploadServerRaw(Integer albumId, Integer groupId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "VKontakte", bNesisToken, "PhotosGetUploadServerRaw", albumId, groupId);
		}

		/**
		 *  Gets the service token. 	
		 * @return {Response} Service Token 
		 * @throws Exception
		 */
		public Response GetServiceTokenRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "VKontakte", bNesisToken, "GetServiceTokenRaw");
		}

		/**
		 *  Returns detailed information on current user.
	 * https://vk.com/dev/users.get 	
		 * @return {VKontakteResponse} Returns a list of user objects. 
		 * @throws Exception
		 */
		public VKontakteResponse GetUserFullData() throws Exception
		{
			return _bNesisApi.<VKontakteResponse>Call(VKontakteResponse.class, "VKontakte", bNesisToken, "GetUserFullData");
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
		 * @throws Exception
		 */
		public VKontakteResponse GetUsers(String user_ids, String fields, String name_case) throws Exception
		{
			return _bNesisApi.<VKontakteResponse>Call(VKontakteResponse.class, "VKontakte", bNesisToken, "GetUsers", user_ids, fields, name_case);
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
		 * @throws Exception
		 */
		public VKontakteResponse2 GetFollowersUsers(Integer user_id, Integer offset, Integer count, String fields, String name_case) throws Exception
		{
			return _bNesisApi.<VKontakteResponse2>Call(VKontakteResponse2.class, "VKontakte", bNesisToken, "GetFollowersUsers", user_id, offset, count, fields, name_case);
		}

		/**
		 *  Returns detailed information on current user.
	 * https://vk.com/dev/users.get 	
		 * @return {Response} Returns a list of user objects. 
		 * @throws Exception
		 */
		public Response GetUserFullDataRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "VKontakte", bNesisToken, "GetUserFullDataRaw");
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
		 * @throws Exception
		 */
		public Response GetUsersRaw(String user_ids, String fields, String name_case) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "VKontakte", bNesisToken, "GetUsersRaw", user_ids, fields, name_case);
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
		 * @throws Exception
		 */
		public Response GetFollowersUsersRaw(Integer user_id, Integer offset, Integer count, String fields, String name_case) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "VKontakte", bNesisToken, "GetFollowersUsersRaw", user_id, offset, count, fields, name_case);
		}
}