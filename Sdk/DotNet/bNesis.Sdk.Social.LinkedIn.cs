using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;
using bNesis.Api.Desktop;
using bNesis.Sdk.Common;

namespace bNesis.Sdk.Social.LinkedIn
{
	public class LinkedIn  
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

		public LinkedIn(DesktopbNesisApi bNesisApi)
		{
			this.bNesisApi = bNesisApi;
		}

		/// <summary>
		/// The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		/// </summary>
		/// <returns>bNesisToken value</returns>	
		public string Auth(string data,string bNesisDevId,string redirectUrl,string clientId,string clientSecret,string[] scopes,string login,string password,bool isSandbox,string serviceUrl)
		{
			bNesisToken = bNesisApi.Auth("LinkedIn", data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl);
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
			bool result = bNesisApi.LogoffService("LinkedIn", bNesisToken);
			if (result) bNesisToken = string.Empty;
			return result;             
		}


		///<summary>
		/// Getting last exception for current provider 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo GetLastError()
		{
			return bNesisApi.Call<ErrorInfo>("LinkedIn", bNesisToken, "GetLastError");
		}

		///<summary>
		/// Getting arrays of error info 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo[] GetErrorLog()
		{
			return bNesisApi.Call<ErrorInfo[]>("LinkedIn", bNesisToken, "GetErrorLog");
		}

		///<summary>
		/// Checks the token in the service. 
		/// </summary>
		/// <returns>if token valid return true, if token not valid return false</returns>
		public Boolean ValidateToken()
		{
			return bNesisApi.Call<Boolean>("LinkedIn", bNesisToken, "ValidateToken");
		}

