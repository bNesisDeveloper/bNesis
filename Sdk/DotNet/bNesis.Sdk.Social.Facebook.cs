using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;
using bNesis.Api.Desktop;
using bNesis.Sdk.Common;

namespace bNesis.Sdk.Social.Facebook
{
	public class Facebook  
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

		public Facebook(DesktopbNesisApi bNesisApi)
		{
			this.bNesisApi = bNesisApi;
		}

		/// <summary>
		/// The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		/// </summary>
		/// <returns>bNesisToken value</returns>	
		public string Auth(string data,string bNesisDevId,string redirectUrl,string clientId,string clientSecret,string[] scopes,string login,string password,bool isSandbox,string serviceUrl)
		{
			bNesisToken = bNesisApi.Auth("Facebook", data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl);
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
			bool result = bNesisApi.LogoffService("Facebook", bNesisToken);
			if (result) bNesisToken = string.Empty;
			return result;             
		}


		///<summary>
		/// Getting last exception for current provider 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo GetLastError()
		{
			return bNesisApi.Call<ErrorInfo>("Facebook", bNesisToken, "GetLastError");
		}

		///<summary>
		/// Getting arrays of error info 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo[] GetErrorLog()
		{
			return bNesisApi.Call<ErrorInfo[]>("Facebook", bNesisToken, "GetErrorLog");
		}

		///<summary>
		/// Checks the token in the service. 
		/// </summary>
		/// <returns>if token valid return true, if token not valid return false</returns>
		public Boolean ValidateToken()
		{
			return bNesisApi.Call<Boolean>("Facebook", bNesisToken, "ValidateToken");
		}

		///<summary>
		/// Disables the access token used to authenticate the call. 
		/// </summary>
		/// <returns>if token revoked method returns true 
		/// if token doesn't support token revocation or token is revoked method returns false</returns>
		public Boolean Logoff()
		{
			return bNesisApi.Call<Boolean>("Facebook", bNesisToken, "Logoff");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ContactItem GetFieldsUserUnified(string id)
		{
			return bNesisApi.Call<ContactItem>("Facebook", bNesisToken, "GetFieldsUserUnified", id);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="id"></param>
		/// <param name="field"></param>
		/// <returns></returns>
		public ContactItem GetFieldUserUnified(string id, string field)
		{
			return bNesisApi.Call<ContactItem>("Facebook", bNesisToken, "GetFieldUserUnified", id, field);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ContactItem GetUserAboutUnified(string id)
		{
			return bNesisApi.Call<ContactItem>("Facebook", bNesisToken, "GetUserAboutUnified", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The Facebook Groups of which the person is an Admin.</returns>
		public Response GetUserGroupsRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserGroupsRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Businesses can claim ownership of multiple apps using Business Manager. 
		/// This edge returns the list of IDs that this user has in any of those other apps</returns>
		public Response GetUserIdsForBusinessRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserIdsForBusinessRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>A list of lead generation forms belonging to Pages that the user has advertiser permissions on</returns>
		public Response GetUserLeadgenFormsRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserLeadgenFormsRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>All the Pages this person has liked</returns>
		public Response GetUserLikesRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserLikesRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Live encoders owned by this person</returns>
		public Response GetUserLiveEncodersRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserLiveEncodersRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Live videos from this person</returns>
		public Response GetUserLiveVideosRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserLiveVideosRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Movies this person likes</returns>
		public Response GetUserMoviesRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserMoviesRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Music this person likes</returns>
		public Response GetUserMusicRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserMusicRaw", id);
		}

		///<summary>
		/// Gets the user premissions.
		/// https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>a list of granted and declined permissions.</returns>
		public Response GetUserPremissionsRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserPremissionsRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Photos the person is tagged in or has uploaded</returns>
		public Response GetUserPhotosRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserPhotosRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's profile picture</returns>
		public Response GetUserPictureRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserPictureRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Developers' Graph API request history</returns>
		public Response GetUserRequestHistoryRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserRequestHistoryRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>A list of rich media documents belonging to Pages that the user has advertiser permissions on</returns>
		public Response GetUserRichMediaDocumentsRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserRichMediaDocumentsRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Any session keys that the app knows the user by</returns>
		public Response GetUserSessionKeysRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserSessionKeysRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>A list of filters that can be applied to the News Feed edge</returns>
		public Response GetUserStreamFiltersRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserStreamFiltersRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Friends that can be tagged in content published via the Graph API</returns>
		public Response GetUserTaggableFriendsRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserTaggableFriendsRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>List of tagged places for this person. It can include tags on videos, posts, statuses or links</returns>
		public Response GetUserTaggedPlacesRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserTaggedPlacesRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>TV shows this person likes</returns>
		public Response GetUserTelevisionRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserTelevisionRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Video broadcasts from this person</returns>
		public Response GetUserVideoBroadcastsRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserVideoBroadcastsRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Videos the person is tagged in or uploaded</returns>
		public Response GetUserVideosRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserVideosRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The feed of posts (including status updates) and links published by this person.</returns>
		public Response GetUserFeedRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserFeedRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <param name="message">The main body of the post, otherwise called the status message.
		/// Either link, place, or message must be supplied.</param>
		/// <param name="link">The URL of a link to attach to the post. 
		/// Either link, place, or message must be supplied. Additional fields associated with link are shown below.</param>
		/// <returns>The feed of posts (including status updates) and links published by this person.</returns>
		public Response PostUserFeedRaw(string id, string message, string link)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "PostUserFeedRaw", id, message, link);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The scores this person has received from Facebook Games that they've played.</returns>
		public Response GetUserScoresRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserScoresRaw", id);
		}

		///<summary>
		/// Page Access Tokens 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>a list of pages that the person administers along with other information about the Page, 
		/// such as the Page category, the permissions the admin has for that Page, and the page access token.</returns>
		public Response GetPageAccessTokenRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetPageAccessTokenRaw", id);
		}

		///<summary>
		/// Generates an App Access Token 
		/// </summary>
		/// <returns>app Access Token</returns>
		public Response GetAppAccessTokenRaw()
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetAppAccessTokenRaw");
		}

