using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;
using bNesis.Api.Desktop;
using bNesis.Sdk.Common;

namespace bNesis.Sdk.Delivery.UkrPoshta
{
	public class UkrPoshta  
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

		public UkrPoshta(DesktopbNesisApi bNesisApi)
		{
			this.bNesisApi = bNesisApi;
		}

		/// <summary>
		/// The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		/// </summary>
		/// <returns>bNesisToken value</returns>	
		public string Auth(string bNesisDevId,string redirectUrl,string clientId,string clientSecret,bool isSandbox)
		{
			bNesisToken = bNesisApi.Auth("UkrPoshta", string.Empty,bNesisDevId,redirectUrl,clientId,clientSecret,null,string.Empty,string.Empty,isSandbox,string.Empty);
			return bNesisToken;
		}

		/// <summary>
		/// The method stops the authorization session with the service and clears the value of bNesisToken.
		/// </summary>
		/// <returns>true - if service logoff is successful</returns>
		public bool LogoffService()
		{
			bool result = bNesisApi.LogoffService("UkrPoshta", bNesisToken);
			if (result) bNesisToken = string.Empty;
			return result;             
		}


		///<summary>
		/// Getting last exception for current provider 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo GetLastError()
		{
			return bNesisApi.Call<ErrorInfo>("UkrPoshta", bNesisToken, "GetLastError");
		}

		///<summary>
		/// Getting arrays of error info 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo[] GetErrorLog()
		{
			return bNesisApi.Call<ErrorInfo[]>("UkrPoshta", bNesisToken, "GetErrorLog");
		}

		///<summary>
		/// Checks the token in the service. 
		/// </summary>
		/// <returns>if token valid return true, if token not valid return false</returns>
		public Boolean ValidateToken()
		{
			return bNesisApi.Call<Boolean>("UkrPoshta", bNesisToken, "ValidateToken");
		}

		///<summary>
		/// Disables the access token used to authenticate the call. 
		/// </summary>
		/// <returns>if token revoked method returns true 
		/// if token doesn't support token revocation or token is revoked method returns false</returns>
		public Boolean Logoff()
		{
			return bNesisApi.Call<Boolean>("UkrPoshta", bNesisToken, "Logoff");
		}

		///<summary>
		/// Getting address by identifier. 
		/// </summary>
		/// <param name="id">Address identifier.</param>
		/// <returns>Return in AddressOut.</returns>
		public UkrPoshtaAddressOut GetAddress(Int32 id)
		{
			return bNesisApi.Call<UkrPoshtaAddressOut>("UkrPoshta", bNesisToken, "GetAddress", id);
		}

		///<summary>
		/// Creating new address. 
		/// </summary>
		/// <param name="address">Body of address(required:postcode).</param>
		/// <returns>Return in AddressOut.</returns>
		public UkrPoshtaAddressOut AddAddress(UkrPoshtaAddressIn address)
		{
			return bNesisApi.Call<UkrPoshtaAddressOut>("UkrPoshta", bNesisToken, "AddAddress", address);
		}

		///<summary>
		/// Creating new clients. 
		/// </summary>
		/// <param name="client">Requirment CustomerIn.
		///     If the client is an individual, then the value of the individual should be true.In this case, you must specify the first name, last name and patronymic of the client (firstName, lastName and middleName parameters respectively).The name parameter is generated automatically. If the client is a legal entity, the value of the individual must be false. In this case, the API accepts only the parameter name.</param>
		/// <returns>Return in CustomerOut.</returns>
		public UkrPoshtaCustomerOut AddClient(UkrPoshtaCustomerIn client)
		{
			return bNesisApi.Call<UkrPoshtaCustomerOut>("UkrPoshta", bNesisToken, "AddClient", client);
		}

		///<summary>
		/// Creating new clients. 
		/// </summary>
		/// <param name="clients">Requirment array of CustomerIn.
		///     If the client is an individual, then the value of the individual should be true.In this case, you must specify the first name, last name and patronymic of the client (firstName, lastName and middleName parameters respectively).The name parameter is generated automatically. If the client is a legal entity, the value of the individual must be false. In this case, the API accepts only the parameter name.</param>
		/// <returns>Return in CustomerOut.</returns>
		public UkrPoshtaCustomerOut[] AddClients(UkrPoshtaCustomerIn[] clients)
		{
			return bNesisApi.Call<UkrPoshtaCustomerOut[]>("UkrPoshta", bNesisToken, "AddClients", clients);
		}

		///<summary>
		/// Edit client. 
		/// </summary>
		/// <param name="clientUuid">Client uuid</param>
		/// <param name="client">Body of CustomerIn.</param>
		/// <returns>Return in CustomerOut.</returns>
		public UkrPoshtaCustomerOut EditClient(string clientUuid, UkrPoshtaCustomerIn client)
		{
			return bNesisApi.Call<UkrPoshtaCustomerOut>("UkrPoshta", bNesisToken, "EditClient", clientUuid, client);
		}

		///<summary>
		/// Getting client. 
		/// </summary>
		/// <param name="externalId">External identifier</param>
		/// <returns>Return in CustomerOut.</returns>
		public UkrPoshtaCustomerOut[] GetClients(string externalId)
		{
			return bNesisApi.Call<UkrPoshtaCustomerOut[]>("UkrPoshta", bNesisToken, "GetClients", externalId);
		}

		///<summary>
		/// Getting telephones numbers of client. 
		/// </summary>
		/// <param name="clientUuid">Client uuid.</param>
		/// <returns>Return in CustomerPhone.</returns>
		public UkrPoshtaCustomerPhone[] GetClientPhones(string clientUuid)
		{
			return bNesisApi.Call<UkrPoshtaCustomerPhone[]>("UkrPoshta", bNesisToken, "GetClientPhones", clientUuid);
		}

		///<summary>
		/// Delete telephone number from client. 
		/// </summary>
		/// <param name="phoneNumberUuid">Phone uuid</param>
		/// <returns>Return in true if delete.</returns>
		public Boolean DeleteClientPhone(string phoneNumberUuid)
		{
			return bNesisApi.Call<Boolean>("UkrPoshta", bNesisToken, "DeleteClientPhone", phoneNumberUuid);
		}

