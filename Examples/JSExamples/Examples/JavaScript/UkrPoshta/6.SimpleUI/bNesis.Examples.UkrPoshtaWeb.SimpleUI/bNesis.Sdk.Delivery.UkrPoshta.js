UkrPoshta = function (bNesisApi) {
    this.bNesisToken = null;
    var _bNesisApi = bNesisApi;

    /**
     * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
	 * or Attach to bNesis session with exists bNesis token
     * @return {string} bNesisToken value | true if bNesisToken is valid
	 */
    this.Auth = function (bNesisDevId,redirectUrl,clientId,clientSecret,isSandbox) {
		if(arguments.length !== 1){
			var bNesisToken = _bNesisApi.Auth("UkrPoshta", "",bNesisDevId,redirectUrl,clientId,clientSecret,null,"","",isSandbox,"");
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
		var result = _bNesisApi.LogoffService("UkrPoshta", this.bNesisToken);
		if (result) this.bNesisToken = "";
		return result;             
    }
	
	/**
	 *  Getting last exception for current provider 	
	 * @return {ErrorInfo} 
	 */
    this.GetLastError = function () {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "GetLastError");
        return result;
    }

	/**
	 *  Getting arrays of error info 	
	 * @return {ErrorInfo[]} 
	 */
    this.GetErrorLog = function () {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "GetErrorLog");
        return result;
    }

	/**
	 *  Checks the token in the service. 	
	 * @return {Boolean} if token valid return true, if token not valid return false
	 */
    this.ValidateToken = function () {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "ValidateToken");
        return result;
    }

	/**
	 *  Disables the access token used to authenticate the call. 	
	 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false
	 */
    this.Logoff = function () {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "Logoff");
        return result;
    }

	/**
	 *  Getting address by identifier. 	
	 * @param id Address identifier.
	 * @return {UkrPoshtaAddressOut} Return in AddressOut.
	 */
    this.GetAddress = function (id) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "GetAddress", id);
        return result;
    }

	/**
	 *  Creating new address. 	
	 * @param address Body of address(required:postcode).
	 * @return {UkrPoshtaAddressOut} Return in AddressOut.
	 */
    this.AddAddress = function (address) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "AddAddress", address);
        return result;
    }

	/**
	 *  Creating new clients. 	
	 * @param client Requirment CustomerIn.
	 *     If the client is an individual, then the value of the individual should be true.In this case, you must specify the first name, last name and patronymic of the client (firstName, lastName and middleName parameters respectively).The name parameter is generated automatically. If the client is a legal entity, the value of the individual must be false. In this case, the API accepts only the parameter name.
	 * @return {UkrPoshtaCustomerOut} Return in CustomerOut.
	 */
    this.AddClient = function (client) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "AddClient", client);
        return result;
    }

	/**
	 *  Creating new clients. 	
	 * @param clients Requirment array of CustomerIn.
	 *     If the client is an individual, then the value of the individual should be true.In this case, you must specify the first name, last name and patronymic of the client (firstName, lastName and middleName parameters respectively).The name parameter is generated automatically. If the client is a legal entity, the value of the individual must be false. In this case, the API accepts only the parameter name.
	 * @return {UkrPoshtaCustomerOut[]} Return in CustomerOut.
	 */
    this.AddClients = function (clients) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "AddClients", clients);
        return result;
    }

	/**
	 *  Edit client. 	
	 * @param clientUuid Client uuid
	 * @param client Body of CustomerIn.
	 * @return {UkrPoshtaCustomerOut} Return in CustomerOut.
	 */
    this.EditClient = function (clientUuid, client) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "EditClient", clientUuid, client);
        return result;
    }

	/**
	 *  Getting client. 	
	 * @param externalId External identifier
	 * @return {UkrPoshtaCustomerOut[]} Return in CustomerOut.
	 */
    this.GetClients = function (externalId) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "GetClients", externalId);
        return result;
    }

	/**
	 *  Getting telephones numbers of client. 	
	 * @param clientUuid Client uuid.
	 * @return {UkrPoshtaCustomerPhone[]} Return in CustomerPhone.
	 */
    this.GetClientPhones = function (clientUuid) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "GetClientPhones", clientUuid);
        return result;
    }

	/**
	 *  Delete telephone number from client. 	
	 * @param phoneNumberUuid Phone uuid
	 * @return {Boolean} Return in true if delete.
	 */
    this.DeleteClientPhone = function (phoneNumberUuid) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "DeleteClientPhone", phoneNumberUuid);
        return result;
    }

	/**
	 *  Getting addresses of client. 	
	 * @param clientUuid Client uuid.
	 * @return {UkrPoshtaCustomerAddress[]} Return in CustomerAddress.
	 */
    this.GetClientAddresses = function (clientUuid) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "GetClientAddresses", clientUuid);
        return result;
    }

	/**
	 *  Delete address from client. 	
	 * @param addressUuid Address uuid.
	 * @return {Boolean} Return in true if delete.
	 */
    this.DeleteClientAddress = function (addressUuid) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "DeleteClientAddress", addressUuid);
        return result;
    }

	/**
	 *  Getting emails of client. 	
	 * @param clientUuid Client uuid
	 * @return {UkrPoshtaCustomerEmail[]} Return in CustomerEmail.
	 */
    this.GetClientEmails = function (clientUuid) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "GetClientEmails", clientUuid);
        return result;
    }

	/**
	 *  Delete email from client. 	
	 * @param emailUuid Email uuid.
	 * @return {Boolean} Return in true if delete.
	 */
    this.DeleteClientEmail = function (emailUuid) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "DeleteClientEmail", emailUuid);
        return result;
    }

	/**
	 *  Creating new shipment. 	
	 * @param shipment Body of ShipmentIn.
	 * The sender and recipient when creating a postal mail are specified as an embedded JSON:if uuid client is not empty or null, then the existing client will be used, otherwise - a new one will be created.When creating a shipment, the sender may specify additional recipient information that is used in printed forms.There can be only one "parcel" in the current release in the mail.Parameters of dispatch are filled out on the basis of parcel (weight, length, declaredPrice, etc.).The delivery amount is calculated when creating a postal item and is displayed in the response body as the "deliveryPrice" parameter.
	 * @return {UkrPoshtaShipmentOut} Return in ShipmentOut.
	 */
    this.AddShipment = function (shipment) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "AddShipment", shipment);
        return result;
    }

	/**
	 *  Edit shipment group by uuid. 	
	 * @param shipmentGroupUuid Shipment group uuid
	 * @param shipment Body of shipment
	 * @return {UkrPoshtaShipmentOut} Return in ShipmentOut.
	 */
    this.EditShipment = function (shipmentGroupUuid, shipment) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "EditShipment", shipmentGroupUuid, shipment);
        return result;
    }

	/**
	 *  Getting shipment by uuid. 	
	 * @param shipmentUuid Shipment uuid.
	 * @return {UkrPoshtaShipmentOut} Return in ShipmentOut.
	 */
    this.GetShipment = function (shipmentUuid) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "GetShipment", shipmentUuid);
        return result;
    }

	/**
	 *  Delete shipment by uuid. 	
	 * @param shipmentUuid Shipment uuid.
	 * @return {Boolean} Return in true if delete.
	 */
    this.DeleteShipment = function (shipmentUuid) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "DeleteShipment", shipmentUuid);
        return result;
    }

	/**
	 *  Creating shipment group. 	
	 * @param shipmentGroup Body of shipment group.
	 * @return {UkrPoshtaShipmentGroupOut} Return in ShipmentGroupOut.
	 */
    this.AddShipmentGroup = function (shipmentGroup) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "AddShipmentGroup", shipmentGroup);
        return result;
    }

	/**
	 *  Edit shipment group by uuid. 	
	 * @param shipmentGroupUuid Shipment group uuid.
	 * @param shipmentGroup Body of shipment group.
	 * @return {UkrPoshtaShipmentGroupOut} Return in ShipmentGroupOut.
	 */
    this.EditShipmentGroup = function (shipmentGroupUuid, shipmentGroup) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "EditShipmentGroup", shipmentGroupUuid, shipmentGroup);
        return result;
    }

	/**
	 *  Getting shimpent group by client uuid. 	
	 * @param clientUuid Client uuid.
	 * @return {UkrPoshtaShipmentGroupOut} Return in ShipmentGroupOut.
	 */
    this.GetShipmentGroupByClient = function (clientUuid) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "GetShipmentGroupByClient", clientUuid);
        return result;
    }

	/**
	 *  Getting shipment by uuid. 	
	 * @param shipmentGroupUuid Shipment group uuid.
	 * @return {UkrPoshtaShipmentGroupOut} Return in ShipmentGroupOut.
	 */
    this.GetShipmentGroup = function (shipmentGroupUuid) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "GetShipmentGroup", shipmentGroupUuid);
        return result;
    }

	/**
	 *  Delete shipmnent by uuid. 	
	 * @param shipmentUuid Shipment uuid.
	 * @return {Boolean} Return in true if delete.
	 */
    this.DeleteShipmentGroup = function (shipmentUuid) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "DeleteShipmentGroup", shipmentUuid);
        return result;
    }

	/**
	 *  Getting postal invoice size A5 in PDF format. 	
	 * @param shipmentUuid Shipment identifier
	 * @param hideDeliveryPrice 1 - hide delivery price 0 - unhide delivery price.
	 * @return {Stream} Return bytes of file
	 */
    this.GetShipmentLabel = function (shipmentUuid, hideDeliveryPrice) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "GetShipmentLabel", shipmentUuid, hideDeliveryPrice);
        return result;
    }

	/**
	 *  Getting address label 100*100 in PDF format. 	
	 * @param shipmentUuid Shipment identifier
	 * @return {Stream} Return bytes of file
	 */
    this.GetShipmentSticker = function (shipmentUuid) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "GetShipmentSticker", shipmentUuid);
        return result;
    }

	/**
	 *  Getting all invoices and forms postpay for shipment group in PDF format. 	
	 * @param shipmentGroupUuid Shipment group identifier.
	 * @return {Stream} Return bytes of file
	 */
    this.GetShipmentGroupLabel = function (shipmentGroupUuid) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "GetShipmentGroupLabel", shipmentGroupUuid);
        return result;
    }

	/**
	 *  Getting labels for shipment group in PDF format. 	
	 * @param shipmentGroupUuid Shipment group identifier.
	 * @return {Stream} Return bytes of file
	 */
    this.GetShipmentGroupSticker = function (shipmentGroupUuid) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "GetShipmentGroupSticker", shipmentGroupUuid);
        return result;
    }

	/**
	 *  Getting form 103a for shipment group in PDF format. 	
	 * @param shipmentGroupUuid Shipment group identifier.
	 * @return {Stream} Return bytes of file
	 */
    this.GetShipmentGroupForm103a = function (shipmentGroupUuid) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "GetShipmentGroupForm103a", shipmentGroupUuid);
        return result;
    }

	/**
	 *  Getting address by identifier. 	
	 * @param id Address identifier.
	 * @return {Response} Return in responce.
	 */
    this.GetAddressRaw = function (id) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "GetAddressRaw", id);
        return result;
    }

	/**
	 *  Creating new address. 	
	 * @param address Body of address(required:postcode).
	 * @return {Response} Return in response.
	 */
    this.AddAddressRaw = function (address) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "AddAddressRaw", address);
        return result;
    }

	/**
	 *  Creating new client. 	
	 * @param clients Requirment body client.
	 * If the client is an individual, then the value of the individual should be true.In this case, you must specify the first name, last name and patronymic of the client (firstName, lastName and middleName parameters respectively).The name parameter is generated automatically. If the client is a legal entity, the value of the individual must be false. In this case, the API accepts only the parameter name.
	 * @return {Response} Return in response.
	 */
    this.AddClientsRaw = function (clients) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "AddClientsRaw", clients);
        return result;
    }

	/**
	 *  Edit client. 	
	 * @param clientUuid Client uuid
	 * @param client Body client.
	 * @return {Response} Return in response.
	 */
    this.EditClientRaw = function (clientUuid, client) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "EditClientRaw", clientUuid, client);
        return result;
    }

	/**
	 *  Getting client. 	
	 * @param externalId External identifier
	 * @return {Response} Return in response.
	 */
    this.GetClientsRaw = function (externalId) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "GetClientsRaw", externalId);
        return result;
    }

	/**
	 *  Getting telephones numbers of client. 	
	 * @param clientUuid Client uuid.
	 * @return {Response} Return in response.
	 */
    this.GetClientPhonesRaw = function (clientUuid) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "GetClientPhonesRaw", clientUuid);
        return result;
    }

	/**
	 *  Delete telephone number from client. 	
	 * @param phoneNumberUuid Phone uuid
	 * @return {Response} Return in response.
	 */
    this.DeleteClientPhoneRaw = function (phoneNumberUuid) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "DeleteClientPhoneRaw", phoneNumberUuid);
        return result;
    }

	/**
	 *  Getting addresses of client. 	
	 * @param clientUuid Client uuid.
	 * @return {Response} Return in response.
	 */
    this.GetClientAddressesRaw = function (clientUuid) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "GetClientAddressesRaw", clientUuid);
        return result;
    }

	/**
	 *  Delete address from client. 	
	 * @param addressUuid Address uuid.
	 * @return {Response} Return in response.
	 */
    this.DeleteClientAddressRaw = function (addressUuid) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "DeleteClientAddressRaw", addressUuid);
        return result;
    }

	/**
	 *  Getting emails of client. 	
	 * @param clientUuid Client uuid
	 * @return {Response} Return in response.
	 */
    this.GetClientEmailsRaw = function (clientUuid) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "GetClientEmailsRaw", clientUuid);
        return result;
    }

	/**
	 *  Delete email from client. 	
	 * @param emailUuid Email uuid.
	 * @return {Response} Return in response.
	 */
    this.DeleteClientEmailRaw = function (emailUuid) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "DeleteClientEmailRaw", emailUuid);
        return result;
    }

	/**
	 *  Creating new shipment. 	
	 * @param shipment Body of shipment.
	 * The sender and recipient when creating a postal mail are specified as an embedded JSON:if uuid client is not empty or null, then the existing client will be used, otherwise - a new one will be created.When creating a shipment, the sender may specify additional recipient information that is used in printed forms.There can be only one "parcel" in the current release in the mail.Parameters of dispatch are filled out on the basis of parcel (weight, length, declaredPrice, etc.).The delivery amount is calculated when creating a postal item and is displayed in the response body as the "deliveryPrice" parameter.
	 * @return {Response} Return in response.
	 */
    this.AddShipmentRaw = function (shipment) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "AddShipmentRaw", shipment);
        return result;
    }

	/**
	 *  Eddut shipment group by uuid. 	
	 * @param shipmentGroupUuid Shipment group uuid
	 * @param shipment Body of shipment
	 * @return {Response} Return in response.
	 */
    this.EditShipmentRaw = function (shipmentGroupUuid, shipment) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "EditShipmentRaw", shipmentGroupUuid, shipment);
        return result;
    }

	/**
	 *  Getting shipment by uuid. 	
	 * @param shipmentUuid Shipment uuid.
	 * @return {Response} Return in response.
	 */
    this.GetShipmentRaw = function (shipmentUuid) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "GetShipmentRaw", shipmentUuid);
        return result;
    }

	/**
	 *  Delete shipment by uuid. 	
	 * @param shipmentUuid Shipment uuid.
	 * @return {Response} Return in response.
	 */
    this.DeleteShipmentRaw = function (shipmentUuid) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "DeleteShipmentRaw", shipmentUuid);
        return result;
    }

	/**
	 *  Creating shipment group. 	
	 * @param shipmentGroup Body of shipment group.
	 * @return {Response} Return in response.
	 */
    this.AddShipmentGroupRaw = function (shipmentGroup) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "AddShipmentGroupRaw", shipmentGroup);
        return result;
    }

	/**
	 *  Edit shipment group by uuid. 	
	 * @param shipmentGroupUuid Shipment group uuid.
	 * @param shipmentGroup Body of shipment group.
	 * @return {Response} Return in response.
	 */
    this.EditShipmentGroupRaw = function (shipmentGroupUuid, shipmentGroup) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "EditShipmentGroupRaw", shipmentGroupUuid, shipmentGroup);
        return result;
    }

	/**
	 *  Getting shimpent group by client uuid. 	
	 * @param clientUuid Client uuid.
	 * @return {Response} Return in response.
	 */
    this.GetShipmentGroupByClientRaw = function (clientUuid) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "GetShipmentGroupByClientRaw", clientUuid);
        return result;
    }

	/**
	 *  Getting shipment by uuid. 	
	 * @param shipmentGroupUuid Shipment group uuid.
	 * @return {Response} Return in response.
	 */
    this.GetShipmentGroupRaw = function (shipmentGroupUuid) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "GetShipmentGroupRaw", shipmentGroupUuid);
        return result;
    }

	/**
	 *  Delete shipmnent by uuid. 	
	 * @param shipmentUuid Shipment uuid.
	 * @return {Response} Return in response.
	 */
    this.DeleteShipmentGroupRaw = function (shipmentUuid) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "DeleteShipmentGroupRaw", shipmentUuid);
        return result;
    }

	/**
	 *  Getting postal invoice size A5 in PDF format. 	
	 * @param shipmentUuid Shipment identifier.
	 * @param hideDeliveryPrice 1 - hide delivery price 0 - unhide delivery price.
	 * @return {Response} Return in response.
	 */
    this.GetShipmentLabelRaw = function (shipmentUuid, hideDeliveryPrice) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "GetShipmentLabelRaw", shipmentUuid, hideDeliveryPrice);
        return result;
    }

	/**
	 *  Getting address label 100*100 in PDF format. 	
	 * @param shipmentUuid Shipment identifier.
	 * @return {Response} Return in response.
	 */
    this.GetShipmentStickerRaw = function (shipmentUuid) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "GetShipmentStickerRaw", shipmentUuid);
        return result;
    }

	/**
	 *  Getting all invoices and forms postpay for shipment group in PDF format. 	
	 * @param shipmentGroupUuid Shipment group identifier.
	 * @return {Response} Return in response.
	 */
    this.GetShipmentGroupLabelRaw = function (shipmentGroupUuid) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "GetShipmentGroupLabelRaw", shipmentGroupUuid);
        return result;
    }

	/**
	 *  Getting labels for shipment group in PDF format. 	
	 * @param shipmentGroupUuid Shipment group identifier.
	 * @return {Response} Return in response.
	 */
    this.GetShipmentGroupStickerRaw = function (shipmentGroupUuid) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "GetShipmentGroupStickerRaw", shipmentGroupUuid);
        return result;
    }

	/**
	 *  Getting form 103a for shipment group in PDF format. 	
	 * @param shipmentGroupUuid Shipment group identifier.
	 * @return {Response} Return in response.
	 */
    this.GetShipmentGroupForm103aRaw = function (shipmentGroupUuid) {
        var result = _bNesisApi.Call("UkrPoshta", this.bNesisToken, "GetShipmentGroupForm103aRaw", shipmentGroupUuid);
        return result;
    }
}
/**
 * AddressOut used when need get information about address. 
 * @typedef {Object} UkrPoshtaAddressOut
 */
 UkrPoshtaAddressOut = function () { 
	/**
	 * A unique address identifier is assigned automatically when you create it.
	 * @type {Int32}
	 */
	this.id = 0;

	/**
	 * Post index.
	 * @type {string}
	 */
	this.postcode = "";

	/**
	 * The name of region.
	 * @type {string}
	 */
	this.region = "";

	/**
	 * The name of district.
	 * @type {string}
	 */
	this.district = "";

	/**
	 * The name of settlement.
	 * @type {string}
	 */
	this.city = "";

	/**
	 * The name of street.
	 * @type {string}
	 */
	this.street = "";

	/**
	 * The number of house.
	 * @type {string}
	 */
	this.houseNumber = "";

	/**
	 * The number of aprtment.
	 * @type {string}
	 */
	this.apartmentNumber = "";

	/**
	 * Description or comments.
	 * @type {string}
	 */
	this.description = "";

	/**
	 * An intimation of the true/false. Used for calculation of billing is assigned automatically to based on index.
	 * @type {Boolean}
	 */
	this.countryside = false;

	/**
	 * Part of the collected addresses, separated by commas.
	 * @type {string}
	 */
	this.detailedInfo = "";

	/**
	 * The country is on the default UA.
	 * @type {string}
	 */
	this.country = "";

}

