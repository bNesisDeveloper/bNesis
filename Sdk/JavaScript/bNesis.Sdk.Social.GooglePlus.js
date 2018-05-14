GooglePlus = function (bNesisApi) {
    this.bNesisToken = null;
    var _bNesisApi = bNesisApi;

    /**
     * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
	 * or Attach to bNesis session with exists bNesis token
     * @return {string} bNesisToken value | true if bNesisToken is valid
	 */
    this.Auth = function (bNesisDevId,clientId,clientSecret,redirectUrl,scopes,data) {
		if(arguments.length !== 1){
			var bNesisToken = _bNesisApi.Auth("Google", data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,"","",false,"");
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
		var result = _bNesisApi.LogoffService("Google", this.bNesisToken);
		if (result) this.bNesisToken = "";
		return result;             
    }
	
	/**
	 *  Getting last exception for current provider 	
	 * @return {ErrorInfo} 
	 */
    this.GetLastError = function () {
        var result = _bNesisApi.Call("GooglePlus", this.bNesisToken, "GetLastError");
        return result;
    }

	/**
	 *  Getting arrays of error info 	
	 * @return {ErrorInfo[]} 
	 */
    this.GetErrorLog = function () {
        var result = _bNesisApi.Call("GooglePlus", this.bNesisToken, "GetErrorLog");
        return result;
    }

	/**
	 *  Checks the token in the service. 	
	 * @return {Boolean} if token valid return true, if token not valid return false
	 */
    this.ValidateToken = function () {
        var result = _bNesisApi.Call("GooglePlus", this.bNesisToken, "ValidateToken");
        return result;
    }

	/**
	 *  Disables the access token used to authenticate the call. 	
	 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false
	 */
    this.Logoff = function () {
        var result = _bNesisApi.Call("GooglePlus", this.bNesisToken, "Logoff");
        return result;
    }

	/**
	 *   	
	 * @param id 
	 * @return {ContactItem} 
	 */
    this.GetFieldsUserUnified = function (id) {
        var result = _bNesisApi.Call("GooglePlus", this.bNesisToken, "GetFieldsUserUnified", id);
        return result;
    }

	/**
	 *   	
	 * @param id 
	 * @param field 
	 * @return {ContactItem} 
	 */
    this.GetFieldUserUnified = function (id, field) {
        var result = _bNesisApi.Call("GooglePlus", this.bNesisToken, "GetFieldUserUnified", id, field);
        return result;
    }

	/**
	 *   	
	 * @param id 
	 * @return {ContactItem} 
	 */
    this.GetUserAboutUnified = function (id) {
        var result = _bNesisApi.Call("GooglePlus", this.bNesisToken, "GetUserAboutUnified", id);
        return result;
    }

	/**
	 *  Gets current user profile based on token.
	 * For see all information about user, app must request from member this scope: https://www.googleapis.com/auth/plus.me, https://www.googleapis.com/auth/plus.login,
	 * https://www.googleapis.com/auth/userinfo.email, https://www.googleapis.com/auth/userinfo.profile 	
	 * @return {GooglePlusProfile} Return in GooglePlusProfile.
	 */
    this.GetAboutMe = function () {
        var result = _bNesisApi.Call("GooglePlus", this.bNesisToken, "GetAboutMe");
        return result;
    }

	/**
	 *  Gets user profile by identifier. 	
	 * @param userId User identifier. If identifier is 'me' see .
	 * @return {GooglePlusProfile} Return in GooglePlusProfile.
	 */
    this.GetUserProfile = function (userId) {
        var result = _bNesisApi.Call("GooglePlus", this.bNesisToken, "GetUserProfile", userId);
        return result;
    }

	/**
	 *  Search all public profiles. 	
	 * @param query Specify a query string for full text search of public text in all profiles.
	 * @param language Specify the preferred language to search with. All code languages see: https://developers.google.com/+/web/api/rest/search#available-languages
	 * @param maxResults The maximum number of people returned on response. Acceptable, values are 1 to 50.
	 * @param pageToken The continion token to next page. (Possible can be getted in response then can it use here)
	 * @return {GooglePlusProfileCollection} Return in GooglePlusItemCollection.
	 */
    this.FindProfile = function (query, language, maxResults, pageToken) {
        var result = _bNesisApi.Call("GooglePlus", this.bNesisToken, "FindProfile", query, language, maxResults, pageToken);
        return result;
    }

	/**
	 *  Gets list of people in the specified collection on particular activity. 	
	 * @param id User identifier. If identifier is 'me' see .
	 * @param collection The collection of people list. 
	 *  Possible values are:
	 *  plusoners - List all people who have +1'd this activity.
	 *  resharers - List all people who have reshared this activity.
	 * @param maxResults The maximum people included in response. Acceptable values are 1 to 100.
	 * @param pageToken The continued token to next page. (Possible can be getted in response then can it use here)
	 * @return {GooglePlusProfileCollection} Return in GooglePlusItemCollection.
	 */
    this.GetListPeopleByActivity = function (id, collection, maxResults, pageToken) {
        var result = _bNesisApi.Call("GooglePlus", this.bNesisToken, "GetListPeopleByActivity", id, collection, maxResults, pageToken);
        return result;
    }

	/**
	 *  Gets list of people in the specified collection.
	 *  App must request from user this required scopes: https://www.googleapis.com/auth/plus.login 	
	 * @param id User identifier. If identifier is 'me' see .
	 * @param collection The collection of people list. 
	 *  Possible values are:
	 *  connected - The list of visible people in the authenticated user's circles who also use the requesting app. This list is limited to users who made their app activities visible to the authenticated user.
	 *  visible - The list of people who this user has added to one or more circles, limited to the circles visible to the requesting application.
	 * @param orderBy Sorting people in the response by one of next order value:
	 *  alphabetical - Order the people by their display name.
	 *  best - Order people based on the relevence to the viewer.
	 * @param maxResults The maximum people included in response. Acceptable values are 1 to 100
	 * @param pageToken The continued token to next page. (Possible can be getted in response then can it use here)
	 * @return {GooglePlusProfileCollection} Return in GooglePlusItemCollection.
	 */
    this.GetListPeople = function (id, collection, orderBy, maxResults, pageToken) {
        var result = _bNesisApi.Call("GooglePlus", this.bNesisToken, "GetListPeople", id, collection, orderBy, maxResults, pageToken);
        return result;
    }

	/**
	 *  Gets the list of all comments for an activity. 	
	 * @param activityId The identifier comment to get for.
	 * @param maxResults The maximum number of comments returned in response. Acceptable values are 0 to 500.
	 * @param pageToken The continued token to next page. (Possible can be getted in response then can it use here)
	 * @param sortOrder The order in which to sort the list of comments.
	 *  Acceptable values are:
	 *  ascending - Sort oldest comments first. (default)
	 *  descending - Sort newest comments first.
	 * @return {GooglePlusCommentCollection} Return in GooglePlusItemCollection.
	 */
    this.GetListOfComment = function (activityId, maxResults, pageToken, sortOrder) {
        var result = _bNesisApi.Call("GooglePlus", this.bNesisToken, "GetListOfComment", activityId, maxResults, pageToken, sortOrder);
        return result;
    }

	/**
	 *  Gets a comment by identifier. 	
	 * @param commentId The comment identifier.
	 * @return {GooglePlusComment} Return in GooglePlusComment.
	 */
    this.GetComment = function (commentId) {
        var result = _bNesisApi.Call("GooglePlus", this.bNesisToken, "GetComment", commentId);
        return result;
    }

	/**
	 *  Gets list of activities by specified collection for a particular user.
	 *  App must request from user this scope: https://www.googleapis.com/auth/plus.login 
	 * or https://www.googleapis.com/auth/plus.me if used userId - 'me'. 	
	 * @param userId The identifier of user. If identifier 'me' see .
	 * @param collection The collection of activities to list.
	 *      Acceptable values are:
	 *      public - All public activities created by the specified user.
	 * @param maxResults The maximum activities in response. Acceptable values are 1 to 100.
	 * @param pageToken The continued token to next page. (Possible can be getted in response then can it use here)
	 * @return {GooglePlusActivityCollection} Return in GooglePlusItemCollection.
	 */
    this.GetListOfActivity = function (userId, collection, maxResults, pageToken) {
        var result = _bNesisApi.Call("GooglePlus", this.bNesisToken, "GetListOfActivity", userId, collection, maxResults, pageToken);
        return result;
    }

	/**
	 *  Gets activity by identifier. 	
	 * @param activityId The activity identifier.
	 * @return {GooglePlusActivity} Return in GooglePlusActivity.
	 */
    this.GetActivity = function (activityId) {
        var result = _bNesisApi.Call("GooglePlus", this.bNesisToken, "GetActivity", activityId);
        return result;
    }

	/**
	 *  Search public activities. 	
	 * @param query Full-text query string.
	 * @param language Specify the preferred language to search with. All code languages see: https://developers.google.com/+/web/api/rest/search#available-languages
	 * @param maxResults The maximum activities in response. Acceptable values are 1 to 20.
	 * @param orderType Specifies how to order search results. 
	 *      Acceptable values are:
	 *      best - Sort activities by relevance to the user, most relevant first.
	 *      recent - Sort activities by published date, most recent first. (default)
	 * @param pageToken The continued token to next page. (Possible can be getted in response then can it use here)
	 * @return {GooglePlusActivityCollection} Return in GooglePlusItemCollection.
	 */
    this.FindActivities = function (query, language, maxResults, orderType, pageToken) {
        var result = _bNesisApi.Call("GooglePlus", this.bNesisToken, "FindActivities", query, language, maxResults, orderType, pageToken);
        return result;
    }

	/**
	 *  Gets current user profile based on token.
	 * For see all information about user, app must request from member this scope: https://www.googleapis.com/auth/plus.me, https://www.googleapis.com/auth/plus.login,
	 * https://www.googleapis.com/auth/userinfo.email, https://www.googleapis.com/auth/userinfo.profile 	
	 * @return {Response} Return in response.
	 */
    this.GetAboutMeRaw = function () {
        var result = _bNesisApi.Call("GooglePlus", this.bNesisToken, "GetAboutMeRaw");
        return result;
    }

	/**
	 *  Gets user profile by identifier. 	
	 * @param userId User identifier. If identifier is 'me' see .
	 * @return {Response} Return in response.
	 */
    this.GetUserProfileRaw = function (userId) {
        var result = _bNesisApi.Call("GooglePlus", this.bNesisToken, "GetUserProfileRaw", userId);
        return result;
    }

	/**
	 *  Search all public profiles. 	
	 * @param query Specify a query string for full text search of public text in all profiles.
	 * @param language Specify the preferred language to search with. All code languages see: https://developers.google.com/+/web/api/rest/search#available-languages
	 * @param maxResults The maximum number of people returned on response. Acceptable values are 1 to 50.
	 * @param pageToken The continued token to next page. (Possible can be getted in response then can it use here)
	 * @return {Response} Return in response.
	 */
    this.FindProfileRaw = function (query, language, maxResults, pageToken) {
        var result = _bNesisApi.Call("GooglePlus", this.bNesisToken, "FindProfileRaw", query, language, maxResults, pageToken);
        return result;
    }

	/**
	 *  Gets list of people in the specified collection on particular activity. 	
	 * @param id User identifier. If identifier is 'me' see .
	 * @param collection The collection of people list. 
	 *  Acceptable values are:
	 *  plusoners - List all people who have +1'd this activity.
	 *  resharers - List all people who have reshared this activity.
	 * @param maxResults The maximum people included in response. Acceptable values are 1 to 100.
	 * @param pageToken The continued token to next page. (Possible can be getted in response then can it use here)
	 * @return {Response} Return in response.
	 */
    this.GetListPeopleByActivityRaw = function (id, collection, maxResults, pageToken) {
        var result = _bNesisApi.Call("GooglePlus", this.bNesisToken, "GetListPeopleByActivityRaw", id, collection, maxResults, pageToken);
        return result;
    }

	/**
	 *  Gets list of people in the specified collection.
	 *  App must request from user this required scopes: https://www.googleapis.com/auth/plus.login 	
	 * @param id User identifier. If identifier is 'me' see .
	 * @param collection The collection of people list. 
	 *  Acceptable values are:
	 *  connected - The list of visible people in the authenticated user's circles who also use the requesting app. This list is limited to users who made their app activities visible to the authenticated user.
	 *  visible - The list of people who this user has added to one or more circles, limited to the circles visible to the requesting application.
	 * @param orderBy Sorting people in the response by one of next order value:
	 *  alphabetical - Order the people by their display name.
	 *  best - Order people based on the relevence to the viewer.
	 * @param maxResults The maximum people included in response. Acceptable values are 1 to 100
	 * @param pageToken The continued token to next page. (Possible can be getted in response then can it use here)
	 * @return {Response} Return in response.
	 */
    this.GetListPeopleRaw = function (id, collection, orderBy, maxResults, pageToken) {
        var result = _bNesisApi.Call("GooglePlus", this.bNesisToken, "GetListPeopleRaw", id, collection, orderBy, maxResults, pageToken);
        return result;
    }

	/**
	 *  Gets the list of all comments for an activity. 	
	 * @param activityId The identifier comment to get for.
	 * @param maxResults The maximum number of comments returned in response. Acceptable values are 0 to 500.
	 * @param pageToken The continued token to next page. (Possible can be getted in response then can it use here)
	 * @param sortOrder The order in which to sort the list of comments.
	 *  Acceptable values are:
	 *  ascending - Sort oldest comments first. (default)
	 *  descending - Sort newest comments first.
	 * @return {Response} Return in response.
	 */
    this.GetListOfCommentRaw = function (activityId, maxResults, pageToken, sortOrder) {
        var result = _bNesisApi.Call("GooglePlus", this.bNesisToken, "GetListOfCommentRaw", activityId, maxResults, pageToken, sortOrder);
        return result;
    }

	/**
	 *  Gets a comment by identifier. 	
	 * @param commentId The comment identifier.
	 * @return {Response} Return in response.
	 */
    this.GetCommentRaw = function (commentId) {
        var result = _bNesisApi.Call("GooglePlus", this.bNesisToken, "GetCommentRaw", commentId);
        return result;
    }

	/**
	 *  Gets list of activities by specified collection for a particular user.
	 *  App must request from user this scope: https://www.googleapis.com/auth/plus.login 
	 * or https://www.googleapis.com/auth/plus.me if used userId - 'me'. 	
	 * @param userId The identifier of user. If identifier 'me' see .
	 * @param collection The collection of activities to list.
	 *  Acceptable values are:
	 *  public - All public activities created by the specified user.
	 * @param maxResults The maximum activities in response. Acceptable values are 1 to 100.
	 * @param pageToken The continued token to next page. (Possible can be getted in response then can it use here)
	 * @return {Response} Return in response.
	 */
    this.GetListOfActivityRaw = function (userId, collection, maxResults, pageToken) {
        var result = _bNesisApi.Call("GooglePlus", this.bNesisToken, "GetListOfActivityRaw", userId, collection, maxResults, pageToken);
        return result;
    }

	/**
	 *  Gets activity by identifier. 	
	 * @param activityId The activity identifier.
	 * @return {Response} Return in response.
	 */
    this.GetActivityRaw = function (activityId) {
        var result = _bNesisApi.Call("GooglePlus", this.bNesisToken, "GetActivityRaw", activityId);
        return result;
    }

	/**
	 *  Search public activities. 	
	 * @param query Full-text query string.
	 * @param language Specify the preferred language to search with. All code languages see: https://developers.google.com/+/web/api/rest/search#available-languages
	 * @param maxResults The maximum activities in response. Acceptable values are 1 to 20.
	 * @param orderType Specifies how to order search results. 
	 *  Acceptable values are:
	 *  best - Sort activities by relevance to the user, most relevant first.
	 *  recent - Sort activities by published date, most recent first. (default)
	 * @param pageToken The continued token to next page. (Possible can be getted in response then can it use here)
	 * @return {Response} Return in response.
	 */
    this.FindActivitiesRaw = function (query, language, maxResults, orderType, pageToken) {
        var result = _bNesisApi.Call("GooglePlus", this.bNesisToken, "FindActivitiesRaw", query, language, maxResults, orderType, pageToken);
        return result;
    }
}
/**
 * Implementation class of GooglePlusEmails. 
 * @typedef {Object} GooglePlusEmail
 */
 GooglePlusEmail = function () { 
	/**
	 * The email address.
	 * @type {string}
	 */
	this.value = "";

	/**
	 * The type address.
	 *   Possible values are:
	 *   account - Google account email address.
	 *   home - Home email address.
	 *   work - Work email address.
	 *   other - Other.
	 * @type {string}
	 */
	this.type = "";

}

/**
 * Implementation class of GooglePlusUrl 
 * @typedef {Object} GooglePlusUrl
 */
 GooglePlusUrl = function () { 
	/**
	 * The type of URL.
	 *   Possible values are:
	 *   otherProfile - URL for another profile.
	 *   contributor - URL to a site for which this person is a contributor.
	 *   website - URL for this Google+ Page's primary website.
	 *   other - Other URL.
	 * @type {string}
	 */
	this.value = "";

	/**
	 * The URL value.
	 * @type {string}
	 */
	this.type = "";

	/**
	 * The label of the URL.
	 * @type {string}
	 */
	this.label = "";

}

/**
 * Implementation class of GooglePlusName. 
 * @typedef {Object} GooglePlusName
 */
 GooglePlusName = function () { 
	/**
	 * The full name of person.
	 * @type {string}
	 */
	this.formatted = "";

	/**
	 * The family(last) name of person.
	 * @type {string}
	 */
	this.familyName = "";

	/**
	 * The given(first) name of person.
	 * @type {string}
	 */
	this.givenName = "";

	/**
	 * The middle name of person.
	 * @type {string}
	 */
	this.middleName = "";

	/**
	 * The honorific prefixes (such as "Dr." or "Mrs.") for person.
	 * @type {string}
	 */
	this.honorificPrefix = "";

	/**
	 * The honorific suffixes (such as "Jr.") for person.
	 * @type {string}
	 */
	this.honorificSuffix = "";

}

/**
 * Implementation class of GooglePlusImage. 
 * @typedef {Object} GooglePlusImage
 */
 GooglePlusImage = function () { 
	/**
	 * The URL of the image.
	 * @type {string}
	 */
	this.url = "";

	/**
	 * Media type of the link.
	 * @type {string}
	 */
	this.type = "";

	/**
	 * Image height. (Can be unspecified)
	 * @type {Int32}
	 */
	this.height = 0;

	/**
	 * Image width. (Can be unspecified)
	 * @type {Int32}
	 */
	this.width = 0;

}

/**
 * Implementation class of GooglePlusOrganization. 
 * @typedef {Object} GooglePlusOrganization
 */
 GooglePlusOrganization = function () { 
	/**
	 * The organization name.
	 * @type {string}
	 */
	this.name = "";

	/**
	 * The department within the organization.
	 * @type {string}
	 */
	this.department = "";

	/**
	 * The person's job title or role of this organization.
	 * @type {string}
	 */
	this.title = "";

	/**
	 * The type of organization.
	 *  Possible values are:
	 *   work - Work.
	 *   school - School.
	 * @type {string}
	 */
	this.type = "";

	/**
	 * The date that the person joined this organization.
	 * @type {string}
	 */
	this.startDate = "";

	/**
	 * The date that the person left this organization.
	 * @type {string}
	 */
	this.endDate = "";

	/**
	 * The location of this organization.
	 * @type {string}
	 */
	this.location = "";

	/**
	 * The short description of the person's role of this organization.
	 * @type {string}
	 */
	this.description = "";

	/**
	 * If true this organization is the current one.
	 * @type {Boolean}
	 */
	this.primary = false;

}

/**
 * Implementation class of GooglePlusPlaceLived. 
 * @typedef {Object} GooglePlusPlaceLived
 */
 GooglePlusPlaceLived = function () { 
	/**
	 * A place where person live.
	 * @type {string}
	 */
	this.value = "";

	/**
	 * If true, this place of residence is this person's primary residence.
	 * @type {Boolean}
	 */
	this.primary = false;

}

/**
 * Implementation class of GooglePlusAgeRange. 
 * @typedef {Object} GooglePlusAgeRange
 */
 GooglePlusAgeRange = function () { 
	/**
	 * The age range lower bound.
	 * @type {Int32}
	 */
	this.min = 0;

	/**
	 * The age range upper bound.
	 * @type {Int32}
	 */
	this.max = 0;

}

/**
 * Implementation class of GooglePlusCoverPhoto 
 * @typedef {Object} GooglePlusCoverPhoto
 */
 GooglePlusCoverPhoto = function () { 
	/**
	 * The URL of the image.
	 * @type {string}
	 */
	this.url = "";

	/**
	 * The image height.
	 * @type {Int32}
	 */
	this.height = 0;

	/**
	 * The image width.
	 * @type {Int32}
	 */
	this.width = 0;

}

/**
 * Implementation class of GooglePlusCoverInfo. 
 * @typedef {Object} GooglePlusCoverInfo
 */
 GooglePlusCoverInfo = function () { 
	/**
	 * The difference between the top position of the cover image and the actual displayed cover image. 
	 *   Only valid for banner layout.
	 * @type {Int32}
	 */
	this.topImageOffset = 0;

	/**
	 * The difference between the left position of the cover image and the actual displayed cover image
	 *   Only valid for banner layout.
	 * @type {Int32}
	 */
	this.leftImageOffset = 0;

}

/**
 * Implementation class of GooglePlusCover 
 * @typedef {Object} GooglePlusCover
 */
 GooglePlusCover = function () { 
	/**
	 * The layout of the cover art.
	 *   Possible values are:
	 *   banner - One large image banner.
	 *   See also: https://developers.google.com/+/web/api/rest/latest/people#cover.layout
	 * @type {string}
	 */
	this.layout = "";

	/**
	 * The person's primary cover image.
	 * @type {GooglePlusCoverPhoto}
	 */
	this.coverPhoto = new GooglePlusCoverPhoto();

	/**
	 * Extra information about the cover photo.
	 * @type {GooglePlusCoverInfo}
	 */
	this.coverInfo = new GooglePlusCoverInfo();

}

/**
 * Implementation class of GooglePlusProfile. 
 * @typedef {Object} GooglePlusProfile
 */
 GooglePlusProfile = function () { 
	/**
	 * Identifies this resource.
	 * @type {string}
	 */
	this.kind = "";

	/**
	 * The identifier of this profile.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * ETag of this profile.
	 * @type {string}
	 */
	this.etag = "";

	/**
	 * The nickname of this profile.
	 * @type {string}
	 */
	this.nickname = "";

	/**
	 * The occupation of this profile.
	 * @type {string}
	 */
	this.occupation = "";

	/**
	 * The person's skills.
	 * @type {string}
	 */
	this.skills = "";

	/**
	 * The person's date of birth. (Format: YYYY-MM-DD)
	 * @type {string}
	 */
	this.birthday = "";

	/**
	 * The person's gender.
	 *   Possible values are:
	 *   male - Male gender.
	 *   female - Female gender.
	 *   other - Other.
	 * @type {string}
	 */
	this.gender = "";

	/**
	 * The array of email which has in this profile.
	 * @type {GooglePlusEmail[]}
	 */
	this.emails = new Array();

	/**
	 * The array of url which has in this profile.
	 * @type {GooglePlusUrl[]}
	 */
	this.urls = new Array();

	/**
	 * The type of this profile .
	 *   Possible values are:
	 *   person - represents an actual person.
	 *   page - represents a page.
	 * @type {string}
	 */
	this.objectType = "";

	/**
	 * The person name, which is displayed.
	 * @type {string}
	 */
	this.displayName = "";

	/**
	 * An object representation of the individual components of a person's name.
	 * @type {GooglePlusName}
	 */
	this.name = new GooglePlusName();

	/**
	 * The brief description (tagline) in this profile.
	 * @type {string}
	 */
	this.tagline = "";

	/**
	 * The "bragging rights" line in this profile.
	 * @type {string}
	 */
	this.braggingRights = "";

	/**
	 * A short biography.
	 * @type {string}
	 */
	this.aboutMe = "";

	/**
	 * The person's relationship status.
	 *   Possible values are:
	 *   single - Person is single.
	 *   in_a_relationship - Person is in a relationship.
	 *   engaged - Person is engaged.
	 *   married - Person is married.
	 *   See also: https://developers.google.com/+/web/api/rest/latest/people#relationshipStatus
	 * @type {string}
	 */
	this.relationshipStatus = "";

	/**
	 * The url to person's profile.
	 * @type {string}
	 */
	this.url = "";

	/**
	 * The representation of person's profile photo.
	 * @type {GooglePlusImage}
	 */
	this.image = new GooglePlusImage();

	/**
	 * The array of orgainzation with which person is associated.
	 * @type {GooglePlusOrganization[]}
	 */
	this.organizations = new Array();

	/**
	 * The array of place where person is lived.
	 * @type {GooglePlusPlaceLived[]}
	 */
	this.placesLived = new Array();

	/**
	 * Whether this user has signed up for Google+.
	 * @type {Boolean}
	 */
	this.isPlusUser = false;

	/**
	 * The person's preferred language.
	 * @type {string}
	 */
	this.language = "";

	/**
	 * The age range of the person.
	 * @type {GooglePlusAgeRange}
	 */
	this.ageRange = new GooglePlusAgeRange();

	/**
	 * If a Google+ Page, the number of people who have +1'd this page.
	 * @type {Int32}
	 */
	this.plusOneCount = 0;

	/**
	 * Followers who are visible, the number of people who have added this person or page to a circle.
	 * @type {Int32}
	 */
	this.circledByCount = 0;

	/**
	 * Whether the person or Google+ Page has been verified. This is used only for pages with a higher risk of being impersonated or similar.
	 *   This flag will not be present on most profiles, so is can be null.
	 * @type {Nullable<Boolean>}
	 */
	this.verified = false;

	/**
	 * The cover photo content.
	 * @type {GooglePlusCover}
	 */
	this.cover = new GooglePlusCover();

	/**
	 * The hosted domain name for the user's Google Apps account.
	 * @type {string}
	 */
	this.domain = "";

}

/**
 * Implementation class of GooglePlusProfileCollection. 
 * @typedef {Object} GooglePlusProfileCollection
 */
 GooglePlusProfileCollection = function () { 
	/**
	 * Identifier the resource.
	 * @type {string}
	 */
	this.kind = "";

	/**
	 * ETag of this response for caching purposes.
	 * @type {string}
	 */
	this.etag = "";

	/**
	 * Link to this resource.
	 * @type {string}
	 */
	this.selfLink = "";

	/**
	 * The title of collection.
	 * @type {string}
	 */
	this.title = "";

	/**
	 * The next page token to collection.
	 * @type {string}
	 */
	this.nextPageToken = "";

	/**
	 * The total items.
	 * @type {Int32}
	 */
	this.totalItems = 0;

	/**
	 * The array of GooglePlusProfile.
	 * @type {GooglePlusProfile[]}
	 */
	this.items = new Array();

}

/**
 * Implementation class of GooglePlusActor. 
 * @typedef {Object} GooglePlusActor
 */
 GooglePlusActor = function () { 
	/**
	 * The identifier of the actor.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The formated name of the actor.
	 * @type {string}
	 */
	this.displayName = "";

	/**
	 * The representation of actor name.
	 * @type {GooglePlusName}
	 */
	this.name = new GooglePlusName();

	/**
	 * A link to the Person for this actor.
	 * @type {string}
	 */
	this.url = "";

	/**
	 * The image representation for this actor.
	 * @type {GooglePlusImage}
	 */
	this.image = new GooglePlusImage();

}

/**
 * Implementation class of GooglePlusCommentContent. 
 * @typedef {Object} GooglePlusCommentContent
 */
 GooglePlusCommentContent = function () { 
	/**
	 * The object type.
	 *  Possible values are:
	 * comment - A comment in reply to an activity.
	 * @type {string}
	 */
	this.objectType = "";

	/**
	 * The HTML-formatted content.
	 * @type {string}
	 */
	this.content = "";

	/**
	 * The content without HTML-formatted.
	 * @type {string}
	 */
	this.originalContent = "";

}

/**
 * Implementation class of GooglePlusInReplyTo 
 * @typedef {Object} GooglePlusInReplyTo
 */
 GooglePlusInReplyTo = function () { 
	/**
	 * The identifier of activity.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The url of activity.
	 * @type {string}
	 */
	this.url = "";

}

/**
 * Implementation class of GooglePlusAboutItem. 
 * @typedef {Object} GooglePlusAboutItem
 */
 GooglePlusAboutItem = function () { 
	/**
	 * The number of.
	 * @type {Int32}
	 */
	this.totalItems = 0;

	/**
	 * The URL of.
	 * @type {string}
	 */
	this.selfLink = "";

}

/**
 * Implementation class of GooglePlusComment 
 * @typedef {Object} GooglePlusComment
 */
 GooglePlusComment = function () { 
	/**
	 * Identifier this resources as a comment.
	 * @type {string}
	 */
	this.kind = "";

	/**
	 * The identifier.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * ETag of this response for caching purposes
	 * @type {string}
	 */
	this.etag = "";

	/**
	 * This comment's verb, indicating what action was performed.
	 *   Possible values are:
	 *   post - Publish content to the stream.
	 * @type {string}
	 */
	this.verb = "";

	/**
	 * When comment created.
	 * @type {string}
	 */
	this.published = "";

	/**
	 * When comment updated.
	 * @type {string}
	 */
	this.updated = "";

	/**
	 * Actor who write comment.
	 * @type {GooglePlusActor}
	 */
	this.actor = new GooglePlusActor();

	/**
	 * Content contain some information about of comment.
	 * @type {GooglePlusCommentContent}
	 */
	this.content = new GooglePlusCommentContent();

	/**
	 * Link to this comment resource.
	 * @type {string}
	 */
	this.selfLink = "";

	/**
	 * The activity this comment replied to.
	 * @type {GooglePlusInReplyTo[]}
	 */
	this.inReplyTo = new Array();

	/**
	 * People who +1'd this comment ''.
	 * @type {GooglePlusAboutItem}
	 */
	this.plusoners = new GooglePlusAboutItem();

}

/**
 * Implementation class of GooglePlusCommentCollection. 
 * @typedef {Object} GooglePlusCommentCollection
 */
 GooglePlusCommentCollection = function () { 
	/**
	 * Identifier the resource.
	 * @type {string}
	 */
	this.kind = "";

	/**
	 * ETag of this response for caching purposes.
	 * @type {string}
	 */
	this.etag = "";

	/**
	 * Link to next page.
	 * @type {string}
	 */
	this.nextLink = "";

	/**
	 * The title of collection.
	 * @type {string}
	 */
	this.title = "";

	/**
	 * The next page token to collection.
	 * @type {string}
	 */
	this.nextPageToken = "";

	/**
	 * When updated.
	 * @type {string}
	 */
	this.updated = "";

	/**
	 * The identifier of collection.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * Some description.
	 * @type {string}
	 */
	this.description = "";

	/**
	 * The array of GooglePlusComment.
	 * @type {GooglePlusComment[]}
	 */
	this.items = new Array();

}

/**
 * Implementation class of GooglePlusEmbed. 
 * @typedef {Object} GooglePlusEmbed
 */
 GooglePlusEmbed = function () { 
	/**
	 * URL of the link.
	 * @type {string}
	 */
	this.url = "";

	/**
	 * Media type of the link
	 * @type {string}
	 */
	this.type = "";

}

/**
 * Implementation class of GooglePlusThumbnail. 
 * @typedef {Object} GooglePlusThumbnail
 */
 GooglePlusThumbnail = function () { 
	/**
	 * The URL to album.
	 * @type {string}
	 */
	this.url = "";

	/**
	 * The description of album.
	 * @type {string}
	 */
	this.description = "";

	/**
	 * Image resource.
	 * @type {GooglePlusImage}
	 */
	this.image = new GooglePlusImage();

}

/**
 * Implementation class of GooglePlusAttachment. 
 * @typedef {Object} GooglePlusAttachment
 */
 GooglePlusAttachment = function () { 
	/**
	 * The identifier of attachment.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The type of media object.
	 *   Possible values are:
	 *   photo - A photo.
	 *   album - A photo album.
	 *   video - A video.
	 *   article - An article, specified by a link.
	 * @type {string}
	 */
	this.objectType = "";

	/**
	 * The title of attachment.
	 * @type {string}
	 */
	this.displayName = "";

	/**
	 * Contain description for .
	 * @type {string}
	 */
	this.content = "";

	/**
	 * The link to attachment.
	 * @type {string}
	 */
	this.url = "";

	/**
	 * Preview for photos or videos.
	 * @type {GooglePlusImage}
	 */
	this.image = new GooglePlusImage();

	/**
	 * The full image URL for attachment.
	 * @type {GooglePlusImage}
	 */
	this.fullImage = new GooglePlusImage();

	/**
	 * If attachment is video, the emdedable link.
	 * @type {GooglePlusEmbed}
	 */
	this.embed = new GooglePlusEmbed();

	/**
	 * If attachment is album contain list of potential additional thumbnails from the album.
	 * @type {GooglePlusThumbnail[]}
	 */
	this.thumbnails = new Array();

}

/**
 * Implementation class of GooglePlusActivityContent. 
 * @typedef {Object} GooglePlusActivityContent
 */
 GooglePlusActivityContent = function () { 
	/**
	 * The identifier of this content.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The type of the content.
	 *   Possible values are:
	 *   note - textual content.
	 *   activity - A Google+ activity.
	 * @type {string}
	 */
	this.objectType = "";

	/**
	 * If this activity's object is itself another activity, such as when a person reshares an activity,
	 *  this property specifies the original activity's actor.
	 * @type {GooglePlusActor}
	 */
	this.actor = new GooglePlusActor();

	/**
	 * The HTML-formatted content.
	 * @type {string}
	 */
	this.content = "";

	/**
	 * The content(text) without HTML.
	 * @type {string}
	 */
	this.originalContent = "";

	/**
	 * The URL to the resource.
	 * @type {string}
	 */
	this.url = "";

	/**
	 * Total number of comments on this activity.
	 *  ( - number of comments)
	 * @type {GooglePlusAboutItem}
	 */
	this.replies = new GooglePlusAboutItem();

	/**
	 * People who +1'd this activity.
	 *   ( - number of people)
	 * @type {GooglePlusAboutItem}
	 */
	this.plusoners = new GooglePlusAboutItem();

	/**
	 * People who reshared this activity.
	 *   ( - number of people)
	 * @type {GooglePlusAboutItem}
	 */
	this.resharers = new GooglePlusAboutItem();

	/**
	 * The media objects attached to this activity.
	 * @type {GooglePlusAttachment[]}
	 */
	this.attachments = new Array();

}

/**
 * Implementation class of GooglePlusProvider 
 * @typedef {Object} GooglePlusProvider
 */
 GooglePlusProvider = function () { 
	/**
	 * Name of the service provider.
	 * @type {string}
	 */
	this.title = "";

}

/**
 * Implementation class of GooglePlusAccess. 
 * @typedef {Object} GooglePlusAccess
 */
 GooglePlusAccess = function () { 
	/**
	 * The identifier of entry for circle or person .
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The type of entry for whom have access is granted.
	 *   Possible values are:
	 *   person - Access to an individual.
	 *   circle - Access to members of a circle.
	 *   "myCircles - Access to members of all the person's circles.
	 *   extendedCircles - Access to members of all the person's circles, plus all of the people in their circles.
	 *   domain - Access to members of the person's Google Apps domain.
	 *   public - Access to anyone on the web.
	 * @type {string}
	 */
	this.type = "";

	/**
	 * A descriptive name for this entry.
	 * @type {string}
	 */
	this.displayName = "";

}

/**
 * Implementation class of GooglePlusPosition. 
 * @typedef {Object} GooglePlusPosition
 */
 GooglePlusPosition = function () { 
	/**
	 * The latitude of this position.
	 * @type {Single}
	 */
	this.latitude = new Single();

	/**
	 * The longitude of this position.
	 * @type {Single}
	 */
	this.longitude = new Single();

}

/**
 * Implementation class of GooglePlusAddress. 
 * @typedef {Object} GooglePlusAddress
 */
 GooglePlusAddress = function () { 
	/**
	 * The formated address.
	 * @type {string}
	 */
	this.formatted = "";

}

/**
 * Implementation class of GooglePlusLocation. 
 * @typedef {Object} GooglePlusLocation
 */
 GooglePlusLocation = function () { 
	/**
	 * Identifies this resource as a place.
	 * @type {string}
	 */
	this.kind = "";

	/**
	 * The identifier of the location.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The name of the place
	 * @type {string}
	 */
	this.displayName = "";

	/**
	 * The position of the place.
	 * @type {GooglePlusPosition}
	 */
	this.position = new GooglePlusPosition();

	/**
	 * The physical address of the place.
	 * @type {GooglePlusAddress}
	 */
	this.address = new GooglePlusAddress();

}

/**
 * Implementation class of GooglePlusActivity. 
 * @typedef {Object} GooglePlusActivity
 */
 GooglePlusActivity = function () { 
	/**
	 * The identifier of this activity.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * Identifies this resource as an activity
	 * @type {string}
	 */
	this.kind = "";

	/**
	 * ETag of this response for caching purposes
	 * @type {string}
	 */
	this.etag = "";

	/**
	 * The title of this activity.
	 * @type {string}
	 */
	this.title = "";

	/**
	 * The time when this activity initially published.
	 * @type {string}
	 */
	this.published = "";

	/**
	 * The time when this activity was updated.
	 * @type {string}
	 */
	this.updated = "";

	/**
	 * The link to this activity.
	 * @type {string}
	 */
	this.url = "";

	/**
	 * The person who perfomed this activity.
	 * @type {GooglePlusActor}
	 */
	this.actor = new GooglePlusActor();

	/**
	 * This activity's verb, which indicates the action that was performed.
	 *   Possible values are:
	 *   post - Publish content to the stream.
	 *   share - Reshare an activity.
	 * @type {string}
	 */
	this.verb = "";

	/**
	 * The content of this activity.
	 * @type {GooglePlusActivityContent}
	 */
	this.activityContent = new GooglePlusActivityContent();

	/**
	 * Additional content added by the person who shared this activity, applicable only when resharing an activity.
	 * @type {string}
	 */
	this.annotation = "";

	/**
	 * If this activity is a crosspost from another system, this property specifies the ID of the original activity.
	 * @type {string}
	 */
	this.crosspostSource = "";

	/**
	 * The service provider who published this activity.
	 * @type {GooglePlusProvider}
	 */
	this.provider = new GooglePlusProvider();

	/**
	 * Identifies who has access to see this activity.
	 * @type {GooglePlusAccess}
	 */
	this.access = new GooglePlusAccess();

	/**
	 * Latitude and longitude where this activity occurred. Format is latitude followed by longitude, space separated.
	 * @type {string}
	 */
	this.geocode = "";

	/**
	 * Street address where this activity occurred.
	 * @type {string}
	 */
	this.address = "";

	/**
	 * Radius, in meters, of the region where this activity occurred, centered at the latitude and longitude identified in .
	 * @type {string}
	 */
	this.radius = "";

	/**
	 * The identifier of the place where this activity occurred.
	 * @type {string}
	 */
	this.placeId = "";

	/**
	 * Name of the place where this activity occurred.
	 * @type {string}
	 */
	this.placeName = "";

	/**
	 * The location where this activity occurred.
	 * @type {GooglePlusLocation}
	 */
	this.location = new GooglePlusLocation();

}

/**
 * Implementation class of GooglePlusActivityCollection. 
 * @typedef {Object} GooglePlusActivityCollection
 */
 GooglePlusActivityCollection = function () { 
	/**
	 * Identifier the resource.
	 * @type {string}
	 */
	this.kind = "";

	/**
	 * ETag of this response for caching purposes.
	 * @type {string}
	 */
	this.etag = "";

	/**
	 * Link to this resource.
	 * @type {string}
	 */
	this.selfLink = "";

	/**
	 * Link to next page.
	 * @type {string}
	 */
	this.nextLink = "";

	/**
	 * The title of collection.
	 * @type {string}
	 */
	this.title = "";

	/**
	 * The next page token to collection.
	 * @type {string}
	 */
	this.nextPageToken = "";

	/**
	 * When update
	 * @type {string}
	 */
	this.updated = "";

	/**
	 * The identifier of collection.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The array of GooglePlusActivity.
	 * @type {GooglePlusActivity[]}
	 */
	this.items = new Array();

}