		///<summary>
		/// Getting addresses of client. 
		/// </summary>
		/// <param name="clientUuid">Client uuid.</param>
		/// <returns>Return in CustomerAddress.</returns>
		public UkrPoshtaCustomerAddress[] GetClientAddresses(string clientUuid)
		{
			return bNesisApi.Call<UkrPoshtaCustomerAddress[]>("UkrPoshta", bNesisToken, "GetClientAddresses", clientUuid);
		}

		///<summary>
		/// Delete address from client. 
		/// </summary>
		/// <param name="addressUuid">Address uuid.</param>
		/// <returns>Return in true if delete.</returns>
		public Boolean DeleteClientAddress(string addressUuid)
		{
			return bNesisApi.Call<Boolean>("UkrPoshta", bNesisToken, "DeleteClientAddress", addressUuid);
		}

		///<summary>
		/// Getting emails of client. 
		/// </summary>
		/// <param name="clientUuid">Client uuid</param>
		/// <returns>Return in CustomerEmail.</returns>
		public UkrPoshtaCustomerEmail[] GetClientEmails(string clientUuid)
		{
			return bNesisApi.Call<UkrPoshtaCustomerEmail[]>("UkrPoshta", bNesisToken, "GetClientEmails", clientUuid);
		}

		///<summary>
		/// Delete email from client. 
		/// </summary>
		/// <param name="emailUuid">Email uuid.</param>
		/// <returns>Return in true if delete.</returns>
		public Boolean DeleteClientEmail(string emailUuid)
		{
			return bNesisApi.Call<Boolean>("UkrPoshta", bNesisToken, "DeleteClientEmail", emailUuid);
		}

		///<summary>
		/// Creating new shipment. 
		/// </summary>
		/// <param name="shipment">Body of ShipmentIn.
		/// The sender and recipient when creating a postal mail are specified as an embedded JSON:if uuid client is not empty or null, then the existing client will be used, otherwise - a new one will be created.When creating a shipment, the sender may specify additional recipient information that is used in printed forms.There can be only one "parcel" in the current release in the mail.Parameters of dispatch are filled out on the basis of parcel (weight, length, declaredPrice, etc.).The delivery amount is calculated when creating a postal item and is displayed in the response body as the "deliveryPrice" parameter.</param>
		/// <returns>Return in ShipmentOut.</returns>
		public UkrPoshtaShipmentOut AddShipment(UkrPoshtaShipmentIn shipment)
		{
			return bNesisApi.Call<UkrPoshtaShipmentOut>("UkrPoshta", bNesisToken, "AddShipment", shipment);
		}

		///<summary>
		/// Edit shipment group by uuid. 
		/// </summary>
		/// <param name="shipmentGroupUuid">Shipment group uuid</param>
		/// <param name="shipment">Body of shipment</param>
		/// <returns>Return in ShipmentOut.</returns>
		public UkrPoshtaShipmentOut EditShipment(string shipmentGroupUuid, UkrPoshtaShipmentIn shipment)
		{
			return bNesisApi.Call<UkrPoshtaShipmentOut>("UkrPoshta", bNesisToken, "EditShipment", shipmentGroupUuid, shipment);
		}

		///<summary>
		/// Getting shipment by uuid. 
		/// </summary>
		/// <param name="shipmentUuid">Shipment uuid.</param>
		/// <returns>Return in ShipmentOut.</returns>
		public UkrPoshtaShipmentOut GetShipment(string shipmentUuid)
		{
			return bNesisApi.Call<UkrPoshtaShipmentOut>("UkrPoshta", bNesisToken, "GetShipment", shipmentUuid);
		}

		///<summary>
		/// Delete shipment by uuid. 
		/// </summary>
		/// <param name="shipmentUuid">Shipment uuid.</param>
		/// <returns>Return in true if delete.</returns>
		public Boolean DeleteShipment(string shipmentUuid)
		{
			return bNesisApi.Call<Boolean>("UkrPoshta", bNesisToken, "DeleteShipment", shipmentUuid);
		}

		///<summary>
		/// Creating shipment group. 
		/// </summary>
		/// <param name="shipmentGroup">Body of shipment group.</param>
		/// <returns>Return in ShipmentGroupOut.</returns>
		public UkrPoshtaShipmentGroupOut AddShipmentGroup(UkrPoshtaShipmentGroupIn shipmentGroup)
		{
			return bNesisApi.Call<UkrPoshtaShipmentGroupOut>("UkrPoshta", bNesisToken, "AddShipmentGroup", shipmentGroup);
		}

		///<summary>
		/// Edit shipment group by uuid. 
		/// </summary>
		/// <param name="shipmentGroupUuid">Shipment group uuid.</param>
		/// <param name="shipmentGroup">Body of shipment group.</param>
		/// <returns>Return in ShipmentGroupOut.</returns>
		public UkrPoshtaShipmentGroupOut EditShipmentGroup(string shipmentGroupUuid, UkrPoshtaShipmentGroupIn shipmentGroup)
		{
			return bNesisApi.Call<UkrPoshtaShipmentGroupOut>("UkrPoshta", bNesisToken, "EditShipmentGroup", shipmentGroupUuid, shipmentGroup);
		}

		///<summary>
		/// Getting shimpent group by client uuid. 
		/// </summary>
		/// <param name="clientUuid">Client uuid.</param>
		/// <returns>Return in ShipmentGroupOut.</returns>
		public UkrPoshtaShipmentGroupOut GetShipmentGroupByClient(string clientUuid)
		{
			return bNesisApi.Call<UkrPoshtaShipmentGroupOut>("UkrPoshta", bNesisToken, "GetShipmentGroupByClient", clientUuid);
		}

		///<summary>
		/// Getting shipment by uuid. 
		/// </summary>
		/// <param name="shipmentGroupUuid">Shipment group uuid.</param>
		/// <returns>Return in ShipmentGroupOut.</returns>
		public UkrPoshtaShipmentGroupOut GetShipmentGroup(string shipmentGroupUuid)
		{
			return bNesisApi.Call<UkrPoshtaShipmentGroupOut>("UkrPoshta", bNesisToken, "GetShipmentGroup", shipmentGroupUuid);
		}

		///<summary>
		/// Delete shipmnent by uuid. 
		/// </summary>
		/// <param name="shipmentUuid">Shipment uuid.</param>
		/// <returns>Return in true if delete.</returns>
		public Boolean DeleteShipmentGroup(string shipmentUuid)
		{
			return bNesisApi.Call<Boolean>("UkrPoshta", bNesisToken, "DeleteShipmentGroup", shipmentUuid);
		}

