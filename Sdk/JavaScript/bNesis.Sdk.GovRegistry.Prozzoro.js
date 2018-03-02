Prozzoro = function (bNesisApi) {
    this.bNesisToken = null;
    var _bNesisApi = bNesisApi;

    this.Auth = function (data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl) {
        var bNesisToken = _bNesisApi.Auth("Prozzoro", data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl);
        return bNesisToken;
    }
	
	/**
	 *  Getting last exception for current provider 	
	 * @return {ErrorInfo} 
	 */
    this.GetLastError = function () {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetLastError");
        return result;
    }

	/**
	 *  Getting arrays of error info 	
	 * @return {ErrorInfo[]} 
	 */
    this.GetErrorLog = function () {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetErrorLog");
        return result;
    }

	/**
	 *  Checks the token in the service. 	
	 * @return {Boolean} if token valid return true, if token not valid return false
	 */
    this.ValidateToken = function () {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "ValidateToken");
        return result;
    }

	/**
	 *  Disables the access token used to authenticate the call. 	
	 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false
	 */
    this.Logoff = function () {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "Logoff");
        return result;
    }

	/**
	 *  Gets the tender contract documents. 	
	 * @param tenderId The tender uid.
	 * @param contractId The contract uid.
	 * @return {Response} Response.
	 */
    this.GetTenderContractDocumentsRaw = function (tenderId, contractId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderContractDocumentsRaw", tenderId, contractId);
        return result;
    }

	/**
	 *  Gets the tender contract document. 	
	 * @param tenderId The tender uid.
	 * @param contractId The contract uid.
	 * @param documentId The contract document uid.
	 * @return {Response} Response.
	 */
    this.GetTenderContractDocumentRaw = function (tenderId, contractId, documentId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderContractDocumentRaw", tenderId, contractId, documentId);
        return result;
    }

	/**
	 *  Downloads the tender contract document. 	
	 * @param tenderId The tender uid.
	 * @param contractId The contract uid.
	 * @param documentId The contract document uid.
	 * @return {Response} Response.
	 */
    this.DownloadTenderContractDocumentRaw = function (tenderId, contractId, documentId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "DownloadTenderContractDocumentRaw", tenderId, contractId, documentId);
        return result;
    }

	/**
	 *  Gets the tender lots. 	
	 * @param tenderId The tender uid.
	 * @return {Response} Response.
	 */
    this.GetTenderLotsRaw = function (tenderId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderLotsRaw", tenderId);
        return result;
    }

	/**
	 *  Gets the tender lot. 	
	 * @param tenderId The tender uid.
	 * @param lotId The lot uid.
	 * @return {Response} Response.
	 */
    this.GetTenderLotRaw = function (tenderId, lotId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderLotRaw", tenderId, lotId);
        return result;
    }

	/**
	 *  Gets the tender lot documents. 	
	 * @param tenderId The tender uid.
	 * @param lotId The lot uid.
	 * @return {Response} Response.
	 */
    this.GetTenderLotDocumentsRaw = function (tenderId, lotId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderLotDocumentsRaw", tenderId, lotId);
        return result;
    }

	/**
	 *  Gets the tender lot document. 	
	 * @param tenderId The tender uid.
	 * @param lotId The lot uid.
	 * @param documentId The lot document uid.
	 * @return {Response} Response.
	 */
    this.GetTenderLotDocumentRaw = function (tenderId, lotId, documentId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderLotDocumentRaw", tenderId, lotId, documentId);
        return result;
    }

	/**
	 *  Downloads the tender lot document. 	
	 * @param tenderId The tender uid.
	 * @param lotId The lot uid.
	 * @param documentId The lot document uid.
	 * @return {Response} Response.
	 */
    this.DownloadTenderLotDocumentRaw = function (tenderId, lotId, documentId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "DownloadTenderLotDocumentRaw", tenderId, lotId, documentId);
        return result;
    }

	/**
	 *  Getting list of all tenders (Limit:100). 	
	 * @return {ProzzoroPageInfo} PageInfo.
	 */
    this.GetTenders = function () {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenders");
        return result;
    }

	/**
	 *  Getting list of all tenders in next page (Limit:100). 	
	 * @param offset Offset date time.
	 * @return {ProzzoroPageInfo} PageInfo.
	 */
    this.GetTendersNext = function (offset) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTendersNext", offset);
        return result;
    }

	/**
	 *  Gets tender. 	
	 * @param tenderId The uid tender.
	 * @return {ProzzoroTender} Tender.
	 */
    this.GetTenderByIdentifier = function (tenderId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderByIdentifier", tenderId);
        return result;
    }

	/**
	 *  Gets the tender documents. 	
	 * @param tenderId The tender uid.
	 * @return {ProzzoroDocument[]} Array of Document.
	 */
    this.GetTenderDocuments = function (tenderId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderDocuments", tenderId);
        return result;
    }

	/**
	 *  Gets the tender document. 	
	 * @param tenderId The tender uid.
	 * @param documentId The document uid.
	 * @return {ProzzoroDocument} Document.
	 */
    this.GetTenderDocument = function (tenderId, documentId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderDocument", tenderId, documentId);
        return result;
    }

	/**
	 *  Downloads the tender document. 	
	 * @param tenderId The tender uid.
	 * @param documentId The document uid.
	 * @return {Stream} Stream.
	 */
    this.DownloadTenderDocument = function (tenderId, documentId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "DownloadTenderDocument", tenderId, documentId);
        return result;
    }

	/**
	 *  Gets the tender bids. 	
	 * @param id The uid tender.
	 * @return {ProzzoroBid[]} Array of Bid.
	 */
    this.GetTenderBids = function (id) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderBids", id);
        return result;
    }

	/**
	 *  Gets the tender bid. 	
	 * @param tenderId The tender uid.
	 * @param bidId The bid uid.
	 * @return {ProzzoroBid} Bid.
	 */
    this.GetTenderBid = function (tenderId, bidId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderBid", tenderId, bidId);
        return result;
    }

	/**
	 *  Gets the tender bid documents. 	
	 * @param tenderId The tender uid.
	 * @param bidId The bid uid.
	 * @return {ProzzoroDocument[]} Array of Document.
	 */
    this.GetTenderBidDocuments = function (tenderId, bidId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderBidDocuments", tenderId, bidId);
        return result;
    }

	/**
	 *  Gets the tender bid document. 	
	 * @param tenderId The tender uid.
	 * @param bidId The bid uid.
	 * @param documentId The bid document uid.
	 * @return {ProzzoroDocument} Document.
	 */
    this.GetTenderBidDocument = function (tenderId, bidId, documentId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderBidDocument", tenderId, bidId, documentId);
        return result;
    }

	/**
	 *  Downloads the tender bid document. 	
	 * @param tenderId The tender uid.
	 * @param bidId The bid uid.
	 * @param documentId The bid document uid.
	 * @return {Stream} Stream.
	 */
    this.DownloadTenderBidDocument = function (tenderId, bidId, documentId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "DownloadTenderBidDocument", tenderId, bidId, documentId);
        return result;
    }

	/**
	 *  Gets the tender awards. 	
	 * @param tenderId The uid tender.
	 * @return {ProzzoroAward[]} Array of Award.
	 */
    this.GetTenderAwards = function (tenderId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderAwards", tenderId);
        return result;
    }

	/**
	 *  Gets the tender award. 	
	 * @param tenderId The tender uid.
	 * @param awardId The award uid.
	 * @return {ProzzoroAward} Award.
	 */
    this.GetTenderAward = function (tenderId, awardId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderAward", tenderId, awardId);
        return result;
    }

	/**
	 *  Gets the tender award documents. 	
	 * @param tenderId The tender uid.
	 * @param awardId The award uid.
	 * @return {ProzzoroDocument[]} Array of Document.
	 */
    this.GetTenderAwardDocuments = function (tenderId, awardId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderAwardDocuments", tenderId, awardId);
        return result;
    }

	/**
	 *  Gets the tender award document. 	
	 * @param tenderId The tender uid.
	 * @param awardId The award uid.
	 * @param documentId The award document uid.
	 * @return {ProzzoroDocument} Document.
	 */
    this.GetTenderAwardDocument = function (tenderId, awardId, documentId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderAwardDocument", tenderId, awardId, documentId);
        return result;
    }

	/**
	 *  Downloads the tender award document. 	
	 * @param tenderId The tender uid.
	 * @param awardId The award uid.
	 * @param documentId The award document uid.
	 * @return {Stream} Stream.
	 */
    this.DownloadTenderAwardDocument = function (tenderId, awardId, documentId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "DownloadTenderAwardDocument", tenderId, awardId, documentId);
        return result;
    }

	/**
	 *  Gets the tender cancellations. 	
	 * @param tenderId The tender uid.
	 * @return {ProzzoroCancellation[]} Array of Cancellation.
	 */
    this.GetTenderCancellations = function (tenderId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderCancellations", tenderId);
        return result;
    }

	/**
	 *  Gets the tender cancellation. 	
	 * @param tenderId The tender uid.
	 * @param cancellationId The cancellation uid.
	 * @return {ProzzoroCancellation} Cancellation.
	 */
    this.GetTenderCancellation = function (tenderId, cancellationId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderCancellation", tenderId, cancellationId);
        return result;
    }

	/**
	 *  Gets the tender cancellation documents. 	
	 * @param tenderId The tender uid.
	 * @param cancellationId The cancellation uid.
	 * @return {ProzzoroDocument[]} Array of Document.
	 */
    this.GetTenderCancellationDocuments = function (tenderId, cancellationId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderCancellationDocuments", tenderId, cancellationId);
        return result;
    }

	/**
	 *  Gets the tender cancellation document. 	
	 * @param tenderId The tender uid.
	 * @param cancellationId The cancellation uid.
	 * @param documentId The award document uid.
	 * @return {ProzzoroDocument} Document.
	 */
    this.GetTenderCancellationDocument = function (tenderId, cancellationId, documentId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderCancellationDocument", tenderId, cancellationId, documentId);
        return result;
    }

	/**
	 *  Downloads the tender cancellation document. 	
	 * @param tenderId The tender uid.
	 * @param cancellationId The cancellation uid.
	 * @param documentId The award document uid.
	 * @return {Stream} Stream.
	 */
    this.DownloadTenderCancellationDocument = function (tenderId, cancellationId, documentId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "DownloadTenderCancellationDocument", tenderId, cancellationId, documentId);
        return result;
    }

	/**
	 *  Gets the tender complaints. 	
	 * @param tenderId The tender uid.
	 * @return {ProzzoroComplaint[]} Array of complaint.
	 */
    this.GetTenderComplaints = function (tenderId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderComplaints", tenderId);
        return result;
    }

	/**
	 *  Gets the tender complaint. 	
	 * @param tenderId The tender uid.
	 * @param complaintId The complaint uid.
	 * @return {ProzzoroComplaint} Complaint.
	 */
    this.GetTenderComplaint = function (tenderId, complaintId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderComplaint", tenderId, complaintId);
        return result;
    }

	/**
	 *  Gets the tender complaint documents. 	
	 * @param tenderId The tender uid.
	 * @param complaintId The complaint uid.
	 * @return {ProzzoroDocument[]} Array of Document.
	 */
    this.GetTenderComplaintDocuments = function (tenderId, complaintId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderComplaintDocuments", tenderId, complaintId);
        return result;
    }

	/**
	 *  Gets the tender complaint document. 	
	 * @param tenderId The tender uid.
	 * @param complaintId The complaint uid.
	 * @param documentId The complaint document uid.
	 * @return {ProzzoroDocument} Document.
	 */
    this.GetTenderComplaintDocument = function (tenderId, complaintId, documentId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderComplaintDocument", tenderId, complaintId, documentId);
        return result;
    }

	/**
	 *  Downloads the tender complaint document. 	
	 * @param tenderId The tender uid.
	 * @param complaintId The complaint uid.
	 * @param documentId The complaint document uid.
	 * @return {Stream} Stream.
	 */
    this.DownloadTenderComplaintDocument = function (tenderId, complaintId, documentId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "DownloadTenderComplaintDocument", tenderId, complaintId, documentId);
        return result;
    }

	/**
	 *  Gets the tender contracts. 	
	 * @param tenderId The tender uid.
	 * @return {ProzzoroContract[]} Array of Contracts.
	 */
    this.GetTenderContracts = function (tenderId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderContracts", tenderId);
        return result;
    }

	/**
	 *  Gets the tender contract. 	
	 * @param tenderId The tender uid.
	 * @param contractId The contract uid.
	 * @return {ProzzoroContract} Contract.
	 */
    this.GetTenderContract = function (tenderId, contractId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderContract", tenderId, contractId);
        return result;
    }

	/**
	 *  Gets the tender contract documents. 	
	 * @param tenderId The tender uid.
	 * @param contractId The contract uid.
	 * @return {ProzzoroDocument[]} Array of Document.
	 */
    this.GetTenderContractDocuments = function (tenderId, contractId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderContractDocuments", tenderId, contractId);
        return result;
    }

	/**
	 *  Gets the tender contract document. 	
	 * @param tenderId The tender uid.
	 * @param contractId The contract uid.
	 * @param documentId The contract document uid.
	 * @return {ProzzoroDocument} Document.
	 */
    this.GetTenderContractDocument = function (tenderId, contractId, documentId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderContractDocument", tenderId, contractId, documentId);
        return result;
    }

	/**
	 *  Downloads the tender contract document. 	
	 * @param tenderId The tender uid.
	 * @param contractId The contract uid.
	 * @param documentId The contract document uid.
	 * @return {Stream} Stream.
	 */
    this.DownloadTenderContractDocument = function (tenderId, contractId, documentId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "DownloadTenderContractDocument", tenderId, contractId, documentId);
        return result;
    }

	/**
	 *  Gets the tender lots. 	
	 * @param tenderId The tender uid.
	 * @return {ProzzoroLot[]} Array of lot.
	 */
    this.GetTenderLots = function (tenderId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderLots", tenderId);
        return result;
    }

	/**
	 *  Gets the tender lot. 	
	 * @param tenderId The tender uid.
	 * @param lotId The lot uid.
	 * @return {ProzzoroLot} Lot.
	 */
    this.GetTenderLot = function (tenderId, lotId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderLot", tenderId, lotId);
        return result;
    }

	/**
	 *  Gets the tender lot documents. 	
	 * @param tenderId The tender uid.
	 * @param lotId The lot uid.
	 * @return {ProzzoroDocument[]} Array of Document.
	 */
    this.GetTenderLotDocuments = function (tenderId, lotId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderLotDocuments", tenderId, lotId);
        return result;
    }

	/**
	 *  Gets the tender lot document. 	
	 * @param tenderId The tender uid.
	 * @param lotId The lot uid.
	 * @param documentId The lot document uid.
	 * @return {ProzzoroDocument} Document.
	 */
    this.GetTenderLotDocument = function (tenderId, lotId, documentId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderLotDocument", tenderId, lotId, documentId);
        return result;
    }

	/**
	 *  Downloads the tender lot document. 	
	 * @param tenderId The tender uid.
	 * @param lotId The lot uid.
	 * @param documentId The lot document uid.
	 * @return {Stream} Stream.
	 */
    this.DownloadTenderLotDocument = function (tenderId, lotId, documentId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "DownloadTenderLotDocument", tenderId, lotId, documentId);
        return result;
    }

	/**
	 *  Gets list of all tender(Limit:100). 	
	 * @return {Response} Response.
	 */
    this.GetTendersRaw = function () {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTendersRaw");
        return result;
    }

	/**
	 *  Gets list of all tender(Limit:100) in next page. 	
	 * @param offset Offset date time.
	 * @return {Response} Response.
	 */
    this.GetTendersInNextPageRaw = function (offset) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTendersInNextPageRaw", offset);
        return result;
    }

	/**
	 *  Gets the tender. 	
	 * @param tenderId The tender uid.
	 * @return {Response} Response.
	 */
    this.GetTenderByIdentifierRaw = function (tenderId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderByIdentifierRaw", tenderId);
        return result;
    }

	/**
	 *  Gets the tender documents. 	
	 * @param tenderId The tender uid.
	 * @return {Response} Response.
	 */
    this.GetTenderDocumentsRaw = function (tenderId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderDocumentsRaw", tenderId);
        return result;
    }

	/**
	 *  Gets the tender document. 	
	 * @param tenderId The tender uid.
	 * @param documentId The tender document uid.
	 * @return {Response} Response.
	 */
    this.GetTenderDocumentRaw = function (tenderId, documentId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderDocumentRaw", tenderId, documentId);
        return result;
    }

	/**
	 *  Downloads the tender document. 	
	 * @param tenderId The tender uid.
	 * @param documentId The tender document uid.
	 * @return {Response} Response.
	 */
    this.DownloadTenderDocumentRaw = function (tenderId, documentId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "DownloadTenderDocumentRaw", tenderId, documentId);
        return result;
    }

	/**
	 *  Gets the tender bids. 	
	 * @param tenderId The tender uid.
	 * @return {Response} Response.
	 */
    this.GetTenderBidsRaw = function (tenderId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderBidsRaw", tenderId);
        return result;
    }

	/**
	 *  Gets the tender bid. 	
	 * @param tenderId The tender uid.
	 * @param bidId The bid uid.
	 * @return {Response} Response.
	 */
    this.GetTenderBidRaw = function (tenderId, bidId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderBidRaw", tenderId, bidId);
        return result;
    }

	/**
	 *  Gets the tender bid documents. 	
	 * @param tenderId The tender uid.
	 * @param bidId The bid uid.
	 * @return {Response} Response.
	 */
    this.GetTenderBidDocumentsRaw = function (tenderId, bidId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderBidDocumentsRaw", tenderId, bidId);
        return result;
    }

	/**
	 *  Gets the tender bid document. 	
	 * @param tenderId The tender uid.
	 * @param bidId The bid uid.
	 * @param documentId The bid document uid.
	 * @return {Response} Response.
	 */
    this.GetTenderBidDocumentRaw = function (tenderId, bidId, documentId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderBidDocumentRaw", tenderId, bidId, documentId);
        return result;
    }

	/**
	 *  Downloads the tender bid document. 	
	 * @param tenderId The tender uid.
	 * @param bidId The bid uid.
	 * @param documentId The bid document uid.
	 * @return {Response} Response.
	 */
    this.DownloadTenderBidDocumentRaw = function (tenderId, bidId, documentId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "DownloadTenderBidDocumentRaw", tenderId, bidId, documentId);
        return result;
    }

	/**
	 *  Gets the tender awards. 	
	 * @param id The tender uid.
	 * @return {Response} Response.
	 */
    this.GetTenderAwardsRaw = function (id) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderAwardsRaw", id);
        return result;
    }

	/**
	 *  Gets the tender award. 	
	 * @param tenderId The tender uid.
	 * @param awardId The award uid.
	 * @return {Response} Response.
	 */
    this.GetTenderAwardRaw = function (tenderId, awardId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderAwardRaw", tenderId, awardId);
        return result;
    }

	/**
	 *  Gets the tender award documents. 	
	 * @param tenderId The tender uid.
	 * @param awardId The award uid.
	 * @return {Response} Response.
	 */
    this.GetTenderAwardDocumentsRaw = function (tenderId, awardId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderAwardDocumentsRaw", tenderId, awardId);
        return result;
    }

	/**
	 *  Gets the tender award document. 	
	 * @param tenderId The tender uid.
	 * @param awardId The award uid.
	 * @param documentId The award document uid.
	 * @return {Response} Response.
	 */
    this.GetTenderAwardDocumentRaw = function (tenderId, awardId, documentId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderAwardDocumentRaw", tenderId, awardId, documentId);
        return result;
    }

	/**
	 *  Downloads the tender award document. 	
	 * @param tenderId The tender uid.
	 * @param awardId The award uid.
	 * @param documentId The award document uid.
	 * @return {Response} Response.
	 */
    this.DownloadTenderAwardDocumentRaw = function (tenderId, awardId, documentId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "DownloadTenderAwardDocumentRaw", tenderId, awardId, documentId);
        return result;
    }

	/**
	 *  Gets the tender cancellations. 	
	 * @param tenderId The tender uid.
	 * @return {Response} Response.
	 */
    this.GetTenderCancellationsRaw = function (tenderId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderCancellationsRaw", tenderId);
        return result;
    }

	/**
	 *  Gets the tender cancellation. 	
	 * @param tenderId The tender uid.
	 * @param cancellationId The cancellation uid.
	 * @return {Response} Response.
	 */
    this.GetTenderCancellationRaw = function (tenderId, cancellationId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderCancellationRaw", tenderId, cancellationId);
        return result;
    }

	/**
	 *  Gets the tender cancellation documents. 	
	 * @param tenderId The tender uid.
	 * @param cancellationId The cancellation uid.
	 * @return {Response} Response.
	 */
    this.GetTenderCancellationDocumentsRaw = function (tenderId, cancellationId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderCancellationDocumentsRaw", tenderId, cancellationId);
        return result;
    }

	/**
	 *  Gets the tender cancellation document. 	
	 * @param tenderId The tender uid.
	 * @param cancellationId The cancellation uid.
	 * @param documentId The award document uid.
	 * @return {Response} Response.
	 */
    this.GetTenderCancellationDocumentRaw = function (tenderId, cancellationId, documentId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderCancellationDocumentRaw", tenderId, cancellationId, documentId);
        return result;
    }

	/**
	 *  Downloads the tender cancellation document. 	
	 * @param tenderId The tender uid.
	 * @param cancellationId The cancellation uid.
	 * @param documentId The award document uid.
	 * @return {Response} Response.
	 */
    this.DownloadTenderCancellationDocumentRaw = function (tenderId, cancellationId, documentId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "DownloadTenderCancellationDocumentRaw", tenderId, cancellationId, documentId);
        return result;
    }

	/**
	 *  Gets the tender complaints. 	
	 * @param tenderId The tender uid.
	 * @return {Response} Response.
	 */
    this.GetTenderComplaintsRaw = function (tenderId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderComplaintsRaw", tenderId);
        return result;
    }

	/**
	 *  Gets the tender complaint. 	
	 * @param tenderId The tender uid.
	 * @param complaintId The complaint uid.
	 * @return {Response} Response.
	 */
    this.GetTenderComplaintRaw = function (tenderId, complaintId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderComplaintRaw", tenderId, complaintId);
        return result;
    }

	/**
	 *  Gets the tender complaint documents. 	
	 * @param tenderId The tender uid.
	 * @param complaintId The complaint uid.
	 * @return {Response} Response.
	 */
    this.GetTenderComplaintDocumentsRaw = function (tenderId, complaintId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderComplaintDocumentsRaw", tenderId, complaintId);
        return result;
    }

	/**
	 *  Gets the tender complaint document. 	
	 * @param tenderId The tender uid.
	 * @param complaintId The complaint uid.
	 * @param documentId The complaint document uid.
	 * @return {Response} Response.
	 */
    this.GetTenderComplaintDocumentRaw = function (tenderId, complaintId, documentId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderComplaintDocumentRaw", tenderId, complaintId, documentId);
        return result;
    }

	/**
	 *  Downloads the tender complaint document. 	
	 * @param tenderId The tender uid.
	 * @param complaintId The complaint uid.
	 * @param documentId The complaint document uid.
	 * @return {Response} Response.
	 */
    this.DownloadTenderComplaintDocumentRaw = function (tenderId, complaintId, documentId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "DownloadTenderComplaintDocumentRaw", tenderId, complaintId, documentId);
        return result;
    }

	/**
	 *  Gets the tender contracts. 	
	 * @param tenderId The tender uid.
	 * @return {Response} Response.
	 */
    this.GetTenderContractsRaw = function (tenderId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderContractsRaw", tenderId);
        return result;
    }

	/**
	 *  Gets the tender contract. 	
	 * @param tenderId The tender uid.
	 * @param contractId The contract uid.
	 * @return {Response} Response.
	 */
    this.GetTenderContractRaw = function (tenderId, contractId) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderContractRaw", tenderId, contractId);
        return result;
    }
}
/**
 * Implementation class of NextPage. 
 * @typedef {Object} ProzzoroNextPage
 */
 ProzzoroNextPage = function () { 
	/**
	 * The path.
	 * @type {string}
	 */
	this.path = "";

	/**
	 * The uri.
	 * @type {string}
	 */
	this.uri = "";

	/**
	 * The offset.
	 * @type {string}
	 */
	this.offset = "";

}

