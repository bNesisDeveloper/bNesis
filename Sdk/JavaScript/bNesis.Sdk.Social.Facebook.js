Facebook = function (bNesisApi) {
    this.bNesisToken = null;
    var _bNesisApi = bNesisApi;

    /**
     * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
	 * or Attach to bNesis session with exists bNesis token
     * @return {string} bNesisToken value | true if bNesisToken is valid
	 */
    this.Auth = function (bNesisDevId,clientId,clientSecret,redirectUrl,scopes) {
		if(arguments.length !== 1){
			var bNesisToken = _bNesisApi.Auth("Facebook", "",bNesisDevId,redirectUrl,clientId,clientSecret,scopes,"","",false,"");
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
		var result = _bNesisApi.LogoffService("Facebook", this.bNesisToken);
		if (result) this.bNesisToken = "";
		return result;             
    }
	
	/**
	 *  Getting last exception for current provider 	
	 * @return {ErrorInfo} 
	 */
    this.GetLastError = function () {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetLastError");
        return result;
    }

	/**
	 *  Getting arrays of error info 	
	 * @return {ErrorInfo[]} 
	 */
    this.GetErrorLog = function () {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetErrorLog");
        return result;
    }

	/**
	 *  Checks the token in the service. 	
	 * @return {Boolean} if token valid return true, if token not valid return false
	 */
    this.ValidateToken = function () {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "ValidateToken");
        return result;
    }

	/**
	 *  Disables the access token used to authenticate the call. 	
	 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false
	 */
    this.Logoff = function () {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "Logoff");
        return result;
    }

	/**
	 *   	
	 * @param id 
	 * @return {ContactItem} 
	 */
    this.GetFieldsUserUnified = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetFieldsUserUnified", id);
        return result;
    }

	/**
	 *   	
	 * @param id 
	 * @param field 
	 * @return {ContactItem} 
	 */
    this.GetFieldUserUnified = function (id, field) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetFieldUserUnified", id, field);
        return result;
    }

	/**
	 *   	
	 * @param id 
	 * @return {ContactItem} 
	 */
    this.GetUserAboutUnified = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserAboutUnified", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Videos the person is tagged in or uploaded
	 */
    this.GetUserVideosRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserVideosRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The feed of posts (including status updates) and links published by this person.
	 */
    this.GetUserFeedRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserFeedRaw", id);
        return result;
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
	 */
    this.PostUserFeedRaw = function (id, message, link) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "PostUserFeedRaw", id, message, link);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The scores this person has received from Facebook Games that they've played.
	 */
    this.GetUserScoresRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserScoresRaw", id);
        return result;
    }

	/**
	 *  Page Access Tokens 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} a list of pages that the person administers along with other information about the Page, 
	 * such as the Page category, the permissions the admin has for that Page, and the page access token.
	 */
    this.GetPageAccessTokenRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetPageAccessTokenRaw", id);
        return result;
    }

	/**
	 *  Generates an App Access Token 	
	 * @return {Response} app Access Token
	 */
    this.GetAppAccessTokenRaw = function () {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetAppAccessTokenRaw");
        return result;
    }

	/**
	 *  Checks the token in the service. 	
	 * @return {Response} data with information about the token
	 */
    this.ValidationTokenRaw = function () {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "ValidationTokenRaw");
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} What the person is interested in meeting for
	 */
    this.GetUserMeetingForRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserMeetingForRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The person's name formatted to correctly handle Chinese, Japanese, or Korean ordering
	 */
    this.GetUserNameFormatRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserNameFormatRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The person's payment pricepoints
	 */
    this.GetUserPaymentPricepointsRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserPaymentPricepointsRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The person's political views
	 */
    this.GetUserPoliticalRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserPoliticalRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The person's PGP public key
	 */
    this.GetUserPublicKeyRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserPublicKeyRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The person's favorite quotes
	 */
    this.GetUserQuotesRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserQuotesRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The person's relationship status
	 */
    this.GetUserRelationshipStatusRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserRelationshipStatusRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The person's religion
	 */
    this.GetUserReligionRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserReligionRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Security settings
	 */
    this.GetUserSecuritySettingsRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserSecuritySettingsRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Security settings
	 */
    this.GetUserSharedLoginUpgradeRequiredByRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserSharedLoginUpgradeRequiredByRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Shortened, locale-aware name for the person
	 */
    this.GetUserShortNameRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserShortNameRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The person's significant other
	 */
    this.GetUserSignificantOtherRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserSignificantOtherRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Sports played by the person
	 */
    this.GetUserSportsRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserSportsRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Platform test group
	 */
    this.GetUserTestGroupRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserTestGroupRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} A string containing an anonymous, but unique identifier for the person. You can use this identifier with third parties
	 */
    this.GetUserThirdPartyIdRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserThirdPartyIdRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The person's current timezone offset from UTC
	 */
    this.GetUserTimezoneRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserTimezoneRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Updated time
	 */
    this.GetUserUpdatedTimeRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserUpdatedTimeRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Latest user ref that matches a given PSID that should be invalidated. 
	 * This should only be used for anonymous messaging PSID migration
	 */
    this.GetUserUserRefRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserUserRefRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Indicates whether the account has been verified. 
	 * This is distinct from the is_verified field. Someone is considered verified if they take any of the following actions:
	 */
    this.GetUserVerifiedRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserVerifiedRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Video upload limits
	 */
    this.GetUserVideoUploadLimitsRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserVideoUploadLimitsRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Can the viewer send a gift to this person?
	 */
    this.GetUserViewerCanSendGiftRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserViewerCanSendGiftRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The person's website
	 */
    this.GetUserWebsiteRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserWebsiteRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The person's website
	 */
    this.GetUserWorkRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserWorkRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Pages this User has a role on.
	 */
    this.GetUserAccountsRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserAccountsRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Achievements made in Facebook games
	 */
    this.GetUserAchievementsRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserAchievementsRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Ad studies that this person can view
	 */
    this.GetUserAdStudiesRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserAdStudiesRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The advertising accounts to which this person has access
	 */
    this.GetUserAdAccountsRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserAdAccountsRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Insights data for the person's Audience Network apps
	 */
    this.GetUserAdNetWorkanalyticsRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserAdNetWorkanalyticsRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The photo albums this person has created
	 */
    this.GetUserAlbumsRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserAlbumsRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} App requests
	 */
    this.GetUserApprequestForMerrecipientsRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserApprequestForMerrecipientsRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} This person's pending requests from an app
	 */
    this.GetUserAppRequestsRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserAppRequestsRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The 3D assets owned by the user
	 */
    this.GetUserAsset3DsRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserAsset3DsRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The books listed on this person's profile
	 */
    this.GetUserBooksRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserBooksRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Business users corresponding to the user
	 */
    this.GetUserBusinessUsersRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserBusinessUsersRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Businesses associated with the user
	 */
    this.GetUserBusinessesRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserBusinessesRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The curated collections created by this user
	 */
    this.GetUserCuratedCollectionsRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserCuratedCollectionsRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} custom labels
	 */
    this.GetUserCustomLabelsRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserCustomLabelsRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The domains the user admins
	 */
    this.GetUserDomainsRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserDomainsRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Events for this person.By default this does not include events the person has declined or not replied to
	 */
    this.GetUserEventsRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserEventsRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} This person's family relationships.
	 */
    this.GetUserFamilyRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserFamilyRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Developers' favorite requests to the Graph API
	 */
    this.GetUserFavoriteRequestsRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserFavoriteRequestsRaw", id);
        return result;
    }

	/**
	 *  A person's custom friend lists.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} A person's custom friend lists.
	 */
    this.GetUserFriendlistsRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserFriendlistsRaw", id);
        return result;
    }

	/**
	 *  Get the User's friends who have installed the app making the query.
	 * Get the User's total number of friends (including those who have not installed the app making the query)
	 * Permissions:
	 * a User access token with the following permissions: user_friends.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The person's friends
	 */
    this.GetFieldsUserFriendsRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetFieldsUserFriendsRaw", id);
        return result;
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
	 */
    this.GetFieldUserFriendsRaw = function (id, field) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetFieldUserFriendsRaw", id, field);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Games this person likes
	 */
    this.GetUserGamesRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserGamesRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The Facebook Groups of which the person is an Admin.
	 */
    this.GetUserGroupsRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserGroupsRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Businesses can claim ownership of multiple apps using Business Manager. 
	 * This edge returns the list of IDs that this user has in any of those other apps
	 */
    this.GetUserIdsForBusinessRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserIdsForBusinessRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} A list of lead generation forms belonging to Pages that the user has advertiser permissions on
	 */
    this.GetUserLeadgenFormsRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserLeadgenFormsRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} All the Pages this person has liked
	 */
    this.GetUserLikesRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserLikesRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Live encoders owned by this person
	 */
    this.GetUserLiveEncodersRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserLiveEncodersRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Live videos from this person
	 */
    this.GetUserLiveVideosRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserLiveVideosRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Movies this person likes
	 */
    this.GetUserMoviesRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserMoviesRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Music this person likes
	 */
    this.GetUserMusicRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserMusicRaw", id);
        return result;
    }

	/**
	 *  Gets the user premissions.
	 * https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} a list of granted and declined permissions.
	 */
    this.GetUserPremissionsRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserPremissionsRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Photos the person is tagged in or has uploaded
	 */
    this.GetUserPhotosRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserPhotosRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The person's profile picture
	 */
    this.GetUserPictureRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserPictureRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Developers' Graph API request history
	 */
    this.GetUserRequestHistoryRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserRequestHistoryRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} A list of rich media documents belonging to Pages that the user has advertiser permissions on
	 */
    this.GetUserRichMediaDocumentsRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserRichMediaDocumentsRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Any session keys that the app knows the user by
	 */
    this.GetUserSessionKeysRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserSessionKeysRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} A list of filters that can be applied to the News Feed edge
	 */
    this.GetUserStreamFiltersRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserStreamFiltersRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Friends that can be tagged in content published via the Graph API
	 */
    this.GetUserTaggableFriendsRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserTaggableFriendsRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} List of tagged places for this person. It can include tags on videos, posts, statuses or links
	 */
    this.GetUserTaggedPlacesRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserTaggedPlacesRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} TV shows this person likes
	 */
    this.GetUserTelevisionRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserTelevisionRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Video broadcasts from this person
	 */
    this.GetUserVideoBroadcastsRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserVideoBroadcastsRaw", id);
        return result;
    }

	/**
	 *  The curated collections created by this user
	 * https://developers.facebook.com/docs/graph-api/reference/user/curated_collections/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserCuratedCollections} The curated collections created by this user
	 */
    this.GetUserCuratedCollections = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserCuratedCollections", id);
        return result;
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
	 */
    this.GetUserCustomLabels = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserCustomLabels", id);
        return result;
    }

	/**
	 *  The domains the user admins
	 * https://developers.facebook.com/docs/graph-api/reference/user/domains/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserDomains} The domains the user admins
	 */
    this.GetUserDomains = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserDomains", id);
        return result;
    }

	/**
	 *  Events for this person. By default this does not include events the person has declined or not replied to
	 * https://developers.facebook.com/docs/graph-api/reference/user/events/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserEvents} Events for this person.By default this does not include events the person has declined or not replied to
	 */
    this.GetUserEvents = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserEvents", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserFamily} This person's family relationships.
	 */
    this.GetUserFamily = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserFamily", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserFavoriteRequests} Developers' favorite requests to the Graph API
	 */
    this.GetUserFavoriteRequests = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserFavoriteRequests", id);
        return result;
    }

	/**
	 *  A person's custom friend lists.
	 * https://developers.facebook.com/docs/graph-api/reference/user/friendlists/ 	
	 * @param id 
	 * @return {FacebookUserFriendlists} A person's custom friend lists.
	 */
    this.GetUserFriendlists = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserFriendlists", id);
        return result;
    }

	/**
	 *  Get the User's friends who have installed the app making the query.
	 * Get the User's total number of friends (including those who have not installed the app making the query)
	 * Permissions:
	 * a User access token with the following permissions: user_friends.
	 * https://developers.facebook.com/docs/graph-api/reference/user/friends 	
	 * @param id 
	 * @return {FacebookUserFriends} The person's friends
	 */
    this.GetFieldsUserFriends = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetFieldsUserFriends", id);
        return result;
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
	 */
    this.GetFieldUserFriends = function (id, field) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetFieldUserFriends", id, field);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/
	 * Permission 
	 * user_likes 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserGames} Games this person likes
	 */
    this.GetUserGames = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserGames", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/
	 * Permission
	 * user_managed_groups 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserGroups} The Facebook Groups of which the person is an Admin.
	 */
    this.GetUserGroups = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserGroups", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserIDsForBusiness} Businesses can claim ownership of multiple apps using Business Manager. 
	 * This edge returns the list of IDs that this user has in any of those other apps
	 */
    this.GetUserIdsForBusiness = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserIdsForBusiness", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/
	 * Permission:
	 * ads_read 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserLeadgenForms} A list of lead generation forms belonging to Pages that the user has advertiser permissions on
	 */
    this.GetUserLeadgenForms = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserLeadgenForms", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/
	 * Permission
	 * user_likes 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserLikes} All the Pages this person has liked
	 */
    this.GetUserLikes = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserLikes", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserLiveEncoders} Live encoders owned by this person
	 */
    this.GetUserLiveEncoders = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserLiveEncoders", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserLiveVideos} Live videos from this person
	 */
    this.GetUserLiveVideos = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserLiveVideos", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/
	 * Permission: user_likes 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserMovies} Movies this person likes
	 */
    this.GetUserMovies = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserMovies", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/
	 * Permission: user_likes 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserMusic} Music this person likes
	 */
    this.GetUserMusic = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserMusic", id);
        return result;
    }

	/**
	 *  Gets the user permissions.
	 * https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserPermissions} a list of granted and declined permissions.
	 */
    this.GetUserPremissions = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserPremissions", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/
	 * Permission: user_photos 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserPhotos} Photos the person is tagged in or has uploaded
	 */
    this.GetUserPhotos = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserPhotos", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserPicture} The person's profile picture
	 */
    this.GetUserPicture = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserPicture", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserRequestHistory} Developers' Graph API request history
	 */
    this.GetUserRequestHistory = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserRequestHistory", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserRichMediaDocuments} A list of rich media documents belonging to Pages that the user has advertiser permissions on
	 */
    this.GetUserRichMediaDocuments = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserRichMediaDocuments", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserSessionKeys} Any session keys that the app knows the user by
	 */
    this.GetUserSessionKeys = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserSessionKeys", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserStreamFilters} A list of filters that can be applied to the News Feed edge
	 */
    this.GetUserStreamFilters = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserStreamFilters", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/
	 * Permission user_friends 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserTaggableFriends} Friends that can be tagged in content published via the Graph API
	 */
    this.GetUserTaggableFriends = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserTaggableFriends", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/
	 * Permission user_tagged_places 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserTaggedPlaces} List of tagged places for this person. It can include tags on videos, posts, statuses or links
	 */
    this.GetUserTaggedPlaces = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserTaggedPlaces", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/
	 * Permission user_likes 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserTelevision} TV shows this person likes
	 */
    this.GetUserTelevision = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserTelevision", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserVideoBroadcasts} Video broadcasts from this person
	 */
    this.GetUserVideoBroadcasts = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserVideoBroadcasts", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/
	 * Permission user_videos 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserVideos} Videos the person is tagged in or uploaded
	 */
    this.GetUserVideos = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserVideos", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/v2.12/user/feed
	 * Permission user_posts 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookFeed} The feed of posts (including status updates) and links published by this person.
	 */
    this.GetUserFeed = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserFeed", id);
        return result;
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
	 */
    this.PostUserFeed = function (id, message, link) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "PostUserFeed", id, message, link);
        return result;
    }

	/**
	 *  Page Access Tokens 	
	 * @param id 
	 * @return {FacebookUserAccounts} a list of pages that the person administers along with other information about the Page,
	 * such as the Page category, the permissions the admin has for that Page, and the page access token.
	 * Permissions
	 * A Page access token for a User with a role(other than Live Contributor) on the Page and the following permissions:
	 * manage_pages or pages_show_list
	 */
    this.GetPageAccessToken = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetPageAccessToken", id);
        return result;
    }

	/**
	 *  Generates an App Access Token 	
	 * @return {FacebookAppToken} app Access Token
	 */
    this.GetAppAccessToken = function () {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetAppAccessToken");
        return result;
    }

	/**
	 *  Checks the token in the service. 	
	 * @return {FacebookDebug} data with information about the token
	 */
    this.ValidationToken = function () {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "ValidationToken");
        return result;
    }

	/**
	 *  Represents current person on Facebook 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} information about current user
	 */
    this.GetFieldsUserRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetFieldsUserRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook. 
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @param field The field. Example: string fields = "id,name,birthday".
	 * It is necessary to form fields independently.
	 * @return {Response} information about current user
	 */
    this.GetFieldUserRaw = function (id, field) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetFieldUserRaw", id, field);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * Equivalent to the bio field
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Equivalent to the bio field
	 */
    this.GetUserAboutRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserAboutRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * The id of this person's user account. This ID is unique to each app and cannot be used across different apps
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @return {Response} id
	 */
    this.GetUserIdRaw = function () {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserIdRaw");
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * The person's current location as entered by them on their profile. This field is not related to check-ins
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The person's address
	 */
    this.GetUserAddressRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserAddressRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * The age segment for this person expressed as a minimum and maximum age. For example, more than 18, less than 21.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} age range
	 */
    this.GetUserAgeRangeRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserAgeRangeRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * The person's birthday. This is a fixed format string, like MM/DD/YYYY. 
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} birthday
	 */
    this.GetUserBirthdayRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserBirthdayRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Can the person review brand polls
	 */
    this.GetUserCanReviewMeasurementRequestRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserCanReviewMeasurementRequestRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Social context for this person
	 */
    this.GetUserContextRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserContextRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The person's cover photo
	 */
    this.GetUserCoverRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserCoverRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The person's local currency information
	 */
    this.GetUserCurrencyRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserCurrencyRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The list of devices the person is using. This will return only iOS and Android devices
	 */
    this.GetUserDevicesRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserDevicesRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The person's education
	 */
    this.GetUserEducationRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserEducationRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The person's primary email address listed on their profile. 
	 * This field will not be returned if no valid email address is available
	 */
    this.GetUserEmailRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserEmailRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Athletes the person likes
	 */
    this.GetUserFavoriteAthletesRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserFavoriteAthletesRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Sports teams the person likes
	 */
    this.GetUserFavoriteTeamsRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserFavoriteTeamsRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The person's first and last name
	 */
    this.GetUserFirstMiddleLastNameRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserFirstMiddleLastNameRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The gender selected by this person, male or female. 
	 * If the gender is set to a custom value, this value will be based off of the preferred pronoun; 
	 * it will be omitted if the preferred preferred pronoun is neutral
	 */
    this.GetUserGenderRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserGenderRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The person's hometown
	 */
    this.GetUserHometownRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserHometownRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The person's inspirational people
	 */
    this.GetUserInspirationalPeopleRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserInspirationalPeopleRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Install type
	 */
    this.GetUserInstallTypeRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserInstallTypeRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Is the app making the request installed?
	 */
    this.GetUserInstalledRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserInstalledRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Genders the person is interested in
	 */
    this.GetUserInterestedInRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserInterestedInRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Is this a shared login (e.g. a gray user)
	 */
    this.GetUserIsSharedLoginRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserIsSharedLoginRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} People with large numbers of followers can have the authenticity of their identity manually verified by Facebook. 
	 * This field indicates whether the person's profile is verified in this way. 
	 * This is distinct from the verified field
	 */
    this.GetUserIsVerifiedRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserIsVerifiedRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} Facebook Pages representing the languages this person knows
	 */
    this.GetUserLanguagesRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserLanguagesRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} A link to the person's Timeline
	 */
    this.GetUserLinkRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserLinkRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} The person's locale
	 */
    this.GetUserLocaleRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserLocaleRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * The person's current location as entered by them on their profile. This field is not related to check-ins
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {Response} location
	 */
    this.GetUserLocationRaw = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserLocationRaw", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} information about current user
	 */
    this.GetFieldsUser = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetFieldsUser", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @param field The field. Example: string fields = "id,name,birthday".
	 * It is necessary to form fields independently.
	 * @return {FacebookUser} information about current user
	 */
    this.GetFieldUser = function (id, field) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetFieldUser", id, field);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * Equivalent to the bio field
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Equivalent to the bio field
	 */
    this.GetUserAbout = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserAbout", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * The id of this person's user account. This ID is unique to each app and cannot be used across different apps
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @return {FacebookUser} id
	 */
    this.GetUserId = function () {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserId");
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * The person's current location as entered by them on their profile. This field is not related to check-ins
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's address
	 */
    this.GetUserAddress = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserAddress", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * The age segment for this person expressed as a minimum and maximum age. For example, more than 18, less than 21.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} age range
	 */
    this.GetUserAgeRange = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserAgeRange", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * The person's birthday. This is a fixed format string, like MM/DD/YYYY.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} birthday
	 */
    this.GetUserBirthday = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserBirthday", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Can the person review brand polls
	 */
    this.GetUserCanReviewMeasurementRequest = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserCanReviewMeasurementRequest", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id 
	 * @return {FacebookUser} Social context for this person
	 */
    this.GetUserContext = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserContext", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's cover photo
	 */
    this.GetUserCover = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserCover", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's local currency information
	 */
    this.GetUserCurrency = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserCurrency", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The list of devices the person is using. This will return only iOS and Android devices
	 */
    this.GetUserDevices = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserDevices", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's education
	 */
    this.GetUserEducation = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserEducation", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's primary email address listed on their profile. 
	 * This field will not be returned if no valid email address is available
	 */
    this.GetUserEmail = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserEmail", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Athletes the person likes
	 */
    this.GetUserFavoriteAthletes = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserFavoriteAthletes", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Sports teams the person likes
	 */
    this.GetUserFavoriteTeams = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserFavoriteTeams", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's first and last name
	 */
    this.GetUserFirstMiddleLastName = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserFirstMiddleLastName", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The gender selected by this person, male or female. 
	 * If the gender is set to a custom value, this value will be based off of the preferred pronoun; 
	 * it will be omitted if the preferred preferred pronoun is neutral
	 */
    this.GetUserGender = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserGender", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's hometown
	 */
    this.GetUserHometown = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserHometown", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's inspirational people
	 */
    this.GetUserInspirationalPeople = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserInspirationalPeople", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Install type
	 */
    this.GetUserInstallType = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserInstallType", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Is the app making the request installed?
	 */
    this.GetUserInstalled = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserInstalled", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Genders the person is interested in
	 */
    this.GetUserInterestedIn = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserInterestedIn", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Is this a shared login (e.g. a gray user)
	 */
    this.GetUserIsSharedLogin = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserIsSharedLogin", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} People with large numbers of followers can have the authenticity of their identity manually verified by Facebook. 
	 * This field indicates whether the person's profile is verified in this way. 
	 * This is distinct from the verified field
	 */
    this.GetUserIsVerified = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserIsVerified", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Facebook Pages representing the languages this person knows
	 */
    this.GetUserLanguages = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserLanguages", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} A link to the person's Timeline
	 */
    this.GetUserLink = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserLink", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's locale
	 */
    this.GetUserLocale = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserLocale", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * The person's current location as entered by them on their profile. This field is not related to check-ins
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} location
	 */
    this.GetUserLocation = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserLocation", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} What the person is interested in meeting for
	 */
    this.GetUserMeetingFor = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserMeetingFor", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's name formatted to correctly handle Chinese, Japanese, or Korean ordering
	 */
    this.GetUserNameFormat = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserNameFormat", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's payment pricepoints
	 */
    this.GetUserPaymentPricepoints = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserPaymentPricepoints", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's political views
	 */
    this.GetUserPolitical = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserPolitical", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's PGP public key
	 */
    this.GetUserPublicKey = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserPublicKey", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's favorite quotes
	 */
    this.GetUserQuotes = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserQuotes", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's relationship status
	 */
    this.GetUserRelationshipStatus = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserRelationshipStatus", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's religion
	 */
    this.GetUserReligion = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserReligion", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Security settings
	 */
    this.GetUserSecuritySettings = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserSecuritySettings", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Security settings
	 */
    this.GetUserSharedLoginUpgradeRequiredBy = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserSharedLoginUpgradeRequiredBy", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Security settings
	 */
    this.GetUserShortName = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserShortName", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's significant other
	 */
    this.GetUserSignificantOther = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserSignificantOther", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Sports played by the person
	 */
    this.GetUserSports = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserSports", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Platform test group
	 */
    this.GetUserTestGroup = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserTestGroup", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} A string containing an anonymous, but unique identifier for the person. You can use this identifier with third parties
	 */
    this.GetUserThirdPartyId = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserThirdPartyId", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's current timezone offset from UTC
	 */
    this.GetUserTimezone = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserTimezone", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Updated time
	 */
    this.GetUserUpdatedTime = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserUpdatedTime", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Updated time
	 */
    this.GetUserUserRef = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserUserRef", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Indicates whether the account has been verified. 
	 * This is distinct from the is_verified field. Someone is considered verified if they take any of the following actions:
	 */
    this.GetUserVerified = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserVerified", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Video upload limits
	 */
    this.GetUserVideoUploadLimits = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserVideoUploadLimits", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} Video upload limits
	 */
    this.GetUserViewerCanSendGift = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserViewerCanSendGift", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's website
	 */
    this.GetUserWebsite = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserWebsite", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUser} The person's website
	 */
    this.GetUserWork = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserWork", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/accounts/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserAccounts} Pages this User has a role on.
	 */
    this.GetUserAccounts = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserAccounts", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/achievements/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserAchievements} Achievements made in Facebook games
	 */
    this.GetUserAchievements = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserAchievements", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserAdStudies} Ad studies that this person can view
	 */
    this.GetUserAdStudies = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserAdStudies", id);
        return result;
    }

	/**
	 *  The advertising accounts to which this person has access.
	 * https://developers.facebook.com/docs/graph-api/reference/user/adaccounts/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserAdaccounts} The advertising accounts to which this person has access
	 */
    this.GetUserAdAccounts = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserAdAccounts", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/user/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserAdnetworkanalytics} Insights data for the person's Audience Network apps
	 */
    this.GetUserAdNetWorkanalytics = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserAdNetWorkanalytics", id);
        return result;
    }

	/**
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/v2.12/album 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserAlbums} The photo albums this person has created
	 */
    this.GetUserAlbums = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserAlbums", id);
        return result;
    }

	/**
	 *  App requests
	 * https://developers.facebook.com/docs/graph-api/reference/user/apprequestformerrecipients/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookApprequestformerrecipients} App requests
	 */
    this.GetUserApprequestForMerrecipients = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserApprequestForMerrecipients", id);
        return result;
    }

	/**
	 *  This person's pending requests from an app
	 * https://developers.facebook.com/docs/graph-api/reference/user/apprequests/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserApprequests} This person's pending requests from an app
	 */
    this.GetUserAppRequests = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserAppRequests", id);
        return result;
    }

	/**
	 *  The 3D assets owned by the user
	 * https://developers.facebook.com/docs/graph-api/reference/user/asset3ds/ 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserAsset3ds} The 3D assets owned by the user
	 */
    this.GetUserAsset3Ds = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserAsset3Ds", id);
        return result;
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
	 */
    this.GetUserBooks = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserBooks", id);
        return result;
    }

	/**
	 *  Business users corresponding to the user
	 * https://developers.facebook.com/docs/graph-api/reference/user/business_users/
	 * Permission business_management 	
	 * @param id The identifier. "me" - current user
	 * @return {FacebookUserBusinessUsers} Business users corresponding to the user
	 */
    this.GetUserBusinessUsers = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserBusinessUsers", id);
        return result;
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
	 */
    this.GetUserBusinesses = function (id) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "GetUserBusinesses", id);
        return result;
    }
}
/**
 * A Facebook page
 *     https://developers.facebook.com/docs/graph-api/reference/page/
 *     Permissions:
 *     For pages that are published, you need:
 *     An App or User access token to view fields from fully public pages.
 *     A User access token to view fields from restricted pages that this person is able to view (such as those restrict to certain demographics like location or age, or those only viewable by Page admins).
 *     A Page access token can also be used to view those restricted fields. A Page access token is required to view any User information for any objects owned by a Page.
 *     You need to be the Admin of the root page for child pages in order to read the global_brand_children edge for a page.
 *     For pages that are not published, you need:
 *     To have the Admin role for the page
 *     A Page access token 
 * @typedef {Object} FacebookPage
 */
 FacebookPage = function () { 
	/**
	 * Page ID. No access token is required to access this field
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The Page's access token. Only returned if the User making the request has a role (other than Live Contributor) on the Page.
	 * If your business requires two-factor authentication, the User must also be authenticated.
	 * @type {string}
	 */
	this.access_token = "";

	/**
	 * The Business associated with this Page. Visible only with a page access token or a user access token that has admin rights on the page.
	 * @type {FacebookPage}
	 */
	this.business = new FacebookPage();

	/**
	 * The Page's category. e.g. Product/Service, Computers/Technology
	 * @type {string}
	 */
	this.category = "";

	/**
	 * Time the object liked the page
	 * @type {DateTime}
	 */
	this.created_time = new DateTime();

	/**
	 * The name of the Page
	 * @type {string}
	 */
	this.name = "";

	/**
	 * Gets or sets the perms.
	 * @type {string[]}
	 */
	this.perms = new Array();

}

