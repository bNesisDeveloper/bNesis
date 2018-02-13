Stripe = function (bNesisApi) {
    this.bNesisToken = null;
    var _bNesisApi = bNesisApi;

    this.Auth = function (data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl) {
        var bNesisToken = _bNesisApi.Auth("Stripe", data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl);
        return bNesisToken;
    }
	
	/**
	 *  Getting last exception for current provider 	
	 * @return {ErrorInfo} 
	 */
    this.GetLastError = function () {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "GetLastError");
        return result;
    }

	/**
	 *  Getting arrays of error info 	
	 * @return {ErrorInfo[]} 
	 */
    this.GetErrorLog = function () {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "GetErrorLog");
        return result;
    }

	/**
	 *  Checks the token in the service. 	
	 * @return {Boolean} if token valid return true, if token not valid return false
	 */
    this.ValidationTokenUnified = function () {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "ValidationTokenUnified");
        return result;
    }

	/**
	 *   	
	 * @return {Balance[]} 
	 */
    this.BalanceUnified = function () {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "BalanceUnified");
        return result;
    }

	/**
	 *   	
	 * @param id 
	 * @return {RetrieveBalanceUnified} 
	 */
    this.RetrieveBalancePosixUnified = function (id) {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "RetrieveBalancePosixUnified", id);
        return result;
    }

	/**
	 *   	
	 * @param id 
	 * @return {RetrieveBalanceUnified} 
	 */
    this.RetrieveBalanceUnified = function (id) {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "RetrieveBalanceUnified", id);
        return result;
    }

	/**
	 *   	
	 * @param date_from 
	 * @param date_to 
	 * @param resp_format 
	 * @return {PaymentsArchive} 
	 */
    this.GetPaymentHistoryUnified = function (date_from, date_to, resp_format) {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "GetPaymentHistoryUnified", date_from, date_to, resp_format);
        return result;
    }

	/**
	 *  Retrieves the current account balance, based on the authentication that was used to make the request. 	
	 * @return {Response} Returns a balance object for the account authenticated as.
	 */
    this.BalanceRaw = function () {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "BalanceRaw");
        return result;
    }

	/**
	 *  Retrieves the current account balance, based on the authentication that was used to make the request. 	
	 * @return {StripeBalanceItemOut} Returns a balance object for the account authenticated as.
	 */
    this.Balance = function () {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "Balance");
        return result;
    }

	/**
	 *  Retrieves the balance transaction with the given ID. 	
	 * @param id The ID of the desired balance transaction (as found on any API object that affects the balance, e.g. a charge or transfer).
	 * @return {Response} Returns a balance transaction if a valid balance transaction ID was provided.
	 *  Returns an error otherwise.
	 */
    this.RetrieveBalanceRaw = function (id) {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "RetrieveBalanceRaw", id);
        return result;
    }

	/**
	 *  Retrieves the balance transaction with the given ID. 	
	 * @param id The ID of the desired balance transaction (as found on any API object that affects the balance, e.g. a charge or transfer).
	 * @return {RetrieveBalance} Returns a balance transaction with POSIXTime. if a valid balance transaction ID was provided. 
	 *  Returns an error otherwise.
	 */
    this.RetrieveBalancePosix = function (id) {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "RetrieveBalancePosix", id);
        return result;
    }

	/**
	 *  Retrieves the balance transaction with the given ID. 	
	 * @param id The ID of the desired balance transaction (as found on any API object that affects the balance, e.g. a charge or transfer).
	 * @return {RetrieveBalance} Returns a balance transaction if a valid balance transaction ID was provided.
	 *  Returns an error otherwise.
	 */
    this.RetrieveBalance = function (id) {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "RetrieveBalance", id);
        return result;
    }

	/**
	 *  Returns a list of transactions that have contributed to the Stripe account balance (e.g., charges, transfers, and so forth).
	 * The transactions are returned in sorted order, with the most recent transactions appearing first. 	
	 * @return {Response} A dictionary with a data property that contains an array of up to limit transactions, starting after transaction starting_after.
	 *  Each entry in the array is a separate transaction history object.
	 *  If no more transactions are available, the resulting array will be empty.
	 */
    this.ListBalanceHistoryRaw = function () {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "ListBalanceHistoryRaw");
        return result;
    }

	/**
	 *  To charge a credit card, you create a Charge object.
	 * If your API key is in test mode, the supplied payment source (e.g., card) won't actually be charged, though everything else will occur as if in live mode.
	 * (Stripe assumes that the charge would have completed successfully). 	
	 * @param arguments https://stripe.com/docs/api/curl#create_charge
	 * @return {Response} Returns a Charge object if the charge succeeded.
	 * Returns an error if something goes wrong. 
	 * A common source of error is an invalid or expired card, or a valid card with insufficient available balance.
	 */
    this.CreateChargeRaw = function (arguments) {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "CreateChargeRaw", arguments);
        return result;
    }

	/**
	 *  Returns a list of charges you’ve previously created. The charges are returned in sorted order, with the most recent charges appearing first. 	
	 * @param limit A limit on the number of objects to be returned, between 1 and 100.
	 * @return {Response} A dictionary with a data property that contains an array of up to limit charges, starting after charge starting_after. Each entry in the array is a separate charge object. If no more charges are available, the resulting array will be empty. If you provide a non-existent customer ID, this call returns an error.
	 */
    this.ListChargesRaw = function (limit) {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "ListChargesRaw", limit);
        return result;
    }

	/**
	 *  Retrieves the details of a charge that has previously been created.
	 * Supply the unique charge ID that was returned from your previous request, and Stripe will return the corresponding charge information.
	 * The same information is returned when creating or refunding the charge. 	
	 * @param chargeId The identifier of the charge to be retrieved.
	 * @return {Response} Returns a charge if a valid identifier was provided, and returns an error otherwise.
	 */
    this.RetrieveChargeRaw = function (chargeId) {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "RetrieveChargeRaw", chargeId);
        return result;
    }

	/**
	 *  Updates the specified charge by setting the values of the parameters passed. Any parameters not provided will be left unchanged. 	
	 * @param chargeId The identifier of the charge to be retrieved.
	 * @param arguments This request accepts only the description, metadata, receipt_email, fraud_details, and shipping as arguments.
	 * @return {Response} Returns the charge object if the update succeeded. This call will return an error if update parameters are invalid.
	 */
    this.UpdateChargeRaw = function (chargeId, arguments) {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "UpdateChargeRaw", chargeId, arguments);
        return result;
    }

	/**
	 *  Capture the payment of an existing, uncaptured, charge.
	 * This is the second half of the two-step payment flow, where first you created a charge with the capture option set to false. 	
	 * @param chargeId The identifier of the charge to be retrieved
	 * @return {Response} Returns the charge object, with an updated captured property (set to true).
	 *  Capturing a charge will always succeed, unless the charge is already refunded, expired,
	 *  captured, or an invalid capture amount is specified, in which case this method will return an error.
	 */
    this.CaptureChargeRaw = function (chargeId) {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "CaptureChargeRaw", chargeId);
        return result;
    }

	/**
	 *  Creates a new customer object. 	
	 * @param arguments https://stripe.com/docs/api/curl#create_customer
	 * @return {Response} Returns a customer object if the call succeeded.
	 * The returned object will have information about subscriptions, discount, and payment sources, if that information has been provided. 
	 * If an invoice payment is due and a source is not provided, the call will return an error.
	 * If a non-existent plan or a non-existent or expired coupon is provided, the call will return an error.
	 */
    this.CreateCustomerRaw = function (arguments) {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "CreateCustomerRaw", arguments);
        return result;
    }

	/**
	 *  Retrieves the details of an existing customer.
	 * You need only supply the unique customer identifier that was returned upon customer creation. 	
	 * @param customerId The identifier of the customer to be retrieved.
	 * @return {Response} Returns a customer object if a valid identifier was provided. 
	 * When requesting the ID of a customer that has been deleted, a subset of the customer’s information will be returned, including a deleted property, which will be true.
	 */
    this.RetrieveCustomerRaw = function (customerId) {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "RetrieveCustomerRaw", customerId);
        return result;
    }

	/**
	 *  Updates the specified customer by setting the values of the parameters passed. 	
	 * @param customerId The identifier of the customer to be retrieved.
	 * @param arguments https://stripe.com/docs/api/curl#update_customer
	 * @return {Response} Returns the customer object if the update succeeded.
	 *  Returns an error if update parameters are invalid (e.g. specifying an invalid coupon or an invalid source).
	 */
    this.UpdateCustomerRaw = function (customerId, arguments) {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "UpdateCustomerRaw", customerId, arguments);
        return result;
    }

	/**
	 *  Permanently deletes a customer. It cannot be undone. Also immediately cancels any active subscriptions on the customer. 	
	 * @param customerId The identifier of the customer to be deleted.
	 * @return {Response} Returns an object with a deleted parameter on success. 
	 * If the customer ID does not exist, this call returns an error.
	 */
    this.DeleteCustomerRaw = function (customerId) {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "DeleteCustomerRaw", customerId);
        return result;
    }

	/**
	 *  Returns a list of your customers.
	 * The customers are returned sorted by creation date, with the most recent customers appearing first. 	
	 * @param limit A limit on the number of objects to be returned. Limit can range between 1 and 100 items, and the default is 10 items.
	 * @return {Response} A dictionary with a data property that contains an array of up to limit customers, starting after customer starting_after.
	 *  Each entry in the array is a separate customer object.
	 *  If no more customers are available, the resulting array will be empty.
	 *  This request should never return an error.
	 */
    this.ListCustomersRaw = function (limit) {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "ListCustomersRaw", limit);
        return result;
    }

	/**
	 *  Retrieves the dispute with the given ID. 	
	 * @param disputeId ID of dispute to retrieve.
	 * @return {Response} Returns a dispute if a valid dispute ID was provided. Returns an error otherwise.
	 */
    this.RetrieveDisputeRaw = function (disputeId) {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "RetrieveDisputeRaw", disputeId);
        return result;
    }

	/**
	 *  Retrieves the dispute with the given ID. 	
	 * @param disputeId ID of dispute to retrieve.
	 * @param evidenceField Evidence to upload to respond to a dispute.
	 *  Updating any field in the hash will submit all fields in the hash for review.
	 * @return {Response} Returns a dispute if a valid dispute ID was provided. Returns an error otherwise.
	 */
    this.UpdateDisputeRaw = function (disputeId, evidenceField) {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "UpdateDisputeRaw", disputeId, evidenceField);
        return result;
    }

	/**
	 *  Closing the dispute for a charge indicates that you do not have any evidence to submit and are essentially ‘dismissing’ the dispute, acknowledging it as lost 	
	 * @param disputeId ID of dispute to close.
	 * @return {Response} Returns the dispute object.
	 */
    this.CloseDisputeRaw = function (disputeId) {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "CloseDisputeRaw", disputeId);
        return result;
    }

	/**
	 *  Returns a list of your disputes. 	
	 * @param limit A limit on the number of objects to be returned. Limit can range between 1 and 100 items, and the default is 10 items.
	 * @return {Response} A dictionary with a data property that contains an array of up to limit disputes, starting after dispute starting_after.
	 * Each entry in the array is a separate dispute object. If no more disputes are available, the resulting array will be empty. 
	 * This request should never return an error.
	 */
    this.ListDisputesRaw = function (limit) {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "ListDisputesRaw", limit);
        return result;
    }

	/**
	 *  Retrieves the details of an event. Supply the unique identifier of the event, which you might have received in a webhook. 	
	 * @param id The identifier of the event to be retrieved.
	 * @return {Response} Returns an event object if a valid identifier was provided.
	 *  All events share a common structure, detailed to the right.
	 *  The only property that will differ is the data property.
	 */
    this.RetrieveEventRaw = function (id) {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "RetrieveEventRaw", id);
        return result;
    }

	/**
	 *  List events, going back up to 30 days. 	
	 * @param limit A limit on the number of objects to be returned. Limit can range between 1 and 100 items, and the default is 10 items.
	 * @return {Response} A dictionary with a data property that contains an array of up to limit events, starting after event starting_after. Each entry in the array is a separate event object.
	 *  If no more events are available, the resulting array will be empty.
	 *  This request should never return an error.
	 */
    this.ListEventsRaw = function (limit) {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "ListEventsRaw", limit);
        return result;
    }

	/**
	 *  Creates a new customer payout object. 	
	 * @param arguments https://stripe.com/docs/api/curl#create_payout
	 * @return {Response} Returns a payout object if there were no initial errors with the payout creation (invalid routing number, insufficient funds, etc).
	 *  The status of the payout object will be initially marked as pending.
	 */
    this.CreatePayoutRaw = function (arguments) {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "CreatePayoutRaw", arguments);
        return result;
    }

	/**
	 *  Retrieves the details of an existing payout. 	
	 * @param payoutId The identifier of the payout to be retrieved.
	 * @return {Response} Returns a payout object if a valid identifier was provided, and returns an error otherwise.
	 */
    this.RetrievePayoutRaw = function (payoutId) {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "RetrievePayoutRaw", payoutId);
        return result;
    }

	/**
	 *  Updates the specified payout by setting the values of the parameters passed. Any parameters not provided will be left unchanged. This request accepts only the metadata as arguments. 	
	 * @param payoutId The identifier of the payout to be retrieved.
	 * @param arguments https://stripe.com/docs/api/curl#update_payout
	 * @return {Response} Returns the payout object if the update succeeded.
	 *  This call returns an error if update parameters are invalid.
	 */
    this.UpdatePayoutRaw = function (payoutId, arguments) {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "UpdatePayoutRaw", payoutId, arguments);
        return result;
    }

	/**
	 *  Returns a list of existing payouts sent to third-party bank accounts or that Stripe has sent you. The payouts are returned in sorted order, with the most recently created payouts appearing first. 	
	 * @param limit A dictionary with a data property that contains an array of up to limit payouts, starting after payout starting_after.
	 * @return {Response} Each entry in the array is a separate payout object.
	 *  If no more payouts are available, the resulting array will be empty.
	 */
    this.ListPayoutRaw = function (limit) {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "ListPayoutRaw", limit);
        return result;
    }

	/**
	 *  A previously created payout can be canceled if it has not yet been paid out. 	
	 * @param payoutId The identifier of the payout to be canceled.
	 * @return {Response} Returns a the payout object if the cancellation succeeded.
	 *  Returns an error if the payout has already been canceled or cannot be canceled.
	 */
    this.CancelPayoutRaw = function (payoutId) {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "CancelPayoutRaw", payoutId);
        return result;
    }

	/**
	 *  Returns a list of all refunds you’ve previously created. 	
	 * @param limit A dictionary with a data property that contains an array of up to limit payouts, starting after payout starting_after.
	 * @return {Response} A dictionary with a data property that contains an array of up to limit refunds, starting after refund starting_after.
	 *  Each entry in the array is a separate refund object. If no more refunds are available, the resulting array will be empty.
	 *  If you provide a non-existent charge ID, this call returns an error.
	 */
    this.ListRefundsRaw = function (limit) {
        var result = _bNesisApi.Call("Stripe", this.bNesisToken, "ListRefundsRaw", limit);
        return result;
    }
}
 StripeSource_types = function () { 
	this.card = new Double();

}

 StripeAvailable = function () { 
	this.currency = "";

	this.amount = new Double();

	this.source_types = new StripeSource_types();

}

 StripeConnect_reserved = function () { 
	this.currency = "";

	this.amount = new Double();

}

 StripeBalanceItemOut = function () { 
	this.objectStripe = "";

	this.available = new Array();

	this.connect_reserved = new Array();

	this.livemode = false;

	this.pending = new Array();

}

 StripeFee_details = function () { 
	this.amount = new Double();

	this.application = "";

	this.currency = "";

	this.description = "";

	this.type = "";

}

 RetrieveBalance = function () { 
	this.id = "";

	this.objectStripe = "";

	this.amount = new Double();

	this.available_on = "";

	this.created = "";

	this.currency = "";

	this.description = "";

	this.fee = new Double();

	this.fee_details = new Array();

	this.net = "";

	this.source = "";

	this.status = "";

	this.type = "";

}