		///<summary>
		/// Checks the token in the service. 
		/// </summary>
		/// <returns>data with information about the token</returns>
		public Response ValidationTokenRaw()
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "ValidationTokenRaw");
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's local currency information</returns>
		public Response GetUserCurrencyRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserCurrencyRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The list of devices the person is using. This will return only iOS and Android devices</returns>
		public Response GetUserDevicesRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserDevicesRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's education</returns>
		public Response GetUserEducationRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserEducationRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's primary email address listed on their profile. 
		/// This field will not be returned if no valid email address is available</returns>
		public Response GetUserEmailRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserEmailRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Athletes the person likes</returns>
		public Response GetUserFavoriteAthletesRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserFavoriteAthletesRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Sports teams the person likes</returns>
		public Response GetUserFavoriteTeamsRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserFavoriteTeamsRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's first and last name</returns>
		public Response GetUserFirstMiddleLastNameRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserFirstMiddleLastNameRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The gender selected by this person, male or female. 
		/// If the gender is set to a custom value, this value will be based off of the preferred pronoun; 
		/// it will be omitted if the preferred preferred pronoun is neutral</returns>
		public Response GetUserGenderRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserGenderRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's hometown</returns>
		public Response GetUserHometownRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserHometownRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's inspirational people</returns>
		public Response GetUserInspirationalPeopleRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserInspirationalPeopleRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Install type</returns>
		public Response GetUserInstallTypeRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserInstallTypeRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Is the app making the request installed?</returns>
		public Response GetUserInstalledRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserInstalledRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Genders the person is interested in</returns>
		public Response GetUserInterestedInRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserInterestedInRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Is this a shared login (e.g. a gray user)</returns>
		public Response GetUserIsSharedLoginRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserIsSharedLoginRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>People with large numbers of followers can have the authenticity of their identity manually verified by Facebook. 
		/// This field indicates whether the person's profile is verified in this way. 
		/// This is distinct from the verified field</returns>
		public Response GetUserIsVerifiedRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserIsVerifiedRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Facebook Pages representing the languages this person knows</returns>
		public Response GetUserLanguagesRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserLanguagesRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>A link to the person's Timeline</returns>
		public Response GetUserLinkRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserLinkRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's locale</returns>
		public Response GetUserLocaleRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserLocaleRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// The person's current location as entered by them on their profile. This field is not related to check-ins
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>location</returns>
		public Response GetUserLocationRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserLocationRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>What the person is interested in meeting for</returns>
		public Response GetUserMeetingForRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserMeetingForRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's name formatted to correctly handle Chinese, Japanese, or Korean ordering</returns>
		public Response GetUserNameFormatRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserNameFormatRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's payment pricepoints</returns>
		public Response GetUserPaymentPricepointsRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserPaymentPricepointsRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's political views</returns>
		public Response GetUserPoliticalRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserPoliticalRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's PGP public key</returns>
		public Response GetUserPublicKeyRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserPublicKeyRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's favorite quotes</returns>
		public Response GetUserQuotesRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserQuotesRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's relationship status</returns>
		public Response GetUserRelationshipStatusRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserRelationshipStatusRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's religion</returns>
		public Response GetUserReligionRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserReligionRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Security settings</returns>
		public Response GetUserSecuritySettingsRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserSecuritySettingsRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Security settings</returns>
		public Response GetUserSharedLoginUpgradeRequiredByRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserSharedLoginUpgradeRequiredByRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Shortened, locale-aware name for the person</returns>
		public Response GetUserShortNameRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserShortNameRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's significant other</returns>
		public Response GetUserSignificantOtherRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserSignificantOtherRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Sports played by the person</returns>
		public Response GetUserSportsRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserSportsRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Platform test group</returns>
		public Response GetUserTestGroupRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserTestGroupRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>A string containing an anonymous, but unique identifier for the person. You can use this identifier with third parties</returns>
		public Response GetUserThirdPartyIdRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserThirdPartyIdRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's current timezone offset from UTC</returns>
		public Response GetUserTimezoneRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserTimezoneRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Updated time</returns>
		public Response GetUserUpdatedTimeRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserUpdatedTimeRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Latest user ref that matches a given PSID that should be invalidated. 
		/// This should only be used for anonymous messaging PSID migration</returns>
		public Response GetUserUserRefRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserUserRefRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Indicates whether the account has been verified. 
		/// This is distinct from the is_verified field. Someone is considered verified if they take any of the following actions:</returns>
		public Response GetUserVerifiedRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserVerifiedRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Video upload limits</returns>
		public Response GetUserVideoUploadLimitsRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserVideoUploadLimitsRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Can the viewer send a gift to this person?</returns>
		public Response GetUserViewerCanSendGiftRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserViewerCanSendGiftRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's website</returns>
		public Response GetUserWebsiteRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserWebsiteRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's website</returns>
		public Response GetUserWorkRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserWorkRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Pages this User has a role on.</returns>
		public Response GetUserAccountsRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserAccountsRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Achievements made in Facebook games</returns>
		public Response GetUserAchievementsRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserAchievementsRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Ad studies that this person can view</returns>
		public Response GetUserAdStudiesRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserAdStudiesRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The advertising accounts to which this person has access</returns>
		public Response GetUserAdAccountsRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserAdAccountsRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Insights data for the person's Audience Network apps</returns>
		public Response GetUserAdNetWorkanalyticsRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserAdNetWorkanalyticsRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The photo albums this person has created</returns>
		public Response GetUserAlbumsRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserAlbumsRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>App requests</returns>
		public Response GetUserApprequestForMerrecipientsRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserApprequestForMerrecipientsRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>This person's pending requests from an app</returns>
		public Response GetUserAppRequestsRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserAppRequestsRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The 3D assets owned by the user</returns>
		public Response GetUserAsset3DsRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserAsset3DsRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The books listed on this person's profile</returns>
		public Response GetUserBooksRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserBooksRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Business users corresponding to the user</returns>
		public Response GetUserBusinessUsersRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserBusinessUsersRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Businesses associated with the user</returns>
		public Response GetUserBusinessesRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserBusinessesRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The curated collections created by this user</returns>
		public Response GetUserCuratedCollectionsRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserCuratedCollectionsRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>custom labels</returns>
		public Response GetUserCustomLabelsRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserCustomLabelsRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The domains the user admins</returns>
		public Response GetUserDomainsRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserDomainsRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Events for this person.By default this does not include events the person has declined or not replied to</returns>
		public Response GetUserEventsRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserEventsRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>This person's family relationships.</returns>
		public Response GetUserFamilyRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserFamilyRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Developers' favorite requests to the Graph API</returns>
		public Response GetUserFavoriteRequestsRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserFavoriteRequestsRaw", id);
		}

		///<summary>
		/// A person's custom friend lists.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>A person's custom friend lists.</returns>
		public Response GetUserFriendlistsRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserFriendlistsRaw", id);
		}

		///<summary>
		/// Get the User's friends who have installed the app making the query.
		/// Get the User's total number of friends (including those who have not installed the app making the query)
		/// Permissions:
		/// a User access token with the following permissions: user_friends.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's friends</returns>
		public Response GetFieldsUserFriendsRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetFieldsUserFriendsRaw", id);
		}

		///<summary>
		/// Get the User's friends who have installed the app making the query.
		/// Get the User's total number of friends (including those who have not installed the app making the query)
		/// Permissions:
		/// a User access token with the following permissions: user_friends.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <param name="field">The field. Example: string fields = "id,name,birthday".
		/// It is necessary to form fields independently.</param>
		/// <returns>The person's friends</returns>
		public Response GetFieldUserFriendsRaw(string id, string field)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetFieldUserFriendsRaw", id, field);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Games this person likes</returns>
		public Response GetUserGamesRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserGamesRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>information about current user</returns>
		public FacebookUser GetFieldsUser(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetFieldsUser", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <param name="field">The field. Example: string fields = "id,name,birthday".
		/// It is necessary to form fields independently.</param>
		/// <returns>information about current user</returns>
		public FacebookUser GetFieldUser(string id, string field)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetFieldUser", id, field);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// Equivalent to the bio field
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Equivalent to the bio field</returns>
		public FacebookUser GetUserAbout(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserAbout", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// The id of this person's user account. This ID is unique to each app and cannot be used across different apps
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <returns>id</returns>
		public FacebookUser GetUserId()
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserId");
		}

		///<summary>
		/// Represents current person on Facebook.
		/// The person's current location as entered by them on their profile. This field is not related to check-ins
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's address</returns>
		public FacebookUser GetUserAddress(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserAddress", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// The age segment for this person expressed as a minimum and maximum age. For example, more than 18, less than 21.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>age range</returns>
		public FacebookUser GetUserAgeRange(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserAgeRange", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// The person's birthday. This is a fixed format string, like MM/DD/YYYY.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>birthday</returns>
		public FacebookUser GetUserBirthday(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserBirthday", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Can the person review brand polls</returns>
		public FacebookUser GetUserCanReviewMeasurementRequest(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserCanReviewMeasurementRequest", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Social context for this person</returns>
		public FacebookUser GetUserContext(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserContext", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's cover photo</returns>
		public FacebookUser GetUserCover(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserCover", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's local currency information</returns>
		public FacebookUser GetUserCurrency(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserCurrency", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The list of devices the person is using. This will return only iOS and Android devices</returns>
		public FacebookUser GetUserDevices(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserDevices", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's education</returns>
		public FacebookUser GetUserEducation(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserEducation", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's primary email address listed on their profile. 
		/// This field will not be returned if no valid email address is available</returns>
		public FacebookUser GetUserEmail(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserEmail", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Athletes the person likes</returns>
		public FacebookUser GetUserFavoriteAthletes(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserFavoriteAthletes", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Sports teams the person likes</returns>
		public FacebookUser GetUserFavoriteTeams(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserFavoriteTeams", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's first and last name</returns>
		public FacebookUser GetUserFirstMiddleLastName(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserFirstMiddleLastName", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The gender selected by this person, male or female. 
		/// If the gender is set to a custom value, this value will be based off of the preferred pronoun; 
		/// it will be omitted if the preferred preferred pronoun is neutral</returns>
		public FacebookUser GetUserGender(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserGender", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's hometown</returns>
		public FacebookUser GetUserHometown(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserHometown", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's inspirational people</returns>
		public FacebookUser GetUserInspirationalPeople(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserInspirationalPeople", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Install type</returns>
		public FacebookUser GetUserInstallType(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserInstallType", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Is the app making the request installed?</returns>
		public FacebookUser GetUserInstalled(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserInstalled", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Genders the person is interested in</returns>
		public FacebookUser GetUserInterestedIn(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserInterestedIn", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Is this a shared login (e.g. a gray user)</returns>
		public FacebookUser GetUserIsSharedLogin(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserIsSharedLogin", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>People with large numbers of followers can have the authenticity of their identity manually verified by Facebook. 
		/// This field indicates whether the person's profile is verified in this way. 
		/// This is distinct from the verified field</returns>
		public FacebookUser GetUserIsVerified(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserIsVerified", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Facebook Pages representing the languages this person knows</returns>
		public FacebookUser GetUserLanguages(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserLanguages", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>A link to the person's Timeline</returns>
		public FacebookUser GetUserLink(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserLink", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's locale</returns>
		public FacebookUser GetUserLocale(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserLocale", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// The person's current location as entered by them on their profile. This field is not related to check-ins
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>location</returns>
		public FacebookUser GetUserLocation(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserLocation", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>What the person is interested in meeting for</returns>
		public FacebookUser GetUserMeetingFor(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserMeetingFor", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's name formatted to correctly handle Chinese, Japanese, or Korean ordering</returns>
		public FacebookUser GetUserNameFormat(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserNameFormat", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's payment pricepoints</returns>
		public FacebookUser GetUserPaymentPricepoints(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserPaymentPricepoints", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's political views</returns>
		public FacebookUser GetUserPolitical(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserPolitical", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's PGP public key</returns>
		public FacebookUser GetUserPublicKey(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserPublicKey", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's favorite quotes</returns>
		public FacebookUser GetUserQuotes(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserQuotes", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's relationship status</returns>
		public FacebookUser GetUserRelationshipStatus(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserRelationshipStatus", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's religion</returns>
		public FacebookUser GetUserReligion(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserReligion", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Security settings</returns>
		public FacebookUser GetUserSecuritySettings(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserSecuritySettings", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Security settings</returns>
		public FacebookUser GetUserSharedLoginUpgradeRequiredBy(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserSharedLoginUpgradeRequiredBy", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Security settings</returns>
		public FacebookUser GetUserShortName(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserShortName", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's significant other</returns>
		public FacebookUser GetUserSignificantOther(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserSignificantOther", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Sports played by the person</returns>
		public FacebookUser GetUserSports(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserSports", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Platform test group</returns>
		public FacebookUser GetUserTestGroup(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserTestGroup", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>A string containing an anonymous, but unique identifier for the person. You can use this identifier with third parties</returns>
		public FacebookUser GetUserThirdPartyId(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserThirdPartyId", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's current timezone offset from UTC</returns>
		public FacebookUser GetUserTimezone(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserTimezone", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Updated time</returns>
		public FacebookUser GetUserUpdatedTime(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserUpdatedTime", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Updated time</returns>
		public FacebookUser GetUserUserRef(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserUserRef", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Indicates whether the account has been verified. 
		/// This is distinct from the is_verified field. Someone is considered verified if they take any of the following actions:</returns>
		public FacebookUser GetUserVerified(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserVerified", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Video upload limits</returns>
		public FacebookUser GetUserVideoUploadLimits(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserVideoUploadLimits", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Video upload limits</returns>
		public FacebookUser GetUserViewerCanSendGift(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserViewerCanSendGift", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's website</returns>
		public FacebookUser GetUserWebsite(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserWebsite", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's website</returns>
		public FacebookUser GetUserWork(string id)
		{
			return bNesisApi.Call<FacebookUser>("Facebook", bNesisToken, "GetUserWork", id);
		}

		///<summary>
		/// Get the User's friends who have installed the app making the query.
		/// Get the User's total number of friends (including those who have not installed the app making the query)
		/// Permissions:
		/// a User access token with the following permissions: user_friends.
		/// https://developers.facebook.com/docs/graph-api/reference/user/friends 
		/// </summary>
		/// <param name="id"></param>
		/// <returns>The person's friends</returns>
		public FacebookUserFriends GetFieldsUserFriends(string id)
		{
			return bNesisApi.Call<FacebookUserFriends>("Facebook", bNesisToken, "GetFieldsUserFriends", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/v2.12/user/feed 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <param name="message">The main body of the post, otherwise called the status message.
		/// Either link, place, or message must be supplied.</param>
		/// <param name="link">The URL of a link to attach to the post.
		/// Either link, place, or message must be supplied. Additional fields associated with link are shown below.</param>
		/// <returns>The feed of posts (including status updates) and links published by this person.</returns>
		public FacebookFeedResponse PostUserFeed(string id, string message, string link)
		{
			return bNesisApi.Call<FacebookFeedResponse>("Facebook", bNesisToken, "PostUserFeed", id, message, link);
		}

		///<summary>
		/// Represents current person on Facebook 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>information about current user</returns>
		public Response GetFieldsUserRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetFieldsUserRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook. 
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <param name="field">The field. Example: string fields = "id,name,birthday".
		/// It is necessary to form fields independently.</param>
		/// <returns>information about current user</returns>
		public Response GetFieldUserRaw(string id, string field)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetFieldUserRaw", id, field);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// Equivalent to the bio field
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Equivalent to the bio field</returns>
		public Response GetUserAboutRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserAboutRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// The id of this person's user account. This ID is unique to each app and cannot be used across different apps
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <returns>id</returns>
		public Response GetUserIdRaw()
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserIdRaw");
		}

		///<summary>
		/// Represents current person on Facebook.
		/// The person's current location as entered by them on their profile. This field is not related to check-ins
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's address</returns>
		public Response GetUserAddressRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserAddressRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// The age segment for this person expressed as a minimum and maximum age. For example, more than 18, less than 21.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>age range</returns>
		public Response GetUserAgeRangeRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserAgeRangeRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// The person's birthday. This is a fixed format string, like MM/DD/YYYY. 
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>birthday</returns>
		public Response GetUserBirthdayRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserBirthdayRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Can the person review brand polls</returns>
		public Response GetUserCanReviewMeasurementRequestRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserCanReviewMeasurementRequestRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Social context for this person</returns>
		public Response GetUserContextRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserContextRaw", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's cover photo</returns>
		public Response GetUserCoverRaw(string id)
		{
			return bNesisApi.Call<Response>("Facebook", bNesisToken, "GetUserCoverRaw", id);
		}
}
	///<summary>
	/// Location node used with other objects in the Graph API. 
	/// </summary>
	public class FacebookLocation
	{
		/// <summary>
		/// Gets or sets the city. 
		/// </summary>
		public string city { get; set; }

		/// <summary>
		/// City ID. Any city identified is also a city you can use for targeting ads. 
		/// </summary>
		public string city_id { get; set; }

		/// <summary>
		/// Country 
		/// </summary>
		public string country { get; set; }

		/// <summary>
		/// Country code 
		/// </summary>
		public string country_code { get; set; }

		/// <summary>
		/// Latitude 
		/// </summary>
		public Single latitude { get; set; }

		/// <summary>
		/// The parent location if this location is located within another location 
		/// </summary>
		public string located_in { get; set; }

		/// <summary>
		/// Longitude 
		/// </summary>
		public Single longitude { get; set; }

		/// <summary>
		/// Longitude 
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// Region 
		/// </summary>
		public string region { get; set; }

		/// <summary>
		/// Region ID. Specifies a geographic region, such as California. An identified region is the same as one you can use to target ads. 
		/// </summary>
		public string region_id { get; set; }

		/// <summary>
		/// State 
		/// </summary>
		public string state { get; set; }

		/// <summary>
		/// Street 
		/// </summary>
		public string street { get; set; }

		/// <summary>
		/// Zip code 
		/// </summary>
		public string zip { get; set; }

	}

	///<summary>
	/// An age range 
	/// </summary>
	public class FacebookAgeRange
	{
		/// <summary>
		/// The upper bounds of the range for this person's age. 
		/// </summary>
		public Int32 max { get; set; }

		/// <summary>
		/// The lower bounds of the range for this person's age. 
		/// </summary>
		public Int32 min { get; set; }

	}

	///<summary>
	/// FacebookData 
	/// </summary>
	public class FacebookData
	{
		/// <summary>
		/// Gets or sets the name. 
		/// </summary>
		/// <value>The name.</value>
		public string name { get; set; }

		/// <summary>
		/// Gets or sets the identifier. 
		/// </summary>
		/// <value>The identifier.</value>
		public string id { get; set; }

	}

	///<summary>
	/// FacebookCursors 
	/// </summary>
	public class FacebookCursors
	{
		/// <summary>
		/// Gets or sets the before. 
		/// </summary>
		/// <value>The before.</value>
		public string before { get; set; }

		/// <summary>
		/// Gets or sets the after. 
		/// </summary>
		/// <value>The after.</value>
		public string after { get; set; }

	}

	///<summary>
	/// FacebookPaging 
	/// </summary>
	public class FacebookPaging
	{
		/// <summary>
		/// Gets or sets the cursors. 
		/// </summary>
		/// <value>The cursors.</value>
		public FacebookCursors cursors { get; set; }

	}

	public class FacebookSummary
	{
		/// <summary>
		/// Gets or sets the total count. 
		/// </summary>
		/// <value>The total count.</value>
		public Int32 total_count { get; set; }

	}

	///<summary>
	/// All friends that the viewer and the target person have in common. This includes the friends who do not use your app
	///     Returns a list of all the Facebook friends that the session user and the request user have in common.This includes friends who use the app as well as non-app-using mutual friends. 
	/// </summary>
	public class FacebookAllMutualFriends
	{
		/// <summary>
		/// A list of User nodes. 
		/// </summary>
		public FacebookData[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

		/// <summary>
		/// Aggregated information about the edge, such as counts. 
		/// </summary>
		public FacebookSummary summary { get; set; }

	}

	///<summary>
	/// Social context edge providing a list of Facebook friends that have logged into the app that the viewer and the target person have in common 
	/// </summary>
	public class FacebookMutualFriends
	{
		/// <summary>
		/// A list of User nodes. 
		/// </summary>
		public FacebookData[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

		/// <summary>
		/// Aggregated information about the edge, such as counts. 
		/// </summary>
		public FacebookSummary summary { get; set; }

	}

	///<summary>
	/// Social context edge providing a list of the liked Pages that the calling person and the target person have in common 
	/// </summary>
	public class FacebookMutualLikes
	{
		/// <summary>
		/// A list of Page nodes. 
		/// </summary>
		public FacebookData[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

		/// <summary>
		/// Aggregated information about the edge, such as counts. 
		/// </summary>
		public FacebookSummary summary { get; set; }

	}

	///<summary>
	/// Friends of the viewer who are mutual friends with the target and have the app installed. 
	/// </summary>
	public class FacebookthreeDegreeMutualFriends
	{
		/// <summary>
		/// A list of User nodes. 
		/// </summary>
		public FacebookData[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

	}

	///<summary>
	/// Social context for a person 
	/// </summary>
	public class FacebookUserContext
	{
		/// <summary>
		/// The token representing the social context 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// All friends that the viewer and the target person have in common. This includes the friends who do not use your app 
		/// </summary>
		/// <value>Returns a list of all the Facebook friends that the session user and the request user have in common. 
		/// This includes friends who use the app as well as non-app-using mutual friends.</value>
		public FacebookAllMutualFriends all_mutual_friends { get; set; }

		/// <summary>
		/// Social context edge providing a list of Facebook friends that have logged into the app that the viewer and the target person have in common 
		/// </summary>
		public FacebookMutualFriends mutual_friends { get; set; }

		/// <summary>
		/// Social context edge providing a list of the liked Pages that the calling person and the target person have in common 
		/// </summary>
		public FacebookMutualLikes mutual_likes { get; set; }

		/// <summary>
		/// Friends of the viewer who are mutual friends with the target and have the app installed 
		/// </summary>
		public FacebookthreeDegreeMutualFriends three_degree_mutual_friends { get; set; }

	}

	///<summary>
	/// A cover photo for objects in the Graph API. Cover photos are used with Events, Groups, Pages and People. 
	/// </summary>
	public class FacebookCoverPhoto
	{
		/// <summary>
		/// The ID of the cover photo 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// Deprecated. Please use the id field instead 
		/// </summary>
		public string cover_id { get; set; }

		/// <summary>
		/// When greater than 0% but less than 100%, the cover photo overflows horizontally. 
		/// The value represents the horizontal manual offset (the amount the user dragged the photo horizontally to show the part of interest) as a percentage of the offset necessary to make the photo fit the space. 
		/// </summary>
		public Single offset_x { get; set; }

		/// <summary>
		/// When greater than 0% but less than 100%, the cover photo overflows vertically. 
		/// The value represents the vertical manual offset (the amount the user dragged the photo vertically to show the part of interest) as a percentage of the offset necessary to make the photo fit the space. 
		/// </summary>
		public Single offset_y { get; set; }

		/// <summary>
		/// Direct URL for the person's cover photo image 
		/// </summary>
		public string source { get; set; }

	}

	///<summary>
	/// A currency 
	/// </summary>
	public class FacebookCurrency
	{
		/// <summary>
		/// Will return a number that describes the number of additional decimal places to include when displaying the person's currency. For example, the API will return 100 because USD is usually displayed with two decimal places.
		/// JPY does not use decimal places, so the API will return 1. 
		/// </summary>
		public Int32 currency_offset { get; set; }

		/// <summary>
		/// The exchange rate between the person's preferred currency and US Dollars 
		/// </summary>
		public Single usd_exchange { get; set; }

		/// <summary>
		/// The inverse of usd_exchange 
		/// </summary>
		public Single usd_exchange_inverse { get; set; }

		/// <summary>
		/// The ISO-4217-3 code for the person's preferred currency (defaulting to USD if the person hasn't set one) 
		/// </summary>
		public string user_currency { get; set; }

	}

	///<summary>
	/// Device 
	/// </summary>
	public class FacebookUserDevices
	{
		/// <summary>
		/// Hardware 
		/// </summary>
		public string hardware { get; set; }

		/// <summary>
		/// OS 
		/// </summary>
		public string os { get; set; }

	}

	///<summary>
	/// An experience 
	/// </summary>
	public class FacebookExperience
	{
		/// <summary>
		/// ID 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// Description 
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// From 
		/// </summary>
		public FacebookUser from { get; set; }

		/// <summary>
		/// Name 
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// Tagged users 
		/// </summary>
		public FacebookUser[] with { get; set; }

	}

	///<summary>
	/// A Facebook page
	///     https://developers.facebook.com/docs/graph-api/reference/page/ 
	/// </summary>
	public class FacebookPage
	{
		/// <summary>
		/// Page ID. No access token is required to access this field 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The name of the Page 
		/// </summary>
		public string name { get; set; }

	}

	public class FacebookEducationExperience
	{
		/// <summary>
		/// numeric string 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// Classes taken 
		/// </summary>
		public FacebookExperience classes { get; set; }

		/// <summary>
		/// Facebook Pages representing subjects studied 
		/// </summary>
		public FacebookPage[] concentration { get; set; }

		/// <summary>
		/// The Facebook Page for the degree obtained 
		/// </summary>
		public FacebookPage degree { get; set; }

		/// <summary>
		/// The Facebook Page for this school 
		/// </summary>
		public FacebookPage school { get; set; }

		/// <summary>
		/// The type of educational institution 
		/// </summary>
		public string type { get; set; }

		/// <summary>
		/// People tagged who went to school with this person 
		/// </summary>
		public FacebookUser[] with { get; set; }

		/// <summary>
		/// Facebook Page for the year this person graduated 
		/// </summary>
		public FacebookPage year { get; set; }

	}

	///<summary>
	/// A payment pricepoint 
	/// </summary>
	public class FacebookPaymentPricepoint
	{
		/// <summary>
		/// Gets or sets the credits. 
		/// </summary>
		/// <value>The credits.</value>
		public Single credits { get; set; }

		/// <summary>
		/// Gets or sets the local currency. 
		/// </summary>
		/// <value>The local currency.</value>
		public string local_currency { get; set; }

		/// <summary>
		/// Gets or sets the user price. 
		/// </summary>
		/// <value>The user price.</value>
		public string user_price { get; set; }

	}

	///<summary>
	/// Payment pricepoints 
	/// </summary>
	public class FacebookPaymentPricepoints
	{
		/// <summary>
		/// Mobile payment pricepoints 
		/// </summary>
		public FacebookPaymentPricepoint[] mobile { get; set; }

	}

	///<summary>
	/// Secure browsing settings 
	/// </summary>
	public class FacebookSecureBrowsing
	{
		/// <summary>
		/// Enabled 
		/// </summary>
		public string enabled { get; set; }

	}

	///<summary>
	/// Security settings 
	/// </summary>
	public class FacebookSecuritySettings
	{
		/// <summary>
		/// Secure browsing settings 
		/// </summary>
		public FacebookSecureBrowsing secure_browsing { get; set; }

	}

	///<summary>
	/// Video upload limits 
	/// </summary>
	public class FacebookVideoUploadLimits
	{
		/// <summary>
		/// Length 
		/// </summary>
		public string length { get; set; }

		/// <summary>
		/// Size 
		/// </summary>
		public string size { get; set; }

	}

	///<summary>
	/// Information about a project experience 
	/// </summary>
	public class FacebookPrjectExperience
	{
		/// <summary>
		/// ID 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// Description. 
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// End date 
		/// </summary>
		public string end_date { get; set; }

		/// <summary>
		/// From 
		/// </summary>
		public FacebookUser from { get; set; }

		/// <summary>
		/// Name 
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// Start date 
		/// </summary>
		public string start_date { get; set; }

		/// <summary>
		/// Tagged users 
		/// </summary>
		public FacebookUser[] with { get; set; }

	}

	///<summary>
	/// Information about a user's work 
	/// </summary>
	public class FacebookWorkExperience
	{
		/// <summary>
		/// Identifier 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// Description 
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// Employer 
		/// </summary>
		public FacebookPage employer { get; set; }

		/// <summary>
		/// End date 
		/// </summary>
		public string end_date { get; set; }

		/// <summary>
		/// Tagged by 
		/// </summary>
		public string from { get; set; }

		/// <summary>
		/// Location 
		/// </summary>
		public FacebookPage location { get; set; }

		/// <summary>
		/// Position 
		/// </summary>
		public FacebookPage position { get; set; }

		/// <summary>
		/// Projects 
		/// </summary>
		public FacebookPrjectExperience[] projects { get; set; }

		/// <summary>
		/// Start date 
		/// </summary>
		public string start_date { get; set; }

		/// <summary>
		/// Tagged users 
		/// </summary>
		public FacebookUser[] with { get; set; }

	}

	///<summary>
	/// This edge allows you to:
	///     get the User's friends who have installed the app making the query
	///     get the User's total number of friends (including those who have not installed the app making the query)
	///     The person's friends 
	/// </summary>
	public class FacebookUserFriends
	{
		/// <summary>
		/// A list of User nodes. 
		/// </summary>
		public FacebookUser[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

		/// <summary>
		/// Aggregated information about the edge, such as counts. 
		/// Specify the fields to fetch in the summary param (like summary=total_count). 
		/// </summary>
		public FacebookSummary summary { get; set; }

	}

	///<summary>
	/// Information of User 
	/// </summary>
	public class FacebookUser
	{
		/// <summary>
		/// The id of this person's user account. 
		/// This ID is unique to each app and cannot be used across different apps. 
		/// </summary>
		/// <value>The identifier.</value>
		public string id { get; set; }

		/// <summary>
		/// Equivalent to the bio field 
		/// </summary>
		/// <value>The about.</value>
		public string about { get; set; }

		/// <summary>
		/// The person's address 
		/// </summary>
		public FacebookLocation address { get; set; }

		/// <summary>
		/// Gets or sets the age range. 
		/// </summary>
		/// <value>The age range.</value>
		public FacebookAgeRange age_range { get; set; }

		/// <summary>
		/// The person's birthday. This is a fixed format string, like MM/DD/YYYY. 
		/// </summary>
		/// <value>The birthday.</value>
		public string birthday { get; set; }

		/// <summary>
		/// Can the person review brand polls 
		/// </summary>
		/// <value>The can review measurement request.</value>
		public string can_review_measurement_request { get; set; }

		/// <summary>
		/// Social context for a person 
		/// </summary>
		public FacebookUserContext context { get; set; }

		/// <summary>
		/// A cover photo for objects in the Graph API. Cover photos are used with Events, Groups, Pages and People. 
		/// </summary>
		public FacebookCoverPhoto cover { get; set; }

		/// <summary>
		/// The person's local currency information 
		/// </summary>
		public FacebookCurrency currency { get; set; }

		/// <summary>
		/// The list of devices the person is using. This will return only iOS and Android devices 
		/// </summary>
		public FacebookUserDevices[] devices { get; set; }

		/// <summary>
		/// The person's education 
		/// </summary>
		/// <value>The person's education history</value>
		public FacebookEducationExperience[] education { get; set; }

		/// <summary>
		/// The person's primary email address listed on their profile. 
		/// This field will not be returned if no valid email address is available 
		/// </summary>
		public string email { get; set; }

		/// <summary>
		/// Athletes the person likes 
		/// </summary>
		public FacebookExperience[] favorite_athletes { get; set; }

		/// <summary>
		/// Sports teams the person likes 
		/// </summary>
		public FacebookExperience[] favorite_teams { get; set; }

		/// <summary>
		/// The person's first name 
		/// </summary>
		public string first_name { get; set; }

		/// <summary>
		/// The gender selected by this person, male or female. 
		/// If the gender is set to a custom value, this value will be based off of the preferred pronoun; 
		/// it will be omitted if the preferred preferred pronoun is neutral 
		/// </summary>
		public string gender { get; set; }

		/// <summary>
		/// The person's hometown 
		/// </summary>
		public FacebookPage hometown { get; set; }

		/// <summary>
		/// The person's inspirational people 
		/// </summary>
		public FacebookExperience[] inspirational_people { get; set; }

		/// <summary>
		/// Install type 
		/// </summary>
		public string install_type { get; set; }

		/// <summary>
		/// Is the app making the request installed? 
		/// </summary>
		public string installed { get; set; }

		/// <summary>
		/// Genders the person is interested in 
		/// </summary>
		public string[] interested_in { get; set; }

		/// <summary>
		/// Is this a shared login (e.g. a gray user) 
		/// </summary>
		public string is_shared_login { get; set; }

		/// <summary>
		/// People with large numbers of followers can have the authenticity of their identity manually verified by Facebook. 
		/// This field indicates whether the person's profile is verified in this way. This is distinct from the verified field 
		/// </summary>
		public string is_verified { get; set; }

		/// <summary>
		/// A link to the person's Timeline 
		/// </summary>
		public string link { get; set; }

		/// <summary>
		/// Facebook Pages representing the languages this person knows 
		/// </summary>
		public FacebookExperience[] languages { get; set; }

		/// <summary>
		/// The person's last name 
		/// </summary>
		public string last_name { get; set; }

		/// <summary>
		/// The person's locale 
		/// </summary>
		public string locale { get; set; }

		/// <summary>
		/// Location node used with other objects in the Graph API. 
		/// </summary>
		/// <value>The location.</value>
		public FacebookPage location { get; set; }

		/// <summary>
		/// What the person is interested in meeting for 
		/// </summary>
		public string[] meeting_for { get; set; }

		/// <summary>
		/// The person's middle name 
		/// </summary>
		public string middle_name { get; set; }

		/// <summary>
		/// The person's full name 
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// The person's name formatted to correctly handle Chinese, Japanese, or Korean ordering 
		/// </summary>
		public string name_format { get; set; }

		/// <summary>
		/// The person's payment pricepoints 
		/// </summary>
		public FacebookPaymentPricepoints payment_pricepoints { get; set; }

		/// <summary>
		/// The person's political views 
		/// </summary>
		public string political { get; set; }

		/// <summary>
		/// The person's PGP public key 
		/// </summary>
		public string public_key { get; set; }

		/// <summary>
		/// The person's favorite quotes 
		/// </summary>
		public string quotes { get; set; }

		/// <summary>
		/// The person's relationship status 
		/// </summary>
		public string relationship_status { get; set; }

		/// <summary>
		/// The person's religion 
		/// </summary>
		public string religion { get; set; }

		/// <summary>
		/// Security settings 
		/// </summary>
		public FacebookSecuritySettings security_settings { get; set; }

		/// <summary>
		/// The time that the shared loginneeds to be upgraded to Business Manager by
		/// if date is {01.01.0001 0:00:00} then date is not received from server 
		/// </summary>
		public DateTime shared_login_upgrade_required_by { get; set; }

		/// <summary>
		/// Shortened, locale-aware name for the person 
		/// </summary>
		public string short_name { get; set; }

		/// <summary>
		/// The person's significant other 
		/// </summary>
		public FacebookUser significant_other { get; set; }

		/// <summary>
		/// Sports played by the person 
		/// </summary>
		public FacebookExperience sports { get; set; }

		/// <summary>
		/// Platform test group 
		/// </summary>
		public Int32 test_group { get; set; }

		/// <summary>
		/// A string containing an anonymous, but unique identifier for the person. You can use this identifier with third parties 
		/// </summary>
		public string third_party_id { get; set; }

		/// <summary>
		/// The person's current timezone offset from UTC
		/// Type: float (min: -24) (max: 24) 
		/// </summary>
		public Single timezone { get; set; }

		/// <summary>
		/// Updated time
		/// if date is {01.01.0001 0:00:00} then date is not received from server 
		/// </summary>
		public DateTime updated_time { get; set; }

		/// <summary>
		/// Latest user ref that matches a given PSID that should be invalidated. 
		/// This should only be used for anonymous messaging PSID migration 
		/// </summary>
		public string user_ref { get; set; }

		/// <summary>
		/// Indicates whether the account has been verified. This is distinct from the is_verified field.
		///  Someone is considered verified if they take any of the following actions:
		/// * Register for mobile
		/// * Confirm their account via SMS
		/// * Enter a valid credit card 
		/// </summary>
		public string verified { get; set; }

		/// <summary>
		/// Video upload limits 
		/// </summary>
		public FacebookVideoUploadLimits video_upload_limits { get; set; }

		/// <summary>
		/// Can the viewer send a gift to this person? 
		/// </summary>
		public string viewer_can_send_gift { get; set; }

		/// <summary>
		/// The person's website 
		/// </summary>
		public string website { get; set; }

		/// <summary>
		/// Details of a person`s work experience 
		/// </summary>
		public FacebookWorkExperience[] work { get; set; }

		/// <summary>
		/// A person's friends. 
		/// </summary>
		public FacebookUserFriends friends { get; set; }

	}

	///<summary>
	/// The feed of posts 
	/// </summary>
	public class FacebookFeedResponse
	{
		/// <summary>
		/// The newly created post ID 
		/// </summary>
		public string id { get; set; }

	}

}