/**
 * AddressIn used for add or edit address. 
 * @typedef {Object} UkrPoshtaAddressIn
 */
 UkrPoshtaAddressIn = function () { 
	/**
	 * Post index. (Only numbers 5 characters)
	 * @type {string}
	 */
	this.postcode = "";

	/**
	 * The name region. (Max characters is 45)
	 * @type {string}
	 */
	this.region = "";

	/**
	 * The name district. (Max characters is 45)
	 * @type {string}
	 */
	this.district = "";

	/**
	 * The name settlement. (Max characters is 45)
	 * @type {string}
	 */
	this.city = "";

	/**
	 * The name street. (Max characters is 255)
	 * @type {string}
	 */
	this.street = "";

	/**
	 * The number house. (Max characters is 15)
	 * @type {string}
	 */
	this.houseNumber = "";

	/**
	 * The number aprtment. (Max characters is 15)
	 * @type {string}
	 */
	this.apartmentNumber = "";

	/**
	 * Description or comments. (Max characters is 255)
	 * @type {string}
	 */
	this.description = "";

	/**
	 * An intimation of the true/false. Used for calculation of billing is assigned automatically to based on index.
	 * @type {Boolean}
	 */
	this.countryside = false;

	/**
	 * Part of the collected addresses, separated by commas.
	 * @type {string}
	 */
	this.detailedInfo = "";

	/**
	 * The country is on the default UA.
	 * @type {string}
	 */
	this.country = "";

}

