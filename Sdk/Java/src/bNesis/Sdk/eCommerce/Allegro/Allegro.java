package bNesis.Sdk.eCommerce.Allegro;

import java.io.*;
import java.util.List;
import java.util.Date;
import java.util.Map.Entry;
import bNesis.Api.*;

import bNesis.Sdk.Common.*;
import java.net.URI.*;

	public class Allegro  
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

		public Allegro(bNesisApi bnesisApi)
		{
			this._bNesisApi = bnesisApi;
		}

		/**
		 * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		 * @return {String} bNesisToken value
		 */
		public String Auth(String bNesisDevId,String clientId,String clientSecret,String redirectUrl,String[] scopes,Boolean isSandbox,String data) throws Exception
		{
			bNesisToken = _bNesisApi.Auth("Allegro", data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,"","",isSandbox,"");
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
			Boolean result = _bNesisApi.LogoffService("Allegro", bNesisToken);
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
			return _bNesisApi.<ErrorInfo>Call(ErrorInfo.class, "Allegro", bNesisToken, "GetLastError");
		}

		/**
		 *  Getting arrays of error info 	
		 * @return {ErrorInfo[]}  
		 * @throws Exception
		 */
		public ErrorInfo[] GetErrorLog() throws Exception
		{
			return _bNesisApi.<ErrorInfo[]>Call(ErrorInfo[].class, "Allegro", bNesisToken, "GetErrorLog");
		}

		/**
		 *  Checks the token in the service. 	
		 * @return {Boolean} if token valid return true, if token not valid return false 
		 * @throws Exception
		 */
		public Boolean ValidateToken() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "Allegro", bNesisToken, "ValidateToken");
		}

		/**
		 *  Disables the access token used to authenticate the call. 	
		 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false 
		 * @throws Exception
		 */
		public Boolean Logoff() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "Allegro", bNesisToken, "Logoff");
		}

		/**
		 *   	
		 * @param contactItem 
	 * @return {Boolean}  
		 * @throws Exception
		 */
		public Boolean CreateCustomerUnified(ContactItem contactItem) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "Allegro", bNesisToken, "CreateCustomerUnified", contactItem);
		}

		/**
		 *   	
		 * @return {ContactItem[]}  
		 * @throws Exception
		 */
		public ContactItem[] GetCustomersUnified() throws Exception
		{
			return _bNesisApi.<ContactItem[]>Call(ContactItem[].class, "Allegro", bNesisToken, "GetCustomersUnified");
		}

		/**
		 *   	
		 * @param productItem 
	 * @return {Boolean}  
		 * @throws Exception
		 */
		public Boolean AddProductUnified(ProductItem productItem) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "Allegro", bNesisToken, "AddProductUnified", productItem);
		}

		/**
		 *   	
		 * @return {ProductItem[]}  
		 * @throws Exception
		 */
		public ProductItem[] GetProductsUnified() throws Exception
		{
			return _bNesisApi.<ProductItem[]>Call(ProductItem[].class, "Allegro", bNesisToken, "GetProductsUnified");
		}

		/**
		 *   	
		 * @param IdProduct 
	 * @return {Boolean}  
		 * @throws Exception
		 */
		public Boolean DeleteProductUnified(String IdProduct) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "Allegro", bNesisToken, "DeleteProductUnified", IdProduct);
		}

		/**
		 *   	
		 * @return {CountryItem[]}  
		 * @throws Exception
		 */
		public CountryItem[] GetCountriesUnified() throws Exception
		{
			return _bNesisApi.<CountryItem[]>Call(CountryItem[].class, "Allegro", bNesisToken, "GetCountriesUnified");
		}

		/**
		 *   	
		 * @return {Integer}  
		 * @throws Exception
		 */
		public Integer GetCountCountriesUnified() throws Exception
		{
			return _bNesisApi.<Integer>Call(Integer.class, "Allegro", bNesisToken, "GetCountCountriesUnified");
		}

		/**
		 *   	
		 * @param IdCountry 
	 * @return {CountryItem}  
		 * @throws Exception
		 */
		public CountryItem ReceiveCountryUnified(String IdCountry) throws Exception
		{
			return _bNesisApi.<CountryItem>Call(CountryItem.class, "Allegro", bNesisToken, "ReceiveCountryUnified", IdCountry);
		}

		/**
		 *   	
		 * @param IdCountry 
	 * @return {Boolean}  
		 * @throws Exception
		 */
		public Boolean DeleteCountryUnified(String IdCountry) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "Allegro", bNesisToken, "DeleteCountryUnified", IdCountry);
		}

		/**
		 *   	
		 * @param countryItem 
	 * @return {CountryItem}  
		 * @throws Exception
		 */
		public CountryItem CreateCountryUnified(CountryItem countryItem) throws Exception
		{
			return _bNesisApi.<CountryItem>Call(CountryItem.class, "Allegro", bNesisToken, "CreateCountryUnified", countryItem);
		}

		/**
		 *   	
		 * @param countryItem 
	 * @return {CountryItem}  
		 * @throws Exception
		 */
		public CountryItem UpdateCountryUnified(CountryItem countryItem) throws Exception
		{
			return _bNesisApi.<CountryItem>Call(CountryItem.class, "Allegro", bNesisToken, "UpdateCountryUnified", countryItem);
		}

		/**
		 *   	
		 * @param IdCustomer 
	 * @return {ContactItem}  
		 * @throws Exception
		 */
		public ContactItem ReceiveCustomerUnified(String IdCustomer) throws Exception
		{
			return _bNesisApi.<ContactItem>Call(ContactItem.class, "Allegro", bNesisToken, "ReceiveCustomerUnified", IdCustomer);
		}

		/**
		 *  Gets seller warranties.
	 * You are allowed to list only your warranties
	 * https://developer.allegro.pl/documentation/#!/after-sales-service-conditions/getPublicSellerListingUsingGET_2 	
		 * @param sellerUuid Seller Id
	 * @param offset It defines a number of a batch of returned data and is numbered from 0.
	 * @param limit It defines a number of elements on the page, which cannot be higher than the maximum limit supported by the resource.
	 * @return {Response} Seller warranties 
		 * @throws Exception
		 */
		public Response GetSellerWarrantiesRaw(String sellerUuid, Integer offset, Integer limit) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetSellerWarrantiesRaw", sellerUuid, offset, limit);
		}

		/**
		 *  Gets seller implied warranties.
	 * You are allowed to list only your implied warranties
	 * https://developer.allegro.pl/documentation/#!/after-sales-service-conditions/getPublicSellerListingUsingGET 	
		 * @param sellerUuid Seller Id
	 * @param offset It defines a number of a batch of returned data and is numbered from 0.
	 * @param limit It defines a number of elements on the page, which cannot be higher than the maximum limit supported by the resource.
	 * @return {Response} Seller implied warranties 
		 * @throws Exception
		 */
		public Response GetSellerImpliedWarrantiesRaw(String sellerUuid, Integer offset, Integer limit) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetSellerImpliedWarrantiesRaw", sellerUuid, offset, limit);
		}

		/**
		 *  Gets seller return policies.
	 * You are allowed to list only your return policies
	 * https://developer.allegro.pl/documentation/#!/after-sales-service-conditions/getPublicSellerListingUsingGET_1 	
		 * @param sellerUuid Seller Id
	 * @param offset It defines a number of a batch of returned data and is numbered from 0.
	 * @param limit It defines a number of elements on the page, which cannot be higher than the maximum limit supported by the resource.
	 * @return {Response} Seller return policies 
		 * @throws Exception
		 */
		public Response GetSellerReturnPoliciesRaw(String sellerUuid, Integer offset, Integer limit) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetSellerReturnPoliciesRaw", sellerUuid, offset, limit);
		}

		/**
		 *  Delete the user by id. 	
		 * @param userUuid The unique user id
	 * @return {Response} response message 
		 * @throws Exception
		 */
		public Response DeleteUserRaw(String userUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "DeleteUserRaw", userUuid);
		}

		/**
		 *  Update the user by id. 	
		 * @param userUuid The unique user id
	 * @param user User info for update
	 * @return {Response} Data with info about user after update 
		 * @throws Exception
		 */
		public Response UpdateUserRaw(String userUuid, String user) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "UpdateUserRaw", userUuid, user);
		}

		/**
		 *  Get the user by id. 	
		 * @param userUuid The unique user id
	 * @return {Response} Data with info about user 
		 * @throws Exception
		 */
		public Response GetUserRaw(String userUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetUserRaw", userUuid);
		}

		/**
		 *  Gets the user list. 	
		 * @return {Response} Data with info about list of user 
		 * @throws Exception
		 */
		public Response GetUserListRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetUserListRaw");
		}

		/**
		 *  Create the user. 	
		 * @param user New user info
	 * @return {Response} Data with info about new user 
		 * @throws Exception
		 */
		public Response CreateUserRaw(String user) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "CreateUserRaw", user);
		}

		/**
		 *  Changes a Buy Now price in a single offer
	 * https://developer.allegro.pl/documentation/#!/default/put_offers_offerId_change_price_commands_commandId 	
		 * @param offerUuid The unique offer id
	 * @param commandUuid UUID you generate to enforce idempotency
	 * @param command Command input data. Note that the amount field must be transferred as a string to avoid rounding errors. A currency must be provided as a 3-letter code as defined in ISO 4217.
	 * @return {Response} Updated Buy Now price in offer 
		 * @throws Exception
		 */
		public Response ChangeBuyNowPriceInOfferRaw(String offerUuid, String commandUuid, String command) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "ChangeBuyNowPriceInOfferRaw", offerUuid, commandUuid, command);
		}

		/**
		 *  [BETA] Provides publication report summary for given commandid
	 * https://developer.allegro.pl/documentation/#!/offer/getPublicationReportUsingGET 	
		 * @param commandUuid UUID you generate to enforce idempotency
	 * @return {Response} Offer publication data 
		 * @throws Exception
		 */
		public Response GetOffersPublicationReportSummaryByIdRaw(String commandUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetOffersPublicationReportSummaryByIdRaw", commandUuid);
		}

		/**
		 *  [BETA] Allows modification of multiple offers' publication at once.
	 * https://developer.allegro.pl/documentation/#!/offer/changePublicationStatusUsingPUT 	
		 * @param commandUuid UUID you generate to enforce idempotency
	 * @param publicationChangeCommandDto Command to change publication
	 * @return {Response} Updated offers' publication data 
		 * @throws Exception
		 */
		public Response ChangeOffersPublicationByIdRaw(String commandUuid, String publicationChangeCommandDto) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "ChangeOffersPublicationByIdRaw", commandUuid, publicationChangeCommandDto);
		}

		/**
		 *  Provides modification report summary for given commandid
	 * https://developer.allegro.pl/documentation/#!/offer/getGeneralReportUsingGET 	
		 * @param commandUuid UUID you generate to enforce idempotency
	 * @return {Response} Offer modification data 
		 * @throws Exception
		 */
		public Response GetOffersModificationReportSummaryByIdRaw(String commandUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetOffersModificationReportSummaryByIdRaw", commandUuid);
		}

		/**
		 *  Allows modification of multiple offers at once.
	 * https://developer.allegro.pl/documentation/#!/offer/modificationCommandUsingPUT 	
		 * @param commandUuid UUID you generate to enforce idempotency
	 * @param publicationChangeCommandDto command to change publication
	 * @return {Response} Updated offer modification data 
		 * @throws Exception
		 */
		public Response ChangeOffersModificationByIdRaw(String commandUuid, String publicationChangeCommandDto) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "ChangeOffersModificationByIdRaw", commandUuid, publicationChangeCommandDto);
		}

		/**
		 *  [BETA] Returns a list of seller's shipping rates. Seller authentication is required.
	 * https://developer.allegro.pl/documentation/#!/offer/get_sale_shipping_rates 	
		 * @param sellerUuid id of shipping rates owner
	 * @return {Response} List of seller's shipping rates 
		 * @throws Exception
		 */
		public Response GetSellersShippingRatesRaw(String sellerUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetSellersShippingRatesRaw", sellerUuid);
		}

		/**
		 *  Gets list of offers. 	
		 * @return {Response} Total list of offers 
		 * @throws Exception
		 */
		public Response GetAllOffersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetAllOffersRaw");
		}

		/**
		 *  [BETA] Gets list of offers for the saler. 	
		 * @return {Response} List of offers 
		 * @throws Exception
		 */
		public Response GetOffersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetOffersRaw");
		}

		/**
		 *  [BETA] Creates single offer 
	 * https://developer.allegro.pl/documentation/#!/offer/createOfferUsingPOST 	
		 * @param offer offer
	 * @return {Response} Data with info about user 
		 * @throws Exception
		 */
		public Response CreateOfferRaw(String offer) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "CreateOfferRaw", offer);
		}

		/**
		 *  [BETA] Returns a list of available delivery methods. Client authentication is required.
	 * https://developer.allegro.pl/documentation/#!/offer/get_sale_delivery_methods 	
		 * @return {Response} list of available delivery methods 
		 * @throws Exception
		 */
		public Response GetDeliveryMethodsRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetDeliveryMethodsRaw");
		}

		/**
		 *  [BETA] Gets single offer by id
	 * https://developer.allegro.pl/documentation/#!/offer/getOfferUsingGET 	
		 * @param offerUuid The unique offer id
	 * @return {Response} Offer data info 
		 * @throws Exception
		 */
		public Response GetOffersByIdRaw(String offerUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetOffersByIdRaw", offerUuid);
		}

		/**
		 *  [BETA] Modifies offer by id.
	 * https://developer.allegro.pl/documentation/#!/offer/updateOfferUsingPUT 	
		 * @param offerUuid The unique offer id
	 * @param offer Offer data info for update
	 * @return {Response} Updated offer data info 
		 * @throws Exception
		 */
		public Response UpdateOfferRaw(String offerUuid, String offer) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "UpdateOfferRaw", offerUuid, offer);
		}

		/**
		 *  [BETA] Returns details of the given shipping rates set. Seller authentication is required.
	 * https://developer.allegro.pl/documentation/#!/offer/get_sale_shipping_rates_id 	
		 * @param shippingRatesUuid id of shipping rates set
	 * @return {Response} Details of the given shipping rates set. 
		 * @throws Exception
		 */
		public Response GetShippingRatesDetailsByIdRaw(String shippingRatesUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetShippingRatesDetailsByIdRaw", shippingRatesUuid);
		}

		/**
		 *  Provides detailed modification report for single command task
	 * https://developer.allegro.pl/documentation/#!/offer/getTasksUsingGET 	
		 * @param commandUuid id of command task
	 * @param offset It defines a number of a batch of returned data and is numbered from 0.
	 * @param limit It defines a number of elements on the page, which cannot be higher than the maximum limit supported by the resource.
	 * @return {Response} Detailed modification report for single command task 
		 * @throws Exception
		 */
		public Response GetModificationDetailedReportRaw(String commandUuid, Integer offset, Integer limit) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetModificationDetailedReportRaw", commandUuid, offset, limit);
		}

		/**
		 *  [BETA] Provides detailed publication report for single command task
	 * https://developer.allegro.pl/documentation/#!/offer/getPublicationTasksUsingGET 	
		 * @param commandUuid Id of command task
	 * @param offset It defines a number of a batch of returned data and is numbered from 0.
	 * @param limit It defines a number of elements on the page, which cannot be higher than the maximum limit supported by the resource.
	 * @return {Response} Detailed publication report for single command task 
		 * @throws Exception
		 */
		public Response GetPublicationDetailedReportRaw(String commandUuid, Integer offset, Integer limit) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetPublicationDetailedReportRaw", commandUuid, offset, limit);
		}

		/**
		 *  Returns group of additional services defined by user
	 * https://developer.allegro.pl/documentation/#!/offer-additional-services/get_sale_offer_additional_services_groups 	
		 * @param userUuid The unique user id
	 * @param offset It defines a number of a batch of returned data and is numbered from 0.
	 * @param limit It defines a number of elements on the page, which cannot be higher than the maximum limit supported by the resource.
	 * @return {Response} Additional service groups by user ID 
		 * @throws Exception
		 */
		public Response GetAdditionalServiceGroupRaw(String userUuid, Integer offset, Integer limit) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetAdditionalServiceGroupRaw", userUuid, offset, limit);
		}

		/**
		 *  Creates group of additional services
	 * https://developer.allegro.pl/documentation/#!/offer-additional-services/post_sale_offer_additional_services_groups 	
		 * @param body Aditional service group body
	 * @return {Response} Additional service group 
		 * @throws Exception
		 */
		public Response CreateAdditionalServiceGroupRaw(String body) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "CreateAdditionalServiceGroupRaw", body);
		}

		/**
		 *  Returns additional services definitions
	 * https://developer.allegro.pl/documentation/#!/offer-additional-services/get_sale_offer_additional_services_definitions 	
		 * @param userUuid The unique user id
	 * @param offset It defines a number of a batch of returned data and is numbered from 0.
	 * @param limit It defines a number of elements on the page, which cannot be higher than the maximum limit supported by the resource.
	 * @return {Response} Additional services definition by user ID 
		 * @throws Exception
		 */
		public Response GetAdditionalServiceDefinitionsRaw(String userUuid, Integer offset, Integer limit) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetAdditionalServiceDefinitionsRaw", userUuid, offset, limit);
		}

		/**
		 *  Returns additional services group for a given Id
	 * https://developer.allegro.pl/documentation/#!/offer-additional-services/get_sale_offer_additional_services_groups_groupId 	
		 * @param groupUuid Additional service group ID
	 * @return {Response} Additional services group for a given Id 
		 * @throws Exception
		 */
		public Response GetAdditionalServiceGroupForIdRaw(String groupUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetAdditionalServiceGroupForIdRaw", groupUuid);
		}

		/**
		 *  Updates existing additional service group
	 * https://developer.allegro.pl/documentation/#!/offer-additional-services/put_sale_offer_additional_services_groups_groupId 	
		 * @param groupUuid Additional service group ID
	 * @param body Additional service group body
	 * @return {Response} Updated additional service group 
		 * @throws Exception
		 */
		public Response UpdateAdditionalServiceGroupRaw(String groupUuid, String body) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "UpdateAdditionalServiceGroupRaw", groupUuid, body);
		}

		/**
		 *  Gets all contacts
	 * https://developer.allegro.pl/documentation/#!/offer-contacts/get_sale_offer_contacts 	
		 * @param sellerUuid Seller Id
	 * @return {Response} List of all contacts 
		 * @throws Exception
		 */
		public Response GetAllContactsRaw(String sellerUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetAllContactsRaw", sellerUuid);
		}

		/**
		 *  Creates new contact
	 * https://developer.allegro.pl/documentation/#!/offer-contacts/post_sale_offer_contacts 	
		 * @param body New contact data info
	 * @return {Response} New contact data info 
		 * @throws Exception
		 */
		public Response CreateContactRaw(String body) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "CreateContactRaw", body);
		}

		/**
		 *  Gets contact info by Id
	 * https://developer.allegro.pl/documentation/#!/offer-contacts/get_sale_offer_contacts_id 	
		 * @param contactUuid Contact ID
	 * @return {Response} Contact data info 
		 * @throws Exception
		 */
		public Response GetContactRaw(String contactUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetContactRaw", contactUuid);
		}

		/**
		 *  Updates existing contact
	 * https://developer.allegro.pl/documentation/#!/offer-contacts/put_sale_offer_contacts_id 	
		 * @param contactUuid Contact ID
	 * @param body Contact data info for update
	 * @return {Response} Updated contact data info 
		 * @throws Exception
		 */
		public Response UpdateContactRaw(String contactUuid, String body) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "UpdateContactRaw", contactUuid, body);
		}

		/**
		 *  Deletes a point of service. User authentication is required.
	 * https://developer.allegro.pl/documentation/#!/points-of-service/delete_points_of_service_id 	
		 * @param pointOfServiceUuid Point of service id
	 * @return {Response} response message 
		 * @throws Exception
		 */
		public Response DeletePointOfServiceRaw(String pointOfServiceUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "DeletePointOfServiceRaw", pointOfServiceUuid);
		}

		/**
		 *  Returns point of service details for a given Id. Client authentication is required.
	 * https://developer.allegro.pl/documentation/#!/points-of-service/get_points_of_service_id 	
		 * @param pointOfServiceUuid Point of service ID
	 * @return {Response} Point of service details for a given Id 
		 * @throws Exception
		 */
		public Response GetPointOfServiceRaw(String pointOfServiceUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetPointOfServiceRaw", pointOfServiceUuid);
		}

		/**
		 *  Updates a point of service. User authentication is required.
	 * https://developer.allegro.pl/documentation/#!/points-of-service/put_points_of_service_id 	
		 * @param pointOfServiceUuid Point of service ID. Must match values with 'id' property from the body.
	 * @param body Contact data info for update
	 * @return {Response} Updates contact data info 
		 * @throws Exception
		 */
		public Response UpdatePointOfServiceRaw(String pointOfServiceUuid, String body) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "UpdatePointOfServiceRaw", pointOfServiceUuid, body);
		}

		/**
		 *  Returns a list of points of service. Client authentication is required.
	 * https://developer.allegro.pl/documentation/#!/points-of-service/get_points_of_service 	
		 * @param sellerUuid Seller ID
	 * @return {Response} List of points of service by seller ID 
		 * @throws Exception
		 */
		public Response GetPointOfServiceListRaw(String sellerUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetPointOfServiceListRaw", sellerUuid);
		}

		/**
		 *  Creates a point of service. User authentication is required.
	 * https://developer.allegro.pl/documentation/#!/points-of-service/post_points_of_service 	
		 * @param pointOfService Point of service info to add
	 * @return {Response} New point of service 
		 * @throws Exception
		 */
		public Response CreatePointOfServiceListRaw(String pointOfService) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "CreatePointOfServiceListRaw", pointOfService);
		}

		/**
		 *  This endpoint calculates fees for a provided offer conditions. The quotation is estimated and based on the current configuration of the Allegro
	 * price list and the data entered in this API. The stated price does not include package discounts. The rules of charging and amount of charges are
	 * described in the Allegro regulations in Appendix 4. The final amount of the fee for the offer will be available after approval under the tab: My
	 * Account> Accounts> History.
	 * https://developer.allegro.pl/documentation/#!/pricing/previewFeesPublicAPIUsingPOST 	
		 * @param command Command used for calculate fee preview
	 * @return {Response} Fees for a provided offer conditions 
		 * @throws Exception
		 */
		public Response CalculateFeePReviewRaw(String command) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "CalculateFeePReviewRaw", command);
		}

		/**
		 *  This endpoint returns current offer quotes (listing and promo fees) cycles for authenticated user and list of offers.
	 * https://developer.allegro.pl/documentation/#!/pricing/offerQuotesPublicUsingGET 	
		 * @param offerUuid List of offer ids, maximum 20 values
	 * @return {Response} Current offer quotes for authenticated user and list of offers 
		 * @throws Exception
		 */
		public Response GetCurrentOfferQuotesRaw(String offerUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetCurrentOfferQuotesRaw", offerUuid);
		}

		/**
		 *  Returns a list of promotions defined by the specified user. You can list only your own promotions.
	 * https://developer.allegro.pl/documentation/#!/promotions/listSellerPromotionsUsingGET_1 	
		 * @param userUuid user.id
	 * @param offset It defines a number of a batch of returned data and is numbered from 0.
	 * @param limit It defines a number of elements on the page, which cannot be higher than the maximum limit supported by the resource.
	 * @param details details
	 * @param authenticated authenticated
	 * @return {Response} List of promotions by user id 
		 * @throws Exception
		 */
		public Response GetPromotionsListRaw(String userUuid, Integer offset, Integer limit, Object details, Boolean authenticated) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetPromotionsListRaw", userUuid, offset, limit, details, authenticated);
		}

		/**
		 *  Creates a new promotion. You can define the following types of promotions:
	 * 1) Bundle
	 * 2) Multipack
	 * https://developer.allegro.pl/documentation/#!/promotions/createPromotionUsingPOST_1 	
		 * @param request request for create a new promotion
	 * @param details details
	 * @param authenticated authenticated
	 * @return {Response} New promotion data info 
		 * @throws Exception
		 */
		public Response CrearePromotionRaw(String request, Object details, Boolean authenticated) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "CrearePromotionRaw", request, details, authenticated);
		}

		/**
		 *  Deactivates the requested promotion. You need to use its unique id.
	 * https://developer.allegro.pl/documentation/#!/promotions/deactivatePromotionUsingDELETE 	
		 * @param promotionUuid promotion id
	 * @return {Response} response message 
		 * @throws Exception
		 */
		public Response DeactivatePromotionRaw(String promotionUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "DeactivatePromotionRaw", promotionUuid);
		}

		/**
		 *  Returns the requested promotion. You need to use its unique id.
	 * https://developer.allegro.pl/documentation/#!/promotions/getPromotionUsingGET 	
		 * @param promotionUuid Promotion id
	 * @param details 
	 * @param authenticated 
	 * @return {Response} List of promotions by user id 
		 * @throws Exception
		 */
		public Response GetPromotionRaw(String promotionUuid, Object details, Boolean authenticated) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetPromotionRaw", promotionUuid, details, authenticated);
		}

		/**
		 *  [BETA] Gets parameters by category id for the saler.
	 * https://developer.allegro.pl/documentation/#!/sale-endpoint/getFlatParametersUsingGET_2 	
		 * @param categoryUuid 
	 * @return {Response} Parameters by category id 
		 * @throws Exception
		 */
		public Response GetParametersByCategoryIdRaw(String categoryUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetParametersByCategoryIdRaw", categoryUuid);
		}

		/**
		 *  [BETA] Gets categories for the saler. 	
		 * @return {Response} List of categories 
		 * @throws Exception
		 */
		public Response GetCategoriesRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetCategoriesRaw");
		}

		/**
		 *  [BETA] Gets categories children by parent id.
	 * https://developer.allegro.pl/documentation/#!/sale-endpoint/getCategoriesUsingGET 	
		 * @param parentUuid The unique parent id
	 * @return {Response} Categories children by parent id 
		 * @throws Exception
		 */
		public Response GetCategoriesByParentIdRaw(String parentUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetCategoriesByParentIdRaw", parentUuid);
		}

		/**
		 *  [BETA] Gets category by id.
	 * https://developer.allegro.pl/documentation/#!/sale-endpoint/getCategoryUsingGET_1 	
		 * @param categoryUuid The unique category id
	 * @return {Response} Category data info 
		 * @throws Exception
		 */
		public Response GetCategoriesByIdRaw(String categoryUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetCategoriesByIdRaw", categoryUuid);
		}

		/**
		 *  [BETA] Read size table of authenticated user.
	 * https://developer.allegro.pl/documentation/#!/size-tables/getTableUsingGET 	
		 * @param tableUuid The unique table id
	 * @return {Response} Size table of authenticated user. 
		 * @throws Exception
		 */
		public Response GetSizeTableRaw(String tableUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetSizeTableRaw", tableUuid);
		}

		/**
		 *  [BETA] Read size tables list of authenticated user.
	 * https://developer.allegro.pl/documentation/#!/size-tables/getTablesUsingGET 	
		 * @param userUuid The unique user id
	 * @return {Response} Size table list. 
		 * @throws Exception
		 */
		public Response GetSizeTablesListRaw(String userUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetSizeTablesListRaw", userUuid);
		}

		/**
		 *  Gets user rating-summary
	 * https://developer.allegro.pl/documentation/#!/user-ratings/getUserSummaryUsingGET 	
		 * @param userUuid The unique user id
	 * @return {Response} User rating-summary. 
		 * @throws Exception
		 */
		public Response GetUserRatingSummaryRaw(String userUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetUserRatingSummaryRaw", userUuid);
		}

		/**
		 *  Gets user-rating
	 * https://developer.allegro.pl/documentation/#!/user-ratings/getUserRatingsUsingGET 	
		 * @param userUuid The unique user id. Filter by user id, you are allowed to get your ratings only.
	 * @param recommended Filter by recommended.
	 * @param offset It defines a number of a batch of returned data and is numbered from 0.
	 * @param limit It defines a number of elements on the page, which cannot be higher than the maximum limit supported by the resource.
	 * @return {Response} User-rating. 
		 * @throws Exception
		 */
		public Response GetUserRatingRaw(String userUuid, Boolean recommended, Integer offset, Integer limit) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Allegro", bNesisToken, "GetUserRatingRaw", userUuid, recommended, offset, limit);
		}
}