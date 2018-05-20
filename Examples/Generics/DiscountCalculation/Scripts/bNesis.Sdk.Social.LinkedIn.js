LinkedIn = function (bNesisApi) {
    this.bNesisToken = null;
    var _bNesisApi = bNesisApi;

    this.Auth = function (data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl) {
        var bNesisToken = _bNesisApi.Auth("LinkedIn", data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl);
        return bNesisToken;
    }
	
	/**
	 *  Getting last exception for current provider 	
	 * @return {ErrorInfo} 
	 */
    this.GetLastError = function () {
        var result = _bNesisApi.Call("LinkedIn", this.bNesisToken, "GetLastError");
        return result;
    }

	/**
	 *  Getting arrays of error info 	
	 * @return {ErrorInfo[]} 
	 */
    this.GetErrorLog = function () {
        var result = _bNesisApi.Call("LinkedIn", this.bNesisToken, "GetErrorLog");
        return result;
    }

	/**
	 *  Checks the token in the service. 	
	 * @return {Boolean} if token valid return true, if token not valid return false
	 */
    this.ValidateToken = function () {
        var result = _bNesisApi.Call("LinkedIn", this.bNesisToken, "ValidateToken");
        return result;
    }

	/**
	 *  Disables the access token used to authenticate the call. 	
	 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false
	 */
    this.Logoff = function () {
        var result = _bNesisApi.Call("LinkedIn", this.bNesisToken, "Logoff");
        return result;
    }

	/**
	 *   	
	 * @param id 
	 * @return {ContactItem} 
	 */
    this.GetFieldsUserUnified = function (id) {
        var result = _bNesisApi.Call("LinkedIn", this.bNesisToken, "GetFieldsUserUnified", id);
        return result;
    }

	/**
	 *   	
	 * @param id 
	 * @param field 
	 * @return {ContactItem} 
	 */
    this.GetFieldUserUnified = function (id, field) {
        var result = _bNesisApi.Call("LinkedIn", this.bNesisToken, "GetFieldUserUnified", id, field);
        return result;
    }

	/**
	 *   	
	 * @param id 
	 * @return {ContactItem} 
	 */
    this.GetUserAboutUnified = function (id) {
        var result = _bNesisApi.Call("LinkedIn", this.bNesisToken, "GetUserAboutUnified", id);
        return result;
    }

	/**
	 *  Gets current member basic profile based on the access token.
	 *  App must request from member this scope: r_basicprofile, r_emailaddress. 	
	 * @return {LinkedInMemberBasicProfile} Return in response.
	 */
    this.GetMemberProfileV1 = function () {
        var result = _bNesisApi.Call("LinkedIn", this.bNesisToken, "GetMemberProfileV1");
        return result;
    }

	/**
	 *  Gets current member simple profile based on the access token.
	 *  App must request from member this scope: r_basicprofile, 	
	 * @return {LinkedInMemberBasicProfile} Return in response.
	 */
    this.GetMemberSimpleProfileV1 = function () {
        var result = _bNesisApi.Call("LinkedIn", this.bNesisToken, "GetMemberSimpleProfileV1");
        return result;
    }

	/**
	 *  Gets current member profile based on the access token, with input specified fields. 	
	 * @param fields Possible input fields values are:
	 * id, first-name, second-name, maiden-name, location, industry, positions, etc.
	 * For more information see: https://developer.linkedin.com/docs/fields/basic-profile
	 * @return {LinkedInMemberBasicProfile} Return in response.
	 */
    this.GetMemberProfileSpecificFieldsV1 = function (fields) {
        var result = _bNesisApi.Call("LinkedIn", this.bNesisToken, "GetMemberProfileSpecificFieldsV1", fields);
        return result;
    }

	/**
	 *  Creates a new post on the LinkedIn member page.
	 *  Permissions and Limits see: https://developer.linkedin.com/docs/share-on-linkedin 	
	 * @param content The content is required.
	 * @return {Boolean} Return in response.
	 */
    this.SharePost = function (content) {
        var result = _bNesisApi.Call("LinkedIn", this.bNesisToken, "SharePost", content);
        return result;
    }

	/**
	 *  Gets company profile by identifier.
	 *  Member based on token must have permission access 'Administrator' to company. 	
	 * @param companyId Company identifier.
	 * @return {LinkedInCompany} Return in response.
	 */
    this.GetCompanyProfileV1 = function (companyId) {
        var result = _bNesisApi.Call("LinkedIn", this.bNesisToken, "GetCompanyProfileV1", companyId);
        return result;
    }

	/**
	 *  Gets company simple profile by identifier.
	 *  Member based on token must have permission access 'Administrator' to company. 	
	 * @param companyId Company identifier.
	 * @return {LinkedInCompany} Return in response.
	 */
    this.GetCompanySimpleProfileV1 = function (companyId) {
        var result = _bNesisApi.Call("LinkedIn", this.bNesisToken, "GetCompanySimpleProfileV1", companyId);
        return result;
    }

	/**
	 *  Gets company profile with input specified fields.
	 *  Member based on token must have permission access 'Administrator' to company. 	
	 * @param companyId Company identifier.
	 * @param fields Possible values are: id, name, type, industry, ticker
	 *      For more information see:https://developer.linkedin.com/docs/fields/companies
	 * @return {LinkedInCompany} Return in response.
	 */
    this.GetCompanyProfileSpecificFieldsV1 = function (companyId, fields) {
        var result = _bNesisApi.Call("LinkedIn", this.bNesisToken, "GetCompanyProfileSpecificFieldsV1", companyId, fields);
        return result;
    }

	/**
	 *  Gets current member basic profile based on the access token.
	 *  App must request from member this scope: r_basicprofile, r_emailaddress. 	
	 * @return {Response} Return in response.
	 */
    this.GetMemberProfileV1Raw = function () {
        var result = _bNesisApi.Call("LinkedIn", this.bNesisToken, "GetMemberProfileV1Raw");
        return result;
    }

	/**
	 *  Gets current member simple profile based on the access token.
	 *  App must request from member this scope: r_basicprofile, 	
	 * @return {Response} Return in response.
	 */
    this.GetMemberSimpleProfileV1Raw = function () {
        var result = _bNesisApi.Call("LinkedIn", this.bNesisToken, "GetMemberSimpleProfileV1Raw");
        return result;
    }

	/**
	 *  Gets current member profile based on the access token, with input specified fields. 	
	 * @param fields Possible input fields values are:
	 * id, first-name, second-name, maiden-name, location, industry, positions, etc.
	 * For more information see: https://developer.linkedin.com/docs/fields/basic-profile
	 * @return {Response} Return in response.
	 */
    this.GetMemberProfileSpecificFieldsV1Raw = function (fields) {
        var result = _bNesisApi.Call("LinkedIn", this.bNesisToken, "GetMemberProfileSpecificFieldsV1Raw", fields);
        return result;
    }

	/**
	 *  Gets current member profile based on the access token. 	
	 * @return {Response} Return in response.
	 */
    this.GetMemberProfileRaw = function () {
        var result = _bNesisApi.Call("LinkedIn", this.bNesisToken, "GetMemberProfileRaw");
        return result;
    }

	/**
	 *  Gets the specific members. 	
	 * @param personIds The members ids which need get.
	 * @return {Response} Return in response.
	 */
    this.GetSpecificMembersRaw = function (personIds) {
        var result = _bNesisApi.Call("LinkedIn", this.bNesisToken, "GetSpecificMembersRaw", personIds);
        return result;
    }

	/**
	 *  Gets member profile by identifier. 	
	 * @param personId The member identifier.
	 * @return {Response} Return in response.
	 */
    this.GetMemberByIdentifierRaw = function (personId) {
        var result = _bNesisApi.Call("LinkedIn", this.bNesisToken, "GetMemberByIdentifierRaw", personId);
        return result;
    }

	/**
	 *  Gets member profile only with specific fields. 	
	 * @param personId The member identifier.
	 * @param fields The fields. 
	 * Example:id,firstname etc. 
	 * (See also: https://developer.linkedin.com/docs/ref/v2/profile - Basic or Full Profile Fields)
	 * @return {Response} Return in response.
	 */
    this.GetMemberByIdentifierWithSelectedFiedsRaw = function (personId, fields) {
        var result = _bNesisApi.Call("LinkedIn", this.bNesisToken, "GetMemberByIdentifierWithSelectedFiedsRaw", personId, fields);
        return result;
    }

	/**
	 *  Gets location name. 	
	 * @param locationKey Need standardized location key. 
	 * Format: urn:li:standardizedLocationKey:(country,PostalCode) 
	 * Can be getted from member field 'location'->'standardizedLocationKey'
	 * @return {Response} Return in response.
	 */
    this.GetLocationNameRaw = function (locationKey) {
        var result = _bNesisApi.Call("LinkedIn", this.bNesisToken, "GetLocationNameRaw", locationKey);
        return result;
    }

	/**
	 *  Gets location name. 	
	 * @param countryURN The country URN. (Format: urn:li:country )
	 * @param placeCode The place code. (Can be getted from member field 'location'->'userSelectedGeoPlaceCode')
	 * @return {Response} Return in response.
	 */
    this.GetLocationNameByGeoPlaceCodeRaw = function (countryURN, placeCode) {
        var result = _bNesisApi.Call("LinkedIn", this.bNesisToken, "GetLocationNameByGeoPlaceCodeRaw", countryURN, placeCode);
        return result;
    }

	/**
	 *  Creates a new post on the LinkedIn member page.
	 *  Permissions and Limits see: https://developer.linkedin.com/docs/share-on-linkedin 	
	 * @param contentBody Content with information for post. (Required json)
	 * @return {Response} Return in response.
	 */
    this.SharePostRaw = function (contentBody) {
        var result = _bNesisApi.Call("LinkedIn", this.bNesisToken, "SharePostRaw", contentBody);
        return result;
    }

	/**
	 *  Gets company profile by identifier.
	 *  Member based on token must have permission access 'Administrator' to company. 	
	 * @param companyId Company identifier.
	 * @return {Response} Return in response.
	 */
    this.GetCompanyProfileV1Raw = function (companyId) {
        var result = _bNesisApi.Call("LinkedIn", this.bNesisToken, "GetCompanyProfileV1Raw", companyId);
        return result;
    }

	/**
	 *  Gets company simple profile by identifier.
	 *  Member based on token must have permission access 'Administrator' to company. 	
	 * @param companyId Company identifier.
	 * @return {Response} Return in response.
	 */
    this.GetCompanySimpleProfileV1Raw = function (companyId) {
        var result = _bNesisApi.Call("LinkedIn", this.bNesisToken, "GetCompanySimpleProfileV1Raw", companyId);
        return result;
    }

	/**
	 *  Gets company profile with input specified fields.
	 *  Member based on token must have permission access 'Administrator' to company. 	
	 * @param companyId Company identifier.
	 * @param fields Possible values are: id, name, type, industry, ticker
	 *      For more information see:https://developer.linkedin.com/docs/fields/companies
	 * @return {Response} Return in response.
	 */
    this.GetCompanyProfileSpecificFieldsV1Raw = function (companyId, fields) {
        var result = _bNesisApi.Call("LinkedIn", this.bNesisToken, "GetCompanyProfileSpecificFieldsV1Raw", companyId, fields);
        return result;
    }
}
/**
 * Implementation class of Country. 
 * @typedef {Object} LinkedInCountry
 */
 LinkedInCountry = function () { 
	/**
	 * Contains country code.
	 * @type {string}
	 */
	this.code = "";

}

