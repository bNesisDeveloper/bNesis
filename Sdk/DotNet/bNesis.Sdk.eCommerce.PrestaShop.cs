using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;
using bNesis.Api.Desktop;
using bNesis.Sdk.Common;

namespace bNesis.Sdk.eCommerce.PrestaShop
{
	public class PrestaShop  
	{
		public string bNesisToken {get; private set;}
		private DesktopbNesisApi bNesisApi;

		public PrestaShop(DesktopbNesisApi bNesisApi)
		{
			this.bNesisApi = bNesisApi;
		}

		public string Auth(string data,string bNesisDevId,string redirectUrl,string clientId,string clientSecret,string[] scopes,string login,string password,bool isSandbox,string serviceUrl)
		{

			bNesisToken = bNesisApi.Auth("PrestaShop", data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl);

			return bNesisToken;
		}

		///<summary>
		/// Getting last exception for current provider 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo GetLastError()
		{
			return bNesisApi.Call<ErrorInfo>("PrestaShop", bNesisToken, "GetLastError");
		}

		///<summary>
		/// Getting arrays of error info 
		/// </summary>
		/// <returns></returns>
		public ErrorInfo[] GetErrorLog()
		{
			return bNesisApi.Call<ErrorInfo[]>("PrestaShop", bNesisToken, "GetErrorLog");
		}

