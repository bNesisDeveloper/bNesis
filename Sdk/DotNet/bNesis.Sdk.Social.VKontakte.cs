using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;
using bNesis.Api.Desktop;
using bNesis.Sdk.Common;

namespace bNesis.Sdk.Social.VKontakte
{
	public class VKontakte  
	{
		public string bNesisToken {get; private set;}
		private DesktopbNesisApi bNesisApi;

		public VKontakte(DesktopbNesisApi bNesisApi)
		{
			this.bNesisApi = bNesisApi;
		}

		public string Auth(string data,string bNesisDevId,string redirectUrl,string clientId,string clientSecret,string[] scopes,string login,string password,bool isSandbox,string serviceUrl)
		{

			bNesisToken = bNesisApi.Auth("VKontakte", data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl);

			return bNesisToken;
		}

		///<summary>
		/// Getting last exception for current provider 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo GetLastError()
		{
			return bNesisApi.Call<ErrorInfo>("VKontakte", bNesisToken, "GetLastError");
		}

		///<summary>
		/// Getting arrays of error info 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo[] GetErrorLog()
		{
			return bNesisApi.Call<ErrorInfo[]>("VKontakte", bNesisToken, "GetErrorLog");
		}

		///<summary>
		/// Checks the token in the service. 
		/// </summary>
		/// <returns>if token valid return true, if token not valid return false</returns>
		public Boolean ValidationTokenUnified()
		{
			return bNesisApi.Call<Boolean>("VKontakte", bNesisToken, "ValidationTokenUnified");
		}

		///<summary>
		/// Gets the user identifier. 
		/// </summary>
		/// <returns>response with user ID</returns>
		public Response GetUserIdRaw()
		{
			return bNesisApi.Call<Response>("VKontakte", bNesisToken, "GetUserIdRaw");
		}

		///<summary>
		/// Gets ID frends of the user 
		/// </summary>
		/// <returns>frends of the user</returns>
		public Response GetFriendsRaw()
		{
			return bNesisApi.Call<Response>("VKontakte", bNesisToken, "GetFriendsRaw");
		}

		///<summary>
		/// Gets ID frends of the user 
		/// </summary>
		/// <param name="userId">user ID</param>
		/// <returns>Id, nickname, photo, status frends of the user</returns>
		public Response GetFriendsIdRaw(Int32 userId)
		{
			return bNesisApi.Call<Response>("VKontakte", bNesisToken, "GetFriendsIdRaw", userId);
		}

		///<summary>
		/// Get VK messages, TEST MODE METHOD, needed VK documents sign 
		/// </summary>
		/// <returns></returns>
		public Response GetMessagesRaw()
		{
			return bNesisApi.Call<Response>("VKontakte", bNesisToken, "GetMessagesRaw");
		}

		///<summary>
		/// Bans the user. 
		/// </summary>
		/// <param name="userId">The user identifier.</param>
		/// <returns></returns>
		public Response AccountBanUserRaw(Int32 userId)
		{
			return bNesisApi.Call<Response>("VKontakte", bNesisToken, "AccountBanUserRaw", userId);
		}

		///<summary>
		/// Gets App Permissions 
		/// </summary>
		/// <param name="userId"></param>
		/// <returns>Returns a bit mask of the user's settings in this application</returns>
		public Response AccountGetAppPermissionsRaw(Int32 userId)
		{
			return bNesisApi.Call<Response>("VKontakte", bNesisToken, "AccountGetAppPermissionsRaw", userId);
		}

		///<summary>
		/// Returns a user's blacklist 
		/// </summary>
		/// <param name="offset">Offset needed to return a specific subset of results. positive number</param>
		/// <param name="count">Number of results to return. positive number, default 20, maximum value 200</param>
		/// <returns>Returns a user's blacklist</returns>
		public Response AccountGetBannedRaw(Int32 offset, Int32 count)
		{
			return bNesisApi.Call<Response>("VKontakte", bNesisToken, "AccountGetBannedRaw", offset, count);
		}