/**
 * Implementation class of Location. 
 * @typedef {Object} LinkedInLocation
 */
 LinkedInLocation = function () { 
	/**
	 * The country.
	 * @type {LinkedInCountry}
	 */
	this.country = new LinkedInCountry();

	/**
	 * Country name.
	 * @type {string}
	 */
	this.name = "";

}

/**
 * Implementation class of Company. 
 * @typedef {Object} LinkedInCompany
 */
 LinkedInCompany = function () { 
	/**
	 * The company identifier.
	 * @type {Int32}
	 */
	this.id = 0;

	/**
	 * The company industry name.
	 * @type {string}
	 */
	this.industry = "";

	/**
	 * The company name.
	 * @type {string}
	 */
	this.name = "";

	/**
	 * The company size.
	 * @type {string}
	 */
	this.size = "";

	/**
	 * The company type.
	 * @type {string}
	 */
	this.type = "";

}

/**
 * Implementation class of Company. 
 * @typedef {Object} LinkedInCompanyInfo
 */
 LinkedInCompanyInfo = function () { 
	/**
	 * The company.
	 * @type {LinkedInCompany}
	 */
	this.company = new LinkedInCompany();

	/**
	 * The identifier of company info.
	 * @type {Int32}
	 */
	this.id = 0;

	/**
	 * The member is now at this company.
	 * @type {Boolean}
	 */
	this.isCurrent = false;

	/**
	 * Company location.
	 * @type {LinkedInLocation}
	 */
	this.location = new LinkedInLocation();

	/**
	 * The title.
	 * @type {string}
	 */
	this.title = "";

}

