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
	 *  Getting list of all tenders (Limit in data:100). 	
	 * @return {PageInfo} Return Info.
	 */
    this.GetTenders = function () {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenders");
        return result;
    }

	/**
	 *  Getting list of all tenders in next page (Limit in data:100). 	
	 * @param offset Offset to next page.
	 * @return {PageInfo} Return Info.
	 */
    this.GetTendersNext = function (offset) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTendersNext", offset);
        return result;
    }

	/**
	 *  Getting particular tender by identifier. 	
	 * @param id Identifier tender.
	 * @return {TenderOut} Return .
	 */
    this.GetTenderByIdentifier = function (id) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderByIdentifier", id);
        return result;
    }

	/**
	 *  Getting list of all tenders. 	
	 * @return {Response} Return response
	 */
    this.GetTendersRaw = function () {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTendersRaw");
        return result;
    }

	/**
	 *  Getting list of all tender in next page. 	
	 * @param offset Offset time.
	 * @return {Response} Return response.
	 */
    this.GetTendersInNextPageRaw = function (offset) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTendersInNextPageRaw", offset);
        return result;
    }

	/**
	 *  Getting particular tender by id. 	
	 * @param id Identifier tender.
	 * @return {Response} Return response.
	 */
    this.GetTenderByIdentifierRaw = function (id) {
        var result = _bNesisApi.Call("Prozzoro", this.bNesisToken, "GetTenderByIdentifierRaw", id);
        return result;
    }
}
/**
 * Implementation for  'next_page'. 
 * @typedef {Object} NextPage
 */
 NextPage = function () { 
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
 * Implementation for 'data'. 
 * @typedef {Object} Data
 */
 Data = function () { 
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
 * Implementation for page information. 
 * @typedef {Object} PageInfo
 */
 PageInfo = function () { 
	/**
	 * Information about next page.
	 * @type {NextPage}
	 */
	this.next_page = new NextPage();

	/**
	 * Data information.
	 * @type {Data[]}
	 */
	this.data = new Array();

}

/**
 * Implementation for tender 'tenderPeriod'. 
 * @typedef {Object} TenderPeriod
 */
 TenderPeriod = function () { 
	/**
	 * When started.
	 * @type {string}
	 */
	this.startDate = "";

	/**
	 * When ended.
	 * @type {string}
	 */
	this.endDate = "";

}

/**
 * Implementation for tender 'minimalStep'. 
 * @typedef {Object} MinimalStep
 */
 MinimalStep = function () { 
	/**
	 * The currency.
	 * @type {string}
	 */
	this.currency = "";

	/**
	 * The amount.
	 * @type {string}
	 */
	this.amount = "";

	/**
	 * The value added tax included.
	 * @type {Boolean}
	 */
	this.valueAddedTaxIncluded = false;

}

/**
 * Implementation for tender 'classification'. 
 * @typedef {Object} Classification
 */
 Classification = function () { 
	/**
	 * The scheme.
	 * @type {string}
	 */
	this.scheme = "";

	/**
	 * The description for classification.
	 * @type {string}
	 */
	this.description = "";

	/**
	 * Classification identifier.
	 * @type {string}
	 */
	this.id = "";

}

/**
 * Implementation for tender 'additionalClassification' 
 * @typedef {Object} AdditionalClassification
 */
 AdditionalClassification = function () { 
	/**
	 * The scheme.
	 * @type {string}
	 */
	this.scheme = "";

	/**
	 * Additional classification identifier.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The description for additional classification.
	 * @type {string}
	 */
	this.description = "";

}

/**
 * Implementation for tender 'deliveryAddress' 
 * @typedef {Object} DeliveryAddress
 */
 DeliveryAddress = function () { 
	/**
	 * The postalcode.
	 * @type {string}
	 */
	this.postalCode = "";

	/**
	 * The country name.
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
 * Implementation for tender 'deliveryDate'. 
 * @typedef {Object} DeliveryDate
 */
 DeliveryDate = function () { 
	/**
	 * When started.
	 * @type {string}
	 */
	this.startDate = "";

	/**
	 * When ended.
	 * @type {string}
	 */
	this.endDate = "";

}

/**
 * Implementation for tender 'unit'. 
 * @typedef {Object} Unit
 */
 Unit = function () { 
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
 * Implementation for tender 'items'. 
 * @typedef {Object} Item
 */
 Item = function () { 
	/**
	 * Description about item.
	 * @type {string}
	 */
	this.description = "";

	/**
	 * Item classfication.
	 * @type {Classification}
	 */
	this.classification = new Classification();

	/**
	 * Item additional classification.
	 * @type {AdditionalClassification[]}
	 */
	this.additionalClassifications = new Array();

	/**
	 * Customer address.
	 * @type {DeliveryAddress}
	 */
	this.deliveryAddress = new DeliveryAddress();

	/**
	 * The delivery date.
	 * @type {DeliveryDate}
	 */
	this.deliveryDate = new DeliveryDate();

	/**
	 * Item identifier.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The unit.
	 * @type {Unit}
	 */
	this.unit = new Unit();

	/**
	 * The quantity.
	 * @type {Int32}
	 */
	this.quantity = 0;

}

/**
 * Implementation for tender 'value'. 
 * @typedef {Object} Cost
 */
 Cost = function () { 
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

	/**
	 * The value added tax included.
	 * @type {Boolean}
	 */
	this.valueAddedTaxIncluded = false;

}

/**
 * Implementation for tender 'contactPoint'. 
 * @typedef {Object} ContactPoint
 */
 ContactPoint = function () { 
	/**
	 * The telephone number.
	 * @type {string}
	 */
	this.telephone = "";

	/**
	 * The fax number.
	 * @type {string}
	 */
	this.faxNumber = "";

	/**
	 * The name.
	 * @type {string}
	 */
	this.name = "";

	/**
	 * The e-mail.
	 * @type {string}
	 */
	this.email = "";

}

/**
 * Implementation for tender 'identifier'. 
 * @typedef {Object} Identifier
 */
 Identifier = function () { 
	/**
	 * The scheme.
	 * @type {string}
	 */
	this.scheme = "";

	/**
	 * The identifier.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The legal name.
	 * @type {string}
	 */
	this.legalName = "";

}

/**
 * Implementation for tender 'address'. 
 * @typedef {Object} Address
 */
 Address = function () { 
	/**
	 * The postalcode.
	 * @type {string}
	 */
	this.postalCode = "";

	/**
	 * The country name.
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
 * Implementation for tender 'procuringEntity'. 
 * @typedef {Object} ProcuringEntity
 */
 ProcuringEntity = function () { 
	/**
	 * The contact point.
	 * @type {ContactPoint}
	 */
	this.contactPoint = new ContactPoint();

	/**
	 * The identifier.
	 * @type {Identifier}
	 */
	this.identifier = new Identifier();

	/**
	 * The name.
	 * @type {string}
	 */
	this.name = "";

	/**
	 * The address.
	 * @type {Address}
	 */
	this.address = new Address();

}

/**
 * Implementation for tender 'enquiryPeriod'. 
 * @typedef {Object} EnquiryPeriod
 */
 EnquiryPeriod = function () { 
	/**
	 * When started.
	 * @type {string}
	 */
	this.startDate = "";

	/**
	 * When ended.
	 * @type {string}
	 */
	this.endDate = "";

}

/**
 * Implementation for tender. 
 * @typedef {Object} TenderOut
 */
 TenderOut = function () { 
	/**
	 * The procurement method.
	 * @type {string}
	 */
	this.procurementMethod = "";

	/**
	 * The status.
	 * @type {string}
	 */
	this.status = "";

	/**
	 * The tender period.
	 * @type {TenderPeriod}
	 */
	this.tenderPeriod = new TenderPeriod();

	/**
	 * The number of bids.
	 * @type {Int32}
	 */
	this.numberOfBids = 0;

	/**
	 * The description.
	 * @type {string}
	 */
	this.description = "";

	/**
	 * The title.
	 * @type {string}
	 */
	this.title = "";

	/**
	 * The minimal step.
	 * @type {MinimalStep}
	 */
	this.minimalStep = new MinimalStep();

	/**
	 * The items of tender.
	 * @type {Item[]}
	 */
	this.items = new Array();

	/**
	 * The identifier.
	 * @type {string}
	 */
	this.id = "";

	/**
	 * The procurement method type.
	 * @type {string}
	 */
	this.procurementMethodType = "";

	/**
	 * The cost.
	 * @type {Cost}
	 */
	this.cost = new Cost();

	/**
	 * The submission method.
	 * @type {string}
	 */
	this.submissionMethod = "";

	/**
	 * The procuring entity.
	 * @type {ProcuringEntity}
	 */
	this.procuringEntity = new ProcuringEntity();

	/**
	 * Tender identifier.
	 * @type {string}
	 */
	this.tenderID = "";

	/**
	 * The enquiry period.
	 * @type {EnquiryPeriod}
	 */
	this.enquiryPeriod = new EnquiryPeriod();

	/**
	 * The owner.
	 * @type {string}
	 */
	this.owner = "";

	/**
	 * When modified.
	 * @type {string}
	 */
	this.dateModified = "";

	/**
	 * The award criteria.
	 * @type {string}
	 */
	this.awardCriteria = "";

}

