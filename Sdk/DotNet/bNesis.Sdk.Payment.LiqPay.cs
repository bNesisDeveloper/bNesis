using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;
using bNesis.Api.Desktop;
using bNesis.Sdk.Common;

namespace bNesis.Sdk.Payment.LiqPay
{
	public class LiqPay  
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

		public LiqPay(DesktopbNesisApi bNesisApi)
		{
			this.bNesisApi = bNesisApi;
		}

		/// <summary>
		/// The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		/// </summary>
		/// <returns>bNesisToken value</returns>	
		public string Auth(string bNesisDevId,string clientId,string clientSecret,string redirectUrl,string login)
		{
			bNesisToken = bNesisApi.Auth("LiqPay", string.Empty,bNesisDevId,redirectUrl,clientId,clientSecret,null,login,string.Empty,false,string.Empty);
			return bNesisToken;
		}

		/// <summary>
		/// Attach to bNesis session with exists bNesis token
		/// </summary>		
		/// <returns>true if bNesisToken is valid</returns>	
		public bool Auth(string bNesisToken)
		{
		    this.bNesisToken = bNesisToken;			
			return ValidateToken();
		}

		/// <summary>
		/// The method stops the authorization session with the service and clears the value of bNesisToken.
		/// </summary>
		/// <returns>true - if service logoff is successful</returns>
		public bool LogoffService()
		{
			bool result = bNesisApi.LogoffService("LiqPay", bNesisToken);
			if (result) bNesisToken = string.Empty;
			return result;             
		}


		///<summary>
		/// Getting last exception for current provider 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo GetLastError()
		{
			return bNesisApi.Call<ErrorInfo>("LiqPay", bNesisToken, "GetLastError");
		}

		///<summary>
		/// Getting arrays of error info 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo[] GetErrorLog()
		{
			return bNesisApi.Call<ErrorInfo[]>("LiqPay", bNesisToken, "GetErrorLog");
		}

		///<summary>
		/// Checks the token in the service. 
		/// </summary>
		/// <returns>if token valid return true, if token not valid return false</returns>
		public Boolean ValidateToken()
		{
			return bNesisApi.Call<Boolean>("LiqPay", bNesisToken, "ValidateToken");
		}