/**
 * Implementation class of Positions 
 * @typedef {Object} LinkedInPositions
 */
 LinkedInPositions = function () { 
	/**
	 * Count values.
	 * @type {Int32}
	 */
	this.total = 0;

	/**
	 * Can contains information about companies.
	 * @type {LinkedInCompanyInfo[]}
	 */
	this.values = new Array();

}

/**
 * Implementation class of SiteStandardProfileRequest. 
 * @typedef {Object} LinkedInSiteStandardProfileRequest
 */
 LinkedInSiteStandardProfileRequest = function () { 
	/**
	 * Can be contains url to member profile with request.
	 * @type {string}
	 */
	this.url = "";

}

/**
 * Implementation class of BasicProfile. 
 *     Contains information of member LinkedIn. 
 * @typedef {Object} LinkedInMemberBasicProfile
 */
 LinkedInMemberBasicProfile = function () { 
	/**
	 * The member contact e-mail.
	 * @type {string}
	 */
	this.emailAddress = "";

	/**
	 * The member first name.
	 * @type {string}
	 */
	this.firstName = "";

	/**
	 * The member formated name.
	 * @type {string}
	 */
	this.formattedName = "";

	/**
	 * The member last name.
	 * @type {string}
	 */
	this.headline = "";

	/**
	 * The member identifier.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The industry the member belongs to.
	 * @type {string}
	 */
	this.industry = "";

	/**
	 * The member last name.
	 * @type {string}
	 */
	this.lastName = "";

	/**
	 * Contains information about member location.
	 * @type {LinkedInLocation}
	 */
	this.location = new LinkedInLocation();

	/**
	 * The number of connections to LinkedIn.
	 * @type {Int32}
	 */
	this.numConnections = 0;

	/**
	 * If true, the member has count connections capped.
	 * @type {Boolean}
	 */
	this.numConnectionsCapped = false;

	/**
	 * The picture url.
	 * @type {string}
	 */
	this.pictureUrl = "";

	/**
	 * Represents member current position.
	 * @type {LinkedInPositions}
	 */
	this.positions = new LinkedInPositions();

	/**
	 * The member public profile url.
	 * @type {string}
	 */
	this.publicProfileUrl = "";

	/**
	 * The member site standart profile request.
	 * @type {LinkedInSiteStandardProfileRequest}
	 */
	this.siteStandardProfileRequest = new LinkedInSiteStandardProfileRequest();

}

