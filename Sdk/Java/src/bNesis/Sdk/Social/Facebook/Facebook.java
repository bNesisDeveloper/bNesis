package bNesis.Sdk.Social.Facebook;

import java.io.*;
import java.util.List;
import java.util.Date;
import java.util.Map.Entry;
import bNesis.Api.*;

import bNesis.Sdk.Common.*;
import java.net.URI.*;
import bNesis.Sdk.Social.Facebook.*;
import java.util.Date.*;

	public class Facebook  
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

		public Facebook(bNesisApi bnesisApi)
		{
			this._bNesisApi = bnesisApi;
		}

		/**
		 * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		 * @return {String} bNesisToken value
		 */
		public String Auth(String bNesisDevId,String clientId,String clientSecret,String redirectUrl,String[] scopes) throws Exception
		{
			bNesisToken = _bNesisApi.Auth("Facebook", "",bNesisDevId,redirectUrl,clientId,clientSecret,scopes,"","",false,"");
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
			Boolean result = _bNesisApi.LogoffService("Facebook", bNesisToken);
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
			return _bNesisApi.<ErrorInfo>Call(ErrorInfo.class, "Facebook", bNesisToken, "GetLastError");
		}

		/**
		 *  Getting arrays of error info 	
		 * @return {ErrorInfo[]}  
		 * @throws Exception
		 */
		public ErrorInfo[] GetErrorLog() throws Exception
		{
			return _bNesisApi.<ErrorInfo[]>Call(ErrorInfo[].class, "Facebook", bNesisToken, "GetErrorLog");
		}

		/**
		 *  Checks the token in the service. 	
		 * @return {Boolean} if token valid return true, if token not valid return false 
		 * @throws Exception
		 */
		public Boolean ValidateToken() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "Facebook", bNesisToken, "ValidateToken");
		}

		/**
		 *  Disables the access token used to authenticate the call. 	
		 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false 
		 * @throws Exception
		 */
		public Boolean Logoff() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "Facebook", bNesisToken, "Logoff");
		}

		/**
		 *   	
		 * @param id 
	 * @return {ContactItem}  
		 * @throws Exception
		 */
		public ContactItem GetFieldsUserUnified(String id) throws Exception
		{
			return _bNesisApi.<ContactItem>Call(ContactItem.class, "Facebook", bNesisToken, "GetFieldsUserUnified", id);
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
			return _bNesisApi.<ContactItem>Call(ContactItem.class, "Facebook", bNesisToken, "GetFieldUserUnified", id, field);
		}

		/**
		 *   	
		 * @param id 
	 * @return {ContactItem}  
		 * @throws Exception
		 */
		public ContactItem GetUserAboutUnified(String id) throws Exception
		{
			return _bNesisApi.<ContactItem>Call(ContactItem.class, "Facebook", bNesisToken, "GetUserAboutUnified", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Videos the person is tagged in or uploaded 
		 * @throws Exception
		 */
		public Response GetUserVideosRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserVideosRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The feed of posts (including status updates) and links published by this person. 
		 * @throws Exception
		 */
		public Response GetUserFeedRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserFeedRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 	
		 * @param id The identifier. "me" - current user
	 * @param message The main body of the post, otherwise called the status message.
	 * Either link, place, or message must be supplied.
	 * @param link The URL of a link to attach to the post. 
	 * Either link, place, or message must be supplied. Additional fields associated with link are shown below.
	 * @return {Response} The feed of posts (including status updates) and links published by this person. 
		 * @throws Exception
		 */
		public Response PostUserFeedRaw(String id, String message, String link) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "PostUserFeedRaw", id, message, link);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The scores this person has received from Facebook Games that they've played. 
		 * @throws Exception
		 */
		public Response GetUserScoresRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserScoresRaw", id);
		}

		/**
		 *  Page Access Tokens 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} a list of pages that the person administers along with other information about the Page, 
	 * such as the Page category, the permissions the admin has for that Page, and the page access token. 
		 * @throws Exception
		 */
		public Response GetPageAccessTokenRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetPageAccessTokenRaw", id);
		}

		/**
		 *  Generates an App Access Token 	
		 * @return {Response} app Access Token 
		 * @throws Exception
		 */
		public Response GetAppAccessTokenRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetAppAccessTokenRaw");
		}

		/**
		 *  Checks the token in the service. 	
		 * @return {Response} data with information about the token 
		 * @throws Exception
		 */
		public Response ValidationTokenRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "ValidationTokenRaw");
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} What the person is interested in meeting for 
		 * @throws Exception
		 */
		public Response GetUserMeetingForRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserMeetingForRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The person's name formatted to correctly handle Chinese, Japanese, or Korean ordering 
		 * @throws Exception
		 */
		public Response GetUserNameFormatRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserNameFormatRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The person's payment pricepoints 
		 * @throws Exception
		 */
		public Response GetUserPaymentPricepointsRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserPaymentPricepointsRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The person's political views 
		 * @throws Exception
		 */
		public Response GetUserPoliticalRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserPoliticalRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The person's PGP public key 
		 * @throws Exception
		 */
		public Response GetUserPublicKeyRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserPublicKeyRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The person's favorite quotes 
		 * @throws Exception
		 */
		public Response GetUserQuotesRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserQuotesRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The person's relationship status 
		 * @throws Exception
		 */
		public Response GetUserRelationshipStatusRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserRelationshipStatusRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The person's religion 
		 * @throws Exception
		 */
		public Response GetUserReligionRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserReligionRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Security settings 
		 * @throws Exception
		 */
		public Response GetUserSecuritySettingsRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserSecuritySettingsRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Security settings 
		 * @throws Exception
		 */
		public Response GetUserSharedLoginUpgradeRequiredByRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserSharedLoginUpgradeRequiredByRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Shortened, locale-aware name for the person 
		 * @throws Exception
		 */
		public Response GetUserShortNameRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserShortNameRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The person's significant other 
		 * @throws Exception
		 */
		public Response GetUserSignificantOtherRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserSignificantOtherRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Sports played by the person 
		 * @throws Exception
		 */
		public Response GetUserSportsRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserSportsRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Platform test group 
		 * @throws Exception
		 */
		public Response GetUserTestGroupRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserTestGroupRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} A string containing an anonymous, but unique identifier for the person. You can use this identifier with third parties 
		 * @throws Exception
		 */
		public Response GetUserThirdPartyIdRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserThirdPartyIdRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The person's current timezone offset from UTC 
		 * @throws Exception
		 */
		public Response GetUserTimezoneRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserTimezoneRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Updated time 
		 * @throws Exception
		 */
		public Response GetUserUpdatedTimeRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserUpdatedTimeRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Latest user ref that matches a given PSID that should be invalidated. 
	 * This should only be used for anonymous messaging PSID migration 
		 * @throws Exception
		 */
		public Response GetUserUserRefRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserUserRefRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Indicates whether the account has been verified. 
	 * This is distinct from the is_verified field. Someone is considered verified if they take any of the following actions: 
		 * @throws Exception
		 */
		public Response GetUserVerifiedRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserVerifiedRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Video upload limits 
		 * @throws Exception
		 */
		public Response GetUserVideoUploadLimitsRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserVideoUploadLimitsRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Can the viewer send a gift to this person? 
		 * @throws Exception
		 */
		public Response GetUserViewerCanSendGiftRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserViewerCanSendGiftRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The person's website 
		 * @throws Exception
		 */
		public Response GetUserWebsiteRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserWebsiteRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The person's website 
		 * @throws Exception
		 */
		public Response GetUserWorkRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserWorkRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Pages this User has a role on. 
		 * @throws Exception
		 */
		public Response GetUserAccountsRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserAccountsRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Achievements made in Facebook games 
		 * @throws Exception
		 */
		public Response GetUserAchievementsRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserAchievementsRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Ad studies that this person can view 
		 * @throws Exception
		 */
		public Response GetUserAdStudiesRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserAdStudiesRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The advertising accounts to which this person has access 
		 * @throws Exception
		 */
		public Response GetUserAdAccountsRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserAdAccountsRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Insights data for the person's Audience Network apps 
		 * @throws Exception
		 */
		public Response GetUserAdNetWorkanalyticsRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserAdNetWorkanalyticsRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The photo albums this person has created 
		 * @throws Exception
		 */
		public Response GetUserAlbumsRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserAlbumsRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} App requests 
		 * @throws Exception
		 */
		public Response GetUserApprequestForMerrecipientsRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserApprequestForMerrecipientsRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} This person's pending requests from an app 
		 * @throws Exception
		 */
		public Response GetUserAppRequestsRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserAppRequestsRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The 3D assets owned by the user 
		 * @throws Exception
		 */
		public Response GetUserAsset3DsRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserAsset3DsRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The books listed on this person's profile 
		 * @throws Exception
		 */
		public Response GetUserBooksRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserBooksRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Business users corresponding to the user 
		 * @throws Exception
		 */
		public Response GetUserBusinessUsersRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserBusinessUsersRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Businesses associated with the user 
		 * @throws Exception
		 */
		public Response GetUserBusinessesRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserBusinessesRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The curated collections created by this user 
		 * @throws Exception
		 */
		public Response GetUserCuratedCollectionsRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserCuratedCollectionsRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} custom labels 
		 * @throws Exception
		 */
		public Response GetUserCustomLabelsRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserCustomLabelsRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The domains the user admins 
		 * @throws Exception
		 */
		public Response GetUserDomainsRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserDomainsRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Events for this person.By default this does not include events the person has declined or not replied to 
		 * @throws Exception
		 */
		public Response GetUserEventsRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserEventsRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} This person's family relationships. 
		 * @throws Exception
		 */
		public Response GetUserFamilyRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserFamilyRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Developers' favorite requests to the Graph API 
		 * @throws Exception
		 */
		public Response GetUserFavoriteRequestsRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserFavoriteRequestsRaw", id);
		}

		/**
		 *  A person's custom friend lists.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} A person's custom friend lists. 
		 * @throws Exception
		 */
		public Response GetUserFriendlistsRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserFriendlistsRaw", id);
		}

		/**
		 *  Get the User's friends who have installed the app making the query.
	 * Get the User's total number of friends (including those who have not installed the app making the query)
	 * Permissions:
	 * a User access token with the following permissions: user_friends.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The person's friends 
		 * @throws Exception
		 */
		public Response GetFieldsUserFriendsRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetFieldsUserFriendsRaw", id);
		}

		/**
		 *  Get the User's friends who have installed the app making the query.
	 * Get the User's total number of friends (including those who have not installed the app making the query)
	 * Permissions:
	 * a User access token with the following permissions: user_friends.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @param field The field. Example: string fields = "id,name,birthday".
	 * It is necessary to form fields independently.
	 * @return {Response} The person's friends 
		 * @throws Exception
		 */
		public Response GetFieldUserFriendsRaw(String id, String field) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetFieldUserFriendsRaw", id, field);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Games this person likes 
		 * @throws Exception
		 */
		public Response GetUserGamesRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserGamesRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The Facebook Groups of which the person is an Admin. 
		 * @throws Exception
		 */
		public Response GetUserGroupsRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserGroupsRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Businesses can claim ownership of multiple apps using Business Manager. 
	 * This edge returns the list of IDs that this user has in any of those other apps 
		 * @throws Exception
		 */
		public Response GetUserIdsForBusinessRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserIdsForBusinessRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} A list of lead generation forms belonging to Pages that the user has advertiser permissions on 
		 * @throws Exception
		 */
		public Response GetUserLeadgenFormsRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserLeadgenFormsRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} All the Pages this person has liked 
		 * @throws Exception
		 */
		public Response GetUserLikesRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserLikesRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Live encoders owned by this person 
		 * @throws Exception
		 */
		public Response GetUserLiveEncodersRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserLiveEncodersRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Live videos from this person 
		 * @throws Exception
		 */
		public Response GetUserLiveVideosRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserLiveVideosRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Movies this person likes 
		 * @throws Exception
		 */
		public Response GetUserMoviesRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserMoviesRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Music this person likes 
		 * @throws Exception
		 */
		public Response GetUserMusicRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserMusicRaw", id);
		}

		/**
		 *  Gets the user premissions.
	 * https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} a list of granted and declined permissions. 
		 * @throws Exception
		 */
		public Response GetUserPremissionsRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserPremissionsRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Photos the person is tagged in or has uploaded 
		 * @throws Exception
		 */
		public Response GetUserPhotosRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserPhotosRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The person's profile picture 
		 * @throws Exception
		 */
		public Response GetUserPictureRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserPictureRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Developers' Graph API request history 
		 * @throws Exception
		 */
		public Response GetUserRequestHistoryRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserRequestHistoryRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} A list of rich media documents belonging to Pages that the user has advertiser permissions on 
		 * @throws Exception
		 */
		public Response GetUserRichMediaDocumentsRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserRichMediaDocumentsRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Any session keys that the app knows the user by 
		 * @throws Exception
		 */
		public Response GetUserSessionKeysRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserSessionKeysRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} A list of filters that can be applied to the News Feed edge 
		 * @throws Exception
		 */
		public Response GetUserStreamFiltersRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserStreamFiltersRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Friends that can be tagged in content published via the Graph API 
		 * @throws Exception
		 */
		public Response GetUserTaggableFriendsRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserTaggableFriendsRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} List of tagged places for this person. It can include tags on videos, posts, statuses or links 
		 * @throws Exception
		 */
		public Response GetUserTaggedPlacesRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserTaggedPlacesRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} TV shows this person likes 
		 * @throws Exception
		 */
		public Response GetUserTelevisionRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserTelevisionRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Video broadcasts from this person 
		 * @throws Exception
		 */
		public Response GetUserVideoBroadcastsRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserVideoBroadcastsRaw", id);
		}

		/**
		 *  The curated collections created by this user
	 * https://developers.facebook.com/docs/graph-api/reference/user/curated_collections/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserCuratedCollections} The curated collections created by this user 
		 * @throws Exception
		 */
		public FacebookUserCuratedCollections GetUserCuratedCollections(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserCuratedCollections>Call(FacebookUserCuratedCollections.class, "Facebook", bNesisToken, "GetUserCuratedCollections", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/custom_labels/
	 * Permissions
	 * Developers usually request these permissions for this endpoint:
	 * Marketing Apps
	 * No data
	 * Page management Apps
	 * manage_pages
	 * pages_show_list
	 * pages_messaging
	 * Other Apps
	 * No data 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserCustomLabels} custom labels 
		 * @throws Exception
		 */
		public FacebookUserCustomLabels GetUserCustomLabels(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserCustomLabels>Call(FacebookUserCustomLabels.class, "Facebook", bNesisToken, "GetUserCustomLabels", id);
		}

		/**
		 *  The domains the user admins
	 * https://developers.facebook.com/docs/graph-api/reference/user/domains/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserDomains} The domains the user admins 
		 * @throws Exception
		 */
		public FacebookUserDomains GetUserDomains(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserDomains>Call(FacebookUserDomains.class, "Facebook", bNesisToken, "GetUserDomains", id);
		}

		/**
		 *  Events for this person. By default this does not include events the person has declined or not replied to
	 * https://developers.facebook.com/docs/graph-api/reference/user/events/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserEvents} Events for this person.By default this does not include events the person has declined or not replied to 
		 * @throws Exception
		 */
		public FacebookUserEvents GetUserEvents(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserEvents>Call(FacebookUserEvents.class, "Facebook", bNesisToken, "GetUserEvents", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserFamily} This person's family relationships. 
		 * @throws Exception
		 */
		public FacebookUserFamily GetUserFamily(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserFamily>Call(FacebookUserFamily.class, "Facebook", bNesisToken, "GetUserFamily", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserFavoriteRequests} Developers' favorite requests to the Graph API 
		 * @throws Exception
		 */
		public FacebookUserFavoriteRequests GetUserFavoriteRequests(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserFavoriteRequests>Call(FacebookUserFavoriteRequests.class, "Facebook", bNesisToken, "GetUserFavoriteRequests", id);
		}

		/**
		 *  A person's custom friend lists.
	 * https://developers.facebook.com/docs/graph-api/reference/user/friendlists/ 	
		 * @param id 
	 * @return {FacebookUserFriendlists} A person's custom friend lists. 
		 * @throws Exception
		 */
		public FacebookUserFriendlists GetUserFriendlists(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserFriendlists>Call(FacebookUserFriendlists.class, "Facebook", bNesisToken, "GetUserFriendlists", id);
		}

		/**
		 *  Get the User's friends who have installed the app making the query.
	 * Get the User's total number of friends (including those who have not installed the app making the query)
	 * Permissions:
	 * a User access token with the following permissions: user_friends.
	 * https://developers.facebook.com/docs/graph-api/reference/user/friends 	
		 * @param id 
	 * @return {FacebookUserFriends} The person's friends 
		 * @throws Exception
		 */
		public FacebookUserFriends GetFieldsUserFriends(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserFriends>Call(FacebookUserFriends.class, "Facebook", bNesisToken, "GetFieldsUserFriends", id);
		}

		/**
		 *  Get the User's friends who have installed the app making the query.
	 * Get the User's total number of friends (including those who have not installed the app making the query)
	 * Permissions:
	 * a User access token with the following permissions: user_friends.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @param field The field. Example: string fields = "id,name,birthday".
	 * It is necessary to form fields independently.
	 * @return {FacebookUserFriends} The person's friends 
		 * @throws Exception
		 */
		public FacebookUserFriends GetFieldUserFriends(String id, String field) throws Exception
		{
			return _bNesisApi.<FacebookUserFriends>Call(FacebookUserFriends.class, "Facebook", bNesisToken, "GetFieldUserFriends", id, field);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/
	 * Permission 
	 * user_likes 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserGames} Games this person likes 
		 * @throws Exception
		 */
		public FacebookUserGames GetUserGames(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserGames>Call(FacebookUserGames.class, "Facebook", bNesisToken, "GetUserGames", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/
	 * Permission
	 * user_managed_groups 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserGroups} The Facebook Groups of which the person is an Admin. 
		 * @throws Exception
		 */
		public FacebookUserGroups GetUserGroups(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserGroups>Call(FacebookUserGroups.class, "Facebook", bNesisToken, "GetUserGroups", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserIDsForBusiness} Businesses can claim ownership of multiple apps using Business Manager. 
	 * This edge returns the list of IDs that this user has in any of those other apps 
		 * @throws Exception
		 */
		public FacebookUserIDsForBusiness GetUserIdsForBusiness(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserIDsForBusiness>Call(FacebookUserIDsForBusiness.class, "Facebook", bNesisToken, "GetUserIdsForBusiness", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/
	 * Permission:
	 * ads_read 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserLeadgenForms} A list of lead generation forms belonging to Pages that the user has advertiser permissions on 
		 * @throws Exception
		 */
		public FacebookUserLeadgenForms GetUserLeadgenForms(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserLeadgenForms>Call(FacebookUserLeadgenForms.class, "Facebook", bNesisToken, "GetUserLeadgenForms", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/
	 * Permission
	 * user_likes 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserLikes} All the Pages this person has liked 
		 * @throws Exception
		 */
		public FacebookUserLikes GetUserLikes(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserLikes>Call(FacebookUserLikes.class, "Facebook", bNesisToken, "GetUserLikes", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserLiveEncoders} Live encoders owned by this person 
		 * @throws Exception
		 */
		public FacebookUserLiveEncoders GetUserLiveEncoders(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserLiveEncoders>Call(FacebookUserLiveEncoders.class, "Facebook", bNesisToken, "GetUserLiveEncoders", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserLiveVideos} Live videos from this person 
		 * @throws Exception
		 */
		public FacebookUserLiveVideos GetUserLiveVideos(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserLiveVideos>Call(FacebookUserLiveVideos.class, "Facebook", bNesisToken, "GetUserLiveVideos", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/
	 * Permission: user_likes 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserMovies} Movies this person likes 
		 * @throws Exception
		 */
		public FacebookUserMovies GetUserMovies(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserMovies>Call(FacebookUserMovies.class, "Facebook", bNesisToken, "GetUserMovies", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/
	 * Permission: user_likes 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserMusic} Music this person likes 
		 * @throws Exception
		 */
		public FacebookUserMusic GetUserMusic(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserMusic>Call(FacebookUserMusic.class, "Facebook", bNesisToken, "GetUserMusic", id);
		}

		/**
		 *  Gets the user permissions.
	 * https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserPermissions} a list of granted and declined permissions. 
		 * @throws Exception
		 */
		public FacebookUserPermissions GetUserPremissions(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserPermissions>Call(FacebookUserPermissions.class, "Facebook", bNesisToken, "GetUserPremissions", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/
	 * Permission: user_photos 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserPhotos} Photos the person is tagged in or has uploaded 
		 * @throws Exception
		 */
		public FacebookUserPhotos GetUserPhotos(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserPhotos>Call(FacebookUserPhotos.class, "Facebook", bNesisToken, "GetUserPhotos", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserPicture} The person's profile picture 
		 * @throws Exception
		 */
		public FacebookUserPicture GetUserPicture(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserPicture>Call(FacebookUserPicture.class, "Facebook", bNesisToken, "GetUserPicture", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserRequestHistory} Developers' Graph API request history 
		 * @throws Exception
		 */
		public FacebookUserRequestHistory GetUserRequestHistory(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserRequestHistory>Call(FacebookUserRequestHistory.class, "Facebook", bNesisToken, "GetUserRequestHistory", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserRichMediaDocuments} A list of rich media documents belonging to Pages that the user has advertiser permissions on 
		 * @throws Exception
		 */
		public FacebookUserRichMediaDocuments GetUserRichMediaDocuments(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserRichMediaDocuments>Call(FacebookUserRichMediaDocuments.class, "Facebook", bNesisToken, "GetUserRichMediaDocuments", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserSessionKeys} Any session keys that the app knows the user by 
		 * @throws Exception
		 */
		public FacebookUserSessionKeys GetUserSessionKeys(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserSessionKeys>Call(FacebookUserSessionKeys.class, "Facebook", bNesisToken, "GetUserSessionKeys", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserStreamFilters} A list of filters that can be applied to the News Feed edge 
		 * @throws Exception
		 */
		public FacebookUserStreamFilters GetUserStreamFilters(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserStreamFilters>Call(FacebookUserStreamFilters.class, "Facebook", bNesisToken, "GetUserStreamFilters", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/
	 * Permission user_friends 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserTaggableFriends} Friends that can be tagged in content published via the Graph API 
		 * @throws Exception
		 */
		public FacebookUserTaggableFriends GetUserTaggableFriends(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserTaggableFriends>Call(FacebookUserTaggableFriends.class, "Facebook", bNesisToken, "GetUserTaggableFriends", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/
	 * Permission user_tagged_places 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserTaggedPlaces} List of tagged places for this person. It can include tags on videos, posts, statuses or links 
		 * @throws Exception
		 */
		public FacebookUserTaggedPlaces GetUserTaggedPlaces(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserTaggedPlaces>Call(FacebookUserTaggedPlaces.class, "Facebook", bNesisToken, "GetUserTaggedPlaces", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/
	 * Permission user_likes 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserTelevision} TV shows this person likes 
		 * @throws Exception
		 */
		public FacebookUserTelevision GetUserTelevision(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserTelevision>Call(FacebookUserTelevision.class, "Facebook", bNesisToken, "GetUserTelevision", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserVideoBroadcasts} Video broadcasts from this person 
		 * @throws Exception
		 */
		public FacebookUserVideoBroadcasts GetUserVideoBroadcasts(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserVideoBroadcasts>Call(FacebookUserVideoBroadcasts.class, "Facebook", bNesisToken, "GetUserVideoBroadcasts", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/
	 * Permission user_videos 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserVideos} Videos the person is tagged in or uploaded 
		 * @throws Exception
		 */
		public FacebookUserVideos GetUserVideos(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserVideos>Call(FacebookUserVideos.class, "Facebook", bNesisToken, "GetUserVideos", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/v2.12/user/feed
	 * Permission user_posts 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookFeed} The feed of posts (including status updates) and links published by this person. 
		 * @throws Exception
		 */
		public FacebookFeed GetUserFeed(String id) throws Exception
		{
			return _bNesisApi.<FacebookFeed>Call(FacebookFeed.class, "Facebook", bNesisToken, "GetUserFeed", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/v2.12/user/feed
	 * Requires either publish_actions permission, or manage_pages and publish_pages as an admin with sufficient administrative permission" 	
		 * @param id The identifier. "me" - current user
	 * @param message The main body of the post, otherwise called the status message.
	 * Either link, place, or message must be supplied.
	 * @param link The URL of a link to attach to the post.
	 * Either link, place, or message must be supplied. Additional fields associated with link are shown below.
	 * @return {FacebookPost} The feed of posts (including status updates) and links published by this person. 
		 * @throws Exception
		 */
		public FacebookPost PostUserFeed(String id, String message, String link) throws Exception
		{
			return _bNesisApi.<FacebookPost>Call(FacebookPost.class, "Facebook", bNesisToken, "PostUserFeed", id, message, link);
		}

		/**
		 *  Page Access Tokens 	
		 * @param id 
	 * @return {FacebookUserAccounts} a list of pages that the person administers along with other information about the Page,
	 * such as the Page category, the permissions the admin has for that Page, and the page access token.
	 * Permissions
	 * A Page access token for a User with a role(other than Live Contributor) on the Page and the following permissions:
	 * manage_pages or pages_show_list 
		 * @throws Exception
		 */
		public FacebookUserAccounts GetPageAccessToken(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserAccounts>Call(FacebookUserAccounts.class, "Facebook", bNesisToken, "GetPageAccessToken", id);
		}

		/**
		 *  Generates an App Access Token 	
		 * @return {FacebookAppToken} app Access Token 
		 * @throws Exception
		 */
		public FacebookAppToken GetAppAccessToken() throws Exception
		{
			return _bNesisApi.<FacebookAppToken>Call(FacebookAppToken.class, "Facebook", bNesisToken, "GetAppAccessToken");
		}

		/**
		 *  Checks the token in the service. 	
		 * @return {FacebookDebug} data with information about the token 
		 * @throws Exception
		 */
		public FacebookDebug ValidationToken() throws Exception
		{
			return _bNesisApi.<FacebookDebug>Call(FacebookDebug.class, "Facebook", bNesisToken, "ValidationToken");
		}

		/**
		 *  Represents current person on Facebook 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} information about current user 
		 * @throws Exception
		 */
		public Response GetFieldsUserRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetFieldsUserRaw", id);
		}

		/**
		 *  Represents current person on Facebook. 
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @param field The field. Example: string fields = "id,name,birthday".
	 * It is necessary to form fields independently.
	 * @return {Response} information about current user 
		 * @throws Exception
		 */
		public Response GetFieldUserRaw(String id, String field) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetFieldUserRaw", id, field);
		}

		/**
		 *  Represents current person on Facebook.
	 * Equivalent to the bio field
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Equivalent to the bio field 
		 * @throws Exception
		 */
		public Response GetUserAboutRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserAboutRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * The id of this person's user account. This ID is unique to each app and cannot be used across different apps
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @return {Response} id 
		 * @throws Exception
		 */
		public Response GetUserIdRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserIdRaw");
		}

		/**
		 *  Represents current person on Facebook.
	 * The person's current location as entered by them on their profile. This field is not related to check-ins
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The person's address 
		 * @throws Exception
		 */
		public Response GetUserAddressRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserAddressRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * The age segment for this person expressed as a minimum and maximum age. For example, more than 18, less than 21.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} age range 
		 * @throws Exception
		 */
		public Response GetUserAgeRangeRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserAgeRangeRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * The person's birthday. This is a fixed format string, like MM/DD/YYYY. 
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} birthday 
		 * @throws Exception
		 */
		public Response GetUserBirthdayRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserBirthdayRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Can the person review brand polls 
		 * @throws Exception
		 */
		public Response GetUserCanReviewMeasurementRequestRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserCanReviewMeasurementRequestRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Social context for this person 
		 * @throws Exception
		 */
		public Response GetUserContextRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserContextRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The person's cover photo 
		 * @throws Exception
		 */
		public Response GetUserCoverRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserCoverRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The person's local currency information 
		 * @throws Exception
		 */
		public Response GetUserCurrencyRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserCurrencyRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The list of devices the person is using. This will return only iOS and Android devices 
		 * @throws Exception
		 */
		public Response GetUserDevicesRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserDevicesRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The person's education 
		 * @throws Exception
		 */
		public Response GetUserEducationRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserEducationRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The person's primary email address listed on their profile. 
	 * This field will not be returned if no valid email address is available 
		 * @throws Exception
		 */
		public Response GetUserEmailRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserEmailRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Athletes the person likes 
		 * @throws Exception
		 */
		public Response GetUserFavoriteAthletesRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserFavoriteAthletesRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Sports teams the person likes 
		 * @throws Exception
		 */
		public Response GetUserFavoriteTeamsRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserFavoriteTeamsRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The person's first and last name 
		 * @throws Exception
		 */
		public Response GetUserFirstMiddleLastNameRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserFirstMiddleLastNameRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The gender selected by this person, male or female. 
	 * If the gender is set to a custom value, this value will be based off of the preferred pronoun; 
	 * it will be omitted if the preferred preferred pronoun is neutral 
		 * @throws Exception
		 */
		public Response GetUserGenderRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserGenderRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The person's hometown 
		 * @throws Exception
		 */
		public Response GetUserHometownRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserHometownRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The person's inspirational people 
		 * @throws Exception
		 */
		public Response GetUserInspirationalPeopleRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserInspirationalPeopleRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Install type 
		 * @throws Exception
		 */
		public Response GetUserInstallTypeRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserInstallTypeRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Is the app making the request installed? 
		 * @throws Exception
		 */
		public Response GetUserInstalledRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserInstalledRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Genders the person is interested in 
		 * @throws Exception
		 */
		public Response GetUserInterestedInRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserInterestedInRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Is this a shared login (e.g. a gray user) 
		 * @throws Exception
		 */
		public Response GetUserIsSharedLoginRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserIsSharedLoginRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} People with large numbers of followers can have the authenticity of their identity manually verified by Facebook. 
	 * This field indicates whether the person's profile is verified in this way. 
	 * This is distinct from the verified field 
		 * @throws Exception
		 */
		public Response GetUserIsVerifiedRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserIsVerifiedRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} Facebook Pages representing the languages this person knows 
		 * @throws Exception
		 */
		public Response GetUserLanguagesRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserLanguagesRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} A link to the person's Timeline 
		 * @throws Exception
		 */
		public Response GetUserLinkRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserLinkRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} The person's locale 
		 * @throws Exception
		 */
		public Response GetUserLocaleRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserLocaleRaw", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * The person's current location as entered by them on their profile. This field is not related to check-ins
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {Response} location 
		 * @throws Exception
		 */
		public Response GetUserLocationRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Facebook", bNesisToken, "GetUserLocationRaw", id);
		}

		/**
		 *  Represents current person on Facebook 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} information about current user 
		 * @throws Exception
		 */
		public FacebookUser GetFieldsUser(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetFieldsUser", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @param field The field. Example: string fields = "id,name,birthday".
	 * It is necessary to form fields independently.
	 * @return {FacebookUser} information about current user 
		 * @throws Exception
		 */
		public FacebookUser GetFieldUser(String id, String field) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetFieldUser", id, field);
		}

		/**
		 *  Represents current person on Facebook.
	 * Equivalent to the bio field
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Equivalent to the bio field 
		 * @throws Exception
		 */
		public FacebookUser GetUserAbout(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserAbout", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * The id of this person's user account. This ID is unique to each app and cannot be used across different apps
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @return {FacebookUser} id 
		 * @throws Exception
		 */
		public FacebookUser GetUserId() throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserId");
		}

		/**
		 *  Represents current person on Facebook.
	 * The person's current location as entered by them on their profile. This field is not related to check-ins
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's address 
		 * @throws Exception
		 */
		public FacebookUser GetUserAddress(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserAddress", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * The age segment for this person expressed as a minimum and maximum age. For example, more than 18, less than 21.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} age range 
		 * @throws Exception
		 */
		public FacebookUser GetUserAgeRange(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserAgeRange", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * The person's birthday. This is a fixed format string, like MM/DD/YYYY.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} birthday 
		 * @throws Exception
		 */
		public FacebookUser GetUserBirthday(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserBirthday", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Can the person review brand polls 
		 * @throws Exception
		 */
		public FacebookUser GetUserCanReviewMeasurementRequest(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserCanReviewMeasurementRequest", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id 
	 * @return {FacebookUser} Social context for this person 
		 * @throws Exception
		 */
		public FacebookUser GetUserContext(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserContext", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's cover photo 
		 * @throws Exception
		 */
		public FacebookUser GetUserCover(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserCover", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's local currency information 
		 * @throws Exception
		 */
		public FacebookUser GetUserCurrency(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserCurrency", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The list of devices the person is using. This will return only iOS and Android devices 
		 * @throws Exception
		 */
		public FacebookUser GetUserDevices(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserDevices", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's education 
		 * @throws Exception
		 */
		public FacebookUser GetUserEducation(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserEducation", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's primary email address listed on their profile. 
	 * This field will not be returned if no valid email address is available 
		 * @throws Exception
		 */
		public FacebookUser GetUserEmail(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserEmail", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Athletes the person likes 
		 * @throws Exception
		 */
		public FacebookUser GetUserFavoriteAthletes(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserFavoriteAthletes", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Sports teams the person likes 
		 * @throws Exception
		 */
		public FacebookUser GetUserFavoriteTeams(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserFavoriteTeams", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's first and last name 
		 * @throws Exception
		 */
		public FacebookUser GetUserFirstMiddleLastName(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserFirstMiddleLastName", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The gender selected by this person, male or female. 
	 * If the gender is set to a custom value, this value will be based off of the preferred pronoun; 
	 * it will be omitted if the preferred preferred pronoun is neutral 
		 * @throws Exception
		 */
		public FacebookUser GetUserGender(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserGender", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's hometown 
		 * @throws Exception
		 */
		public FacebookUser GetUserHometown(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserHometown", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's inspirational people 
		 * @throws Exception
		 */
		public FacebookUser GetUserInspirationalPeople(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserInspirationalPeople", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Install type 
		 * @throws Exception
		 */
		public FacebookUser GetUserInstallType(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserInstallType", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Is the app making the request installed? 
		 * @throws Exception
		 */
		public FacebookUser GetUserInstalled(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserInstalled", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Genders the person is interested in 
		 * @throws Exception
		 */
		public FacebookUser GetUserInterestedIn(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserInterestedIn", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Is this a shared login (e.g. a gray user) 
		 * @throws Exception
		 */
		public FacebookUser GetUserIsSharedLogin(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserIsSharedLogin", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} People with large numbers of followers can have the authenticity of their identity manually verified by Facebook. 
	 * This field indicates whether the person's profile is verified in this way. 
	 * This is distinct from the verified field 
		 * @throws Exception
		 */
		public FacebookUser GetUserIsVerified(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserIsVerified", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Facebook Pages representing the languages this person knows 
		 * @throws Exception
		 */
		public FacebookUser GetUserLanguages(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserLanguages", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} A link to the person's Timeline 
		 * @throws Exception
		 */
		public FacebookUser GetUserLink(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserLink", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's locale 
		 * @throws Exception
		 */
		public FacebookUser GetUserLocale(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserLocale", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * The person's current location as entered by them on their profile. This field is not related to check-ins
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} location 
		 * @throws Exception
		 */
		public FacebookUser GetUserLocation(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserLocation", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} What the person is interested in meeting for 
		 * @throws Exception
		 */
		public FacebookUser GetUserMeetingFor(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserMeetingFor", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's name formatted to correctly handle Chinese, Japanese, or Korean ordering 
		 * @throws Exception
		 */
		public FacebookUser GetUserNameFormat(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserNameFormat", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's payment pricepoints 
		 * @throws Exception
		 */
		public FacebookUser GetUserPaymentPricepoints(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserPaymentPricepoints", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's political views 
		 * @throws Exception
		 */
		public FacebookUser GetUserPolitical(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserPolitical", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's PGP public key 
		 * @throws Exception
		 */
		public FacebookUser GetUserPublicKey(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserPublicKey", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's favorite quotes 
		 * @throws Exception
		 */
		public FacebookUser GetUserQuotes(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserQuotes", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's relationship status 
		 * @throws Exception
		 */
		public FacebookUser GetUserRelationshipStatus(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserRelationshipStatus", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's religion 
		 * @throws Exception
		 */
		public FacebookUser GetUserReligion(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserReligion", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Security settings 
		 * @throws Exception
		 */
		public FacebookUser GetUserSecuritySettings(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserSecuritySettings", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Security settings 
		 * @throws Exception
		 */
		public FacebookUser GetUserSharedLoginUpgradeRequiredBy(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserSharedLoginUpgradeRequiredBy", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Security settings 
		 * @throws Exception
		 */
		public FacebookUser GetUserShortName(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserShortName", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's significant other 
		 * @throws Exception
		 */
		public FacebookUser GetUserSignificantOther(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserSignificantOther", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Sports played by the person 
		 * @throws Exception
		 */
		public FacebookUser GetUserSports(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserSports", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Platform test group 
		 * @throws Exception
		 */
		public FacebookUser GetUserTestGroup(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserTestGroup", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} A string containing an anonymous, but unique identifier for the person. You can use this identifier with third parties 
		 * @throws Exception
		 */
		public FacebookUser GetUserThirdPartyId(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserThirdPartyId", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's current timezone offset from UTC 
		 * @throws Exception
		 */
		public FacebookUser GetUserTimezone(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserTimezone", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Updated time 
		 * @throws Exception
		 */
		public FacebookUser GetUserUpdatedTime(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserUpdatedTime", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Updated time 
		 * @throws Exception
		 */
		public FacebookUser GetUserUserRef(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserUserRef", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Indicates whether the account has been verified. 
	 * This is distinct from the is_verified field. Someone is considered verified if they take any of the following actions: 
		 * @throws Exception
		 */
		public FacebookUser GetUserVerified(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserVerified", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Video upload limits 
		 * @throws Exception
		 */
		public FacebookUser GetUserVideoUploadLimits(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserVideoUploadLimits", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Video upload limits 
		 * @throws Exception
		 */
		public FacebookUser GetUserViewerCanSendGift(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserViewerCanSendGift", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's website 
		 * @throws Exception
		 */
		public FacebookUser GetUserWebsite(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserWebsite", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's website 
		 * @throws Exception
		 */
		public FacebookUser GetUserWork(String id) throws Exception
		{
			return _bNesisApi.<FacebookUser>Call(FacebookUser.class, "Facebook", bNesisToken, "GetUserWork", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/accounts/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserAccounts} Pages this User has a role on. 
		 * @throws Exception
		 */
		public FacebookUserAccounts GetUserAccounts(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserAccounts>Call(FacebookUserAccounts.class, "Facebook", bNesisToken, "GetUserAccounts", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/achievements/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserAchievements} Achievements made in Facebook games 
		 * @throws Exception
		 */
		public FacebookUserAchievements GetUserAchievements(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserAchievements>Call(FacebookUserAchievements.class, "Facebook", bNesisToken, "GetUserAchievements", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserAdStudies} Ad studies that this person can view 
		 * @throws Exception
		 */
		public FacebookUserAdStudies GetUserAdStudies(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserAdStudies>Call(FacebookUserAdStudies.class, "Facebook", bNesisToken, "GetUserAdStudies", id);
		}

		/**
		 *  The advertising accounts to which this person has access.
	 * https://developers.facebook.com/docs/graph-api/reference/user/adaccounts/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserAdaccounts} The advertising accounts to which this person has access 
		 * @throws Exception
		 */
		public FacebookUserAdaccounts GetUserAdAccounts(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserAdaccounts>Call(FacebookUserAdaccounts.class, "Facebook", bNesisToken, "GetUserAdAccounts", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserAdnetworkanalytics} Insights data for the person's Audience Network apps 
		 * @throws Exception
		 */
		public FacebookUserAdnetworkanalytics GetUserAdNetWorkanalytics(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserAdnetworkanalytics>Call(FacebookUserAdnetworkanalytics.class, "Facebook", bNesisToken, "GetUserAdNetWorkanalytics", id);
		}

		/**
		 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/v2.12/album 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserAlbums} The photo albums this person has created 
		 * @throws Exception
		 */
		public FacebookUserAlbums GetUserAlbums(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserAlbums>Call(FacebookUserAlbums.class, "Facebook", bNesisToken, "GetUserAlbums", id);
		}

		/**
		 *  App requests
	 * https://developers.facebook.com/docs/graph-api/reference/user/apprequestformerrecipients/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookApprequestformerrecipients} App requests 
		 * @throws Exception
		 */
		public FacebookApprequestformerrecipients GetUserApprequestForMerrecipients(String id) throws Exception
		{
			return _bNesisApi.<FacebookApprequestformerrecipients>Call(FacebookApprequestformerrecipients.class, "Facebook", bNesisToken, "GetUserApprequestForMerrecipients", id);
		}

		/**
		 *  This person's pending requests from an app
	 * https://developers.facebook.com/docs/graph-api/reference/user/apprequests/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserApprequests} This person's pending requests from an app 
		 * @throws Exception
		 */
		public FacebookUserApprequests GetUserAppRequests(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserApprequests>Call(FacebookUserApprequests.class, "Facebook", bNesisToken, "GetUserAppRequests", id);
		}

		/**
		 *  The 3D assets owned by the user
	 * https://developers.facebook.com/docs/graph-api/reference/user/asset3ds/ 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserAsset3ds} The 3D assets owned by the user 
		 * @throws Exception
		 */
		public FacebookUserAsset3ds GetUserAsset3Ds(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserAsset3ds>Call(FacebookUserAsset3ds.class, "Facebook", bNesisToken, "GetUserAsset3Ds", id);
		}

		/**
		 *  The books listed on this person's profile
	 * https://developers.facebook.com/docs/graph-api/reference/user/books/
	 * Permissions
	 * Developers usually request these permissions for this endpoint:
	 * Marketing Apps
	 * No data
	 * Page management Apps
	 * No data
	 * Other Apps
	 * user_likes 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserBooks} The books listed on this person's profile 
		 * @throws Exception
		 */
		public FacebookUserBooks GetUserBooks(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserBooks>Call(FacebookUserBooks.class, "Facebook", bNesisToken, "GetUserBooks", id);
		}

		/**
		 *  Business users corresponding to the user
	 * https://developers.facebook.com/docs/graph-api/reference/user/business_users/
	 * Permission business_management 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserBusinessUsers} Business users corresponding to the user 
		 * @throws Exception
		 */
		public FacebookUserBusinessUsers GetUserBusinessUsers(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserBusinessUsers>Call(FacebookUserBusinessUsers.class, "Facebook", bNesisToken, "GetUserBusinessUsers", id);
		}

		/**
		 *  Businesses associated with the user
	 * https://developers.facebook.com/docs/graph-api/reference/user/businesses/
	 * Permissions
	 * Developers usually request these permissions for this endpoint:
	 * Marketing Apps
	 * ads_management
	 * ads_read
	 * manage_pages
	 * business_management
	 * Page management Apps
	 * No data
	 * Other Apps
	 * No data 	
		 * @param id The identifier. "me" - current user
	 * @return {FacebookUserBusinesses} Businesses associated with the user 
		 * @throws Exception
		 */
		public FacebookUserBusinesses GetUserBusinesses(String id) throws Exception
		{
			return _bNesisApi.<FacebookUserBusinesses>Call(FacebookUserBusinesses.class, "Facebook", bNesisToken, "GetUserBusinesses", id);
		}
}