/**
 * Implementation class of Data. 
 * @typedef {Object} ProzzoroData
 */
 ProzzoroData = function () { 
	/**
	 * The identifier.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * When modified.
	 * @type {string}
	 */
	this.dateModified = "";

}

/**
 * Implementation class of PageInfo. 
 * @typedef {Object} ProzzoroPageInfo
 */
 ProzzoroPageInfo = function () { 
	/**
	 * Information about next page.
	 * @type {ProzzoroNextPage}
	 */
	this.next_page = new ProzzoroNextPage();

	/**
	 * Data information.
	 * @type {ProzzoroData[]}
	 */
	this.data = new Array();

}

/**
 * Implementation class of Period. 
 * @typedef {Object} ProzzoroPeriod
 */
 ProzzoroPeriod = function () { 
	/**
	 * The date when period started.
	 * @type {string}
	 */
	this.startDate = "";

	/**
	 * The date when period ended.
	 * @type {string}
	 */
	this.endDate = "";

}

/**
 * Implementation class of ContactPoint. 
 * @typedef {Object} ProzzoroContactPoint
 */
 ProzzoroContactPoint = function () { 
	/**
	 * The telephone number of the contact point/person
	 * @type {string}
	 */
	this.telephone = "";

	/**
	 * The fax number of the contact point/person.
	 * @type {string}
	 */
	this.faxNumber = "";

	/**
	 * The name of the contact person, department, or contact point, for correspondence relating to this contracting process.
	 * @type {string}
	 */
	this.name = "";

	/**
	 * The e-mail address of person.
	 * @type {string}
	 */
	this.email = "";

	/**
	 * A web address for the contact point/person.
	 * @type {string}
	 */
	this.url = "";

}

