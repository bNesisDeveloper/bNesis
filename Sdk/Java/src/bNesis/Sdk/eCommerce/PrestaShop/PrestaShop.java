package bNesis.Sdk.eCommerce.PrestaShop;

import java.io.*;
import java.util.List;
import java.util.Date;
import java.util.Map.Entry;
import bNesis.Api.*;

import bNesis.Sdk.Common.*;
import java.net.URI.*;
import bNesis.Sdk.eCommerce.PrestaShop.*;

	public class PrestaShop  
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

		public PrestaShop(bNesisApi bnesisApi)
		{
			this._bNesisApi = bnesisApi;
		}

		/**
		 * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
		 * @return {String} bNesisToken value
		 */
		public String Auth(String bNesisDevId,String redirectUrl,String login,String serviceUrl) throws Exception
		{
			bNesisToken = _bNesisApi.Auth("PrestaShop", "",bNesisDevId,redirectUrl,"","",null,login,"",false,serviceUrl);
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
			Boolean result = _bNesisApi.LogoffService("PrestaShop", bNesisToken);
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
			return _bNesisApi.<ErrorInfo>Call(ErrorInfo.class, "PrestaShop", bNesisToken, "GetLastError");
		}

		/**
		 *  Getting arrays of error info 	
		 * @return {ErrorInfo[]}  
		 * @throws Exception
		 */
		public ErrorInfo[] GetErrorLog() throws Exception
		{
			return _bNesisApi.<ErrorInfo[]>Call(ErrorInfo[].class, "PrestaShop", bNesisToken, "GetErrorLog");
		}

		/**
		 *  Checks the token in the service. 	
		 * @return {Boolean} if token valid return true, if token not valid return false 
		 * @throws Exception
		 */
		public Boolean ValidateToken() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "ValidateToken");
		}

		/**
		 *  Disables the access token used to authenticate the call. 	
		 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false 
		 * @throws Exception
		 */
		public Boolean Logoff() throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "Logoff");
		}

		/**
		 *   	
		 * @param contactItem 
	 * @return {Boolean}  
		 * @throws Exception
		 */
		public Boolean CreateCustomerUnified(ContactItem contactItem) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "CreateCustomerUnified", contactItem);
		}

		/**
		 *   	
		 * @return {ContactItem[]}  
		 * @throws Exception
		 */
		public ContactItem[] GetCustomersUnified() throws Exception
		{
			return _bNesisApi.<ContactItem[]>Call(ContactItem[].class, "PrestaShop", bNesisToken, "GetCustomersUnified");
		}

		/**
		 *   	
		 * @param productItem 
	 * @return {Boolean}  
		 * @throws Exception
		 */
		public Boolean AddProductUnified(ProductItem productItem) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddProductUnified", productItem);
		}

		/**
		 *   	
		 * @return {ProductItem[]}  
		 * @throws Exception
		 */
		public ProductItem[] GetProductsUnified() throws Exception
		{
			return _bNesisApi.<ProductItem[]>Call(ProductItem[].class, "PrestaShop", bNesisToken, "GetProductsUnified");
		}

		/**
		 *   	
		 * @param IdProduct 
	 * @return {Boolean}  
		 * @throws Exception
		 */
		public Boolean DeleteProductUnified(String IdProduct) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteProductUnified", IdProduct);
		}

		/**
		 *   	
		 * @return {CountryItem[]}  
		 * @throws Exception
		 */
		public CountryItem[] GetCountriesUnified() throws Exception
		{
			return _bNesisApi.<CountryItem[]>Call(CountryItem[].class, "PrestaShop", bNesisToken, "GetCountriesUnified");
		}

		/**
		 *   	
		 * @return {Integer}  
		 * @throws Exception
		 */
		public Integer GetCountCountriesUnified() throws Exception
		{
			return _bNesisApi.<Integer>Call(Integer.class, "PrestaShop", bNesisToken, "GetCountCountriesUnified");
		}

		/**
		 *   	
		 * @param IdCountry 
	 * @return {CountryItem}  
		 * @throws Exception
		 */
		public CountryItem ReceiveCountryUnified(String IdCountry) throws Exception
		{
			return _bNesisApi.<CountryItem>Call(CountryItem.class, "PrestaShop", bNesisToken, "ReceiveCountryUnified", IdCountry);
		}

		/**
		 *   	
		 * @param IdCountry 
	 * @return {Boolean}  
		 * @throws Exception
		 */
		public Boolean DeleteCountryUnified(String IdCountry) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteCountryUnified", IdCountry);
		}

		/**
		 *   	
		 * @param countryItem 
	 * @return {CountryItem}  
		 * @throws Exception
		 */
		public CountryItem CreateCountryUnified(CountryItem countryItem) throws Exception
		{
			return _bNesisApi.<CountryItem>Call(CountryItem.class, "PrestaShop", bNesisToken, "CreateCountryUnified", countryItem);
		}

		/**
		 *   	
		 * @param countryItem 
	 * @return {CountryItem}  
		 * @throws Exception
		 */
		public CountryItem UpdateCountryUnified(CountryItem countryItem) throws Exception
		{
			return _bNesisApi.<CountryItem>Call(CountryItem.class, "PrestaShop", bNesisToken, "UpdateCountryUnified", countryItem);
		}

		/**
		 *   	
		 * @param IdCustomer 
	 * @return {ContactItem}  
		 * @throws Exception
		 */
		public ContactItem ReceiveCustomerUnified(String IdCustomer) throws Exception
		{
			return _bNesisApi.<ContactItem>Call(ContactItem.class, "PrestaShop", bNesisToken, "ReceiveCustomerUnified", IdCustomer);
		}

		/**
		 *  Getting supply order states identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopSupplyOrderState. 
		 * @throws Exception
		 */
		public Response GetSupplyOrderStatesIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetSupplyOrderStatesIdentifiersRaw");
		}

		/**
		 *  Getting supply order states by rendering options. 	
		 * @param renderingOptions For request specified information about supply order states use: display and filter or sort.
	 * @return {Response} Returns only certain information about SupplyOrderState in PrestaShopSupplyOrderState class. 
		 * @throws Exception
		 */
		public Response GetSupplyOrderStatesByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetSupplyOrderStatesByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Getting supply order by identifier. 	
		 * @param id Identifier of supply order.
	 * @return {Response} Return PrestaShopSupplyOrder. 
		 * @throws Exception
		 */
		public Response GetSupplyOrderRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetSupplyOrderRaw", id);
		}

		/**
		 *  Getting supply orders identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopSupplyOrder. 
		 * @throws Exception
		 */
		public Response GetSupplyOrdersIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetSupplyOrdersIdentifiersRaw");
		}

		/**
		 *  Getting supply orders by rendering options. 	
		 * @param renderingOptions For request specified information about supply orders use: display and filter or sort.
	 * @return {Response} Returns only certain information about SupplyOrder in PrestaShopSupplyOrder class. 
		 * @throws Exception
		 */
		public Response GetSupplyOrdersByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetSupplyOrdersByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new tag. 	
		 * @param tag Body of tag.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddTagRaw(Object tag) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddTagRaw", tag);
		}

		/**
		 *  Update information in specified tag. 	
		 * @param tag Body of tag.
	 * @return {Response} Return updated PrestaShopTag. 
		 * @throws Exception
		 */
		public Response EditTagRaw(Object tag) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditTagRaw", tag);
		}

		/**
		 *  Remove tag by identifier. 	
		 * @param id Identifier of tag.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteTagRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteTagRaw", id);
		}

		/**
		 *  Getting tag by identifier. 	
		 * @param id Identifier of tag.
	 * @return {Response} Return PrestaShopTag. 
		 * @throws Exception
		 */
		public Response GetTagRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetTagRaw", id);
		}

		/**
		 *  Getting tags identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopTag. 
		 * @throws Exception
		 */
		public Response GetTagsIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetTagsIdentifiersRaw");
		}

		/**
		 *  Getting tags by rendering options. 	
		 * @param renderingOptions For request specified information about tags use: display and filter or sort.
	 * @return {Response} Returns only certain information about Tag in PrestaShopTag class. 
		 * @throws Exception
		 */
		public Response GetTagsByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetTagsByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new tax rule group. 	
		 * @param taxRuleGroup Body of tax rule group.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddTaxRuleGroupRaw(Object taxRuleGroup) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddTaxRuleGroupRaw", taxRuleGroup);
		}

		/**
		 *  Update information in specified tax rule group. 	
		 * @param taxRuleGroup Body of tax rule group.
	 * @return {Response} Return updated PrestaShopTaxRuleGroup. 
		 * @throws Exception
		 */
		public Response EditTaxRuleGroupRaw(Object taxRuleGroup) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditTaxRuleGroupRaw", taxRuleGroup);
		}

		/**
		 *  Remove tax rule group by identifier. 	
		 * @param id Identifier of tax rule group.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteTaxRuleGroupRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteTaxRuleGroupRaw", id);
		}

		/**
		 *  Getting tax rule group by identifier. 	
		 * @param id Identifier of tax rule group.
	 * @return {Response} Return PrestaShopTaxRuleGroup. 
		 * @throws Exception
		 */
		public Response GetTaxRuleGroupRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetTaxRuleGroupRaw", id);
		}

		/**
		 *  Getting tax rule groups identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopTaxRuleGroup. 
		 * @throws Exception
		 */
		public Response GetTaxRuleGroupsIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetTaxRuleGroupsIdentifiersRaw");
		}

		/**
		 *  Getting tax rule groups by rendering options. 	
		 * @param renderingOptions For request specified information about tax rule groups use: display and filter or sort.
	 * @return {Response} Returns only certain information about TaxRuleGroup in PrestaShopTaxRuleGroup class. 
		 * @throws Exception
		 */
		public Response GetTaxRuleGroupsByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetTaxRuleGroupsByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new tax rule. 	
		 * @param taxRule Body of tax rule.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddTaxRuleRaw(Object taxRule) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddTaxRuleRaw", taxRule);
		}

		/**
		 *  Update information in specified tax rule. 	
		 * @param taxRule Body of tax rule.
	 * @return {Response} Return updated PrestaShopTaxRule. 
		 * @throws Exception
		 */
		public Response EditTaxRuleRaw(Object taxRule) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditTaxRuleRaw", taxRule);
		}

		/**
		 *  Remove tax rule by identifier. 	
		 * @param id Identifier of tax rule.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteTaxRuleRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteTaxRuleRaw", id);
		}

		/**
		 *  Getting tax rule by identifier. 	
		 * @param id Identifier of tax rule.
	 * @return {Response} Return PrestaShopTaxRule. 
		 * @throws Exception
		 */
		public Response GetTaxRuleRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetTaxRuleRaw", id);
		}

		/**
		 *  Getting tax rules identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopTaxRule. 
		 * @throws Exception
		 */
		public Response GetTaxRulesIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetTaxRulesIdentifiersRaw");
		}

		/**
		 *  Getting tax rules by rendering options. 	
		 * @param renderingOptions For request specified information about tax rules use: display and filter or sort.
	 * @return {Response} Returns only certain information about TaxRule in PrestaShopTaxRule class. 
		 * @throws Exception
		 */
		public Response GetTaxRulesByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetTaxRulesByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new tax. 	
		 * @param tax Body of tax.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddTaxRaw(Object tax) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddTaxRaw", tax);
		}

		/**
		 *  Update information in specified tax. 	
		 * @param tax Body of tax.
	 * @return {Response} Return updated PrestaShopTax. 
		 * @throws Exception
		 */
		public Response EditTaxRaw(Object tax) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditTaxRaw", tax);
		}

		/**
		 *  Remove tax by identifier. 	
		 * @param id Identifier of tax.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteTaxRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteTaxRaw", id);
		}

		/**
		 *  Getting tax by identifier. 	
		 * @param id Identifier of tax.
	 * @return {Response} Return PrestaShopTax. 
		 * @throws Exception
		 */
		public Response GetTaxRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetTaxRaw", id);
		}

		/**
		 *  Getting taxes identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopTax. 
		 * @throws Exception
		 */
		public Response GetTaxesIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetTaxesIdentifiersRaw");
		}

		/**
		 *  Getting taxes by rendering options. 	
		 * @param renderingOptions For request specified information about taxes use: display and filter or sort.
	 * @return {Response} Returns only certain information about Tax in PrestaShopTax class. 
		 * @throws Exception
		 */
		public Response GetTaxesByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetTaxesByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new translated configuration. 	
		 * @param translatedConfiguration Body of translated configuration.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddTranslatedConfigurationRaw(Object translatedConfiguration) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddTranslatedConfigurationRaw", translatedConfiguration);
		}

		/**
		 *  Update information in specified translated configuration. 	
		 * @param translatedConfiguration Body of translated configuration.
	 * @return {Response} Return updated PrestaShopTranslatedConfiguration. 
		 * @throws Exception
		 */
		public Response EditTranslatedConfigurationRaw(Object translatedConfiguration) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditTranslatedConfigurationRaw", translatedConfiguration);
		}

		/**
		 *  Remove translated configuration by identifier. 	
		 * @param id Identifier of translated configuration.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteTranslatedConfigurationRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteTranslatedConfigurationRaw", id);
		}

		/**
		 *  Getting translated configuration by identifier. 	
		 * @param id Identifier of translated configuration.
	 * @return {Response} Return PrestaShopTranslatedConfiguration. 
		 * @throws Exception
		 */
		public Response GetTranslatedConfigurationRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetTranslatedConfigurationRaw", id);
		}

		/**
		 *  Getting translated configurations identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopTranslatedConfiguration. 
		 * @throws Exception
		 */
		public Response GetTranslatedConfigurationsIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetTranslatedConfigurationsIdentifiersRaw");
		}

		/**
		 *  Getting translated configurations by rendering options. 	
		 * @param renderingOptions For request specified information about translated configurations use: display and filter or sort.
	 * @return {Response} Returns only certain information about TranslatedConfiguration in PrestaShopTranslatedConfiguration class. 
		 * @throws Exception
		 */
		public Response GetTranslatedConfigurationsByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetTranslatedConfigurationsByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Getting warehouse product location by identifier. 	
		 * @param id Identifier of warehouse product location.
	 * @return {Response} Return PrestaShopWarehouseProductLocation. 
		 * @throws Exception
		 */
		public Response GetWarehouseProductLocationRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetWarehouseProductLocationRaw", id);
		}

		/**
		 *  Getting warehouse product locations identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopWarehouseProductLocation. 
		 * @throws Exception
		 */
		public Response GetWarehouseProductLocationsIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetWarehouseProductLocationsIdentifiersRaw");
		}

		/**
		 *  Getting warehouse product locations by rendering options. 	
		 * @param renderingOptions For request specified information about warehouse product locations use: display and filter or sort.
	 * @return {Response} Returns only certain information about WarehouseProductLocation in PrestaShopWarehouseProductLocation class. 
		 * @throws Exception
		 */
		public Response GetWarehouseProductLocationsByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetWarehouseProductLocationsByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new weight range. 	
		 * @param weightRange Body of weight range.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddWeightRangeRaw(Object weightRange) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddWeightRangeRaw", weightRange);
		}

		/**
		 *  Update information in specified weight range. 	
		 * @param weightRange Body of weight range.
	 * @return {Response} Return updated PrestaShopWeightRange. 
		 * @throws Exception
		 */
		public Response EditWeightRangeRaw(Object weightRange) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditWeightRangeRaw", weightRange);
		}

		/**
		 *  Remove weight range by identifier. 	
		 * @param id Identifier of weight range.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteWeightRangeRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteWeightRangeRaw", id);
		}

		/**
		 *  Getting weight range by identifier. 	
		 * @param id Identifier of weight range.
	 * @return {Response} Return PrestaShopWeightRange. 
		 * @throws Exception
		 */
		public Response GetWeightRangeRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetWeightRangeRaw", id);
		}

		/**
		 *  Getting weight ranges identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopWeightRange. 
		 * @throws Exception
		 */
		public Response GetWeightRangesIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetWeightRangesIdentifiersRaw");
		}

		/**
		 *  Getting weight ranges by rendering options. 	
		 * @param renderingOptions For request specified information about weight ranges use: display and filter or sort.
	 * @return {Response} Returns only certain information about WeightRange in PrestaShopWeightRange class. 
		 * @throws Exception
		 */
		public Response GetWeightRangesByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetWeightRangesByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new zone. 	
		 * @param zone Body of zone.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddZoneRaw(Object zone) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddZoneRaw", zone);
		}

		/**
		 *  Update information in specified zone. 	
		 * @param zone Body of zone.
	 * @return {Response} Return updated PrestaShopZone. 
		 * @throws Exception
		 */
		public Response EditZoneRaw(Object zone) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditZoneRaw", zone);
		}

		/**
		 *  Remove zone by identifier. 	
		 * @param id Identifier of zone.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteZoneRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteZoneRaw", id);
		}

		/**
		 *  Getting zone by identifier. 	
		 * @param id Identifier of zone.
	 * @return {Response} Return PrestaShopZone. 
		 * @throws Exception
		 */
		public Response GetZoneRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetZoneRaw", id);
		}

		/**
		 *  Getting zones identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopZone. 
		 * @throws Exception
		 */
		public Response GetZonesIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetZonesIdentifiersRaw");
		}

		/**
		 *  Getting zones by rendering options. 	
		 * @param renderingOptions For request specified information about zones use: display and filter or sort.
	 * @return {Response} Returns only certain information about Zone in PrestaShopZone class. 
		 * @throws Exception
		 */
		public Response GetZonesByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetZonesByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Getting shop group by identifier. 	
		 * @param id Identifier of shop group.
	 * @return {Response} Return PrestaShopShopGroup. 
		 * @throws Exception
		 */
		public Response GetShopGroupRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetShopGroupRaw", id);
		}

		/**
		 *  Getting shop groups identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopShopGroup. 
		 * @throws Exception
		 */
		public Response GetShopGroupsIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetShopGroupsIdentifiersRaw");
		}

		/**
		 *  Getting shop groups by rendering options. 	
		 * @param renderingOptions For request specified information about shop groups use: display and filter or sort.
	 * @return {Response} Returns only certain information about ShopGroup in PrestaShopShopGroup class. 
		 * @throws Exception
		 */
		public Response GetShopGroupsByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetShopGroupsByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new shop url. 	
		 * @param shopUrl Body of shop url.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddShopUrlRaw(Object shopUrl) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddShopUrlRaw", shopUrl);
		}

		/**
		 *  Update information in specified shop url. 	
		 * @param shopUrl Body of shop url.
	 * @return {Response} Return updated PrestaShopShopUrl. 
		 * @throws Exception
		 */
		public Response EditShopUrlRaw(Object shopUrl) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditShopUrlRaw", shopUrl);
		}

		/**
		 *  Remove shop url by identifier. 	
		 * @param id Identifier of shop url.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteShopUrlRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteShopUrlRaw", id);
		}

		/**
		 *  Getting shop url by identifier. 	
		 * @param id Identifier of shop url.
	 * @return {Response} Return PrestaShopShopUrl. 
		 * @throws Exception
		 */
		public Response GetShopUrlRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetShopUrlRaw", id);
		}

		/**
		 *  Getting shop urls identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopShopUrl. 
		 * @throws Exception
		 */
		public Response GetShopUrlsIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetShopUrlsIdentifiersRaw");
		}

		/**
		 *  Getting shop urls by rendering options. 	
		 * @param renderingOptions For request specified information about shop urls use: display and filter or sort.
	 * @return {Response} Returns only certain information about ShopUrl in PrestaShopShopUrl class. 
		 * @throws Exception
		 */
		public Response GetShopUrlsByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetShopUrlsByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new shop. 	
		 * @param shop Body of shop.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddShopRaw(Object shop) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddShopRaw", shop);
		}

		/**
		 *  Update information in specified shop. 	
		 * @param shop Body of shop.
	 * @return {Response} Return updated PrestaShopShop. 
		 * @throws Exception
		 */
		public Response EditShopRaw(Object shop) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditShopRaw", shop);
		}

		/**
		 *  Remove shop by identifier. 	
		 * @param id Identifier of shop.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteShopRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteShopRaw", id);
		}

		/**
		 *  Getting shop by identifier. 	
		 * @param id Identifier of shop.
	 * @return {Response} Return PrestaShopShop. 
		 * @throws Exception
		 */
		public Response GetShopRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetShopRaw", id);
		}

		/**
		 *  Getting shops identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopShop. 
		 * @throws Exception
		 */
		public Response GetShopsIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetShopsIdentifiersRaw");
		}

		/**
		 *  Getting shops by rendering options. 	
		 * @param renderingOptions For request specified information about shops use: display and filter or sort.
	 * @return {Response} Returns only certain information about Shop in PrestaShopShop class. 
		 * @throws Exception
		 */
		public Response GetShopsByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetShopsByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new specific price rule. 	
		 * @param specificPriceRule Body of specific price rule.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddSpecificPriceRuleRaw(Object specificPriceRule) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddSpecificPriceRuleRaw", specificPriceRule);
		}

		/**
		 *  Update information in specified specific price rule. 	
		 * @param specificPriceRule Body of specific price rule.
	 * @return {Response} Return updated PrestaShopSpecificPriceRule. 
		 * @throws Exception
		 */
		public Response EditSpecificPriceRuleRaw(Object specificPriceRule) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditSpecificPriceRuleRaw", specificPriceRule);
		}

		/**
		 *  Remove specific price rule by identifier. 	
		 * @param id Identifier of specific price rule.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteSpecificPriceRuleRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteSpecificPriceRuleRaw", id);
		}

		/**
		 *  Getting specific price rule by identifier. 	
		 * @param id Identifier of specific price rule.
	 * @return {Response} Return PrestaShopSpecificPriceRule. 
		 * @throws Exception
		 */
		public Response GetSpecificPriceRuleRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetSpecificPriceRuleRaw", id);
		}

		/**
		 *  Getting specific price rules identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopSpecificPriceRule. 
		 * @throws Exception
		 */
		public Response GetSpecificPriceRulesIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetSpecificPriceRulesIdentifiersRaw");
		}

		/**
		 *  Getting specific price rules by rendering options. 	
		 * @param renderingOptions For request specified information about specific price rules use: display and filter or sort.
	 * @return {Response} Returns only certain information about SpecificPriceRule in PrestaShopSpecificPriceRule class. 
		 * @throws Exception
		 */
		public Response GetSpecificPriceRulesByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetSpecificPriceRulesByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new specific price. 	
		 * @param specificPrice Body of specific price.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddSpecificPriceRaw(Object specificPrice) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddSpecificPriceRaw", specificPrice);
		}

		/**
		 *  Update information in specified specific price. 	
		 * @param specificPrice Body of specific price.
	 * @return {Response} Return updated PrestaShopSpecificPrice. 
		 * @throws Exception
		 */
		public Response EditSpecificPriceRaw(Object specificPrice) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditSpecificPriceRaw", specificPrice);
		}

		/**
		 *  Remove specific price by identifier. 	
		 * @param id Identifier of specific price.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteSpecificPriceRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteSpecificPriceRaw", id);
		}

		/**
		 *  Getting specific price by identifier. 	
		 * @param id Identifier of specific price.
	 * @return {Response} Return PrestaShopSpecificPrice. 
		 * @throws Exception
		 */
		public Response GetSpecificPriceRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetSpecificPriceRaw", id);
		}

		/**
		 *  Getting specific prices identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopSpecificPrice. 
		 * @throws Exception
		 */
		public Response GetSpecificPricesIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetSpecificPricesIdentifiersRaw");
		}

		/**
		 *  Getting specific prices by rendering options. 	
		 * @param renderingOptions For request specified information about specific prices use: display and filter or sort.
	 * @return {Response} Returns only certain information about SpecificPrice in PrestaShopSpecificPrice class. 
		 * @throws Exception
		 */
		public Response GetSpecificPricesByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetSpecificPricesByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Getting state by identifier. 	
		 * @param id Identifier of state.
	 * @return {Response} Return PrestaShopState. 
		 * @throws Exception
		 */
		public Response GetStateRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetStateRaw", id);
		}

		/**
		 *  Getting states identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopState. 
		 * @throws Exception
		 */
		public Response GetStatesIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetStatesIdentifiersRaw");
		}

		/**
		 *  Getting states by rendering options. 	
		 * @param renderingOptions For request specified information about states use: display and filter or sort.
	 * @return {Response} Returns only certain information about State in PrestaShopState class. 
		 * @throws Exception
		 */
		public Response GetStatesByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetStatesByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new stock movement reason. 	
		 * @param stockMovementReason Body of stock movement reason.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddStockMovementReasonRaw(Object stockMovementReason) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddStockMovementReasonRaw", stockMovementReason);
		}

		/**
		 *  Update information in specified stock movement reason. 	
		 * @param stockMovementReason Body of stock movement reason.
	 * @return {Response} Return updated PrestaShopStockMovementReason. 
		 * @throws Exception
		 */
		public Response EditStockMovementReasonRaw(Object stockMovementReason) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditStockMovementReasonRaw", stockMovementReason);
		}

		/**
		 *  Remove stock movement reason by identifier. 	
		 * @param id Identifier of stock movement reason.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteStockMovementReasonRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteStockMovementReasonRaw", id);
		}

		/**
		 *  Getting stock movement reason by identifier. 	
		 * @param id Identifier of stock movement reason.
	 * @return {Response} Return PrestaShopStockMovementReason. 
		 * @throws Exception
		 */
		public Response GetStockMovementReasonRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetStockMovementReasonRaw", id);
		}

		/**
		 *  Getting stock movement reasons identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopStockMovementReason. 
		 * @throws Exception
		 */
		public Response GetStockMovementReasonsIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetStockMovementReasonsIdentifiersRaw");
		}

		/**
		 *  Getting stock movement reasons by rendering options. 	
		 * @param renderingOptions For request specified information about stock movement reasons use: display and filter or sort.
	 * @return {Response} Returns only certain information about StockMovementReason in PrestaShopStockMovementReason class. 
		 * @throws Exception
		 */
		public Response GetStockMovementReasonsByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetStockMovementReasonsByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Getting stock movement by identifier. 	
		 * @param id Identifier of stock movement.
	 * @return {Response} Return PrestaShopStockMovement. 
		 * @throws Exception
		 */
		public Response GetStockMovementRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetStockMovementRaw", id);
		}

		/**
		 *  Getting stock movements identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopStockMovement. 
		 * @throws Exception
		 */
		public Response GetStockMovementsIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetStockMovementsIdentifiersRaw");
		}

		/**
		 *  Getting stock movements by rendering options. 	
		 * @param renderingOptions For request specified information about stock movements use: display and filter or sort.
	 * @return {Response} Returns only certain information about StockMovement in PrestaShopStockMovement class. 
		 * @throws Exception
		 */
		public Response GetStockMovementsByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetStockMovementsByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Getting stock by identifier. 	
		 * @param id Identifier of stock.
	 * @return {Response} Return PrestaShopStock. 
		 * @throws Exception
		 */
		public Response GetStockRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetStockRaw", id);
		}

		/**
		 *  Getting stocks identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopStock. 
		 * @throws Exception
		 */
		public Response GetStocksIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetStocksIdentifiersRaw");
		}

		/**
		 *  Getting stocks by rendering options. 	
		 * @param renderingOptions For request specified information about stocks use: display and filter or sort.
	 * @return {Response} Returns only certain information about Stock in PrestaShopStock class. 
		 * @throws Exception
		 */
		public Response GetStocksByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetStocksByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new store. 	
		 * @param store Body of store.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddStoreRaw(Object store) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddStoreRaw", store);
		}

		/**
		 *  Update information in specified store. 	
		 * @param store Body of store.
	 * @return {Response} Return updated PrestaShopStore. 
		 * @throws Exception
		 */
		public Response EditStoreRaw(Object store) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditStoreRaw", store);
		}

		/**
		 *  Remove store by identifier. 	
		 * @param id Identifier of store.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteStoreRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteStoreRaw", id);
		}

		/**
		 *  Getting store by identifier. 	
		 * @param id Identifier of store.
	 * @return {Response} Return PrestaShopStore. 
		 * @throws Exception
		 */
		public Response GetStoreRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetStoreRaw", id);
		}

		/**
		 *  Getting stores identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopStore. 
		 * @throws Exception
		 */
		public Response GetStoresIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetStoresIdentifiersRaw");
		}

		/**
		 *  Getting stores by rendering options. 	
		 * @param renderingOptions For request specified information about stores use: display and filter or sort.
	 * @return {Response} Returns only certain information about Store in PrestaShopStore class. 
		 * @throws Exception
		 */
		public Response GetStoresByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetStoresByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new supplier. 	
		 * @param supplier Body of supplier.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddSupplierRaw(Object supplier) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddSupplierRaw", supplier);
		}

		/**
		 *  Update information in specified supplier. 	
		 * @param supplier Body of supplier.
	 * @return {Response} Return updated PrestaShopSupplier. 
		 * @throws Exception
		 */
		public Response EditSupplierRaw(Object supplier) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditSupplierRaw", supplier);
		}

		/**
		 *  Remove supplier by identifier. 	
		 * @param id Identifier of supplier.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteSupplierRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteSupplierRaw", id);
		}

		/**
		 *  Getting supplier by identifier. 	
		 * @param id Identifier of supplier.
	 * @return {Response} Return PrestaShopSupplier. 
		 * @throws Exception
		 */
		public Response GetSupplierRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetSupplierRaw", id);
		}

		/**
		 *  Getting suppliers identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopSupplier. 
		 * @throws Exception
		 */
		public Response GetSuppliersIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetSuppliersIdentifiersRaw");
		}

		/**
		 *  Getting suppliers by rendering options. 	
		 * @param renderingOptions For request specified information about suppliers use: display and filter or sort.
	 * @return {Response} Returns only certain information about Supplier in PrestaShopSupplier class. 
		 * @throws Exception
		 */
		public Response GetSuppliersByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetSuppliersByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Getting supply order detail by identifier. 	
		 * @param id Identifier of supply order detail.
	 * @return {Response} Return PrestaShopSupplyOrderDetail. 
		 * @throws Exception
		 */
		public Response GetSupplyOrderDetailRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetSupplyOrderDetailRaw", id);
		}

		/**
		 *  Getting supply order details identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopSupplyOrderDetail. 
		 * @throws Exception
		 */
		public Response GetSupplyOrderDetailsIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetSupplyOrderDetailsIdentifiersRaw");
		}

		/**
		 *  Getting supply order details by rendering options. 	
		 * @param renderingOptions For request specified information about supply order details use: display and filter or sort.
	 * @return {Response} Returns only certain information about SupplyOrderDetail in PrestaShopSupplyOrderDetail class. 
		 * @throws Exception
		 */
		public Response GetSupplyOrderDetailsByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetSupplyOrderDetailsByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Getting supply order history by identifier. 	
		 * @param id Identifier of supply order history.
	 * @return {Response} Return PrestaShopSupplyOrderHistory. 
		 * @throws Exception
		 */
		public Response GetSupplyOrderHistoryRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetSupplyOrderHistoryRaw", id);
		}

		/**
		 *  Getting supply order histories identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopSupplyOrderHistory. 
		 * @throws Exception
		 */
		public Response GetSupplyOrderHistoriesIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetSupplyOrderHistoriesIdentifiersRaw");
		}

		/**
		 *  Getting supply order histories by rendering options. 	
		 * @param renderingOptions For request specified information about supply order histories use: display and filter or sort.
	 * @return {Response} Returns only certain information about SupplyOrderHistory in PrestaShopSupplyOrderHistory class. 
		 * @throws Exception
		 */
		public Response GetSupplyOrderHistoriesByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetSupplyOrderHistoriesByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Getting supply order receipt history by identifier. 	
		 * @param id Identifier of supply order receipt history.
	 * @return {Response} Return PrestaShopSupplyOrderReceiptHistory. 
		 * @throws Exception
		 */
		public Response GetSupplyOrderReceiptHistoryRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetSupplyOrderReceiptHistoryRaw", id);
		}

		/**
		 *  Getting supply order receipt histories identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopSupplyOrderReceiptHistory. 
		 * @throws Exception
		 */
		public Response GetSupplyOrderReceiptHistoriesIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetSupplyOrderReceiptHistoriesIdentifiersRaw");
		}

		/**
		 *  Getting supply order receipt histories by rendering options. 	
		 * @param renderingOptions For request specified information about supply order receipt histories use: display and filter or sort.
	 * @return {Response} Returns only certain information about SupplyOrderReceiptHistory in PrestaShopSupplyOrderReceiptHistory class. 
		 * @throws Exception
		 */
		public Response GetSupplyOrderReceiptHistoriesByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetSupplyOrderReceiptHistoriesByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Getting supply order state by identifier. 	
		 * @param id Identifier of supply order state.
	 * @return {Response} Return PrestaShopSupplyOrderState. 
		 * @throws Exception
		 */
		public Response GetSupplyOrderStateRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetSupplyOrderStateRaw", id);
		}

		/**
		 *  Getting order payments by rendering options. 	
		 * @param renderingOptions For request specified information about order payments use: display and filter or sort.
	 * @return {Response} Returns only certain information about OrderPayment in PrestaShopOrderPayment class. 
		 * @throws Exception
		 */
		public Response GetOrderPaymentsByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetOrderPaymentsByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new order slip. 	
		 * @param orderSlip Body of order slip.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddOrderSlipRaw(Object orderSlip) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddOrderSlipRaw", orderSlip);
		}

		/**
		 *  Update information in specified order slip. 	
		 * @param orderSlip Body of order slip.
	 * @return {Response} Return updated PrestaShopOrderSlip. 
		 * @throws Exception
		 */
		public Response EditOrderSlipRaw(Object orderSlip) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditOrderSlipRaw", orderSlip);
		}

		/**
		 *  Remove order slip by identifier. 	
		 * @param id Identifier of order slip.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteOrderSlipRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteOrderSlipRaw", id);
		}

		/**
		 *  Getting order slip by identifier. 	
		 * @param id Identifier of order slip.
	 * @return {Response} Return PrestaShopOrderSlip. 
		 * @throws Exception
		 */
		public Response GetOrderSlipRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetOrderSlipRaw", id);
		}

		/**
		 *  Getting order slip identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopOrderSlip. 
		 * @throws Exception
		 */
		public Response GetOrderSlipIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetOrderSlipIdentifiersRaw");
		}

		/**
		 *  Getting order slip by rendering options. 	
		 * @param renderingOptions For request specified information about order slip use: display and filter or sort.
	 * @return {Response} Returns only certain information about OrderSlip in PrestaShopOrderSlip class. 
		 * @throws Exception
		 */
		public Response GetOrderSlipByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetOrderSlipByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Getting order state by identifier. 	
		 * @param id Identifier of order state.
	 * @return {Response} Return PrestaShopOrderState. 
		 * @throws Exception
		 */
		public Response GetOrderStateRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetOrderStateRaw", id);
		}

		/**
		 *  Getting order states identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopOrderState. 
		 * @throws Exception
		 */
		public Response GetOrderStatesIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetOrderStatesIdentifiersRaw");
		}

		/**
		 *  Getting order states by rendering options. 	
		 * @param renderingOptions For request specified information about order states use: display and filter or sort.
	 * @return {Response} Returns only certain information about OrderState in PrestaShopOrderState class. 
		 * @throws Exception
		 */
		public Response GetOrderStatesByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetOrderStatesByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Getting order by identifier. 	
		 * @param id Identifier of order.
	 * @return {Response} Return PrestaShopOrder. 
		 * @throws Exception
		 */
		public Response GetOrderRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetOrderRaw", id);
		}

		/**
		 *  Getting orders identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopOrder. 
		 * @throws Exception
		 */
		public Response GetOrdersIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetOrdersIdentifiersRaw");
		}

		/**
		 *  Getting orders by rendering options. 	
		 * @param renderingOptions For request specified information about orders use: display and filter or sort.
	 * @return {Response} Returns only certain information about Order in PrestaShopOrder class. 
		 * @throws Exception
		 */
		public Response GetOrdersByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetOrdersByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new price range. 	
		 * @param priceRange Body of price range.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddPriceRangeRaw(Object priceRange) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddPriceRangeRaw", priceRange);
		}

		/**
		 *  Update information in specified price range. 	
		 * @param priceRange Body of price range.
	 * @return {Response} Return updated PrestaShopPriceRange. 
		 * @throws Exception
		 */
		public Response EditPriceRangeRaw(Object priceRange) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditPriceRangeRaw", priceRange);
		}

		/**
		 *  Remove price range by identifier. 	
		 * @param id Identifier of price range.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeletePriceRangeRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeletePriceRangeRaw", id);
		}

		/**
		 *  Getting price range by identifier. 	
		 * @param id Identifier of price range.
	 * @return {Response} Return PrestaShopPriceRange. 
		 * @throws Exception
		 */
		public Response GetPriceRangeRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetPriceRangeRaw", id);
		}

		/**
		 *  Getting price ranges identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopPriceRange. 
		 * @throws Exception
		 */
		public Response GetPriceRangesIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetPriceRangesIdentifiersRaw");
		}

		/**
		 *  Getting price ranges by rendering options. 	
		 * @param renderingOptions For request specified information about price ranges use: display and filter or sort.
	 * @return {Response} Returns only certain information about PriceRange in PrestaShopPriceRange class. 
		 * @throws Exception
		 */
		public Response GetPriceRangesByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetPriceRangesByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new product customization field. 	
		 * @param productCustomizationField Body of product customization field.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddProductCustomizationFieldRaw(Object productCustomizationField) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddProductCustomizationFieldRaw", productCustomizationField);
		}

		/**
		 *  Update information in specified product customization field. 	
		 * @param productCustomizationField Body of product customization field.
	 * @return {Response} Return updated PrestaShopProductCustomizationField. 
		 * @throws Exception
		 */
		public Response EditProductCustomizationFieldRaw(Object productCustomizationField) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditProductCustomizationFieldRaw", productCustomizationField);
		}

		/**
		 *  Remove product customization field by identifier. 	
		 * @param id Identifier of product customization field.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteProductCustomizationFieldRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteProductCustomizationFieldRaw", id);
		}

		/**
		 *  Getting product customization field by identifier. 	
		 * @param id Identifier of product customization field.
	 * @return {Response} Return PrestaShopProductCustomizationField. 
		 * @throws Exception
		 */
		public Response GetProductCustomizationFieldRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetProductCustomizationFieldRaw", id);
		}

		/**
		 *  Getting product customization fields identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopProductCustomizationField. 
		 * @throws Exception
		 */
		public Response GetProductCustomizationFieldsIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetProductCustomizationFieldsIdentifiersRaw");
		}

		/**
		 *  Getting product customization fields by rendering options. 	
		 * @param renderingOptions For request specified information about product customization fields use: display and filter or sort.
	 * @return {Response} Returns only certain information about ProductCustomizationField in PrestaShopProductCustomizationField class. 
		 * @throws Exception
		 */
		public Response GetProductCustomizationFieldsByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetProductCustomizationFieldsByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new product feature value. 	
		 * @param productFeatureValue Body of product feature value.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddProductFeatureValueRaw(Object productFeatureValue) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddProductFeatureValueRaw", productFeatureValue);
		}

		/**
		 *  Update information in specified product feature value. 	
		 * @param productFeatureValue Body of product feature value.
	 * @return {Response} Return updated PrestaShopProductFeatureValue. 
		 * @throws Exception
		 */
		public Response EditProductFeatureValueRaw(Object productFeatureValue) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditProductFeatureValueRaw", productFeatureValue);
		}

		/**
		 *  Remove product feature value by identifier. 	
		 * @param id Identifier of product feature value.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteProductFeatureValueRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteProductFeatureValueRaw", id);
		}

		/**
		 *  Getting product feature value by identifier. 	
		 * @param id Identifier of product feature value.
	 * @return {Response} Return PrestaShopProductFeatureValue. 
		 * @throws Exception
		 */
		public Response GetProductFeatureValueRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetProductFeatureValueRaw", id);
		}

		/**
		 *  Getting product feature values identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopProductFeatureValue. 
		 * @throws Exception
		 */
		public Response GetProductFeatureValuesIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetProductFeatureValuesIdentifiersRaw");
		}

		/**
		 *  Getting product feature values by rendering options. 	
		 * @param renderingOptions For request specified information about product feature values use: display and filter or sort.
	 * @return {Response} Returns only certain information about ProductFeatureValue in PrestaShopProductFeatureValue class. 
		 * @throws Exception
		 */
		public Response GetProductFeatureValuesByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetProductFeatureValuesByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new product feature. 	
		 * @param productFeature Body of product feature.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddProductFeatureRaw(Object productFeature) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddProductFeatureRaw", productFeature);
		}

		/**
		 *  Update information in specified product feature. 	
		 * @param productFeature Body of product feature.
	 * @return {Response} Return updated PrestaShopProductFeature. 
		 * @throws Exception
		 */
		public Response EditProductFeatureRaw(Object productFeature) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditProductFeatureRaw", productFeature);
		}

		/**
		 *  Remove product feature by identifier. 	
		 * @param id Identifier of product feature.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteProductFeatureRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteProductFeatureRaw", id);
		}

		/**
		 *  Getting product feature by identifier. 	
		 * @param id Identifier of product feature.
	 * @return {Response} Return PrestaShopProductFeature. 
		 * @throws Exception
		 */
		public Response GetProductFeatureRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetProductFeatureRaw", id);
		}

		/**
		 *  Getting product features identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopProductFeature. 
		 * @throws Exception
		 */
		public Response GetProductFeaturesIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetProductFeaturesIdentifiersRaw");
		}

		/**
		 *  Getting product features by rendering options. 	
		 * @param renderingOptions For request specified information about product features use: display and filter or sort.
	 * @return {Response} Returns only certain information about ProductFeature in PrestaShopProductFeature class. 
		 * @throws Exception
		 */
		public Response GetProductFeaturesByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetProductFeaturesByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new product option value. 	
		 * @param productOptionValue Body of product option value.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddProductOptionValueRaw(Object productOptionValue) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddProductOptionValueRaw", productOptionValue);
		}

		/**
		 *  Update information in specified product option value. 	
		 * @param productOptionValue Body of product option value.
	 * @return {Response} Return updated PrestaShopProductOptionValue. 
		 * @throws Exception
		 */
		public Response EditProductOptionValueRaw(Object productOptionValue) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditProductOptionValueRaw", productOptionValue);
		}

		/**
		 *  Remove product option value by identifier. 	
		 * @param id Identifier of product option value.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteProductOptionValueRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteProductOptionValueRaw", id);
		}

		/**
		 *  Getting product option value by identifier. 	
		 * @param id Identifier of product option value.
	 * @return {Response} Return PrestaShopProductOptionValue. 
		 * @throws Exception
		 */
		public Response GetProductOptionValueRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetProductOptionValueRaw", id);
		}

		/**
		 *  Getting product option values identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopProductOptionValue. 
		 * @throws Exception
		 */
		public Response GetProductOptionValuesIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetProductOptionValuesIdentifiersRaw");
		}

		/**
		 *  Getting product option values by rendering options. 	
		 * @param renderingOptions For request specified information about product option values use: display and filter or sort.
	 * @return {Response} Returns only certain information about ProductOptionValue in PrestaShopProductOptionValue class. 
		 * @throws Exception
		 */
		public Response GetProductOptionValuesByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetProductOptionValuesByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new product option. 	
		 * @param productOption Body of product option.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddProductOptionRaw(Object productOption) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddProductOptionRaw", productOption);
		}

		/**
		 *  Update information in specified product option. 	
		 * @param productOption Body of product option.
	 * @return {Response} Return updated PrestaShopProductOption. 
		 * @throws Exception
		 */
		public Response EditProductOptionRaw(Object productOption) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditProductOptionRaw", productOption);
		}

		/**
		 *  Remove product option by identifier. 	
		 * @param id Identifier of product option.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteProductOptionRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteProductOptionRaw", id);
		}

		/**
		 *  Getting product option by identifier. 	
		 * @param id Identifier of product option.
	 * @return {Response} Return PrestaShopProductOption. 
		 * @throws Exception
		 */
		public Response GetProductOptionRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetProductOptionRaw", id);
		}

		/**
		 *  Getting product options identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopProductOption. 
		 * @throws Exception
		 */
		public Response GetProductOptionsIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetProductOptionsIdentifiersRaw");
		}

		/**
		 *  Getting product options by rendering options. 	
		 * @param renderingOptions For request specified information about product options use: display and filter or sort.
	 * @return {Response} Returns only certain information about ProductOption in PrestaShopProductOption class. 
		 * @throws Exception
		 */
		public Response GetProductOptionsByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetProductOptionsByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new product supplier. 	
		 * @param productSupplier Body of product supplier.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddProductSupplierRaw(Object productSupplier) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddProductSupplierRaw", productSupplier);
		}

		/**
		 *  Update information in specified product supplier. 	
		 * @param productSupplier Body of product supplier.
	 * @return {Response} Return updated PrestaShopProductSupplier. 
		 * @throws Exception
		 */
		public Response EditProductSupplierRaw(Object productSupplier) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditProductSupplierRaw", productSupplier);
		}

		/**
		 *  Remove product supplier by identifier. 	
		 * @param id Identifier of product supplier.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteProductSupplierRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteProductSupplierRaw", id);
		}

		/**
		 *  Getting product supplier by identifier. 	
		 * @param id Identifier of product supplier.
	 * @return {Response} Return PrestaShopProductSupplier. 
		 * @throws Exception
		 */
		public Response GetProductSupplierRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetProductSupplierRaw", id);
		}

		/**
		 *  Getting product suppliers identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopProductSupplier. 
		 * @throws Exception
		 */
		public Response GetProductSuppliersIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetProductSuppliersIdentifiersRaw");
		}

		/**
		 *  Getting product suppliers by rendering options. 	
		 * @param renderingOptions For request specified information about product suppliers use: display and filter or sort.
	 * @return {Response} Returns only certain information about ProductSupplier in PrestaShopProductSupplier class. 
		 * @throws Exception
		 */
		public Response GetProductSuppliersByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetProductSuppliersByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new product supplier. 	
		 * @param product Body of product supplier.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddProductRaw(Object product) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddProductRaw", product);
		}

		/**
		 *  Update information in specified product supplier. 	
		 * @param product Body of product supplier.
	 * @return {Response} Return updated PrestaShopProduct. 
		 * @throws Exception
		 */
		public Response EditProductRaw(Object product) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditProductRaw", product);
		}

		/**
		 *  Remove product by identifier. 	
		 * @param id Identifier of product.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteProductRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteProductRaw", id);
		}

		/**
		 *  Getting product by identifier. 	
		 * @param id Identifier of product.
	 * @return {Response} Return PrestaShopProduct. 
		 * @throws Exception
		 */
		public Response GetProductRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetProductRaw", id);
		}

		/**
		 *  Getting products identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopProduct. 
		 * @throws Exception
		 */
		public Response GetProductsIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetProductsIdentifiersRaw");
		}

		/**
		 *  Getting products by rendering options. 	
		 * @param renderingOptions For request specified information about products use: display and filter or sort.
	 * @return {Response} Returns only certain information about Product in PrestaShopProduct class. 
		 * @throws Exception
		 */
		public Response GetProductsByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetProductsByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new shop group. 	
		 * @param shopGroup Body of shop group.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddShopGroupRaw(Object shopGroup) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddShopGroupRaw", shopGroup);
		}

		/**
		 *  Update information in specified shop group. 	
		 * @param shopGroup Body of shop group.
	 * @return {Response} Return updated PrestaShopShopGroup. 
		 * @throws Exception
		 */
		public Response EditShopGroupRaw(Object shopGroup) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditShopGroupRaw", shopGroup);
		}

		/**
		 *  Remove shop group by identifier. 	
		 * @param id Identifier of shop group.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteShopGroupRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteShopGroupRaw", id);
		}

		/**
		 *  Update information in specified group. 	
		 * @param group Body of group.
	 * @return {Response} Return updated PrestaShopGroup. 
		 * @throws Exception
		 */
		public Response EditGroupRaw(Object group) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditGroupRaw", group);
		}

		/**
		 *  Remove group by identifier. 	
		 * @param id Identifier of group.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteGroupRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteGroupRaw", id);
		}

		/**
		 *  Getting group by identifier. 	
		 * @param id Identifier of group.
	 * @return {Response} Return PrestaShopGroup. 
		 * @throws Exception
		 */
		public Response GetGroupRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetGroupRaw", id);
		}

		/**
		 *  Getting groups identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopGroup. 
		 * @throws Exception
		 */
		public Response GetGroupsIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetGroupsIdentifiersRaw");
		}

		/**
		 *  Getting groups by rendering options. 	
		 * @param renderingOptions For request specified information about groups use: display and filter or sort.
	 * @return {Response} Returns only certain information about Group in PrestaShopGroup class. 
		 * @throws Exception
		 */
		public Response GetGroupsByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetGroupsByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new guest. 	
		 * @param guest Body of guest.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddGuestRaw(Object guest) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddGuestRaw", guest);
		}

		/**
		 *  Update information in specified guest. 	
		 * @param guest Body of guest.
	 * @return {Response} Return updated PrestaShopGuest. 
		 * @throws Exception
		 */
		public Response EditGuestRaw(Object guest) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditGuestRaw", guest);
		}

		/**
		 *  Remove guest by identifier. 	
		 * @param id Identifier of guest.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteGuestRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteGuestRaw", id);
		}

		/**
		 *  Getting guest by identifier. 	
		 * @param id Identifier of guest.
	 * @return {Response} Return PrestaShopGuest. 
		 * @throws Exception
		 */
		public Response GetGuestRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetGuestRaw", id);
		}

		/**
		 *  Getting guests identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopGuest. 
		 * @throws Exception
		 */
		public Response GetGuestsIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetGuestsIdentifiersRaw");
		}

		/**
		 *  Getting guests by rendering options. 	
		 * @param renderingOptions For request specified information about guests use: display and filter or sort.
	 * @return {Response} Returns only certain information about Guest in PrestaShopGuest class. 
		 * @throws Exception
		 */
		public Response GetGuestsByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetGuestsByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new image type. 	
		 * @param imageType Body of image type.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddImageTypeRaw(Object imageType) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddImageTypeRaw", imageType);
		}

		/**
		 *  Update information in specified image type. 	
		 * @param imageType Body of image type.
	 * @return {Response} Return updated PrestaShopImageType. 
		 * @throws Exception
		 */
		public Response EditImageTypeRaw(Object imageType) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditImageTypeRaw", imageType);
		}

		/**
		 *  Remove image type by identifier. 	
		 * @param id Identifier of image type.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteImageTypeRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteImageTypeRaw", id);
		}

		/**
		 *  Getting image type by identifier. 	
		 * @param id Identifier of image type.
	 * @return {Response} Return PrestaShopImageType. 
		 * @throws Exception
		 */
		public Response GetImageTypeRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetImageTypeRaw", id);
		}

		/**
		 *  Getting image types identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopImageType. 
		 * @throws Exception
		 */
		public Response GetImageTypesIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetImageTypesIdentifiersRaw");
		}

		/**
		 *  Getting image types by rendering options. 	
		 * @param renderingOptions For request specified information about image types use: display and filter or sort.
	 * @return {Response} Returns only certain information about ImageType in PrestaShopImageType class. 
		 * @throws Exception
		 */
		public Response GetImageTypesByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetImageTypesByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new image. 	
		 * @param image Body of image.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddImageRaw(Object image) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddImageRaw", image);
		}

		/**
		 *  Update information in specified image. 	
		 * @param image Body of image.
	 * @return {Response} Return updated PrestaShopImage. 
		 * @throws Exception
		 */
		public Response EditImageRaw(Object image) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditImageRaw", image);
		}

		/**
		 *  Remove image by identifier. 	
		 * @param id Identifier of image.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteImageRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteImageRaw", id);
		}

		/**
		 *  Getting image by identifier. 	
		 * @param id Identifier of image.
	 * @return {Response} Return PrestaShopImage. 
		 * @throws Exception
		 */
		public Response GetImageRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetImageRaw", id);
		}

		/**
		 *  Getting images identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopImage. 
		 * @throws Exception
		 */
		public Response GetImagesIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetImagesIdentifiersRaw");
		}

		/**
		 *  Getting images by rendering options. 	
		 * @param renderingOptions For request specified information about images use: display and filter or sort.
	 * @return {Response} Returns only certain information about Image in PrestaShopImage class. 
		 * @throws Exception
		 */
		public Response GetImagesByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetImagesByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new language. 	
		 * @param language Body of language.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddLanguageRaw(Object language) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddLanguageRaw", language);
		}

		/**
		 *  Update information in specified language. 	
		 * @param language Body of language.
	 * @return {Response} Return updated PrestaShopLanguage. 
		 * @throws Exception
		 */
		public Response EditLanguageRaw(Object language) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditLanguageRaw", language);
		}

		/**
		 *  Remove language by identifier. 	
		 * @param id Identifier of language.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteLanguageRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteLanguageRaw", id);
		}

		/**
		 *  Getting language by identifier. 	
		 * @param id Identifier of language.
	 * @return {Response} Return PrestaShopLanguage. 
		 * @throws Exception
		 */
		public Response GetLanguageRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetLanguageRaw", id);
		}

		/**
		 *  Getting languages identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopLanguage. 
		 * @throws Exception
		 */
		public Response GetLanguagesIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetLanguagesIdentifiersRaw");
		}

		/**
		 *  Getting languages by rendering options. 	
		 * @param renderingOptions For request specified information about languages use: display and filter or sort.
	 * @return {Response} Returns only certain information about Language in PrestaShopLanguage class. 
		 * @throws Exception
		 */
		public Response GetLanguagesByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetLanguagesByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new manufacturer. 	
		 * @param manufacturer Body of manufacturer.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddManufacturerRaw(Object manufacturer) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddManufacturerRaw", manufacturer);
		}

		/**
		 *  Update information in specified manufacturer. 	
		 * @param manufacturer Body of manufacturer.
	 * @return {Response} Return updated PrestaShopManufacturer. 
		 * @throws Exception
		 */
		public Response EditManufacturerRaw(Object manufacturer) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditManufacturerRaw", manufacturer);
		}

		/**
		 *  Remove manufacturer by identifier. 	
		 * @param id Identifier of manufacturer.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteManufacturerRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteManufacturerRaw", id);
		}

		/**
		 *  Getting manufacturer by identifier. 	
		 * @param id Identifier of manufacturer.
	 * @return {Response} Return PrestaShopManufacturer. 
		 * @throws Exception
		 */
		public Response GetManufacturerRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetManufacturerRaw", id);
		}

		/**
		 *  Getting manufacturers identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopManufacturer. 
		 * @throws Exception
		 */
		public Response GetManufacturersIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetManufacturersIdentifiersRaw");
		}

		/**
		 *  Getting manufacturers by rendering options. 	
		 * @param renderingOptions For request specified information about manufacturers use: display and filter or sort.
	 * @return {Response} Returns only certain information about Manufacturer in PrestaShopManufacturer class. 
		 * @throws Exception
		 */
		public Response GetManufacturersByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetManufacturersByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new message. 	
		 * @param message Body of message.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddMessageRaw(Object message) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddMessageRaw", message);
		}

		/**
		 *  Update information in specified message. 	
		 * @param message Body of message.
	 * @return {Response} Return updated PrestaShopMessage. 
		 * @throws Exception
		 */
		public Response EditMessageRaw(Object message) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditMessageRaw", message);
		}

		/**
		 *  Remove message by identifier. 	
		 * @param id Identifier of message.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteMessageRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteMessageRaw", id);
		}

		/**
		 *  Getting message by identifier. 	
		 * @param id Identifier of message.
	 * @return {Response} Return PrestaShopMessage. 
		 * @throws Exception
		 */
		public Response GetMessageRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetMessageRaw", id);
		}

		/**
		 *  Getting messages identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopMessage. 
		 * @throws Exception
		 */
		public Response GetMessagesIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetMessagesIdentifiersRaw");
		}

		/**
		 *  Getting messages by rendering options. 	
		 * @param renderingOptions For request specified information about messages use: display and filter or sort.
	 * @return {Response} Returns only certain information about Message in PrestaShopMessage class. 
		 * @throws Exception
		 */
		public Response GetMessagesByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetMessagesByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new order carrier. 	
		 * @param orderCarrier Body of order carrier.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddOrderCarrierRaw(Object orderCarrier) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddOrderCarrierRaw", orderCarrier);
		}

		/**
		 *  Update information in specified order carrier. 	
		 * @param orderCarrier Body of order carrier.
	 * @return {Response} Return updated PrestaShopOrderCarrier. 
		 * @throws Exception
		 */
		public Response EditOrderCarrierRaw(Object orderCarrier) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditOrderCarrierRaw", orderCarrier);
		}

		/**
		 *  Remove order carrier by identifier. 	
		 * @param id Identifier of order carrier.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteOrderCarrierRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteOrderCarrierRaw", id);
		}

		/**
		 *  Getting order carrier by identifier. 	
		 * @param id Identifier of order carrier.
	 * @return {Response} Return PrestaShopOrderCarrier. 
		 * @throws Exception
		 */
		public Response GetOrderCarrierRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetOrderCarrierRaw", id);
		}

		/**
		 *  Getting order carriers identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopOrderCarrier. 
		 * @throws Exception
		 */
		public Response GetOrderCarriersIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetOrderCarriersIdentifiersRaw");
		}

		/**
		 *  Getting order carriers by rendering options. 	
		 * @param renderingOptions For request specified information about order carriers use: display and filter or sort.
	 * @return {Response} Returns only certain information about OrderCarrier in PrestaShopOrderCarrier class. 
		 * @throws Exception
		 */
		public Response GetOrderCarriersByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetOrderCarriersByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Getting order detail by identifier. 	
		 * @param id Identifier of order detail.
	 * @return {Response} Return PrestaShopOrderDetail. 
		 * @throws Exception
		 */
		public Response GetOrderDetailRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetOrderDetailRaw", id);
		}

		/**
		 *  Getting order details identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopOrderDetail. 
		 * @throws Exception
		 */
		public Response GetOrderDetailsIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetOrderDetailsIdentifiersRaw");
		}

		/**
		 *  Getting order details by rendering options. 	
		 * @param renderingOptions For request specified information about order details use: display and filter or sort.
	 * @return {Response} Returns only certain information about OrderDetail in PrestaShopOrderDetail class. 
		 * @throws Exception
		 */
		public Response GetOrderDetailsByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetOrderDetailsByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Getting order history by identifier. 	
		 * @param id Identifier of order history.
	 * @return {Response} Return PrestaShopOrderHistory. 
		 * @throws Exception
		 */
		public Response GetOrderHistoryRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetOrderHistoryRaw", id);
		}

		/**
		 *  Getting order histories identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopOrderHistory. 
		 * @throws Exception
		 */
		public Response GetOrderHistoriesIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetOrderHistoriesIdentifiersRaw");
		}

		/**
		 *  Getting order histories by rendering options. 	
		 * @param renderingOptions For request specified information about order histories use: display and filter or sort.
	 * @return {Response} Returns only certain information about OrderHistory in PrestaShopOrderHistory class. 
		 * @throws Exception
		 */
		public Response GetOrderHistoriesByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetOrderHistoriesByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new order invoice. 	
		 * @param orderInvoice Body of order invoice.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddOrderInvoiceRaw(Object orderInvoice) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddOrderInvoiceRaw", orderInvoice);
		}

		/**
		 *  Update information in specified order invoice. 	
		 * @param orderInvoice Body of order invoice.
	 * @return {Response} Return updated PrestaShopOrderInvoice. 
		 * @throws Exception
		 */
		public Response EditOrderInvoiceRaw(Object orderInvoice) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditOrderInvoiceRaw", orderInvoice);
		}

		/**
		 *  Remove order invoice by identifier. 	
		 * @param id Identifier of order invoice.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteOrderInvoiceRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteOrderInvoiceRaw", id);
		}

		/**
		 *  Getting order invoice by identifier. 	
		 * @param id Identifier of order invoice.
	 * @return {Response} Return PrestaShopOrderInvoice. 
		 * @throws Exception
		 */
		public Response GetOrderInvoiceRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetOrderInvoiceRaw", id);
		}

		/**
		 *  Getting order invoices identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopOrderInvoice. 
		 * @throws Exception
		 */
		public Response GetOrderInvoicesIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetOrderInvoicesIdentifiersRaw");
		}

		/**
		 *  Getting order invoices by rendering options. 	
		 * @param renderingOptions For request specified information about order invoices use: display and filter or sort.
	 * @return {Response} Returns only certain information about OrderInvoice in PrestaShopOrderInvoice class. 
		 * @throws Exception
		 */
		public Response GetOrderInvoicesByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetOrderInvoicesByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new order payment. 	
		 * @param orderPayment Body of order payment.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddOrderPaymentRaw(Object orderPayment) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddOrderPaymentRaw", orderPayment);
		}

		/**
		 *  Update information in specified order payment. 	
		 * @param orderPayment Body of order payment.
	 * @return {Response} Return updated PrestaShopOrderPayment. 
		 * @throws Exception
		 */
		public Response EditOrderPaymentRaw(Object orderPayment) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditOrderPaymentRaw", orderPayment);
		}

		/**
		 *  Remove order payment by identifier. 	
		 * @param id Identifier of order payment.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteOrderPaymentRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteOrderPaymentRaw", id);
		}

		/**
		 *  Getting order payment by identifier. 	
		 * @param id Identifier of order payment.
	 * @return {Response} Return PrestaShopOrderPayment. 
		 * @throws Exception
		 */
		public Response GetOrderPaymentRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetOrderPaymentRaw", id);
		}

		/**
		 *  Getting order payments identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopOrderPayment. 
		 * @throws Exception
		 */
		public Response GetOrderPaymentsIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetOrderPaymentsIdentifiersRaw");
		}

		/**
		 *  Getting configuration by identifier. 	
		 * @param id Identifier of configuration.
	 * @return {Response} Return PrestaShopConfiguration. 
		 * @throws Exception
		 */
		public Response GetConfigurationRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetConfigurationRaw", id);
		}

		/**
		 *  Getting configurations identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopConfiguration. 
		 * @throws Exception
		 */
		public Response GetConfigurationsIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetConfigurationsIdentifiersRaw");
		}

		/**
		 *  Getting configurations by rendering options. 	
		 * @param renderingOptions For request specified information about configurations use: display and filter or sort.
	 * @return {Response} Returns only certain information about Configuration in PrestaShopConfiguration class. 
		 * @throws Exception
		 */
		public Response GetConfigurationsByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetConfigurationsByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new contact. 	
		 * @param contact Body of contact.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddContactRaw(Object contact) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddContactRaw", contact);
		}

		/**
		 *  Update information in specified contact. 	
		 * @param contact Body of contact.
	 * @return {Response} Return updated PrestaShopContact. 
		 * @throws Exception
		 */
		public Response EditContactRaw(Object contact) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditContactRaw", contact);
		}

		/**
		 *  Remove contact by identifier. 	
		 * @param id Identifier of contact.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteContactRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteContactRaw", id);
		}

		/**
		 *  Getting contact by identifier. 	
		 * @param id Identifier of contact.
	 * @return {Response} Return PrestaShopContact. 
		 * @throws Exception
		 */
		public Response GetContactRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetContactRaw", id);
		}

		/**
		 *  Getting contacts identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopContact. 
		 * @throws Exception
		 */
		public Response GetContactsIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetContactsIdentifiersRaw");
		}

		/**
		 *  Getting contacts by rendering options. 	
		 * @param renderingOptions For request specified information about contacts use: display and filter or sort.
	 * @return {Response} Returns only certain information about Contact in PrestaShopContact class. 
		 * @throws Exception
		 */
		public Response GetContactsByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetContactsByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new content management system. 	
		 * @param contentManagementSystem Body of content management system.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddContentManagementSystemRaw(Object contentManagementSystem) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddContentManagementSystemRaw", contentManagementSystem);
		}

		/**
		 *  Update information in specified content management system. 	
		 * @param contentManagementSystem Body of content management system.
	 * @return {Response} Return updated PrestaShopContentManagementSystem. 
		 * @throws Exception
		 */
		public Response EditContentManagementSystemRaw(Object contentManagementSystem) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditContentManagementSystemRaw", contentManagementSystem);
		}

		/**
		 *  Remove content management system by identifier. 	
		 * @param id Identifier of content management system.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteContentManagementSystemRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteContentManagementSystemRaw", id);
		}

		/**
		 *  Getting content management system by identifier. 	
		 * @param id Identifier of content management system.
	 * @return {Response} Return PrestaShopContentManagementSystem. 
		 * @throws Exception
		 */
		public Response GetContentManagementSystemRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetContentManagementSystemRaw", id);
		}

		/**
		 *  Getting content management system identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopContentManagementSystem. 
		 * @throws Exception
		 */
		public Response GetContentManagementSystemIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetContentManagementSystemIdentifiersRaw");
		}

		/**
		 *  Getting content management system by rendering options. 	
		 * @param renderingOptions For request specified information about content management system use: display and filter or sort.
	 * @return {Response} Returns only certain information about ContentManagementSystem in PrestaShopContentManagementSystem class. 
		 * @throws Exception
		 */
		public Response GetContentManagementSystemByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetContentManagementSystemByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new country. 	
		 * @param country Body of country.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddCountryRaw(Object country) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddCountryRaw", country);
		}

		/**
		 *  Update information in specified country. 	
		 * @param country Body of country.
	 * @return {Response} Return updated PrestaShopCountry. 
		 * @throws Exception
		 */
		public Response EditCountryRaw(Object country) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditCountryRaw", country);
		}

		/**
		 *  Remove country by identifier. 	
		 * @param id Identifier of country.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteCountryRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteCountryRaw", id);
		}

		/**
		 *  Getting country by identifier. 	
		 * @param id Identifier of country.
	 * @return {Response} Return PrestaShopCountry. 
		 * @throws Exception
		 */
		public Response GetCountryRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCountryRaw", id);
		}

		/**
		 *  Getting countries identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopCountry. 
		 * @throws Exception
		 */
		public Response GetCountriesIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCountriesIdentifiersRaw");
		}

		/**
		 *  Getting countries by rendering options. 	
		 * @param renderingOptions For request specified information about countries use: display and filter or sort.
	 * @return {Response} Returns only certain information about Country in PrestaShopCountry class. 
		 * @throws Exception
		 */
		public Response GetCountriesByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCountriesByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new currency. 	
		 * @param currency Body of currency.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddCurrencyRaw(Object currency) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddCurrencyRaw", currency);
		}

		/**
		 *  Update information in specified currency. 	
		 * @param currency Body of currency.
	 * @return {Response} Return updated PrestaShopCurrency. 
		 * @throws Exception
		 */
		public Response EditCurrencyRaw(Object currency) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditCurrencyRaw", currency);
		}

		/**
		 *  Remove currency by identifier. 	
		 * @param id Identifier of currency.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteCurrencyRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteCurrencyRaw", id);
		}

		/**
		 *  Getting currency by identifier. 	
		 * @param id Identifier of currency.
	 * @return {Response} Return PrestaShopCurrency. 
		 * @throws Exception
		 */
		public Response GetCurrencyRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCurrencyRaw", id);
		}

		/**
		 *  Getting currencies identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopCurrency. 
		 * @throws Exception
		 */
		public Response GetCurrenciesIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCurrenciesIdentifiersRaw");
		}

		/**
		 *  Getting currencies by rendering options. 	
		 * @param renderingOptions For request specified information about currencies use: display and filter or sort.
	 * @return {Response} Returns only certain information about Currency in PrestaShopCurrency class. 
		 * @throws Exception
		 */
		public Response GetCurrenciesByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCurrenciesByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new customer message. 	
		 * @param customerMessage Body of customer message.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddCustomerMessageRaw(Object customerMessage) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddCustomerMessageRaw", customerMessage);
		}

		/**
		 *  Update information in specified customer message. 	
		 * @param customerMessage Body of customer message.
	 * @return {Response} Return updated PrestaShopCustomerMessage. 
		 * @throws Exception
		 */
		public Response EditCustomerMessageRaw(Object customerMessage) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditCustomerMessageRaw", customerMessage);
		}

		/**
		 *  Remove customer message by identifier. 	
		 * @param id Identifier of customer message.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteCustomerMessageRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteCustomerMessageRaw", id);
		}

		/**
		 *  Getting customer message by identifier. 	
		 * @param id Identifier of customer message.
	 * @return {Response} Return PrestaShopCustomerMessage. 
		 * @throws Exception
		 */
		public Response GetCustomerMessageRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCustomerMessageRaw", id);
		}

		/**
		 *  Getting customer messages identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopCustomerMessage. 
		 * @throws Exception
		 */
		public Response GetCustomerMessagesIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCustomerMessagesIdentifiersRaw");
		}

		/**
		 *  Getting customer messages by rendering options. 	
		 * @param renderingOptions For request specified information about customer messages use: display and filter or sort.
	 * @return {Response} Returns only certain information about CustomerMessage in PrestaShopCustomerMessage class. 
		 * @throws Exception
		 */
		public Response GetCustomerMessagesByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCustomerMessagesByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new customer thread. 	
		 * @param customerThread Body of customer thread.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddCustomerThreadRaw(Object customerThread) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddCustomerThreadRaw", customerThread);
		}

		/**
		 *  Update information in specified customer thread. 	
		 * @param customerThread Body of customer thread.
	 * @return {Response} Return updated PrestaShopCustomerThread. 
		 * @throws Exception
		 */
		public Response EditCustomerThreadRaw(Object customerThread) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditCustomerThreadRaw", customerThread);
		}

		/**
		 *  Remove customer thread by identifier. 	
		 * @param id Identifier of customer thread.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteCustomerThreadRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteCustomerThreadRaw", id);
		}

		/**
		 *  Getting customer thread by identifier. 	
		 * @param id Identifier of customer thread.
	 * @return {Response} Return PrestaShopCustomerThread. 
		 * @throws Exception
		 */
		public Response GetCustomerThreadRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCustomerThreadRaw", id);
		}

		/**
		 *  Getting customer threads identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopCustomerThread. 
		 * @throws Exception
		 */
		public Response GetCustomerThreadsIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCustomerThreadsIdentifiersRaw");
		}

		/**
		 *  Getting customer threads by rendering options. 	
		 * @param renderingOptions For request specified information about customer threads use: display and filter or sort.
	 * @return {Response} Returns only certain information about CustomerThread in PrestaShopCustomerThread class. 
		 * @throws Exception
		 */
		public Response GetCustomerThreadsByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCustomerThreadsByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new customer. 	
		 * @param customer Body of customer.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddCustomerRaw(Object customer) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddCustomerRaw", customer);
		}

		/**
		 *  Update information in specified customer. 	
		 * @param customer Body of customer.
	 * @return {Response} Return updated PrestaShopCustomer. 
		 * @throws Exception
		 */
		public Response EditCustomerRaw(Object customer) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditCustomerRaw", customer);
		}

		/**
		 *  Remove customer by identifier. 	
		 * @param id Identifier of customer.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteCustomerRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteCustomerRaw", id);
		}

		/**
		 *  Getting customer by identifier. 	
		 * @param id Identifier of customer.
	 * @return {Response} Return PrestaShopCustomer. 
		 * @throws Exception
		 */
		public Response GetCustomerRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCustomerRaw", id);
		}

		/**
		 *  Getting customers identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopCustomer. 
		 * @throws Exception
		 */
		public Response GetCustomersIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCustomersIdentifiersRaw");
		}

		/**
		 *  Getting customers by rendering options. 	
		 * @param renderingOptions For request specified information about customers use: display and filter or sort.
	 * @return {Response} Returns only certain information about Customer in PrestaShopCustomer class. 
		 * @throws Exception
		 */
		public Response GetCustomersByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCustomersByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new customization. 	
		 * @param customization Body of customization.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddCustomizationRaw(Object customization) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddCustomizationRaw", customization);
		}

		/**
		 *  Update information in specified customization. 	
		 * @param customization Body of customization.
	 * @return {Response} Return updated PrestaShopCustomization. 
		 * @throws Exception
		 */
		public Response EditCustomizationRaw(Object customization) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditCustomizationRaw", customization);
		}

		/**
		 *  Remove customization by identifier. 	
		 * @param id Identifier of customization.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteCustomizationRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteCustomizationRaw", id);
		}

		/**
		 *  Getting customization by identifier. 	
		 * @param id Identifier of customization.
	 * @return {Response} Return PrestaShopCustomization. 
		 * @throws Exception
		 */
		public Response GetCustomizationRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCustomizationRaw", id);
		}

		/**
		 *  Getting customizations identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopCustomization. 
		 * @throws Exception
		 */
		public Response GetCustomizationsIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCustomizationsIdentifiersRaw");
		}

		/**
		 *  Getting customizations by rendering options. 	
		 * @param renderingOptions For request specified information about customizations use: display and filter or sort.
	 * @return {Response} Returns only certain information about Customization in PrestaShopCustomization class. 
		 * @throws Exception
		 */
		public Response GetCustomizationsByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCustomizationsByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new delivery. 	
		 * @param delivery Body of delivery.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddDeliveryRaw(Object delivery) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddDeliveryRaw", delivery);
		}

		/**
		 *  Update information in specified delivery. 	
		 * @param delivery Body of delivery.
	 * @return {Response} Return updated PrestaShopDelivery. 
		 * @throws Exception
		 */
		public Response EditDeliveryRaw(Object delivery) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditDeliveryRaw", delivery);
		}

		/**
		 *  Remove delivery by identifier. 	
		 * @param id Identifier of delivery.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteDeliveryRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteDeliveryRaw", id);
		}

		/**
		 *  Getting delivery by identifier. 	
		 * @param id Identifier of delivery.
	 * @return {Response} Return PrestaShopDelivery. 
		 * @throws Exception
		 */
		public Response GetDeliveryRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetDeliveryRaw", id);
		}

		/**
		 *  Getting deliveries identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopDelivery. 
		 * @throws Exception
		 */
		public Response GetDeliveriesIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetDeliveriesIdentifiersRaw");
		}

		/**
		 *  Getting deliveries by rendering options. 	
		 * @param renderingOptions For request specified information about deliveries use: display and filter or sort.
	 * @return {Response} Returns only certain information about Delivery in PrestaShopDelivery class. 
		 * @throws Exception
		 */
		public Response GetDeliveriesByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetDeliveriesByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new employee. 	
		 * @param employee Body of employee.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddEmployeeRaw(Object employee) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddEmployeeRaw", employee);
		}

		/**
		 *  Update information in specified employee. 	
		 * @param employee Body of employee.
	 * @return {Response} Return updated PrestaShopEmployee. 
		 * @throws Exception
		 */
		public Response EditEmployeeRaw(Object employee) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditEmployeeRaw", employee);
		}

		/**
		 *  Remove employee by identifier. 	
		 * @param id Identifier of employee.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteEmployeeRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteEmployeeRaw", id);
		}

		/**
		 *  Getting employee by identifier. 	
		 * @param id Identifier of employee.
	 * @return {Response} Return PrestaShopEmployee. 
		 * @throws Exception
		 */
		public Response GetEmployeeRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetEmployeeRaw", id);
		}

		/**
		 *  Getting employees identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopEmployee. 
		 * @throws Exception
		 */
		public Response GetEmployeesIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetEmployeesIdentifiersRaw");
		}

		/**
		 *  Getting employees by rendering options. 	
		 * @param renderingOptions For request specified information about employees use: display and filter or sort.
	 * @return {Response} Returns only certain information about Employee in PrestaShopEmployee class. 
		 * @throws Exception
		 */
		public Response GetEmployeesByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetEmployeesByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new group. 	
		 * @param group Body of group.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddGroupRaw(Object group) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddGroupRaw", group);
		}

		/**
		 *  Remove tax by identifier. 	
		 * @param id Identifier of tax.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteTax(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteTax", id);
		}

		/**
		 *  Getting tax by identifier. 	
		 * @param id Identifier of tax.
	 * @return {PrestaShopTax} Return PrestaShopTax. 
		 * @throws Exception
		 */
		public PrestaShopTax GetTax(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopTax>Call(PrestaShopTax.class, "PrestaShop", bNesisToken, "GetTax", id);
		}

		/**
		 *  Getting taxes by rendering options. 	
		 * @param renderingOptions For request specified information about taxes use: display and filter or sort.
	 * @return {PrestaShopTax[]} Returns only certain information about Tax in PrestaShopTax class. 
		 * @throws Exception
		 */
		public PrestaShopTax[] GetTaxesByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopTax[]>Call(PrestaShopTax[].class, "PrestaShop", bNesisToken, "GetTaxesByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting taxes identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopTax. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetTaxesIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetTaxesIdentifiers");
		}

		/**
		 *  Adding new translated configuration. 	
		 * @param translatedConfiguration Body of translated configuration.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddTranslatedConfiguration(PrestaShopTranslatedConfigurationIn translatedConfiguration) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddTranslatedConfiguration", translatedConfiguration);
		}

		/**
		 *  Update information in specified translated configuration. 	
		 * @param translatedConfiguration Body of translated configuration.
	 * @return {PrestaShopTranslatedConfiguration} Return updated PrestaShopTranslatedConfiguration. 
		 * @throws Exception
		 */
		public PrestaShopTranslatedConfiguration EditTranslatedConfiguration(PrestaShopTranslatedConfiguration translatedConfiguration) throws Exception
		{
			return _bNesisApi.<PrestaShopTranslatedConfiguration>Call(PrestaShopTranslatedConfiguration.class, "PrestaShop", bNesisToken, "EditTranslatedConfiguration", translatedConfiguration);
		}

		/**
		 *  Remove translated configuration by identifier. 	
		 * @param id Identifier of translated configuration.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteTranslatedConfiguration(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteTranslatedConfiguration", id);
		}

		/**
		 *  Getting translated configuration by identifier. 	
		 * @param id Identifier of translated configuration.
	 * @return {PrestaShopTranslatedConfiguration} Return PrestaShopTranslatedConfiguration. 
		 * @throws Exception
		 */
		public PrestaShopTranslatedConfiguration GetTranslatedConfiguration(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopTranslatedConfiguration>Call(PrestaShopTranslatedConfiguration.class, "PrestaShop", bNesisToken, "GetTranslatedConfiguration", id);
		}

		/**
		 *  Getting translated configurations by rendering options. 	
		 * @param renderingOptions For request specified information about translated configurations use: display and filter or sort.
	 * @return {PrestaShopTranslatedConfiguration[]} Returns only certain information about TranslatedConfiguration in PrestaShopTranslatedConfiguration class. 
		 * @throws Exception
		 */
		public PrestaShopTranslatedConfiguration[] GetTranslatedConfigurationsByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopTranslatedConfiguration[]>Call(PrestaShopTranslatedConfiguration[].class, "PrestaShop", bNesisToken, "GetTranslatedConfigurationsByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting translated configurations identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopTranslatedConfiguration. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetTranslatedConfigurationsIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetTranslatedConfigurationsIdentifiers");
		}

		/**
		 *  Getting warehouse product location by identifier. 	
		 * @param id Identifier of warehouse product location.
	 * @return {PrestaShopWarehouseProductLocation} Return PrestaShopWarehouseProductLocation. 
		 * @throws Exception
		 */
		public PrestaShopWarehouseProductLocation GetWarehouseProductLocation(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopWarehouseProductLocation>Call(PrestaShopWarehouseProductLocation.class, "PrestaShop", bNesisToken, "GetWarehouseProductLocation", id);
		}

		/**
		 *  Getting warehouse product locations by rendering options. 	
		 * @param renderingOptions For request specified information about warehouse product locations use: display and filter or sort.
	 * @return {PrestaShopWarehouseProductLocation[]} Returns only certain information about WarehouseProductLocation in PrestaShopWarehouseProductLocation class. 
		 * @throws Exception
		 */
		public PrestaShopWarehouseProductLocation[] GetWarehouseProductLocationsByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopWarehouseProductLocation[]>Call(PrestaShopWarehouseProductLocation[].class, "PrestaShop", bNesisToken, "GetWarehouseProductLocationsByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting warehouse product locations identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopWarehouseProductLocation. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetWarehouseProductLocationsIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetWarehouseProductLocationsIdentifiers");
		}

		/**
		 *  Adding new weight range. 	
		 * @param weightRange Body of weight range.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddWeightRange(PrestaShopWeightRangeIn weightRange) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddWeightRange", weightRange);
		}

		/**
		 *  Update information in specified weight range. 	
		 * @param weightRange Body of weight range.
	 * @return {PrestaShopWeightRange} Return updated PrestaShopWeightRange. 
		 * @throws Exception
		 */
		public PrestaShopWeightRange EditWeightRange(PrestaShopWeightRange weightRange) throws Exception
		{
			return _bNesisApi.<PrestaShopWeightRange>Call(PrestaShopWeightRange.class, "PrestaShop", bNesisToken, "EditWeightRange", weightRange);
		}

		/**
		 *  Remove weight range by identifier. 	
		 * @param id Identifier of weight range.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteWeightRange(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteWeightRange", id);
		}

		/**
		 *  Getting weight range by identifier. 	
		 * @param id Identifier of weight range.
	 * @return {PrestaShopWeightRange} Return PrestaShopWeightRange. 
		 * @throws Exception
		 */
		public PrestaShopWeightRange GetWeightRange(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopWeightRange>Call(PrestaShopWeightRange.class, "PrestaShop", bNesisToken, "GetWeightRange", id);
		}

		/**
		 *  Getting weight ranges by rendering options. 	
		 * @param renderingOptions For request specified information about weight ranges use: display and filter or sort.
	 * @return {PrestaShopWeightRange[]} Returns only certain information about WeightRange in PrestaShopWeightRange class. 
		 * @throws Exception
		 */
		public PrestaShopWeightRange[] GetWeightRangesByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopWeightRange[]>Call(PrestaShopWeightRange[].class, "PrestaShop", bNesisToken, "GetWeightRangesByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting weight ranges identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopWeightRange. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetWeightRangesIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetWeightRangesIdentifiers");
		}

		/**
		 *  Adding new zone. 	
		 * @param zone Body of zone.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddZone(PrestaShopZoneIn zone) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddZone", zone);
		}

		/**
		 *  Update information in specified zone. 	
		 * @param zone Body of zone.
	 * @return {PrestaShopZone} Return updated PrestaShopZone. 
		 * @throws Exception
		 */
		public PrestaShopZone EditZone(PrestaShopZone zone) throws Exception
		{
			return _bNesisApi.<PrestaShopZone>Call(PrestaShopZone.class, "PrestaShop", bNesisToken, "EditZone", zone);
		}

		/**
		 *  Remove zone by identifier. 	
		 * @param id Identifier of zone.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteZone(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteZone", id);
		}

		/**
		 *  Getting zone by identifier. 	
		 * @param id Identifier of zone.
	 * @return {PrestaShopZone} Return PrestaShopZone. 
		 * @throws Exception
		 */
		public PrestaShopZone GetZone(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopZone>Call(PrestaShopZone.class, "PrestaShop", bNesisToken, "GetZone", id);
		}

		/**
		 *  Getting zones by rendering options. 	
		 * @param renderingOptions For request specified information about zones use: display and filter or sort.
	 * @return {PrestaShopZone[]} Returns only certain information about Zone in PrestaShopZone class. 
		 * @throws Exception
		 */
		public PrestaShopZone[] GetZonesByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopZone[]>Call(PrestaShopZone[].class, "PrestaShop", bNesisToken, "GetZonesByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting zones identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopZone. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetZonesIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetZonesIdentifiers");
		}

		/**
		 *  Adding new address. 	
		 * @param address Body of address.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddAddressRaw(Object address) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddAddressRaw", address);
		}

		/**
		 *  Update information in specified address. 	
		 * @param address Body of address.
	 * @return {Response} Return updated PrestaShopAddress. 
		 * @throws Exception
		 */
		public Response EditAddressRaw(Object address) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditAddressRaw", address);
		}

		/**
		 *  Remove address by identifier. 	
		 * @param id Identifier of address.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteAddressRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteAddressRaw", id);
		}

		/**
		 *  Getting address by identifier. 	
		 * @param id Identifier of address.
	 * @return {Response} Return PrestaShopAddress. 
		 * @throws Exception
		 */
		public Response GetAddressRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetAddressRaw", id);
		}

		/**
		 *  Getting addresses identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopAddress. 
		 * @throws Exception
		 */
		public Response GetAddressesIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetAddressesIdentifiersRaw");
		}

		/**
		 *  Getting addresses by rendering options. 	
		 * @param renderingOptions For request specified information about addresses use: display and filter or sort.
	 * @return {Response} Returns only certain information about Address in PrestaShopAddress class. 
		 * @throws Exception
		 */
		public Response GetAddressesByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetAddressesByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new carrier. 	
		 * @param carrier Body of carrier.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddCarrierRaw(Object carrier) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddCarrierRaw", carrier);
		}

		/**
		 *  Update information in specified carrier. 	
		 * @param carrier Body of carrier.
	 * @return {Response} Return updated PrestaShopCarrier. 
		 * @throws Exception
		 */
		public Response EditCarrierRaw(Object carrier) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditCarrierRaw", carrier);
		}

		/**
		 *  Remove carrier by identifier. 	
		 * @param id Identifier of carrier.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteCarrierRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteCarrierRaw", id);
		}

		/**
		 *  Getting carrier by identifier. 	
		 * @param id Identifier of carrier.
	 * @return {Response} Return PrestaShopCarrier. 
		 * @throws Exception
		 */
		public Response GetCarrierRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCarrierRaw", id);
		}

		/**
		 *  Getting carriers identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopCarrier. 
		 * @throws Exception
		 */
		public Response GetCarriersIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCarriersIdentifiersRaw");
		}

		/**
		 *  Getting carriers by rendering options. 	
		 * @param renderingOptions For request specified information about carriers use: display and filter or sort.
	 * @return {Response} Returns only certain information about Carrier in PrestaShopCarrier class. 
		 * @throws Exception
		 */
		public Response GetCarriersByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCarriersByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new cart rule. 	
		 * @param cartRule Body of cart rule.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddCartRuleRaw(Object cartRule) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddCartRuleRaw", cartRule);
		}

		/**
		 *  Update information in specified cart rule. 	
		 * @param cartRule Body of cart rule.
	 * @return {Response} Return updated PrestaShopCartRule. 
		 * @throws Exception
		 */
		public Response EditCartRuleRaw(Object cartRule) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditCartRuleRaw", cartRule);
		}

		/**
		 *  Remove cart rule by identifier. 	
		 * @param id Identifier of cart rule.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteCartRuleRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteCartRuleRaw", id);
		}

		/**
		 *  Getting cart rule by identifier. 	
		 * @param id Identifier of cart rule.
	 * @return {Response} Return PrestaShopCartRule. 
		 * @throws Exception
		 */
		public Response GetCartRuleRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCartRuleRaw", id);
		}

		/**
		 *  Getting cart rules identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopCartRule. 
		 * @throws Exception
		 */
		public Response GetCartRulesIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCartRulesIdentifiersRaw");
		}

		/**
		 *  Getting cart rules by rendering options. 	
		 * @param renderingOptions For request specified information about cart rules use: display and filter or sort.
	 * @return {Response} Returns only certain information about CartRule in PrestaShopCartRule class. 
		 * @throws Exception
		 */
		public Response GetCartRulesByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCartRulesByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new cart. 	
		 * @param cart Body of cart.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddCartRaw(Object cart) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddCartRaw", cart);
		}

		/**
		 *  Update information in specified cart. 	
		 * @param cart Body of cart.
	 * @return {Response} Return updated PrestaShopCart. 
		 * @throws Exception
		 */
		public Response EditCartRaw(Object cart) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditCartRaw", cart);
		}

		/**
		 *  Remove cart by identifier. 	
		 * @param id Identifier of cart.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteCartRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteCartRaw", id);
		}

		/**
		 *  Getting cart by identifier. 	
		 * @param id Identifier of cart.
	 * @return {Response} Return PrestaShopCart. 
		 * @throws Exception
		 */
		public Response GetCartRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCartRaw", id);
		}

		/**
		 *  Getting carts identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopCart. 
		 * @throws Exception
		 */
		public Response GetCartsIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCartsIdentifiersRaw");
		}

		/**
		 *  Getting carts by rendering options. 	
		 * @param renderingOptions For request specified information about carts use: display and filter or sort.
	 * @return {Response} Returns only certain information about Cart in PrestaShopCart class. 
		 * @throws Exception
		 */
		public Response GetCartsByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCartsByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new category. 	
		 * @param category Body of category.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddCategoryRaw(Object category) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddCategoryRaw", category);
		}

		/**
		 *  Update information in specified category. 	
		 * @param category Body of category.
	 * @return {Response} Return updated PrestaShopCategory. 
		 * @throws Exception
		 */
		public Response EditCategoryRaw(Object category) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditCategoryRaw", category);
		}

		/**
		 *  Remove category by identifier. 	
		 * @param id Identifier of category.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteCategoryRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteCategoryRaw", id);
		}

		/**
		 *  Getting category by identifier. 	
		 * @param id Identifier of category.
	 * @return {Response} Return PrestaShopCategory. 
		 * @throws Exception
		 */
		public Response GetCategoryRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCategoryRaw", id);
		}

		/**
		 *  Getting categories identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopCategory. 
		 * @throws Exception
		 */
		public Response GetCategoriesIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCategoriesIdentifiersRaw");
		}

		/**
		 *  Getting categories by rendering options. 	
		 * @param renderingOptions For request specified information about categories use: display and filter or sort.
	 * @return {Response} Returns only certain information about Category in PrestaShopCategory class. 
		 * @throws Exception
		 */
		public Response GetCategoriesByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCategoriesByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new combination. 	
		 * @param combination Body of combination.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddCombinationRaw(Object combination) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddCombinationRaw", combination);
		}

		/**
		 *  Update information in specified combination. 	
		 * @param combination Body of combination.
	 * @return {Response} Return updated PrestaShopCombination. 
		 * @throws Exception
		 */
		public Response EditCombinationRaw(Object combination) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditCombinationRaw", combination);
		}

		/**
		 *  Remove combination by identifier. 	
		 * @param id Identifier of combination.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteCombinationRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteCombinationRaw", id);
		}

		/**
		 *  Getting combination by identifier. 	
		 * @param id Identifier of combination.
	 * @return {Response} Return PrestaShopCombination. 
		 * @throws Exception
		 */
		public Response GetCombinationRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCombinationRaw", id);
		}

		/**
		 *  Getting combinations identifiers. 	
		 * @return {Response} Return identifiers of PrestaShopCombination. 
		 * @throws Exception
		 */
		public Response GetCombinationsIdentifiersRaw() throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCombinationsIdentifiersRaw");
		}

		/**
		 *  Getting combinations by rendering options. 	
		 * @param renderingOptions For request specified information about combinations use: display and filter or sort.
	 * @return {Response} Returns only certain information about Combination in PrestaShopCombination class. 
		 * @throws Exception
		 */
		public Response GetCombinationsByRenderingOptionsRaw(Object renderingOptions) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "GetCombinationsByRenderingOptionsRaw", renderingOptions);
		}

		/**
		 *  Adding new configuration. 	
		 * @param configuration Body of configuration.
	 * @return {Response} If added return true. 
		 * @throws Exception
		 */
		public Response AddConfigurationRaw(Object configuration) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "AddConfigurationRaw", configuration);
		}

		/**
		 *  Update information in specified configuration. 	
		 * @param configuration Body of configuration.
	 * @return {Response} Return updated PrestaShopConfiguration. 
		 * @throws Exception
		 */
		public Response EditConfigurationRaw(Object configuration) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "EditConfigurationRaw", configuration);
		}

		/**
		 *  Remove configuration by identifier. 	
		 * @param id Identifier of configuration.
	 * @return {Response} If removed return true. 
		 * @throws Exception
		 */
		public Response DeleteConfigurationRaw(Integer id) throws Exception
		{
			return _bNesisApi.<Response>Call(Response.class, "PrestaShop", bNesisToken, "DeleteConfigurationRaw", id);
		}

		/**
		 *  Getting specific prices by rendering options. 	
		 * @param renderingOptions For request specified information about specific prices use: display and filter or sort.
	 * @return {PrestaShopSpecificPrice[]} Returns only certain information about SpecificPrice in PrestaShopSpecificPrice class. 
		 * @throws Exception
		 */
		public PrestaShopSpecificPrice[] GetSpecificPricesByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopSpecificPrice[]>Call(PrestaShopSpecificPrice[].class, "PrestaShop", bNesisToken, "GetSpecificPricesByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting specific prices identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopSpecificPrice. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetSpecificPricesIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetSpecificPricesIdentifiers");
		}

		/**
		 *  Getting state by identifier. 	
		 * @param id Identifier of state.
	 * @return {PrestaShopState} Return PrestaShopState. 
		 * @throws Exception
		 */
		public PrestaShopState GetState(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopState>Call(PrestaShopState.class, "PrestaShop", bNesisToken, "GetState", id);
		}

		/**
		 *  Getting states by rendering options. 	
		 * @param renderingOptions For request specified information about states use: display and filter or sort.
	 * @return {PrestaShopState[]} Returns only certain information about State in PrestaShopState class. 
		 * @throws Exception
		 */
		public PrestaShopState[] GetStatesByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopState[]>Call(PrestaShopState[].class, "PrestaShop", bNesisToken, "GetStatesByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting states identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopState. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetStatesIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetStatesIdentifiers");
		}

		/**
		 *  Adding new stock movement reason. 	
		 * @param stockMovementReason Body of stock movement reason.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddStockMovementReason(PrestaShopStockMovementReasonIn stockMovementReason) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddStockMovementReason", stockMovementReason);
		}

		/**
		 *  Update information in specified stock movement reason. 	
		 * @param stockMovementReason Body of stock movement reason.
	 * @return {PrestaShopStockMovementReason} Return updated PrestaShopStockMovementReason. 
		 * @throws Exception
		 */
		public PrestaShopStockMovementReason EditStockMovementReason(PrestaShopStockMovementReason stockMovementReason) throws Exception
		{
			return _bNesisApi.<PrestaShopStockMovementReason>Call(PrestaShopStockMovementReason.class, "PrestaShop", bNesisToken, "EditStockMovementReason", stockMovementReason);
		}

		/**
		 *  Remove stock movement reason by identifier. 	
		 * @param id Identifier of stock movement reason.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteStockMovementReason(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteStockMovementReason", id);
		}

		/**
		 *  Getting stock movement reason by identifier. 	
		 * @param id Identifier of stock movement reason.
	 * @return {PrestaShopStockMovementReason} Return PrestaShopStockMovementReason. 
		 * @throws Exception
		 */
		public PrestaShopStockMovementReason GetStockMovementReason(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopStockMovementReason>Call(PrestaShopStockMovementReason.class, "PrestaShop", bNesisToken, "GetStockMovementReason", id);
		}

		/**
		 *  Getting stock movement reasons by rendering options. 	
		 * @param renderingOptions For request specified information about stock movement reasons use: display and filter or sort.
	 * @return {PrestaShopStockMovementReason[]} Returns only certain information about StockMovementReason in PrestaShopStockMovementReason class. 
		 * @throws Exception
		 */
		public PrestaShopStockMovementReason[] GetStockMovementReasonsByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopStockMovementReason[]>Call(PrestaShopStockMovementReason[].class, "PrestaShop", bNesisToken, "GetStockMovementReasonsByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting stock movement reasons identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopStockMovementReason. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetStockMovementReasonsIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetStockMovementReasonsIdentifiers");
		}

		/**
		 *  Getting stock movement by identifier. 	
		 * @param id Identifier of stock movement.
	 * @return {PrestaShopStockMovement} Return PrestaShopStockMovement. 
		 * @throws Exception
		 */
		public PrestaShopStockMovement GetStockMovement(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopStockMovement>Call(PrestaShopStockMovement.class, "PrestaShop", bNesisToken, "GetStockMovement", id);
		}

		/**
		 *  Getting stock movements by rendering options. 	
		 * @param renderingOptions For request specified information about stock movements use: display and filter or sort.
	 * @return {PrestaShopStockMovement[]} Returns only certain information about StockMovement in PrestaShopStockMovement class. 
		 * @throws Exception
		 */
		public PrestaShopStockMovement[] GetStockMovementsByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopStockMovement[]>Call(PrestaShopStockMovement[].class, "PrestaShop", bNesisToken, "GetStockMovementsByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting stock movements identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopStockMovement. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetStockMovementsIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetStockMovementsIdentifiers");
		}

		/**
		 *  Getting stock by identifier. 	
		 * @param id Identifier of stock.
	 * @return {PrestaShopStock} Return PrestaShopStock. 
		 * @throws Exception
		 */
		public PrestaShopStock GetStock(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopStock>Call(PrestaShopStock.class, "PrestaShop", bNesisToken, "GetStock", id);
		}

		/**
		 *  Getting stocks by rendering options. 	
		 * @param renderingOptions For request specified information about stocks use: display and filter or sort.
	 * @return {PrestaShopStock[]} Returns only certain information about Stock in PrestaShopStock class. 
		 * @throws Exception
		 */
		public PrestaShopStock[] GetStocksByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopStock[]>Call(PrestaShopStock[].class, "PrestaShop", bNesisToken, "GetStocksByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting stocks identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopStock. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetStocksIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetStocksIdentifiers");
		}

		/**
		 *  Adding new store. 	
		 * @param store Body of store.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddStore(PrestaShopStoreIn store) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddStore", store);
		}

		/**
		 *  Update information in specified store. 	
		 * @param store Body of store.
	 * @return {PrestaShopStore} Return updated PrestaShopStore. 
		 * @throws Exception
		 */
		public PrestaShopStore EditStore(PrestaShopStore store) throws Exception
		{
			return _bNesisApi.<PrestaShopStore>Call(PrestaShopStore.class, "PrestaShop", bNesisToken, "EditStore", store);
		}

		/**
		 *  Remove store by identifier. 	
		 * @param id Identifier of store.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteStore(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteStore", id);
		}

		/**
		 *  Getting store by identifier. 	
		 * @param id Identifier of store.
	 * @return {PrestaShopStore} Return PrestaShopStore. 
		 * @throws Exception
		 */
		public PrestaShopStore GetStore(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopStore>Call(PrestaShopStore.class, "PrestaShop", bNesisToken, "GetStore", id);
		}

		/**
		 *  Getting stores by rendering options. 	
		 * @param renderingOptions For request specified information about stores use: display and filter or sort.
	 * @return {PrestaShopStore[]} Returns only certain information about Store in PrestaShopStore class. 
		 * @throws Exception
		 */
		public PrestaShopStore[] GetStoresByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopStore[]>Call(PrestaShopStore[].class, "PrestaShop", bNesisToken, "GetStoresByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting stores identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopStore. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetStoresIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetStoresIdentifiers");
		}

		/**
		 *  Adding new supplier. 	
		 * @param supplier Body of supplier.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddSupplier(PrestaShopSupplierIn supplier) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddSupplier", supplier);
		}

		/**
		 *  Update information in specified supplier. 	
		 * @param supplier Body of supplier.
	 * @return {PrestaShopSupplier} Return updated PrestaShopSupplier. 
		 * @throws Exception
		 */
		public PrestaShopSupplier EditSupplier(PrestaShopSupplier supplier) throws Exception
		{
			return _bNesisApi.<PrestaShopSupplier>Call(PrestaShopSupplier.class, "PrestaShop", bNesisToken, "EditSupplier", supplier);
		}

		/**
		 *  Remove supplier by identifier. 	
		 * @param id Identifier of supplier.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteSupplier(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteSupplier", id);
		}

		/**
		 *  Getting supplier by identifier. 	
		 * @param id Identifier of supplier.
	 * @return {PrestaShopSupplier} Return PrestaShopSupplier. 
		 * @throws Exception
		 */
		public PrestaShopSupplier GetSupplier(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopSupplier>Call(PrestaShopSupplier.class, "PrestaShop", bNesisToken, "GetSupplier", id);
		}

		/**
		 *  Getting suppliers by rendering options. 	
		 * @param renderingOptions For request specified information about suppliers use: display and filter or sort.
	 * @return {PrestaShopSupplier[]} Returns only certain information about Supplier in PrestaShopSupplier class. 
		 * @throws Exception
		 */
		public PrestaShopSupplier[] GetSuppliersByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopSupplier[]>Call(PrestaShopSupplier[].class, "PrestaShop", bNesisToken, "GetSuppliersByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting suppliers identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopSupplier. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetSuppliersIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetSuppliersIdentifiers");
		}

		/**
		 *  Getting supply order detail by identifier. 	
		 * @param id Identifier of supply order detail.
	 * @return {PrestaShopSupplyOrderDetail} Return PrestaShopSupplyOrderDetail. 
		 * @throws Exception
		 */
		public PrestaShopSupplyOrderDetail GetSupplyOrderDetail(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopSupplyOrderDetail>Call(PrestaShopSupplyOrderDetail.class, "PrestaShop", bNesisToken, "GetSupplyOrderDetail", id);
		}

		/**
		 *  Getting supply order details by rendering options. 	
		 * @param renderingOptions For request specified information about supply order details use: display and filter or sort.
	 * @return {PrestaShopSupplyOrderDetail[]} Returns only certain information about SupplyOrderDetail in PrestaShopSupplyOrderDetail class. 
		 * @throws Exception
		 */
		public PrestaShopSupplyOrderDetail[] GetSupplyOrderDetailsByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopSupplyOrderDetail[]>Call(PrestaShopSupplyOrderDetail[].class, "PrestaShop", bNesisToken, "GetSupplyOrderDetailsByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting supply order details identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopSupplyOrderDetail. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetSupplyOrderDetailsIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetSupplyOrderDetailsIdentifiers");
		}

		/**
		 *  Getting supply order history by identifier. 	
		 * @param id Identifier of supply order history.
	 * @return {PrestaShopSupplyOrderHistory} Return PrestaShopSupplyOrderHistory. 
		 * @throws Exception
		 */
		public PrestaShopSupplyOrderHistory GetSupplyOrderHistory(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopSupplyOrderHistory>Call(PrestaShopSupplyOrderHistory.class, "PrestaShop", bNesisToken, "GetSupplyOrderHistory", id);
		}

		/**
		 *  Getting supply order histories by rendering options. 	
		 * @param renderingOptions For request specified information about supply order histories use: display and filter or sort.
	 * @return {PrestaShopSupplyOrderHistory[]} Returns only certain information about SupplyOrderHistory in PrestaShopSupplyOrderHistory class. 
		 * @throws Exception
		 */
		public PrestaShopSupplyOrderHistory[] GetSupplyOrderHistoriesByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopSupplyOrderHistory[]>Call(PrestaShopSupplyOrderHistory[].class, "PrestaShop", bNesisToken, "GetSupplyOrderHistoriesByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting supply order histories identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopSupplyOrderHistory. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetSupplyOrderHistoriesIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetSupplyOrderHistoriesIdentifiers");
		}

		/**
		 *  Getting supply order receipt history by identifier. 	
		 * @param id Identifier of supply order receipt history.
	 * @return {PrestaShopSupplyOrderReceiptHistory} Return PrestaShopSupplyOrderReceiptHistory. 
		 * @throws Exception
		 */
		public PrestaShopSupplyOrderReceiptHistory GetSupplyOrderReceiptHistory(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopSupplyOrderReceiptHistory>Call(PrestaShopSupplyOrderReceiptHistory.class, "PrestaShop", bNesisToken, "GetSupplyOrderReceiptHistory", id);
		}

		/**
		 *  Getting supply order receipt histories by rendering options. 	
		 * @param renderingOptions For request specified information about supply order receipt histories use: display and filter or sort.
	 * @return {PrestaShopSupplyOrderReceiptHistory[]} Returns only certain information about SupplyOrderReceiptHistory in PrestaShopSupplyOrderReceiptHistory class. 
		 * @throws Exception
		 */
		public PrestaShopSupplyOrderReceiptHistory[] GetSupplyOrderReceiptHistoriesByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopSupplyOrderReceiptHistory[]>Call(PrestaShopSupplyOrderReceiptHistory[].class, "PrestaShop", bNesisToken, "GetSupplyOrderReceiptHistoriesByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting supply order receipt histories identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopSupplyOrderReceiptHistory. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetSupplyOrderReceiptHistoriesIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetSupplyOrderReceiptHistoriesIdentifiers");
		}

		/**
		 *  Getting supply order state by identifier. 	
		 * @param id Identifier of supply order state.
	 * @return {PrestaShopSupplyOrderState} Return PrestaShopSupplyOrderState. 
		 * @throws Exception
		 */
		public PrestaShopSupplyOrderState GetSupplyOrderState(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopSupplyOrderState>Call(PrestaShopSupplyOrderState.class, "PrestaShop", bNesisToken, "GetSupplyOrderState", id);
		}

		/**
		 *  Getting supply order states by rendering options. 	
		 * @param renderingOptions For request specified information about supply order states use: display and filter or sort.
	 * @return {PrestaShopSupplyOrderState[]} Returns only certain information about SupplyOrderState in PrestaShopSupplyOrderState class. 
		 * @throws Exception
		 */
		public PrestaShopSupplyOrderState[] GetSupplyOrderStatesByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopSupplyOrderState[]>Call(PrestaShopSupplyOrderState[].class, "PrestaShop", bNesisToken, "GetSupplyOrderStatesByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting supply order states identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopSupplyOrderState. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetSupplyOrderStatesIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetSupplyOrderStatesIdentifiers");
		}

		/**
		 *  Getting supply order by identifier. 	
		 * @param id Identifier of supply order.
	 * @return {PrestaShopSupplyOrder} Return PrestaShopSupplyOrder. 
		 * @throws Exception
		 */
		public PrestaShopSupplyOrder GetSupplyOrder(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopSupplyOrder>Call(PrestaShopSupplyOrder.class, "PrestaShop", bNesisToken, "GetSupplyOrder", id);
		}

		/**
		 *  Getting supply orders by rendering options. 	
		 * @param renderingOptions For request specified information about supply orders use: display and filter or sort.
	 * @return {PrestaShopSupplyOrder[]} Returns only certain information about SupplyOrder in PrestaShopSupplyOrder class. 
		 * @throws Exception
		 */
		public PrestaShopSupplyOrder[] GetSupplyOrdersByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopSupplyOrder[]>Call(PrestaShopSupplyOrder[].class, "PrestaShop", bNesisToken, "GetSupplyOrdersByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting supply orders identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopSupplyOrder. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetSupplyOrdersIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetSupplyOrdersIdentifiers");
		}

		/**
		 *  Adding new tag. 	
		 * @param tag Body of tag.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddTag(PrestaShopTagIn tag) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddTag", tag);
		}

		/**
		 *  Update information in specified tag. 	
		 * @param tag Body of tag.
	 * @return {PrestaShopTag} Return updated PrestaShopTag. 
		 * @throws Exception
		 */
		public PrestaShopTag EditTag(PrestaShopTag tag) throws Exception
		{
			return _bNesisApi.<PrestaShopTag>Call(PrestaShopTag.class, "PrestaShop", bNesisToken, "EditTag", tag);
		}

		/**
		 *  Remove tag by identifier. 	
		 * @param id Identifier of tag.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteTag(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteTag", id);
		}

		/**
		 *  Getting tag by identifier. 	
		 * @param id Identifier of tag.
	 * @return {PrestaShopTag} Return PrestaShopTag. 
		 * @throws Exception
		 */
		public PrestaShopTag GetTag(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopTag>Call(PrestaShopTag.class, "PrestaShop", bNesisToken, "GetTag", id);
		}

		/**
		 *  Getting tags by rendering options. 	
		 * @param renderingOptions For request specified information about tags use: display and filter or sort.
	 * @return {PrestaShopTag[]} Returns only certain information about Tag in PrestaShopTag class. 
		 * @throws Exception
		 */
		public PrestaShopTag[] GetTagsByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopTag[]>Call(PrestaShopTag[].class, "PrestaShop", bNesisToken, "GetTagsByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting tags identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopTag. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetTagsIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetTagsIdentifiers");
		}

		/**
		 *  Adding new tax rule group. 	
		 * @param taxRuleGroup Body of tax rule group.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddTaxRuleGroup(PrestaShopTaxRuleGroupIn taxRuleGroup) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddTaxRuleGroup", taxRuleGroup);
		}

		/**
		 *  Update information in specified tax rule group. 	
		 * @param taxRuleGroup Body of tax rule group.
	 * @return {PrestaShopTaxRuleGroup} Return updated PrestaShopTaxRuleGroup. 
		 * @throws Exception
		 */
		public PrestaShopTaxRuleGroup EditTaxRuleGroup(PrestaShopTaxRuleGroup taxRuleGroup) throws Exception
		{
			return _bNesisApi.<PrestaShopTaxRuleGroup>Call(PrestaShopTaxRuleGroup.class, "PrestaShop", bNesisToken, "EditTaxRuleGroup", taxRuleGroup);
		}

		/**
		 *  Remove tax rule group by identifier. 	
		 * @param id Identifier of tax rule group.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteTaxRuleGroup(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteTaxRuleGroup", id);
		}

		/**
		 *  Getting tax rule group by identifier. 	
		 * @param id Identifier of tax rule group.
	 * @return {PrestaShopTaxRuleGroup} Return PrestaShopTaxRuleGroup. 
		 * @throws Exception
		 */
		public PrestaShopTaxRuleGroup GetTaxRuleGroup(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopTaxRuleGroup>Call(PrestaShopTaxRuleGroup.class, "PrestaShop", bNesisToken, "GetTaxRuleGroup", id);
		}

		/**
		 *  Getting tax rule groups by rendering options. 	
		 * @param renderingOptions For request specified information about tax rule groups use: display and filter or sort.
	 * @return {PrestaShopTaxRuleGroup[]} Returns only certain information about TaxRuleGroup in PrestaShopTaxRuleGroup class. 
		 * @throws Exception
		 */
		public PrestaShopTaxRuleGroup[] GetTaxRuleGroupsByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopTaxRuleGroup[]>Call(PrestaShopTaxRuleGroup[].class, "PrestaShop", bNesisToken, "GetTaxRuleGroupsByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting tax rule groups identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopTaxRuleGroup. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetTaxRuleGroupsIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetTaxRuleGroupsIdentifiers");
		}

		/**
		 *  Adding new tax rule. 	
		 * @param taxRule Body of tax rule.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddTaxRule(PrestaShopTaxRuleIn taxRule) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddTaxRule", taxRule);
		}

		/**
		 *  Update information in specified tax rule. 	
		 * @param taxRule Body of tax rule.
	 * @return {PrestaShopTaxRule} Return updated PrestaShopTaxRule. 
		 * @throws Exception
		 */
		public PrestaShopTaxRule EditTaxRule(PrestaShopTaxRule taxRule) throws Exception
		{
			return _bNesisApi.<PrestaShopTaxRule>Call(PrestaShopTaxRule.class, "PrestaShop", bNesisToken, "EditTaxRule", taxRule);
		}

		/**
		 *  Remove tax rule by identifier. 	
		 * @param id Identifier of tax rule.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteTaxRule(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteTaxRule", id);
		}

		/**
		 *  Getting tax rule by identifier. 	
		 * @param id Identifier of tax rule.
	 * @return {PrestaShopTaxRule} Return PrestaShopTaxRule. 
		 * @throws Exception
		 */
		public PrestaShopTaxRule GetTaxRule(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopTaxRule>Call(PrestaShopTaxRule.class, "PrestaShop", bNesisToken, "GetTaxRule", id);
		}

		/**
		 *  Getting tax rules by rendering options. 	
		 * @param renderingOptions For request specified information about tax rules use: display and filter or sort.
	 * @return {PrestaShopTaxRule[]} Returns only certain information about TaxRule in PrestaShopTaxRule class. 
		 * @throws Exception
		 */
		public PrestaShopTaxRule[] GetTaxRulesByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopTaxRule[]>Call(PrestaShopTaxRule[].class, "PrestaShop", bNesisToken, "GetTaxRulesByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting tax rules identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopTaxRule. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetTaxRulesIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetTaxRulesIdentifiers");
		}

		/**
		 *  Adding new tax. 	
		 * @param tax Body of tax.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddTax(PrestaShopTaxIn tax) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddTax", tax);
		}

		/**
		 *  Update information in specified tax. 	
		 * @param tax Body of tax.
	 * @return {PrestaShopTax} Return updated PrestaShopTax. 
		 * @throws Exception
		 */
		public PrestaShopTax EditTax(PrestaShopTax tax) throws Exception
		{
			return _bNesisApi.<PrestaShopTax>Call(PrestaShopTax.class, "PrestaShop", bNesisToken, "EditTax", tax);
		}

		/**
		 *  Adding new product feature value. 	
		 * @param productFeatureValue Body of product feature value.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddProductFeatureValue(PrestaShopProductFeatureValueIn productFeatureValue) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddProductFeatureValue", productFeatureValue);
		}

		/**
		 *  Update information in specified product feature value. 	
		 * @param productFeatureValue Body of product feature value.
	 * @return {PrestaShopProductFeatureValue} Return updated PrestaShopProductFeatureValue. 
		 * @throws Exception
		 */
		public PrestaShopProductFeatureValue EditProductFeatureValue(PrestaShopProductFeatureValue productFeatureValue) throws Exception
		{
			return _bNesisApi.<PrestaShopProductFeatureValue>Call(PrestaShopProductFeatureValue.class, "PrestaShop", bNesisToken, "EditProductFeatureValue", productFeatureValue);
		}

		/**
		 *  Remove product feature value by identifier. 	
		 * @param id Identifier of product feature value.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteProductFeatureValue(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteProductFeatureValue", id);
		}

		/**
		 *  Getting product feature value by identifier. 	
		 * @param id Identifier of product feature value.
	 * @return {PrestaShopProductFeatureValue} Return PrestaShopProductFeatureValue. 
		 * @throws Exception
		 */
		public PrestaShopProductFeatureValue GetProductFeatureValue(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopProductFeatureValue>Call(PrestaShopProductFeatureValue.class, "PrestaShop", bNesisToken, "GetProductFeatureValue", id);
		}

		/**
		 *  Getting product feature values by rendering options. 	
		 * @param renderingOptions For request specified information about product feature values use: display and filter or sort.
	 * @return {PrestaShopProductFeatureValue[]} Returns only certain information about ProductFeatureValue in PrestaShopProductFeatureValue class. 
		 * @throws Exception
		 */
		public PrestaShopProductFeatureValue[] GetProductFeatureValuesByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopProductFeatureValue[]>Call(PrestaShopProductFeatureValue[].class, "PrestaShop", bNesisToken, "GetProductFeatureValuesByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting product feature values identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopProductFeatureValue. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetProductFeatureValuesIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetProductFeatureValuesIdentifiers");
		}

		/**
		 *  Adding new product feature. 	
		 * @param productFeature Body of product feature.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddProductFeature(PrestaShopProductFeatureIn productFeature) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddProductFeature", productFeature);
		}

		/**
		 *  Update information in specified product feature. 	
		 * @param productFeature Body of product feature.
	 * @return {PrestaShopProductFeature} Return updated PrestaShopProductFeature. 
		 * @throws Exception
		 */
		public PrestaShopProductFeature EditProductFeature(PrestaShopProductFeature productFeature) throws Exception
		{
			return _bNesisApi.<PrestaShopProductFeature>Call(PrestaShopProductFeature.class, "PrestaShop", bNesisToken, "EditProductFeature", productFeature);
		}

		/**
		 *  Remove product feature by identifier. 	
		 * @param id Identifier of product feature.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteProductFeature(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteProductFeature", id);
		}

		/**
		 *  Getting product feature by identifier. 	
		 * @param id Identifier of product feature.
	 * @return {PrestaShopProductFeature} Return PrestaShopProductFeature. 
		 * @throws Exception
		 */
		public PrestaShopProductFeature GetProductFeature(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopProductFeature>Call(PrestaShopProductFeature.class, "PrestaShop", bNesisToken, "GetProductFeature", id);
		}

		/**
		 *  Getting product features by rendering options. 	
		 * @param renderingOptions For request specified information about product features use: display and filter or sort.
	 * @return {PrestaShopProductFeature[]} Returns only certain information about ProductFeature in PrestaShopProductFeature class. 
		 * @throws Exception
		 */
		public PrestaShopProductFeature[] GetProductFeaturesByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopProductFeature[]>Call(PrestaShopProductFeature[].class, "PrestaShop", bNesisToken, "GetProductFeaturesByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting product features identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopProductFeature. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetProductFeaturesIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetProductFeaturesIdentifiers");
		}

		/**
		 *  Adding new product option value. 	
		 * @param productOptionValue Body of product option value.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddProductOptionValue(PrestaShopProductOptionValueIn productOptionValue) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddProductOptionValue", productOptionValue);
		}

		/**
		 *  Update information in specified product option value. 	
		 * @param productOptionValue Body of product option value.
	 * @return {PrestaShopProductOptionValue} Return updated PrestaShopProductOptionValue. 
		 * @throws Exception
		 */
		public PrestaShopProductOptionValue EditProductOptionValue(PrestaShopProductOptionValue productOptionValue) throws Exception
		{
			return _bNesisApi.<PrestaShopProductOptionValue>Call(PrestaShopProductOptionValue.class, "PrestaShop", bNesisToken, "EditProductOptionValue", productOptionValue);
		}

		/**
		 *  Remove product option value by identifier. 	
		 * @param id Identifier of product option value.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteProductOptionValue(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteProductOptionValue", id);
		}

		/**
		 *  Getting product option value by identifier. 	
		 * @param id Identifier of product option value.
	 * @return {PrestaShopProductOptionValue} Return PrestaShopProductOptionValue. 
		 * @throws Exception
		 */
		public PrestaShopProductOptionValue GetProductOptionValue(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopProductOptionValue>Call(PrestaShopProductOptionValue.class, "PrestaShop", bNesisToken, "GetProductOptionValue", id);
		}

		/**
		 *  Getting product option values by rendering options. 	
		 * @param renderingOptions For request specified information about product option values use: display and filter or sort.
	 * @return {PrestaShopProductOptionValue[]} Returns only certain information about ProductOptionValue in PrestaShopProductOptionValue class. 
		 * @throws Exception
		 */
		public PrestaShopProductOptionValue[] GetProductOptionValuesByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopProductOptionValue[]>Call(PrestaShopProductOptionValue[].class, "PrestaShop", bNesisToken, "GetProductOptionValuesByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting product option values identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopProductOptionValue. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetProductOptionValuesIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetProductOptionValuesIdentifiers");
		}

		/**
		 *  Adding new product option. 	
		 * @param productOption Body of product option.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddProductOption(PrestaShopProductOptionIn productOption) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddProductOption", productOption);
		}

		/**
		 *  Update information in specified product option. 	
		 * @param productOption Body of product option.
	 * @return {PrestaShopProductOption} Return updated PrestaShopProductOption. 
		 * @throws Exception
		 */
		public PrestaShopProductOption EditProductOption(PrestaShopProductOption productOption) throws Exception
		{
			return _bNesisApi.<PrestaShopProductOption>Call(PrestaShopProductOption.class, "PrestaShop", bNesisToken, "EditProductOption", productOption);
		}

		/**
		 *  Remove product option by identifier. 	
		 * @param id Identifier of product option.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteProductOption(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteProductOption", id);
		}

		/**
		 *  Getting product option by identifier. 	
		 * @param id Identifier of product option.
	 * @return {PrestaShopProductOption} Return PrestaShopProductOption. 
		 * @throws Exception
		 */
		public PrestaShopProductOption GetProductOption(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopProductOption>Call(PrestaShopProductOption.class, "PrestaShop", bNesisToken, "GetProductOption", id);
		}

		/**
		 *  Getting product options by rendering options. 	
		 * @param renderingOptions For request specified information about product options use: display and filter or sort.
	 * @return {PrestaShopProductOption[]} Returns only certain information about ProductOption in PrestaShopProductOption class. 
		 * @throws Exception
		 */
		public PrestaShopProductOption[] GetProductOptionsByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopProductOption[]>Call(PrestaShopProductOption[].class, "PrestaShop", bNesisToken, "GetProductOptionsByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting product options identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopProductOption. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetProductOptionsIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetProductOptionsIdentifiers");
		}

		/**
		 *  Adding new product supplier. 	
		 * @param productSupplier Body of product supplier.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddProductSupplier(PrestaShopProductSupplierIn productSupplier) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddProductSupplier", productSupplier);
		}

		/**
		 *  Update information in specified product supplier. 	
		 * @param productSupplier Body of product supplier.
	 * @return {PrestaShopProductSupplier} Return updated PrestaShopProductSupplier. 
		 * @throws Exception
		 */
		public PrestaShopProductSupplier EditProductSupplier(PrestaShopProductSupplier productSupplier) throws Exception
		{
			return _bNesisApi.<PrestaShopProductSupplier>Call(PrestaShopProductSupplier.class, "PrestaShop", bNesisToken, "EditProductSupplier", productSupplier);
		}

		/**
		 *  Remove product supplier by identifier. 	
		 * @param id Identifier of product supplier.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteProductSupplier(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteProductSupplier", id);
		}

		/**
		 *  Getting product supplier by identifier. 	
		 * @param id Identifier of product supplier.
	 * @return {PrestaShopProductSupplier} Return PrestaShopProductSupplier. 
		 * @throws Exception
		 */
		public PrestaShopProductSupplier GetProductSupplier(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopProductSupplier>Call(PrestaShopProductSupplier.class, "PrestaShop", bNesisToken, "GetProductSupplier", id);
		}

		/**
		 *  Getting product suppliers by rendering options. 	
		 * @param renderingOptions For request specified information about product suppliers use: display and filter or sort.
	 * @return {PrestaShopProductSupplier[]} Returns only certain information about ProductSupplier in PrestaShopProductSupplier class. 
		 * @throws Exception
		 */
		public PrestaShopProductSupplier[] GetProductSuppliersByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopProductSupplier[]>Call(PrestaShopProductSupplier[].class, "PrestaShop", bNesisToken, "GetProductSuppliersByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting product suppliers identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopProductSupplier. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetProductSuppliersIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetProductSuppliersIdentifiers");
		}

		/**
		 *  Adding new product supplier. 	
		 * @param product Body of product supplier.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddProduct(PrestaShopProductIn product) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddProduct", product);
		}

		/**
		 *  Update information in specified product supplier. 	
		 * @param product Body of product supplier.
	 * @return {PrestaShopProduct} Return updated PrestaShopProduct. 
		 * @throws Exception
		 */
		public PrestaShopProduct EditProduct(PrestaShopProduct product) throws Exception
		{
			return _bNesisApi.<PrestaShopProduct>Call(PrestaShopProduct.class, "PrestaShop", bNesisToken, "EditProduct", product);
		}

		/**
		 *  Remove product by identifier. 	
		 * @param id Identifier of product.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteProduct(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteProduct", id);
		}

		/**
		 *  Getting product by identifier. 	
		 * @param id Identifier of product.
	 * @return {PrestaShopProduct} Return PrestaShopProduct. 
		 * @throws Exception
		 */
		public PrestaShopProduct GetProduct(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopProduct>Call(PrestaShopProduct.class, "PrestaShop", bNesisToken, "GetProduct", id);
		}

		/**
		 *  Getting products by rendering options. 	
		 * @param renderingOptions For request specified information about products use: display and filter or sort.
	 * @return {PrestaShopProduct[]} Returns only certain information about Product in PrestaShopProduct class. 
		 * @throws Exception
		 */
		public PrestaShopProduct[] GetProductsByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopProduct[]>Call(PrestaShopProduct[].class, "PrestaShop", bNesisToken, "GetProductsByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting products identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopProduct. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetProductsIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetProductsIdentifiers");
		}

		/**
		 *  Adding new shop group. 	
		 * @param shopGroup Body of shop group.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddShopGroup(PrestaShopShopGroupIn shopGroup) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddShopGroup", shopGroup);
		}

		/**
		 *  Update information in specified shop group. 	
		 * @param shopGroup Body of shop group.
	 * @return {PrestaShopShopGroup} Return updated PrestaShopShopGroup. 
		 * @throws Exception
		 */
		public PrestaShopShopGroup EditShopGroup(PrestaShopShopGroup shopGroup) throws Exception
		{
			return _bNesisApi.<PrestaShopShopGroup>Call(PrestaShopShopGroup.class, "PrestaShop", bNesisToken, "EditShopGroup", shopGroup);
		}

		/**
		 *  Remove shop group by identifier. 	
		 * @param id Identifier of shop group.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteShopGroup(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteShopGroup", id);
		}

		/**
		 *  Getting shop group by identifier. 	
		 * @param id Identifier of shop group.
	 * @return {PrestaShopShopGroup} Return PrestaShopShopGroup. 
		 * @throws Exception
		 */
		public PrestaShopShopGroup GetShopGroup(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopShopGroup>Call(PrestaShopShopGroup.class, "PrestaShop", bNesisToken, "GetShopGroup", id);
		}

		/**
		 *  Getting shop groups by rendering options. 	
		 * @param renderingOptions For request specified information about shop groups use: display and filter or sort.
	 * @return {PrestaShopShopGroup[]} Returns only certain information about ShopGroup in PrestaShopShopGroup class. 
		 * @throws Exception
		 */
		public PrestaShopShopGroup[] GetShopGroupsByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopShopGroup[]>Call(PrestaShopShopGroup[].class, "PrestaShop", bNesisToken, "GetShopGroupsByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting shop groups identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopShopGroup. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetShopGroupsIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetShopGroupsIdentifiers");
		}

		/**
		 *  Adding new shop url. 	
		 * @param shopUrl Body of shop url.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddShopUrl(PrestaShopShopUrlIn shopUrl) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddShopUrl", shopUrl);
		}

		/**
		 *  Update information in specified shop url. 	
		 * @param shopUrl Body of shop url.
	 * @return {PrestaShopShopUrl} Return updated PrestaShopShopUrl. 
		 * @throws Exception
		 */
		public PrestaShopShopUrl EditShopUrl(PrestaShopShopUrl shopUrl) throws Exception
		{
			return _bNesisApi.<PrestaShopShopUrl>Call(PrestaShopShopUrl.class, "PrestaShop", bNesisToken, "EditShopUrl", shopUrl);
		}

		/**
		 *  Remove shop url by identifier. 	
		 * @param id Identifier of shop url.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteShopUrl(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteShopUrl", id);
		}

		/**
		 *  Getting shop url by identifier. 	
		 * @param id Identifier of shop url.
	 * @return {PrestaShopShopUrl} Return PrestaShopShopUrl. 
		 * @throws Exception
		 */
		public PrestaShopShopUrl GetShopUrl(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopShopUrl>Call(PrestaShopShopUrl.class, "PrestaShop", bNesisToken, "GetShopUrl", id);
		}

		/**
		 *  Getting shop urls by rendering options. 	
		 * @param renderingOptions For request specified information about shop urls use: display and filter or sort.
	 * @return {PrestaShopShopUrl[]} Returns only certain information about ShopUrl in PrestaShopShopUrl class. 
		 * @throws Exception
		 */
		public PrestaShopShopUrl[] GetShopUrlsByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopShopUrl[]>Call(PrestaShopShopUrl[].class, "PrestaShop", bNesisToken, "GetShopUrlsByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting shop urls identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopShopUrl. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetShopUrlsIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetShopUrlsIdentifiers");
		}

		/**
		 *  Adding new shop. 	
		 * @param shop Body of shop.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddShop(PrestaShopShopIn shop) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddShop", shop);
		}

		/**
		 *  Update information in specified shop. 	
		 * @param shop Body of shop.
	 * @return {PrestaShopShop} Return updated PrestaShopShop. 
		 * @throws Exception
		 */
		public PrestaShopShop EditShop(PrestaShopShop shop) throws Exception
		{
			return _bNesisApi.<PrestaShopShop>Call(PrestaShopShop.class, "PrestaShop", bNesisToken, "EditShop", shop);
		}

		/**
		 *  Remove shop by identifier. 	
		 * @param id Identifier of shop.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteShop(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteShop", id);
		}

		/**
		 *  Getting shop by identifier. 	
		 * @param id Identifier of shop.
	 * @return {PrestaShopShop} Return PrestaShopShop. 
		 * @throws Exception
		 */
		public PrestaShopShop GetShop(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopShop>Call(PrestaShopShop.class, "PrestaShop", bNesisToken, "GetShop", id);
		}

		/**
		 *  Getting shops by rendering options. 	
		 * @param renderingOptions For request specified information about shops use: display and filter or sort.
	 * @return {PrestaShopShop[]} Returns only certain information about Shop in PrestaShopShop class. 
		 * @throws Exception
		 */
		public PrestaShopShop[] GetShopsByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopShop[]>Call(PrestaShopShop[].class, "PrestaShop", bNesisToken, "GetShopsByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting shops identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopShop. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetShopsIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetShopsIdentifiers");
		}

		/**
		 *  Adding new specific price rule. 	
		 * @param specificPriceRule Body of specific price rule.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddSpecificPriceRule(PrestaShopSpecificPriceRuleIn specificPriceRule) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddSpecificPriceRule", specificPriceRule);
		}

		/**
		 *  Update information in specified specific price rule. 	
		 * @param specificPriceRule Body of specific price rule.
	 * @return {PrestaShopSpecificPriceRule} Return updated PrestaShopSpecificPriceRule. 
		 * @throws Exception
		 */
		public PrestaShopSpecificPriceRule EditSpecificPriceRule(PrestaShopSpecificPriceRule specificPriceRule) throws Exception
		{
			return _bNesisApi.<PrestaShopSpecificPriceRule>Call(PrestaShopSpecificPriceRule.class, "PrestaShop", bNesisToken, "EditSpecificPriceRule", specificPriceRule);
		}

		/**
		 *  Remove specific price rule by identifier. 	
		 * @param id Identifier of specific price rule.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteSpecificPriceRule(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteSpecificPriceRule", id);
		}

		/**
		 *  Getting specific price rule by identifier. 	
		 * @param id Identifier of specific price rule.
	 * @return {PrestaShopSpecificPriceRule} Return PrestaShopSpecificPriceRule. 
		 * @throws Exception
		 */
		public PrestaShopSpecificPriceRule GetSpecificPriceRule(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopSpecificPriceRule>Call(PrestaShopSpecificPriceRule.class, "PrestaShop", bNesisToken, "GetSpecificPriceRule", id);
		}

		/**
		 *  Getting specific price rules by rendering options. 	
		 * @param renderingOptions For request specified information about specific price rules use: display and filter or sort.
	 * @return {PrestaShopSpecificPriceRule[]} Returns only certain information about SpecificPriceRule in PrestaShopSpecificPriceRule class. 
		 * @throws Exception
		 */
		public PrestaShopSpecificPriceRule[] GetSpecificPriceRulesByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopSpecificPriceRule[]>Call(PrestaShopSpecificPriceRule[].class, "PrestaShop", bNesisToken, "GetSpecificPriceRulesByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting specific price rules identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopSpecificPriceRule. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetSpecificPriceRulesIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetSpecificPriceRulesIdentifiers");
		}

		/**
		 *  Adding new specific price. 	
		 * @param specificPrice Body of specific price.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddSpecificPrice(PrestaShopSpecificPriceIn specificPrice) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddSpecificPrice", specificPrice);
		}

		/**
		 *  Update information in specified specific price. 	
		 * @param specificPrice Body of specific price.
	 * @return {PrestaShopSpecificPrice} Return updated PrestaShopSpecificPrice. 
		 * @throws Exception
		 */
		public PrestaShopSpecificPrice EditSpecificPrice(PrestaShopSpecificPrice specificPrice) throws Exception
		{
			return _bNesisApi.<PrestaShopSpecificPrice>Call(PrestaShopSpecificPrice.class, "PrestaShop", bNesisToken, "EditSpecificPrice", specificPrice);
		}

		/**
		 *  Remove specific price by identifier. 	
		 * @param id Identifier of specific price.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteSpecificPrice(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteSpecificPrice", id);
		}

		/**
		 *  Getting specific price by identifier. 	
		 * @param id Identifier of specific price.
	 * @return {PrestaShopSpecificPrice} Return PrestaShopSpecificPrice. 
		 * @throws Exception
		 */
		public PrestaShopSpecificPrice GetSpecificPrice(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopSpecificPrice>Call(PrestaShopSpecificPrice.class, "PrestaShop", bNesisToken, "GetSpecificPrice", id);
		}

		/**
		 *  Remove language by identifier. 	
		 * @param id Identifier of language.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteLanguage(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteLanguage", id);
		}

		/**
		 *  Getting language by identifier. 	
		 * @param id Identifier of language.
	 * @return {PrestaShopLanguage} Return PrestaShopLanguage. 
		 * @throws Exception
		 */
		public PrestaShopLanguage GetLanguage(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopLanguage>Call(PrestaShopLanguage.class, "PrestaShop", bNesisToken, "GetLanguage", id);
		}

		/**
		 *  Getting languages by rendering options. 	
		 * @param renderingOptions For request specified information about languages use: display and filter or sort.
	 * @return {PrestaShopLanguage[]} Returns only certain information about Language in PrestaShopLanguage class. 
		 * @throws Exception
		 */
		public PrestaShopLanguage[] GetLanguagesByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopLanguage[]>Call(PrestaShopLanguage[].class, "PrestaShop", bNesisToken, "GetLanguagesByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting languages identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopLanguage. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetLanguagesIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetLanguagesIdentifiers");
		}

		/**
		 *  Adding new manufacturer. 	
		 * @param manufacturer Body of manufacturer.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddManufacturer(PrestaShopManufacturerIn manufacturer) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddManufacturer", manufacturer);
		}

		/**
		 *  Update information in specified manufacturer. 	
		 * @param manufacturer Body of manufacturer.
	 * @return {PrestaShopManufacturer} Return updated PrestaShopManufacturer. 
		 * @throws Exception
		 */
		public PrestaShopManufacturer EditManufacturer(PrestaShopManufacturer manufacturer) throws Exception
		{
			return _bNesisApi.<PrestaShopManufacturer>Call(PrestaShopManufacturer.class, "PrestaShop", bNesisToken, "EditManufacturer", manufacturer);
		}

		/**
		 *  Remove manufacturer by identifier. 	
		 * @param id Identifier of manufacturer.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteManufacturer(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteManufacturer", id);
		}

		/**
		 *  Getting manufacturer by identifier. 	
		 * @param id Identifier of manufacturer.
	 * @return {PrestaShopManufacturer} Return PrestaShopManufacturer. 
		 * @throws Exception
		 */
		public PrestaShopManufacturer GetManufacturer(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopManufacturer>Call(PrestaShopManufacturer.class, "PrestaShop", bNesisToken, "GetManufacturer", id);
		}

		/**
		 *  Getting manufacturers by rendering options. 	
		 * @param renderingOptions For request specified information about manufacturers use: display and filter or sort.
	 * @return {PrestaShopManufacturer[]} Returns only certain information about Manufacturer in PrestaShopManufacturer class. 
		 * @throws Exception
		 */
		public PrestaShopManufacturer[] GetManufacturersByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopManufacturer[]>Call(PrestaShopManufacturer[].class, "PrestaShop", bNesisToken, "GetManufacturersByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting manufacturers identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopManufacturer. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetManufacturersIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetManufacturersIdentifiers");
		}

		/**
		 *  Adding new message. 	
		 * @param message Body of message.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddMessage(PrestaShopMessageIn message) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddMessage", message);
		}

		/**
		 *  Update information in specified message. 	
		 * @param message Body of message.
	 * @return {PrestaShopMessage} Return updated PrestaShopMessage. 
		 * @throws Exception
		 */
		public PrestaShopMessage EditMessage(PrestaShopMessage message) throws Exception
		{
			return _bNesisApi.<PrestaShopMessage>Call(PrestaShopMessage.class, "PrestaShop", bNesisToken, "EditMessage", message);
		}

		/**
		 *  Remove message by identifier. 	
		 * @param id Identifier of message.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteMessage(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteMessage", id);
		}

		/**
		 *  Getting message by identifier. 	
		 * @param id Identifier of message.
	 * @return {PrestaShopMessage} Return PrestaShopMessage. 
		 * @throws Exception
		 */
		public PrestaShopMessage GetMessage(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopMessage>Call(PrestaShopMessage.class, "PrestaShop", bNesisToken, "GetMessage", id);
		}

		/**
		 *  Getting messages by rendering options. 	
		 * @param renderingOptions For request specified information about messages use: display and filter or sort.
	 * @return {PrestaShopMessage[]} Returns only certain information about Message in PrestaShopMessage class. 
		 * @throws Exception
		 */
		public PrestaShopMessage[] GetMessagesByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopMessage[]>Call(PrestaShopMessage[].class, "PrestaShop", bNesisToken, "GetMessagesByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting messages identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopMessage. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetMessagesIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetMessagesIdentifiers");
		}

		/**
		 *  Adding new order carrier. 	
		 * @param orderCarrier Body of order carrier.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddOrderCarrier(PrestaShopOrderCarrierIn orderCarrier) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddOrderCarrier", orderCarrier);
		}

		/**
		 *  Update information in specified order carrier. 	
		 * @param orderCarrier Body of order carrier.
	 * @return {PrestaShopOrderCarrier} Return updated PrestaShopOrderCarrier. 
		 * @throws Exception
		 */
		public PrestaShopOrderCarrier EditOrderCarrier(PrestaShopOrderCarrier orderCarrier) throws Exception
		{
			return _bNesisApi.<PrestaShopOrderCarrier>Call(PrestaShopOrderCarrier.class, "PrestaShop", bNesisToken, "EditOrderCarrier", orderCarrier);
		}

		/**
		 *  Remove order carrier by identifier. 	
		 * @param id Identifier of order carrier.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteOrderCarrier(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteOrderCarrier", id);
		}

		/**
		 *  Getting order carrier by identifier. 	
		 * @param id Identifier of order carrier.
	 * @return {PrestaShopOrderCarrier} Return PrestaShopOrderCarrier. 
		 * @throws Exception
		 */
		public PrestaShopOrderCarrier GetOrderCarrier(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopOrderCarrier>Call(PrestaShopOrderCarrier.class, "PrestaShop", bNesisToken, "GetOrderCarrier", id);
		}

		/**
		 *  Getting order carriers by rendering options. 	
		 * @param renderingOptions For request specified information about order carriers use: display and filter or sort.
	 * @return {PrestaShopOrderCarrier[]} Returns only certain information about OrderCarrier in PrestaShopOrderCarrier class. 
		 * @throws Exception
		 */
		public PrestaShopOrderCarrier[] GetOrderCarriersByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopOrderCarrier[]>Call(PrestaShopOrderCarrier[].class, "PrestaShop", bNesisToken, "GetOrderCarriersByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting order carriers identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopOrderCarrier. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetOrderCarriersIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetOrderCarriersIdentifiers");
		}

		/**
		 *  Getting order detail by identifier. 	
		 * @param id Identifier of order detail.
	 * @return {PrestaShopOrderDetail} Return PrestaShopOrderDetail. 
		 * @throws Exception
		 */
		public PrestaShopOrderDetail GetOrderDetail(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopOrderDetail>Call(PrestaShopOrderDetail.class, "PrestaShop", bNesisToken, "GetOrderDetail", id);
		}

		/**
		 *  Getting order details by rendering options. 	
		 * @param renderingOptions For request specified information about order details use: display and filter or sort.
	 * @return {PrestaShopOrderDetail[]} Returns only certain information about OrderDetail in PrestaShopOrderDetail class. 
		 * @throws Exception
		 */
		public PrestaShopOrderDetail[] GetOrderDetailsByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopOrderDetail[]>Call(PrestaShopOrderDetail[].class, "PrestaShop", bNesisToken, "GetOrderDetailsByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting order details identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopOrderDetail. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetOrderDetailsIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetOrderDetailsIdentifiers");
		}

		/**
		 *  Getting order history by identifier. 	
		 * @param id Identifier of order history.
	 * @return {PrestaShopOrderHistory} Return PrestaShopOrderHistory. 
		 * @throws Exception
		 */
		public PrestaShopOrderHistory GetOrderHistory(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopOrderHistory>Call(PrestaShopOrderHistory.class, "PrestaShop", bNesisToken, "GetOrderHistory", id);
		}

		/**
		 *  Getting order histories by rendering options. 	
		 * @param renderingOptions For request specified information about order histories use: display and filter or sort.
	 * @return {PrestaShopOrderHistory[]} Returns only certain information about OrderHistory in PrestaShopOrderHistory class. 
		 * @throws Exception
		 */
		public PrestaShopOrderHistory[] GetOrderHistoriesByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopOrderHistory[]>Call(PrestaShopOrderHistory[].class, "PrestaShop", bNesisToken, "GetOrderHistoriesByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting order histories identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopOrderHistory. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetOrderHistoriesIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetOrderHistoriesIdentifiers");
		}

		/**
		 *  Adding new order invoice. 	
		 * @param orderInvoice Body of order invoice.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddOrderInvoice(PrestaShopOrderInvoiceIn orderInvoice) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddOrderInvoice", orderInvoice);
		}

		/**
		 *  Update information in specified order invoice. 	
		 * @param orderInvoice Body of order invoice.
	 * @return {PrestaShopOrderInvoice} Return updated PrestaShopOrderInvoice. 
		 * @throws Exception
		 */
		public PrestaShopOrderInvoice EditOrderInvoice(PrestaShopOrderInvoice orderInvoice) throws Exception
		{
			return _bNesisApi.<PrestaShopOrderInvoice>Call(PrestaShopOrderInvoice.class, "PrestaShop", bNesisToken, "EditOrderInvoice", orderInvoice);
		}

		/**
		 *  Remove order invoice by identifier. 	
		 * @param id Identifier of order invoice.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteOrderInvoice(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteOrderInvoice", id);
		}

		/**
		 *  Getting order invoice by identifier. 	
		 * @param id Identifier of order invoice.
	 * @return {PrestaShopOrderInvoice} Return PrestaShopOrderInvoice. 
		 * @throws Exception
		 */
		public PrestaShopOrderInvoice GetOrderInvoice(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopOrderInvoice>Call(PrestaShopOrderInvoice.class, "PrestaShop", bNesisToken, "GetOrderInvoice", id);
		}

		/**
		 *  Getting order invoices by rendering options. 	
		 * @param renderingOptions For request specified information about order invoices use: display and filter or sort.
	 * @return {PrestaShopOrderInvoice[]} Returns only certain information about OrderInvoice in PrestaShopOrderInvoice class. 
		 * @throws Exception
		 */
		public PrestaShopOrderInvoice[] GetOrderInvoicesByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopOrderInvoice[]>Call(PrestaShopOrderInvoice[].class, "PrestaShop", bNesisToken, "GetOrderInvoicesByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting order invoices identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopOrderInvoice. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetOrderInvoicesIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetOrderInvoicesIdentifiers");
		}

		/**
		 *  Adding new order payment. 	
		 * @param orderPayment Body of order payment.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddOrderPayment(PrestaShopOrderPaymentIn orderPayment) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddOrderPayment", orderPayment);
		}

		/**
		 *  Update information in specified order payment. 	
		 * @param orderPayment Body of order payment.
	 * @return {PrestaShopOrderPayment} Return updated PrestaShopOrderPayment. 
		 * @throws Exception
		 */
		public PrestaShopOrderPayment EditOrderPayment(PrestaShopOrderPayment orderPayment) throws Exception
		{
			return _bNesisApi.<PrestaShopOrderPayment>Call(PrestaShopOrderPayment.class, "PrestaShop", bNesisToken, "EditOrderPayment", orderPayment);
		}

		/**
		 *  Remove order payment by identifier. 	
		 * @param id Identifier of order payment.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteOrderPayment(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteOrderPayment", id);
		}

		/**
		 *  Getting order payment by identifier. 	
		 * @param id Identifier of order payment.
	 * @return {PrestaShopOrderPayment} Return PrestaShopOrderPayment. 
		 * @throws Exception
		 */
		public PrestaShopOrderPayment GetOrderPayment(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopOrderPayment>Call(PrestaShopOrderPayment.class, "PrestaShop", bNesisToken, "GetOrderPayment", id);
		}

		/**
		 *  Getting order payments by rendering options. 	
		 * @param renderingOptions For request specified information about order payments use: display and filter or sort.
	 * @return {PrestaShopOrderPayment[]} Returns only certain information about OrderPayment in PrestaShopOrderPayment class. 
		 * @throws Exception
		 */
		public PrestaShopOrderPayment[] GetOrderPaymentsByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopOrderPayment[]>Call(PrestaShopOrderPayment[].class, "PrestaShop", bNesisToken, "GetOrderPaymentsByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting order payments identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopOrderPayment. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetOrderPaymentsIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetOrderPaymentsIdentifiers");
		}

		/**
		 *  Adding new order slip. 	
		 * @param orderSlip Body of order slip.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddOrderSlip(PrestaShopOrderSlipIn orderSlip) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddOrderSlip", orderSlip);
		}

		/**
		 *  Update information in specified order slip. 	
		 * @param orderSlip Body of order slip.
	 * @return {PrestaShopOrderSlip} Return updated PrestaShopOrderSlip. 
		 * @throws Exception
		 */
		public PrestaShopOrderSlip EditOrderSlip(PrestaShopOrderSlip orderSlip) throws Exception
		{
			return _bNesisApi.<PrestaShopOrderSlip>Call(PrestaShopOrderSlip.class, "PrestaShop", bNesisToken, "EditOrderSlip", orderSlip);
		}

		/**
		 *  Remove order slip by identifier. 	
		 * @param id Identifier of order slip.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteOrderSlip(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteOrderSlip", id);
		}

		/**
		 *  Getting order slip by identifier. 	
		 * @param id Identifier of order slip.
	 * @return {PrestaShopOrderSlip} Return PrestaShopOrderSlip. 
		 * @throws Exception
		 */
		public PrestaShopOrderSlip GetOrderSlip(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopOrderSlip>Call(PrestaShopOrderSlip.class, "PrestaShop", bNesisToken, "GetOrderSlip", id);
		}

		/**
		 *  Getting order slip by rendering options. 	
		 * @param renderingOptions For request specified information about order slip use: display and filter or sort.
	 * @return {PrestaShopOrderSlip[]} Returns only certain information about OrderSlip in PrestaShopOrderSlip class. 
		 * @throws Exception
		 */
		public PrestaShopOrderSlip[] GetOrderSlipByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopOrderSlip[]>Call(PrestaShopOrderSlip[].class, "PrestaShop", bNesisToken, "GetOrderSlipByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting order slip identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopOrderSlip. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetOrderSlipIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetOrderSlipIdentifiers");
		}

		/**
		 *  Getting order state by identifier. 	
		 * @param id Identifier of order state.
	 * @return {PrestaShopOrderState} Return PrestaShopOrderState. 
		 * @throws Exception
		 */
		public PrestaShopOrderState GetOrderState(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopOrderState>Call(PrestaShopOrderState.class, "PrestaShop", bNesisToken, "GetOrderState", id);
		}

		/**
		 *  Getting order states by rendering options. 	
		 * @param renderingOptions For request specified information about order states use: display and filter or sort.
	 * @return {PrestaShopOrderState[]} Returns only certain information about OrderState in PrestaShopOrderState class. 
		 * @throws Exception
		 */
		public PrestaShopOrderState[] GetOrderStatesByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopOrderState[]>Call(PrestaShopOrderState[].class, "PrestaShop", bNesisToken, "GetOrderStatesByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting order states identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopOrderState. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetOrderStatesIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetOrderStatesIdentifiers");
		}

		/**
		 *  Getting order by identifier. 	
		 * @param id Identifier of order.
	 * @return {PrestaShopOrder} Return PrestaShopOrder. 
		 * @throws Exception
		 */
		public PrestaShopOrder GetOrder(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopOrder>Call(PrestaShopOrder.class, "PrestaShop", bNesisToken, "GetOrder", id);
		}

		/**
		 *  Getting orders by rendering options. 	
		 * @param renderingOptions For request specified information about orders use: display and filter or sort.
	 * @return {PrestaShopOrder[]} Returns only certain information about Order in PrestaShopOrder class. 
		 * @throws Exception
		 */
		public PrestaShopOrder[] GetOrdersByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopOrder[]>Call(PrestaShopOrder[].class, "PrestaShop", bNesisToken, "GetOrdersByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting orders identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopOrder. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetOrdersIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetOrdersIdentifiers");
		}

		/**
		 *  Adding new price range. 	
		 * @param priceRange Body of price range.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddPriceRange(PrestaShopPriceRangeIn priceRange) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddPriceRange", priceRange);
		}

		/**
		 *  Update information in specified price range. 	
		 * @param priceRange Body of price range.
	 * @return {PrestaShopPriceRange} Return updated PrestaShopPriceRange. 
		 * @throws Exception
		 */
		public PrestaShopPriceRange EditPriceRange(PrestaShopPriceRange priceRange) throws Exception
		{
			return _bNesisApi.<PrestaShopPriceRange>Call(PrestaShopPriceRange.class, "PrestaShop", bNesisToken, "EditPriceRange", priceRange);
		}

		/**
		 *  Remove price range by identifier. 	
		 * @param id Identifier of price range.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeletePriceRange(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeletePriceRange", id);
		}

		/**
		 *  Getting price range by identifier. 	
		 * @param id Identifier of price range.
	 * @return {PrestaShopPriceRange} Return PrestaShopPriceRange. 
		 * @throws Exception
		 */
		public PrestaShopPriceRange GetPriceRange(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopPriceRange>Call(PrestaShopPriceRange.class, "PrestaShop", bNesisToken, "GetPriceRange", id);
		}

		/**
		 *  Getting price ranges by rendering options. 	
		 * @param renderingOptions For request specified information about price ranges use: display and filter or sort.
	 * @return {PrestaShopPriceRange[]} Returns only certain information about PriceRange in PrestaShopPriceRange class. 
		 * @throws Exception
		 */
		public PrestaShopPriceRange[] GetPriceRangesByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopPriceRange[]>Call(PrestaShopPriceRange[].class, "PrestaShop", bNesisToken, "GetPriceRangesByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting price ranges identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopPriceRange. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetPriceRangesIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetPriceRangesIdentifiers");
		}

		/**
		 *  Adding new product customization field. 	
		 * @param productCustomizationField Body of product customization field.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddProductCustomizationField(PrestaShopProductCustomizationFieldIn productCustomizationField) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddProductCustomizationField", productCustomizationField);
		}

		/**
		 *  Update information in specified product customization field. 	
		 * @param productCustomizationField Body of product customization field.
	 * @return {PrestaShopProductCustomizationField} Return updated PrestaShopProductCustomizationField. 
		 * @throws Exception
		 */
		public PrestaShopProductCustomizationField EditProductCustomizationField(PrestaShopProductCustomizationField productCustomizationField) throws Exception
		{
			return _bNesisApi.<PrestaShopProductCustomizationField>Call(PrestaShopProductCustomizationField.class, "PrestaShop", bNesisToken, "EditProductCustomizationField", productCustomizationField);
		}

		/**
		 *  Remove product customization field by identifier. 	
		 * @param id Identifier of product customization field.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteProductCustomizationField(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteProductCustomizationField", id);
		}

		/**
		 *  Getting product customization field by identifier. 	
		 * @param id Identifier of product customization field.
	 * @return {PrestaShopProductCustomizationField} Return PrestaShopProductCustomizationField. 
		 * @throws Exception
		 */
		public PrestaShopProductCustomizationField GetProductCustomizationField(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopProductCustomizationField>Call(PrestaShopProductCustomizationField.class, "PrestaShop", bNesisToken, "GetProductCustomizationField", id);
		}

		/**
		 *  Getting product customization fields by rendering options. 	
		 * @param renderingOptions For request specified information about product customization fields use: display and filter or sort.
	 * @return {PrestaShopProductCustomizationField[]} Returns only certain information about ProductCustomizationField in PrestaShopProductCustomizationField class. 
		 * @throws Exception
		 */
		public PrestaShopProductCustomizationField[] GetProductCustomizationFieldsByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopProductCustomizationField[]>Call(PrestaShopProductCustomizationField[].class, "PrestaShop", bNesisToken, "GetProductCustomizationFieldsByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting product customization fields identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopProductCustomizationField. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetProductCustomizationFieldsIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetProductCustomizationFieldsIdentifiers");
		}

		/**
		 *  Getting currencies by rendering options. 	
		 * @param renderingOptions For request specified information about currencies use: display and filter or sort.
	 * @return {PrestaShopCurrency[]} Returns only certain information about Currency in PrestaShopCurrency class. 
		 * @throws Exception
		 */
		public PrestaShopCurrency[] GetCurrenciesByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopCurrency[]>Call(PrestaShopCurrency[].class, "PrestaShop", bNesisToken, "GetCurrenciesByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting currencies identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopCurrency. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetCurrenciesIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetCurrenciesIdentifiers");
		}

		/**
		 *  Adding new customer message. 	
		 * @param customerMessage Body of customer message.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddCustomerMessage(PrestaShopCustomerMessageIn customerMessage) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddCustomerMessage", customerMessage);
		}

		/**
		 *  Update information in specified customer message. 	
		 * @param customerMessage Body of customer message.
	 * @return {PrestaShopCustomerMessage} Return updated PrestaShopCustomerMessage. 
		 * @throws Exception
		 */
		public PrestaShopCustomerMessage EditCustomerMessage(PrestaShopCustomerMessage customerMessage) throws Exception
		{
			return _bNesisApi.<PrestaShopCustomerMessage>Call(PrestaShopCustomerMessage.class, "PrestaShop", bNesisToken, "EditCustomerMessage", customerMessage);
		}

		/**
		 *  Remove customer message by identifier. 	
		 * @param id Identifier of customer message.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteCustomerMessage(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteCustomerMessage", id);
		}

		/**
		 *  Getting customer message by identifier. 	
		 * @param id Identifier of customer message.
	 * @return {PrestaShopCustomerMessage} Return PrestaShopCustomerMessage. 
		 * @throws Exception
		 */
		public PrestaShopCustomerMessage GetCustomerMessage(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopCustomerMessage>Call(PrestaShopCustomerMessage.class, "PrestaShop", bNesisToken, "GetCustomerMessage", id);
		}

		/**
		 *  Getting customer messages by rendering options. 	
		 * @param renderingOptions For request specified information about customer messages use: display and filter or sort.
	 * @return {PrestaShopCustomerMessage[]} Returns only certain information about CustomerMessage in PrestaShopCustomerMessage class. 
		 * @throws Exception
		 */
		public PrestaShopCustomerMessage[] GetCustomerMessagesByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopCustomerMessage[]>Call(PrestaShopCustomerMessage[].class, "PrestaShop", bNesisToken, "GetCustomerMessagesByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting customer messages identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopCustomerMessage. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetCustomerMessagesIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetCustomerMessagesIdentifiers");
		}

		/**
		 *  Adding new customer thread. 	
		 * @param customerThread Body of customer thread.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddCustomerThread(PrestaShopCustomerThreadIn customerThread) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddCustomerThread", customerThread);
		}

		/**
		 *  Update information in specified customer thread. 	
		 * @param customerThread Body of customer thread.
	 * @return {PrestaShopCustomerThread} Return updated PrestaShopCustomerThread. 
		 * @throws Exception
		 */
		public PrestaShopCustomerThread EditCustomerThread(PrestaShopCustomerThread customerThread) throws Exception
		{
			return _bNesisApi.<PrestaShopCustomerThread>Call(PrestaShopCustomerThread.class, "PrestaShop", bNesisToken, "EditCustomerThread", customerThread);
		}

		/**
		 *  Remove customer thread by identifier. 	
		 * @param id Identifier of customer thread.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteCustomerThread(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteCustomerThread", id);
		}

		/**
		 *  Getting customer thread by identifier. 	
		 * @param id Identifier of customer thread.
	 * @return {PrestaShopCustomerThread} Return PrestaShopCustomerThread. 
		 * @throws Exception
		 */
		public PrestaShopCustomerThread GetCustomerThread(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopCustomerThread>Call(PrestaShopCustomerThread.class, "PrestaShop", bNesisToken, "GetCustomerThread", id);
		}

		/**
		 *  Getting customer threads by rendering options. 	
		 * @param renderingOptions For request specified information about customer threads use: display and filter or sort.
	 * @return {PrestaShopCustomerThread[]} Returns only certain information about CustomerThread in PrestaShopCustomerThread class. 
		 * @throws Exception
		 */
		public PrestaShopCustomerThread[] GetCustomerThreadsByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopCustomerThread[]>Call(PrestaShopCustomerThread[].class, "PrestaShop", bNesisToken, "GetCustomerThreadsByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting customer threads identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopCustomerThread. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetCustomerThreadsIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetCustomerThreadsIdentifiers");
		}

		/**
		 *  Adding new customer. 	
		 * @param customer Body of customer.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddCustomer(PrestaShopCustomerIn customer) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddCustomer", customer);
		}

		/**
		 *  Update information in specified customer. 	
		 * @param customer Body of customer.
	 * @return {PrestaShopCustomer} Return updated PrestaShopCustomer. 
		 * @throws Exception
		 */
		public PrestaShopCustomer EditCustomer(PrestaShopCustomer customer) throws Exception
		{
			return _bNesisApi.<PrestaShopCustomer>Call(PrestaShopCustomer.class, "PrestaShop", bNesisToken, "EditCustomer", customer);
		}

		/**
		 *  Remove customer by identifier. 	
		 * @param id Identifier of customer.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteCustomer(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteCustomer", id);
		}

		/**
		 *  Getting customer by identifier. 	
		 * @param id Identifier of customer.
	 * @return {PrestaShopCustomer} Return PrestaShopCustomer. 
		 * @throws Exception
		 */
		public PrestaShopCustomer GetCustomer(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopCustomer>Call(PrestaShopCustomer.class, "PrestaShop", bNesisToken, "GetCustomer", id);
		}

		/**
		 *  Getting customers by rendering options. 	
		 * @param renderingOptions For request specified information about customers use: display and filter or sort.
	 * @return {PrestaShopCustomer[]} Returns only certain information about Customer in PrestaShopCustomer class. 
		 * @throws Exception
		 */
		public PrestaShopCustomer[] GetCustomersByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopCustomer[]>Call(PrestaShopCustomer[].class, "PrestaShop", bNesisToken, "GetCustomersByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting customers identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopCustomer. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetCustomersIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetCustomersIdentifiers");
		}

		/**
		 *  Adding new customization. 	
		 * @param customization Body of customization.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddCustomization(PrestaShopCustomizationIn customization) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddCustomization", customization);
		}

		/**
		 *  Update information in specified customization. 	
		 * @param customization Body of customization.
	 * @return {PrestaShopCustomization} Return updated PrestaShopCustomization. 
		 * @throws Exception
		 */
		public PrestaShopCustomization EditCustomization(PrestaShopCustomization customization) throws Exception
		{
			return _bNesisApi.<PrestaShopCustomization>Call(PrestaShopCustomization.class, "PrestaShop", bNesisToken, "EditCustomization", customization);
		}

		/**
		 *  Remove customization by identifier. 	
		 * @param id Identifier of customization.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteCustomization(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteCustomization", id);
		}

		/**
		 *  Getting customization by identifier. 	
		 * @param id Identifier of customization.
	 * @return {PrestaShopCustomization} Return PrestaShopCustomization. 
		 * @throws Exception
		 */
		public PrestaShopCustomization GetCustomization(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopCustomization>Call(PrestaShopCustomization.class, "PrestaShop", bNesisToken, "GetCustomization", id);
		}

		/**
		 *  Getting customizations by rendering options. 	
		 * @param renderingOptions For request specified information about customizations use: display and filter or sort.
	 * @return {PrestaShopCustomization[]} Returns only certain information about Customization in PrestaShopCustomization class. 
		 * @throws Exception
		 */
		public PrestaShopCustomization[] GetCustomizationsByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopCustomization[]>Call(PrestaShopCustomization[].class, "PrestaShop", bNesisToken, "GetCustomizationsByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting customizations identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopCustomization. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetCustomizationsIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetCustomizationsIdentifiers");
		}

		/**
		 *  Adding new delivery. 	
		 * @param delivery Body of delivery.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddDelivery(PrestaShopDeliveryIn delivery) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddDelivery", delivery);
		}

		/**
		 *  Update information in specified delivery. 	
		 * @param delivery Body of delivery.
	 * @return {PrestaShopDelivery} Return updated PrestaShopDelivery. 
		 * @throws Exception
		 */
		public PrestaShopDelivery EditDelivery(PrestaShopDelivery delivery) throws Exception
		{
			return _bNesisApi.<PrestaShopDelivery>Call(PrestaShopDelivery.class, "PrestaShop", bNesisToken, "EditDelivery", delivery);
		}

		/**
		 *  Remove delivery by identifier. 	
		 * @param id Identifier of delivery.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteDelivery(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteDelivery", id);
		}

		/**
		 *  Getting delivery by identifier. 	
		 * @param id Identifier of delivery.
	 * @return {PrestaShopDelivery} Return PrestaShopDelivery. 
		 * @throws Exception
		 */
		public PrestaShopDelivery GetDelivery(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopDelivery>Call(PrestaShopDelivery.class, "PrestaShop", bNesisToken, "GetDelivery", id);
		}

		/**
		 *  Getting deliveries by rendering options. 	
		 * @param renderingOptions For request specified information about deliveries use: display and filter or sort.
	 * @return {PrestaShopDelivery[]} Returns only certain information about Delivery in PrestaShopDelivery class. 
		 * @throws Exception
		 */
		public PrestaShopDelivery[] GetDeliveriesByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopDelivery[]>Call(PrestaShopDelivery[].class, "PrestaShop", bNesisToken, "GetDeliveriesByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting deliveries identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopDelivery. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetDeliveriesIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetDeliveriesIdentifiers");
		}

		/**
		 *  Adding new employee. 	
		 * @param employee Body of employee.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddEmployee(PrestaShopEmployeeIn employee) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddEmployee", employee);
		}

		/**
		 *  Update information in specified employee. 	
		 * @param employee Body of employee.
	 * @return {PrestaShopEmployee} Return updated PrestaShopEmployee. 
		 * @throws Exception
		 */
		public PrestaShopEmployee EditEmployee(PrestaShopEmployee employee) throws Exception
		{
			return _bNesisApi.<PrestaShopEmployee>Call(PrestaShopEmployee.class, "PrestaShop", bNesisToken, "EditEmployee", employee);
		}

		/**
		 *  Remove employee by identifier. 	
		 * @param id Identifier of employee.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteEmployee(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteEmployee", id);
		}

		/**
		 *  Getting employee by identifier. 	
		 * @param id Identifier of employee.
	 * @return {PrestaShopEmployee} Return PrestaShopEmployee. 
		 * @throws Exception
		 */
		public PrestaShopEmployee GetEmployee(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopEmployee>Call(PrestaShopEmployee.class, "PrestaShop", bNesisToken, "GetEmployee", id);
		}

		/**
		 *  Getting employees by rendering options. 	
		 * @param renderingOptions For request specified information about employees use: display and filter or sort.
	 * @return {PrestaShopEmployee[]} Returns only certain information about Employee in PrestaShopEmployee class. 
		 * @throws Exception
		 */
		public PrestaShopEmployee[] GetEmployeesByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopEmployee[]>Call(PrestaShopEmployee[].class, "PrestaShop", bNesisToken, "GetEmployeesByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting employees identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopEmployee. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetEmployeesIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetEmployeesIdentifiers");
		}

		/**
		 *  Adding new group. 	
		 * @param group Body of group.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddGroup(PrestaShopGroupIn group) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddGroup", group);
		}

		/**
		 *  Update information in specified group. 	
		 * @param group Body of group.
	 * @return {PrestaShopGroup} Return updated PrestaShopGroup. 
		 * @throws Exception
		 */
		public PrestaShopGroup EditGroup(PrestaShopGroup group) throws Exception
		{
			return _bNesisApi.<PrestaShopGroup>Call(PrestaShopGroup.class, "PrestaShop", bNesisToken, "EditGroup", group);
		}

		/**
		 *  Remove group by identifier. 	
		 * @param id Identifier of group.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteGroup(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteGroup", id);
		}

		/**
		 *  Getting group by identifier. 	
		 * @param id Identifier of group.
	 * @return {PrestaShopGroup} Return PrestaShopGroup. 
		 * @throws Exception
		 */
		public PrestaShopGroup GetGroup(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopGroup>Call(PrestaShopGroup.class, "PrestaShop", bNesisToken, "GetGroup", id);
		}

		/**
		 *  Getting groups by rendering options. 	
		 * @param renderingOptions For request specified information about groups use: display and filter or sort.
	 * @return {PrestaShopGroup[]} Returns only certain information about Group in PrestaShopGroup class. 
		 * @throws Exception
		 */
		public PrestaShopGroup[] GetGroupsByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopGroup[]>Call(PrestaShopGroup[].class, "PrestaShop", bNesisToken, "GetGroupsByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting groups identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopGroup. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetGroupsIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetGroupsIdentifiers");
		}

		/**
		 *  Adding new guest. 	
		 * @param guest Body of guest.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddGuest(PrestaShopGuestIn guest) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddGuest", guest);
		}

		/**
		 *  Update information in specified guest. 	
		 * @param guest Body of guest.
	 * @return {PrestaShopGuest} Return updated PrestaShopGuest. 
		 * @throws Exception
		 */
		public PrestaShopGuest EditGuest(PrestaShopGuest guest) throws Exception
		{
			return _bNesisApi.<PrestaShopGuest>Call(PrestaShopGuest.class, "PrestaShop", bNesisToken, "EditGuest", guest);
		}

		/**
		 *  Remove guest by identifier. 	
		 * @param id Identifier of guest.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteGuest(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteGuest", id);
		}

		/**
		 *  Getting guest by identifier. 	
		 * @param id Identifier of guest.
	 * @return {PrestaShopGuest} Return PrestaShopGuest. 
		 * @throws Exception
		 */
		public PrestaShopGuest GetGuest(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopGuest>Call(PrestaShopGuest.class, "PrestaShop", bNesisToken, "GetGuest", id);
		}

		/**
		 *  Getting guests by rendering options. 	
		 * @param renderingOptions For request specified information about guests use: display and filter or sort.
	 * @return {PrestaShopGuest[]} Returns only certain information about Guest in PrestaShopGuest class. 
		 * @throws Exception
		 */
		public PrestaShopGuest[] GetGuestsByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopGuest[]>Call(PrestaShopGuest[].class, "PrestaShop", bNesisToken, "GetGuestsByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting guests identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopGuest. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetGuestsIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetGuestsIdentifiers");
		}

		/**
		 *  Adding new image type. 	
		 * @param imageType Body of image type.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddImageType(PrestaShopImageTypeIn imageType) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddImageType", imageType);
		}

		/**
		 *  Update information in specified image type. 	
		 * @param imageType Body of image type.
	 * @return {PrestaShopImageType} Return updated PrestaShopImageType. 
		 * @throws Exception
		 */
		public PrestaShopImageType EditImageType(PrestaShopImageType imageType) throws Exception
		{
			return _bNesisApi.<PrestaShopImageType>Call(PrestaShopImageType.class, "PrestaShop", bNesisToken, "EditImageType", imageType);
		}

		/**
		 *  Remove image type by identifier. 	
		 * @param id Identifier of image type.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteImageType(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteImageType", id);
		}

		/**
		 *  Getting image type by identifier. 	
		 * @param id Identifier of image type.
	 * @return {PrestaShopImageType} Return PrestaShopImageType. 
		 * @throws Exception
		 */
		public PrestaShopImageType GetImageType(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopImageType>Call(PrestaShopImageType.class, "PrestaShop", bNesisToken, "GetImageType", id);
		}

		/**
		 *  Getting image types by rendering options. 	
		 * @param renderingOptions For request specified information about image types use: display and filter or sort.
	 * @return {PrestaShopImageType[]} Returns only certain information about ImageType in PrestaShopImageType class. 
		 * @throws Exception
		 */
		public PrestaShopImageType[] GetImageTypesByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopImageType[]>Call(PrestaShopImageType[].class, "PrestaShop", bNesisToken, "GetImageTypesByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting image types identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopImageType. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetImageTypesIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetImageTypesIdentifiers");
		}

		/**
		 *  Adding new image. 	
		 * @param image Body of image.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddImage(PrestaShopImageIn image) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddImage", image);
		}

		/**
		 *  Update information in specified image. 	
		 * @param image Body of image.
	 * @return {PrestaShopImage} Return updated PrestaShopImage. 
		 * @throws Exception
		 */
		public PrestaShopImage EditImage(PrestaShopImage image) throws Exception
		{
			return _bNesisApi.<PrestaShopImage>Call(PrestaShopImage.class, "PrestaShop", bNesisToken, "EditImage", image);
		}

		/**
		 *  Remove image by identifier. 	
		 * @param id Identifier of image.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteImage(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteImage", id);
		}

		/**
		 *  Getting image by identifier. 	
		 * @param id Identifier of image.
	 * @return {PrestaShopImage} Return PrestaShopImage. 
		 * @throws Exception
		 */
		public PrestaShopImage GetImage(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopImage>Call(PrestaShopImage.class, "PrestaShop", bNesisToken, "GetImage", id);
		}

		/**
		 *  Getting images by rendering options. 	
		 * @param renderingOptions For request specified information about images use: display and filter or sort.
	 * @return {PrestaShopImage[]} Returns only certain information about Image in PrestaShopImage class. 
		 * @throws Exception
		 */
		public PrestaShopImage[] GetImagesByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopImage[]>Call(PrestaShopImage[].class, "PrestaShop", bNesisToken, "GetImagesByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting images identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopImage. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetImagesIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetImagesIdentifiers");
		}

		/**
		 *  Adding new language. 	
		 * @param language Body of language.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddLanguage(PrestaShopLanguageIn language) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddLanguage", language);
		}

		/**
		 *  Update information in specified language. 	
		 * @param language Body of language.
	 * @return {PrestaShopLanguage} Return updated PrestaShopLanguage. 
		 * @throws Exception
		 */
		public PrestaShopLanguage EditLanguage(PrestaShopLanguage language) throws Exception
		{
			return _bNesisApi.<PrestaShopLanguage>Call(PrestaShopLanguage.class, "PrestaShop", bNesisToken, "EditLanguage", language);
		}

		/**
		 *  Adding new address. 	
		 * @param address Body of address.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddAddress(PrestaShopAddressIn address) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddAddress", address);
		}

		/**
		 *  Update information in specified address. 	
		 * @param address Body of address.
	 * @return {PrestaShopAddress} Return updated PrestaShopAddress. 
		 * @throws Exception
		 */
		public PrestaShopAddress EditAddress(PrestaShopAddress address) throws Exception
		{
			return _bNesisApi.<PrestaShopAddress>Call(PrestaShopAddress.class, "PrestaShop", bNesisToken, "EditAddress", address);
		}

		/**
		 *  Remove address by identifier. 	
		 * @param id Identifier of address.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteAddress(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteAddress", id);
		}

		/**
		 *  Getting address by identifier. 	
		 * @param id Identifier of address.
	 * @return {PrestaShopAddress} Return PrestaShopAddress. 
		 * @throws Exception
		 */
		public PrestaShopAddress GetAddress(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopAddress>Call(PrestaShopAddress.class, "PrestaShop", bNesisToken, "GetAddress", id);
		}

		/**
		 *  Getting addresses by rendering options. 	
		 * @param renderingOptions For request specified information about addresses use: display and filter or sort.
	 * @return {PrestaShopAddress[]} Returns only certain information about Address in PrestaShopAddress class. 
		 * @throws Exception
		 */
		public PrestaShopAddress[] GetAddressesByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopAddress[]>Call(PrestaShopAddress[].class, "PrestaShop", bNesisToken, "GetAddressesByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting addresses identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopAddress. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetAddressesIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetAddressesIdentifiers");
		}

		/**
		 *  Adding new carrier. 	
		 * @param carrier Body of carrier.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddCarrier(PrestaShopCarrierIn carrier) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddCarrier", carrier);
		}

		/**
		 *  Update information in specified carrier. 	
		 * @param carrier Body of carrier.
	 * @return {PrestaShopCarrier} Return updated PrestaShopCarrier. 
		 * @throws Exception
		 */
		public PrestaShopCarrier EditCarrier(PrestaShopCarrier carrier) throws Exception
		{
			return _bNesisApi.<PrestaShopCarrier>Call(PrestaShopCarrier.class, "PrestaShop", bNesisToken, "EditCarrier", carrier);
		}

		/**
		 *  Remove carrier by identifier. 	
		 * @param id Identifier of carrier.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteCarrier(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteCarrier", id);
		}

		/**
		 *  Getting carrier by identifier. 	
		 * @param id Identifier of carrier.
	 * @return {PrestaShopCarrier} Return PrestaShopCarrier. 
		 * @throws Exception
		 */
		public PrestaShopCarrier GetCarrier(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopCarrier>Call(PrestaShopCarrier.class, "PrestaShop", bNesisToken, "GetCarrier", id);
		}

		/**
		 *  Getting carriers by rendering options. 	
		 * @param renderingOptions For request specified information about carriers use: display and filter or sort.
	 * @return {PrestaShopCarrier[]} Returns only certain information about Carrier in PrestaShopCarrier class. 
		 * @throws Exception
		 */
		public PrestaShopCarrier[] GetCarriersByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopCarrier[]>Call(PrestaShopCarrier[].class, "PrestaShop", bNesisToken, "GetCarriersByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting carriers identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopCarrier. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetCarriersIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetCarriersIdentifiers");
		}

		/**
		 *  Adding new cart rule. 	
		 * @param cartRule Body of cart rule.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddCartRule(PrestaShopCartRuleIn cartRule) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddCartRule", cartRule);
		}

		/**
		 *  Update information in specified cart rule. 	
		 * @param cartRule Body of cart rule.
	 * @return {PrestaShopCartRule} Return updated PrestaShopCartRule. 
		 * @throws Exception
		 */
		public PrestaShopCartRule EditCartRule(PrestaShopCartRule cartRule) throws Exception
		{
			return _bNesisApi.<PrestaShopCartRule>Call(PrestaShopCartRule.class, "PrestaShop", bNesisToken, "EditCartRule", cartRule);
		}

		/**
		 *  Remove cart rule by identifier. 	
		 * @param id Identifier of cart rule.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteCartRule(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteCartRule", id);
		}

		/**
		 *  Getting cart rule by identifier. 	
		 * @param id Identifier of cart rule.
	 * @return {PrestaShopCartRule} Return PrestaShopCartRule. 
		 * @throws Exception
		 */
		public PrestaShopCartRule GetCartRule(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopCartRule>Call(PrestaShopCartRule.class, "PrestaShop", bNesisToken, "GetCartRule", id);
		}

		/**
		 *  Getting cart rules by rendering options. 	
		 * @param renderingOptions For request specified information about cart rules use: display and filter or sort.
	 * @return {PrestaShopCartRule[]} Returns only certain information about CartRule in PrestaShopCartRule class. 
		 * @throws Exception
		 */
		public PrestaShopCartRule[] GetCartRulesByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopCartRule[]>Call(PrestaShopCartRule[].class, "PrestaShop", bNesisToken, "GetCartRulesByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting cart rules identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopCartRule. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetCartRulesIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetCartRulesIdentifiers");
		}

		/**
		 *  Adding new cart. 	
		 * @param cart Body of cart.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddCart(PrestaShopCartIn cart) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddCart", cart);
		}

		/**
		 *  Update information in specified cart. 	
		 * @param cart Body of cart.
	 * @return {PrestaShopCart} Return updated PrestaShopCart. 
		 * @throws Exception
		 */
		public PrestaShopCart EditCart(PrestaShopCart cart) throws Exception
		{
			return _bNesisApi.<PrestaShopCart>Call(PrestaShopCart.class, "PrestaShop", bNesisToken, "EditCart", cart);
		}

		/**
		 *  Remove cart by identifier. 	
		 * @param id Identifier of cart.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteCart(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteCart", id);
		}

		/**
		 *  Getting cart by identifier. 	
		 * @param id Identifier of cart.
	 * @return {PrestaShopCart} Return PrestaShopCart. 
		 * @throws Exception
		 */
		public PrestaShopCart GetCart(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopCart>Call(PrestaShopCart.class, "PrestaShop", bNesisToken, "GetCart", id);
		}

		/**
		 *  Getting carts by rendering options. 	
		 * @param renderingOptions For request specified information about carts use: display and filter or sort.
	 * @return {PrestaShopCart[]} Returns only certain information about Cart in PrestaShopCart class. 
		 * @throws Exception
		 */
		public PrestaShopCart[] GetCartsByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopCart[]>Call(PrestaShopCart[].class, "PrestaShop", bNesisToken, "GetCartsByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting carts identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopCart. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetCartsIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetCartsIdentifiers");
		}

		/**
		 *  Adding new category. 	
		 * @param category Body of category.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddCategory(PrestaShopCategoryIn category) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddCategory", category);
		}

		/**
		 *  Update information in specified category. 	
		 * @param category Body of category.
	 * @return {PrestaShopCategory} Return updated PrestaShopCategory. 
		 * @throws Exception
		 */
		public PrestaShopCategory EditCategory(PrestaShopCategory category) throws Exception
		{
			return _bNesisApi.<PrestaShopCategory>Call(PrestaShopCategory.class, "PrestaShop", bNesisToken, "EditCategory", category);
		}

		/**
		 *  Remove category by identifier. 	
		 * @param id Identifier of category.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteCategory(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteCategory", id);
		}

		/**
		 *  Getting category by identifier. 	
		 * @param id Identifier of category.
	 * @return {PrestaShopCategory} Return PrestaShopCategory. 
		 * @throws Exception
		 */
		public PrestaShopCategory GetCategory(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopCategory>Call(PrestaShopCategory.class, "PrestaShop", bNesisToken, "GetCategory", id);
		}

		/**
		 *  Getting categories by rendering options. 	
		 * @param renderingOptions For request specified information about categories use: display and filter or sort.
	 * @return {PrestaShopCategory[]} Returns only certain information about Category in PrestaShopCategory class. 
		 * @throws Exception
		 */
		public PrestaShopCategory[] GetCategoriesByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopCategory[]>Call(PrestaShopCategory[].class, "PrestaShop", bNesisToken, "GetCategoriesByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting categories identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopCategory. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetCategoriesIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetCategoriesIdentifiers");
		}

		/**
		 *  Adding new combination. 	
		 * @param combination Body of combination.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddCombination(PrestaShopCombinationIn combination) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddCombination", combination);
		}

		/**
		 *  Update information in specified combination. 	
		 * @param combination Body of combination.
	 * @return {PrestaShopCombination} Return updated PrestaShopCombination. 
		 * @throws Exception
		 */
		public PrestaShopCombination EditCombination(PrestaShopCombination combination) throws Exception
		{
			return _bNesisApi.<PrestaShopCombination>Call(PrestaShopCombination.class, "PrestaShop", bNesisToken, "EditCombination", combination);
		}

		/**
		 *  Remove combination by identifier. 	
		 * @param id Identifier of combination.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteCombination(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteCombination", id);
		}

		/**
		 *  Getting combination by identifier. 	
		 * @param id Identifier of combination.
	 * @return {PrestaShopCombination} Return PrestaShopCombination. 
		 * @throws Exception
		 */
		public PrestaShopCombination GetCombination(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopCombination>Call(PrestaShopCombination.class, "PrestaShop", bNesisToken, "GetCombination", id);
		}

		/**
		 *  Getting combinations by rendering options. 	
		 * @param renderingOptions For request specified information about combinations use: display and filter or sort.
	 * @return {PrestaShopCombination[]} Returns only certain information about Combination in PrestaShopCombination class. 
		 * @throws Exception
		 */
		public PrestaShopCombination[] GetCombinationsByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopCombination[]>Call(PrestaShopCombination[].class, "PrestaShop", bNesisToken, "GetCombinationsByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting combinations identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopCombination. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetCombinationsIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetCombinationsIdentifiers");
		}

		/**
		 *  Adding new configuration. 	
		 * @param configuration Body of configuration.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddConfiguration(PrestaShopConfigurationIn configuration) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddConfiguration", configuration);
		}

		/**
		 *  Update information in specified configuration. 	
		 * @param configuration Body of configuration.
	 * @return {PrestaShopConfiguration} Return updated PrestaShopConfiguration. 
		 * @throws Exception
		 */
		public PrestaShopConfiguration EditConfiguration(PrestaShopConfiguration configuration) throws Exception
		{
			return _bNesisApi.<PrestaShopConfiguration>Call(PrestaShopConfiguration.class, "PrestaShop", bNesisToken, "EditConfiguration", configuration);
		}

		/**
		 *  Remove configuration by identifier. 	
		 * @param id Identifier of configuration.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteConfiguration(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteConfiguration", id);
		}

		/**
		 *  Getting configuration by identifier. 	
		 * @param id Identifier of configuration.
	 * @return {PrestaShopConfiguration} Return PrestaShopConfiguration. 
		 * @throws Exception
		 */
		public PrestaShopConfiguration GetConfiguration(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopConfiguration>Call(PrestaShopConfiguration.class, "PrestaShop", bNesisToken, "GetConfiguration", id);
		}

		/**
		 *  Getting configurations by rendering options. 	
		 * @param renderingOptions For request specified information about configurations use: display and filter or sort.
	 * @return {PrestaShopConfiguration[]} Returns only certain information about Configuration in PrestaShopConfiguration class. 
		 * @throws Exception
		 */
		public PrestaShopConfiguration[] GetConfigurationsByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopConfiguration[]>Call(PrestaShopConfiguration[].class, "PrestaShop", bNesisToken, "GetConfigurationsByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting configurations identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopConfiguration. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetConfigurationsIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetConfigurationsIdentifiers");
		}

		/**
		 *  Adding new contact. 	
		 * @param contact Body of contact.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddContact(PrestaShopContactIn contact) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddContact", contact);
		}

		/**
		 *  Update information in specified contact. 	
		 * @param contact Body of contact.
	 * @return {PrestaShopContact} Return updated PrestaShopContact. 
		 * @throws Exception
		 */
		public PrestaShopContact EditContact(PrestaShopContact contact) throws Exception
		{
			return _bNesisApi.<PrestaShopContact>Call(PrestaShopContact.class, "PrestaShop", bNesisToken, "EditContact", contact);
		}

		/**
		 *  Remove contact by identifier. 	
		 * @param id Identifier of contact.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteContact(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteContact", id);
		}

		/**
		 *  Getting contact by identifier. 	
		 * @param id Identifier of contact.
	 * @return {PrestaShopContact} Return PrestaShopContact. 
		 * @throws Exception
		 */
		public PrestaShopContact GetContact(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopContact>Call(PrestaShopContact.class, "PrestaShop", bNesisToken, "GetContact", id);
		}

		/**
		 *  Getting contacts by rendering options. 	
		 * @param renderingOptions For request specified information about contacts use: display and filter or sort.
	 * @return {PrestaShopContact[]} Returns only certain information about Contact in PrestaShopContact class. 
		 * @throws Exception
		 */
		public PrestaShopContact[] GetContactsByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopContact[]>Call(PrestaShopContact[].class, "PrestaShop", bNesisToken, "GetContactsByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting contacts identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopContact. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetContactsIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetContactsIdentifiers");
		}

		/**
		 *  Adding new content management system. 	
		 * @param contentManagementSystem Body of content management system.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddContentManagementSystem(PrestaShopContentManagementSystemIn contentManagementSystem) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddContentManagementSystem", contentManagementSystem);
		}

		/**
		 *  Update information in specified content management system. 	
		 * @param contentManagementSystem Body of content management system.
	 * @return {PrestaShopContentManagementSystem} Return updated PrestaShopContentManagementSystem. 
		 * @throws Exception
		 */
		public PrestaShopContentManagementSystem EditContentManagementSystem(PrestaShopContentManagementSystem contentManagementSystem) throws Exception
		{
			return _bNesisApi.<PrestaShopContentManagementSystem>Call(PrestaShopContentManagementSystem.class, "PrestaShop", bNesisToken, "EditContentManagementSystem", contentManagementSystem);
		}

		/**
		 *  Remove content management system by identifier. 	
		 * @param id Identifier of content management system.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteContentManagementSystem(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteContentManagementSystem", id);
		}

		/**
		 *  Getting content management system by identifier. 	
		 * @param id Identifier of content management system.
	 * @return {PrestaShopContentManagementSystem} Return PrestaShopContentManagementSystem. 
		 * @throws Exception
		 */
		public PrestaShopContentManagementSystem GetContentManagementSystem(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopContentManagementSystem>Call(PrestaShopContentManagementSystem.class, "PrestaShop", bNesisToken, "GetContentManagementSystem", id);
		}

		/**
		 *  Getting content management system by rendering options. 	
		 * @param renderingOptions For request specified information about content management system use: display and filter or sort.
	 * @return {PrestaShopContentManagementSystem[]} Returns only certain information about ContentManagementSystem in PrestaShopContentManagementSystem class. 
		 * @throws Exception
		 */
		public PrestaShopContentManagementSystem[] GetContentManagementSystemByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopContentManagementSystem[]>Call(PrestaShopContentManagementSystem[].class, "PrestaShop", bNesisToken, "GetContentManagementSystemByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting content management system identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopContentManagementSystem. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetContentManagementSystemIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetContentManagementSystemIdentifiers");
		}

		/**
		 *  Adding new country. 	
		 * @param country Body of country.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddCountry(PrestaShopCountryIn country) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddCountry", country);
		}

		/**
		 *  Update information in specified country. 	
		 * @param country Body of country.
	 * @return {PrestaShopCountry} Return updated PrestaShopCountry. 
		 * @throws Exception
		 */
		public PrestaShopCountry EditCountry(PrestaShopCountry country) throws Exception
		{
			return _bNesisApi.<PrestaShopCountry>Call(PrestaShopCountry.class, "PrestaShop", bNesisToken, "EditCountry", country);
		}

		/**
		 *  Remove country by identifier. 	
		 * @param id Identifier of country.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteCountry(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteCountry", id);
		}

		/**
		 *  Getting country by identifier. 	
		 * @param id Identifier of country.
	 * @return {PrestaShopCountry} Return PrestaShopCountry. 
		 * @throws Exception
		 */
		public PrestaShopCountry GetCountry(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopCountry>Call(PrestaShopCountry.class, "PrestaShop", bNesisToken, "GetCountry", id);
		}

		/**
		 *  Getting countries by rendering options. 	
		 * @param renderingOptions For request specified information about countries use: display and filter or sort.
	 * @return {PrestaShopCountry[]} Returns only certain information about Country in PrestaShopCountry class. 
		 * @throws Exception
		 */
		public PrestaShopCountry[] GetCountriesByRenderingOptions(PrestaShopRenderingOptions renderingOptions) throws Exception
		{
			return _bNesisApi.<PrestaShopCountry[]>Call(PrestaShopCountry[].class, "PrestaShop", bNesisToken, "GetCountriesByRenderingOptions", renderingOptions);
		}

		/**
		 *  Getting countries identifiers. 	
		 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopCountry. 
		 * @throws Exception
		 */
		public PrestaShopIdentifier[] GetCountriesIdentifiers() throws Exception
		{
			return _bNesisApi.<PrestaShopIdentifier[]>Call(PrestaShopIdentifier[].class, "PrestaShop", bNesisToken, "GetCountriesIdentifiers");
		}

		/**
		 *  Adding new currency. 	
		 * @param currency Body of currency.
	 * @return {Boolean} If added return true. 
		 * @throws Exception
		 */
		public Boolean AddCurrency(PrestaShopCurrencyIn currency) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "AddCurrency", currency);
		}

		/**
		 *  Update information in specified currency. 	
		 * @param currency Body of currency.
	 * @return {PrestaShopCurrency} Return updated PrestaShopCurrency. 
		 * @throws Exception
		 */
		public PrestaShopCurrency EditCurrency(PrestaShopCurrency currency) throws Exception
		{
			return _bNesisApi.<PrestaShopCurrency>Call(PrestaShopCurrency.class, "PrestaShop", bNesisToken, "EditCurrency", currency);
		}

		/**
		 *  Remove currency by identifier. 	
		 * @param id Identifier of currency.
	 * @return {Boolean} If removed return true. 
		 * @throws Exception
		 */
		public Boolean DeleteCurrency(Integer id) throws Exception
		{
			return _bNesisApi.<Boolean>Call(Boolean.class, "PrestaShop", bNesisToken, "DeleteCurrency", id);
		}

		/**
		 *  Getting currency by identifier. 	
		 * @param id Identifier of currency.
	 * @return {PrestaShopCurrency} Return PrestaShopCurrency. 
		 * @throws Exception
		 */
		public PrestaShopCurrency GetCurrency(Integer id) throws Exception
		{
			return _bNesisApi.<PrestaShopCurrency>Call(PrestaShopCurrency.class, "PrestaShop", bNesisToken, "GetCurrency", id);
		}
}