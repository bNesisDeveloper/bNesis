using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;
using bNesis.Api.Desktop;
using bNesis.Sdk.Common;

namespace bNesis.Sdk.GovRegistry.Prozzoro
{
	public class Prozzoro  
	{
		public string bNesisToken {get; private set;}
		private DesktopbNesisApi bNesisApi;

		public Prozzoro(DesktopbNesisApi bNesisApi)
		{
			this.bNesisApi = bNesisApi;
		}

		public string Auth(string data,string bNesisDevId,string redirectUrl,string clientId,string clientSecret,string[] scopes,string login,string password,bool isSandbox,string serviceUrl)
		{

			bNesisToken = bNesisApi.Auth("Prozzoro", data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl);

			return bNesisToken;
		}

		///<summary>
		/// Getting last exception for current provider 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo GetLastError()
		{
			return bNesisApi.Call<ErrorInfo>("Prozzoro", bNesisToken, "GetLastError");
		}

		///<summary>
		/// Getting arrays of error info 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo[] GetErrorLog()
		{
			return bNesisApi.Call<ErrorInfo[]>("Prozzoro", bNesisToken, "GetErrorLog");
		}

		///<summary>
		/// Checks the token in the service. 
		/// </summary>
		/// <returns>if token valid return true, if token not valid return false</returns>
		public Boolean ValidateToken()
		{
			return bNesisApi.Call<Boolean>("Prozzoro", bNesisToken, "ValidateToken");
		}

		///<summary>
		/// Disables the access token used to authenticate the call. 
		/// </summary>
		/// <returns>if token revoked method returns true 
		/// if token doesn't support token revocation or token is revoked method returns false</returns>
		public Boolean Logoff()
		{
			return bNesisApi.Call<Boolean>("Prozzoro", bNesisToken, "Logoff");
		}

		///<summary>
		/// Getting list of all tenders (Limit in data:100). 
		/// </summary>
		/// <returns>Return Info.</returns>
		public PageInfo GetTenders()
		{
			return bNesisApi.Call<PageInfo>("Prozzoro", bNesisToken, "GetTenders");
		}

		///<summary>
		/// Getting list of all tenders in next page (Limit in data:100). 
		/// </summary>
		/// <param name="offset">Offset to next page.</param>
		/// <returns>Return Info.</returns>
		public PageInfo GetTendersNext(string offset)
		{
			return bNesisApi.Call<PageInfo>("Prozzoro", bNesisToken, "GetTendersNext", offset);
		}

		///<summary>
		/// Getting particular tender by identifier. 
		/// </summary>
		/// <param name="id">Identifier tender.</param>
		/// <returns>Return .</returns>
		public TenderOut GetTenderByIdentifier(string id)
		{
			return bNesisApi.Call<TenderOut>("Prozzoro", bNesisToken, "GetTenderByIdentifier", id);
		}

		///<summary>
		/// Getting list of all tenders. 
		/// </summary>
		/// <returns>Return response</returns>
		public Response GetTendersRaw()
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTendersRaw");
		}

