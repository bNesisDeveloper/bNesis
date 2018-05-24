package bNesis.Sdk.Payment.LiqPay;

import java.io.*;
import java.util.List;
import java.util.Date;
import java.util.Map.Entry;
import bNesis.Api.*;

import bNesis.Sdk.Common.*;
import java.net.URI.*;
import bNesis.Sdk.Payment.LiqPay.*;

	public class LiqPay  
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

		public LiqPay(bNesisApi bnesisApi)
		{
			this._bNesisApi = bnesisApi;
		}

		/**
		 * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		 * @return {String} bNesisToken value
		 */
		public String Auth(String bNesisDevId,String clientId,String clientSecret,String redirectUrl,String login) throws Exception
		{
			bNesisToken = _bNesisApi.Auth("LiqPay", "",bNesisDevId,redirectUrl,clientId,clientSecret,null,login,"",false,"");
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
			Boolean result = _bNesisApi.LogoffService("LiqPay", bNesisToken);
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
			return _bNesisApi.<ErrorInfo>Call(ErrorInfo.class, "LiqPay", bNesisToken, "GetLastError");
		}

		/**
		 *  Getting arrays of error info 	
		 * @return {ErrorInfo[]}  
		 * @throws Exception
		 */
		public ErrorInfo[] GetErrorLog() throws Exception
		{
			return _bNesisApi.<ErrorInfo[]>Call(ErrorInfo[].class, "LiqPay", bNesisToken, "GetErrorLog");
		}

		/**
		 *  Checks the token in the service. 	
		 * @return {Boolean} if token valid return true, if token not valid return false 
		 * @throws Exception
		 */
		public Boolean ValidateToken() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "LiqPay", bNesisToken, "ValidateToken");
		}

		/**
		 *  Disables the access token used to authenticate the call. 	
		 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false 
		 * @throws Exception
		 */
		public Boolean Logoff() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "LiqPay", bNesisToken, "Logoff");
		}

		/**
		 *   	
		 * @return {Balance[]}  
		 * @throws Exception
		 */
		public Balance[] BalanceUnified() throws Exception
		{
			return _bNesisApi.<Balance[]>Call(Balance[].class, "LiqPay", bNesisToken, "BalanceUnified");
		}

		/**
		 *   	
		 * @param id 
	 * @return {RetrieveBalanceUnified}  
		 * @throws Exception
		 */
		public RetrieveBalanceUnified RetrieveBalancePosixUnified(String id) throws Exception
		{
			return _bNesisApi.<RetrieveBalanceUnified>Call(RetrieveBalanceUnified.class, "LiqPay", bNesisToken, "RetrieveBalancePosixUnified", id);
		}

		/**
		 *   	
		 * @param id 
	 * @return {RetrieveBalanceUnified}  
		 * @throws Exception
		 */
		public RetrieveBalanceUnified RetrieveBalanceUnified(String id) throws Exception
		{
			return _bNesisApi.<RetrieveBalanceUnified>Call(RetrieveBalanceUnified.class, "LiqPay", bNesisToken, "RetrieveBalanceUnified", id);
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
			return _bNesisApi.<PaymentsArchive>Call(PaymentsArchive.class, "LiqPay", bNesisToken, "GetPaymentHistoryUnified", date_from, date_to, resp_format);
		}

		/**
		 *  Gets the link for payment. 	
		 * @param amount Payment amount. For example: 5, 7.34
	 * @param sandbox Enables the testing environment for developers. 
	 * Payer card will not be charged. To enable testing environment you will need to transmit value 1. 
	 * All test payments will have the status sandbox - successful test payment.
	 * @return {Response}  
		 * @throws Exception
		 */
		public Response GetLinkForPaymentRaw(Double amount, String sandbox) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "LiqPay", bNesisToken, "GetLinkForPaymentRaw", amount, sandbox);
		}

		/**
		 *  Gets the payment history. 	
		 * @param date_from Start date of a report in timestamp in milliseconds. Exemp: 1443161386000
	 * @param date_to End date of a report in timestamp in milliseconds. Exemp: 1443164386000
	 * @param resp_format Possible report format json, csv, xml. If parameter is not passed, will be passed by default json.
	 * @return {LiqPayPaymentsArchive} The archive of all received payments 
		 * @throws Exception
		 */
		public LiqPayPaymentsArchive GetPaymentHistory(String date_from, String date_to, String resp_format) throws Exception
		{
			return _bNesisApi.<LiqPayPaymentsArchive>Call(LiqPayPaymentsArchive.class, "LiqPay", bNesisToken, "GetPaymentHistory", date_from, date_to, resp_format);
		}

		/**
		 *  Gets the payment history. 	
		 * @param date_from Start date of a report in timestamp in milliseconds. Exemp: 1443161386000
	 * @param date_to End date of a report in timestamp in milliseconds. Exemp: 1443164386000
	 * @param resp_format Possible report format json, csv, xml. If parameter is not passed, will be passed by default json.
	 * @return {Response} The archive of all received payments 
		 * @throws Exception
		 */
		public Response GetPaymentHistoryRaw(String date_from, String date_to, String resp_format) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "LiqPay", bNesisToken, "GetPaymentHistoryRaw", date_from, date_to, resp_format);
		}

		/**
		 *  Purchases in the store 	
		 * @param version Version API. Current value - 3.
	 * @param public_key Public key - the store identifier.
	 * @param merchant_public_key Public_key of agent shop.
	 * @param action Transaction type. Possible values: pay - payment, hold - amount of hold on sender's account, subscribe - regular payment, paydonate - donation, auth - card preauth.
	 * @param order_id order_id of successful paymen.
	 * @param email email for reciept sending.
	 * @param phone Payer's mobile phone. One time password will be sent to the number to confirm the payment. Mobile number should be in the international format (Ukraine +380, Russia +7). For example: +380950000001 (with +) or 380950000001 (without +).
	 * @param amount Payment amount.For example: 5, 7.34
	 * @param currency Payment currency. Available values: USD, EUR, RUB, UAH BYN KZT. Additional currencies can be added by company's request.
	 * @param description Payment description.
	 * @return {String} The result of the query is a transfer of funds from the payer's card to the store account. 
		 * @throws Exception
		 */
		public String Pay(Integer version, String public_key, String merchant_public_key, String action, String order_id, String email, String phone, Integer amount, String currency, String description) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "LiqPay", bNesisToken, "Pay", version, public_key, merchant_public_key, action, order_id, email, phone, amount, currency, description);
		}

		/**
		 *  Payment using mob app Privat24 / Sender
	 * Creating invoice for customer in mob app Privat24 / Sender.Customer can confirm payment in mob app Privat24 / SENDER
	 * Once payment is confirmed it will be finished. 	
		 * @param version Version API. Current value - 3.
	 * @param public_key Public key - the store identifier.
	 * @param merchant_public_key Public_key of agent shop.
	 * @param action Transaction type. Possible values: pay - payment, hold - amount of hold on sender's account, subscribe - regular payment, paydonate - donation, auth - card preauth.
	 * @param order_id order_id of successful paymen.
	 * @param email email for reciept sending.
	 * @param phone Payer's mobile phone. One time password will be sent to the number to confirm the payment. Mobile number should be in the international format (Ukraine +380, Russia +7). For example: +380950000001 (with +) or 380950000001 (without +).
	 * @param amount Payment amount.For example: 5, 7.34
	 * @param currency Payment currency. Available values: USD, EUR, RUB, UAH BYN KZT. Additional currencies can be added by company's request.
	 * @param description Payment description.
	 * @return {String}  
		 * @throws Exception
		 */
		public String PaySender(Integer version, String public_key, String merchant_public_key, String action, String order_id, String email, String phone, Integer amount, String currency, String description) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "LiqPay", bNesisToken, "PaySender", version, public_key, merchant_public_key, action, order_id, email, phone, amount, currency, description);
		}

		/**
		 *  Payment using cash 	
		 * @param version Version API. Current value - 3.
	 * @param public_key Public key - the store identifier.
	 * @param merchant_public_key Public_key of agent shop.
	 * @param action Transaction type. Possible values: pay - payment, hold - amount of hold on sender's account, subscribe - regular payment, paydonate - donation, auth - card preauth.
	 * @param order_id order_id of successful paymen.
	 * @param email email for reciept sending.
	 * @param phone Payer's mobile phone. One time password will be sent to the number to confirm the payment. Mobile number should be in the international format (Ukraine +380, Russia +7). For example: +380950000001 (with +) or 380950000001 (without +).
	 * @param amount Payment amount.For example: 5, 7.34
	 * @param currency Payment currency. Available values: USD, EUR, RUB, UAH BYN KZT. Additional currencies can be added by company's request.
	 * @param description Payment description.
	 * @return {String} The result of a request is a payment in status - waiting for a customer to pay with cash. 
		 * @throws Exception
		 */
		public String PayCash(Integer version, String public_key, String merchant_public_key, String action, String order_id, String email, String phone, Integer amount, String currency, String description) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "LiqPay", bNesisToken, "PayCash", version, public_key, merchant_public_key, action, order_id, email, phone, amount, currency, description);
		}

		/**
		 *  Money transfer from card to card 	
		 * @param version Version API. Current value - 3
	 * @param public_key Public key - the store identifier. You can get the key in the store settings
	 * @param merchant_public_key Public_key of agent shop
	 * @param action Transaction type. Possible values: pay - payment, hold - amount of hold on sender's account, subscribe - regular payment, paydonate - donation, auth - card preauth
	 * @param order_id order_id of successful payment
	 * @param email email for reciept sending
	 * @param phone Payer's mobile phone. One time password will be sent to the number to confirm the payment. Mobile number should be in the international format (Ukraine +380, Russia +7). For example: +380950000001 (with +) or 380950000001 (without +)
	 * @param amount Payment amount.For example: 5, 7.34
	 * @param currency Payment currency. Available values: USD, EUR, RUB, UAH BYN KZT. Additional currencies can be added by company's request.
	 * @param description Payment description.
	 * @return {String} The result of the query is a money transfer from the Sender card to the Recipient card. 
		 * @throws Exception
		 */
		public String P2P(Long version, String public_key, String merchant_public_key, String action, String order_id, String email, String phone, String amount, String currency, String description) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "LiqPay", bNesisToken, "P2P", version, public_key, merchant_public_key, action, order_id, email, phone, amount, currency, description);
		}

		/**
		 *  Money Transfer from business account to card (B2C) 	
		 * @param version Version API. Current value - 3.
	 * @param public_key Public key - the store identifier. You can get the key in the store settings.
	 * @param merchant_public_key Public_key of agent shop
	 * @param action p2pcredit
	 * @param order_id order_id of successful payment
	 * @param email email for reciept sending
	 * @param phone Payer's mobile phone. One time password will be sent to the number to confirm the payment. Mobile number should be in the international format (Ukraine +380, Russia +7). For example: +380950000001 (with +) or 380950000001 (without +)
	 * @param amount Payment amount.For example: 5, 7.34
	 * @param currency Payment currency. Available values: USD, EUR, RUB, UAH BYN KZT. Additional currencies can be added by company's request.
	 * @param description Payment description.
	 * @return {String} The result of the request is the transfer of funds from the business account to the recipient card. 
		 * @throws Exception
		 */
		public String P2P_credit(Long version, String public_key, String merchant_public_key, String action, String order_id, String email, String phone, String amount, String currency, String description) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "LiqPay", bNesisToken, "P2P_credit", version, public_key, merchant_public_key, action, order_id, email, phone, amount, currency, description);
		}

		/**
		 *  Checking the status of payment 	
		 * @param version Version API. Current value
	 * @param public_key Public key - the store identifier.
	 * @param merchant_public_key Public_key of agent shop.
	 * @param action Public key - the store identifierTransaction type.
	 * @param action1 Status
	 * @param order_id Order_id of successful payment
	 * @param email Email for reciept sending
	 * @param card Card number of the payer
	 * @return {String} Returns payment status. 
		 * @throws Exception
		 */
		public String Status(Integer version, String public_key, String merchant_public_key, String action, String action1, String order_id, String email, String card) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "LiqPay", bNesisToken, "Status", version, public_key, merchant_public_key, action, action1, order_id, email, card);
		}

		/**
		 *  Reverse of funds to a Customer 	
		 * @param version Version API. Current value
	 * @param public_key Public key - the store identifier
	 * @param merchant_public_key Public_key of agent shop
	 * @param action Public key - the store identifierTransaction type
	 * @param action1 Status
	 * @param order_id Order_id of successful payment
	 * @param email Email for reciept sending
	 * @param phone Payer's mobile phone. One time password will be sent to the number to confirm the payment
	 * @param amount Payment amount
	 * @param card Card number of the payer
	 * @return {String} The result of the query is a reverse of funds. 
		 * @throws Exception
		 */
		public String Refund(Integer version, String public_key, String merchant_public_key, String action, String action1, String order_id, String email, String phone, String amount, String card) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "LiqPay", bNesisToken, "Refund", version, public_key, merchant_public_key, action, action1, order_id, email, phone, amount, card);
		}

		/**
		 *  Payment report 	
		 * @param version Version API. Current value
	 * @param public_key Public key - the store identifier.
	 * @param merchant_public_key Public_key of agent shop.
	 * @param action Public key - the store identifierTransaction type.
	 * @param action1 Status
	 * @param order_id Order_id of successful payment
	 * @param email Email for reciept sending
	 * @param card Card number of the payer
	 * @param ip client IP
	 * @return {String} Returns result of payment report 
		 * @throws Exception
		 */
		public String Reports(Integer version, String public_key, String merchant_public_key, String action, String action1, String order_id, String email, String card, String ip) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "LiqPay", bNesisToken, "Reports", version, public_key, merchant_public_key, action, action1, order_id, email, card, ip);
		}

		/**
		 *  Send invoice to customer's e-mail. 	
		 * @param version Version API. Current value
	 * @param public_key Public key - the store identifier. You can get the key in the store settings
	 * @param merchant_public_key The merchant public key.
	 * @param acton Transaction type. Possible values: pay - payment, hold - amount of hold on sender's account, subscribe - regular payment, paydonate - donation, auth - card preauth
	 * @param order_id order_id of successful payment
	 * @param email email for reciept sending
	 * @param phone Payer's mobile phone. One time password will be sent to the number to confirm the payment. Mobile number should be in the international format (Ukraine +380, Russia +7). For example: +380950000001 (with +) or 380950000001 (without +)
	 * @return {String} The result of the query is a sending invoice to the customer's e-mail. 
		 * @throws Exception
		 */
		public String InvoiseSend(Integer version, String public_key, String merchant_public_key, String acton, String order_id, String email, String phone) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "LiqPay", bNesisToken, "InvoiseSend", version, public_key, merchant_public_key, acton, order_id, email, phone);
		}

		/**
		 *  Creating invoice using bot. 	
		 * @param version Version API. Current value
	 * @param public_key Public key - the store identifier. You can get the key in the store settings
	 * @param merchant_public_key Public_key of agent shop
	 * @param acton Transaction type. Possible values: pay - payment, hold - amount of hold on sender's account, subscribe - regular payment, paydonate - donation, auth - card preauth
	 * @param order_id order_id of successful payment
	 * @param email email for reciept sending
	 * @param phone Payer's mobile phone. One time password will be sent to the number to confirm the payment. Mobile number should be in the international format (Ukraine +380, Russia +7). For example: +380950000001 (with +) or 380950000001 (without +)
	 * @return {String} Find out how to set bots for Facebook and Telegram in Corezoid 
		 * @throws Exception
		 */
		public String InvoiceForBots(Integer version, String public_key, String merchant_public_key, String acton, String order_id, String email, String phone) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "LiqPay", bNesisToken, "InvoiceForBots", version, public_key, merchant_public_key, acton, order_id, email, phone);
		}

		/**
		 *  Cancel the sent invoice. 	
		 * @param version Version API. Current value
	 * @param public_key Public key - the store identifier. You can get the key in the store settings
	 * @param merchant_public_key Public_key of agent shop
	 * @param acton Transaction type. Possible values: pay - payment, hold - amount of hold on sender's account, subscribe - regular payment, paydonate - donation, auth - card preauth
	 * @param order_id order_id of successful payment
	 * @param email email for reciept sending
	 * @param phone Payer's mobile phone. One time password will be sent to the number to confirm the payment. Mobile number should be in the international format (Ukraine +380, Russia +7). For example: +380950000001 (with +) or 380950000001 (without +)
	 * @return {String} Find out how to set bots for Facebook and Telegram in Corezoid 
		 * @throws Exception
		 */
		public String InvoiceCancel(Integer version, String public_key, String merchant_public_key, String acton, String order_id, String email, String phone) throws Exception
		{
			return _bNesisApi.<String>Call(String.class, "LiqPay", bNesisToken, "InvoiceCancel", version, public_key, merchant_public_key, acton, order_id, email, phone);
		}
}