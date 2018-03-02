using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;
using bNesis.Api.Desktop;
using bNesis.Sdk.Common;

namespace bNesis.Sdk.Payment.Stripe
{
	public class Stripe  
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

		public Stripe(DesktopbNesisApi bNesisApi)
		{
			this.bNesisApi = bNesisApi;
		}

		/// <summary>
		/// The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		/// </summary>
		/// <returns>bNesisToken value</returns>	
		public string Auth(string data,string bNesisDevId,string redirectUrl,string clientId,string clientSecret,string[] scopes,string login,string password,bool isSandbox,string serviceUrl)
		{
			bNesisToken = bNesisApi.Auth("Stripe", data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl);
			return bNesisToken;
		}

		/// <summary>
		/// The method stops the authorization session with the service and clears the value of bNesisToken.
		/// </summary>
		/// <returns>true - if service logoff is successful</returns>
		public bool LogoffService()
		{
			bool result = bNesisApi.LogoffService("Stripe", bNesisToken);
			if (result) bNesisToken = string.Empty;
			return result;             
		}


		///<summary>
		/// Getting last exception for current provider 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo GetLastError()
		{
			return bNesisApi.Call<ErrorInfo>("Stripe", bNesisToken, "GetLastError");
		}

		///<summary>
		/// Getting arrays of error info 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo[] GetErrorLog()
		{
			return bNesisApi.Call<ErrorInfo[]>("Stripe", bNesisToken, "GetErrorLog");
		}

		///<summary>
		/// Checks the token in the service. 
		/// </summary>
		/// <returns>if token valid return true, if token not valid return false</returns>
		public Boolean ValidateToken()
		{
			return bNesisApi.Call<Boolean>("Stripe", bNesisToken, "ValidateToken");
		}