/**
 * Implementation class of Identifier. 
 * @typedef {Object} ProzzoroIdentifier
 */
 ProzzoroIdentifier = function () { 
	/**
	 * The identifier.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The scheme.
	 * @type {string}
	 */
	this.scheme = "";

	/**
	 * The legal name.
	 * @type {string}
	 */
	this.legalName = "";

}

/**
 * Implementation class of Address. 
 * @typedef {Object} ProzzoroAddress
 */
 ProzzoroAddress = function () { 
	/**
	 * The postal code.
	 * @type {string}
	 */
	this.postalCode = "";

	/**
	 * The name of the country.
	 * @type {string}
	 */
	this.countryName = "";

	/**
	 * The street address.
	 * @type {string}
	 */
	this.streetAddress = "";

	/**
	 * The region.
	 * @type {string}
	 */
	this.region = "";

	/**
	 * The locality.
	 * @type {string}
	 */
	this.locality = "";

}

/**
 * Implementation class of ProcuringEntity. 
 * @typedef {Object} ProcuringEntity
 */
 ProcuringEntity = function () { 
	/**
	 * The contact point.
	 * @type {ProzzoroContactPoint}
	 */
	this.contactPoint = new ProzzoroContactPoint();

	/**
	 * The identifier.
	 * @type {ProzzoroIdentifier}
	 */
	this.identifier = new ProzzoroIdentifier();

	/**
	 * The name.
	 * @type {string}
	 */
	this.name = "";

	/**
	 * The address.
	 * @type {ProzzoroAddress}
	 */
	this.address = new ProzzoroAddress();

}