/**
 * Customer address 
 * @typedef {Object} UkrPoshtaCustomerAddress
 */
 UkrPoshtaCustomerAddress = function () { 
	/**
	 * Identificator.
	 * @type {string}
	 */
	this.uuid = "";

	/**
	 * Address identificator.
	 * @type {Int32}
	 */
	this.addressId = 0;

	/**
	 * Type phone number of customer (PHYSICAL, LEGAL).
	 * @type {string}
	 */
	this.type = "";

	/**
	 * It is address main or not
	 * @type {Boolean}
	 */
	this.main = false;

}

/**
 * Customer phone. 
 * @typedef {Object} UkrPoshtaCustomerPhone
 */
 UkrPoshtaCustomerPhone = function () { 
	/**
	 * Identificator.
	 * @type {string}
	 */
	this.uuid = "";

	/**
	 * Phone number.
	 * @type {string}
	 */
	this.phoneNumber = "";

	/**
	 * Type phone number of customer (WORK, PERSONAL).
	 * @type {string}
	 */
	this.type = "";

	/**
	 * It is phone number main or not
	 * @type {Boolean}
	 */
	this.main = false;

}

/**
 * Customer E-mail 
 * @typedef {Object} UkrPoshtaCustomerEmail
 */
 UkrPoshtaCustomerEmail = function () { 
	/**
	 * Identificator.
	 * @type {string}
	 */
	this.uuid = "";

	/**
	 * E-mail
	 * @type {string}
	 */
	this.email = "";

	/**
	 * It is e-mail main or not
	 * @type {Boolean}
	 */
	this.main = false;

}

