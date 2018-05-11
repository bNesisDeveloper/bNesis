using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;
using bNesis.Api.Desktop;
using bNesis.Sdk.Common;

namespace bNesis.Sdk.Social.GooglePlus
{
	public class GooglePlus  
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

		public GooglePlus(DesktopbNesisApi bNesisApi)
		{
			this.bNesisApi = bNesisApi;
		}

		/// <summary>
		/// The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		/// </summary>
		/// <returns>bNesisToken value</returns>	
		public string Auth(string bNesisDevId,string redirectUrl)
		{
			bNesisToken = bNesisApi.Auth("Google", string.Empty,bNesisDevId,redirectUrl,string.Empty,string.Empty,null,string.Empty,string.Empty,false,string.Empty);
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
			bool result = bNesisApi.LogoffService("Google", bNesisToken);
			if (result) bNesisToken = string.Empty;
			return result;             
		}


		///<summary>
		/// Getting last exception for current provider 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo GetLastError()
		{
			return bNesisApi.Call<ErrorInfo>("GooglePlus", bNesisToken, "GetLastError");
		}

		///<summary>
		/// Getting arrays of error info 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo[] GetErrorLog()
		{
			return bNesisApi.Call<ErrorInfo[]>("GooglePlus", bNesisToken, "GetErrorLog");
		}

		///<summary>
		/// Checks the token in the service. 
		/// </summary>
		/// <returns>if token valid return true, if token not valid return false</returns>
		public Boolean ValidateToken()
		{
			return bNesisApi.Call<Boolean>("GooglePlus", bNesisToken, "ValidateToken");
		}

