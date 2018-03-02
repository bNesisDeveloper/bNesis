Facebook = function (bNesisApi) {
    this.bNesisToken = null;
    var _bNesisApi = bNesisApi;

    this.Auth = function (data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl) {
        var bNesisToken = _bNesisApi.Auth("Facebook", data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl);
        return bNesisToken;
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
	 *  Represents current person on Facebook.
	 * https://developers.facebook.com/docs/graph-api/reference/v2.12/user/feed 	
	 * @param id The identifier. "me" - current user
	 * @param message The main body of the post, otherwise called the status message.
	 * Either link, place, or message must be supplied.
	 * @param link The URL of a link to attach to the post.
	 * Either link, place, or message must be supplied. Additional fields associated with link are shown below.
	 * @return {FacebookFeedResponse} The feed of posts (including status updates) and links published by this person.
	 */
    this.PostUserFeed = function (id, message, link) {
        var result = _bNesisApi.Call("Facebook", this.bNesisToken, "PostUserFeed", id, message, link);
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

/**
 * FacebookData 
 * @typedef {Object} FacebookData
	 * @property {string}  name - The name.
	 * @property {string}  id - The identifier.
 */
 FacebookData = function () { 
	/**
	 * Gets or sets the name.
	 * @type {string}
	 */
	this.name = "";

	/**
	 * Gets or sets the identifier.
	 * @type {string}
	 */
	this.id = "";

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
 * @typedef {Object} FacebookPaging
	 * @property {FacebookCursors}  cursors - The cursors.
 */
 FacebookPaging = function () { 
	/**
	 * Gets or sets the cursors.
	 * @type {FacebookCursors}
	 */
	this.cursors = new FacebookCursors();

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
	 * @type {FacebookData[]}
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
	 * @type {FacebookData[]}
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
	 * @type {FacebookData[]}
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
	 * @type {FacebookData[]}
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

/**
 * A Facebook page
 *     https://developers.facebook.com/docs/graph-api/reference/page/ 
 * @typedef {Object} FacebookPage
 */
 FacebookPage = function () { 
	/**
	 * Page ID. No access token is required to access this field
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The name of the Page
	 * @type {string}
	 */
	this.name = "";

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
	 * @type {FacebookPage[]}
	 */
	this.degree = new Array();

	/**
	 * The Facebook Page for this school
	 * @type {FacebookPage[]}
	 */
	this.school = new Array();

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
	 * @type {FacebookPage[]}
	 */
	this.year = new Array();

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
	 * @type {FacebookPage[]}
	 */
	this.employer = new Array();

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
	 * @type {FacebookPage[]}
	 */
	this.location = new Array();

	/**
	 * Position
	 * @type {FacebookPage[]}
	 */
	this.position = new Array();

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
 * Information of User 
 * @typedef {Object} FacebookUser
	 * @property {string}  id - The identifier.
	 * @property {string}  about - The about.
	 * @property {FacebookAgeRange}  age_range - The age range.
	 * @property {string}  birthday - The birthday.
	 * @property {string}  can_review_measurement_request - The can review measurement request.
	 * @property {FacebookEducationExperience[]}  education - The person's education history
	 * @property {FacebookPage[]}  location - The location.
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
	 * @type {FacebookPage[]}
	 */
	this.hometown = new Array();

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
	 * @type {FacebookPage[]}
	 */
	this.location = new Array();

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
	 * A person's friends.
	 * @type {FacebookUserFriends}
	 */
	this.friends = new FacebookUserFriends();

}

/**
 * The feed of posts 
 * @typedef {Object} FacebookFeedResponse
 */
 FacebookFeedResponse = function () { 
	/**
	 * The newly created post ID
	 * @type {string}
	 */
	this.id = "";

}

