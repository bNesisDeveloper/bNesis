Shopify = function (bNesisApi) {
    this.bNesisToken = null;
    var _bNesisApi = bNesisApi;

    /**
     * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
	 * or Attach to bNesis session with exists bNesis token
     * @return {string} bNesisToken value | true if bNesisToken is valid
	 */
    this.Auth = function (bNesisDevId,clientId,clientSecret,redirectUrl,scopes) {
		if(arguments.length !== 1){
			var bNesisToken = _bNesisApi.Auth("Shopify", "",bNesisDevId,redirectUrl,clientId,clientSecret,scopes,"","",false,"");
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
		var result = _bNesisApi.LogoffService("Shopify", this.bNesisToken);
		if (result) this.bNesisToken = "";
		return result;             
    }
	
	/**
	 *  Getting last exception for current provider 	
	 * @return {ErrorInfo} 
	 */
    this.GetLastError = function () {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "GetLastError");
        return result;
    }

	/**
	 *  Getting arrays of error info 	
	 * @return {ErrorInfo[]} 
	 */
    this.GetErrorLog = function () {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "GetErrorLog");
        return result;
    }

	/**
	 *  Checks the token in the service. 	
	 * @return {Boolean} if token valid return true, if token not valid return false
	 */
    this.ValidateToken = function () {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "ValidateToken");
        return result;
    }

	/**
	 *  Disables the access token used to authenticate the call. 	
	 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false
	 */
    this.Logoff = function () {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "Logoff");
        return result;
    }

	/**
	 *   	
	 * @param contactItem 
	 * @return {Boolean} 
	 */
    this.CreateCustomerUnified = function (contactItem) {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "CreateCustomerUnified", contactItem);
        return result;
    }

	/**
	 *   	
	 * @return {ContactItem[]} 
	 */
    this.GetCustomersUnified = function () {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "GetCustomersUnified");
        return result;
    }

	/**
	 *   	
	 * @param productItem 
	 * @return {Boolean} 
	 */
    this.AddProductUnified = function (productItem) {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "AddProductUnified", productItem);
        return result;
    }

	/**
	 *   	
	 * @return {ProductItem[]} 
	 */
    this.GetProductsUnified = function () {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "GetProductsUnified");
        return result;
    }

	/**
	 *   	
	 * @param IdProduct 
	 * @return {Boolean} 
	 */
    this.DeleteProductUnified = function (IdProduct) {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "DeleteProductUnified", IdProduct);
        return result;
    }

	/**
	 *   	
	 * @return {CountryItem[]} 
	 */
    this.GetCountriesUnified = function () {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "GetCountriesUnified");
        return result;
    }

	/**
	 *   	
	 * @return {Int32} 
	 */
    this.GetCountCountriesUnified = function () {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "GetCountCountriesUnified");
        return result;
    }

	/**
	 *   	
	 * @param IdCountry 
	 * @return {CountryItem} 
	 */
    this.ReceiveCountryUnified = function (IdCountry) {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "ReceiveCountryUnified", IdCountry);
        return result;
    }

	/**
	 *   	
	 * @param IdCountry 
	 * @return {Boolean} 
	 */
    this.DeleteCountryUnified = function (IdCountry) {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "DeleteCountryUnified", IdCountry);
        return result;
    }

	/**
	 *   	
	 * @param countryItem 
	 * @return {CountryItem} 
	 */
    this.CreateCountryUnified = function (countryItem) {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "CreateCountryUnified", countryItem);
        return result;
    }

	/**
	 *   	
	 * @param countryItem 
	 * @return {CountryItem} 
	 */
    this.UpdateCountryUnified = function (countryItem) {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "UpdateCountryUnified", countryItem);
        return result;
    }

	/**
	 *   	
	 * @param IdCustomer 
	 * @return {ContactItem} 
	 */
    this.ReceiveCustomerUnified = function (IdCustomer) {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "ReceiveCustomerUnified", IdCustomer);
        return result;
    }

	/**
	 *  Create a new customer by ShopifyCustomerIn structure 	
	 * @param shopifyCustomerIn bNesis ShopifyCustomerIn
	 * @return {ShopifyCustomerOut} created customer
	 */
    this.CreateCustomer = function (shopifyCustomerIn) {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "CreateCustomer", shopifyCustomerIn);
        return result;
    }

	/**
	 *  Create a new customer by JSON parameter 	
	 * @param shopifyCustomerInObject Shopify customer JSON
	 * @return {Response} added contact in JSON
	 */
    this.CreateCustomerRaw = function (shopifyCustomerInObject) {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "CreateCustomerRaw", shopifyCustomerInObject);
        return result;
    }

	/**
	 *  Receive a list of all customers as ShopifyCustomersOut 	
	 * @return {ShopifyCustomersOut} list of all customers at JSON
	 */
    this.GetCustomers = function () {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "GetCustomers");
        return result;
    }

	/**
	 *  Get all customers as JSON 	
	 * @return {Response} list of all contacts in JSON
	 */
    this.GetCustomersRaw = function () {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "GetCustomersRaw");
        return result;
    }

	/**
	 *  Adds product 	
	 * @param shopifyProductIn 
	 * @return {ShopifyProductOut} added product
	 */
    this.AddProduct = function (shopifyProductIn) {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "AddProduct", shopifyProductIn);
        return result;
    }

	/**
	 *  Adds product 	
	 * @param ProductItem Product item
	 * @return {Response} added product
	 */
    this.AddProductRaw = function (ProductItem) {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "AddProductRaw", ProductItem);
        return result;
    }

	/**
	 *   	
	 * @return {ShopifyProductsOut} 
	 */
    this.GetProducts = function () {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "GetProducts");
        return result;
    }

	/**
	 *  Gets products 	
	 * @return {Response} list of all products
	 */
    this.GetProductsRaw = function () {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "GetProductsRaw");
        return result;
    }

	/**
	 *   	
	 * @param IdProduct 
	 * @return {Boolean} 
	 */
    this.DeleteProduct = function (IdProduct) {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "DeleteProduct", IdProduct);
        return result;
    }

	/**
	 *  Removes a product from the shop 	
	 * @param IdProduct The product identifier.
	 * @return {Response} status
	 */
    this.DeleteProductRaw = function (IdProduct) {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "DeleteProductRaw", IdProduct);
        return result;
    }

	/**
	 *   	
	 * @return {ShopifyCountriesOut} 
	 */
    this.GetCountries = function () {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "GetCountries");
        return result;
    }

	/**
	 *  Get a list of all countries 	
	 * @return {Response} list of all countries
	 */
    this.GetCountriesRaw = function () {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "GetCountriesRaw");
        return result;
    }

	/**
	 *  Gets a count of all countries. 	
	 * @return {Int32} count of all countries.
	 */
    this.GetCountCountries = function () {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "GetCountCountries");
        return result;
    }

	/**
	 *  Get a count of all countries. 	
	 * @return {Response} count of all countries.
	 */
    this.GetCountCountriesRaw = function () {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "GetCountCountriesRaw");
        return result;
    }

	/**
	 *   	
	 * @param IdCountry 
	 * @return {ShopifyCountryOut} 
	 */
    this.ReceiveCountry = function (IdCountry) {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "ReceiveCountry", IdCountry);
        return result;
    }

	/**
	 *  Receive a single Country 	
	 * @param IdCountry The identifier.
	 * @return {Response} a single Country
	 */
    this.ReceiveCountryRaw = function (IdCountry) {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "ReceiveCountryRaw", IdCountry);
        return result;
    }

	/**
	 *  Deletes a single Country 	
	 * @param IdCountry 
	 * @return {Boolean} result
	 */
    this.DeleteCountry = function (IdCountry) {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "DeleteCountry", IdCountry);
        return result;
    }

	/**
	 *  Deletes a single Country 	
	 * @param IdCountry 
	 * @return {Response} status
	 */
    this.DeleteCountryRaw = function (IdCountry) {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "DeleteCountryRaw", IdCountry);
        return result;
    }

	/**
	 *  Create a country 	
	 * @param shopifyCountryIn The country.
	 * @return {ShopifyCountryOut} result
	 */
    this.CreateCountry = function (shopifyCountryIn) {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "CreateCountry", shopifyCountryIn);
        return result;
    }

	/**
	 *  Create a country 	
	 * @param shopifyCountryInObject The country.
	 * @return {Response} result
	 */
    this.CreateCountryRaw = function (shopifyCountryInObject) {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "CreateCountryRaw", shopifyCountryInObject);
        return result;
    }

	/**
	 *   	
	 * @param shopifyCountryIn 
	 * @return {ShopifyCountryOut} 
	 */
    this.UpdateCountry = function (shopifyCountryIn) {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "UpdateCountry", shopifyCountryIn);
        return result;
    }

	/**
	 *  Update a country 	
	 * @param shopifyCountryInObject The country.
	 * @return {Response} result
	 */
    this.UpdateCountryRaw = function (shopifyCountryInObject) {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "UpdateCountryRaw", shopifyCountryInObject);
        return result;
    }

	/**
	 *  Receive a list of all customers as ShopifyCustomersOut 	
	 * @param IdCustomer 
	 * @return {ShopifyCustomerOut} list of all customers at JSON
	 */
    this.ReceiveCustomer = function (IdCustomer) {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "ReceiveCustomer", IdCustomer);
        return result;
    }

	/**
	 *  Receives a single Customer 	
	 * @param IdCustomer The identifier.
	 * @return {Response} a single Customer
	 */
    this.ReceiveCustomerRaw = function (IdCustomer) {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "ReceiveCustomerRaw", IdCustomer);
        return result;
    }

	/**
	 *  Send an account invite for the customer 	
	 * @param IdCustomer result
	 * @return {Response} 
	 */
    this.SendDefaultInviteRaw = function (IdCustomer) {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "SendDefaultInviteRaw", IdCustomer);
        return result;
    }

	/**
	 *  Sends a customized invite 	
	 * @param Invite invite.
	 * @return {Response} Invite
	 */
    this.SendCustomizedInviteRaw = function (Invite) {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "SendCustomizedInviteRaw", Invite);
        return result;
    }

	/**
	 *   	
	 * @param IdCustomer 
	 * @return {Response} 
	 */
    this.CreateAccountActivationUrlRaw = function (IdCustomer) {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "CreateAccountActivationUrlRaw", IdCustomer);
        return result;
    }

	/**
	 *  Receive a single Shop 	
	 * @return {Response} Details of current shop
	 */
    this.Shop = function () {
        var result = _bNesisApi.Call("Shopify", this.bNesisToken, "Shop");
        return result;
    }
}
 ShopifyAddressOut = function () { 
	this.id = "";

	this.address1 = "";

	this.address2 = "";

	this.city = "";

	this.name = "";

	this.company = "";

	this.country = "";

	this.country_code = "";

	this.latitude = new Double();

	this.longitude = new Double();

	this.first_name = "";

	this.last_name = "";

	this.phone = "";

	this.province = "";

	this.province_code = "";

	this.zip = "";

}

 ShopifyCustomerItemOut = function () { 
	this.id = 0;

	this.email = "";

	this.accepts_marketing = false;

	this.created_at = new DateTime();

	this.updated_at = new DateTime();

	this.first_name = "";

	this.last_name = "";

	this.orders_count = 0;

	this.state = "";

	this.total_spent = "";

	this.last_order_id = 0;

	this.note = "";

	this.verified_email = false;

	this.multipass_identifier = "";

	this.tax_exempt = false;

	this.phone = "";

	this.tags = "";

	this.last_order_name = "";

	this.addresses = new Array();

	this.default_address = new ShopifyAddressOut();

}

 ShopifyCustomerOut = function () { 
	this.customer = new ShopifyCustomerItemOut();

}

 ShopifyAddressIn = function () { 
	this.address1 = "";

	this.address2 = "";

	this.city = "";

	this.name = "";

	this.company = "";

	this.country = "";

	this.country_code = "";

	this.latitude = new Double();

	this.longitude = new Double();

	this.first_name = "";

	this.last_name = "";

	this.phone = "";

	this.province = "";

	this.province_code = "";

	this.zip = "";

}

 ShopifyMetafields = function () { 
	this.key = "";

	this.namespace_ = "";

	this.value = "";

	this.value_type = "";

}