		///<summary>
		/// Disables the access token used to authenticate the call. 
		/// </summary>
		/// <returns>if token revoked method returns true 
		/// if token doesn't support token revocation or token is revoked method returns false</returns>
		public Boolean Logoff()
		{
			return bNesisApi.Call<Boolean>("GooglePlus", bNesisToken, "Logoff");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ContactItem GetFieldsUserUnified(string id)
		{
			return bNesisApi.Call<ContactItem>("GooglePlus", bNesisToken, "GetFieldsUserUnified", id);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="id"></param>
		/// <param name="field"></param>
		/// <returns></returns>
		public ContactItem GetFieldUserUnified(string id, string field)
		{
			return bNesisApi.Call<ContactItem>("GooglePlus", bNesisToken, "GetFieldUserUnified", id, field);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ContactItem GetUserAboutUnified(string id)
		{
			return bNesisApi.Call<ContactItem>("GooglePlus", bNesisToken, "GetUserAboutUnified", id);
		}

		///<summary>
		/// Gets current user profile based on token.
		/// For see all information about user, app must request from member this scope: https://www.googleapis.com/auth/plus.me, https://www.googleapis.com/auth/plus.login,
		/// https://www.googleapis.com/auth/userinfo.email, https://www.googleapis.com/auth/userinfo.profile 
		/// </summary>
		/// <returns>Return in GooglePlusProfile.</returns>
		public GooglePlusProfile GetAboutMe()
		{
			return bNesisApi.Call<GooglePlusProfile>("GooglePlus", bNesisToken, "GetAboutMe");
		}

		///<summary>
		/// Gets user profile by identifier. 
		/// </summary>
		/// <param name="userId">User identifier. If identifier is 'me' see .</param>
		/// <returns>Return in GooglePlusProfile.</returns>
		public GooglePlusProfile GetUserProfile(string userId)
		{
			return bNesisApi.Call<GooglePlusProfile>("GooglePlus", bNesisToken, "GetUserProfile", userId);
		}

		///<summary>
		/// Search all public profiles. 
		/// </summary>
		/// <param name="query">Specify a query string for full text search of public text in all profiles.</param>
		/// <param name="language">Specify the preferred language to search with. All code languages see: https://developers.google.com/+/web/api/rest/search#available-languages</param>
		/// <param name="maxResults">The maximum number of people returned on response. Acceptable, values are 1 to 50.</param>
		/// <param name="pageToken">The continion token to next page. (Possible can be getted in response then can it use here)</param>
		/// <returns>Return in GooglePlusItemCollection.</returns>
		public GooglePlusProfileCollection FindProfile(string query, string language, Int32 maxResults, string pageToken)
		{
			return bNesisApi.Call<GooglePlusProfileCollection>("GooglePlus", bNesisToken, "FindProfile", query, language, maxResults, pageToken);
		}

		///<summary>
		/// Gets list of people in the specified collection on particular activity. 
		/// </summary>
		/// <param name="id">User identifier. If identifier is 'me' see .</param>
		/// <param name="collection">The collection of people list. 
		///  Possible values are:
		///  plusoners - List all people who have +1'd this activity.
		///  resharers - List all people who have reshared this activity.</param>
		/// <param name="maxResults">The maximum people included in response. Acceptable values are 1 to 100.</param>
		/// <param name="pageToken">The continued token to next page. (Possible can be getted in response then can it use here)</param>
		/// <returns>Return in GooglePlusItemCollection.</returns>
		public GooglePlusProfileCollection GetListPeopleByActivity(string id, string collection, Int32 maxResults, string pageToken)
		{
			return bNesisApi.Call<GooglePlusProfileCollection>("GooglePlus", bNesisToken, "GetListPeopleByActivity", id, collection, maxResults, pageToken);
		}

		///<summary>
		/// Gets list of people in the specified collection.
		///  App must request from user this required scopes: https://www.googleapis.com/auth/plus.login 
		/// </summary>
		/// <param name="id">User identifier. If identifier is 'me' see .</param>
		/// <param name="collection">The collection of people list. 
		///  Possible values are:
		///  connected - The list of visible people in the authenticated user's circles who also use the requesting app. This list is limited to users who made their app activities visible to the authenticated user.
		///  visible - The list of people who this user has added to one or more circles, limited to the circles visible to the requesting application.</param>
		/// <param name="orderBy">Sorting people in the response by one of next order value:
		///  alphabetical - Order the people by their display name.
		///  best - Order people based on the relevence to the viewer.</param>
		/// <param name="maxResults">The maximum people included in response. Acceptable values are 1 to 100</param>
		/// <param name="pageToken">The continued token to next page. (Possible can be getted in response then can it use here)</param>
		/// <returns>Return in GooglePlusItemCollection.</returns>
		public GooglePlusProfileCollection GetListPeople(string id, string collection, string orderBy, Int32 maxResults, string pageToken)
		{
			return bNesisApi.Call<GooglePlusProfileCollection>("GooglePlus", bNesisToken, "GetListPeople", id, collection, orderBy, maxResults, pageToken);
		}

		///<summary>
		/// Gets the list of all comments for an activity. 
		/// </summary>
		/// <param name="activityId">The identifier comment to get for.</param>
		/// <param name="maxResults">The maximum number of comments returned in response. Acceptable values are 0 to 500.</param>
		/// <param name="pageToken">The continued token to next page. (Possible can be getted in response then can it use here)</param>
		/// <param name="sortOrder">The order in which to sort the list of comments.
		///  Acceptable values are:
		///  ascending - Sort oldest comments first. (default)
		///  descending - Sort newest comments first.</param>
		/// <returns>Return in GooglePlusItemCollection.</returns>
		public GooglePlusCommentCollection GetListOfComment(string activityId, Int32 maxResults, string pageToken, string sortOrder)
		{
			return bNesisApi.Call<GooglePlusCommentCollection>("GooglePlus", bNesisToken, "GetListOfComment", activityId, maxResults, pageToken, sortOrder);
		}

		///<summary>
		/// Gets a comment by identifier. 
		/// </summary>
		/// <param name="commentId">The comment identifier.</param>
		/// <returns>Return in GooglePlusComment.</returns>
		public GooglePlusComment GetComment(string commentId)
		{
			return bNesisApi.Call<GooglePlusComment>("GooglePlus", bNesisToken, "GetComment", commentId);
		}

		///<summary>
		/// Gets list of activities by specified collection for a particular user.
		///  App must request from user this scope: https://www.googleapis.com/auth/plus.login 
		/// or https://www.googleapis.com/auth/plus.me if used userId - 'me'. 
		/// </summary>
		/// <param name="userId">The identifier of user. If identifier 'me' see .</param>
		/// <param name="collection">The collection of activities to list.
		///      Acceptable values are:
		///      public - All public activities created by the specified user.</param>
		/// <param name="maxResults">The maximum activities in response. Acceptable values are 1 to 100.</param>
		/// <param name="pageToken">The continued token to next page. (Possible can be getted in response then can it use here)</param>
		/// <returns>Return in GooglePlusItemCollection.</returns>
		public GooglePlusActivityCollection GetListOfActivity(string userId, string collection, Int32 maxResults, string pageToken)
		{
			return bNesisApi.Call<GooglePlusActivityCollection>("GooglePlus", bNesisToken, "GetListOfActivity", userId, collection, maxResults, pageToken);
		}

		///<summary>
		/// Gets activity by identifier. 
		/// </summary>
		/// <param name="activityId">The activity identifier.</param>
		/// <returns>Return in GooglePlusActivity.</returns>
		public GooglePlusActivity GetActivity(string activityId)
		{
			return bNesisApi.Call<GooglePlusActivity>("GooglePlus", bNesisToken, "GetActivity", activityId);
		}

		///<summary>
		/// Search public activities. 
		/// </summary>
		/// <param name="query">Full-text query string.</param>
		/// <param name="language">Specify the preferred language to search with. All code languages see: https://developers.google.com/+/web/api/rest/search#available-languages</param>
		/// <param name="maxResults">The maximum activities in response. Acceptable values are 1 to 20.</param>
		/// <param name="orderType">Specifies how to order search results. 
		///      Acceptable values are:
		///      best - Sort activities by relevance to the user, most relevant first.
		///      recent - Sort activities by published date, most recent first. (default)</param>
		/// <param name="pageToken">The continued token to next page. (Possible can be getted in response then can it use here)</param>
		/// <returns>Return in GooglePlusItemCollection.</returns>
		public GooglePlusActivityCollection FindActivities(string query, string language, Int32 maxResults, string orderType, string pageToken)
		{
			return bNesisApi.Call<GooglePlusActivityCollection>("GooglePlus", bNesisToken, "FindActivities", query, language, maxResults, orderType, pageToken);
		}

		///<summary>
		/// Gets current user profile based on token.
		/// For see all information about user, app must request from member this scope: https://www.googleapis.com/auth/plus.me, https://www.googleapis.com/auth/plus.login,
		/// https://www.googleapis.com/auth/userinfo.email, https://www.googleapis.com/auth/userinfo.profile 
		/// </summary>
		/// <returns>Return in response.</returns>
		public Response GetAboutMeRaw()
		{
			return bNesisApi.Call<Response>("GooglePlus", bNesisToken, "GetAboutMeRaw");
		}

		///<summary>
		/// Gets user profile by identifier. 
		/// </summary>
		/// <param name="userId">User identifier. If identifier is 'me' see .</param>
		/// <returns>Return in response.</returns>
		public Response GetUserProfileRaw(string userId)
		{
			return bNesisApi.Call<Response>("GooglePlus", bNesisToken, "GetUserProfileRaw", userId);
		}

		///<summary>
		/// Search all public profiles. 
		/// </summary>
		/// <param name="query">Specify a query string for full text search of public text in all profiles.</param>
		/// <param name="language">Specify the preferred language to search with. All code languages see: https://developers.google.com/+/web/api/rest/search#available-languages</param>
		/// <param name="maxResults">The maximum number of people returned on response. Acceptable values are 1 to 50.</param>
		/// <param name="pageToken">The continued token to next page. (Possible can be getted in response then can it use here)</param>
		/// <returns>Return in response.</returns>
		public Response FindProfileRaw(string query, string language, Int32 maxResults, string pageToken)
		{
			return bNesisApi.Call<Response>("GooglePlus", bNesisToken, "FindProfileRaw", query, language, maxResults, pageToken);
		}

		///<summary>
		/// Gets list of people in the specified collection on particular activity. 
		/// </summary>
		/// <param name="id">User identifier. If identifier is 'me' see .</param>
		/// <param name="collection">The collection of people list. 
		///  Acceptable values are:
		///  plusoners - List all people who have +1'd this activity.
		///  resharers - List all people who have reshared this activity.</param>
		/// <param name="maxResults">The maximum people included in response. Acceptable values are 1 to 100.</param>
		/// <param name="pageToken">The continued token to next page. (Possible can be getted in response then can it use here)</param>
		/// <returns>Return in response.</returns>
		public Response GetListPeopleByActivityRaw(string id, string collection, Int32 maxResults, string pageToken)
		{
			return bNesisApi.Call<Response>("GooglePlus", bNesisToken, "GetListPeopleByActivityRaw", id, collection, maxResults, pageToken);
		}

		///<summary>
		/// Gets list of people in the specified collection.
		///  App must request from user this required scopes: https://www.googleapis.com/auth/plus.login 
		/// </summary>
		/// <param name="id">User identifier. If identifier is 'me' see .</param>
		/// <param name="collection">The collection of people list. 
		///  Acceptable values are:
		///  connected - The list of visible people in the authenticated user's circles who also use the requesting app. This list is limited to users who made their app activities visible to the authenticated user.
		///  visible - The list of people who this user has added to one or more circles, limited to the circles visible to the requesting application.</param>
		/// <param name="orderBy">Sorting people in the response by one of next order value:
		///  alphabetical - Order the people by their display name.
		///  best - Order people based on the relevence to the viewer.</param>
		/// <param name="maxResults">The maximum people included in response. Acceptable values are 1 to 100</param>
		/// <param name="pageToken">The continued token to next page. (Possible can be getted in response then can it use here)</param>
		/// <returns>Return in response.</returns>
		public Response GetListPeopleRaw(string id, string collection, string orderBy, Int32 maxResults, string pageToken)
		{
			return bNesisApi.Call<Response>("GooglePlus", bNesisToken, "GetListPeopleRaw", id, collection, orderBy, maxResults, pageToken);
		}

		///<summary>
		/// Gets the list of all comments for an activity. 
		/// </summary>
		/// <param name="activityId">The identifier comment to get for.</param>
		/// <param name="maxResults">The maximum number of comments returned in response. Acceptable values are 0 to 500.</param>
		/// <param name="pageToken">The continued token to next page. (Possible can be getted in response then can it use here)</param>
		/// <param name="sortOrder">The order in which to sort the list of comments.
		///  Acceptable values are:
		///  ascending - Sort oldest comments first. (default)
		///  descending - Sort newest comments first.</param>
		/// <returns>Return in response.</returns>
		public Response GetListOfCommentRaw(string activityId, Int32 maxResults, string pageToken, string sortOrder)
		{
			return bNesisApi.Call<Response>("GooglePlus", bNesisToken, "GetListOfCommentRaw", activityId, maxResults, pageToken, sortOrder);
		}

		///<summary>
		/// Gets a comment by identifier. 
		/// </summary>
		/// <param name="commentId">The comment identifier.</param>
		/// <returns>Return in response.</returns>
		public Response GetCommentRaw(string commentId)
		{
			return bNesisApi.Call<Response>("GooglePlus", bNesisToken, "GetCommentRaw", commentId);
		}

		///<summary>
		/// Gets list of activities by specified collection for a particular user.
		///  App must request from user this scope: https://www.googleapis.com/auth/plus.login 
		/// or https://www.googleapis.com/auth/plus.me if used userId - 'me'. 
		/// </summary>
		/// <param name="userId">The identifier of user. If identifier 'me' see .</param>
		/// <param name="collection">The collection of activities to list.
		///  Acceptable values are:
		///  public - All public activities created by the specified user.</param>
		/// <param name="maxResults">The maximum activities in response. Acceptable values are 1 to 100.</param>
		/// <param name="pageToken">The continued token to next page. (Possible can be getted in response then can it use here)</param>
		/// <returns>Return in response.</returns>
		public Response GetListOfActivityRaw(string userId, string collection, Int32 maxResults, string pageToken)
		{
			return bNesisApi.Call<Response>("GooglePlus", bNesisToken, "GetListOfActivityRaw", userId, collection, maxResults, pageToken);
		}

		///<summary>
		/// Gets activity by identifier. 
		/// </summary>
		/// <param name="activityId">The activity identifier.</param>
		/// <returns>Return in response.</returns>
		public Response GetActivityRaw(string activityId)
		{
			return bNesisApi.Call<Response>("GooglePlus", bNesisToken, "GetActivityRaw", activityId);
		}

		///<summary>
		/// Search public activities. 
		/// </summary>
		/// <param name="query">Full-text query string.</param>
		/// <param name="language">Specify the preferred language to search with. All code languages see: https://developers.google.com/+/web/api/rest/search#available-languages</param>
		/// <param name="maxResults">The maximum activities in response. Acceptable values are 1 to 20.</param>
		/// <param name="orderType">Specifies how to order search results. 
		///  Acceptable values are:
		///  best - Sort activities by relevance to the user, most relevant first.
		///  recent - Sort activities by published date, most recent first. (default)</param>
		/// <param name="pageToken">The continued token to next page. (Possible can be getted in response then can it use here)</param>
		/// <returns>Return in response.</returns>
		public Response FindActivitiesRaw(string query, string language, Int32 maxResults, string orderType, string pageToken)
		{
			return bNesisApi.Call<Response>("GooglePlus", bNesisToken, "FindActivitiesRaw", query, language, maxResults, orderType, pageToken);
		}
}
	///<summary>
	/// Implementation class of GooglePlusEmails. 
	/// </summary>
	public class GooglePlusEmail
	{
		/// <summary>
		/// The email address. 
		/// </summary>
		public string value { get; set; }

		/// <summary>
		/// The type address.
		///   Possible values are:
		///   account - Google account email address.
		///   home - Home email address.
		///   work - Work email address.
		///   other - Other. 
		/// </summary>
		public string type { get; set; }

	}

	///<summary>
	/// Implementation class of GooglePlusUrl 
	/// </summary>
	public class GooglePlusUrl
	{
		/// <summary>
		/// The type of URL.
		///   Possible values are:
		///   otherProfile - URL for another profile.
		///   contributor - URL to a site for which this person is a contributor.
		///   website - URL for this Google+ Page's primary website.
		///   other - Other URL. 
		/// </summary>
		public string value { get; set; }

		/// <summary>
		/// The URL value. 
		/// </summary>
		public string type { get; set; }

		/// <summary>
		/// The label of the URL. 
		/// </summary>
		public string label { get; set; }

	}

	///<summary>
	/// Implementation class of GooglePlusName. 
	/// </summary>
	public class GooglePlusName
	{
		/// <summary>
		/// The full name of person. 
		/// </summary>
		public string formatted { get; set; }

		/// <summary>
		/// The family(last) name of person. 
		/// </summary>
		public string familyName { get; set; }

		/// <summary>
		/// The given(first) name of person. 
		/// </summary>
		public string givenName { get; set; }

		/// <summary>
		/// The middle name of person. 
		/// </summary>
		public string middleName { get; set; }

		/// <summary>
		/// The honorific prefixes (such as "Dr." or "Mrs.") for person. 
		/// </summary>
		public string honorificPrefix { get; set; }

		/// <summary>
		/// The honorific suffixes (such as "Jr.") for person. 
		/// </summary>
		public string honorificSuffix { get; set; }

	}

	///<summary>
	/// Implementation class of GooglePlusImage. 
	/// </summary>
	public class GooglePlusImage
	{
		/// <summary>
		/// The URL of the image. 
		/// </summary>
		public string url { get; set; }

		/// <summary>
		/// Media type of the link. 
		/// </summary>
		public string type { get; set; }

		/// <summary>
		/// Image height. (Can be unspecified) 
		/// </summary>
		public Int32 height { get; set; }

		/// <summary>
		/// Image width. (Can be unspecified) 
		/// </summary>
		public Int32 width { get; set; }

	}

	///<summary>
	/// Implementation class of GooglePlusOrganization. 
	/// </summary>
	public class GooglePlusOrganization
	{
		/// <summary>
		/// The organization name. 
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// The department within the organization. 
		/// </summary>
		public string department { get; set; }

		/// <summary>
		/// The person's job title or role of this organization. 
		/// </summary>
		public string title { get; set; }

		/// <summary>
		/// The type of organization.
		///  Possible values are:
		///   work - Work.
		///   school - School. 
		/// </summary>
		public string type { get; set; }

		/// <summary>
		/// The date that the person joined this organization. 
		/// </summary>
		public string startDate { get; set; }

		/// <summary>
		/// The date that the person left this organization. 
		/// </summary>
		public string endDate { get; set; }

		/// <summary>
		/// The location of this organization. 
		/// </summary>
		public string location { get; set; }

		/// <summary>
		/// The short description of the person's role of this organization. 
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// If true this organization is the current one. 
		/// </summary>
		public Boolean primary { get; set; }

	}

	///<summary>
	/// Implementation class of GooglePlusPlaceLived. 
	/// </summary>
	public class GooglePlusPlaceLived
	{
		/// <summary>
		/// A place where person live. 
		/// </summary>
		public string value { get; set; }

		/// <summary>
		/// If true, this place of residence is this person's primary residence. 
		/// </summary>
		public Boolean primary { get; set; }

	}

	///<summary>
	/// Implementation class of GooglePlusAgeRange. 
	/// </summary>
	public class GooglePlusAgeRange
	{
		/// <summary>
		/// The age range lower bound. 
		/// </summary>
		public Int32 min { get; set; }

		/// <summary>
		/// The age range upper bound. 
		/// </summary>
		public Int32 max { get; set; }

	}

	///<summary>
	/// Implementation class of GooglePlusCoverPhoto 
	/// </summary>
	public class GooglePlusCoverPhoto
	{
		/// <summary>
		/// The URL of the image. 
		/// </summary>
		public string url { get; set; }

		/// <summary>
		/// The image height. 
		/// </summary>
		public Int32 height { get; set; }

		/// <summary>
		/// The image width. 
		/// </summary>
		public Int32 width { get; set; }

	}

	///<summary>
	/// Implementation class of GooglePlusCoverInfo. 
	/// </summary>
	public class GooglePlusCoverInfo
	{
		/// <summary>
		/// The difference between the top position of the cover image and the actual displayed cover image. 
		///   Only valid for banner layout. 
		/// </summary>
		public Int32 topImageOffset { get; set; }

		/// <summary>
		/// The difference between the left position of the cover image and the actual displayed cover image
		///   Only valid for banner layout. 
		/// </summary>
		public Int32 leftImageOffset { get; set; }

	}

	///<summary>
	/// Implementation class of GooglePlusCover 
	/// </summary>
	public class GooglePlusCover
	{
		/// <summary>
		/// The layout of the cover art.
		///   Possible values are:
		///   banner - One large image banner.
		///   See also: https://developers.google.com/+/web/api/rest/latest/people#cover.layout 
		/// </summary>
		public string layout { get; set; }

		/// <summary>
		/// The person's primary cover image. 
		/// </summary>
		public GooglePlusCoverPhoto coverPhoto { get; set; }

		/// <summary>
		/// Extra information about the cover photo. 
		/// </summary>
		public GooglePlusCoverInfo coverInfo { get; set; }

	}

	///<summary>
	/// Implementation class of GooglePlusProfile. 
	/// </summary>
	public class GooglePlusProfile
	{
		/// <summary>
		/// Identifies this resource. 
		/// </summary>
		public string kind { get; set; }

		/// <summary>
		/// The identifier of this profile. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// ETag of this profile. 
		/// </summary>
		public string etag { get; set; }

		/// <summary>
		/// The nickname of this profile. 
		/// </summary>
		public string nickname { get; set; }

		/// <summary>
		/// The occupation of this profile. 
		/// </summary>
		public string occupation { get; set; }

		/// <summary>
		/// The person's skills. 
		/// </summary>
		public string skills { get; set; }

		/// <summary>
		/// The person's date of birth. (Format: YYYY-MM-DD) 
		/// </summary>
		public string birthday { get; set; }

		/// <summary>
		/// The person's gender.
		///   Possible values are:
		///   male - Male gender.
		///   female - Female gender.
		///   other - Other. 
		/// </summary>
		public string gender { get; set; }

		/// <summary>
		/// The array of email which has in this profile. 
		/// </summary>
		public GooglePlusEmail[] emails { get; set; }

		/// <summary>
		/// The array of url which has in this profile. 
		/// </summary>
		public GooglePlusUrl[] urls { get; set; }

		/// <summary>
		/// The type of this profile .
		///   Possible values are:
		///   person - represents an actual person.
		///   page - represents a page. 
		/// </summary>
		public string objectType { get; set; }

		/// <summary>
		/// The person name, which is displayed. 
		/// </summary>
		public string displayName { get; set; }

		/// <summary>
		/// An object representation of the individual components of a person's name. 
		/// </summary>
		public GooglePlusName name { get; set; }

		/// <summary>
		/// The brief description (tagline) in this profile. 
		/// </summary>
		public string tagline { get; set; }

		/// <summary>
		/// The "bragging rights" line in this profile. 
		/// </summary>
		public string braggingRights { get; set; }

		/// <summary>
		/// A short biography. 
		/// </summary>
		public string aboutMe { get; set; }

		/// <summary>
		/// The person's relationship status.
		///   Possible values are:
		///   single - Person is single.
		///   in_a_relationship - Person is in a relationship.
		///   engaged - Person is engaged.
		///   married - Person is married.
		///   See also: https://developers.google.com/+/web/api/rest/latest/people#relationshipStatus 
		/// </summary>
		public string relationshipStatus { get; set; }

		/// <summary>
		/// The url to person's profile. 
		/// </summary>
		public string url { get; set; }

		/// <summary>
		/// The representation of person's profile photo. 
		/// </summary>
		public GooglePlusImage image { get; set; }

		/// <summary>
		/// The array of orgainzation with which person is associated. 
		/// </summary>
		public GooglePlusOrganization[] organizations { get; set; }

		/// <summary>
		/// The array of place where person is lived. 
		/// </summary>
		public GooglePlusPlaceLived[] placesLived { get; set; }

		/// <summary>
		/// Whether this user has signed up for Google+. 
		/// </summary>
		public Boolean isPlusUser { get; set; }

		/// <summary>
		/// The person's preferred language. 
		/// </summary>
		public string language { get; set; }

		/// <summary>
		/// The age range of the person. 
		/// </summary>
		public GooglePlusAgeRange ageRange { get; set; }

		/// <summary>
		/// If a Google+ Page, the number of people who have +1'd this page. 
		/// </summary>
		public Int32 plusOneCount { get; set; }

		/// <summary>
		/// Followers who are visible, the number of people who have added this person or page to a circle. 
		/// </summary>
		public Int32 circledByCount { get; set; }

		/// <summary>
		/// Whether the person or Google+ Page has been verified. This is used only for pages with a higher risk of being impersonated or similar.
		///   This flag will not be present on most profiles, so is can be null. 
		/// </summary>
		public Nullable<Boolean> verified { get; set; }

		/// <summary>
		/// The cover photo content. 
		/// </summary>
		public GooglePlusCover cover { get; set; }

		/// <summary>
		/// The hosted domain name for the user's Google Apps account. 
		/// </summary>
		public string domain { get; set; }

	}

	///<summary>
	/// Implementation class of GooglePlusProfileCollection. 
	/// </summary>
	public class GooglePlusProfileCollection
	{
		/// <summary>
		/// Identifier the resource. 
		/// </summary>
		public string kind { get; set; }

		/// <summary>
		/// ETag of this response for caching purposes. 
		/// </summary>
		public string etag { get; set; }

		/// <summary>
		/// Link to this resource. 
		/// </summary>
		public string selfLink { get; set; }

		/// <summary>
		/// The title of collection. 
		/// </summary>
		public string title { get; set; }

		/// <summary>
		/// The next page token to collection. 
		/// </summary>
		public string nextPageToken { get; set; }

		/// <summary>
		/// The total items. 
		/// </summary>
		public Int32 totalItems { get; set; }

		/// <summary>
		/// The array of GooglePlusProfile. 
		/// </summary>
		public GooglePlusProfile[] items { get; set; }

	}

	///<summary>
	/// Implementation class of GooglePlusActor. 
	/// </summary>
	public class GooglePlusActor
	{
		/// <summary>
		/// The identifier of the actor. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The formated name of the actor. 
		/// </summary>
		public string displayName { get; set; }

		/// <summary>
		/// The representation of actor name. 
		/// </summary>
		public GooglePlusName name { get; set; }

		/// <summary>
		/// A link to the Person for this actor. 
		/// </summary>
		public string url { get; set; }

		/// <summary>
		/// The image representation for this actor. 
		/// </summary>
		public GooglePlusImage image { get; set; }

	}

	///<summary>
	/// Implementation class of GooglePlusCommentContent. 
	/// </summary>
	public class GooglePlusCommentContent
	{
		/// <summary>
		/// The object type.
		///  Possible values are:
		/// comment - A comment in reply to an activity. 
		/// </summary>
		public string objectType { get; set; }

		/// <summary>
		/// The HTML-formatted content. 
		/// </summary>
		public string content { get; set; }

		/// <summary>
		/// The content without HTML-formatted. 
		/// </summary>
		public string originalContent { get; set; }

	}

	///<summary>
	/// Implementation class of GooglePlusInReplyTo 
	/// </summary>
	public class GooglePlusInReplyTo
	{
		/// <summary>
		/// The identifier of activity. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The url of activity. 
		/// </summary>
		public string url { get; set; }

	}

	///<summary>
	/// Implementation class of GooglePlusAboutItem. 
	/// </summary>
	public class GooglePlusAboutItem
	{
		/// <summary>
		/// The number of. 
		/// </summary>
		public Int32 totalItems { get; set; }

		/// <summary>
		/// The URL of. 
		/// </summary>
		public string selfLink { get; set; }

	}

	///<summary>
	/// Implementation class of GooglePlusComment 
	/// </summary>
	public class GooglePlusComment
	{
		/// <summary>
		/// Identifier this resources as a comment. 
		/// </summary>
		public string kind { get; set; }

		/// <summary>
		/// The identifier. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// ETag of this response for caching purposes 
		/// </summary>
		public string etag { get; set; }

		/// <summary>
		/// This comment's verb, indicating what action was performed.
		///   Possible values are:
		///   post - Publish content to the stream. 
		/// </summary>
		public string verb { get; set; }

		/// <summary>
		/// When comment created. 
		/// </summary>
		public string published { get; set; }

		/// <summary>
		/// When comment updated. 
		/// </summary>
		public string updated { get; set; }

		/// <summary>
		/// Actor who write comment. 
		/// </summary>
		public GooglePlusActor actor { get; set; }

		/// <summary>
		/// Content contain some information about of comment. 
		/// </summary>
		public GooglePlusCommentContent content { get; set; }

		/// <summary>
		/// Link to this comment resource. 
		/// </summary>
		public string selfLink { get; set; }

		/// <summary>
		/// The activity this comment replied to. 
		/// </summary>
		public GooglePlusInReplyTo[] inReplyTo { get; set; }

		/// <summary>
		/// People who +1'd this comment ''. 
		/// </summary>
		public GooglePlusAboutItem plusoners { get; set; }

	}

	///<summary>
	/// Implementation class of GooglePlusCommentCollection. 
	/// </summary>
	public class GooglePlusCommentCollection
	{
		/// <summary>
		/// Identifier the resource. 
		/// </summary>
		public string kind { get; set; }

		/// <summary>
		/// ETag of this response for caching purposes. 
		/// </summary>
		public string etag { get; set; }

		/// <summary>
		/// Link to next page. 
		/// </summary>
		public string nextLink { get; set; }

		/// <summary>
		/// The title of collection. 
		/// </summary>
		public string title { get; set; }

		/// <summary>
		/// The next page token to collection. 
		/// </summary>
		public string nextPageToken { get; set; }

		/// <summary>
		/// When updated. 
		/// </summary>
		public string updated { get; set; }

		/// <summary>
		/// The identifier of collection. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// Some description. 
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// The array of GooglePlusComment. 
		/// </summary>
		public GooglePlusComment[] items { get; set; }

	}

	///<summary>
	/// Implementation class of GooglePlusEmbed. 
	/// </summary>
	public class GooglePlusEmbed
	{
		/// <summary>
		/// URL of the link. 
		/// </summary>
		public string url { get; set; }

		/// <summary>
		/// Media type of the link 
		/// </summary>
		public string type { get; set; }

	}

	///<summary>
	/// Implementation class of GooglePlusThumbnail. 
	/// </summary>
	public class GooglePlusThumbnail
	{
		/// <summary>
		/// The URL to album. 
		/// </summary>
		public string url { get; set; }

		/// <summary>
		/// The description of album. 
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// Image resource. 
		/// </summary>
		public GooglePlusImage image { get; set; }

	}

	///<summary>
	/// Implementation class of GooglePlusAttachment. 
	/// </summary>
	public class GooglePlusAttachment
	{
		/// <summary>
		/// The identifier of attachment. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The type of media object.
		///   Possible values are:
		///   photo - A photo.
		///   album - A photo album.
		///   video - A video.
		///   article - An article, specified by a link. 
		/// </summary>
		public string objectType { get; set; }

		/// <summary>
		/// The title of attachment. 
		/// </summary>
		public string displayName { get; set; }

		/// <summary>
		/// Contain description for . 
		/// </summary>
		public string content { get; set; }

		/// <summary>
		/// The link to attachment. 
		/// </summary>
		public string url { get; set; }

		/// <summary>
		/// Preview for photos or videos. 
		/// </summary>
		public GooglePlusImage image { get; set; }

		/// <summary>
		/// The full image URL for attachment. 
		/// </summary>
		public GooglePlusImage fullImage { get; set; }

		/// <summary>
		/// If attachment is video, the emdedable link. 
		/// </summary>
		public GooglePlusEmbed embed { get; set; }

		/// <summary>
		/// If attachment is album contain list of potential additional thumbnails from the album. 
		/// </summary>
		public GooglePlusThumbnail[] thumbnails { get; set; }

	}

	///<summary>
	/// Implementation class of GooglePlusActivityContent. 
	/// </summary>
	public class GooglePlusActivityContent
	{
		/// <summary>
		/// The identifier of this content. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The type of the content.
		///   Possible values are:
		///   note - textual content.
		///   activity - A Google+ activity. 
		/// </summary>
		public string objectType { get; set; }

		/// <summary>
		/// If this activity's object is itself another activity, such as when a person reshares an activity,
		///  this property specifies the original activity's actor. 
		/// </summary>
		public GooglePlusActor actor { get; set; }

		/// <summary>
		/// The HTML-formatted content. 
		/// </summary>
		public string content { get; set; }

		/// <summary>
		/// The content(text) without HTML. 
		/// </summary>
		public string originalContent { get; set; }

		/// <summary>
		/// The URL to the resource. 
		/// </summary>
		public string url { get; set; }

		/// <summary>
		/// Total number of comments on this activity.
		///  ( - number of comments) 
		/// </summary>
		public GooglePlusAboutItem replies { get; set; }

		/// <summary>
		/// People who +1'd this activity.
		///   ( - number of people) 
		/// </summary>
		public GooglePlusAboutItem plusoners { get; set; }

		/// <summary>
		/// People who reshared this activity.
		///   ( - number of people) 
		/// </summary>
		public GooglePlusAboutItem resharers { get; set; }

		/// <summary>
		/// The media objects attached to this activity. 
		/// </summary>
		public GooglePlusAttachment[] attachments { get; set; }

	}

	///<summary>
	/// Implementation class of GooglePlusProvider 
	/// </summary>
	public class GooglePlusProvider
	{
		/// <summary>
		/// Name of the service provider. 
		/// </summary>
		public string title { get; set; }

	}

	///<summary>
	/// Implementation class of GooglePlusAccess. 
	/// </summary>
	public class GooglePlusAccess
	{
		/// <summary>
		/// The identifier of entry for circle or person . 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The type of entry for whom have access is granted.
		///   Possible values are:
		///   person - Access to an individual.
		///   circle - Access to members of a circle.
		///   "myCircles - Access to members of all the person's circles.
		///   extendedCircles - Access to members of all the person's circles, plus all of the people in their circles.
		///   domain - Access to members of the person's Google Apps domain.
		///   public - Access to anyone on the web. 
		/// </summary>
		public string type { get; set; }

		/// <summary>
		/// A descriptive name for this entry. 
		/// </summary>
		public string displayName { get; set; }

	}

	///<summary>
	/// Implementation class of GooglePlusPosition. 
	/// </summary>
	public class GooglePlusPosition
	{
		/// <summary>
		/// The latitude of this position. 
		/// </summary>
		public Single latitude { get; set; }

		/// <summary>
		/// The longitude of this position. 
		/// </summary>
		public Single longitude { get; set; }

	}

	///<summary>
	/// Implementation class of GooglePlusAddress. 
	/// </summary>
	public class GooglePlusAddress
	{
		/// <summary>
		/// The formated address. 
		/// </summary>
		public string formatted { get; set; }

	}

	///<summary>
	/// Implementation class of GooglePlusLocation. 
	/// </summary>
	public class GooglePlusLocation
	{
		/// <summary>
		/// Identifies this resource as a place. 
		/// </summary>
		public string kind { get; set; }

		/// <summary>
		/// The identifier of the location. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The name of the place 
		/// </summary>
		public string displayName { get; set; }

		/// <summary>
		/// The position of the place. 
		/// </summary>
		public GooglePlusPosition position { get; set; }

		/// <summary>
		/// The physical address of the place. 
		/// </summary>
		public GooglePlusAddress address { get; set; }

	}

	///<summary>
	/// Implementation class of GooglePlusActivity. 
	/// </summary>
	public class GooglePlusActivity
	{
		/// <summary>
		/// The identifier of this activity. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// Identifies this resource as an activity 
		/// </summary>
		public string kind { get; set; }

		/// <summary>
		/// ETag of this response for caching purposes 
		/// </summary>
		public string etag { get; set; }

		/// <summary>
		/// The title of this activity. 
		/// </summary>
		public string title { get; set; }

		/// <summary>
		/// The time when this activity initially published. 
		/// </summary>
		public string published { get; set; }

		/// <summary>
		/// The time when this activity was updated. 
		/// </summary>
		public string updated { get; set; }

		/// <summary>
		/// The link to this activity. 
		/// </summary>
		public string url { get; set; }

		/// <summary>
		/// The person who perfomed this activity. 
		/// </summary>
		public GooglePlusActor actor { get; set; }

		/// <summary>
		/// This activity's verb, which indicates the action that was performed.
		///   Possible values are:
		///   post - Publish content to the stream.
		///   share - Reshare an activity. 
		/// </summary>
		public string verb { get; set; }

		/// <summary>
		/// The content of this activity. 
		/// </summary>
		public GooglePlusActivityContent activityContent { get; set; }

		/// <summary>
		/// Additional content added by the person who shared this activity, applicable only when resharing an activity. 
		/// </summary>
		public string annotation { get; set; }

		/// <summary>
		/// If this activity is a crosspost from another system, this property specifies the ID of the original activity. 
		/// </summary>
		public string crosspostSource { get; set; }

		/// <summary>
		/// The service provider who published this activity. 
		/// </summary>
		public GooglePlusProvider provider { get; set; }

		/// <summary>
		/// Identifies who has access to see this activity. 
		/// </summary>
		public GooglePlusAccess access { get; set; }

		/// <summary>
		/// Latitude and longitude where this activity occurred. Format is latitude followed by longitude, space separated. 
		/// </summary>
		public string geocode { get; set; }

		/// <summary>
		/// Street address where this activity occurred. 
		/// </summary>
		public string address { get; set; }

		/// <summary>
		/// Radius, in meters, of the region where this activity occurred, centered at the latitude and longitude identified in . 
		/// </summary>
		public string radius { get; set; }

		/// <summary>
		/// The identifier of the place where this activity occurred. 
		/// </summary>
		public string placeId { get; set; }

		/// <summary>
		/// Name of the place where this activity occurred. 
		/// </summary>
		public string placeName { get; set; }

		/// <summary>
		/// The location where this activity occurred. 
		/// </summary>
		public GooglePlusLocation location { get; set; }

	}

	///<summary>
	/// Implementation class of GooglePlusActivityCollection. 
	/// </summary>
	public class GooglePlusActivityCollection
	{
		/// <summary>
		/// Identifier the resource. 
		/// </summary>
		public string kind { get; set; }

		/// <summary>
		/// ETag of this response for caching purposes. 
		/// </summary>
		public string etag { get; set; }

		/// <summary>
		/// Link to this resource. 
		/// </summary>
		public string selfLink { get; set; }

		/// <summary>
		/// Link to next page. 
		/// </summary>
		public string nextLink { get; set; }

		/// <summary>
		/// The title of collection. 
		/// </summary>
		public string title { get; set; }

		/// <summary>
		/// The next page token to collection. 
		/// </summary>
		public string nextPageToken { get; set; }

		/// <summary>
		/// When update 
		/// </summary>
		public string updated { get; set; }

		/// <summary>
		/// The identifier of collection. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The array of GooglePlusActivity. 
		/// </summary>
		public GooglePlusActivity[] items { get; set; }

	}

}