/**
 * Implementation class of Document. 
 * @typedef {Object} ProzzoroDocument
 */
 ProzzoroDocument = function () { 
	/**
	 * The main document identifier.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The document hash.
	 * @type {string}
	 */
	this.hash = "";

	/**
	 * The document author.
	 * @type {string}
	 */
	this.author = "";

	/**
	 * The format of the document taken from the IANA Media Types code list,
	 * with the addition of one extra value for ‘offline/print’, 
	 * used when this document entry is being used to describe the offline publication of a document
	 * @type {string}
	 */
	this.format = "";

	/**
	 * Direct link to the document or attachment.
	 * @type {string}
	 */
	this.url = "";

	/**
	 * The document title.
	 * @type {string}
	 */
	this.title = "";

	/**
	 * The document of one of the possible values are: 
	 * tender, item, lot
	 * @type {string}
	 */
	this.documentOf = "";

	/**
	 * The date on which the document was first published.
	 * @type {string}
	 */
	this.datePublished = "";

	/**
	 * The type of the document.
	 * See possible values on:http://api-docs.openprocurement.org/en/latest/standard/document.html#schema
	 * @type {string}
	 */
	this.documentType = "";

	/**
	 * Date that the document was last modified.
	 * @type {string}
	 */
	this.dateModified = "";

	/**
	 * The identifier of related Lot or Item.
	 * @type {string}
	 */
	this.relatedItem = "";

	/**
	 * A short description of the document.
	 * @type {string}
	 */
	this.description = "";

}