/**
 * CustomerOut used when get information about customer. 
 * @typedef {Object} UkrPoshtaCustomerOut
 */
 UkrPoshtaCustomerOut = function () { 
	/**
	 * Identificator.
	 * @type {string}
	 */
	this.uuid = "";

	/**
	 * Name of customer, formated from parameters: firstName, middleName, lastName.
	 * @type {string}
	 */
	this.name = "";

	/**
	 * First name of customer.
	 * @type {string}
	 */
	this.firstName = "";

	/**
	 * Middle name of customer.
	 * @type {string}
	 */
	this.middleName = "";

	/**
	 * Last name of customer.
	 * @type {string}
	 */
	this.lastName = "";

	/**
	 * Name of customer, formated from parameters: firstNameEn, lastNameEn.
	 * @type {string}
	 */
	this.nameEn = "";

	/**
	 * First name an english of customer.
	 * @type {string}
	 */
	this.firstNameEn = "";

	/**
	 * Last name an english of customer.
	 * @type {string}
	 */
	this.lastNameEn = "";

	/**
	 * Unique customer ID provided by "Ukrposhta".
	 * @type {string}
	 */
	this.postId = "";

	/**
	 * External Customer ID in counterparty base.
	 * @type {string}
	 */
	this.externalId = "";

	/**
	 * Unique reqistration number.
	 * @type {string}
	 */
	this.uniqueRegistrationNumber = "";

	/**
	 * Counterparty identificator.
	 * @type {string}
	 */
	this.counterpartyUuid = "";

	/**
	 * Address ID, indicates the Id of the pre-created address.
	 * @type {Int32}
	 */
	this.addressId = 0;

	/**
	 * If the customer has specified multiple addresses, it will be used only the one with 'main' setted true.
	 * @type {UkrPoshtaCustomerAddress[]}
	 */
	this.addresses = new Array();

	/**
	 * Phone number of customer.
	 * @type {string}
	 */
	this.phoneNumber = "";

	/**
	 * If the customer has specified multiple phones, it will be used only the one with 'main' setted true.
	 * @type {UkrPoshtaCustomerPhone[]}
	 */
	this.phones = new Array();

	/**
	 * E-mail customer.
	 * @type {string}
	 */
	this.email = "";

	/**
	 * If the customer has specified multiple emails, it will be used only the one with 'main' setted true.
	 * @type {UkrPoshtaCustomerEmail[]}
	 */
	this.emails = new Array();

	/**
	 * A variable that indicates whether the customer is a entity or an individual.
	 * @type {Boolean}
	 */
	this.individual = false;

	/**
	 * EDRPOU entity.
	 * @type {string}
	 */
	this.edrpou = "";

	/**
	 * Bank Code.
	 * @type {string}
	 */
	this.bankCode = "";

	/**
	 * Recipient account.
	 * @type {string}
	 */
	this.bankAccount = "";

	/**
	 * Individual tax number for entities.
	 * @type {string}
	 */
	this.tin = "";

	/**
	 * Contact name.
	 * @type {string}
	 */
	this.contactPersonName = "";

	/**
	 * Resident of Ukraine. If resident is true, customer is a resident of Ukraine.
	 * @type {Boolean}
	 */
	this.resident = false;

}