/**
 * Shopify customer item 
 * @typedef {Object} ShopifyCustomerItemIn
 */
 ShopifyCustomerItemIn = function () { 
	/**
	 * customet id
	 * @type {Int32}
	 */
	this.id = 0;

	/**
	 * customer email
	 * @type {string}
	 */
	this.email = "";

	this.accepts_marketing = false;

	this.created_at = new DateTime();

	this.updated_at = new DateTime();

	this.first_name = "";

	this.last_name = "";

	this.orders_count = 0;

	this.state = "";

	this.total_spent = "";

	this.last_order_id = 0;

	this.note = "";

	this.verified_email = false;

	this.multipass_identifier = "";

	this.tax_exempt = false;

	this.phone = "";

	this.tags = "";

	this.last_order_name = "";

	this.addresses = new Array();

	this.password = "";

	this.password_confirmation = "";

	this.send_email_invite = false;

	this.send_email_welcome = false;

	this.metafields = new Array();

}

 ShopifyCustomerIn = function () { 
	this.customer = new ShopifyCustomerItemIn();

}

 ShopifyCustomersOut = function () { 
	this.customers = new Array();

}

 ShopifyImage = function () { 
	this.attachment = "";

	this.src = "";

}

 ShopifyOptions = function () { 
	this.name = "";

}

 ShopifyVariants = function () { 
	this.barcode = "";

	this.compare_at_price = "";

	this.created_at = new DateTime();

	this.fulfillment_service = "";

	this.grams = 0;

	this.id = 0;

	this.image_id = 0;

	this.inventory_management = "";

	this.inventory_policy = "";

	this.inventory_quantity = 0;

	this.inventory_quantity_adjustment = "";

	this.metafields = new Array();

	this.old_inventory_quantity = 0;

	this.option1 = "";

	this.option2 = "";

	this.option3 = "";

	this.position = 0;

	this.price = "";

	this.product_id = 0;

	this.requires_shipping = false;

	this.sku = "";

	this.taxable = false;

	this.title = "";

	this.updated_at = new DateTime();

	this.weight = 0;

	this.weight_unit = "";

}

