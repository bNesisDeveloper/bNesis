Allegro = function (bNesisApi) {
    this.bNesisToken = null;
    var _bNesisApi = bNesisApi;

    /**
     * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
	 * or Attach to bNesis session with exists bNesis token
     * @return {string} bNesisToken value | true if bNesisToken is valid
	 */
    this.Auth = function (bNesisDevId,clientId,clientSecret,redirectUrl,scopes,isSandbox,data) {
		if(arguments.length !== 1){
			var bNesisToken = _bNesisApi.Auth("Allegro", data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,"","",isSandbox,"");
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
		var result = _bNesisApi.LogoffService("Allegro", this.bNesisToken);
		if (result) this.bNesisToken = "";
		return result;             
    }
	
	/**
	 *  Getting last exception for current provider 	
	 * @return {ErrorInfo} 
	 */
    this.GetLastError = function () {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetLastError");
        return result;
    }

	/**
	 *  Getting arrays of error info 	
	 * @return {ErrorInfo[]} 
	 */
    this.GetErrorLog = function () {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetErrorLog");
        return result;
    }

	/**
	 *  Checks the token in the service. 	
	 * @return {Boolean} if token valid return true, if token not valid return false
	 */
    this.ValidateToken = function () {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "ValidateToken");
        return result;
    }

	/**
	 *  Disables the access token used to authenticate the call. 	
	 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false
	 */
    this.Logoff = function () {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "Logoff");
        return result;
    }

	/**
	 *   	
	 * @param contactItem 
	 * @return {Boolean} 
	 */
    this.CreateCustomerUnified = function (contactItem) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "CreateCustomerUnified", contactItem);
        return result;
    }

	/**
	 *   	
	 * @return {ContactItem[]} 
	 */
    this.GetCustomersUnified = function () {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetCustomersUnified");
        return result;
    }

	/**
	 *   	
	 * @param productItem 
	 * @return {Boolean} 
	 */
    this.AddProductUnified = function (productItem) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "AddProductUnified", productItem);
        return result;
    }

	/**
	 *   	
	 * @return {ProductItem[]} 
	 */
    this.GetProductsUnified = function () {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetProductsUnified");
        return result;
    }

	/**
	 *   	
	 * @param IdProduct 
	 * @return {Boolean} 
	 */
    this.DeleteProductUnified = function (IdProduct) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "DeleteProductUnified", IdProduct);
        return result;
    }

	/**
	 *   	
	 * @return {CountryItem[]} 
	 */
    this.GetCountriesUnified = function () {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetCountriesUnified");
        return result;
    }

	/**
	 *   	
	 * @return {Int32} 
	 */
    this.GetCountCountriesUnified = function () {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetCountCountriesUnified");
        return result;
    }

	/**
	 *   	
	 * @param IdCountry 
	 * @return {CountryItem} 
	 */
    this.ReceiveCountryUnified = function (IdCountry) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "ReceiveCountryUnified", IdCountry);
        return result;
    }

	/**
	 *   	
	 * @param IdCountry 
	 * @return {Boolean} 
	 */
    this.DeleteCountryUnified = function (IdCountry) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "DeleteCountryUnified", IdCountry);
        return result;
    }

	/**
	 *   	
	 * @param countryItem 
	 * @return {CountryItem} 
	 */
    this.CreateCountryUnified = function (countryItem) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "CreateCountryUnified", countryItem);
        return result;
    }

	/**
	 *   	
	 * @param countryItem 
	 * @return {CountryItem} 
	 */
    this.UpdateCountryUnified = function (countryItem) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "UpdateCountryUnified", countryItem);
        return result;
    }

	/**
	 *   	
	 * @param IdCustomer 
	 * @return {ContactItem} 
	 */
    this.ReceiveCustomerUnified = function (IdCustomer) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "ReceiveCustomerUnified", IdCustomer);
        return result;
    }

	/**
	 *  Gets the user list. 	
	 * @return {Response} Data with info about list of user
	 */
    this.GetUserListRaw = function () {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetUserListRaw");
        return result;
    }

	/**
	 *  Create the user. 	
	 * @param user New user info
	 * @return {Response} Data with info about new user
	 */
    this.CreateUserRaw = function (user) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "CreateUserRaw", user);
        return result;
    }

	/**
	 *  Get the user by id. 	
	 * @param userUuid The unique user id
	 * @return {Response} Data with info about user
	 */
    this.GetUserRaw = function (userUuid) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetUserRaw", userUuid);
        return result;
    }

	/**
	 *  Update the user by id. 	
	 * @param userUuid The unique user id
	 * @param user User info for update
	 * @return {Response} Data with info about user after update
	 */
    this.UpdateUserRaw = function (userUuid, user) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "UpdateUserRaw", userUuid, user);
        return result;
    }

	/**
	 *  Delete the user by id. 	
	 * @param userUuid The unique user id
	 * @return {Response} response message
	 */
    this.DeleteUserRaw = function (userUuid) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "DeleteUserRaw", userUuid);
        return result;
    }

	/**
	 *  Gets seller return policies.
	 * You are allowed to list only your return policies
	 * https://developer.allegro.pl/documentation/#!/after-sales-service-conditions/getPublicSellerListingUsingGET_1 	
	 * @param sellerUuid Seller Id
	 * @param offset It defines a number of a batch of returned data and is numbered from 0.
	 * @param limit It defines a number of elements on the page, which cannot be higher than the maximum limit supported by the resource.
	 * @return {Response} Seller return policies
	 */
    this.GetSellerReturnPoliciesRaw = function (sellerUuid, offset, limit) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetSellerReturnPoliciesRaw", sellerUuid, offset, limit);
        return result;
    }

	/**
	 *  Gets seller implied warranties.
	 * You are allowed to list only your implied warranties
	 * https://developer.allegro.pl/documentation/#!/after-sales-service-conditions/getPublicSellerListingUsingGET 	
	 * @param sellerUuid Seller Id
	 * @param offset It defines a number of a batch of returned data and is numbered from 0.
	 * @param limit It defines a number of elements on the page, which cannot be higher than the maximum limit supported by the resource.
	 * @return {Response} Seller implied warranties
	 */
    this.GetSellerImpliedWarrantiesRaw = function (sellerUuid, offset, limit) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetSellerImpliedWarrantiesRaw", sellerUuid, offset, limit);
        return result;
    }

	/**
	 *  Gets seller warranties.
	 * You are allowed to list only your warranties
	 * https://developer.allegro.pl/documentation/#!/after-sales-service-conditions/getPublicSellerListingUsingGET_2 	
	 * @param sellerUuid Seller Id
	 * @param offset It defines a number of a batch of returned data and is numbered from 0.
	 * @param limit It defines a number of elements on the page, which cannot be higher than the maximum limit supported by the resource.
	 * @return {Response} Seller warranties
	 */
    this.GetSellerWarrantiesRaw = function (sellerUuid, offset, limit) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetSellerWarrantiesRaw", sellerUuid, offset, limit);
        return result;
    }

	/**
	 *  Changes a Buy Now price in a single offer
	 * https://developer.allegro.pl/documentation/#!/default/put_offers_offerId_change_price_commands_commandId 	
	 * @param offerUuid The unique offer id
	 * @param commandUuid UUID you generate to enforce idempotency
	 * @param command Command input data. Note that the amount field must be transferred as a string to avoid rounding errors. A currency must be provided as a 3-letter code as defined in ISO 4217.
	 * @return {Response} Updated Buy Now price in offer
	 */
    this.ChangeBuyNowPriceInOfferRaw = function (offerUuid, commandUuid, command) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "ChangeBuyNowPriceInOfferRaw", offerUuid, commandUuid, command);
        return result;
    }

	/**
	 *  [BETA] Provides publication report summary for given commandid
	 * https://developer.allegro.pl/documentation/#!/offer/getPublicationReportUsingGET 	
	 * @param commandUuid UUID you generate to enforce idempotency
	 * @return {Response} Offer publication data
	 */
    this.GetOffersPublicationReportSummaryByIdRaw = function (commandUuid) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetOffersPublicationReportSummaryByIdRaw", commandUuid);
        return result;
    }

	/**
	 *  [BETA] Allows modification of multiple offers' publication at once.
	 * https://developer.allegro.pl/documentation/#!/offer/changePublicationStatusUsingPUT 	
	 * @param commandUuid UUID you generate to enforce idempotency
	 * @param publicationChangeCommandDto Command to change publication
	 * @return {Response} Updated offers' publication data
	 */
    this.ChangeOffersPublicationByIdRaw = function (commandUuid, publicationChangeCommandDto) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "ChangeOffersPublicationByIdRaw", commandUuid, publicationChangeCommandDto);
        return result;
    }

	/**
	 *  Provides modification report summary for given commandid
	 * https://developer.allegro.pl/documentation/#!/offer/getGeneralReportUsingGET 	
	 * @param commandUuid UUID you generate to enforce idempotency
	 * @return {Response} Offer modification data
	 */
    this.GetOffersModificationReportSummaryByIdRaw = function (commandUuid) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetOffersModificationReportSummaryByIdRaw", commandUuid);
        return result;
    }

	/**
	 *  Allows modification of multiple offers at once.
	 * https://developer.allegro.pl/documentation/#!/offer/modificationCommandUsingPUT 	
	 * @param commandUuid UUID you generate to enforce idempotency
	 * @param publicationChangeCommandDto command to change publication
	 * @return {Response} Updated offer modification data
	 */
    this.ChangeOffersModificationByIdRaw = function (commandUuid, publicationChangeCommandDto) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "ChangeOffersModificationByIdRaw", commandUuid, publicationChangeCommandDto);
        return result;
    }

	/**
	 *  [BETA] Returns a list of seller's shipping rates. Seller authentication is required.
	 * https://developer.allegro.pl/documentation/#!/offer/get_sale_shipping_rates 	
	 * @param sellerUuid id of shipping rates owner
	 * @return {Response} List of seller's shipping rates
	 */
    this.GetSellersShippingRatesRaw = function (sellerUuid) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetSellersShippingRatesRaw", sellerUuid);
        return result;
    }

	/**
	 *  Gets list of offers. 	
	 * @return {Response} Total list of offers
	 */
    this.GetAllOffersRaw = function () {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetAllOffersRaw");
        return result;
    }

	/**
	 *  [BETA] Gets list of offers for the saler. 	
	 * @return {Response} List of offers
	 */
    this.GetOffersRaw = function () {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetOffersRaw");
        return result;
    }

	/**
	 *  [BETA] Creates single offer 
	 * https://developer.allegro.pl/documentation/#!/offer/createOfferUsingPOST 	
	 * @param offer offer
	 * @return {Response} Data with info about user
	 */
    this.CreateOfferRaw = function (offer) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "CreateOfferRaw", offer);
        return result;
    }

	/**
	 *  [BETA] Returns a list of available delivery methods. Client authentication is required.
	 * https://developer.allegro.pl/documentation/#!/offer/get_sale_delivery_methods 	
	 * @return {Response} list of available delivery methods
	 */
    this.GetDeliveryMethodsRaw = function () {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetDeliveryMethodsRaw");
        return result;
    }

	/**
	 *  [BETA] Gets single offer by id
	 * https://developer.allegro.pl/documentation/#!/offer/getOfferUsingGET 	
	 * @param offerUuid The unique offer id
	 * @return {Response} Offer data info
	 */
    this.GetOffersByIdRaw = function (offerUuid) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetOffersByIdRaw", offerUuid);
        return result;
    }

	/**
	 *  [BETA] Modifies offer by id.
	 * https://developer.allegro.pl/documentation/#!/offer/updateOfferUsingPUT 	
	 * @param offerUuid The unique offer id
	 * @param offer Offer data info for update
	 * @return {Response} Updated offer data info
	 */
    this.UpdateOfferRaw = function (offerUuid, offer) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "UpdateOfferRaw", offerUuid, offer);
        return result;
    }

	/**
	 *  [BETA] Returns details of the given shipping rates set. Seller authentication is required.
	 * https://developer.allegro.pl/documentation/#!/offer/get_sale_shipping_rates_id 	
	 * @param shippingRatesUuid id of shipping rates set
	 * @return {Response} Details of the given shipping rates set.
	 */
    this.GetShippingRatesDetailsByIdRaw = function (shippingRatesUuid) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetShippingRatesDetailsByIdRaw", shippingRatesUuid);
        return result;
    }

	/**
	 *  Provides detailed modification report for single command task
	 * https://developer.allegro.pl/documentation/#!/offer/getTasksUsingGET 	
	 * @param commandUuid id of command task
	 * @param offset It defines a number of a batch of returned data and is numbered from 0.
	 * @param limit It defines a number of elements on the page, which cannot be higher than the maximum limit supported by the resource.
	 * @return {Response} Detailed modification report for single command task
	 */
    this.GetModificationDetailedReportRaw = function (commandUuid, offset, limit) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetModificationDetailedReportRaw", commandUuid, offset, limit);
        return result;
    }

	/**
	 *  [BETA] Provides detailed publication report for single command task
	 * https://developer.allegro.pl/documentation/#!/offer/getPublicationTasksUsingGET 	
	 * @param commandUuid Id of command task
	 * @param offset It defines a number of a batch of returned data and is numbered from 0.
	 * @param limit It defines a number of elements on the page, which cannot be higher than the maximum limit supported by the resource.
	 * @return {Response} Detailed publication report for single command task
	 */
    this.GetPublicationDetailedReportRaw = function (commandUuid, offset, limit) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetPublicationDetailedReportRaw", commandUuid, offset, limit);
        return result;
    }

	/**
	 *  Returns group of additional services defined by user
	 * https://developer.allegro.pl/documentation/#!/offer-additional-services/get_sale_offer_additional_services_groups 	
	 * @param userUuid The unique user id
	 * @param offset It defines a number of a batch of returned data and is numbered from 0.
	 * @param limit It defines a number of elements on the page, which cannot be higher than the maximum limit supported by the resource.
	 * @return {Response} Additional service groups by user ID
	 */
    this.GetAdditionalServiceGroupRaw = function (userUuid, offset, limit) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetAdditionalServiceGroupRaw", userUuid, offset, limit);
        return result;
    }

	/**
	 *  Creates group of additional services
	 * https://developer.allegro.pl/documentation/#!/offer-additional-services/post_sale_offer_additional_services_groups 	
	 * @param body Aditional service group body
	 * @return {Response} Additional service group
	 */
    this.CreateAdditionalServiceGroupRaw = function (body) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "CreateAdditionalServiceGroupRaw", body);
        return result;
    }

	/**
	 *  Returns additional services definitions
	 * https://developer.allegro.pl/documentation/#!/offer-additional-services/get_sale_offer_additional_services_definitions 	
	 * @param userUuid The unique user id
	 * @param offset It defines a number of a batch of returned data and is numbered from 0.
	 * @param limit It defines a number of elements on the page, which cannot be higher than the maximum limit supported by the resource.
	 * @return {Response} Additional services definition by user ID
	 */
    this.GetAdditionalServiceDefinitionsRaw = function (userUuid, offset, limit) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetAdditionalServiceDefinitionsRaw", userUuid, offset, limit);
        return result;
    }

	/**
	 *  Returns additional services group for a given Id
	 * https://developer.allegro.pl/documentation/#!/offer-additional-services/get_sale_offer_additional_services_groups_groupId 	
	 * @param groupUuid Additional service group ID
	 * @return {Response} Additional services group for a given Id
	 */
    this.GetAdditionalServiceGroupForIdRaw = function (groupUuid) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetAdditionalServiceGroupForIdRaw", groupUuid);
        return result;
    }

	/**
	 *  Updates existing additional service group
	 * https://developer.allegro.pl/documentation/#!/offer-additional-services/put_sale_offer_additional_services_groups_groupId 	
	 * @param groupUuid Additional service group ID
	 * @param body Additional service group body
	 * @return {Response} Updated additional service group
	 */
    this.UpdateAdditionalServiceGroupRaw = function (groupUuid, body) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "UpdateAdditionalServiceGroupRaw", groupUuid, body);
        return result;
    }

	/**
	 *  Gets all contacts
	 * https://developer.allegro.pl/documentation/#!/offer-contacts/get_sale_offer_contacts 	
	 * @param sellerUuid Seller Id
	 * @return {Response} List of all contacts
	 */
    this.GetAllContactsRaw = function (sellerUuid) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetAllContactsRaw", sellerUuid);
        return result;
    }

	/**
	 *  Creates new contact
	 * https://developer.allegro.pl/documentation/#!/offer-contacts/post_sale_offer_contacts 	
	 * @param body New contact data info
	 * @return {Response} New contact data info
	 */
    this.CreateContactRaw = function (body) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "CreateContactRaw", body);
        return result;
    }

	/**
	 *  Gets contact info by Id
	 * https://developer.allegro.pl/documentation/#!/offer-contacts/get_sale_offer_contacts_id 	
	 * @param contactUuid Contact ID
	 * @return {Response} Contact data info
	 */
    this.GetContactRaw = function (contactUuid) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetContactRaw", contactUuid);
        return result;
    }

	/**
	 *  Updates existing contact
	 * https://developer.allegro.pl/documentation/#!/offer-contacts/put_sale_offer_contacts_id 	
	 * @param contactUuid Contact ID
	 * @param body Contact data info for update
	 * @return {Response} Updated contact data info
	 */
    this.UpdateContactRaw = function (contactUuid, body) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "UpdateContactRaw", contactUuid, body);
        return result;
    }

	/**
	 *  Deletes a point of service. User authentication is required.
	 * https://developer.allegro.pl/documentation/#!/points-of-service/delete_points_of_service_id 	
	 * @param pointOfServiceUuid Point of service id
	 * @return {Response} response message
	 */
    this.DeletePointOfServiceRaw = function (pointOfServiceUuid) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "DeletePointOfServiceRaw", pointOfServiceUuid);
        return result;
    }

	/**
	 *  Returns point of service details for a given Id. Client authentication is required.
	 * https://developer.allegro.pl/documentation/#!/points-of-service/get_points_of_service_id 	
	 * @param pointOfServiceUuid Point of service ID
	 * @return {Response} Point of service details for a given Id
	 */
    this.GetPointOfServiceRaw = function (pointOfServiceUuid) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetPointOfServiceRaw", pointOfServiceUuid);
        return result;
    }

	/**
	 *  Updates a point of service. User authentication is required.
	 * https://developer.allegro.pl/documentation/#!/points-of-service/put_points_of_service_id 	
	 * @param pointOfServiceUuid Point of service ID. Must match values with 'id' property from the body.
	 * @param body Contact data info for update
	 * @return {Response} Updates contact data info
	 */
    this.UpdatePointOfServiceRaw = function (pointOfServiceUuid, body) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "UpdatePointOfServiceRaw", pointOfServiceUuid, body);
        return result;
    }

	/**
	 *  Returns a list of points of service. Client authentication is required.
	 * https://developer.allegro.pl/documentation/#!/points-of-service/get_points_of_service 	
	 * @param sellerUuid Seller ID
	 * @return {Response} List of points of service by seller ID
	 */
    this.GetPointOfServiceListRaw = function (sellerUuid) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetPointOfServiceListRaw", sellerUuid);
        return result;
    }

	/**
	 *  Creates a point of service. User authentication is required.
	 * https://developer.allegro.pl/documentation/#!/points-of-service/post_points_of_service 	
	 * @param pointOfService Point of service info to add
	 * @return {Response} New point of service
	 */
    this.CreatePointOfServiceListRaw = function (pointOfService) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "CreatePointOfServiceListRaw", pointOfService);
        return result;
    }

	/**
	 *  This endpoint calculates fees for a provided offer conditions. The quotation is estimated and based on the current configuration of the Allegro
	 * price list and the data entered in this API. The stated price does not include package discounts. The rules of charging and amount of charges are
	 * described in the Allegro regulations in Appendix 4. The final amount of the fee for the offer will be available after approval under the tab: My
	 * Account> Accounts> History.
	 * https://developer.allegro.pl/documentation/#!/pricing/previewFeesPublicAPIUsingPOST 	
	 * @param command Command used for calculate fee preview
	 * @return {Response} Fees for a provided offer conditions
	 */
    this.CalculateFeePReviewRaw = function (command) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "CalculateFeePReviewRaw", command);
        return result;
    }

	/**
	 *  This endpoint returns current offer quotes (listing and promo fees) cycles for authenticated user and list of offers.
	 * https://developer.allegro.pl/documentation/#!/pricing/offerQuotesPublicUsingGET 	
	 * @param offerUuid List of offer ids, maximum 20 values
	 * @return {Response} Current offer quotes for authenticated user and list of offers
	 */
    this.GetCurrentOfferQuotesRaw = function (offerUuid) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetCurrentOfferQuotesRaw", offerUuid);
        return result;
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
	 */
    this.GetPromotionsListRaw = function (userUuid, offset, limit, details, authenticated) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetPromotionsListRaw", userUuid, offset, limit, details, authenticated);
        return result;
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
	 */
    this.CrearePromotionRaw = function (request, details, authenticated) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "CrearePromotionRaw", request, details, authenticated);
        return result;
    }

	/**
	 *  Deactivates the requested promotion. You need to use its unique id.
	 * https://developer.allegro.pl/documentation/#!/promotions/deactivatePromotionUsingDELETE 	
	 * @param promotionUuid promotion id
	 * @return {Response} response message
	 */
    this.DeactivatePromotionRaw = function (promotionUuid) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "DeactivatePromotionRaw", promotionUuid);
        return result;
    }

	/**
	 *  Returns the requested promotion. You need to use its unique id.
	 * https://developer.allegro.pl/documentation/#!/promotions/getPromotionUsingGET 	
	 * @param promotionUuid Promotion id
	 * @param details 
	 * @param authenticated 
	 * @return {Response} List of promotions by user id
	 */
    this.GetPromotionRaw = function (promotionUuid, details, authenticated) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetPromotionRaw", promotionUuid, details, authenticated);
        return result;
    }

	/**
	 *  [BETA] Gets parameters by category id for the saler.
	 * https://developer.allegro.pl/documentation/#!/sale-endpoint/getFlatParametersUsingGET_2 	
	 * @param categoryUuid 
	 * @return {Response} Parameters by category id
	 */
    this.GetParametersByCategoryIdRaw = function (categoryUuid) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetParametersByCategoryIdRaw", categoryUuid);
        return result;
    }

	/**
	 *  [BETA] Gets categories for the saler. 	
	 * @return {Response} List of categories
	 */
    this.GetCategoriesRaw = function () {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetCategoriesRaw");
        return result;
    }

	/**
	 *  [BETA] Gets categories children by parent id.
	 * https://developer.allegro.pl/documentation/#!/sale-endpoint/getCategoriesUsingGET 	
	 * @param parentUuid The unique parent id
	 * @return {Response} Categories children by parent id
	 */
    this.GetCategoriesByParentIdRaw = function (parentUuid) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetCategoriesByParentIdRaw", parentUuid);
        return result;
    }

	/**
	 *  [BETA] Gets category by id.
	 * https://developer.allegro.pl/documentation/#!/sale-endpoint/getCategoryUsingGET_1 	
	 * @param categoryUuid The unique category id
	 * @return {Response} Category data info
	 */
    this.GetCategoriesByIdRaw = function (categoryUuid) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetCategoriesByIdRaw", categoryUuid);
        return result;
    }

	/**
	 *  [BETA] Read size table of authenticated user.
	 * https://developer.allegro.pl/documentation/#!/size-tables/getTableUsingGET 	
	 * @param tableUuid The unique table id
	 * @return {Response} Size table of authenticated user.
	 */
    this.GetSizeTableRaw = function (tableUuid) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetSizeTableRaw", tableUuid);
        return result;
    }

	/**
	 *  [BETA] Read size tables list of authenticated user.
	 * https://developer.allegro.pl/documentation/#!/size-tables/getTablesUsingGET 	
	 * @param userUuid The unique user id
	 * @return {Response} Size table list.
	 */
    this.GetSizeTablesListRaw = function (userUuid) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetSizeTablesListRaw", userUuid);
        return result;
    }

	/**
	 *  Gets user rating-summary
	 * https://developer.allegro.pl/documentation/#!/user-ratings/getUserSummaryUsingGET 	
	 * @param userUuid The unique user id
	 * @return {Response} User rating-summary.
	 */
    this.GetUserRatingSummaryRaw = function (userUuid) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetUserRatingSummaryRaw", userUuid);
        return result;
    }

	/**
	 *  Gets user-rating
	 * https://developer.allegro.pl/documentation/#!/user-ratings/getUserRatingsUsingGET 	
	 * @param userUuid The unique user id. Filter by user id, you are allowed to get your ratings only.
	 * @param recommended Filter by recommended.
	 * @param offset It defines a number of a batch of returned data and is numbered from 0.
	 * @param limit It defines a number of elements on the page, which cannot be higher than the maximum limit supported by the resource.
	 * @return {Response} User-rating.
	 */
    this.GetUserRatingRaw = function (userUuid, recommended, offset, limit) {
        var result = _bNesisApi.Call("Allegro", this.bNesisToken, "GetUserRatingRaw", userUuid, recommended, offset, limit);
        return result;
    }
}
