using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace bNesis.Sdk.Common
{
	///<summary>
	/// Information about error 
	/// </summary>
	public class ErrorInfo
	{
		/// <summary>
		/// Error code 
		/// </summary>
		public Int32 Code { get; set; }

		/// <summary>
		/// When ErrorInfo was created 
		/// </summary>
		public string DateTime { get; set; }

		/// <summary>
		/// Service name 
		/// </summary>
		public string Service { get; set; }

		/// <summary>
		/// Describes important error information 
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// All information about error 
		/// </summary>
		public string BasicDescription { get; set; }

	}

	///<summary>
	/// A generic class that defines the HTTP result of the API call in bNesse
	///     Each bNesis services RAW API must return this class (used as data structure) to Client 
	/// </summary>
	public class Response
	{
		/// <summary>
		/// HTTP response status code 
		/// </summary>
		public HttpStatusCode StatusCode { get; set; }

		/// <summary>
		/// HTTP response status code text description 
		/// </summary>
		public string StatusDescription { get; set; }

		/// <summary>
		/// String representation of response content 
		/// </summary>
		public string Content { get; set; }

		/// <summary>
		/// Encoding of the response content 
		/// </summary>
		public string ContentEncoding { get; set; }

		/// <summary>
		/// Length in bytes of the response content 
		/// </summary>
		public Int64 ContentLength { get; set; }

		/// <summary>
		/// MIME content type of response 
		/// </summary>
		public string ContentType { get; set; }

		/// <summary>
		/// Bytes 
		/// </summary>
		public Byte[] RawBytes { get; set; }

		/// <summary>
		/// Headers at JSON temporary solution 
		/// </summary>
		public string Headers { get; set; }

		/// <summary>
		/// message with error information 
		/// </summary>
		public string ErrorMessage { get; set; }

		/// <summary>
		/// Status of the request. Will return Error for transport errors. HTTP errors will
		/// still return ResponseStatus.Completed, check StatusCode instead 
		/// </summary>
		public string ResponseStatus { get; set; }

		/// <summary>
		/// The URL that actually responded to the content (different from request if redirected) 
		/// </summary>
		public Uri ResponseUri { get; set; }

		/// <summary>
		/// HttpWebResponse.Server 
		/// </summary>
		public string Server { get; set; }

	}

	///<summary>
	/// Only for testing class at class 
	/// </summary>
	public class AddressTest
	{
		/// <summary>
		/// some Country simple property 
		/// </summary>
		public string Country { get; set; }

		/// <summary>
		/// some City simple string property 
		/// </summary>
		public string City { get; set; }

		/// <summary>
		/// City streets array for test - at Class AddressTest exists complex property Street[] - is array of strings 
		/// </summary>
		public string[] Street { get; set; }

	}

	///<summary>
	/// bNesis unified contact item for services unified API call 
	/// </summary>
	public class ContactItem
	{
		/// <summary>
		/// contact address at free format - just string 
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// contact email, is class is not check are the email typed at right email format 
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// contact data block (record) Id - is unical for all service contact 
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// this is test property for formalised Address - street, home, post code 
		/// </summary>
		public AddressTest AddressTestProp { get; set; }

		/// <summary>
		/// Contact name - it maybe single name or FNAMEspaceLNAME 
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// contact phone at free format, this class is not checkid it 
		/// </summary>
		public string Phone { get; set; }

	}

	///<summary>
	/// unified bNesis product variants defenition class 
	/// </summary>
	public class Variants
	{
		/// <summary>
		/// product variant options 
		/// </summary>
		public string Option { get; set; }

		/// <summary>
		/// product price variant 
		/// </summary>
		public string Price { get; set; }

		/// <summary>
		/// product sku variant 
		/// </summary>
		public string Sku { get; set; }

	}

	///<summary>
	/// bNesis unified product item class for services unified API call 
	/// </summary>
	public class ProductItem
	{
		public string Title { get; set; }

		public string BodyHtml { get; set; }

		public string Vendor { get; set; }

		public string ProductType { get; set; }

		public Variants[] Variants { get; set; }

	}

	///<summary>
	/// bNesis unified Coutry item for services unified API call 
	/// </summary>
	public class CountryItem
	{
		/// <summary>
		/// Country data block (record) unical Id 
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// The Name of the Country 
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Coutry Code
		/// https://en.wikipedia.org/wiki/Country_code
		/// ISO 
		/// </summary>
		public string Code { get; set; }

		/// <summary>
		/// https://en.wikipedia.org/wiki/List_of_countries_by_tax_rates 
		/// </summary>
		public string Tax { get; set; }

	}

	///<summary>
	/// bNesis balance class for unified API 
	/// </summary>
	public class Balance
	{
		/// <summary>
		/// currency type flag 
		/// </summary>
		public string Currency { get; set; }

		/// <summary>
		/// Currency ammount value 
		/// </summary>
		public Double Amount { get; set; }

	}

	///<summary>
	/// bNesis balance result unified class 
	/// </summary>
	public class RetrieveBalanceUnified
	{
		/// <summary>
		/// this record Id - define data block at service 
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Amount value 
		/// </summary>
		public Double Amount { get; set; }

		/// <summary>
		/// Currency type flag 
		/// </summary>
		public string Currency { get; set; }

		/// <summary>
		/// data block (record) creation date time 
		/// </summary>
		public string Created { get; set; }

	}

	public class PaymentsArchiveData
	{
		public Int64 PaymentId { get; set; }

		public Double Amount { get; set; }

		public string Currency { get; set; }

		public Int64 CreateDate { get; set; }

		public Int64 TransactionId { get; set; }

	}

	public class PaymentsArchive
	{
		public PaymentsArchiveData[] data { get; set; }

	}

}