using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;
using bNesis.Api.Desktop;
using bNesis.Sdk.Common;

namespace bNesis.Sdk.eCommerce.Allegro
{
	public class Allegro  
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

		public Allegro(DesktopbNesisApi bNesisApi)
		{
			this.bNesisApi = bNesisApi;
		}

		/// <summary>
		/// The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		/// </summary>
		/// <returns>bNesisToken value</returns>	
		public string Auth(string bNesisDevId,string clientId,string clientSecret,string redirectUrl,string[] scopes,bool isSandbox,string data)
		{
			bNesisToken = bNesisApi.Auth("Allegro", data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,string.Empty,string.Empty,isSandbox,string.Empty);
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
			bool result = bNesisApi.LogoffService("Allegro", bNesisToken);
			if (result) bNesisToken = string.Empty;
			return result;             
		}


		///<summary>
		/// Getting last exception for current provider 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo GetLastError()
		{
			return bNesisApi.Call<ErrorInfo>("Allegro", bNesisToken, "GetLastError");
		}

		///<summary>
		/// Getting arrays of error info 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo[] GetErrorLog()
		{
			return bNesisApi.Call<ErrorInfo[]>("Allegro", bNesisToken, "GetErrorLog");
		}

		///<summary>
		/// Checks the token in the service. 
		/// </summary>
		/// <returns>if token valid return true, if token not valid return false</returns>
		public Boolean ValidateToken()
		{
			return bNesisApi.Call<Boolean>("Allegro", bNesisToken, "ValidateToken");
		}