		///<summary>
		/// Current account info 
		/// </summary>
		/// <returns>Returns current account info</returns>
		public Response AccountGetInfoRaw()
		{
			return bNesisApi.Call<Response>("VKontakte", bNesisToken, "AccountGetInfoRaw");
		}

		///<summary>
		/// current account info 
		/// </summary>
		/// <returns>Returns the current account info</returns>
		public Response AccountGetProfileInfoRaw()
		{
			return bNesisApi.Call<Response>("VKontakte", bNesisToken, "AccountGetProfileInfoRaw");
		}

		///<summary>
		/// Creates an empty photo album 
		/// </summary>
		/// <param name="title">Album title</param>
		/// <returns>Returns an object containing the following fields: aid — ID of the created album. 
		/// thumb_id — ID of the album cover photo. owner_id — ID of the user or community that owns the album.
		/// title — Album title.description — Album description. created — Date (in Unix time) when the album was created.
		/// updated — Date(in Unix time) the album was last updated. size — Number of photos in the album.
		/// privacy — Privacy settings for viewing the album.comment_privacy — Privacy settings for commenting on the album.</returns>
		public Response PhotosCreateAlbumRaw(string title)
		{
			return bNesisApi.Call<Response>("VKontakte", bNesisToken, "PhotosCreateAlbumRaw", title);
		}

		///<summary>
		/// Collection of images for community app widgets. 
		/// </summary>
		/// <returns>Returns total results count in count (integer) and items (array) array with objects describing images</returns>
		public Response AppWidgetsGetAppImages()
		{
			return bNesisApi.Call<Response>("VKontakte", bNesisToken, "AppWidgetsGetAppImages");
		}

		///<summary>
		/// Returns a URL for uploading a photo to the community collection for community app widgets 
		/// </summary>
		/// <returns>Returns an object with the only upload_url field. To upload an image, generate POST-request to upload_url with a file in photo field. Then call appWidgets.saveAppImage method</returns>
		public Response AppWidgetsGetGroupImageUploadServer()
		{
			return bNesisApi.Call<Response>("VKontakte", bNesisToken, "AppWidgetsGetGroupImageUploadServer");
		}

		///<summary>
		/// Marks a current user as offline 
		/// </summary>
		/// <returns>In case of success returns 1</returns>
		public Response AccountSetOfflineRaw()
		{
			return bNesisApi.Call<Response>("VKontakte", bNesisToken, "AccountSetOfflineRaw");
		}

		///<summary>
		/// Deletes a photo 
		/// </summary>
		/// <param name="ownerId">ID of the user or community that owns the photo. current user id is used by default</param>
		/// <param name="photoId">Photo ID. positive number, required parameter</param>
		/// <returns>Returns 1</returns>
		public Response PhotosDeleteRaw(Int32 ownerId, Int32 photoId)
		{
			return bNesisApi.Call<Response>("VKontakte", bNesisToken, "PhotosDeleteRaw", ownerId, photoId);
		}

		///<summary>
		/// Returns the server address for photo upload. When uploaded successfully, the photo can be saved with the photos.save method 
		/// </summary>
		/// <param name="albumId">Album ID</param>
		/// <param name="groupId">ID of community that owns the album (if the photo will be uploaded to a community album)</param>
		/// <returns></returns>
		public Response PhotosGetUploadServerRaw(Int32 albumId, Int32 groupId)
		{
			return bNesisApi.Call<Response>("VKontakte", bNesisToken, "PhotosGetUploadServerRaw", albumId, groupId);
		}

		///<summary>
		/// Gets the service token. 
		/// </summary>
		/// <returns>Service Token</returns>
		public Response GetServiceTokenRaw()
		{
			return bNesisApi.Call<Response>("VKontakte", bNesisToken, "GetServiceTokenRaw");
		}
	}
}