/**
 * Implementation class of Organization. 
 * @typedef {Object} ProzzoroOrganization
 */
 ProzzoroOrganization = function () { 
	/**
	 * The contact point.
	 * @type {ProzzoroContactPoint}
	 */
	this.contactPoint = new ProzzoroContactPoint();

	/**
	 * The primary identifier for this organization
	 * @type {ProzzoroIdentifier}
	 */
	this.identifier = new ProzzoroIdentifier();

	/**
	 * The common name of the organization.
	 * @type {string}
	 */
	this.name = "";

	/**
	 * The address.
	 * @type {ProzzoroAddress}
	 */
	this.address = new ProzzoroAddress();

}

/**
 * Implementation class of Complain. Used when need get information about tender complaint. 
 * @typedef {Object} ProzzoroComplaint
 */
 ProzzoroComplaint = function () { 
	/**
	 * The main complain identifier.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The complain status.
	 *  Possible values are:
	 *  draft, claim, answered, pending, invalid, declined, resolved, cancelled
	 * @type {string}
	 */
	this.status = "";

	/**
	 * The array of document.
	 * @type {ProzzoroDocument[]}
	 */
	this.documents = new Array();

	/**
	 * Description of the issue.
	 * @type {string}
	 */
	this.description = "";

	/**
	 * Organization filing a complaint.
	 * @type {ProzzoroOrganization}
	 */
	this.author = new ProzzoroOrganization();

	/**
	 * The resotion type.
	 * Possible values of resolution type are:
	 * invalid,declined,resolved
	 * @type {string}
	 */
	this.resolutionType = "";

	/**
	 * Resolution of Procuring entity.
	 * @type {string}
	 */
	this.resolution = "";

	/**
	 * Title of the complaint.
	 * @type {string}
	 */
	this.title = "";

	/**
	 * Date when Procuring entity answered the claim.
	 * @type {string}
	 */
	this.dateAnswered = "";

	/**
	 * Date of claim to complaint escalation.
	 * @type {string}
	 */
	this.dateEscalated = "";

	/**
	 * Date of complaint decision.
	 * @type {string}
	 */
	this.dateDecision = "";

	/**
	 * Date of cancelling.
	 * @type {string}
	 */
	this.dateCanceled = "";

	/**
	 * Date when claim was submitted.
	 * @type {string}
	 */
	this.dateSubmitted = "";

	/**
	 * The secondary complaint identifier.
	 * @type {string}
	 */
	this.complaintID = "";

	/**
	 * Date of posting.
	 * @type {string}
	 */
	this.date = "";

	/**
	 * The complaint type.
	 *   Possible values of type are:
	 *  claim, complaint.
	 * @type {string}
	 */
	this.type = "";

}

