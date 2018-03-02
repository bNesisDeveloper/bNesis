using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;
using bNesis.Api.Desktop;
using bNesis.Sdk.Common;

namespace bNesis.Sdk.GovRegistry.Prozzoro
{
	public class Prozzoro  
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

		public Prozzoro(DesktopbNesisApi bNesisApi)
		{
			this.bNesisApi = bNesisApi;
		}

		/// <summary>
		/// The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		/// </summary>
		/// <returns>bNesisToken value</returns>	
		public string Auth(string data,string bNesisDevId,string redirectUrl,string clientId,string clientSecret,string[] scopes,string login,string password,bool isSandbox,string serviceUrl)
		{
			bNesisToken = bNesisApi.Auth("Prozzoro", data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl);
			return bNesisToken;
		}

		/// <summary>
		/// The method stops the authorization session with the service and clears the value of bNesisToken.
		/// </summary>
		/// <returns>true - if service logoff is successful</returns>
		public bool LogoffService()
		{
			bool result = bNesisApi.LogoffService("Prozzoro", bNesisToken);
			if (result) bNesisToken = string.Empty;
			return result;             
		}


		///<summary>
		/// Getting last exception for current provider 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo GetLastError()
		{
			return bNesisApi.Call<ErrorInfo>("Prozzoro", bNesisToken, "GetLastError");
		}

		///<summary>
		/// Getting arrays of error info 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo[] GetErrorLog()
		{
			return bNesisApi.Call<ErrorInfo[]>("Prozzoro", bNesisToken, "GetErrorLog");
		}

		///<summary>
		/// Checks the token in the service. 
		/// </summary>
		/// <returns>if token valid return true, if token not valid return false</returns>
		public Boolean ValidateToken()
		{
			return bNesisApi.Call<Boolean>("Prozzoro", bNesisToken, "ValidateToken");
		}

		///<summary>
		/// Disables the access token used to authenticate the call. 
		/// </summary>
		/// <returns>if token revoked method returns true 
		/// if token doesn't support token revocation or token is revoked method returns false</returns>
		public Boolean Logoff()
		{
			return bNesisApi.Call<Boolean>("Prozzoro", bNesisToken, "Logoff");
		}

		///<summary>
		/// Gets the tender contract documents. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="contractId">The contract uid.</param>
		/// <returns>Response.</returns>
		public Response GetTenderContractDocumentsRaw(string tenderId, string contractId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTenderContractDocumentsRaw", tenderId, contractId);
		}

		///<summary>
		/// Gets the tender contract document. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="contractId">The contract uid.</param>
		/// <param name="documentId">The contract document uid.</param>
		/// <returns>Response.</returns>
		public Response GetTenderContractDocumentRaw(string tenderId, string contractId, string documentId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTenderContractDocumentRaw", tenderId, contractId, documentId);
		}

