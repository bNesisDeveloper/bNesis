package bNesis.Sdk.Payment.Stripe;

import java.io.*;
import java.util.List;
import java.util.Date;
import java.util.Map.Entry;
import bNesis.Api.*;

import bNesis.Sdk.Common.*;
import java.net.URI.*;
import bNesis.Sdk.Payment.Stripe.*;

	public class Stripe  
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

		public Stripe(bNesisApi bnesisApi)
		{
			this._bNesisApi = bnesisApi;
		}

		/**
		 * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		 * @return {String} bNesisToken value
		 */
		public String Auth(String bNesisDevId,String clientId,String clientSecret,String redirectUrl,String[] scopes) throws Exception
		{
			bNesisToken = _bNesisApi.Auth("Stripe", "",bNesisDevId,redirectUrl,clientId,clientSecret,scopes,"","",false,"");
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
			Boolean result = _bNesisApi.LogoffService("Stripe", bNesisToken);
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
			return _bNesisApi.<ErrorInfo>Call(ErrorInfo.class, "Stripe", bNesisToken, "GetLastError");
		}

		/**
		 *  Getting arrays of error info 	
		 * @return {ErrorInfo[]}  
		 * @throws Exception
		 */
		public ErrorInfo[] GetErrorLog() throws Exception
		{
			return _bNesisApi.<ErrorInfo[]>Call(ErrorInfo[].class, "Stripe", bNesisToken, "GetErrorLog");
		}

		/**
		 *  Checks the token in the service. 	
		 * @return {Boolean} if token valid return true, if token not valid return false 
		 * @throws Exception
		 */
		public Boolean ValidateToken() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "Stripe", bNesisToken, "ValidateToken");
		}

		/**
		 *  Disables the access token used to authenticate the call. 	
		 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false 
		 * @throws Exception
		 */
		public Boolean Logoff() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "Stripe", bNesisToken, "Logoff");
		}

		/**
		 *   	
		 * @return {Balance[]}  
		 * @throws Exception
		 */
		public Balance[] BalanceUnified() throws Exception
		{
			return _bNesisApi.<Balance[]>Call(Balance[].class, "Stripe", bNesisToken, "BalanceUnified");
		}

		/**
		 *   	
		 * @param id 
	 * @return {RetrieveBalanceUnified}  
		 * @throws Exception
		 */
		public RetrieveBalanceUnified RetrieveBalancePosixUnified(String id) throws Exception
		{
			return _bNesisApi.<RetrieveBalanceUnified>Call(RetrieveBalanceUnified.class, "Stripe", bNesisToken, "RetrieveBalancePosixUnified", id);
		}

		/**
		 *   	
		 * @param id 
	 * @return {RetrieveBalanceUnified}  
		 * @throws Exception
		 */
		public RetrieveBalanceUnified RetrieveBalanceUnified(String id) throws Exception
		{
			return _bNesisApi.<RetrieveBalanceUnified>Call(RetrieveBalanceUnified.class, "Stripe", bNesisToken, "RetrieveBalanceUnified", id);
		}

		/**
		 *   	
		 * @param date_from 
	 * @param date_to 
	 * @param resp_format 
	 * @return {PaymentsArchive}  
		 * @throws Exception
		 */
		public PaymentsArchive GetPaymentHistoryUnified(String date_from, String date_to, String resp_format) throws Exception
		{
			return _bNesisApi.<PaymentsArchive>Call(PaymentsArchive.class, "Stripe", bNesisToken, "GetPaymentHistoryUnified", date_from, date_to, resp_format);
		}

		/**
		 *  Retrieves the current account balance, based on the authentication that was used to make the request. 	
		 * @return {Response} Returns a balance object for the account authenticated as. 
		 * @throws Exception
		 */
		public Response BalanceRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Stripe", bNesisToken, "BalanceRaw");
		}

		/**
		 *  Retrieves the current account balance, based on the authentication that was used to make the request. 	
		 * @return {StripeBalanceItemOut} Returns a balance object for the account authenticated as. 
		 * @throws Exception
		 */
		public StripeBalanceItemOut Balance() throws Exception
		{
			return _bNesisApi.<StripeBalanceItemOut>Call(StripeBalanceItemOut.class, "Stripe", bNesisToken, "Balance");
		}

		/**
		 *  Retrieves the balance transaction with the given ID. 	
		 * @param id The ID of the desired balance transaction (as found on any API object that affects the balance, e.g. a charge or transfer).
	 * @return {Response} Returns a balance transaction if a valid balance transaction ID was provided.
	 *  Returns an error otherwise. 
		 * @throws Exception
		 */
		public Response RetrieveBalanceRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Stripe", bNesisToken, "RetrieveBalanceRaw", id);
		}

		/**
		 *  Retrieves the balance transaction with the given ID. 	
		 * @param id The ID of the desired balance transaction (as found on any API object that affects the balance, e.g. a charge or transfer).
	 * @return {RetrieveBalance} Returns a balance transaction with POSIXTime. if a valid balance transaction ID was provided. 
	 *  Returns an error otherwise. 
		 * @throws Exception
		 */
		public RetrieveBalance RetrieveBalancePosix(String id) throws Exception
		{
			return _bNesisApi.<RetrieveBalance>Call(RetrieveBalance.class, "Stripe", bNesisToken, "RetrieveBalancePosix", id);
		}

		/**
		 *  Retrieves the balance transaction with the given ID. 	
		 * @param id The ID of the desired balance transaction (as found on any API object that affects the balance, e.g. a charge or transfer).
	 * @return {RetrieveBalance} Returns a balance transaction if a valid balance transaction ID was provided.
	 *  Returns an error otherwise. 
		 * @throws Exception
		 */
		public RetrieveBalance RetrieveBalance(String id) throws Exception
		{
			return _bNesisApi.<RetrieveBalance>Call(RetrieveBalance.class, "Stripe", bNesisToken, "RetrieveBalance", id);
		}

		/**
		 *  Returns a list of transactions that have contributed to the Stripe account balance (e.g., charges, transfers, and so forth).
	 * The transactions are returned in sorted order, with the most recent transactions appearing first. 	
		 * @return {Response} A dictionary with a data property that contains an array of up to limit transactions, starting after transaction starting_after.
	 *  Each entry in the array is a separate transaction history object.
	 *  If no more transactions are available, the resulting array will be empty. 
		 * @throws Exception
		 */
		public Response ListBalanceHistoryRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Stripe", bNesisToken, "ListBalanceHistoryRaw");
		}

		/**
		 *  To charge a credit card, you create a Charge object.
	 * If your API key is in test mode, the supplied payment source (e.g., card) won't actually be charged, though everything else will occur as if in live mode.
	 * (Stripe assumes that the charge would have completed successfully). 	
		 * @param arguments https://stripe.com/docs/api/curl#create_charge
	 * @return {Response} Returns a Charge object if the charge succeeded.
	 * Returns an error if something goes wrong. 
	 * A common source of error is an invalid or expired card, or a valid card with insufficient available balance. 
		 * @throws Exception
		 */
		public Response CreateChargeRaw(String arguments) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Stripe", bNesisToken, "CreateChargeRaw", arguments);
		}

		/**
		 *  Returns a list of charges you've previously created. The charges are returned in sorted order, with the most recent charges appearing first. 	
		 * @param limit A limit on the number of objects to be returned, between 1 and 100.
	 * @return {Response} A dictionary with a data property that contains an array of up to limit charges, starting after charge starting_after. Each entry in the array is a separate charge object. If no more charges are available, the resulting array will be empty. If you provide a non-existent customer ID, this call returns an error. 
		 * @throws Exception
		 */
		public Response ListChargesRaw(String limit) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Stripe", bNesisToken, "ListChargesRaw", limit);
		}

		/**
		 *  Retrieves the details of a charge that has previously been created.
	 * Supply the unique charge ID that was returned from your previous request, and Stripe will return the corresponding charge information.
	 * The same information is returned when creating or refunding the charge. 	
		 * @param chargeId The identifier of the charge to be retrieved.
	 * @return {Response} Returns a charge if a valid identifier was provided, and returns an error otherwise. 
		 * @throws Exception
		 */
		public Response RetrieveChargeRaw(String chargeId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Stripe", bNesisToken, "RetrieveChargeRaw", chargeId);
		}

		/**
		 *  Updates the specified charge by setting the values of the parameters passed. Any parameters not provided will be left unchanged. 	
		 * @param chargeId The identifier of the charge to be retrieved.
	 * @param arguments This request accepts only the description, metadata, receipt_email, fraud_details, and shipping as arguments.
	 * @return {Response} Returns the charge object if the update succeeded. This call will return an error if update parameters are invalid. 
		 * @throws Exception
		 */
		public Response UpdateChargeRaw(String chargeId, String arguments) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Stripe", bNesisToken, "UpdateChargeRaw", chargeId, arguments);
		}

		/**
		 *  Capture the payment of an existing, uncaptured, charge.
	 * This is the second half of the two-step payment flow, where first you created a charge with the capture option set to false. 	
		 * @param chargeId The identifier of the charge to be retrieved
	 * @return {Response} Returns the charge object, with an updated captured property (set to true).
	 *  Capturing a charge will always succeed, unless the charge is already refunded, expired,
	 *  captured, or an invalid capture amount is specified, in which case this method will return an error. 
		 * @throws Exception
		 */
		public Response CaptureChargeRaw(String chargeId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Stripe", bNesisToken, "CaptureChargeRaw", chargeId);
		}

		/**
		 *  Creates a new customer object. 	
		 * @param arguments https://stripe.com/docs/api/curl#create_customer
	 * @return {Response} Returns a customer object if the call succeeded.
	 * The returned object will have information about subscriptions, discount, and payment sources, if that information has been provided. 
	 * If an invoice payment is due and a source is not provided, the call will return an error.
	 * If a non-existent plan or a non-existent or expired coupon is provided, the call will return an error. 
		 * @throws Exception
		 */
		public Response CreateCustomerRaw(String arguments) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Stripe", bNesisToken, "CreateCustomerRaw", arguments);
		}

		/**
		 *  Retrieves the details of an existing customer.
	 * You need only supply the unique customer identifier that was returned upon customer creation. 	
		 * @param customerId The identifier of the customer to be retrieved.
	 * @return {Response} Returns a customer object if a valid identifier was provided. 
	 * When requesting the ID of a customer that has been deleted, a subset of the customer's information will be returned, including a deleted property, which will be true. 
		 * @throws Exception
		 */
		public Response RetrieveCustomerRaw(String customerId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Stripe", bNesisToken, "RetrieveCustomerRaw", customerId);
		}

		/**
		 *  Updates the specified customer by setting the values of the parameters passed. 	
		 * @param customerId The identifier of the customer to be retrieved.
	 * @param arguments https://stripe.com/docs/api/curl#update_customer
	 * @return {Response} Returns the customer object if the update succeeded.
	 *  Returns an error if update parameters are invalid (e.g. specifying an invalid coupon or an invalid source). 
		 * @throws Exception
		 */
		public Response UpdateCustomerRaw(String customerId, String arguments) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Stripe", bNesisToken, "UpdateCustomerRaw", customerId, arguments);
		}

		/**
		 *  Permanently deletes a customer. It cannot be undone. Also immediately cancels any active subscriptions on the customer. 	
		 * @param customerId The identifier of the customer to be deleted.
	 * @return {Response} Returns an object with a deleted parameter on success. 
	 * If the customer ID does not exist, this call returns an error. 
		 * @throws Exception
		 */
		public Response DeleteCustomerRaw(String customerId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Stripe", bNesisToken, "DeleteCustomerRaw", customerId);
		}

		/**
		 *  Returns a list of your customers.
	 * The customers are returned sorted by creation date, with the most recent customers appearing first. 	
		 * @param limit A limit on the number of objects to be returned. Limit can range between 1 and 100 items, and the default is 10 items.
	 * @return {Response} A dictionary with a data property that contains an array of up to limit customers, starting after customer starting_after.
	 *  Each entry in the array is a separate customer object.
	 *  If no more customers are available, the resulting array will be empty.
	 *  This request should never return an error. 
		 * @throws Exception
		 */
		public Response ListCustomersRaw(String limit) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Stripe", bNesisToken, "ListCustomersRaw", limit);
		}

		/**
		 *  Retrieves the dispute with the given ID. 	
		 * @param disputeId ID of dispute to retrieve.
	 * @return {Response} Returns a dispute if a valid dispute ID was provided. Returns an error otherwise. 
		 * @throws Exception
		 */
		public Response RetrieveDisputeRaw(String disputeId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Stripe", bNesisToken, "RetrieveDisputeRaw", disputeId);
		}

		/**
		 *  Retrieves the dispute with the given ID. 	
		 * @param disputeId ID of dispute to retrieve.
	 * @param evidenceField Evidence to upload to respond to a dispute.
	 *  Updating any field in the hash will submit all fields in the hash for review.
	 * @return {Response} Returns a dispute if a valid dispute ID was provided. Returns an error otherwise. 
		 * @throws Exception
		 */
		public Response UpdateDisputeRaw(String disputeId, String evidenceField) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Stripe", bNesisToken, "UpdateDisputeRaw", disputeId, evidenceField);
		}

		/**
		 *  Closing the dispute for a charge indicates that you do not have any evidence to submit and are essentially 'dismissing' the dispute, acknowledging it as lost 	
		 * @param disputeId ID of dispute to close.
	 * @return {Response} Returns the dispute object. 
		 * @throws Exception
		 */
		public Response CloseDisputeRaw(String disputeId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Stripe", bNesisToken, "CloseDisputeRaw", disputeId);
		}

		/**
		 *  Returns a list of your disputes. 	
		 * @param limit A limit on the number of objects to be returned. Limit can range between 1 and 100 items, and the default is 10 items.
	 * @return {Response} A dictionary with a data property that contains an array of up to limit disputes, starting after dispute starting_after.
	 * Each entry in the array is a separate dispute object. If no more disputes are available, the resulting array will be empty. 
	 * This request should never return an error. 
		 * @throws Exception
		 */
		public Response ListDisputesRaw(String limit) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Stripe", bNesisToken, "ListDisputesRaw", limit);
		}

		/**
		 *  Retrieves the details of an event. Supply the unique identifier of the event, which you might have received in a webhook. 	
		 * @param id The identifier of the event to be retrieved.
	 * @return {Response} Returns an event object if a valid identifier was provided.
	 *  All events share a common structure, detailed to the right.
	 *  The only property that will differ is the data property. 
		 * @throws Exception
		 */
		public Response RetrieveEventRaw(String id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Stripe", bNesisToken, "RetrieveEventRaw", id);
		}

		/**
		 *  List events, going back up to 30 days. 	
		 * @param limit A limit on the number of objects to be returned. Limit can range between 1 and 100 items, and the default is 10 items.
	 * @return {Response} A dictionary with a data property that contains an array of up to limit events, starting after event starting_after. Each entry in the array is a separate event object.
	 *  If no more events are available, the resulting array will be empty.
	 *  This request should never return an error. 
		 * @throws Exception
		 */
		public Response ListEventsRaw(String limit) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Stripe", bNesisToken, "ListEventsRaw", limit);
		}

		/**
		 *  Creates a new customer payout object. 	
		 * @param arguments https://stripe.com/docs/api/curl#create_payout
	 * @return {Response} Returns a payout object if there were no initial errors with the payout creation (invalid routing number, insufficient funds, etc).
	 *  The status of the payout object will be initially marked as pending. 
		 * @throws Exception
		 */
		public Response CreatePayoutRaw(String arguments) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Stripe", bNesisToken, "CreatePayoutRaw", arguments);
		}

		/**
		 *  Retrieves the details of an existing payout. 	
		 * @param payoutId The identifier of the payout to be retrieved.
	 * @return {Response} Returns a payout object if a valid identifier was provided, and returns an error otherwise. 
		 * @throws Exception
		 */
		public Response RetrievePayoutRaw(String payoutId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Stripe", bNesisToken, "RetrievePayoutRaw", payoutId);
		}

		/**
		 *  Updates the specified payout by setting the values of the parameters passed. Any parameters not provided will be left unchanged. This request accepts only the metadata as arguments. 	
		 * @param payoutId The identifier of the payout to be retrieved.
	 * @param arguments https://stripe.com/docs/api/curl#update_payout
	 * @return {Response} Returns the payout object if the update succeeded.
	 *  This call returns an error if update parameters are invalid. 
		 * @throws Exception
		 */
		public Response UpdatePayoutRaw(String payoutId, String arguments) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Stripe", bNesisToken, "UpdatePayoutRaw", payoutId, arguments);
		}

		/**
		 *  Returns a list of existing payouts sent to third-party bank accounts or that Stripe has sent you. The payouts are returned in sorted order, with the most recently created payouts appearing first. 	
		 * @param limit A dictionary with a data property that contains an array of up to limit payouts, starting after payout starting_after.
	 * @return {Response} Each entry in the array is a separate payout object.
	 *  If no more payouts are available, the resulting array will be empty. 
		 * @throws Exception
		 */
		public Response ListPayoutRaw(String limit) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Stripe", bNesisToken, "ListPayoutRaw", limit);
		}

		/**
		 *  A previously created payout can be canceled if it has not yet been paid out. 	
		 * @param payoutId The identifier of the payout to be canceled.
	 * @return {Response} Returns a the payout object if the cancellation succeeded.
	 *  Returns an error if the payout has already been canceled or cannot be canceled. 
		 * @throws Exception
		 */
		public Response CancelPayoutRaw(String payoutId) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Stripe", bNesisToken, "CancelPayoutRaw", payoutId);
		}

		/**
		 *  Returns a list of all refunds you've previously created. 	
		 * @param limit A dictionary with a data property that contains an array of up to limit payouts, starting after payout starting_after.
	 * @return {Response} A dictionary with a data property that contains an array of up to limit refunds, starting after refund starting_after.
	 *  Each entry in the array is a separate refund object. If no more refunds are available, the resulting array will be empty.
	 *  If you provide a non-existent charge ID, this call returns an error. 
		 * @throws Exception
		 */
		public Response ListRefundsRaw(String limit) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "Stripe", bNesisToken, "ListRefundsRaw", limit);
		}
}