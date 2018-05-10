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
		/// <summary>
		/// bNesisToken is a unique identifier of the current service work session
		/// bNesisToken is relevant only after successful authorization in the service.
		/// The Auth() method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		/// The LogoffService() method stops the authorization session with the service and clears the value of bNesisToken.
		/// </summary>		
		public string bNesisToken {get; private set;}

		/// <summary>
		/// bNesis Core object
		/// </summary>
		private DesktopbNesisApi bNesisApi;

		public VKontakte(DesktopbNesisApi bNesisApi)
		{
			this.bNesisApi = bNesisApi;
		}

		/// <summary>
		/// The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		/// </summary>
		/// <returns>bNesisToken value</returns>	
		public string Auth(string data,string bNesisDevId,string redirectUrl,string clientId,string clientSecret,string[] scopes,string login,string password,bool isSandbox,string serviceUrl)
		{
			bNesisToken = bNesisApi.Auth("VKontakte", data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl);
			return bNesisToken;
		}

		/// <summary>
		/// Attach to bNesis session with exists bNesis token
		/// </summary>		
		/// <returns>true if bNesisToken is valid</returns>	
		public bool Auth(string bNesisToken)
		{
		    this.bNesisToken = bNesisToken;			
			return ValidateToken();
		}

		/// <summary>
		/// The method stops the authorization session with the service and clears the value of bNesisToken.
		/// </summary>
		/// <returns>true - if service logoff is successful</returns>
		public bool LogoffService()
		{
			bool result = bNesisApi.LogoffService("VKontakte", bNesisToken);
			if (result) bNesisToken = string.Empty;
			return result;             
		}


		///<summary>
		///  
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ContactItem GetFieldsUserUnified(string id)
		{
			return bNesisApi.Call<ContactItem>("VKontakte", bNesisToken, "GetFieldsUserUnified", id);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="id"></param>
		/// <param name="field"></param>
		/// <returns></returns>
		public ContactItem GetFieldUserUnified(string id, string field)
		{
			return bNesisApi.Call<ContactItem>("VKontakte", bNesisToken, "GetFieldUserUnified", id, field);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ContactItem GetUserAboutUnified(string id)
		{
			return bNesisApi.Call<ContactItem>("VKontakte", bNesisToken, "GetUserAboutUnified", id);
		}

		///<summary>
		/// Returns detailed information on current user.
		/// https://vk.com/dev/users.get 
		/// </summary>
		/// <returns>Returns a list of user objects.</returns>
		public VKontakteResultUser GetUser()
		{
			return bNesisApi.Call<VKontakteResultUser>("VKontakte", bNesisToken, "GetUser");
		}

		///<summary>
		/// Returns detailed information on current user.
		/// https://vk.com/dev/users.get 
		/// </summary>
		/// <returns>Returns a list of user objects.</returns>
		public Response GetUserRaw()
		{
			return bNesisApi.Call<Response>("VKontakte", bNesisToken, "GetUserRaw");
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
		public Boolean ValidateToken()
		{
			return bNesisApi.Call<Boolean>("VKontakte", bNesisToken, "ValidateToken");
		}

		///<summary>
		/// Disables the access token used to authenticate the call. 
		/// </summary>
		/// <returns>if token revoked method returns true 
		/// if token doesn't support token revocation or token is revoked method returns false</returns>
		public Boolean Logoff()
		{
			return bNesisApi.Call<Boolean>("VKontakte", bNesisToken, "Logoff");
		}
}
	///<summary>
	/// information about user's career. 
	/// </summary>
	public class VKontakteCareer
	{
		/// <summary>
		/// community ID(if available, otherwise company) 
		/// </summary>
		public string group_id { get; set; }

		/// <summary>
		/// company name(if available, otherwise group_id) 
		/// </summary>
		public string company { get; set; }

		/// <summary>
		/// country ID 
		/// </summary>
		public string country_id { get; set; }

		/// <summary>
		/// city ID(if available, otherwise city_name) 
		/// </summary>
		public string city_id { get; set; }

		/// <summary>
		/// city name(if available, otherwise city_id) 
		/// </summary>
		public string city_name { get; set; }

		/// <summary>
		/// career beginning year 
		/// </summary>
		public string from { get; set; }

		/// <summary>
		/// career ending year 
		/// </summary>
		public string until { get; set; }

		/// <summary>
		/// position 
		/// </summary>
		public string position { get; set; }

	}

	///<summary>
	/// City specified on user's page in "Contacts" section. 
	/// </summary>
	public class VKontakteCity
	{
		/// <summary>
		/// id(integer) — city ID; 
		/// </summary>
		public Int32 id { get; set; }

		/// <summary>
		/// title(string) — city name. 
		/// </summary>
		public string title { get; set; }

	}

	///<summary>
	/// Information about user's phone numbers. 
	/// </summary>
	public class VKontakteContacts
	{
		/// <summary>
		/// user's mobile phone number (only for standalone applications) 
		/// </summary>
		public string mobile_phone { get; set; }

		/// <summary>
		/// user's additional phone number 
		/// </summary>
		public string home_phone { get; set; }

	}

	///<summary>
	/// Number of various objects the user has.  Can be used in users.get method only when requesting information about a user. 
	///     Returns only in users.get method when only one user information is requested and access_token is passed. 
	/// </summary>
	public class VKontakteCounters
	{
		/// <summary>
		/// number of photo albums 
		/// </summary>
		public string albums { get; set; }

		/// <summary>
		/// number of videos 
		/// </summary>
		public string videos { get; set; }

		/// <summary>
		/// number of audios 
		/// </summary>
		public string audios { get; set; }

		/// <summary>
		/// number of photos 
		/// </summary>
		public string photos { get; set; }

		/// <summary>
		/// number of photo albums 
		/// </summary>
		public string notes { get; set; }

		/// <summary>
		/// number of friends 
		/// </summary>
		public string friends { get; set; }

		/// <summary>
		/// number of communities 
		/// </summary>
		public string groups { get; set; }

		/// <summary>
		/// number of online friends 
		/// </summary>
		public string online_friends { get; set; }

		/// <summary>
		/// number of mutual friends 
		/// </summary>
		public string mutual_friends { get; set; }

		/// <summary>
		/// number of videos the user is tagged on 
		/// </summary>
		public string user_videos { get; set; }

		/// <summary>
		/// number of followers 
		/// </summary>
		public string followers { get; set; }

		/// <summary>
		/// number of subscriptions(users only) 
		/// </summary>
		public string pages { get; set; }

	}

	///<summary>
	/// Country specified on user's page in "Contacts" section. 
	/// </summary>
	public class VKontakteCountry
	{
		/// <summary>
		/// id(integer) — country ID; 
		/// </summary>
		public Int32 id { get; set; }

		/// <summary>
		/// title(string) — country name. 
		/// </summary>
		public string title { get; set; }

	}

	///<summary>
	/// Object describes photo.
	///     https://vk.com/dev/objects/photo 
	/// </summary>
	public class VKontaktePhoto
	{
		/// <summary>
		/// Photo ID. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// Photo album ID. 
		/// </summary>
		public string album_id { get; set; }

		/// <summary>
		/// Photo owner ID. 
		/// </summary>
		public string owner_id { get; set; }

		/// <summary>
		/// Photo owner ID. 
		/// </summary>
		public string user_id { get; set; }

		/// <summary>
		/// Description text. 
		/// </summary>
		public string text { get; set; }

		/// <summary>
		/// Date when the photo has been added in Unixtime. 
		/// </summary>
		public string date { get; set; }

		/// <summary>
		/// URL of the copy with maximum size of 75x75px. 
		/// </summary>
		public string photo_75 { get; set; }

		/// <summary>
		/// URL of the copy with maximum size of 130x130px. 
		/// </summary>
		public string photo_130 { get; set; }

		/// <summary>
		/// URL of the copy with maximum size of 604x604px 
		/// </summary>
		public string photo_604 { get; set; }

		/// <summary>
		/// URL of the copy with maximum size of 807x807px. 
		/// </summary>
		public string photo_807 { get; set; }

		/// <summary>
		/// URL of the copy with maximum size of 1280x1024px. 
		/// </summary>
		public string photo_1280 { get; set; }

		/// <summary>
		/// URL of the copy with maximum size of 2560x2048px. 
		/// </summary>
		public string photo_2560 { get; set; }

		/// <summary>
		/// Width of the original photo in px. 
		/// </summary>
		public string width { get; set; }

		/// <summary>
		/// Height of the original photo in px. 
		/// </summary>
		public string height { get; set; }

		/// <summary>
		/// The post identifier. 
		/// </summary>
		public string post_id { get; set; }

	}

	///<summary>
	/// Data about points used for cropping of profile and preview user photos. 
	/// </summary>
	public class VKontakteCrop
	{
		/// <summary>
		/// X coordinate for the left upper corner 
		/// </summary>
		public string x { get; set; }

		/// <summary>
		/// Y coordinate for the left upper corner 
		/// </summary>
		public string y { get; set; }

		/// <summary>
		/// X coordinate for the right bottom corner 
		/// </summary>
		public string x2 { get; set; }

		/// <summary>
		/// Y coordinate for the right bottom corner 
		/// </summary>
		public string y2 { get; set; }

	}

	///<summary>
	/// preview square photo cropped from crop photo 
	/// </summary>
	public class VKontakteRect
	{
		/// <summary>
		/// X coordinate for the left upper corner 
		/// </summary>
		public string x { get; set; }

		/// <summary>
		/// Y coordinate for the left upper corner 
		/// </summary>
		public string y { get; set; }

		/// <summary>
		/// X coordinate for the right bottom corner 
		/// </summary>
		public string x2 { get; set; }

		/// <summary>
		/// Y coordinate for the right bottom corner 
		/// </summary>
		public string y2 { get; set; }

	}

	///<summary>
	/// Data about points used for cropping of profile and preview user photos. 
	/// </summary>
	public class VKontakteCropPhoto
	{
		/// <summary>
		/// Photo object with user photo used for cropping main profile photo. 
		/// </summary>
		public VKontaktePhoto photo { get; set; }

		/// <summary>
		/// cropped user photo. Contains following fields:
		///  x(number) — X coordinate for the left upper corner, %;
		///  y(number) — Y coordinate for the left upper corner, %;
		///  x2(number) — X coordinate for the right bottom corner, %;
		///  y2(number) —Y coordinate for the right bottom corner, %. 
		/// </summary>
		public VKontakteCrop crop { get; set; }

		/// <summary>
		/// preview square photo cropped from crop photo. Contains the same fields set as crop object. 
		/// </summary>
		public VKontakteRect rect { get; set; }

	}

	///<summary>
	/// Information about user's higher education institution. 
	/// </summary>
	public class VKontakteEducation
	{
		/// <summary>
		/// university ID 
		/// </summary>
		public string university { get; set; }

		/// <summary>
		/// university name 
		/// </summary>
		public string university_name { get; set; }

		/// <summary>
		/// faculty ID 
		/// </summary>
		public string faculty { get; set; }

		/// <summary>
		/// faculty name 
		/// </summary>
		public string faculty_name { get; set; }

		/// <summary>
		/// graduation year 
		/// </summary>
		public string graduation { get; set; }

	}

	///<summary>
	/// last visit date. 
	/// </summary>
	public class VKontakteLastSeen
	{
		/// <summary>
		/// last visit date (in Unixtime) 
		/// </summary>
		public string time { get; set; }

		/// <summary>
		/// — type of the platform that used for the last authorization. Possible values:
		///  1 — m.vk.com;
		///  2 — iPhone app;
		///  3 — iPad app;
		///  4 — Android app;
		///  5 —Windows Phone app;
		///  6 — Windows 8 app;
		///  7 — web(vk.com);
		///  8 — VK Mobile. 
		/// </summary>
		public string platform { get; set; }

	}

	///<summary>
	/// Information about user's military service. 
	/// </summary>
	public class VKontakteMilitary
	{
		/// <summary>
		/// unit number 
		/// </summary>
		public string unit_id { get; set; }

		/// <summary>
		/// country ID 
		/// </summary>
		public string country_id { get; set; }

		/// <summary>
		/// service starting year 
		/// </summary>
		public string from { get; set; }

		/// <summary>
		/// service ending year 
		/// </summary>
		public string until { get; set; }

	}

	///<summary>
	/// User's occupation. 
	/// </summary>
	public class VKontakteOccupation
	{
		/// <summary>
		/// type. Possible values: work, school, university 
		/// </summary>
		public string type { get; set; }

		/// <summary>
		/// ID of school, university, company group (the one a user works in) 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// name of school, university or work place 
		/// </summary>
		public string name { get; set; }

	}

	///<summary>
	/// Information from the "Personal views" section. 
	/// </summary>
	public class VKontaktePersonal
	{
		/// <summary>
		/// political views. Possible values:
		/// 1 – Communist;
		/// 2 – Socialist;
		/// 3 – Moderate;
		/// 4 – Liberal;
		/// 5 – Conservative;
		/// 6 – Monarchist;
		/// 7 – Ultraconservative;
		/// 8 – Apathetic;
		/// 9 – Libertarian. 
		/// </summary>
		public string political { get; set; }

		/// <summary>
		/// languages 
		/// </summary>
		public string[] langs { get; set; }

		/// <summary>
		/// world view 
		/// </summary>
		public string religion { get; set; }

		/// <summary>
		/// inspired by 
		/// </summary>
		public string inspired_by { get; set; }

		/// <summary>
		/// improtant in others. Possible values:
		///  1 – intellect and creativity;
		///  2 – kindness and honesty;
		///  3 – health and beauty;
		///  4 – wealth and power;
		///  5 – courage and persistance;
		///  6 – humor and love for life. 
		/// </summary>
		public string people_main { get; set; }

		/// <summary>
		/// personal priority. Possible values:
		///  1 – family and children;
		///  2 – career and money;
		///  3 – entertainment and leisure;
		///  4 – science and research;
		///  5 – improving the world;
		///  6 – personal development;
		///  7 – beauty and art ;
		///  8 – fame and influence; 
		/// </summary>
		public string life_main { get; set; }

		/// <summary>
		/// views on smoking. Possible values:
		///  1 – very negative;
		///  2 – negative;
		///  3 – neutral;
		///  4 – compromisable;
		///  5 – positive. 
		/// </summary>
		public string smoking { get; set; }

		/// <summary>
		/// views on alcohol. Possible values:
		///  1 – very negative;
		///  2 – negative;
		///  3 – neutral;
		///  4 – compromisable;
		///  5 – positive. 
		/// </summary>
		public string alcohol { get; set; }

	}

	///<summary>
	/// Current user's relatives list.
	///     Returns a list of objects with id and type fields (name instead of id if a relative is not a VK user). 
	/// </summary>
	public class VKontakteRelatives
	{
		/// <summary>
		/// ID 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// name instead of id if a relative is not a VK user 
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// type – relationship type. Possible values:
		/// sibling
		/// parent
		/// child
		/// grandparent
		/// grandchild 
		/// </summary>
		public string type { get; set; }

	}

	///<summary>
	/// List of schools where user studied. 
	/// </summary>
	public class VKontakteSchools
	{
		/// <summary>
		/// school ID 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// ID of the country the school is located in 
		/// </summary>
		public string country { get; set; }

		/// <summary>
		/// ID of the city the school is located in 
		/// </summary>
		public string city { get; set; }

		/// <summary>
		/// school name 
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// year the user started to study 
		/// </summary>
		public string year_from { get; set; }

		/// <summary>
		/// year the user finished to study 
		/// </summary>
		public string year_to { get; set; }

		/// <summary>
		/// graduation year 
		/// </summary>
		public string year_graduated { get; set; }

		/// <summary>
		/// school class letter 
		/// </summary>
		public string class_ { get; set; }

		/// <summary>
		/// speciality 
		/// </summary>
		public string speciality { get; set; }

		/// <summary>
		/// type ID 
		/// </summary>
		public string type { get; set; }

		/// <summary>
		/// type name. Possible values for pairs type-typeStr: 
		/// 0 — "school";
		/// 1 — "gymnasium";
		/// 2 —"lyceum";
		/// 3 — "boarding school";
		/// 4 — "evening school";
		/// 5 — "music school";
		/// 6 — "sport school";
		/// 7 — "artistic school";
		/// 8 — "college";
		/// 9 — "professional lyceum";
		/// 10 — "technical college";
		/// 11 — "vocational";
		/// 12 — "specialized school";
		/// 13 — "art school". 
		/// </summary>
		public string type_str { get; set; }

	}

	///<summary>
	/// List of higher education institutions where user studied. 
	/// </summary>
	public class VKontakteUniversities
	{
		/// <summary>
		/// university ID 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// ID of the country the university is located in 
		/// </summary>
		public string country { get; set; }

		/// <summary>
		/// ID of the city the university is located in 
		/// </summary>
		public string city { get; set; }

		/// <summary>
		/// university name 
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// faculty ID 
		/// </summary>
		public string faculty { get; set; }

		/// <summary>
		/// faculty name 
		/// </summary>
		public string faculty_name { get; set; }

		/// <summary>
		/// university chair ID 
		/// </summary>
		public string chair { get; set; }

		/// <summary>
		/// chair name 
		/// </summary>
		public string chair_name { get; set; }

		/// <summary>
		/// graduation year 
		/// </summary>
		public string graduation { get; set; }

		/// <summary>
		/// education form 
		/// </summary>
		public string education_form { get; set; }

		/// <summary>
		/// status 
		/// </summary>
		public string education_status { get; set; }

	}

	///<summary>
	/// object describes a user profile
	///     https://vk.com/dev/objects/user
	///     Object contains information about user. Fields set may vary depending on called method and passed parameters. 
	/// </summary>
	public class VKontakteUser
	{
		/// <summary>
		/// "About me" 
		/// </summary>
		public string about { get; set; }

		/// <summary>
		/// Activities. 
		/// </summary>
		public string activities { get; set; }

		/// <summary>
		/// user's date of birth.  
		/// Returned as DD.MM.YYYY or DD.MM (if birth year is hidden). If the whole date is hidden, no field is returned. 
		/// </summary>
		public string bdate { get; set; }

		/// <summary>
		/// Returns 1 if a current user is in the requested user's blacklist. 
		/// </summary>
		public string blacklisted { get; set; }

		/// <summary>
		/// Returns 1 if a user is in the current user's blacklist. 
		/// </summary>
		public string blacklisted_by_me { get; set; }

		/// <summary>
		/// Favorite books. 
		/// </summary>
		public string books { get; set; }

		/// <summary>
		/// Information whether current user can post on the wall: 1 – allowed, 0 — not allowed. 
		/// </summary>
		public string can_post { get; set; }

		/// <summary>
		/// Information whether current user can see other users' posts on the wall: 1 – allowed, 0 – not allowed. 
		/// </summary>
		public string can_see_all_posts { get; set; }

		/// <summary>
		/// Information whether current user can see users' audio: 1 – allowed, 0 – not allowed. 
		/// </summary>
		public string can_see_audio { get; set; }

		/// <summary>
		/// Information whether current user can send friend request to a user: 1 – allowed, 0 – not allowed. 
		/// </summary>
		public string can_send_friend_request { get; set; }

		/// <summary>
		/// Information whether current user can write private messages to a user: 1 – allowed, 0 – not allowed. 
		/// </summary>
		public string can_write_private_message { get; set; }

		/// <summary>
		/// information about user's career. Object with following fileds:
		///  group_id(integer) — community ID(if available, otherwise company);
		///  company(string) — company name(if available, otherwise group_id);
		///  country_id(integer) — country ID;
		///  city_id(integer) — city ID(if available, otherwise city_name);
		///  city_name(string) — city name(if available, otherwise city_id);
		///  from(integer) — career beginning year;
		///  until(integer) — career ending year;
		///  position(string) — position. 
		/// </summary>
		public VKontakteCareer[] career { get; set; }

		/// <summary>
		/// City specified on user's page in "Contacts" section. Contains following fields:
		///  id(integer) — city ID;
		///  title(string) — city name. 
		/// </summary>
		public VKontakteCity city { get; set; }

		/// <summary>
		/// Number of common friends with current user. 
		/// </summary>
		public string common_count { get; set; }

		/// <summary>
		/// Returns specified services such as: skype, facebook, twitter, livejournal, instagram. 
		/// </summary>
		public string connections { get; set; }

		/// <summary>
		/// Information about user's phone numbers. 
		/// If data are available and not hidden in privacy settings, the following fields are returned:
		///  mobile_phone(string) — user's mobile phone number (only for standalone applications);
		///  home_phone(string) — user's additional phone number. 
		/// </summary>
		public VKontakteContacts contacts { get; set; }

		/// <summary>
		/// Number of various objects the user has.  Can be used in users.get method only when requesting information about a user. 
		/// </summary>
		public VKontakteCounters counters { get; set; }

		/// <summary>
		/// Country specified on user's page in "Contacts" section. Contains following fields:
		/// id(integer) — country ID;
		/// title(string) — country name. 
		/// </summary>
		public VKontakteCountry country { get; set; }

		/// <summary>
		/// Data about points used for cropping of profile and preview user photos. Contains following fields:
		///  photo(object) — Photo object with user photo used for cropping main profile photo.
		///  crop(object) — cropped user photo.Contains following fields:
		///  x(number) — X coordinate for the left upper corner, %;
		///  y(number) — Y coordinate for the left upper corner, %;
		///  x2(number) — X coordinate for the right bottom corner, %;
		///  y2(number) —Y coordinate for the right bottom corner, %.
		///  rect(object) — preview square photo cropped from crop photo.Contains the same fields set as crop object.. 
		/// </summary>
		public VKontakteCropPhoto crop_photo { get; set; }

		/// <summary>
		/// page screen name.  Returns a string with a page screen name (only subdomain is returned, like andrew). 
		///  If not set, "id'+uid is returned, e.g. id35828305. 
		/// </summary>
		public string domain { get; set; }

		/// <summary>
		/// Information about user's higher education institution. 
		/// </summary>
		public VKontakteEducation education { get; set; }

		/// <summary>
		/// first name 
		/// </summary>
		public string first_name { get; set; }

		/// <summary>
		/// Number of followers 
		/// </summary>
		public string followers_count { get; set; }

		/// <summary>
		/// Friend status with a current user. Possible values:
		///  0 — not a friend;
		///  1 — outcome request has been sent;
		///  2 — incoming request has been sent;,
		///  3 — friend. 
		/// </summary>
		public string friend_status { get; set; }

		/// <summary>
		/// Favorite games. 
		/// </summary>
		public string games { get; set; }

		/// <summary>
		/// Information whether the user's mobile phone number is available.  
		/// Returned values: 1 — available, 0 — not available.  
		/// We recommend you to use it prior to call of secure.sendSMSNotification method. 
		/// flag, can be 1 or 0 
		/// </summary>
		public string has_mobile { get; set; }

		/// <summary>
		/// Information whether the user has profile photo. 
		/// </summary>
		public string has_photo { get; set; }

		/// <summary>
		/// User's home town name. 
		/// </summary>
		public string home_town { get; set; }

		/// <summary>
		/// Interests. 
		/// </summary>
		public string interests { get; set; }

		/// <summary>
		/// Information whether the user is in faves of current user. 
		/// </summary>
		public string is_favorite { get; set; }

		/// <summary>
		/// Information whether the user is a friend of current user. 
		/// </summary>
		public string is_friend { get; set; }

		/// <summary>
		/// Information whether the user is hidden from current user's feed. 
		/// </summary>
		public string is_hidden_from_feed { get; set; }

		/// <summary>
		/// last name 
		/// </summary>
		public string last_name { get; set; }

		/// <summary>
		/// last visit date.  Returns last_seen object with the following fields:
		///  time(integer) — last visit date(in Unixtime). 
		///  platform(integer) — type of the platform that used for the last authorization.Possible values:
		///  1 — m.vk.com;
		///  2 — iPhone app;
		///  3 — iPad app;
		///  4 — Android app;
		///  5 —Windows Phone app;
		///  6 — Windows 8 app;
		///  7 — web(vk.com);
		///  8 — VK Mobile. 
		/// </summary>
		public VKontakteLastSeen last_seen { get; set; }

		/// <summary>
		/// Comma-separated friend lists IDs the user is included to. Field is available for friends.get method only. 
		/// </summary>
		public string lists { get; set; }

		/// <summary>
		/// Maiden name. 
		/// </summary>
		public string maiden_name { get; set; }

		/// <summary>
		/// Information about user's military service. 
		/// </summary>
		public VKontakteMilitary[] military { get; set; }

		/// <summary>
		/// Favorite movies. 
		/// </summary>
		public string movies { get; set; }

		/// <summary>
		/// Favorite music. 
		/// </summary>
		public string music { get; set; }

		/// <summary>
		/// User nickname 
		/// </summary>
		public string nickname { get; set; }

		/// <summary>
		/// User's occupation. 
		/// </summary>
		public VKontakteOccupation occupation { get; set; }

		/// <summary>
		/// Information whether the user is online.  
		///  Returned values: 1 — online, 0 — offline.  
		///  If user utilizes a mobile application or site mobile version, it returns online_mobile additional field that includes 1.
		///  With that, in case of application, online_app additional field is returned with application ID. 
		/// </summary>
		public string online { get; set; }

		/// <summary>
		/// Information from the "Personal views" section. 
		/// </summary>
		public VKontaktePersonal personal { get; set; }

		/// <summary>
		/// returns URL of square photo of the user with 50 pixels in width.  
		///  In case user does not have a photo, http://vk.com/images/camera_c.gif is returned. 
		/// </summary>
		public string photo_50 { get; set; }

		/// <summary>
		/// returns URL of square photo of the user with 100 pixels in width.  
		/// In case user does not have a photo, http://vk.com/images/camera_b.gif is returned. 
		/// </summary>
		public string photo_100 { get; set; }

		/// <summary>
		/// returns URL of user's photo with 200 pixels in width.  
		/// In case user does not have a photo, http://vk.com/images/camera_a.gif is returned. 
		/// </summary>
		public string photo_200_orig { get; set; }

		/// <summary>
		/// returns URL of square photo of the user with 200 pixels in width.  
		/// If the photo was uploaded long time ago, there can be no image of such size and in this case the reply will not include this field. 
		/// </summary>
		public string photo_200 { get; set; }

		/// <summary>
		/// returns URL of user's photo with 400 pixels in width.
		/// If user does not have a photo of such size, reply will not include this field. 
		/// </summary>
		public string photo_400_orig { get; set; }

		/// <summary>
		/// String ID of the main profile photo in format {user_id}_{photo_id}, e.g., 6492_192164258. 
		/// Note that this field can be absent. 
		/// </summary>
		public string photo_id { get; set; }

		/// <summary>
		/// returns URL of square photo of the user with maximum width. 
		/// Can be returned a photo both 200 and 100 pixels in width.  
		/// In case user does not have a photo, http://vk.com/images/camera_b.gif is returned. 
		/// </summary>
		public string photo_max { get; set; }

		/// <summary>
		/// returns URL of square photo of the user with maximum width.
		/// Can be returned a photo both 200 and 100 pixels in width.
		/// In case user does not have a photo, http://vk.com/images/camera_b.gif is returned. 
		/// </summary>
		public string photo_max_orig { get; set; }

		/// <summary>
		/// Favorite quotes. 
		/// </summary>
		public string quotes { get; set; }

		/// <summary>
		/// Current user's relatives list. 
		/// Returns a list of objects with id and type fields (name instead of id if a relative is not a VK user). 
		/// </summary>
		public VKontakteRelatives[] relatives { get; set; }

		/// <summary>
		/// User relationship status. Returned values:
		///  1 – single;
		///  2 – in a relationship;
		///  3 – engaged;
		///  4 – married;
		///  5 – it's complicated;
		///  6 – actively searching;
		///  7 – in love;
		///  8 — in a civil union;
		///  0 — not specified. 
		/// </summary>
		public string relation { get; set; }

		/// <summary>
		/// List of schools where user studied. 
		/// </summary>
		public VKontakteSchools[] schools { get; set; }

		/// <summary>
		/// user page's screen name (subdomain). 
		/// </summary>
		public string screen_name { get; set; }

		/// <summary>
		/// user sex.  One of three values is returned:
		///  1 — female;
		///  2 — male;
		///  0 — not specified. 
		/// </summary>
		public string sex { get; set; }

		/// <summary>
		/// Returns a website address from a user profile. 
		/// </summary>
		public string site { get; set; }

		/// <summary>
		/// User status. If the audio broadcast is enabled, contains additional status_audio field with an audio object. 
		/// </summary>
		public string status { get; set; }

		/// <summary>
		/// user time zone. Retuns only while requesting current user info. 
		/// </summary>
		public string timezone { get; set; }

		/// <summary>
		/// Information whether the user a "fire" pictogram. 
		/// </summary>
		public string trending { get; set; }

		/// <summary>
		/// Favorite TV shows. 
		/// </summary>
		public string tv { get; set; }

		/// <summary>
		/// List of higher education institutions where user studied. 
		/// </summary>
		public VKontakteUniversities[] universities { get; set; }

		/// <summary>
		/// Returns 1 if the profile is verified, 0 if not. 
		/// </summary>
		public string verified { get; set; }

		/// <summary>
		/// Wall comments allowed (1 — allowed, 0 — not allowed). 
		/// </summary>
		public string wall_comments { get; set; }

		/// <summary>
		/// user ID. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// skype 
		/// </summary>
		public string skype { get; set; }

		/// <summary>
		/// university 
		/// </summary>
		public string university { get; set; }

		/// <summary>
		/// university name 
		/// </summary>
		public string university_name { get; set; }

		/// <summary>
		/// faculty 
		/// </summary>
		public string faculty { get; set; }

		/// <summary>
		/// faculty name 
		/// </summary>
		public string faculty_name { get; set; }

		/// <summary>
		/// graduation 
		/// </summary>
		public string graduation { get; set; }

	}

	///<summary>
	/// a list of user objects 
	/// </summary>
	public class VKontakteResultUser
	{
		/// <summary>
		/// object describes a user profile
		/// https://vk.com/dev/objects/user
		/// Object contains information about user. Fields set may vary depending on called method and passed parameters. 
		/// </summary>
		public VKontakteUser[] response { get; set; }

	}

}