		///<summary>
		/// Getting postal invoice size A5 in PDF format. 
		/// </summary>
		/// <param name="shipmentUuid">Shipment identifier</param>
		/// <param name="hideDeliveryPrice">1 - hide delivery price 0 - unhide delivery price.</param>
		/// <returns>Return bytes of file</returns>
		public Stream GetShipmentLabel(string shipmentUuid, Int32 hideDeliveryPrice)
		{
			return bNesisApi.Call<Stream>("UkrPoshta", bNesisToken, "GetShipmentLabel", shipmentUuid, hideDeliveryPrice);
		}

		///<summary>
		/// Getting address label 100*100 in PDF format. 
		/// </summary>
		/// <param name="shipmentUuid">Shipment identifier</param>
		/// <returns>Return bytes of file</returns>
		public Stream GetShipmentSticker(string shipmentUuid)
		{
			return bNesisApi.Call<Stream>("UkrPoshta", bNesisToken, "GetShipmentSticker", shipmentUuid);
		}

		///<summary>
		/// Getting all invoices and forms postpay for shipment group in PDF format. 
		/// </summary>
		/// <param name="shipmentGroupUuid">Shipment group identifier.</param>
		/// <returns>Return bytes of file</returns>
		public Stream GetShipmentGroupLabel(string shipmentGroupUuid)
		{
			return bNesisApi.Call<Stream>("UkrPoshta", bNesisToken, "GetShipmentGroupLabel", shipmentGroupUuid);
		}

		///<summary>
		/// Getting labels for shipment group in PDF format. 
		/// </summary>
		/// <param name="shipmentGroupUuid">Shipment group identifier.</param>
		/// <returns>Return bytes of file</returns>
		public Stream GetShipmentGroupSticker(string shipmentGroupUuid)
		{
			return bNesisApi.Call<Stream>("UkrPoshta", bNesisToken, "GetShipmentGroupSticker", shipmentGroupUuid);
		}

		///<summary>
		/// Getting form 103a for shipment group in PDF format. 
		/// </summary>
		/// <param name="shipmentGroupUuid">Shipment group identifier.</param>
		/// <returns>Return bytes of file</returns>
		public Stream GetShipmentGroupForm103a(string shipmentGroupUuid)
		{
			return bNesisApi.Call<Stream>("UkrPoshta", bNesisToken, "GetShipmentGroupForm103a", shipmentGroupUuid);
		}

