package bNesis.Sdk.GovRegistry.Prozzoro;

import java.io.*;
import java.util.List;
import java.util.Date;
import java.util.Map.Entry;
import bNesis.Api.*;

import bNesis.Sdk.Common.*;
import java.net.URI.*;
import bNesis.Sdk.GovRegistry.Prozzoro.*;

	public class Prozzoro  
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

		public Prozzoro(bNesisApi bnesisApi)
		{
			this._bNesisApi = bnesisApi;
		}

		/**
		 * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		 * @return {String} bNesisToken value
		 */
		public String Auth(String bNesisDevId,String redirectUrl) throws Exception
		{
			bNesisToken = _bNesisApi.Auth("Prozzoro", "",bNesisDevId,redirectUrl,"","",null,"","",false,"");
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
			Boolean result = _bNesisApi.LogoffService("Prozzoro", bNesisToken);
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
			return _bNesisApi.<ErrorInfo>Call(ErrorInfo.class, "Prozzoro", bNesisToken, "GetLastError");
		}

		/**
		 *  Getting arrays of error info 	
		 * @return {ErrorInfo[]}  
		 * @throws Exception
		 */
		public ErrorInfo[] GetErrorLog() throws Exception
		{
			return _bNesisApi.<ErrorInfo[]>Call(ErrorInfo[].class, "Prozzoro", bNesisToken, "GetErrorLog");
		}

		/**
		 *  Checks the token in the service. 	
		 * @return {Boolean} if token valid return true, if token not valid return false 
		 * @throws Exception
		 */
		public Boolean ValidateToken() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "Prozzoro", bNesisToken, "ValidateToken");
		}

		/**
		 *  Disables the access token used to authenticate the call. 	
		 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false 
		 * @throws Exception
		 */
		public Boolean Logoff() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "Prozzoro", bNesisToken, "Logoff");
		}

		/**
		 *  Gets the tender contract documents. 	
		 * @param tenderId The tender uid.
	 * @param contractId The contract uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetTenderContractDocumentsRaw(String tenderId, String contractId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "GetTenderContractDocumentsRaw", tenderId, contractId);
		}

		/**
		 *  Gets the tender contract document. 	
		 * @param tenderId The tender uid.
	 * @param contractId The contract uid.
	 * @param documentId The contract document uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetTenderContractDocumentRaw(String tenderId, String contractId, String documentId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "GetTenderContractDocumentRaw", tenderId, contractId, documentId);
		}

		/**
		 *  Downloads the tender contract document. 	
		 * @param tenderId The tender uid.
	 * @param contractId The contract uid.
	 * @param documentId The contract document uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response DownloadTenderContractDocumentRaw(String tenderId, String contractId, String documentId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "DownloadTenderContractDocumentRaw", tenderId, contractId, documentId);
		}

		/**
		 *  Gets the tender lots. 	
		 * @param tenderId The tender uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetTenderLotsRaw(String tenderId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "GetTenderLotsRaw", tenderId);
		}

		/**
		 *  Gets the tender lot. 	
		 * @param tenderId The tender uid.
	 * @param lotId The lot uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetTenderLotRaw(String tenderId, String lotId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "GetTenderLotRaw", tenderId, lotId);
		}

		/**
		 *  Gets the tender lot documents. 	
		 * @param tenderId The tender uid.
	 * @param lotId The lot uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetTenderLotDocumentsRaw(String tenderId, String lotId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "GetTenderLotDocumentsRaw", tenderId, lotId);
		}

		/**
		 *  Gets the tender lot document. 	
		 * @param tenderId The tender uid.
	 * @param lotId The lot uid.
	 * @param documentId The lot document uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetTenderLotDocumentRaw(String tenderId, String lotId, String documentId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "GetTenderLotDocumentRaw", tenderId, lotId, documentId);
		}

		/**
		 *  Downloads the tender lot document. 	
		 * @param tenderId The tender uid.
	 * @param lotId The lot uid.
	 * @param documentId The lot document uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response DownloadTenderLotDocumentRaw(String tenderId, String lotId, String documentId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "DownloadTenderLotDocumentRaw", tenderId, lotId, documentId);
		}

		/**
		 *  Getting list of all tenders (Limit:100). 	
		 * @return {ProzzoroPageInfo} PageInfo. 
		 * @throws Exception
		 */
		public ProzzoroPageInfo GetTenders() throws Exception
		{
			return _bNesisApi.<ProzzoroPageInfo>Call(ProzzoroPageInfo.class, "Prozzoro", bNesisToken, "GetTenders");
		}

		/**
		 *  Getting list of all tenders in next page (Limit:100). 	
		 * @param offset Offset date time.
	 * @return {ProzzoroPageInfo} PageInfo. 
		 * @throws Exception
		 */
		public ProzzoroPageInfo GetTendersNext(String offset) throws Exception
		{
			return _bNesisApi.<ProzzoroPageInfo>Call(ProzzoroPageInfo.class, "Prozzoro", bNesisToken, "GetTendersNext", offset);
		}

		/**
		 *  Gets tender. 	
		 * @param tenderId The uid tender.
	 * @return {ProzzoroTender} Tender. 
		 * @throws Exception
		 */
		public ProzzoroTender GetTenderByIdentifier(String tenderId) throws Exception
		{
			return _bNesisApi.<ProzzoroTender>Call(ProzzoroTender.class, "Prozzoro", bNesisToken, "GetTenderByIdentifier", tenderId);
		}

		/**
		 *  Gets the tender documents. 	
		 * @param tenderId The tender uid.
	 * @return {ProzzoroDocument[]} Array of Document. 
		 * @throws Exception
		 */
		public ProzzoroDocument[] GetTenderDocuments(String tenderId) throws Exception
		{
			return _bNesisApi.<ProzzoroDocument[]>Call(ProzzoroDocument[].class, "Prozzoro", bNesisToken, "GetTenderDocuments", tenderId);
		}

		/**
		 *  Gets the tender document. 	
		 * @param tenderId The tender uid.
	 * @param documentId The document uid.
	 * @return {ProzzoroDocument} Document. 
		 * @throws Exception
		 */
		public ProzzoroDocument GetTenderDocument(String tenderId, String documentId) throws Exception
		{
			return _bNesisApi.<ProzzoroDocument>Call(ProzzoroDocument.class, "Prozzoro", bNesisToken, "GetTenderDocument", tenderId, documentId);
		}

		/**
		 *  Downloads the tender document. 	
		 * @param tenderId The tender uid.
	 * @param documentId The document uid.
	 * @return {OutputStream} Stream. 
		 * @throws Exception
		 */
		public OutputStream DownloadTenderDocument(String tenderId, String documentId) throws Exception
		{
			return _bNesisApi.<OutputStream>Call(OutputStream.class, "Prozzoro", bNesisToken, "DownloadTenderDocument", tenderId, documentId);
		}

		/**
		 *  Gets the tender bids. 	
		 * @param id The uid tender.
	 * @return {ProzzoroBid[]} Array of Bid. 
		 * @throws Exception
		 */
		public ProzzoroBid[] GetTenderBids(String id) throws Exception
		{
			return _bNesisApi.<ProzzoroBid[]>Call(ProzzoroBid[].class, "Prozzoro", bNesisToken, "GetTenderBids", id);
		}

		/**
		 *  Gets the tender bid. 	
		 * @param tenderId The tender uid.
	 * @param bidId The bid uid.
	 * @return {ProzzoroBid} Bid. 
		 * @throws Exception
		 */
		public ProzzoroBid GetTenderBid(String tenderId, String bidId) throws Exception
		{
			return _bNesisApi.<ProzzoroBid>Call(ProzzoroBid.class, "Prozzoro", bNesisToken, "GetTenderBid", tenderId, bidId);
		}

		/**
		 *  Gets the tender bid documents. 	
		 * @param tenderId The tender uid.
	 * @param bidId The bid uid.
	 * @return {ProzzoroDocument[]} Array of Document. 
		 * @throws Exception
		 */
		public ProzzoroDocument[] GetTenderBidDocuments(String tenderId, String bidId) throws Exception
		{
			return _bNesisApi.<ProzzoroDocument[]>Call(ProzzoroDocument[].class, "Prozzoro", bNesisToken, "GetTenderBidDocuments", tenderId, bidId);
		}

		/**
		 *  Gets the tender bid document. 	
		 * @param tenderId The tender uid.
	 * @param bidId The bid uid.
	 * @param documentId The bid document uid.
	 * @return {ProzzoroDocument} Document. 
		 * @throws Exception
		 */
		public ProzzoroDocument GetTenderBidDocument(String tenderId, String bidId, String documentId) throws Exception
		{
			return _bNesisApi.<ProzzoroDocument>Call(ProzzoroDocument.class, "Prozzoro", bNesisToken, "GetTenderBidDocument", tenderId, bidId, documentId);
		}

		/**
		 *  Downloads the tender bid document. 	
		 * @param tenderId The tender uid.
	 * @param bidId The bid uid.
	 * @param documentId The bid document uid.
	 * @return {OutputStream} Stream. 
		 * @throws Exception
		 */
		public OutputStream DownloadTenderBidDocument(String tenderId, String bidId, String documentId) throws Exception
		{
			return _bNesisApi.<OutputStream>Call(OutputStream.class, "Prozzoro", bNesisToken, "DownloadTenderBidDocument", tenderId, bidId, documentId);
		}

		/**
		 *  Gets the tender awards. 	
		 * @param tenderId The uid tender.
	 * @return {ProzzoroAward[]} Array of Award. 
		 * @throws Exception
		 */
		public ProzzoroAward[] GetTenderAwards(String tenderId) throws Exception
		{
			return _bNesisApi.<ProzzoroAward[]>Call(ProzzoroAward[].class, "Prozzoro", bNesisToken, "GetTenderAwards", tenderId);
		}

		/**
		 *  Gets the tender award. 	
		 * @param tenderId The tender uid.
	 * @param awardId The award uid.
	 * @return {ProzzoroAward} Award. 
		 * @throws Exception
		 */
		public ProzzoroAward GetTenderAward(String tenderId, String awardId) throws Exception
		{
			return _bNesisApi.<ProzzoroAward>Call(ProzzoroAward.class, "Prozzoro", bNesisToken, "GetTenderAward", tenderId, awardId);
		}

		/**
		 *  Gets the tender award documents. 	
		 * @param tenderId The tender uid.
	 * @param awardId The award uid.
	 * @return {ProzzoroDocument[]} Array of Document. 
		 * @throws Exception
		 */
		public ProzzoroDocument[] GetTenderAwardDocuments(String tenderId, String awardId) throws Exception
		{
			return _bNesisApi.<ProzzoroDocument[]>Call(ProzzoroDocument[].class, "Prozzoro", bNesisToken, "GetTenderAwardDocuments", tenderId, awardId);
		}

		/**
		 *  Gets the tender award document. 	
		 * @param tenderId The tender uid.
	 * @param awardId The award uid.
	 * @param documentId The award document uid.
	 * @return {ProzzoroDocument} Document. 
		 * @throws Exception
		 */
		public ProzzoroDocument GetTenderAwardDocument(String tenderId, String awardId, String documentId) throws Exception
		{
			return _bNesisApi.<ProzzoroDocument>Call(ProzzoroDocument.class, "Prozzoro", bNesisToken, "GetTenderAwardDocument", tenderId, awardId, documentId);
		}

		/**
		 *  Downloads the tender award document. 	
		 * @param tenderId The tender uid.
	 * @param awardId The award uid.
	 * @param documentId The award document uid.
	 * @return {OutputStream} Stream. 
		 * @throws Exception
		 */
		public OutputStream DownloadTenderAwardDocument(String tenderId, String awardId, String documentId) throws Exception
		{
			return _bNesisApi.<OutputStream>Call(OutputStream.class, "Prozzoro", bNesisToken, "DownloadTenderAwardDocument", tenderId, awardId, documentId);
		}

		/**
		 *  Gets the tender cancellations. 	
		 * @param tenderId The tender uid.
	 * @return {ProzzoroCancellation[]} Array of Cancellation. 
		 * @throws Exception
		 */
		public ProzzoroCancellation[] GetTenderCancellations(String tenderId) throws Exception
		{
			return _bNesisApi.<ProzzoroCancellation[]>Call(ProzzoroCancellation[].class, "Prozzoro", bNesisToken, "GetTenderCancellations", tenderId);
		}

		/**
		 *  Gets the tender cancellation. 	
		 * @param tenderId The tender uid.
	 * @param cancellationId The cancellation uid.
	 * @return {ProzzoroCancellation} Cancellation. 
		 * @throws Exception
		 */
		public ProzzoroCancellation GetTenderCancellation(String tenderId, String cancellationId) throws Exception
		{
			return _bNesisApi.<ProzzoroCancellation>Call(ProzzoroCancellation.class, "Prozzoro", bNesisToken, "GetTenderCancellation", tenderId, cancellationId);
		}

		/**
		 *  Gets the tender cancellation documents. 	
		 * @param tenderId The tender uid.
	 * @param cancellationId The cancellation uid.
	 * @return {ProzzoroDocument[]} Array of Document. 
		 * @throws Exception
		 */
		public ProzzoroDocument[] GetTenderCancellationDocuments(String tenderId, String cancellationId) throws Exception
		{
			return _bNesisApi.<ProzzoroDocument[]>Call(ProzzoroDocument[].class, "Prozzoro", bNesisToken, "GetTenderCancellationDocuments", tenderId, cancellationId);
		}

		/**
		 *  Gets the tender cancellation document. 	
		 * @param tenderId The tender uid.
	 * @param cancellationId The cancellation uid.
	 * @param documentId The award document uid.
	 * @return {ProzzoroDocument} Document. 
		 * @throws Exception
		 */
		public ProzzoroDocument GetTenderCancellationDocument(String tenderId, String cancellationId, String documentId) throws Exception
		{
			return _bNesisApi.<ProzzoroDocument>Call(ProzzoroDocument.class, "Prozzoro", bNesisToken, "GetTenderCancellationDocument", tenderId, cancellationId, documentId);
		}

		/**
		 *  Downloads the tender cancellation document. 	
		 * @param tenderId The tender uid.
	 * @param cancellationId The cancellation uid.
	 * @param documentId The award document uid.
	 * @return {OutputStream} Stream. 
		 * @throws Exception
		 */
		public OutputStream DownloadTenderCancellationDocument(String tenderId, String cancellationId, String documentId) throws Exception
		{
			return _bNesisApi.<OutputStream>Call(OutputStream.class, "Prozzoro", bNesisToken, "DownloadTenderCancellationDocument", tenderId, cancellationId, documentId);
		}

		/**
		 *  Gets the tender complaints. 	
		 * @param tenderId The tender uid.
	 * @return {ProzzoroComplaint[]} Array of complaint. 
		 * @throws Exception
		 */
		public ProzzoroComplaint[] GetTenderComplaints(String tenderId) throws Exception
		{
			return _bNesisApi.<ProzzoroComplaint[]>Call(ProzzoroComplaint[].class, "Prozzoro", bNesisToken, "GetTenderComplaints", tenderId);
		}

		/**
		 *  Gets the tender complaint. 	
		 * @param tenderId The tender uid.
	 * @param complaintId The complaint uid.
	 * @return {ProzzoroComplaint} Complaint. 
		 * @throws Exception
		 */
		public ProzzoroComplaint GetTenderComplaint(String tenderId, String complaintId) throws Exception
		{
			return _bNesisApi.<ProzzoroComplaint>Call(ProzzoroComplaint.class, "Prozzoro", bNesisToken, "GetTenderComplaint", tenderId, complaintId);
		}

		/**
		 *  Gets the tender complaint documents. 	
		 * @param tenderId The tender uid.
	 * @param complaintId The complaint uid.
	 * @return {ProzzoroDocument[]} Array of Document. 
		 * @throws Exception
		 */
		public ProzzoroDocument[] GetTenderComplaintDocuments(String tenderId, String complaintId) throws Exception
		{
			return _bNesisApi.<ProzzoroDocument[]>Call(ProzzoroDocument[].class, "Prozzoro", bNesisToken, "GetTenderComplaintDocuments", tenderId, complaintId);
		}

		/**
		 *  Gets the tender complaint document. 	
		 * @param tenderId The tender uid.
	 * @param complaintId The complaint uid.
	 * @param documentId The complaint document uid.
	 * @return {ProzzoroDocument} Document. 
		 * @throws Exception
		 */
		public ProzzoroDocument GetTenderComplaintDocument(String tenderId, String complaintId, String documentId) throws Exception
		{
			return _bNesisApi.<ProzzoroDocument>Call(ProzzoroDocument.class, "Prozzoro", bNesisToken, "GetTenderComplaintDocument", tenderId, complaintId, documentId);
		}

		/**
		 *  Downloads the tender complaint document. 	
		 * @param tenderId The tender uid.
	 * @param complaintId The complaint uid.
	 * @param documentId The complaint document uid.
	 * @return {OutputStream} Stream. 
		 * @throws Exception
		 */
		public OutputStream DownloadTenderComplaintDocument(String tenderId, String complaintId, String documentId) throws Exception
		{
			return _bNesisApi.<OutputStream>Call(OutputStream.class, "Prozzoro", bNesisToken, "DownloadTenderComplaintDocument", tenderId, complaintId, documentId);
		}

		/**
		 *  Gets the tender contracts. 	
		 * @param tenderId The tender uid.
	 * @return {ProzzoroContract[]} Array of Contracts. 
		 * @throws Exception
		 */
		public ProzzoroContract[] GetTenderContracts(String tenderId) throws Exception
		{
			return _bNesisApi.<ProzzoroContract[]>Call(ProzzoroContract[].class, "Prozzoro", bNesisToken, "GetTenderContracts", tenderId);
		}

		/**
		 *  Gets the tender contract. 	
		 * @param tenderId The tender uid.
	 * @param contractId The contract uid.
	 * @return {ProzzoroContract} Contract. 
		 * @throws Exception
		 */
		public ProzzoroContract GetTenderContract(String tenderId, String contractId) throws Exception
		{
			return _bNesisApi.<ProzzoroContract>Call(ProzzoroContract.class, "Prozzoro", bNesisToken, "GetTenderContract", tenderId, contractId);
		}

		/**
		 *  Gets the tender contract documents. 	
		 * @param tenderId The tender uid.
	 * @param contractId The contract uid.
	 * @return {ProzzoroDocument[]} Array of Document. 
		 * @throws Exception
		 */
		public ProzzoroDocument[] GetTenderContractDocuments(String tenderId, String contractId) throws Exception
		{
			return _bNesisApi.<ProzzoroDocument[]>Call(ProzzoroDocument[].class, "Prozzoro", bNesisToken, "GetTenderContractDocuments", tenderId, contractId);
		}

		/**
		 *  Gets the tender contract document. 	
		 * @param tenderId The tender uid.
	 * @param contractId The contract uid.
	 * @param documentId The contract document uid.
	 * @return {ProzzoroDocument} Document. 
		 * @throws Exception
		 */
		public ProzzoroDocument GetTenderContractDocument(String tenderId, String contractId, String documentId) throws Exception
		{
			return _bNesisApi.<ProzzoroDocument>Call(ProzzoroDocument.class, "Prozzoro", bNesisToken, "GetTenderContractDocument", tenderId, contractId, documentId);
		}

		/**
		 *  Downloads the tender contract document. 	
		 * @param tenderId The tender uid.
	 * @param contractId The contract uid.
	 * @param documentId The contract document uid.
	 * @return {OutputStream} Stream. 
		 * @throws Exception
		 */
		public OutputStream DownloadTenderContractDocument(String tenderId, String contractId, String documentId) throws Exception
		{
			return _bNesisApi.<OutputStream>Call(OutputStream.class, "Prozzoro", bNesisToken, "DownloadTenderContractDocument", tenderId, contractId, documentId);
		}

		/**
		 *  Gets the tender lots. 	
		 * @param tenderId The tender uid.
	 * @return {ProzzoroLot[]} Array of lot. 
		 * @throws Exception
		 */
		public ProzzoroLot[] GetTenderLots(String tenderId) throws Exception
		{
			return _bNesisApi.<ProzzoroLot[]>Call(ProzzoroLot[].class, "Prozzoro", bNesisToken, "GetTenderLots", tenderId);
		}

		/**
		 *  Gets the tender lot. 	
		 * @param tenderId The tender uid.
	 * @param lotId The lot uid.
	 * @return {ProzzoroLot} Lot. 
		 * @throws Exception
		 */
		public ProzzoroLot GetTenderLot(String tenderId, String lotId) throws Exception
		{
			return _bNesisApi.<ProzzoroLot>Call(ProzzoroLot.class, "Prozzoro", bNesisToken, "GetTenderLot", tenderId, lotId);
		}

		/**
		 *  Gets the tender lot documents. 	
		 * @param tenderId The tender uid.
	 * @param lotId The lot uid.
	 * @return {ProzzoroDocument[]} Array of Document. 
		 * @throws Exception
		 */
		public ProzzoroDocument[] GetTenderLotDocuments(String tenderId, String lotId) throws Exception
		{
			return _bNesisApi.<ProzzoroDocument[]>Call(ProzzoroDocument[].class, "Prozzoro", bNesisToken, "GetTenderLotDocuments", tenderId, lotId);
		}

		/**
		 *  Gets the tender lot document. 	
		 * @param tenderId The tender uid.
	 * @param lotId The lot uid.
	 * @param documentId The lot document uid.
	 * @return {ProzzoroDocument} Document. 
		 * @throws Exception
		 */
		public ProzzoroDocument GetTenderLotDocument(String tenderId, String lotId, String documentId) throws Exception
		{
			return _bNesisApi.<ProzzoroDocument>Call(ProzzoroDocument.class, "Prozzoro", bNesisToken, "GetTenderLotDocument", tenderId, lotId, documentId);
		}

		/**
		 *  Downloads the tender lot document. 	
		 * @param tenderId The tender uid.
	 * @param lotId The lot uid.
	 * @param documentId The lot document uid.
	 * @return {OutputStream} Stream. 
		 * @throws Exception
		 */
		public OutputStream DownloadTenderLotDocument(String tenderId, String lotId, String documentId) throws Exception
		{
			return _bNesisApi.<OutputStream>Call(OutputStream.class, "Prozzoro", bNesisToken, "DownloadTenderLotDocument", tenderId, lotId, documentId);
		}

		/**
		 *  Gets list of all tender(Limit:100). 	
		 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetTendersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "GetTendersRaw");
		}

		/**
		 *  Gets list of all tender(Limit:100) in next page. 	
		 * @param offset Offset date time.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetTendersInNextPageRaw(String offset) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "GetTendersInNextPageRaw", offset);
		}

		/**
		 *  Gets the tender. 	
		 * @param tenderId The tender uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetTenderByIdentifierRaw(String tenderId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "GetTenderByIdentifierRaw", tenderId);
		}

		/**
		 *  Gets the tender documents. 	
		 * @param tenderId The tender uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetTenderDocumentsRaw(String tenderId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "GetTenderDocumentsRaw", tenderId);
		}

		/**
		 *  Gets the tender document. 	
		 * @param tenderId The tender uid.
	 * @param documentId The tender document uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetTenderDocumentRaw(String tenderId, String documentId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "GetTenderDocumentRaw", tenderId, documentId);
		}

		/**
		 *  Downloads the tender document. 	
		 * @param tenderId The tender uid.
	 * @param documentId The tender document uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response DownloadTenderDocumentRaw(String tenderId, String documentId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "DownloadTenderDocumentRaw", tenderId, documentId);
		}

		/**
		 *  Gets the tender bids. 	
		 * @param tenderId The tender uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetTenderBidsRaw(String tenderId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "GetTenderBidsRaw", tenderId);
		}

		/**
		 *  Gets the tender bid. 	
		 * @param tenderId The tender uid.
	 * @param bidId The bid uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetTenderBidRaw(String tenderId, String bidId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "GetTenderBidRaw", tenderId, bidId);
		}

		/**
		 *  Gets the tender bid documents. 	
		 * @param tenderId The tender uid.
	 * @param bidId The bid uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetTenderBidDocumentsRaw(String tenderId, String bidId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "GetTenderBidDocumentsRaw", tenderId, bidId);
		}

		/**
		 *  Gets the tender bid document. 	
		 * @param tenderId The tender uid.
	 * @param bidId The bid uid.
	 * @param documentId The bid document uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetTenderBidDocumentRaw(String tenderId, String bidId, String documentId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "GetTenderBidDocumentRaw", tenderId, bidId, documentId);
		}

		/**
		 *  Downloads the tender bid document. 	
		 * @param tenderId The tender uid.
	 * @param bidId The bid uid.
	 * @param documentId The bid document uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response DownloadTenderBidDocumentRaw(String tenderId, String bidId, String documentId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "DownloadTenderBidDocumentRaw", tenderId, bidId, documentId);
		}

		/**
		 *  Gets the tender awards. 	
		 * @param id The tender uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetTenderAwardsRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "GetTenderAwardsRaw", id);
		}

		/**
		 *  Gets the tender award. 	
		 * @param tenderId The tender uid.
	 * @param awardId The award uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetTenderAwardRaw(String tenderId, String awardId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "GetTenderAwardRaw", tenderId, awardId);
		}

		/**
		 *  Gets the tender award documents. 	
		 * @param tenderId The tender uid.
	 * @param awardId The award uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetTenderAwardDocumentsRaw(String tenderId, String awardId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "GetTenderAwardDocumentsRaw", tenderId, awardId);
		}

		/**
		 *  Gets the tender award document. 	
		 * @param tenderId The tender uid.
	 * @param awardId The award uid.
	 * @param documentId The award document uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetTenderAwardDocumentRaw(String tenderId, String awardId, String documentId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "GetTenderAwardDocumentRaw", tenderId, awardId, documentId);
		}

		/**
		 *  Downloads the tender award document. 	
		 * @param tenderId The tender uid.
	 * @param awardId The award uid.
	 * @param documentId The award document uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response DownloadTenderAwardDocumentRaw(String tenderId, String awardId, String documentId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "DownloadTenderAwardDocumentRaw", tenderId, awardId, documentId);
		}

		/**
		 *  Gets the tender cancellations. 	
		 * @param tenderId The tender uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetTenderCancellationsRaw(String tenderId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "GetTenderCancellationsRaw", tenderId);
		}

		/**
		 *  Gets the tender cancellation. 	
		 * @param tenderId The tender uid.
	 * @param cancellationId The cancellation uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetTenderCancellationRaw(String tenderId, String cancellationId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "GetTenderCancellationRaw", tenderId, cancellationId);
		}

		/**
		 *  Gets the tender cancellation documents. 	
		 * @param tenderId The tender uid.
	 * @param cancellationId The cancellation uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetTenderCancellationDocumentsRaw(String tenderId, String cancellationId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "GetTenderCancellationDocumentsRaw", tenderId, cancellationId);
		}

		/**
		 *  Gets the tender cancellation document. 	
		 * @param tenderId The tender uid.
	 * @param cancellationId The cancellation uid.
	 * @param documentId The award document uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetTenderCancellationDocumentRaw(String tenderId, String cancellationId, String documentId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "GetTenderCancellationDocumentRaw", tenderId, cancellationId, documentId);
		}

		/**
		 *  Downloads the tender cancellation document. 	
		 * @param tenderId The tender uid.
	 * @param cancellationId The cancellation uid.
	 * @param documentId The award document uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response DownloadTenderCancellationDocumentRaw(String tenderId, String cancellationId, String documentId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "DownloadTenderCancellationDocumentRaw", tenderId, cancellationId, documentId);
		}

		/**
		 *  Gets the tender complaints. 	
		 * @param tenderId The tender uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetTenderComplaintsRaw(String tenderId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "GetTenderComplaintsRaw", tenderId);
		}

		/**
		 *  Gets the tender complaint. 	
		 * @param tenderId The tender uid.
	 * @param complaintId The complaint uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetTenderComplaintRaw(String tenderId, String complaintId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "GetTenderComplaintRaw", tenderId, complaintId);
		}

		/**
		 *  Gets the tender complaint documents. 	
		 * @param tenderId The tender uid.
	 * @param complaintId The complaint uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetTenderComplaintDocumentsRaw(String tenderId, String complaintId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "GetTenderComplaintDocumentsRaw", tenderId, complaintId);
		}

		/**
		 *  Gets the tender complaint document. 	
		 * @param tenderId The tender uid.
	 * @param complaintId The complaint uid.
	 * @param documentId The complaint document uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetTenderComplaintDocumentRaw(String tenderId, String complaintId, String documentId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "GetTenderComplaintDocumentRaw", tenderId, complaintId, documentId);
		}

		/**
		 *  Downloads the tender complaint document. 	
		 * @param tenderId The tender uid.
	 * @param complaintId The complaint uid.
	 * @param documentId The complaint document uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response DownloadTenderComplaintDocumentRaw(String tenderId, String complaintId, String documentId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "DownloadTenderComplaintDocumentRaw", tenderId, complaintId, documentId);
		}

		/**
		 *  Gets the tender contracts. 	
		 * @param tenderId The tender uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetTenderContractsRaw(String tenderId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "GetTenderContractsRaw", tenderId);
		}

		/**
		 *  Gets the tender contract. 	
		 * @param tenderId The tender uid.
	 * @param contractId The contract uid.
	 * @return {Response} Response. 
		 * @throws Exception
		 */
		public Response GetTenderContractRaw(String tenderId, String contractId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Prozzoro", bNesisToken, "GetTenderContractRaw", tenderId, contractId);
		}
}