/**
 * CustomerIn used when add or edit customer.
 *     If the customer is an individual, the value of the individual should be true. In this case, you must specify the first name, last name and middle name (in parameters: firstName, lastName and middleName) of the customer. The 'name' parameter is generated automatically. If the customer is a entity, the value of the individual must be false. In this case, the API accepts only the 'name' parameter. 
 * @typedef {Object} UkrPoshtaCustomerIn
 */
 UkrPoshtaCustomerIn = function () { 
	/**
	 * Name of the customer. (Maximum number of characters 250, is mandatory for a entity, for an individual is formed from the parameters: firstName, middleName, lastName)
	 * @type {string}
	 */
	this.name = "";

	/**
	 * First name of the individual. (Maximum number of characters is 250, the minimum 2)
	 * @type {string}
	 */
	this.firstName = "";

	/**
	 * Middle name of an individual. (the maximum number of characters is 250, the minimum is 2)
	 * @type {string}
	 */
	this.middleName = "";

	/**
	 * Last name of an individual. (the maximum number of characters is 250, the minimum is 2)
	 * @type {string}
	 */
	this.lastName = "";

	/**
	 * External Customer ID in the counterparty's base.
	 * @type {string}
	 */
	this.externalId = "";

	/**
	 * Unique registration number.
	 * @type {string}
	 */
	this.uniqueRegistrationNumber = "";

	/**
	 * Address ID, indicates the Id of the pre-created address.
	 * @type {Int32}
	 */
	this.addressId = 0;

	/**
	 * Customer phone number (only numbers, maximum 25 characters)
	 * @type {string}
	 */
	this.phoneNumber = "";

	/**
	 * E-mail customer
	 * @type {string}
	 */
	this.email = "";

	/**
	 * A variable that indicates whether the customer is entity or an individual. The entity of the individual must be-false, in physical-true. (Can not be changed after creation)
	 * @type {Boolean}
	 */
	this.individual = false;

	/**
	 * EDRPOU entity (only numbers 5-8 characters). Only the valid EDRPOU can be saved. 
	 *  Before the creation is validated according to the algorithm:Site with algorithm validation 'http://1cinfo.com.ua/Articles/Proverka_koda_po_EDRPOU.aspx'.
	 * @type {string}
	 */
	this.edrpou = "";

	/**
	 * Bank Code.(Only numbers, maximum characters 6)
	 * @type {string}
	 */
	this.bankCode = "";

	/**
	 * Recipient account.(Only numbers, maximum characters 14)
	 * @type {string}
	 */
	this.bankAccount = "";

	/**
	 * Individual tax number for entities. (Only numbers, maximum characters 32)
	 * @type {string}
	 */
	this.tin = "";

	/**
	 * Contact name.
	 * @type {string}
	 */
	this.contactPersonName = "";

	/**
	 * Resident of Ukraine. If resident is true, customer is a resident of Ukraine. By default, when creating a resident, it is true.
	 * @type {Boolean}
	 */
	this.resident = true;

}