		///<summary>
		/// Disables the access token used to authenticate the call. 
		/// </summary>
		/// <returns>if token revoked method returns true 
		/// if token doesn't support token revocation or token is revoked method returns false</returns>
		public Boolean Logoff()
		{
			return bNesisApi.Call<Boolean>("LiqPay", bNesisToken, "Logoff");
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public Balance[] BalanceUnified()
		{
			return bNesisApi.Call<Balance[]>("LiqPay", bNesisToken, "BalanceUnified");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public RetrieveBalanceUnified RetrieveBalancePosixUnified(string id)
		{
			return bNesisApi.Call<RetrieveBalanceUnified>("LiqPay", bNesisToken, "RetrieveBalancePosixUnified", id);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public RetrieveBalanceUnified RetrieveBalanceUnified(string id)
		{
			return bNesisApi.Call<RetrieveBalanceUnified>("LiqPay", bNesisToken, "RetrieveBalanceUnified", id);
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
			return bNesisApi.Call<PaymentsArchive>("LiqPay", bNesisToken, "GetPaymentHistoryUnified", date_from, date_to, resp_format);
		}

		///<summary>
		/// Gets the link for payment. 
		/// </summary>
		/// <param name="amount">Payment amount. For example: 5, 7.34</param>
		/// <param name="sandbox">Enables the testing environment for developers. 
		/// Payer card will not be charged. To enable testing environment you will need to transmit value 1. 
		/// All test payments will have the status sandbox - successful test payment.</param>
		/// <returns></returns>
		public Response GetLinkForPaymentRaw(Double amount, string sandbox)
		{
			return bNesisApi.Call<Response>("LiqPay", bNesisToken, "GetLinkForPaymentRaw", amount, sandbox);
		}

		///<summary>
		/// Gets the payment history. 
		/// </summary>
		/// <param name="date_from">Start date of a report in timestamp in milliseconds. Exemp: 1443161386000</param>
		/// <param name="date_to">End date of a report in timestamp in milliseconds. Exemp: 1443164386000</param>
		/// <param name="resp_format">Possible report format json, csv, xml. If parameter is not passed, will be passed by default json.</param>
		/// <returns>The archive of all received payments</returns>
		public LiqPayPaymentsArchive GetPaymentHistory(string date_from, string date_to, string resp_format)
		{
			return bNesisApi.Call<LiqPayPaymentsArchive>("LiqPay", bNesisToken, "GetPaymentHistory", date_from, date_to, resp_format);
		}

		///<summary>
		/// Gets the payment history. 
		/// </summary>
		/// <param name="date_from">Start date of a report in timestamp in milliseconds. Exemp: 1443161386000</param>
		/// <param name="date_to">End date of a report in timestamp in milliseconds. Exemp: 1443164386000</param>
		/// <param name="resp_format">Possible report format json, csv, xml. If parameter is not passed, will be passed by default json.</param>
		/// <returns>The archive of all received payments</returns>
		public Response GetPaymentHistoryRaw(string date_from, string date_to, string resp_format)
		{
			return bNesisApi.Call<Response>("LiqPay", bNesisToken, "GetPaymentHistoryRaw", date_from, date_to, resp_format);
		}

		///<summary>
		/// Purchases in the store 
		/// </summary>
		/// <param name="version">Version API. Current value - 3.</param>
		/// <param name="public_key">Public key - the store identifier.</param>
		/// <param name="merchant_public_key">Public_key of agent shop.</param>
		/// <param name="action">Transaction type. Possible values: pay - payment, hold - amount of hold on sender's account, subscribe - regular payment, paydonate - donation, auth - card preauth.</param>
		/// <param name="order_id">order_id of successful paymen.</param>
		/// <param name="email">email for reciept sending.</param>
		/// <param name="phone">Payer's mobile phone. One time password will be sent to the number to confirm the payment. Mobile number should be in the international format (Ukraine +380, Russia +7). For example: +380950000001 (with +) or 380950000001 (without +).</param>
		/// <param name="amount">Payment amount.For example: 5, 7.34</param>
		/// <param name="currency">Payment currency. Available values: USD, EUR, RUB, UAH BYN KZT. Additional currencies can be added by company's request.</param>
		/// <param name="description">Payment description.</param>
		/// <returns>The result of the query is a transfer of funds from the payer's card to the store account.</returns>
		public string Pay(Int32 version, string public_key, string merchant_public_key, string action, string order_id, string email, string phone, Int32 amount, string currency, string description)
		{
			return bNesisApi.Call<string>("LiqPay", bNesisToken, "Pay", version, public_key, merchant_public_key, action, order_id, email, phone, amount, currency, description);
		}

		///<summary>
		/// Payment using mob app Privat24 / Sender
		/// Creating invoice for customer in mob app Privat24 / Sender.Customer can confirm payment in mob app Privat24 / SENDER
		/// Once payment is confirmed it will be finished. 
		/// </summary>
		/// <param name="version">Version API. Current value - 3.</param>
		/// <param name="public_key">Public key - the store identifier.</param>
		/// <param name="merchant_public_key">Public_key of agent shop.</param>
		/// <param name="action">Transaction type. Possible values: pay - payment, hold - amount of hold on sender's account, subscribe - regular payment, paydonate - donation, auth - card preauth.</param>
		/// <param name="order_id">order_id of successful paymen.</param>
		/// <param name="email">email for reciept sending.</param>
		/// <param name="phone">Payer's mobile phone. One time password will be sent to the number to confirm the payment. Mobile number should be in the international format (Ukraine +380, Russia +7). For example: +380950000001 (with +) or 380950000001 (without +).</param>
		/// <param name="amount">Payment amount.For example: 5, 7.34</param>
		/// <param name="currency">Payment currency. Available values: USD, EUR, RUB, UAH BYN KZT. Additional currencies can be added by company's request.</param>
		/// <param name="description">Payment description.</param>
		/// <returns></returns>
		public string PaySender(Int32 version, string public_key, string merchant_public_key, string action, string order_id, string email, string phone, Int32 amount, string currency, string description)
		{
			return bNesisApi.Call<string>("LiqPay", bNesisToken, "PaySender", version, public_key, merchant_public_key, action, order_id, email, phone, amount, currency, description);
		}

		///<summary>
		/// Payment using cash 
		/// </summary>
		/// <param name="version">Version API. Current value - 3.</param>
		/// <param name="public_key">Public key - the store identifier.</param>
		/// <param name="merchant_public_key">Public_key of agent shop.</param>
		/// <param name="action">Transaction type. Possible values: pay - payment, hold - amount of hold on sender's account, subscribe - regular payment, paydonate - donation, auth - card preauth.</param>
		/// <param name="order_id">order_id of successful paymen.</param>
		/// <param name="email">email for reciept sending.</param>
		/// <param name="phone">Payer's mobile phone. One time password will be sent to the number to confirm the payment. Mobile number should be in the international format (Ukraine +380, Russia +7). For example: +380950000001 (with +) or 380950000001 (without +).</param>
		/// <param name="amount">Payment amount.For example: 5, 7.34</param>
		/// <param name="currency">Payment currency. Available values: USD, EUR, RUB, UAH BYN KZT. Additional currencies can be added by company's request.</param>
		/// <param name="description">Payment description.</param>
		/// <returns>The result of a request is a payment in status - waiting for a customer to pay with cash.</returns>
		public string PayCash(Int32 version, string public_key, string merchant_public_key, string action, string order_id, string email, string phone, Int32 amount, string currency, string description)
		{
			return bNesisApi.Call<string>("LiqPay", bNesisToken, "PayCash", version, public_key, merchant_public_key, action, order_id, email, phone, amount, currency, description);
		}

		///<summary>
		/// Money transfer from card to card 
		/// </summary>
		/// <param name="version">Version API. Current value - 3</param>
		/// <param name="public_key">Public key - the store identifier. You can get the key in the store settings</param>
		/// <param name="merchant_public_key">Public_key of agent shop</param>
		/// <param name="action">Transaction type. Possible values: pay - payment, hold - amount of hold on sender's account, subscribe - regular payment, paydonate - donation, auth - card preauth</param>
		/// <param name="order_id">order_id of successful payment</param>
		/// <param name="email">email for reciept sending</param>
		/// <param name="phone">Payer's mobile phone. One time password will be sent to the number to confirm the payment. Mobile number should be in the international format (Ukraine +380, Russia +7). For example: +380950000001 (with +) or 380950000001 (without +)</param>
		/// <param name="amount">Payment amount.For example: 5, 7.34</param>
		/// <param name="currency">Payment currency. Available values: USD, EUR, RUB, UAH BYN KZT. Additional currencies can be added by company's request.</param>
		/// <param name="description">Payment description.</param>
		/// <returns>The result of the query is a money transfer from the Sender card to the Recipient card.</returns>
		public string P2P(Int64 version, string public_key, string merchant_public_key, string action, string order_id, string email, string phone, string amount, string currency, string description)
		{
			return bNesisApi.Call<string>("LiqPay", bNesisToken, "P2P", version, public_key, merchant_public_key, action, order_id, email, phone, amount, currency, description);
		}

		///<summary>
		/// Money Transfer from business account to card (B2C) 
		/// </summary>
		/// <param name="version">Version API. Current value - 3.</param>
		/// <param name="public_key">Public key - the store identifier. You can get the key in the store settings.</param>
		/// <param name="merchant_public_key">Public_key of agent shop</param>
		/// <param name="action">p2pcredit</param>
		/// <param name="order_id">order_id of successful payment</param>
		/// <param name="email">email for reciept sending</param>
		/// <param name="phone">Payer's mobile phone. One time password will be sent to the number to confirm the payment. Mobile number should be in the international format (Ukraine +380, Russia +7). For example: +380950000001 (with +) or 380950000001 (without +)</param>
		/// <param name="amount">Payment amount.For example: 5, 7.34</param>
		/// <param name="currency">Payment currency. Available values: USD, EUR, RUB, UAH BYN KZT. Additional currencies can be added by company's request.</param>
		/// <param name="description">Payment description.</param>
		/// <returns>The result of the request is the transfer of funds from the business account to the recipient card.</returns>
		public string P2P_credit(Int64 version, string public_key, string merchant_public_key, string action, string order_id, string email, string phone, string amount, string currency, string description)
		{
			return bNesisApi.Call<string>("LiqPay", bNesisToken, "P2P_credit", version, public_key, merchant_public_key, action, order_id, email, phone, amount, currency, description);
		}

		///<summary>
		/// Checking the status of payment 
		/// </summary>
		/// <param name="version">Version API. Current value</param>
		/// <param name="public_key">Public key - the store identifier.</param>
		/// <param name="merchant_public_key">Public_key of agent shop.</param>
		/// <param name="action">Public key - the store identifierTransaction type.</param>
		/// <param name="action1">Status</param>
		/// <param name="order_id">Order_id of successful payment</param>
		/// <param name="email">Email for reciept sending</param>
		/// <param name="card">Card number of the payer</param>
		/// <returns>Returns payment status.</returns>
		public string Status(Int32 version, string public_key, string merchant_public_key, string action, string action1, string order_id, string email, string card)
		{
			return bNesisApi.Call<string>("LiqPay", bNesisToken, "Status", version, public_key, merchant_public_key, action, action1, order_id, email, card);
		}

		///<summary>
		/// Reverse of funds to a Customer 
		/// </summary>
		/// <param name="version">Version API. Current value</param>
		/// <param name="public_key">Public key - the store identifier</param>
		/// <param name="merchant_public_key">Public_key of agent shop</param>
		/// <param name="action">Public key - the store identifierTransaction type</param>
		/// <param name="action1">Status</param>
		/// <param name="order_id">Order_id of successful payment</param>
		/// <param name="email">Email for reciept sending</param>
		/// <param name="phone">Payer's mobile phone. One time password will be sent to the number to confirm the payment</param>
		/// <param name="amount">Payment amount</param>
		/// <param name="card">Card number of the payer</param>
		/// <returns>The result of the query is a reverse of funds.</returns>
		public string Refund(Int32 version, string public_key, string merchant_public_key, string action, string action1, string order_id, string email, string phone, string amount, string card)
		{
			return bNesisApi.Call<string>("LiqPay", bNesisToken, "Refund", version, public_key, merchant_public_key, action, action1, order_id, email, phone, amount, card);
		}

		///<summary>
		/// Payment report 
		/// </summary>
		/// <param name="version">Version API. Current value</param>
		/// <param name="public_key">Public key - the store identifier.</param>
		/// <param name="merchant_public_key">Public_key of agent shop.</param>
		/// <param name="action">Public key - the store identifierTransaction type.</param>
		/// <param name="action1">Status</param>
		/// <param name="order_id">Order_id of successful payment</param>
		/// <param name="email">Email for reciept sending</param>
		/// <param name="card">Card number of the payer</param>
		/// <param name="ip">client IP</param>
		/// <returns>Returns result of payment report</returns>
		public string Reports(Int32 version, string public_key, string merchant_public_key, string action, string action1, string order_id, string email, string card, string ip)
		{
			return bNesisApi.Call<string>("LiqPay", bNesisToken, "Reports", version, public_key, merchant_public_key, action, action1, order_id, email, card, ip);
		}

		///<summary>
		/// Send invoice to customer's e-mail. 
		/// </summary>
		/// <param name="version">Version API. Current value</param>
		/// <param name="public_key">Public key - the store identifier. You can get the key in the store settings</param>
		/// <param name="merchant_public_key">The merchant public key.</param>
		/// <param name="acton">Transaction type. Possible values: pay - payment, hold - amount of hold on sender's account, subscribe - regular payment, paydonate - donation, auth - card preauth</param>
		/// <param name="order_id">order_id of successful payment</param>
		/// <param name="email">email for reciept sending</param>
		/// <param name="phone">Payer's mobile phone. One time password will be sent to the number to confirm the payment. Mobile number should be in the international format (Ukraine +380, Russia +7). For example: +380950000001 (with +) or 380950000001 (without +)</param>
		/// <returns>The result of the query is a sending invoice to the customer's e-mail.</returns>
		public string InvoiseSend(Int32 version, string public_key, string merchant_public_key, string acton, string order_id, string email, string phone)
		{
			return bNesisApi.Call<string>("LiqPay", bNesisToken, "InvoiseSend", version, public_key, merchant_public_key, acton, order_id, email, phone);
		}

		///<summary>
		/// Creating invoice using bot. 
		/// </summary>
		/// <param name="version">Version API. Current value</param>
		/// <param name="public_key">Public key - the store identifier. You can get the key in the store settings</param>
		/// <param name="merchant_public_key">Public_key of agent shop</param>
		/// <param name="acton">Transaction type. Possible values: pay - payment, hold - amount of hold on sender's account, subscribe - regular payment, paydonate - donation, auth - card preauth</param>
		/// <param name="order_id">order_id of successful payment</param>
		/// <param name="email">email for reciept sending</param>
		/// <param name="phone">Payer's mobile phone. One time password will be sent to the number to confirm the payment. Mobile number should be in the international format (Ukraine +380, Russia +7). For example: +380950000001 (with +) or 380950000001 (without +)</param>
		/// <returns>Find out how to set bots for Facebook and Telegram in Corezoid</returns>
		public string InvoiceForBots(Int32 version, string public_key, string merchant_public_key, string acton, string order_id, string email, string phone)
		{
			return bNesisApi.Call<string>("LiqPay", bNesisToken, "InvoiceForBots", version, public_key, merchant_public_key, acton, order_id, email, phone);
		}

		///<summary>
		/// Cancel the sent invoice. 
		/// </summary>
		/// <param name="version">Version API. Current value</param>
		/// <param name="public_key">Public key - the store identifier. You can get the key in the store settings</param>
		/// <param name="merchant_public_key">Public_key of agent shop</param>
		/// <param name="acton">Transaction type. Possible values: pay - payment, hold - amount of hold on sender's account, subscribe - regular payment, paydonate - donation, auth - card preauth</param>
		/// <param name="order_id">order_id of successful payment</param>
		/// <param name="email">email for reciept sending</param>
		/// <param name="phone">Payer's mobile phone. One time password will be sent to the number to confirm the payment. Mobile number should be in the international format (Ukraine +380, Russia +7). For example: +380950000001 (with +) or 380950000001 (without +)</param>
		/// <returns>Find out how to set bots for Facebook and Telegram in Corezoid</returns>
		public string InvoiceCancel(Int32 version, string public_key, string merchant_public_key, string acton, string order_id, string email, string phone)
		{
			return bNesisApi.Call<string>("LiqPay", bNesisToken, "InvoiceCancel", version, public_key, merchant_public_key, acton, order_id, email, phone);
		}
}
	public class LiqPayPaymentsArchiveData
	{
		public string action { get; set; }

		public Int64 payment_id { get; set; }

		public string status { get; set; }

		public Double version { get; set; }

		public string type { get; set; }

		public string public_key { get; set; }

		public Int64 acq_id { get; set; }

		public string order_id { get; set; }

		public string liqpay_order_id { get; set; }

		public string description { get; set; }

		public string sender_phone { get; set; }

		public string sender_first_name { get; set; }

		public string sender_last_name { get; set; }

		public string sender_card_mask2 { get; set; }

		public string sender_card_bank { get; set; }

		public string sender_card_type { get; set; }

		public Int32 sender_card_country { get; set; }

		public Double amount { get; set; }

		public string currency { get; set; }

		public Double sender_commission { get; set; }

		public Double receiver_commission { get; set; }

		public Double agent_commission { get; set; }

		public Double amount_debit { get; set; }

		public Double amount_credit { get; set; }

		public Double commission_debit { get; set; }

		public Double commission_credit { get; set; }

		public string currency_debit { get; set; }

		public string currency_credit { get; set; }

		public Double sender_bonus { get; set; }

		public Double amount_bonus { get; set; }

		public Int64 authcode_debit { get; set; }

		public Int64 authcode_credit { get; set; }

		public Int64 rrn_debit { get; set; }

		public Int64 rrn_credit { get; set; }

		public Int32 mpi_eci { get; set; }

		public Boolean is_3ds { get; set; }

		public Int64 create_date { get; set; }

		public Int64 end_date { get; set; }

		public Int64 transaction_id { get; set; }

	}

	public class LiqPayPaymentsArchive
	{
		public string result { get; set; }

		public LiqPayPaymentsArchiveData[] data { get; set; }

	}

}