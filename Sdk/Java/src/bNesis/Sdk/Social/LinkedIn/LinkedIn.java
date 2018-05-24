package bNesis.Sdk.Social.LinkedIn;

import java.io.*;
import java.util.List;
import java.util.Date;
import java.util.Map.Entry;
import bNesis.Api.*;

import bNesis.Sdk.Common.*;
import bNesis.Sdk.Social.LinkedIn.*;
import java.net.URI.*;

	public class LinkedIn  
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

		public LinkedIn(bNesisApi bnesisApi)
		{
			this._bNesisApi = bnesisApi;
		}

		/**
		 * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		 * @return {String} bNesisToken value
		 */
		public String Auth(String bNesisDevId,String clientId,String clientSecret,String redirectUrl,String[] scopes) throws Exception
		{
			bNesisToken = _bNesisApi.Auth("LinkedIn", "",bNesisDevId,redirectUrl,clientId,clientSecret,scopes,"","",false,"");
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
			Boolean result = _bNesisApi.LogoffService("LinkedIn", bNesisToken);
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
			return _bNesisApi.<ErrorInfo>Call(ErrorInfo.class, "LinkedIn", bNesisToken, "GetLastError");
		}

		/**
		 *  Getting arrays of error info 	
		 * @return {ErrorInfo[]}  
		 * @throws Exception
		 */
		public ErrorInfo[] GetErrorLog() throws Exception
		{
			return _bNesisApi.<ErrorInfo[]>Call(ErrorInfo[].class, "LinkedIn", bNesisToken, "GetErrorLog");
		}

		/**
		 *  Checks the token in the service. 	
		 * @return {Boolean} if token valid return true, if token not valid return false 
		 * @throws Exception
		 */
		public Boolean ValidateToken() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "LinkedIn", bNesisToken, "ValidateToken");
		}

		/**
		 *  Disables the access token used to authenticate the call. 	
		 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false 
		 * @throws Exception
		 */
		public Boolean Logoff() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "LinkedIn", bNesisToken, "Logoff");
		}

		/**
		 *   	
		 * @param id 
	 * @return {ContactItem}  
		 * @throws Exception
		 */
		public ContactItem GetFieldsUserUnified(String id) throws Exception
		{
			return _bNesisApi.<ContactItem>Call(ContactItem.class, "LinkedIn", bNesisToken, "GetFieldsUserUnified", id);
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
			return _bNesisApi.<ContactItem>Call(ContactItem.class, "LinkedIn", bNesisToken, "GetFieldUserUnified", id, field);
		}

		/**
		 *   	
		 * @param id 
	 * @return {ContactItem}  
		 * @throws Exception
		 */
		public ContactItem GetUserAboutUnified(String id) throws Exception
		{
			return _bNesisApi.<ContactItem>Call(ContactItem.class, "LinkedIn", bNesisToken, "GetUserAboutUnified", id);
		}

		/**
		 *  Gets current member basic profile based on the access token.
	 *  App must request from member this scope: r_basicprofile, r_emailaddress. 	
		 * @return {LinkedInMemberBasicProfile} Return in response. 
		 * @throws Exception
		 */
		public LinkedInMemberBasicProfile GetMemberProfileV1() throws Exception
		{
			return _bNesisApi.<LinkedInMemberBasicProfile>Call(LinkedInMemberBasicProfile.class, "LinkedIn", bNesisToken, "GetMemberProfileV1");
		}

		/**
		 *  Gets current member simple profile based on the access token.
	 *  App must request from member this scope: r_basicprofile, 	
		 * @return {LinkedInMemberBasicProfile} Return in response. 
		 * @throws Exception
		 */
		public LinkedInMemberBasicProfile GetMemberSimpleProfileV1() throws Exception
		{
			return _bNesisApi.<LinkedInMemberBasicProfile>Call(LinkedInMemberBasicProfile.class, "LinkedIn", bNesisToken, "GetMemberSimpleProfileV1");
		}

		/**
		 *  Gets current member profile based on the access token, with input specified fields. 	
		 * @param fields Possible input fields values are:
	 * id, first-name, second-name, maiden-name, location, industry, positions, etc.
	 * For more information see: https://developer.linkedin.com/docs/fields/basic-profile
	 * @return {LinkedInMemberBasicProfile} Return in response. 
		 * @throws Exception
		 */
		public LinkedInMemberBasicProfile GetMemberProfileSpecificFieldsV1(String[] fields) throws Exception
		{
			return _bNesisApi.<LinkedInMemberBasicProfile>Call(LinkedInMemberBasicProfile.class, "LinkedIn", bNesisToken, "GetMemberProfileSpecificFieldsV1", fields);
		}

		/**
		 *  Creates a new post on the LinkedIn member page.
	 *  Permissions and Limits see: https://developer.linkedin.com/docs/share-on-linkedin 	
		 * @param content The content is required.
	 * @return {Boolean} Return in response. 
		 * @throws Exception
		 */
		public Boolean SharePost(LinkedInShare content) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "LinkedIn", bNesisToken, "SharePost", content);
		}

		/**
		 *  Gets company profile by identifier.
	 *  Member based on token must have permission access 'Administrator' to company. 	
		 * @param companyId Company identifier.
	 * @return {LinkedInCompany} Return in response. 
		 * @throws Exception
		 */
		public LinkedInCompany GetCompanyProfileV1(Integer companyId) throws Exception
		{
			return _bNesisApi.<LinkedInCompany>Call(LinkedInCompany.class, "LinkedIn", bNesisToken, "GetCompanyProfileV1", companyId);
		}

		/**
		 *  Gets company simple profile by identifier.
	 *  Member based on token must have permission access 'Administrator' to company. 	
		 * @param companyId Company identifier.
	 * @return {LinkedInCompany} Return in response. 
		 * @throws Exception
		 */
		public LinkedInCompany GetCompanySimpleProfileV1(Integer companyId) throws Exception
		{
			return _bNesisApi.<LinkedInCompany>Call(LinkedInCompany.class, "LinkedIn", bNesisToken, "GetCompanySimpleProfileV1", companyId);
		}

		/**
		 *  Gets company profile with input specified fields.
	 *  Member based on token must have permission access 'Administrator' to company. 	
		 * @param companyId Company identifier.
	 * @param fields Possible values are: id, name, type, industry, ticker
	 *      For more information see:https://developer.linkedin.com/docs/fields/companies
	 * @return {LinkedInCompany} Return in response. 
		 * @throws Exception
		 */
		public LinkedInCompany GetCompanyProfileSpecificFieldsV1(Integer companyId, String[] fields) throws Exception
		{
			return _bNesisApi.<LinkedInCompany>Call(LinkedInCompany.class, "LinkedIn", bNesisToken, "GetCompanyProfileSpecificFieldsV1", companyId, fields);
		}

		/**
		 *  Gets current member basic profile based on the access token.
	 *  App must request from member this scope: r_basicprofile, r_emailaddress. 	
		 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response GetMemberProfileV1Raw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "LinkedIn", bNesisToken, "GetMemberProfileV1Raw");
		}

		/**
		 *  Gets current member simple profile based on the access token.
	 *  App must request from member this scope: r_basicprofile, 	
		 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response GetMemberSimpleProfileV1Raw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "LinkedIn", bNesisToken, "GetMemberSimpleProfileV1Raw");
		}

		/**
		 *  Gets current member profile based on the access token, with input specified fields. 	
		 * @param fields Possible input fields values are:
	 * id, first-name, second-name, maiden-name, location, industry, positions, etc.
	 * For more information see: https://developer.linkedin.com/docs/fields/basic-profile
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response GetMemberProfileSpecificFieldsV1Raw(String[] fields) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "LinkedIn", bNesisToken, "GetMemberProfileSpecificFieldsV1Raw", fields);
		}

		/**
		 *  Gets current member profile based on the access token. 	
		 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response GetMemberProfileRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "LinkedIn", bNesisToken, "GetMemberProfileRaw");
		}

		/**
		 *  Gets the specific members. 	
		 * @param personIds The members ids which need get.
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response GetSpecificMembersRaw(Integer[] personIds) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "LinkedIn", bNesisToken, "GetSpecificMembersRaw", personIds);
		}

		/**
		 *  Gets member profile by identifier. 	
		 * @param personId The member identifier.
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response GetMemberByIdentifierRaw(Integer personId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "LinkedIn", bNesisToken, "GetMemberByIdentifierRaw", personId);
		}

		/**
		 *  Gets member profile only with specific fields. 	
		 * @param personId The member identifier.
	 * @param fields The fields. 
	 * Example:id,firstname etc. 
	 * (See also: https://developer.linkedin.com/docs/ref/v2/profile - Basic or Full Profile Fields)
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response GetMemberByIdentifierWithSelectedFiedsRaw(Integer personId, String[] fields) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "LinkedIn", bNesisToken, "GetMemberByIdentifierWithSelectedFiedsRaw", personId, fields);
		}

		/**
		 *  Gets location name. 	
		 * @param locationKey Need standardized location key. 
	 * Format: urn:li:standardizedLocationKey:(country,PostalCode) 
	 * Can be getted from member field 'location'->'standardizedLocationKey'
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response GetLocationNameRaw(String locationKey) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "LinkedIn", bNesisToken, "GetLocationNameRaw", locationKey);
		}

		/**
		 *  Gets location name. 	
		 * @param countryURN The country URN. (Format: urn:li:country )
	 * @param placeCode The place code. (Can be getted from member field 'location'->'userSelectedGeoPlaceCode')
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response GetLocationNameByGeoPlaceCodeRaw(String countryURN, String placeCode) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "LinkedIn", bNesisToken, "GetLocationNameByGeoPlaceCodeRaw", countryURN, placeCode);
		}

		/**
		 *  Creates a new post on the LinkedIn member page.
	 *  Permissions and Limits see: https://developer.linkedin.com/docs/share-on-linkedin 	
		 * @param contentBody Content with information for post. (Required json)
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response SharePostRaw(Object contentBody) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "LinkedIn", bNesisToken, "SharePostRaw", contentBody);
		}

		/**
		 *  Gets company profile by identifier.
	 *  Member based on token must have permission access 'Administrator' to company. 	
		 * @param companyId Company identifier.
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response GetCompanyProfileV1Raw(Integer companyId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "LinkedIn", bNesisToken, "GetCompanyProfileV1Raw", companyId);
		}

		/**
		 *  Gets company simple profile by identifier.
	 *  Member based on token must have permission access 'Administrator' to company. 	
		 * @param companyId Company identifier.
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response GetCompanySimpleProfileV1Raw(Integer companyId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "LinkedIn", bNesisToken, "GetCompanySimpleProfileV1Raw", companyId);
		}

		/**
		 *  Gets company profile with input specified fields.
	 *  Member based on token must have permission access 'Administrator' to company. 	
		 * @param companyId Company identifier.
	 * @param fields Possible values are: id, name, type, industry, ticker
	 *      For more information see:https://developer.linkedin.com/docs/fields/companies
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response GetCompanyProfileSpecificFieldsV1Raw(Integer companyId, String[] fields) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "LinkedIn", bNesisToken, "GetCompanyProfileSpecificFieldsV1Raw", companyId, fields);
		}
}