/**
 * Implementation class of Value. 
 * @typedef {Object} ProzzoroValue
 */
 ProzzoroValue = function () { 
	/**
	 * The currency in 3-letter ISO 4217 format.
	 * @type {string}
	 */
	this.currency = "";

	/**
	 * The amount.
	 * @type {Single}
	 */
	this.amount = new Single();

	/**
	 * A value indicating whether value-added tax include.
	 * @type {Boolean}
	 */
	this.valueAddedTaxIncluded = false;

}

/**
 * Implementation class of Guarantee. 
 * @typedef {Object} ProzzoroGuarantee
 */
 ProzzoroGuarantee = function () { 
	/**
	 * The currency.
	 * @type {string}
	 */
	this.currency = "";

	/**
	 * The amount.
	 * @type {Single}
	 */
	this.amount = new Single();

}

/**
 * Implementation class of Cancellation. Used when need get information about tender/lot cancellation. 
 * @typedef {Object} ProzzoroCancellation
 */
 ProzzoroCancellation = function () { 
	/**
	 * The main cancellation identifier.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * Possible status values are:
	 *  pending:	Default.The request is being prepared.
	 *  active:	Cancellation activated.
	 * @type {string}
	 */
	this.status = "";

	/**
	 * Protocol of Tender Committee with decision to cancel the Tender.
	 * @type {ProzzoroDocument[]}
	 */
	this.documents = new Array();

	/**
	 * The reason, why Tender is being cancelled.
	 * @type {string}
	 */
	this.reason = "";

	/**
	 * The reason type.
	 * @type {string}
	 */
	this.reasonType = "";

	/**
	 * Cancellation date.
	 * @type {string}
	 */
	this.date = "";

	/**
	 * The cancellation of possible values are:
	 *  tender, lot.
	 * @type {string}
	 */
	this.cancellationOf = "";

	/**
	 * The identifier of related Lot.
	 * @type {string}
	 */
	this.relatedLot = "";

}

/**
 * Implementation class of Lot. Used when need get information about tender lot. 
 * @typedef {Object} ProzzoroLot
 */
 ProzzoroLot = function () { 
	/**
	 * The main lot identifier.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The status of lot.
	 *  Possible values are:active:	Active tender lot (active)
	 *  unsuccessful:	Unsuccessful tender lot(unsuccessful)
	 *  complete:	Complete tender lot(complete)
	 *  cancelled:	Cancelled tender lot(cancelled)
	 * @type {string}
	 */
	this.status = "";

	/**
	 * Detailed description of tender lot.
	 * @type {string}
	 */
	this.description = "";

	/**
	 * Array of document.
	 * @type {ProzzoroDocument[]}
	 */
	this.documents = new Array();

	/**
	 * The name of tender lot.
	 * @type {string}
	 */
	this.title = "";

	/**
	 * The minimal step of auction.
	 * @type {ProzzoroValue}
	 */
	this.minimalStep = new ProzzoroValue();

	/**
	 * Total available tender lot budget.
	 * @type {ProzzoroValue}
	 */
	this.value = new ProzzoroValue();

	/**
	 * When created.
	 * @type {string}
	 */
	this.date = "";

	/**
	 * Bid guarantee.
	 * @type {ProzzoroGuarantee}
	 */
	this.guarantee = new ProzzoroGuarantee();

	/**
	 * The Cancellation object describes the reason of lot cancellation contains accompanying documents if any.
	 * @type {ProzzoroCancellation[]}
	 */
	this.cancellations = new Array();

}

