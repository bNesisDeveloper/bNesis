package bNesis.Sdk.Delivery.UkrPoshta;

import java.io.*;
import java.util.List;
import java.util.Date;
import java.util.Map.Entry;
import bNesis.Api.*;

import bNesis.Sdk.Common.*;
import bNesis.Sdk.Delivery.UkrPoshta.*;
import java.net.URI.*;

	public class UkrPoshta  
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

		public UkrPoshta(bNesisApi bnesisApi)
		{
			this._bNesisApi = bnesisApi;
		}

		/**
		 * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		 * @return {String} bNesisToken value
		 */
		public String Auth(String bNesisDevId,String clientId,String clientSecret,String redirectUrl) throws Exception
		{
			bNesisToken = _bNesisApi.Auth("UkrPoshta", "",bNesisDevId,redirectUrl,clientId,clientSecret,null,"","",false,"");
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
			Boolean result = _bNesisApi.LogoffService("UkrPoshta", bNesisToken);
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
			return _bNesisApi.<ErrorInfo>Call(ErrorInfo.class, "UkrPoshta", bNesisToken, "GetLastError");
		}

		/**
		 *  Getting arrays of error info 	
		 * @return {ErrorInfo[]}  
		 * @throws Exception
		 */
		public ErrorInfo[] GetErrorLog() throws Exception
		{
			return _bNesisApi.<ErrorInfo[]>Call(ErrorInfo[].class, "UkrPoshta", bNesisToken, "GetErrorLog");
		}

		/**
		 *  Checks the token in the service. 	
		 * @return {Boolean} if token valid return true, if token not valid return false 
		 * @throws Exception
		 */
		public Boolean ValidateToken() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "UkrPoshta", bNesisToken, "ValidateToken");
		}

		/**
		 *  Disables the access token used to authenticate the call. 	
		 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false 
		 * @throws Exception
		 */
		public Boolean Logoff() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "UkrPoshta", bNesisToken, "Logoff");
		}

		/**
		 *  Getting address by identifier. 	
		 * @param id Address identifier.
	 * @return {UkrPoshtaAddressOut} Return in AddressOut. 
		 * @throws Exception
		 */
		public UkrPoshtaAddressOut GetAddress(Integer id) throws Exception
		{
			return _bNesisApi.<UkrPoshtaAddressOut>Call(UkrPoshtaAddressOut.class, "UkrPoshta", bNesisToken, "GetAddress", id);
		}

		/**
		 *  Creating new address. 	
		 * @param address Body of address(required:postcode).
	 * @return {UkrPoshtaAddressOut} Return in AddressOut. 
		 * @throws Exception
		 */
		public UkrPoshtaAddressOut AddAddress(UkrPoshtaAddressIn address) throws Exception
		{
			return _bNesisApi.<UkrPoshtaAddressOut>Call(UkrPoshtaAddressOut.class, "UkrPoshta", bNesisToken, "AddAddress", address);
		}

		/**
		 *  Creating new clients. 	
		 * @param client Requirment CustomerIn.
	 *     If the client is an individual, then the value of the individual should be true.In this case, you must specify the first name, last name and patronymic of the client (firstName, lastName and middleName parameters respectively).The name parameter is generated automatically. If the client is a legal entity, the value of the individual must be false. In this case, the API accepts only the parameter name.
	 * @return {UkrPoshtaCustomerOut} Return in CustomerOut. 
		 * @throws Exception
		 */
		public UkrPoshtaCustomerOut AddClient(UkrPoshtaCustomerIn client) throws Exception
		{
			return _bNesisApi.<UkrPoshtaCustomerOut>Call(UkrPoshtaCustomerOut.class, "UkrPoshta", bNesisToken, "AddClient", client);
		}

		/**
		 *  Creating new clients. 	
		 * @param clients Requirment array of CustomerIn.
	 *     If the client is an individual, then the value of the individual should be true.In this case, you must specify the first name, last name and patronymic of the client (firstName, lastName and middleName parameters respectively).The name parameter is generated automatically. If the client is a legal entity, the value of the individual must be false. In this case, the API accepts only the parameter name.
	 * @return {UkrPoshtaCustomerOut[]} Return in CustomerOut. 
		 * @throws Exception
		 */
		public UkrPoshtaCustomerOut[] AddClients(UkrPoshtaCustomerIn[] clients) throws Exception
		{
			return _bNesisApi.<UkrPoshtaCustomerOut[]>Call(UkrPoshtaCustomerOut[].class, "UkrPoshta", bNesisToken, "AddClients", clients);
		}

		/**
		 *  Edit client. 	
		 * @param clientUuid Client uuid
	 * @param client Body of CustomerIn.
	 * @return {UkrPoshtaCustomerOut} Return in CustomerOut. 
		 * @throws Exception
		 */
		public UkrPoshtaCustomerOut EditClient(String clientUuid, UkrPoshtaCustomerIn client) throws Exception
		{
			return _bNesisApi.<UkrPoshtaCustomerOut>Call(UkrPoshtaCustomerOut.class, "UkrPoshta", bNesisToken, "EditClient", clientUuid, client);
		}

		/**
		 *  Getting client. 	
		 * @param externalId External identifier
	 * @return {UkrPoshtaCustomerOut[]} Return in CustomerOut. 
		 * @throws Exception
		 */
		public UkrPoshtaCustomerOut[] GetClients(String externalId) throws Exception
		{
			return _bNesisApi.<UkrPoshtaCustomerOut[]>Call(UkrPoshtaCustomerOut[].class, "UkrPoshta", bNesisToken, "GetClients", externalId);
		}

		/**
		 *  Getting telephones numbers of client. 	
		 * @param clientUuid Client uuid.
	 * @return {UkrPoshtaCustomerPhone[]} Return in CustomerPhone. 
		 * @throws Exception
		 */
		public UkrPoshtaCustomerPhone[] GetClientPhones(String clientUuid) throws Exception
		{
			return _bNesisApi.<UkrPoshtaCustomerPhone[]>Call(UkrPoshtaCustomerPhone[].class, "UkrPoshta", bNesisToken, "GetClientPhones", clientUuid);
		}

		/**
		 *  Delete telephone number from client. 	
		 * @param phoneNumberUuid Phone uuid
	 * @return {Boolean} Return in true if delete. 
		 * @throws Exception
		 */
		public Boolean DeleteClientPhone(String phoneNumberUuid) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "UkrPoshta", bNesisToken, "DeleteClientPhone", phoneNumberUuid);
		}

		/**
		 *  Getting addresses of client. 	
		 * @param clientUuid Client uuid.
	 * @return {UkrPoshtaCustomerAddress[]} Return in CustomerAddress. 
		 * @throws Exception
		 */
		public UkrPoshtaCustomerAddress[] GetClientAddresses(String clientUuid) throws Exception
		{
			return _bNesisApi.<UkrPoshtaCustomerAddress[]>Call(UkrPoshtaCustomerAddress[].class, "UkrPoshta", bNesisToken, "GetClientAddresses", clientUuid);
		}

		/**
		 *  Delete address from client. 	
		 * @param addressUuid Address uuid.
	 * @return {Boolean} Return in true if delete. 
		 * @throws Exception
		 */
		public Boolean DeleteClientAddress(String addressUuid) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "UkrPoshta", bNesisToken, "DeleteClientAddress", addressUuid);
		}

		/**
		 *  Getting emails of client. 	
		 * @param clientUuid Client uuid
	 * @return {UkrPoshtaCustomerEmail[]} Return in CustomerEmail. 
		 * @throws Exception
		 */
		public UkrPoshtaCustomerEmail[] GetClientEmails(String clientUuid) throws Exception
		{
			return _bNesisApi.<UkrPoshtaCustomerEmail[]>Call(UkrPoshtaCustomerEmail[].class, "UkrPoshta", bNesisToken, "GetClientEmails", clientUuid);
		}

		/**
		 *  Delete email from client. 	
		 * @param emailUuid Email uuid.
	 * @return {Boolean} Return in true if delete. 
		 * @throws Exception
		 */
		public Boolean DeleteClientEmail(String emailUuid) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "UkrPoshta", bNesisToken, "DeleteClientEmail", emailUuid);
		}

		/**
		 *  Creating new shipment. 	
		 * @param shipment Body of ShipmentIn.
	 * The sender and recipient when creating a postal mail are specified as an embedded JSON:if uuid client is not empty or null, then the existing client will be used, otherwise - a new one will be created.When creating a shipment, the sender may specify additional recipient information that is used in printed forms.There can be only one "parcel" in the current release in the mail.Parameters of dispatch are filled out on the basis of parcel (weight, length, declaredPrice, etc.).The delivery amount is calculated when creating a postal item and is displayed in the response body as the "deliveryPrice" parameter.
	 * @return {UkrPoshtaShipmentOut} Return in ShipmentOut. 
		 * @throws Exception
		 */
		public UkrPoshtaShipmentOut AddShipment(UkrPoshtaShipmentIn shipment) throws Exception
		{
			return _bNesisApi.<UkrPoshtaShipmentOut>Call(UkrPoshtaShipmentOut.class, "UkrPoshta", bNesisToken, "AddShipment", shipment);
		}

		/**
		 *  Edit shipment group by uuid. 	
		 * @param shipmentGroupUuid Shipment group uuid
	 * @param shipment Body of shipment
	 * @return {UkrPoshtaShipmentOut} Return in ShipmentOut. 
		 * @throws Exception
		 */
		public UkrPoshtaShipmentOut EditShipment(String shipmentGroupUuid, UkrPoshtaShipmentIn shipment) throws Exception
		{
			return _bNesisApi.<UkrPoshtaShipmentOut>Call(UkrPoshtaShipmentOut.class, "UkrPoshta", bNesisToken, "EditShipment", shipmentGroupUuid, shipment);
		}

		/**
		 *  Getting shipment by uuid. 	
		 * @param shipmentUuid Shipment uuid.
	 * @return {UkrPoshtaShipmentOut} Return in ShipmentOut. 
		 * @throws Exception
		 */
		public UkrPoshtaShipmentOut GetShipment(String shipmentUuid) throws Exception
		{
			return _bNesisApi.<UkrPoshtaShipmentOut>Call(UkrPoshtaShipmentOut.class, "UkrPoshta", bNesisToken, "GetShipment", shipmentUuid);
		}

		/**
		 *  Delete shipment by uuid. 	
		 * @param shipmentUuid Shipment uuid.
	 * @return {Boolean} Return in true if delete. 
		 * @throws Exception
		 */
		public Boolean DeleteShipment(String shipmentUuid) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "UkrPoshta", bNesisToken, "DeleteShipment", shipmentUuid);
		}

		/**
		 *  Creating shipment group. 	
		 * @param shipmentGroup Body of shipment group.
	 * @return {UkrPoshtaShipmentGroupOut} Return in ShipmentGroupOut. 
		 * @throws Exception
		 */
		public UkrPoshtaShipmentGroupOut AddShipmentGroup(UkrPoshtaShipmentGroupIn shipmentGroup) throws Exception
		{
			return _bNesisApi.<UkrPoshtaShipmentGroupOut>Call(UkrPoshtaShipmentGroupOut.class, "UkrPoshta", bNesisToken, "AddShipmentGroup", shipmentGroup);
		}

		/**
		 *  Edit shipment group by uuid. 	
		 * @param shipmentGroupUuid Shipment group uuid.
	 * @param shipmentGroup Body of shipment group.
	 * @return {UkrPoshtaShipmentGroupOut} Return in ShipmentGroupOut. 
		 * @throws Exception
		 */
		public UkrPoshtaShipmentGroupOut EditShipmentGroup(String shipmentGroupUuid, UkrPoshtaShipmentGroupIn shipmentGroup) throws Exception
		{
			return _bNesisApi.<UkrPoshtaShipmentGroupOut>Call(UkrPoshtaShipmentGroupOut.class, "UkrPoshta", bNesisToken, "EditShipmentGroup", shipmentGroupUuid, shipmentGroup);
		}

		/**
		 *  Getting shimpent group by client uuid. 	
		 * @param clientUuid Client uuid.
	 * @return {UkrPoshtaShipmentGroupOut} Return in ShipmentGroupOut. 
		 * @throws Exception
		 */
		public UkrPoshtaShipmentGroupOut GetShipmentGroupByClient(String clientUuid) throws Exception
		{
			return _bNesisApi.<UkrPoshtaShipmentGroupOut>Call(UkrPoshtaShipmentGroupOut.class, "UkrPoshta", bNesisToken, "GetShipmentGroupByClient", clientUuid);
		}

		/**
		 *  Getting shipment by uuid. 	
		 * @param shipmentGroupUuid Shipment group uuid.
	 * @return {UkrPoshtaShipmentGroupOut} Return in ShipmentGroupOut. 
		 * @throws Exception
		 */
		public UkrPoshtaShipmentGroupOut GetShipmentGroup(String shipmentGroupUuid) throws Exception
		{
			return _bNesisApi.<UkrPoshtaShipmentGroupOut>Call(UkrPoshtaShipmentGroupOut.class, "UkrPoshta", bNesisToken, "GetShipmentGroup", shipmentGroupUuid);
		}

		/**
		 *  Delete shipmnent by uuid. 	
		 * @param shipmentUuid Shipment uuid.
	 * @return {Boolean} Return in true if delete. 
		 * @throws Exception
		 */
		public Boolean DeleteShipmentGroup(String shipmentUuid) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "UkrPoshta", bNesisToken, "DeleteShipmentGroup", shipmentUuid);
		}

		/**
		 *  Getting postal invoice size A5 in PDF format. 	
		 * @param shipmentUuid Shipment identifier
	 * @param hideDeliveryPrice 1 - hide delivery price 0 - unhide delivery price.
	 * @return {OutputStream} Return bytes of file 
		 * @throws Exception
		 */
		public OutputStream GetShipmentLabel(String shipmentUuid, Integer hideDeliveryPrice) throws Exception
		{
			return _bNesisApi.<OutputStream>Call(OutputStream.class, "UkrPoshta", bNesisToken, "GetShipmentLabel", shipmentUuid, hideDeliveryPrice);
		}

		/**
		 *  Getting address label 100*100 in PDF format. 	
		 * @param shipmentUuid Shipment identifier
	 * @return {OutputStream} Return bytes of file 
		 * @throws Exception
		 */
		public OutputStream GetShipmentSticker(String shipmentUuid) throws Exception
		{
			return _bNesisApi.<OutputStream>Call(OutputStream.class, "UkrPoshta", bNesisToken, "GetShipmentSticker", shipmentUuid);
		}

		/**
		 *  Getting all invoices and forms postpay for shipment group in PDF format. 	
		 * @param shipmentGroupUuid Shipment group identifier.
	 * @return {OutputStream} Return bytes of file 
		 * @throws Exception
		 */
		public OutputStream GetShipmentGroupLabel(String shipmentGroupUuid) throws Exception
		{
			return _bNesisApi.<OutputStream>Call(OutputStream.class, "UkrPoshta", bNesisToken, "GetShipmentGroupLabel", shipmentGroupUuid);
		}

		/**
		 *  Getting labels for shipment group in PDF format. 	
		 * @param shipmentGroupUuid Shipment group identifier.
	 * @return {OutputStream} Return bytes of file 
		 * @throws Exception
		 */
		public OutputStream GetShipmentGroupSticker(String shipmentGroupUuid) throws Exception
		{
			return _bNesisApi.<OutputStream>Call(OutputStream.class, "UkrPoshta", bNesisToken, "GetShipmentGroupSticker", shipmentGroupUuid);
		}

		/**
		 *  Getting form 103a for shipment group in PDF format. 	
		 * @param shipmentGroupUuid Shipment group identifier.
	 * @return {OutputStream} Return bytes of file 
		 * @throws Exception
		 */
		public OutputStream GetShipmentGroupForm103a(String shipmentGroupUuid) throws Exception
		{
			return _bNesisApi.<OutputStream>Call(OutputStream.class, "UkrPoshta", bNesisToken, "GetShipmentGroupForm103a", shipmentGroupUuid);
		}

		/**
		 *  Getting address by identifier. 	
		 * @param id Address identifier.
	 * @return {Response} Return in responce. 
		 * @throws Exception
		 */
		public Response GetAddressRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "UkrPoshta", bNesisToken, "GetAddressRaw", id);
		}

		/**
		 *  Creating new address. 	
		 * @param address Body of address(required:postcode).
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response AddAddressRaw(Object address) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "UkrPoshta", bNesisToken, "AddAddressRaw", address);
		}

		/**
		 *  Creating new client. 	
		 * @param clients Requirment body client.
	 * If the client is an individual, then the value of the individual should be true.In this case, you must specify the first name, last name and patronymic of the client (firstName, lastName and middleName parameters respectively).The name parameter is generated automatically. If the client is a legal entity, the value of the individual must be false. In this case, the API accepts only the parameter name.
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response AddClientsRaw(Object clients) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "UkrPoshta", bNesisToken, "AddClientsRaw", clients);
		}

		/**
		 *  Edit client. 	
		 * @param clientUuid Client uuid
	 * @param client Body client.
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response EditClientRaw(String clientUuid, Object client) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "UkrPoshta", bNesisToken, "EditClientRaw", clientUuid, client);
		}

		/**
		 *  Getting client. 	
		 * @param externalId External identifier
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response GetClientsRaw(String externalId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "UkrPoshta", bNesisToken, "GetClientsRaw", externalId);
		}

		/**
		 *  Getting telephones numbers of client. 	
		 * @param clientUuid Client uuid.
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response GetClientPhonesRaw(String clientUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "UkrPoshta", bNesisToken, "GetClientPhonesRaw", clientUuid);
		}

		/**
		 *  Delete telephone number from client. 	
		 * @param phoneNumberUuid Phone uuid
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response DeleteClientPhoneRaw(String phoneNumberUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "UkrPoshta", bNesisToken, "DeleteClientPhoneRaw", phoneNumberUuid);
		}

		/**
		 *  Getting addresses of client. 	
		 * @param clientUuid Client uuid.
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response GetClientAddressesRaw(String clientUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "UkrPoshta", bNesisToken, "GetClientAddressesRaw", clientUuid);
		}

		/**
		 *  Delete address from client. 	
		 * @param addressUuid Address uuid.
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response DeleteClientAddressRaw(String addressUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "UkrPoshta", bNesisToken, "DeleteClientAddressRaw", addressUuid);
		}

		/**
		 *  Getting emails of client. 	
		 * @param clientUuid Client uuid
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response GetClientEmailsRaw(String clientUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "UkrPoshta", bNesisToken, "GetClientEmailsRaw", clientUuid);
		}

		/**
		 *  Delete email from client. 	
		 * @param emailUuid Email uuid.
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response DeleteClientEmailRaw(String emailUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "UkrPoshta", bNesisToken, "DeleteClientEmailRaw", emailUuid);
		}

		/**
		 *  Creating new shipment. 	
		 * @param shipment Body of shipment.
	 * The sender and recipient when creating a postal mail are specified as an embedded JSON:if uuid client is not empty or null, then the existing client will be used, otherwise - a new one will be created.When creating a shipment, the sender may specify additional recipient information that is used in printed forms.There can be only one "parcel" in the current release in the mail.Parameters of dispatch are filled out on the basis of parcel (weight, length, declaredPrice, etc.).The delivery amount is calculated when creating a postal item and is displayed in the response body as the "deliveryPrice" parameter.
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response AddShipmentRaw(Object shipment) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "UkrPoshta", bNesisToken, "AddShipmentRaw", shipment);
		}

		/**
		 *  Eddut shipment group by uuid. 	
		 * @param shipmentGroupUuid Shipment group uuid
	 * @param shipment Body of shipment
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response EditShipmentRaw(String shipmentGroupUuid, Object shipment) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "UkrPoshta", bNesisToken, "EditShipmentRaw", shipmentGroupUuid, shipment);
		}

		/**
		 *  Getting shipment by uuid. 	
		 * @param shipmentUuid Shipment uuid.
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response GetShipmentRaw(String shipmentUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "UkrPoshta", bNesisToken, "GetShipmentRaw", shipmentUuid);
		}

		/**
		 *  Delete shipment by uuid. 	
		 * @param shipmentUuid Shipment uuid.
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response DeleteShipmentRaw(String shipmentUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "UkrPoshta", bNesisToken, "DeleteShipmentRaw", shipmentUuid);
		}

		/**
		 *  Creating shipment group. 	
		 * @param shipmentGroup Body of shipment group.
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response AddShipmentGroupRaw(Object shipmentGroup) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "UkrPoshta", bNesisToken, "AddShipmentGroupRaw", shipmentGroup);
		}

		/**
		 *  Edit shipment group by uuid. 	
		 * @param shipmentGroupUuid Shipment group uuid.
	 * @param shipmentGroup Body of shipment group.
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response EditShipmentGroupRaw(String shipmentGroupUuid, Object shipmentGroup) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "UkrPoshta", bNesisToken, "EditShipmentGroupRaw", shipmentGroupUuid, shipmentGroup);
		}

		/**
		 *  Getting shimpent group by client uuid. 	
		 * @param clientUuid Client uuid.
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response GetShipmentGroupByClientRaw(String clientUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "UkrPoshta", bNesisToken, "GetShipmentGroupByClientRaw", clientUuid);
		}

		/**
		 *  Getting shipment by uuid. 	
		 * @param shipmentGroupUuid Shipment group uuid.
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response GetShipmentGroupRaw(String shipmentGroupUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "UkrPoshta", bNesisToken, "GetShipmentGroupRaw", shipmentGroupUuid);
		}

		/**
		 *  Delete shipmnent by uuid. 	
		 * @param shipmentUuid Shipment uuid.
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response DeleteShipmentGroupRaw(String shipmentUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "UkrPoshta", bNesisToken, "DeleteShipmentGroupRaw", shipmentUuid);
		}

		/**
		 *  Getting postal invoice size A5 in PDF format. 	
		 * @param shipmentUuid Shipment identifier.
	 * @param hideDeliveryPrice 1 - hide delivery price 0 - unhide delivery price.
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response GetShipmentLabelRaw(String shipmentUuid, Integer hideDeliveryPrice) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "UkrPoshta", bNesisToken, "GetShipmentLabelRaw", shipmentUuid, hideDeliveryPrice);
		}

		/**
		 *  Getting address label 100*100 in PDF format. 	
		 * @param shipmentUuid Shipment identifier.
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response GetShipmentStickerRaw(String shipmentUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "UkrPoshta", bNesisToken, "GetShipmentStickerRaw", shipmentUuid);
		}

		/**
		 *  Getting all invoices and forms postpay for shipment group in PDF format. 	
		 * @param shipmentGroupUuid Shipment group identifier.
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response GetShipmentGroupLabelRaw(String shipmentGroupUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "UkrPoshta", bNesisToken, "GetShipmentGroupLabelRaw", shipmentGroupUuid);
		}

		/**
		 *  Getting labels for shipment group in PDF format. 	
		 * @param shipmentGroupUuid Shipment group identifier.
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response GetShipmentGroupStickerRaw(String shipmentGroupUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "UkrPoshta", bNesisToken, "GetShipmentGroupStickerRaw", shipmentGroupUuid);
		}

		/**
		 *  Getting form 103a for shipment group in PDF format. 	
		 * @param shipmentGroupUuid Shipment group identifier.
	 * @return {Response} Return in response. 
		 * @throws Exception
		 */
		public Response GetShipmentGroupForm103aRaw(String shipmentGroupUuid) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "UkrPoshta", bNesisToken, "GetShipmentGroupForm103aRaw", shipmentGroupUuid);
		}
}