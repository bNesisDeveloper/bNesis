/**
 * A generic class that defines the HTTP result of the API call in bNesse
 *     Each bNesis services RAW API must return this class (used as data structure) to Client 
 * @typedef {Object} Response
 */
 Response = function () { 
	/**
	 * HTTP response status code
	 * @type {HttpStatusCode}
	 */
	this.StatusCode = new HttpStatusCode();

	/**
	 * HTTP response status code text description
	 * @type {string}
	 */
	this.StatusDescription = "";

	/**
	 * String representation of response content
	 * @type {string}
	 */
	this.Content = "";

	/**
	 * Encoding of the response content
	 * @type {string}
	 */
	this.ContentEncoding = "";

	/**
	 * Length in bytes of the response content
	 * @type {Int64}
	 */
	this.ContentLength = 0;

	/**
	 * MIME content type of response
	 * @type {string}
	 */
	this.ContentType = "";

	/**
	 * Bytes
	 * @type {Byte[]}
	 */
	this.RawBytes = new Array();

	/**
	 * Headers at JSON temporary solution
	 * @type {string}
	 */
	this.Headers = "";

	/**
	 * message with error information
	 * @type {string}
	 */
	this.ErrorMessage = "";

	/**
	 * Status of the request. Will return Error for transport errors. HTTP errors will
	 * still return ResponseStatus.Completed, check StatusCode instead
	 * @type {string}
	 */
	this.ResponseStatus = "";

	/**
	 * The URL that actually responded to the content (different from request if redirected)
	 * @type {Uri}
	 */
	this.ResponseUri = new Uri();

	/**
	 * HttpWebResponse.Server
	 * @type {string}
	 */
	this.Server = "";

}

/**
 * Information about error 
 * @typedef {Object} ErrorInfo
 */
 ErrorInfo = function () { 
	/**
	 * Error code
	 * @type {Int32}
	 */
	this.Code = 0;

	/**
	 * When ErrorInfo was created
	 * @type {string}
	 */
	this.DateTime = "";

	/**
	 * Service name
	 * @type {string}
	 */
	this.Service = "";

	/**
	 * Describes important error information
	 * @type {string}
	 */
	this.Description = "";

	/**
	 * All information about error
	 * @type {string}
	 */
	this.BasicDescription = "";

}

/**
 * Only for testing class at class 
 * @typedef {Object} AddressTest
 */
 AddressTest = function () { 
	/**
	 * some Country simple property
	 * @type {string}
	 */
	this.Country = "";

	/**
	 * some City simple string property
	 * @type {string}
	 */
	this.City = "";

	/**
	 * City streets array for test - at Class AddressTest exists complex property Street[] - is array of strings
	 * @type {string[]}
	 */
	this.Street = new Array();

}

/**
 * bNesis unified contact item for services unified API call 
 * @typedef {Object} ContactItem
 */
 ContactItem = function () { 
	/**
	 * contact address at free format - just string
	 * @type {string}
	 */
	this.Address = "";

	/**
	 * contact email, is class is not check are the email typed at right email format
	 * @type {string}
	 */
	this.Email = "";

	/**
	 * contact data block (record) Id - is unical for all service contact
	 * @type {string}
	 */
	this.Id = "";

	/**
	 * this is test property for formalised Address - street, home, post code
	 * @type {AddressTest}
	 */
	this.AddressTestProp = new AddressTest();

	/**
	 * Contact name - it maybe single name or FNAMEspaceLNAME
	 * @type {string}
	 */
	this.Name = "";

	/**
	 * contact phone at free format, this class is not checkid it
	 * @type {string}
	 */
	this.Phone = "";

	/**
	 * additional information
	 * @type {string}
	 */
	this.About = "";

	/**
	 * for dynamic response
	 * @type {string}
	 */
	this.FieldsDynamic = "";

}

/**
 * unified bNesis product variants defenition class 
 * @typedef {Object} Variants
 */
 Variants = function () { 
	/**
	 * product variant options
	 * @type {string}
	 */
	this.Option = "";

	/**
	 * product price variant
	 * @type {string}
	 */
	this.Price = "";

	/**
	 * product sku variant
	 * @type {string}
	 */
	this.Sku = "";

}

/**
 * bNesis unified product item class for services unified API call 
 * @typedef {Object} ProductItem
 */
 ProductItem = function () { 
	this.Title = "";

	this.BodyHtml = "";

	this.Vendor = "";

	this.ProductType = "";

	this.Variants = new Array();

}

/**
 * bNesis unified Coutry item for services unified API call 
 * @typedef {Object} CountryItem
 */
 CountryItem = function () { 
	/**
	 * Country data block (record) unical Id
	 * @type {string}
	 */
	this.Id = "";

	/**
	 * The Name of the Country
	 * @type {string}
	 */
	this.Name = "";

	/**
	 * Coutry Code
	 * https://en.wikipedia.org/wiki/Country_code
	 * ISO
	 * @type {string}
	 */
	this.Code = "";

	/**
	 * https://en.wikipedia.org/wiki/List_of_countries_by_tax_rates
	 * @type {string}
	 */
	this.Tax = "";

}

/**
 * bNesis balance class for unified API 
 * @typedef {Object} Balance
 */
 Balance = function () { 
	/**
	 * currency type flag
	 * @type {string}
	 */
	this.Currency = "";

	/**
	 * Currency ammount value
	 * @type {Double}
	 */
	this.Amount = new Double();

}

/**
 * bNesis balance result unified class 
 * @typedef {Object} RetrieveBalanceUnified
 */
 RetrieveBalanceUnified = function () { 
	/**
	 * this record Id - define data block at service
	 * @type {string}
	 */
	this.Id = "";

	/**
	 * Amount value
	 * @type {Double}
	 */
	this.Amount = new Double();

	/**
	 * Currency type flag
	 * @type {string}
	 */
	this.Currency = "";

	/**
	 * data block (record) creation date time
	 * @type {string}
	 */
	this.Created = "";

}

 PaymentsArchiveData = function () { 
	this.PaymentId = 0;

	this.Amount = new Double();

	this.Currency = "";

	this.CreateDate = 0;

	this.TransactionId = 0;

}

 PaymentsArchive = function () { 
	this.data = new Array();

}