/**
 * Implementation class of Supplier. 
 * @typedef {Object} ProzzoroSupplier
 */
 ProzzoroSupplier = function () { 
	/**
	 * The contact point.
	 * @type {ProzzoroContactPoint}
	 */
	this.contactPoint = new ProzzoroContactPoint();

	/**
	 * The name an english.
	 * @type {string}
	 */
	this.name_en = "";

	/**
	 * The identifier.
	 * @type {ProzzoroIdentifier}
	 */
	this.identifier = new ProzzoroIdentifier();

	/**
	 * The name.
	 * @type {string}
	 */
	this.name = "";

	/**
	 * The address.
	 * @type {ProzzoroAddress}
	 */
	this.address = new ProzzoroAddress();

}

/**
 * Implementation class of Award. Used when need get information about tender award. 
 * @typedef {Object} ProzzoroAward
 */
 ProzzoroAward = function () { 
	/**
	 * The main award identifier.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The status.
	 * @type {string}
	 */
	this.status = "";

	/**
	 * All documents and attachments related to the award, including any notices.
	 * @type {ProzzoroDocument[]}
	 */
	this.documents = new Array();

	/**
	 * The timeframe when complaints can be submitted.
	 * @type {ProzzoroPeriod}
	 */
	this.complaintPeriod = new ProzzoroPeriod();

	/**
	 * The suppliers awarded with this award.
	 * @type {ProzzoroSupplier[]}
	 */
	this.suppliers = new Array();

	/**
	 * A value indicating whether award is eligible.
	 * true - the award is eligible.false - the award is not eligible.
	 * @type {Boolean}
	 */
	this.eligible = false;

	/**
	 * The Id of a bid that the award relates to.
	 * @type {string}
	 */
	this.bid_id = "";

	/**
	 * The total value of this award.
	 * @type {ProzzoroValue}
	 */
	this.value = new ProzzoroValue();

	/**
	 * A value indicating whether the award is qualified.
	 * true - the award is qualified.false - the award is not qualified.
	 * @type {Boolean}
	 */
	this.qualified = false;

	/**
	 * The date of the contract award.
	 * @type {string}
	 */
	this.date = "";

}

/**
 * Implementation class of Classification. 
 * @typedef {Object} ProzzoroClassification
 */
 ProzzoroClassification = function () { 
	/**
	 * The classification identifier.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The scheme.
	 * @type {string}
	 */
	this.scheme = "";

	/**
	 * The description.
	 * @type {string}
	 */
	this.description = "";

}

/**
 * Implementation class of Unit. 
 * @typedef {Object} ProzzoroUnit
 */
 ProzzoroUnit = function () { 
	/**
	 * The code.
	 * @type {string}
	 */
	this.code = "";

	/**
	 * The name.
	 * @type {string}
	 */
	this.name = "";

}

/**
 * Implementation class of Item. 
 * @typedef {Object} ProzzoroItem
 */
 ProzzoroItem = function () { 
	/**
	 * The item identifier.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The description about item.
	 * @type {string}
	 */
	this.description = "";

	/**
	 * The item classfication.
	 * @type {ProzzoroClassification}
	 */
	this.classification = new ProzzoroClassification();

	/**
	 * The array of item additional classification.
	 * @type {ProzzoroClassification[]}
	 */
	this.additionalClassifications = new Array();

	/**
	 * The customer address.
	 * @type {ProzzoroAddress}
	 */
	this.deliveryAddress = new ProzzoroAddress();

	/**
	 * The delivery date.
	 * @type {ProzzoroPeriod}
	 */
	this.deliveryDate = new ProzzoroPeriod();

	/**
	 * The unit.
	 * @type {ProzzoroUnit}
	 */
	this.unit = new ProzzoroUnit();

	/**
	 * The quantity.
	 * @type {Int32}
	 */
	this.quantity = 0;

}

/**
 * Implementation class of Tenderer. 
 * @typedef {Object} ProzzoroTenderer
 */
 ProzzoroTenderer = function () { 
	/**
	 * The contact point.
	 * @type {ProzzoroContactPoint}
	 */
	this.contactPoint = new ProzzoroContactPoint();

	/**
	 * The name en.
	 * @type {string}
	 */
	this.name_en = "";

	/**
	 * The identifier.
	 * @type {ProzzoroIdentifier}
	 */
	this.identifier = new ProzzoroIdentifier();

	/**
	 * The name.
	 * @type {string}
	 */
	this.name = "";

	/**
	 * The address.
	 * @type {ProzzoroAddress}
	 */
	this.address = new ProzzoroAddress();

}

/**
 * Implementation class of Bid. Used when need get information about tender bid. 
 * @typedef {Object} ProzzoroBid
 */
 ProzzoroBid = function () { 
	/**
	 * The main bid identifier.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * Possible status values are:
	 * draft,active
	 * @type {string}
	 */
	this.status = "";

	/**
	 * The array of document.
	 * @type {ProzzoroDocument[]}
	 */
	this.documents = new Array();

	/**
	 * A value of whether bid self-eligible.
	 * true - bid self-eigible.
	 * false - bid not self-eigible.
	 * @type {Boolean}
	 */
	this.selfEligible = false;

	/**
	 * The cost of bid.
	 * @type {ProzzoroValue}
	 */
	this.value = new ProzzoroValue();

	/**
	 * A value indicating whether bid self-qualified.
	 * true - bid self-qualified.
	 * false - bid not self-qualified.
	 * @type {Boolean}
	 */
	this.selfQualified = false;

	/**
	 * The array of tenderer.
	 * @type {ProzzoroTenderer[]}
	 */
	this.tenderers = new Array();

	/**
	 * The date.
	 * @type {string}
	 */
	this.date = "";

	/**
	 * The participation URL.
	 * @type {string}
	 */
	this.participationUrl = "";

}