/**
 * Parameters of the parcel. 
 *     When creating a parcel, you need to specify the main fields: weight - the maximum weight of sending 30000 grams. Weight of departure must be greater than zero.length - largest side of the departure, indicates the length in inches, length of departure must be greater than zero.declaredPrice - The stated price is sending filled in UAH 
 * @typedef {Object} UkrPoshtaParcel
 */
 UkrPoshtaParcel = function () { 
	/**
	 * Shipping weight.
	 * @type {Int32}
	 */
	this.weight = 0;

	/**
	 * Shipping length.
	 * @type {Int32}
	 */
	this.length = 0;

	/**
	 * Shipping width.
	 * @type {Int32}
	 */
	this.width = 0;

	/**
	 * Shipping height.
	 * @type {Int32}
	 */
	this.height = 0;

	/**
	 * Shipping declared price.
	 * @type {Int64}
	 */
	this.declaredPrice = 0;

}

/**
 * Information about discount per customer. 
 * @typedef {Object} UkrPoshtaDiscountPerCustomer
 */
 UkrPoshtaDiscountPerCustomer = function () { 
	/**
	 * Identifier.
	 * @type {string}
	 */
	this.uuid = "";

	/**
	 * Customer identifier.
	 * @type {string}
	 */
	this.clientUuid = "";

	/**
	 * Discount identifier.
	 * @type {string}
	 */
	this.discountUuid = "";

	/**
	 * Value of discount.
	 * @type {Single}
	 */
	this.value = new Single();

	/**
	 * Discount available from date.
	 * @type {string}
	 */
	this.fromDate = "";

	/**
	 * Discount available to date.
	 * @type {string}
	 */
	this.toDate = "";

	/**
	 * Shipment type.
	 * @type {string}
	 */
	this.shipmentType = "";

}