/**
 * Shopify customer item 
 * @typedef {Object} ShopifyProductItemOut
 */
 ShopifyProductItemOut = function () { 
	this.updated_at = new DateTime();

	this.vendor = "";

	this.product_type = "";

	this.published_at = new DateTime();

	this.published_scope = "";

	this.published = false;

	this.tags = "";

	this.template_suffix = "";

	this.title = "";

	this.metafields_global_description_tag = "";

	this.metafields_global_title_tag = "";

	this.body_html = "";

	this.created_at = new DateTime();

	this.handle = "";

	this.id = "";

	this.image = new ShopifyImage();

	this.images = new Array();

	this.metafields = new Array();

	this.options = new Array();

	this.variants = new Array();

}

 ShopifyProductOut = function () { 
	this.product = new ShopifyProductItemOut();

}

/**
 * Shopify customer item 
 * @typedef {Object} ShopifyProductItemIn
 */
 ShopifyProductItemIn = function () { 
	this.updated_at = new DateTime();

	this.vendor = "";

	this.product_type = "";

	this.published_at = new DateTime();

	this.published_scope = "";

	this.published = false;

	this.tags = "";

	this.template_suffix = "";

	this.title = "";

	this.metafields_global_description_tag = "";

	this.metafields_global_title_tag = "";

	this.body_html = "";

	this.created_at = new DateTime();

	this.handle = "";

	this.id = "";

	this.image = new ShopifyImage();

	this.images = new Array();

	this.metafields = new Array();

	this.options = new Array();

	this.variants = new Array();

}

 ShopifyProductIn = function () { 
	this.product = new ShopifyProductItemIn();

}

 ShopifyProductsOut = function () { 
	this.products = new Array();

}

 ShopifyProvinces = function () { 
	this.code = "";

	this.country_id = 0;

	this.id = 0;

	this.name = "";

	this.shipping_zone_id = 0;

	this.tax = new Double();

	this.tax_name = "";

	this.tax_percentage = new Double();

}

/**
 * Shopify customer item 
 * @typedef {Object} ShopifyCountryItemOut
 */
 ShopifyCountryItemOut = function () { 
	this.code = "";

	this.id = 0;

	this.name = "";

	this.provinces = new Array();

	this.tax = new Double();

	this.tax_name = "";

}

 ShopifyCountriesOut = function () { 
	this.countries = new Array();

}

 ShopifyCountryOut = function () { 
	this.country = new ShopifyCountryItemOut();

}

 ShopifyCountryItemIn = function () { 
	this.code = "";

	this.id = 0;

	this.name = "";

	this.provinces = new Array();

	this.tax = new Double();

	this.tax_name = "";

}

 ShopifyCountryIn = function () { 
	this.country = new ShopifyCountryItemIn();

}

