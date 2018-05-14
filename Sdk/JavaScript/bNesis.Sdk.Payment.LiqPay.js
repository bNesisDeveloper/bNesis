LiqPay = function (bNesisApi) {
    this.bNesisToken = null;
    var _bNesisApi = bNesisApi;

    /**
     * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
	 * or Attach to bNesis session with exists bNesis token
     * @return {string} bNesisToken value | true if bNesisToken is valid
	 */
    this.Auth = function (bNesisDevId,clientId,clientSecret,redirectUrl,login) {
		if(arguments.length !== 1){
			var bNesisToken = _bNesisApi.Auth("LiqPay", "",bNesisDevId,redirectUrl,clientId,clientSecret,null,login,"",false,"");
			return bNesisToken;
		}
		else{
		    this.bNesisToken = arguments[0];			
			return ValidateToken();		
		}		
    }

    /**
     * The method stops the authorization session with the service and clears the value of bNesisToken.
     * @return {Boolean} true - if service logoff is successful
	 */
    this.LogoffService = function () {
		var result = _bNesisApi.LogoffService("LiqPay", this.bNesisToken);
		if (result) this.bNesisToken = "";
		return result;             
    }
	
	/**
	 *  Getting last exception for current provider 	
	 * @return {ErrorInfo} 
	 */
    this.GetLastError = function () {
        var result = _bNesisApi.Call("LiqPay", this.bNesisToken, "GetLastError");
        return result;
    }

	/**
	 *  Getting arrays of error info 	
	 * @return {ErrorInfo[]} 
	 */
    this.GetErrorLog = function () {
        var result = _bNesisApi.Call("LiqPay", this.bNesisToken, "GetErrorLog");
        return result;
    }

	/**
	 *  Checks the token in the service. 	
	 * @return {Boolean} if token valid return true, if token not valid return false
	 */
    this.ValidateToken = function () {
        var result = _bNesisApi.Call("LiqPay", this.bNesisToken, "ValidateToken");
        return result;
    }

	/**
	 *  Disables the access token used to authenticate the call. 	
	 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false
	 */
    this.Logoff = function () {
        var result = _bNesisApi.Call("LiqPay", this.bNesisToken, "Logoff");
        return result;
    }

	/**
	 *   	
	 * @return {Balance[]} 
	 */
    this.BalanceUnified = function () {
        var result = _bNesisApi.Call("LiqPay", this.bNesisToken, "BalanceUnified");
        return result;
    }

	/**
	 *   	
	 * @param id 
	 * @return {RetrieveBalanceUnified} 
	 */
    this.RetrieveBalancePosixUnified = function (id) {
        var result = _bNesisApi.Call("LiqPay", this.bNesisToken, "RetrieveBalancePosixUnified", id);
        return result;
    }

	/**
	 *   	
	 * @param id 
	 * @return {RetrieveBalanceUnified} 
	 */
    this.RetrieveBalanceUnified = function (id) {
        var result = _bNesisApi.Call("LiqPay", this.bNesisToken, "RetrieveBalanceUnified", id);
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
        var result = _bNesisApi.Call("LiqPay", this.bNesisToken, "GetPaymentHistoryUnified", date_from, date_to, resp_format);
        return result;
    }

	/**
	 *  Gets the link for payment. 	
	 * @param amount Payment amount. For example: 5, 7.34
	 * @param sandbox Enables the testing environment for developers. 
	 * Payer card will not be charged. To enable testing environment you will need to transmit value 1. 
	 * All test payments will have the status sandbox - successful test payment.
	 * @return {Response} 
	 */
    this.GetLinkForPaymentRaw = function (amount, sandbox) {
        var result = _bNesisApi.Call("LiqPay", this.bNesisToken, "GetLinkForPaymentRaw", amount, sandbox);
        return result;
    }

	/**
	 *  Gets the payment history. 	
	 * @param date_from Start date of a report in timestamp in milliseconds. Exemp: 1443161386000
	 * @param date_to End date of a report in timestamp in milliseconds. Exemp: 1443164386000
	 * @param resp_format Possible report format json, csv, xml. If parameter is not passed, will be passed by default json.
	 * @return {LiqPayPaymentsArchive} The archive of all received payments
	 */
    this.GetPaymentHistory = function (date_from, date_to, resp_format) {
        var result = _bNesisApi.Call("LiqPay", this.bNesisToken, "GetPaymentHistory", date_from, date_to, resp_format);
        return result;
    }

	/**
	 *  Gets the payment history. 	
	 * @param date_from Start date of a report in timestamp in milliseconds. Exemp: 1443161386000
	 * @param date_to End date of a report in timestamp in milliseconds. Exemp: 1443164386000
	 * @param resp_format Possible report format json, csv, xml. If parameter is not passed, will be passed by default json.
	 * @return {Response} The archive of all received payments
	 */
    this.GetPaymentHistoryRaw = function (date_from, date_to, resp_format) {
        var result = _bNesisApi.Call("LiqPay", this.bNesisToken, "GetPaymentHistoryRaw", date_from, date_to, resp_format);
        return result;
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
	 * @return {string} The result of the query is a transfer of funds from the payer's card to the store account.
	 */
    this.Pay = function (version, public_key, merchant_public_key, action, order_id, email, phone, amount, currency, description) {
        var result = _bNesisApi.Call("LiqPay", this.bNesisToken, "Pay", version, public_key, merchant_public_key, action, order_id, email, phone, amount, currency, description);
        return result;
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
	 * @return {string} 
	 */
    this.PaySender = function (version, public_key, merchant_public_key, action, order_id, email, phone, amount, currency, description) {
        var result = _bNesisApi.Call("LiqPay", this.bNesisToken, "PaySender", version, public_key, merchant_public_key, action, order_id, email, phone, amount, currency, description);
        return result;
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
	 * @return {string} The result of a request is a payment in status - waiting for a customer to pay with cash.
	 */
    this.PayCash = function (version, public_key, merchant_public_key, action, order_id, email, phone, amount, currency, description) {
        var result = _bNesisApi.Call("LiqPay", this.bNesisToken, "PayCash", version, public_key, merchant_public_key, action, order_id, email, phone, amount, currency, description);
        return result;
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
	 * @return {string} The result of the query is a money transfer from the Sender card to the Recipient card.
	 */
    this.P2P = function (version, public_key, merchant_public_key, action, order_id, email, phone, amount, currency, description) {
        var result = _bNesisApi.Call("LiqPay", this.bNesisToken, "P2P", version, public_key, merchant_public_key, action, order_id, email, phone, amount, currency, description);
        return result;
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
	 * @return {string} The result of the request is the transfer of funds from the business account to the recipient card.
	 */
    this.P2P_credit = function (version, public_key, merchant_public_key, action, order_id, email, phone, amount, currency, description) {
        var result = _bNesisApi.Call("LiqPay", this.bNesisToken, "P2P_credit", version, public_key, merchant_public_key, action, order_id, email, phone, amount, currency, description);
        return result;
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
	 * @return {string} Returns payment status.
	 */
    this.Status = function (version, public_key, merchant_public_key, action, action1, order_id, email, card) {
        var result = _bNesisApi.Call("LiqPay", this.bNesisToken, "Status", version, public_key, merchant_public_key, action, action1, order_id, email, card);
        return result;
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
	 * @return {string} The result of the query is a reverse of funds.
	 */
    this.Refund = function (version, public_key, merchant_public_key, action, action1, order_id, email, phone, amount, card) {
        var result = _bNesisApi.Call("LiqPay", this.bNesisToken, "Refund", version, public_key, merchant_public_key, action, action1, order_id, email, phone, amount, card);
        return result;
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
	 * @return {string} Returns result of payment report
	 */
    this.Reports = function (version, public_key, merchant_public_key, action, action1, order_id, email, card, ip) {
        var result = _bNesisApi.Call("LiqPay", this.bNesisToken, "Reports", version, public_key, merchant_public_key, action, action1, order_id, email, card, ip);
        return result;
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
	 * @return {string} The result of the query is a sending invoice to the customer's e-mail.
	 */
    this.InvoiseSend = function (version, public_key, merchant_public_key, acton, order_id, email, phone) {
        var result = _bNesisApi.Call("LiqPay", this.bNesisToken, "InvoiseSend", version, public_key, merchant_public_key, acton, order_id, email, phone);
        return result;
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
	 * @return {string} Find out how to set bots for Facebook and Telegram in Corezoid
	 */
    this.InvoiceForBots = function (version, public_key, merchant_public_key, acton, order_id, email, phone) {
        var result = _bNesisApi.Call("LiqPay", this.bNesisToken, "InvoiceForBots", version, public_key, merchant_public_key, acton, order_id, email, phone);
        return result;
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
	 * @return {string} Find out how to set bots for Facebook and Telegram in Corezoid
	 */
    this.InvoiceCancel = function (version, public_key, merchant_public_key, acton, order_id, email, phone) {
        var result = _bNesisApi.Call("LiqPay", this.bNesisToken, "InvoiceCancel", version, public_key, merchant_public_key, acton, order_id, email, phone);
        return result;
    }
}
 LiqPayPaymentsArchiveData = function () { 
	this.action = "";

	this.payment_id = 0;

	this.status = "";

	this.version = new Double();

	this.type = "";

	this.public_key = "";

	this.acq_id = 0;

	this.order_id = "";

	this.liqpay_order_id = "";

	this.description = "";

	this.sender_phone = "";

	this.sender_first_name = "";

	this.sender_last_name = "";

	this.sender_card_mask2 = "";

	this.sender_card_bank = "";

	this.sender_card_type = "";

	this.sender_card_country = 0;

	this.amount = new Double();

	this.currency = "";

	this.sender_commission = new Double();

	this.receiver_commission = new Double();

	this.agent_commission = new Double();

	this.amount_debit = new Double();

	this.amount_credit = new Double();

	this.commission_debit = new Double();

	this.commission_credit = new Double();

	this.currency_debit = "";

	this.currency_credit = "";

	this.sender_bonus = new Double();

	this.amount_bonus = new Double();

	this.authcode_debit = 0;

	this.authcode_credit = 0;

	this.rrn_debit = 0;

	this.rrn_credit = 0;

	this.mpi_eci = 0;

	this.is_3ds = false;

	this.create_date = 0;

	this.end_date = 0;

	this.transaction_id = 0;

}

 LiqPayPaymentsArchive = function () { 
	this.result = "";

	this.data = new Array();

}