/**
 * ShipmentOut used when get information about shipment. 
 * @typedef {Object} UkrPoshtaShipmentOut
 */
 UkrPoshtaShipmentOut = function () { 
	/**
	 * Identificator.
	 * @type {string}
	 */
	this.uuid = "";

	/**
	 * Information about sender.
	 * @type {UkrPoshtaCustomerOut}
	 */
	this.sender = new UkrPoshtaCustomerOut();

	/**
	 * Information about recipient.
	 * @type {UkrPoshtaCustomerOut}
	 */
	this.recipient = new UkrPoshtaCustomerOut();

	/**
	 * Recipient phone.
	 * @type {string}
	 */
	this.recipientPhone = "";

	/**
	 * Recipient email.
	 * @type {string}
	 */
	this.recipientEmail = "";

	/**
	 * Recipient address identifier.
	 * @type {string}
	 */
	this.recipientAddressId = "";

	/**
	 * Return address identifier.
	 * @type {string}
	 */
	this.returnAddressId = "";

	/**
	 * Shipment group identifier.
	 * @type {string}
	 */
	this.shipmentGroupUuid = "";

	/**
	 * External identifier.
	 * @type {string}
	 */
	this.externalId = "";

	/**
	 * Delivery type.
	 *  RETURN - return to the sender.RETURN_AFTER_F REE_STORAGE - return after the expiration of free storage.PROCESS_AS_REF USAL - destroy the parcel.By default RETURN.
	 * @type {string}
	 */
	this.deliveryType = "RETURN";

	/**
	 * Package type.
	 * @type {string}
	 */
	this.packageType = "";

	/**
	 * Actions with shipment in case the recipient did not take it.
	 * @type {string}
	 */
	this.onFailReceiveType = "";

	/**
	 * Parcel barcode.
	 * @type {string}
	 */
	this.barcode = "";

	/**
	 * Parcels.
	 * @type {UkrPoshtaParcel[]}
	 */
	this.parcels = new Array();

	/**
	 * Delivery price.
	 * @type {Int64}
	 */
	this.deliveryPrice = 0;

	/**
	 * Post pay.
	 * @type {Int64}
	 */
	this.postPay = 0;

	/**
	 * Currency code.
	 * @type {string}
	 */
	this.currencyCode = "";

	/**
	 * Post pay currency code.
	 * @type {string}
	 */
	this.postPayCurrencyCode = "";

	/**
	 * Currency exchange rate.
	 * @type {string}
	 */
	this.currencyExchangeRate = "";

	/**
	 * Discount per customer.
	 * @type {UkrPoshtaDiscountPerCustomer}
	 */
	this.discountPerClient = new UkrPoshtaDiscountPerCustomer();

	/**
	 * Date of making the latest changes in the shipment. Date and time in the format "2017-06- 12T12: 31: 56"
	 * @type {string}
	 */
	this.lastModified = "";

	/**
	 * Description or comments.
	 * @type {string}
	 */
	this.description = "";

	/**
	 * Tracking departure.
	 * @type {Object[]}
	 */
	this.statusTrackings = new Array();

	/**
	 * Payment for the shipment upon receipt. 
	 *  true - payment by the recipient.false - payment sender.By default, false.
	 * @type {Boolean}
	 */
	this.paidByRecipient = false;

	/**
	 * Payment by cashless payment.
	 *  true - non-cash.false - cash.By default, true.
	 * @type {Boolean}
	 */
	this.nonCashPayment = true;

	/**
	 * The note is a bulky parcel.
	 *  true - cumbersomefalse - not cumbersomeBy default false
	 * @type {Boolean}
	 */
	this.bulky = false;

	/**
	 * The note is a fragile parcel.
	 *  true - brittle.false - not fragile.By default false.
	 * @type {Boolean}
	 */
	this.fragile = false;

	/**
	 * Bee pointing.
	 *  By default false.
	 * @type {Boolean}
	 */
	this.bees = false;

	/**
	 * Sending from a receipt.
	 *  If true when receiving a shipment (Service for which an additional price is charged. Details on the site ukrposhta.ua), the sender receives a letter stating that the shipment has been received.By default false.
	 * @type {Boolean}
	 */
	this.recommended = false;

	/**
	 * Sms message about the arrival of the parcel.
	 *  If the true recipient receives the message (Service for which an additional price is charged. Details on the site ukrposhta.ua).By default false.
	 * @type {Boolean}
	 */
	this.sms = false;

	/**
	 * International shipping
	 *  By default false.
	 * @type {Boolean}
	 */
	this.international = false;

	/**
	 * Shipping price.
	 * @type {string}
	 */
	this.postPayDeliveryPrice = "";

	/**
	 * The party who pays the postpay billing fee.
	 *  true - the amount is paid by the recipient.false - is paid by the sender.By default true.
	 * @type {Boolean}
	 */
	this.postPayPaidByRecipient = true;

	/**
	 * A description of the costing that describes how the cost of mail is generated.
	 * @type {string}
	 */
	this.calculationDescription = "";

	/**
	 * Return shipping documentation.
	 *  By default false.
	 * @type {Boolean}
	 */
	this.documentBack = false;

	/**
	 * Review at handed.
	 *  By default false.
	 * @type {Boolean}
	 */
	this.checkOnDelivery = false;

	/**
	 * Display information about the sender's bank account on the address bar.
	 *  By default false. Only if there is postpay.
	 * @type {Boolean}
	 */
	this.transferPostPayToBankAccount = false;

	/**
	 * The shipping charge has been paid.
	 * @type {Boolean}
	 */
	this.deliveryPricePaid = false;

	/**
	 * Postpay paid.
	 * @type {Boolean}
	 */
	this.postPayPaid = false;

	/**
	 * The shipping charge has been paid.
	 * @type {Boolean}
	 */
	this.postPayDeliveryPricePaid = false;

	/**
	 * Type shipment.
	 *  EXPRESS - Ukrposhta Express.STANDARD - Ukrposhta standard.For more detail see:http://ukrposhta.ua/ By default EXPRESS.
	 * @type {string}
	 */
	this.type = "EXPRESS";

	/**
	 * After the creation of the sending status changes to CREATED, after the registration of the shipment in the communications branch status changes to REGISTERED.
	 * @type {string}
	 */
	this.status = "";

}

/**
 * Customer Identificator. 
 * @typedef {Object} UkrPoshtaCustomerUuid
 */
 UkrPoshtaCustomerUuid = function () { 
	/**
	 * Identificator.
	 * @type {string}
	 */
	this.uuid = "";

}