		///<summary>
		/// Getting address by identifier. 
		/// </summary>
		/// <param name="id">Address identifier.</param>
		/// <returns>Return in responce.</returns>
		public Response GetAddressRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("UkrPoshta", bNesisToken, "GetAddressRaw", id);
		}

		///<summary>
		/// Creating new address. 
		/// </summary>
		/// <param name="address">Body of address(required:postcode).</param>
		/// <returns>Return in response.</returns>
		public Response AddAddressRaw(Object address)
		{
			return bNesisApi.Call<Response>("UkrPoshta", bNesisToken, "AddAddressRaw", address);
		}

		///<summary>
		/// Creating new client. 
		/// </summary>
		/// <param name="clients">Requirment body client.
		/// If the client is an individual, then the value of the individual should be true.In this case, you must specify the first name, last name and patronymic of the client (firstName, lastName and middleName parameters respectively).The name parameter is generated automatically. If the client is a legal entity, the value of the individual must be false. In this case, the API accepts only the parameter name.</param>
		/// <returns>Return in response.</returns>
		public Response AddClientsRaw(Object clients)
		{
			return bNesisApi.Call<Response>("UkrPoshta", bNesisToken, "AddClientsRaw", clients);
		}

		///<summary>
		/// Edit client. 
		/// </summary>
		/// <param name="clientUuid">Client uuid</param>
		/// <param name="client">Body client.</param>
		/// <returns>Return in response.</returns>
		public Response EditClientRaw(string clientUuid, Object client)
		{
			return bNesisApi.Call<Response>("UkrPoshta", bNesisToken, "EditClientRaw", clientUuid, client);
		}

		///<summary>
		/// Getting client. 
		/// </summary>
		/// <param name="externalId">External identifier</param>
		/// <returns>Return in response.</returns>
		public Response GetClientsRaw(string externalId)
		{
			return bNesisApi.Call<Response>("UkrPoshta", bNesisToken, "GetClientsRaw", externalId);
		}

		///<summary>
		/// Getting telephones numbers of client. 
		/// </summary>
		/// <param name="clientUuid">Client uuid.</param>
		/// <returns>Return in response.</returns>
		public Response GetClientPhonesRaw(string clientUuid)
		{
			return bNesisApi.Call<Response>("UkrPoshta", bNesisToken, "GetClientPhonesRaw", clientUuid);
		}

		///<summary>
		/// Delete telephone number from client. 
		/// </summary>
		/// <param name="phoneNumberUuid">Phone uuid</param>
		/// <returns>Return in response.</returns>
		public Response DeleteClientPhoneRaw(string phoneNumberUuid)
		{
			return bNesisApi.Call<Response>("UkrPoshta", bNesisToken, "DeleteClientPhoneRaw", phoneNumberUuid);
		}

		///<summary>
		/// Getting addresses of client. 
		/// </summary>
		/// <param name="clientUuid">Client uuid.</param>
		/// <returns>Return in response.</returns>
		public Response GetClientAddressesRaw(string clientUuid)
		{
			return bNesisApi.Call<Response>("UkrPoshta", bNesisToken, "GetClientAddressesRaw", clientUuid);
		}

		///<summary>
		/// Delete address from client. 
		/// </summary>
		/// <param name="addressUuid">Address uuid.</param>
		/// <returns>Return in response.</returns>
		public Response DeleteClientAddressRaw(string addressUuid)
		{
			return bNesisApi.Call<Response>("UkrPoshta", bNesisToken, "DeleteClientAddressRaw", addressUuid);
		}

		///<summary>
		/// Getting emails of client. 
		/// </summary>
		/// <param name="clientUuid">Client uuid</param>
		/// <returns>Return in response.</returns>
		public Response GetClientEmailsRaw(string clientUuid)
		{
			return bNesisApi.Call<Response>("UkrPoshta", bNesisToken, "GetClientEmailsRaw", clientUuid);
		}

		///<summary>
		/// Delete email from client. 
		/// </summary>
		/// <param name="emailUuid">Email uuid.</param>
		/// <returns>Return in response.</returns>
		public Response DeleteClientEmailRaw(string emailUuid)
		{
			return bNesisApi.Call<Response>("UkrPoshta", bNesisToken, "DeleteClientEmailRaw", emailUuid);
		}

		///<summary>
		/// Creating new shipment. 
		/// </summary>
		/// <param name="shipment">Body of shipment.
		/// The sender and recipient when creating a postal mail are specified as an embedded JSON:if uuid client is not empty or null, then the existing client will be used, otherwise - a new one will be created.When creating a shipment, the sender may specify additional recipient information that is used in printed forms.There can be only one "parcel" in the current release in the mail.Parameters of dispatch are filled out on the basis of parcel (weight, length, declaredPrice, etc.).The delivery amount is calculated when creating a postal item and is displayed in the response body as the "deliveryPrice" parameter.</param>
		/// <returns>Return in response.</returns>
		public Response AddShipmentRaw(Object shipment)
		{
			return bNesisApi.Call<Response>("UkrPoshta", bNesisToken, "AddShipmentRaw", shipment);
		}

		///<summary>
		/// Eddut shipment group by uuid. 
		/// </summary>
		/// <param name="shipmentGroupUuid">Shipment group uuid</param>
		/// <param name="shipment">Body of shipment</param>
		/// <returns>Return in response.</returns>
		public Response EditShipmentRaw(string shipmentGroupUuid, Object shipment)
		{
			return bNesisApi.Call<Response>("UkrPoshta", bNesisToken, "EditShipmentRaw", shipmentGroupUuid, shipment);
		}

		///<summary>
		/// Getting shipment by uuid. 
		/// </summary>
		/// <param name="shipmentUuid">Shipment uuid.</param>
		/// <returns>Return in response.</returns>
		public Response GetShipmentRaw(string shipmentUuid)
		{
			return bNesisApi.Call<Response>("UkrPoshta", bNesisToken, "GetShipmentRaw", shipmentUuid);
		}

		///<summary>
		/// Delete shipment by uuid. 
		/// </summary>
		/// <param name="shipmentUuid">Shipment uuid.</param>
		/// <returns>Return in response.</returns>
		public Response DeleteShipmentRaw(string shipmentUuid)
		{
			return bNesisApi.Call<Response>("UkrPoshta", bNesisToken, "DeleteShipmentRaw", shipmentUuid);
		}

		///<summary>
		/// Creating shipment group. 
		/// </summary>
		/// <param name="shipmentGroup">Body of shipment group.</param>
		/// <returns>Return in response.</returns>
		public Response AddShipmentGroupRaw(Object shipmentGroup)
		{
			return bNesisApi.Call<Response>("UkrPoshta", bNesisToken, "AddShipmentGroupRaw", shipmentGroup);
		}

		///<summary>
		/// Edit shipment group by uuid. 
		/// </summary>
		/// <param name="shipmentGroupUuid">Shipment group uuid.</param>
		/// <param name="shipmentGroup">Body of shipment group.</param>
		/// <returns>Return in response.</returns>
		public Response EditShipmentGroupRaw(string shipmentGroupUuid, Object shipmentGroup)
		{
			return bNesisApi.Call<Response>("UkrPoshta", bNesisToken, "EditShipmentGroupRaw", shipmentGroupUuid, shipmentGroup);
		}

		///<summary>
		/// Getting shimpent group by client uuid. 
		/// </summary>
		/// <param name="clientUuid">Client uuid.</param>
		/// <returns>Return in response.</returns>
		public Response GetShipmentGroupByClientRaw(string clientUuid)
		{
			return bNesisApi.Call<Response>("UkrPoshta", bNesisToken, "GetShipmentGroupByClientRaw", clientUuid);
		}

		///<summary>
		/// Getting shipment by uuid. 
		/// </summary>
		/// <param name="shipmentGroupUuid">Shipment group uuid.</param>
		/// <returns>Return in response.</returns>
		public Response GetShipmentGroupRaw(string shipmentGroupUuid)
		{
			return bNesisApi.Call<Response>("UkrPoshta", bNesisToken, "GetShipmentGroupRaw", shipmentGroupUuid);
		}

		///<summary>
		/// Delete shipmnent by uuid. 
		/// </summary>
		/// <param name="shipmentUuid">Shipment uuid.</param>
		/// <returns>Return in response.</returns>
		public Response DeleteShipmentGroupRaw(string shipmentUuid)
		{
			return bNesisApi.Call<Response>("UkrPoshta", bNesisToken, "DeleteShipmentGroupRaw", shipmentUuid);
		}

		///<summary>
		/// Getting postal invoice size A5 in PDF format. 
		/// </summary>
		/// <param name="shipmentUuid">Shipment identifier.</param>
		/// <param name="hideDeliveryPrice">1 - hide delivery price 0 - unhide delivery price.</param>
		/// <returns>Return in response.</returns>
		public Response GetShipmentLabelRaw(string shipmentUuid, Int32 hideDeliveryPrice)
		{
			return bNesisApi.Call<Response>("UkrPoshta", bNesisToken, "GetShipmentLabelRaw", shipmentUuid, hideDeliveryPrice);
		}

		///<summary>
		/// Getting address label 100*100 in PDF format. 
		/// </summary>
		/// <param name="shipmentUuid">Shipment identifier.</param>
		/// <returns>Return in response.</returns>
		public Response GetShipmentStickerRaw(string shipmentUuid)
		{
			return bNesisApi.Call<Response>("UkrPoshta", bNesisToken, "GetShipmentStickerRaw", shipmentUuid);
		}

		///<summary>
		/// Getting all invoices and forms postpay for shipment group in PDF format. 
		/// </summary>
		/// <param name="shipmentGroupUuid">Shipment group identifier.</param>
		/// <returns>Return in response.</returns>
		public Response GetShipmentGroupLabelRaw(string shipmentGroupUuid)
		{
			return bNesisApi.Call<Response>("UkrPoshta", bNesisToken, "GetShipmentGroupLabelRaw", shipmentGroupUuid);
		}

		///<summary>
		/// Getting labels for shipment group in PDF format. 
		/// </summary>
		/// <param name="shipmentGroupUuid">Shipment group identifier.</param>
		/// <returns>Return in response.</returns>
		public Response GetShipmentGroupStickerRaw(string shipmentGroupUuid)
		{
			return bNesisApi.Call<Response>("UkrPoshta", bNesisToken, "GetShipmentGroupStickerRaw", shipmentGroupUuid);
		}

		///<summary>
		/// Getting form 103a for shipment group in PDF format. 
		/// </summary>
		/// <param name="shipmentGroupUuid">Shipment group identifier.</param>
		/// <returns>Return in response.</returns>
		public Response GetShipmentGroupForm103aRaw(string shipmentGroupUuid)
		{
			return bNesisApi.Call<Response>("UkrPoshta", bNesisToken, "GetShipmentGroupForm103aRaw", shipmentGroupUuid);
		}
}
	///<summary>
	/// AddressOut used when need get information about address. 
	/// </summary>
	public class UkrPoshtaAddressOut
	{
		/// <summary>
		/// A unique address identifier is assigned automatically when you create it. 
		/// </summary>
		public Int32 id { get; set; }

		/// <summary>
		/// Post index. 
		/// </summary>
		public string postcode { get; set; }

		/// <summary>
		/// The name of region. 
		/// </summary>
		public string region { get; set; }

		/// <summary>
		/// The name of district. 
		/// </summary>
		public string district { get; set; }

		/// <summary>
		/// The name of settlement. 
		/// </summary>
		public string city { get; set; }

		/// <summary>
		/// The name of street. 
		/// </summary>
		public string street { get; set; }

		/// <summary>
		/// The number of house. 
		/// </summary>
		public string houseNumber { get; set; }

		/// <summary>
		/// The number of aprtment. 
		/// </summary>
		public string apartmentNumber { get; set; }

		/// <summary>
		/// Description or comments. 
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// An intimation of the true/false. Used for calculation of billing is assigned automatically to based on index. 
		/// </summary>
		public Boolean countryside { get; set; }

		/// <summary>
		/// Part of the collected addresses, separated by commas. 
		/// </summary>
		public string detailedInfo { get; set; }

		/// <summary>
		/// The country is on the default UA. 
		/// </summary>
		public string country { get; set; }

	}

	///<summary>
	/// AddressIn used for add or edit address. 
	/// </summary>
	public class UkrPoshtaAddressIn
	{
		/// <summary>
		/// Post index. (Only numbers 5 characters) 
		/// </summary>
		public string postcode { get; set; }

		/// <summary>
		/// The name region. (Max characters is 45) 
		/// </summary>
		public string region { get; set; }

		/// <summary>
		/// The name district. (Max characters is 45) 
		/// </summary>
		public string district { get; set; }

		/// <summary>
		/// The name settlement. (Max characters is 45) 
		/// </summary>
		public string city { get; set; }

		/// <summary>
		/// The name street. (Max characters is 255) 
		/// </summary>
		public string street { get; set; }

		/// <summary>
		/// The number house. (Max characters is 15) 
		/// </summary>
		public string houseNumber { get; set; }

		/// <summary>
		/// The number aprtment. (Max characters is 15) 
		/// </summary>
		public string apartmentNumber { get; set; }

		/// <summary>
		/// Description or comments. (Max characters is 255) 
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// An intimation of the true/false. Used for calculation of billing is assigned automatically to based on index. 
		/// </summary>
		public Boolean countryside { get; set; }

		/// <summary>
		/// Part of the collected addresses, separated by commas. 
		/// </summary>
		public string detailedInfo { get; set; }

		/// <summary>
		/// The country is on the default UA. 
		/// </summary>
		public string country { get; set; }

	}

	///<summary>
	/// Customer address 
	/// </summary>
	public class UkrPoshtaCustomerAddress
	{
		/// <summary>
		/// Identificator. 
		/// </summary>
		public string uuid { get; set; }

		/// <summary>
		/// Address identificator. 
		/// </summary>
		public Int32 addressId { get; set; }

		/// <summary>
		/// Type phone number of customer (PHYSICAL, LEGAL). 
		/// </summary>
		public string type { get; set; }

		/// <summary>
		/// It is address main or not 
		/// </summary>
		public Boolean main { get; set; }

	}

	///<summary>
	/// Customer phone. 
	/// </summary>
	public class UkrPoshtaCustomerPhone
	{
		/// <summary>
		/// Identificator. 
		/// </summary>
		public string uuid { get; set; }

		/// <summary>
		/// Phone number. 
		/// </summary>
		public string phoneNumber { get; set; }

		/// <summary>
		/// Type phone number of customer (WORK, PERSONAL). 
		/// </summary>
		public string type { get; set; }

		/// <summary>
		/// It is phone number main or not 
		/// </summary>
		public Boolean main { get; set; }

	}

	///<summary>
	/// Customer E-mail 
	/// </summary>
	public class UkrPoshtaCustomerEmail
	{
		/// <summary>
		/// Identificator. 
		/// </summary>
		public string uuid { get; set; }

		/// <summary>
		/// E-mail 
		/// </summary>
		public string email { get; set; }

		/// <summary>
		/// It is e-mail main or not 
		/// </summary>
		public Boolean main { get; set; }

	}

	///<summary>
	/// CustomerOut used when get information about customer. 
	/// </summary>
	public class UkrPoshtaCustomerOut
	{
		/// <summary>
		/// Identificator. 
		/// </summary>
		public string uuid { get; set; }

		/// <summary>
		/// Name of customer, formated from parameters: firstName, middleName, lastName. 
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// First name of customer. 
		/// </summary>
		public string firstName { get; set; }

		/// <summary>
		/// Middle name of customer. 
		/// </summary>
		public string middleName { get; set; }

		/// <summary>
		/// Last name of customer. 
		/// </summary>
		public string lastName { get; set; }

		/// <summary>
		/// Name of customer, formated from parameters: firstNameEn, lastNameEn. 
		/// </summary>
		public string nameEn { get; set; }

		/// <summary>
		/// First name an english of customer. 
		/// </summary>
		public string firstNameEn { get; set; }

		/// <summary>
		/// Last name an english of customer. 
		/// </summary>
		public string lastNameEn { get; set; }

		/// <summary>
		/// Unique customer ID provided by "Ukrposhta". 
		/// </summary>
		public string postId { get; set; }

		/// <summary>
		/// External Customer ID in counterparty base. 
		/// </summary>
		public string externalId { get; set; }

		/// <summary>
		/// Unique reqistration number. 
		/// </summary>
		public string uniqueRegistrationNumber { get; set; }

		/// <summary>
		/// Counterparty identificator. 
		/// </summary>
		public string counterpartyUuid { get; set; }

		/// <summary>
		/// Address ID, indicates the Id of the pre-created address. 
		/// </summary>
		public Int32 addressId { get; set; }

		/// <summary>
		/// If the customer has specified multiple addresses, it will be used only the one with 'main' setted true. 
		/// </summary>
		public UkrPoshtaCustomerAddress[] addresses { get; set; }

		/// <summary>
		/// Phone number of customer. 
		/// </summary>
		public string phoneNumber { get; set; }

		/// <summary>
		/// If the customer has specified multiple phones, it will be used only the one with 'main' setted true. 
		/// </summary>
		public UkrPoshtaCustomerPhone[] phones { get; set; }

		/// <summary>
		/// E-mail customer. 
		/// </summary>
		public string email { get; set; }

		/// <summary>
		/// If the customer has specified multiple emails, it will be used only the one with 'main' setted true. 
		/// </summary>
		public UkrPoshtaCustomerEmail[] emails { get; set; }

		/// <summary>
		/// A variable that indicates whether the customer is a entity or an individual. 
		/// </summary>
		public Boolean individual { get; set; }

		/// <summary>
		/// EDRPOU entity. 
		/// </summary>
		public string edrpou { get; set; }

		/// <summary>
		/// Bank Code. 
		/// </summary>
		public string bankCode { get; set; }

		/// <summary>
		/// Recipient account. 
		/// </summary>
		public string bankAccount { get; set; }

		/// <summary>
		/// Individual tax number for entities. 
		/// </summary>
		public string tin { get; set; }

		/// <summary>
		/// Contact name. 
		/// </summary>
		public string contactPersonName { get; set; }

		/// <summary>
		/// Resident of Ukraine. If resident is true, customer is a resident of Ukraine. 
		/// </summary>
		public Boolean resident { get; set; }

	}

	///<summary>
	/// CustomerIn used when add or edit customer.
	///     If the customer is an individual, the value of the individual should be true. In this case, you must specify the first name, last name and middle name (in parameters: firstName, lastName and middleName) of the customer. The 'name' parameter is generated automatically. If the customer is a entity, the value of the individual must be false. In this case, the API accepts only the 'name' parameter. 
	/// </summary>
	public class UkrPoshtaCustomerIn
	{
		/// <summary>
		/// Name of the customer. (Maximum number of characters 250, is mandatory for a entity, for an individual is formed from the parameters: firstName, middleName, lastName) 
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// First name of the individual. (Maximum number of characters is 250, the minimum 2) 
		/// </summary>
		public string firstName { get; set; }

		/// <summary>
		/// Middle name of an individual. (the maximum number of characters is 250, the minimum is 2) 
		/// </summary>
		public string middleName { get; set; }

		/// <summary>
		/// Last name of an individual. (the maximum number of characters is 250, the minimum is 2) 
		/// </summary>
		public string lastName { get; set; }

		/// <summary>
		/// External Customer ID in the counterparty's base. 
		/// </summary>
		public string externalId { get; set; }

		/// <summary>
		/// Unique registration number. 
		/// </summary>
		public string uniqueRegistrationNumber { get; set; }

		/// <summary>
		/// Address ID, indicates the Id of the pre-created address. 
		/// </summary>
		public Int32 addressId { get; set; }

		/// <summary>
		/// Customer phone number (only numbers, maximum 25 characters) 
		/// </summary>
		public string phoneNumber { get; set; }

		/// <summary>
		/// E-mail customer 
		/// </summary>
		public string email { get; set; }

		/// <summary>
		/// A variable that indicates whether the customer is entity or an individual. The entity of the individual must be-false, in physical-true. (Can not be changed after creation) 
		/// </summary>
		public Boolean individual { get; set; }

		/// <summary>
		/// EDRPOU entity (only numbers 5-8 characters). Only the valid EDRPOU can be saved. 
		///  Before the creation is validated according to the algorithm:Site with algorithm validation 'http://1cinfo.com.ua/Articles/Proverka_koda_po_EDRPOU.aspx'. 
		/// </summary>
		public string edrpou { get; set; }

		/// <summary>
		/// Bank Code.(Only numbers, maximum characters 6) 
		/// </summary>
		public string bankCode { get; set; }

		/// <summary>
		/// Recipient account.(Only numbers, maximum characters 14) 
		/// </summary>
		public string bankAccount { get; set; }

		/// <summary>
		/// Individual tax number for entities. (Only numbers, maximum characters 32) 
		/// </summary>
		public string tin { get; set; }

		/// <summary>
		/// Contact name. 
		/// </summary>
		public string contactPersonName { get; set; }

		/// <summary>
		/// Resident of Ukraine. If resident is true, customer is a resident of Ukraine. By default, when creating a resident, it is true. 
		/// </summary>
		public Boolean resident { get; set; }

	}

	///<summary>
	/// Parameters of the parcel. 
	///     When creating a parcel, you need to specify the main fields: weight - the maximum weight of sending 30000 grams. Weight of departure must be greater than zero.length - largest side of the departure, indicates the length in inches, length of departure must be greater than zero.declaredPrice - The stated price is sending filled in UAH 
	/// </summary>
	public class UkrPoshtaParcel
	{
		/// <summary>
		/// Shipping weight. 
		/// </summary>
		public Int32 weight { get; set; }

		/// <summary>
		/// Shipping length. 
		/// </summary>
		public Int32 length { get; set; }

		/// <summary>
		/// Shipping width. 
		/// </summary>
		public Int32 width { get; set; }

		/// <summary>
		/// Shipping height. 
		/// </summary>
		public Int32 height { get; set; }

		/// <summary>
		/// Shipping declared price. 
		/// </summary>
		public Int64 declaredPrice { get; set; }

	}

	///<summary>
	/// Information about discount per customer. 
	/// </summary>
	public class UkrPoshtaDiscountPerCustomer
	{
		/// <summary>
		/// Identifier. 
		/// </summary>
		public string uuid { get; set; }

		/// <summary>
		/// Customer identifier. 
		/// </summary>
		public string clientUuid { get; set; }

		/// <summary>
		/// Discount identifier. 
		/// </summary>
		public string discountUuid { get; set; }

		/// <summary>
		/// Value of discount. 
		/// </summary>
		public Single value { get; set; }

		/// <summary>
		/// Discount available from date. 
		/// </summary>
		public string fromDate { get; set; }

		/// <summary>
		/// Discount available to date. 
		/// </summary>
		public string toDate { get; set; }

		/// <summary>
		/// Shipment type. 
		/// </summary>
		public string shipmentType { get; set; }

	}

	///<summary>
	/// ShipmentOut used when get information about shipment. 
	/// </summary>
	public class UkrPoshtaShipmentOut
	{
		/// <summary>
		/// Identificator. 
		/// </summary>
		public string uuid { get; set; }

		/// <summary>
		/// Information about sender. 
		/// </summary>
		public UkrPoshtaCustomerOut sender { get; set; }

		/// <summary>
		/// Information about recipient. 
		/// </summary>
		public UkrPoshtaCustomerOut recipient { get; set; }

		/// <summary>
		/// Recipient phone. 
		/// </summary>
		public string recipientPhone { get; set; }

		/// <summary>
		/// Recipient email. 
		/// </summary>
		public string recipientEmail { get; set; }

		/// <summary>
		/// Recipient address identifier. 
		/// </summary>
		public string recipientAddressId { get; set; }

		/// <summary>
		/// Return address identifier. 
		/// </summary>
		public string returnAddressId { get; set; }

		/// <summary>
		/// Shipment group identifier. 
		/// </summary>
		public string shipmentGroupUuid { get; set; }

		/// <summary>
		/// External identifier. 
		/// </summary>
		public string externalId { get; set; }

		/// <summary>
		/// Delivery type.
		///  RETURN - return to the sender.RETURN_AFTER_F REE_STORAGE - return after the expiration of free storage.PROCESS_AS_REF USAL - destroy the parcel.By default RETURN. 
		/// </summary>
		public string deliveryType { get; set; }

		/// <summary>
		/// Package type. 
		/// </summary>
		public string packageType { get; set; }

		/// <summary>
		/// Actions with shipment in case the recipient did not take it. 
		/// </summary>
		public string onFailReceiveType { get; set; }

		/// <summary>
		/// Parcel barcode. 
		/// </summary>
		public string barcode { get; set; }

		/// <summary>
		/// Parcels. 
		/// </summary>
		public UkrPoshtaParcel[] parcels { get; set; }

		/// <summary>
		/// Delivery price. 
		/// </summary>
		public Int64 deliveryPrice { get; set; }

		/// <summary>
		/// Post pay. 
		/// </summary>
		public Int64 postPay { get; set; }

		/// <summary>
		/// Currency code. 
		/// </summary>
		public string currencyCode { get; set; }

		/// <summary>
		/// Post pay currency code. 
		/// </summary>
		public string postPayCurrencyCode { get; set; }

		/// <summary>
		/// Currency exchange rate. 
		/// </summary>
		public string currencyExchangeRate { get; set; }

		/// <summary>
		/// Discount per customer. 
		/// </summary>
		public UkrPoshtaDiscountPerCustomer discountPerClient { get; set; }

		/// <summary>
		/// Date of making the latest changes in the shipment. Date and time in the format "2017-06- 12T12: 31: 56" 
		/// </summary>
		public string lastModified { get; set; }

		/// <summary>
		/// Description or comments. 
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// Tracking departure. 
		/// </summary>
		public Object[] statusTrackings { get; set; }

		/// <summary>
		/// Payment for the shipment upon receipt. 
		///  true - payment by the recipient.false - payment sender.By default, false. 
		/// </summary>
		public Boolean paidByRecipient { get; set; }

		/// <summary>
		/// Payment by cashless payment.
		///  true - non-cash.false - cash.By default, true. 
		/// </summary>
		public Boolean nonCashPayment { get; set; }

		/// <summary>
		/// The note is a bulky parcel.
		///  true - cumbersomefalse - not cumbersomeBy default false 
		/// </summary>
		public Boolean bulky { get; set; }

		/// <summary>
		/// The note is a fragile parcel.
		///  true - brittle.false - not fragile.By default false. 
		/// </summary>
		public Boolean fragile { get; set; }

		/// <summary>
		/// Bee pointing.
		///  By default false. 
		/// </summary>
		public Boolean bees { get; set; }

		/// <summary>
		/// Sending from a receipt.
		///  If true when receiving a shipment (Service for which an additional price is charged. Details on the site ukrposhta.ua), the sender receives a letter stating that the shipment has been received.By default false. 
		/// </summary>
		public Boolean recommended { get; set; }

		/// <summary>
		/// Sms message about the arrival of the parcel.
		///  If the true recipient receives the message (Service for which an additional price is charged. Details on the site ukrposhta.ua).By default false. 
		/// </summary>
		public Boolean sms { get; set; }

		/// <summary>
		/// International shipping
		///  By default false. 
		/// </summary>
		public Boolean international { get; set; }

		/// <summary>
		/// Shipping price. 
		/// </summary>
		public string postPayDeliveryPrice { get; set; }

		/// <summary>
		/// The party who pays the postpay billing fee.
		///  true - the amount is paid by the recipient.false - is paid by the sender.By default true. 
		/// </summary>
		public Boolean postPayPaidByRecipient { get; set; }

		/// <summary>
		/// A description of the costing that describes how the cost of mail is generated. 
		/// </summary>
		public string calculationDescription { get; set; }

		/// <summary>
		/// Return shipping documentation.
		///  By default false. 
		/// </summary>
		public Boolean documentBack { get; set; }

		/// <summary>
		/// Review at handed.
		///  By default false. 
		/// </summary>
		public Boolean checkOnDelivery { get; set; }

		/// <summary>
		/// Display information about the sender's bank account on the address bar.
		///  By default false. Only if there is postpay. 
		/// </summary>
		public Boolean transferPostPayToBankAccount { get; set; }

		/// <summary>
		/// The shipping charge has been paid. 
		/// </summary>
		public Boolean deliveryPricePaid { get; set; }

		/// <summary>
		/// Postpay paid. 
		/// </summary>
		public Boolean postPayPaid { get; set; }

		/// <summary>
		/// The shipping charge has been paid. 
		/// </summary>
		public Boolean postPayDeliveryPricePaid { get; set; }

		/// <summary>
		/// Type shipment.
		///  EXPRESS - Ukrposhta Express.STANDARD - Ukrposhta standard.For more detail see:http://ukrposhta.ua/ By default EXPRESS. 
		/// </summary>
		public string type { get; set; }

		/// <summary>
		/// After the creation of the sending status changes to CREATED, after the registration of the shipment in the communications branch status changes to REGISTERED. 
		/// </summary>
		public string status { get; set; }

	}

	///<summary>
	/// Customer Identificator. 
	/// </summary>
	public class UkrPoshtaCustomerUuid
	{
		/// <summary>
		/// Identificator. 
		/// </summary>
		public string uuid { get; set; }

	}

	///<summary>
	/// ShipmentIn used when add or edit information shipment. 
	/// </summary>
	public class UkrPoshtaShipmentIn
	{
		/// <summary>
		/// Identificator sender customer. 
		/// </summary>
		public UkrPoshtaCustomerUuid sender { get; set; }

		/// <summary>
		/// Identificator recipient customer. 
		/// </summary>
		public UkrPoshtaCustomerUuid recipient { get; set; }

		/// <summary>
		/// Repient phone. 
		/// </summary>
		public string recipientPhone { get; set; }

		/// <summary>
		/// Recipient email. 
		/// </summary>
		public string recipientEmail { get; set; }

		/// <summary>
		/// Recipient address id. 
		/// </summary>
		public string recipientAddressId { get; set; }

		/// <summary>
		/// Return address id, may be specified additionally, if not specified will used main address where 'main' is true. 
		/// </summary>
		public string returnAddressId { get; set; }

		/// <summary>
		/// Identificator of shipment group, if sending is a group. 
		/// </summary>
		public string shipmentGroupUuid { get; set; }

		/// <summary>
		/// External ID of departure at the base counterparty. 
		/// </summary>
		public string externalId { get; set; }

		/// <summary>
		/// Delivery type(for international shippment).
		///  Have mostly 4 types:W2D warehouse-door 
		///  W2W warehouse-warehouse 
		///  D2W door-warehouse
		///  D2D door-door 
		/// </summary>
		public string deliveryType { get; set; }

		/// <summary>
		/// Actions with shipment in case the recipient did not take it.
		///  RETURN - return to the sender.RETURN_AFTER_F REE_STORAGE - return after the expiration of free storage.PROCESS_AS_REF USAL - destroy the parcel.By default RETURN. 
		/// </summary>
		public string onFailReceiveType { get; set; }

		/// <summary>
		/// Parcels. 
		/// </summary>
		public UkrPoshtaParcel[] parcels { get; set; }

		/// <summary>
		/// Postpay in UAH may not be higher than the stated price. 
		/// </summary>
		public Int64 postPay { get; set; }

		/// <summary>
		/// Description or comments (max 255 characters). 
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// Payment for the shipment upon receipt. 
		///  true - payment by the recipient.false - payment sender.By default, false. 
		/// </summary>
		public Boolean paidByRecipient { get; set; }

		/// <summary>
		/// Payment by cashless payment.
		///  true - non-cash.false - cash.By default, true. 
		/// </summary>
		public Boolean nonCashPayment { get; set; }

		/// <summary>
		/// The note is a bulky parcel.
		///  true - cumbersomefalse - not cumbersomeBy default false 
		/// </summary>
		public Boolean bulky { get; set; }

		/// <summary>
		/// The note is a fragile parcel.
		///  true - brittle.false - not fragile.By default false. 
		/// </summary>
		public Boolean fragile { get; set; }

		/// <summary>
		/// Bee pointing.
		///  By default false. 
		/// </summary>
		public Boolean bees { get; set; }

		/// <summary>
		/// Sending from a receipt.
		///  If true when receiving a shipment (Service for which an additional price is charged. Details on the site ukrposhta.ua), the sender receives a letter stating that the shipment has been received.By default false. 
		/// </summary>
		public Boolean recommended { get; set; }

		/// <summary>
		/// Sms message about the arrival of the parcel.
		///  If the true recipient receives the message (Service for which an additional price is charged. Details on the site ukrposhta.ua).By default false. 
		/// </summary>
		public Boolean sms { get; set; }

		/// <summary>
		/// Return shipping documentation
		///  By default false. 
		/// </summary>
		public Boolean documentBack { get; set; }

		/// <summary>
		/// Review at handed.
		///  By default false. 
		/// </summary>
		public Boolean checkOnDelivery { get; set; }

		/// <summary>
		/// Display information about the sender's bank account on the address bar.
		///  By default false. Only if there is postpay. 
		/// </summary>
		public Boolean transferPostPayToBankAccount { get; set; }

		/// <summary>
		/// Type shipment.
		///  EXPRESS - Ukrposhta Express.STANDARD - Ukrposhta standard.For more detail see:http://ukrposhta.ua/ By default EXPRESS. 
		/// </summary>
		public string type { get; set; }

		/// <summary>
		/// The party who pays the postpay billing fee.
		///  true - the amount is paid by the recipient.false - is paid by the sender.By default true. 
		/// </summary>
		public Boolean postPayPaidByRecipient { get; set; }

	}

	///<summary>
	/// ShipmentGroupOut used when get information about shipment group. 
	/// </summary>
	public class UkrPoshtaShipmentGroupOut
	{
		/// <summary>
		/// Identificator shipment group. 
		/// </summary>
		public string uuid { get; set; }

		/// <summary>
		/// Name of shipment group. 
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// Customer identificator. 
		/// </summary>
		public string clientUuid { get; set; }

		/// <summary>
		/// Consignment(for international shipments). 
		/// </summary>
		public string consignment { get; set; }

		/// <summary>
		/// Registered group. 
		/// </summary>
		public Boolean approved { get; set; }

		/// <summary>
		/// Type group parcel. 
		/// </summary>
		public string type { get; set; }

	}

	///<summary>
	/// ShipmentGroupIn used for add or edit information about shipmentGroup. 
	/// </summary>
	public class UkrPoshtaShipmentGroupIn
	{
		/// <summary>
		/// Name of shipment group. 
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// Identificator client. 
		/// </summary>
		public string clientUuid { get; set; }

		/// <summary>
		/// Type group parcel.
		///  EXPRESS - Ukrposhta Express.STANDARD - Ukrposhta standard.For more detail see:http://ukrposhta.ua/ By default EXPRESS. 
		/// </summary>
		public string type { get; set; }

	}

}