		///<summary>
		/// Disables the access token used to authenticate the call. 
		/// </summary>
		/// <returns>if token revoked method returns true 
		/// if token doesn't support token revocation or token is revoked method returns false</returns>
		public Boolean Logoff()
		{
			return bNesisApi.Call<Boolean>("LinkedIn", bNesisToken, "Logoff");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ContactItem GetFieldsUserUnified(string id)
		{
			return bNesisApi.Call<ContactItem>("LinkedIn", bNesisToken, "GetFieldsUserUnified", id);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="id"></param>
		/// <param name="field"></param>
		/// <returns></returns>
		public ContactItem GetFieldUserUnified(string id, string field)
		{
			return bNesisApi.Call<ContactItem>("LinkedIn", bNesisToken, "GetFieldUserUnified", id, field);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ContactItem GetUserAboutUnified(string id)
		{
			return bNesisApi.Call<ContactItem>("LinkedIn", bNesisToken, "GetUserAboutUnified", id);
		}

		///<summary>
		/// Gets current member basic profile based on the access token.
		///  App must request from member this scope: r_basicprofile, r_emailaddress. 
		/// </summary>
		/// <returns>Return in response.</returns>
		public LinkedInMemberBasicProfile GetMemberProfileV1()
		{
			return bNesisApi.Call<LinkedInMemberBasicProfile>("LinkedIn", bNesisToken, "GetMemberProfileV1");
		}

		///<summary>
		/// Gets current member simple profile based on the access token.
		///  App must request from member this scope: r_basicprofile, 
		/// </summary>
		/// <returns>Return in response.</returns>
		public LinkedInMemberBasicProfile GetMemberSimpleProfileV1()
		{
			return bNesisApi.Call<LinkedInMemberBasicProfile>("LinkedIn", bNesisToken, "GetMemberSimpleProfileV1");
		}

		///<summary>
		/// Gets current member profile based on the access token, with input specified fields. 
		/// </summary>
		/// <param name="fields">Possible input fields values are:
		/// id, first-name, second-name, maiden-name, location, industry, positions, etc.
		/// For more information see: https://developer.linkedin.com/docs/fields/basic-profile</param>
		/// <returns>Return in response.</returns>
		public LinkedInMemberBasicProfile GetMemberProfileSpecificFieldsV1(string[] fields)
		{
			return bNesisApi.Call<LinkedInMemberBasicProfile>("LinkedIn", bNesisToken, "GetMemberProfileSpecificFieldsV1", fields);
		}

		///<summary>
		/// Creates a new post on the LinkedIn member page.
		///  Permissions and Limits see: https://developer.linkedin.com/docs/share-on-linkedin 
		/// </summary>
		/// <param name="content">The content is required.</param>
		/// <returns>Return in response.</returns>
		public Boolean SharePost(LinkedInShare content)
		{
			return bNesisApi.Call<Boolean>("LinkedIn", bNesisToken, "SharePost", content);
		}

		///<summary>
		/// Gets company profile by identifier.
		///  Member based on token must have permission access 'Administrator' to company. 
		/// </summary>
		/// <param name="companyId">Company identifier.</param>
		/// <returns>Return in response.</returns>
		public LinkedInCompany GetCompanyProfileV1(Int32 companyId)
		{
			return bNesisApi.Call<LinkedInCompany>("LinkedIn", bNesisToken, "GetCompanyProfileV1", companyId);
		}

		///<summary>
		/// Gets company simple profile by identifier.
		///  Member based on token must have permission access 'Administrator' to company. 
		/// </summary>
		/// <param name="companyId">Company identifier.</param>
		/// <returns>Return in response.</returns>
		public LinkedInCompany GetCompanySimpleProfileV1(Int32 companyId)
		{
			return bNesisApi.Call<LinkedInCompany>("LinkedIn", bNesisToken, "GetCompanySimpleProfileV1", companyId);
		}

		///<summary>
		/// Gets company profile with input specified fields.
		///  Member based on token must have permission access 'Administrator' to company. 
		/// </summary>
		/// <param name="companyId">Company identifier.</param>
		/// <param name="fields">Possible values are: id, name, type, industry, ticker
		///      For more information see:https://developer.linkedin.com/docs/fields/companies</param>
		/// <returns>Return in response.</returns>
		public LinkedInCompany GetCompanyProfileSpecificFieldsV1(Int32 companyId, string[] fields)
		{
			return bNesisApi.Call<LinkedInCompany>("LinkedIn", bNesisToken, "GetCompanyProfileSpecificFieldsV1", companyId, fields);
		}

		///<summary>
		/// Gets current member basic profile based on the access token.
		///  App must request from member this scope: r_basicprofile, r_emailaddress. 
		/// </summary>
		/// <returns>Return in response.</returns>
		public Response GetMemberProfileV1Raw()
		{
			return bNesisApi.Call<Response>("LinkedIn", bNesisToken, "GetMemberProfileV1Raw");
		}

		///<summary>
		/// Gets current member simple profile based on the access token.
		///  App must request from member this scope: r_basicprofile, 
		/// </summary>
		/// <returns>Return in response.</returns>
		public Response GetMemberSimpleProfileV1Raw()
		{
			return bNesisApi.Call<Response>("LinkedIn", bNesisToken, "GetMemberSimpleProfileV1Raw");
		}

		///<summary>
		/// Gets current member profile based on the access token, with input specified fields. 
		/// </summary>
		/// <param name="fields">Possible input fields values are:
		/// id, first-name, second-name, maiden-name, location, industry, positions, etc.
		/// For more information see: https://developer.linkedin.com/docs/fields/basic-profile</param>
		/// <returns>Return in response.</returns>
		public Response GetMemberProfileSpecificFieldsV1Raw(string[] fields)
		{
			return bNesisApi.Call<Response>("LinkedIn", bNesisToken, "GetMemberProfileSpecificFieldsV1Raw", fields);
		}

		///<summary>
		/// Gets current member profile based on the access token. 
		/// </summary>
		/// <returns>Return in response.</returns>
		public Response GetMemberProfileRaw()
		{
			return bNesisApi.Call<Response>("LinkedIn", bNesisToken, "GetMemberProfileRaw");
		}

		///<summary>
		/// Gets the specific members. 
		/// </summary>
		/// <param name="personIds">The members ids which need get.</param>
		/// <returns>Return in response.</returns>
		public Response GetSpecificMembersRaw(Int32[] personIds)
		{
			return bNesisApi.Call<Response>("LinkedIn", bNesisToken, "GetSpecificMembersRaw", personIds);
		}

		///<summary>
		/// Gets member profile by identifier. 
		/// </summary>
		/// <param name="personId">The member identifier.</param>
		/// <returns>Return in response.</returns>
		public Response GetMemberByIdentifierRaw(Int32 personId)
		{
			return bNesisApi.Call<Response>("LinkedIn", bNesisToken, "GetMemberByIdentifierRaw", personId);
		}

		///<summary>
		/// Gets member profile only with specific fields. 
		/// </summary>
		/// <param name="personId">The member identifier.</param>
		/// <param name="fields">The fields. 
		/// Example:id,firstname etc. 
		/// (See also: https://developer.linkedin.com/docs/ref/v2/profile - Basic or Full Profile Fields)</param>
		/// <returns>Return in response.</returns>
		public Response GetMemberByIdentifierWithSelectedFiedsRaw(Int32 personId, string[] fields)
		{
			return bNesisApi.Call<Response>("LinkedIn", bNesisToken, "GetMemberByIdentifierWithSelectedFiedsRaw", personId, fields);
		}

		///<summary>
		/// Gets location name. 
		/// </summary>
		/// <param name="locationKey">Need standardized location key. 
		/// Format: urn:li:standardizedLocationKey:(country,PostalCode) 
		/// Can be getted from member field 'location'->'standardizedLocationKey'</param>
		/// <returns>Return in response.</returns>
		public Response GetLocationNameRaw(string locationKey)
		{
			return bNesisApi.Call<Response>("LinkedIn", bNesisToken, "GetLocationNameRaw", locationKey);
		}

		///<summary>
		/// Gets location name. 
		/// </summary>
		/// <param name="countryURN">The country URN. (Format: urn:li:country )</param>
		/// <param name="placeCode">The place code. (Can be getted from member field 'location'->'userSelectedGeoPlaceCode')</param>
		/// <returns>Return in response.</returns>
		public Response GetLocationNameByGeoPlaceCodeRaw(string countryURN, string placeCode)
		{
			return bNesisApi.Call<Response>("LinkedIn", bNesisToken, "GetLocationNameByGeoPlaceCodeRaw", countryURN, placeCode);
		}

		///<summary>
		/// Creates a new post on the LinkedIn member page.
		///  Permissions and Limits see: https://developer.linkedin.com/docs/share-on-linkedin 
		/// </summary>
		/// <param name="contentBody">Content with information for post. (Required json)</param>
		/// <returns>Return in response.</returns>
		public Response SharePostRaw(Object contentBody)
		{
			return bNesisApi.Call<Response>("LinkedIn", bNesisToken, "SharePostRaw", contentBody);
		}

		///<summary>
		/// Gets company profile by identifier.
		///  Member based on token must have permission access 'Administrator' to company. 
		/// </summary>
		/// <param name="companyId">Company identifier.</param>
		/// <returns>Return in response.</returns>
		public Response GetCompanyProfileV1Raw(Int32 companyId)
		{
			return bNesisApi.Call<Response>("LinkedIn", bNesisToken, "GetCompanyProfileV1Raw", companyId);
		}

		///<summary>
		/// Gets company simple profile by identifier.
		///  Member based on token must have permission access 'Administrator' to company. 
		/// </summary>
		/// <param name="companyId">Company identifier.</param>
		/// <returns>Return in response.</returns>
		public Response GetCompanySimpleProfileV1Raw(Int32 companyId)
		{
			return bNesisApi.Call<Response>("LinkedIn", bNesisToken, "GetCompanySimpleProfileV1Raw", companyId);
		}

		///<summary>
		/// Gets company profile with input specified fields.
		///  Member based on token must have permission access 'Administrator' to company. 
		/// </summary>
		/// <param name="companyId">Company identifier.</param>
		/// <param name="fields">Possible values are: id, name, type, industry, ticker
		///      For more information see:https://developer.linkedin.com/docs/fields/companies</param>
		/// <returns>Return in response.</returns>
		public Response GetCompanyProfileSpecificFieldsV1Raw(Int32 companyId, string[] fields)
		{
			return bNesisApi.Call<Response>("LinkedIn", bNesisToken, "GetCompanyProfileSpecificFieldsV1Raw", companyId, fields);
		}
}
	///<summary>
	/// Implementation class of Country. 
	/// </summary>
	public class LinkedInCountry
	{
		/// <summary>
		/// Contains country code. 
		/// </summary>
		public string code { get; set; }

	}

	///<summary>
	/// Implementation class of Location. 
	/// </summary>
	public class LinkedInLocation
	{
		/// <summary>
		/// The country. 
		/// </summary>
		public LinkedInCountry country { get; set; }

		/// <summary>
		/// Country name. 
		/// </summary>
		public string name { get; set; }

	}

	///<summary>
	/// Implementation class of Company. 
	/// </summary>
	public class LinkedInCompany
	{
		/// <summary>
		/// The company identifier. 
		/// </summary>
		public Int32 id { get; set; }

		/// <summary>
		/// The company industry name. 
		/// </summary>
		public string industry { get; set; }

		/// <summary>
		/// The company name. 
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// The company size. 
		/// </summary>
		public string size { get; set; }

		/// <summary>
		/// The company type. 
		/// </summary>
		public string type { get; set; }

	}

	///<summary>
	/// Implementation class of Company. 
	/// </summary>
	public class LinkedInCompanyInfo
	{
		/// <summary>
		/// The company. 
		/// </summary>
		public LinkedInCompany company { get; set; }

		/// <summary>
		/// The identifier of company info. 
		/// </summary>
		public Int32 id { get; set; }

		/// <summary>
		/// The member is now at this company. 
		/// </summary>
		public Boolean isCurrent { get; set; }

		/// <summary>
		/// Company location. 
		/// </summary>
		public LinkedInLocation location { get; set; }

		/// <summary>
		/// The title. 
		/// </summary>
		public string title { get; set; }

	}

	///<summary>
	/// Implementation class of Positions 
	/// </summary>
	public class LinkedInPositions
	{
		/// <summary>
		/// Count values. 
		/// </summary>
		public Int32 total { get; set; }

		/// <summary>
		/// Can contains information about companies. 
		/// </summary>
		public LinkedInCompanyInfo[] values { get; set; }

	}

	///<summary>
	/// Implementation class of SiteStandardProfileRequest. 
	/// </summary>
	public class LinkedInSiteStandardProfileRequest
	{
		/// <summary>
		/// Can be contains url to member profile with request. 
		/// </summary>
		public string url { get; set; }

	}

	///<summary>
	/// Implementation class of BasicProfile. 
	///     Contains information of member LinkedIn. 
	/// </summary>
	public class LinkedInMemberBasicProfile
	{
		/// <summary>
		/// The member contact e-mail. 
		/// </summary>
		public string emailAddress { get; set; }

		/// <summary>
		/// The member first name. 
		/// </summary>
		public string firstName { get; set; }

		/// <summary>
		/// The member formated name. 
		/// </summary>
		public string formattedName { get; set; }

		/// <summary>
		/// The member last name. 
		/// </summary>
		public string headline { get; set; }

		/// <summary>
		/// The member identifier. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The industry the member belongs to. 
		/// </summary>
		public string industry { get; set; }

		/// <summary>
		/// The member last name. 
		/// </summary>
		public string lastName { get; set; }

		/// <summary>
		/// Contains information about member location. 
		/// </summary>
		public LinkedInLocation location { get; set; }

		/// <summary>
		/// The number of connections to LinkedIn. 
		/// </summary>
		public Int32 numConnections { get; set; }

		/// <summary>
		/// If true, the member has count connections capped. 
		/// </summary>
		public Boolean numConnectionsCapped { get; set; }

		/// <summary>
		/// The picture url. 
		/// </summary>
		public string pictureUrl { get; set; }

		/// <summary>
		/// Represents member current position. 
		/// </summary>
		public LinkedInPositions positions { get; set; }

		/// <summary>
		/// The member public profile url. 
		/// </summary>
		public string publicProfileUrl { get; set; }

		/// <summary>
		/// The member site standart profile request. 
		/// </summary>
		public LinkedInSiteStandardProfileRequest siteStandardProfileRequest { get; set; }

	}

	///<summary>
	/// Implementation class of Content. 
	/// </summary>
	public class LinkedInContent
	{
		/// <summary>
		/// The content title. 
		/// </summary>
		public string title { get; set; }

		/// <summary>
		/// Some description. 
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// A fully qualified URL for the content being shared. 
		/// </summary>
		public string submittedUrl { get; set; }

		/// <summary>
		/// A fully qualified URL to a thumbnail image to accompany the shared content. (Image should be at least 80 x 150px) 
		/// </summary>
		public string submittedImageUrl { get; set; }

	}

	///<summary>
	/// Implementation class of Visibility. 
	/// </summary>
	public class LinkedInVisibility
	{
		/// <summary>
		/// A collection of visibility information about the share..
		///  Possible values are:
		///  anyone:  Share will be visible to all members.
		///  connections-only:  Share will only be visible to connections of the member performing the share. 
		/// </summary>
		public string code { get; set; }

	}

	///<summary>
	/// Implementation class of Share. 
	/// </summary>
	public class LinkedInShare
	{
		/// <summary>
		/// The commentary. 
		/// </summary>
		public string comment { get; set; }

		/// <summary>
		/// The content. 
		/// </summary>
		public LinkedInContent content { get; set; }

		/// <summary>
		/// Who can see this post. 
		/// </summary>
		public LinkedInVisibility visibility { get; set; }

	}

}