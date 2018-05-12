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
		public string Auth(string bNesisDevId,string clientId,string clientSecret,string redirectUrl,string[] scopes)
		{
			bNesisToken = bNesisApi.Auth("Facebook", string.Empty,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,string.Empty,string.Empty,false,string.Empty);
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
		/// The curated collections created by this user
		/// https://developers.facebook.com/docs/graph-api/reference/user/curated_collections/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The curated collections created by this user</returns>
		public FacebookUserCuratedCollections GetUserCuratedCollections(string id)
		{
			return bNesisApi.Call<FacebookUserCuratedCollections>("Facebook", bNesisToken, "GetUserCuratedCollections", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/custom_labels/
		/// Permissions
		/// Developers usually request these permissions for this endpoint:
		/// Marketing Apps
		/// No data
		/// Page management Apps
		/// manage_pages
		/// pages_show_list
		/// pages_messaging
		/// Other Apps
		/// No data 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>custom labels</returns>
		public FacebookUserCustomLabels GetUserCustomLabels(string id)
		{
			return bNesisApi.Call<FacebookUserCustomLabels>("Facebook", bNesisToken, "GetUserCustomLabels", id);
		}

		///<summary>
		/// The domains the user admins
		/// https://developers.facebook.com/docs/graph-api/reference/user/domains/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The domains the user admins</returns>
		public FacebookUserDomains GetUserDomains(string id)
		{
			return bNesisApi.Call<FacebookUserDomains>("Facebook", bNesisToken, "GetUserDomains", id);
		}

		///<summary>
		/// Events for this person. By default this does not include events the person has declined or not replied to
		/// https://developers.facebook.com/docs/graph-api/reference/user/events/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Events for this person.By default this does not include events the person has declined or not replied to</returns>
		public FacebookUserEvents GetUserEvents(string id)
		{
			return bNesisApi.Call<FacebookUserEvents>("Facebook", bNesisToken, "GetUserEvents", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>This person's family relationships.</returns>
		public FacebookUserFamily GetUserFamily(string id)
		{
			return bNesisApi.Call<FacebookUserFamily>("Facebook", bNesisToken, "GetUserFamily", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Developers' favorite requests to the Graph API</returns>
		public FacebookUserFavoriteRequests GetUserFavoriteRequests(string id)
		{
			return bNesisApi.Call<FacebookUserFavoriteRequests>("Facebook", bNesisToken, "GetUserFavoriteRequests", id);
		}

		///<summary>
		/// A person's custom friend lists.
		/// https://developers.facebook.com/docs/graph-api/reference/user/friendlists/ 
		/// </summary>
		/// <param name="id"></param>
		/// <returns>A person's custom friend lists.</returns>
		public FacebookUserFriendlists GetUserFriendlists(string id)
		{
			return bNesisApi.Call<FacebookUserFriendlists>("Facebook", bNesisToken, "GetUserFriendlists", id);
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
		public FacebookUserFriends GetFieldUserFriends(string id, string field)
		{
			return bNesisApi.Call<FacebookUserFriends>("Facebook", bNesisToken, "GetFieldUserFriends", id, field);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/
		/// Permission 
		/// user_likes 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Games this person likes</returns>
		public FacebookUserGames GetUserGames(string id)
		{
			return bNesisApi.Call<FacebookUserGames>("Facebook", bNesisToken, "GetUserGames", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/
		/// Permission
		/// user_managed_groups 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The Facebook Groups of which the person is an Admin.</returns>
		public FacebookUserGroups GetUserGroups(string id)
		{
			return bNesisApi.Call<FacebookUserGroups>("Facebook", bNesisToken, "GetUserGroups", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Businesses can claim ownership of multiple apps using Business Manager. 
		/// This edge returns the list of IDs that this user has in any of those other apps</returns>
		public FacebookUserIDsForBusiness GetUserIdsForBusiness(string id)
		{
			return bNesisApi.Call<FacebookUserIDsForBusiness>("Facebook", bNesisToken, "GetUserIdsForBusiness", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/
		/// Permission:
		/// ads_read 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>A list of lead generation forms belonging to Pages that the user has advertiser permissions on</returns>
		public FacebookUserLeadgenForms GetUserLeadgenForms(string id)
		{
			return bNesisApi.Call<FacebookUserLeadgenForms>("Facebook", bNesisToken, "GetUserLeadgenForms", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/
		/// Permission
		/// user_likes 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>All the Pages this person has liked</returns>
		public FacebookUserLikes GetUserLikes(string id)
		{
			return bNesisApi.Call<FacebookUserLikes>("Facebook", bNesisToken, "GetUserLikes", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Live encoders owned by this person</returns>
		public FacebookUserLiveEncoders GetUserLiveEncoders(string id)
		{
			return bNesisApi.Call<FacebookUserLiveEncoders>("Facebook", bNesisToken, "GetUserLiveEncoders", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Live videos from this person</returns>
		public FacebookUserLiveVideos GetUserLiveVideos(string id)
		{
			return bNesisApi.Call<FacebookUserLiveVideos>("Facebook", bNesisToken, "GetUserLiveVideos", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/
		/// Permission: user_likes 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Movies this person likes</returns>
		public FacebookUserMovies GetUserMovies(string id)
		{
			return bNesisApi.Call<FacebookUserMovies>("Facebook", bNesisToken, "GetUserMovies", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/
		/// Permission: user_likes 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Music this person likes</returns>
		public FacebookUserMusic GetUserMusic(string id)
		{
			return bNesisApi.Call<FacebookUserMusic>("Facebook", bNesisToken, "GetUserMusic", id);
		}

		///<summary>
		/// Gets the user permissions.
		/// https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>a list of granted and declined permissions.</returns>
		public FacebookUserPermissions GetUserPremissions(string id)
		{
			return bNesisApi.Call<FacebookUserPermissions>("Facebook", bNesisToken, "GetUserPremissions", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/
		/// Permission: user_photos 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Photos the person is tagged in or has uploaded</returns>
		public FacebookUserPhotos GetUserPhotos(string id)
		{
			return bNesisApi.Call<FacebookUserPhotos>("Facebook", bNesisToken, "GetUserPhotos", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The person's profile picture</returns>
		public FacebookUserPicture GetUserPicture(string id)
		{
			return bNesisApi.Call<FacebookUserPicture>("Facebook", bNesisToken, "GetUserPicture", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Developers' Graph API request history</returns>
		public FacebookUserRequestHistory GetUserRequestHistory(string id)
		{
			return bNesisApi.Call<FacebookUserRequestHistory>("Facebook", bNesisToken, "GetUserRequestHistory", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>A list of rich media documents belonging to Pages that the user has advertiser permissions on</returns>
		public FacebookUserRichMediaDocuments GetUserRichMediaDocuments(string id)
		{
			return bNesisApi.Call<FacebookUserRichMediaDocuments>("Facebook", bNesisToken, "GetUserRichMediaDocuments", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Any session keys that the app knows the user by</returns>
		public FacebookUserSessionKeys GetUserSessionKeys(string id)
		{
			return bNesisApi.Call<FacebookUserSessionKeys>("Facebook", bNesisToken, "GetUserSessionKeys", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>A list of filters that can be applied to the News Feed edge</returns>
		public FacebookUserStreamFilters GetUserStreamFilters(string id)
		{
			return bNesisApi.Call<FacebookUserStreamFilters>("Facebook", bNesisToken, "GetUserStreamFilters", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/
		/// Permission user_friends 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Friends that can be tagged in content published via the Graph API</returns>
		public FacebookUserTaggableFriends GetUserTaggableFriends(string id)
		{
			return bNesisApi.Call<FacebookUserTaggableFriends>("Facebook", bNesisToken, "GetUserTaggableFriends", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/
		/// Permission user_tagged_places 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>List of tagged places for this person. It can include tags on videos, posts, statuses or links</returns>
		public FacebookUserTaggedPlaces GetUserTaggedPlaces(string id)
		{
			return bNesisApi.Call<FacebookUserTaggedPlaces>("Facebook", bNesisToken, "GetUserTaggedPlaces", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/
		/// Permission user_likes 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>TV shows this person likes</returns>
		public FacebookUserTelevision GetUserTelevision(string id)
		{
			return bNesisApi.Call<FacebookUserTelevision>("Facebook", bNesisToken, "GetUserTelevision", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Video broadcasts from this person</returns>
		public FacebookUserVideoBroadcasts GetUserVideoBroadcasts(string id)
		{
			return bNesisApi.Call<FacebookUserVideoBroadcasts>("Facebook", bNesisToken, "GetUserVideoBroadcasts", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/
		/// Permission user_videos 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Videos the person is tagged in or uploaded</returns>
		public FacebookUserVideos GetUserVideos(string id)
		{
			return bNesisApi.Call<FacebookUserVideos>("Facebook", bNesisToken, "GetUserVideos", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/v2.12/user/feed
		/// Permission user_posts 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The feed of posts (including status updates) and links published by this person.</returns>
		public FacebookFeed GetUserFeed(string id)
		{
			return bNesisApi.Call<FacebookFeed>("Facebook", bNesisToken, "GetUserFeed", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/v2.12/user/feed
		/// Requires either publish_actions permission, or manage_pages and publish_pages as an admin with sufficient administrative permission" 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <param name="message">The main body of the post, otherwise called the status message.
		/// Either link, place, or message must be supplied.</param>
		/// <param name="link">The URL of a link to attach to the post.
		/// Either link, place, or message must be supplied. Additional fields associated with link are shown below.</param>
		/// <returns>The feed of posts (including status updates) and links published by this person.</returns>
		public FacebookPost PostUserFeed(string id, string message, string link)
		{
			return bNesisApi.Call<FacebookPost>("Facebook", bNesisToken, "PostUserFeed", id, message, link);
		}

		///<summary>
		/// Page Access Tokens 
		/// </summary>
		/// <param name="id"></param>
		/// <returns>a list of pages that the person administers along with other information about the Page,
		/// such as the Page category, the permissions the admin has for that Page, and the page access token.
		/// Permissions
		/// A Page access token for a User with a role(other than Live Contributor) on the Page and the following permissions:
		/// manage_pages or pages_show_list</returns>
		public FacebookUserAccounts GetPageAccessToken(string id)
		{
			return bNesisApi.Call<FacebookUserAccounts>("Facebook", bNesisToken, "GetPageAccessToken", id);
		}

		///<summary>
		/// Generates an App Access Token 
		/// </summary>
		/// <returns>app Access Token</returns>
		public FacebookAppToken GetAppAccessToken()
		{
			return bNesisApi.Call<FacebookAppToken>("Facebook", bNesisToken, "GetAppAccessToken");
		}

		///<summary>
		/// Checks the token in the service. 
		/// </summary>
		/// <returns>data with information about the token</returns>
		public FacebookDebug ValidationToken()
		{
			return bNesisApi.Call<FacebookDebug>("Facebook", bNesisToken, "ValidationToken");
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
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/accounts/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Pages this User has a role on.</returns>
		public FacebookUserAccounts GetUserAccounts(string id)
		{
			return bNesisApi.Call<FacebookUserAccounts>("Facebook", bNesisToken, "GetUserAccounts", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/achievements/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Achievements made in Facebook games</returns>
		public FacebookUserAchievements GetUserAchievements(string id)
		{
			return bNesisApi.Call<FacebookUserAchievements>("Facebook", bNesisToken, "GetUserAchievements", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Ad studies that this person can view</returns>
		public FacebookUserAdStudies GetUserAdStudies(string id)
		{
			return bNesisApi.Call<FacebookUserAdStudies>("Facebook", bNesisToken, "GetUserAdStudies", id);
		}

		///<summary>
		/// The advertising accounts to which this person has access.
		/// https://developers.facebook.com/docs/graph-api/reference/user/adaccounts/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The advertising accounts to which this person has access</returns>
		public FacebookUserAdaccounts GetUserAdAccounts(string id)
		{
			return bNesisApi.Call<FacebookUserAdaccounts>("Facebook", bNesisToken, "GetUserAdAccounts", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/user/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Insights data for the person's Audience Network apps</returns>
		public FacebookUserAdnetworkanalytics GetUserAdNetWorkanalytics(string id)
		{
			return bNesisApi.Call<FacebookUserAdnetworkanalytics>("Facebook", bNesisToken, "GetUserAdNetWorkanalytics", id);
		}

		///<summary>
		/// Represents current person on Facebook.
		/// https://developers.facebook.com/docs/graph-api/reference/v2.12/album 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The photo albums this person has created</returns>
		public FacebookUserAlbums GetUserAlbums(string id)
		{
			return bNesisApi.Call<FacebookUserAlbums>("Facebook", bNesisToken, "GetUserAlbums", id);
		}

		///<summary>
		/// App requests
		/// https://developers.facebook.com/docs/graph-api/reference/user/apprequestformerrecipients/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>App requests</returns>
		public FacebookApprequestformerrecipients GetUserApprequestForMerrecipients(string id)
		{
			return bNesisApi.Call<FacebookApprequestformerrecipients>("Facebook", bNesisToken, "GetUserApprequestForMerrecipients", id);
		}

		///<summary>
		/// This person's pending requests from an app
		/// https://developers.facebook.com/docs/graph-api/reference/user/apprequests/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>This person's pending requests from an app</returns>
		public FacebookUserApprequests GetUserAppRequests(string id)
		{
			return bNesisApi.Call<FacebookUserApprequests>("Facebook", bNesisToken, "GetUserAppRequests", id);
		}

		///<summary>
		/// The 3D assets owned by the user
		/// https://developers.facebook.com/docs/graph-api/reference/user/asset3ds/ 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The 3D assets owned by the user</returns>
		public FacebookUserAsset3ds GetUserAsset3Ds(string id)
		{
			return bNesisApi.Call<FacebookUserAsset3ds>("Facebook", bNesisToken, "GetUserAsset3Ds", id);
		}

		///<summary>
		/// The books listed on this person's profile
		/// https://developers.facebook.com/docs/graph-api/reference/user/books/
		/// Permissions
		/// Developers usually request these permissions for this endpoint:
		/// Marketing Apps
		/// No data
		/// Page management Apps
		/// No data
		/// Other Apps
		/// user_likes 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>The books listed on this person's profile</returns>
		public FacebookUserBooks GetUserBooks(string id)
		{
			return bNesisApi.Call<FacebookUserBooks>("Facebook", bNesisToken, "GetUserBooks", id);
		}

		///<summary>
		/// Business users corresponding to the user
		/// https://developers.facebook.com/docs/graph-api/reference/user/business_users/
		/// Permission business_management 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Business users corresponding to the user</returns>
		public FacebookUserBusinessUsers GetUserBusinessUsers(string id)
		{
			return bNesisApi.Call<FacebookUserBusinessUsers>("Facebook", bNesisToken, "GetUserBusinessUsers", id);
		}

		///<summary>
		/// Businesses associated with the user
		/// https://developers.facebook.com/docs/graph-api/reference/user/businesses/
		/// Permissions
		/// Developers usually request these permissions for this endpoint:
		/// Marketing Apps
		/// ads_management
		/// ads_read
		/// manage_pages
		/// business_management
		/// Page management Apps
		/// No data
		/// Other Apps
		/// No data 
		/// </summary>
		/// <param name="id">The identifier. "me" - current user</param>
		/// <returns>Businesses associated with the user</returns>
		public FacebookUserBusinesses GetUserBusinesses(string id)
		{
			return bNesisApi.Call<FacebookUserBusinesses>("Facebook", bNesisToken, "GetUserBusinesses", id);
		}
}
	///<summary>
	/// A Facebook page
	///     https://developers.facebook.com/docs/graph-api/reference/page/
	///     Permissions:
	///     For pages that are published, you need:
	///     An App or User access token to view fields from fully public pages.
	///     A User access token to view fields from restricted pages that this person is able to view (such as those restrict to certain demographics like location or age, or those only viewable by Page admins).
	///     A Page access token can also be used to view those restricted fields. A Page access token is required to view any User information for any objects owned by a Page.
	///     You need to be the Admin of the root page for child pages in order to read the global_brand_children edge for a page.
	///     For pages that are not published, you need:
	///     To have the Admin role for the page
	///     A Page access token 
	/// </summary>
	public class FacebookPage
	{
		/// <summary>
		/// Page ID. No access token is required to access this field 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The Page's access token. Only returned if the User making the request has a role (other than Live Contributor) on the Page.
		/// If your business requires two-factor authentication, the User must also be authenticated. 
		/// </summary>
		public string access_token { get; set; }

		/// <summary>
		/// The Business associated with this Page. Visible only with a page access token or a user access token that has admin rights on the page. 
		/// </summary>
		public FacebookPage business { get; set; }

		/// <summary>
		/// The Page's category. e.g. Product/Service, Computers/Technology 
		/// </summary>
		public string category { get; set; }

		/// <summary>
		/// Time the object liked the page 
		/// </summary>
		public DateTime created_time { get; set; }

		/// <summary>
		/// The name of the Page 
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// Gets or sets the perms. 
		/// </summary>
		public string[] perms { get; set; }

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
	///      https://developers.facebook.com/docs/graph-api/using-graph-api/#paging 
	/// </summary>
	public class FacebookPaging
	{
		/// <summary>
		/// Gets or sets the cursors. 
		/// </summary>
		public FacebookCursors cursors { get; set; }

		/// <summary>
		/// The Graph API endpoint that will return the previous page of data. If not included, this is the first page of data. 
		/// </summary>
		public string previous { get; set; }

		/// <summary>
		/// The Graph API endpoint that will return the next page of data. 
		/// If not included, this is the last page of data. 
		/// Due to how pagination works with visibility and privacy, it is possible that a page may be empty but contain a 'next' paging link. 
		/// Stop paging when the 'next' link no longer appears. 
		/// </summary>
		public string next { get; set; }

	}

	///<summary>
	/// The curated collections created by this user.
	///     https://developers.facebook.com/docs/graph-api/reference/user/curated_collections/ 
	/// </summary>
	public class FacebookUserCuratedCollections
	{
		/// <summary>
		/// A list of CuratedCollection nodes. 
		/// </summary>
		public FacebookPage[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

	}

	///<summary>
	/// https://developers.facebook.com/docs/graph-api/reference/user/custom_labels/
	///     Permissions
	///     Developers usually request these permissions for this endpoint:
	///     Marketing Apps
	///     No data
	///     Page management Apps
	///     manage_pages
	///     pages_show_list
	///     pages_messaging
	///     Other Apps
	///     No data 
	/// </summary>
	public class FacebookUserCustomLabels
	{
		/// <summary>
		/// A list of PageUserMessageThreadLabel nodes. 
		/// </summary>
		public FacebookPage[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

	}

	///<summary>
	/// https://developers.facebook.com/docs/graph-api/reference/v2.12/domain 
	/// </summary>
	public class FacebookDomain
	{
		/// <summary>
		/// The ID of the domain. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The name of the domain. 
		/// </summary>
		public string name { get; set; }

	}

	///<summary>
	/// The domains the user admins
	///     https://developers.facebook.com/docs/graph-api/reference/user/domains/ 
	/// </summary>
	public class FacebookUserDomains
	{
		/// <summary>
		/// A list of Domain nodes. 
		/// </summary>
		public FacebookDomain[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

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
	/// A place
	///      https://developers.facebook.com/docs/graph-api/reference/place/ 
	/// </summary>
	public class FacebookPlace
	{
		/// <summary>
		/// ID 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// Location of Place 
		/// </summary>
		public FacebookLocation location { get; set; }

		/// <summary>
		/// Name 
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// Overall Rating of Place, on a 5-star scale. 0 means not enough data to get a combined rating. 
		/// </summary>
		public Single overall_rating { get; set; }

	}

	///<summary>
	/// Represents a Facebook event. The /{event-id} node returns a single event.
	///     https://developers.facebook.com/docs/graph-api/reference/event/
	///     Permissions
	///     Any access token can be used to retrieve events with privacy set to OPEN.
	///     A user access token with user_events permission can be used to retrieve any events that are visible to that person.
	///     An app or page token can be used to retrieve any events that were created by that app or page.
	///     Login Review: user_events
	///     To use the user_events permission you need to submit your app for review. 
	/// </summary>
	public class FacebookEvent
	{
		/// <summary>
		/// The event ID 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The category of the event 
		/// </summary>
		public string category { get; set; }

		/// <summary>
		/// Long-form description 
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// Event name 
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// Event Place information. 
		/// </summary>
		public FacebookPlace place { get; set; }

		/// <summary>
		/// Start time 
		/// </summary>
		public string start_time { get; set; }

		/// <summary>
		/// Gets or sets the RSVP status. 
		/// </summary>
		public string rsvp_status { get; set; }

	}

	///<summary>
	/// Events for this person. By default this does not include events the person has declined or not replied to
	///     https://developers.facebook.com/docs/graph-api/reference/user/events/
	///     Permissions
	///     Developers usually request these permissions for this endpoint:
	///     Marketing Apps
	///     No data
	///     Page management Apps
	///     manage_pages
	///     pages_show_list
	///     user_events
	///     Other Apps
	///     user_events 
	/// </summary>
	public class FacebookUserEvents
	{
		/// <summary>
		/// A list of Event nodes. 
		/// </summary>
		public FacebookEvent[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

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
		public FacebookPage[] data { get; set; }

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
		public FacebookPage[] data { get; set; }

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
		public FacebookPage[] data { get; set; }

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
		public FacebookPage[] data { get; set; }

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
	/// Accounts for a Facebook User. 
	///     Pages this User has a role on.
	///      https://developers.facebook.com/docs/graph-api/reference/user/accounts/
	///      A Page access token for a User with a role (other than Live Contributor) on the Page and the following permissions:
	///      manage_pages or pages_show_list 
	/// </summary>
	public class FacebookUserAccounts
	{
		/// <summary>
		/// A list of Page nodes. 
		/// </summary>
		public FacebookPage[] data { get; set; }

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
	/// An Open Graph object
	///     https://developers.facebook.com/docs/graph-api/reference/open-graph-object--generic/ 
	/// </summary>
	public class FacebookOGOGeneric
	{
		/// <summary>
		/// The Open Graph object ID 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The time the object was created 
		/// </summary>
		public DateTime created_time { get; set; }

		/// <summary>
		/// A short description of the object 
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// The word that appears before the object's title 
		/// </summary>
		public string determiner { get; set; }

		/// <summary>
		/// Whether the object has been scraped
		/// Type: bool 
		/// </summary>
		public string is_scraped { get; set; }

		/// <summary>
		/// The location inherited from Place 
		/// </summary>
		public FacebookLocation location { get; set; }

		/// <summary>
		/// The action ID that created this object 
		/// </summary>
		public string post_action_id { get; set; }

		/// <summary>
		/// An array of URLs of related resources 
		/// </summary>
		public string[] see_also { get; set; }

		/// <summary>
		/// The name of the web site upon which the object resides 
		/// </summary>
		public string site_name { get; set; }

		/// <summary>
		/// The title of the object as it should appear in the graph 
		/// </summary>
		public string title { get; set; }

		/// <summary>
		/// The type of the object 
		/// </summary>
		public string type { get; set; }

		/// <summary>
		/// The last time the object was updated 
		/// </summary>
		public DateTime updated_time { get; set; }

	}

	///<summary>
	/// Open graph actions taken by the user 
	/// </summary>
	public class FacebookUserAchievements
	{
		/// <summary>
		/// A list of OpenGraphAction:generic nodes. 
		/// </summary>
		public FacebookOGOGeneric[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

	}

	///<summary>
	/// A lift study object
	///     https://developers.facebook.com/docs/marketing-api/reference/ad-study/ 
	/// </summary>
	public class FacebookAdStudy
	{
		/// <summary>
		/// Time stamp when study was canceled 
		/// </summary>
		public DateTime canceled_time { get; set; }

		/// <summary>
		/// Who Lift study was created by 
		/// </summary>
		public FacebookUser created_by { get; set; }

		/// <summary>
		/// The time the object was created 
		/// </summary>
		public DateTime created_time { get; set; }

		/// <summary>
		/// Description 
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// End time 
		/// </summary>
		public DateTime end_time { get; set; }

		/// <summary>
		/// ID of the Lift study 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// Cooldown start time 
		/// </summary>
		public DateTime cooldown_start_time { get; set; }

		/// <summary>
		/// Name of the Lift study 
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// Observation end time 
		/// </summary>
		public DateTime observation_end_time { get; set; }

		/// <summary>
		/// Start time 
		/// </summary>
		public DateTime start_time { get; set; }

		/// <summary>
		/// The type of study, either audience segmentation or lift 
		/// </summary>
		public string type { get; set; }

		/// <summary>
		/// Updated by 
		/// </summary>
		public FacebookUser updated_by { get; set; }

		/// <summary>
		/// Updated time 
		/// </summary>
		public DateTime updated_time { get; set; }

	}

	///<summary>
	/// Ad studies that this person can view 
	///      https://developers.facebook.com/docs/graph-api/reference/user/ad_studies/ 
	/// </summary>
	public class FacebookUserAdStudies
	{
		/// <summary>
		/// A list of AdStudy nodes 
		/// </summary>
		public FacebookAdStudy[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide 
		/// </summary>
		public FacebookPaging paging { get; set; }

		/// <summary>
		/// Aggregated information about the edge, such as counts. 
		/// Specify the fields to fetch in the summary param (like summary=total_count). 
		/// </summary>
		public FacebookPaging summary { get; set; }

	}

	///<summary>
	/// Represents a business, person or other entity who creates and manage ads on Facebook. 
	///     Multiple people can manage an account, and each person can have one or more levels of access to an account, by specifying roles, see Ad User. 
	///     Permissions
	///     Developers usually request these permissions for this endpoint:
	///     Marketing Apps
	///     ads_read 
	/// </summary>
	public class FacebookAdAccount
	{
		/// <summary>
		/// The string act_{ad_account_id} 
		/// </summary>
		public string account_id { get; set; }

		/// <summary>
		/// The ID of the ad account 
		/// </summary>
		public string id { get; set; }

	}

	///<summary>
	/// The advertising accounts to which this person has access.
	///      Developers usually request these permissions for this endpoint:
	///      Marketing Apps ads_management. 
	/// </summary>
	public class FacebookUserAdaccounts
	{
		/// <summary>
		/// A list of AdAccount nodes. 
		/// </summary>
		public FacebookAdAccount[] data { get; set; }

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
	/// Results from an insights query. Please see our documentation on the app_insights edge for more information. 
	///     Data of Insights Query
	///     https://developers.facebook.com/docs/graph-api/reference/insights-query-result/ 
	/// </summary>
	public class FacebookInsightsQueryResult
	{
		/// <summary>
		/// Gets or sets the time. 
		/// </summary>
		public DateTime time { get; set; }

		/// <summary>
		/// Gets or sets the value. 
		/// </summary>
		public string value { get; set; }

	}

	///<summary>
	/// Insights for all of this user's Audience Network apps. 
	/// </summary>
	public class FacebookUserAdnetworkanalytics
	{
		/// <summary>
		/// A list of InsightsQueryResult nodes 
		/// </summary>
		public FacebookInsightsQueryResult[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

	}

	///<summary>
	/// Image source and dimensions 
	/// </summary>
	public class FacebookPlatformImageSource
	{
		/// <summary>
		/// Height of the image. 
		/// </summary>
		public Int32 height { get; set; }

		/// <summary>
		/// URI of the image. 
		/// </summary>
		public string source { get; set; }

		/// <summary>
		/// Width of the image 
		/// </summary>
		public Int32 width { get; set; }

	}

	///<summary>
	/// All the Pages this person has liked
	///     https://developers.facebook.com/docs/graph-api/reference/user/likes/
	///     Permissions
	///     Developers usually request these permissions for this endpoint:
	///     Marketing Apps
	///     No data
	///     Page management Apps
	///     No data
	///     Other Apps
	///     user_likes 
	/// </summary>
	public class FacebookUserLikes
	{
		/// <summary>
		/// A list of Page nodes. 
		/// </summary>
		public FacebookPage[] data { get; set; }

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
	/// A comment can be made on various types of content on Facebook. 
	///     Most Graph API nodes have a /comments edge that lists all the comments on that object. 
	///     The /{comment-id} node returns a single comment. 
	/// </summary>
	public class FacebookComment
	{
		/// <summary>
		/// The comment ID 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The time this comment was made 
		/// </summary>
		public DateTime created_time { get; set; }

		/// <summary>
		/// The person that made this comment 
		/// </summary>
		public FacebookUser from { get; set; }

		/// <summary>
		/// The comment text. 
		/// </summary>
		public string message { get; set; }

		/// <summary>
		/// Whether the viewer has liked this comment. 
		/// </summary>
		public string user_likes { get; set; }

	}

	///<summary>
	/// This reference describes the /comments edge that is common to multiple Graph API nodes. 
	/// </summary>
	public class FacebookComments
	{
		/// <summary>
		/// The data. 
		/// </summary>
		public FacebookComment[] data { get; set; }

		/// <summary>
		/// Paging. 
		/// </summary>
		public FacebookPaging paging { get; set; }

	}

	///<summary>
	/// Represents an individual photo on Facebook.
	///     https://developers.facebook.com/docs/graph-api/reference/photo
	///     Permissions
	///     Any valid access token can read photos on a public Page.
	///     A page access token can read all photos posted to or posted by that Page.
	///     A user access token can read any photo your application created on behalf of that user.
	///     A user's photos can be read if the owner has granted the user_photos or user_posts permission.
	///     A user access token may read a photo that user is tagged in if they have granted the user_photos or user_posts permission. However, in some cases the photo's owner's privacy settings may not allow your application to access it.
	///     A User access token for an Admin of a Group can read Group-owned Photos.
	///     A User access token for an Admin of an Event can read Event-owned Photos. 
	/// </summary>
	public class FacebookPhoto
	{
		/// <summary>
		/// The photo ID 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The album this photo is in 
		/// </summary>
		public FacebookAlbum album { get; set; }

		/// <summary>
		/// The time this photo was published. 
		/// </summary>
		public DateTime created_time { get; set; }

		/// <summary>
		/// If this object has a place, the event associated with the place. 
		/// </summary>
		public FacebookEvent event_ { get; set; }

		/// <summary>
		/// The icon that Facebook displays when photos are published to News Feed 
		/// </summary>
		public string icon { get; set; }

		/// <summary>
		/// The different stored representations of the photo. Can vary in number based upon the size of the original photo. 
		/// </summary>
		public FacebookPlatformImageSource[] images { get; set; }

		/// <summary>
		/// A link to the photo on Facebook. 
		/// </summary>
		public string link { get; set; }

		/// <summary>
		/// The user-provided caption given to this photo. Corresponds to caption when creating photos 
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// Link to the 100px wide representation of this photo 
		/// </summary>
		public string picture { get; set; }

		/// <summary>
		/// Gets or sets the place. 
		/// </summary>
		public FacebookPlace place { get; set; }

		/// <summary>
		/// The last time the photo was updated 
		/// </summary>
		public DateTime updated_time { get; set; }

		/// <summary>
		/// People who like this 
		/// </summary>
		public FacebookUserLikes likes { get; set; }

		/// <summary>
		/// Comments on an object 
		/// </summary>
		public FacebookComments comments { get; set; }

	}

	///<summary>
	/// Album
	///     https://developers.facebook.com/docs/graph-api/reference/v2.12/album 
	/// </summary>
	public class FacebookAlbum
	{
		/// <summary>
		/// The album ID 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// Whether the viewer can upload photos to this album
		/// Type: bool 
		/// </summary>
		public string can_upload { get; set; }

		/// <summary>
		/// The approximate number of photos in the album. This is not necessarily an exact count 
		/// </summary>
		public Int32 count { get; set; }

		/// <summary>
		/// The ID of the album's cover photo. 
		/// </summary>
		public FacebookPhoto cover_photo { get; set; }

		/// <summary>
		/// The time the album was initially created. 
		/// </summary>
		public DateTime created_time { get; set; }

		/// <summary>
		/// The description of the album. 
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// The event associated with this album. 
		/// </summary>
		public FacebookEvent event_ { get; set; }

		/// <summary>
		/// The profile that created the album. 
		/// </summary>
		public FacebookUser from { get; set; }

		/// <summary>
		/// A link to this album on Facebook. 
		/// </summary>
		public string link { get; set; }

		/// <summary>
		/// The textual location of the album. 
		/// </summary>
		public string location { get; set; }

		/// <summary>
		/// The title of the album. 
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// The place associated with this album. 
		/// </summary>
		public FacebookPage place { get; set; }

		/// <summary>
		/// The privacy settings for the album. 
		/// </summary>
		public string privacy { get; set; }

		/// <summary>
		/// The type of the album. 
		/// </summary>
		public string type { get; set; }

		/// <summary>
		/// The last time the album was updated. 
		/// </summary>
		public DateTime updated_time { get; set; }

	}

	///<summary>
	/// Albums for a Facebook User
	///     https://developers.facebook.com/docs/graph-api/reference/user/albums/ 
	/// </summary>
	public class FacebookUserAlbums
	{
		/// <summary>
		/// A list of Album nodes 
		/// </summary>
		public FacebookAlbum[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide 
		/// </summary>
		public FacebookPaging paging { get; set; }

	}

	///<summary>
	/// Information about users that received app requests from the viewer in the past
	///     https://developers.facebook.com/docs/graph-api/reference/app-request-former-recipient/ 
	/// </summary>
	public class FacebookAppRequestFormerRecipient
	{
		/// <summary>
		/// Viewer ID 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// Recipient ID 
		/// </summary>
		public string recipient_id { get; set; }

	}

	///<summary>
	/// App requests
	///     Permissions
	///     Developers usually request these permissions for this endpoint:
	///     Marketing Apps
	///     No data
	///     Page management Apps
	///     No data
	///     Other Apps
	///     user_friends
	///     https://developers.facebook.com/docs/graph-api/reference/user/apprequestformerrecipients/ 
	/// </summary>
	public class FacebookApprequestformerrecipients
	{
		/// <summary>
		/// Gets or sets the data. 
		/// </summary>
		public FacebookAppRequestFormerRecipient[] data { get; set; }

		/// <summary>
		/// Gets or sets the paging. 
		/// </summary>
		public FacebookPaging paging { get; set; }

	}

	///<summary>
	/// An individual app request received by someone, sent by an app or another person
	///     https://developers.facebook.com/docs/graph-api/reference/app-request/ 
	/// </summary>
	public class FacebookAppRequest
	{
		/// <summary>
		/// The ID of an individual request 
		/// </summary>
		public string id { get; set; }

	}

	///<summary>
	/// This person's pending requests from an app 
	///      https://developers.facebook.com/docs/graph-api/reference/user/apprequests/ 
	/// </summary>
	public class FacebookUserApprequests
	{
		/// <summary>
		/// A list of AppRequest nodes. 
		/// </summary>
		public FacebookAppRequest[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

	}

	///<summary>
	/// Represents a 3D Asset. 
	/// </summary>
	public class FacebookWithAsset3D
	{
		/// <summary>
		/// The id of the object 
		/// </summary>
		public string id { get; set; }

	}

	///<summary>
	/// The 3D assets owned by this user.
	///     https://developers.facebook.com/docs/graph-api/reference/user/asset3ds/ 
	/// </summary>
	public class FacebookUserAsset3ds
	{
		/// <summary>
		/// A list of WithAsset3D nodes. 
		/// </summary>
		public FacebookWithAsset3D[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

	}

	///<summary>
	/// Books listed in someone's Facebook profile.
	///     https://developers.facebook.com/docs/graph-api/reference/user/books/ 
	///      Permissions
	///      Developers usually request these permissions for this endpoint:
	///      Marketing Apps
	///      No data
	///      Page management Apps
	///      No data
	///      Other Apps
	///      user_likes 
	/// </summary>
	public class FacebookUserBooks
	{
		/// <summary>
		/// Gets or sets the data. 
		/// </summary>
		public FacebookPage[] data { get; set; }

		/// <summary>
		/// Gets or sets the paging. 
		/// </summary>
		public FacebookPaging paging { get; set; }

		/// <summary>
		/// Gets or sets the summary. 
		/// </summary>
		public FacebookSummary summary { get; set; }

	}

	///<summary>
	/// Get business users that a personal user has.
	///     https://developers.facebook.com/docs/graph-api/reference/user/business_users/ 
	/// </summary>
	public class FacebookUserBusinessUsers
	{
		/// <summary>
		/// A list of BusinessUser nodes. 
		/// </summary>
		public FacebookPage[] data { get; set; }

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
	/// Businesses associated with the user
	///     https://developers.facebook.com/docs/graph-api/reference/user/businesses/
	///     Permissions
	///     Developers usually request these permissions for this endpoint:
	///     Marketing Apps
	///     ads_management
	///     ads_read
	///     manage_pages
	///     business_management
	///     Page management Apps
	///     No data
	///     Other Apps
	///     No data 
	/// </summary>
	public class FacebookUserBusinesses
	{
		/// <summary>
		/// A list of Business nodes. 
		/// </summary>
		public FacebookPage[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

	}

	///<summary>
	/// Developers' favorite requests to the Graph API
	///     https://developers.facebook.com/docs/graph-api/reference/user/favorite_requests/ 
	/// </summary>
	public class FacebookUserFavoriteRequests
	{
		/// <summary>
		/// A list of FavoriteRequest nodes. 
		/// </summary>
		public FacebookPage[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

	}

	///<summary>
	/// This represents a user's friend list on Facebook
	///     https://developers.facebook.com/docs/graph-api/reference/friend-list/
	///     Permissions
	///     A user access token with read_custom_friendlists permission is required. 
	/// </summary>
	public class FacebookFriendList
	{
		/// <summary>
		/// The friend list ID 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The type of the friend list 
		/// </summary>
		public string list_type { get; set; }

		/// <summary>
		/// The name of the friend list 
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// The owner of the friend list 
		/// </summary>
		public string owner { get; set; }

	}

	///<summary>
	/// A person's custom friend lists.
	///     https://developers.facebook.com/docs/graph-api/reference/user/friendlists/
	///     Permissions
	///     Developers usually request these permissions for this endpoint:
	///     Marketing Apps
	///     ads_management
	///     manage_pages
	///     pages_show_list
	///     read_custom_friendlists
	///     user_location
	///     user_education_history
	///     Page management Apps
	///     No data
	///     Other Apps
	///     read_custom_friendlists 
	/// </summary>
	public class FacebookUserFriendlists
	{
		/// <summary>
		/// A list of FriendList nodes. 
		/// </summary>
		public FacebookFriendList[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

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
	/// Games a person likes.
	///     https://developers.facebook.com/docs/graph-api/reference/user/games/
	///     Permission 
	///     user_likes 
	/// </summary>
	public class FacebookUserGames
	{
		/// <summary>
		/// A list of Page nodes. 
		/// </summary>
		public FacebookPage[] data { get; set; }

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
	/// A Group.
	///     Returns information about a single Group object. To get a list of Groups a User belongs to, use the /user/groups edge instead.
	///     Permissions
	///     For Public and Closed Groups
	///     A User access token.
	///     For Secret Groups
	///     A User access token for an Admin of the Group with the following permissions:
	///     user_managed_groups 
	/// </summary>
	public class FacebookGroup
	{
		/// <summary>
		/// The group ID 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// Information about the group's cover photo. 
		/// </summary>
		public FacebookCoverPhoto cover { get; set; }

		/// <summary>
		/// A brief description of the group. 
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// The email address to upload content to the group. Only current members of the group can use this. 
		/// </summary>
		public string email { get; set; }

	}

	///<summary>
	/// The Facebook Groups of which the person is an Admin.
	///     https://developers.facebook.com/docs/graph-api/reference/user/groups/
	///     Permissions
	///     Developers usually request these permissions for this endpoint:
	///     Marketing Apps
	///     manage_pages
	///     business_management
	///     user_managed_groups
	///     user_events
	///     user_photos
	///     Page management Apps
	///     manage_pages
	///     user_managed_groups
	///     user_events
	///     user_photos
	///     Other Apps
	///     user_managed_groups 
	/// </summary>
	public class FacebookUserGroups
	{
		/// <summary>
		/// A list of Group nodes. 
		/// </summary>
		public FacebookGroup[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

	}

	///<summary>
	/// A Facebook app.
	///     https://developers.facebook.com/docs/graph-api/reference/application/
	///     Permissions
	///     An app access token can be used to view all fields for an app. 
	/// </summary>
	public class FacebookApplication
	{
		/// <summary>
		/// The app ID 
		/// </summary>
		public string id { get; set; }

	}

	///<summary>
	/// A users's ID for an app 
	/// </summary>
	public class FacebookUserIdForApp
	{
		/// <summary>
		/// ID. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// App. 
		/// </summary>
		public FacebookApplication app { get; set; }

	}

	///<summary>
	/// The IDs that apps owned by the business know the user as
	///     https://developers.facebook.com/docs/graph-api/reference/user/ids_for_business/ 
	/// </summary>
	public class FacebookUserIDsForBusiness
	{
		/// <summary>
		/// A list of UserIDForApp nodes. 
		/// </summary>
		public FacebookUserIdForApp[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

	}

	///<summary>
	/// A list of lead generation forms belonging to Pages that the user has advertiser permissions on
	///     https://developers.facebook.com/docs/graph-api/reference/user/leadgen_forms/ 
	/// </summary>
	public class FacebookUserLeadgenForms
	{
		/// <summary>
		/// A list of LeadGenData nodes. 
		/// </summary>
		public FacebookPage[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

	}

	///<summary>
	/// An EntLiveEncoder is for the live encoders that can be associated withvideo broadcasts. This is part of the reference live encoder API.
	///     https://developers.facebook.com/docs/graph-api/reference/live-encoder/ 
	/// </summary>
	public class FacebookLiveEncoder
	{
		/// <summary>
		/// The id of the object 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The live encoder brand (eg: Wowza) 
		/// </summary>
		public string brand { get; set; }

		/// <summary>
		/// Creation time 
		/// </summary>
		public DateTime creation_time { get; set; }

	}

	///<summary>
	/// Live encoders owned by this person
	///     https://developers.facebook.com/docs/graph-api/reference/user/live_videos/ 
	/// </summary>
	public class FacebookUserLiveEncoders
	{
		/// <summary>
		/// A list of LiveEncoder nodes. 
		/// </summary>
		public FacebookLiveEncoder[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

	}

	///<summary>
	/// Represents an individual video on Facebook.
	///     https://developers.facebook.com/docs/graph-api/reference/video/
	///     Permissions
	///     Any valid access token can read videos on a public Page.
	///     A page access token can read all videos posted to or posted by that Page.
	///     A user access token can read any video your application created on behalf of that user.
	///     A user's videos can be read if the owner has granted the user_videos or user_posts permission.
	///     A user access token may read a video that user is tagged in if they user granted the user_videos or user_posts permission. However, in some cases the video's owner's privacy settings may not allow your application to access it.
	///     The source field will not be returned for Page-owned videos unless the User making the request has a role on the owning Page. 
	/// </summary>
	public class FacebookVideo
	{
		/// <summary>
		/// The time the video was initially published. 
		/// </summary>
		public DateTime created_time { get; set; }

		/// <summary>
		/// The video ID. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The description of the video. 
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// Location associated with the video, if any. 
		/// </summary>
		public FacebookPlace place { get; set; }

	}

	///<summary>
	/// A live video
	///     https://developers.facebook.com/docs/graph-api/reference/live-video/
	///     Permissions:
	///     Developers usually request these permissions for this endpoint:
	///     Marketing Apps
	///     manage_pages
	///     pages_show_list
	///     business_management
	///     Page management Apps
	///     manage_pages
	///     pages_show_list
	///     Other Apps
	///     Permissions are not usually requested.
	///     A Page access token can read all videos posted to or posted by that Page.
	///     A User access token can read any video your application created on behalf of that user.
	///     A User's videos can be read if the owner has granted the user_videos or user_posts permission.
	///     A User access token may read a video that a user is tagged in if the user granted the user_videos or user_posts permission. However, in some cases the video's owner's privacy settings may not allow your application to access it.
	///     A User access token for an Admin of a Group can read Group-owned Live Videos.
	///     A User access token for an Admin of an Event can read Event-owned Live Videos. 
	/// </summary>
	public class FacebookLiveVideo
	{
		/// <summary>
		/// The time the video was initially published 
		/// </summary>
		public DateTime broadcast_start_time { get; set; }

		/// <summary>
		/// The live video ID 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The description of the live video 
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// The title of the live video 
		/// </summary>
		public string title { get; set; }

		/// <summary>
		/// The inside video of live video - only visible when the live video has ended. 
		/// </summary>
		public FacebookVideo video { get; set; }

	}

	///<summary>
	/// Live videos from this person
	///     https://developers.facebook.com/docs/graph-api/reference/user/live_videos/
	///     Permissions
	///     Developers usually request these permissions for this endpoint:
	///     Marketing Apps
	///     No data
	///     Page management Apps
	///     No data
	///     Other Apps
	///     publish_actions 
	/// </summary>
	public class FacebookUserLiveVideos
	{
		/// <summary>
		/// A list of LiveVideo nodes. 
		/// </summary>
		public FacebookLiveVideo[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

	}

	///<summary>
	/// Movies this person likes
	///     https://developers.facebook.com/docs/graph-api/reference/user/movies/
	///     Permissions
	///     Developers usually request these permissions for this endpoint:
	///     Marketing Apps
	///     ads_management
	///     manage_pages
	///     pages_show_list
	///     user_likes
	///     Page management Apps
	///     No data
	///     Other Apps
	///     user_likes 
	/// </summary>
	public class FacebookUserMovies
	{
		/// <summary>
		/// A list of Page nodes. 
		/// </summary>
		public FacebookPage[] data { get; set; }

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
	/// Music this person likes.
	///     https://developers.facebook.com/docs/graph-api/reference/user/music/
	///     Permissions
	///     Developers usually request these permissions for this endpoint:
	///     Marketing Apps
	///     No data
	///     Page management Apps
	///     No data
	///     Other Apps
	///     user_likes 
	/// </summary>
	public class FacebookUserMusic
	{
		/// <summary>
		/// A list of Page nodes. 
		/// </summary>
		public FacebookPage[] data { get; set; }

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
	/// A permission requested from a user by an application
	///     https://developers.facebook.com/docs/graph-api/reference/permission/ 
	/// </summary>
	public class FacebookPermission
	{
		/// <summary>
		/// Name of the permission 
		/// </summary>
		public string permission { get; set; }

		/// <summary>
		/// Permission status 
		/// </summary>
		public string status { get; set; }

	}

	///<summary>
	/// Returns a list of granted and declined permissions.
	///     https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 
	/// </summary>
	public class FacebookUserPermissions
	{
		/// <summary>
		/// A list of Permission nodes. 
		/// </summary>
		public FacebookPermission[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

	}

	///<summary>
	/// Photos for a person.
	///     https://developers.facebook.com/docs/graph-api/reference/user/photos/
	///     Permissions
	///     Any valid access token for any photo with public privacy settings.
	///     For any photos uploaded by someone, and any photos in which they have been tagged - A user access token for that person with user_photos permission. 
	/// </summary>
	public class FacebookUserPhotos
	{
		/// <summary>
		/// A list of Photo nodes. 
		/// </summary>
		public FacebookPhoto[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

	}

	///<summary>
	/// Profile Picture
	///     https://developers.facebook.com/docs/graph-api/reference/profile-picture-source/ 
	/// </summary>
	public class FacebookProfilePictureSource
	{
		/// <summary>
		/// A key to identify the profile picture for the purpose of invalidating the image cache 
		/// </summary>
		public string cache_key { get; set; }

		/// <summary>
		/// Picture height in pixels. Only returned when specified as a modifier 
		/// </summary>
		public Int32 height { get; set; }

		/// <summary>
		/// True if the profile picture is the default 'silhouette' picture 
		/// </summary>
		public string is_silhouette { get; set; }

		/// <summary>
		/// URL of the profile picture 
		/// </summary>
		public string url { get; set; }

		/// <summary>
		/// Picture width in pixels. Only returned when specified as a modifier 
		/// </summary>
		public Int32 width { get; set; }

	}

	///<summary>
	/// A Picture for a Facebook User.
	///     https://developers.facebook.com/docs/graph-api/reference/user/picture/ 
	/// </summary>
	public class FacebookUserPicture
	{
		/// <summary>
		/// A single ProfilePictureSource node. 
		/// </summary>
		public FacebookProfilePictureSource data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

	}

	///<summary>
	/// A Graph API past request object
	///     https://developers.facebook.com/docs/graph-api/reference/request-history/ 
	/// </summary>
	public class FacebookRequestHistory
	{
		/// <summary>
		/// Gets or sets the API version. 
		/// </summary>
		public string api_version { get; set; }

		/// <summary>
		/// Graph API version of the stored request 
		/// </summary>
		public DateTime created_time { get; set; }

		/// <summary>
		/// Error code of the past request 
		/// </summary>
		public Int32 error_code { get; set; }

		/// <summary>
		/// Graph path of the stored request 
		/// </summary>
		public string graph_path { get; set; }

		/// <summary>
		/// HTTP method of the stored request. 
		/// </summary>
		public string http_method { get; set; }

	}

	///<summary>
	/// Developers' Graph API request history
	///     https://developers.facebook.com/docs/graph-api/reference/user/request_history/ 
	/// </summary>
	public class FacebookUserRequestHistory
	{
		/// <summary>
		/// A list of RequestHistory nodes. 
		/// </summary>
		public FacebookRequestHistory[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

	}

	///<summary>
	/// A canvas document.
	///     https://developers.facebook.com/docs/graph-api/reference/canvas/ 
	/// </summary>
	public class FacebookCanvas
	{
		/// <summary>
		/// Gets or sets the identifier. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The canvas link for the canvas 
		/// </summary>
		public string canvas_link { get; set; }

		/// <summary>
		/// The canvas is hidden or not 
		/// </summary>
		public string is_hidden { get; set; }

		/// <summary>
		/// Publish status of the canvas 
		/// </summary>
		public string is_published { get; set; }

		/// <summary>
		/// User who last edited this canvas 
		/// </summary>
		public FacebookUser last_editor { get; set; }

		/// <summary>
		/// Name used to label the canvas 
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// Page that owns this canvas 
		/// </summary>
		public FacebookPage owner { get; set; }

		/// <summary>
		/// Last updated time of the canvas 
		/// </summary>
		public Int32 update_time { get; set; }

	}

	///<summary>
	/// A list of rich media documents belonging to Pages that the user has advertiser permissions on
	///     https://developers.facebook.com/docs/graph-api/reference/user/rich_media_documents/ 
	/// </summary>
	public class FacebookUserRichMediaDocuments
	{
		/// <summary>
		/// A list of Canvas nodes. 
		/// </summary>
		public FacebookCanvas[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

	}

	///<summary>
	/// Any session keys that the app knows the user by
	///     https://developers.facebook.com/docs/graph-api/reference/user/session_keys/ 
	/// </summary>
	public class FacebookUserSessionKeys
	{
		/// <summary>
		/// A list of PlatformSessionKey nodes. 
		/// </summary>
		public FacebookPage[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

	}

	///<summary>
	/// This represents a News Feed filter
	///     https://developers.facebook.com/docs/graph-api/reference/stream-filter/ 
	/// </summary>
	public class FacebookStreamFilter
	{
		/// <summary>
		/// The filter key used by the News Feed 
		/// </summary>
		public string filter_key { get; set; }

		/// <summary>
		/// The name of the filter 
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// The type of the filter 
		/// </summary>
		public string Type { get; set; }

	}

	///<summary>
	/// A list of filters that can be applied to the News Feed edge
	///     https://developers.facebook.com/docs/graph-api/reference/user/stream_filters/ 
	/// </summary>
	public class FacebookUserStreamFilters
	{
		/// <summary>
		/// A list of StreamFilter nodes. 
		/// </summary>
		public FacebookStreamFilter[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

	}

	///<summary>
	/// Profile picture link
	///     https://developers.facebook.com/docs/graph-api/reference/user-taggable-friend/picture/ 
	/// </summary>
	public class FacebookUserTaggableFriendPicture
	{
		/// <summary>
		/// A single ProfilePictureSource node. 
		/// </summary>
		public FacebookProfilePictureSource data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

	}

	///<summary>
	/// Taggable friend of current user
	///     https://developers.facebook.com/docs/graph-api/reference/user-taggable-friend/ 
	/// </summary>
	public class FacebookUserTaggableFriend
	{
		/// <summary>
		/// First name 
		/// </summary>
		public string first_name { get; set; }

		/// <summary>
		/// ID 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// Last name 
		/// </summary>
		public string last_name { get; set; }

		/// <summary>
		/// Middle name 
		/// </summary>
		public string middle_name { get; set; }

		/// <summary>
		/// Name 
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// Profile picture link 
		/// </summary>
		public FacebookUserTaggableFriendPicture picture { get; set; }

	}

	///<summary>
	/// Friends that can be tagged in content published via the Graph API
	///     https://developers.facebook.com/docs/graph-api/reference/user/taggable_friends/
	///     Permissions
	///     Developers usually request these permissions for this endpoint:
	///     Marketing Apps
	///     No data
	///     Page management Apps
	///     No data
	///     Other Apps
	///     user_friends 
	/// </summary>
	public class FacebookUserTaggableFriends
	{
		/// <summary>
		/// A list of UserTaggableFriend nodes. 
		/// </summary>
		public FacebookUserTaggableFriend[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

	}

	///<summary>
	/// A Place Tag
	///     https://developers.facebook.com/docs/graph-api/reference/place-tag/ 
	/// </summary>
	public class FacebookPlaceTag
	{
		/// <summary>
		/// ID 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// Time when the place was visited 
		/// </summary>
		public DateTime created_time { get; set; }

		/// <summary>
		/// The place that was visited 
		/// </summary>
		public FacebookPage place { get; set; }

	}

	///<summary>
	/// Tagged Places for a Facebook User.
	///     https://developers.facebook.com/docs/graph-api/reference/user/tagged_places/
	///     Permissions
	///     Developers usually request these permissions for this endpoint:
	///     Marketing Apps
	///     No data
	///     Page management Apps
	///     No data
	///     Other Apps
	///     user_tagged_places 
	/// </summary>
	public class FacebookUserTaggedPlaces
	{
		/// <summary>
		/// A list of PlaceTag nodes. 
		/// </summary>
		public FacebookPlaceTag[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

	}

	///<summary>
	/// TV shows this person likes.
	///     https://developers.facebook.com/docs/graph-api/reference/user/television/
	///     Permissions
	///     Developers usually request these permissions for this endpoint:
	///     Marketing Apps
	///     No data
	///     Page management Apps
	///     No data
	///     Other Apps
	///     user_likes 
	/// </summary>
	public class FacebookUserTelevision
	{
		/// <summary>
		/// A list of Page nodes. 
		/// </summary>
		public FacebookPage[] data { get; set; }

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
	/// Video broadcasts from this person 
	/// </summary>
	public class FacebookUserVideoBroadcasts
	{
		/// <summary>
		/// A list of LiveVideo nodes. 
		/// </summary>
		public FacebookLiveVideo[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

	}

	///<summary>
	/// Videos for a Facebook User.
	///     https://developers.facebook.com/docs/graph-api/reference/user/videos/
	///     Permissions
	///     Developers usually request these permissions for this endpoint:
	///     Marketing Apps
	///     No data
	///     Page management Apps
	///      No data
	///     Other Apps
	///      user_videos 
	/// </summary>
	public class FacebookUserVideos
	{
		/// <summary>
		/// A list of Video nodes. 
		/// </summary>
		public FacebookVideo[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

	}

	///<summary>
	/// An individual entry in a profile's feed. The profile could be a user, page, app, or group. 
	/// </summary>
	public class FacebookPost
	{
		/// <summary>
		/// The post ID 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The time the post was initially published. For a post about a life event, this will be the date and time of the life event. 
		/// </summary>
		public DateTime created_time { get; set; }

		/// <summary>
		/// The status message in the post. 
		/// </summary>
		public string message { get; set; }

		/// <summary>
		/// The link attached to this post. 
		/// </summary>
		public string link { get; set; }

		/// <summary>
		/// Likes. 
		/// </summary>
		public FacebookUserLikes likes { get; set; }

		/// <summary>
		/// Any location information attached to the post. 
		/// </summary>
		public FacebookPlace place { get; set; }

		/// <summary>
		/// Text from stories not intentionally generated by users, such as those generated when two people become friends, 
		/// or when someone else posts on the person's wall. 
		/// </summary>
		public string story { get; set; }

	}

	///<summary>
	/// The feed of posts 
	/// </summary>
	public class FacebookFeed
	{
		/// <summary>
		/// Data 
		/// </summary>
		public FacebookPost[] data { get; set; }

		/// <summary>
		/// Gets or sets the paging. 
		/// </summary>
		public FacebookPaging paging { get; set; }

	}

	///<summary>
	/// Information of User
	///     https://developers.facebook.com/docs/graph-api/reference/user/
	///     Permissions
	///     Developers usually request these permissions for this endpoint:
	///     Marketing Apps
	///     No data
	///     Page management Apps
	///     manage_pages
	///     pages_show_list
	///     Other Apps
	///     Permissions are not usually requested. 
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
		/// The relationship between user and family member. 
		/// </summary>
		public string relationship { get; set; }

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
		/// Pages this User has a role on. 
		/// </summary>
		public FacebookUserAccounts accounts { get; set; }

		/// <summary>
		/// Achievements made in Facebook games 
		/// </summary>
		public FacebookUserAchievements achievements { get; set; }

		/// <summary>
		/// Ad studies that this person can view 
		/// </summary>
		public FacebookUserAdStudies ad_studies { get; set; }

		/// <summary>
		/// The advertising accounts to which this person has access 
		/// </summary>
		public FacebookUserAdaccounts adaccounts { get; set; }

		/// <summary>
		/// Insights data for the person's Audience Network apps. 
		/// </summary>
		public FacebookUserAdnetworkanalytics adnetworkanalytics { get; set; }

		/// <summary>
		/// The photo albums this person has created 
		/// </summary>
		public FacebookUserAlbums albums { get; set; }

		/// <summary>
		/// App requests. 
		/// </summary>
		public FacebookApprequestformerrecipients apprequestformerrecipients { get; set; }

		/// <summary>
		/// App requests. 
		/// </summary>
		public FacebookUserApprequests apprequests { get; set; }

		/// <summary>
		/// The 3D assets owned by the user 
		/// </summary>
		public FacebookUserAsset3ds asset3ds { get; set; }

		/// <summary>
		/// The books listed on this person's profile. 
		/// </summary>
		public FacebookUserBooks books { get; set; }

		/// <summary>
		/// Business users corresponding to the user. 
		/// </summary>
		public FacebookUserBusinessUsers business_users { get; set; }

		/// <summary>
		/// Businesses associated with the user 
		/// </summary>
		public FacebookUserBusinesses businesses { get; set; }

		/// <summary>
		/// The curated collections created by this user 
		/// </summary>
		public FacebookUserCuratedCollections curated_collections { get; set; }

		/// <summary>
		/// Custom labels. 
		/// </summary>
		public FacebookUserCustomLabels custom_labels { get; set; }

		/// <summary>
		/// The domains the user admins 
		/// </summary>
		public FacebookUserDomains domains { get; set; }

		/// <summary>
		/// Events for this person. By default this does not include events the person has declined or not replied to 
		/// </summary>
		public FacebookUserEvents events { get; set; }

		/// <summary>
		/// This person's family relationships. 
		/// </summary>
		public FacebookUserFamily family { get; set; }

		/// <summary>
		/// Developers' favorite requests to the Graph API. 
		/// </summary>
		public FacebookUserFavoriteRequests favorite_requests { get; set; }

		/// <summary>
		/// The person's custom friend lists 
		/// </summary>
		public FacebookUserFriendlists friendlists { get; set; }

		/// <summary>
		/// A person's friends. 
		/// </summary>
		public FacebookUserFriends friends { get; set; }

		/// <summary>
		/// Games this person likes. 
		/// </summary>
		public FacebookUserGames games { get; set; }

		/// <summary>
		/// A list of Facebook Groups of which a person is an admin. 
		/// </summary>
		public FacebookUserGroups groups { get; set; }

		/// <summary>
		/// Businesses can claim ownership of multiple apps using Business Manager. 
		/// This edge returns the list of IDs that this user has in any of those other apps 
		/// </summary>
		public FacebookUserIDsForBusiness ids_for_business { get; set; }

		/// <summary>
		/// A list of lead generation forms belonging to Pages that the user has advertiser permissions on 
		/// </summary>
		public FacebookUserLeadgenForms leadgen_forms { get; set; }

		/// <summary>
		/// All the Pages this person has liked. 
		/// </summary>
		public FacebookUserLikes likes { get; set; }

		/// <summary>
		/// Live encoders owned by this person. 
		/// </summary>
		public FacebookUserLiveEncoders live_encoders { get; set; }

		/// <summary>
		/// Live videos from this person 
		/// </summary>
		public FacebookUserLiveVideos live_videos { get; set; }

		/// <summary>
		/// Movies this person likes 
		/// </summary>
		public FacebookUserMovies movies { get; set; }

		/// <summary>
		/// Music this person likes 
		/// </summary>
		public FacebookUserMusic music { get; set; }

		/// <summary>
		/// The permissions that the person has granted this app 
		/// </summary>
		public FacebookUserPermissions permissions { get; set; }

		/// <summary>
		/// Photos the person is tagged in or has uploaded. 
		/// </summary>
		public FacebookUserPhotos photos { get; set; }

		/// <summary>
		/// The person's profile picture 
		/// </summary>
		public FacebookUserPicture picture { get; set; }

		/// <summary>
		/// Developers' Graph API request history 
		/// </summary>
		public FacebookUserRequestHistory request_history { get; set; }

		/// <summary>
		/// A list of rich media documents belonging to Pages that the user has advertiser permissions on 
		/// </summary>
		public FacebookUserRichMediaDocuments rich_media_documents { get; set; }

		/// <summary>
		/// Any session keys that the app knows the user by 
		/// </summary>
		public FacebookUserSessionKeys session_keys { get; set; }

		/// <summary>
		/// A list of filters that can be applied to the News Feed edge 
		/// </summary>
		public FacebookUserStreamFilters stream_filters { get; set; }

		/// <summary>
		/// Friends that can be tagged in content published via the Graph API 
		/// </summary>
		public FacebookUserTaggableFriends taggable_friends { get; set; }

		/// <summary>
		/// List of tagged places for this person. It can include tags on videos, posts, statuses or links 
		/// </summary>
		public FacebookUserTaggedPlaces tagged_places { get; set; }

		/// <summary>
		/// TV shows this person likes 
		/// </summary>
		public FacebookUserTelevision television { get; set; }

		/// <summary>
		/// Video broadcasts from this person 
		/// </summary>
		public FacebookUserVideoBroadcasts video_broadcasts { get; set; }

		/// <summary>
		/// Videos the person is tagged in or uploaded 
		/// </summary>
		public FacebookUserVideos videos { get; set; }

		/// <summary>
		/// Gets or sets the feed. 
		/// </summary>
		public FacebookFeed feed { get; set; }

	}

	///<summary>
	/// A person's family relationships.
	///     https://developers.facebook.com/docs/graph-api/reference/user/family 
	/// </summary>
	public class FacebookUserFamily
	{
		/// <summary>
		/// A list of User nodes. 
		/// </summary>
		public FacebookUser[] data { get; set; }

		/// <summary>
		/// For more details about pagination, see the Graph API guide. 
		/// </summary>
		public FacebookPaging paging { get; set; }

	}

	///<summary>
	/// App access tokens are used to make requests to Facebook APIs on behalf of an app rather than a user. This can be used to modify the parameters of your app, create and manage test users, or read your apps's insights.
	///      https://developers.facebook.com/docs/facebook-login/access-tokens#apptokens 
	/// </summary>
	public class FacebookAppToken
	{
		/// <summary>
		/// App Token 
		/// </summary>
		public string access_token { get; set; }

		/// <summary>
		/// Token Type 
		/// </summary>
		public string token_type { get; set; }

	}

	///<summary>
	/// Inspecting Access Tokens
	///      https://developers.facebook.com/docs/facebook-login/manually-build-a-login-flow 
	/// </summary>
	public class FacebookDebugMetadata
	{
		/// <summary>
		/// Gets or sets the sso. 
		/// </summary>
		public string sso { get; set; }

	}

	///<summary>
	/// Inspecting Access Tokens
	///      https://developers.facebook.com/docs/facebook-login/manually-build-a-login-flow 
	/// </summary>
	public class FacebookDebugData
	{
		/// <summary>
		/// The application identifier. 
		/// </summary>
		public string app_id { get; set; }

		/// <summary>
		/// The type. 
		/// </summary>
		public string type { get; set; }

		/// <summary>
		/// The application. 
		/// </summary>
		public string application { get; set; }

		/// <summary>
		/// The expires at. 
		/// </summary>
		public string expires_at { get; set; }

		/// <summary>
		/// The is valid. 
		/// </summary>
		public string is_valid { get; set; }

		/// <summary>
		/// The issued at. 
		/// </summary>
		public string issued_at { get; set; }

		/// <summary>
		/// The metadata. 
		/// </summary>
		public FacebookDebugMetadata metadata { get; set; }

		/// <summary>
		/// The scopes. 
		/// </summary>
		public string[] scopes { get; set; }

		/// <summary>
		/// The user identifier. 
		/// </summary>
		public string user_id { get; set; }

	}

	///<summary>
	/// Inspecting Access Tokens
	///      https://developers.facebook.com/docs/facebook-login/manually-build-a-login-flow 
	/// </summary>
	public class FacebookDebug
	{
		/// <summary>
		/// The data. 
		/// </summary>
		public FacebookDebugData data { get; set; }

	}

}