		///<summary>
		/// Disables the access token used to authenticate the call. 
		/// </summary>
		/// <returns>if token revoked method returns true 
		/// if token doesn't support token revocation or token is revoked method returns false</returns>
		public Boolean Logoff()
		{
			return bNesisApi.Call<Boolean>("Allegro", bNesisToken, "Logoff");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="contactItem"></param>
		/// <returns></returns>
		public Boolean CreateCustomerUnified(ContactItem contactItem)
		{
			return bNesisApi.Call<Boolean>("Allegro", bNesisToken, "CreateCustomerUnified", contactItem);
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public ContactItem[] GetCustomersUnified()
		{
			return bNesisApi.Call<ContactItem[]>("Allegro", bNesisToken, "GetCustomersUnified");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="productItem"></param>
		/// <returns></returns>
		public Boolean AddProductUnified(ProductItem productItem)
		{
			return bNesisApi.Call<Boolean>("Allegro", bNesisToken, "AddProductUnified", productItem);
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public ProductItem[] GetProductsUnified()
		{
			return bNesisApi.Call<ProductItem[]>("Allegro", bNesisToken, "GetProductsUnified");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="IdProduct"></param>
		/// <returns></returns>
		public Boolean DeleteProductUnified(string IdProduct)
		{
			return bNesisApi.Call<Boolean>("Allegro", bNesisToken, "DeleteProductUnified", IdProduct);
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public CountryItem[] GetCountriesUnified()
		{
			return bNesisApi.Call<CountryItem[]>("Allegro", bNesisToken, "GetCountriesUnified");
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public Int32 GetCountCountriesUnified()
		{
			return bNesisApi.Call<Int32>("Allegro", bNesisToken, "GetCountCountriesUnified");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="IdCountry"></param>
		/// <returns></returns>
		public CountryItem ReceiveCountryUnified(string IdCountry)
		{
			return bNesisApi.Call<CountryItem>("Allegro", bNesisToken, "ReceiveCountryUnified", IdCountry);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="IdCountry"></param>
		/// <returns></returns>
		public Boolean DeleteCountryUnified(string IdCountry)
		{
			return bNesisApi.Call<Boolean>("Allegro", bNesisToken, "DeleteCountryUnified", IdCountry);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="countryItem"></param>
		/// <returns></returns>
		public CountryItem CreateCountryUnified(CountryItem countryItem)
		{
			return bNesisApi.Call<CountryItem>("Allegro", bNesisToken, "CreateCountryUnified", countryItem);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="countryItem"></param>
		/// <returns></returns>
		public CountryItem UpdateCountryUnified(CountryItem countryItem)
		{
			return bNesisApi.Call<CountryItem>("Allegro", bNesisToken, "UpdateCountryUnified", countryItem);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="IdCustomer"></param>
		/// <returns></returns>
		public ContactItem ReceiveCustomerUnified(string IdCustomer)
		{
			return bNesisApi.Call<ContactItem>("Allegro", bNesisToken, "ReceiveCustomerUnified", IdCustomer);
		}

		///<summary>
		/// Gets the user list. 
		/// </summary>
		/// <returns>Data with info about list of user</returns>
		public Response GetUserListRaw()
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetUserListRaw");
		}

		///<summary>
		/// Create the user. 
		/// </summary>
		/// <param name="user">New user info</param>
		/// <returns>Data with info about new user</returns>
		public Response CreateUserRaw(string user)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "CreateUserRaw", user);
		}

		///<summary>
		/// Get the user by id. 
		/// </summary>
		/// <param name="userUuid">The unique user id</param>
		/// <returns>Data with info about user</returns>
		public Response GetUserRaw(string userUuid)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetUserRaw", userUuid);
		}

		///<summary>
		/// Update the user by id. 
		/// </summary>
		/// <param name="userUuid">The unique user id</param>
		/// <param name="user">User info for update</param>
		/// <returns>Data with info about user after update</returns>
		public Response UpdateUserRaw(string userUuid, string user)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "UpdateUserRaw", userUuid, user);
		}

		///<summary>
		/// Delete the user by id. 
		/// </summary>
		/// <param name="userUuid">The unique user id</param>
		/// <returns>response message</returns>
		public Response DeleteUserRaw(string userUuid)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "DeleteUserRaw", userUuid);
		}

		///<summary>
		/// Gets seller return policies.
		/// You are allowed to list only your return policies
		/// https://developer.allegro.pl/documentation/#!/after-sales-service-conditions/getPublicSellerListingUsingGET_1 
		/// </summary>
		/// <param name="sellerUuid">Seller Id</param>
		/// <param name="offset">It defines a number of a batch of returned data and is numbered from 0.</param>
		/// <param name="limit">It defines a number of elements on the page, which cannot be higher than the maximum limit supported by the resource.</param>
		/// <returns>Seller return policies</returns>
		public Response GetSellerReturnPoliciesRaw(string sellerUuid, Int32 offset, Int32 limit)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetSellerReturnPoliciesRaw", sellerUuid, offset, limit);
		}

		///<summary>
		/// Gets seller implied warranties.
		/// You are allowed to list only your implied warranties
		/// https://developer.allegro.pl/documentation/#!/after-sales-service-conditions/getPublicSellerListingUsingGET 
		/// </summary>
		/// <param name="sellerUuid">Seller Id</param>
		/// <param name="offset">It defines a number of a batch of returned data and is numbered from 0.</param>
		/// <param name="limit">It defines a number of elements on the page, which cannot be higher than the maximum limit supported by the resource.</param>
		/// <returns>Seller implied warranties</returns>
		public Response GetSellerImpliedWarrantiesRaw(string sellerUuid, Int32 offset, Int32 limit)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetSellerImpliedWarrantiesRaw", sellerUuid, offset, limit);
		}

		///<summary>
		/// Gets seller warranties.
		/// You are allowed to list only your warranties
		/// https://developer.allegro.pl/documentation/#!/after-sales-service-conditions/getPublicSellerListingUsingGET_2 
		/// </summary>
		/// <param name="sellerUuid">Seller Id</param>
		/// <param name="offset">It defines a number of a batch of returned data and is numbered from 0.</param>
		/// <param name="limit">It defines a number of elements on the page, which cannot be higher than the maximum limit supported by the resource.</param>
		/// <returns>Seller warranties</returns>
		public Response GetSellerWarrantiesRaw(string sellerUuid, Int32 offset, Int32 limit)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetSellerWarrantiesRaw", sellerUuid, offset, limit);
		}

		///<summary>
		/// Changes a Buy Now price in a single offer
		/// https://developer.allegro.pl/documentation/#!/default/put_offers_offerId_change_price_commands_commandId 
		/// </summary>
		/// <param name="offerUuid">The unique offer id</param>
		/// <param name="commandUuid">UUID you generate to enforce idempotency</param>
		/// <param name="command">Command input data. Note that the amount field must be transferred as a string to avoid rounding errors. A currency must be provided as a 3-letter code as defined in ISO 4217.</param>
		/// <returns>Updated Buy Now price in offer</returns>
		public Response ChangeBuyNowPriceInOfferRaw(string offerUuid, string commandUuid, string command)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "ChangeBuyNowPriceInOfferRaw", offerUuid, commandUuid, command);
		}

		///<summary>
		/// [BETA] Provides publication report summary for given commandid
		/// https://developer.allegro.pl/documentation/#!/offer/getPublicationReportUsingGET 
		/// </summary>
		/// <param name="commandUuid">UUID you generate to enforce idempotency</param>
		/// <returns>Offer publication data</returns>
		public Response GetOffersPublicationReportSummaryByIdRaw(string commandUuid)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetOffersPublicationReportSummaryByIdRaw", commandUuid);
		}

		///<summary>
		/// [BETA] Allows modification of multiple offers' publication at once.
		/// https://developer.allegro.pl/documentation/#!/offer/changePublicationStatusUsingPUT 
		/// </summary>
		/// <param name="commandUuid">UUID you generate to enforce idempotency</param>
		/// <param name="publicationChangeCommandDto">Command to change publication</param>
		/// <returns>Updated offers' publication data</returns>
		public Response ChangeOffersPublicationByIdRaw(string commandUuid, string publicationChangeCommandDto)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "ChangeOffersPublicationByIdRaw", commandUuid, publicationChangeCommandDto);
		}

		///<summary>
		/// Provides modification report summary for given commandid
		/// https://developer.allegro.pl/documentation/#!/offer/getGeneralReportUsingGET 
		/// </summary>
		/// <param name="commandUuid">UUID you generate to enforce idempotency</param>
		/// <returns>Offer modification data</returns>
		public Response GetOffersModificationReportSummaryByIdRaw(string commandUuid)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetOffersModificationReportSummaryByIdRaw", commandUuid);
		}

		///<summary>
		/// Allows modification of multiple offers at once.
		/// https://developer.allegro.pl/documentation/#!/offer/modificationCommandUsingPUT 
		/// </summary>
		/// <param name="commandUuid">UUID you generate to enforce idempotency</param>
		/// <param name="publicationChangeCommandDto">command to change publication</param>
		/// <returns>Updated offer modification data</returns>
		public Response ChangeOffersModificationByIdRaw(string commandUuid, string publicationChangeCommandDto)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "ChangeOffersModificationByIdRaw", commandUuid, publicationChangeCommandDto);
		}

		///<summary>
		/// [BETA] Returns a list of seller's shipping rates. Seller authentication is required.
		/// https://developer.allegro.pl/documentation/#!/offer/get_sale_shipping_rates 
		/// </summary>
		/// <param name="sellerUuid">id of shipping rates owner</param>
		/// <returns>List of seller's shipping rates</returns>
		public Response GetSellersShippingRatesRaw(string sellerUuid)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetSellersShippingRatesRaw", sellerUuid);
		}

		///<summary>
		/// Gets list of offers. 
		/// </summary>
		/// <returns>Total list of offers</returns>
		public Response GetAllOffersRaw()
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetAllOffersRaw");
		}

		///<summary>
		/// [BETA] Gets list of offers for the saler. 
		/// </summary>
		/// <returns>List of offers</returns>
		public Response GetOffersRaw()
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetOffersRaw");
		}

		///<summary>
		/// [BETA] Creates single offer 
		/// https://developer.allegro.pl/documentation/#!/offer/createOfferUsingPOST 
		/// </summary>
		/// <param name="offer">offer</param>
		/// <returns>Data with info about user</returns>
		public Response CreateOfferRaw(string offer)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "CreateOfferRaw", offer);
		}

		///<summary>
		/// [BETA] Returns a list of available delivery methods. Client authentication is required.
		/// https://developer.allegro.pl/documentation/#!/offer/get_sale_delivery_methods 
		/// </summary>
		/// <returns>list of available delivery methods</returns>
		public Response GetDeliveryMethodsRaw()
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetDeliveryMethodsRaw");
		}

		///<summary>
		/// [BETA] Gets single offer by id
		/// https://developer.allegro.pl/documentation/#!/offer/getOfferUsingGET 
		/// </summary>
		/// <param name="offerUuid">The unique offer id</param>
		/// <returns>Offer data info</returns>
		public Response GetOffersByIdRaw(string offerUuid)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetOffersByIdRaw", offerUuid);
		}

		///<summary>
		/// [BETA] Modifies offer by id.
		/// https://developer.allegro.pl/documentation/#!/offer/updateOfferUsingPUT 
		/// </summary>
		/// <param name="offerUuid">The unique offer id</param>
		/// <param name="offer">Offer data info for update</param>
		/// <returns>Updated offer data info</returns>
		public Response UpdateOfferRaw(string offerUuid, string offer)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "UpdateOfferRaw", offerUuid, offer);
		}

		///<summary>
		/// [BETA] Returns details of the given shipping rates set. Seller authentication is required.
		/// https://developer.allegro.pl/documentation/#!/offer/get_sale_shipping_rates_id 
		/// </summary>
		/// <param name="shippingRatesUuid">id of shipping rates set</param>
		/// <returns>Details of the given shipping rates set.</returns>
		public Response GetShippingRatesDetailsByIdRaw(string shippingRatesUuid)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetShippingRatesDetailsByIdRaw", shippingRatesUuid);
		}

		///<summary>
		/// Provides detailed modification report for single command task
		/// https://developer.allegro.pl/documentation/#!/offer/getTasksUsingGET 
		/// </summary>
		/// <param name="commandUuid">id of command task</param>
		/// <param name="offset">It defines a number of a batch of returned data and is numbered from 0.</param>
		/// <param name="limit">It defines a number of elements on the page, which cannot be higher than the maximum limit supported by the resource.</param>
		/// <returns>Detailed modification report for single command task</returns>
		public Response GetModificationDetailedReportRaw(string commandUuid, Int32 offset, Int32 limit)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetModificationDetailedReportRaw", commandUuid, offset, limit);
		}

		///<summary>
		/// [BETA] Provides detailed publication report for single command task
		/// https://developer.allegro.pl/documentation/#!/offer/getPublicationTasksUsingGET 
		/// </summary>
		/// <param name="commandUuid">Id of command task</param>
		/// <param name="offset">It defines a number of a batch of returned data and is numbered from 0.</param>
		/// <param name="limit">It defines a number of elements on the page, which cannot be higher than the maximum limit supported by the resource.</param>
		/// <returns>Detailed publication report for single command task</returns>
		public Response GetPublicationDetailedReportRaw(string commandUuid, Int32 offset, Int32 limit)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetPublicationDetailedReportRaw", commandUuid, offset, limit);
		}

		///<summary>
		/// Returns group of additional services defined by user
		/// https://developer.allegro.pl/documentation/#!/offer-additional-services/get_sale_offer_additional_services_groups 
		/// </summary>
		/// <param name="userUuid">The unique user id</param>
		/// <param name="offset">It defines a number of a batch of returned data and is numbered from 0.</param>
		/// <param name="limit">It defines a number of elements on the page, which cannot be higher than the maximum limit supported by the resource.</param>
		/// <returns>Additional service groups by user ID</returns>
		public Response GetAdditionalServiceGroupRaw(string userUuid, Int32 offset, Int32 limit)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetAdditionalServiceGroupRaw", userUuid, offset, limit);
		}

		///<summary>
		/// Creates group of additional services
		/// https://developer.allegro.pl/documentation/#!/offer-additional-services/post_sale_offer_additional_services_groups 
		/// </summary>
		/// <param name="body">Aditional service group body</param>
		/// <returns>Additional service group</returns>
		public Response CreateAdditionalServiceGroupRaw(string body)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "CreateAdditionalServiceGroupRaw", body);
		}

		///<summary>
		/// Returns additional services definitions
		/// https://developer.allegro.pl/documentation/#!/offer-additional-services/get_sale_offer_additional_services_definitions 
		/// </summary>
		/// <param name="userUuid">The unique user id</param>
		/// <param name="offset">It defines a number of a batch of returned data and is numbered from 0.</param>
		/// <param name="limit">It defines a number of elements on the page, which cannot be higher than the maximum limit supported by the resource.</param>
		/// <returns>Additional services definition by user ID</returns>
		public Response GetAdditionalServiceDefinitionsRaw(string userUuid, Int32 offset, Int32 limit)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetAdditionalServiceDefinitionsRaw", userUuid, offset, limit);
		}

		///<summary>
		/// Returns additional services group for a given Id
		/// https://developer.allegro.pl/documentation/#!/offer-additional-services/get_sale_offer_additional_services_groups_groupId 
		/// </summary>
		/// <param name="groupUuid">Additional service group ID</param>
		/// <returns>Additional services group for a given Id</returns>
		public Response GetAdditionalServiceGroupForIdRaw(string groupUuid)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetAdditionalServiceGroupForIdRaw", groupUuid);
		}

		///<summary>
		/// Updates existing additional service group
		/// https://developer.allegro.pl/documentation/#!/offer-additional-services/put_sale_offer_additional_services_groups_groupId 
		/// </summary>
		/// <param name="groupUuid">Additional service group ID</param>
		/// <param name="body">Additional service group body</param>
		/// <returns>Updated additional service group</returns>
		public Response UpdateAdditionalServiceGroupRaw(string groupUuid, string body)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "UpdateAdditionalServiceGroupRaw", groupUuid, body);
		}

		///<summary>
		/// Gets all contacts
		/// https://developer.allegro.pl/documentation/#!/offer-contacts/get_sale_offer_contacts 
		/// </summary>
		/// <param name="sellerUuid">Seller Id</param>
		/// <returns>List of all contacts</returns>
		public Response GetAllContactsRaw(string sellerUuid)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetAllContactsRaw", sellerUuid);
		}

		///<summary>
		/// Creates new contact
		/// https://developer.allegro.pl/documentation/#!/offer-contacts/post_sale_offer_contacts 
		/// </summary>
		/// <param name="body">New contact data info</param>
		/// <returns>New contact data info</returns>
		public Response CreateContactRaw(string body)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "CreateContactRaw", body);
		}

		///<summary>
		/// Gets contact info by Id
		/// https://developer.allegro.pl/documentation/#!/offer-contacts/get_sale_offer_contacts_id 
		/// </summary>
		/// <param name="contactUuid">Contact ID</param>
		/// <returns>Contact data info</returns>
		public Response GetContactRaw(string contactUuid)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetContactRaw", contactUuid);
		}

		///<summary>
		/// Updates existing contact
		/// https://developer.allegro.pl/documentation/#!/offer-contacts/put_sale_offer_contacts_id 
		/// </summary>
		/// <param name="contactUuid">Contact ID</param>
		/// <param name="body">Contact data info for update</param>
		/// <returns>Updated contact data info</returns>
		public Response UpdateContactRaw(string contactUuid, string body)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "UpdateContactRaw", contactUuid, body);
		}

		///<summary>
		/// Deletes a point of service. User authentication is required.
		/// https://developer.allegro.pl/documentation/#!/points-of-service/delete_points_of_service_id 
		/// </summary>
		/// <param name="pointOfServiceUuid">Point of service id</param>
		/// <returns>response message</returns>
		public Response DeletePointOfServiceRaw(string pointOfServiceUuid)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "DeletePointOfServiceRaw", pointOfServiceUuid);
		}

		///<summary>
		/// Returns point of service details for a given Id. Client authentication is required.
		/// https://developer.allegro.pl/documentation/#!/points-of-service/get_points_of_service_id 
		/// </summary>
		/// <param name="pointOfServiceUuid">Point of service ID</param>
		/// <returns>Point of service details for a given Id</returns>
		public Response GetPointOfServiceRaw(string pointOfServiceUuid)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetPointOfServiceRaw", pointOfServiceUuid);
		}

		///<summary>
		/// Updates a point of service. User authentication is required.
		/// https://developer.allegro.pl/documentation/#!/points-of-service/put_points_of_service_id 
		/// </summary>
		/// <param name="pointOfServiceUuid">Point of service ID. Must match values with 'id' property from the body.</param>
		/// <param name="body">Contact data info for update</param>
		/// <returns>Updates contact data info</returns>
		public Response UpdatePointOfServiceRaw(string pointOfServiceUuid, string body)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "UpdatePointOfServiceRaw", pointOfServiceUuid, body);
		}

		///<summary>
		/// Returns a list of points of service. Client authentication is required.
		/// https://developer.allegro.pl/documentation/#!/points-of-service/get_points_of_service 
		/// </summary>
		/// <param name="sellerUuid">Seller ID</param>
		/// <returns>List of points of service by seller ID</returns>
		public Response GetPointOfServiceListRaw(string sellerUuid)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetPointOfServiceListRaw", sellerUuid);
		}

		///<summary>
		/// Creates a point of service. User authentication is required.
		/// https://developer.allegro.pl/documentation/#!/points-of-service/post_points_of_service 
		/// </summary>
		/// <param name="pointOfService">Point of service info to add</param>
		/// <returns>New point of service</returns>
		public Response CreatePointOfServiceListRaw(string pointOfService)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "CreatePointOfServiceListRaw", pointOfService);
		}

		///<summary>
		/// This endpoint calculates fees for a provided offer conditions. The quotation is estimated and based on the current configuration of the Allegro
		/// price list and the data entered in this API. The stated price does not include package discounts. The rules of charging and amount of charges are
		/// described in the Allegro regulations in Appendix 4. The final amount of the fee for the offer will be available after approval under the tab: My
		/// Account> Accounts> History.
		/// https://developer.allegro.pl/documentation/#!/pricing/previewFeesPublicAPIUsingPOST 
		/// </summary>
		/// <param name="command">Command used for calculate fee preview</param>
		/// <returns>Fees for a provided offer conditions</returns>
		public Response CalculateFeePReviewRaw(string command)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "CalculateFeePReviewRaw", command);
		}

		///<summary>
		/// This endpoint returns current offer quotes (listing and promo fees) cycles for authenticated user and list of offers.
		/// https://developer.allegro.pl/documentation/#!/pricing/offerQuotesPublicUsingGET 
		/// </summary>
		/// <param name="offerUuid">List of offer ids, maximum 20 values</param>
		/// <returns>Current offer quotes for authenticated user and list of offers</returns>
		public Response GetCurrentOfferQuotesRaw(string offerUuid)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetCurrentOfferQuotesRaw", offerUuid);
		}

		///<summary>
		/// Returns a list of promotions defined by the specified user. You can list only your own promotions.
		/// https://developer.allegro.pl/documentation/#!/promotions/listSellerPromotionsUsingGET_1 
		/// </summary>
		/// <param name="userUuid">user.id</param>
		/// <param name="offset">It defines a number of a batch of returned data and is numbered from 0.</param>
		/// <param name="limit">It defines a number of elements on the page, which cannot be higher than the maximum limit supported by the resource.</param>
		/// <param name="details">details</param>
		/// <param name="authenticated">authenticated</param>
		/// <returns>List of promotions by user id</returns>
		public Response GetPromotionsListRaw(string userUuid, Int32 offset, Int32 limit, Object details, Boolean authenticated)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetPromotionsListRaw", userUuid, offset, limit, details, authenticated);
		}

		///<summary>
		/// Creates a new promotion. You can define the following types of promotions:
		/// 1) Bundle
		/// 2) Multipack
		/// https://developer.allegro.pl/documentation/#!/promotions/createPromotionUsingPOST_1 
		/// </summary>
		/// <param name="request">request for create a new promotion</param>
		/// <param name="details">details</param>
		/// <param name="authenticated">authenticated</param>
		/// <returns>New promotion data info</returns>
		public Response CrearePromotionRaw(string request, Object details, Boolean authenticated)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "CrearePromotionRaw", request, details, authenticated);
		}

		///<summary>
		/// Deactivates the requested promotion. You need to use its unique id.
		/// https://developer.allegro.pl/documentation/#!/promotions/deactivatePromotionUsingDELETE 
		/// </summary>
		/// <param name="promotionUuid">promotion id</param>
		/// <returns>response message</returns>
		public Response DeactivatePromotionRaw(string promotionUuid)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "DeactivatePromotionRaw", promotionUuid);
		}

		///<summary>
		/// Returns the requested promotion. You need to use its unique id.
		/// https://developer.allegro.pl/documentation/#!/promotions/getPromotionUsingGET 
		/// </summary>
		/// <param name="promotionUuid">Promotion id</param>
		/// <param name="details"></param>
		/// <param name="authenticated"></param>
		/// <returns>List of promotions by user id</returns>
		public Response GetPromotionRaw(string promotionUuid, Object details, Boolean authenticated)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetPromotionRaw", promotionUuid, details, authenticated);
		}

		///<summary>
		/// [BETA] Gets parameters by category id for the saler.
		/// https://developer.allegro.pl/documentation/#!/sale-endpoint/getFlatParametersUsingGET_2 
		/// </summary>
		/// <param name="categoryUuid"></param>
		/// <returns>Parameters by category id</returns>
		public Response GetParametersByCategoryIdRaw(string categoryUuid)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetParametersByCategoryIdRaw", categoryUuid);
		}

		///<summary>
		/// [BETA] Gets categories for the saler. 
		/// </summary>
		/// <returns>List of categories</returns>
		public Response GetCategoriesRaw()
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetCategoriesRaw");
		}

		///<summary>
		/// [BETA] Gets categories children by parent id.
		/// https://developer.allegro.pl/documentation/#!/sale-endpoint/getCategoriesUsingGET 
		/// </summary>
		/// <param name="parentUuid">The unique parent id</param>
		/// <returns>Categories children by parent id</returns>
		public Response GetCategoriesByParentIdRaw(string parentUuid)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetCategoriesByParentIdRaw", parentUuid);
		}

		///<summary>
		/// [BETA] Gets category by id.
		/// https://developer.allegro.pl/documentation/#!/sale-endpoint/getCategoryUsingGET_1 
		/// </summary>
		/// <param name="categoryUuid">The unique category id</param>
		/// <returns>Category data info</returns>
		public Response GetCategoriesByIdRaw(string categoryUuid)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetCategoriesByIdRaw", categoryUuid);
		}

		///<summary>
		/// [BETA] Read size table of authenticated user.
		/// https://developer.allegro.pl/documentation/#!/size-tables/getTableUsingGET 
		/// </summary>
		/// <param name="tableUuid">The unique table id</param>
		/// <returns>Size table of authenticated user.</returns>
		public Response GetSizeTableRaw(string tableUuid)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetSizeTableRaw", tableUuid);
		}

		///<summary>
		/// [BETA] Read size tables list of authenticated user.
		/// https://developer.allegro.pl/documentation/#!/size-tables/getTablesUsingGET 
		/// </summary>
		/// <param name="userUuid">The unique user id</param>
		/// <returns>Size table list.</returns>
		public Response GetSizeTablesListRaw(string userUuid)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetSizeTablesListRaw", userUuid);
		}

		///<summary>
		/// Gets user rating-summary
		/// https://developer.allegro.pl/documentation/#!/user-ratings/getUserSummaryUsingGET 
		/// </summary>
		/// <param name="userUuid">The unique user id</param>
		/// <returns>User rating-summary.</returns>
		public Response GetUserRatingSummaryRaw(string userUuid)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetUserRatingSummaryRaw", userUuid);
		}

		///<summary>
		/// Gets user-rating
		/// https://developer.allegro.pl/documentation/#!/user-ratings/getUserRatingsUsingGET 
		/// </summary>
		/// <param name="userUuid">The unique user id. Filter by user id, you are allowed to get your ratings only.</param>
		/// <param name="recommended">Filter by recommended.</param>
		/// <param name="offset">It defines a number of a batch of returned data and is numbered from 0.</param>
		/// <param name="limit">It defines a number of elements on the page, which cannot be higher than the maximum limit supported by the resource.</param>
		/// <returns>User-rating.</returns>
		public Response GetUserRatingRaw(string userUuid, Boolean recommended, Int32 offset, Int32 limit)
		{
			return bNesisApi.Call<Response>("Allegro", bNesisToken, "GetUserRatingRaw", userUuid, recommended, offset, limit);
		}
}
}