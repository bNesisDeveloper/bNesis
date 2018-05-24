package bNesis.Sdk.Social.GooglePlus;

import java.io.*;
import java.util.List;
import java.util.Date;
import java.util.Map.Entry;
import bNesis.Api.*;

import bNesis.Sdk.Common.*;
import bNesis.Sdk.Social.GooglePlus.*;
import java.net.URI.*;

	public class GooglePlus  
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

		public GooglePlus(bNesisApi bnesisApi)
		{
			this._bNesisApi = bnesisApi;
		}

		/**
		 * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		 * @return {String} bNesisToken value
		 */
		public String Auth(String bNesisDevId,String clientId,String clientSecret,String redirectUrl,String[] scopes,String data) throws Exception
		{
			bNesisToken = _bNesisApi.Auth("Google", data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,"","",false,"");
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
			Boolean result = _bNesisApi.LogoffService("Google", bNesisToken);
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
			return _bNesisApi.<ErrorInfo>Call(ErrorInfo.class, "GooglePlus", bNesisToken, "GetLastError");
		}

		/**
		 *  Getting arrays of error info 	
		 * @return {ErrorInfo[]}  
		 * @throws Exception
		 */
		public ErrorInfo[] GetErrorLog() throws Exception
		{
			return _bNesisApi.<ErrorInfo[]>Call(ErrorInfo[].class, "GooglePlus", bNesisToken, "GetErrorLog");
		}

		/**
		 *  Checks the token in the service. 	
		 * @return {Boolean} if token valid return true, if token not valid return false 
		 * @throws Exception
		 */
		public Boolean ValidateToken() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "GooglePlus", bNesisToken, "ValidateToken");
		}

		/**
		 *  Disables the access token used to authenticate the call. 	
		 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false 
		 * @throws Exception
		 */
		public Boolean Logoff() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "GooglePlus", bNesisToken, "Logoff");
		}

		/**
		 *   	
		 * @param id 
	 * @return {ContactItem}  
		 * @throws Exception
		 */
		public ContactItem GetFieldsUserUnified(String id) throws Exception
		{
			return _bNesisApi.<ContactItem>Call(ContactItem.class, "GooglePlus", bNesisToken, "GetFieldsUserUnified", id);
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
			return _bNesisApi.<ContactItem>Call(ContactItem.class, "GooglePlus", bNesisToken, "GetFieldUserUnified", id, field);
		}

		/**
		 *   	
		 * @param id 
	 * @return {ContactItem}  
		 * @throws Exception
		 */
		public ContactItem GetUserAboutUnified(String id) throws Exception
		{
			return _bNesisApi.<ContactItem>Call(ContactItem.class, "GooglePlus", bNesisToken, "GetUserAboutUnified", id);
		}

		/**
		 *  Gets current user profile based on token.
	 * For see all information about user, app must request from member this scope: https://www.googleapis.com/auth/plus.me, https://www.googleapis.com/auth/plus.login,
	 * https://www.googleapis.com/auth/userinfo.email, https://www.googleapis.com/auth/userinfo.profile 	
		 * @return {GooglePlusProfile} Return in GooglePlusProfile. 
		 * @throws Exception
		 */
		public GooglePlusProfile GetAboutMe() throws Exception
		{
			return _bNesisApi.<GooglePlusProfile>Call(GooglePlusProfile.class, "GooglePlus", bNesisToken, "GetAboutMe");
		}

		/**
		 *  Gets user profile by identifier. 	
		 * @param userId User identifier. If identifier is 'me' see .
	 * @return {GooglePlusProfile} Return in GooglePlusProfile. 
		 * @throws Exception
		 */
		public GooglePlusProfile GetUserProfile(String userId) throws Exception
		{
			return _bNesisApi.<GooglePlusProfile>Call(GooglePlusProfile.class, "GooglePlus", bNesisToken, "GetUserProfile", userId);
		}

		/**
		 *  Search all public profiles. 	
		 * @param query Specify a query string for full text search of public text in all profiles.
	 * @param language Specify the preferred language to search with. All code languages see: https://developers.google.com/+/web/api/rest/search#available-languages
	 * @param maxResults The maximum number of people returned on response. Acceptable, values are 1 to 50.
	 * @param pageToken The continion token to next page. (Possible can be getted in response then can it use here)
	 * @return {GooglePlusProfileCollection} Return in GooglePlusItemCollection. 
		 * @throws Exception
		 */
		public GooglePlusProfileCollection FindProfile(String query, String language, Integer maxResults, String pageToken) throws Exception
		{
			return _bNesisApi.<GooglePlusProfileCollection>Call(GooglePlusProfileCollection.class, "GooglePlus", bNesisToken, "FindProfile", query, language, maxResults, pageToken);
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
		 * @throws Exception
		 */
		public GooglePlusProfileCollection GetListPeopleByActivity(String id, String collection, Integer maxResults, String pageToken) throws Exception
		{
			return _bNesisApi.<GooglePlusProfileCollection>Call(GooglePlusProfileCollection.class, "GooglePlus", bNesisToken, "GetListPeopleByActivity", id, collection, maxResults, pageToken);
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
		 * @throws Exception
		 */
		public GooglePlusProfileCollection GetListPeople(String id, String collection, String orderBy, Integer maxResults, String pageToken) throws Exception
		{
			return _bNesisApi.<GooglePlusProfileCollection>Call(GooglePlusProfileCollection.class, "GooglePlus", bNesisToken, "GetListPeople", id, collection, orderBy, maxResults, pageToken);
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
		 * @throws Exception
		 */
		public GooglePlusCommentCollection GetListOfComment(String activityId, Integer maxResults, String pageToken, String sortOrder) throws Exception
		{
			return _bNesisApi.<GooglePlusCommentCollection>Call(GooglePlusCommentCollection.class, "GooglePlus", bNesisToken, "GetListOfComment", activityId, maxResults, pageToken, sortOrder);
		}

		/**
		 *  Gets a comment by identifier. 	
		 * @param commentId The comment identifier.
	 * @return {GooglePlusComment} Return in GooglePlusComment. 
		 * @throws Exception
		 */
		public GooglePlusComment GetComment(String commentId) throws Exception
		{
			return _bNesisApi.<GooglePlusComment>Call(GooglePlusComment.class, "GooglePlus", bNesisToken, "GetComment", commentId);
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
		 * @throws Exception
		 */
		public GooglePlusActivityCollection GetListOfActivity(String userId, String collection, Integer maxResults, String pageToken) throws Exception
		{
			return _bNesisApi.<GooglePlusActivityCollection>Call(GooglePlusActivityCollection.class, "GooglePlus", bNesisToken, "GetListOfActivity", userId, collection, maxResults, pageToken);
		}

		/**
		 *  Gets activity by identifier. 	
		 * @param activityId The activity identifier.
	 * @return {GooglePlusActivity} Return in GooglePlusActivity. 
		 * @throws Exception
		 */
		public GooglePlusActivity GetActivity(String activityId) throws Exception
		{
			return _bNesisApi.<GooglePlusActivity>Call(GooglePlusActivity.class, "GooglePlus", bNesisToken, "GetActivity", activityId);
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
		 * @throws Exception
		 */
		public GooglePlusActivityCollection FindActivities(String query, String language, Integer maxResults, String orderType, String pageToken) throws Exception
		{
			return _bNesisApi.<GooglePlusActivityCollection>Call(GooglePlusActivityCollection.class, "GooglePlus", bNesisToken, "FindActivities", query, language, maxResults, orderType, pageToken);
		}

		/**
		 *  Gets current user profile based on token.
	 * For see all information about user, app must request from member this scope: https://www.googleapis.com/auth/plus.me, https://www.googleapis.com/auth/plus.login,
	 * https://www.googleapis.com/auth/userinfo.email, https://www.googleapis.com/auth/userinfo.profile 	
		 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response GetAboutMeRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "GooglePlus", bNesisToken, "GetAboutMeRaw");
		}

		/**
		 *  Gets user profile by identifier. 	
		 * @param userId User identifier. If identifier is 'me' see .
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response GetUserProfileRaw(String userId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "GooglePlus", bNesisToken, "GetUserProfileRaw", userId);
		}

		/**
		 *  Search all public profiles. 	
		 * @param query Specify a query string for full text search of public text in all profiles.
	 * @param language Specify the preferred language to search with. All code languages see: https://developers.google.com/+/web/api/rest/search#available-languages
	 * @param maxResults The maximum number of people returned on response. Acceptable values are 1 to 50.
	 * @param pageToken The continued token to next page. (Possible can be getted in response then can it use here)
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response FindProfileRaw(String query, String language, Integer maxResults, String pageToken) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "GooglePlus", bNesisToken, "FindProfileRaw", query, language, maxResults, pageToken);
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
		 * @throws Exception
		 */
		public Response GetListPeopleByActivityRaw(String id, String collection, Integer maxResults, String pageToken) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "GooglePlus", bNesisToken, "GetListPeopleByActivityRaw", id, collection, maxResults, pageToken);
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
		 * @throws Exception
		 */
		public Response GetListPeopleRaw(String id, String collection, String orderBy, Integer maxResults, String pageToken) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "GooglePlus", bNesisToken, "GetListPeopleRaw", id, collection, orderBy, maxResults, pageToken);
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
		 * @throws Exception
		 */
		public Response GetListOfCommentRaw(String activityId, Integer maxResults, String pageToken, String sortOrder) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "GooglePlus", bNesisToken, "GetListOfCommentRaw", activityId, maxResults, pageToken, sortOrder);
		}

		/**
		 *  Gets a comment by identifier. 	
		 * @param commentId The comment identifier.
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response GetCommentRaw(String commentId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "GooglePlus", bNesisToken, "GetCommentRaw", commentId);
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
		 * @throws Exception
		 */
		public Response GetListOfActivityRaw(String userId, String collection, Integer maxResults, String pageToken) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "GooglePlus", bNesisToken, "GetListOfActivityRaw", userId, collection, maxResults, pageToken);
		}

		/**
		 *  Gets activity by identifier. 	
		 * @param activityId The activity identifier.
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response GetActivityRaw(String activityId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "GooglePlus", bNesisToken, "GetActivityRaw", activityId);
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
		 * @throws Exception
		 */
		public Response FindActivitiesRaw(String query, String language, Integer maxResults, String orderType, String pageToken) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "GooglePlus", bNesisToken, "FindActivitiesRaw", query, language, maxResults, orderType, pageToken);
		}
}