/**
 * Implementation class of Content. 
 * @typedef {Object} LinkedInContent
 */
 LinkedInContent = function () { 
	/**
	 * The content title.
	 * @type {string}
	 */
	this.title = "";

	/**
	 * Some description.
	 * @type {string}
	 */
	this.description = "";

	/**
	 * A fully qualified URL for the content being shared.
	 * @type {string}
	 */
	this.submittedUrl = "";

	/**
	 * A fully qualified URL to a thumbnail image to accompany the shared content. (Image should be at least 80 x 150px)
	 * @type {string}
	 */
	this.submittedImageUrl = "";

}

/**
 * Implementation class of Visibility. 
 * @typedef {Object} LinkedInVisibility
 */
 LinkedInVisibility = function () { 
	/**
	 * A collection of visibility information about the share..
	 *  Possible values are:
	 *  anyone:  Share will be visible to all members.
	 *  connections-only:  Share will only be visible to connections of the member performing the share.
	 * @type {string}
	 */
	this.code = "";

}

/**
 * Implementation class of Share. 
 * @typedef {Object} LinkedInShare
 */
 LinkedInShare = function () { 
	/**
	 * The commentary.
	 * @type {string}
	 */
	this.comment = "";

	/**
	 * The content.
	 * @type {LinkedInContent}
	 */
	this.content = new LinkedInContent();

	/**
	 * Who can see this post.
	 * @type {LinkedInVisibility}
	 */
	this.visibility = new LinkedInVisibility();

}