/**
 * Implementation class of Contract. Used when need get information about tender contract. 
 * @typedef {Object} ProzzoroContract
 */
 ProzzoroContract = function () { 
	/**
	 * The main contract identifier.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The contact status.
	 *   Possible values are:
	 *   pending - this contract has been proposed, but is not yet in force. It may be awaiting signature.
	 *   active - this contract has been signed by all the parties, and is now legally in force.
	 *   cancelled - this contract has been cancelled prior to being signed.
	 * @type {string}
	 */
	this.status = "";

	/**
	 * All documents and attachments related to the contract, including any notices.
	 * @type {ProzzoroDocument[]}
	 */
	this.documents = new Array();

	/**
	 * Array of item in this contract.
	 * @type {ProzzoroItem[]}
	 */
	this.items = new Array();

	/**
	 * The array of supplier.
	 * @type {ProzzoroSupplier[]}
	 */
	this.suppliers = new Array();

	/**
	 * The number of contracts.
	 * @type {string}
	 */
	this.contractNumber = "";

	/**
	 * The start and end date for the contract.
	 * @type {ProzzoroPeriod}
	 */
	this.period = new ProzzoroPeriod();

	/**
	 * The date when the contract was signed.
	 * @type {string}
	 */
	this.dateSigned = "";

	/**
	 * The total value of this contract.
	 * @type {ProzzoroValue}
	 */
	this.value = new ProzzoroValue();

	/**
	 * The date when the contract was changed or activated.
	 * @type {string}
	 */
	this.date = "";

	/**
	 * The awardId against which this contract is being issued.
	 * @type {string}
	 */
	this.awardID = "";

	/**
	 * The secondary contract identifiery.
	 * @type {string}
	 */
	this.contractID = "";

}

/**
 * Implementation class of Tender. 
 * @typedef {Object} ProzzoroTender
 */
 ProzzoroTender = function () { 
	/**
	 * The main tender identifier.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The procurement method.
	 * @type {string}
	 */
	this.procurementMethod = "";

	/**
	 * The number of bid.
	 * @type {Int32}
	 */
	this.numberOfBids = 0;

	/**
	 * The  awarding process period.
	 * @type {ProzzoroPeriod}
	 */
	this.awardPeriod = new ProzzoroPeriod();

	/**
	 * The complaint period.
	 * @type {ProzzoroPeriod}
	 */
	this.complaintPeriod = new ProzzoroPeriod();

	/**
	 * The auction URL.
	 * @type {string}
	 */
	this.auctionUrl = "";

	/**
	 * The period when questions are allowed. At least endDate has to be provided.
	 * @type {ProzzoroPeriod}
	 */
	this.enquiryPeriod = new ProzzoroPeriod();

	/**
	 * The submission method.
	 * @type {string}
	 */
	this.submissionMethod = "";

	/**
	 * The organization conducting the tender.
	 * @type {ProcuringEntity}
	 */
	this.procuringEntity = new ProcuringEntity();

	/**
	 * The owner of tender.
	 * @type {string}
	 */
	this.owner = "";

	/**
	 * The description about tender.
	 * @type {string}
	 */
	this.description = "";

	/**
	 * All documents and attachments related to the tender.
	 * @type {ProzzoroDocument[]}
	 */
	this.document = new Array();

	/**
	 * Complaints to tender conditions and their resolutions.
	 * @type {ProzzoroComplaint[]}
	 */
	this.complaints = new Array();

	/**
	 * Can contain all tender lots.
	 * @type {ProzzoroLot[]}
	 */
	this.lots = new Array();

	/**
	 * The name of the tender.
	 * @type {string}
	 */
	this.title = "";

	/**
	 * The tender identifier to refer tender to in "paper" documentation.
	 * @type {string}
	 */
	this.tenderID = "";

	/**
	 * The bid guarantee.
	 * @type {ProzzoroGuarantee}
	 */
	this.guarantee = new ProzzoroGuarantee();

	/**
	 * Date modified when tender was modified.
	 * @type {string}
	 */
	this.dateModified = "";

	/**
	 * The status of the tender.
	 *  Here is some value can be returned:
	 *  active.enquiries:Enquiries period(enquiries)
	 *  active.tendering: Tendering period(tendering)
	 *  active.auction:	Auction period(auction)
	 *  active.qualification: Winner qualification(qualification)
	 *  active.awarded:	Standstill period (standstill)
	 *  unsuccessful:	Unsuccessful tender(unsuccessful)
	 *  complete:	Complete tender(complete)
	 *  cancelled:	Cancelled tender(cancelled)
	 * @type {string}
	 */
	this.status = "";

	/**
	 * Period when bids can be submitted. At least endDate has to be provided.
	 * @type {ProzzoroPeriod}
	 */
	this.tenderPeriod = new ProzzoroPeriod();

	/**
	 * Period when auction is conducted.
	 * @type {ProzzoroPeriod}
	 */
	this.auctionPeriod = new ProzzoroPeriod();

	/**
	 * The type of the procurement method.
	 * @type {string}
	 */
	this.procurementMethodType = "";

	/**
	 * The all qualifications (disqualifications and awards)..
	 * @type {ProzzoroAward[]}
	 */
	this.awards = new Array();

	/**
	 * The date.
	 * @type {string}
	 */
	this.date = "";

	/**
	 * The minimal step of auction (reduction).
	 * @type {ProzzoroValue}
	 */
	this.minimalStep = new ProzzoroValue();

	/**
	 * The list that contains single item being procured.
	 * @type {ProzzoroItem[]}
	 */
	this.items = new Array();

	/**
	 * A list of all bid placed in the tender with information about tenderers, 
	 * their proposal and other qualification documentation.
	 * @type {ProzzoroBid[]}
	 */
	this.bids = new Array();

	/**
	 * The array of contract.
	 * @type {ProzzoroContract[]}
	 */
	this.contracts = new Array();

	/**
	 * The Cancellation object describes the reason of tender cancellation contains accompanying documents if any.
	 * @type {ProzzoroCancellation[]}
	 */
	this.cancellations = new Array();

	/**
	 * The total available tender budget.
	 * @type {ProzzoroValue}
	 */
	this.budget = new ProzzoroValue();

	/**
	 * The award criteria.
	 * @type {string}
	 */
	this.awardCriteria = "";

}