/**
 * FacebookCursors 
 * @typedef {Object} FacebookCursors
	 * @property {string}  before - The before.
	 * @property {string}  after - The after.
 */
 FacebookCursors = function () { 
	/**
	 * Gets or sets the before.
	 * @type {string}
	 */
	this.before = "";

	/**
	 * Gets or sets the after.
	 * @type {string}
	 */
	this.after = "";

}

/**
 * FacebookPaging
 *      https://developers.facebook.com/docs/graph-api/using-graph-api/#paging 
 * @typedef {Object} FacebookPaging
 */
 FacebookPaging = function () { 
	/**
	 * Gets or sets the cursors.
	 * @type {FacebookCursors}
	 */
	this.cursors = new FacebookCursors();

	/**
	 * The Graph API endpoint that will return the previous page of data. If not included, this is the first page of data.
	 * @type {string}
	 */
	this.previous = "";

	/**
	 * The Graph API endpoint that will return the next page of data. 
	 * If not included, this is the last page of data. 
	 * Due to how pagination works with visibility and privacy, it is possible that a page may be empty but contain a 'next' paging link. 
	 * Stop paging when the 'next' link no longer appears.
	 * @type {string}
	 */
	this.next = "";

}

/**
 * The curated collections created by this user.
 *     https://developers.facebook.com/docs/graph-api/reference/user/curated_collections/ 
 * @typedef {Object} FacebookUserCuratedCollections
 */
 FacebookUserCuratedCollections = function () { 
	/**
	 * A list of CuratedCollection nodes.
	 * @type {FacebookPage[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * https://developers.facebook.com/docs/graph-api/reference/user/custom_labels/
 *     Permissions
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     No data
 *     Page management Apps
 *     manage_pages
 *     pages_show_list
 *     pages_messaging
 *     Other Apps
 *     No data 
 * @typedef {Object} FacebookUserCustomLabels
 */
 FacebookUserCustomLabels = function () { 
	/**
	 * A list of PageUserMessageThreadLabel nodes.
	 * @type {FacebookPage[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * https://developers.facebook.com/docs/graph-api/reference/v2.12/domain 
 * @typedef {Object} FacebookDomain
 */
 FacebookDomain = function () { 
	/**
	 * The ID of the domain.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The name of the domain.
	 * @type {string}
	 */
	this.name = "";

}

/**
 * The domains the user admins
 *     https://developers.facebook.com/docs/graph-api/reference/user/domains/ 
 * @typedef {Object} FacebookUserDomains
 */
 FacebookUserDomains = function () { 
	/**
	 * A list of Domain nodes.
	 * @type {FacebookDomain[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * Location node used with other objects in the Graph API. 
 * @typedef {Object} FacebookLocation
 */
 FacebookLocation = function () { 
	/**
	 * Gets or sets the city.
	 * @type {string}
	 */
	this.city = "";

	/**
	 * City ID. Any city identified is also a city you can use for targeting ads.
	 * @type {string}
	 */
	this.city_id = "";

	/**
	 * Country
	 * @type {string}
	 */
	this.country = "";

	/**
	 * Country code
	 * @type {string}
	 */
	this.country_code = "";

	/**
	 * Latitude
	 * @type {Single}
	 */
	this.latitude = new Single();

	/**
	 * The parent location if this location is located within another location
	 * @type {string}
	 */
	this.located_in = "";

	/**
	 * Longitude
	 * @type {Single}
	 */
	this.longitude = new Single();

	/**
	 * Longitude
	 * @type {string}
	 */
	this.name = "";

	/**
	 * Region
	 * @type {string}
	 */
	this.region = "";

	/**
	 * Region ID. Specifies a geographic region, such as California. An identified region is the same as one you can use to target ads.
	 * @type {string}
	 */
	this.region_id = "";

	/**
	 * State
	 * @type {string}
	 */
	this.state = "";

	/**
	 * Street
	 * @type {string}
	 */
	this.street = "";

	/**
	 * Zip code
	 * @type {string}
	 */
	this.zip = "";

}

/**
 * A place
 *      https://developers.facebook.com/docs/graph-api/reference/place/ 
 * @typedef {Object} FacebookPlace
 */
 FacebookPlace = function () { 
	/**
	 * ID
	 * @type {string}
	 */
	this.id = "";

	/**
	 * Location of Place
	 * @type {FacebookLocation}
	 */
	this.location = new FacebookLocation();

	/**
	 * Name
	 * @type {string}
	 */
	this.name = "";

	/**
	 * Overall Rating of Place, on a 5-star scale. 0 means not enough data to get a combined rating.
	 * @type {Single}
	 */
	this.overall_rating = new Single();

}

/**
 * Represents a Facebook event. The /{event-id} node returns a single event.
 *     https://developers.facebook.com/docs/graph-api/reference/event/
 *     Permissions
 *     Any access token can be used to retrieve events with privacy set to OPEN.
 *     A user access token with user_events permission can be used to retrieve any events that are visible to that person.
 *     An app or page token can be used to retrieve any events that were created by that app or page.
 *     Login Review: user_events
 *     To use the user_events permission you need to submit your app for review. 
 * @typedef {Object} FacebookEvent
 */
 FacebookEvent = function () { 
	/**
	 * The event ID
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The category of the event
	 * @type {string}
	 */
	this.category = "";

	/**
	 * Long-form description
	 * @type {string}
	 */
	this.description = "";

	/**
	 * Event name
	 * @type {string}
	 */
	this.name = "";

	/**
	 * Event Place information.
	 * @type {FacebookPlace}
	 */
	this.place = new FacebookPlace();

	/**
	 * Start time
	 * @type {string}
	 */
	this.start_time = "";

	/**
	 * Gets or sets the RSVP status.
	 * @type {string}
	 */
	this.rsvp_status = "";

}

/**
 * Events for this person. By default this does not include events the person has declined or not replied to
 *     https://developers.facebook.com/docs/graph-api/reference/user/events/
 *     Permissions
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     No data
 *     Page management Apps
 *     manage_pages
 *     pages_show_list
 *     user_events
 *     Other Apps
 *     user_events 
 * @typedef {Object} FacebookUserEvents
 */
 FacebookUserEvents = function () { 
	/**
	 * A list of Event nodes.
	 * @type {FacebookEvent[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * An age range 
 * @typedef {Object} FacebookAgeRange
 */
 FacebookAgeRange = function () { 
	/**
	 * The upper bounds of the range for this person's age.
	 * @type {Int32}
	 */
	this.max = 0;

	/**
	 * The lower bounds of the range for this person's age.
	 * @type {Int32}
	 */
	this.min = 0;

}

 FacebookSummary = function () { 
	/**
	 * Gets or sets the total count.
	 * @type {Int32}
	 */
	this.total_count = 0;

}

/**
 * All friends that the viewer and the target person have in common. This includes the friends who do not use your app
 *     Returns a list of all the Facebook friends that the session user and the request user have in common.This includes friends who use the app as well as non-app-using mutual friends. 
 * @typedef {Object} FacebookAllMutualFriends
 */
 FacebookAllMutualFriends = function () { 
	/**
	 * A list of User nodes.
	 * @type {FacebookPage[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

	/**
	 * Aggregated information about the edge, such as counts.
	 * @type {FacebookSummary}
	 */
	this.summary = new FacebookSummary();

}

/**
 * Social context edge providing a list of Facebook friends that have logged into the app that the viewer and the target person have in common 
 * @typedef {Object} FacebookMutualFriends
 */
 FacebookMutualFriends = function () { 
	/**
	 * A list of User nodes.
	 * @type {FacebookPage[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

	/**
	 * Aggregated information about the edge, such as counts.
	 * @type {FacebookSummary}
	 */
	this.summary = new FacebookSummary();

}

/**
 * Social context edge providing a list of the liked Pages that the calling person and the target person have in common 
 * @typedef {Object} FacebookMutualLikes
 */
 FacebookMutualLikes = function () { 
	/**
	 * A list of Page nodes.
	 * @type {FacebookPage[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

	/**
	 * Aggregated information about the edge, such as counts.
	 * @type {FacebookSummary}
	 */
	this.summary = new FacebookSummary();

}

/**
 * Friends of the viewer who are mutual friends with the target and have the app installed. 
 * @typedef {Object} FacebookthreeDegreeMutualFriends
 */
 FacebookthreeDegreeMutualFriends = function () { 
	/**
	 * A list of User nodes.
	 * @type {FacebookPage[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * Social context for a person 
 * @typedef {Object} FacebookUserContext
	 * @property {FacebookAllMutualFriends}  all_mutual_friends - Returns a list of all the Facebook friends that the session user and the request user have in common. 
	 * This includes friends who use the app as well as non-app-using mutual friends.
 */
 FacebookUserContext = function () { 
	/**
	 * The token representing the social context
	 * @type {string}
	 */
	this.id = "";

	/**
	 * All friends that the viewer and the target person have in common. This includes the friends who do not use your app
	 * @type {FacebookAllMutualFriends}
	 */
	this.all_mutual_friends = new FacebookAllMutualFriends();

	/**
	 * Social context edge providing a list of Facebook friends that have logged into the app that the viewer and the target person have in common
	 * @type {FacebookMutualFriends}
	 */
	this.mutual_friends = new FacebookMutualFriends();

	/**
	 * Social context edge providing a list of the liked Pages that the calling person and the target person have in common
	 * @type {FacebookMutualLikes}
	 */
	this.mutual_likes = new FacebookMutualLikes();

	/**
	 * Friends of the viewer who are mutual friends with the target and have the app installed
	 * @type {FacebookthreeDegreeMutualFriends}
	 */
	this.three_degree_mutual_friends = new FacebookthreeDegreeMutualFriends();

}

/**
 * A cover photo for objects in the Graph API. Cover photos are used with Events, Groups, Pages and People. 
 * @typedef {Object} FacebookCoverPhoto
 */
 FacebookCoverPhoto = function () { 
	/**
	 * The ID of the cover photo
	 * @type {string}
	 */
	this.id = "";

	/**
	 * Deprecated. Please use the id field instead
	 * @type {string}
	 */
	this.cover_id = "";

	/**
	 * When greater than 0% but less than 100%, the cover photo overflows horizontally. 
	 * The value represents the horizontal manual offset (the amount the user dragged the photo horizontally to show the part of interest) as a percentage of the offset necessary to make the photo fit the space.
	 * @type {Single}
	 */
	this.offset_x = new Single();

	/**
	 * When greater than 0% but less than 100%, the cover photo overflows vertically. 
	 * The value represents the vertical manual offset (the amount the user dragged the photo vertically to show the part of interest) as a percentage of the offset necessary to make the photo fit the space.
	 * @type {Single}
	 */
	this.offset_y = new Single();

	/**
	 * Direct URL for the person's cover photo image
	 * @type {string}
	 */
	this.source = "";

}

/**
 * A currency 
 * @typedef {Object} FacebookCurrency
 */
 FacebookCurrency = function () { 
	/**
	 * Will return a number that describes the number of additional decimal places to include when displaying the person's currency. For example, the API will return 100 because USD is usually displayed with two decimal places.
	 * JPY does not use decimal places, so the API will return 1.
	 * @type {Int32}
	 */
	this.currency_offset = 0;

	/**
	 * The exchange rate between the person's preferred currency and US Dollars
	 * @type {Single}
	 */
	this.usd_exchange = new Single();

	/**
	 * The inverse of usd_exchange
	 * @type {Single}
	 */
	this.usd_exchange_inverse = new Single();

	/**
	 * The ISO-4217-3 code for the person's preferred currency (defaulting to USD if the person hasn't set one)
	 * @type {string}
	 */
	this.user_currency = "";

}

/**
 * Device 
 * @typedef {Object} FacebookUserDevices
 */
 FacebookUserDevices = function () { 
	/**
	 * Hardware
	 * @type {string}
	 */
	this.hardware = "";

	/**
	 * OS
	 * @type {string}
	 */
	this.os = "";

}

/**
 * An experience 
 * @typedef {Object} FacebookExperience
 */
 FacebookExperience = function () { 
	/**
	 * ID
	 * @type {string}
	 */
	this.id = "";

	/**
	 * Description
	 * @type {string}
	 */
	this.description = "";

	/**
	 * From
	 * @type {FacebookUser}
	 */
	this.from = new FacebookUser();

	/**
	 * Name
	 * @type {string}
	 */
	this.name = "";

	/**
	 * Tagged users
	 * @type {FacebookUser[]}
	 */
	this.with = new Array();

}

 FacebookEducationExperience = function () { 
	/**
	 * numeric string
	 * @type {string}
	 */
	this.id = "";

	/**
	 * Classes taken
	 * @type {FacebookExperience}
	 */
	this.classes = new FacebookExperience();

	/**
	 * Facebook Pages representing subjects studied
	 * @type {FacebookPage[]}
	 */
	this.concentration = new Array();

	/**
	 * The Facebook Page for the degree obtained
	 * @type {FacebookPage}
	 */
	this.degree = new FacebookPage();

	/**
	 * The Facebook Page for this school
	 * @type {FacebookPage}
	 */
	this.school = new FacebookPage();

	/**
	 * The type of educational institution
	 * @type {string}
	 */
	this.type = "";

	/**
	 * People tagged who went to school with this person
	 * @type {FacebookUser[]}
	 */
	this.with = new Array();

	/**
	 * Facebook Page for the year this person graduated
	 * @type {FacebookPage}
	 */
	this.year = new FacebookPage();

}

/**
 * A payment pricepoint 
 * @typedef {Object} FacebookPaymentPricepoint
	 * @property {Single}  credits - The credits.
	 * @property {string}  local_currency - The local currency.
	 * @property {string}  user_price - The user price.
 */
 FacebookPaymentPricepoint = function () { 
	/**
	 * Gets or sets the credits.
	 * @type {Single}
	 */
	this.credits = new Single();

	/**
	 * Gets or sets the local currency.
	 * @type {string}
	 */
	this.local_currency = "";

	/**
	 * Gets or sets the user price.
	 * @type {string}
	 */
	this.user_price = "";

}

/**
 * Payment pricepoints 
 * @typedef {Object} FacebookPaymentPricepoints
 */
 FacebookPaymentPricepoints = function () { 
	/**
	 * Mobile payment pricepoints
	 * @type {FacebookPaymentPricepoint[]}
	 */
	this.mobile = new Array();

}

/**
 * Secure browsing settings 
 * @typedef {Object} FacebookSecureBrowsing
 */
 FacebookSecureBrowsing = function () { 
	/**
	 * Enabled
	 * @type {string}
	 */
	this.enabled = "";

}

/**
 * Security settings 
 * @typedef {Object} FacebookSecuritySettings
 */
 FacebookSecuritySettings = function () { 
	/**
	 * Secure browsing settings
	 * @type {FacebookSecureBrowsing}
	 */
	this.secure_browsing = new FacebookSecureBrowsing();

}

/**
 * Video upload limits 
 * @typedef {Object} FacebookVideoUploadLimits
 */
 FacebookVideoUploadLimits = function () { 
	/**
	 * Length
	 * @type {string}
	 */
	this.length = "";

	/**
	 * Size
	 * @type {string}
	 */
	this.size = "";

}

/**
 * Information about a project experience 
 * @typedef {Object} FacebookPrjectExperience
 */
 FacebookPrjectExperience = function () { 
	/**
	 * ID
	 * @type {string}
	 */
	this.id = "";

	/**
	 * Description.
	 * @type {string}
	 */
	this.description = "";

	/**
	 * End date
	 * @type {string}
	 */
	this.end_date = "";

	/**
	 * From
	 * @type {FacebookUser}
	 */
	this.from = new FacebookUser();

	/**
	 * Name
	 * @type {string}
	 */
	this.name = "";

	/**
	 * Start date
	 * @type {string}
	 */
	this.start_date = "";

	/**
	 * Tagged users
	 * @type {FacebookUser[]}
	 */
	this.with = new Array();

}

/**
 * Information about a user's work 
 * @typedef {Object} FacebookWorkExperience
 */
 FacebookWorkExperience = function () { 
	/**
	 * Identifier
	 * @type {string}
	 */
	this.id = "";

	/**
	 * Description
	 * @type {string}
	 */
	this.description = "";

	/**
	 * Employer
	 * @type {FacebookPage}
	 */
	this.employer = new FacebookPage();

	/**
	 * End date
	 * @type {string}
	 */
	this.end_date = "";

	/**
	 * Tagged by
	 * @type {string}
	 */
	this.from = "";

	/**
	 * Location
	 * @type {FacebookPage}
	 */
	this.location = new FacebookPage();

	/**
	 * Position
	 * @type {FacebookPage}
	 */
	this.position = new FacebookPage();

	/**
	 * Projects
	 * @type {FacebookPrjectExperience[]}
	 */
	this.projects = new Array();

	/**
	 * Start date
	 * @type {string}
	 */
	this.start_date = "";

	/**
	 * Tagged users
	 * @type {FacebookUser[]}
	 */
	this.with = new Array();

}

/**
 * Accounts for a Facebook User. 
 *     Pages this User has a role on.
 *      https://developers.facebook.com/docs/graph-api/reference/user/accounts/
 *      A Page access token for a User with a role (other than Live Contributor) on the Page and the following permissions:
 *      manage_pages or pages_show_list 
 * @typedef {Object} FacebookUserAccounts
 */
 FacebookUserAccounts = function () { 
	/**
	 * A list of Page nodes.
	 * @type {FacebookPage[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

	/**
	 * Aggregated information about the edge, such as counts.
	 * @type {FacebookSummary}
	 */
	this.summary = new FacebookSummary();

}

/**
 * An Open Graph object
 *     https://developers.facebook.com/docs/graph-api/reference/open-graph-object--generic/ 
 * @typedef {Object} FacebookOGOGeneric
 */
 FacebookOGOGeneric = function () { 
	/**
	 * The Open Graph object ID
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The time the object was created
	 * @type {DateTime}
	 */
	this.created_time = new DateTime();

	/**
	 * A short description of the object
	 * @type {string}
	 */
	this.description = "";

	/**
	 * The word that appears before the object's title
	 * @type {string}
	 */
	this.determiner = "";

	/**
	 * Whether the object has been scraped
	 * Type: bool
	 * @type {string}
	 */
	this.is_scraped = "";

	/**
	 * The location inherited from Place
	 * @type {FacebookLocation}
	 */
	this.location = new FacebookLocation();

	/**
	 * The action ID that created this object
	 * @type {string}
	 */
	this.post_action_id = "";

	/**
	 * An array of URLs of related resources
	 * @type {string[]}
	 */
	this.see_also = new Array();

	/**
	 * The name of the web site upon which the object resides
	 * @type {string}
	 */
	this.site_name = "";

	/**
	 * The title of the object as it should appear in the graph
	 * @type {string}
	 */
	this.title = "";

	/**
	 * The type of the object
	 * @type {string}
	 */
	this.type = "";

	/**
	 * The last time the object was updated
	 * @type {DateTime}
	 */
	this.updated_time = new DateTime();

}

/**
 * Open graph actions taken by the user 
 * @typedef {Object} FacebookUserAchievements
 */
 FacebookUserAchievements = function () { 
	/**
	 * A list of OpenGraphAction:generic nodes.
	 * @type {FacebookOGOGeneric[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * A lift study object
 *     https://developers.facebook.com/docs/marketing-api/reference/ad-study/ 
 * @typedef {Object} FacebookAdStudy
 */
 FacebookAdStudy = function () { 
	/**
	 * Time stamp when study was canceled
	 * @type {DateTime}
	 */
	this.canceled_time = new DateTime();

	/**
	 * Who Lift study was created by
	 * @type {FacebookUser}
	 */
	this.created_by = new FacebookUser();

	/**
	 * The time the object was created
	 * @type {DateTime}
	 */
	this.created_time = new DateTime();

	/**
	 * Description
	 * @type {string}
	 */
	this.description = "";

	/**
	 * End time
	 * @type {DateTime}
	 */
	this.end_time = new DateTime();

	/**
	 * ID of the Lift study
	 * @type {string}
	 */
	this.id = "";

	/**
	 * Cooldown start time
	 * @type {DateTime}
	 */
	this.cooldown_start_time = new DateTime();

	/**
	 * Name of the Lift study
	 * @type {string}
	 */
	this.name = "";

	/**
	 * Observation end time
	 * @type {DateTime}
	 */
	this.observation_end_time = new DateTime();

	/**
	 * Start time
	 * @type {DateTime}
	 */
	this.start_time = new DateTime();

	/**
	 * The type of study, either audience segmentation or lift
	 * @type {string}
	 */
	this.type = "";

	/**
	 * Updated by
	 * @type {FacebookUser}
	 */
	this.updated_by = new FacebookUser();

	/**
	 * Updated time
	 * @type {DateTime}
	 */
	this.updated_time = new DateTime();

}

/**
 * Ad studies that this person can view 
 *      https://developers.facebook.com/docs/graph-api/reference/user/ad_studies/ 
 * @typedef {Object} FacebookUserAdStudies
 */
 FacebookUserAdStudies = function () { 
	/**
	 * A list of AdStudy nodes
	 * @type {FacebookAdStudy[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

	/**
	 * Aggregated information about the edge, such as counts. 
	 * Specify the fields to fetch in the summary param (like summary=total_count).
	 * @type {FacebookPaging}
	 */
	this.summary = new FacebookPaging();

}

/**
 * Represents a business, person or other entity who creates and manage ads on Facebook. 
 *     Multiple people can manage an account, and each person can have one or more levels of access to an account, by specifying roles, see Ad User. 
 *     Permissions
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     ads_read 
 * @typedef {Object} FacebookAdAccount
 */
 FacebookAdAccount = function () { 
	/**
	 * The string act_{ad_account_id}
	 * @type {string}
	 */
	this.account_id = "";

	/**
	 * The ID of the ad account
	 * @type {string}
	 */
	this.id = "";

}

/**
 * The advertising accounts to which this person has access.
 *      Developers usually request these permissions for this endpoint:
 *      Marketing Apps ads_management. 
 * @typedef {Object} FacebookUserAdaccounts
 */
 FacebookUserAdaccounts = function () { 
	/**
	 * A list of AdAccount nodes.
	 * @type {FacebookAdAccount[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

	/**
	 * Aggregated information about the edge, such as counts.
	 * @type {FacebookSummary}
	 */
	this.summary = new FacebookSummary();

}

/**
 * Results from an insights query. Please see our documentation on the app_insights edge for more information. 
 *     Data of Insights Query
 *     https://developers.facebook.com/docs/graph-api/reference/insights-query-result/ 
 * @typedef {Object} FacebookInsightsQueryResult
 */
 FacebookInsightsQueryResult = function () { 
	/**
	 * Gets or sets the time.
	 * @type {DateTime}
	 */
	this.time = new DateTime();

	/**
	 * Gets or sets the value.
	 * @type {string}
	 */
	this.value = "";

}

/**
 * Insights for all of this user's Audience Network apps. 
 * @typedef {Object} FacebookUserAdnetworkanalytics
 */
 FacebookUserAdnetworkanalytics = function () { 
	/**
	 * A list of InsightsQueryResult nodes
	 * @type {FacebookInsightsQueryResult[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * Image source and dimensions 
 * @typedef {Object} FacebookPlatformImageSource
 */
 FacebookPlatformImageSource = function () { 
	/**
	 * Height of the image.
	 * @type {Int32}
	 */
	this.height = 0;

	/**
	 * URI of the image.
	 * @type {string}
	 */
	this.source = "";

	/**
	 * Width of the image
	 * @type {Int32}
	 */
	this.width = 0;

}

/**
 * All the Pages this person has liked
 *     https://developers.facebook.com/docs/graph-api/reference/user/likes/
 *     Permissions
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     No data
 *     Page management Apps
 *     No data
 *     Other Apps
 *     user_likes 
 * @typedef {Object} FacebookUserLikes
 */
 FacebookUserLikes = function () { 
	/**
	 * A list of Page nodes.
	 * @type {FacebookPage[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

	/**
	 * Aggregated information about the edge, such as counts.
	 * @type {FacebookSummary}
	 */
	this.summary = new FacebookSummary();

}

/**
 * A comment can be made on various types of content on Facebook. 
 *     Most Graph API nodes have a /comments edge that lists all the comments on that object. 
 *     The /{comment-id} node returns a single comment. 
 * @typedef {Object} FacebookComment
 */
 FacebookComment = function () { 
	/**
	 * The comment ID
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The time this comment was made
	 * @type {DateTime}
	 */
	this.created_time = new DateTime();

	/**
	 * The person that made this comment
	 * @type {FacebookUser}
	 */
	this.from = new FacebookUser();

	/**
	 * The comment text.
	 * @type {string}
	 */
	this.message = "";

	/**
	 * Whether the viewer has liked this comment.
	 * @type {string}
	 */
	this.user_likes = "";

}

/**
 * This reference describes the /comments edge that is common to multiple Graph API nodes. 
 * @typedef {Object} FacebookComments
 */
 FacebookComments = function () { 
	/**
	 * The data.
	 * @type {FacebookComment[]}
	 */
	this.data = new Array();

	/**
	 * Paging.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * Represents an individual photo on Facebook.
 *     https://developers.facebook.com/docs/graph-api/reference/photo
 *     Permissions
 *     Any valid access token can read photos on a public Page.
 *     A page access token can read all photos posted to or posted by that Page.
 *     A user access token can read any photo your application created on behalf of that user.
 *     A user's photos can be read if the owner has granted the user_photos or user_posts permission.
 *     A user access token may read a photo that user is tagged in if they have granted the user_photos or user_posts permission. However, in some cases the photo's owner's privacy settings may not allow your application to access it.
 *     A User access token for an Admin of a Group can read Group-owned Photos.
 *     A User access token for an Admin of an Event can read Event-owned Photos. 
 * @typedef {Object} FacebookPhoto
 */
 FacebookPhoto = function () { 
	/**
	 * The photo ID
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The album this photo is in
	 * @type {FacebookAlbum}
	 */
	this.album = new FacebookAlbum();

	/**
	 * The time this photo was published.
	 * @type {DateTime}
	 */
	this.created_time = new DateTime();

	/**
	 * If this object has a place, the event associated with the place.
	 * @type {FacebookEvent}
	 */
	this.event_ = new FacebookEvent();

	/**
	 * The icon that Facebook displays when photos are published to News Feed
	 * @type {string}
	 */
	this.icon = "";

	/**
	 * The different stored representations of the photo. Can vary in number based upon the size of the original photo.
	 * @type {FacebookPlatformImageSource[]}
	 */
	this.images = new Array();

	/**
	 * A link to the photo on Facebook.
	 * @type {string}
	 */
	this.link = "";

	/**
	 * The user-provided caption given to this photo. Corresponds to caption when creating photos
	 * @type {string}
	 */
	this.name = "";

	/**
	 * Link to the 100px wide representation of this photo
	 * @type {string}
	 */
	this.picture = "";

	/**
	 * Gets or sets the place.
	 * @type {FacebookPlace}
	 */
	this.place = new FacebookPlace();

	/**
	 * The last time the photo was updated
	 * @type {DateTime}
	 */
	this.updated_time = new DateTime();

	/**
	 * People who like this
	 * @type {FacebookUserLikes}
	 */
	this.likes = new FacebookUserLikes();

	/**
	 * Comments on an object
	 * @type {FacebookComments}
	 */
	this.comments = new FacebookComments();

}

/**
 * Album
 *     https://developers.facebook.com/docs/graph-api/reference/v2.12/album 
 * @typedef {Object} FacebookAlbum
 */
 FacebookAlbum = function () { 
	/**
	 * The album ID
	 * @type {string}
	 */
	this.id = "";

	/**
	 * Whether the viewer can upload photos to this album
	 * Type: bool
	 * @type {string}
	 */
	this.can_upload = "";

	/**
	 * The approximate number of photos in the album. This is not necessarily an exact count
	 * @type {Int32}
	 */
	this.count = 0;

	/**
	 * The ID of the album's cover photo.
	 * @type {FacebookPhoto}
	 */
	this.cover_photo = new FacebookPhoto();

	/**
	 * The time the album was initially created.
	 * @type {DateTime}
	 */
	this.created_time = new DateTime();

	/**
	 * The description of the album.
	 * @type {string}
	 */
	this.description = "";

	/**
	 * The event associated with this album.
	 * @type {FacebookEvent}
	 */
	this.event_ = new FacebookEvent();

	/**
	 * The profile that created the album.
	 * @type {FacebookUser}
	 */
	this.from = new FacebookUser();

	/**
	 * A link to this album on Facebook.
	 * @type {string}
	 */
	this.link = "";

	/**
	 * The textual location of the album.
	 * @type {string}
	 */
	this.location = "";

	/**
	 * The title of the album.
	 * @type {string}
	 */
	this.name = "";

	/**
	 * The place associated with this album.
	 * @type {FacebookPage}
	 */
	this.place = new FacebookPage();

	/**
	 * The privacy settings for the album.
	 * @type {string}
	 */
	this.privacy = "";

	/**
	 * The type of the album.
	 * @type {string}
	 */
	this.type = "";

	/**
	 * The last time the album was updated.
	 * @type {DateTime}
	 */
	this.updated_time = new DateTime();

}

/**
 * Albums for a Facebook User
 *     https://developers.facebook.com/docs/graph-api/reference/user/albums/ 
 * @typedef {Object} FacebookUserAlbums
 */
 FacebookUserAlbums = function () { 
	/**
	 * A list of Album nodes
	 * @type {FacebookAlbum[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * Information about users that received app requests from the viewer in the past
 *     https://developers.facebook.com/docs/graph-api/reference/app-request-former-recipient/ 
 * @typedef {Object} FacebookAppRequestFormerRecipient
 */
 FacebookAppRequestFormerRecipient = function () { 
	/**
	 * Viewer ID
	 * @type {string}
	 */
	this.id = "";

	/**
	 * Recipient ID
	 * @type {string}
	 */
	this.recipient_id = "";

}

/**
 * App requests
 *     Permissions
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     No data
 *     Page management Apps
 *     No data
 *     Other Apps
 *     user_friends
 *     https://developers.facebook.com/docs/graph-api/reference/user/apprequestformerrecipients/ 
 * @typedef {Object} FacebookApprequestformerrecipients
 */
 FacebookApprequestformerrecipients = function () { 
	/**
	 * Gets or sets the data.
	 * @type {FacebookAppRequestFormerRecipient[]}
	 */
	this.data = new Array();

	/**
	 * Gets or sets the paging.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * An individual app request received by someone, sent by an app or another person
 *     https://developers.facebook.com/docs/graph-api/reference/app-request/ 
 * @typedef {Object} FacebookAppRequest
 */
 FacebookAppRequest = function () { 
	/**
	 * The ID of an individual request
	 * @type {string}
	 */
	this.id = "";

}

/**
 * This person's pending requests from an app 
 *      https://developers.facebook.com/docs/graph-api/reference/user/apprequests/ 
 * @typedef {Object} FacebookUserApprequests
 */
 FacebookUserApprequests = function () { 
	/**
	 * A list of AppRequest nodes.
	 * @type {FacebookAppRequest[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * Represents a 3D Asset. 
 * @typedef {Object} FacebookWithAsset3D
 */
 FacebookWithAsset3D = function () { 
	/**
	 * The id of the object
	 * @type {string}
	 */
	this.id = "";

}

/**
 * The 3D assets owned by this user.
 *     https://developers.facebook.com/docs/graph-api/reference/user/asset3ds/ 
 * @typedef {Object} FacebookUserAsset3ds
 */
 FacebookUserAsset3ds = function () { 
	/**
	 * A list of WithAsset3D nodes.
	 * @type {FacebookWithAsset3D[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * Books listed in someone's Facebook profile.
 *     https://developers.facebook.com/docs/graph-api/reference/user/books/ 
 *      Permissions
 *      Developers usually request these permissions for this endpoint:
 *      Marketing Apps
 *      No data
 *      Page management Apps
 *      No data
 *      Other Apps
 *      user_likes 
 * @typedef {Object} FacebookUserBooks
 */
 FacebookUserBooks = function () { 
	/**
	 * Gets or sets the data.
	 * @type {FacebookPage[]}
	 */
	this.data = new Array();

	/**
	 * Gets or sets the paging.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

	/**
	 * Gets or sets the summary.
	 * @type {FacebookSummary}
	 */
	this.summary = new FacebookSummary();

}

/**
 * Get business users that a personal user has.
 *     https://developers.facebook.com/docs/graph-api/reference/user/business_users/ 
 * @typedef {Object} FacebookUserBusinessUsers
 */
 FacebookUserBusinessUsers = function () { 
	/**
	 * A list of BusinessUser nodes.
	 * @type {FacebookPage[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

	/**
	 * Aggregated information about the edge, such as counts.
	 * @type {FacebookSummary}
	 */
	this.summary = new FacebookSummary();

}

/**
 * Businesses associated with the user
 *     https://developers.facebook.com/docs/graph-api/reference/user/businesses/
 *     Permissions
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     ads_management
 *     ads_read
 *     manage_pages
 *     business_management
 *     Page management Apps
 *     No data
 *     Other Apps
 *     No data 
 * @typedef {Object} FacebookUserBusinesses
 */
 FacebookUserBusinesses = function () { 
	/**
	 * A list of Business nodes.
	 * @type {FacebookPage[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * Developers' favorite requests to the Graph API
 *     https://developers.facebook.com/docs/graph-api/reference/user/favorite_requests/ 
 * @typedef {Object} FacebookUserFavoriteRequests
 */
 FacebookUserFavoriteRequests = function () { 
	/**
	 * A list of FavoriteRequest nodes.
	 * @type {FacebookPage[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * This represents a user's friend list on Facebook
 *     https://developers.facebook.com/docs/graph-api/reference/friend-list/
 *     Permissions
 *     A user access token with read_custom_friendlists permission is required. 
 * @typedef {Object} FacebookFriendList
 */
 FacebookFriendList = function () { 
	/**
	 * The friend list ID
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The type of the friend list
	 * @type {string}
	 */
	this.list_type = "";

	/**
	 * The name of the friend list
	 * @type {string}
	 */
	this.name = "";

	/**
	 * The owner of the friend list
	 * @type {string}
	 */
	this.owner = "";

}

/**
 * A person's custom friend lists.
 *     https://developers.facebook.com/docs/graph-api/reference/user/friendlists/
 *     Permissions
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     ads_management
 *     manage_pages
 *     pages_show_list
 *     read_custom_friendlists
 *     user_location
 *     user_education_history
 *     Page management Apps
 *     No data
 *     Other Apps
 *     read_custom_friendlists 
 * @typedef {Object} FacebookUserFriendlists
 */
 FacebookUserFriendlists = function () { 
	/**
	 * A list of FriendList nodes.
	 * @type {FacebookFriendList[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * This edge allows you to:
 *     get the User's friends who have installed the app making the query
 *     get the User's total number of friends (including those who have not installed the app making the query)
 *     The person's friends 
 * @typedef {Object} FacebookUserFriends
 */
 FacebookUserFriends = function () { 
	/**
	 * A list of User nodes.
	 * @type {FacebookUser[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

	/**
	 * Aggregated information about the edge, such as counts. 
	 * Specify the fields to fetch in the summary param (like summary=total_count).
	 * @type {FacebookSummary}
	 */
	this.summary = new FacebookSummary();

}

/**
 * Games a person likes.
 *     https://developers.facebook.com/docs/graph-api/reference/user/games/
 *     Permission 
 *     user_likes 
 * @typedef {Object} FacebookUserGames
 */
 FacebookUserGames = function () { 
	/**
	 * A list of Page nodes.
	 * @type {FacebookPage[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

	/**
	 * Aggregated information about the edge, such as counts.
	 * @type {FacebookSummary}
	 */
	this.summary = new FacebookSummary();

}

/**
 * A Group.
 *     Returns information about a single Group object. To get a list of Groups a User belongs to, use the /user/groups edge instead.
 *     Permissions
 *     For Public and Closed Groups
 *     A User access token.
 *     For Secret Groups
 *     A User access token for an Admin of the Group with the following permissions:
 *     user_managed_groups 
 * @typedef {Object} FacebookGroup
 */
 FacebookGroup = function () { 
	/**
	 * The group ID
	 * @type {string}
	 */
	this.id = "";

	/**
	 * Information about the group's cover photo.
	 * @type {FacebookCoverPhoto}
	 */
	this.cover = new FacebookCoverPhoto();

	/**
	 * A brief description of the group.
	 * @type {string}
	 */
	this.description = "";

	/**
	 * The email address to upload content to the group. Only current members of the group can use this.
	 * @type {string}
	 */
	this.email = "";

}

/**
 * The Facebook Groups of which the person is an Admin.
 *     https://developers.facebook.com/docs/graph-api/reference/user/groups/
 *     Permissions
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     manage_pages
 *     business_management
 *     user_managed_groups
 *     user_events
 *     user_photos
 *     Page management Apps
 *     manage_pages
 *     user_managed_groups
 *     user_events
 *     user_photos
 *     Other Apps
 *     user_managed_groups 
 * @typedef {Object} FacebookUserGroups
 */
 FacebookUserGroups = function () { 
	/**
	 * A list of Group nodes.
	 * @type {FacebookGroup[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * A Facebook app.
 *     https://developers.facebook.com/docs/graph-api/reference/application/
 *     Permissions
 *     An app access token can be used to view all fields for an app. 
 * @typedef {Object} FacebookApplication
 */
 FacebookApplication = function () { 
	/**
	 * The app ID
	 * @type {string}
	 */
	this.id = "";

}

/**
 * A users's ID for an app 
 * @typedef {Object} FacebookUserIdForApp
 */
 FacebookUserIdForApp = function () { 
	/**
	 * ID.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * App.
	 * @type {FacebookApplication}
	 */
	this.app = new FacebookApplication();

}

/**
 * The IDs that apps owned by the business know the user as
 *     https://developers.facebook.com/docs/graph-api/reference/user/ids_for_business/ 
 * @typedef {Object} FacebookUserIDsForBusiness
 */
 FacebookUserIDsForBusiness = function () { 
	/**
	 * A list of UserIDForApp nodes.
	 * @type {FacebookUserIdForApp[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * A list of lead generation forms belonging to Pages that the user has advertiser permissions on
 *     https://developers.facebook.com/docs/graph-api/reference/user/leadgen_forms/ 
 * @typedef {Object} FacebookUserLeadgenForms
 */
 FacebookUserLeadgenForms = function () { 
	/**
	 * A list of LeadGenData nodes.
	 * @type {FacebookPage[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * An EntLiveEncoder is for the live encoders that can be associated withvideo broadcasts. This is part of the reference live encoder API.
 *     https://developers.facebook.com/docs/graph-api/reference/live-encoder/ 
 * @typedef {Object} FacebookLiveEncoder
 */
 FacebookLiveEncoder = function () { 
	/**
	 * The id of the object
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The live encoder brand (eg: Wowza)
	 * @type {string}
	 */
	this.brand = "";

	/**
	 * Creation time
	 * @type {DateTime}
	 */
	this.creation_time = new DateTime();

}

/**
 * Live encoders owned by this person
 *     https://developers.facebook.com/docs/graph-api/reference/user/live_videos/ 
 * @typedef {Object} FacebookUserLiveEncoders
 */
 FacebookUserLiveEncoders = function () { 
	/**
	 * A list of LiveEncoder nodes.
	 * @type {FacebookLiveEncoder[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * Represents an individual video on Facebook.
 *     https://developers.facebook.com/docs/graph-api/reference/video/
 *     Permissions
 *     Any valid access token can read videos on a public Page.
 *     A page access token can read all videos posted to or posted by that Page.
 *     A user access token can read any video your application created on behalf of that user.
 *     A user's videos can be read if the owner has granted the user_videos or user_posts permission.
 *     A user access token may read a video that user is tagged in if they user granted the user_videos or user_posts permission. However, in some cases the video's owner's privacy settings may not allow your application to access it.
 *     The source field will not be returned for Page-owned videos unless the User making the request has a role on the owning Page. 
 * @typedef {Object} FacebookVideo
 */
 FacebookVideo = function () { 
	/**
	 * The time the video was initially published.
	 * @type {DateTime}
	 */
	this.created_time = new DateTime();

	/**
	 * The video ID.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The description of the video.
	 * @type {string}
	 */
	this.description = "";

	/**
	 * Location associated with the video, if any.
	 * @type {FacebookPlace}
	 */
	this.place = new FacebookPlace();

}

/**
 * A live video
 *     https://developers.facebook.com/docs/graph-api/reference/live-video/
 *     Permissions:
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     manage_pages
 *     pages_show_list
 *     business_management
 *     Page management Apps
 *     manage_pages
 *     pages_show_list
 *     Other Apps
 *     Permissions are not usually requested.
 *     A Page access token can read all videos posted to or posted by that Page.
 *     A User access token can read any video your application created on behalf of that user.
 *     A User's videos can be read if the owner has granted the user_videos or user_posts permission.
 *     A User access token may read a video that a user is tagged in if the user granted the user_videos or user_posts permission. However, in some cases the video's owner's privacy settings may not allow your application to access it.
 *     A User access token for an Admin of a Group can read Group-owned Live Videos.
 *     A User access token for an Admin of an Event can read Event-owned Live Videos. 
 * @typedef {Object} FacebookLiveVideo
 */
 FacebookLiveVideo = function () { 
	/**
	 * The time the video was initially published
	 * @type {DateTime}
	 */
	this.broadcast_start_time = new DateTime();

	/**
	 * The live video ID
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The description of the live video
	 * @type {string}
	 */
	this.description = "";

	/**
	 * The title of the live video
	 * @type {string}
	 */
	this.title = "";

	/**
	 * The inside video of live video - only visible when the live video has ended.
	 * @type {FacebookVideo}
	 */
	this.video = new FacebookVideo();

}

/**
 * Live videos from this person
 *     https://developers.facebook.com/docs/graph-api/reference/user/live_videos/
 *     Permissions
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     No data
 *     Page management Apps
 *     No data
 *     Other Apps
 *     publish_actions 
 * @typedef {Object} FacebookUserLiveVideos
 */
 FacebookUserLiveVideos = function () { 
	/**
	 * A list of LiveVideo nodes.
	 * @type {FacebookLiveVideo[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * Movies this person likes
 *     https://developers.facebook.com/docs/graph-api/reference/user/movies/
 *     Permissions
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     ads_management
 *     manage_pages
 *     pages_show_list
 *     user_likes
 *     Page management Apps
 *     No data
 *     Other Apps
 *     user_likes 
 * @typedef {Object} FacebookUserMovies
 */
 FacebookUserMovies = function () { 
	/**
	 * A list of Page nodes.
	 * @type {FacebookPage[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

	/**
	 * Aggregated information about the edge, such as counts.
	 * @type {FacebookSummary}
	 */
	this.summary = new FacebookSummary();

}

/**
 * Music this person likes.
 *     https://developers.facebook.com/docs/graph-api/reference/user/music/
 *     Permissions
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     No data
 *     Page management Apps
 *     No data
 *     Other Apps
 *     user_likes 
 * @typedef {Object} FacebookUserMusic
 */
 FacebookUserMusic = function () { 
	/**
	 * A list of Page nodes.
	 * @type {FacebookPage[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

	/**
	 * Aggregated information about the edge, such as counts.
	 * @type {FacebookSummary}
	 */
	this.summary = new FacebookSummary();

}

/**
 * A permission requested from a user by an application
 *     https://developers.facebook.com/docs/graph-api/reference/permission/ 
 * @typedef {Object} FacebookPermission
 */
 FacebookPermission = function () { 
	/**
	 * Name of the permission
	 * @type {string}
	 */
	this.permission = "";

	/**
	 * Permission status
	 * @type {string}
	 */
	this.status = "";

}

/**
 * Returns a list of granted and declined permissions.
 *     https://developers.facebook.com/docs/graph-api/reference/user/permissions/ 
 * @typedef {Object} FacebookUserPermissions
 */
 FacebookUserPermissions = function () { 
	/**
	 * A list of Permission nodes.
	 * @type {FacebookPermission[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * Photos for a person.
 *     https://developers.facebook.com/docs/graph-api/reference/user/photos/
 *     Permissions
 *     Any valid access token for any photo with public privacy settings.
 *     For any photos uploaded by someone, and any photos in which they have been tagged - A user access token for that person with user_photos permission. 
 * @typedef {Object} FacebookUserPhotos
 */
 FacebookUserPhotos = function () { 
	/**
	 * A list of Photo nodes.
	 * @type {FacebookPhoto[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * Profile Picture
 *     https://developers.facebook.com/docs/graph-api/reference/profile-picture-source/ 
 * @typedef {Object} FacebookProfilePictureSource
 */
 FacebookProfilePictureSource = function () { 
	/**
	 * A key to identify the profile picture for the purpose of invalidating the image cache
	 * @type {string}
	 */
	this.cache_key = "";

	/**
	 * Picture height in pixels. Only returned when specified as a modifier
	 * @type {Int32}
	 */
	this.height = 0;

	/**
	 * True if the profile picture is the default 'silhouette' picture
	 * @type {string}
	 */
	this.is_silhouette = "";

	/**
	 * URL of the profile picture
	 * @type {string}
	 */
	this.url = "";

	/**
	 * Picture width in pixels. Only returned when specified as a modifier
	 * @type {Int32}
	 */
	this.width = 0;

}

/**
 * A Picture for a Facebook User.
 *     https://developers.facebook.com/docs/graph-api/reference/user/picture/ 
 * @typedef {Object} FacebookUserPicture
 */
 FacebookUserPicture = function () { 
	/**
	 * A single ProfilePictureSource node.
	 * @type {FacebookProfilePictureSource}
	 */
	this.data = new FacebookProfilePictureSource();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * A Graph API past request object
 *     https://developers.facebook.com/docs/graph-api/reference/request-history/ 
 * @typedef {Object} FacebookRequestHistory
 */
 FacebookRequestHistory = function () { 
	/**
	 * Gets or sets the API version.
	 * @type {string}
	 */
	this.api_version = "";

	/**
	 * Graph API version of the stored request
	 * @type {DateTime}
	 */
	this.created_time = new DateTime();

	/**
	 * Error code of the past request
	 * @type {Int32}
	 */
	this.error_code = 0;

	/**
	 * Graph path of the stored request
	 * @type {string}
	 */
	this.graph_path = "";

	/**
	 * HTTP method of the stored request.
	 * @type {string}
	 */
	this.http_method = "";

}

/**
 * Developers' Graph API request history
 *     https://developers.facebook.com/docs/graph-api/reference/user/request_history/ 
 * @typedef {Object} FacebookUserRequestHistory
 */
 FacebookUserRequestHistory = function () { 
	/**
	 * A list of RequestHistory nodes.
	 * @type {FacebookRequestHistory[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * A canvas document.
 *     https://developers.facebook.com/docs/graph-api/reference/canvas/ 
 * @typedef {Object} FacebookCanvas
 */
 FacebookCanvas = function () { 
	/**
	 * Gets or sets the identifier.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The canvas link for the canvas
	 * @type {string}
	 */
	this.canvas_link = "";

	/**
	 * The canvas is hidden or not
	 * @type {string}
	 */
	this.is_hidden = "";

	/**
	 * Publish status of the canvas
	 * @type {string}
	 */
	this.is_published = "";

	/**
	 * User who last edited this canvas
	 * @type {FacebookUser}
	 */
	this.last_editor = new FacebookUser();

	/**
	 * Name used to label the canvas
	 * @type {string}
	 */
	this.name = "";

	/**
	 * Page that owns this canvas
	 * @type {FacebookPage}
	 */
	this.owner = new FacebookPage();

	/**
	 * Last updated time of the canvas
	 * @type {Int32}
	 */
	this.update_time = 0;

}

/**
 * A list of rich media documents belonging to Pages that the user has advertiser permissions on
 *     https://developers.facebook.com/docs/graph-api/reference/user/rich_media_documents/ 
 * @typedef {Object} FacebookUserRichMediaDocuments
 */
 FacebookUserRichMediaDocuments = function () { 
	/**
	 * A list of Canvas nodes.
	 * @type {FacebookCanvas[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * Any session keys that the app knows the user by
 *     https://developers.facebook.com/docs/graph-api/reference/user/session_keys/ 
 * @typedef {Object} FacebookUserSessionKeys
 */
 FacebookUserSessionKeys = function () { 
	/**
	 * A list of PlatformSessionKey nodes.
	 * @type {FacebookPage[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * This represents a News Feed filter
 *     https://developers.facebook.com/docs/graph-api/reference/stream-filter/ 
 * @typedef {Object} FacebookStreamFilter
 */
 FacebookStreamFilter = function () { 
	/**
	 * The filter key used by the News Feed
	 * @type {string}
	 */
	this.filter_key = "";

	/**
	 * The name of the filter
	 * @type {string}
	 */
	this.name = "";

	/**
	 * The type of the filter
	 * @type {string}
	 */
	this.Type = "";

}

/**
 * A list of filters that can be applied to the News Feed edge
 *     https://developers.facebook.com/docs/graph-api/reference/user/stream_filters/ 
 * @typedef {Object} FacebookUserStreamFilters
 */
 FacebookUserStreamFilters = function () { 
	/**
	 * A list of StreamFilter nodes.
	 * @type {FacebookStreamFilter[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * Profile picture link
 *     https://developers.facebook.com/docs/graph-api/reference/user-taggable-friend/picture/ 
 * @typedef {Object} FacebookUserTaggableFriendPicture
 */
 FacebookUserTaggableFriendPicture = function () { 
	/**
	 * A single ProfilePictureSource node.
	 * @type {FacebookProfilePictureSource}
	 */
	this.data = new FacebookProfilePictureSource();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * Taggable friend of current user
 *     https://developers.facebook.com/docs/graph-api/reference/user-taggable-friend/ 
 * @typedef {Object} FacebookUserTaggableFriend
 */
 FacebookUserTaggableFriend = function () { 
	/**
	 * First name
	 * @type {string}
	 */
	this.first_name = "";

	/**
	 * ID
	 * @type {string}
	 */
	this.id = "";

	/**
	 * Last name
	 * @type {string}
	 */
	this.last_name = "";

	/**
	 * Middle name
	 * @type {string}
	 */
	this.middle_name = "";

	/**
	 * Name
	 * @type {string}
	 */
	this.name = "";

	/**
	 * Profile picture link
	 * @type {FacebookUserTaggableFriendPicture}
	 */
	this.picture = new FacebookUserTaggableFriendPicture();

}

/**
 * Friends that can be tagged in content published via the Graph API
 *     https://developers.facebook.com/docs/graph-api/reference/user/taggable_friends/
 *     Permissions
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     No data
 *     Page management Apps
 *     No data
 *     Other Apps
 *     user_friends 
 * @typedef {Object} FacebookUserTaggableFriends
 */
 FacebookUserTaggableFriends = function () { 
	/**
	 * A list of UserTaggableFriend nodes.
	 * @type {FacebookUserTaggableFriend[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * A Place Tag
 *     https://developers.facebook.com/docs/graph-api/reference/place-tag/ 
 * @typedef {Object} FacebookPlaceTag
 */
 FacebookPlaceTag = function () { 
	/**
	 * ID
	 * @type {string}
	 */
	this.id = "";

	/**
	 * Time when the place was visited
	 * @type {DateTime}
	 */
	this.created_time = new DateTime();

	/**
	 * The place that was visited
	 * @type {FacebookPage}
	 */
	this.place = new FacebookPage();

}

/**
 * Tagged Places for a Facebook User.
 *     https://developers.facebook.com/docs/graph-api/reference/user/tagged_places/
 *     Permissions
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     No data
 *     Page management Apps
 *     No data
 *     Other Apps
 *     user_tagged_places 
 * @typedef {Object} FacebookUserTaggedPlaces
 */
 FacebookUserTaggedPlaces = function () { 
	/**
	 * A list of PlaceTag nodes.
	 * @type {FacebookPlaceTag[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * TV shows this person likes.
 *     https://developers.facebook.com/docs/graph-api/reference/user/television/
 *     Permissions
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     No data
 *     Page management Apps
 *     No data
 *     Other Apps
 *     user_likes 
 * @typedef {Object} FacebookUserTelevision
 */
 FacebookUserTelevision = function () { 
	/**
	 * A list of Page nodes.
	 * @type {FacebookPage[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

	/**
	 * Aggregated information about the edge, such as counts.
	 * @type {FacebookSummary}
	 */
	this.summary = new FacebookSummary();

}

/**
 * Video broadcasts from this person 
 * @typedef {Object} FacebookUserVideoBroadcasts
 */
 FacebookUserVideoBroadcasts = function () { 
	/**
	 * A list of LiveVideo nodes.
	 * @type {FacebookLiveVideo[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * Videos for a Facebook User.
 *     https://developers.facebook.com/docs/graph-api/reference/user/videos/
 *     Permissions
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     No data
 *     Page management Apps
 *      No data
 *     Other Apps
 *      user_videos 
 * @typedef {Object} FacebookUserVideos
 */
 FacebookUserVideos = function () { 
	/**
	 * A list of Video nodes.
	 * @type {FacebookVideo[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * An individual entry in a profile's feed. The profile could be a user, page, app, or group. 
 * @typedef {Object} FacebookPost
 */
 FacebookPost = function () { 
	/**
	 * The post ID
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The time the post was initially published. For a post about a life event, this will be the date and time of the life event.
	 * @type {DateTime}
	 */
	this.created_time = new DateTime();

	/**
	 * The status message in the post.
	 * @type {string}
	 */
	this.message = "";

	/**
	 * The link attached to this post.
	 * @type {string}
	 */
	this.link = "";

	/**
	 * Likes.
	 * @type {FacebookUserLikes}
	 */
	this.likes = new FacebookUserLikes();

	/**
	 * Any location information attached to the post.
	 * @type {FacebookPlace}
	 */
	this.place = new FacebookPlace();

	/**
	 * Text from stories not intentionally generated by users, such as those generated when two people become friends, 
	 * or when someone else posts on the person's wall.
	 * @type {string}
	 */
	this.story = "";

}

/**
 * The feed of posts 
 * @typedef {Object} FacebookFeed
 */
 FacebookFeed = function () { 
	/**
	 * Data
	 * @type {FacebookPost[]}
	 */
	this.data = new Array();

	/**
	 * Gets or sets the paging.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * Information of User
 *     https://developers.facebook.com/docs/graph-api/reference/user/
 *     Permissions
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     No data
 *     Page management Apps
 *     manage_pages
 *     pages_show_list
 *     Other Apps
 *     Permissions are not usually requested. 
 * @typedef {Object} FacebookUser
	 * @property {string}  id - The identifier.
	 * @property {string}  about - The about.
	 * @property {FacebookAgeRange}  age_range - The age range.
	 * @property {string}  birthday - The birthday.
	 * @property {string}  can_review_measurement_request - The can review measurement request.
	 * @property {FacebookEducationExperience[]}  education - The person's education history
	 * @property {FacebookPage}  location - The location.
 */
 FacebookUser = function () { 
	/**
	 * The id of this person's user account. 
	 * This ID is unique to each app and cannot be used across different apps.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * Equivalent to the bio field
	 * @type {string}
	 */
	this.about = "";

	/**
	 * The person's address
	 * @type {FacebookLocation}
	 */
	this.address = new FacebookLocation();

	/**
	 * Gets or sets the age range.
	 * @type {FacebookAgeRange}
	 */
	this.age_range = new FacebookAgeRange();

	/**
	 * The person's birthday. This is a fixed format string, like MM/DD/YYYY.
	 * @type {string}
	 */
	this.birthday = "";

	/**
	 * Can the person review brand polls
	 * @type {string}
	 */
	this.can_review_measurement_request = "";

	/**
	 * Social context for a person
	 * @type {FacebookUserContext}
	 */
	this.context = new FacebookUserContext();

	/**
	 * A cover photo for objects in the Graph API. Cover photos are used with Events, Groups, Pages and People.
	 * @type {FacebookCoverPhoto}
	 */
	this.cover = new FacebookCoverPhoto();

	/**
	 * The person's local currency information
	 * @type {FacebookCurrency}
	 */
	this.currency = new FacebookCurrency();

	/**
	 * The list of devices the person is using. This will return only iOS and Android devices
	 * @type {FacebookUserDevices[]}
	 */
	this.devices = new Array();

	/**
	 * The person's education
	 * @type {FacebookEducationExperience[]}
	 */
	this.education = new Array();

	/**
	 * The person's primary email address listed on their profile. 
	 * This field will not be returned if no valid email address is available
	 * @type {string}
	 */
	this.email = "";

	/**
	 * Athletes the person likes
	 * @type {FacebookExperience[]}
	 */
	this.favorite_athletes = new Array();

	/**
	 * Sports teams the person likes
	 * @type {FacebookExperience[]}
	 */
	this.favorite_teams = new Array();

	/**
	 * The person's first name
	 * @type {string}
	 */
	this.first_name = "";

	/**
	 * The gender selected by this person, male or female. 
	 * If the gender is set to a custom value, this value will be based off of the preferred pronoun; 
	 * it will be omitted if the preferred preferred pronoun is neutral
	 * @type {string}
	 */
	this.gender = "";

	/**
	 * The person's hometown
	 * @type {FacebookPage}
	 */
	this.hometown = new FacebookPage();

	/**
	 * The person's inspirational people
	 * @type {FacebookExperience[]}
	 */
	this.inspirational_people = new Array();

	/**
	 * Install type
	 * @type {string}
	 */
	this.install_type = "";

	/**
	 * Is the app making the request installed?
	 * @type {string}
	 */
	this.installed = "";

	/**
	 * Genders the person is interested in
	 * @type {string[]}
	 */
	this.interested_in = new Array();

	/**
	 * Is this a shared login (e.g. a gray user)
	 * @type {string}
	 */
	this.is_shared_login = "";

	/**
	 * People with large numbers of followers can have the authenticity of their identity manually verified by Facebook. 
	 * This field indicates whether the person's profile is verified in this way. This is distinct from the verified field
	 * @type {string}
	 */
	this.is_verified = "";

	/**
	 * A link to the person's Timeline
	 * @type {string}
	 */
	this.link = "";

	/**
	 * Facebook Pages representing the languages this person knows
	 * @type {FacebookExperience[]}
	 */
	this.languages = new Array();

	/**
	 * The person's last name
	 * @type {string}
	 */
	this.last_name = "";

	/**
	 * The person's locale
	 * @type {string}
	 */
	this.locale = "";

	/**
	 * Location node used with other objects in the Graph API.
	 * @type {FacebookPage}
	 */
	this.location = new FacebookPage();

	/**
	 * What the person is interested in meeting for
	 * @type {string[]}
	 */
	this.meeting_for = new Array();

	/**
	 * The person's middle name
	 * @type {string}
	 */
	this.middle_name = "";

	/**
	 * The person's full name
	 * @type {string}
	 */
	this.name = "";

	/**
	 * The person's name formatted to correctly handle Chinese, Japanese, or Korean ordering
	 * @type {string}
	 */
	this.name_format = "";

	/**
	 * The person's payment pricepoints
	 * @type {FacebookPaymentPricepoints}
	 */
	this.payment_pricepoints = new FacebookPaymentPricepoints();

	/**
	 * The person's political views
	 * @type {string}
	 */
	this.political = "";

	/**
	 * The person's PGP public key
	 * @type {string}
	 */
	this.public_key = "";

	/**
	 * The person's favorite quotes
	 * @type {string}
	 */
	this.quotes = "";

	/**
	 * The person's relationship status
	 * @type {string}
	 */
	this.relationship_status = "";

	/**
	 * The relationship between user and family member.
	 * @type {string}
	 */
	this.relationship = "";

	/**
	 * The person's religion
	 * @type {string}
	 */
	this.religion = "";

	/**
	 * Security settings
	 * @type {FacebookSecuritySettings}
	 */
	this.security_settings = new FacebookSecuritySettings();

	/**
	 * The time that the shared loginneeds to be upgraded to Business Manager by
	 * if date is {01.01.0001 0:00:00} then date is not received from server
	 * @type {DateTime}
	 */
	this.shared_login_upgrade_required_by = new DateTime();

	/**
	 * Shortened, locale-aware name for the person
	 * @type {string}
	 */
	this.short_name = "";

	/**
	 * The person's significant other
	 * @type {FacebookUser}
	 */
	this.significant_other = new FacebookUser();

	/**
	 * Sports played by the person
	 * @type {FacebookExperience}
	 */
	this.sports = new FacebookExperience();

	/**
	 * Platform test group
	 * @type {Int32}
	 */
	this.test_group = 0;

	/**
	 * A string containing an anonymous, but unique identifier for the person. You can use this identifier with third parties
	 * @type {string}
	 */
	this.third_party_id = "";

	/**
	 * The person's current timezone offset from UTC
	 * Type: float (min: -24) (max: 24)
	 * @type {Single}
	 */
	this.timezone = new Single();

	/**
	 * Updated time
	 * if date is {01.01.0001 0:00:00} then date is not received from server
	 * @type {DateTime}
	 */
	this.updated_time = new DateTime();

	/**
	 * Latest user ref that matches a given PSID that should be invalidated. 
	 * This should only be used for anonymous messaging PSID migration
	 * @type {string}
	 */
	this.user_ref = "";

	/**
	 * Indicates whether the account has been verified. This is distinct from the is_verified field.
	 *  Someone is considered verified if they take any of the following actions:
	 * * Register for mobile
	 * * Confirm their account via SMS
	 * * Enter a valid credit card
	 * @type {string}
	 */
	this.verified = "";

	/**
	 * Video upload limits
	 * @type {FacebookVideoUploadLimits}
	 */
	this.video_upload_limits = new FacebookVideoUploadLimits();

	/**
	 * Can the viewer send a gift to this person?
	 * @type {string}
	 */
	this.viewer_can_send_gift = "";

	/**
	 * The person's website
	 * @type {string}
	 */
	this.website = "";

	/**
	 * Details of a person`s work experience
	 * @type {FacebookWorkExperience[]}
	 */
	this.work = new Array();

	/**
	 * Pages this User has a role on.
	 * @type {FacebookUserAccounts}
	 */
	this.accounts = new FacebookUserAccounts();

	/**
	 * Achievements made in Facebook games
	 * @type {FacebookUserAchievements}
	 */
	this.achievements = new FacebookUserAchievements();

	/**
	 * Ad studies that this person can view
	 * @type {FacebookUserAdStudies}
	 */
	this.ad_studies = new FacebookUserAdStudies();

	/**
	 * The advertising accounts to which this person has access
	 * @type {FacebookUserAdaccounts}
	 */
	this.adaccounts = new FacebookUserAdaccounts();

	/**
	 * Insights data for the person's Audience Network apps.
	 * @type {FacebookUserAdnetworkanalytics}
	 */
	this.adnetworkanalytics = new FacebookUserAdnetworkanalytics();

	/**
	 * The photo albums this person has created
	 * @type {FacebookUserAlbums}
	 */
	this.albums = new FacebookUserAlbums();

	/**
	 * App requests.
	 * @type {FacebookApprequestformerrecipients}
	 */
	this.apprequestformerrecipients = new FacebookApprequestformerrecipients();

	/**
	 * App requests.
	 * @type {FacebookUserApprequests}
	 */
	this.apprequests = new FacebookUserApprequests();

	/**
	 * The 3D assets owned by the user
	 * @type {FacebookUserAsset3ds}
	 */
	this.asset3ds = new FacebookUserAsset3ds();

	/**
	 * The books listed on this person's profile.
	 * @type {FacebookUserBooks}
	 */
	this.books = new FacebookUserBooks();

	/**
	 * Business users corresponding to the user.
	 * @type {FacebookUserBusinessUsers}
	 */
	this.business_users = new FacebookUserBusinessUsers();

	/**
	 * Businesses associated with the user
	 * @type {FacebookUserBusinesses}
	 */
	this.businesses = new FacebookUserBusinesses();

	/**
	 * The curated collections created by this user
	 * @type {FacebookUserCuratedCollections}
	 */
	this.curated_collections = new FacebookUserCuratedCollections();

	/**
	 * Custom labels.
	 * @type {FacebookUserCustomLabels}
	 */
	this.custom_labels = new FacebookUserCustomLabels();

	/**
	 * The domains the user admins
	 * @type {FacebookUserDomains}
	 */
	this.domains = new FacebookUserDomains();

	/**
	 * Events for this person. By default this does not include events the person has declined or not replied to
	 * @type {FacebookUserEvents}
	 */
	this.events = new FacebookUserEvents();

	/**
	 * This person's family relationships.
	 * @type {FacebookUserFamily}
	 */
	this.family = new FacebookUserFamily();

	/**
	 * Developers' favorite requests to the Graph API.
	 * @type {FacebookUserFavoriteRequests}
	 */
	this.favorite_requests = new FacebookUserFavoriteRequests();

	/**
	 * The person's custom friend lists
	 * @type {FacebookUserFriendlists}
	 */
	this.friendlists = new FacebookUserFriendlists();

	/**
	 * A person's friends.
	 * @type {FacebookUserFriends}
	 */
	this.friends = new FacebookUserFriends();

	/**
	 * Games this person likes.
	 * @type {FacebookUserGames}
	 */
	this.games = new FacebookUserGames();

	/**
	 * A list of Facebook Groups of which a person is an admin.
	 * @type {FacebookUserGroups}
	 */
	this.groups = new FacebookUserGroups();

	/**
	 * Businesses can claim ownership of multiple apps using Business Manager. 
	 * This edge returns the list of IDs that this user has in any of those other apps
	 * @type {FacebookUserIDsForBusiness}
	 */
	this.ids_for_business = new FacebookUserIDsForBusiness();

	/**
	 * A list of lead generation forms belonging to Pages that the user has advertiser permissions on
	 * @type {FacebookUserLeadgenForms}
	 */
	this.leadgen_forms = new FacebookUserLeadgenForms();

	/**
	 * All the Pages this person has liked.
	 * @type {FacebookUserLikes}
	 */
	this.likes = new FacebookUserLikes();

	/**
	 * Live encoders owned by this person.
	 * @type {FacebookUserLiveEncoders}
	 */
	this.live_encoders = new FacebookUserLiveEncoders();

	/**
	 * Live videos from this person
	 * @type {FacebookUserLiveVideos}
	 */
	this.live_videos = new FacebookUserLiveVideos();

	/**
	 * Movies this person likes
	 * @type {FacebookUserMovies}
	 */
	this.movies = new FacebookUserMovies();

	/**
	 * Music this person likes
	 * @type {FacebookUserMusic}
	 */
	this.music = new FacebookUserMusic();

	/**
	 * The permissions that the person has granted this app
	 * @type {FacebookUserPermissions}
	 */
	this.permissions = new FacebookUserPermissions();

	/**
	 * Photos the person is tagged in or has uploaded.
	 * @type {FacebookUserPhotos}
	 */
	this.photos = new FacebookUserPhotos();

	/**
	 * The person's profile picture
	 * @type {FacebookUserPicture}
	 */
	this.picture = new FacebookUserPicture();

	/**
	 * Developers' Graph API request history
	 * @type {FacebookUserRequestHistory}
	 */
	this.request_history = new FacebookUserRequestHistory();

	/**
	 * A list of rich media documents belonging to Pages that the user has advertiser permissions on
	 * @type {FacebookUserRichMediaDocuments}
	 */
	this.rich_media_documents = new FacebookUserRichMediaDocuments();

	/**
	 * Any session keys that the app knows the user by
	 * @type {FacebookUserSessionKeys}
	 */
	this.session_keys = new FacebookUserSessionKeys();

	/**
	 * A list of filters that can be applied to the News Feed edge
	 * @type {FacebookUserStreamFilters}
	 */
	this.stream_filters = new FacebookUserStreamFilters();

	/**
	 * Friends that can be tagged in content published via the Graph API
	 * @type {FacebookUserTaggableFriends}
	 */
	this.taggable_friends = new FacebookUserTaggableFriends();

	/**
	 * List of tagged places for this person. It can include tags on videos, posts, statuses or links
	 * @type {FacebookUserTaggedPlaces}
	 */
	this.tagged_places = new FacebookUserTaggedPlaces();

	/**
	 * TV shows this person likes
	 * @type {FacebookUserTelevision}
	 */
	this.television = new FacebookUserTelevision();

	/**
	 * Video broadcasts from this person
	 * @type {FacebookUserVideoBroadcasts}
	 */
	this.video_broadcasts = new FacebookUserVideoBroadcasts();

	/**
	 * Videos the person is tagged in or uploaded
	 * @type {FacebookUserVideos}
	 */
	this.videos = new FacebookUserVideos();

	/**
	 * Gets or sets the feed.
	 * @type {FacebookFeed}
	 */
	this.feed = new FacebookFeed();

}

/**
 * A person's family relationships.
 *     https://developers.facebook.com/docs/graph-api/reference/user/family 
 * @typedef {Object} FacebookUserFamily
 */
 FacebookUserFamily = function () { 
	/**
	 * A list of User nodes.
	 * @type {FacebookUser[]}
	 */
	this.data = new Array();

	/**
	 * For more details about pagination, see the Graph API guide.
	 * @type {FacebookPaging}
	 */
	this.paging = new FacebookPaging();

}

/**
 * App access tokens are used to make requests to Facebook APIs on behalf of an app rather than a user. This can be used to modify the parameters of your app, create and manage test users, or read your apps's insights.
 *      https://developers.facebook.com/docs/facebook-login/access-tokens#apptokens 
 * @typedef {Object} FacebookAppToken
 */
 FacebookAppToken = function () { 
	/**
	 * App Token
	 * @type {string}
	 */
	this.access_token = "";

	/**
	 * Token Type
	 * @type {string}
	 */
	this.token_type = "";

}

/**
 * Inspecting Access Tokens
 *      https://developers.facebook.com/docs/facebook-login/manually-build-a-login-flow 
 * @typedef {Object} FacebookDebugMetadata
 */
 FacebookDebugMetadata = function () { 
	/**
	 * Gets or sets the sso.
	 * @type {string}
	 */
	this.sso = "";

}

/**
 * Inspecting Access Tokens
 *      https://developers.facebook.com/docs/facebook-login/manually-build-a-login-flow 
 * @typedef {Object} FacebookDebugData
 */
 FacebookDebugData = function () { 
	/**
	 * The application identifier.
	 * @type {string}
	 */
	this.app_id = "";

	/**
	 * The type.
	 * @type {string}
	 */
	this.type = "";

	/**
	 * The application.
	 * @type {string}
	 */
	this.application = "";

	/**
	 * The expires at.
	 * @type {string}
	 */
	this.expires_at = "";

	/**
	 * The is valid.
	 * @type {string}
	 */
	this.is_valid = "";

	/**
	 * The issued at.
	 * @type {string}
	 */
	this.issued_at = "";

	/**
	 * The metadata.
	 * @type {FacebookDebugMetadata}
	 */
	this.metadata = new FacebookDebugMetadata();

	/**
	 * The scopes.
	 * @type {string[]}
	 */
	this.scopes = new Array();

	/**
	 * The user identifier.
	 * @type {string}
	 */
	this.user_id = "";

}

/**
 * Inspecting Access Tokens
 *      https://developers.facebook.com/docs/facebook-login/manually-build-a-login-flow 
 * @typedef {Object} FacebookDebug
 */
 FacebookDebug = function () { 
	/**
	 * The data.
	 * @type {FacebookDebugData}
	 */
	this.data = new FacebookDebugData();

}