		///<summary>
		/// Checks the token in the service. 
		/// </summary>
		/// <returns>if token valid return true, if token not valid return false</returns>
		public Boolean ValidateToken()
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "ValidateToken");
		}

		///<summary>
		/// Disables the access token used to authenticate the call. 
		/// </summary>
		/// <returns>if token revoked method returns true 
		/// if token doesn't support token revocation or token is revoked method returns false</returns>
		public Boolean Logoff()
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "Logoff");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="contactItem"></param>
		/// <returns></returns>
		public Boolean CreateCustomerUnified(ContactItem contactItem)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "CreateCustomerUnified", contactItem);
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public ContactItem[] GetCustomersUnified()
		{
			return bNesisApi.Call<ContactItem[]>("PrestaShop", bNesisToken, "GetCustomersUnified");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="productItem"></param>
		/// <returns></returns>
		public Boolean AddProductUnified(ProductItem productItem)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddProductUnified", productItem);
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public ProductItem[] GetProductsUnified()
		{
			return bNesisApi.Call<ProductItem[]>("PrestaShop", bNesisToken, "GetProductsUnified");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="IdProduct"></param>
		/// <returns></returns>
		public Boolean DeleteProductUnified(string IdProduct)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteProductUnified", IdProduct);
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public CountryItem[] GetCountriesUnified()
		{
			return bNesisApi.Call<CountryItem[]>("PrestaShop", bNesisToken, "GetCountriesUnified");
		}

		///<summary>
		///  
		/// </summary>
		/// <returns></returns>
		public Int32 GetCountCountriesUnified()
		{
			return bNesisApi.Call<Int32>("PrestaShop", bNesisToken, "GetCountCountriesUnified");
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="IdCountry"></param>
		/// <returns></returns>
		public CountryItem ReceiveCountryUnified(string IdCountry)
		{
			return bNesisApi.Call<CountryItem>("PrestaShop", bNesisToken, "ReceiveCountryUnified", IdCountry);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="IdCountry"></param>
		/// <returns></returns>
		public Boolean DeleteCountryUnified(string IdCountry)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteCountryUnified", IdCountry);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="countryItem"></param>
		/// <returns></returns>
		public CountryItem CreateCountryUnified(CountryItem countryItem)
		{
			return bNesisApi.Call<CountryItem>("PrestaShop", bNesisToken, "CreateCountryUnified", countryItem);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="countryItem"></param>
		/// <returns></returns>
		public CountryItem UpdateCountryUnified(CountryItem countryItem)
		{
			return bNesisApi.Call<CountryItem>("PrestaShop", bNesisToken, "UpdateCountryUnified", countryItem);
		}

		///<summary>
		///  
		/// </summary>
		/// <param name="IdCustomer"></param>
		/// <returns></returns>
		public ContactItem ReceiveCustomerUnified(string IdCustomer)
		{
			return bNesisApi.Call<ContactItem>("PrestaShop", bNesisToken, "ReceiveCustomerUnified", IdCustomer);
		}

		///<summary>
		/// Getting supply order states identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopSupplyOrderState.</returns>
		public Response GetSupplyOrderStatesIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetSupplyOrderStatesIdentifiersRaw");
		}

		///<summary>
		/// Getting supply order states by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about supply order states use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about SupplyOrderState in PrestaShopSupplyOrderState class.</returns>
		public Response GetSupplyOrderStatesByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetSupplyOrderStatesByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Getting supply order by identifier. 
		/// </summary>
		/// <param name="id">Identifier of supply order.</param>
		/// <returns>Return PrestaShopSupplyOrder.</returns>
		public Response GetSupplyOrderRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetSupplyOrderRaw", id);
		}

		///<summary>
		/// Getting supply orders identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopSupplyOrder.</returns>
		public Response GetSupplyOrdersIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetSupplyOrdersIdentifiersRaw");
		}

		///<summary>
		/// Getting supply orders by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about supply orders use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about SupplyOrder in PrestaShopSupplyOrder class.</returns>
		public Response GetSupplyOrdersByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetSupplyOrdersByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new tag. 
		/// </summary>
		/// <param name="tag">Body of tag.</param>
		/// <returns>If added return true.</returns>
		public Response AddTagRaw(Object tag)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddTagRaw", tag);
		}

		///<summary>
		/// Update information in specified tag. 
		/// </summary>
		/// <param name="tag">Body of tag.</param>
		/// <returns>Return updated PrestaShopTag.</returns>
		public Response EditTagRaw(Object tag)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditTagRaw", tag);
		}

		///<summary>
		/// Remove tag by identifier. 
		/// </summary>
		/// <param name="id">Identifier of tag.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteTagRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteTagRaw", id);
		}

		///<summary>
		/// Getting tag by identifier. 
		/// </summary>
		/// <param name="id">Identifier of tag.</param>
		/// <returns>Return PrestaShopTag.</returns>
		public Response GetTagRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetTagRaw", id);
		}

		///<summary>
		/// Getting tags identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopTag.</returns>
		public Response GetTagsIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetTagsIdentifiersRaw");
		}

		///<summary>
		/// Getting tags by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about tags use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Tag in PrestaShopTag class.</returns>
		public Response GetTagsByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetTagsByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new tax rule group. 
		/// </summary>
		/// <param name="taxRuleGroup">Body of tax rule group.</param>
		/// <returns>If added return true.</returns>
		public Response AddTaxRuleGroupRaw(Object taxRuleGroup)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddTaxRuleGroupRaw", taxRuleGroup);
		}

		///<summary>
		/// Update information in specified tax rule group. 
		/// </summary>
		/// <param name="taxRuleGroup">Body of tax rule group.</param>
		/// <returns>Return updated PrestaShopTaxRuleGroup.</returns>
		public Response EditTaxRuleGroupRaw(Object taxRuleGroup)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditTaxRuleGroupRaw", taxRuleGroup);
		}

		///<summary>
		/// Remove tax rule group by identifier. 
		/// </summary>
		/// <param name="id">Identifier of tax rule group.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteTaxRuleGroupRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteTaxRuleGroupRaw", id);
		}

		///<summary>
		/// Getting tax rule group by identifier. 
		/// </summary>
		/// <param name="id">Identifier of tax rule group.</param>
		/// <returns>Return PrestaShopTaxRuleGroup.</returns>
		public Response GetTaxRuleGroupRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetTaxRuleGroupRaw", id);
		}

		///<summary>
		/// Getting tax rule groups identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopTaxRuleGroup.</returns>
		public Response GetTaxRuleGroupsIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetTaxRuleGroupsIdentifiersRaw");
		}

		///<summary>
		/// Getting tax rule groups by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about tax rule groups use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about TaxRuleGroup in PrestaShopTaxRuleGroup class.</returns>
		public Response GetTaxRuleGroupsByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetTaxRuleGroupsByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new tax rule. 
		/// </summary>
		/// <param name="taxRule">Body of tax rule.</param>
		/// <returns>If added return true.</returns>
		public Response AddTaxRuleRaw(Object taxRule)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddTaxRuleRaw", taxRule);
		}

		///<summary>
		/// Update information in specified tax rule. 
		/// </summary>
		/// <param name="taxRule">Body of tax rule.</param>
		/// <returns>Return updated PrestaShopTaxRule.</returns>
		public Response EditTaxRuleRaw(Object taxRule)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditTaxRuleRaw", taxRule);
		}

		///<summary>
		/// Remove tax rule by identifier. 
		/// </summary>
		/// <param name="id">Identifier of tax rule.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteTaxRuleRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteTaxRuleRaw", id);
		}

		///<summary>
		/// Getting tax rule by identifier. 
		/// </summary>
		/// <param name="id">Identifier of tax rule.</param>
		/// <returns>Return PrestaShopTaxRule.</returns>
		public Response GetTaxRuleRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetTaxRuleRaw", id);
		}

		///<summary>
		/// Getting tax rules identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopTaxRule.</returns>
		public Response GetTaxRulesIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetTaxRulesIdentifiersRaw");
		}

		///<summary>
		/// Getting tax rules by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about tax rules use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about TaxRule in PrestaShopTaxRule class.</returns>
		public Response GetTaxRulesByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetTaxRulesByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new tax. 
		/// </summary>
		/// <param name="tax">Body of tax.</param>
		/// <returns>If added return true.</returns>
		public Response AddTaxRaw(Object tax)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddTaxRaw", tax);
		}

		///<summary>
		/// Update information in specified tax. 
		/// </summary>
		/// <param name="tax">Body of tax.</param>
		/// <returns>Return updated PrestaShopTax.</returns>
		public Response EditTaxRaw(Object tax)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditTaxRaw", tax);
		}

		///<summary>
		/// Remove tax by identifier. 
		/// </summary>
		/// <param name="id">Identifier of tax.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteTaxRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteTaxRaw", id);
		}

		///<summary>
		/// Getting tax by identifier. 
		/// </summary>
		/// <param name="id">Identifier of tax.</param>
		/// <returns>Return PrestaShopTax.</returns>
		public Response GetTaxRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetTaxRaw", id);
		}

		///<summary>
		/// Getting taxes identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopTax.</returns>
		public Response GetTaxesIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetTaxesIdentifiersRaw");
		}

		///<summary>
		/// Getting taxes by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about taxes use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Tax in PrestaShopTax class.</returns>
		public Response GetTaxesByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetTaxesByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new translated configuration. 
		/// </summary>
		/// <param name="translatedConfiguration">Body of translated configuration.</param>
		/// <returns>If added return true.</returns>
		public Response AddTranslatedConfigurationRaw(Object translatedConfiguration)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddTranslatedConfigurationRaw", translatedConfiguration);
		}

		///<summary>
		/// Update information in specified translated configuration. 
		/// </summary>
		/// <param name="translatedConfiguration">Body of translated configuration.</param>
		/// <returns>Return updated PrestaShopTranslatedConfiguration.</returns>
		public Response EditTranslatedConfigurationRaw(Object translatedConfiguration)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditTranslatedConfigurationRaw", translatedConfiguration);
		}

		///<summary>
		/// Remove translated configuration by identifier. 
		/// </summary>
		/// <param name="id">Identifier of translated configuration.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteTranslatedConfigurationRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteTranslatedConfigurationRaw", id);
		}

		///<summary>
		/// Getting translated configuration by identifier. 
		/// </summary>
		/// <param name="id">Identifier of translated configuration.</param>
		/// <returns>Return PrestaShopTranslatedConfiguration.</returns>
		public Response GetTranslatedConfigurationRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetTranslatedConfigurationRaw", id);
		}

		///<summary>
		/// Getting translated configurations identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopTranslatedConfiguration.</returns>
		public Response GetTranslatedConfigurationsIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetTranslatedConfigurationsIdentifiersRaw");
		}

		///<summary>
		/// Getting translated configurations by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about translated configurations use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about TranslatedConfiguration in PrestaShopTranslatedConfiguration class.</returns>
		public Response GetTranslatedConfigurationsByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetTranslatedConfigurationsByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Getting warehouse product location by identifier. 
		/// </summary>
		/// <param name="id">Identifier of warehouse product location.</param>
		/// <returns>Return PrestaShopWarehouseProductLocation.</returns>
		public Response GetWarehouseProductLocationRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetWarehouseProductLocationRaw", id);
		}

		///<summary>
		/// Getting warehouse product locations identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopWarehouseProductLocation.</returns>
		public Response GetWarehouseProductLocationsIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetWarehouseProductLocationsIdentifiersRaw");
		}

		///<summary>
		/// Getting warehouse product locations by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about warehouse product locations use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about WarehouseProductLocation in PrestaShopWarehouseProductLocation class.</returns>
		public Response GetWarehouseProductLocationsByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetWarehouseProductLocationsByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new weight range. 
		/// </summary>
		/// <param name="weightRange">Body of weight range.</param>
		/// <returns>If added return true.</returns>
		public Response AddWeightRangeRaw(Object weightRange)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddWeightRangeRaw", weightRange);
		}

		///<summary>
		/// Update information in specified weight range. 
		/// </summary>
		/// <param name="weightRange">Body of weight range.</param>
		/// <returns>Return updated PrestaShopWeightRange.</returns>
		public Response EditWeightRangeRaw(Object weightRange)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditWeightRangeRaw", weightRange);
		}

		///<summary>
		/// Remove weight range by identifier. 
		/// </summary>
		/// <param name="id">Identifier of weight range.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteWeightRangeRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteWeightRangeRaw", id);
		}

		///<summary>
		/// Getting weight range by identifier. 
		/// </summary>
		/// <param name="id">Identifier of weight range.</param>
		/// <returns>Return PrestaShopWeightRange.</returns>
		public Response GetWeightRangeRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetWeightRangeRaw", id);
		}

		///<summary>
		/// Getting weight ranges identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopWeightRange.</returns>
		public Response GetWeightRangesIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetWeightRangesIdentifiersRaw");
		}

		///<summary>
		/// Getting weight ranges by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about weight ranges use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about WeightRange in PrestaShopWeightRange class.</returns>
		public Response GetWeightRangesByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetWeightRangesByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new zone. 
		/// </summary>
		/// <param name="zone">Body of zone.</param>
		/// <returns>If added return true.</returns>
		public Response AddZoneRaw(Object zone)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddZoneRaw", zone);
		}

		///<summary>
		/// Update information in specified zone. 
		/// </summary>
		/// <param name="zone">Body of zone.</param>
		/// <returns>Return updated PrestaShopZone.</returns>
		public Response EditZoneRaw(Object zone)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditZoneRaw", zone);
		}

		///<summary>
		/// Remove zone by identifier. 
		/// </summary>
		/// <param name="id">Identifier of zone.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteZoneRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteZoneRaw", id);
		}

		///<summary>
		/// Getting zone by identifier. 
		/// </summary>
		/// <param name="id">Identifier of zone.</param>
		/// <returns>Return PrestaShopZone.</returns>
		public Response GetZoneRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetZoneRaw", id);
		}

		///<summary>
		/// Getting zones identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopZone.</returns>
		public Response GetZonesIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetZonesIdentifiersRaw");
		}

		///<summary>
		/// Getting zones by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about zones use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Zone in PrestaShopZone class.</returns>
		public Response GetZonesByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetZonesByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Getting shop group by identifier. 
		/// </summary>
		/// <param name="id">Identifier of shop group.</param>
		/// <returns>Return PrestaShopShopGroup.</returns>
		public Response GetShopGroupRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetShopGroupRaw", id);
		}

		///<summary>
		/// Getting shop groups identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopShopGroup.</returns>
		public Response GetShopGroupsIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetShopGroupsIdentifiersRaw");
		}

		///<summary>
		/// Getting shop groups by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about shop groups use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about ShopGroup in PrestaShopShopGroup class.</returns>
		public Response GetShopGroupsByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetShopGroupsByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new shop url. 
		/// </summary>
		/// <param name="shopUrl">Body of shop url.</param>
		/// <returns>If added return true.</returns>
		public Response AddShopUrlRaw(Object shopUrl)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddShopUrlRaw", shopUrl);
		}

		///<summary>
		/// Update information in specified shop url. 
		/// </summary>
		/// <param name="shopUrl">Body of shop url.</param>
		/// <returns>Return updated PrestaShopShopUrl.</returns>
		public Response EditShopUrlRaw(Object shopUrl)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditShopUrlRaw", shopUrl);
		}

		///<summary>
		/// Remove shop url by identifier. 
		/// </summary>
		/// <param name="id">Identifier of shop url.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteShopUrlRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteShopUrlRaw", id);
		}

		///<summary>
		/// Getting shop url by identifier. 
		/// </summary>
		/// <param name="id">Identifier of shop url.</param>
		/// <returns>Return PrestaShopShopUrl.</returns>
		public Response GetShopUrlRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetShopUrlRaw", id);
		}

		///<summary>
		/// Getting shop urls identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopShopUrl.</returns>
		public Response GetShopUrlsIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetShopUrlsIdentifiersRaw");
		}

		///<summary>
		/// Getting shop urls by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about shop urls use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about ShopUrl in PrestaShopShopUrl class.</returns>
		public Response GetShopUrlsByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetShopUrlsByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new shop. 
		/// </summary>
		/// <param name="shop">Body of shop.</param>
		/// <returns>If added return true.</returns>
		public Response AddShopRaw(Object shop)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddShopRaw", shop);
		}

		///<summary>
		/// Update information in specified shop. 
		/// </summary>
		/// <param name="shop">Body of shop.</param>
		/// <returns>Return updated PrestaShopShop.</returns>
		public Response EditShopRaw(Object shop)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditShopRaw", shop);
		}

		///<summary>
		/// Remove shop by identifier. 
		/// </summary>
		/// <param name="id">Identifier of shop.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteShopRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteShopRaw", id);
		}

		///<summary>
		/// Getting shop by identifier. 
		/// </summary>
		/// <param name="id">Identifier of shop.</param>
		/// <returns>Return PrestaShopShop.</returns>
		public Response GetShopRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetShopRaw", id);
		}

		///<summary>
		/// Getting shops identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopShop.</returns>
		public Response GetShopsIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetShopsIdentifiersRaw");
		}

		///<summary>
		/// Getting shops by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about shops use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Shop in PrestaShopShop class.</returns>
		public Response GetShopsByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetShopsByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new specific price rule. 
		/// </summary>
		/// <param name="specificPriceRule">Body of specific price rule.</param>
		/// <returns>If added return true.</returns>
		public Response AddSpecificPriceRuleRaw(Object specificPriceRule)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddSpecificPriceRuleRaw", specificPriceRule);
		}

		///<summary>
		/// Update information in specified specific price rule. 
		/// </summary>
		/// <param name="specificPriceRule">Body of specific price rule.</param>
		/// <returns>Return updated PrestaShopSpecificPriceRule.</returns>
		public Response EditSpecificPriceRuleRaw(Object specificPriceRule)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditSpecificPriceRuleRaw", specificPriceRule);
		}

		///<summary>
		/// Remove specific price rule by identifier. 
		/// </summary>
		/// <param name="id">Identifier of specific price rule.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteSpecificPriceRuleRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteSpecificPriceRuleRaw", id);
		}

		///<summary>
		/// Getting specific price rule by identifier. 
		/// </summary>
		/// <param name="id">Identifier of specific price rule.</param>
		/// <returns>Return PrestaShopSpecificPriceRule.</returns>
		public Response GetSpecificPriceRuleRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetSpecificPriceRuleRaw", id);
		}

		///<summary>
		/// Getting specific price rules identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopSpecificPriceRule.</returns>
		public Response GetSpecificPriceRulesIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetSpecificPriceRulesIdentifiersRaw");
		}

		///<summary>
		/// Getting specific price rules by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about specific price rules use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about SpecificPriceRule in PrestaShopSpecificPriceRule class.</returns>
		public Response GetSpecificPriceRulesByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetSpecificPriceRulesByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new specific price. 
		/// </summary>
		/// <param name="specificPrice">Body of specific price.</param>
		/// <returns>If added return true.</returns>
		public Response AddSpecificPriceRaw(Object specificPrice)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddSpecificPriceRaw", specificPrice);
		}

		///<summary>
		/// Update information in specified specific price. 
		/// </summary>
		/// <param name="specificPrice">Body of specific price.</param>
		/// <returns>Return updated PrestaShopSpecificPrice.</returns>
		public Response EditSpecificPriceRaw(Object specificPrice)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditSpecificPriceRaw", specificPrice);
		}

		///<summary>
		/// Remove specific price by identifier. 
		/// </summary>
		/// <param name="id">Identifier of specific price.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteSpecificPriceRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteSpecificPriceRaw", id);
		}

		///<summary>
		/// Getting specific price by identifier. 
		/// </summary>
		/// <param name="id">Identifier of specific price.</param>
		/// <returns>Return PrestaShopSpecificPrice.</returns>
		public Response GetSpecificPriceRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetSpecificPriceRaw", id);
		}

		///<summary>
		/// Getting specific prices identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopSpecificPrice.</returns>
		public Response GetSpecificPricesIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetSpecificPricesIdentifiersRaw");
		}

		///<summary>
		/// Getting specific prices by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about specific prices use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about SpecificPrice in PrestaShopSpecificPrice class.</returns>
		public Response GetSpecificPricesByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetSpecificPricesByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Getting state by identifier. 
		/// </summary>
		/// <param name="id">Identifier of state.</param>
		/// <returns>Return PrestaShopState.</returns>
		public Response GetStateRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetStateRaw", id);
		}

		///<summary>
		/// Getting states identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopState.</returns>
		public Response GetStatesIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetStatesIdentifiersRaw");
		}

		///<summary>
		/// Getting states by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about states use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about State in PrestaShopState class.</returns>
		public Response GetStatesByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetStatesByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new stock movement reason. 
		/// </summary>
		/// <param name="stockMovementReason">Body of stock movement reason.</param>
		/// <returns>If added return true.</returns>
		public Response AddStockMovementReasonRaw(Object stockMovementReason)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddStockMovementReasonRaw", stockMovementReason);
		}

		///<summary>
		/// Update information in specified stock movement reason. 
		/// </summary>
		/// <param name="stockMovementReason">Body of stock movement reason.</param>
		/// <returns>Return updated PrestaShopStockMovementReason.</returns>
		public Response EditStockMovementReasonRaw(Object stockMovementReason)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditStockMovementReasonRaw", stockMovementReason);
		}

		///<summary>
		/// Remove stock movement reason by identifier. 
		/// </summary>
		/// <param name="id">Identifier of stock movement reason.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteStockMovementReasonRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteStockMovementReasonRaw", id);
		}

		///<summary>
		/// Getting stock movement reason by identifier. 
		/// </summary>
		/// <param name="id">Identifier of stock movement reason.</param>
		/// <returns>Return PrestaShopStockMovementReason.</returns>
		public Response GetStockMovementReasonRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetStockMovementReasonRaw", id);
		}

		///<summary>
		/// Getting stock movement reasons identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopStockMovementReason.</returns>
		public Response GetStockMovementReasonsIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetStockMovementReasonsIdentifiersRaw");
		}

		///<summary>
		/// Getting stock movement reasons by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about stock movement reasons use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about StockMovementReason in PrestaShopStockMovementReason class.</returns>
		public Response GetStockMovementReasonsByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetStockMovementReasonsByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Getting stock movement by identifier. 
		/// </summary>
		/// <param name="id">Identifier of stock movement.</param>
		/// <returns>Return PrestaShopStockMovement.</returns>
		public Response GetStockMovementRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetStockMovementRaw", id);
		}

		///<summary>
		/// Getting stock movements identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopStockMovement.</returns>
		public Response GetStockMovementsIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetStockMovementsIdentifiersRaw");
		}

		///<summary>
		/// Getting stock movements by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about stock movements use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about StockMovement in PrestaShopStockMovement class.</returns>
		public Response GetStockMovementsByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetStockMovementsByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Getting stock by identifier. 
		/// </summary>
		/// <param name="id">Identifier of stock.</param>
		/// <returns>Return PrestaShopStock.</returns>
		public Response GetStockRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetStockRaw", id);
		}

		///<summary>
		/// Getting stocks identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopStock.</returns>
		public Response GetStocksIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetStocksIdentifiersRaw");
		}

		///<summary>
		/// Getting stocks by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about stocks use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Stock in PrestaShopStock class.</returns>
		public Response GetStocksByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetStocksByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new store. 
		/// </summary>
		/// <param name="store">Body of store.</param>
		/// <returns>If added return true.</returns>
		public Response AddStoreRaw(Object store)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddStoreRaw", store);
		}

		///<summary>
		/// Update information in specified store. 
		/// </summary>
		/// <param name="store">Body of store.</param>
		/// <returns>Return updated PrestaShopStore.</returns>
		public Response EditStoreRaw(Object store)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditStoreRaw", store);
		}

		///<summary>
		/// Remove store by identifier. 
		/// </summary>
		/// <param name="id">Identifier of store.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteStoreRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteStoreRaw", id);
		}

		///<summary>
		/// Getting store by identifier. 
		/// </summary>
		/// <param name="id">Identifier of store.</param>
		/// <returns>Return PrestaShopStore.</returns>
		public Response GetStoreRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetStoreRaw", id);
		}

		///<summary>
		/// Getting stores identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopStore.</returns>
		public Response GetStoresIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetStoresIdentifiersRaw");
		}

		///<summary>
		/// Getting stores by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about stores use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Store in PrestaShopStore class.</returns>
		public Response GetStoresByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetStoresByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new supplier. 
		/// </summary>
		/// <param name="supplier">Body of supplier.</param>
		/// <returns>If added return true.</returns>
		public Response AddSupplierRaw(Object supplier)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddSupplierRaw", supplier);
		}

		///<summary>
		/// Update information in specified supplier. 
		/// </summary>
		/// <param name="supplier">Body of supplier.</param>
		/// <returns>Return updated PrestaShopSupplier.</returns>
		public Response EditSupplierRaw(Object supplier)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditSupplierRaw", supplier);
		}

		///<summary>
		/// Remove supplier by identifier. 
		/// </summary>
		/// <param name="id">Identifier of supplier.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteSupplierRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteSupplierRaw", id);
		}

		///<summary>
		/// Getting supplier by identifier. 
		/// </summary>
		/// <param name="id">Identifier of supplier.</param>
		/// <returns>Return PrestaShopSupplier.</returns>
		public Response GetSupplierRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetSupplierRaw", id);
		}

		///<summary>
		/// Getting suppliers identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopSupplier.</returns>
		public Response GetSuppliersIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetSuppliersIdentifiersRaw");
		}

		///<summary>
		/// Getting suppliers by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about suppliers use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Supplier in PrestaShopSupplier class.</returns>
		public Response GetSuppliersByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetSuppliersByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Getting supply order detail by identifier. 
		/// </summary>
		/// <param name="id">Identifier of supply order detail.</param>
		/// <returns>Return PrestaShopSupplyOrderDetail.</returns>
		public Response GetSupplyOrderDetailRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetSupplyOrderDetailRaw", id);
		}

		///<summary>
		/// Getting supply order details identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopSupplyOrderDetail.</returns>
		public Response GetSupplyOrderDetailsIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetSupplyOrderDetailsIdentifiersRaw");
		}

		///<summary>
		/// Getting supply order details by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about supply order details use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about SupplyOrderDetail in PrestaShopSupplyOrderDetail class.</returns>
		public Response GetSupplyOrderDetailsByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetSupplyOrderDetailsByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Getting supply order history by identifier. 
		/// </summary>
		/// <param name="id">Identifier of supply order history.</param>
		/// <returns>Return PrestaShopSupplyOrderHistory.</returns>
		public Response GetSupplyOrderHistoryRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetSupplyOrderHistoryRaw", id);
		}

		///<summary>
		/// Getting supply order histories identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopSupplyOrderHistory.</returns>
		public Response GetSupplyOrderHistoriesIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetSupplyOrderHistoriesIdentifiersRaw");
		}

		///<summary>
		/// Getting supply order histories by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about supply order histories use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about SupplyOrderHistory in PrestaShopSupplyOrderHistory class.</returns>
		public Response GetSupplyOrderHistoriesByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetSupplyOrderHistoriesByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Getting supply order receipt history by identifier. 
		/// </summary>
		/// <param name="id">Identifier of supply order receipt history.</param>
		/// <returns>Return PrestaShopSupplyOrderReceiptHistory.</returns>
		public Response GetSupplyOrderReceiptHistoryRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetSupplyOrderReceiptHistoryRaw", id);
		}

		///<summary>
		/// Getting supply order receipt histories identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopSupplyOrderReceiptHistory.</returns>
		public Response GetSupplyOrderReceiptHistoriesIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetSupplyOrderReceiptHistoriesIdentifiersRaw");
		}

		///<summary>
		/// Getting supply order receipt histories by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about supply order receipt histories use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about SupplyOrderReceiptHistory in PrestaShopSupplyOrderReceiptHistory class.</returns>
		public Response GetSupplyOrderReceiptHistoriesByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetSupplyOrderReceiptHistoriesByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Getting supply order state by identifier. 
		/// </summary>
		/// <param name="id">Identifier of supply order state.</param>
		/// <returns>Return PrestaShopSupplyOrderState.</returns>
		public Response GetSupplyOrderStateRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetSupplyOrderStateRaw", id);
		}

		///<summary>
		/// Getting order payments by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about order payments use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about OrderPayment in PrestaShopOrderPayment class.</returns>
		public Response GetOrderPaymentsByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetOrderPaymentsByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new order slip. 
		/// </summary>
		/// <param name="orderSlip">Body of order slip.</param>
		/// <returns>If added return true.</returns>
		public Response AddOrderSlipRaw(Object orderSlip)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddOrderSlipRaw", orderSlip);
		}

		///<summary>
		/// Update information in specified order slip. 
		/// </summary>
		/// <param name="orderSlip">Body of order slip.</param>
		/// <returns>Return updated PrestaShopOrderSlip.</returns>
		public Response EditOrderSlipRaw(Object orderSlip)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditOrderSlipRaw", orderSlip);
		}

		///<summary>
		/// Remove order slip by identifier. 
		/// </summary>
		/// <param name="id">Identifier of order slip.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteOrderSlipRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteOrderSlipRaw", id);
		}

		///<summary>
		/// Getting order slip by identifier. 
		/// </summary>
		/// <param name="id">Identifier of order slip.</param>
		/// <returns>Return PrestaShopOrderSlip.</returns>
		public Response GetOrderSlipRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetOrderSlipRaw", id);
		}

		///<summary>
		/// Getting order slip identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopOrderSlip.</returns>
		public Response GetOrderSlipIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetOrderSlipIdentifiersRaw");
		}

		///<summary>
		/// Getting order slip by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about order slip use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about OrderSlip in PrestaShopOrderSlip class.</returns>
		public Response GetOrderSlipByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetOrderSlipByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Getting order state by identifier. 
		/// </summary>
		/// <param name="id">Identifier of order state.</param>
		/// <returns>Return PrestaShopOrderState.</returns>
		public Response GetOrderStateRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetOrderStateRaw", id);
		}

		///<summary>
		/// Getting order states identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopOrderState.</returns>
		public Response GetOrderStatesIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetOrderStatesIdentifiersRaw");
		}

		///<summary>
		/// Getting order states by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about order states use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about OrderState in PrestaShopOrderState class.</returns>
		public Response GetOrderStatesByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetOrderStatesByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Getting order by identifier. 
		/// </summary>
		/// <param name="id">Identifier of order.</param>
		/// <returns>Return PrestaShopOrder.</returns>
		public Response GetOrderRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetOrderRaw", id);
		}

		///<summary>
		/// Getting orders identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopOrder.</returns>
		public Response GetOrdersIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetOrdersIdentifiersRaw");
		}

		///<summary>
		/// Getting orders by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about orders use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Order in PrestaShopOrder class.</returns>
		public Response GetOrdersByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetOrdersByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new price range. 
		/// </summary>
		/// <param name="priceRange">Body of price range.</param>
		/// <returns>If added return true.</returns>
		public Response AddPriceRangeRaw(Object priceRange)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddPriceRangeRaw", priceRange);
		}

		///<summary>
		/// Update information in specified price range. 
		/// </summary>
		/// <param name="priceRange">Body of price range.</param>
		/// <returns>Return updated PrestaShopPriceRange.</returns>
		public Response EditPriceRangeRaw(Object priceRange)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditPriceRangeRaw", priceRange);
		}

		///<summary>
		/// Remove price range by identifier. 
		/// </summary>
		/// <param name="id">Identifier of price range.</param>
		/// <returns>If removed return true.</returns>
		public Response DeletePriceRangeRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeletePriceRangeRaw", id);
		}

		///<summary>
		/// Getting price range by identifier. 
		/// </summary>
		/// <param name="id">Identifier of price range.</param>
		/// <returns>Return PrestaShopPriceRange.</returns>
		public Response GetPriceRangeRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetPriceRangeRaw", id);
		}

		///<summary>
		/// Getting price ranges identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopPriceRange.</returns>
		public Response GetPriceRangesIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetPriceRangesIdentifiersRaw");
		}

		///<summary>
		/// Getting price ranges by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about price ranges use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about PriceRange in PrestaShopPriceRange class.</returns>
		public Response GetPriceRangesByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetPriceRangesByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new product customization field. 
		/// </summary>
		/// <param name="productCustomizationField">Body of product customization field.</param>
		/// <returns>If added return true.</returns>
		public Response AddProductCustomizationFieldRaw(Object productCustomizationField)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddProductCustomizationFieldRaw", productCustomizationField);
		}

		///<summary>
		/// Update information in specified product customization field. 
		/// </summary>
		/// <param name="productCustomizationField">Body of product customization field.</param>
		/// <returns>Return updated PrestaShopProductCustomizationField.</returns>
		public Response EditProductCustomizationFieldRaw(Object productCustomizationField)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditProductCustomizationFieldRaw", productCustomizationField);
		}

		///<summary>
		/// Remove product customization field by identifier. 
		/// </summary>
		/// <param name="id">Identifier of product customization field.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteProductCustomizationFieldRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteProductCustomizationFieldRaw", id);
		}

		///<summary>
		/// Getting product customization field by identifier. 
		/// </summary>
		/// <param name="id">Identifier of product customization field.</param>
		/// <returns>Return PrestaShopProductCustomizationField.</returns>
		public Response GetProductCustomizationFieldRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetProductCustomizationFieldRaw", id);
		}

		///<summary>
		/// Getting product customization fields identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopProductCustomizationField.</returns>
		public Response GetProductCustomizationFieldsIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetProductCustomizationFieldsIdentifiersRaw");
		}

		///<summary>
		/// Getting product customization fields by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about product customization fields use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about ProductCustomizationField in PrestaShopProductCustomizationField class.</returns>
		public Response GetProductCustomizationFieldsByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetProductCustomizationFieldsByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new product feature value. 
		/// </summary>
		/// <param name="productFeatureValue">Body of product feature value.</param>
		/// <returns>If added return true.</returns>
		public Response AddProductFeatureValueRaw(Object productFeatureValue)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddProductFeatureValueRaw", productFeatureValue);
		}

		///<summary>
		/// Update information in specified product feature value. 
		/// </summary>
		/// <param name="productFeatureValue">Body of product feature value.</param>
		/// <returns>Return updated PrestaShopProductFeatureValue.</returns>
		public Response EditProductFeatureValueRaw(Object productFeatureValue)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditProductFeatureValueRaw", productFeatureValue);
		}

		///<summary>
		/// Remove product feature value by identifier. 
		/// </summary>
		/// <param name="id">Identifier of product feature value.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteProductFeatureValueRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteProductFeatureValueRaw", id);
		}

		///<summary>
		/// Getting product feature value by identifier. 
		/// </summary>
		/// <param name="id">Identifier of product feature value.</param>
		/// <returns>Return PrestaShopProductFeatureValue.</returns>
		public Response GetProductFeatureValueRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetProductFeatureValueRaw", id);
		}

		///<summary>
		/// Getting product feature values identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopProductFeatureValue.</returns>
		public Response GetProductFeatureValuesIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetProductFeatureValuesIdentifiersRaw");
		}

		///<summary>
		/// Getting product feature values by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about product feature values use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about ProductFeatureValue in PrestaShopProductFeatureValue class.</returns>
		public Response GetProductFeatureValuesByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetProductFeatureValuesByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new product feature. 
		/// </summary>
		/// <param name="productFeature">Body of product feature.</param>
		/// <returns>If added return true.</returns>
		public Response AddProductFeatureRaw(Object productFeature)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddProductFeatureRaw", productFeature);
		}

		///<summary>
		/// Update information in specified product feature. 
		/// </summary>
		/// <param name="productFeature">Body of product feature.</param>
		/// <returns>Return updated PrestaShopProductFeature.</returns>
		public Response EditProductFeatureRaw(Object productFeature)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditProductFeatureRaw", productFeature);
		}

		///<summary>
		/// Remove product feature by identifier. 
		/// </summary>
		/// <param name="id">Identifier of product feature.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteProductFeatureRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteProductFeatureRaw", id);
		}

		///<summary>
		/// Getting product feature by identifier. 
		/// </summary>
		/// <param name="id">Identifier of product feature.</param>
		/// <returns>Return PrestaShopProductFeature.</returns>
		public Response GetProductFeatureRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetProductFeatureRaw", id);
		}

		///<summary>
		/// Getting product features identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopProductFeature.</returns>
		public Response GetProductFeaturesIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetProductFeaturesIdentifiersRaw");
		}

		///<summary>
		/// Getting product features by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about product features use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about ProductFeature in PrestaShopProductFeature class.</returns>
		public Response GetProductFeaturesByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetProductFeaturesByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new product option value. 
		/// </summary>
		/// <param name="productOptionValue">Body of product option value.</param>
		/// <returns>If added return true.</returns>
		public Response AddProductOptionValueRaw(Object productOptionValue)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddProductOptionValueRaw", productOptionValue);
		}

		///<summary>
		/// Update information in specified product option value. 
		/// </summary>
		/// <param name="productOptionValue">Body of product option value.</param>
		/// <returns>Return updated PrestaShopProductOptionValue.</returns>
		public Response EditProductOptionValueRaw(Object productOptionValue)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditProductOptionValueRaw", productOptionValue);
		}

		///<summary>
		/// Remove product option value by identifier. 
		/// </summary>
		/// <param name="id">Identifier of product option value.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteProductOptionValueRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteProductOptionValueRaw", id);
		}

		///<summary>
		/// Getting product option value by identifier. 
		/// </summary>
		/// <param name="id">Identifier of product option value.</param>
		/// <returns>Return PrestaShopProductOptionValue.</returns>
		public Response GetProductOptionValueRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetProductOptionValueRaw", id);
		}

		///<summary>
		/// Getting product option values identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopProductOptionValue.</returns>
		public Response GetProductOptionValuesIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetProductOptionValuesIdentifiersRaw");
		}

		///<summary>
		/// Getting product option values by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about product option values use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about ProductOptionValue in PrestaShopProductOptionValue class.</returns>
		public Response GetProductOptionValuesByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetProductOptionValuesByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new product option. 
		/// </summary>
		/// <param name="productOption">Body of product option.</param>
		/// <returns>If added return true.</returns>
		public Response AddProductOptionRaw(Object productOption)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddProductOptionRaw", productOption);
		}

		///<summary>
		/// Update information in specified product option. 
		/// </summary>
		/// <param name="productOption">Body of product option.</param>
		/// <returns>Return updated PrestaShopProductOption.</returns>
		public Response EditProductOptionRaw(Object productOption)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditProductOptionRaw", productOption);
		}

		///<summary>
		/// Remove product option by identifier. 
		/// </summary>
		/// <param name="id">Identifier of product option.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteProductOptionRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteProductOptionRaw", id);
		}

		///<summary>
		/// Getting product option by identifier. 
		/// </summary>
		/// <param name="id">Identifier of product option.</param>
		/// <returns>Return PrestaShopProductOption.</returns>
		public Response GetProductOptionRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetProductOptionRaw", id);
		}

		///<summary>
		/// Getting product options identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopProductOption.</returns>
		public Response GetProductOptionsIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetProductOptionsIdentifiersRaw");
		}

		///<summary>
		/// Getting product options by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about product options use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about ProductOption in PrestaShopProductOption class.</returns>
		public Response GetProductOptionsByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetProductOptionsByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new product supplier. 
		/// </summary>
		/// <param name="productSupplier">Body of product supplier.</param>
		/// <returns>If added return true.</returns>
		public Response AddProductSupplierRaw(Object productSupplier)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddProductSupplierRaw", productSupplier);
		}

		///<summary>
		/// Update information in specified product supplier. 
		/// </summary>
		/// <param name="productSupplier">Body of product supplier.</param>
		/// <returns>Return updated PrestaShopProductSupplier.</returns>
		public Response EditProductSupplierRaw(Object productSupplier)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditProductSupplierRaw", productSupplier);
		}

		///<summary>
		/// Remove product supplier by identifier. 
		/// </summary>
		/// <param name="id">Identifier of product supplier.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteProductSupplierRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteProductSupplierRaw", id);
		}

		///<summary>
		/// Getting product supplier by identifier. 
		/// </summary>
		/// <param name="id">Identifier of product supplier.</param>
		/// <returns>Return PrestaShopProductSupplier.</returns>
		public Response GetProductSupplierRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetProductSupplierRaw", id);
		}

		///<summary>
		/// Getting product suppliers identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopProductSupplier.</returns>
		public Response GetProductSuppliersIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetProductSuppliersIdentifiersRaw");
		}

		///<summary>
		/// Getting product suppliers by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about product suppliers use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about ProductSupplier in PrestaShopProductSupplier class.</returns>
		public Response GetProductSuppliersByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetProductSuppliersByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new product supplier. 
		/// </summary>
		/// <param name="product">Body of product supplier.</param>
		/// <returns>If added return true.</returns>
		public Response AddProductRaw(Object product)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddProductRaw", product);
		}

		///<summary>
		/// Update information in specified product supplier. 
		/// </summary>
		/// <param name="product">Body of product supplier.</param>
		/// <returns>Return updated PrestaShopProduct.</returns>
		public Response EditProductRaw(Object product)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditProductRaw", product);
		}

		///<summary>
		/// Remove product by identifier. 
		/// </summary>
		/// <param name="id">Identifier of product.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteProductRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteProductRaw", id);
		}

		///<summary>
		/// Getting product by identifier. 
		/// </summary>
		/// <param name="id">Identifier of product.</param>
		/// <returns>Return PrestaShopProduct.</returns>
		public Response GetProductRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetProductRaw", id);
		}

		///<summary>
		/// Getting products identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopProduct.</returns>
		public Response GetProductsIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetProductsIdentifiersRaw");
		}

		///<summary>
		/// Getting products by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about products use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Product in PrestaShopProduct class.</returns>
		public Response GetProductsByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetProductsByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new shop group. 
		/// </summary>
		/// <param name="shopGroup">Body of shop group.</param>
		/// <returns>If added return true.</returns>
		public Response AddShopGroupRaw(Object shopGroup)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddShopGroupRaw", shopGroup);
		}

		///<summary>
		/// Update information in specified shop group. 
		/// </summary>
		/// <param name="shopGroup">Body of shop group.</param>
		/// <returns>Return updated PrestaShopShopGroup.</returns>
		public Response EditShopGroupRaw(Object shopGroup)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditShopGroupRaw", shopGroup);
		}

		///<summary>
		/// Remove shop group by identifier. 
		/// </summary>
		/// <param name="id">Identifier of shop group.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteShopGroupRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteShopGroupRaw", id);
		}

		///<summary>
		/// Update information in specified group. 
		/// </summary>
		/// <param name="group">Body of group.</param>
		/// <returns>Return updated PrestaShopGroup.</returns>
		public Response EditGroupRaw(Object group)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditGroupRaw", group);
		}

		///<summary>
		/// Remove group by identifier. 
		/// </summary>
		/// <param name="id">Identifier of group.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteGroupRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteGroupRaw", id);
		}

		///<summary>
		/// Getting group by identifier. 
		/// </summary>
		/// <param name="id">Identifier of group.</param>
		/// <returns>Return PrestaShopGroup.</returns>
		public Response GetGroupRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetGroupRaw", id);
		}

		///<summary>
		/// Getting groups identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopGroup.</returns>
		public Response GetGroupsIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetGroupsIdentifiersRaw");
		}

		///<summary>
		/// Getting groups by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about groups use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Group in PrestaShopGroup class.</returns>
		public Response GetGroupsByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetGroupsByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new guest. 
		/// </summary>
		/// <param name="guest">Body of guest.</param>
		/// <returns>If added return true.</returns>
		public Response AddGuestRaw(Object guest)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddGuestRaw", guest);
		}

		///<summary>
		/// Update information in specified guest. 
		/// </summary>
		/// <param name="guest">Body of guest.</param>
		/// <returns>Return updated PrestaShopGuest.</returns>
		public Response EditGuestRaw(Object guest)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditGuestRaw", guest);
		}

		///<summary>
		/// Remove guest by identifier. 
		/// </summary>
		/// <param name="id">Identifier of guest.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteGuestRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteGuestRaw", id);
		}

		///<summary>
		/// Getting guest by identifier. 
		/// </summary>
		/// <param name="id">Identifier of guest.</param>
		/// <returns>Return PrestaShopGuest.</returns>
		public Response GetGuestRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetGuestRaw", id);
		}

		///<summary>
		/// Getting guests identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopGuest.</returns>
		public Response GetGuestsIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetGuestsIdentifiersRaw");
		}

		///<summary>
		/// Getting guests by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about guests use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Guest in PrestaShopGuest class.</returns>
		public Response GetGuestsByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetGuestsByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new image type. 
		/// </summary>
		/// <param name="imageType">Body of image type.</param>
		/// <returns>If added return true.</returns>
		public Response AddImageTypeRaw(Object imageType)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddImageTypeRaw", imageType);
		}

		///<summary>
		/// Update information in specified image type. 
		/// </summary>
		/// <param name="imageType">Body of image type.</param>
		/// <returns>Return updated PrestaShopImageType.</returns>
		public Response EditImageTypeRaw(Object imageType)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditImageTypeRaw", imageType);
		}

		///<summary>
		/// Remove image type by identifier. 
		/// </summary>
		/// <param name="id">Identifier of image type.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteImageTypeRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteImageTypeRaw", id);
		}

		///<summary>
		/// Getting image type by identifier. 
		/// </summary>
		/// <param name="id">Identifier of image type.</param>
		/// <returns>Return PrestaShopImageType.</returns>
		public Response GetImageTypeRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetImageTypeRaw", id);
		}

		///<summary>
		/// Getting image types identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopImageType.</returns>
		public Response GetImageTypesIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetImageTypesIdentifiersRaw");
		}

		///<summary>
		/// Getting image types by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about image types use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about ImageType in PrestaShopImageType class.</returns>
		public Response GetImageTypesByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetImageTypesByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new image. 
		/// </summary>
		/// <param name="image">Body of image.</param>
		/// <returns>If added return true.</returns>
		public Response AddImageRaw(Object image)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddImageRaw", image);
		}

		///<summary>
		/// Update information in specified image. 
		/// </summary>
		/// <param name="image">Body of image.</param>
		/// <returns>Return updated PrestaShopImage.</returns>
		public Response EditImageRaw(Object image)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditImageRaw", image);
		}

		///<summary>
		/// Remove image by identifier. 
		/// </summary>
		/// <param name="id">Identifier of image.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteImageRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteImageRaw", id);
		}

		///<summary>
		/// Getting image by identifier. 
		/// </summary>
		/// <param name="id">Identifier of image.</param>
		/// <returns>Return PrestaShopImage.</returns>
		public Response GetImageRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetImageRaw", id);
		}

		///<summary>
		/// Getting images identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopImage.</returns>
		public Response GetImagesIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetImagesIdentifiersRaw");
		}

		///<summary>
		/// Getting images by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about images use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Image in PrestaShopImage class.</returns>
		public Response GetImagesByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetImagesByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new language. 
		/// </summary>
		/// <param name="language">Body of language.</param>
		/// <returns>If added return true.</returns>
		public Response AddLanguageRaw(Object language)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddLanguageRaw", language);
		}

		///<summary>
		/// Update information in specified language. 
		/// </summary>
		/// <param name="language">Body of language.</param>
		/// <returns>Return updated PrestaShopLanguage.</returns>
		public Response EditLanguageRaw(Object language)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditLanguageRaw", language);
		}

		///<summary>
		/// Remove language by identifier. 
		/// </summary>
		/// <param name="id">Identifier of language.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteLanguageRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteLanguageRaw", id);
		}

		///<summary>
		/// Getting language by identifier. 
		/// </summary>
		/// <param name="id">Identifier of language.</param>
		/// <returns>Return PrestaShopLanguage.</returns>
		public Response GetLanguageRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetLanguageRaw", id);
		}

		///<summary>
		/// Getting languages identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopLanguage.</returns>
		public Response GetLanguagesIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetLanguagesIdentifiersRaw");
		}

		///<summary>
		/// Getting languages by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about languages use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Language in PrestaShopLanguage class.</returns>
		public Response GetLanguagesByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetLanguagesByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new manufacturer. 
		/// </summary>
		/// <param name="manufacturer">Body of manufacturer.</param>
		/// <returns>If added return true.</returns>
		public Response AddManufacturerRaw(Object manufacturer)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddManufacturerRaw", manufacturer);
		}

		///<summary>
		/// Update information in specified manufacturer. 
		/// </summary>
		/// <param name="manufacturer">Body of manufacturer.</param>
		/// <returns>Return updated PrestaShopManufacturer.</returns>
		public Response EditManufacturerRaw(Object manufacturer)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditManufacturerRaw", manufacturer);
		}

		///<summary>
		/// Remove manufacturer by identifier. 
		/// </summary>
		/// <param name="id">Identifier of manufacturer.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteManufacturerRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteManufacturerRaw", id);
		}

		///<summary>
		/// Getting manufacturer by identifier. 
		/// </summary>
		/// <param name="id">Identifier of manufacturer.</param>
		/// <returns>Return PrestaShopManufacturer.</returns>
		public Response GetManufacturerRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetManufacturerRaw", id);
		}

		///<summary>
		/// Getting manufacturers identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopManufacturer.</returns>
		public Response GetManufacturersIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetManufacturersIdentifiersRaw");
		}

		///<summary>
		/// Getting manufacturers by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about manufacturers use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Manufacturer in PrestaShopManufacturer class.</returns>
		public Response GetManufacturersByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetManufacturersByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new message. 
		/// </summary>
		/// <param name="message">Body of message.</param>
		/// <returns>If added return true.</returns>
		public Response AddMessageRaw(Object message)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddMessageRaw", message);
		}

		///<summary>
		/// Update information in specified message. 
		/// </summary>
		/// <param name="message">Body of message.</param>
		/// <returns>Return updated PrestaShopMessage.</returns>
		public Response EditMessageRaw(Object message)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditMessageRaw", message);
		}

		///<summary>
		/// Remove message by identifier. 
		/// </summary>
		/// <param name="id">Identifier of message.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteMessageRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteMessageRaw", id);
		}

		///<summary>
		/// Getting message by identifier. 
		/// </summary>
		/// <param name="id">Identifier of message.</param>
		/// <returns>Return PrestaShopMessage.</returns>
		public Response GetMessageRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetMessageRaw", id);
		}

		///<summary>
		/// Getting messages identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopMessage.</returns>
		public Response GetMessagesIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetMessagesIdentifiersRaw");
		}

		///<summary>
		/// Getting messages by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about messages use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Message in PrestaShopMessage class.</returns>
		public Response GetMessagesByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetMessagesByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new order carrier. 
		/// </summary>
		/// <param name="orderCarrier">Body of order carrier.</param>
		/// <returns>If added return true.</returns>
		public Response AddOrderCarrierRaw(Object orderCarrier)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddOrderCarrierRaw", orderCarrier);
		}

		///<summary>
		/// Update information in specified order carrier. 
		/// </summary>
		/// <param name="orderCarrier">Body of order carrier.</param>
		/// <returns>Return updated PrestaShopOrderCarrier.</returns>
		public Response EditOrderCarrierRaw(Object orderCarrier)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditOrderCarrierRaw", orderCarrier);
		}

		///<summary>
		/// Remove order carrier by identifier. 
		/// </summary>
		/// <param name="id">Identifier of order carrier.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteOrderCarrierRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteOrderCarrierRaw", id);
		}

		///<summary>
		/// Getting order carrier by identifier. 
		/// </summary>
		/// <param name="id">Identifier of order carrier.</param>
		/// <returns>Return PrestaShopOrderCarrier.</returns>
		public Response GetOrderCarrierRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetOrderCarrierRaw", id);
		}

		///<summary>
		/// Getting order carriers identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopOrderCarrier.</returns>
		public Response GetOrderCarriersIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetOrderCarriersIdentifiersRaw");
		}

		///<summary>
		/// Getting order carriers by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about order carriers use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about OrderCarrier in PrestaShopOrderCarrier class.</returns>
		public Response GetOrderCarriersByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetOrderCarriersByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Getting order detail by identifier. 
		/// </summary>
		/// <param name="id">Identifier of order detail.</param>
		/// <returns>Return PrestaShopOrderDetail.</returns>
		public Response GetOrderDetailRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetOrderDetailRaw", id);
		}

		///<summary>
		/// Getting order details identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopOrderDetail.</returns>
		public Response GetOrderDetailsIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetOrderDetailsIdentifiersRaw");
		}

		///<summary>
		/// Getting order details by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about order details use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about OrderDetail in PrestaShopOrderDetail class.</returns>
		public Response GetOrderDetailsByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetOrderDetailsByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Getting order history by identifier. 
		/// </summary>
		/// <param name="id">Identifier of order history.</param>
		/// <returns>Return PrestaShopOrderHistory.</returns>
		public Response GetOrderHistoryRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetOrderHistoryRaw", id);
		}

		///<summary>
		/// Getting order histories identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopOrderHistory.</returns>
		public Response GetOrderHistoriesIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetOrderHistoriesIdentifiersRaw");
		}

		///<summary>
		/// Getting order histories by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about order histories use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about OrderHistory in PrestaShopOrderHistory class.</returns>
		public Response GetOrderHistoriesByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetOrderHistoriesByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new order invoice. 
		/// </summary>
		/// <param name="orderInvoice">Body of order invoice.</param>
		/// <returns>If added return true.</returns>
		public Response AddOrderInvoiceRaw(Object orderInvoice)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddOrderInvoiceRaw", orderInvoice);
		}

		///<summary>
		/// Update information in specified order invoice. 
		/// </summary>
		/// <param name="orderInvoice">Body of order invoice.</param>
		/// <returns>Return updated PrestaShopOrderInvoice.</returns>
		public Response EditOrderInvoiceRaw(Object orderInvoice)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditOrderInvoiceRaw", orderInvoice);
		}

		///<summary>
		/// Remove order invoice by identifier. 
		/// </summary>
		/// <param name="id">Identifier of order invoice.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteOrderInvoiceRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteOrderInvoiceRaw", id);
		}

		///<summary>
		/// Getting order invoice by identifier. 
		/// </summary>
		/// <param name="id">Identifier of order invoice.</param>
		/// <returns>Return PrestaShopOrderInvoice.</returns>
		public Response GetOrderInvoiceRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetOrderInvoiceRaw", id);
		}

		///<summary>
		/// Getting order invoices identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopOrderInvoice.</returns>
		public Response GetOrderInvoicesIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetOrderInvoicesIdentifiersRaw");
		}

		///<summary>
		/// Getting order invoices by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about order invoices use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about OrderInvoice in PrestaShopOrderInvoice class.</returns>
		public Response GetOrderInvoicesByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetOrderInvoicesByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new order payment. 
		/// </summary>
		/// <param name="orderPayment">Body of order payment.</param>
		/// <returns>If added return true.</returns>
		public Response AddOrderPaymentRaw(Object orderPayment)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddOrderPaymentRaw", orderPayment);
		}

		///<summary>
		/// Update information in specified order payment. 
		/// </summary>
		/// <param name="orderPayment">Body of order payment.</param>
		/// <returns>Return updated PrestaShopOrderPayment.</returns>
		public Response EditOrderPaymentRaw(Object orderPayment)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditOrderPaymentRaw", orderPayment);
		}

		///<summary>
		/// Remove order payment by identifier. 
		/// </summary>
		/// <param name="id">Identifier of order payment.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteOrderPaymentRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteOrderPaymentRaw", id);
		}

		///<summary>
		/// Getting order payment by identifier. 
		/// </summary>
		/// <param name="id">Identifier of order payment.</param>
		/// <returns>Return PrestaShopOrderPayment.</returns>
		public Response GetOrderPaymentRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetOrderPaymentRaw", id);
		}

		///<summary>
		/// Getting order payments identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopOrderPayment.</returns>
		public Response GetOrderPaymentsIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetOrderPaymentsIdentifiersRaw");
		}

		///<summary>
		/// Getting configuration by identifier. 
		/// </summary>
		/// <param name="id">Identifier of configuration.</param>
		/// <returns>Return PrestaShopConfiguration.</returns>
		public Response GetConfigurationRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetConfigurationRaw", id);
		}

		///<summary>
		/// Getting configurations identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopConfiguration.</returns>
		public Response GetConfigurationsIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetConfigurationsIdentifiersRaw");
		}

		///<summary>
		/// Getting configurations by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about configurations use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Configuration in PrestaShopConfiguration class.</returns>
		public Response GetConfigurationsByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetConfigurationsByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new contact. 
		/// </summary>
		/// <param name="contact">Body of contact.</param>
		/// <returns>If added return true.</returns>
		public Response AddContactRaw(Object contact)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddContactRaw", contact);
		}

		///<summary>
		/// Update information in specified contact. 
		/// </summary>
		/// <param name="contact">Body of contact.</param>
		/// <returns>Return updated PrestaShopContact.</returns>
		public Response EditContactRaw(Object contact)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditContactRaw", contact);
		}

		///<summary>
		/// Remove contact by identifier. 
		/// </summary>
		/// <param name="id">Identifier of contact.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteContactRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteContactRaw", id);
		}

		///<summary>
		/// Getting contact by identifier. 
		/// </summary>
		/// <param name="id">Identifier of contact.</param>
		/// <returns>Return PrestaShopContact.</returns>
		public Response GetContactRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetContactRaw", id);
		}

		///<summary>
		/// Getting contacts identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopContact.</returns>
		public Response GetContactsIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetContactsIdentifiersRaw");
		}

		///<summary>
		/// Getting contacts by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about contacts use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Contact in PrestaShopContact class.</returns>
		public Response GetContactsByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetContactsByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new content management system. 
		/// </summary>
		/// <param name="contentManagementSystem">Body of content management system.</param>
		/// <returns>If added return true.</returns>
		public Response AddContentManagementSystemRaw(Object contentManagementSystem)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddContentManagementSystemRaw", contentManagementSystem);
		}

		///<summary>
		/// Update information in specified content management system. 
		/// </summary>
		/// <param name="contentManagementSystem">Body of content management system.</param>
		/// <returns>Return updated PrestaShopContentManagementSystem.</returns>
		public Response EditContentManagementSystemRaw(Object contentManagementSystem)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditContentManagementSystemRaw", contentManagementSystem);
		}

		///<summary>
		/// Remove content management system by identifier. 
		/// </summary>
		/// <param name="id">Identifier of content management system.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteContentManagementSystemRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteContentManagementSystemRaw", id);
		}

		///<summary>
		/// Getting content management system by identifier. 
		/// </summary>
		/// <param name="id">Identifier of content management system.</param>
		/// <returns>Return PrestaShopContentManagementSystem.</returns>
		public Response GetContentManagementSystemRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetContentManagementSystemRaw", id);
		}

		///<summary>
		/// Getting content management system identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopContentManagementSystem.</returns>
		public Response GetContentManagementSystemIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetContentManagementSystemIdentifiersRaw");
		}

		///<summary>
		/// Getting content management system by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about content management system use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about ContentManagementSystem in PrestaShopContentManagementSystem class.</returns>
		public Response GetContentManagementSystemByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetContentManagementSystemByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new country. 
		/// </summary>
		/// <param name="country">Body of country.</param>
		/// <returns>If added return true.</returns>
		public Response AddCountryRaw(Object country)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddCountryRaw", country);
		}

		///<summary>
		/// Update information in specified country. 
		/// </summary>
		/// <param name="country">Body of country.</param>
		/// <returns>Return updated PrestaShopCountry.</returns>
		public Response EditCountryRaw(Object country)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditCountryRaw", country);
		}

		///<summary>
		/// Remove country by identifier. 
		/// </summary>
		/// <param name="id">Identifier of country.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteCountryRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteCountryRaw", id);
		}

		///<summary>
		/// Getting country by identifier. 
		/// </summary>
		/// <param name="id">Identifier of country.</param>
		/// <returns>Return PrestaShopCountry.</returns>
		public Response GetCountryRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCountryRaw", id);
		}

		///<summary>
		/// Getting countries identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopCountry.</returns>
		public Response GetCountriesIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCountriesIdentifiersRaw");
		}

		///<summary>
		/// Getting countries by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about countries use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Country in PrestaShopCountry class.</returns>
		public Response GetCountriesByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCountriesByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new currency. 
		/// </summary>
		/// <param name="currency">Body of currency.</param>
		/// <returns>If added return true.</returns>
		public Response AddCurrencyRaw(Object currency)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddCurrencyRaw", currency);
		}

		///<summary>
		/// Update information in specified currency. 
		/// </summary>
		/// <param name="currency">Body of currency.</param>
		/// <returns>Return updated PrestaShopCurrency.</returns>
		public Response EditCurrencyRaw(Object currency)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditCurrencyRaw", currency);
		}

		///<summary>
		/// Remove currency by identifier. 
		/// </summary>
		/// <param name="id">Identifier of currency.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteCurrencyRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteCurrencyRaw", id);
		}

		///<summary>
		/// Getting currency by identifier. 
		/// </summary>
		/// <param name="id">Identifier of currency.</param>
		/// <returns>Return PrestaShopCurrency.</returns>
		public Response GetCurrencyRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCurrencyRaw", id);
		}

		///<summary>
		/// Getting currencies identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopCurrency.</returns>
		public Response GetCurrenciesIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCurrenciesIdentifiersRaw");
		}

		///<summary>
		/// Getting currencies by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about currencies use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Currency in PrestaShopCurrency class.</returns>
		public Response GetCurrenciesByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCurrenciesByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new customer message. 
		/// </summary>
		/// <param name="customerMessage">Body of customer message.</param>
		/// <returns>If added return true.</returns>
		public Response AddCustomerMessageRaw(Object customerMessage)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddCustomerMessageRaw", customerMessage);
		}

		///<summary>
		/// Update information in specified customer message. 
		/// </summary>
		/// <param name="customerMessage">Body of customer message.</param>
		/// <returns>Return updated PrestaShopCustomerMessage.</returns>
		public Response EditCustomerMessageRaw(Object customerMessage)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditCustomerMessageRaw", customerMessage);
		}

		///<summary>
		/// Remove customer message by identifier. 
		/// </summary>
		/// <param name="id">Identifier of customer message.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteCustomerMessageRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteCustomerMessageRaw", id);
		}

		///<summary>
		/// Getting customer message by identifier. 
		/// </summary>
		/// <param name="id">Identifier of customer message.</param>
		/// <returns>Return PrestaShopCustomerMessage.</returns>
		public Response GetCustomerMessageRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCustomerMessageRaw", id);
		}

		///<summary>
		/// Getting customer messages identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopCustomerMessage.</returns>
		public Response GetCustomerMessagesIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCustomerMessagesIdentifiersRaw");
		}

		///<summary>
		/// Getting customer messages by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about customer messages use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about CustomerMessage in PrestaShopCustomerMessage class.</returns>
		public Response GetCustomerMessagesByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCustomerMessagesByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new customer thread. 
		/// </summary>
		/// <param name="customerThread">Body of customer thread.</param>
		/// <returns>If added return true.</returns>
		public Response AddCustomerThreadRaw(Object customerThread)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddCustomerThreadRaw", customerThread);
		}

		///<summary>
		/// Update information in specified customer thread. 
		/// </summary>
		/// <param name="customerThread">Body of customer thread.</param>
		/// <returns>Return updated PrestaShopCustomerThread.</returns>
		public Response EditCustomerThreadRaw(Object customerThread)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditCustomerThreadRaw", customerThread);
		}

		///<summary>
		/// Remove customer thread by identifier. 
		/// </summary>
		/// <param name="id">Identifier of customer thread.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteCustomerThreadRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteCustomerThreadRaw", id);
		}

		///<summary>
		/// Getting customer thread by identifier. 
		/// </summary>
		/// <param name="id">Identifier of customer thread.</param>
		/// <returns>Return PrestaShopCustomerThread.</returns>
		public Response GetCustomerThreadRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCustomerThreadRaw", id);
		}

		///<summary>
		/// Getting customer threads identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopCustomerThread.</returns>
		public Response GetCustomerThreadsIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCustomerThreadsIdentifiersRaw");
		}

		///<summary>
		/// Getting customer threads by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about customer threads use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about CustomerThread in PrestaShopCustomerThread class.</returns>
		public Response GetCustomerThreadsByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCustomerThreadsByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new customer. 
		/// </summary>
		/// <param name="customer">Body of customer.</param>
		/// <returns>If added return true.</returns>
		public Response AddCustomerRaw(Object customer)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddCustomerRaw", customer);
		}

		///<summary>
		/// Update information in specified customer. 
		/// </summary>
		/// <param name="customer">Body of customer.</param>
		/// <returns>Return updated PrestaShopCustomer.</returns>
		public Response EditCustomerRaw(Object customer)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditCustomerRaw", customer);
		}

		///<summary>
		/// Remove customer by identifier. 
		/// </summary>
		/// <param name="id">Identifier of customer.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteCustomerRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteCustomerRaw", id);
		}

		///<summary>
		/// Getting customer by identifier. 
		/// </summary>
		/// <param name="id">Identifier of customer.</param>
		/// <returns>Return PrestaShopCustomer.</returns>
		public Response GetCustomerRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCustomerRaw", id);
		}

		///<summary>
		/// Getting customers identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopCustomer.</returns>
		public Response GetCustomersIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCustomersIdentifiersRaw");
		}

		///<summary>
		/// Getting customers by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about customers use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Customer in PrestaShopCustomer class.</returns>
		public Response GetCustomersByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCustomersByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new customization. 
		/// </summary>
		/// <param name="customization">Body of customization.</param>
		/// <returns>If added return true.</returns>
		public Response AddCustomizationRaw(Object customization)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddCustomizationRaw", customization);
		}

		///<summary>
		/// Update information in specified customization. 
		/// </summary>
		/// <param name="customization">Body of customization.</param>
		/// <returns>Return updated PrestaShopCustomization.</returns>
		public Response EditCustomizationRaw(Object customization)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditCustomizationRaw", customization);
		}

		///<summary>
		/// Remove customization by identifier. 
		/// </summary>
		/// <param name="id">Identifier of customization.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteCustomizationRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteCustomizationRaw", id);
		}

		///<summary>
		/// Getting customization by identifier. 
		/// </summary>
		/// <param name="id">Identifier of customization.</param>
		/// <returns>Return PrestaShopCustomization.</returns>
		public Response GetCustomizationRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCustomizationRaw", id);
		}

		///<summary>
		/// Getting customizations identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopCustomization.</returns>
		public Response GetCustomizationsIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCustomizationsIdentifiersRaw");
		}

		///<summary>
		/// Getting customizations by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about customizations use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Customization in PrestaShopCustomization class.</returns>
		public Response GetCustomizationsByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCustomizationsByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new delivery. 
		/// </summary>
		/// <param name="delivery">Body of delivery.</param>
		/// <returns>If added return true.</returns>
		public Response AddDeliveryRaw(Object delivery)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddDeliveryRaw", delivery);
		}

		///<summary>
		/// Update information in specified delivery. 
		/// </summary>
		/// <param name="delivery">Body of delivery.</param>
		/// <returns>Return updated PrestaShopDelivery.</returns>
		public Response EditDeliveryRaw(Object delivery)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditDeliveryRaw", delivery);
		}

		///<summary>
		/// Remove delivery by identifier. 
		/// </summary>
		/// <param name="id">Identifier of delivery.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteDeliveryRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteDeliveryRaw", id);
		}

		///<summary>
		/// Getting delivery by identifier. 
		/// </summary>
		/// <param name="id">Identifier of delivery.</param>
		/// <returns>Return PrestaShopDelivery.</returns>
		public Response GetDeliveryRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetDeliveryRaw", id);
		}

		///<summary>
		/// Getting deliveries identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopDelivery.</returns>
		public Response GetDeliveriesIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetDeliveriesIdentifiersRaw");
		}

		///<summary>
		/// Getting deliveries by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about deliveries use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Delivery in PrestaShopDelivery class.</returns>
		public Response GetDeliveriesByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetDeliveriesByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new employee. 
		/// </summary>
		/// <param name="employee">Body of employee.</param>
		/// <returns>If added return true.</returns>
		public Response AddEmployeeRaw(Object employee)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddEmployeeRaw", employee);
		}

		///<summary>
		/// Update information in specified employee. 
		/// </summary>
		/// <param name="employee">Body of employee.</param>
		/// <returns>Return updated PrestaShopEmployee.</returns>
		public Response EditEmployeeRaw(Object employee)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditEmployeeRaw", employee);
		}

		///<summary>
		/// Remove employee by identifier. 
		/// </summary>
		/// <param name="id">Identifier of employee.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteEmployeeRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteEmployeeRaw", id);
		}

		///<summary>
		/// Getting employee by identifier. 
		/// </summary>
		/// <param name="id">Identifier of employee.</param>
		/// <returns>Return PrestaShopEmployee.</returns>
		public Response GetEmployeeRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetEmployeeRaw", id);
		}

		///<summary>
		/// Getting employees identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopEmployee.</returns>
		public Response GetEmployeesIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetEmployeesIdentifiersRaw");
		}

		///<summary>
		/// Getting employees by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about employees use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Employee in PrestaShopEmployee class.</returns>
		public Response GetEmployeesByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetEmployeesByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new group. 
		/// </summary>
		/// <param name="group">Body of group.</param>
		/// <returns>If added return true.</returns>
		public Response AddGroupRaw(Object group)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddGroupRaw", group);
		}

		///<summary>
		/// Remove tax by identifier. 
		/// </summary>
		/// <param name="id">Identifier of tax.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteTax(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteTax", id);
		}

		///<summary>
		/// Getting tax by identifier. 
		/// </summary>
		/// <param name="id">Identifier of tax.</param>
		/// <returns>Return PrestaShopTax.</returns>
		public PrestaShopTax GetTax(Int32 id)
		{
			return bNesisApi.Call<PrestaShopTax>("PrestaShop", bNesisToken, "GetTax", id);
		}

		///<summary>
		/// Getting taxes by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about taxes use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Tax in PrestaShopTax class.</returns>
		public PrestaShopTax[] GetTaxesByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopTax[]>("PrestaShop", bNesisToken, "GetTaxesByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting taxes identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopTax.</returns>
		public PrestaShopIdentifier[] GetTaxesIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetTaxesIdentifiers");
		}

		///<summary>
		/// Adding new translated configuration. 
		/// </summary>
		/// <param name="translatedConfiguration">Body of translated configuration.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddTranslatedConfiguration(PrestaShopTranslatedConfigurationIn translatedConfiguration)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddTranslatedConfiguration", translatedConfiguration);
		}

		///<summary>
		/// Update information in specified translated configuration. 
		/// </summary>
		/// <param name="translatedConfiguration">Body of translated configuration.</param>
		/// <returns>Return updated PrestaShopTranslatedConfiguration.</returns>
		public PrestaShopTranslatedConfiguration EditTranslatedConfiguration(PrestaShopTranslatedConfiguration translatedConfiguration)
		{
			return bNesisApi.Call<PrestaShopTranslatedConfiguration>("PrestaShop", bNesisToken, "EditTranslatedConfiguration", translatedConfiguration);
		}

		///<summary>
		/// Remove translated configuration by identifier. 
		/// </summary>
		/// <param name="id">Identifier of translated configuration.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteTranslatedConfiguration(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteTranslatedConfiguration", id);
		}

		///<summary>
		/// Getting translated configuration by identifier. 
		/// </summary>
		/// <param name="id">Identifier of translated configuration.</param>
		/// <returns>Return PrestaShopTranslatedConfiguration.</returns>
		public PrestaShopTranslatedConfiguration GetTranslatedConfiguration(Int32 id)
		{
			return bNesisApi.Call<PrestaShopTranslatedConfiguration>("PrestaShop", bNesisToken, "GetTranslatedConfiguration", id);
		}

		///<summary>
		/// Getting translated configurations by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about translated configurations use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about TranslatedConfiguration in PrestaShopTranslatedConfiguration class.</returns>
		public PrestaShopTranslatedConfiguration[] GetTranslatedConfigurationsByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopTranslatedConfiguration[]>("PrestaShop", bNesisToken, "GetTranslatedConfigurationsByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting translated configurations identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopTranslatedConfiguration.</returns>
		public PrestaShopIdentifier[] GetTranslatedConfigurationsIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetTranslatedConfigurationsIdentifiers");
		}

		///<summary>
		/// Getting warehouse product location by identifier. 
		/// </summary>
		/// <param name="id">Identifier of warehouse product location.</param>
		/// <returns>Return PrestaShopWarehouseProductLocation.</returns>
		public PrestaShopWarehouseProductLocation GetWarehouseProductLocation(Int32 id)
		{
			return bNesisApi.Call<PrestaShopWarehouseProductLocation>("PrestaShop", bNesisToken, "GetWarehouseProductLocation", id);
		}

		///<summary>
		/// Getting warehouse product locations by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about warehouse product locations use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about WarehouseProductLocation in PrestaShopWarehouseProductLocation class.</returns>
		public PrestaShopWarehouseProductLocation[] GetWarehouseProductLocationsByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopWarehouseProductLocation[]>("PrestaShop", bNesisToken, "GetWarehouseProductLocationsByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting warehouse product locations identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopWarehouseProductLocation.</returns>
		public PrestaShopIdentifier[] GetWarehouseProductLocationsIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetWarehouseProductLocationsIdentifiers");
		}

		///<summary>
		/// Adding new weight range. 
		/// </summary>
		/// <param name="weightRange">Body of weight range.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddWeightRange(PrestaShopWeightRangeIn weightRange)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddWeightRange", weightRange);
		}

		///<summary>
		/// Update information in specified weight range. 
		/// </summary>
		/// <param name="weightRange">Body of weight range.</param>
		/// <returns>Return updated PrestaShopWeightRange.</returns>
		public PrestaShopWeightRange EditWeightRange(PrestaShopWeightRange weightRange)
		{
			return bNesisApi.Call<PrestaShopWeightRange>("PrestaShop", bNesisToken, "EditWeightRange", weightRange);
		}

		///<summary>
		/// Remove weight range by identifier. 
		/// </summary>
		/// <param name="id">Identifier of weight range.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteWeightRange(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteWeightRange", id);
		}

		///<summary>
		/// Getting weight range by identifier. 
		/// </summary>
		/// <param name="id">Identifier of weight range.</param>
		/// <returns>Return PrestaShopWeightRange.</returns>
		public PrestaShopWeightRange GetWeightRange(Int32 id)
		{
			return bNesisApi.Call<PrestaShopWeightRange>("PrestaShop", bNesisToken, "GetWeightRange", id);
		}

		///<summary>
		/// Getting weight ranges by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about weight ranges use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about WeightRange in PrestaShopWeightRange class.</returns>
		public PrestaShopWeightRange[] GetWeightRangesByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopWeightRange[]>("PrestaShop", bNesisToken, "GetWeightRangesByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting weight ranges identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopWeightRange.</returns>
		public PrestaShopIdentifier[] GetWeightRangesIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetWeightRangesIdentifiers");
		}

		///<summary>
		/// Adding new zone. 
		/// </summary>
		/// <param name="zone">Body of zone.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddZone(PrestaShopZoneIn zone)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddZone", zone);
		}

		///<summary>
		/// Update information in specified zone. 
		/// </summary>
		/// <param name="zone">Body of zone.</param>
		/// <returns>Return updated PrestaShopZone.</returns>
		public PrestaShopZone EditZone(PrestaShopZone zone)
		{
			return bNesisApi.Call<PrestaShopZone>("PrestaShop", bNesisToken, "EditZone", zone);
		}

		///<summary>
		/// Remove zone by identifier. 
		/// </summary>
		/// <param name="id">Identifier of zone.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteZone(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteZone", id);
		}

		///<summary>
		/// Getting zone by identifier. 
		/// </summary>
		/// <param name="id">Identifier of zone.</param>
		/// <returns>Return PrestaShopZone.</returns>
		public PrestaShopZone GetZone(Int32 id)
		{
			return bNesisApi.Call<PrestaShopZone>("PrestaShop", bNesisToken, "GetZone", id);
		}

		///<summary>
		/// Getting zones by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about zones use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Zone in PrestaShopZone class.</returns>
		public PrestaShopZone[] GetZonesByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopZone[]>("PrestaShop", bNesisToken, "GetZonesByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting zones identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopZone.</returns>
		public PrestaShopIdentifier[] GetZonesIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetZonesIdentifiers");
		}

		///<summary>
		/// Adding new address. 
		/// </summary>
		/// <param name="address">Body of address.</param>
		/// <returns>If added return true.</returns>
		public Response AddAddressRaw(Object address)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddAddressRaw", address);
		}

		///<summary>
		/// Update information in specified address. 
		/// </summary>
		/// <param name="address">Body of address.</param>
		/// <returns>Return updated PrestaShopAddress.</returns>
		public Response EditAddressRaw(Object address)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditAddressRaw", address);
		}

		///<summary>
		/// Remove address by identifier. 
		/// </summary>
		/// <param name="id">Identifier of address.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteAddressRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteAddressRaw", id);
		}

		///<summary>
		/// Getting address by identifier. 
		/// </summary>
		/// <param name="id">Identifier of address.</param>
		/// <returns>Return PrestaShopAddress.</returns>
		public Response GetAddressRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetAddressRaw", id);
		}

		///<summary>
		/// Getting addresses identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopAddress.</returns>
		public Response GetAddressesIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetAddressesIdentifiersRaw");
		}

		///<summary>
		/// Getting addresses by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about addresses use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Address in PrestaShopAddress class.</returns>
		public Response GetAddressesByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetAddressesByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new carrier. 
		/// </summary>
		/// <param name="carrier">Body of carrier.</param>
		/// <returns>If added return true.</returns>
		public Response AddCarrierRaw(Object carrier)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddCarrierRaw", carrier);
		}

		///<summary>
		/// Update information in specified carrier. 
		/// </summary>
		/// <param name="carrier">Body of carrier.</param>
		/// <returns>Return updated PrestaShopCarrier.</returns>
		public Response EditCarrierRaw(Object carrier)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditCarrierRaw", carrier);
		}

		///<summary>
		/// Remove carrier by identifier. 
		/// </summary>
		/// <param name="id">Identifier of carrier.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteCarrierRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteCarrierRaw", id);
		}

		///<summary>
		/// Getting carrier by identifier. 
		/// </summary>
		/// <param name="id">Identifier of carrier.</param>
		/// <returns>Return PrestaShopCarrier.</returns>
		public Response GetCarrierRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCarrierRaw", id);
		}

		///<summary>
		/// Getting carriers identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopCarrier.</returns>
		public Response GetCarriersIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCarriersIdentifiersRaw");
		}

		///<summary>
		/// Getting carriers by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about carriers use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Carrier in PrestaShopCarrier class.</returns>
		public Response GetCarriersByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCarriersByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new cart rule. 
		/// </summary>
		/// <param name="cartRule">Body of cart rule.</param>
		/// <returns>If added return true.</returns>
		public Response AddCartRuleRaw(Object cartRule)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddCartRuleRaw", cartRule);
		}

		///<summary>
		/// Update information in specified cart rule. 
		/// </summary>
		/// <param name="cartRule">Body of cart rule.</param>
		/// <returns>Return updated PrestaShopCartRule.</returns>
		public Response EditCartRuleRaw(Object cartRule)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditCartRuleRaw", cartRule);
		}

		///<summary>
		/// Remove cart rule by identifier. 
		/// </summary>
		/// <param name="id">Identifier of cart rule.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteCartRuleRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteCartRuleRaw", id);
		}

		///<summary>
		/// Getting cart rule by identifier. 
		/// </summary>
		/// <param name="id">Identifier of cart rule.</param>
		/// <returns>Return PrestaShopCartRule.</returns>
		public Response GetCartRuleRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCartRuleRaw", id);
		}

		///<summary>
		/// Getting cart rules identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopCartRule.</returns>
		public Response GetCartRulesIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCartRulesIdentifiersRaw");
		}

		///<summary>
		/// Getting cart rules by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about cart rules use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about CartRule in PrestaShopCartRule class.</returns>
		public Response GetCartRulesByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCartRulesByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new cart. 
		/// </summary>
		/// <param name="cart">Body of cart.</param>
		/// <returns>If added return true.</returns>
		public Response AddCartRaw(Object cart)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddCartRaw", cart);
		}

		///<summary>
		/// Update information in specified cart. 
		/// </summary>
		/// <param name="cart">Body of cart.</param>
		/// <returns>Return updated PrestaShopCart.</returns>
		public Response EditCartRaw(Object cart)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditCartRaw", cart);
		}

		///<summary>
		/// Remove cart by identifier. 
		/// </summary>
		/// <param name="id">Identifier of cart.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteCartRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteCartRaw", id);
		}

		///<summary>
		/// Getting cart by identifier. 
		/// </summary>
		/// <param name="id">Identifier of cart.</param>
		/// <returns>Return PrestaShopCart.</returns>
		public Response GetCartRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCartRaw", id);
		}

		///<summary>
		/// Getting carts identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopCart.</returns>
		public Response GetCartsIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCartsIdentifiersRaw");
		}

		///<summary>
		/// Getting carts by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about carts use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Cart in PrestaShopCart class.</returns>
		public Response GetCartsByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCartsByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new category. 
		/// </summary>
		/// <param name="category">Body of category.</param>
		/// <returns>If added return true.</returns>
		public Response AddCategoryRaw(Object category)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddCategoryRaw", category);
		}

		///<summary>
		/// Update information in specified category. 
		/// </summary>
		/// <param name="category">Body of category.</param>
		/// <returns>Return updated PrestaShopCategory.</returns>
		public Response EditCategoryRaw(Object category)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditCategoryRaw", category);
		}

		///<summary>
		/// Remove category by identifier. 
		/// </summary>
		/// <param name="id">Identifier of category.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteCategoryRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteCategoryRaw", id);
		}

		///<summary>
		/// Getting category by identifier. 
		/// </summary>
		/// <param name="id">Identifier of category.</param>
		/// <returns>Return PrestaShopCategory.</returns>
		public Response GetCategoryRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCategoryRaw", id);
		}

		///<summary>
		/// Getting categories identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopCategory.</returns>
		public Response GetCategoriesIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCategoriesIdentifiersRaw");
		}

		///<summary>
		/// Getting categories by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about categories use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Category in PrestaShopCategory class.</returns>
		public Response GetCategoriesByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCategoriesByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new combination. 
		/// </summary>
		/// <param name="combination">Body of combination.</param>
		/// <returns>If added return true.</returns>
		public Response AddCombinationRaw(Object combination)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddCombinationRaw", combination);
		}

		///<summary>
		/// Update information in specified combination. 
		/// </summary>
		/// <param name="combination">Body of combination.</param>
		/// <returns>Return updated PrestaShopCombination.</returns>
		public Response EditCombinationRaw(Object combination)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditCombinationRaw", combination);
		}

		///<summary>
		/// Remove combination by identifier. 
		/// </summary>
		/// <param name="id">Identifier of combination.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteCombinationRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteCombinationRaw", id);
		}

		///<summary>
		/// Getting combination by identifier. 
		/// </summary>
		/// <param name="id">Identifier of combination.</param>
		/// <returns>Return PrestaShopCombination.</returns>
		public Response GetCombinationRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCombinationRaw", id);
		}

		///<summary>
		/// Getting combinations identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopCombination.</returns>
		public Response GetCombinationsIdentifiersRaw()
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCombinationsIdentifiersRaw");
		}

		///<summary>
		/// Getting combinations by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about combinations use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Combination in PrestaShopCombination class.</returns>
		public Response GetCombinationsByRenderingOptionsRaw(Object renderingOptions)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "GetCombinationsByRenderingOptionsRaw", renderingOptions);
		}

		///<summary>
		/// Adding new configuration. 
		/// </summary>
		/// <param name="configuration">Body of configuration.</param>
		/// <returns>If added return true.</returns>
		public Response AddConfigurationRaw(Object configuration)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "AddConfigurationRaw", configuration);
		}

		///<summary>
		/// Update information in specified configuration. 
		/// </summary>
		/// <param name="configuration">Body of configuration.</param>
		/// <returns>Return updated PrestaShopConfiguration.</returns>
		public Response EditConfigurationRaw(Object configuration)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "EditConfigurationRaw", configuration);
		}

		///<summary>
		/// Remove configuration by identifier. 
		/// </summary>
		/// <param name="id">Identifier of configuration.</param>
		/// <returns>If removed return true.</returns>
		public Response DeleteConfigurationRaw(Int32 id)
		{
			return bNesisApi.Call<Response>("PrestaShop", bNesisToken, "DeleteConfigurationRaw", id);
		}

		///<summary>
		/// Getting specific prices by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about specific prices use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about SpecificPrice in PrestaShopSpecificPrice class.</returns>
		public PrestaShopSpecificPrice[] GetSpecificPricesByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopSpecificPrice[]>("PrestaShop", bNesisToken, "GetSpecificPricesByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting specific prices identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopSpecificPrice.</returns>
		public PrestaShopIdentifier[] GetSpecificPricesIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetSpecificPricesIdentifiers");
		}

		///<summary>
		/// Getting state by identifier. 
		/// </summary>
		/// <param name="id">Identifier of state.</param>
		/// <returns>Return PrestaShopState.</returns>
		public PrestaShopState GetState(Int32 id)
		{
			return bNesisApi.Call<PrestaShopState>("PrestaShop", bNesisToken, "GetState", id);
		}

		///<summary>
		/// Getting states by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about states use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about State in PrestaShopState class.</returns>
		public PrestaShopState[] GetStatesByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopState[]>("PrestaShop", bNesisToken, "GetStatesByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting states identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopState.</returns>
		public PrestaShopIdentifier[] GetStatesIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetStatesIdentifiers");
		}

		///<summary>
		/// Adding new stock movement reason. 
		/// </summary>
		/// <param name="stockMovementReason">Body of stock movement reason.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddStockMovementReason(PrestaShopStockMovementReasonIn stockMovementReason)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddStockMovementReason", stockMovementReason);
		}

		///<summary>
		/// Update information in specified stock movement reason. 
		/// </summary>
		/// <param name="stockMovementReason">Body of stock movement reason.</param>
		/// <returns>Return updated PrestaShopStockMovementReason.</returns>
		public PrestaShopStockMovementReason EditStockMovementReason(PrestaShopStockMovementReason stockMovementReason)
		{
			return bNesisApi.Call<PrestaShopStockMovementReason>("PrestaShop", bNesisToken, "EditStockMovementReason", stockMovementReason);
		}

		///<summary>
		/// Remove stock movement reason by identifier. 
		/// </summary>
		/// <param name="id">Identifier of stock movement reason.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteStockMovementReason(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteStockMovementReason", id);
		}

		///<summary>
		/// Getting stock movement reason by identifier. 
		/// </summary>
		/// <param name="id">Identifier of stock movement reason.</param>
		/// <returns>Return PrestaShopStockMovementReason.</returns>
		public PrestaShopStockMovementReason GetStockMovementReason(Int32 id)
		{
			return bNesisApi.Call<PrestaShopStockMovementReason>("PrestaShop", bNesisToken, "GetStockMovementReason", id);
		}

		///<summary>
		/// Getting stock movement reasons by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about stock movement reasons use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about StockMovementReason in PrestaShopStockMovementReason class.</returns>
		public PrestaShopStockMovementReason[] GetStockMovementReasonsByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopStockMovementReason[]>("PrestaShop", bNesisToken, "GetStockMovementReasonsByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting stock movement reasons identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopStockMovementReason.</returns>
		public PrestaShopIdentifier[] GetStockMovementReasonsIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetStockMovementReasonsIdentifiers");
		}

		///<summary>
		/// Getting stock movement by identifier. 
		/// </summary>
		/// <param name="id">Identifier of stock movement.</param>
		/// <returns>Return PrestaShopStockMovement.</returns>
		public PrestaShopStockMovement GetStockMovement(Int32 id)
		{
			return bNesisApi.Call<PrestaShopStockMovement>("PrestaShop", bNesisToken, "GetStockMovement", id);
		}

		///<summary>
		/// Getting stock movements by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about stock movements use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about StockMovement in PrestaShopStockMovement class.</returns>
		public PrestaShopStockMovement[] GetStockMovementsByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopStockMovement[]>("PrestaShop", bNesisToken, "GetStockMovementsByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting stock movements identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopStockMovement.</returns>
		public PrestaShopIdentifier[] GetStockMovementsIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetStockMovementsIdentifiers");
		}

		///<summary>
		/// Getting stock by identifier. 
		/// </summary>
		/// <param name="id">Identifier of stock.</param>
		/// <returns>Return PrestaShopStock.</returns>
		public PrestaShopStock GetStock(Int32 id)
		{
			return bNesisApi.Call<PrestaShopStock>("PrestaShop", bNesisToken, "GetStock", id);
		}

		///<summary>
		/// Getting stocks by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about stocks use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Stock in PrestaShopStock class.</returns>
		public PrestaShopStock[] GetStocksByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopStock[]>("PrestaShop", bNesisToken, "GetStocksByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting stocks identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopStock.</returns>
		public PrestaShopIdentifier[] GetStocksIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetStocksIdentifiers");
		}

		///<summary>
		/// Adding new store. 
		/// </summary>
		/// <param name="store">Body of store.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddStore(PrestaShopStoreIn store)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddStore", store);
		}

		///<summary>
		/// Update information in specified store. 
		/// </summary>
		/// <param name="store">Body of store.</param>
		/// <returns>Return updated PrestaShopStore.</returns>
		public PrestaShopStore EditStore(PrestaShopStore store)
		{
			return bNesisApi.Call<PrestaShopStore>("PrestaShop", bNesisToken, "EditStore", store);
		}

		///<summary>
		/// Remove store by identifier. 
		/// </summary>
		/// <param name="id">Identifier of store.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteStore(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteStore", id);
		}

		///<summary>
		/// Getting store by identifier. 
		/// </summary>
		/// <param name="id">Identifier of store.</param>
		/// <returns>Return PrestaShopStore.</returns>
		public PrestaShopStore GetStore(Int32 id)
		{
			return bNesisApi.Call<PrestaShopStore>("PrestaShop", bNesisToken, "GetStore", id);
		}

		///<summary>
		/// Getting stores by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about stores use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Store in PrestaShopStore class.</returns>
		public PrestaShopStore[] GetStoresByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopStore[]>("PrestaShop", bNesisToken, "GetStoresByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting stores identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopStore.</returns>
		public PrestaShopIdentifier[] GetStoresIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetStoresIdentifiers");
		}

		///<summary>
		/// Adding new supplier. 
		/// </summary>
		/// <param name="supplier">Body of supplier.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddSupplier(PrestaShopSupplierIn supplier)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddSupplier", supplier);
		}

		///<summary>
		/// Update information in specified supplier. 
		/// </summary>
		/// <param name="supplier">Body of supplier.</param>
		/// <returns>Return updated PrestaShopSupplier.</returns>
		public PrestaShopSupplier EditSupplier(PrestaShopSupplier supplier)
		{
			return bNesisApi.Call<PrestaShopSupplier>("PrestaShop", bNesisToken, "EditSupplier", supplier);
		}

		///<summary>
		/// Remove supplier by identifier. 
		/// </summary>
		/// <param name="id">Identifier of supplier.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteSupplier(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteSupplier", id);
		}

		///<summary>
		/// Getting supplier by identifier. 
		/// </summary>
		/// <param name="id">Identifier of supplier.</param>
		/// <returns>Return PrestaShopSupplier.</returns>
		public PrestaShopSupplier GetSupplier(Int32 id)
		{
			return bNesisApi.Call<PrestaShopSupplier>("PrestaShop", bNesisToken, "GetSupplier", id);
		}

		///<summary>
		/// Getting suppliers by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about suppliers use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Supplier in PrestaShopSupplier class.</returns>
		public PrestaShopSupplier[] GetSuppliersByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopSupplier[]>("PrestaShop", bNesisToken, "GetSuppliersByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting suppliers identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopSupplier.</returns>
		public PrestaShopIdentifier[] GetSuppliersIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetSuppliersIdentifiers");
		}

		///<summary>
		/// Getting supply order detail by identifier. 
		/// </summary>
		/// <param name="id">Identifier of supply order detail.</param>
		/// <returns>Return PrestaShopSupplyOrderDetail.</returns>
		public PrestaShopSupplyOrderDetail GetSupplyOrderDetail(Int32 id)
		{
			return bNesisApi.Call<PrestaShopSupplyOrderDetail>("PrestaShop", bNesisToken, "GetSupplyOrderDetail", id);
		}

		///<summary>
		/// Getting supply order details by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about supply order details use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about SupplyOrderDetail in PrestaShopSupplyOrderDetail class.</returns>
		public PrestaShopSupplyOrderDetail[] GetSupplyOrderDetailsByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopSupplyOrderDetail[]>("PrestaShop", bNesisToken, "GetSupplyOrderDetailsByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting supply order details identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopSupplyOrderDetail.</returns>
		public PrestaShopIdentifier[] GetSupplyOrderDetailsIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetSupplyOrderDetailsIdentifiers");
		}

		///<summary>
		/// Getting supply order history by identifier. 
		/// </summary>
		/// <param name="id">Identifier of supply order history.</param>
		/// <returns>Return PrestaShopSupplyOrderHistory.</returns>
		public PrestaShopSupplyOrderHistory GetSupplyOrderHistory(Int32 id)
		{
			return bNesisApi.Call<PrestaShopSupplyOrderHistory>("PrestaShop", bNesisToken, "GetSupplyOrderHistory", id);
		}

		///<summary>
		/// Getting supply order histories by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about supply order histories use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about SupplyOrderHistory in PrestaShopSupplyOrderHistory class.</returns>
		public PrestaShopSupplyOrderHistory[] GetSupplyOrderHistoriesByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopSupplyOrderHistory[]>("PrestaShop", bNesisToken, "GetSupplyOrderHistoriesByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting supply order histories identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopSupplyOrderHistory.</returns>
		public PrestaShopIdentifier[] GetSupplyOrderHistoriesIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetSupplyOrderHistoriesIdentifiers");
		}

		///<summary>
		/// Getting supply order receipt history by identifier. 
		/// </summary>
		/// <param name="id">Identifier of supply order receipt history.</param>
		/// <returns>Return PrestaShopSupplyOrderReceiptHistory.</returns>
		public PrestaShopSupplyOrderReceiptHistory GetSupplyOrderReceiptHistory(Int32 id)
		{
			return bNesisApi.Call<PrestaShopSupplyOrderReceiptHistory>("PrestaShop", bNesisToken, "GetSupplyOrderReceiptHistory", id);
		}

		///<summary>
		/// Getting supply order receipt histories by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about supply order receipt histories use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about SupplyOrderReceiptHistory in PrestaShopSupplyOrderReceiptHistory class.</returns>
		public PrestaShopSupplyOrderReceiptHistory[] GetSupplyOrderReceiptHistoriesByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopSupplyOrderReceiptHistory[]>("PrestaShop", bNesisToken, "GetSupplyOrderReceiptHistoriesByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting supply order receipt histories identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopSupplyOrderReceiptHistory.</returns>
		public PrestaShopIdentifier[] GetSupplyOrderReceiptHistoriesIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetSupplyOrderReceiptHistoriesIdentifiers");
		}

		///<summary>
		/// Getting supply order state by identifier. 
		/// </summary>
		/// <param name="id">Identifier of supply order state.</param>
		/// <returns>Return PrestaShopSupplyOrderState.</returns>
		public PrestaShopSupplyOrderState GetSupplyOrderState(Int32 id)
		{
			return bNesisApi.Call<PrestaShopSupplyOrderState>("PrestaShop", bNesisToken, "GetSupplyOrderState", id);
		}

		///<summary>
		/// Getting supply order states by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about supply order states use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about SupplyOrderState in PrestaShopSupplyOrderState class.</returns>
		public PrestaShopSupplyOrderState[] GetSupplyOrderStatesByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopSupplyOrderState[]>("PrestaShop", bNesisToken, "GetSupplyOrderStatesByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting supply order states identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopSupplyOrderState.</returns>
		public PrestaShopIdentifier[] GetSupplyOrderStatesIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetSupplyOrderStatesIdentifiers");
		}

		///<summary>
		/// Getting supply order by identifier. 
		/// </summary>
		/// <param name="id">Identifier of supply order.</param>
		/// <returns>Return PrestaShopSupplyOrder.</returns>
		public PrestaShopSupplyOrder GetSupplyOrder(Int32 id)
		{
			return bNesisApi.Call<PrestaShopSupplyOrder>("PrestaShop", bNesisToken, "GetSupplyOrder", id);
		}

		///<summary>
		/// Getting supply orders by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about supply orders use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about SupplyOrder in PrestaShopSupplyOrder class.</returns>
		public PrestaShopSupplyOrder[] GetSupplyOrdersByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopSupplyOrder[]>("PrestaShop", bNesisToken, "GetSupplyOrdersByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting supply orders identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopSupplyOrder.</returns>
		public PrestaShopIdentifier[] GetSupplyOrdersIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetSupplyOrdersIdentifiers");
		}

		///<summary>
		/// Adding new tag. 
		/// </summary>
		/// <param name="tag">Body of tag.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddTag(PrestaShopTagIn tag)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddTag", tag);
		}

		///<summary>
		/// Update information in specified tag. 
		/// </summary>
		/// <param name="tag">Body of tag.</param>
		/// <returns>Return updated PrestaShopTag.</returns>
		public PrestaShopTag EditTag(PrestaShopTag tag)
		{
			return bNesisApi.Call<PrestaShopTag>("PrestaShop", bNesisToken, "EditTag", tag);
		}

		///<summary>
		/// Remove tag by identifier. 
		/// </summary>
		/// <param name="id">Identifier of tag.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteTag(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteTag", id);
		}

		///<summary>
		/// Getting tag by identifier. 
		/// </summary>
		/// <param name="id">Identifier of tag.</param>
		/// <returns>Return PrestaShopTag.</returns>
		public PrestaShopTag GetTag(Int32 id)
		{
			return bNesisApi.Call<PrestaShopTag>("PrestaShop", bNesisToken, "GetTag", id);
		}

		///<summary>
		/// Getting tags by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about tags use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Tag in PrestaShopTag class.</returns>
		public PrestaShopTag[] GetTagsByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopTag[]>("PrestaShop", bNesisToken, "GetTagsByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting tags identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopTag.</returns>
		public PrestaShopIdentifier[] GetTagsIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetTagsIdentifiers");
		}

		///<summary>
		/// Adding new tax rule group. 
		/// </summary>
		/// <param name="taxRuleGroup">Body of tax rule group.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddTaxRuleGroup(PrestaShopTaxRuleGroupIn taxRuleGroup)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddTaxRuleGroup", taxRuleGroup);
		}

		///<summary>
		/// Update information in specified tax rule group. 
		/// </summary>
		/// <param name="taxRuleGroup">Body of tax rule group.</param>
		/// <returns>Return updated PrestaShopTaxRuleGroup.</returns>
		public PrestaShopTaxRuleGroup EditTaxRuleGroup(PrestaShopTaxRuleGroup taxRuleGroup)
		{
			return bNesisApi.Call<PrestaShopTaxRuleGroup>("PrestaShop", bNesisToken, "EditTaxRuleGroup", taxRuleGroup);
		}

		///<summary>
		/// Remove tax rule group by identifier. 
		/// </summary>
		/// <param name="id">Identifier of tax rule group.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteTaxRuleGroup(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteTaxRuleGroup", id);
		}

		///<summary>
		/// Getting tax rule group by identifier. 
		/// </summary>
		/// <param name="id">Identifier of tax rule group.</param>
		/// <returns>Return PrestaShopTaxRuleGroup.</returns>
		public PrestaShopTaxRuleGroup GetTaxRuleGroup(Int32 id)
		{
			return bNesisApi.Call<PrestaShopTaxRuleGroup>("PrestaShop", bNesisToken, "GetTaxRuleGroup", id);
		}

		///<summary>
		/// Getting tax rule groups by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about tax rule groups use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about TaxRuleGroup in PrestaShopTaxRuleGroup class.</returns>
		public PrestaShopTaxRuleGroup[] GetTaxRuleGroupsByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopTaxRuleGroup[]>("PrestaShop", bNesisToken, "GetTaxRuleGroupsByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting tax rule groups identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopTaxRuleGroup.</returns>
		public PrestaShopIdentifier[] GetTaxRuleGroupsIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetTaxRuleGroupsIdentifiers");
		}

		///<summary>
		/// Adding new tax rule. 
		/// </summary>
		/// <param name="taxRule">Body of tax rule.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddTaxRule(PrestaShopTaxRuleIn taxRule)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddTaxRule", taxRule);
		}

		///<summary>
		/// Update information in specified tax rule. 
		/// </summary>
		/// <param name="taxRule">Body of tax rule.</param>
		/// <returns>Return updated PrestaShopTaxRule.</returns>
		public PrestaShopTaxRule EditTaxRule(PrestaShopTaxRule taxRule)
		{
			return bNesisApi.Call<PrestaShopTaxRule>("PrestaShop", bNesisToken, "EditTaxRule", taxRule);
		}

		///<summary>
		/// Remove tax rule by identifier. 
		/// </summary>
		/// <param name="id">Identifier of tax rule.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteTaxRule(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteTaxRule", id);
		}

		///<summary>
		/// Getting tax rule by identifier. 
		/// </summary>
		/// <param name="id">Identifier of tax rule.</param>
		/// <returns>Return PrestaShopTaxRule.</returns>
		public PrestaShopTaxRule GetTaxRule(Int32 id)
		{
			return bNesisApi.Call<PrestaShopTaxRule>("PrestaShop", bNesisToken, "GetTaxRule", id);
		}

		///<summary>
		/// Getting tax rules by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about tax rules use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about TaxRule in PrestaShopTaxRule class.</returns>
		public PrestaShopTaxRule[] GetTaxRulesByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopTaxRule[]>("PrestaShop", bNesisToken, "GetTaxRulesByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting tax rules identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopTaxRule.</returns>
		public PrestaShopIdentifier[] GetTaxRulesIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetTaxRulesIdentifiers");
		}

		///<summary>
		/// Adding new tax. 
		/// </summary>
		/// <param name="tax">Body of tax.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddTax(PrestaShopTaxIn tax)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddTax", tax);
		}

		///<summary>
		/// Update information in specified tax. 
		/// </summary>
		/// <param name="tax">Body of tax.</param>
		/// <returns>Return updated PrestaShopTax.</returns>
		public PrestaShopTax EditTax(PrestaShopTax tax)
		{
			return bNesisApi.Call<PrestaShopTax>("PrestaShop", bNesisToken, "EditTax", tax);
		}

		///<summary>
		/// Adding new product feature value. 
		/// </summary>
		/// <param name="productFeatureValue">Body of product feature value.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddProductFeatureValue(PrestaShopProductFeatureValueIn productFeatureValue)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddProductFeatureValue", productFeatureValue);
		}

		///<summary>
		/// Update information in specified product feature value. 
		/// </summary>
		/// <param name="productFeatureValue">Body of product feature value.</param>
		/// <returns>Return updated PrestaShopProductFeatureValue.</returns>
		public PrestaShopProductFeatureValue EditProductFeatureValue(PrestaShopProductFeatureValue productFeatureValue)
		{
			return bNesisApi.Call<PrestaShopProductFeatureValue>("PrestaShop", bNesisToken, "EditProductFeatureValue", productFeatureValue);
		}

		///<summary>
		/// Remove product feature value by identifier. 
		/// </summary>
		/// <param name="id">Identifier of product feature value.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteProductFeatureValue(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteProductFeatureValue", id);
		}

		///<summary>
		/// Getting product feature value by identifier. 
		/// </summary>
		/// <param name="id">Identifier of product feature value.</param>
		/// <returns>Return PrestaShopProductFeatureValue.</returns>
		public PrestaShopProductFeatureValue GetProductFeatureValue(Int32 id)
		{
			return bNesisApi.Call<PrestaShopProductFeatureValue>("PrestaShop", bNesisToken, "GetProductFeatureValue", id);
		}

		///<summary>
		/// Getting product feature values by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about product feature values use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about ProductFeatureValue in PrestaShopProductFeatureValue class.</returns>
		public PrestaShopProductFeatureValue[] GetProductFeatureValuesByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopProductFeatureValue[]>("PrestaShop", bNesisToken, "GetProductFeatureValuesByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting product feature values identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopProductFeatureValue.</returns>
		public PrestaShopIdentifier[] GetProductFeatureValuesIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetProductFeatureValuesIdentifiers");
		}

		///<summary>
		/// Adding new product feature. 
		/// </summary>
		/// <param name="productFeature">Body of product feature.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddProductFeature(PrestaShopProductFeatureIn productFeature)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddProductFeature", productFeature);
		}

		///<summary>
		/// Update information in specified product feature. 
		/// </summary>
		/// <param name="productFeature">Body of product feature.</param>
		/// <returns>Return updated PrestaShopProductFeature.</returns>
		public PrestaShopProductFeature EditProductFeature(PrestaShopProductFeature productFeature)
		{
			return bNesisApi.Call<PrestaShopProductFeature>("PrestaShop", bNesisToken, "EditProductFeature", productFeature);
		}

		///<summary>
		/// Remove product feature by identifier. 
		/// </summary>
		/// <param name="id">Identifier of product feature.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteProductFeature(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteProductFeature", id);
		}

		///<summary>
		/// Getting product feature by identifier. 
		/// </summary>
		/// <param name="id">Identifier of product feature.</param>
		/// <returns>Return PrestaShopProductFeature.</returns>
		public PrestaShopProductFeature GetProductFeature(Int32 id)
		{
			return bNesisApi.Call<PrestaShopProductFeature>("PrestaShop", bNesisToken, "GetProductFeature", id);
		}

		///<summary>
		/// Getting product features by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about product features use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about ProductFeature in PrestaShopProductFeature class.</returns>
		public PrestaShopProductFeature[] GetProductFeaturesByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopProductFeature[]>("PrestaShop", bNesisToken, "GetProductFeaturesByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting product features identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopProductFeature.</returns>
		public PrestaShopIdentifier[] GetProductFeaturesIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetProductFeaturesIdentifiers");
		}

		///<summary>
		/// Adding new product option value. 
		/// </summary>
		/// <param name="productOptionValue">Body of product option value.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddProductOptionValue(PrestaShopProductOptionValueIn productOptionValue)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddProductOptionValue", productOptionValue);
		}

		///<summary>
		/// Update information in specified product option value. 
		/// </summary>
		/// <param name="productOptionValue">Body of product option value.</param>
		/// <returns>Return updated PrestaShopProductOptionValue.</returns>
		public PrestaShopProductOptionValue EditProductOptionValue(PrestaShopProductOptionValue productOptionValue)
		{
			return bNesisApi.Call<PrestaShopProductOptionValue>("PrestaShop", bNesisToken, "EditProductOptionValue", productOptionValue);
		}

		///<summary>
		/// Remove product option value by identifier. 
		/// </summary>
		/// <param name="id">Identifier of product option value.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteProductOptionValue(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteProductOptionValue", id);
		}

		///<summary>
		/// Getting product option value by identifier. 
		/// </summary>
		/// <param name="id">Identifier of product option value.</param>
		/// <returns>Return PrestaShopProductOptionValue.</returns>
		public PrestaShopProductOptionValue GetProductOptionValue(Int32 id)
		{
			return bNesisApi.Call<PrestaShopProductOptionValue>("PrestaShop", bNesisToken, "GetProductOptionValue", id);
		}

		///<summary>
		/// Getting product option values by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about product option values use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about ProductOptionValue in PrestaShopProductOptionValue class.</returns>
		public PrestaShopProductOptionValue[] GetProductOptionValuesByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopProductOptionValue[]>("PrestaShop", bNesisToken, "GetProductOptionValuesByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting product option values identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopProductOptionValue.</returns>
		public PrestaShopIdentifier[] GetProductOptionValuesIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetProductOptionValuesIdentifiers");
		}

		///<summary>
		/// Adding new product option. 
		/// </summary>
		/// <param name="productOption">Body of product option.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddProductOption(PrestaShopProductOptionIn productOption)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddProductOption", productOption);
		}

		///<summary>
		/// Update information in specified product option. 
		/// </summary>
		/// <param name="productOption">Body of product option.</param>
		/// <returns>Return updated PrestaShopProductOption.</returns>
		public PrestaShopProductOption EditProductOption(PrestaShopProductOption productOption)
		{
			return bNesisApi.Call<PrestaShopProductOption>("PrestaShop", bNesisToken, "EditProductOption", productOption);
		}

		///<summary>
		/// Remove product option by identifier. 
		/// </summary>
		/// <param name="id">Identifier of product option.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteProductOption(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteProductOption", id);
		}

		///<summary>
		/// Getting product option by identifier. 
		/// </summary>
		/// <param name="id">Identifier of product option.</param>
		/// <returns>Return PrestaShopProductOption.</returns>
		public PrestaShopProductOption GetProductOption(Int32 id)
		{
			return bNesisApi.Call<PrestaShopProductOption>("PrestaShop", bNesisToken, "GetProductOption", id);
		}

		///<summary>
		/// Getting product options by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about product options use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about ProductOption in PrestaShopProductOption class.</returns>
		public PrestaShopProductOption[] GetProductOptionsByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopProductOption[]>("PrestaShop", bNesisToken, "GetProductOptionsByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting product options identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopProductOption.</returns>
		public PrestaShopIdentifier[] GetProductOptionsIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetProductOptionsIdentifiers");
		}

		///<summary>
		/// Adding new product supplier. 
		/// </summary>
		/// <param name="productSupplier">Body of product supplier.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddProductSupplier(PrestaShopProductSupplierIn productSupplier)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddProductSupplier", productSupplier);
		}

		///<summary>
		/// Update information in specified product supplier. 
		/// </summary>
		/// <param name="productSupplier">Body of product supplier.</param>
		/// <returns>Return updated PrestaShopProductSupplier.</returns>
		public PrestaShopProductSupplier EditProductSupplier(PrestaShopProductSupplier productSupplier)
		{
			return bNesisApi.Call<PrestaShopProductSupplier>("PrestaShop", bNesisToken, "EditProductSupplier", productSupplier);
		}

		///<summary>
		/// Remove product supplier by identifier. 
		/// </summary>
		/// <param name="id">Identifier of product supplier.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteProductSupplier(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteProductSupplier", id);
		}

		///<summary>
		/// Getting product supplier by identifier. 
		/// </summary>
		/// <param name="id">Identifier of product supplier.</param>
		/// <returns>Return PrestaShopProductSupplier.</returns>
		public PrestaShopProductSupplier GetProductSupplier(Int32 id)
		{
			return bNesisApi.Call<PrestaShopProductSupplier>("PrestaShop", bNesisToken, "GetProductSupplier", id);
		}

		///<summary>
		/// Getting product suppliers by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about product suppliers use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about ProductSupplier in PrestaShopProductSupplier class.</returns>
		public PrestaShopProductSupplier[] GetProductSuppliersByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopProductSupplier[]>("PrestaShop", bNesisToken, "GetProductSuppliersByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting product suppliers identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopProductSupplier.</returns>
		public PrestaShopIdentifier[] GetProductSuppliersIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetProductSuppliersIdentifiers");
		}

		///<summary>
		/// Adding new product supplier. 
		/// </summary>
		/// <param name="product">Body of product supplier.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddProduct(PrestaShopProductIn product)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddProduct", product);
		}

		///<summary>
		/// Update information in specified product supplier. 
		/// </summary>
		/// <param name="product">Body of product supplier.</param>
		/// <returns>Return updated PrestaShopProduct.</returns>
		public PrestaShopProduct EditProduct(PrestaShopProduct product)
		{
			return bNesisApi.Call<PrestaShopProduct>("PrestaShop", bNesisToken, "EditProduct", product);
		}

		///<summary>
		/// Remove product by identifier. 
		/// </summary>
		/// <param name="id">Identifier of product.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteProduct(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteProduct", id);
		}

		///<summary>
		/// Getting product by identifier. 
		/// </summary>
		/// <param name="id">Identifier of product.</param>
		/// <returns>Return PrestaShopProduct.</returns>
		public PrestaShopProduct GetProduct(Int32 id)
		{
			return bNesisApi.Call<PrestaShopProduct>("PrestaShop", bNesisToken, "GetProduct", id);
		}

		///<summary>
		/// Getting products by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about products use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Product in PrestaShopProduct class.</returns>
		public PrestaShopProduct[] GetProductsByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopProduct[]>("PrestaShop", bNesisToken, "GetProductsByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting products identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopProduct.</returns>
		public PrestaShopIdentifier[] GetProductsIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetProductsIdentifiers");
		}

		///<summary>
		/// Adding new shop group. 
		/// </summary>
		/// <param name="shopGroup">Body of shop group.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddShopGroup(PrestaShopShopGroupIn shopGroup)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddShopGroup", shopGroup);
		}

		///<summary>
		/// Update information in specified shop group. 
		/// </summary>
		/// <param name="shopGroup">Body of shop group.</param>
		/// <returns>Return updated PrestaShopShopGroup.</returns>
		public PrestaShopShopGroup EditShopGroup(PrestaShopShopGroup shopGroup)
		{
			return bNesisApi.Call<PrestaShopShopGroup>("PrestaShop", bNesisToken, "EditShopGroup", shopGroup);
		}

		///<summary>
		/// Remove shop group by identifier. 
		/// </summary>
		/// <param name="id">Identifier of shop group.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteShopGroup(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteShopGroup", id);
		}

		///<summary>
		/// Getting shop group by identifier. 
		/// </summary>
		/// <param name="id">Identifier of shop group.</param>
		/// <returns>Return PrestaShopShopGroup.</returns>
		public PrestaShopShopGroup GetShopGroup(Int32 id)
		{
			return bNesisApi.Call<PrestaShopShopGroup>("PrestaShop", bNesisToken, "GetShopGroup", id);
		}

		///<summary>
		/// Getting shop groups by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about shop groups use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about ShopGroup in PrestaShopShopGroup class.</returns>
		public PrestaShopShopGroup[] GetShopGroupsByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopShopGroup[]>("PrestaShop", bNesisToken, "GetShopGroupsByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting shop groups identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopShopGroup.</returns>
		public PrestaShopIdentifier[] GetShopGroupsIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetShopGroupsIdentifiers");
		}

		///<summary>
		/// Adding new shop url. 
		/// </summary>
		/// <param name="shopUrl">Body of shop url.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddShopUrl(PrestaShopShopUrlIn shopUrl)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddShopUrl", shopUrl);
		}

		///<summary>
		/// Update information in specified shop url. 
		/// </summary>
		/// <param name="shopUrl">Body of shop url.</param>
		/// <returns>Return updated PrestaShopShopUrl.</returns>
		public PrestaShopShopUrl EditShopUrl(PrestaShopShopUrl shopUrl)
		{
			return bNesisApi.Call<PrestaShopShopUrl>("PrestaShop", bNesisToken, "EditShopUrl", shopUrl);
		}

		///<summary>
		/// Remove shop url by identifier. 
		/// </summary>
		/// <param name="id">Identifier of shop url.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteShopUrl(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteShopUrl", id);
		}

		///<summary>
		/// Getting shop url by identifier. 
		/// </summary>
		/// <param name="id">Identifier of shop url.</param>
		/// <returns>Return PrestaShopShopUrl.</returns>
		public PrestaShopShopUrl GetShopUrl(Int32 id)
		{
			return bNesisApi.Call<PrestaShopShopUrl>("PrestaShop", bNesisToken, "GetShopUrl", id);
		}

		///<summary>
		/// Getting shop urls by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about shop urls use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about ShopUrl in PrestaShopShopUrl class.</returns>
		public PrestaShopShopUrl[] GetShopUrlsByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopShopUrl[]>("PrestaShop", bNesisToken, "GetShopUrlsByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting shop urls identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopShopUrl.</returns>
		public PrestaShopIdentifier[] GetShopUrlsIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetShopUrlsIdentifiers");
		}

		///<summary>
		/// Adding new shop. 
		/// </summary>
		/// <param name="shop">Body of shop.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddShop(PrestaShopShopIn shop)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddShop", shop);
		}

		///<summary>
		/// Update information in specified shop. 
		/// </summary>
		/// <param name="shop">Body of shop.</param>
		/// <returns>Return updated PrestaShopShop.</returns>
		public PrestaShopShop EditShop(PrestaShopShop shop)
		{
			return bNesisApi.Call<PrestaShopShop>("PrestaShop", bNesisToken, "EditShop", shop);
		}

		///<summary>
		/// Remove shop by identifier. 
		/// </summary>
		/// <param name="id">Identifier of shop.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteShop(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteShop", id);
		}

		///<summary>
		/// Getting shop by identifier. 
		/// </summary>
		/// <param name="id">Identifier of shop.</param>
		/// <returns>Return PrestaShopShop.</returns>
		public PrestaShopShop GetShop(Int32 id)
		{
			return bNesisApi.Call<PrestaShopShop>("PrestaShop", bNesisToken, "GetShop", id);
		}

		///<summary>
		/// Getting shops by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about shops use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Shop in PrestaShopShop class.</returns>
		public PrestaShopShop[] GetShopsByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopShop[]>("PrestaShop", bNesisToken, "GetShopsByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting shops identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopShop.</returns>
		public PrestaShopIdentifier[] GetShopsIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetShopsIdentifiers");
		}

		///<summary>
		/// Adding new specific price rule. 
		/// </summary>
		/// <param name="specificPriceRule">Body of specific price rule.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddSpecificPriceRule(PrestaShopSpecificPriceRuleIn specificPriceRule)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddSpecificPriceRule", specificPriceRule);
		}

		///<summary>
		/// Update information in specified specific price rule. 
		/// </summary>
		/// <param name="specificPriceRule">Body of specific price rule.</param>
		/// <returns>Return updated PrestaShopSpecificPriceRule.</returns>
		public PrestaShopSpecificPriceRule EditSpecificPriceRule(PrestaShopSpecificPriceRule specificPriceRule)
		{
			return bNesisApi.Call<PrestaShopSpecificPriceRule>("PrestaShop", bNesisToken, "EditSpecificPriceRule", specificPriceRule);
		}

		///<summary>
		/// Remove specific price rule by identifier. 
		/// </summary>
		/// <param name="id">Identifier of specific price rule.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteSpecificPriceRule(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteSpecificPriceRule", id);
		}

		///<summary>
		/// Getting specific price rule by identifier. 
		/// </summary>
		/// <param name="id">Identifier of specific price rule.</param>
		/// <returns>Return PrestaShopSpecificPriceRule.</returns>
		public PrestaShopSpecificPriceRule GetSpecificPriceRule(Int32 id)
		{
			return bNesisApi.Call<PrestaShopSpecificPriceRule>("PrestaShop", bNesisToken, "GetSpecificPriceRule", id);
		}

		///<summary>
		/// Getting specific price rules by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about specific price rules use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about SpecificPriceRule in PrestaShopSpecificPriceRule class.</returns>
		public PrestaShopSpecificPriceRule[] GetSpecificPriceRulesByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopSpecificPriceRule[]>("PrestaShop", bNesisToken, "GetSpecificPriceRulesByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting specific price rules identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopSpecificPriceRule.</returns>
		public PrestaShopIdentifier[] GetSpecificPriceRulesIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetSpecificPriceRulesIdentifiers");
		}

		///<summary>
		/// Adding new specific price. 
		/// </summary>
		/// <param name="specificPrice">Body of specific price.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddSpecificPrice(PrestaShopSpecificPriceIn specificPrice)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddSpecificPrice", specificPrice);
		}

		///<summary>
		/// Update information in specified specific price. 
		/// </summary>
		/// <param name="specificPrice">Body of specific price.</param>
		/// <returns>Return updated PrestaShopSpecificPrice.</returns>
		public PrestaShopSpecificPrice EditSpecificPrice(PrestaShopSpecificPrice specificPrice)
		{
			return bNesisApi.Call<PrestaShopSpecificPrice>("PrestaShop", bNesisToken, "EditSpecificPrice", specificPrice);
		}

		///<summary>
		/// Remove specific price by identifier. 
		/// </summary>
		/// <param name="id">Identifier of specific price.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteSpecificPrice(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteSpecificPrice", id);
		}

		///<summary>
		/// Getting specific price by identifier. 
		/// </summary>
		/// <param name="id">Identifier of specific price.</param>
		/// <returns>Return PrestaShopSpecificPrice.</returns>
		public PrestaShopSpecificPrice GetSpecificPrice(Int32 id)
		{
			return bNesisApi.Call<PrestaShopSpecificPrice>("PrestaShop", bNesisToken, "GetSpecificPrice", id);
		}

		///<summary>
		/// Remove language by identifier. 
		/// </summary>
		/// <param name="id">Identifier of language.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteLanguage(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteLanguage", id);
		}

		///<summary>
		/// Getting language by identifier. 
		/// </summary>
		/// <param name="id">Identifier of language.</param>
		/// <returns>Return PrestaShopLanguage.</returns>
		public PrestaShopLanguage GetLanguage(Int32 id)
		{
			return bNesisApi.Call<PrestaShopLanguage>("PrestaShop", bNesisToken, "GetLanguage", id);
		}

		///<summary>
		/// Getting languages by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about languages use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Language in PrestaShopLanguage class.</returns>
		public PrestaShopLanguage[] GetLanguagesByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopLanguage[]>("PrestaShop", bNesisToken, "GetLanguagesByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting languages identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopLanguage.</returns>
		public PrestaShopIdentifier[] GetLanguagesIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetLanguagesIdentifiers");
		}

		///<summary>
		/// Adding new manufacturer. 
		/// </summary>
		/// <param name="manufacturer">Body of manufacturer.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddManufacturer(PrestaShopManufacturerIn manufacturer)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddManufacturer", manufacturer);
		}

		///<summary>
		/// Update information in specified manufacturer. 
		/// </summary>
		/// <param name="manufacturer">Body of manufacturer.</param>
		/// <returns>Return updated PrestaShopManufacturer.</returns>
		public PrestaShopManufacturer EditManufacturer(PrestaShopManufacturer manufacturer)
		{
			return bNesisApi.Call<PrestaShopManufacturer>("PrestaShop", bNesisToken, "EditManufacturer", manufacturer);
		}

		///<summary>
		/// Remove manufacturer by identifier. 
		/// </summary>
		/// <param name="id">Identifier of manufacturer.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteManufacturer(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteManufacturer", id);
		}

		///<summary>
		/// Getting manufacturer by identifier. 
		/// </summary>
		/// <param name="id">Identifier of manufacturer.</param>
		/// <returns>Return PrestaShopManufacturer.</returns>
		public PrestaShopManufacturer GetManufacturer(Int32 id)
		{
			return bNesisApi.Call<PrestaShopManufacturer>("PrestaShop", bNesisToken, "GetManufacturer", id);
		}

		///<summary>
		/// Getting manufacturers by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about manufacturers use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Manufacturer in PrestaShopManufacturer class.</returns>
		public PrestaShopManufacturer[] GetManufacturersByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopManufacturer[]>("PrestaShop", bNesisToken, "GetManufacturersByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting manufacturers identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopManufacturer.</returns>
		public PrestaShopIdentifier[] GetManufacturersIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetManufacturersIdentifiers");
		}

		///<summary>
		/// Adding new message. 
		/// </summary>
		/// <param name="message">Body of message.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddMessage(PrestaShopMessageIn message)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddMessage", message);
		}

		///<summary>
		/// Update information in specified message. 
		/// </summary>
		/// <param name="message">Body of message.</param>
		/// <returns>Return updated PrestaShopMessage.</returns>
		public PrestaShopMessage EditMessage(PrestaShopMessage message)
		{
			return bNesisApi.Call<PrestaShopMessage>("PrestaShop", bNesisToken, "EditMessage", message);
		}

		///<summary>
		/// Remove message by identifier. 
		/// </summary>
		/// <param name="id">Identifier of message.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteMessage(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteMessage", id);
		}

		///<summary>
		/// Getting message by identifier. 
		/// </summary>
		/// <param name="id">Identifier of message.</param>
		/// <returns>Return PrestaShopMessage.</returns>
		public PrestaShopMessage GetMessage(Int32 id)
		{
			return bNesisApi.Call<PrestaShopMessage>("PrestaShop", bNesisToken, "GetMessage", id);
		}

		///<summary>
		/// Getting messages by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about messages use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Message in PrestaShopMessage class.</returns>
		public PrestaShopMessage[] GetMessagesByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopMessage[]>("PrestaShop", bNesisToken, "GetMessagesByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting messages identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopMessage.</returns>
		public PrestaShopIdentifier[] GetMessagesIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetMessagesIdentifiers");
		}

		///<summary>
		/// Adding new order carrier. 
		/// </summary>
		/// <param name="orderCarrier">Body of order carrier.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddOrderCarrier(PrestaShopOrderCarrierIn orderCarrier)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddOrderCarrier", orderCarrier);
		}

		///<summary>
		/// Update information in specified order carrier. 
		/// </summary>
		/// <param name="orderCarrier">Body of order carrier.</param>
		/// <returns>Return updated PrestaShopOrderCarrier.</returns>
		public PrestaShopOrderCarrier EditOrderCarrier(PrestaShopOrderCarrier orderCarrier)
		{
			return bNesisApi.Call<PrestaShopOrderCarrier>("PrestaShop", bNesisToken, "EditOrderCarrier", orderCarrier);
		}

		///<summary>
		/// Remove order carrier by identifier. 
		/// </summary>
		/// <param name="id">Identifier of order carrier.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteOrderCarrier(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteOrderCarrier", id);
		}

		///<summary>
		/// Getting order carrier by identifier. 
		/// </summary>
		/// <param name="id">Identifier of order carrier.</param>
		/// <returns>Return PrestaShopOrderCarrier.</returns>
		public PrestaShopOrderCarrier GetOrderCarrier(Int32 id)
		{
			return bNesisApi.Call<PrestaShopOrderCarrier>("PrestaShop", bNesisToken, "GetOrderCarrier", id);
		}

		///<summary>
		/// Getting order carriers by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about order carriers use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about OrderCarrier in PrestaShopOrderCarrier class.</returns>
		public PrestaShopOrderCarrier[] GetOrderCarriersByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopOrderCarrier[]>("PrestaShop", bNesisToken, "GetOrderCarriersByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting order carriers identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopOrderCarrier.</returns>
		public PrestaShopIdentifier[] GetOrderCarriersIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetOrderCarriersIdentifiers");
		}

		///<summary>
		/// Getting order detail by identifier. 
		/// </summary>
		/// <param name="id">Identifier of order detail.</param>
		/// <returns>Return PrestaShopOrderDetail.</returns>
		public PrestaShopOrderDetail GetOrderDetail(Int32 id)
		{
			return bNesisApi.Call<PrestaShopOrderDetail>("PrestaShop", bNesisToken, "GetOrderDetail", id);
		}

		///<summary>
		/// Getting order details by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about order details use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about OrderDetail in PrestaShopOrderDetail class.</returns>
		public PrestaShopOrderDetail[] GetOrderDetailsByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopOrderDetail[]>("PrestaShop", bNesisToken, "GetOrderDetailsByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting order details identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopOrderDetail.</returns>
		public PrestaShopIdentifier[] GetOrderDetailsIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetOrderDetailsIdentifiers");
		}

		///<summary>
		/// Getting order history by identifier. 
		/// </summary>
		/// <param name="id">Identifier of order history.</param>
		/// <returns>Return PrestaShopOrderHistory.</returns>
		public PrestaShopOrderHistory GetOrderHistory(Int32 id)
		{
			return bNesisApi.Call<PrestaShopOrderHistory>("PrestaShop", bNesisToken, "GetOrderHistory", id);
		}

		///<summary>
		/// Getting order histories by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about order histories use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about OrderHistory in PrestaShopOrderHistory class.</returns>
		public PrestaShopOrderHistory[] GetOrderHistoriesByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopOrderHistory[]>("PrestaShop", bNesisToken, "GetOrderHistoriesByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting order histories identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopOrderHistory.</returns>
		public PrestaShopIdentifier[] GetOrderHistoriesIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetOrderHistoriesIdentifiers");
		}

		///<summary>
		/// Adding new order invoice. 
		/// </summary>
		/// <param name="orderInvoice">Body of order invoice.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddOrderInvoice(PrestaShopOrderInvoiceIn orderInvoice)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddOrderInvoice", orderInvoice);
		}

		///<summary>
		/// Update information in specified order invoice. 
		/// </summary>
		/// <param name="orderInvoice">Body of order invoice.</param>
		/// <returns>Return updated PrestaShopOrderInvoice.</returns>
		public PrestaShopOrderInvoice EditOrderInvoice(PrestaShopOrderInvoice orderInvoice)
		{
			return bNesisApi.Call<PrestaShopOrderInvoice>("PrestaShop", bNesisToken, "EditOrderInvoice", orderInvoice);
		}

		///<summary>
		/// Remove order invoice by identifier. 
		/// </summary>
		/// <param name="id">Identifier of order invoice.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteOrderInvoice(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteOrderInvoice", id);
		}

		///<summary>
		/// Getting order invoice by identifier. 
		/// </summary>
		/// <param name="id">Identifier of order invoice.</param>
		/// <returns>Return PrestaShopOrderInvoice.</returns>
		public PrestaShopOrderInvoice GetOrderInvoice(Int32 id)
		{
			return bNesisApi.Call<PrestaShopOrderInvoice>("PrestaShop", bNesisToken, "GetOrderInvoice", id);
		}

		///<summary>
		/// Getting order invoices by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about order invoices use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about OrderInvoice in PrestaShopOrderInvoice class.</returns>
		public PrestaShopOrderInvoice[] GetOrderInvoicesByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopOrderInvoice[]>("PrestaShop", bNesisToken, "GetOrderInvoicesByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting order invoices identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopOrderInvoice.</returns>
		public PrestaShopIdentifier[] GetOrderInvoicesIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetOrderInvoicesIdentifiers");
		}

		///<summary>
		/// Adding new order payment. 
		/// </summary>
		/// <param name="orderPayment">Body of order payment.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddOrderPayment(PrestaShopOrderPaymentIn orderPayment)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddOrderPayment", orderPayment);
		}

		///<summary>
		/// Update information in specified order payment. 
		/// </summary>
		/// <param name="orderPayment">Body of order payment.</param>
		/// <returns>Return updated PrestaShopOrderPayment.</returns>
		public PrestaShopOrderPayment EditOrderPayment(PrestaShopOrderPayment orderPayment)
		{
			return bNesisApi.Call<PrestaShopOrderPayment>("PrestaShop", bNesisToken, "EditOrderPayment", orderPayment);
		}

		///<summary>
		/// Remove order payment by identifier. 
		/// </summary>
		/// <param name="id">Identifier of order payment.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteOrderPayment(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteOrderPayment", id);
		}

		///<summary>
		/// Getting order payment by identifier. 
		/// </summary>
		/// <param name="id">Identifier of order payment.</param>
		/// <returns>Return PrestaShopOrderPayment.</returns>
		public PrestaShopOrderPayment GetOrderPayment(Int32 id)
		{
			return bNesisApi.Call<PrestaShopOrderPayment>("PrestaShop", bNesisToken, "GetOrderPayment", id);
		}

		///<summary>
		/// Getting order payments by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about order payments use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about OrderPayment in PrestaShopOrderPayment class.</returns>
		public PrestaShopOrderPayment[] GetOrderPaymentsByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopOrderPayment[]>("PrestaShop", bNesisToken, "GetOrderPaymentsByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting order payments identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopOrderPayment.</returns>
		public PrestaShopIdentifier[] GetOrderPaymentsIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetOrderPaymentsIdentifiers");
		}

		///<summary>
		/// Adding new order slip. 
		/// </summary>
		/// <param name="orderSlip">Body of order slip.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddOrderSlip(PrestaShopOrderSlipIn orderSlip)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddOrderSlip", orderSlip);
		}

		///<summary>
		/// Update information in specified order slip. 
		/// </summary>
		/// <param name="orderSlip">Body of order slip.</param>
		/// <returns>Return updated PrestaShopOrderSlip.</returns>
		public PrestaShopOrderSlip EditOrderSlip(PrestaShopOrderSlip orderSlip)
		{
			return bNesisApi.Call<PrestaShopOrderSlip>("PrestaShop", bNesisToken, "EditOrderSlip", orderSlip);
		}

		///<summary>
		/// Remove order slip by identifier. 
		/// </summary>
		/// <param name="id">Identifier of order slip.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteOrderSlip(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteOrderSlip", id);
		}

		///<summary>
		/// Getting order slip by identifier. 
		/// </summary>
		/// <param name="id">Identifier of order slip.</param>
		/// <returns>Return PrestaShopOrderSlip.</returns>
		public PrestaShopOrderSlip GetOrderSlip(Int32 id)
		{
			return bNesisApi.Call<PrestaShopOrderSlip>("PrestaShop", bNesisToken, "GetOrderSlip", id);
		}

		///<summary>
		/// Getting order slip by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about order slip use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about OrderSlip in PrestaShopOrderSlip class.</returns>
		public PrestaShopOrderSlip[] GetOrderSlipByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopOrderSlip[]>("PrestaShop", bNesisToken, "GetOrderSlipByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting order slip identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopOrderSlip.</returns>
		public PrestaShopIdentifier[] GetOrderSlipIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetOrderSlipIdentifiers");
		}

		///<summary>
		/// Getting order state by identifier. 
		/// </summary>
		/// <param name="id">Identifier of order state.</param>
		/// <returns>Return PrestaShopOrderState.</returns>
		public PrestaShopOrderState GetOrderState(Int32 id)
		{
			return bNesisApi.Call<PrestaShopOrderState>("PrestaShop", bNesisToken, "GetOrderState", id);
		}

		///<summary>
		/// Getting order states by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about order states use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about OrderState in PrestaShopOrderState class.</returns>
		public PrestaShopOrderState[] GetOrderStatesByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopOrderState[]>("PrestaShop", bNesisToken, "GetOrderStatesByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting order states identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopOrderState.</returns>
		public PrestaShopIdentifier[] GetOrderStatesIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetOrderStatesIdentifiers");
		}

		///<summary>
		/// Getting order by identifier. 
		/// </summary>
		/// <param name="id">Identifier of order.</param>
		/// <returns>Return PrestaShopOrder.</returns>
		public PrestaShopOrder GetOrder(Int32 id)
		{
			return bNesisApi.Call<PrestaShopOrder>("PrestaShop", bNesisToken, "GetOrder", id);
		}

		///<summary>
		/// Getting orders by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about orders use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Order in PrestaShopOrder class.</returns>
		public PrestaShopOrder[] GetOrdersByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopOrder[]>("PrestaShop", bNesisToken, "GetOrdersByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting orders identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopOrder.</returns>
		public PrestaShopIdentifier[] GetOrdersIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetOrdersIdentifiers");
		}

		///<summary>
		/// Adding new price range. 
		/// </summary>
		/// <param name="priceRange">Body of price range.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddPriceRange(PrestaShopPriceRangeIn priceRange)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddPriceRange", priceRange);
		}

		///<summary>
		/// Update information in specified price range. 
		/// </summary>
		/// <param name="priceRange">Body of price range.</param>
		/// <returns>Return updated PrestaShopPriceRange.</returns>
		public PrestaShopPriceRange EditPriceRange(PrestaShopPriceRange priceRange)
		{
			return bNesisApi.Call<PrestaShopPriceRange>("PrestaShop", bNesisToken, "EditPriceRange", priceRange);
		}

		///<summary>
		/// Remove price range by identifier. 
		/// </summary>
		/// <param name="id">Identifier of price range.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeletePriceRange(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeletePriceRange", id);
		}

		///<summary>
		/// Getting price range by identifier. 
		/// </summary>
		/// <param name="id">Identifier of price range.</param>
		/// <returns>Return PrestaShopPriceRange.</returns>
		public PrestaShopPriceRange GetPriceRange(Int32 id)
		{
			return bNesisApi.Call<PrestaShopPriceRange>("PrestaShop", bNesisToken, "GetPriceRange", id);
		}

		///<summary>
		/// Getting price ranges by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about price ranges use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about PriceRange in PrestaShopPriceRange class.</returns>
		public PrestaShopPriceRange[] GetPriceRangesByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopPriceRange[]>("PrestaShop", bNesisToken, "GetPriceRangesByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting price ranges identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopPriceRange.</returns>
		public PrestaShopIdentifier[] GetPriceRangesIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetPriceRangesIdentifiers");
		}

		///<summary>
		/// Adding new product customization field. 
		/// </summary>
		/// <param name="productCustomizationField">Body of product customization field.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddProductCustomizationField(PrestaShopProductCustomizationFieldIn productCustomizationField)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddProductCustomizationField", productCustomizationField);
		}

		///<summary>
		/// Update information in specified product customization field. 
		/// </summary>
		/// <param name="productCustomizationField">Body of product customization field.</param>
		/// <returns>Return updated PrestaShopProductCustomizationField.</returns>
		public PrestaShopProductCustomizationField EditProductCustomizationField(PrestaShopProductCustomizationField productCustomizationField)
		{
			return bNesisApi.Call<PrestaShopProductCustomizationField>("PrestaShop", bNesisToken, "EditProductCustomizationField", productCustomizationField);
		}

		///<summary>
		/// Remove product customization field by identifier. 
		/// </summary>
		/// <param name="id">Identifier of product customization field.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteProductCustomizationField(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteProductCustomizationField", id);
		}

		///<summary>
		/// Getting product customization field by identifier. 
		/// </summary>
		/// <param name="id">Identifier of product customization field.</param>
		/// <returns>Return PrestaShopProductCustomizationField.</returns>
		public PrestaShopProductCustomizationField GetProductCustomizationField(Int32 id)
		{
			return bNesisApi.Call<PrestaShopProductCustomizationField>("PrestaShop", bNesisToken, "GetProductCustomizationField", id);
		}

		///<summary>
		/// Getting product customization fields by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about product customization fields use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about ProductCustomizationField in PrestaShopProductCustomizationField class.</returns>
		public PrestaShopProductCustomizationField[] GetProductCustomizationFieldsByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopProductCustomizationField[]>("PrestaShop", bNesisToken, "GetProductCustomizationFieldsByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting product customization fields identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopProductCustomizationField.</returns>
		public PrestaShopIdentifier[] GetProductCustomizationFieldsIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetProductCustomizationFieldsIdentifiers");
		}

		///<summary>
		/// Getting currencies by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about currencies use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Currency in PrestaShopCurrency class.</returns>
		public PrestaShopCurrency[] GetCurrenciesByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopCurrency[]>("PrestaShop", bNesisToken, "GetCurrenciesByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting currencies identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopCurrency.</returns>
		public PrestaShopIdentifier[] GetCurrenciesIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetCurrenciesIdentifiers");
		}

		///<summary>
		/// Adding new customer message. 
		/// </summary>
		/// <param name="customerMessage">Body of customer message.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddCustomerMessage(PrestaShopCustomerMessageIn customerMessage)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddCustomerMessage", customerMessage);
		}

		///<summary>
		/// Update information in specified customer message. 
		/// </summary>
		/// <param name="customerMessage">Body of customer message.</param>
		/// <returns>Return updated PrestaShopCustomerMessage.</returns>
		public PrestaShopCustomerMessage EditCustomerMessage(PrestaShopCustomerMessage customerMessage)
		{
			return bNesisApi.Call<PrestaShopCustomerMessage>("PrestaShop", bNesisToken, "EditCustomerMessage", customerMessage);
		}

		///<summary>
		/// Remove customer message by identifier. 
		/// </summary>
		/// <param name="id">Identifier of customer message.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteCustomerMessage(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteCustomerMessage", id);
		}

		///<summary>
		/// Getting customer message by identifier. 
		/// </summary>
		/// <param name="id">Identifier of customer message.</param>
		/// <returns>Return PrestaShopCustomerMessage.</returns>
		public PrestaShopCustomerMessage GetCustomerMessage(Int32 id)
		{
			return bNesisApi.Call<PrestaShopCustomerMessage>("PrestaShop", bNesisToken, "GetCustomerMessage", id);
		}

		///<summary>
		/// Getting customer messages by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about customer messages use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about CustomerMessage in PrestaShopCustomerMessage class.</returns>
		public PrestaShopCustomerMessage[] GetCustomerMessagesByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopCustomerMessage[]>("PrestaShop", bNesisToken, "GetCustomerMessagesByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting customer messages identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopCustomerMessage.</returns>
		public PrestaShopIdentifier[] GetCustomerMessagesIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetCustomerMessagesIdentifiers");
		}

		///<summary>
		/// Adding new customer thread. 
		/// </summary>
		/// <param name="customerThread">Body of customer thread.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddCustomerThread(PrestaShopCustomerThreadIn customerThread)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddCustomerThread", customerThread);
		}

		///<summary>
		/// Update information in specified customer thread. 
		/// </summary>
		/// <param name="customerThread">Body of customer thread.</param>
		/// <returns>Return updated PrestaShopCustomerThread.</returns>
		public PrestaShopCustomerThread EditCustomerThread(PrestaShopCustomerThread customerThread)
		{
			return bNesisApi.Call<PrestaShopCustomerThread>("PrestaShop", bNesisToken, "EditCustomerThread", customerThread);
		}

		///<summary>
		/// Remove customer thread by identifier. 
		/// </summary>
		/// <param name="id">Identifier of customer thread.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteCustomerThread(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteCustomerThread", id);
		}

		///<summary>
		/// Getting customer thread by identifier. 
		/// </summary>
		/// <param name="id">Identifier of customer thread.</param>
		/// <returns>Return PrestaShopCustomerThread.</returns>
		public PrestaShopCustomerThread GetCustomerThread(Int32 id)
		{
			return bNesisApi.Call<PrestaShopCustomerThread>("PrestaShop", bNesisToken, "GetCustomerThread", id);
		}

		///<summary>
		/// Getting customer threads by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about customer threads use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about CustomerThread in PrestaShopCustomerThread class.</returns>
		public PrestaShopCustomerThread[] GetCustomerThreadsByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopCustomerThread[]>("PrestaShop", bNesisToken, "GetCustomerThreadsByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting customer threads identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopCustomerThread.</returns>
		public PrestaShopIdentifier[] GetCustomerThreadsIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetCustomerThreadsIdentifiers");
		}

		///<summary>
		/// Adding new customer. 
		/// </summary>
		/// <param name="customer">Body of customer.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddCustomer(PrestaShopCustomerIn customer)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddCustomer", customer);
		}

		///<summary>
		/// Update information in specified customer. 
		/// </summary>
		/// <param name="customer">Body of customer.</param>
		/// <returns>Return updated PrestaShopCustomer.</returns>
		public PrestaShopCustomer EditCustomer(PrestaShopCustomer customer)
		{
			return bNesisApi.Call<PrestaShopCustomer>("PrestaShop", bNesisToken, "EditCustomer", customer);
		}

		///<summary>
		/// Remove customer by identifier. 
		/// </summary>
		/// <param name="id">Identifier of customer.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteCustomer(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteCustomer", id);
		}

		///<summary>
		/// Getting customer by identifier. 
		/// </summary>
		/// <param name="id">Identifier of customer.</param>
		/// <returns>Return PrestaShopCustomer.</returns>
		public PrestaShopCustomer GetCustomer(Int32 id)
		{
			return bNesisApi.Call<PrestaShopCustomer>("PrestaShop", bNesisToken, "GetCustomer", id);
		}

		///<summary>
		/// Getting customers by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about customers use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Customer in PrestaShopCustomer class.</returns>
		public PrestaShopCustomer[] GetCustomersByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopCustomer[]>("PrestaShop", bNesisToken, "GetCustomersByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting customers identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopCustomer.</returns>
		public PrestaShopIdentifier[] GetCustomersIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetCustomersIdentifiers");
		}

		///<summary>
		/// Adding new customization. 
		/// </summary>
		/// <param name="customization">Body of customization.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddCustomization(PrestaShopCustomizationIn customization)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddCustomization", customization);
		}

		///<summary>
		/// Update information in specified customization. 
		/// </summary>
		/// <param name="customization">Body of customization.</param>
		/// <returns>Return updated PrestaShopCustomization.</returns>
		public PrestaShopCustomization EditCustomization(PrestaShopCustomization customization)
		{
			return bNesisApi.Call<PrestaShopCustomization>("PrestaShop", bNesisToken, "EditCustomization", customization);
		}

		///<summary>
		/// Remove customization by identifier. 
		/// </summary>
		/// <param name="id">Identifier of customization.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteCustomization(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteCustomization", id);
		}

		///<summary>
		/// Getting customization by identifier. 
		/// </summary>
		/// <param name="id">Identifier of customization.</param>
		/// <returns>Return PrestaShopCustomization.</returns>
		public PrestaShopCustomization GetCustomization(Int32 id)
		{
			return bNesisApi.Call<PrestaShopCustomization>("PrestaShop", bNesisToken, "GetCustomization", id);
		}

		///<summary>
		/// Getting customizations by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about customizations use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Customization in PrestaShopCustomization class.</returns>
		public PrestaShopCustomization[] GetCustomizationsByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopCustomization[]>("PrestaShop", bNesisToken, "GetCustomizationsByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting customizations identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopCustomization.</returns>
		public PrestaShopIdentifier[] GetCustomizationsIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetCustomizationsIdentifiers");
		}

		///<summary>
		/// Adding new delivery. 
		/// </summary>
		/// <param name="delivery">Body of delivery.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddDelivery(PrestaShopDeliveryIn delivery)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddDelivery", delivery);
		}

		///<summary>
		/// Update information in specified delivery. 
		/// </summary>
		/// <param name="delivery">Body of delivery.</param>
		/// <returns>Return updated PrestaShopDelivery.</returns>
		public PrestaShopDelivery EditDelivery(PrestaShopDelivery delivery)
		{
			return bNesisApi.Call<PrestaShopDelivery>("PrestaShop", bNesisToken, "EditDelivery", delivery);
		}

		///<summary>
		/// Remove delivery by identifier. 
		/// </summary>
		/// <param name="id">Identifier of delivery.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteDelivery(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteDelivery", id);
		}

		///<summary>
		/// Getting delivery by identifier. 
		/// </summary>
		/// <param name="id">Identifier of delivery.</param>
		/// <returns>Return PrestaShopDelivery.</returns>
		public PrestaShopDelivery GetDelivery(Int32 id)
		{
			return bNesisApi.Call<PrestaShopDelivery>("PrestaShop", bNesisToken, "GetDelivery", id);
		}

		///<summary>
		/// Getting deliveries by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about deliveries use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Delivery in PrestaShopDelivery class.</returns>
		public PrestaShopDelivery[] GetDeliveriesByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopDelivery[]>("PrestaShop", bNesisToken, "GetDeliveriesByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting deliveries identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopDelivery.</returns>
		public PrestaShopIdentifier[] GetDeliveriesIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetDeliveriesIdentifiers");
		}

		///<summary>
		/// Adding new employee. 
		/// </summary>
		/// <param name="employee">Body of employee.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddEmployee(PrestaShopEmployeeIn employee)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddEmployee", employee);
		}

		///<summary>
		/// Update information in specified employee. 
		/// </summary>
		/// <param name="employee">Body of employee.</param>
		/// <returns>Return updated PrestaShopEmployee.</returns>
		public PrestaShopEmployee EditEmployee(PrestaShopEmployee employee)
		{
			return bNesisApi.Call<PrestaShopEmployee>("PrestaShop", bNesisToken, "EditEmployee", employee);
		}

		///<summary>
		/// Remove employee by identifier. 
		/// </summary>
		/// <param name="id">Identifier of employee.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteEmployee(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteEmployee", id);
		}

		///<summary>
		/// Getting employee by identifier. 
		/// </summary>
		/// <param name="id">Identifier of employee.</param>
		/// <returns>Return PrestaShopEmployee.</returns>
		public PrestaShopEmployee GetEmployee(Int32 id)
		{
			return bNesisApi.Call<PrestaShopEmployee>("PrestaShop", bNesisToken, "GetEmployee", id);
		}

		///<summary>
		/// Getting employees by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about employees use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Employee in PrestaShopEmployee class.</returns>
		public PrestaShopEmployee[] GetEmployeesByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopEmployee[]>("PrestaShop", bNesisToken, "GetEmployeesByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting employees identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopEmployee.</returns>
		public PrestaShopIdentifier[] GetEmployeesIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetEmployeesIdentifiers");
		}

		///<summary>
		/// Adding new group. 
		/// </summary>
		/// <param name="group">Body of group.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddGroup(PrestaShopGroupIn group)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddGroup", group);
		}

		///<summary>
		/// Update information in specified group. 
		/// </summary>
		/// <param name="group">Body of group.</param>
		/// <returns>Return updated PrestaShopGroup.</returns>
		public PrestaShopGroup EditGroup(PrestaShopGroup group)
		{
			return bNesisApi.Call<PrestaShopGroup>("PrestaShop", bNesisToken, "EditGroup", group);
		}

		///<summary>
		/// Remove group by identifier. 
		/// </summary>
		/// <param name="id">Identifier of group.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteGroup(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteGroup", id);
		}

		///<summary>
		/// Getting group by identifier. 
		/// </summary>
		/// <param name="id">Identifier of group.</param>
		/// <returns>Return PrestaShopGroup.</returns>
		public PrestaShopGroup GetGroup(Int32 id)
		{
			return bNesisApi.Call<PrestaShopGroup>("PrestaShop", bNesisToken, "GetGroup", id);
		}

		///<summary>
		/// Getting groups by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about groups use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Group in PrestaShopGroup class.</returns>
		public PrestaShopGroup[] GetGroupsByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopGroup[]>("PrestaShop", bNesisToken, "GetGroupsByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting groups identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopGroup.</returns>
		public PrestaShopIdentifier[] GetGroupsIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetGroupsIdentifiers");
		}

		///<summary>
		/// Adding new guest. 
		/// </summary>
		/// <param name="guest">Body of guest.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddGuest(PrestaShopGuestIn guest)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddGuest", guest);
		}

		///<summary>
		/// Update information in specified guest. 
		/// </summary>
		/// <param name="guest">Body of guest.</param>
		/// <returns>Return updated PrestaShopGuest.</returns>
		public PrestaShopGuest EditGuest(PrestaShopGuest guest)
		{
			return bNesisApi.Call<PrestaShopGuest>("PrestaShop", bNesisToken, "EditGuest", guest);
		}

		///<summary>
		/// Remove guest by identifier. 
		/// </summary>
		/// <param name="id">Identifier of guest.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteGuest(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteGuest", id);
		}

		///<summary>
		/// Getting guest by identifier. 
		/// </summary>
		/// <param name="id">Identifier of guest.</param>
		/// <returns>Return PrestaShopGuest.</returns>
		public PrestaShopGuest GetGuest(Int32 id)
		{
			return bNesisApi.Call<PrestaShopGuest>("PrestaShop", bNesisToken, "GetGuest", id);
		}

		///<summary>
		/// Getting guests by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about guests use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Guest in PrestaShopGuest class.</returns>
		public PrestaShopGuest[] GetGuestsByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopGuest[]>("PrestaShop", bNesisToken, "GetGuestsByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting guests identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopGuest.</returns>
		public PrestaShopIdentifier[] GetGuestsIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetGuestsIdentifiers");
		}

		///<summary>
		/// Adding new image type. 
		/// </summary>
		/// <param name="imageType">Body of image type.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddImageType(PrestaShopImageTypeIn imageType)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddImageType", imageType);
		}

		///<summary>
		/// Update information in specified image type. 
		/// </summary>
		/// <param name="imageType">Body of image type.</param>
		/// <returns>Return updated PrestaShopImageType.</returns>
		public PrestaShopImageType EditImageType(PrestaShopImageType imageType)
		{
			return bNesisApi.Call<PrestaShopImageType>("PrestaShop", bNesisToken, "EditImageType", imageType);
		}

		///<summary>
		/// Remove image type by identifier. 
		/// </summary>
		/// <param name="id">Identifier of image type.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteImageType(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteImageType", id);
		}

		///<summary>
		/// Getting image type by identifier. 
		/// </summary>
		/// <param name="id">Identifier of image type.</param>
		/// <returns>Return PrestaShopImageType.</returns>
		public PrestaShopImageType GetImageType(Int32 id)
		{
			return bNesisApi.Call<PrestaShopImageType>("PrestaShop", bNesisToken, "GetImageType", id);
		}

		///<summary>
		/// Getting image types by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about image types use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about ImageType in PrestaShopImageType class.</returns>
		public PrestaShopImageType[] GetImageTypesByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopImageType[]>("PrestaShop", bNesisToken, "GetImageTypesByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting image types identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopImageType.</returns>
		public PrestaShopIdentifier[] GetImageTypesIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetImageTypesIdentifiers");
		}

		///<summary>
		/// Adding new image. 
		/// </summary>
		/// <param name="image">Body of image.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddImage(PrestaShopImageIn image)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddImage", image);
		}

		///<summary>
		/// Update information in specified image. 
		/// </summary>
		/// <param name="image">Body of image.</param>
		/// <returns>Return updated PrestaShopImage.</returns>
		public PrestaShopImage EditImage(PrestaShopImage image)
		{
			return bNesisApi.Call<PrestaShopImage>("PrestaShop", bNesisToken, "EditImage", image);
		}

		///<summary>
		/// Remove image by identifier. 
		/// </summary>
		/// <param name="id">Identifier of image.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteImage(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteImage", id);
		}

		///<summary>
		/// Getting image by identifier. 
		/// </summary>
		/// <param name="id">Identifier of image.</param>
		/// <returns>Return PrestaShopImage.</returns>
		public PrestaShopImage GetImage(Int32 id)
		{
			return bNesisApi.Call<PrestaShopImage>("PrestaShop", bNesisToken, "GetImage", id);
		}

		///<summary>
		/// Getting images by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about images use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Image in PrestaShopImage class.</returns>
		public PrestaShopImage[] GetImagesByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopImage[]>("PrestaShop", bNesisToken, "GetImagesByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting images identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopImage.</returns>
		public PrestaShopIdentifier[] GetImagesIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetImagesIdentifiers");
		}

		///<summary>
		/// Adding new language. 
		/// </summary>
		/// <param name="language">Body of language.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddLanguage(PrestaShopLanguageIn language)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddLanguage", language);
		}

		///<summary>
		/// Update information in specified language. 
		/// </summary>
		/// <param name="language">Body of language.</param>
		/// <returns>Return updated PrestaShopLanguage.</returns>
		public PrestaShopLanguage EditLanguage(PrestaShopLanguage language)
		{
			return bNesisApi.Call<PrestaShopLanguage>("PrestaShop", bNesisToken, "EditLanguage", language);
		}

		///<summary>
		/// Adding new address. 
		/// </summary>
		/// <param name="address">Body of address.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddAddress(PrestaShopAddressIn address)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddAddress", address);
		}

		///<summary>
		/// Update information in specified address. 
		/// </summary>
		/// <param name="address">Body of address.</param>
		/// <returns>Return updated PrestaShopAddress.</returns>
		public PrestaShopAddress EditAddress(PrestaShopAddress address)
		{
			return bNesisApi.Call<PrestaShopAddress>("PrestaShop", bNesisToken, "EditAddress", address);
		}

		///<summary>
		/// Remove address by identifier. 
		/// </summary>
		/// <param name="id">Identifier of address.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteAddress(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteAddress", id);
		}

		///<summary>
		/// Getting address by identifier. 
		/// </summary>
		/// <param name="id">Identifier of address.</param>
		/// <returns>Return PrestaShopAddress.</returns>
		public PrestaShopAddress GetAddress(Int32 id)
		{
			return bNesisApi.Call<PrestaShopAddress>("PrestaShop", bNesisToken, "GetAddress", id);
		}

		///<summary>
		/// Getting addresses by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about addresses use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Address in PrestaShopAddress class.</returns>
		public PrestaShopAddress[] GetAddressesByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopAddress[]>("PrestaShop", bNesisToken, "GetAddressesByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting addresses identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopAddress.</returns>
		public PrestaShopIdentifier[] GetAddressesIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetAddressesIdentifiers");
		}

		///<summary>
		/// Adding new carrier. 
		/// </summary>
		/// <param name="carrier">Body of carrier.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddCarrier(PrestaShopCarrierIn carrier)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddCarrier", carrier);
		}

		///<summary>
		/// Update information in specified carrier. 
		/// </summary>
		/// <param name="carrier">Body of carrier.</param>
		/// <returns>Return updated PrestaShopCarrier.</returns>
		public PrestaShopCarrier EditCarrier(PrestaShopCarrier carrier)
		{
			return bNesisApi.Call<PrestaShopCarrier>("PrestaShop", bNesisToken, "EditCarrier", carrier);
		}

		///<summary>
		/// Remove carrier by identifier. 
		/// </summary>
		/// <param name="id">Identifier of carrier.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteCarrier(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteCarrier", id);
		}

		///<summary>
		/// Getting carrier by identifier. 
		/// </summary>
		/// <param name="id">Identifier of carrier.</param>
		/// <returns>Return PrestaShopCarrier.</returns>
		public PrestaShopCarrier GetCarrier(Int32 id)
		{
			return bNesisApi.Call<PrestaShopCarrier>("PrestaShop", bNesisToken, "GetCarrier", id);
		}

		///<summary>
		/// Getting carriers by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about carriers use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Carrier in PrestaShopCarrier class.</returns>
		public PrestaShopCarrier[] GetCarriersByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopCarrier[]>("PrestaShop", bNesisToken, "GetCarriersByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting carriers identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopCarrier.</returns>
		public PrestaShopIdentifier[] GetCarriersIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetCarriersIdentifiers");
		}

		///<summary>
		/// Adding new cart rule. 
		/// </summary>
		/// <param name="cartRule">Body of cart rule.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddCartRule(PrestaShopCartRuleIn cartRule)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddCartRule", cartRule);
		}

		///<summary>
		/// Update information in specified cart rule. 
		/// </summary>
		/// <param name="cartRule">Body of cart rule.</param>
		/// <returns>Return updated PrestaShopCartRule.</returns>
		public PrestaShopCartRule EditCartRule(PrestaShopCartRule cartRule)
		{
			return bNesisApi.Call<PrestaShopCartRule>("PrestaShop", bNesisToken, "EditCartRule", cartRule);
		}

		///<summary>
		/// Remove cart rule by identifier. 
		/// </summary>
		/// <param name="id">Identifier of cart rule.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteCartRule(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteCartRule", id);
		}

		///<summary>
		/// Getting cart rule by identifier. 
		/// </summary>
		/// <param name="id">Identifier of cart rule.</param>
		/// <returns>Return PrestaShopCartRule.</returns>
		public PrestaShopCartRule GetCartRule(Int32 id)
		{
			return bNesisApi.Call<PrestaShopCartRule>("PrestaShop", bNesisToken, "GetCartRule", id);
		}

		///<summary>
		/// Getting cart rules by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about cart rules use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about CartRule in PrestaShopCartRule class.</returns>
		public PrestaShopCartRule[] GetCartRulesByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopCartRule[]>("PrestaShop", bNesisToken, "GetCartRulesByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting cart rules identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopCartRule.</returns>
		public PrestaShopIdentifier[] GetCartRulesIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetCartRulesIdentifiers");
		}

		///<summary>
		/// Adding new cart. 
		/// </summary>
		/// <param name="cart">Body of cart.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddCart(PrestaShopCartIn cart)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddCart", cart);
		}

		///<summary>
		/// Update information in specified cart. 
		/// </summary>
		/// <param name="cart">Body of cart.</param>
		/// <returns>Return updated PrestaShopCart.</returns>
		public PrestaShopCart EditCart(PrestaShopCart cart)
		{
			return bNesisApi.Call<PrestaShopCart>("PrestaShop", bNesisToken, "EditCart", cart);
		}

		///<summary>
		/// Remove cart by identifier. 
		/// </summary>
		/// <param name="id">Identifier of cart.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteCart(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteCart", id);
		}

		///<summary>
		/// Getting cart by identifier. 
		/// </summary>
		/// <param name="id">Identifier of cart.</param>
		/// <returns>Return PrestaShopCart.</returns>
		public PrestaShopCart GetCart(Int32 id)
		{
			return bNesisApi.Call<PrestaShopCart>("PrestaShop", bNesisToken, "GetCart", id);
		}

		///<summary>
		/// Getting carts by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about carts use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Cart in PrestaShopCart class.</returns>
		public PrestaShopCart[] GetCartsByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopCart[]>("PrestaShop", bNesisToken, "GetCartsByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting carts identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopCart.</returns>
		public PrestaShopIdentifier[] GetCartsIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetCartsIdentifiers");
		}

		///<summary>
		/// Adding new category. 
		/// </summary>
		/// <param name="category">Body of category.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddCategory(PrestaShopCategoryIn category)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddCategory", category);
		}

		///<summary>
		/// Update information in specified category. 
		/// </summary>
		/// <param name="category">Body of category.</param>
		/// <returns>Return updated PrestaShopCategory.</returns>
		public PrestaShopCategory EditCategory(PrestaShopCategory category)
		{
			return bNesisApi.Call<PrestaShopCategory>("PrestaShop", bNesisToken, "EditCategory", category);
		}

		///<summary>
		/// Remove category by identifier. 
		/// </summary>
		/// <param name="id">Identifier of category.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteCategory(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteCategory", id);
		}

		///<summary>
		/// Getting category by identifier. 
		/// </summary>
		/// <param name="id">Identifier of category.</param>
		/// <returns>Return PrestaShopCategory.</returns>
		public PrestaShopCategory GetCategory(Int32 id)
		{
			return bNesisApi.Call<PrestaShopCategory>("PrestaShop", bNesisToken, "GetCategory", id);
		}

		///<summary>
		/// Getting categories by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about categories use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Category in PrestaShopCategory class.</returns>
		public PrestaShopCategory[] GetCategoriesByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopCategory[]>("PrestaShop", bNesisToken, "GetCategoriesByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting categories identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopCategory.</returns>
		public PrestaShopIdentifier[] GetCategoriesIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetCategoriesIdentifiers");
		}

		///<summary>
		/// Adding new combination. 
		/// </summary>
		/// <param name="combination">Body of combination.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddCombination(PrestaShopCombinationIn combination)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddCombination", combination);
		}

		///<summary>
		/// Update information in specified combination. 
		/// </summary>
		/// <param name="combination">Body of combination.</param>
		/// <returns>Return updated PrestaShopCombination.</returns>
		public PrestaShopCombination EditCombination(PrestaShopCombination combination)
		{
			return bNesisApi.Call<PrestaShopCombination>("PrestaShop", bNesisToken, "EditCombination", combination);
		}

		///<summary>
		/// Remove combination by identifier. 
		/// </summary>
		/// <param name="id">Identifier of combination.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteCombination(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteCombination", id);
		}

		///<summary>
		/// Getting combination by identifier. 
		/// </summary>
		/// <param name="id">Identifier of combination.</param>
		/// <returns>Return PrestaShopCombination.</returns>
		public PrestaShopCombination GetCombination(Int32 id)
		{
			return bNesisApi.Call<PrestaShopCombination>("PrestaShop", bNesisToken, "GetCombination", id);
		}

		///<summary>
		/// Getting combinations by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about combinations use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Combination in PrestaShopCombination class.</returns>
		public PrestaShopCombination[] GetCombinationsByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopCombination[]>("PrestaShop", bNesisToken, "GetCombinationsByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting combinations identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopCombination.</returns>
		public PrestaShopIdentifier[] GetCombinationsIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetCombinationsIdentifiers");
		}

		///<summary>
		/// Adding new configuration. 
		/// </summary>
		/// <param name="configuration">Body of configuration.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddConfiguration(PrestaShopConfigurationIn configuration)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddConfiguration", configuration);
		}

		///<summary>
		/// Update information in specified configuration. 
		/// </summary>
		/// <param name="configuration">Body of configuration.</param>
		/// <returns>Return updated PrestaShopConfiguration.</returns>
		public PrestaShopConfiguration EditConfiguration(PrestaShopConfiguration configuration)
		{
			return bNesisApi.Call<PrestaShopConfiguration>("PrestaShop", bNesisToken, "EditConfiguration", configuration);
		}

		///<summary>
		/// Remove configuration by identifier. 
		/// </summary>
		/// <param name="id">Identifier of configuration.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteConfiguration(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteConfiguration", id);
		}

		///<summary>
		/// Getting configuration by identifier. 
		/// </summary>
		/// <param name="id">Identifier of configuration.</param>
		/// <returns>Return PrestaShopConfiguration.</returns>
		public PrestaShopConfiguration GetConfiguration(Int32 id)
		{
			return bNesisApi.Call<PrestaShopConfiguration>("PrestaShop", bNesisToken, "GetConfiguration", id);
		}

		///<summary>
		/// Getting configurations by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about configurations use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Configuration in PrestaShopConfiguration class.</returns>
		public PrestaShopConfiguration[] GetConfigurationsByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopConfiguration[]>("PrestaShop", bNesisToken, "GetConfigurationsByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting configurations identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopConfiguration.</returns>
		public PrestaShopIdentifier[] GetConfigurationsIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetConfigurationsIdentifiers");
		}

		///<summary>
		/// Adding new contact. 
		/// </summary>
		/// <param name="contact">Body of contact.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddContact(PrestaShopContactIn contact)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddContact", contact);
		}

		///<summary>
		/// Update information in specified contact. 
		/// </summary>
		/// <param name="contact">Body of contact.</param>
		/// <returns>Return updated PrestaShopContact.</returns>
		public PrestaShopContact EditContact(PrestaShopContact contact)
		{
			return bNesisApi.Call<PrestaShopContact>("PrestaShop", bNesisToken, "EditContact", contact);
		}

		///<summary>
		/// Remove contact by identifier. 
		/// </summary>
		/// <param name="id">Identifier of contact.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteContact(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteContact", id);
		}

		///<summary>
		/// Getting contact by identifier. 
		/// </summary>
		/// <param name="id">Identifier of contact.</param>
		/// <returns>Return PrestaShopContact.</returns>
		public PrestaShopContact GetContact(Int32 id)
		{
			return bNesisApi.Call<PrestaShopContact>("PrestaShop", bNesisToken, "GetContact", id);
		}

		///<summary>
		/// Getting contacts by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about contacts use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Contact in PrestaShopContact class.</returns>
		public PrestaShopContact[] GetContactsByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopContact[]>("PrestaShop", bNesisToken, "GetContactsByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting contacts identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopContact.</returns>
		public PrestaShopIdentifier[] GetContactsIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetContactsIdentifiers");
		}

		///<summary>
		/// Adding new content management system. 
		/// </summary>
		/// <param name="contentManagementSystem">Body of content management system.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddContentManagementSystem(PrestaShopContentManagementSystemIn contentManagementSystem)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddContentManagementSystem", contentManagementSystem);
		}

		///<summary>
		/// Update information in specified content management system. 
		/// </summary>
		/// <param name="contentManagementSystem">Body of content management system.</param>
		/// <returns>Return updated PrestaShopContentManagementSystem.</returns>
		public PrestaShopContentManagementSystem EditContentManagementSystem(PrestaShopContentManagementSystem contentManagementSystem)
		{
			return bNesisApi.Call<PrestaShopContentManagementSystem>("PrestaShop", bNesisToken, "EditContentManagementSystem", contentManagementSystem);
		}

		///<summary>
		/// Remove content management system by identifier. 
		/// </summary>
		/// <param name="id">Identifier of content management system.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteContentManagementSystem(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteContentManagementSystem", id);
		}

		///<summary>
		/// Getting content management system by identifier. 
		/// </summary>
		/// <param name="id">Identifier of content management system.</param>
		/// <returns>Return PrestaShopContentManagementSystem.</returns>
		public PrestaShopContentManagementSystem GetContentManagementSystem(Int32 id)
		{
			return bNesisApi.Call<PrestaShopContentManagementSystem>("PrestaShop", bNesisToken, "GetContentManagementSystem", id);
		}

		///<summary>
		/// Getting content management system by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about content management system use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about ContentManagementSystem in PrestaShopContentManagementSystem class.</returns>
		public PrestaShopContentManagementSystem[] GetContentManagementSystemByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopContentManagementSystem[]>("PrestaShop", bNesisToken, "GetContentManagementSystemByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting content management system identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopContentManagementSystem.</returns>
		public PrestaShopIdentifier[] GetContentManagementSystemIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetContentManagementSystemIdentifiers");
		}

		///<summary>
		/// Adding new country. 
		/// </summary>
		/// <param name="country">Body of country.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddCountry(PrestaShopCountryIn country)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddCountry", country);
		}

		///<summary>
		/// Update information in specified country. 
		/// </summary>
		/// <param name="country">Body of country.</param>
		/// <returns>Return updated PrestaShopCountry.</returns>
		public PrestaShopCountry EditCountry(PrestaShopCountry country)
		{
			return bNesisApi.Call<PrestaShopCountry>("PrestaShop", bNesisToken, "EditCountry", country);
		}

		///<summary>
		/// Remove country by identifier. 
		/// </summary>
		/// <param name="id">Identifier of country.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteCountry(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteCountry", id);
		}

		///<summary>
		/// Getting country by identifier. 
		/// </summary>
		/// <param name="id">Identifier of country.</param>
		/// <returns>Return PrestaShopCountry.</returns>
		public PrestaShopCountry GetCountry(Int32 id)
		{
			return bNesisApi.Call<PrestaShopCountry>("PrestaShop", bNesisToken, "GetCountry", id);
		}

		///<summary>
		/// Getting countries by rendering options. 
		/// </summary>
		/// <param name="renderingOptions">For request specified information about countries use: display and filter or sort. Example:display=[firstname,birthday], display=[birthday]&filter[firstname]=[John], display=[id,lastname,firstname]&filter[id]=[1,10],display=full&sort=[lastname_ASC].</param>
		/// <returns>Returns only certain information about Country in PrestaShopCountry class.</returns>
		public PrestaShopCountry[] GetCountriesByRenderingOptions(PrestaShopRenderingOptions renderingOptions)
		{
			return bNesisApi.Call<PrestaShopCountry[]>("PrestaShop", bNesisToken, "GetCountriesByRenderingOptions", renderingOptions);
		}

		///<summary>
		/// Getting countries identifiers. 
		/// </summary>
		/// <returns>Return identifiers of PrestaShopCountry.</returns>
		public PrestaShopIdentifier[] GetCountriesIdentifiers()
		{
			return bNesisApi.Call<PrestaShopIdentifier[]>("PrestaShop", bNesisToken, "GetCountriesIdentifiers");
		}

		///<summary>
		/// Adding new currency. 
		/// </summary>
		/// <param name="currency">Body of currency.</param>
		/// <returns>If added return true.</returns>
		public Boolean AddCurrency(PrestaShopCurrencyIn currency)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "AddCurrency", currency);
		}

		///<summary>
		/// Update information in specified currency. 
		/// </summary>
		/// <param name="currency">Body of currency.</param>
		/// <returns>Return updated PrestaShopCurrency.</returns>
		public PrestaShopCurrency EditCurrency(PrestaShopCurrency currency)
		{
			return bNesisApi.Call<PrestaShopCurrency>("PrestaShop", bNesisToken, "EditCurrency", currency);
		}

		///<summary>
		/// Remove currency by identifier. 
		/// </summary>
		/// <param name="id">Identifier of currency.</param>
		/// <returns>If removed return true.</returns>
		public Boolean DeleteCurrency(Int32 id)
		{
			return bNesisApi.Call<Boolean>("PrestaShop", bNesisToken, "DeleteCurrency", id);
		}

		///<summary>
		/// Getting currency by identifier. 
		/// </summary>
		/// <param name="id">Identifier of currency.</param>
		/// <returns>Return PrestaShopCurrency.</returns>
		public PrestaShopCurrency GetCurrency(Int32 id)
		{
			return bNesisApi.Call<PrestaShopCurrency>("PrestaShop", bNesisToken, "GetCurrency", id);
		}
	}
	public class PrestaShopTax
	{
		public Int32 id { get; set; }

		public Single rate { get; set; }

		public Boolean active { get; set; }

		public Boolean deleted { get; set; }

		public string name { get; set; }

	}

	public class PrestaShopFilter
	{
		public string Key { get; set; }

		public string Value { get; set; }

	}

	///<summary>
	/// PrestaShop rendering options 
	/// </summary>
	public class PrestaShopRenderingOptions
	{
		public string Display { get; set; }

		/// <summary>
		/// Array of Filters 
		/// </summary>
		public PrestaShopFilter[] Filter { get; set; }

	}

	public class PrestaShopIdentifier
	{
		public Int32 id { get; set; }

		public Int32 id_feature_value { get; set; }

		public Int32 id_product_attribute { get; set; }

	}

	public class PrestaShopTranslatedConfigurationIn
	{
		public string value { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

		public string name { get; set; }

		public string id_shop_group { get; set; }

		public string id_show { get; set; }

	}

	public class PrestaShopTranslatedConfiguration
	{
		public Int32 id { get; set; }

		public string value { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

		public string name { get; set; }

		public string id_shop_group { get; set; }

		public string id_show { get; set; }

	}

	public class PrestaShopWarehouseProductLocation
	{
		public Int32 id { get; set; }

		public Int32 id_product { get; set; }

		public Int32 id_product_attribute { get; set; }

		public Int32 id_warehouse { get; set; }

		public string location { get; set; }

	}

	public class PrestaShopWeightRangeIn
	{
		public Int32 id_carrier { get; set; }

		public Single delimiter1 { get; set; }

		public Single delimiter2 { get; set; }

	}

	public class PrestaShopWeightRange
	{
		public Int32 id { get; set; }

		public Int32 id_carrier { get; set; }

		public Single delimiter1 { get; set; }

		public Single delimiter2 { get; set; }

	}

	public class PrestaShopZoneIn
	{
		public string name { get; set; }

		public Boolean active { get; set; }

	}

	public class PrestaShopZone
	{
		public Int32 id { get; set; }

		public string name { get; set; }

		public Boolean active { get; set; }

	}

	public class PrestaShopSpecificPrice
	{
		public Int32 id { get; set; }

		public Int32 id_shop_group { get; set; }

		public Int32 id_shop { get; set; }

		public Int32 id_cart { get; set; }

		public Int32 id_product { get; set; }

		public Int32 id_product_attribute { get; set; }

		public Int32 id_currency { get; set; }

		public Int32 id_country { get; set; }

		public Int32 id_group { get; set; }

		public Int32 id_customer { get; set; }

		public Int32 id_specific_price_rule { get; set; }

		public Single price { get; set; }

		public Int32 from_quantity { get; set; }

		public Single reduction { get; set; }

		public Int32 reduction_tax { get; set; }

		public string reduction_type { get; set; }

		public string from { get; set; }

		public string to { get; set; }

	}

	public class PrestaShopState
	{
		public Int32 id { get; set; }

		public Int32 id_zone { get; set; }

		public Int32 id_country { get; set; }

		public string iso_code { get; set; }

		public string name { get; set; }

		public Boolean active { get; set; }

	}

	public class PrestaShopStockMovementReasonIn
	{
		public Boolean sign { get; set; }

		public Boolean deleted { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

		public string name { get; set; }

	}

	public class PrestaShopStockMovementReason
	{
		public Int32 id { get; set; }

		public Boolean sign { get; set; }

		public Boolean deleted { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

		public string name { get; set; }

	}

	public class PrestaShopStockMovement
	{
		public Int32 id { get; set; }

		public Int32 id_employee { get; set; }

		public string empoyee_firstname { get; set; }

		public Int32 id_stock { get; set; }

		public Int32 physical_quantity { get; set; }

		public Int32 id_stock_mvt_reason { get; set; }

		public Int32 id_order { get; set; }

		public Int32 id_supply_order { get; set; }

		public Int32 sign { get; set; }

		public Single last_wa { get; set; }

		public Single current_wa { get; set; }

		public Single price_te { get; set; }

		public Int32 referer { get; set; }

		public string date_add { get; set; }

	}

	public class PrestaShopStock
	{
		public Int32 id { get; set; }

		public Int32 id_warehouse { get; set; }

		public Int32 id_product { get; set; }

		public Int32 id_product_attribute { get; set; }

		public string reference { get; set; }

		public string ean13 { get; set; }

		public string upc { get; set; }

		public Int32 physical_quantity { get; set; }

		public Int32 usable_quantity { get; set; }

		public Single price_te { get; set; }

	}

	public class PrestaShopStoreIn
	{
		public Int32 id_country { get; set; }

		public Int32 id_state { get; set; }

		public string[] hours { get; set; }

		public string name { get; set; }

		public string address1 { get; set; }

		public string address2 { get; set; }

		public string postcode { get; set; }

		public string city { get; set; }

		public Single latitude { get; set; }

		public Single longitude { get; set; }

		public string phone { get; set; }

		public string fax { get; set; }

		public string note { get; set; }

		public string email { get; set; }

		public Boolean active { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

	}

	public class PrestaShopStore
	{
		public Int32 id { get; set; }

		public Int32 id_country { get; set; }

		public Int32 id_state { get; set; }

		public string[] hours { get; set; }

		public string name { get; set; }

		public string address1 { get; set; }

		public string address2 { get; set; }

		public string postcode { get; set; }

		public string city { get; set; }

		public Single latitude { get; set; }

		public Single longitude { get; set; }

		public string phone { get; set; }

		public string fax { get; set; }

		public string note { get; set; }

		public string email { get; set; }

		public Boolean active { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

	}

	public class PrestaShopSupplierIn
	{
		public string link_rewrite { get; set; }

		public string name { get; set; }

		public Boolean active { get; set; }

		public string date_add { get; set; }

		public string date_up { get; set; }

		public string description { get; set; }

		public string meta_title { get; set; }

		public string meta_description { get; set; }

		public string meta_keywords { get; set; }

	}

	public class PrestaShopSupplier
	{
		public Int32 id { get; set; }

		public string link_rewrite { get; set; }

		public string name { get; set; }

		public Boolean active { get; set; }

		public string date_add { get; set; }

		public string date_up { get; set; }

		public string description { get; set; }

		public string meta_title { get; set; }

		public string meta_description { get; set; }

		public string meta_keywords { get; set; }

	}

	public class PrestaShopSupplyOrderDetail
	{
		public Int32 id { get; set; }

		public Int32 id_supply_order { get; set; }

		public Int32 id_product { get; set; }

		public Int32 id_product_attribute { get; set; }

		public string reference { get; set; }

		public string supplier_reference { get; set; }

		public Int32 name { get; set; }

		public Int32 ean13 { get; set; }

		public string isbn { get; set; }

		public string upc { get; set; }

		public Int32 id_currency { get; set; }

		public Single exchange_rate { get; set; }

		public Single unit_price_te { get; set; }

		public Int32 quantity_expected { get; set; }

		public Int32 quantity_received { get; set; }

		public Single price_te { get; set; }

		public Single discount_rate { get; set; }

		public Single discount_value_te { get; set; }

		public Single price_with_discount_te { get; set; }

		public Int32 tax_rate { get; set; }

		public Single tax_value { get; set; }

		public Single price_ti { get; set; }

		public Single tax_value_with_order_discount { get; set; }

		public Single price_with_order_discount_te { get; set; }

	}

	public class PrestaShopSupplyOrderHistory
	{
		public Int32 id { get; set; }

		public Int32 id_supply_order { get; set; }

		public Int32 id_employee { get; set; }

		public string employee_firstname { get; set; }

		public string employee_lastname { get; set; }

		public Int32 id_state { get; set; }

		public string date_add { get; set; }

	}

	public class PrestaShopSupplyOrderReceiptHistory
	{
		public Int32 id { get; set; }

		public Int32 id_supply_order_detail { get; set; }

		public Int32 id_employee { get; set; }

		public string employee_firstname { get; set; }

		public string employee_lastname { get; set; }

		public Int32 id_supply_order_state { get; set; }

		public Int32 quantity { get; set; }

		public string date_add { get; set; }

	}

	public class PrestaShopSupplyOrderState
	{
		public Int32 id { get; set; }

		public Boolean delivery_note { get; set; }

		public Boolean editable { get; set; }

		public Int32 receipt_state { get; set; }

		public Boolean pending_receipt { get; set; }

		public Boolean enclosed { get; set; }

		public string color { get; set; }

		public string name { get; set; }

	}

	public class PrestaShopSupplyOrder
	{
		public Int32 id { get; set; }

		public Int32 id_supplier { get; set; }

		public string supplier_name { get; set; }

		public Int32 id_lang { get; set; }

		public Int32 id_warehouse { get; set; }

		public Int32 id_supply_order_state { get; set; }

		public Int32 id_currency { get; set; }

		public Int32 id_ref_currency { get; set; }

		public string reference { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

		public string date_delivery_expected { get; set; }

		public Single total_te { get; set; }

		public Single total_with_discount_te { get; set; }

		public Single total_ti { get; set; }

		public Single total_tax { get; set; }

		public Single discount_rate { get; set; }

		public Single discount_value_te { get; set; }

		public Boolean is_template { get; set; }

	}

	public class PrestaShopTagIn
	{
		public Int32 id_lang { get; set; }

		public string name { get; set; }

	}

	public class PrestaShopTag
	{
		public Int32 id { get; set; }

		public Int32 id_lang { get; set; }

		public string name { get; set; }

	}

	public class PrestaShopTaxRuleGroupIn
	{
		public string name { get; set; }

		public Boolean active { get; set; }

		public Boolean deleted { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

	}

	public class PrestaShopTaxRuleGroup
	{
		public Int32 id { get; set; }

		public string name { get; set; }

		public Boolean active { get; set; }

		public Boolean deleted { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

	}

	public class PrestaShopTaxRuleIn
	{
		public Int32 id_tax_rules_group { get; set; }

		public Int32 id_state { get; set; }

		public Int32 id_country { get; set; }

		public string zipcode_from { get; set; }

		public string zipcode_to { get; set; }

		public Int32 id_tax { get; set; }

		public Int32 behavior { get; set; }

		public string description { get; set; }

	}

	public class PrestaShopTaxRule
	{
		public Int32 id { get; set; }

		public Int32 id_tax_rules_group { get; set; }

		public Int32 id_state { get; set; }

		public Int32 id_country { get; set; }

		public string zipcode_from { get; set; }

		public string zipcode_to { get; set; }

		public Int32 id_tax { get; set; }

		public Int32 behavior { get; set; }

		public string description { get; set; }

	}

	public class PrestaShopTaxIn
	{
		public Single rate { get; set; }

		public Boolean active { get; set; }

		public Boolean deleted { get; set; }

		public string name { get; set; }

	}

	public class PrestaShopProductFeatureValueIn
	{
		public Int32 id_feature { get; set; }

		public Int32 custom { get; set; }

		public string value { get; set; }

	}

	public class PrestaShopProductFeatureValue
	{
		public Int32 id { get; set; }

		public Int32 id_feature { get; set; }

		public Int32 custom { get; set; }

		public string value { get; set; }

	}

	public class PrestaShopProductFeatureIn
	{
		public Int32 position { get; set; }

		public string name { get; set; }

	}

	public class PrestaShopProductFeature
	{
		public Int32 id { get; set; }

		public Int32 position { get; set; }

		public string name { get; set; }

	}

	public class PrestaShopProductOptionValueIn
	{
		public Int32 id_attribute_group { get; set; }

		public string color { get; set; }

		public Int32 position { get; set; }

		public string name { get; set; }

	}

	public class PrestaShopProductOptionValue
	{
		public Int32 id { get; set; }

		public Int32 id_attribute_group { get; set; }

		public string color { get; set; }

		public Int32 position { get; set; }

		public string name { get; set; }

	}

	public class PrestaShopOrderRow
	{
		public Int32 id { get; set; }

		public Int32 product_id { get; set; }

		public Int32 product_attribute_id { get; set; }

		public Int32 product_quantity { get; set; }

		public string product_name { get; set; }

		public string product_reference { get; set; }

		public string product_ean13 { get; set; }

		public string product_isbn { get; set; }

		public string product_upc { get; set; }

		public Single product_price { get; set; }

		public Single unit_price_tax_incl { get; set; }

		public Single unit_price_tax_excl { get; set; }

	}

	public class PrestaShopAssociations
	{
		public PrestaShopIdentifier[] categories { get; set; }

		public PrestaShopIdentifier[] groups { get; set; }

		public PrestaShopIdentifier[] product_option_values { get; set; }

		public PrestaShopIdentifier[] images { get; set; }

		public PrestaShopIdentifier[] customer_messages { get; set; }

		public PrestaShopIdentifier[] addresses { get; set; }

		public PrestaShopIdentifier[] combinations { get; set; }

		public PrestaShopOrderRow[] order_rows { get; set; }

		public PrestaShopIdentifier[] product_features { get; set; }

		public PrestaShopIdentifier[] stock_avaibles { get; set; }

	}

	public class PrestaShopProductOptionIn
	{
		public Boolean is_color_group { get; set; }

		public string group_type { get; set; }

		public Int32 position { get; set; }

		public string name { get; set; }

		public string public_name { get; set; }

		public PrestaShopAssociations associations { get; set; }

	}

	public class PrestaShopProductOption
	{
		public Int32 id { get; set; }

		public Boolean is_color_group { get; set; }

		public string group_type { get; set; }

		public Int32 position { get; set; }

		public string name { get; set; }

		public string public_name { get; set; }

		public PrestaShopAssociations associations { get; set; }

	}

	public class PrestaShopProductSupplierIn
	{
		public Int32 id_product { get; set; }

		public Int32 id_product_attribute { get; set; }

		public Int32 id_supplier { get; set; }

		public Int32 id_currency { get; set; }

		public string product_supplier_reference { get; set; }

		public Single product_supplier_price_te { get; set; }

	}

	public class PrestaShopProductSupplier
	{
		public Int32 id { get; set; }

		public Int32 id_product { get; set; }

		public Int32 id_product_attribute { get; set; }

		public Int32 id_supplier { get; set; }

		public Int32 id_currency { get; set; }

		public string product_supplier_reference { get; set; }

		public Single product_supplier_price_te { get; set; }

	}

	public class PrestaShopProductIn
	{
		public Int32 id_manufacturer { get; set; }

		public Int32 id_supplier { get; set; }

		public Int32 id_category_default { get; set; }

		public Boolean is_new { get; set; }

		public Int32 cache_default_attribute { get; set; }

		public Int32 id_default_image { get; set; }

		public Int32 id_default_combination { get; set; }

		public Int32 id_tax_rules_group { get; set; }

		public Int32 position_in_category { get; set; }

		public string manufacturer_name { get; set; }

		public Int32 quantity { get; set; }

		public string type { get; set; }

		public Int32 id_shop_default { get; set; }

		public string reference { get; set; }

		public string supplier_reference { get; set; }

		public string location { get; set; }

		public Single width { get; set; }

		public Single height { get; set; }

		public Single depth { get; set; }

		public Single weight { get; set; }

		public Int32 quantity_discount { get; set; }

		public Boolean ean13 { get; set; }

		public string isbn { get; set; }

		public string upc { get; set; }

		public Boolean cache_is_pack { get; set; }

		public Boolean cache_has_attachments { get; set; }

		public Boolean is_virtual { get; set; }

		public Int32 state { get; set; }

		public Boolean on_sale { get; set; }

		public Boolean online_only { get; set; }

		public Single ecotax { get; set; }

		public Int32 minimal_quantity { get; set; }

		public Single price { get; set; }

		public Single wholesale_price { get; set; }

		public string unity { get; set; }

		public Single unit_price_ratio { get; set; }

		public Single additional_shipping_cost { get; set; }

		public Boolean customizable { get; set; }

		public Boolean text_fields { get; set; }

		public Boolean uploadable_files { get; set; }

		public Boolean active { get; set; }

		public string redirect_type { get; set; }

		public Int32 id_type_redirected { get; set; }

		public Boolean available_for_order { get; set; }

		public string available_date { get; set; }

		public Boolean show_condition { get; set; }

		public string condition { get; set; }

		public Boolean show_price { get; set; }

		public Boolean indexed { get; set; }

		public string visibility { get; set; }

		public Boolean advanced_stock_management { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

		public Int32 intpack_stock_type { get; set; }

		public string meta_description { get; set; }

		public string meta_keywords { get; set; }

		public string meta_title { get; set; }

		public string link_rewrite { get; set; }

		public string name { get; set; }

		public string description { get; set; }

		public string description_short { get; set; }

		public string available_now { get; set; }

		public string available_later { get; set; }

		public PrestaShopAssociations associations { get; set; }

	}

	public class PrestaShopProduct
	{
		public Int32 id { get; set; }

		public Int32 id_manufacturer { get; set; }

		public Int32 id_supplier { get; set; }

		public Int32 id_category_default { get; set; }

		public Boolean is_new { get; set; }

		public Int32 cache_default_attribute { get; set; }

		public Int32 id_default_image { get; set; }

		public Int32 id_default_combination { get; set; }

		public Int32 id_tax_rules_group { get; set; }

		public Int32 position_in_category { get; set; }

		public string manufacturer_name { get; set; }

		public Int32 quantity { get; set; }

		public string type { get; set; }

		public Int32 id_shop_default { get; set; }

		public string reference { get; set; }

		public string supplier_reference { get; set; }

		public string location { get; set; }

		public Single width { get; set; }

		public Single height { get; set; }

		public Single depth { get; set; }

		public Single weight { get; set; }

		public Int32 quantity_discount { get; set; }

		public Boolean ean13 { get; set; }

		public string isbn { get; set; }

		public string upc { get; set; }

		public Boolean cache_is_pack { get; set; }

		public Boolean cache_has_attachments { get; set; }

		public Boolean is_virtual { get; set; }

		public Int32 state { get; set; }

		public Boolean on_sale { get; set; }

		public Boolean online_only { get; set; }

		public Single ecotax { get; set; }

		public Int32 minimal_quantity { get; set; }

		public Single price { get; set; }

		public Single wholesale_price { get; set; }

		public string unity { get; set; }

		public Single unit_price_ratio { get; set; }

		public Single additional_shipping_cost { get; set; }

		public Boolean customizable { get; set; }

		public Boolean text_fields { get; set; }

		public Boolean uploadable_files { get; set; }

		public Boolean active { get; set; }

		public string redirect_type { get; set; }

		public Int32 id_type_redirected { get; set; }

		public Boolean available_for_order { get; set; }

		public string available_date { get; set; }

		public Boolean show_condition { get; set; }

		public string condition { get; set; }

		public Boolean show_price { get; set; }

		public Boolean indexed { get; set; }

		public string visibility { get; set; }

		public Boolean advanced_stock_management { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

		public Int32 intpack_stock_type { get; set; }

		public string meta_description { get; set; }

		public string meta_keywords { get; set; }

		public string meta_title { get; set; }

		public string link_rewrite { get; set; }

		public string name { get; set; }

		public string description { get; set; }

		public string description_short { get; set; }

		public string available_now { get; set; }

		public string available_later { get; set; }

		public PrestaShopAssociations associations { get; set; }

	}

	public class PrestaShopShopGroupIn
	{
		public string name { get; set; }

		public Boolean share_customer { get; set; }

		public Boolean share_order { get; set; }

		public Boolean share_stock { get; set; }

		public Boolean active { get; set; }

		public Boolean deleted { get; set; }

	}

	public class PrestaShopShopGroup
	{
		public Int32 id { get; set; }

		public string name { get; set; }

		public Boolean share_customer { get; set; }

		public Boolean share_order { get; set; }

		public Boolean share_stock { get; set; }

		public Boolean active { get; set; }

		public Boolean deleted { get; set; }

	}

	public class PrestaShopShopUrlIn
	{
		public Int32 id_shop { get; set; }

		public string domain { get; set; }

		public string domain_ssl { get; set; }

		public string physical_uri { get; set; }

		public string virtual_uri { get; set; }

		public Boolean main { get; set; }

		public Boolean active { get; set; }

	}

	public class PrestaShopShopUrl
	{
		public Int32 id { get; set; }

		public Int32 id_shop { get; set; }

		public string domain { get; set; }

		public string domain_ssl { get; set; }

		public string physical_uri { get; set; }

		public string virtual_uri { get; set; }

		public Boolean main { get; set; }

		public Boolean active { get; set; }

	}

	public class PrestaShopShopIn
	{
		public Int32 id_shop_group { get; set; }

		public Int32 id_category { get; set; }

		public Boolean active { get; set; }

		public Boolean deleted { get; set; }

		public string name { get; set; }

		public string theme_name { get; set; }

	}

	public class PrestaShopShop
	{
		public Int32 id { get; set; }

		public Int32 id_shop_group { get; set; }

		public Int32 id_category { get; set; }

		public Boolean active { get; set; }

		public Boolean deleted { get; set; }

		public string name { get; set; }

		public string theme_name { get; set; }

	}

	public class PrestaShopSpecificPriceRuleIn
	{
		public Int32 id_shop { get; set; }

		public Int32 id_country { get; set; }

		public Int32 id_currency { get; set; }

		public Int32 id_group { get; set; }

		public string name { get; set; }

		public Int32 from_quantity { get; set; }

		public Single price { get; set; }

		public Single reduction { get; set; }

		public Int32 reduction_tax { get; set; }

		public string reduction_type { get; set; }

		public string from { get; set; }

		public string to { get; set; }

	}

	public class PrestaShopSpecificPriceRule
	{
		public Int32 id { get; set; }

		public Int32 id_shop { get; set; }

		public Int32 id_country { get; set; }

		public Int32 id_currency { get; set; }

		public Int32 id_group { get; set; }

		public string name { get; set; }

		public Int32 from_quantity { get; set; }

		public Single price { get; set; }

		public Single reduction { get; set; }

		public Int32 reduction_tax { get; set; }

		public string reduction_type { get; set; }

		public string from { get; set; }

		public string to { get; set; }

	}

	public class PrestaShopSpecificPriceIn
	{
		public Int32 id_shop_group { get; set; }

		public Int32 id_shop { get; set; }

		public Int32 id_cart { get; set; }

		public Int32 id_product { get; set; }

		public Int32 id_product_attribute { get; set; }

		public Int32 id_currency { get; set; }

		public Int32 id_country { get; set; }

		public Int32 id_group { get; set; }

		public Int32 id_customer { get; set; }

		public Int32 id_specific_price_rule { get; set; }

		public Single price { get; set; }

		public Int32 from_quantity { get; set; }

		public Single reduction { get; set; }

		public Int32 reduction_tax { get; set; }

		public string reduction_type { get; set; }

		public string from { get; set; }

		public string to { get; set; }

	}

	public class PrestaShopLanguage
	{
		public Int32 id { get; set; }

		public string name { get; set; }

		public string iso_code { get; set; }

		public string locale { get; set; }

		public string language_code { get; set; }

		public Boolean active { get; set; }

		public Boolean is_rtl { get; set; }

		public string date_format_lite { get; set; }

		public string date_format_full { get; set; }

	}

	public class PrestaShopManufacturerIn
	{
		public Boolean active { get; set; }

		public string link_rewrite { get; set; }

		public string name { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

		public string description { get; set; }

		public string short_description { get; set; }

		public string meta_title { get; set; }

		public string meta_description { get; set; }

		public string meta_keywords { get; set; }

		public PrestaShopAssociations associations { get; set; }

	}

	public class PrestaShopManufacturer
	{
		public Int32 id { get; set; }

		public Boolean active { get; set; }

		public string link_rewrite { get; set; }

		public string name { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

		public string description { get; set; }

		public string short_description { get; set; }

		public string meta_title { get; set; }

		public string meta_description { get; set; }

		public string meta_keywords { get; set; }

		public PrestaShopAssociations associations { get; set; }

	}

	public class PrestaShopMessageIn
	{
		public string message { get; set; }

		public Int32 id_cart { get; set; }

		public Int32 id_order { get; set; }

		public Int32 id_customer { get; set; }

		public Int32 id_employee { get; set; }

		public Boolean is_private { get; set; }

		public string date_add { get; set; }

	}

	public class PrestaShopMessage
	{
		public Int32 id { get; set; }

		public string message { get; set; }

		public Int32 id_cart { get; set; }

		public Int32 id_order { get; set; }

		public Int32 id_customer { get; set; }

		public Int32 id_employee { get; set; }

		public Boolean is_private { get; set; }

		public string date_add { get; set; }

	}

	public class PrestaShopOrderCarrierIn
	{
		public Int32 id_order { get; set; }

		public Int32 id_carrier { get; set; }

		public Int32 id_order_invoice { get; set; }

		public Single weight { get; set; }

		public Single shipping_cost_tax_excl { get; set; }

		public Single shipping_cost_tax_incl { get; set; }

		public string tracking_number { get; set; }

		public string date_add { get; set; }

	}

	public class PrestaShopOrderCarrier
	{
		public Int32 id { get; set; }

		public Int32 id_order { get; set; }

		public Int32 id_carrier { get; set; }

		public Int32 id_order_invoice { get; set; }

		public Single weight { get; set; }

		public Single shipping_cost_tax_excl { get; set; }

		public Single shipping_cost_tax_incl { get; set; }

		public string tracking_number { get; set; }

		public string date_add { get; set; }

	}

	public class PrestaShopOrderDetail
	{
		public Int32 id { get; set; }

		public Int32 id_order { get; set; }

		public Int32 id_order_invoice { get; set; }

		public Int32 id_warehouse { get; set; }

		public Int32 id_shop { get; set; }

		public Int32 id_customization { get; set; }

		public Int32 id_tax_rules_group { get; set; }

		public Int32 product_id { get; set; }

		public Int32 product_attribute_id { get; set; }

		public Int32 product_quantity_reinjected { get; set; }

		public Single group_reduction { get; set; }

		public Int32 discount_quantity_applied { get; set; }

		public string download_hash { get; set; }

		public string download_deadline { get; set; }

		public Int32 download_nb { get; set; }

		public string product_name { get; set; }

		public Int32 product_quantity { get; set; }

		public Int32 product_quantity_in_stock { get; set; }

		public Int32 product_quantity_return { get; set; }

		public Int32 product_quantity_refunded { get; set; }

		public Single product_price { get; set; }

		public Single reduction_percent { get; set; }

		public Single reduction_amount { get; set; }

		public Single reduction_amount_tax_incl { get; set; }

		public Single reduction_amount_tax_excl { get; set; }

		public Single product_quantity_discount { get; set; }

		public string product_ean13 { get; set; }

		public string product_isbn { get; set; }

		public string product_upc { get; set; }

		public string product_reference { get; set; }

		public string product_supplier_reference { get; set; }

		public Single product_weight { get; set; }

		public Int32 tax_computation_method { get; set; }

		public Single ecotax { get; set; }

		public Single ecotax_tax_rate { get; set; }

		public Single unit_price_tax_incl { get; set; }

		public Single unit_price_tax_excl { get; set; }

		public Single total_price_tax_incl { get; set; }

		public Single total_price_tax_excl { get; set; }

		public Single total_shipping_price_tax_excl { get; set; }

		public Single total_shipping_price_tax_incl { get; set; }

		public Single purchase_supplier_price { get; set; }

		public Single original_product_price { get; set; }

		public Single original_wholesale_price { get; set; }

	}

	public class PrestaShopOrderHistory
	{
		public Int32 id { get; set; }

		public Int32 id_employee { get; set; }

		public Int32 id_order_state { get; set; }

		public Int32 id_order { get; set; }

		public string date_add { get; set; }

	}

	public class PrestaShopOrderInvoiceIn
	{
		public Int32 id_order { get; set; }

		public Int32 number { get; set; }

		public Int32 delivery_number { get; set; }

		public string delivery_date { get; set; }

		public Single total_discount_tax_excl { get; set; }

		public Single total_discount_tax_incl { get; set; }

		public Single total_paid_tax_excl { get; set; }

		public Single total_paid_tax_incl { get; set; }

		public Single total_products { get; set; }

		public Single total_products_wt { get; set; }

		public Single total_shipping_tax_excl { get; set; }

		public Single total_shipping_tax_incl { get; set; }

		public Single shipping_tax_computation_method { get; set; }

		public Single total_wrapping_tax_excl { get; set; }

		public Single total_wrapping_tax_incl { get; set; }

		public string shop_address { get; set; }

		public string note { get; set; }

		public string date_add { get; set; }

	}

	public class PrestaShopOrderInvoice
	{
		public Int32 id { get; set; }

		public Int32 id_order { get; set; }

		public Int32 number { get; set; }

		public Int32 delivery_number { get; set; }

		public string delivery_date { get; set; }

		public Single total_discount_tax_excl { get; set; }

		public Single total_discount_tax_incl { get; set; }

		public Single total_paid_tax_excl { get; set; }

		public Single total_paid_tax_incl { get; set; }

		public Single total_products { get; set; }

		public Single total_products_wt { get; set; }

		public Single total_shipping_tax_excl { get; set; }

		public Single total_shipping_tax_incl { get; set; }

		public Single shipping_tax_computation_method { get; set; }

		public Single total_wrapping_tax_excl { get; set; }

		public Single total_wrapping_tax_incl { get; set; }

		public string shop_address { get; set; }

		public string note { get; set; }

		public string date_add { get; set; }

	}

	public class PrestaShopOrderPaymentIn
	{
		public string order_reference { get; set; }

		public Int32 id_currency { get; set; }

		public Single amount { get; set; }

		public string payment_method { get; set; }

		public Single conversion_rate { get; set; }

		public string transaction_id { get; set; }

		public string card_number { get; set; }

		public string card_brand { get; set; }

		public string card_expiration { get; set; }

		public string card_holder { get; set; }

		public string date_add { get; set; }

	}

	public class PrestaShopOrderPayment
	{
		public Int32 id { get; set; }

		public string order_reference { get; set; }

		public Int32 id_currency { get; set; }

		public Single amount { get; set; }

		public string payment_method { get; set; }

		public Single conversion_rate { get; set; }

		public string transaction_id { get; set; }

		public string card_number { get; set; }

		public string card_brand { get; set; }

		public string card_expiration { get; set; }

		public string card_holder { get; set; }

		public string date_add { get; set; }

	}

	public class PrestaShopOrderSlipIn
	{
		public Int32 id_customer { get; set; }

		public Int32 id_order { get; set; }

		public Single conversion_rate { get; set; }

		public Single total_products_tax_excl { get; set; }

		public Single total_products_tax_incl { get; set; }

		public Single total_shipping_tax_excl { get; set; }

		public Single total_shipping_tax_incl { get; set; }

		public Int32 amount { get; set; }

		public Int32 shipping_cost { get; set; }

		public Int32 shipping_cost_amount { get; set; }

		public Int32 partial { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

		public Int32 order_slip_type { get; set; }

	}

	public class PrestaShopOrderSlip
	{
		public Int32 id { get; set; }

		public Int32 id_customer { get; set; }

		public Int32 id_order { get; set; }

		public Single conversion_rate { get; set; }

		public Single total_products_tax_excl { get; set; }

		public Single total_products_tax_incl { get; set; }

		public Single total_shipping_tax_excl { get; set; }

		public Single total_shipping_tax_incl { get; set; }

		public Int32 amount { get; set; }

		public Int32 shipping_cost { get; set; }

		public Int32 shipping_cost_amount { get; set; }

		public Int32 partial { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

		public Int32 order_slip_type { get; set; }

	}

	public class PrestaShopOrderState
	{
		public Int32 id { get; set; }

		public Boolean unremovable { get; set; }

		public Boolean delivery { get; set; }

		public Boolean hidden { get; set; }

		public Boolean send_email { get; set; }

		public string module_name { get; set; }

		public Boolean invoice { get; set; }

		public string color { get; set; }

		public Boolean logable { get; set; }

		public Boolean shipped { get; set; }

		public Boolean paid { get; set; }

		public Boolean pdf_delivery { get; set; }

		public Boolean pdf_invoice { get; set; }

		public Boolean deleted { get; set; }

		public string name { get; set; }

		public string template { get; set; }

	}

	public class PrestaShopOrder
	{
		public Int32 id { get; set; }

		public Int32 id_address_delivery { get; set; }

		public Int32 id_address_invoice { get; set; }

		public Int32 id_cart { get; set; }

		public Int32 id_currency { get; set; }

		public Int32 id_lang { get; set; }

		public Int32 id_customer { get; set; }

		public Int32 id_carrier { get; set; }

		public Int32 current_state { get; set; }

		public string module { get; set; }

		public Int32 invoice_number { get; set; }

		public string invoice_date { get; set; }

		public Int32 delivery_number { get; set; }

		public string delivery_date { get; set; }

		public Boolean valid { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

		public string shipping_number { get; set; }

		public Int32 id_shop_group { get; set; }

		public Int32 id_shop { get; set; }

		public string secure_key { get; set; }

		public string payment { get; set; }

		public Boolean recyclable { get; set; }

		public Boolean gift { get; set; }

		public string gift_message { get; set; }

		public Boolean mobile_theme { get; set; }

		public Single total_discounts { get; set; }

		public Single total_discounts_tax_incl { get; set; }

		public Single total_discounts_tax_excl { get; set; }

		public Single total_paid { get; set; }

		public Single total_paid_tax_incl { get; set; }

		public Single total_paid_tax_excl { get; set; }

		public Single total_paid_real { get; set; }

		public Single total_products { get; set; }

		public Single total_products_wt { get; set; }

		public Single total_shipping { get; set; }

		public Single total_shipping_tax_incl { get; set; }

		public Single total_shipping_tax_excl { get; set; }

		public Single carrier_tax_rate { get; set; }

		public Single total_wrapping { get; set; }

		public Single total_wrapping_tax_incl { get; set; }

		public Single total_wrapping_tax_excl { get; set; }

		public Int32 round_mode { get; set; }

		public Int32 round_type { get; set; }

		public Single conversion_rate { get; set; }

		public string reference { get; set; }

		public PrestaShopAssociations associations { get; set; }

	}

	public class PrestaShopPriceRangeIn
	{
		public Int32 id_carrier { get; set; }

		public Single delimiter1 { get; set; }

		public Single delimiter2 { get; set; }

	}

	public class PrestaShopPriceRange
	{
		public Int32 id { get; set; }

		public Int32 id_carrier { get; set; }

		public Single delimiter1 { get; set; }

		public Single delimiter2 { get; set; }

	}

	public class PrestaShopProductCustomizationFieldIn
	{
		public Int32 id { get; set; }

		public Int32 id_product { get; set; }

		public Int32 type { get; set; }

		public Boolean required { get; set; }

		public Boolean is_module { get; set; }

		public string name { get; set; }

	}

	public class PrestaShopProductCustomizationField
	{
		public Int32 id { get; set; }

		public Int32 id_product { get; set; }

		public Int32 type { get; set; }

		public Boolean required { get; set; }

		public Boolean is_module { get; set; }

		public string name { get; set; }

	}

	public class PrestaShopCurrency
	{
		public Int32 id { get; set; }

		public string name { get; set; }

		public string iso_code { get; set; }

		public Single conversion_rate { get; set; }

		public Boolean deleted { get; set; }

		public Boolean active { get; set; }

	}

	public class PrestaShopCustomerMessageIn
	{
		public Int32 id_employee { get; set; }

		public Int32 id_customer_thread { get; set; }

		public string ip_address { get; set; }

		public string message { get; set; }

		public string file_name { get; set; }

		public string user_agent { get; set; }

		public Boolean is_private { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

		public Boolean read { get; set; }

	}

	public class PrestaShopCustomerMessage
	{
		public Int32 id { get; set; }

		public Int32 id_employee { get; set; }

		public Int32 id_customer_thread { get; set; }

		public string ip_address { get; set; }

		public string message { get; set; }

		public string file_name { get; set; }

		public string user_agent { get; set; }

		public Boolean is_private { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

		public Boolean read { get; set; }

	}

	public class PrestaShopCustomerThreadIn
	{
		public Int32 id_lang { get; set; }

		public Int32 id_shop { get; set; }

		public Int32 id_customer { get; set; }

		public Int32 id_order { get; set; }

		public Int32 id_product { get; set; }

		public Int32 id_contact { get; set; }

		public string email { get; set; }

		public string token { get; set; }

		public string status { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

	}

	public class PrestaShopCustomerThread
	{
		public Int32 id { get; set; }

		public Int32 id_lang { get; set; }

		public Int32 id_shop { get; set; }

		public Int32 id_customer { get; set; }

		public Int32 id_order { get; set; }

		public Int32 id_product { get; set; }

		public Int32 id_contact { get; set; }

		public string email { get; set; }

		public string token { get; set; }

		public string status { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

	}

	public class PrestaShopCustomerIn
	{
		public Int32 id_default_group { get; set; }

		public Int32 id_lang { get; set; }

		public string newsletter_date_add { get; set; }

		public string ip_registration_newsletter { get; set; }

		public string secure_key { get; set; }

		public Boolean deleted { get; set; }

		public string passwd { get; set; }

		public string lastname { get; set; }

		public string firstname { get; set; }

		public string email { get; set; }

		public Int32 id_gender { get; set; }

		public string birthday { get; set; }

		public Int32 newsletter { get; set; }

		public Int32 optin { get; set; }

		public string website { get; set; }

		public string company { get; set; }

		public string siret { get; set; }

		public string ape { get; set; }

		public Double outstanding_allow_amount { get; set; }

		public Boolean show_public_prices { get; set; }

		public Int32 id_risk { get; set; }

		public Int32 max_payment_days { get; set; }

		public Boolean active { get; set; }

		public string note { get; set; }

		public Boolean is_guest { get; set; }

		public Int32 id_shop { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

		public string reset_password_token { get; set; }

		public string reset_password_validity { get; set; }

		public PrestaShopAssociations PrestaShopAssociations { get; set; }

	}

	public class PrestaShopCustomer
	{
		public Int32 id { get; set; }

		public Int32 id_default_group { get; set; }

		public Int32 id_lang { get; set; }

		public string newsletter_date_add { get; set; }

		public string ip_registration_newsletter { get; set; }

		public string secure_key { get; set; }

		public Boolean deleted { get; set; }

		public string passwd { get; set; }

		public string lastname { get; set; }

		public string firstname { get; set; }

		public string email { get; set; }

		public Int32 id_gender { get; set; }

		public string birthday { get; set; }

		public Int32 newsletter { get; set; }

		public Int32 optin { get; set; }

		public string website { get; set; }

		public string company { get; set; }

		public string siret { get; set; }

		public string ape { get; set; }

		public Double outstanding_allow_amount { get; set; }

		public Boolean show_public_prices { get; set; }

		public Int32 id_risk { get; set; }

		public Int32 max_payment_days { get; set; }

		public Boolean active { get; set; }

		public string note { get; set; }

		public Boolean is_guest { get; set; }

		public Int32 id_shop { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

		public string reset_password_token { get; set; }

		public string reset_password_validity { get; set; }

		public PrestaShopAssociations PrestaShopAssociations { get; set; }

	}

	public class PrestaShopCustomizationIn
	{
		public Int32 id_product_attribute { get; set; }

		public Int32 id_address_delivery { get; set; }

		public Int32 id_cart { get; set; }

		public Int32 id_product { get; set; }

		public Int32 quantity { get; set; }

		public Int32 quantity_refunded { get; set; }

		public Int32 quantity_returned { get; set; }

		public Boolean in_cart { get; set; }

	}

	public class PrestaShopCustomization
	{
		public Int32 id { get; set; }

		public Int32 id_product_attribute { get; set; }

		public Int32 id_address_delivery { get; set; }

		public Int32 id_cart { get; set; }

		public Int32 id_product { get; set; }

		public Int32 quantity { get; set; }

		public Int32 quantity_refunded { get; set; }

		public Int32 quantity_returned { get; set; }

		public Boolean in_cart { get; set; }

	}

	public class PrestaShopDeliveryIn
	{
		public Int32 id_carrier { get; set; }

		public Int32 id_range_price { get; set; }

		public Int32 id_range_weight { get; set; }

		public Int32 id_zone { get; set; }

		public Int32 id_shop { get; set; }

		public Int32 id_shop_group { get; set; }

		public Single price { get; set; }

	}

	public class PrestaShopDelivery
	{
		public Int32 id { get; set; }

		public Int32 id_carrier { get; set; }

		public Int32 id_range_price { get; set; }

		public Int32 id_range_weight { get; set; }

		public Int32 id_zone { get; set; }

		public Int32 id_shop { get; set; }

		public Int32 id_shop_group { get; set; }

		public Single price { get; set; }

	}

	public class PrestaShopEmployeeIn
	{
		public Int32 id_lang { get; set; }

		public string last_passwd_gen { get; set; }

		public string stats_date_from { get; set; }

		public string stats_date_to { get; set; }

		public string stats_compare_from { get; set; }

		public string stats_compare_to { get; set; }

		public string passwd { get; set; }

		public string lastname { get; set; }

		public string firstname { get; set; }

		public string email { get; set; }

		public Boolean active { get; set; }

		public Boolean optin { get; set; }

		public Int32 id_profile { get; set; }

		public string bo_color { get; set; }

		public Int32 default_tab { get; set; }

		public string bo_theme { get; set; }

		public string bo_css { get; set; }

		public Int32 bo_width { get; set; }

		public Boolean bo_menu { get; set; }

		public Int32 stats_compare_option { get; set; }

		public string preselect_date_range { get; set; }

		public Int32 id_last_order { get; set; }

		public Int32 id_last_customer_message { get; set; }

		public Int32 id_last_customer { get; set; }

		public string reset_password_token { get; set; }

		public string reset_password_validity { get; set; }

	}

	public class PrestaShopEmployee
	{
		public Int32 id { get; set; }

		public Int32 id_lang { get; set; }

		public string last_passwd_gen { get; set; }

		public string stats_date_from { get; set; }

		public string stats_date_to { get; set; }

		public string stats_compare_from { get; set; }

		public string stats_compare_to { get; set; }

		public string passwd { get; set; }

		public string lastname { get; set; }

		public string firstname { get; set; }

		public string email { get; set; }

		public Boolean active { get; set; }

		public Boolean optin { get; set; }

		public Int32 id_profile { get; set; }

		public string bo_color { get; set; }

		public Int32 default_tab { get; set; }

		public string bo_theme { get; set; }

		public string bo_css { get; set; }

		public Int32 bo_width { get; set; }

		public Boolean bo_menu { get; set; }

		public Int32 stats_compare_option { get; set; }

		public string preselect_date_range { get; set; }

		public Int32 id_last_order { get; set; }

		public Int32 id_last_customer_message { get; set; }

		public Int32 id_last_customer { get; set; }

		public string reset_password_token { get; set; }

		public string reset_password_validity { get; set; }

	}

	public class PrestaShopGroupIn
	{
		public Single reduction { get; set; }

		public Boolean price_display_method { get; set; }

		public Boolean show_prices { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

		public string name { get; set; }

	}

	public class PrestaShopGroup
	{
		public Int32 id { get; set; }

		public Single reduction { get; set; }

		public Boolean price_display_method { get; set; }

		public Boolean show_prices { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

		public string name { get; set; }

	}

	public class PrestaShopGuestIn
	{
		public Int32 id_customer { get; set; }

		public Int32 id_operating_system { get; set; }

		public Int32 id_web_browser { get; set; }

		public Boolean javascript { get; set; }

		public Int32 screen_resolution_x { get; set; }

		public Int32 screen_resolution_y { get; set; }

		public Int32 screen_color { get; set; }

		public Boolean sun_java { get; set; }

		public Boolean adobe_flash { get; set; }

		public Boolean adobe_director { get; set; }

		public Boolean apple_quicktime { get; set; }

		public Boolean real_player { get; set; }

		public Boolean windows_media { get; set; }

		public string accept_language { get; set; }

		public Boolean mobile_theme { get; set; }

	}

	public class PrestaShopGuest
	{
		public Int32 id { get; set; }

		public Int32 id_customer { get; set; }

		public Int32 id_operating_system { get; set; }

		public Int32 id_web_browser { get; set; }

		public Boolean javascript { get; set; }

		public Int32 screen_resolution_x { get; set; }

		public Int32 screen_resolution_y { get; set; }

		public Int32 screen_color { get; set; }

		public Boolean sun_java { get; set; }

		public Boolean adobe_flash { get; set; }

		public Boolean adobe_director { get; set; }

		public Boolean apple_quicktime { get; set; }

		public Boolean real_player { get; set; }

		public Boolean windows_media { get; set; }

		public string accept_language { get; set; }

		public Boolean mobile_theme { get; set; }

	}

	public class PrestaShopImageTypeIn
	{
		public string name { get; set; }

		public Int32 width { get; set; }

		public Int32 height { get; set; }

		public Boolean categories { get; set; }

		public Boolean products { get; set; }

		public Boolean manufacturers { get; set; }

		public Boolean suppliers { get; set; }

		public Boolean stores { get; set; }

	}

	public class PrestaShopImageType
	{
		public Int32 id { get; set; }

		public string name { get; set; }

		public Int32 width { get; set; }

		public Int32 height { get; set; }

		public Boolean categories { get; set; }

		public Boolean products { get; set; }

		public Boolean manufacturers { get; set; }

		public Boolean suppliers { get; set; }

		public Boolean stores { get; set; }

	}

	public class PrestaShopImageIn
	{
		public Int32 id_product { get; set; }

		public Int32 position { get; set; }

		public Boolean cover { get; set; }

		public string legend { get; set; }

	}

	public class PrestaShopImage
	{
		public Int32 id { get; set; }

		public Int32 id_product { get; set; }

		public Int32 position { get; set; }

		public Boolean cover { get; set; }

		public string legend { get; set; }

	}

	public class PrestaShopLanguageIn
	{
		public string name { get; set; }

		public string iso_code { get; set; }

		public string locale { get; set; }

		public string language_code { get; set; }

		public Boolean active { get; set; }

		public Boolean is_rtl { get; set; }

		public string date_format_lite { get; set; }

		public string date_format_full { get; set; }

	}

	public class PrestaShopAddressIn
	{
		public Int32 id_customer { get; set; }

		public Int32 id_manufacturer { get; set; }

		public Int32 in_supplier { get; set; }

		public Int32 id_warehouse { get; set; }

		public Int32 id_country { get; set; }

		public Int32 id_state { get; set; }

		public string alias { get; set; }

		public string company { get; set; }

		public string lastname { get; set; }

		public string firstname { get; set; }

		public string vat_number { get; set; }

		public string address1 { get; set; }

		public string address2 { get; set; }

		public Int32 postcode { get; set; }

		public string city { get; set; }

		public string other { get; set; }

		public string phone { get; set; }

		public string phone_mobile { get; set; }

		public string dni { get; set; }

		public Boolean deleted { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

	}

	public class PrestaShopAddress
	{
		public Int32 id { get; set; }

		public Int32 id_customer { get; set; }

		public Int32 id_manufacturer { get; set; }

		public Int32 in_supplier { get; set; }

		public Int32 id_warehouse { get; set; }

		public Int32 id_country { get; set; }

		public Int32 id_state { get; set; }

		public string alias { get; set; }

		public string company { get; set; }

		public string lastname { get; set; }

		public string firstname { get; set; }

		public string vat_number { get; set; }

		public string address1 { get; set; }

		public string address2 { get; set; }

		public Int32 postcode { get; set; }

		public string city { get; set; }

		public string other { get; set; }

		public string phone { get; set; }

		public string phone_mobile { get; set; }

		public string dni { get; set; }

		public Boolean deleted { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

	}

	public class PrestaShopCarrierIn
	{
		public Boolean deleted { get; set; }

		public Boolean is_module { get; set; }

		public Int32 id_tax_rules_group { get; set; }

		public Int32 id_reference { get; set; }

		public string name { get; set; }

		public Boolean active { get; set; }

		public Boolean is_free { get; set; }

		public string url { get; set; }

		public Int32 shipping_handling { get; set; }

		public Int32 shipping_external { get; set; }

		public Int32 range_behavior { get; set; }

		public Int32 shipping_method { get; set; }

		public Int32 max_width { get; set; }

		public Int32 max_height { get; set; }

		public Int32 max_depth { get; set; }

		public Single max_weight { get; set; }

		public Int32 grade { get; set; }

		public string external_module_name { get; set; }

		public Int32 need_range { get; set; }

		public Int32 position { get; set; }

		public string delay { get; set; }

	}

	public class PrestaShopCarrier
	{
		public Int32 id { get; set; }

		public Boolean deleted { get; set; }

		public Boolean is_module { get; set; }

		public Int32 id_tax_rules_group { get; set; }

		public Int32 id_reference { get; set; }

		public string name { get; set; }

		public Boolean active { get; set; }

		public Boolean is_free { get; set; }

		public string url { get; set; }

		public Int32 shipping_handling { get; set; }

		public Int32 shipping_external { get; set; }

		public Int32 range_behavior { get; set; }

		public Int32 shipping_method { get; set; }

		public Int32 max_width { get; set; }

		public Int32 max_height { get; set; }

		public Int32 max_depth { get; set; }

		public Single max_weight { get; set; }

		public Int32 grade { get; set; }

		public string external_module_name { get; set; }

		public Int32 need_range { get; set; }

		public Int32 position { get; set; }

		public string delay { get; set; }

	}

	public class PrestaShopCartRuleIn
	{
		public Int32 id_customer { get; set; }

		public string date_from { get; set; }

		public string date_to { get; set; }

		public string description { get; set; }

		public Int32 quantity { get; set; }

		public Int32 quantity_per_user { get; set; }

		public Int32 priority { get; set; }

		public Int32 partial_use { get; set; }

		public string code { get; set; }

		public Single minimum_amount { get; set; }

		public Single minimum_amount_tax { get; set; }

		public Single minimum_amount_currency { get; set; }

		public Single minimum_amount_shipping { get; set; }

		public Boolean country_restriction { get; set; }

		public Boolean carrier_restriction { get; set; }

		public Boolean group_restriction { get; set; }

		public Boolean cart_rule_restriction { get; set; }

		public Boolean product_restriction { get; set; }

		public Boolean shop_restriction { get; set; }

		public Boolean free_shipping { get; set; }

		public Single reduction_percent { get; set; }

		public Single reduction_amount { get; set; }

		public Int32 reduction_tax { get; set; }

		public Int32 reduction_currency { get; set; }

		public Int32 reduction_product { get; set; }

		public Int32 reduction_exclude_special { get; set; }

		public Int32 gift_product { get; set; }

		public Int32 gift_product_attribute { get; set; }

		public Boolean highlight { get; set; }

		public Boolean active { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

		public string name { get; set; }

	}

	public class PrestaShopCartRule
	{
		public Int32 id { get; set; }

		public Int32 id_customer { get; set; }

		public string date_from { get; set; }

		public string date_to { get; set; }

		public string description { get; set; }

		public Int32 quantity { get; set; }

		public Int32 quantity_per_user { get; set; }

		public Int32 priority { get; set; }

		public Int32 partial_use { get; set; }

		public string code { get; set; }

		public Single minimum_amount { get; set; }

		public Single minimum_amount_tax { get; set; }

		public Single minimum_amount_currency { get; set; }

		public Single minimum_amount_shipping { get; set; }

		public Boolean country_restriction { get; set; }

		public Boolean carrier_restriction { get; set; }

		public Boolean group_restriction { get; set; }

		public Boolean cart_rule_restriction { get; set; }

		public Boolean product_restriction { get; set; }

		public Boolean shop_restriction { get; set; }

		public Boolean free_shipping { get; set; }

		public Single reduction_percent { get; set; }

		public Single reduction_amount { get; set; }

		public Int32 reduction_tax { get; set; }

		public Int32 reduction_currency { get; set; }

		public Int32 reduction_product { get; set; }

		public Int32 reduction_exclude_special { get; set; }

		public Int32 gift_product { get; set; }

		public Int32 gift_product_attribute { get; set; }

		public Boolean highlight { get; set; }

		public Boolean active { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

		public string name { get; set; }

	}

	public class PrestaShopCartIn
	{
		public Int32 id_address_delivery { get; set; }

		public Int32 id_address_invoice { get; set; }

		public Int32 id_currency { get; set; }

		public Int32 id_customer { get; set; }

		public Int32 id_guest { get; set; }

		public Int32 id_lang { get; set; }

		public Int32 id_shop_group { get; set; }

		public Int32 id_shop { get; set; }

		public Int32 id_carrier { get; set; }

		public Int32 recyclable { get; set; }

		public Int32 gift { get; set; }

		public string gift_message { get; set; }

		public Int32 mobile_theme { get; set; }

		public string delivery_option { get; set; }

		public string secure_key { get; set; }

		public Boolean allow_seperated_package { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

	}

	public class PrestaShopCart
	{
		public Int32 id { get; set; }

		public Int32 id_address_delivery { get; set; }

		public Int32 id_address_invoice { get; set; }

		public Int32 id_currency { get; set; }

		public Int32 id_customer { get; set; }

		public Int32 id_guest { get; set; }

		public Int32 id_lang { get; set; }

		public Int32 id_shop_group { get; set; }

		public Int32 id_shop { get; set; }

		public Int32 id_carrier { get; set; }

		public Int32 recyclable { get; set; }

		public Int32 gift { get; set; }

		public string gift_message { get; set; }

		public Int32 mobile_theme { get; set; }

		public string delivery_option { get; set; }

		public string secure_key { get; set; }

		public Boolean allow_seperated_package { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

	}

	public class PrestaShopCategoryIn
	{
		public Int32 id_parent { get; set; }

		public Int32 level_depth { get; set; }

		public Int32 nb_products_recursive { get; set; }

		public Boolean active { get; set; }

		public Int32 id_shop_default { get; set; }

		public Boolean is_root_category { get; set; }

		public Int32 position { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

		public string name { get; set; }

		public string link_rewrite { get; set; }

		public string description { get; set; }

		public string meta_title { get; set; }

		public string meta_description { get; set; }

		public string meta_keywords { get; set; }

	}

	public class PrestaShopCategory
	{
		public Int32 id { get; set; }

		public Int32 id_parent { get; set; }

		public Int32 level_depth { get; set; }

		public Int32 nb_products_recursive { get; set; }

		public Boolean active { get; set; }

		public Int32 id_shop_default { get; set; }

		public Boolean is_root_category { get; set; }

		public Int32 position { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

		public string name { get; set; }

		public string link_rewrite { get; set; }

		public string description { get; set; }

		public string meta_title { get; set; }

		public string meta_description { get; set; }

		public string meta_keywords { get; set; }

	}

	public class PrestaShopCombinationIn
	{
		public Int32 id_product { get; set; }

		public string location { get; set; }

		public string ean13 { get; set; }

		public string isbn { get; set; }

		public string upc { get; set; }

		public Int32 quantity { get; set; }

		public string reference { get; set; }

		public string supplier_reference { get; set; }

		public Single wholesale_price { get; set; }

		public Single price { get; set; }

		public Single ecotax { get; set; }

		public Single weight { get; set; }

		public Single unit_price_impact { get; set; }

		public Int32 minimal_quantity { get; set; }

		public Nullable<Boolean> default_on { get; set; }

		public string available_date { get; set; }

		public PrestaShopAssociations associations { get; set; }

	}

	public class PrestaShopCombination
	{
		public Int32 id { get; set; }

		public Int32 id_product { get; set; }

		public string location { get; set; }

		public string ean13 { get; set; }

		public string isbn { get; set; }

		public string upc { get; set; }

		public Int32 quantity { get; set; }

		public string reference { get; set; }

		public string supplier_reference { get; set; }

		public Single wholesale_price { get; set; }

		public Single price { get; set; }

		public Single ecotax { get; set; }

		public Single weight { get; set; }

		public Single unit_price_impact { get; set; }

		public Int32 minimal_quantity { get; set; }

		public Nullable<Boolean> default_on { get; set; }

		public string available_date { get; set; }

		public PrestaShopAssociations associations { get; set; }

	}

	public class PrestaShopConfigurationIn
	{
		public string value { get; set; }

		public string name { get; set; }

		public Int32 id_shop_group { get; set; }

		public Int32 id_shop { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

	}

	public class PrestaShopConfiguration
	{
		public Int32 id { get; set; }

		public string value { get; set; }

		public string name { get; set; }

		public Int32 id_shop_group { get; set; }

		public Int32 id_shop { get; set; }

		public string date_add { get; set; }

		public string date_upd { get; set; }

	}

	public class PrestaShopContactIn
	{
		public string email { get; set; }

		public Int32 customer_service { get; set; }

		public string name { get; set; }

		public string description { get; set; }

	}

	public class PrestaShopContact
	{
		public Int32 id { get; set; }

		public string email { get; set; }

		public Int32 customer_service { get; set; }

		public string name { get; set; }

		public string description { get; set; }

	}

	public class PrestaShopContentManagementSystemIn
	{
		public Int32 id_cms { get; set; }

		public string meta_title { get; set; }

		public string meta_description { get; set; }

		public string meta_keywords { get; set; }

		public string content { get; set; }

		public string link_rewrite { get; set; }

		public Int32 id_cms_category { get; set; }

		public Int32 position { get; set; }

		public Boolean indexation { get; set; }

		public Boolean active { get; set; }

	}

	public class PrestaShopContentManagementSystem
	{
		public Int32 id { get; set; }

		public Int32 id_cms { get; set; }

		public string meta_title { get; set; }

		public string meta_description { get; set; }

		public string meta_keywords { get; set; }

		public string content { get; set; }

		public string link_rewrite { get; set; }

		public Int32 id_cms_category { get; set; }

		public Int32 position { get; set; }

		public Boolean indexation { get; set; }

		public Boolean active { get; set; }

	}

	public class PrestaShopCountryIn
	{
		public Int32 id_zone { get; set; }

		public Int32 id_currency { get; set; }

		public Int32 call_prefix { get; set; }

		public string iso_code { get; set; }

		public Boolean active { get; set; }

		public Boolean contains_states { get; set; }

		public Boolean need_identification_number { get; set; }

		public string need_zip_code { get; set; }

		public string zip_code_format { get; set; }

		public Boolean display_tax_label { get; set; }

		public string name { get; set; }

	}

	public class PrestaShopCountry
	{
		public Int32 id { get; set; }

		public Int32 id_zone { get; set; }

		public Int32 id_currency { get; set; }

		public Int32 call_prefix { get; set; }

		public string iso_code { get; set; }

		public Boolean active { get; set; }

		public Boolean contains_states { get; set; }

		public Boolean need_identification_number { get; set; }

		public string need_zip_code { get; set; }

		public string zip_code_format { get; set; }

		public Boolean display_tax_label { get; set; }

		public string name { get; set; }

	}

	public class PrestaShopCurrencyIn
	{
		public string name { get; set; }

		public string iso_code { get; set; }

		public Single conversion_rate { get; set; }

		public Boolean deleted { get; set; }

		public Boolean active { get; set; }

	}

}