		///<summary>
		/// Disables the access token used to authenticate the call. 
		/// </summary>
		/// <returns>if token revoked method returns true 
		/// if token doesn't support token revocation or token is revoked method returns false</returns>
		public Boolean Logoff()
		{
			return bNesisApi.Call<Boolean>("Stripe", bNesisToken, "Logoff");
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public Balance[] BalanceUnified()
		{
			return bNesisApi.Call<Balance[]>("Stripe", bNesisToken, "BalanceUnified");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public RetrieveBalanceUnified RetrieveBalancePosixUnified(string id)
		{
			return bNesisApi.Call<RetrieveBalanceUnified>("Stripe", bNesisToken, "RetrieveBalancePosixUnified", id);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public RetrieveBalanceUnified RetrieveBalanceUnified(string id)
		{
			return bNesisApi.Call<RetrieveBalanceUnified>("Stripe", bNesisToken, "RetrieveBalanceUnified", id);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="date_from"></param>
		/// <param name="date_to"></param>
		/// <param name="resp_format"></param>
		/// <returns></returns>
		public PaymentsArchive GetPaymentHistoryUnified(string date_from, string date_to, string resp_format)
		{
			return bNesisApi.Call<PaymentsArchive>("Stripe", bNesisToken, "GetPaymentHistoryUnified", date_from, date_to, resp_format);
		}

		///<summary>
		/// Retrieves the current account balance, based on the authentication that was used to make the request. 
		/// </summary>
		/// <returns>Returns a balance object for the account authenticated as.</returns>
		public Response BalanceRaw()
		{
			return bNesisApi.Call<Response>("Stripe", bNesisToken, "BalanceRaw");
		}

		///<summary>
		/// Retrieves the current account balance, based on the authentication that was used to make the request. 
		/// </summary>
		/// <returns>Returns a balance object for the account authenticated as.</returns>
		public StripeBalanceItemOut Balance()
		{
			return bNesisApi.Call<StripeBalanceItemOut>("Stripe", bNesisToken, "Balance");
		}

		///<summary>
		/// Retrieves the balance transaction with the given ID. 
		/// </summary>
		/// <param name="id">The ID of the desired balance transaction (as found on any API object that affects the balance, e.g. a charge or transfer).</param>
		/// <returns>Returns a balance transaction if a valid balance transaction ID was provided.
		///  Returns an error otherwise.</returns>
		public Response RetrieveBalanceRaw(string id)
		{
			return bNesisApi.Call<Response>("Stripe", bNesisToken, "RetrieveBalanceRaw", id);
		}

		///<summary>
		/// Retrieves the balance transaction with the given ID. 
		/// </summary>
		/// <param name="id">The ID of the desired balance transaction (as found on any API object that affects the balance, e.g. a charge or transfer).</param>
		/// <returns>Returns a balance transaction with POSIXTime. if a valid balance transaction ID was provided. 
		///  Returns an error otherwise.</returns>
		public RetrieveBalance RetrieveBalancePosix(string id)
		{
			return bNesisApi.Call<RetrieveBalance>("Stripe", bNesisToken, "RetrieveBalancePosix", id);
		}

		///<summary>
		/// Retrieves the balance transaction with the given ID. 
		/// </summary>
		/// <param name="id">The ID of the desired balance transaction (as found on any API object that affects the balance, e.g. a charge or transfer).</param>
		/// <returns>Returns a balance transaction if a valid balance transaction ID was provided.
		///  Returns an error otherwise.</returns>
		public RetrieveBalance RetrieveBalance(string id)
		{
			return bNesisApi.Call<RetrieveBalance>("Stripe", bNesisToken, "RetrieveBalance", id);
		}

		///<summary>
		/// Returns a list of transactions that have contributed to the Stripe account balance (e.g., charges, transfers, and so forth).
		/// The transactions are returned in sorted order, with the most recent transactions appearing first. 
		/// </summary>
		/// <returns>A dictionary with a data property that contains an array of up to limit transactions, starting after transaction starting_after.
		///  Each entry in the array is a separate transaction history object.
		///  If no more transactions are available, the resulting array will be empty.</returns>
		public Response ListBalanceHistoryRaw()
		{
			return bNesisApi.Call<Response>("Stripe", bNesisToken, "ListBalanceHistoryRaw");
		}

		///<summary>
		/// To charge a credit card, you create a Charge object.
		/// If your API key is in test mode, the supplied payment source (e.g., card) won't actually be charged, though everything else will occur as if in live mode.
		/// (Stripe assumes that the charge would have completed successfully). 
		/// </summary>
		/// <param name="arguments">https://stripe.com/docs/api/curl#create_charge</param>
		/// <returns>Returns a Charge object if the charge succeeded.
		/// Returns an error if something goes wrong. 
		/// A common source of error is an invalid or expired card, or a valid card with insufficient available balance.</returns>
		public Response CreateChargeRaw(string arguments)
		{
			return bNesisApi.Call<Response>("Stripe", bNesisToken, "CreateChargeRaw", arguments);
		}

		///<summary>
		/// Returns a list of charges you’ve previously created. The charges are returned in sorted order, with the most recent charges appearing first. 
		/// </summary>
		/// <param name="limit">A limit on the number of objects to be returned, between 1 and 100.</param>
		/// <returns>A dictionary with a data property that contains an array of up to limit charges, starting after charge starting_after. Each entry in the array is a separate charge object. If no more charges are available, the resulting array will be empty. If you provide a non-existent customer ID, this call returns an error.</returns>
		public Response ListChargesRaw(string limit)
		{
			return bNesisApi.Call<Response>("Stripe", bNesisToken, "ListChargesRaw", limit);
		}

		///<summary>
		/// Retrieves the details of a charge that has previously been created.
		/// Supply the unique charge ID that was returned from your previous request, and Stripe will return the corresponding charge information.
		/// The same information is returned when creating or refunding the charge. 
		/// </summary>
		/// <param name="chargeId">The identifier of the charge to be retrieved.</param>
		/// <returns>Returns a charge if a valid identifier was provided, and returns an error otherwise.</returns>
		public Response RetrieveChargeRaw(string chargeId)
		{
			return bNesisApi.Call<Response>("Stripe", bNesisToken, "RetrieveChargeRaw", chargeId);
		}

		///<summary>
		/// Updates the specified charge by setting the values of the parameters passed. Any parameters not provided will be left unchanged. 
		/// </summary>
		/// <param name="chargeId">The identifier of the charge to be retrieved.</param>
		/// <param name="arguments">This request accepts only the description, metadata, receipt_email, fraud_details, and shipping as arguments.</param>
		/// <returns>Returns the charge object if the update succeeded. This call will return an error if update parameters are invalid.</returns>
		public Response UpdateChargeRaw(string chargeId, string arguments)
		{
			return bNesisApi.Call<Response>("Stripe", bNesisToken, "UpdateChargeRaw", chargeId, arguments);
		}

		///<summary>
		/// Capture the payment of an existing, uncaptured, charge.
		/// This is the second half of the two-step payment flow, where first you created a charge with the capture option set to false. 
		/// </summary>
		/// <param name="chargeId">The identifier of the charge to be retrieved</param>
		/// <returns>Returns the charge object, with an updated captured property (set to true).
		///  Capturing a charge will always succeed, unless the charge is already refunded, expired,
		///  captured, or an invalid capture amount is specified, in which case this method will return an error.</returns>
		public Response CaptureChargeRaw(string chargeId)
		{
			return bNesisApi.Call<Response>("Stripe", bNesisToken, "CaptureChargeRaw", chargeId);
		}

		///<summary>
		/// Creates a new customer object. 
		/// </summary>
		/// <param name="arguments">https://stripe.com/docs/api/curl#create_customer</param>
		/// <returns>Returns a customer object if the call succeeded.
		/// The returned object will have information about subscriptions, discount, and payment sources, if that information has been provided. 
		/// If an invoice payment is due and a source is not provided, the call will return an error.
		/// If a non-existent plan or a non-existent or expired coupon is provided, the call will return an error.</returns>
		public Response CreateCustomerRaw(string arguments)
		{
			return bNesisApi.Call<Response>("Stripe", bNesisToken, "CreateCustomerRaw", arguments);
		}

		///<summary>
		/// Retrieves the details of an existing customer.
		/// You need only supply the unique customer identifier that was returned upon customer creation. 
		/// </summary>
		/// <param name="customerId">The identifier of the customer to be retrieved.</param>
		/// <returns>Returns a customer object if a valid identifier was provided. 
		/// When requesting the ID of a customer that has been deleted, a subset of the customer’s information will be returned, including a deleted property, which will be true.</returns>
		public Response RetrieveCustomerRaw(string customerId)
		{
			return bNesisApi.Call<Response>("Stripe", bNesisToken, "RetrieveCustomerRaw", customerId);
		}

		///<summary>
		/// Updates the specified customer by setting the values of the parameters passed. 
		/// </summary>
		/// <param name="customerId">The identifier of the customer to be retrieved.</param>
		/// <param name="arguments">https://stripe.com/docs/api/curl#update_customer</param>
		/// <returns>Returns the customer object if the update succeeded.
		///  Returns an error if update parameters are invalid (e.g. specifying an invalid coupon or an invalid source).</returns>
		public Response UpdateCustomerRaw(string customerId, string arguments)
		{
			return bNesisApi.Call<Response>("Stripe", bNesisToken, "UpdateCustomerRaw", customerId, arguments);
		}

		///<summary>
		/// Permanently deletes a customer. It cannot be undone. Also immediately cancels any active subscriptions on the customer. 
		/// </summary>
		/// <param name="customerId">The identifier of the customer to be deleted.</param>
		/// <returns>Returns an object with a deleted parameter on success. 
		/// If the customer ID does not exist, this call returns an error.</returns>
		public Response DeleteCustomerRaw(string customerId)
		{
			return bNesisApi.Call<Response>("Stripe", bNesisToken, "DeleteCustomerRaw", customerId);
		}

		///<summary>
		/// Returns a list of your customers.
		/// The customers are returned sorted by creation date, with the most recent customers appearing first. 
		/// </summary>
		/// <param name="limit">A limit on the number of objects to be returned. Limit can range between 1 and 100 items, and the default is 10 items.</param>
		/// <returns>A dictionary with a data property that contains an array of up to limit customers, starting after customer starting_after.
		///  Each entry in the array is a separate customer object.
		///  If no more customers are available, the resulting array will be empty.
		///  This request should never return an error.</returns>
		public Response ListCustomersRaw(string limit)
		{
			return bNesisApi.Call<Response>("Stripe", bNesisToken, "ListCustomersRaw", limit);
		}

		///<summary>
		/// Retrieves the dispute with the given ID. 
		/// </summary>
		/// <param name="disputeId">ID of dispute to retrieve.</param>
		/// <returns>Returns a dispute if a valid dispute ID was provided. Returns an error otherwise.</returns>
		public Response RetrieveDisputeRaw(string disputeId)
		{
			return bNesisApi.Call<Response>("Stripe", bNesisToken, "RetrieveDisputeRaw", disputeId);
		}

		///<summary>
		/// Retrieves the dispute with the given ID. 
		/// </summary>
		/// <param name="disputeId">ID of dispute to retrieve.</param>
		/// <param name="evidenceField">Evidence to upload to respond to a dispute.
		///  Updating any field in the hash will submit all fields in the hash for review.</param>
		/// <returns>Returns a dispute if a valid dispute ID was provided. Returns an error otherwise.</returns>
		public Response UpdateDisputeRaw(string disputeId, string evidenceField)
		{
			return bNesisApi.Call<Response>("Stripe", bNesisToken, "UpdateDisputeRaw", disputeId, evidenceField);
		}

		///<summary>
		/// Closing the dispute for a charge indicates that you do not have any evidence to submit and are essentially ‘dismissing’ the dispute, acknowledging it as lost 
		/// </summary>
		/// <param name="disputeId">ID of dispute to close.</param>
		/// <returns>Returns the dispute object.</returns>
		public Response CloseDisputeRaw(string disputeId)
		{
			return bNesisApi.Call<Response>("Stripe", bNesisToken, "CloseDisputeRaw", disputeId);
		}

		///<summary>
		/// Returns a list of your disputes. 
		/// </summary>
		/// <param name="limit">A limit on the number of objects to be returned. Limit can range between 1 and 100 items, and the default is 10 items.</param>
		/// <returns>A dictionary with a data property that contains an array of up to limit disputes, starting after dispute starting_after.
		/// Each entry in the array is a separate dispute object. If no more disputes are available, the resulting array will be empty. 
		/// This request should never return an error.</returns>
		public Response ListDisputesRaw(string limit)
		{
			return bNesisApi.Call<Response>("Stripe", bNesisToken, "ListDisputesRaw", limit);
		}

		///<summary>
		/// Retrieves the details of an event. Supply the unique identifier of the event, which you might have received in a webhook. 
		/// </summary>
		/// <param name="id">The identifier of the event to be retrieved.</param>
		/// <returns>Returns an event object if a valid identifier was provided.
		///  All events share a common structure, detailed to the right.
		///  The only property that will differ is the data property.</returns>
		public Response RetrieveEventRaw(string id)
		{
			return bNesisApi.Call<Response>("Stripe", bNesisToken, "RetrieveEventRaw", id);
		}

		///<summary>
		/// List events, going back up to 30 days. 
		/// </summary>
		/// <param name="limit">A limit on the number of objects to be returned. Limit can range between 1 and 100 items, and the default is 10 items.</param>
		/// <returns>A dictionary with a data property that contains an array of up to limit events, starting after event starting_after. Each entry in the array is a separate event object.
		///  If no more events are available, the resulting array will be empty.
		///  This request should never return an error.</returns>
		public Response ListEventsRaw(string limit)
		{
			return bNesisApi.Call<Response>("Stripe", bNesisToken, "ListEventsRaw", limit);
		}

		///<summary>
		/// Creates a new customer payout object. 
		/// </summary>
		/// <param name="arguments">https://stripe.com/docs/api/curl#create_payout</param>
		/// <returns>Returns a payout object if there were no initial errors with the payout creation (invalid routing number, insufficient funds, etc).
		///  The status of the payout object will be initially marked as pending.</returns>
		public Response CreatePayoutRaw(string arguments)
		{
			return bNesisApi.Call<Response>("Stripe", bNesisToken, "CreatePayoutRaw", arguments);
		}

		///<summary>
		/// Retrieves the details of an existing payout. 
		/// </summary>
		/// <param name="payoutId">The identifier of the payout to be retrieved.</param>
		/// <returns>Returns a payout object if a valid identifier was provided, and returns an error otherwise.</returns>
		public Response RetrievePayoutRaw(string payoutId)
		{
			return bNesisApi.Call<Response>("Stripe", bNesisToken, "RetrievePayoutRaw", payoutId);
		}

		///<summary>
		/// Updates the specified payout by setting the values of the parameters passed. Any parameters not provided will be left unchanged. This request accepts only the metadata as arguments. 
		/// </summary>
		/// <param name="payoutId">The identifier of the payout to be retrieved.</param>
		/// <param name="arguments">https://stripe.com/docs/api/curl#update_payout</param>
		/// <returns>Returns the payout object if the update succeeded.
		///  This call returns an error if update parameters are invalid.</returns>
		public Response UpdatePayoutRaw(string payoutId, string arguments)
		{
			return bNesisApi.Call<Response>("Stripe", bNesisToken, "UpdatePayoutRaw", payoutId, arguments);
		}

		///<summary>
		/// Returns a list of existing payouts sent to third-party bank accounts or that Stripe has sent you. The payouts are returned in sorted order, with the most recently created payouts appearing first. 
		/// </summary>
		/// <param name="limit">A dictionary with a data property that contains an array of up to limit payouts, starting after payout starting_after.</param>
		/// <returns>Each entry in the array is a separate payout object.
		///  If no more payouts are available, the resulting array will be empty.</returns>
		public Response ListPayoutRaw(string limit)
		{
			return bNesisApi.Call<Response>("Stripe", bNesisToken, "ListPayoutRaw", limit);
		}

		///<summary>
		/// A previously created payout can be canceled if it has not yet been paid out. 
		/// </summary>
		/// <param name="payoutId">The identifier of the payout to be canceled.</param>
		/// <returns>Returns a the payout object if the cancellation succeeded.
		///  Returns an error if the payout has already been canceled or cannot be canceled.</returns>
		public Response CancelPayoutRaw(string payoutId)
		{
			return bNesisApi.Call<Response>("Stripe", bNesisToken, "CancelPayoutRaw", payoutId);
		}

		///<summary>
		/// Returns a list of all refunds you’ve previously created. 
		/// </summary>
		/// <param name="limit">A dictionary with a data property that contains an array of up to limit payouts, starting after payout starting_after.</param>
		/// <returns>A dictionary with a data property that contains an array of up to limit refunds, starting after refund starting_after.
		///  Each entry in the array is a separate refund object. If no more refunds are available, the resulting array will be empty.
		///  If you provide a non-existent charge ID, this call returns an error.</returns>
		public Response ListRefundsRaw(string limit)
		{
			return bNesisApi.Call<Response>("Stripe", bNesisToken, "ListRefundsRaw", limit);
		}
}
	public class StripeSource_types
	{
		public Double card { get; set; }

	}

	public class StripeAvailable
	{
		public string currency { get; set; }

		public Double amount { get; set; }

		public StripeSource_types source_types { get; set; }

	}

	public class StripeConnect_reserved
	{
		public string currency { get; set; }

		public Double amount { get; set; }

	}

	public class StripeBalanceItemOut
	{
		public string objectStripe { get; set; }

		public StripeAvailable[] available { get; set; }

		public StripeConnect_reserved[] connect_reserved { get; set; }

		public Boolean livemode { get; set; }

		public StripeSource_types[] pending { get; set; }

	}

	public class StripeFee_details
	{
		public Double amount { get; set; }

		public string application { get; set; }

		public string currency { get; set; }

		public string description { get; set; }

		public string type { get; set; }

	}

	public class RetrieveBalance
	{
		public string id { get; set; }

		public string objectStripe { get; set; }

		public Double amount { get; set; }

		public string available_on { get; set; }

		public string created { get; set; }

		public string currency { get; set; }

		public string description { get; set; }

		public Double fee { get; set; }

		public StripeFee_details[] fee_details { get; set; }

		public string net { get; set; }

		public string source { get; set; }

		public string status { get; set; }

		public string type { get; set; }

	}

}