/**
 * ShipmentIn used when add or edit information shipment. 
 * @typedef {Object} UkrPoshtaShipmentIn
 */
 UkrPoshtaShipmentIn = function () { 
	/**
	 * Identificator sender customer.
	 * @type {UkrPoshtaCustomerUuid}
	 */
	this.sender = new UkrPoshtaCustomerUuid();

	/**
	 * Identificator recipient customer.
	 * @type {UkrPoshtaCustomerUuid}
	 */
	this.recipient = new UkrPoshtaCustomerUuid();

	/**
	 * Repient phone.
	 * @type {string}
	 */
	this.recipientPhone = "";

	/**
	 * Recipient email.
	 * @type {string}
	 */
	this.recipientEmail = "";

	/**
	 * Recipient address id.
	 * @type {string}
	 */
	this.recipientAddressId = "";

	/**
	 * Return address id, may be specified additionally, if not specified will used main address where 'main' is true.
	 * @type {string}
	 */
	this.returnAddressId = "";

	/**
	 * Identificator of shipment group, if sending is a group.
	 * @type {string}
	 */
	this.shipmentGroupUuid = "";

	/**
	 * External ID of departure at the base counterparty.
	 * @type {string}
	 */
	this.externalId = "";

	/**
	 * Delivery type(for international shippment).
	 *  Have mostly 4 types:W2D warehouse-door 
	 *  W2W warehouse-warehouse 
	 *  D2W door-warehouse
	 *  D2D door-door
	 * @type {string}
	 */
	this.deliveryType = "";

	/**
	 * Actions with shipment in case the recipient did not take it.
	 *  RETURN - return to the sender.RETURN_AFTER_F REE_STORAGE - return after the expiration of free storage.PROCESS_AS_REF USAL - destroy the parcel.By default RETURN.
	 * @type {string}
	 */
	this.onFailReceiveType = "RETURN";

	/**
	 * Parcels.
	 * @type {UkrPoshtaParcel[]}
	 */
	this.parcels = new Array();

	/**
	 * Postpay in UAH may not be higher than the stated price.
	 * @type {Int64}
	 */
	this.postPay = 0;

	/**
	 * Description or comments (max 255 characters).
	 * @type {string}
	 */
	this.description = "";

	/**
	 * Payment for the shipment upon receipt. 
	 *  true - payment by the recipient.false - payment sender.By default, false.
	 * @type {Boolean}
	 */
	this.paidByRecipient = false;

	/**
	 * Payment by cashless payment.
	 *  true - non-cash.false - cash.By default, true.
	 * @type {Boolean}
	 */
	this.nonCashPayment = true;

	/**
	 * The note is a bulky parcel.
	 *  true - cumbersomefalse - not cumbersomeBy default false
	 * @type {Boolean}
	 */
	this.bulky = false;

	/**
	 * The note is a fragile parcel.
	 *  true - brittle.false - not fragile.By default false.
	 * @type {Boolean}
	 */
	this.fragile = false;

	/**
	 * Bee pointing.
	 *  By default false.
	 * @type {Boolean}
	 */
	this.bees = false;

	/**
	 * Sending from a receipt.
	 *  If true when receiving a shipment (Service for which an additional price is charged. Details on the site ukrposhta.ua), the sender receives a letter stating that the shipment has been received.By default false.
	 * @type {Boolean}
	 */
	this.recommended = false;

	/**
	 * Sms message about the arrival of the parcel.
	 *  If the true recipient receives the message (Service for which an additional price is charged. Details on the site ukrposhta.ua).By default false.
	 * @type {Boolean}
	 */
	this.sms = false;

	/**
	 * Return shipping documentation
	 *  By default false.
	 * @type {Boolean}
	 */
	this.documentBack = false;

	/**
	 * Review at handed.
	 *  By default false.
	 * @type {Boolean}
	 */
	this.checkOnDelivery = false;

	/**
	 * Display information about the sender's bank account on the address bar.
	 *  By default false. Only if there is postpay.
	 * @type {Boolean}
	 */
	this.transferPostPayToBankAccount = false;

	/**
	 * Type shipment.
	 *  EXPRESS - Ukrposhta Express.STANDARD - Ukrposhta standard.For more detail see:http://ukrposhta.ua/ By default EXPRESS.
	 * @type {string}
	 */
	this.type = "EXPRESS";

	/**
	 * The party who pays the postpay billing fee.
	 *  true - the amount is paid by the recipient.false - is paid by the sender.By default true.
	 * @type {Boolean}
	 */
	this.postPayPaidByRecipient = true;

}

/**
 * ShipmentGroupOut used when get information about shipment group. 
 * @typedef {Object} UkrPoshtaShipmentGroupOut
 */
 UkrPoshtaShipmentGroupOut = function () { 
	/**
	 * Identificator shipment group.
	 * @type {string}
	 */
	this.uuid = "";

	/**
	 * Name of shipment group.
	 * @type {string}
	 */
	this.name = "";

	/**
	 * Customer identificator.
	 * @type {string}
	 */
	this.clientUuid = "";

	/**
	 * Consignment(for international shipments).
	 * @type {string}
	 */
	this.consignment = "";

	/**
	 * Registered group.
	 * @type {Boolean}
	 */
	this.approved = false;

	/**
	 * Type group parcel.
	 * @type {string}
	 */
	this.type = "";

}

/**
 * ShipmentGroupIn used for add or edit information about shipmentGroup. 
 * @typedef {Object} UkrPoshtaShipmentGroupIn
 */
 UkrPoshtaShipmentGroupIn = function () { 
	/**
	 * Name of shipment group.
	 * @type {string}
	 */
	this.name = "";

	/**
	 * Identificator client.
	 * @type {string}
	 */
	this.clientUuid = "";

	/**
	 * Type group parcel.
	 *  EXPRESS - Ukrposhta Express.STANDARD - Ukrposhta standard.For more detail see:http://ukrposhta.ua/ By default EXPRESS.
	 * @type {string}
	 */
	this.type = "EXPRESS";

}