		///<summary>
		/// Downloads the tender contract document. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="contractId">The contract uid.</param>
		/// <param name="documentId">The contract document uid.</param>
		/// <returns>Response.</returns>
		public Response DownloadTenderContractDocumentRaw(string tenderId, string contractId, string documentId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "DownloadTenderContractDocumentRaw", tenderId, contractId, documentId);
		}

		///<summary>
		/// Gets the tender lots. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <returns>Response.</returns>
		public Response GetTenderLotsRaw(string tenderId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTenderLotsRaw", tenderId);
		}

		///<summary>
		/// Gets the tender lot. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="lotId">The lot uid.</param>
		/// <returns>Response.</returns>
		public Response GetTenderLotRaw(string tenderId, string lotId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTenderLotRaw", tenderId, lotId);
		}

		///<summary>
		/// Gets the tender lot documents. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="lotId">The lot uid.</param>
		/// <returns>Response.</returns>
		public Response GetTenderLotDocumentsRaw(string tenderId, string lotId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTenderLotDocumentsRaw", tenderId, lotId);
		}

		///<summary>
		/// Gets the tender lot document. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="lotId">The lot uid.</param>
		/// <param name="documentId">The lot document uid.</param>
		/// <returns>Response.</returns>
		public Response GetTenderLotDocumentRaw(string tenderId, string lotId, string documentId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTenderLotDocumentRaw", tenderId, lotId, documentId);
		}

		///<summary>
		/// Downloads the tender lot document. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="lotId">The lot uid.</param>
		/// <param name="documentId">The lot document uid.</param>
		/// <returns>Response.</returns>
		public Response DownloadTenderLotDocumentRaw(string tenderId, string lotId, string documentId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "DownloadTenderLotDocumentRaw", tenderId, lotId, documentId);
		}

		///<summary>
		/// Getting list of all tenders (Limit:100). 
		/// </summary>
		/// <returns>PageInfo.</returns>
		public ProzzoroPageInfo GetTenders()
		{
			return bNesisApi.Call<ProzzoroPageInfo>("Prozzoro", bNesisToken, "GetTenders");
		}

		///<summary>
		/// Getting list of all tenders in next page (Limit:100). 
		/// </summary>
		/// <param name="offset">Offset date time.</param>
		/// <returns>PageInfo.</returns>
		public ProzzoroPageInfo GetTendersNext(string offset)
		{
			return bNesisApi.Call<ProzzoroPageInfo>("Prozzoro", bNesisToken, "GetTendersNext", offset);
		}

		///<summary>
		/// Gets tender. 
		/// </summary>
		/// <param name="tenderId">The uid tender.</param>
		/// <returns>Tender.</returns>
		public ProzzoroTender GetTenderByIdentifier(string tenderId)
		{
			return bNesisApi.Call<ProzzoroTender>("Prozzoro", bNesisToken, "GetTenderByIdentifier", tenderId);
		}

		///<summary>
		/// Gets the tender documents. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <returns>Array of Document.</returns>
		public ProzzoroDocument[] GetTenderDocuments(string tenderId)
		{
			return bNesisApi.Call<ProzzoroDocument[]>("Prozzoro", bNesisToken, "GetTenderDocuments", tenderId);
		}

		///<summary>
		/// Gets the tender document. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="documentId">The document uid.</param>
		/// <returns>Document.</returns>
		public ProzzoroDocument GetTenderDocument(string tenderId, string documentId)
		{
			return bNesisApi.Call<ProzzoroDocument>("Prozzoro", bNesisToken, "GetTenderDocument", tenderId, documentId);
		}

		///<summary>
		/// Downloads the tender document. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="documentId">The document uid.</param>
		/// <returns>Stream.</returns>
		public Stream DownloadTenderDocument(string tenderId, string documentId)
		{
			return bNesisApi.Call<Stream>("Prozzoro", bNesisToken, "DownloadTenderDocument", tenderId, documentId);
		}

		///<summary>
		/// Gets the tender bids. 
		/// </summary>
		/// <param name="id">The uid tender.</param>
		/// <returns>Array of Bid.</returns>
		public ProzzoroBid[] GetTenderBids(string id)
		{
			return bNesisApi.Call<ProzzoroBid[]>("Prozzoro", bNesisToken, "GetTenderBids", id);
		}

		///<summary>
		/// Gets the tender bid. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="bidId">The bid uid.</param>
		/// <returns>Bid.</returns>
		public ProzzoroBid GetTenderBid(string tenderId, string bidId)
		{
			return bNesisApi.Call<ProzzoroBid>("Prozzoro", bNesisToken, "GetTenderBid", tenderId, bidId);
		}

		///<summary>
		/// Gets the tender bid documents. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="bidId">The bid uid.</param>
		/// <returns>Array of Document.</returns>
		public ProzzoroDocument[] GetTenderBidDocuments(string tenderId, string bidId)
		{
			return bNesisApi.Call<ProzzoroDocument[]>("Prozzoro", bNesisToken, "GetTenderBidDocuments", tenderId, bidId);
		}

		///<summary>
		/// Gets the tender bid document. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="bidId">The bid uid.</param>
		/// <param name="documentId">The bid document uid.</param>
		/// <returns>Document.</returns>
		public ProzzoroDocument GetTenderBidDocument(string tenderId, string bidId, string documentId)
		{
			return bNesisApi.Call<ProzzoroDocument>("Prozzoro", bNesisToken, "GetTenderBidDocument", tenderId, bidId, documentId);
		}

		///<summary>
		/// Downloads the tender bid document. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="bidId">The bid uid.</param>
		/// <param name="documentId">The bid document uid.</param>
		/// <returns>Stream.</returns>
		public Stream DownloadTenderBidDocument(string tenderId, string bidId, string documentId)
		{
			return bNesisApi.Call<Stream>("Prozzoro", bNesisToken, "DownloadTenderBidDocument", tenderId, bidId, documentId);
		}

		///<summary>
		/// Gets the tender awards. 
		/// </summary>
		/// <param name="tenderId">The uid tender.</param>
		/// <returns>Array of Award.</returns>
		public ProzzoroAward[] GetTenderAwards(string tenderId)
		{
			return bNesisApi.Call<ProzzoroAward[]>("Prozzoro", bNesisToken, "GetTenderAwards", tenderId);
		}

		///<summary>
		/// Gets the tender award. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="awardId">The award uid.</param>
		/// <returns>Award.</returns>
		public ProzzoroAward GetTenderAward(string tenderId, string awardId)
		{
			return bNesisApi.Call<ProzzoroAward>("Prozzoro", bNesisToken, "GetTenderAward", tenderId, awardId);
		}

		///<summary>
		/// Gets the tender award documents. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="awardId">The award uid.</param>
		/// <returns>Array of Document.</returns>
		public ProzzoroDocument[] GetTenderAwardDocuments(string tenderId, string awardId)
		{
			return bNesisApi.Call<ProzzoroDocument[]>("Prozzoro", bNesisToken, "GetTenderAwardDocuments", tenderId, awardId);
		}

		///<summary>
		/// Gets the tender award document. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="awardId">The award uid.</param>
		/// <param name="documentId">The award document uid.</param>
		/// <returns>Document.</returns>
		public ProzzoroDocument GetTenderAwardDocument(string tenderId, string awardId, string documentId)
		{
			return bNesisApi.Call<ProzzoroDocument>("Prozzoro", bNesisToken, "GetTenderAwardDocument", tenderId, awardId, documentId);
		}

		///<summary>
		/// Downloads the tender award document. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="awardId">The award uid.</param>
		/// <param name="documentId">The award document uid.</param>
		/// <returns>Stream.</returns>
		public Stream DownloadTenderAwardDocument(string tenderId, string awardId, string documentId)
		{
			return bNesisApi.Call<Stream>("Prozzoro", bNesisToken, "DownloadTenderAwardDocument", tenderId, awardId, documentId);
		}

		///<summary>
		/// Gets the tender cancellations. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <returns>Array of Cancellation.</returns>
		public ProzzoroCancellation[] GetTenderCancellations(string tenderId)
		{
			return bNesisApi.Call<ProzzoroCancellation[]>("Prozzoro", bNesisToken, "GetTenderCancellations", tenderId);
		}

		///<summary>
		/// Gets the tender cancellation. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="cancellationId">The cancellation uid.</param>
		/// <returns>Cancellation.</returns>
		public ProzzoroCancellation GetTenderCancellation(string tenderId, string cancellationId)
		{
			return bNesisApi.Call<ProzzoroCancellation>("Prozzoro", bNesisToken, "GetTenderCancellation", tenderId, cancellationId);
		}

		///<summary>
		/// Gets the tender cancellation documents. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="cancellationId">The cancellation uid.</param>
		/// <returns>Array of Document.</returns>
		public ProzzoroDocument[] GetTenderCancellationDocuments(string tenderId, string cancellationId)
		{
			return bNesisApi.Call<ProzzoroDocument[]>("Prozzoro", bNesisToken, "GetTenderCancellationDocuments", tenderId, cancellationId);
		}

		///<summary>
		/// Gets the tender cancellation document. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="cancellationId">The cancellation uid.</param>
		/// <param name="documentId">The award document uid.</param>
		/// <returns>Document.</returns>
		public ProzzoroDocument GetTenderCancellationDocument(string tenderId, string cancellationId, string documentId)
		{
			return bNesisApi.Call<ProzzoroDocument>("Prozzoro", bNesisToken, "GetTenderCancellationDocument", tenderId, cancellationId, documentId);
		}

		///<summary>
		/// Downloads the tender cancellation document. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="cancellationId">The cancellation uid.</param>
		/// <param name="documentId">The award document uid.</param>
		/// <returns>Stream.</returns>
		public Stream DownloadTenderCancellationDocument(string tenderId, string cancellationId, string documentId)
		{
			return bNesisApi.Call<Stream>("Prozzoro", bNesisToken, "DownloadTenderCancellationDocument", tenderId, cancellationId, documentId);
		}

		///<summary>
		/// Gets the tender complaints. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <returns>Array of complaint.</returns>
		public ProzzoroComplaint[] GetTenderComplaints(string tenderId)
		{
			return bNesisApi.Call<ProzzoroComplaint[]>("Prozzoro", bNesisToken, "GetTenderComplaints", tenderId);
		}

		///<summary>
		/// Gets the tender complaint. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="complaintId">The complaint uid.</param>
		/// <returns>Complaint.</returns>
		public ProzzoroComplaint GetTenderComplaint(string tenderId, string complaintId)
		{
			return bNesisApi.Call<ProzzoroComplaint>("Prozzoro", bNesisToken, "GetTenderComplaint", tenderId, complaintId);
		}

		///<summary>
		/// Gets the tender complaint documents. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="complaintId">The complaint uid.</param>
		/// <returns>Array of Document.</returns>
		public ProzzoroDocument[] GetTenderComplaintDocuments(string tenderId, string complaintId)
		{
			return bNesisApi.Call<ProzzoroDocument[]>("Prozzoro", bNesisToken, "GetTenderComplaintDocuments", tenderId, complaintId);
		}

		///<summary>
		/// Gets the tender complaint document. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="complaintId">The complaint uid.</param>
		/// <param name="documentId">The complaint document uid.</param>
		/// <returns>Document.</returns>
		public ProzzoroDocument GetTenderComplaintDocument(string tenderId, string complaintId, string documentId)
		{
			return bNesisApi.Call<ProzzoroDocument>("Prozzoro", bNesisToken, "GetTenderComplaintDocument", tenderId, complaintId, documentId);
		}

		///<summary>
		/// Downloads the tender complaint document. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="complaintId">The complaint uid.</param>
		/// <param name="documentId">The complaint document uid.</param>
		/// <returns>Stream.</returns>
		public Stream DownloadTenderComplaintDocument(string tenderId, string complaintId, string documentId)
		{
			return bNesisApi.Call<Stream>("Prozzoro", bNesisToken, "DownloadTenderComplaintDocument", tenderId, complaintId, documentId);
		}

		///<summary>
		/// Gets the tender contracts. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <returns>Array of Contracts.</returns>
		public ProzzoroContract[] GetTenderContracts(string tenderId)
		{
			return bNesisApi.Call<ProzzoroContract[]>("Prozzoro", bNesisToken, "GetTenderContracts", tenderId);
		}

		///<summary>
		/// Gets the tender contract. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="contractId">The contract uid.</param>
		/// <returns>Contract.</returns>
		public ProzzoroContract GetTenderContract(string tenderId, string contractId)
		{
			return bNesisApi.Call<ProzzoroContract>("Prozzoro", bNesisToken, "GetTenderContract", tenderId, contractId);
		}

		///<summary>
		/// Gets the tender contract documents. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="contractId">The contract uid.</param>
		/// <returns>Array of Document.</returns>
		public ProzzoroDocument[] GetTenderContractDocuments(string tenderId, string contractId)
		{
			return bNesisApi.Call<ProzzoroDocument[]>("Prozzoro", bNesisToken, "GetTenderContractDocuments", tenderId, contractId);
		}

		///<summary>
		/// Gets the tender contract document. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="contractId">The contract uid.</param>
		/// <param name="documentId">The contract document uid.</param>
		/// <returns>Document.</returns>
		public ProzzoroDocument GetTenderContractDocument(string tenderId, string contractId, string documentId)
		{
			return bNesisApi.Call<ProzzoroDocument>("Prozzoro", bNesisToken, "GetTenderContractDocument", tenderId, contractId, documentId);
		}

		///<summary>
		/// Downloads the tender contract document. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="contractId">The contract uid.</param>
		/// <param name="documentId">The contract document uid.</param>
		/// <returns>Stream.</returns>
		public Stream DownloadTenderContractDocument(string tenderId, string contractId, string documentId)
		{
			return bNesisApi.Call<Stream>("Prozzoro", bNesisToken, "DownloadTenderContractDocument", tenderId, contractId, documentId);
		}

		///<summary>
		/// Gets the tender lots. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <returns>Array of lot.</returns>
		public ProzzoroLot[] GetTenderLots(string tenderId)
		{
			return bNesisApi.Call<ProzzoroLot[]>("Prozzoro", bNesisToken, "GetTenderLots", tenderId);
		}

		///<summary>
		/// Gets the tender lot. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="lotId">The lot uid.</param>
		/// <returns>Lot.</returns>
		public ProzzoroLot GetTenderLot(string tenderId, string lotId)
		{
			return bNesisApi.Call<ProzzoroLot>("Prozzoro", bNesisToken, "GetTenderLot", tenderId, lotId);
		}

		///<summary>
		/// Gets the tender lot documents. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="lotId">The lot uid.</param>
		/// <returns>Array of Document.</returns>
		public ProzzoroDocument[] GetTenderLotDocuments(string tenderId, string lotId)
		{
			return bNesisApi.Call<ProzzoroDocument[]>("Prozzoro", bNesisToken, "GetTenderLotDocuments", tenderId, lotId);
		}

		///<summary>
		/// Gets the tender lot document. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="lotId">The lot uid.</param>
		/// <param name="documentId">The lot document uid.</param>
		/// <returns>Document.</returns>
		public ProzzoroDocument GetTenderLotDocument(string tenderId, string lotId, string documentId)
		{
			return bNesisApi.Call<ProzzoroDocument>("Prozzoro", bNesisToken, "GetTenderLotDocument", tenderId, lotId, documentId);
		}

		///<summary>
		/// Downloads the tender lot document. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="lotId">The lot uid.</param>
		/// <param name="documentId">The lot document uid.</param>
		/// <returns>Stream.</returns>
		public Stream DownloadTenderLotDocument(string tenderId, string lotId, string documentId)
		{
			return bNesisApi.Call<Stream>("Prozzoro", bNesisToken, "DownloadTenderLotDocument", tenderId, lotId, documentId);
		}

		///<summary>
		/// Gets list of all tender(Limit:100). 
		/// </summary>
		/// <returns>Response.</returns>
		public Response GetTendersRaw()
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTendersRaw");
		}

		///<summary>
		/// Gets list of all tender(Limit:100) in next page. 
		/// </summary>
		/// <param name="offset">Offset date time.</param>
		/// <returns>Response.</returns>
		public Response GetTendersInNextPageRaw(string offset)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTendersInNextPageRaw", offset);
		}

		///<summary>
		/// Gets the tender. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <returns>Response.</returns>
		public Response GetTenderByIdentifierRaw(string tenderId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTenderByIdentifierRaw", tenderId);
		}

		///<summary>
		/// Gets the tender documents. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <returns>Response.</returns>
		public Response GetTenderDocumentsRaw(string tenderId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTenderDocumentsRaw", tenderId);
		}

		///<summary>
		/// Gets the tender document. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="documentId">The tender document uid.</param>
		/// <returns>Response.</returns>
		public Response GetTenderDocumentRaw(string tenderId, string documentId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTenderDocumentRaw", tenderId, documentId);
		}

		///<summary>
		/// Downloads the tender document. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="documentId">The tender document uid.</param>
		/// <returns>Response.</returns>
		public Response DownloadTenderDocumentRaw(string tenderId, string documentId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "DownloadTenderDocumentRaw", tenderId, documentId);
		}

		///<summary>
		/// Gets the tender bids. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <returns>Response.</returns>
		public Response GetTenderBidsRaw(string tenderId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTenderBidsRaw", tenderId);
		}

		///<summary>
		/// Gets the tender bid. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="bidId">The bid uid.</param>
		/// <returns>Response.</returns>
		public Response GetTenderBidRaw(string tenderId, string bidId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTenderBidRaw", tenderId, bidId);
		}

		///<summary>
		/// Gets the tender bid documents. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="bidId">The bid uid.</param>
		/// <returns>Response.</returns>
		public Response GetTenderBidDocumentsRaw(string tenderId, string bidId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTenderBidDocumentsRaw", tenderId, bidId);
		}

		///<summary>
		/// Gets the tender bid document. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="bidId">The bid uid.</param>
		/// <param name="documentId">The bid document uid.</param>
		/// <returns>Response.</returns>
		public Response GetTenderBidDocumentRaw(string tenderId, string bidId, string documentId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTenderBidDocumentRaw", tenderId, bidId, documentId);
		}

		///<summary>
		/// Downloads the tender bid document. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="bidId">The bid uid.</param>
		/// <param name="documentId">The bid document uid.</param>
		/// <returns>Response.</returns>
		public Response DownloadTenderBidDocumentRaw(string tenderId, string bidId, string documentId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "DownloadTenderBidDocumentRaw", tenderId, bidId, documentId);
		}

		///<summary>
		/// Gets the tender awards. 
		/// </summary>
		/// <param name="id">The tender uid.</param>
		/// <returns>Response.</returns>
		public Response GetTenderAwardsRaw(string id)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTenderAwardsRaw", id);
		}

		///<summary>
		/// Gets the tender award. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="awardId">The award uid.</param>
		/// <returns>Response.</returns>
		public Response GetTenderAwardRaw(string tenderId, string awardId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTenderAwardRaw", tenderId, awardId);
		}

		///<summary>
		/// Gets the tender award documents. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="awardId">The award uid.</param>
		/// <returns>Response.</returns>
		public Response GetTenderAwardDocumentsRaw(string tenderId, string awardId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTenderAwardDocumentsRaw", tenderId, awardId);
		}

		///<summary>
		/// Gets the tender award document. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="awardId">The award uid.</param>
		/// <param name="documentId">The award document uid.</param>
		/// <returns>Response.</returns>
		public Response GetTenderAwardDocumentRaw(string tenderId, string awardId, string documentId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTenderAwardDocumentRaw", tenderId, awardId, documentId);
		}

		///<summary>
		/// Downloads the tender award document. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="awardId">The award uid.</param>
		/// <param name="documentId">The award document uid.</param>
		/// <returns>Response.</returns>
		public Response DownloadTenderAwardDocumentRaw(string tenderId, string awardId, string documentId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "DownloadTenderAwardDocumentRaw", tenderId, awardId, documentId);
		}

		///<summary>
		/// Gets the tender cancellations. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <returns>Response.</returns>
		public Response GetTenderCancellationsRaw(string tenderId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTenderCancellationsRaw", tenderId);
		}

		///<summary>
		/// Gets the tender cancellation. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="cancellationId">The cancellation uid.</param>
		/// <returns>Response.</returns>
		public Response GetTenderCancellationRaw(string tenderId, string cancellationId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTenderCancellationRaw", tenderId, cancellationId);
		}

		///<summary>
		/// Gets the tender cancellation documents. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="cancellationId">The cancellation uid.</param>
		/// <returns>Response.</returns>
		public Response GetTenderCancellationDocumentsRaw(string tenderId, string cancellationId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTenderCancellationDocumentsRaw", tenderId, cancellationId);
		}

		///<summary>
		/// Gets the tender cancellation document. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="cancellationId">The cancellation uid.</param>
		/// <param name="documentId">The award document uid.</param>
		/// <returns>Response.</returns>
		public Response GetTenderCancellationDocumentRaw(string tenderId, string cancellationId, string documentId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTenderCancellationDocumentRaw", tenderId, cancellationId, documentId);
		}

		///<summary>
		/// Downloads the tender cancellation document. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="cancellationId">The cancellation uid.</param>
		/// <param name="documentId">The award document uid.</param>
		/// <returns>Response.</returns>
		public Response DownloadTenderCancellationDocumentRaw(string tenderId, string cancellationId, string documentId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "DownloadTenderCancellationDocumentRaw", tenderId, cancellationId, documentId);
		}

		///<summary>
		/// Gets the tender complaints. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <returns>Response.</returns>
		public Response GetTenderComplaintsRaw(string tenderId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTenderComplaintsRaw", tenderId);
		}

		///<summary>
		/// Gets the tender complaint. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="complaintId">The complaint uid.</param>
		/// <returns>Response.</returns>
		public Response GetTenderComplaintRaw(string tenderId, string complaintId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTenderComplaintRaw", tenderId, complaintId);
		}

		///<summary>
		/// Gets the tender complaint documents. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="complaintId">The complaint uid.</param>
		/// <returns>Response.</returns>
		public Response GetTenderComplaintDocumentsRaw(string tenderId, string complaintId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTenderComplaintDocumentsRaw", tenderId, complaintId);
		}

		///<summary>
		/// Gets the tender complaint document. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="complaintId">The complaint uid.</param>
		/// <param name="documentId">The complaint document uid.</param>
		/// <returns>Response.</returns>
		public Response GetTenderComplaintDocumentRaw(string tenderId, string complaintId, string documentId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTenderComplaintDocumentRaw", tenderId, complaintId, documentId);
		}

		///<summary>
		/// Downloads the tender complaint document. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="complaintId">The complaint uid.</param>
		/// <param name="documentId">The complaint document uid.</param>
		/// <returns>Response.</returns>
		public Response DownloadTenderComplaintDocumentRaw(string tenderId, string complaintId, string documentId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "DownloadTenderComplaintDocumentRaw", tenderId, complaintId, documentId);
		}

		///<summary>
		/// Gets the tender contracts. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <returns>Response.</returns>
		public Response GetTenderContractsRaw(string tenderId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTenderContractsRaw", tenderId);
		}

		///<summary>
		/// Gets the tender contract. 
		/// </summary>
		/// <param name="tenderId">The tender uid.</param>
		/// <param name="contractId">The contract uid.</param>
		/// <returns>Response.</returns>
		public Response GetTenderContractRaw(string tenderId, string contractId)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTenderContractRaw", tenderId, contractId);
		}
}
	///<summary>
	/// Implementation class of NextPage. 
	/// </summary>
	public class ProzzoroNextPage
	{
		/// <summary>
		/// The path. 
		/// </summary>
		public string path { get; set; }

		/// <summary>
		/// The uri. 
		/// </summary>
		public string uri { get; set; }

		/// <summary>
		/// The offset. 
		/// </summary>
		public string offset { get; set; }

	}

	///<summary>
	/// Implementation class of Data. 
	/// </summary>
	public class ProzzoroData
	{
		/// <summary>
		/// The identifier. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// When modified. 
		/// </summary>
		public string dateModified { get; set; }

	}

	///<summary>
	/// Implementation class of PageInfo. 
	/// </summary>
	public class ProzzoroPageInfo
	{
		/// <summary>
		/// Information about next page. 
		/// </summary>
		public ProzzoroNextPage next_page { get; set; }

		/// <summary>
		/// Data information. 
		/// </summary>
		public ProzzoroData[] data { get; set; }

	}

	///<summary>
	/// Implementation class of Period. 
	/// </summary>
	public class ProzzoroPeriod
	{
		/// <summary>
		/// The date when period started. 
		/// </summary>
		public string startDate { get; set; }

		/// <summary>
		/// The date when period ended. 
		/// </summary>
		public string endDate { get; set; }

	}

	///<summary>
	/// Implementation class of ContactPoint. 
	/// </summary>
	public class ProzzoroContactPoint
	{
		/// <summary>
		/// The telephone number of the contact point/person 
		/// </summary>
		public string telephone { get; set; }

		/// <summary>
		/// The fax number of the contact point/person. 
		/// </summary>
		public string faxNumber { get; set; }

		/// <summary>
		/// The name of the contact person, department, or contact point, for correspondence relating to this contracting process. 
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// The e-mail address of person. 
		/// </summary>
		public string email { get; set; }

		/// <summary>
		/// A web address for the contact point/person. 
		/// </summary>
		public string url { get; set; }

	}

	///<summary>
	/// Implementation class of Identifier. 
	/// </summary>
	public class ProzzoroIdentifier
	{
		/// <summary>
		/// The identifier. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The scheme. 
		/// </summary>
		public string scheme { get; set; }

		/// <summary>
		/// The legal name. 
		/// </summary>
		public string legalName { get; set; }

	}

	///<summary>
	/// Implementation class of Address. 
	/// </summary>
	public class ProzzoroAddress
	{
		/// <summary>
		/// The postal code. 
		/// </summary>
		public string postalCode { get; set; }

		/// <summary>
		/// The name of the country. 
		/// </summary>
		public string countryName { get; set; }

		/// <summary>
		/// The street address. 
		/// </summary>
		public string streetAddress { get; set; }

		/// <summary>
		/// The region. 
		/// </summary>
		public string region { get; set; }

		/// <summary>
		/// The locality. 
		/// </summary>
		public string locality { get; set; }

	}

	///<summary>
	/// Implementation class of ProcuringEntity. 
	/// </summary>
	public class ProcuringEntity
	{
		/// <summary>
		/// The contact point. 
		/// </summary>
		public ProzzoroContactPoint contactPoint { get; set; }

		/// <summary>
		/// The identifier. 
		/// </summary>
		public ProzzoroIdentifier identifier { get; set; }

		/// <summary>
		/// The name. 
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// The address. 
		/// </summary>
		public ProzzoroAddress address { get; set; }

	}

	///<summary>
	/// Implementation class of Document. 
	/// </summary>
	public class ProzzoroDocument
	{
		/// <summary>
		/// The main document identifier. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The document hash. 
		/// </summary>
		public string hash { get; set; }

		/// <summary>
		/// The document author. 
		/// </summary>
		public string author { get; set; }

		/// <summary>
		/// The format of the document taken from the IANA Media Types code list,
		/// with the addition of one extra value for ‘offline/print’, 
		/// used when this document entry is being used to describe the offline publication of a document 
		/// </summary>
		public string format { get; set; }

		/// <summary>
		/// Direct link to the document or attachment. 
		/// </summary>
		public string url { get; set; }

		/// <summary>
		/// The document title. 
		/// </summary>
		public string title { get; set; }

		/// <summary>
		/// The document of one of the possible values are: 
		/// tender, item, lot 
		/// </summary>
		public string documentOf { get; set; }

		/// <summary>
		/// The date on which the document was first published. 
		/// </summary>
		public string datePublished { get; set; }

		/// <summary>
		/// The type of the document.
		/// See possible values on:http://api-docs.openprocurement.org/en/latest/standard/document.html#schema 
		/// </summary>
		public string documentType { get; set; }

		/// <summary>
		/// Date that the document was last modified. 
		/// </summary>
		public string dateModified { get; set; }

		/// <summary>
		/// The identifier of related Lot or Item. 
		/// </summary>
		public string relatedItem { get; set; }

		/// <summary>
		/// A short description of the document. 
		/// </summary>
		public string description { get; set; }

	}

	///<summary>
	/// Implementation class of Organization. 
	/// </summary>
	public class ProzzoroOrganization
	{
		/// <summary>
		/// The contact point. 
		/// </summary>
		public ProzzoroContactPoint contactPoint { get; set; }

		/// <summary>
		/// The primary identifier for this organization 
		/// </summary>
		public ProzzoroIdentifier identifier { get; set; }

		/// <summary>
		/// The common name of the organization. 
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// The address. 
		/// </summary>
		public ProzzoroAddress address { get; set; }

	}

	///<summary>
	/// Implementation class of Complain. Used when need get information about tender complaint. 
	/// </summary>
	public class ProzzoroComplaint
	{
		/// <summary>
		/// The main complain identifier. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The complain status.
		///  Possible values are:
		///  draft, claim, answered, pending, invalid, declined, resolved, cancelled 
		/// </summary>
		public string status { get; set; }

		/// <summary>
		/// The array of document. 
		/// </summary>
		public ProzzoroDocument[] documents { get; set; }

		/// <summary>
		/// Description of the issue. 
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// Organization filing a complaint. 
		/// </summary>
		public ProzzoroOrganization author { get; set; }

		/// <summary>
		/// The resotion type.
		/// Possible values of resolution type are:
		/// invalid,declined,resolved 
		/// </summary>
		public string resolutionType { get; set; }

		/// <summary>
		/// Resolution of Procuring entity. 
		/// </summary>
		public string resolution { get; set; }

		/// <summary>
		/// Title of the complaint. 
		/// </summary>
		public string title { get; set; }

		/// <summary>
		/// Date when Procuring entity answered the claim. 
		/// </summary>
		public string dateAnswered { get; set; }

		/// <summary>
		/// Date of claim to complaint escalation. 
		/// </summary>
		public string dateEscalated { get; set; }

		/// <summary>
		/// Date of complaint decision. 
		/// </summary>
		public string dateDecision { get; set; }

		/// <summary>
		/// Date of cancelling. 
		/// </summary>
		public string dateCanceled { get; set; }

		/// <summary>
		/// Date when claim was submitted. 
		/// </summary>
		public string dateSubmitted { get; set; }

		/// <summary>
		/// The secondary complaint identifier. 
		/// </summary>
		public string complaintID { get; set; }

		/// <summary>
		/// Date of posting. 
		/// </summary>
		public string date { get; set; }

		/// <summary>
		/// The complaint type.
		///   Possible values of type are:
		///  claim, complaint. 
		/// </summary>
		public string type { get; set; }

	}

	///<summary>
	/// Implementation class of Value. 
	/// </summary>
	public class ProzzoroValue
	{
		/// <summary>
		/// The currency in 3-letter ISO 4217 format. 
		/// </summary>
		public string currency { get; set; }

		/// <summary>
		/// The amount. 
		/// </summary>
		public Single amount { get; set; }

		/// <summary>
		/// A value indicating whether value-added tax include. 
		/// </summary>
		public Boolean valueAddedTaxIncluded { get; set; }

	}

	///<summary>
	/// Implementation class of Guarantee. 
	/// </summary>
	public class ProzzoroGuarantee
	{
		/// <summary>
		/// The currency. 
		/// </summary>
		public string currency { get; set; }

		/// <summary>
		/// The amount. 
		/// </summary>
		public Single amount { get; set; }

	}

	///<summary>
	/// Implementation class of Cancellation. Used when need get information about tender/lot cancellation. 
	/// </summary>
	public class ProzzoroCancellation
	{
		/// <summary>
		/// The main cancellation identifier. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// Possible status values are:
		///  pending:	Default.The request is being prepared.
		///  active:	Cancellation activated. 
		/// </summary>
		public string status { get; set; }

		/// <summary>
		/// Protocol of Tender Committee with decision to cancel the Tender. 
		/// </summary>
		public ProzzoroDocument[] documents { get; set; }

		/// <summary>
		/// The reason, why Tender is being cancelled. 
		/// </summary>
		public string reason { get; set; }

		/// <summary>
		/// The reason type. 
		/// </summary>
		public string reasonType { get; set; }

		/// <summary>
		/// Cancellation date. 
		/// </summary>
		public string date { get; set; }

		/// <summary>
		/// The cancellation of possible values are:
		///  tender, lot. 
		/// </summary>
		public string cancellationOf { get; set; }

		/// <summary>
		/// The identifier of related Lot. 
		/// </summary>
		public string relatedLot { get; set; }

	}

	///<summary>
	/// Implementation class of Lot. Used when need get information about tender lot. 
	/// </summary>
	public class ProzzoroLot
	{
		/// <summary>
		/// The main lot identifier. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The status of lot.
		///  Possible values are:active:	Active tender lot (active)
		///  unsuccessful:	Unsuccessful tender lot(unsuccessful)
		///  complete:	Complete tender lot(complete)
		///  cancelled:	Cancelled tender lot(cancelled) 
		/// </summary>
		public string status { get; set; }

		/// <summary>
		/// Detailed description of tender lot. 
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// Array of document. 
		/// </summary>
		public ProzzoroDocument[] documents { get; set; }

		/// <summary>
		/// The name of tender lot. 
		/// </summary>
		public string title { get; set; }

		/// <summary>
		/// The minimal step of auction. 
		/// </summary>
		public ProzzoroValue minimalStep { get; set; }

		/// <summary>
		/// Total available tender lot budget. 
		/// </summary>
		public ProzzoroValue value { get; set; }

		/// <summary>
		/// When created. 
		/// </summary>
		public string date { get; set; }

		/// <summary>
		/// Bid guarantee. 
		/// </summary>
		public ProzzoroGuarantee guarantee { get; set; }

		/// <summary>
		/// The Cancellation object describes the reason of lot cancellation contains accompanying documents if any. 
		/// </summary>
		public ProzzoroCancellation[] cancellations { get; set; }

	}

	///<summary>
	/// Implementation class of Supplier. 
	/// </summary>
	public class ProzzoroSupplier
	{
		/// <summary>
		/// The contact point. 
		/// </summary>
		public ProzzoroContactPoint contactPoint { get; set; }

		/// <summary>
		/// The name an english. 
		/// </summary>
		public string name_en { get; set; }

		/// <summary>
		/// The identifier. 
		/// </summary>
		public ProzzoroIdentifier identifier { get; set; }

		/// <summary>
		/// The name. 
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// The address. 
		/// </summary>
		public ProzzoroAddress address { get; set; }

	}

	///<summary>
	/// Implementation class of Award. Used when need get information about tender award. 
	/// </summary>
	public class ProzzoroAward
	{
		/// <summary>
		/// The main award identifier. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The status. 
		/// </summary>
		public string status { get; set; }

		/// <summary>
		/// All documents and attachments related to the award, including any notices. 
		/// </summary>
		public ProzzoroDocument[] documents { get; set; }

		/// <summary>
		/// The timeframe when complaints can be submitted. 
		/// </summary>
		public ProzzoroPeriod complaintPeriod { get; set; }

		/// <summary>
		/// The suppliers awarded with this award. 
		/// </summary>
		public ProzzoroSupplier[] suppliers { get; set; }

		/// <summary>
		/// A value indicating whether award is eligible.
		/// true - the award is eligible.false - the award is not eligible. 
		/// </summary>
		public Boolean eligible { get; set; }

		/// <summary>
		/// The Id of a bid that the award relates to. 
		/// </summary>
		public string bid_id { get; set; }

		/// <summary>
		/// The total value of this award. 
		/// </summary>
		public ProzzoroValue value { get; set; }

		/// <summary>
		/// A value indicating whether the award is qualified.
		/// true - the award is qualified.false - the award is not qualified. 
		/// </summary>
		public Boolean qualified { get; set; }

		/// <summary>
		/// The date of the contract award. 
		/// </summary>
		public string date { get; set; }

	}

	///<summary>
	/// Implementation class of Classification. 
	/// </summary>
	public class ProzzoroClassification
	{
		/// <summary>
		/// The classification identifier. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The scheme. 
		/// </summary>
		public string scheme { get; set; }

		/// <summary>
		/// The description. 
		/// </summary>
		public string description { get; set; }

	}

	///<summary>
	/// Implementation class of Unit. 
	/// </summary>
	public class ProzzoroUnit
	{
		/// <summary>
		/// The code. 
		/// </summary>
		public string code { get; set; }

		/// <summary>
		/// The name. 
		/// </summary>
		public string name { get; set; }

	}

	///<summary>
	/// Implementation class of Item. 
	/// </summary>
	public class ProzzoroItem
	{
		/// <summary>
		/// The item identifier. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The description about item. 
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// The item classfication. 
		/// </summary>
		public ProzzoroClassification classification { get; set; }

		/// <summary>
		/// The array of item additional classification. 
		/// </summary>
		public ProzzoroClassification[] additionalClassifications { get; set; }

		/// <summary>
		/// The customer address. 
		/// </summary>
		public ProzzoroAddress deliveryAddress { get; set; }

		/// <summary>
		/// The delivery date. 
		/// </summary>
		public ProzzoroPeriod deliveryDate { get; set; }

		/// <summary>
		/// The unit. 
		/// </summary>
		public ProzzoroUnit unit { get; set; }

		/// <summary>
		/// The quantity. 
		/// </summary>
		public Int32 quantity { get; set; }

	}

	///<summary>
	/// Implementation class of Tenderer. 
	/// </summary>
	public class ProzzoroTenderer
	{
		/// <summary>
		/// The contact point. 
		/// </summary>
		public ProzzoroContactPoint contactPoint { get; set; }

		/// <summary>
		/// The name en. 
		/// </summary>
		public string name_en { get; set; }

		/// <summary>
		/// The identifier. 
		/// </summary>
		public ProzzoroIdentifier identifier { get; set; }

		/// <summary>
		/// The name. 
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// The address. 
		/// </summary>
		public ProzzoroAddress address { get; set; }

	}

	///<summary>
	/// Implementation class of Bid. Used when need get information about tender bid. 
	/// </summary>
	public class ProzzoroBid
	{
		/// <summary>
		/// The main bid identifier. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// Possible status values are:
		/// draft,active 
		/// </summary>
		public string status { get; set; }

		/// <summary>
		/// The array of document. 
		/// </summary>
		public ProzzoroDocument[] documents { get; set; }

		/// <summary>
		/// A value of whether bid self-eligible.
		/// true - bid self-eigible.
		/// false - bid not self-eigible. 
		/// </summary>
		public Boolean selfEligible { get; set; }

		/// <summary>
		/// The cost of bid. 
		/// </summary>
		public ProzzoroValue value { get; set; }

		/// <summary>
		/// A value indicating whether bid self-qualified.
		/// true - bid self-qualified.
		/// false - bid not self-qualified. 
		/// </summary>
		public Boolean selfQualified { get; set; }

		/// <summary>
		/// The array of tenderer. 
		/// </summary>
		public ProzzoroTenderer[] tenderers { get; set; }

		/// <summary>
		/// The date. 
		/// </summary>
		public string date { get; set; }

		/// <summary>
		/// The participation URL. 
		/// </summary>
		public string participationUrl { get; set; }

	}

	///<summary>
	/// Implementation class of Contract. Used when need get information about tender contract. 
	/// </summary>
	public class ProzzoroContract
	{
		/// <summary>
		/// The main contract identifier. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The contact status.
		///   Possible values are:
		///   pending - this contract has been proposed, but is not yet in force. It may be awaiting signature.
		///   active - this contract has been signed by all the parties, and is now legally in force.
		///   cancelled - this contract has been cancelled prior to being signed. 
		/// </summary>
		public string status { get; set; }

		/// <summary>
		/// All documents and attachments related to the contract, including any notices. 
		/// </summary>
		public ProzzoroDocument[] documents { get; set; }

		/// <summary>
		/// Array of item in this contract. 
		/// </summary>
		public ProzzoroItem[] items { get; set; }

		/// <summary>
		/// The array of supplier. 
		/// </summary>
		public ProzzoroSupplier[] suppliers { get; set; }

		/// <summary>
		/// The number of contracts. 
		/// </summary>
		public string contractNumber { get; set; }

		/// <summary>
		/// The start and end date for the contract. 
		/// </summary>
		public ProzzoroPeriod period { get; set; }

		/// <summary>
		/// The date when the contract was signed. 
		/// </summary>
		public string dateSigned { get; set; }

		/// <summary>
		/// The total value of this contract. 
		/// </summary>
		public ProzzoroValue value { get; set; }

		/// <summary>
		/// The date when the contract was changed or activated. 
		/// </summary>
		public string date { get; set; }

		/// <summary>
		/// The awardId against which this contract is being issued. 
		/// </summary>
		public string awardID { get; set; }

		/// <summary>
		/// The secondary contract identifiery. 
		/// </summary>
		public string contractID { get; set; }

	}

	///<summary>
	/// Implementation class of Tender. 
	/// </summary>
	public class ProzzoroTender
	{
		/// <summary>
		/// The main tender identifier. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The procurement method. 
		/// </summary>
		public string procurementMethod { get; set; }

		/// <summary>
		/// The number of bid. 
		/// </summary>
		public Int32 numberOfBids { get; set; }

		/// <summary>
		/// The  awarding process period. 
		/// </summary>
		public ProzzoroPeriod awardPeriod { get; set; }

		/// <summary>
		/// The complaint period. 
		/// </summary>
		public ProzzoroPeriod complaintPeriod { get; set; }

		/// <summary>
		/// The auction URL. 
		/// </summary>
		public string auctionUrl { get; set; }

		/// <summary>
		/// The period when questions are allowed. At least endDate has to be provided. 
		/// </summary>
		public ProzzoroPeriod enquiryPeriod { get; set; }

		/// <summary>
		/// The submission method. 
		/// </summary>
		public string submissionMethod { get; set; }

		/// <summary>
		/// The organization conducting the tender. 
		/// </summary>
		public ProcuringEntity procuringEntity { get; set; }

		/// <summary>
		/// The owner of tender. 
		/// </summary>
		public string owner { get; set; }

		/// <summary>
		/// The description about tender. 
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// All documents and attachments related to the tender. 
		/// </summary>
		public ProzzoroDocument[] document { get; set; }

		/// <summary>
		/// Complaints to tender conditions and their resolutions. 
		/// </summary>
		public ProzzoroComplaint[] complaints { get; set; }

		/// <summary>
		/// Can contain all tender lots. 
		/// </summary>
		public ProzzoroLot[] lots { get; set; }

		/// <summary>
		/// The name of the tender. 
		/// </summary>
		public string title { get; set; }

		/// <summary>
		/// The tender identifier to refer tender to in "paper" documentation. 
		/// </summary>
		public string tenderID { get; set; }

		/// <summary>
		/// The bid guarantee. 
		/// </summary>
		public ProzzoroGuarantee guarantee { get; set; }

		/// <summary>
		/// Date modified when tender was modified. 
		/// </summary>
		public string dateModified { get; set; }

		/// <summary>
		/// The status of the tender.
		///  Here is some value can be returned:
		///  active.enquiries:Enquiries period(enquiries)
		///  active.tendering: Tendering period(tendering)
		///  active.auction:	Auction period(auction)
		///  active.qualification: Winner qualification(qualification)
		///  active.awarded:	Standstill period (standstill)
		///  unsuccessful:	Unsuccessful tender(unsuccessful)
		///  complete:	Complete tender(complete)
		///  cancelled:	Cancelled tender(cancelled) 
		/// </summary>
		public string status { get; set; }

		/// <summary>
		/// Period when bids can be submitted. At least endDate has to be provided. 
		/// </summary>
		public ProzzoroPeriod tenderPeriod { get; set; }

		/// <summary>
		/// Period when auction is conducted. 
		/// </summary>
		public ProzzoroPeriod auctionPeriod { get; set; }

		/// <summary>
		/// The type of the procurement method. 
		/// </summary>
		public string procurementMethodType { get; set; }

		/// <summary>
		/// The all qualifications (disqualifications and awards).. 
		/// </summary>
		public ProzzoroAward[] awards { get; set; }

		/// <summary>
		/// The date. 
		/// </summary>
		public string date { get; set; }

		/// <summary>
		/// The minimal step of auction (reduction). 
		/// </summary>
		public ProzzoroValue minimalStep { get; set; }

		/// <summary>
		/// The list that contains single item being procured. 
		/// </summary>
		public ProzzoroItem[] items { get; set; }

		/// <summary>
		/// A list of all bid placed in the tender with information about tenderers, 
		/// their proposal and other qualification documentation. 
		/// </summary>
		public ProzzoroBid[] bids { get; set; }

		/// <summary>
		/// The array of contract. 
		/// </summary>
		public ProzzoroContract[] contracts { get; set; }

		/// <summary>
		/// The Cancellation object describes the reason of tender cancellation contains accompanying documents if any. 
		/// </summary>
		public ProzzoroCancellation[] cancellations { get; set; }

		/// <summary>
		/// The total available tender budget. 
		/// </summary>
		public ProzzoroValue budget { get; set; }

		/// <summary>
		/// The award criteria. 
		/// </summary>
		public string awardCriteria { get; set; }

	}

}