		///<summary>
		/// Getting list of all tender in next page. 
		/// </summary>
		/// <param name="offset">Offset time.</param>
		/// <returns>Return response.</returns>
		public Response GetTendersInNextPageRaw(string offset)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTendersInNextPageRaw", offset);
		}

		///<summary>
		/// Getting particular tender by id. 
		/// </summary>
		/// <param name="id">Identifier tender.</param>
		/// <returns>Return response.</returns>
		public Response GetTenderByIdentifierRaw(string id)
		{
			return bNesisApi.Call<Response>("Prozzoro", bNesisToken, "GetTenderByIdentifierRaw", id);
		}
	}
	///<summary>
	/// Implementation for  'next_page'. 
	/// </summary>
	public class NextPage
	{
		/// <summary>
		/// The path. 
		/// </summary>
		public string path { get; set; }

		/// <summary>
		/// The uri. 
		/// </summary>
		public string uri { get; set; }

		/// <summary>
		/// The offset. 
		/// </summary>
		public string offset { get; set; }

	}

	///<summary>
	/// Implementation for 'data'. 
	/// </summary>
	public class Data
	{
		/// <summary>
		/// The identifier. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// When modified. 
		/// </summary>
		public string dateModified { get; set; }

	}

	///<summary>
	/// Implementation for page information. 
	/// </summary>
	public class PageInfo
	{
		/// <summary>
		/// Information about next page. 
		/// </summary>
		public NextPage next_page { get; set; }

		/// <summary>
		/// Data information. 
		/// </summary>
		public Data[] data { get; set; }

	}

	///<summary>
	/// Implementation for tender 'tenderPeriod'. 
	/// </summary>
	public class TenderPeriod
	{
		/// <summary>
		/// When started. 
		/// </summary>
		public string startDate { get; set; }

		/// <summary>
		/// When ended. 
		/// </summary>
		public string endDate { get; set; }

	}

	///<summary>
	/// Implementation for tender 'minimalStep'. 
	/// </summary>
	public class MinimalStep
	{
		/// <summary>
		/// The currency. 
		/// </summary>
		public string currency { get; set; }

		/// <summary>
		/// The amount. 
		/// </summary>
		public string amount { get; set; }

		/// <summary>
		/// The value added tax included. 
		/// </summary>
		public Boolean valueAddedTaxIncluded { get; set; }

	}

	///<summary>
	/// Implementation for tender 'classification'. 
	/// </summary>
	public class Classification
	{
		/// <summary>
		/// The scheme. 
		/// </summary>
		public string scheme { get; set; }

		/// <summary>
		/// The description for classification. 
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// Classification identifier. 
		/// </summary>
		public string id { get; set; }

	}

	///<summary>
	/// Implementation for tender 'additionalClassification' 
	/// </summary>
	public class AdditionalClassification
	{
		/// <summary>
		/// The scheme. 
		/// </summary>
		public string scheme { get; set; }

		/// <summary>
		/// Additional classification identifier. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The description for additional classification. 
		/// </summary>
		public string description { get; set; }

	}

	///<summary>
	/// Implementation for tender 'deliveryAddress' 
	/// </summary>
	public class DeliveryAddress
	{
		/// <summary>
		/// The postalcode. 
		/// </summary>
		public string postalCode { get; set; }

		/// <summary>
		/// The country name. 
		/// </summary>
		public string countryName { get; set; }

		/// <summary>
		/// The street address. 
		/// </summary>
		public string streetAddress { get; set; }

		/// <summary>
		/// The region. 
		/// </summary>
		public string region { get; set; }

		/// <summary>
		/// The locality. 
		/// </summary>
		public string locality { get; set; }

	}

	///<summary>
	/// Implementation for tender 'deliveryDate'. 
	/// </summary>
	public class DeliveryDate
	{
		/// <summary>
		/// When started. 
		/// </summary>
		public string startDate { get; set; }

		/// <summary>
		/// When ended. 
		/// </summary>
		public string endDate { get; set; }

	}

	///<summary>
	/// Implementation for tender 'unit'. 
	/// </summary>
	public class Unit
	{
		/// <summary>
		/// The code. 
		/// </summary>
		public string code { get; set; }

		/// <summary>
		/// The name. 
		/// </summary>
		public string name { get; set; }

	}

	///<summary>
	/// Implementation for tender 'items'. 
	/// </summary>
	public class Item
	{
		/// <summary>
		/// Description about item. 
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// Item classfication. 
		/// </summary>
		public Classification classification { get; set; }

		/// <summary>
		/// Item additional classification. 
		/// </summary>
		public AdditionalClassification[] additionalClassifications { get; set; }

		/// <summary>
		/// Customer address. 
		/// </summary>
		public DeliveryAddress deliveryAddress { get; set; }

		/// <summary>
		/// The delivery date. 
		/// </summary>
		public DeliveryDate deliveryDate { get; set; }

		/// <summary>
		/// Item identifier. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The unit. 
		/// </summary>
		public Unit unit { get; set; }

		/// <summary>
		/// The quantity. 
		/// </summary>
		public Int32 quantity { get; set; }

	}

	///<summary>
	/// Implementation for tender 'value'. 
	/// </summary>
	public class Cost
	{
		/// <summary>
		/// The currency. 
		/// </summary>
		public string currency { get; set; }

		/// <summary>
		/// The amount. 
		/// </summary>
		public Single amount { get; set; }

		/// <summary>
		/// The value added tax included. 
		/// </summary>
		public Boolean valueAddedTaxIncluded { get; set; }

	}

	///<summary>
	/// Implementation for tender 'contactPoint'. 
	/// </summary>
	public class ContactPoint
	{
		/// <summary>
		/// The telephone number. 
		/// </summary>
		public string telephone { get; set; }

		/// <summary>
		/// The fax number. 
		/// </summary>
		public string faxNumber { get; set; }

		/// <summary>
		/// The name. 
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// The e-mail. 
		/// </summary>
		public string email { get; set; }

	}

	///<summary>
	/// Implementation for tender 'identifier'. 
	/// </summary>
	public class Identifier
	{
		/// <summary>
		/// The scheme. 
		/// </summary>
		public string scheme { get; set; }

		/// <summary>
		/// The identifier. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The legal name. 
		/// </summary>
		public string legalName { get; set; }

	}

	///<summary>
	/// Implementation for tender 'address'. 
	/// </summary>
	public class Address
	{
		/// <summary>
		/// The postalcode. 
		/// </summary>
		public string postalCode { get; set; }

		/// <summary>
		/// The country name. 
		/// </summary>
		public string countryName { get; set; }

		/// <summary>
		/// The street address. 
		/// </summary>
		public string streetAddress { get; set; }

		/// <summary>
		/// The region. 
		/// </summary>
		public string region { get; set; }

		/// <summary>
		/// The locality. 
		/// </summary>
		public string locality { get; set; }

	}

	///<summary>
	/// Implementation for tender 'procuringEntity'. 
	/// </summary>
	public class ProcuringEntity
	{
		/// <summary>
		/// The contact point. 
		/// </summary>
		public ContactPoint contactPoint { get; set; }

		/// <summary>
		/// The identifier. 
		/// </summary>
		public Identifier identifier { get; set; }

		/// <summary>
		/// The name. 
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// The address. 
		/// </summary>
		public Address address { get; set; }

	}

	///<summary>
	/// Implementation for tender 'enquiryPeriod'. 
	/// </summary>
	public class EnquiryPeriod
	{
		/// <summary>
		/// When started. 
		/// </summary>
		public string startDate { get; set; }

		/// <summary>
		/// When ended. 
		/// </summary>
		public string endDate { get; set; }

	}

	///<summary>
	/// Implementation for tender. 
	/// </summary>
	public class TenderOut
	{
		/// <summary>
		/// The procurement method. 
		/// </summary>
		public string procurementMethod { get; set; }

		/// <summary>
		/// The status. 
		/// </summary>
		public string status { get; set; }

		/// <summary>
		/// The tender period. 
		/// </summary>
		public TenderPeriod tenderPeriod { get; set; }

		/// <summary>
		/// The number of bids. 
		/// </summary>
		public Int32 numberOfBids { get; set; }

		/// <summary>
		/// The description. 
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// The title. 
		/// </summary>
		public string title { get; set; }

		/// <summary>
		/// The minimal step. 
		/// </summary>
		public MinimalStep minimalStep { get; set; }

		/// <summary>
		/// The items of tender. 
		/// </summary>
		public Item[] items { get; set; }

		/// <summary>
		/// The identifier. 
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The procurement method type. 
		/// </summary>
		public string procurementMethodType { get; set; }

		/// <summary>
		/// The cost. 
		/// </summary>
		public Cost cost { get; set; }

		/// <summary>
		/// The submission method. 
		/// </summary>
		public string submissionMethod { get; set; }

		/// <summary>
		/// The procuring entity. 
		/// </summary>
		public ProcuringEntity procuringEntity { get; set; }

		/// <summary>
		/// Tender identifier. 
		/// </summary>
		public string tenderID { get; set; }

		/// <summary>
		/// The enquiry period. 
		/// </summary>
		public EnquiryPeriod enquiryPeriod { get; set; }

		/// <summary>
		/// The owner. 
		/// </summary>
		public string owner { get; set; }

		/// <summary>
		/// When modified. 
		/// </summary>
		public string dateModified { get; set; }

		/// <summary>
		/// The award criteria. 
		/// </summary>
		public string awardCriteria { get; set; }

	}

}