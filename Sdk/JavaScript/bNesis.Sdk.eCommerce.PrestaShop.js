PrestaShop = function (bNesisApi) {
    this.bNesisToken = null;
    var _bNesisApi = bNesisApi;

    /**
     * The method authorizes the user in the service and if the authorize result is successful assigns the value bNesisToken.
	 * or Attach to bNesis session with exists bNesis token
     * @return {string} bNesisToken value | true if bNesisToken is valid
	 */
    this.Auth = function (data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl) {
		if(arguments.length !== 1){
			var bNesisToken = _bNesisApi.Auth("PrestaShop", data,bNesisDevId,redirectUrl,clientId,clientSecret,scopes,login,password,isSandbox,serviceUrl);
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
		var result = _bNesisApi.LogoffService("PrestaShop", this.bNesisToken);
		if (result) this.bNesisToken = "";
		return result;             
    }
	
	/**
	 *  Getting last exception for current provider 	
	 * @return {ErrorInfo} 
	 */
    this.GetLastError = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetLastError");
        return result;
    }

	/**
	 *  Getting arrays of error info 	
	 * @return {ErrorInfo[]} 
	 */
    this.GetErrorLog = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetErrorLog");
        return result;
    }

	/**
	 *  Checks the token in the service. 	
	 * @return {Boolean} if token valid return true, if token not valid return false
	 */
    this.ValidateToken = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "ValidateToken");
        return result;
    }

	/**
	 *  Disables the access token used to authenticate the call. 	
	 * @return {Boolean} if token revoked method returns true 
	 * if token doesn't support token revocation or token is revoked method returns false
	 */
    this.Logoff = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "Logoff");
        return result;
    }

	/**
	 *   	
	 * @param contactItem 
	 * @return {Boolean} 
	 */
    this.CreateCustomerUnified = function (contactItem) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "CreateCustomerUnified", contactItem);
        return result;
    }

	/**
	 *   	
	 * @return {ContactItem[]} 
	 */
    this.GetCustomersUnified = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCustomersUnified");
        return result;
    }

	/**
	 *   	
	 * @param productItem 
	 * @return {Boolean} 
	 */
    this.AddProductUnified = function (productItem) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddProductUnified", productItem);
        return result;
    }

	/**
	 *   	
	 * @return {ProductItem[]} 
	 */
    this.GetProductsUnified = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductsUnified");
        return result;
    }

	/**
	 *   	
	 * @param IdProduct 
	 * @return {Boolean} 
	 */
    this.DeleteProductUnified = function (IdProduct) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteProductUnified", IdProduct);
        return result;
    }

	/**
	 *   	
	 * @return {CountryItem[]} 
	 */
    this.GetCountriesUnified = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCountriesUnified");
        return result;
    }

	/**
	 *   	
	 * @return {Int32} 
	 */
    this.GetCountCountriesUnified = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCountCountriesUnified");
        return result;
    }

	/**
	 *   	
	 * @param IdCountry 
	 * @return {CountryItem} 
	 */
    this.ReceiveCountryUnified = function (IdCountry) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "ReceiveCountryUnified", IdCountry);
        return result;
    }

	/**
	 *   	
	 * @param IdCountry 
	 * @return {Boolean} 
	 */
    this.DeleteCountryUnified = function (IdCountry) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteCountryUnified", IdCountry);
        return result;
    }

	/**
	 *   	
	 * @param countryItem 
	 * @return {CountryItem} 
	 */
    this.CreateCountryUnified = function (countryItem) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "CreateCountryUnified", countryItem);
        return result;
    }

	/**
	 *   	
	 * @param countryItem 
	 * @return {CountryItem} 
	 */
    this.UpdateCountryUnified = function (countryItem) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "UpdateCountryUnified", countryItem);
        return result;
    }

	/**
	 *   	
	 * @param IdCustomer 
	 * @return {ContactItem} 
	 */
    this.ReceiveCustomerUnified = function (IdCustomer) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "ReceiveCustomerUnified", IdCustomer);
        return result;
    }

	/**
	 *  Getting supply order states identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopSupplyOrderState.
	 */
    this.GetSupplyOrderStatesIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplyOrderStatesIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting supply order states by rendering options. 	
	 * @param renderingOptions For request specified information about supply order states use: display and filter or sort.
	 * @return {Response} Returns only certain information about SupplyOrderState in PrestaShopSupplyOrderState class.
	 */
    this.GetSupplyOrderStatesByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplyOrderStatesByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Getting supply order by identifier. 	
	 * @param id Identifier of supply order.
	 * @return {Response} Return PrestaShopSupplyOrder.
	 */
    this.GetSupplyOrderRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplyOrderRaw", id);
        return result;
    }

	/**
	 *  Getting supply orders identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopSupplyOrder.
	 */
    this.GetSupplyOrdersIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplyOrdersIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting supply orders by rendering options. 	
	 * @param renderingOptions For request specified information about supply orders use: display and filter or sort.
	 * @return {Response} Returns only certain information about SupplyOrder in PrestaShopSupplyOrder class.
	 */
    this.GetSupplyOrdersByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplyOrdersByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new tag. 	
	 * @param tag Body of tag.
	 * @return {Response} If added return true.
	 */
    this.AddTagRaw = function (tag) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddTagRaw", tag);
        return result;
    }

	/**
	 *  Update information in specified tag. 	
	 * @param tag Body of tag.
	 * @return {Response} Return updated PrestaShopTag.
	 */
    this.EditTagRaw = function (tag) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditTagRaw", tag);
        return result;
    }

	/**
	 *  Remove tag by identifier. 	
	 * @param id Identifier of tag.
	 * @return {Response} If removed return true.
	 */
    this.DeleteTagRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteTagRaw", id);
        return result;
    }

	/**
	 *  Getting tag by identifier. 	
	 * @param id Identifier of tag.
	 * @return {Response} Return PrestaShopTag.
	 */
    this.GetTagRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetTagRaw", id);
        return result;
    }

	/**
	 *  Getting tags identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopTag.
	 */
    this.GetTagsIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetTagsIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting tags by rendering options. 	
	 * @param renderingOptions For request specified information about tags use: display and filter or sort.
	 * @return {Response} Returns only certain information about Tag in PrestaShopTag class.
	 */
    this.GetTagsByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetTagsByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new tax rule group. 	
	 * @param taxRuleGroup Body of tax rule group.
	 * @return {Response} If added return true.
	 */
    this.AddTaxRuleGroupRaw = function (taxRuleGroup) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddTaxRuleGroupRaw", taxRuleGroup);
        return result;
    }

	/**
	 *  Update information in specified tax rule group. 	
	 * @param taxRuleGroup Body of tax rule group.
	 * @return {Response} Return updated PrestaShopTaxRuleGroup.
	 */
    this.EditTaxRuleGroupRaw = function (taxRuleGroup) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditTaxRuleGroupRaw", taxRuleGroup);
        return result;
    }

	/**
	 *  Remove tax rule group by identifier. 	
	 * @param id Identifier of tax rule group.
	 * @return {Response} If removed return true.
	 */
    this.DeleteTaxRuleGroupRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteTaxRuleGroupRaw", id);
        return result;
    }

	/**
	 *  Getting tax rule group by identifier. 	
	 * @param id Identifier of tax rule group.
	 * @return {Response} Return PrestaShopTaxRuleGroup.
	 */
    this.GetTaxRuleGroupRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetTaxRuleGroupRaw", id);
        return result;
    }

	/**
	 *  Getting tax rule groups identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopTaxRuleGroup.
	 */
    this.GetTaxRuleGroupsIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetTaxRuleGroupsIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting tax rule groups by rendering options. 	
	 * @param renderingOptions For request specified information about tax rule groups use: display and filter or sort.
	 * @return {Response} Returns only certain information about TaxRuleGroup in PrestaShopTaxRuleGroup class.
	 */
    this.GetTaxRuleGroupsByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetTaxRuleGroupsByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new tax rule. 	
	 * @param taxRule Body of tax rule.
	 * @return {Response} If added return true.
	 */
    this.AddTaxRuleRaw = function (taxRule) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddTaxRuleRaw", taxRule);
        return result;
    }

	/**
	 *  Update information in specified tax rule. 	
	 * @param taxRule Body of tax rule.
	 * @return {Response} Return updated PrestaShopTaxRule.
	 */
    this.EditTaxRuleRaw = function (taxRule) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditTaxRuleRaw", taxRule);
        return result;
    }

	/**
	 *  Remove tax rule by identifier. 	
	 * @param id Identifier of tax rule.
	 * @return {Response} If removed return true.
	 */
    this.DeleteTaxRuleRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteTaxRuleRaw", id);
        return result;
    }

	/**
	 *  Getting tax rule by identifier. 	
	 * @param id Identifier of tax rule.
	 * @return {Response} Return PrestaShopTaxRule.
	 */
    this.GetTaxRuleRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetTaxRuleRaw", id);
        return result;
    }

	/**
	 *  Getting tax rules identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopTaxRule.
	 */
    this.GetTaxRulesIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetTaxRulesIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting tax rules by rendering options. 	
	 * @param renderingOptions For request specified information about tax rules use: display and filter or sort.
	 * @return {Response} Returns only certain information about TaxRule in PrestaShopTaxRule class.
	 */
    this.GetTaxRulesByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetTaxRulesByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new tax. 	
	 * @param tax Body of tax.
	 * @return {Response} If added return true.
	 */
    this.AddTaxRaw = function (tax) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddTaxRaw", tax);
        return result;
    }

	/**
	 *  Update information in specified tax. 	
	 * @param tax Body of tax.
	 * @return {Response} Return updated PrestaShopTax.
	 */
    this.EditTaxRaw = function (tax) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditTaxRaw", tax);
        return result;
    }

	/**
	 *  Remove tax by identifier. 	
	 * @param id Identifier of tax.
	 * @return {Response} If removed return true.
	 */
    this.DeleteTaxRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteTaxRaw", id);
        return result;
    }

	/**
	 *  Getting tax by identifier. 	
	 * @param id Identifier of tax.
	 * @return {Response} Return PrestaShopTax.
	 */
    this.GetTaxRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetTaxRaw", id);
        return result;
    }

	/**
	 *  Getting taxes identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopTax.
	 */
    this.GetTaxesIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetTaxesIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting taxes by rendering options. 	
	 * @param renderingOptions For request specified information about taxes use: display and filter or sort.
	 * @return {Response} Returns only certain information about Tax in PrestaShopTax class.
	 */
    this.GetTaxesByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetTaxesByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new translated configuration. 	
	 * @param translatedConfiguration Body of translated configuration.
	 * @return {Response} If added return true.
	 */
    this.AddTranslatedConfigurationRaw = function (translatedConfiguration) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddTranslatedConfigurationRaw", translatedConfiguration);
        return result;
    }

	/**
	 *  Update information in specified translated configuration. 	
	 * @param translatedConfiguration Body of translated configuration.
	 * @return {Response} Return updated PrestaShopTranslatedConfiguration.
	 */
    this.EditTranslatedConfigurationRaw = function (translatedConfiguration) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditTranslatedConfigurationRaw", translatedConfiguration);
        return result;
    }

	/**
	 *  Remove translated configuration by identifier. 	
	 * @param id Identifier of translated configuration.
	 * @return {Response} If removed return true.
	 */
    this.DeleteTranslatedConfigurationRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteTranslatedConfigurationRaw", id);
        return result;
    }

	/**
	 *  Getting translated configuration by identifier. 	
	 * @param id Identifier of translated configuration.
	 * @return {Response} Return PrestaShopTranslatedConfiguration.
	 */
    this.GetTranslatedConfigurationRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetTranslatedConfigurationRaw", id);
        return result;
    }

	/**
	 *  Getting translated configurations identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopTranslatedConfiguration.
	 */
    this.GetTranslatedConfigurationsIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetTranslatedConfigurationsIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting translated configurations by rendering options. 	
	 * @param renderingOptions For request specified information about translated configurations use: display and filter or sort.
	 * @return {Response} Returns only certain information about TranslatedConfiguration in PrestaShopTranslatedConfiguration class.
	 */
    this.GetTranslatedConfigurationsByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetTranslatedConfigurationsByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Getting warehouse product location by identifier. 	
	 * @param id Identifier of warehouse product location.
	 * @return {Response} Return PrestaShopWarehouseProductLocation.
	 */
    this.GetWarehouseProductLocationRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetWarehouseProductLocationRaw", id);
        return result;
    }

	/**
	 *  Getting warehouse product locations identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopWarehouseProductLocation.
	 */
    this.GetWarehouseProductLocationsIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetWarehouseProductLocationsIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting warehouse product locations by rendering options. 	
	 * @param renderingOptions For request specified information about warehouse product locations use: display and filter or sort.
	 * @return {Response} Returns only certain information about WarehouseProductLocation in PrestaShopWarehouseProductLocation class.
	 */
    this.GetWarehouseProductLocationsByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetWarehouseProductLocationsByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new weight range. 	
	 * @param weightRange Body of weight range.
	 * @return {Response} If added return true.
	 */
    this.AddWeightRangeRaw = function (weightRange) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddWeightRangeRaw", weightRange);
        return result;
    }

	/**
	 *  Update information in specified weight range. 	
	 * @param weightRange Body of weight range.
	 * @return {Response} Return updated PrestaShopWeightRange.
	 */
    this.EditWeightRangeRaw = function (weightRange) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditWeightRangeRaw", weightRange);
        return result;
    }

	/**
	 *  Remove weight range by identifier. 	
	 * @param id Identifier of weight range.
	 * @return {Response} If removed return true.
	 */
    this.DeleteWeightRangeRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteWeightRangeRaw", id);
        return result;
    }

	/**
	 *  Getting weight range by identifier. 	
	 * @param id Identifier of weight range.
	 * @return {Response} Return PrestaShopWeightRange.
	 */
    this.GetWeightRangeRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetWeightRangeRaw", id);
        return result;
    }

	/**
	 *  Getting weight ranges identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopWeightRange.
	 */
    this.GetWeightRangesIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetWeightRangesIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting weight ranges by rendering options. 	
	 * @param renderingOptions For request specified information about weight ranges use: display and filter or sort.
	 * @return {Response} Returns only certain information about WeightRange in PrestaShopWeightRange class.
	 */
    this.GetWeightRangesByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetWeightRangesByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new zone. 	
	 * @param zone Body of zone.
	 * @return {Response} If added return true.
	 */
    this.AddZoneRaw = function (zone) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddZoneRaw", zone);
        return result;
    }

	/**
	 *  Update information in specified zone. 	
	 * @param zone Body of zone.
	 * @return {Response} Return updated PrestaShopZone.
	 */
    this.EditZoneRaw = function (zone) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditZoneRaw", zone);
        return result;
    }

	/**
	 *  Remove zone by identifier. 	
	 * @param id Identifier of zone.
	 * @return {Response} If removed return true.
	 */
    this.DeleteZoneRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteZoneRaw", id);
        return result;
    }

	/**
	 *  Getting zone by identifier. 	
	 * @param id Identifier of zone.
	 * @return {Response} Return PrestaShopZone.
	 */
    this.GetZoneRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetZoneRaw", id);
        return result;
    }

	/**
	 *  Getting zones identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopZone.
	 */
    this.GetZonesIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetZonesIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting zones by rendering options. 	
	 * @param renderingOptions For request specified information about zones use: display and filter or sort.
	 * @return {Response} Returns only certain information about Zone in PrestaShopZone class.
	 */
    this.GetZonesByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetZonesByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Getting shop group by identifier. 	
	 * @param id Identifier of shop group.
	 * @return {Response} Return PrestaShopShopGroup.
	 */
    this.GetShopGroupRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetShopGroupRaw", id);
        return result;
    }

	/**
	 *  Getting shop groups identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopShopGroup.
	 */
    this.GetShopGroupsIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetShopGroupsIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting shop groups by rendering options. 	
	 * @param renderingOptions For request specified information about shop groups use: display and filter or sort.
	 * @return {Response} Returns only certain information about ShopGroup in PrestaShopShopGroup class.
	 */
    this.GetShopGroupsByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetShopGroupsByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new shop url. 	
	 * @param shopUrl Body of shop url.
	 * @return {Response} If added return true.
	 */
    this.AddShopUrlRaw = function (shopUrl) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddShopUrlRaw", shopUrl);
        return result;
    }

	/**
	 *  Update information in specified shop url. 	
	 * @param shopUrl Body of shop url.
	 * @return {Response} Return updated PrestaShopShopUrl.
	 */
    this.EditShopUrlRaw = function (shopUrl) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditShopUrlRaw", shopUrl);
        return result;
    }

	/**
	 *  Remove shop url by identifier. 	
	 * @param id Identifier of shop url.
	 * @return {Response} If removed return true.
	 */
    this.DeleteShopUrlRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteShopUrlRaw", id);
        return result;
    }

	/**
	 *  Getting shop url by identifier. 	
	 * @param id Identifier of shop url.
	 * @return {Response} Return PrestaShopShopUrl.
	 */
    this.GetShopUrlRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetShopUrlRaw", id);
        return result;
    }

	/**
	 *  Getting shop urls identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopShopUrl.
	 */
    this.GetShopUrlsIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetShopUrlsIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting shop urls by rendering options. 	
	 * @param renderingOptions For request specified information about shop urls use: display and filter or sort.
	 * @return {Response} Returns only certain information about ShopUrl in PrestaShopShopUrl class.
	 */
    this.GetShopUrlsByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetShopUrlsByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new shop. 	
	 * @param shop Body of shop.
	 * @return {Response} If added return true.
	 */
    this.AddShopRaw = function (shop) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddShopRaw", shop);
        return result;
    }

	/**
	 *  Update information in specified shop. 	
	 * @param shop Body of shop.
	 * @return {Response} Return updated PrestaShopShop.
	 */
    this.EditShopRaw = function (shop) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditShopRaw", shop);
        return result;
    }

	/**
	 *  Remove shop by identifier. 	
	 * @param id Identifier of shop.
	 * @return {Response} If removed return true.
	 */
    this.DeleteShopRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteShopRaw", id);
        return result;
    }

	/**
	 *  Getting shop by identifier. 	
	 * @param id Identifier of shop.
	 * @return {Response} Return PrestaShopShop.
	 */
    this.GetShopRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetShopRaw", id);
        return result;
    }

	/**
	 *  Getting shops identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopShop.
	 */
    this.GetShopsIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetShopsIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting shops by rendering options. 	
	 * @param renderingOptions For request specified information about shops use: display and filter or sort.
	 * @return {Response} Returns only certain information about Shop in PrestaShopShop class.
	 */
    this.GetShopsByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetShopsByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new specific price rule. 	
	 * @param specificPriceRule Body of specific price rule.
	 * @return {Response} If added return true.
	 */
    this.AddSpecificPriceRuleRaw = function (specificPriceRule) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddSpecificPriceRuleRaw", specificPriceRule);
        return result;
    }

	/**
	 *  Update information in specified specific price rule. 	
	 * @param specificPriceRule Body of specific price rule.
	 * @return {Response} Return updated PrestaShopSpecificPriceRule.
	 */
    this.EditSpecificPriceRuleRaw = function (specificPriceRule) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditSpecificPriceRuleRaw", specificPriceRule);
        return result;
    }

	/**
	 *  Remove specific price rule by identifier. 	
	 * @param id Identifier of specific price rule.
	 * @return {Response} If removed return true.
	 */
    this.DeleteSpecificPriceRuleRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteSpecificPriceRuleRaw", id);
        return result;
    }

	/**
	 *  Getting specific price rule by identifier. 	
	 * @param id Identifier of specific price rule.
	 * @return {Response} Return PrestaShopSpecificPriceRule.
	 */
    this.GetSpecificPriceRuleRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSpecificPriceRuleRaw", id);
        return result;
    }

	/**
	 *  Getting specific price rules identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopSpecificPriceRule.
	 */
    this.GetSpecificPriceRulesIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSpecificPriceRulesIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting specific price rules by rendering options. 	
	 * @param renderingOptions For request specified information about specific price rules use: display and filter or sort.
	 * @return {Response} Returns only certain information about SpecificPriceRule in PrestaShopSpecificPriceRule class.
	 */
    this.GetSpecificPriceRulesByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSpecificPriceRulesByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new specific price. 	
	 * @param specificPrice Body of specific price.
	 * @return {Response} If added return true.
	 */
    this.AddSpecificPriceRaw = function (specificPrice) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddSpecificPriceRaw", specificPrice);
        return result;
    }

	/**
	 *  Update information in specified specific price. 	
	 * @param specificPrice Body of specific price.
	 * @return {Response} Return updated PrestaShopSpecificPrice.
	 */
    this.EditSpecificPriceRaw = function (specificPrice) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditSpecificPriceRaw", specificPrice);
        return result;
    }

	/**
	 *  Remove specific price by identifier. 	
	 * @param id Identifier of specific price.
	 * @return {Response} If removed return true.
	 */
    this.DeleteSpecificPriceRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteSpecificPriceRaw", id);
        return result;
    }

	/**
	 *  Getting specific price by identifier. 	
	 * @param id Identifier of specific price.
	 * @return {Response} Return PrestaShopSpecificPrice.
	 */
    this.GetSpecificPriceRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSpecificPriceRaw", id);
        return result;
    }

	/**
	 *  Getting specific prices identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopSpecificPrice.
	 */
    this.GetSpecificPricesIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSpecificPricesIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting specific prices by rendering options. 	
	 * @param renderingOptions For request specified information about specific prices use: display and filter or sort.
	 * @return {Response} Returns only certain information about SpecificPrice in PrestaShopSpecificPrice class.
	 */
    this.GetSpecificPricesByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSpecificPricesByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Getting state by identifier. 	
	 * @param id Identifier of state.
	 * @return {Response} Return PrestaShopState.
	 */
    this.GetStateRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetStateRaw", id);
        return result;
    }

	/**
	 *  Getting states identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopState.
	 */
    this.GetStatesIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetStatesIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting states by rendering options. 	
	 * @param renderingOptions For request specified information about states use: display and filter or sort.
	 * @return {Response} Returns only certain information about State in PrestaShopState class.
	 */
    this.GetStatesByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetStatesByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new stock movement reason. 	
	 * @param stockMovementReason Body of stock movement reason.
	 * @return {Response} If added return true.
	 */
    this.AddStockMovementReasonRaw = function (stockMovementReason) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddStockMovementReasonRaw", stockMovementReason);
        return result;
    }

	/**
	 *  Update information in specified stock movement reason. 	
	 * @param stockMovementReason Body of stock movement reason.
	 * @return {Response} Return updated PrestaShopStockMovementReason.
	 */
    this.EditStockMovementReasonRaw = function (stockMovementReason) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditStockMovementReasonRaw", stockMovementReason);
        return result;
    }

	/**
	 *  Remove stock movement reason by identifier. 	
	 * @param id Identifier of stock movement reason.
	 * @return {Response} If removed return true.
	 */
    this.DeleteStockMovementReasonRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteStockMovementReasonRaw", id);
        return result;
    }

	/**
	 *  Getting stock movement reason by identifier. 	
	 * @param id Identifier of stock movement reason.
	 * @return {Response} Return PrestaShopStockMovementReason.
	 */
    this.GetStockMovementReasonRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetStockMovementReasonRaw", id);
        return result;
    }

	/**
	 *  Getting stock movement reasons identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopStockMovementReason.
	 */
    this.GetStockMovementReasonsIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetStockMovementReasonsIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting stock movement reasons by rendering options. 	
	 * @param renderingOptions For request specified information about stock movement reasons use: display and filter or sort.
	 * @return {Response} Returns only certain information about StockMovementReason in PrestaShopStockMovementReason class.
	 */
    this.GetStockMovementReasonsByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetStockMovementReasonsByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Getting stock movement by identifier. 	
	 * @param id Identifier of stock movement.
	 * @return {Response} Return PrestaShopStockMovement.
	 */
    this.GetStockMovementRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetStockMovementRaw", id);
        return result;
    }

	/**
	 *  Getting stock movements identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopStockMovement.
	 */
    this.GetStockMovementsIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetStockMovementsIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting stock movements by rendering options. 	
	 * @param renderingOptions For request specified information about stock movements use: display and filter or sort.
	 * @return {Response} Returns only certain information about StockMovement in PrestaShopStockMovement class.
	 */
    this.GetStockMovementsByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetStockMovementsByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Getting stock by identifier. 	
	 * @param id Identifier of stock.
	 * @return {Response} Return PrestaShopStock.
	 */
    this.GetStockRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetStockRaw", id);
        return result;
    }

	/**
	 *  Getting stocks identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopStock.
	 */
    this.GetStocksIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetStocksIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting stocks by rendering options. 	
	 * @param renderingOptions For request specified information about stocks use: display and filter or sort.
	 * @return {Response} Returns only certain information about Stock in PrestaShopStock class.
	 */
    this.GetStocksByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetStocksByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new store. 	
	 * @param store Body of store.
	 * @return {Response} If added return true.
	 */
    this.AddStoreRaw = function (store) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddStoreRaw", store);
        return result;
    }

	/**
	 *  Update information in specified store. 	
	 * @param store Body of store.
	 * @return {Response} Return updated PrestaShopStore.
	 */
    this.EditStoreRaw = function (store) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditStoreRaw", store);
        return result;
    }

	/**
	 *  Remove store by identifier. 	
	 * @param id Identifier of store.
	 * @return {Response} If removed return true.
	 */
    this.DeleteStoreRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteStoreRaw", id);
        return result;
    }

	/**
	 *  Getting store by identifier. 	
	 * @param id Identifier of store.
	 * @return {Response} Return PrestaShopStore.
	 */
    this.GetStoreRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetStoreRaw", id);
        return result;
    }

	/**
	 *  Getting stores identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopStore.
	 */
    this.GetStoresIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetStoresIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting stores by rendering options. 	
	 * @param renderingOptions For request specified information about stores use: display and filter or sort.
	 * @return {Response} Returns only certain information about Store in PrestaShopStore class.
	 */
    this.GetStoresByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetStoresByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new supplier. 	
	 * @param supplier Body of supplier.
	 * @return {Response} If added return true.
	 */
    this.AddSupplierRaw = function (supplier) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddSupplierRaw", supplier);
        return result;
    }

	/**
	 *  Update information in specified supplier. 	
	 * @param supplier Body of supplier.
	 * @return {Response} Return updated PrestaShopSupplier.
	 */
    this.EditSupplierRaw = function (supplier) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditSupplierRaw", supplier);
        return result;
    }

	/**
	 *  Remove supplier by identifier. 	
	 * @param id Identifier of supplier.
	 * @return {Response} If removed return true.
	 */
    this.DeleteSupplierRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteSupplierRaw", id);
        return result;
    }

	/**
	 *  Getting supplier by identifier. 	
	 * @param id Identifier of supplier.
	 * @return {Response} Return PrestaShopSupplier.
	 */
    this.GetSupplierRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplierRaw", id);
        return result;
    }

	/**
	 *  Getting suppliers identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopSupplier.
	 */
    this.GetSuppliersIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSuppliersIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting suppliers by rendering options. 	
	 * @param renderingOptions For request specified information about suppliers use: display and filter or sort.
	 * @return {Response} Returns only certain information about Supplier in PrestaShopSupplier class.
	 */
    this.GetSuppliersByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSuppliersByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Getting supply order detail by identifier. 	
	 * @param id Identifier of supply order detail.
	 * @return {Response} Return PrestaShopSupplyOrderDetail.
	 */
    this.GetSupplyOrderDetailRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplyOrderDetailRaw", id);
        return result;
    }

	/**
	 *  Getting supply order details identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopSupplyOrderDetail.
	 */
    this.GetSupplyOrderDetailsIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplyOrderDetailsIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting supply order details by rendering options. 	
	 * @param renderingOptions For request specified information about supply order details use: display and filter or sort.
	 * @return {Response} Returns only certain information about SupplyOrderDetail in PrestaShopSupplyOrderDetail class.
	 */
    this.GetSupplyOrderDetailsByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplyOrderDetailsByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Getting supply order history by identifier. 	
	 * @param id Identifier of supply order history.
	 * @return {Response} Return PrestaShopSupplyOrderHistory.
	 */
    this.GetSupplyOrderHistoryRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplyOrderHistoryRaw", id);
        return result;
    }

	/**
	 *  Getting supply order histories identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopSupplyOrderHistory.
	 */
    this.GetSupplyOrderHistoriesIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplyOrderHistoriesIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting supply order histories by rendering options. 	
	 * @param renderingOptions For request specified information about supply order histories use: display and filter or sort.
	 * @return {Response} Returns only certain information about SupplyOrderHistory in PrestaShopSupplyOrderHistory class.
	 */
    this.GetSupplyOrderHistoriesByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplyOrderHistoriesByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Getting supply order receipt history by identifier. 	
	 * @param id Identifier of supply order receipt history.
	 * @return {Response} Return PrestaShopSupplyOrderReceiptHistory.
	 */
    this.GetSupplyOrderReceiptHistoryRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplyOrderReceiptHistoryRaw", id);
        return result;
    }

	/**
	 *  Getting supply order receipt histories identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopSupplyOrderReceiptHistory.
	 */
    this.GetSupplyOrderReceiptHistoriesIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplyOrderReceiptHistoriesIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting supply order receipt histories by rendering options. 	
	 * @param renderingOptions For request specified information about supply order receipt histories use: display and filter or sort.
	 * @return {Response} Returns only certain information about SupplyOrderReceiptHistory in PrestaShopSupplyOrderReceiptHistory class.
	 */
    this.GetSupplyOrderReceiptHistoriesByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplyOrderReceiptHistoriesByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Getting supply order state by identifier. 	
	 * @param id Identifier of supply order state.
	 * @return {Response} Return PrestaShopSupplyOrderState.
	 */
    this.GetSupplyOrderStateRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplyOrderStateRaw", id);
        return result;
    }

	/**
	 *  Getting order payments by rendering options. 	
	 * @param renderingOptions For request specified information about order payments use: display and filter or sort.
	 * @return {Response} Returns only certain information about OrderPayment in PrestaShopOrderPayment class.
	 */
    this.GetOrderPaymentsByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderPaymentsByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new order slip. 	
	 * @param orderSlip Body of order slip.
	 * @return {Response} If added return true.
	 */
    this.AddOrderSlipRaw = function (orderSlip) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddOrderSlipRaw", orderSlip);
        return result;
    }

	/**
	 *  Update information in specified order slip. 	
	 * @param orderSlip Body of order slip.
	 * @return {Response} Return updated PrestaShopOrderSlip.
	 */
    this.EditOrderSlipRaw = function (orderSlip) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditOrderSlipRaw", orderSlip);
        return result;
    }

	/**
	 *  Remove order slip by identifier. 	
	 * @param id Identifier of order slip.
	 * @return {Response} If removed return true.
	 */
    this.DeleteOrderSlipRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteOrderSlipRaw", id);
        return result;
    }

	/**
	 *  Getting order slip by identifier. 	
	 * @param id Identifier of order slip.
	 * @return {Response} Return PrestaShopOrderSlip.
	 */
    this.GetOrderSlipRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderSlipRaw", id);
        return result;
    }

	/**
	 *  Getting order slip identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopOrderSlip.
	 */
    this.GetOrderSlipIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderSlipIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting order slip by rendering options. 	
	 * @param renderingOptions For request specified information about order slip use: display and filter or sort.
	 * @return {Response} Returns only certain information about OrderSlip in PrestaShopOrderSlip class.
	 */
    this.GetOrderSlipByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderSlipByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Getting order state by identifier. 	
	 * @param id Identifier of order state.
	 * @return {Response} Return PrestaShopOrderState.
	 */
    this.GetOrderStateRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderStateRaw", id);
        return result;
    }

	/**
	 *  Getting order states identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopOrderState.
	 */
    this.GetOrderStatesIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderStatesIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting order states by rendering options. 	
	 * @param renderingOptions For request specified information about order states use: display and filter or sort.
	 * @return {Response} Returns only certain information about OrderState in PrestaShopOrderState class.
	 */
    this.GetOrderStatesByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderStatesByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Getting order by identifier. 	
	 * @param id Identifier of order.
	 * @return {Response} Return PrestaShopOrder.
	 */
    this.GetOrderRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderRaw", id);
        return result;
    }

	/**
	 *  Getting orders identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopOrder.
	 */
    this.GetOrdersIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrdersIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting orders by rendering options. 	
	 * @param renderingOptions For request specified information about orders use: display and filter or sort.
	 * @return {Response} Returns only certain information about Order in PrestaShopOrder class.
	 */
    this.GetOrdersByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrdersByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new price range. 	
	 * @param priceRange Body of price range.
	 * @return {Response} If added return true.
	 */
    this.AddPriceRangeRaw = function (priceRange) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddPriceRangeRaw", priceRange);
        return result;
    }

	/**
	 *  Update information in specified price range. 	
	 * @param priceRange Body of price range.
	 * @return {Response} Return updated PrestaShopPriceRange.
	 */
    this.EditPriceRangeRaw = function (priceRange) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditPriceRangeRaw", priceRange);
        return result;
    }

	/**
	 *  Remove price range by identifier. 	
	 * @param id Identifier of price range.
	 * @return {Response} If removed return true.
	 */
    this.DeletePriceRangeRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeletePriceRangeRaw", id);
        return result;
    }

	/**
	 *  Getting price range by identifier. 	
	 * @param id Identifier of price range.
	 * @return {Response} Return PrestaShopPriceRange.
	 */
    this.GetPriceRangeRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetPriceRangeRaw", id);
        return result;
    }

	/**
	 *  Getting price ranges identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopPriceRange.
	 */
    this.GetPriceRangesIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetPriceRangesIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting price ranges by rendering options. 	
	 * @param renderingOptions For request specified information about price ranges use: display and filter or sort.
	 * @return {Response} Returns only certain information about PriceRange in PrestaShopPriceRange class.
	 */
    this.GetPriceRangesByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetPriceRangesByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new product customization field. 	
	 * @param productCustomizationField Body of product customization field.
	 * @return {Response} If added return true.
	 */
    this.AddProductCustomizationFieldRaw = function (productCustomizationField) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddProductCustomizationFieldRaw", productCustomizationField);
        return result;
    }

	/**
	 *  Update information in specified product customization field. 	
	 * @param productCustomizationField Body of product customization field.
	 * @return {Response} Return updated PrestaShopProductCustomizationField.
	 */
    this.EditProductCustomizationFieldRaw = function (productCustomizationField) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditProductCustomizationFieldRaw", productCustomizationField);
        return result;
    }

	/**
	 *  Remove product customization field by identifier. 	
	 * @param id Identifier of product customization field.
	 * @return {Response} If removed return true.
	 */
    this.DeleteProductCustomizationFieldRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteProductCustomizationFieldRaw", id);
        return result;
    }

	/**
	 *  Getting product customization field by identifier. 	
	 * @param id Identifier of product customization field.
	 * @return {Response} Return PrestaShopProductCustomizationField.
	 */
    this.GetProductCustomizationFieldRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductCustomizationFieldRaw", id);
        return result;
    }

	/**
	 *  Getting product customization fields identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopProductCustomizationField.
	 */
    this.GetProductCustomizationFieldsIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductCustomizationFieldsIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting product customization fields by rendering options. 	
	 * @param renderingOptions For request specified information about product customization fields use: display and filter or sort.
	 * @return {Response} Returns only certain information about ProductCustomizationField in PrestaShopProductCustomizationField class.
	 */
    this.GetProductCustomizationFieldsByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductCustomizationFieldsByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new product feature value. 	
	 * @param productFeatureValue Body of product feature value.
	 * @return {Response} If added return true.
	 */
    this.AddProductFeatureValueRaw = function (productFeatureValue) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddProductFeatureValueRaw", productFeatureValue);
        return result;
    }

	/**
	 *  Update information in specified product feature value. 	
	 * @param productFeatureValue Body of product feature value.
	 * @return {Response} Return updated PrestaShopProductFeatureValue.
	 */
    this.EditProductFeatureValueRaw = function (productFeatureValue) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditProductFeatureValueRaw", productFeatureValue);
        return result;
    }

	/**
	 *  Remove product feature value by identifier. 	
	 * @param id Identifier of product feature value.
	 * @return {Response} If removed return true.
	 */
    this.DeleteProductFeatureValueRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteProductFeatureValueRaw", id);
        return result;
    }

	/**
	 *  Getting product feature value by identifier. 	
	 * @param id Identifier of product feature value.
	 * @return {Response} Return PrestaShopProductFeatureValue.
	 */
    this.GetProductFeatureValueRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductFeatureValueRaw", id);
        return result;
    }

	/**
	 *  Getting product feature values identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopProductFeatureValue.
	 */
    this.GetProductFeatureValuesIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductFeatureValuesIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting product feature values by rendering options. 	
	 * @param renderingOptions For request specified information about product feature values use: display and filter or sort.
	 * @return {Response} Returns only certain information about ProductFeatureValue in PrestaShopProductFeatureValue class.
	 */
    this.GetProductFeatureValuesByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductFeatureValuesByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new product feature. 	
	 * @param productFeature Body of product feature.
	 * @return {Response} If added return true.
	 */
    this.AddProductFeatureRaw = function (productFeature) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddProductFeatureRaw", productFeature);
        return result;
    }

	/**
	 *  Update information in specified product feature. 	
	 * @param productFeature Body of product feature.
	 * @return {Response} Return updated PrestaShopProductFeature.
	 */
    this.EditProductFeatureRaw = function (productFeature) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditProductFeatureRaw", productFeature);
        return result;
    }

	/**
	 *  Remove product feature by identifier. 	
	 * @param id Identifier of product feature.
	 * @return {Response} If removed return true.
	 */
    this.DeleteProductFeatureRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteProductFeatureRaw", id);
        return result;
    }

	/**
	 *  Getting product feature by identifier. 	
	 * @param id Identifier of product feature.
	 * @return {Response} Return PrestaShopProductFeature.
	 */
    this.GetProductFeatureRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductFeatureRaw", id);
        return result;
    }

	/**
	 *  Getting product features identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopProductFeature.
	 */
    this.GetProductFeaturesIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductFeaturesIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting product features by rendering options. 	
	 * @param renderingOptions For request specified information about product features use: display and filter or sort.
	 * @return {Response} Returns only certain information about ProductFeature in PrestaShopProductFeature class.
	 */
    this.GetProductFeaturesByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductFeaturesByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new product option value. 	
	 * @param productOptionValue Body of product option value.
	 * @return {Response} If added return true.
	 */
    this.AddProductOptionValueRaw = function (productOptionValue) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddProductOptionValueRaw", productOptionValue);
        return result;
    }

	/**
	 *  Update information in specified product option value. 	
	 * @param productOptionValue Body of product option value.
	 * @return {Response} Return updated PrestaShopProductOptionValue.
	 */
    this.EditProductOptionValueRaw = function (productOptionValue) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditProductOptionValueRaw", productOptionValue);
        return result;
    }

	/**
	 *  Remove product option value by identifier. 	
	 * @param id Identifier of product option value.
	 * @return {Response} If removed return true.
	 */
    this.DeleteProductOptionValueRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteProductOptionValueRaw", id);
        return result;
    }

	/**
	 *  Getting product option value by identifier. 	
	 * @param id Identifier of product option value.
	 * @return {Response} Return PrestaShopProductOptionValue.
	 */
    this.GetProductOptionValueRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductOptionValueRaw", id);
        return result;
    }

	/**
	 *  Getting product option values identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopProductOptionValue.
	 */
    this.GetProductOptionValuesIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductOptionValuesIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting product option values by rendering options. 	
	 * @param renderingOptions For request specified information about product option values use: display and filter or sort.
	 * @return {Response} Returns only certain information about ProductOptionValue in PrestaShopProductOptionValue class.
	 */
    this.GetProductOptionValuesByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductOptionValuesByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new product option. 	
	 * @param productOption Body of product option.
	 * @return {Response} If added return true.
	 */
    this.AddProductOptionRaw = function (productOption) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddProductOptionRaw", productOption);
        return result;
    }

	/**
	 *  Update information in specified product option. 	
	 * @param productOption Body of product option.
	 * @return {Response} Return updated PrestaShopProductOption.
	 */
    this.EditProductOptionRaw = function (productOption) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditProductOptionRaw", productOption);
        return result;
    }

	/**
	 *  Remove product option by identifier. 	
	 * @param id Identifier of product option.
	 * @return {Response} If removed return true.
	 */
    this.DeleteProductOptionRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteProductOptionRaw", id);
        return result;
    }

	/**
	 *  Getting product option by identifier. 	
	 * @param id Identifier of product option.
	 * @return {Response} Return PrestaShopProductOption.
	 */
    this.GetProductOptionRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductOptionRaw", id);
        return result;
    }

	/**
	 *  Getting product options identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopProductOption.
	 */
    this.GetProductOptionsIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductOptionsIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting product options by rendering options. 	
	 * @param renderingOptions For request specified information about product options use: display and filter or sort.
	 * @return {Response} Returns only certain information about ProductOption in PrestaShopProductOption class.
	 */
    this.GetProductOptionsByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductOptionsByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new product supplier. 	
	 * @param productSupplier Body of product supplier.
	 * @return {Response} If added return true.
	 */
    this.AddProductSupplierRaw = function (productSupplier) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddProductSupplierRaw", productSupplier);
        return result;
    }

	/**
	 *  Update information in specified product supplier. 	
	 * @param productSupplier Body of product supplier.
	 * @return {Response} Return updated PrestaShopProductSupplier.
	 */
    this.EditProductSupplierRaw = function (productSupplier) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditProductSupplierRaw", productSupplier);
        return result;
    }

	/**
	 *  Remove product supplier by identifier. 	
	 * @param id Identifier of product supplier.
	 * @return {Response} If removed return true.
	 */
    this.DeleteProductSupplierRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteProductSupplierRaw", id);
        return result;
    }

	/**
	 *  Getting product supplier by identifier. 	
	 * @param id Identifier of product supplier.
	 * @return {Response} Return PrestaShopProductSupplier.
	 */
    this.GetProductSupplierRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductSupplierRaw", id);
        return result;
    }

	/**
	 *  Getting product suppliers identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopProductSupplier.
	 */
    this.GetProductSuppliersIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductSuppliersIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting product suppliers by rendering options. 	
	 * @param renderingOptions For request specified information about product suppliers use: display and filter or sort.
	 * @return {Response} Returns only certain information about ProductSupplier in PrestaShopProductSupplier class.
	 */
    this.GetProductSuppliersByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductSuppliersByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new product supplier. 	
	 * @param product Body of product supplier.
	 * @return {Response} If added return true.
	 */
    this.AddProductRaw = function (product) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddProductRaw", product);
        return result;
    }

	/**
	 *  Update information in specified product supplier. 	
	 * @param product Body of product supplier.
	 * @return {Response} Return updated PrestaShopProduct.
	 */
    this.EditProductRaw = function (product) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditProductRaw", product);
        return result;
    }

	/**
	 *  Remove product by identifier. 	
	 * @param id Identifier of product.
	 * @return {Response} If removed return true.
	 */
    this.DeleteProductRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteProductRaw", id);
        return result;
    }

	/**
	 *  Getting product by identifier. 	
	 * @param id Identifier of product.
	 * @return {Response} Return PrestaShopProduct.
	 */
    this.GetProductRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductRaw", id);
        return result;
    }

	/**
	 *  Getting products identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopProduct.
	 */
    this.GetProductsIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductsIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting products by rendering options. 	
	 * @param renderingOptions For request specified information about products use: display and filter or sort.
	 * @return {Response} Returns only certain information about Product in PrestaShopProduct class.
	 */
    this.GetProductsByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductsByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new shop group. 	
	 * @param shopGroup Body of shop group.
	 * @return {Response} If added return true.
	 */
    this.AddShopGroupRaw = function (shopGroup) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddShopGroupRaw", shopGroup);
        return result;
    }

	/**
	 *  Update information in specified shop group. 	
	 * @param shopGroup Body of shop group.
	 * @return {Response} Return updated PrestaShopShopGroup.
	 */
    this.EditShopGroupRaw = function (shopGroup) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditShopGroupRaw", shopGroup);
        return result;
    }

	/**
	 *  Remove shop group by identifier. 	
	 * @param id Identifier of shop group.
	 * @return {Response} If removed return true.
	 */
    this.DeleteShopGroupRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteShopGroupRaw", id);
        return result;
    }

	/**
	 *  Update information in specified group. 	
	 * @param group Body of group.
	 * @return {Response} Return updated PrestaShopGroup.
	 */
    this.EditGroupRaw = function (group) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditGroupRaw", group);
        return result;
    }

	/**
	 *  Remove group by identifier. 	
	 * @param id Identifier of group.
	 * @return {Response} If removed return true.
	 */
    this.DeleteGroupRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteGroupRaw", id);
        return result;
    }

	/**
	 *  Getting group by identifier. 	
	 * @param id Identifier of group.
	 * @return {Response} Return PrestaShopGroup.
	 */
    this.GetGroupRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetGroupRaw", id);
        return result;
    }

	/**
	 *  Getting groups identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopGroup.
	 */
    this.GetGroupsIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetGroupsIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting groups by rendering options. 	
	 * @param renderingOptions For request specified information about groups use: display and filter or sort.
	 * @return {Response} Returns only certain information about Group in PrestaShopGroup class.
	 */
    this.GetGroupsByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetGroupsByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new guest. 	
	 * @param guest Body of guest.
	 * @return {Response} If added return true.
	 */
    this.AddGuestRaw = function (guest) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddGuestRaw", guest);
        return result;
    }

	/**
	 *  Update information in specified guest. 	
	 * @param guest Body of guest.
	 * @return {Response} Return updated PrestaShopGuest.
	 */
    this.EditGuestRaw = function (guest) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditGuestRaw", guest);
        return result;
    }

	/**
	 *  Remove guest by identifier. 	
	 * @param id Identifier of guest.
	 * @return {Response} If removed return true.
	 */
    this.DeleteGuestRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteGuestRaw", id);
        return result;
    }

	/**
	 *  Getting guest by identifier. 	
	 * @param id Identifier of guest.
	 * @return {Response} Return PrestaShopGuest.
	 */
    this.GetGuestRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetGuestRaw", id);
        return result;
    }

	/**
	 *  Getting guests identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopGuest.
	 */
    this.GetGuestsIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetGuestsIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting guests by rendering options. 	
	 * @param renderingOptions For request specified information about guests use: display and filter or sort.
	 * @return {Response} Returns only certain information about Guest in PrestaShopGuest class.
	 */
    this.GetGuestsByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetGuestsByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new image type. 	
	 * @param imageType Body of image type.
	 * @return {Response} If added return true.
	 */
    this.AddImageTypeRaw = function (imageType) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddImageTypeRaw", imageType);
        return result;
    }

	/**
	 *  Update information in specified image type. 	
	 * @param imageType Body of image type.
	 * @return {Response} Return updated PrestaShopImageType.
	 */
    this.EditImageTypeRaw = function (imageType) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditImageTypeRaw", imageType);
        return result;
    }

	/**
	 *  Remove image type by identifier. 	
	 * @param id Identifier of image type.
	 * @return {Response} If removed return true.
	 */
    this.DeleteImageTypeRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteImageTypeRaw", id);
        return result;
    }

	/**
	 *  Getting image type by identifier. 	
	 * @param id Identifier of image type.
	 * @return {Response} Return PrestaShopImageType.
	 */
    this.GetImageTypeRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetImageTypeRaw", id);
        return result;
    }

	/**
	 *  Getting image types identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopImageType.
	 */
    this.GetImageTypesIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetImageTypesIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting image types by rendering options. 	
	 * @param renderingOptions For request specified information about image types use: display and filter or sort.
	 * @return {Response} Returns only certain information about ImageType in PrestaShopImageType class.
	 */
    this.GetImageTypesByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetImageTypesByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new image. 	
	 * @param image Body of image.
	 * @return {Response} If added return true.
	 */
    this.AddImageRaw = function (image) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddImageRaw", image);
        return result;
    }

	/**
	 *  Update information in specified image. 	
	 * @param image Body of image.
	 * @return {Response} Return updated PrestaShopImage.
	 */
    this.EditImageRaw = function (image) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditImageRaw", image);
        return result;
    }

	/**
	 *  Remove image by identifier. 	
	 * @param id Identifier of image.
	 * @return {Response} If removed return true.
	 */
    this.DeleteImageRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteImageRaw", id);
        return result;
    }

	/**
	 *  Getting image by identifier. 	
	 * @param id Identifier of image.
	 * @return {Response} Return PrestaShopImage.
	 */
    this.GetImageRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetImageRaw", id);
        return result;
    }

	/**
	 *  Getting images identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopImage.
	 */
    this.GetImagesIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetImagesIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting images by rendering options. 	
	 * @param renderingOptions For request specified information about images use: display and filter or sort.
	 * @return {Response} Returns only certain information about Image in PrestaShopImage class.
	 */
    this.GetImagesByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetImagesByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new language. 	
	 * @param language Body of language.
	 * @return {Response} If added return true.
	 */
    this.AddLanguageRaw = function (language) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddLanguageRaw", language);
        return result;
    }

	/**
	 *  Update information in specified language. 	
	 * @param language Body of language.
	 * @return {Response} Return updated PrestaShopLanguage.
	 */
    this.EditLanguageRaw = function (language) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditLanguageRaw", language);
        return result;
    }

	/**
	 *  Remove language by identifier. 	
	 * @param id Identifier of language.
	 * @return {Response} If removed return true.
	 */
    this.DeleteLanguageRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteLanguageRaw", id);
        return result;
    }

	/**
	 *  Getting language by identifier. 	
	 * @param id Identifier of language.
	 * @return {Response} Return PrestaShopLanguage.
	 */
    this.GetLanguageRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetLanguageRaw", id);
        return result;
    }

	/**
	 *  Getting languages identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopLanguage.
	 */
    this.GetLanguagesIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetLanguagesIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting languages by rendering options. 	
	 * @param renderingOptions For request specified information about languages use: display and filter or sort.
	 * @return {Response} Returns only certain information about Language in PrestaShopLanguage class.
	 */
    this.GetLanguagesByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetLanguagesByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new manufacturer. 	
	 * @param manufacturer Body of manufacturer.
	 * @return {Response} If added return true.
	 */
    this.AddManufacturerRaw = function (manufacturer) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddManufacturerRaw", manufacturer);
        return result;
    }

	/**
	 *  Update information in specified manufacturer. 	
	 * @param manufacturer Body of manufacturer.
	 * @return {Response} Return updated PrestaShopManufacturer.
	 */
    this.EditManufacturerRaw = function (manufacturer) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditManufacturerRaw", manufacturer);
        return result;
    }

	/**
	 *  Remove manufacturer by identifier. 	
	 * @param id Identifier of manufacturer.
	 * @return {Response} If removed return true.
	 */
    this.DeleteManufacturerRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteManufacturerRaw", id);
        return result;
    }

	/**
	 *  Getting manufacturer by identifier. 	
	 * @param id Identifier of manufacturer.
	 * @return {Response} Return PrestaShopManufacturer.
	 */
    this.GetManufacturerRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetManufacturerRaw", id);
        return result;
    }

	/**
	 *  Getting manufacturers identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopManufacturer.
	 */
    this.GetManufacturersIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetManufacturersIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting manufacturers by rendering options. 	
	 * @param renderingOptions For request specified information about manufacturers use: display and filter or sort.
	 * @return {Response} Returns only certain information about Manufacturer in PrestaShopManufacturer class.
	 */
    this.GetManufacturersByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetManufacturersByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new message. 	
	 * @param message Body of message.
	 * @return {Response} If added return true.
	 */
    this.AddMessageRaw = function (message) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddMessageRaw", message);
        return result;
    }

	/**
	 *  Update information in specified message. 	
	 * @param message Body of message.
	 * @return {Response} Return updated PrestaShopMessage.
	 */
    this.EditMessageRaw = function (message) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditMessageRaw", message);
        return result;
    }

	/**
	 *  Remove message by identifier. 	
	 * @param id Identifier of message.
	 * @return {Response} If removed return true.
	 */
    this.DeleteMessageRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteMessageRaw", id);
        return result;
    }

	/**
	 *  Getting message by identifier. 	
	 * @param id Identifier of message.
	 * @return {Response} Return PrestaShopMessage.
	 */
    this.GetMessageRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetMessageRaw", id);
        return result;
    }

	/**
	 *  Getting messages identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopMessage.
	 */
    this.GetMessagesIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetMessagesIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting messages by rendering options. 	
	 * @param renderingOptions For request specified information about messages use: display and filter or sort.
	 * @return {Response} Returns only certain information about Message in PrestaShopMessage class.
	 */
    this.GetMessagesByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetMessagesByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new order carrier. 	
	 * @param orderCarrier Body of order carrier.
	 * @return {Response} If added return true.
	 */
    this.AddOrderCarrierRaw = function (orderCarrier) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddOrderCarrierRaw", orderCarrier);
        return result;
    }

	/**
	 *  Update information in specified order carrier. 	
	 * @param orderCarrier Body of order carrier.
	 * @return {Response} Return updated PrestaShopOrderCarrier.
	 */
    this.EditOrderCarrierRaw = function (orderCarrier) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditOrderCarrierRaw", orderCarrier);
        return result;
    }

	/**
	 *  Remove order carrier by identifier. 	
	 * @param id Identifier of order carrier.
	 * @return {Response} If removed return true.
	 */
    this.DeleteOrderCarrierRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteOrderCarrierRaw", id);
        return result;
    }

	/**
	 *  Getting order carrier by identifier. 	
	 * @param id Identifier of order carrier.
	 * @return {Response} Return PrestaShopOrderCarrier.
	 */
    this.GetOrderCarrierRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderCarrierRaw", id);
        return result;
    }

	/**
	 *  Getting order carriers identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopOrderCarrier.
	 */
    this.GetOrderCarriersIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderCarriersIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting order carriers by rendering options. 	
	 * @param renderingOptions For request specified information about order carriers use: display and filter or sort.
	 * @return {Response} Returns only certain information about OrderCarrier in PrestaShopOrderCarrier class.
	 */
    this.GetOrderCarriersByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderCarriersByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Getting order detail by identifier. 	
	 * @param id Identifier of order detail.
	 * @return {Response} Return PrestaShopOrderDetail.
	 */
    this.GetOrderDetailRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderDetailRaw", id);
        return result;
    }

	/**
	 *  Getting order details identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopOrderDetail.
	 */
    this.GetOrderDetailsIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderDetailsIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting order details by rendering options. 	
	 * @param renderingOptions For request specified information about order details use: display and filter or sort.
	 * @return {Response} Returns only certain information about OrderDetail in PrestaShopOrderDetail class.
	 */
    this.GetOrderDetailsByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderDetailsByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Getting order history by identifier. 	
	 * @param id Identifier of order history.
	 * @return {Response} Return PrestaShopOrderHistory.
	 */
    this.GetOrderHistoryRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderHistoryRaw", id);
        return result;
    }

	/**
	 *  Getting order histories identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopOrderHistory.
	 */
    this.GetOrderHistoriesIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderHistoriesIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting order histories by rendering options. 	
	 * @param renderingOptions For request specified information about order histories use: display and filter or sort.
	 * @return {Response} Returns only certain information about OrderHistory in PrestaShopOrderHistory class.
	 */
    this.GetOrderHistoriesByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderHistoriesByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new order invoice. 	
	 * @param orderInvoice Body of order invoice.
	 * @return {Response} If added return true.
	 */
    this.AddOrderInvoiceRaw = function (orderInvoice) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddOrderInvoiceRaw", orderInvoice);
        return result;
    }

	/**
	 *  Update information in specified order invoice. 	
	 * @param orderInvoice Body of order invoice.
	 * @return {Response} Return updated PrestaShopOrderInvoice.
	 */
    this.EditOrderInvoiceRaw = function (orderInvoice) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditOrderInvoiceRaw", orderInvoice);
        return result;
    }

	/**
	 *  Remove order invoice by identifier. 	
	 * @param id Identifier of order invoice.
	 * @return {Response} If removed return true.
	 */
    this.DeleteOrderInvoiceRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteOrderInvoiceRaw", id);
        return result;
    }

	/**
	 *  Getting order invoice by identifier. 	
	 * @param id Identifier of order invoice.
	 * @return {Response} Return PrestaShopOrderInvoice.
	 */
    this.GetOrderInvoiceRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderInvoiceRaw", id);
        return result;
    }

	/**
	 *  Getting order invoices identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopOrderInvoice.
	 */
    this.GetOrderInvoicesIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderInvoicesIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting order invoices by rendering options. 	
	 * @param renderingOptions For request specified information about order invoices use: display and filter or sort.
	 * @return {Response} Returns only certain information about OrderInvoice in PrestaShopOrderInvoice class.
	 */
    this.GetOrderInvoicesByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderInvoicesByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new order payment. 	
	 * @param orderPayment Body of order payment.
	 * @return {Response} If added return true.
	 */
    this.AddOrderPaymentRaw = function (orderPayment) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddOrderPaymentRaw", orderPayment);
        return result;
    }

	/**
	 *  Update information in specified order payment. 	
	 * @param orderPayment Body of order payment.
	 * @return {Response} Return updated PrestaShopOrderPayment.
	 */
    this.EditOrderPaymentRaw = function (orderPayment) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditOrderPaymentRaw", orderPayment);
        return result;
    }

	/**
	 *  Remove order payment by identifier. 	
	 * @param id Identifier of order payment.
	 * @return {Response} If removed return true.
	 */
    this.DeleteOrderPaymentRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteOrderPaymentRaw", id);
        return result;
    }

	/**
	 *  Getting order payment by identifier. 	
	 * @param id Identifier of order payment.
	 * @return {Response} Return PrestaShopOrderPayment.
	 */
    this.GetOrderPaymentRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderPaymentRaw", id);
        return result;
    }

	/**
	 *  Getting order payments identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopOrderPayment.
	 */
    this.GetOrderPaymentsIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderPaymentsIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting configuration by identifier. 	
	 * @param id Identifier of configuration.
	 * @return {Response} Return PrestaShopConfiguration.
	 */
    this.GetConfigurationRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetConfigurationRaw", id);
        return result;
    }

	/**
	 *  Getting configurations identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopConfiguration.
	 */
    this.GetConfigurationsIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetConfigurationsIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting configurations by rendering options. 	
	 * @param renderingOptions For request specified information about configurations use: display and filter or sort.
	 * @return {Response} Returns only certain information about Configuration in PrestaShopConfiguration class.
	 */
    this.GetConfigurationsByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetConfigurationsByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new contact. 	
	 * @param contact Body of contact.
	 * @return {Response} If added return true.
	 */
    this.AddContactRaw = function (contact) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddContactRaw", contact);
        return result;
    }

	/**
	 *  Update information in specified contact. 	
	 * @param contact Body of contact.
	 * @return {Response} Return updated PrestaShopContact.
	 */
    this.EditContactRaw = function (contact) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditContactRaw", contact);
        return result;
    }

	/**
	 *  Remove contact by identifier. 	
	 * @param id Identifier of contact.
	 * @return {Response} If removed return true.
	 */
    this.DeleteContactRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteContactRaw", id);
        return result;
    }

	/**
	 *  Getting contact by identifier. 	
	 * @param id Identifier of contact.
	 * @return {Response} Return PrestaShopContact.
	 */
    this.GetContactRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetContactRaw", id);
        return result;
    }

	/**
	 *  Getting contacts identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopContact.
	 */
    this.GetContactsIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetContactsIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting contacts by rendering options. 	
	 * @param renderingOptions For request specified information about contacts use: display and filter or sort.
	 * @return {Response} Returns only certain information about Contact in PrestaShopContact class.
	 */
    this.GetContactsByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetContactsByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new content management system. 	
	 * @param contentManagementSystem Body of content management system.
	 * @return {Response} If added return true.
	 */
    this.AddContentManagementSystemRaw = function (contentManagementSystem) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddContentManagementSystemRaw", contentManagementSystem);
        return result;
    }

	/**
	 *  Update information in specified content management system. 	
	 * @param contentManagementSystem Body of content management system.
	 * @return {Response} Return updated PrestaShopContentManagementSystem.
	 */
    this.EditContentManagementSystemRaw = function (contentManagementSystem) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditContentManagementSystemRaw", contentManagementSystem);
        return result;
    }

	/**
	 *  Remove content management system by identifier. 	
	 * @param id Identifier of content management system.
	 * @return {Response} If removed return true.
	 */
    this.DeleteContentManagementSystemRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteContentManagementSystemRaw", id);
        return result;
    }

	/**
	 *  Getting content management system by identifier. 	
	 * @param id Identifier of content management system.
	 * @return {Response} Return PrestaShopContentManagementSystem.
	 */
    this.GetContentManagementSystemRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetContentManagementSystemRaw", id);
        return result;
    }

	/**
	 *  Getting content management system identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopContentManagementSystem.
	 */
    this.GetContentManagementSystemIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetContentManagementSystemIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting content management system by rendering options. 	
	 * @param renderingOptions For request specified information about content management system use: display and filter or sort.
	 * @return {Response} Returns only certain information about ContentManagementSystem in PrestaShopContentManagementSystem class.
	 */
    this.GetContentManagementSystemByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetContentManagementSystemByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new country. 	
	 * @param country Body of country.
	 * @return {Response} If added return true.
	 */
    this.AddCountryRaw = function (country) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddCountryRaw", country);
        return result;
    }

	/**
	 *  Update information in specified country. 	
	 * @param country Body of country.
	 * @return {Response} Return updated PrestaShopCountry.
	 */
    this.EditCountryRaw = function (country) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditCountryRaw", country);
        return result;
    }

	/**
	 *  Remove country by identifier. 	
	 * @param id Identifier of country.
	 * @return {Response} If removed return true.
	 */
    this.DeleteCountryRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteCountryRaw", id);
        return result;
    }

	/**
	 *  Getting country by identifier. 	
	 * @param id Identifier of country.
	 * @return {Response} Return PrestaShopCountry.
	 */
    this.GetCountryRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCountryRaw", id);
        return result;
    }

	/**
	 *  Getting countries identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopCountry.
	 */
    this.GetCountriesIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCountriesIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting countries by rendering options. 	
	 * @param renderingOptions For request specified information about countries use: display and filter or sort.
	 * @return {Response} Returns only certain information about Country in PrestaShopCountry class.
	 */
    this.GetCountriesByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCountriesByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new currency. 	
	 * @param currency Body of currency.
	 * @return {Response} If added return true.
	 */
    this.AddCurrencyRaw = function (currency) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddCurrencyRaw", currency);
        return result;
    }

	/**
	 *  Update information in specified currency. 	
	 * @param currency Body of currency.
	 * @return {Response} Return updated PrestaShopCurrency.
	 */
    this.EditCurrencyRaw = function (currency) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditCurrencyRaw", currency);
        return result;
    }

	/**
	 *  Remove currency by identifier. 	
	 * @param id Identifier of currency.
	 * @return {Response} If removed return true.
	 */
    this.DeleteCurrencyRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteCurrencyRaw", id);
        return result;
    }

	/**
	 *  Getting currency by identifier. 	
	 * @param id Identifier of currency.
	 * @return {Response} Return PrestaShopCurrency.
	 */
    this.GetCurrencyRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCurrencyRaw", id);
        return result;
    }

	/**
	 *  Getting currencies identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopCurrency.
	 */
    this.GetCurrenciesIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCurrenciesIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting currencies by rendering options. 	
	 * @param renderingOptions For request specified information about currencies use: display and filter or sort.
	 * @return {Response} Returns only certain information about Currency in PrestaShopCurrency class.
	 */
    this.GetCurrenciesByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCurrenciesByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new customer message. 	
	 * @param customerMessage Body of customer message.
	 * @return {Response} If added return true.
	 */
    this.AddCustomerMessageRaw = function (customerMessage) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddCustomerMessageRaw", customerMessage);
        return result;
    }

	/**
	 *  Update information in specified customer message. 	
	 * @param customerMessage Body of customer message.
	 * @return {Response} Return updated PrestaShopCustomerMessage.
	 */
    this.EditCustomerMessageRaw = function (customerMessage) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditCustomerMessageRaw", customerMessage);
        return result;
    }

	/**
	 *  Remove customer message by identifier. 	
	 * @param id Identifier of customer message.
	 * @return {Response} If removed return true.
	 */
    this.DeleteCustomerMessageRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteCustomerMessageRaw", id);
        return result;
    }

	/**
	 *  Getting customer message by identifier. 	
	 * @param id Identifier of customer message.
	 * @return {Response} Return PrestaShopCustomerMessage.
	 */
    this.GetCustomerMessageRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCustomerMessageRaw", id);
        return result;
    }

	/**
	 *  Getting customer messages identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopCustomerMessage.
	 */
    this.GetCustomerMessagesIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCustomerMessagesIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting customer messages by rendering options. 	
	 * @param renderingOptions For request specified information about customer messages use: display and filter or sort.
	 * @return {Response} Returns only certain information about CustomerMessage in PrestaShopCustomerMessage class.
	 */
    this.GetCustomerMessagesByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCustomerMessagesByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new customer thread. 	
	 * @param customerThread Body of customer thread.
	 * @return {Response} If added return true.
	 */
    this.AddCustomerThreadRaw = function (customerThread) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddCustomerThreadRaw", customerThread);
        return result;
    }

	/**
	 *  Update information in specified customer thread. 	
	 * @param customerThread Body of customer thread.
	 * @return {Response} Return updated PrestaShopCustomerThread.
	 */
    this.EditCustomerThreadRaw = function (customerThread) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditCustomerThreadRaw", customerThread);
        return result;
    }

	/**
	 *  Remove customer thread by identifier. 	
	 * @param id Identifier of customer thread.
	 * @return {Response} If removed return true.
	 */
    this.DeleteCustomerThreadRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteCustomerThreadRaw", id);
        return result;
    }

	/**
	 *  Getting customer thread by identifier. 	
	 * @param id Identifier of customer thread.
	 * @return {Response} Return PrestaShopCustomerThread.
	 */
    this.GetCustomerThreadRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCustomerThreadRaw", id);
        return result;
    }

	/**
	 *  Getting customer threads identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopCustomerThread.
	 */
    this.GetCustomerThreadsIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCustomerThreadsIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting customer threads by rendering options. 	
	 * @param renderingOptions For request specified information about customer threads use: display and filter or sort.
	 * @return {Response} Returns only certain information about CustomerThread in PrestaShopCustomerThread class.
	 */
    this.GetCustomerThreadsByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCustomerThreadsByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new customer. 	
	 * @param customer Body of customer.
	 * @return {Response} If added return true.
	 */
    this.AddCustomerRaw = function (customer) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddCustomerRaw", customer);
        return result;
    }

	/**
	 *  Update information in specified customer. 	
	 * @param customer Body of customer.
	 * @return {Response} Return updated PrestaShopCustomer.
	 */
    this.EditCustomerRaw = function (customer) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditCustomerRaw", customer);
        return result;
    }

	/**
	 *  Remove customer by identifier. 	
	 * @param id Identifier of customer.
	 * @return {Response} If removed return true.
	 */
    this.DeleteCustomerRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteCustomerRaw", id);
        return result;
    }

	/**
	 *  Getting customer by identifier. 	
	 * @param id Identifier of customer.
	 * @return {Response} Return PrestaShopCustomer.
	 */
    this.GetCustomerRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCustomerRaw", id);
        return result;
    }

	/**
	 *  Getting customers identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopCustomer.
	 */
    this.GetCustomersIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCustomersIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting customers by rendering options. 	
	 * @param renderingOptions For request specified information about customers use: display and filter or sort.
	 * @return {Response} Returns only certain information about Customer in PrestaShopCustomer class.
	 */
    this.GetCustomersByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCustomersByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new customization. 	
	 * @param customization Body of customization.
	 * @return {Response} If added return true.
	 */
    this.AddCustomizationRaw = function (customization) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddCustomizationRaw", customization);
        return result;
    }

	/**
	 *  Update information in specified customization. 	
	 * @param customization Body of customization.
	 * @return {Response} Return updated PrestaShopCustomization.
	 */
    this.EditCustomizationRaw = function (customization) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditCustomizationRaw", customization);
        return result;
    }

	/**
	 *  Remove customization by identifier. 	
	 * @param id Identifier of customization.
	 * @return {Response} If removed return true.
	 */
    this.DeleteCustomizationRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteCustomizationRaw", id);
        return result;
    }

	/**
	 *  Getting customization by identifier. 	
	 * @param id Identifier of customization.
	 * @return {Response} Return PrestaShopCustomization.
	 */
    this.GetCustomizationRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCustomizationRaw", id);
        return result;
    }

	/**
	 *  Getting customizations identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopCustomization.
	 */
    this.GetCustomizationsIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCustomizationsIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting customizations by rendering options. 	
	 * @param renderingOptions For request specified information about customizations use: display and filter or sort.
	 * @return {Response} Returns only certain information about Customization in PrestaShopCustomization class.
	 */
    this.GetCustomizationsByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCustomizationsByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new delivery. 	
	 * @param delivery Body of delivery.
	 * @return {Response} If added return true.
	 */
    this.AddDeliveryRaw = function (delivery) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddDeliveryRaw", delivery);
        return result;
    }

	/**
	 *  Update information in specified delivery. 	
	 * @param delivery Body of delivery.
	 * @return {Response} Return updated PrestaShopDelivery.
	 */
    this.EditDeliveryRaw = function (delivery) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditDeliveryRaw", delivery);
        return result;
    }

	/**
	 *  Remove delivery by identifier. 	
	 * @param id Identifier of delivery.
	 * @return {Response} If removed return true.
	 */
    this.DeleteDeliveryRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteDeliveryRaw", id);
        return result;
    }

	/**
	 *  Getting delivery by identifier. 	
	 * @param id Identifier of delivery.
	 * @return {Response} Return PrestaShopDelivery.
	 */
    this.GetDeliveryRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetDeliveryRaw", id);
        return result;
    }

	/**
	 *  Getting deliveries identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopDelivery.
	 */
    this.GetDeliveriesIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetDeliveriesIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting deliveries by rendering options. 	
	 * @param renderingOptions For request specified information about deliveries use: display and filter or sort.
	 * @return {Response} Returns only certain information about Delivery in PrestaShopDelivery class.
	 */
    this.GetDeliveriesByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetDeliveriesByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new employee. 	
	 * @param employee Body of employee.
	 * @return {Response} If added return true.
	 */
    this.AddEmployeeRaw = function (employee) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddEmployeeRaw", employee);
        return result;
    }

	/**
	 *  Update information in specified employee. 	
	 * @param employee Body of employee.
	 * @return {Response} Return updated PrestaShopEmployee.
	 */
    this.EditEmployeeRaw = function (employee) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditEmployeeRaw", employee);
        return result;
    }

	/**
	 *  Remove employee by identifier. 	
	 * @param id Identifier of employee.
	 * @return {Response} If removed return true.
	 */
    this.DeleteEmployeeRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteEmployeeRaw", id);
        return result;
    }

	/**
	 *  Getting employee by identifier. 	
	 * @param id Identifier of employee.
	 * @return {Response} Return PrestaShopEmployee.
	 */
    this.GetEmployeeRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetEmployeeRaw", id);
        return result;
    }

	/**
	 *  Getting employees identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopEmployee.
	 */
    this.GetEmployeesIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetEmployeesIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting employees by rendering options. 	
	 * @param renderingOptions For request specified information about employees use: display and filter or sort.
	 * @return {Response} Returns only certain information about Employee in PrestaShopEmployee class.
	 */
    this.GetEmployeesByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetEmployeesByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new group. 	
	 * @param group Body of group.
	 * @return {Response} If added return true.
	 */
    this.AddGroupRaw = function (group) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddGroupRaw", group);
        return result;
    }

	/**
	 *  Remove tax by identifier. 	
	 * @param id Identifier of tax.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteTax = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteTax", id);
        return result;
    }

	/**
	 *  Getting tax by identifier. 	
	 * @param id Identifier of tax.
	 * @return {PrestaShopTax} Return PrestaShopTax.
	 */
    this.GetTax = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetTax", id);
        return result;
    }

	/**
	 *  Getting taxes by rendering options. 	
	 * @param renderingOptions For request specified information about taxes use: display and filter or sort.
	 * @return {PrestaShopTax[]} Returns only certain information about Tax in PrestaShopTax class.
	 */
    this.GetTaxesByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetTaxesByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting taxes identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopTax.
	 */
    this.GetTaxesIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetTaxesIdentifiers");
        return result;
    }

	/**
	 *  Adding new translated configuration. 	
	 * @param translatedConfiguration Body of translated configuration.
	 * @return {Boolean} If added return true.
	 */
    this.AddTranslatedConfiguration = function (translatedConfiguration) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddTranslatedConfiguration", translatedConfiguration);
        return result;
    }

	/**
	 *  Update information in specified translated configuration. 	
	 * @param translatedConfiguration Body of translated configuration.
	 * @return {PrestaShopTranslatedConfiguration} Return updated PrestaShopTranslatedConfiguration.
	 */
    this.EditTranslatedConfiguration = function (translatedConfiguration) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditTranslatedConfiguration", translatedConfiguration);
        return result;
    }

	/**
	 *  Remove translated configuration by identifier. 	
	 * @param id Identifier of translated configuration.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteTranslatedConfiguration = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteTranslatedConfiguration", id);
        return result;
    }

	/**
	 *  Getting translated configuration by identifier. 	
	 * @param id Identifier of translated configuration.
	 * @return {PrestaShopTranslatedConfiguration} Return PrestaShopTranslatedConfiguration.
	 */
    this.GetTranslatedConfiguration = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetTranslatedConfiguration", id);
        return result;
    }

	/**
	 *  Getting translated configurations by rendering options. 	
	 * @param renderingOptions For request specified information about translated configurations use: display and filter or sort.
	 * @return {PrestaShopTranslatedConfiguration[]} Returns only certain information about TranslatedConfiguration in PrestaShopTranslatedConfiguration class.
	 */
    this.GetTranslatedConfigurationsByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetTranslatedConfigurationsByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting translated configurations identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopTranslatedConfiguration.
	 */
    this.GetTranslatedConfigurationsIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetTranslatedConfigurationsIdentifiers");
        return result;
    }

	/**
	 *  Getting warehouse product location by identifier. 	
	 * @param id Identifier of warehouse product location.
	 * @return {PrestaShopWarehouseProductLocation} Return PrestaShopWarehouseProductLocation.
	 */
    this.GetWarehouseProductLocation = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetWarehouseProductLocation", id);
        return result;
    }

	/**
	 *  Getting warehouse product locations by rendering options. 	
	 * @param renderingOptions For request specified information about warehouse product locations use: display and filter or sort.
	 * @return {PrestaShopWarehouseProductLocation[]} Returns only certain information about WarehouseProductLocation in PrestaShopWarehouseProductLocation class.
	 */
    this.GetWarehouseProductLocationsByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetWarehouseProductLocationsByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting warehouse product locations identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopWarehouseProductLocation.
	 */
    this.GetWarehouseProductLocationsIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetWarehouseProductLocationsIdentifiers");
        return result;
    }

	/**
	 *  Adding new weight range. 	
	 * @param weightRange Body of weight range.
	 * @return {Boolean} If added return true.
	 */
    this.AddWeightRange = function (weightRange) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddWeightRange", weightRange);
        return result;
    }

	/**
	 *  Update information in specified weight range. 	
	 * @param weightRange Body of weight range.
	 * @return {PrestaShopWeightRange} Return updated PrestaShopWeightRange.
	 */
    this.EditWeightRange = function (weightRange) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditWeightRange", weightRange);
        return result;
    }

	/**
	 *  Remove weight range by identifier. 	
	 * @param id Identifier of weight range.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteWeightRange = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteWeightRange", id);
        return result;
    }

	/**
	 *  Getting weight range by identifier. 	
	 * @param id Identifier of weight range.
	 * @return {PrestaShopWeightRange} Return PrestaShopWeightRange.
	 */
    this.GetWeightRange = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetWeightRange", id);
        return result;
    }

	/**
	 *  Getting weight ranges by rendering options. 	
	 * @param renderingOptions For request specified information about weight ranges use: display and filter or sort.
	 * @return {PrestaShopWeightRange[]} Returns only certain information about WeightRange in PrestaShopWeightRange class.
	 */
    this.GetWeightRangesByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetWeightRangesByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting weight ranges identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopWeightRange.
	 */
    this.GetWeightRangesIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetWeightRangesIdentifiers");
        return result;
    }

	/**
	 *  Adding new zone. 	
	 * @param zone Body of zone.
	 * @return {Boolean} If added return true.
	 */
    this.AddZone = function (zone) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddZone", zone);
        return result;
    }

	/**
	 *  Update information in specified zone. 	
	 * @param zone Body of zone.
	 * @return {PrestaShopZone} Return updated PrestaShopZone.
	 */
    this.EditZone = function (zone) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditZone", zone);
        return result;
    }

	/**
	 *  Remove zone by identifier. 	
	 * @param id Identifier of zone.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteZone = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteZone", id);
        return result;
    }

	/**
	 *  Getting zone by identifier. 	
	 * @param id Identifier of zone.
	 * @return {PrestaShopZone} Return PrestaShopZone.
	 */
    this.GetZone = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetZone", id);
        return result;
    }

	/**
	 *  Getting zones by rendering options. 	
	 * @param renderingOptions For request specified information about zones use: display and filter or sort.
	 * @return {PrestaShopZone[]} Returns only certain information about Zone in PrestaShopZone class.
	 */
    this.GetZonesByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetZonesByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting zones identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopZone.
	 */
    this.GetZonesIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetZonesIdentifiers");
        return result;
    }

	/**
	 *  Adding new address. 	
	 * @param address Body of address.
	 * @return {Response} If added return true.
	 */
    this.AddAddressRaw = function (address) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddAddressRaw", address);
        return result;
    }

	/**
	 *  Update information in specified address. 	
	 * @param address Body of address.
	 * @return {Response} Return updated PrestaShopAddress.
	 */
    this.EditAddressRaw = function (address) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditAddressRaw", address);
        return result;
    }

	/**
	 *  Remove address by identifier. 	
	 * @param id Identifier of address.
	 * @return {Response} If removed return true.
	 */
    this.DeleteAddressRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteAddressRaw", id);
        return result;
    }

	/**
	 *  Getting address by identifier. 	
	 * @param id Identifier of address.
	 * @return {Response} Return PrestaShopAddress.
	 */
    this.GetAddressRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetAddressRaw", id);
        return result;
    }

	/**
	 *  Getting addresses identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopAddress.
	 */
    this.GetAddressesIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetAddressesIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting addresses by rendering options. 	
	 * @param renderingOptions For request specified information about addresses use: display and filter or sort.
	 * @return {Response} Returns only certain information about Address in PrestaShopAddress class.
	 */
    this.GetAddressesByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetAddressesByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new carrier. 	
	 * @param carrier Body of carrier.
	 * @return {Response} If added return true.
	 */
    this.AddCarrierRaw = function (carrier) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddCarrierRaw", carrier);
        return result;
    }

	/**
	 *  Update information in specified carrier. 	
	 * @param carrier Body of carrier.
	 * @return {Response} Return updated PrestaShopCarrier.
	 */
    this.EditCarrierRaw = function (carrier) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditCarrierRaw", carrier);
        return result;
    }

	/**
	 *  Remove carrier by identifier. 	
	 * @param id Identifier of carrier.
	 * @return {Response} If removed return true.
	 */
    this.DeleteCarrierRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteCarrierRaw", id);
        return result;
    }

	/**
	 *  Getting carrier by identifier. 	
	 * @param id Identifier of carrier.
	 * @return {Response} Return PrestaShopCarrier.
	 */
    this.GetCarrierRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCarrierRaw", id);
        return result;
    }

	/**
	 *  Getting carriers identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopCarrier.
	 */
    this.GetCarriersIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCarriersIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting carriers by rendering options. 	
	 * @param renderingOptions For request specified information about carriers use: display and filter or sort.
	 * @return {Response} Returns only certain information about Carrier in PrestaShopCarrier class.
	 */
    this.GetCarriersByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCarriersByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new cart rule. 	
	 * @param cartRule Body of cart rule.
	 * @return {Response} If added return true.
	 */
    this.AddCartRuleRaw = function (cartRule) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddCartRuleRaw", cartRule);
        return result;
    }

	/**
	 *  Update information in specified cart rule. 	
	 * @param cartRule Body of cart rule.
	 * @return {Response} Return updated PrestaShopCartRule.
	 */
    this.EditCartRuleRaw = function (cartRule) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditCartRuleRaw", cartRule);
        return result;
    }

	/**
	 *  Remove cart rule by identifier. 	
	 * @param id Identifier of cart rule.
	 * @return {Response} If removed return true.
	 */
    this.DeleteCartRuleRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteCartRuleRaw", id);
        return result;
    }

	/**
	 *  Getting cart rule by identifier. 	
	 * @param id Identifier of cart rule.
	 * @return {Response} Return PrestaShopCartRule.
	 */
    this.GetCartRuleRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCartRuleRaw", id);
        return result;
    }

	/**
	 *  Getting cart rules identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopCartRule.
	 */
    this.GetCartRulesIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCartRulesIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting cart rules by rendering options. 	
	 * @param renderingOptions For request specified information about cart rules use: display and filter or sort.
	 * @return {Response} Returns only certain information about CartRule in PrestaShopCartRule class.
	 */
    this.GetCartRulesByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCartRulesByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new cart. 	
	 * @param cart Body of cart.
	 * @return {Response} If added return true.
	 */
    this.AddCartRaw = function (cart) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddCartRaw", cart);
        return result;
    }

	/**
	 *  Update information in specified cart. 	
	 * @param cart Body of cart.
	 * @return {Response} Return updated PrestaShopCart.
	 */
    this.EditCartRaw = function (cart) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditCartRaw", cart);
        return result;
    }

	/**
	 *  Remove cart by identifier. 	
	 * @param id Identifier of cart.
	 * @return {Response} If removed return true.
	 */
    this.DeleteCartRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteCartRaw", id);
        return result;
    }

	/**
	 *  Getting cart by identifier. 	
	 * @param id Identifier of cart.
	 * @return {Response} Return PrestaShopCart.
	 */
    this.GetCartRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCartRaw", id);
        return result;
    }

	/**
	 *  Getting carts identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopCart.
	 */
    this.GetCartsIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCartsIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting carts by rendering options. 	
	 * @param renderingOptions For request specified information about carts use: display and filter or sort.
	 * @return {Response} Returns only certain information about Cart in PrestaShopCart class.
	 */
    this.GetCartsByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCartsByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new category. 	
	 * @param category Body of category.
	 * @return {Response} If added return true.
	 */
    this.AddCategoryRaw = function (category) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddCategoryRaw", category);
        return result;
    }

	/**
	 *  Update information in specified category. 	
	 * @param category Body of category.
	 * @return {Response} Return updated PrestaShopCategory.
	 */
    this.EditCategoryRaw = function (category) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditCategoryRaw", category);
        return result;
    }

	/**
	 *  Remove category by identifier. 	
	 * @param id Identifier of category.
	 * @return {Response} If removed return true.
	 */
    this.DeleteCategoryRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteCategoryRaw", id);
        return result;
    }

	/**
	 *  Getting category by identifier. 	
	 * @param id Identifier of category.
	 * @return {Response} Return PrestaShopCategory.
	 */
    this.GetCategoryRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCategoryRaw", id);
        return result;
    }

	/**
	 *  Getting categories identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopCategory.
	 */
    this.GetCategoriesIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCategoriesIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting categories by rendering options. 	
	 * @param renderingOptions For request specified information about categories use: display and filter or sort.
	 * @return {Response} Returns only certain information about Category in PrestaShopCategory class.
	 */
    this.GetCategoriesByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCategoriesByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new combination. 	
	 * @param combination Body of combination.
	 * @return {Response} If added return true.
	 */
    this.AddCombinationRaw = function (combination) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddCombinationRaw", combination);
        return result;
    }

	/**
	 *  Update information in specified combination. 	
	 * @param combination Body of combination.
	 * @return {Response} Return updated PrestaShopCombination.
	 */
    this.EditCombinationRaw = function (combination) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditCombinationRaw", combination);
        return result;
    }

	/**
	 *  Remove combination by identifier. 	
	 * @param id Identifier of combination.
	 * @return {Response} If removed return true.
	 */
    this.DeleteCombinationRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteCombinationRaw", id);
        return result;
    }

	/**
	 *  Getting combination by identifier. 	
	 * @param id Identifier of combination.
	 * @return {Response} Return PrestaShopCombination.
	 */
    this.GetCombinationRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCombinationRaw", id);
        return result;
    }

	/**
	 *  Getting combinations identifiers. 	
	 * @return {Response} Return identifiers of PrestaShopCombination.
	 */
    this.GetCombinationsIdentifiersRaw = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCombinationsIdentifiersRaw");
        return result;
    }

	/**
	 *  Getting combinations by rendering options. 	
	 * @param renderingOptions For request specified information about combinations use: display and filter or sort.
	 * @return {Response} Returns only certain information about Combination in PrestaShopCombination class.
	 */
    this.GetCombinationsByRenderingOptionsRaw = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCombinationsByRenderingOptionsRaw", renderingOptions);
        return result;
    }

	/**
	 *  Adding new configuration. 	
	 * @param configuration Body of configuration.
	 * @return {Response} If added return true.
	 */
    this.AddConfigurationRaw = function (configuration) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddConfigurationRaw", configuration);
        return result;
    }

	/**
	 *  Update information in specified configuration. 	
	 * @param configuration Body of configuration.
	 * @return {Response} Return updated PrestaShopConfiguration.
	 */
    this.EditConfigurationRaw = function (configuration) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditConfigurationRaw", configuration);
        return result;
    }

	/**
	 *  Remove configuration by identifier. 	
	 * @param id Identifier of configuration.
	 * @return {Response} If removed return true.
	 */
    this.DeleteConfigurationRaw = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteConfigurationRaw", id);
        return result;
    }

	/**
	 *  Getting specific prices by rendering options. 	
	 * @param renderingOptions For request specified information about specific prices use: display and filter or sort.
	 * @return {PrestaShopSpecificPrice[]} Returns only certain information about SpecificPrice in PrestaShopSpecificPrice class.
	 */
    this.GetSpecificPricesByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSpecificPricesByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting specific prices identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopSpecificPrice.
	 */
    this.GetSpecificPricesIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSpecificPricesIdentifiers");
        return result;
    }

	/**
	 *  Getting state by identifier. 	
	 * @param id Identifier of state.
	 * @return {PrestaShopState} Return PrestaShopState.
	 */
    this.GetState = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetState", id);
        return result;
    }

	/**
	 *  Getting states by rendering options. 	
	 * @param renderingOptions For request specified information about states use: display and filter or sort.
	 * @return {PrestaShopState[]} Returns only certain information about State in PrestaShopState class.
	 */
    this.GetStatesByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetStatesByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting states identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopState.
	 */
    this.GetStatesIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetStatesIdentifiers");
        return result;
    }

	/**
	 *  Adding new stock movement reason. 	
	 * @param stockMovementReason Body of stock movement reason.
	 * @return {Boolean} If added return true.
	 */
    this.AddStockMovementReason = function (stockMovementReason) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddStockMovementReason", stockMovementReason);
        return result;
    }

	/**
	 *  Update information in specified stock movement reason. 	
	 * @param stockMovementReason Body of stock movement reason.
	 * @return {PrestaShopStockMovementReason} Return updated PrestaShopStockMovementReason.
	 */
    this.EditStockMovementReason = function (stockMovementReason) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditStockMovementReason", stockMovementReason);
        return result;
    }

	/**
	 *  Remove stock movement reason by identifier. 	
	 * @param id Identifier of stock movement reason.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteStockMovementReason = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteStockMovementReason", id);
        return result;
    }

	/**
	 *  Getting stock movement reason by identifier. 	
	 * @param id Identifier of stock movement reason.
	 * @return {PrestaShopStockMovementReason} Return PrestaShopStockMovementReason.
	 */
    this.GetStockMovementReason = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetStockMovementReason", id);
        return result;
    }

	/**
	 *  Getting stock movement reasons by rendering options. 	
	 * @param renderingOptions For request specified information about stock movement reasons use: display and filter or sort.
	 * @return {PrestaShopStockMovementReason[]} Returns only certain information about StockMovementReason in PrestaShopStockMovementReason class.
	 */
    this.GetStockMovementReasonsByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetStockMovementReasonsByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting stock movement reasons identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopStockMovementReason.
	 */
    this.GetStockMovementReasonsIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetStockMovementReasonsIdentifiers");
        return result;
    }

	/**
	 *  Getting stock movement by identifier. 	
	 * @param id Identifier of stock movement.
	 * @return {PrestaShopStockMovement} Return PrestaShopStockMovement.
	 */
    this.GetStockMovement = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetStockMovement", id);
        return result;
    }

	/**
	 *  Getting stock movements by rendering options. 	
	 * @param renderingOptions For request specified information about stock movements use: display and filter or sort.
	 * @return {PrestaShopStockMovement[]} Returns only certain information about StockMovement in PrestaShopStockMovement class.
	 */
    this.GetStockMovementsByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetStockMovementsByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting stock movements identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopStockMovement.
	 */
    this.GetStockMovementsIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetStockMovementsIdentifiers");
        return result;
    }

	/**
	 *  Getting stock by identifier. 	
	 * @param id Identifier of stock.
	 * @return {PrestaShopStock} Return PrestaShopStock.
	 */
    this.GetStock = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetStock", id);
        return result;
    }

	/**
	 *  Getting stocks by rendering options. 	
	 * @param renderingOptions For request specified information about stocks use: display and filter or sort.
	 * @return {PrestaShopStock[]} Returns only certain information about Stock in PrestaShopStock class.
	 */
    this.GetStocksByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetStocksByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting stocks identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopStock.
	 */
    this.GetStocksIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetStocksIdentifiers");
        return result;
    }

	/**
	 *  Adding new store. 	
	 * @param store Body of store.
	 * @return {Boolean} If added return true.
	 */
    this.AddStore = function (store) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddStore", store);
        return result;
    }

	/**
	 *  Update information in specified store. 	
	 * @param store Body of store.
	 * @return {PrestaShopStore} Return updated PrestaShopStore.
	 */
    this.EditStore = function (store) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditStore", store);
        return result;
    }

	/**
	 *  Remove store by identifier. 	
	 * @param id Identifier of store.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteStore = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteStore", id);
        return result;
    }

	/**
	 *  Getting store by identifier. 	
	 * @param id Identifier of store.
	 * @return {PrestaShopStore} Return PrestaShopStore.
	 */
    this.GetStore = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetStore", id);
        return result;
    }

	/**
	 *  Getting stores by rendering options. 	
	 * @param renderingOptions For request specified information about stores use: display and filter or sort.
	 * @return {PrestaShopStore[]} Returns only certain information about Store in PrestaShopStore class.
	 */
    this.GetStoresByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetStoresByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting stores identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopStore.
	 */
    this.GetStoresIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetStoresIdentifiers");
        return result;
    }

	/**
	 *  Adding new supplier. 	
	 * @param supplier Body of supplier.
	 * @return {Boolean} If added return true.
	 */
    this.AddSupplier = function (supplier) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddSupplier", supplier);
        return result;
    }

	/**
	 *  Update information in specified supplier. 	
	 * @param supplier Body of supplier.
	 * @return {PrestaShopSupplier} Return updated PrestaShopSupplier.
	 */
    this.EditSupplier = function (supplier) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditSupplier", supplier);
        return result;
    }

	/**
	 *  Remove supplier by identifier. 	
	 * @param id Identifier of supplier.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteSupplier = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteSupplier", id);
        return result;
    }

	/**
	 *  Getting supplier by identifier. 	
	 * @param id Identifier of supplier.
	 * @return {PrestaShopSupplier} Return PrestaShopSupplier.
	 */
    this.GetSupplier = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplier", id);
        return result;
    }

	/**
	 *  Getting suppliers by rendering options. 	
	 * @param renderingOptions For request specified information about suppliers use: display and filter or sort.
	 * @return {PrestaShopSupplier[]} Returns only certain information about Supplier in PrestaShopSupplier class.
	 */
    this.GetSuppliersByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSuppliersByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting suppliers identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopSupplier.
	 */
    this.GetSuppliersIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSuppliersIdentifiers");
        return result;
    }

	/**
	 *  Getting supply order detail by identifier. 	
	 * @param id Identifier of supply order detail.
	 * @return {PrestaShopSupplyOrderDetail} Return PrestaShopSupplyOrderDetail.
	 */
    this.GetSupplyOrderDetail = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplyOrderDetail", id);
        return result;
    }

	/**
	 *  Getting supply order details by rendering options. 	
	 * @param renderingOptions For request specified information about supply order details use: display and filter or sort.
	 * @return {PrestaShopSupplyOrderDetail[]} Returns only certain information about SupplyOrderDetail in PrestaShopSupplyOrderDetail class.
	 */
    this.GetSupplyOrderDetailsByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplyOrderDetailsByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting supply order details identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopSupplyOrderDetail.
	 */
    this.GetSupplyOrderDetailsIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplyOrderDetailsIdentifiers");
        return result;
    }

	/**
	 *  Getting supply order history by identifier. 	
	 * @param id Identifier of supply order history.
	 * @return {PrestaShopSupplyOrderHistory} Return PrestaShopSupplyOrderHistory.
	 */
    this.GetSupplyOrderHistory = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplyOrderHistory", id);
        return result;
    }

	/**
	 *  Getting supply order histories by rendering options. 	
	 * @param renderingOptions For request specified information about supply order histories use: display and filter or sort.
	 * @return {PrestaShopSupplyOrderHistory[]} Returns only certain information about SupplyOrderHistory in PrestaShopSupplyOrderHistory class.
	 */
    this.GetSupplyOrderHistoriesByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplyOrderHistoriesByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting supply order histories identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopSupplyOrderHistory.
	 */
    this.GetSupplyOrderHistoriesIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplyOrderHistoriesIdentifiers");
        return result;
    }

	/**
	 *  Getting supply order receipt history by identifier. 	
	 * @param id Identifier of supply order receipt history.
	 * @return {PrestaShopSupplyOrderReceiptHistory} Return PrestaShopSupplyOrderReceiptHistory.
	 */
    this.GetSupplyOrderReceiptHistory = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplyOrderReceiptHistory", id);
        return result;
    }

	/**
	 *  Getting supply order receipt histories by rendering options. 	
	 * @param renderingOptions For request specified information about supply order receipt histories use: display and filter or sort.
	 * @return {PrestaShopSupplyOrderReceiptHistory[]} Returns only certain information about SupplyOrderReceiptHistory in PrestaShopSupplyOrderReceiptHistory class.
	 */
    this.GetSupplyOrderReceiptHistoriesByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplyOrderReceiptHistoriesByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting supply order receipt histories identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopSupplyOrderReceiptHistory.
	 */
    this.GetSupplyOrderReceiptHistoriesIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplyOrderReceiptHistoriesIdentifiers");
        return result;
    }

	/**
	 *  Getting supply order state by identifier. 	
	 * @param id Identifier of supply order state.
	 * @return {PrestaShopSupplyOrderState} Return PrestaShopSupplyOrderState.
	 */
    this.GetSupplyOrderState = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplyOrderState", id);
        return result;
    }

	/**
	 *  Getting supply order states by rendering options. 	
	 * @param renderingOptions For request specified information about supply order states use: display and filter or sort.
	 * @return {PrestaShopSupplyOrderState[]} Returns only certain information about SupplyOrderState in PrestaShopSupplyOrderState class.
	 */
    this.GetSupplyOrderStatesByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplyOrderStatesByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting supply order states identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopSupplyOrderState.
	 */
    this.GetSupplyOrderStatesIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplyOrderStatesIdentifiers");
        return result;
    }

	/**
	 *  Getting supply order by identifier. 	
	 * @param id Identifier of supply order.
	 * @return {PrestaShopSupplyOrder} Return PrestaShopSupplyOrder.
	 */
    this.GetSupplyOrder = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplyOrder", id);
        return result;
    }

	/**
	 *  Getting supply orders by rendering options. 	
	 * @param renderingOptions For request specified information about supply orders use: display and filter or sort.
	 * @return {PrestaShopSupplyOrder[]} Returns only certain information about SupplyOrder in PrestaShopSupplyOrder class.
	 */
    this.GetSupplyOrdersByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplyOrdersByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting supply orders identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopSupplyOrder.
	 */
    this.GetSupplyOrdersIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSupplyOrdersIdentifiers");
        return result;
    }

	/**
	 *  Adding new tag. 	
	 * @param tag Body of tag.
	 * @return {Boolean} If added return true.
	 */
    this.AddTag = function (tag) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddTag", tag);
        return result;
    }

	/**
	 *  Update information in specified tag. 	
	 * @param tag Body of tag.
	 * @return {PrestaShopTag} Return updated PrestaShopTag.
	 */
    this.EditTag = function (tag) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditTag", tag);
        return result;
    }

	/**
	 *  Remove tag by identifier. 	
	 * @param id Identifier of tag.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteTag = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteTag", id);
        return result;
    }

	/**
	 *  Getting tag by identifier. 	
	 * @param id Identifier of tag.
	 * @return {PrestaShopTag} Return PrestaShopTag.
	 */
    this.GetTag = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetTag", id);
        return result;
    }

	/**
	 *  Getting tags by rendering options. 	
	 * @param renderingOptions For request specified information about tags use: display and filter or sort.
	 * @return {PrestaShopTag[]} Returns only certain information about Tag in PrestaShopTag class.
	 */
    this.GetTagsByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetTagsByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting tags identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopTag.
	 */
    this.GetTagsIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetTagsIdentifiers");
        return result;
    }

	/**
	 *  Adding new tax rule group. 	
	 * @param taxRuleGroup Body of tax rule group.
	 * @return {Boolean} If added return true.
	 */
    this.AddTaxRuleGroup = function (taxRuleGroup) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddTaxRuleGroup", taxRuleGroup);
        return result;
    }

	/**
	 *  Update information in specified tax rule group. 	
	 * @param taxRuleGroup Body of tax rule group.
	 * @return {PrestaShopTaxRuleGroup} Return updated PrestaShopTaxRuleGroup.
	 */
    this.EditTaxRuleGroup = function (taxRuleGroup) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditTaxRuleGroup", taxRuleGroup);
        return result;
    }

	/**
	 *  Remove tax rule group by identifier. 	
	 * @param id Identifier of tax rule group.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteTaxRuleGroup = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteTaxRuleGroup", id);
        return result;
    }

	/**
	 *  Getting tax rule group by identifier. 	
	 * @param id Identifier of tax rule group.
	 * @return {PrestaShopTaxRuleGroup} Return PrestaShopTaxRuleGroup.
	 */
    this.GetTaxRuleGroup = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetTaxRuleGroup", id);
        return result;
    }

	/**
	 *  Getting tax rule groups by rendering options. 	
	 * @param renderingOptions For request specified information about tax rule groups use: display and filter or sort.
	 * @return {PrestaShopTaxRuleGroup[]} Returns only certain information about TaxRuleGroup in PrestaShopTaxRuleGroup class.
	 */
    this.GetTaxRuleGroupsByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetTaxRuleGroupsByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting tax rule groups identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopTaxRuleGroup.
	 */
    this.GetTaxRuleGroupsIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetTaxRuleGroupsIdentifiers");
        return result;
    }

	/**
	 *  Adding new tax rule. 	
	 * @param taxRule Body of tax rule.
	 * @return {Boolean} If added return true.
	 */
    this.AddTaxRule = function (taxRule) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddTaxRule", taxRule);
        return result;
    }

	/**
	 *  Update information in specified tax rule. 	
	 * @param taxRule Body of tax rule.
	 * @return {PrestaShopTaxRule} Return updated PrestaShopTaxRule.
	 */
    this.EditTaxRule = function (taxRule) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditTaxRule", taxRule);
        return result;
    }

	/**
	 *  Remove tax rule by identifier. 	
	 * @param id Identifier of tax rule.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteTaxRule = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteTaxRule", id);
        return result;
    }

	/**
	 *  Getting tax rule by identifier. 	
	 * @param id Identifier of tax rule.
	 * @return {PrestaShopTaxRule} Return PrestaShopTaxRule.
	 */
    this.GetTaxRule = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetTaxRule", id);
        return result;
    }

	/**
	 *  Getting tax rules by rendering options. 	
	 * @param renderingOptions For request specified information about tax rules use: display and filter or sort.
	 * @return {PrestaShopTaxRule[]} Returns only certain information about TaxRule in PrestaShopTaxRule class.
	 */
    this.GetTaxRulesByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetTaxRulesByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting tax rules identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopTaxRule.
	 */
    this.GetTaxRulesIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetTaxRulesIdentifiers");
        return result;
    }

	/**
	 *  Adding new tax. 	
	 * @param tax Body of tax.
	 * @return {Boolean} If added return true.
	 */
    this.AddTax = function (tax) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddTax", tax);
        return result;
    }

	/**
	 *  Update information in specified tax. 	
	 * @param tax Body of tax.
	 * @return {PrestaShopTax} Return updated PrestaShopTax.
	 */
    this.EditTax = function (tax) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditTax", tax);
        return result;
    }

	/**
	 *  Adding new product feature value. 	
	 * @param productFeatureValue Body of product feature value.
	 * @return {Boolean} If added return true.
	 */
    this.AddProductFeatureValue = function (productFeatureValue) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddProductFeatureValue", productFeatureValue);
        return result;
    }

	/**
	 *  Update information in specified product feature value. 	
	 * @param productFeatureValue Body of product feature value.
	 * @return {PrestaShopProductFeatureValue} Return updated PrestaShopProductFeatureValue.
	 */
    this.EditProductFeatureValue = function (productFeatureValue) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditProductFeatureValue", productFeatureValue);
        return result;
    }

	/**
	 *  Remove product feature value by identifier. 	
	 * @param id Identifier of product feature value.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteProductFeatureValue = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteProductFeatureValue", id);
        return result;
    }

	/**
	 *  Getting product feature value by identifier. 	
	 * @param id Identifier of product feature value.
	 * @return {PrestaShopProductFeatureValue} Return PrestaShopProductFeatureValue.
	 */
    this.GetProductFeatureValue = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductFeatureValue", id);
        return result;
    }

	/**
	 *  Getting product feature values by rendering options. 	
	 * @param renderingOptions For request specified information about product feature values use: display and filter or sort.
	 * @return {PrestaShopProductFeatureValue[]} Returns only certain information about ProductFeatureValue in PrestaShopProductFeatureValue class.
	 */
    this.GetProductFeatureValuesByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductFeatureValuesByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting product feature values identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopProductFeatureValue.
	 */
    this.GetProductFeatureValuesIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductFeatureValuesIdentifiers");
        return result;
    }

	/**
	 *  Adding new product feature. 	
	 * @param productFeature Body of product feature.
	 * @return {Boolean} If added return true.
	 */
    this.AddProductFeature = function (productFeature) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddProductFeature", productFeature);
        return result;
    }

	/**
	 *  Update information in specified product feature. 	
	 * @param productFeature Body of product feature.
	 * @return {PrestaShopProductFeature} Return updated PrestaShopProductFeature.
	 */
    this.EditProductFeature = function (productFeature) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditProductFeature", productFeature);
        return result;
    }

	/**
	 *  Remove product feature by identifier. 	
	 * @param id Identifier of product feature.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteProductFeature = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteProductFeature", id);
        return result;
    }

	/**
	 *  Getting product feature by identifier. 	
	 * @param id Identifier of product feature.
	 * @return {PrestaShopProductFeature} Return PrestaShopProductFeature.
	 */
    this.GetProductFeature = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductFeature", id);
        return result;
    }

	/**
	 *  Getting product features by rendering options. 	
	 * @param renderingOptions For request specified information about product features use: display and filter or sort.
	 * @return {PrestaShopProductFeature[]} Returns only certain information about ProductFeature in PrestaShopProductFeature class.
	 */
    this.GetProductFeaturesByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductFeaturesByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting product features identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopProductFeature.
	 */
    this.GetProductFeaturesIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductFeaturesIdentifiers");
        return result;
    }

	/**
	 *  Adding new product option value. 	
	 * @param productOptionValue Body of product option value.
	 * @return {Boolean} If added return true.
	 */
    this.AddProductOptionValue = function (productOptionValue) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddProductOptionValue", productOptionValue);
        return result;
    }

	/**
	 *  Update information in specified product option value. 	
	 * @param productOptionValue Body of product option value.
	 * @return {PrestaShopProductOptionValue} Return updated PrestaShopProductOptionValue.
	 */
    this.EditProductOptionValue = function (productOptionValue) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditProductOptionValue", productOptionValue);
        return result;
    }

	/**
	 *  Remove product option value by identifier. 	
	 * @param id Identifier of product option value.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteProductOptionValue = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteProductOptionValue", id);
        return result;
    }

	/**
	 *  Getting product option value by identifier. 	
	 * @param id Identifier of product option value.
	 * @return {PrestaShopProductOptionValue} Return PrestaShopProductOptionValue.
	 */
    this.GetProductOptionValue = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductOptionValue", id);
        return result;
    }

	/**
	 *  Getting product option values by rendering options. 	
	 * @param renderingOptions For request specified information about product option values use: display and filter or sort.
	 * @return {PrestaShopProductOptionValue[]} Returns only certain information about ProductOptionValue in PrestaShopProductOptionValue class.
	 */
    this.GetProductOptionValuesByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductOptionValuesByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting product option values identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopProductOptionValue.
	 */
    this.GetProductOptionValuesIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductOptionValuesIdentifiers");
        return result;
    }

	/**
	 *  Adding new product option. 	
	 * @param productOption Body of product option.
	 * @return {Boolean} If added return true.
	 */
    this.AddProductOption = function (productOption) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddProductOption", productOption);
        return result;
    }

	/**
	 *  Update information in specified product option. 	
	 * @param productOption Body of product option.
	 * @return {PrestaShopProductOption} Return updated PrestaShopProductOption.
	 */
    this.EditProductOption = function (productOption) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditProductOption", productOption);
        return result;
    }

	/**
	 *  Remove product option by identifier. 	
	 * @param id Identifier of product option.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteProductOption = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteProductOption", id);
        return result;
    }

	/**
	 *  Getting product option by identifier. 	
	 * @param id Identifier of product option.
	 * @return {PrestaShopProductOption} Return PrestaShopProductOption.
	 */
    this.GetProductOption = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductOption", id);
        return result;
    }

	/**
	 *  Getting product options by rendering options. 	
	 * @param renderingOptions For request specified information about product options use: display and filter or sort.
	 * @return {PrestaShopProductOption[]} Returns only certain information about ProductOption in PrestaShopProductOption class.
	 */
    this.GetProductOptionsByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductOptionsByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting product options identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopProductOption.
	 */
    this.GetProductOptionsIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductOptionsIdentifiers");
        return result;
    }

	/**
	 *  Adding new product supplier. 	
	 * @param productSupplier Body of product supplier.
	 * @return {Boolean} If added return true.
	 */
    this.AddProductSupplier = function (productSupplier) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddProductSupplier", productSupplier);
        return result;
    }

	/**
	 *  Update information in specified product supplier. 	
	 * @param productSupplier Body of product supplier.
	 * @return {PrestaShopProductSupplier} Return updated PrestaShopProductSupplier.
	 */
    this.EditProductSupplier = function (productSupplier) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditProductSupplier", productSupplier);
        return result;
    }

	/**
	 *  Remove product supplier by identifier. 	
	 * @param id Identifier of product supplier.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteProductSupplier = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteProductSupplier", id);
        return result;
    }

	/**
	 *  Getting product supplier by identifier. 	
	 * @param id Identifier of product supplier.
	 * @return {PrestaShopProductSupplier} Return PrestaShopProductSupplier.
	 */
    this.GetProductSupplier = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductSupplier", id);
        return result;
    }

	/**
	 *  Getting product suppliers by rendering options. 	
	 * @param renderingOptions For request specified information about product suppliers use: display and filter or sort.
	 * @return {PrestaShopProductSupplier[]} Returns only certain information about ProductSupplier in PrestaShopProductSupplier class.
	 */
    this.GetProductSuppliersByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductSuppliersByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting product suppliers identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopProductSupplier.
	 */
    this.GetProductSuppliersIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductSuppliersIdentifiers");
        return result;
    }

	/**
	 *  Adding new product supplier. 	
	 * @param product Body of product supplier.
	 * @return {Boolean} If added return true.
	 */
    this.AddProduct = function (product) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddProduct", product);
        return result;
    }

	/**
	 *  Update information in specified product supplier. 	
	 * @param product Body of product supplier.
	 * @return {PrestaShopProduct} Return updated PrestaShopProduct.
	 */
    this.EditProduct = function (product) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditProduct", product);
        return result;
    }

	/**
	 *  Remove product by identifier. 	
	 * @param id Identifier of product.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteProduct = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteProduct", id);
        return result;
    }

	/**
	 *  Getting product by identifier. 	
	 * @param id Identifier of product.
	 * @return {PrestaShopProduct} Return PrestaShopProduct.
	 */
    this.GetProduct = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProduct", id);
        return result;
    }

	/**
	 *  Getting products by rendering options. 	
	 * @param renderingOptions For request specified information about products use: display and filter or sort.
	 * @return {PrestaShopProduct[]} Returns only certain information about Product in PrestaShopProduct class.
	 */
    this.GetProductsByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductsByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting products identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopProduct.
	 */
    this.GetProductsIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductsIdentifiers");
        return result;
    }

	/**
	 *  Adding new shop group. 	
	 * @param shopGroup Body of shop group.
	 * @return {Boolean} If added return true.
	 */
    this.AddShopGroup = function (shopGroup) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddShopGroup", shopGroup);
        return result;
    }

	/**
	 *  Update information in specified shop group. 	
	 * @param shopGroup Body of shop group.
	 * @return {PrestaShopShopGroup} Return updated PrestaShopShopGroup.
	 */
    this.EditShopGroup = function (shopGroup) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditShopGroup", shopGroup);
        return result;
    }

	/**
	 *  Remove shop group by identifier. 	
	 * @param id Identifier of shop group.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteShopGroup = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteShopGroup", id);
        return result;
    }

	/**
	 *  Getting shop group by identifier. 	
	 * @param id Identifier of shop group.
	 * @return {PrestaShopShopGroup} Return PrestaShopShopGroup.
	 */
    this.GetShopGroup = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetShopGroup", id);
        return result;
    }

	/**
	 *  Getting shop groups by rendering options. 	
	 * @param renderingOptions For request specified information about shop groups use: display and filter or sort.
	 * @return {PrestaShopShopGroup[]} Returns only certain information about ShopGroup in PrestaShopShopGroup class.
	 */
    this.GetShopGroupsByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetShopGroupsByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting shop groups identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopShopGroup.
	 */
    this.GetShopGroupsIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetShopGroupsIdentifiers");
        return result;
    }

	/**
	 *  Adding new shop url. 	
	 * @param shopUrl Body of shop url.
	 * @return {Boolean} If added return true.
	 */
    this.AddShopUrl = function (shopUrl) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddShopUrl", shopUrl);
        return result;
    }

	/**
	 *  Update information in specified shop url. 	
	 * @param shopUrl Body of shop url.
	 * @return {PrestaShopShopUrl} Return updated PrestaShopShopUrl.
	 */
    this.EditShopUrl = function (shopUrl) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditShopUrl", shopUrl);
        return result;
    }

	/**
	 *  Remove shop url by identifier. 	
	 * @param id Identifier of shop url.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteShopUrl = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteShopUrl", id);
        return result;
    }

	/**
	 *  Getting shop url by identifier. 	
	 * @param id Identifier of shop url.
	 * @return {PrestaShopShopUrl} Return PrestaShopShopUrl.
	 */
    this.GetShopUrl = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetShopUrl", id);
        return result;
    }

	/**
	 *  Getting shop urls by rendering options. 	
	 * @param renderingOptions For request specified information about shop urls use: display and filter or sort.
	 * @return {PrestaShopShopUrl[]} Returns only certain information about ShopUrl in PrestaShopShopUrl class.
	 */
    this.GetShopUrlsByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetShopUrlsByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting shop urls identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopShopUrl.
	 */
    this.GetShopUrlsIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetShopUrlsIdentifiers");
        return result;
    }

	/**
	 *  Adding new shop. 	
	 * @param shop Body of shop.
	 * @return {Boolean} If added return true.
	 */
    this.AddShop = function (shop) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddShop", shop);
        return result;
    }

	/**
	 *  Update information in specified shop. 	
	 * @param shop Body of shop.
	 * @return {PrestaShopShop} Return updated PrestaShopShop.
	 */
    this.EditShop = function (shop) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditShop", shop);
        return result;
    }

	/**
	 *  Remove shop by identifier. 	
	 * @param id Identifier of shop.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteShop = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteShop", id);
        return result;
    }

	/**
	 *  Getting shop by identifier. 	
	 * @param id Identifier of shop.
	 * @return {PrestaShopShop} Return PrestaShopShop.
	 */
    this.GetShop = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetShop", id);
        return result;
    }

	/**
	 *  Getting shops by rendering options. 	
	 * @param renderingOptions For request specified information about shops use: display and filter or sort.
	 * @return {PrestaShopShop[]} Returns only certain information about Shop in PrestaShopShop class.
	 */
    this.GetShopsByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetShopsByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting shops identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopShop.
	 */
    this.GetShopsIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetShopsIdentifiers");
        return result;
    }

	/**
	 *  Adding new specific price rule. 	
	 * @param specificPriceRule Body of specific price rule.
	 * @return {Boolean} If added return true.
	 */
    this.AddSpecificPriceRule = function (specificPriceRule) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddSpecificPriceRule", specificPriceRule);
        return result;
    }

	/**
	 *  Update information in specified specific price rule. 	
	 * @param specificPriceRule Body of specific price rule.
	 * @return {PrestaShopSpecificPriceRule} Return updated PrestaShopSpecificPriceRule.
	 */
    this.EditSpecificPriceRule = function (specificPriceRule) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditSpecificPriceRule", specificPriceRule);
        return result;
    }

	/**
	 *  Remove specific price rule by identifier. 	
	 * @param id Identifier of specific price rule.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteSpecificPriceRule = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteSpecificPriceRule", id);
        return result;
    }

	/**
	 *  Getting specific price rule by identifier. 	
	 * @param id Identifier of specific price rule.
	 * @return {PrestaShopSpecificPriceRule} Return PrestaShopSpecificPriceRule.
	 */
    this.GetSpecificPriceRule = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSpecificPriceRule", id);
        return result;
    }

	/**
	 *  Getting specific price rules by rendering options. 	
	 * @param renderingOptions For request specified information about specific price rules use: display and filter or sort.
	 * @return {PrestaShopSpecificPriceRule[]} Returns only certain information about SpecificPriceRule in PrestaShopSpecificPriceRule class.
	 */
    this.GetSpecificPriceRulesByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSpecificPriceRulesByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting specific price rules identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopSpecificPriceRule.
	 */
    this.GetSpecificPriceRulesIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSpecificPriceRulesIdentifiers");
        return result;
    }

	/**
	 *  Adding new specific price. 	
	 * @param specificPrice Body of specific price.
	 * @return {Boolean} If added return true.
	 */
    this.AddSpecificPrice = function (specificPrice) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddSpecificPrice", specificPrice);
        return result;
    }

	/**
	 *  Update information in specified specific price. 	
	 * @param specificPrice Body of specific price.
	 * @return {PrestaShopSpecificPrice} Return updated PrestaShopSpecificPrice.
	 */
    this.EditSpecificPrice = function (specificPrice) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditSpecificPrice", specificPrice);
        return result;
    }

	/**
	 *  Remove specific price by identifier. 	
	 * @param id Identifier of specific price.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteSpecificPrice = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteSpecificPrice", id);
        return result;
    }

	/**
	 *  Getting specific price by identifier. 	
	 * @param id Identifier of specific price.
	 * @return {PrestaShopSpecificPrice} Return PrestaShopSpecificPrice.
	 */
    this.GetSpecificPrice = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetSpecificPrice", id);
        return result;
    }

	/**
	 *  Remove language by identifier. 	
	 * @param id Identifier of language.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteLanguage = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteLanguage", id);
        return result;
    }

	/**
	 *  Getting language by identifier. 	
	 * @param id Identifier of language.
	 * @return {PrestaShopLanguage} Return PrestaShopLanguage.
	 */
    this.GetLanguage = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetLanguage", id);
        return result;
    }

	/**
	 *  Getting languages by rendering options. 	
	 * @param renderingOptions For request specified information about languages use: display and filter or sort.
	 * @return {PrestaShopLanguage[]} Returns only certain information about Language in PrestaShopLanguage class.
	 */
    this.GetLanguagesByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetLanguagesByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting languages identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopLanguage.
	 */
    this.GetLanguagesIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetLanguagesIdentifiers");
        return result;
    }

	/**
	 *  Adding new manufacturer. 	
	 * @param manufacturer Body of manufacturer.
	 * @return {Boolean} If added return true.
	 */
    this.AddManufacturer = function (manufacturer) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddManufacturer", manufacturer);
        return result;
    }

	/**
	 *  Update information in specified manufacturer. 	
	 * @param manufacturer Body of manufacturer.
	 * @return {PrestaShopManufacturer} Return updated PrestaShopManufacturer.
	 */
    this.EditManufacturer = function (manufacturer) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditManufacturer", manufacturer);
        return result;
    }

	/**
	 *  Remove manufacturer by identifier. 	
	 * @param id Identifier of manufacturer.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteManufacturer = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteManufacturer", id);
        return result;
    }

	/**
	 *  Getting manufacturer by identifier. 	
	 * @param id Identifier of manufacturer.
	 * @return {PrestaShopManufacturer} Return PrestaShopManufacturer.
	 */
    this.GetManufacturer = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetManufacturer", id);
        return result;
    }

	/**
	 *  Getting manufacturers by rendering options. 	
	 * @param renderingOptions For request specified information about manufacturers use: display and filter or sort.
	 * @return {PrestaShopManufacturer[]} Returns only certain information about Manufacturer in PrestaShopManufacturer class.
	 */
    this.GetManufacturersByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetManufacturersByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting manufacturers identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopManufacturer.
	 */
    this.GetManufacturersIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetManufacturersIdentifiers");
        return result;
    }

	/**
	 *  Adding new message. 	
	 * @param message Body of message.
	 * @return {Boolean} If added return true.
	 */
    this.AddMessage = function (message) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddMessage", message);
        return result;
    }

	/**
	 *  Update information in specified message. 	
	 * @param message Body of message.
	 * @return {PrestaShopMessage} Return updated PrestaShopMessage.
	 */
    this.EditMessage = function (message) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditMessage", message);
        return result;
    }

	/**
	 *  Remove message by identifier. 	
	 * @param id Identifier of message.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteMessage = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteMessage", id);
        return result;
    }

	/**
	 *  Getting message by identifier. 	
	 * @param id Identifier of message.
	 * @return {PrestaShopMessage} Return PrestaShopMessage.
	 */
    this.GetMessage = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetMessage", id);
        return result;
    }

	/**
	 *  Getting messages by rendering options. 	
	 * @param renderingOptions For request specified information about messages use: display and filter or sort.
	 * @return {PrestaShopMessage[]} Returns only certain information about Message in PrestaShopMessage class.
	 */
    this.GetMessagesByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetMessagesByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting messages identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopMessage.
	 */
    this.GetMessagesIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetMessagesIdentifiers");
        return result;
    }

	/**
	 *  Adding new order carrier. 	
	 * @param orderCarrier Body of order carrier.
	 * @return {Boolean} If added return true.
	 */
    this.AddOrderCarrier = function (orderCarrier) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddOrderCarrier", orderCarrier);
        return result;
    }

	/**
	 *  Update information in specified order carrier. 	
	 * @param orderCarrier Body of order carrier.
	 * @return {PrestaShopOrderCarrier} Return updated PrestaShopOrderCarrier.
	 */
    this.EditOrderCarrier = function (orderCarrier) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditOrderCarrier", orderCarrier);
        return result;
    }

	/**
	 *  Remove order carrier by identifier. 	
	 * @param id Identifier of order carrier.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteOrderCarrier = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteOrderCarrier", id);
        return result;
    }

	/**
	 *  Getting order carrier by identifier. 	
	 * @param id Identifier of order carrier.
	 * @return {PrestaShopOrderCarrier} Return PrestaShopOrderCarrier.
	 */
    this.GetOrderCarrier = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderCarrier", id);
        return result;
    }

	/**
	 *  Getting order carriers by rendering options. 	
	 * @param renderingOptions For request specified information about order carriers use: display and filter or sort.
	 * @return {PrestaShopOrderCarrier[]} Returns only certain information about OrderCarrier in PrestaShopOrderCarrier class.
	 */
    this.GetOrderCarriersByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderCarriersByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting order carriers identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopOrderCarrier.
	 */
    this.GetOrderCarriersIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderCarriersIdentifiers");
        return result;
    }

	/**
	 *  Getting order detail by identifier. 	
	 * @param id Identifier of order detail.
	 * @return {PrestaShopOrderDetail} Return PrestaShopOrderDetail.
	 */
    this.GetOrderDetail = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderDetail", id);
        return result;
    }

	/**
	 *  Getting order details by rendering options. 	
	 * @param renderingOptions For request specified information about order details use: display and filter or sort.
	 * @return {PrestaShopOrderDetail[]} Returns only certain information about OrderDetail in PrestaShopOrderDetail class.
	 */
    this.GetOrderDetailsByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderDetailsByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting order details identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopOrderDetail.
	 */
    this.GetOrderDetailsIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderDetailsIdentifiers");
        return result;
    }

	/**
	 *  Getting order history by identifier. 	
	 * @param id Identifier of order history.
	 * @return {PrestaShopOrderHistory} Return PrestaShopOrderHistory.
	 */
    this.GetOrderHistory = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderHistory", id);
        return result;
    }

	/**
	 *  Getting order histories by rendering options. 	
	 * @param renderingOptions For request specified information about order histories use: display and filter or sort.
	 * @return {PrestaShopOrderHistory[]} Returns only certain information about OrderHistory in PrestaShopOrderHistory class.
	 */
    this.GetOrderHistoriesByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderHistoriesByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting order histories identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopOrderHistory.
	 */
    this.GetOrderHistoriesIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderHistoriesIdentifiers");
        return result;
    }

	/**
	 *  Adding new order invoice. 	
	 * @param orderInvoice Body of order invoice.
	 * @return {Boolean} If added return true.
	 */
    this.AddOrderInvoice = function (orderInvoice) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddOrderInvoice", orderInvoice);
        return result;
    }

	/**
	 *  Update information in specified order invoice. 	
	 * @param orderInvoice Body of order invoice.
	 * @return {PrestaShopOrderInvoice} Return updated PrestaShopOrderInvoice.
	 */
    this.EditOrderInvoice = function (orderInvoice) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditOrderInvoice", orderInvoice);
        return result;
    }

	/**
	 *  Remove order invoice by identifier. 	
	 * @param id Identifier of order invoice.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteOrderInvoice = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteOrderInvoice", id);
        return result;
    }

	/**
	 *  Getting order invoice by identifier. 	
	 * @param id Identifier of order invoice.
	 * @return {PrestaShopOrderInvoice} Return PrestaShopOrderInvoice.
	 */
    this.GetOrderInvoice = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderInvoice", id);
        return result;
    }

	/**
	 *  Getting order invoices by rendering options. 	
	 * @param renderingOptions For request specified information about order invoices use: display and filter or sort.
	 * @return {PrestaShopOrderInvoice[]} Returns only certain information about OrderInvoice in PrestaShopOrderInvoice class.
	 */
    this.GetOrderInvoicesByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderInvoicesByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting order invoices identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopOrderInvoice.
	 */
    this.GetOrderInvoicesIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderInvoicesIdentifiers");
        return result;
    }

	/**
	 *  Adding new order payment. 	
	 * @param orderPayment Body of order payment.
	 * @return {Boolean} If added return true.
	 */
    this.AddOrderPayment = function (orderPayment) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddOrderPayment", orderPayment);
        return result;
    }

	/**
	 *  Update information in specified order payment. 	
	 * @param orderPayment Body of order payment.
	 * @return {PrestaShopOrderPayment} Return updated PrestaShopOrderPayment.
	 */
    this.EditOrderPayment = function (orderPayment) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditOrderPayment", orderPayment);
        return result;
    }

	/**
	 *  Remove order payment by identifier. 	
	 * @param id Identifier of order payment.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteOrderPayment = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteOrderPayment", id);
        return result;
    }

	/**
	 *  Getting order payment by identifier. 	
	 * @param id Identifier of order payment.
	 * @return {PrestaShopOrderPayment} Return PrestaShopOrderPayment.
	 */
    this.GetOrderPayment = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderPayment", id);
        return result;
    }

	/**
	 *  Getting order payments by rendering options. 	
	 * @param renderingOptions For request specified information about order payments use: display and filter or sort.
	 * @return {PrestaShopOrderPayment[]} Returns only certain information about OrderPayment in PrestaShopOrderPayment class.
	 */
    this.GetOrderPaymentsByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderPaymentsByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting order payments identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopOrderPayment.
	 */
    this.GetOrderPaymentsIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderPaymentsIdentifiers");
        return result;
    }

	/**
	 *  Adding new order slip. 	
	 * @param orderSlip Body of order slip.
	 * @return {Boolean} If added return true.
	 */
    this.AddOrderSlip = function (orderSlip) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddOrderSlip", orderSlip);
        return result;
    }

	/**
	 *  Update information in specified order slip. 	
	 * @param orderSlip Body of order slip.
	 * @return {PrestaShopOrderSlip} Return updated PrestaShopOrderSlip.
	 */
    this.EditOrderSlip = function (orderSlip) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditOrderSlip", orderSlip);
        return result;
    }

	/**
	 *  Remove order slip by identifier. 	
	 * @param id Identifier of order slip.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteOrderSlip = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteOrderSlip", id);
        return result;
    }

	/**
	 *  Getting order slip by identifier. 	
	 * @param id Identifier of order slip.
	 * @return {PrestaShopOrderSlip} Return PrestaShopOrderSlip.
	 */
    this.GetOrderSlip = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderSlip", id);
        return result;
    }

	/**
	 *  Getting order slip by rendering options. 	
	 * @param renderingOptions For request specified information about order slip use: display and filter or sort.
	 * @return {PrestaShopOrderSlip[]} Returns only certain information about OrderSlip in PrestaShopOrderSlip class.
	 */
    this.GetOrderSlipByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderSlipByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting order slip identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopOrderSlip.
	 */
    this.GetOrderSlipIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderSlipIdentifiers");
        return result;
    }

	/**
	 *  Getting order state by identifier. 	
	 * @param id Identifier of order state.
	 * @return {PrestaShopOrderState} Return PrestaShopOrderState.
	 */
    this.GetOrderState = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderState", id);
        return result;
    }

	/**
	 *  Getting order states by rendering options. 	
	 * @param renderingOptions For request specified information about order states use: display and filter or sort.
	 * @return {PrestaShopOrderState[]} Returns only certain information about OrderState in PrestaShopOrderState class.
	 */
    this.GetOrderStatesByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderStatesByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting order states identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopOrderState.
	 */
    this.GetOrderStatesIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrderStatesIdentifiers");
        return result;
    }

	/**
	 *  Getting order by identifier. 	
	 * @param id Identifier of order.
	 * @return {PrestaShopOrder} Return PrestaShopOrder.
	 */
    this.GetOrder = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrder", id);
        return result;
    }

	/**
	 *  Getting orders by rendering options. 	
	 * @param renderingOptions For request specified information about orders use: display and filter or sort.
	 * @return {PrestaShopOrder[]} Returns only certain information about Order in PrestaShopOrder class.
	 */
    this.GetOrdersByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrdersByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting orders identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopOrder.
	 */
    this.GetOrdersIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetOrdersIdentifiers");
        return result;
    }

	/**
	 *  Adding new price range. 	
	 * @param priceRange Body of price range.
	 * @return {Boolean} If added return true.
	 */
    this.AddPriceRange = function (priceRange) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddPriceRange", priceRange);
        return result;
    }

	/**
	 *  Update information in specified price range. 	
	 * @param priceRange Body of price range.
	 * @return {PrestaShopPriceRange} Return updated PrestaShopPriceRange.
	 */
    this.EditPriceRange = function (priceRange) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditPriceRange", priceRange);
        return result;
    }

	/**
	 *  Remove price range by identifier. 	
	 * @param id Identifier of price range.
	 * @return {Boolean} If removed return true.
	 */
    this.DeletePriceRange = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeletePriceRange", id);
        return result;
    }

	/**
	 *  Getting price range by identifier. 	
	 * @param id Identifier of price range.
	 * @return {PrestaShopPriceRange} Return PrestaShopPriceRange.
	 */
    this.GetPriceRange = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetPriceRange", id);
        return result;
    }

	/**
	 *  Getting price ranges by rendering options. 	
	 * @param renderingOptions For request specified information about price ranges use: display and filter or sort.
	 * @return {PrestaShopPriceRange[]} Returns only certain information about PriceRange in PrestaShopPriceRange class.
	 */
    this.GetPriceRangesByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetPriceRangesByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting price ranges identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopPriceRange.
	 */
    this.GetPriceRangesIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetPriceRangesIdentifiers");
        return result;
    }

	/**
	 *  Adding new product customization field. 	
	 * @param productCustomizationField Body of product customization field.
	 * @return {Boolean} If added return true.
	 */
    this.AddProductCustomizationField = function (productCustomizationField) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddProductCustomizationField", productCustomizationField);
        return result;
    }

	/**
	 *  Update information in specified product customization field. 	
	 * @param productCustomizationField Body of product customization field.
	 * @return {PrestaShopProductCustomizationField} Return updated PrestaShopProductCustomizationField.
	 */
    this.EditProductCustomizationField = function (productCustomizationField) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditProductCustomizationField", productCustomizationField);
        return result;
    }

	/**
	 *  Remove product customization field by identifier. 	
	 * @param id Identifier of product customization field.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteProductCustomizationField = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteProductCustomizationField", id);
        return result;
    }

	/**
	 *  Getting product customization field by identifier. 	
	 * @param id Identifier of product customization field.
	 * @return {PrestaShopProductCustomizationField} Return PrestaShopProductCustomizationField.
	 */
    this.GetProductCustomizationField = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductCustomizationField", id);
        return result;
    }

	/**
	 *  Getting product customization fields by rendering options. 	
	 * @param renderingOptions For request specified information about product customization fields use: display and filter or sort.
	 * @return {PrestaShopProductCustomizationField[]} Returns only certain information about ProductCustomizationField in PrestaShopProductCustomizationField class.
	 */
    this.GetProductCustomizationFieldsByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductCustomizationFieldsByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting product customization fields identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopProductCustomizationField.
	 */
    this.GetProductCustomizationFieldsIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetProductCustomizationFieldsIdentifiers");
        return result;
    }

	/**
	 *  Getting currencies by rendering options. 	
	 * @param renderingOptions For request specified information about currencies use: display and filter or sort.
	 * @return {PrestaShopCurrency[]} Returns only certain information about Currency in PrestaShopCurrency class.
	 */
    this.GetCurrenciesByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCurrenciesByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting currencies identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopCurrency.
	 */
    this.GetCurrenciesIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCurrenciesIdentifiers");
        return result;
    }

	/**
	 *  Adding new customer message. 	
	 * @param customerMessage Body of customer message.
	 * @return {Boolean} If added return true.
	 */
    this.AddCustomerMessage = function (customerMessage) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddCustomerMessage", customerMessage);
        return result;
    }

	/**
	 *  Update information in specified customer message. 	
	 * @param customerMessage Body of customer message.
	 * @return {PrestaShopCustomerMessage} Return updated PrestaShopCustomerMessage.
	 */
    this.EditCustomerMessage = function (customerMessage) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditCustomerMessage", customerMessage);
        return result;
    }

	/**
	 *  Remove customer message by identifier. 	
	 * @param id Identifier of customer message.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteCustomerMessage = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteCustomerMessage", id);
        return result;
    }

	/**
	 *  Getting customer message by identifier. 	
	 * @param id Identifier of customer message.
	 * @return {PrestaShopCustomerMessage} Return PrestaShopCustomerMessage.
	 */
    this.GetCustomerMessage = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCustomerMessage", id);
        return result;
    }

	/**
	 *  Getting customer messages by rendering options. 	
	 * @param renderingOptions For request specified information about customer messages use: display and filter or sort.
	 * @return {PrestaShopCustomerMessage[]} Returns only certain information about CustomerMessage in PrestaShopCustomerMessage class.
	 */
    this.GetCustomerMessagesByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCustomerMessagesByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting customer messages identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopCustomerMessage.
	 */
    this.GetCustomerMessagesIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCustomerMessagesIdentifiers");
        return result;
    }

	/**
	 *  Adding new customer thread. 	
	 * @param customerThread Body of customer thread.
	 * @return {Boolean} If added return true.
	 */
    this.AddCustomerThread = function (customerThread) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddCustomerThread", customerThread);
        return result;
    }

	/**
	 *  Update information in specified customer thread. 	
	 * @param customerThread Body of customer thread.
	 * @return {PrestaShopCustomerThread} Return updated PrestaShopCustomerThread.
	 */
    this.EditCustomerThread = function (customerThread) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditCustomerThread", customerThread);
        return result;
    }

	/**
	 *  Remove customer thread by identifier. 	
	 * @param id Identifier of customer thread.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteCustomerThread = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteCustomerThread", id);
        return result;
    }

	/**
	 *  Getting customer thread by identifier. 	
	 * @param id Identifier of customer thread.
	 * @return {PrestaShopCustomerThread} Return PrestaShopCustomerThread.
	 */
    this.GetCustomerThread = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCustomerThread", id);
        return result;
    }

	/**
	 *  Getting customer threads by rendering options. 	
	 * @param renderingOptions For request specified information about customer threads use: display and filter or sort.
	 * @return {PrestaShopCustomerThread[]} Returns only certain information about CustomerThread in PrestaShopCustomerThread class.
	 */
    this.GetCustomerThreadsByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCustomerThreadsByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting customer threads identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopCustomerThread.
	 */
    this.GetCustomerThreadsIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCustomerThreadsIdentifiers");
        return result;
    }

	/**
	 *  Adding new customer. 	
	 * @param customer Body of customer.
	 * @return {Boolean} If added return true.
	 */
    this.AddCustomer = function (customer) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddCustomer", customer);
        return result;
    }

	/**
	 *  Update information in specified customer. 	
	 * @param customer Body of customer.
	 * @return {PrestaShopCustomer} Return updated PrestaShopCustomer.
	 */
    this.EditCustomer = function (customer) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditCustomer", customer);
        return result;
    }

	/**
	 *  Remove customer by identifier. 	
	 * @param id Identifier of customer.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteCustomer = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteCustomer", id);
        return result;
    }

	/**
	 *  Getting customer by identifier. 	
	 * @param id Identifier of customer.
	 * @return {PrestaShopCustomer} Return PrestaShopCustomer.
	 */
    this.GetCustomer = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCustomer", id);
        return result;
    }

	/**
	 *  Getting customers by rendering options. 	
	 * @param renderingOptions For request specified information about customers use: display and filter or sort.
	 * @return {PrestaShopCustomer[]} Returns only certain information about Customer in PrestaShopCustomer class.
	 */
    this.GetCustomersByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCustomersByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting customers identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopCustomer.
	 */
    this.GetCustomersIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCustomersIdentifiers");
        return result;
    }

	/**
	 *  Adding new customization. 	
	 * @param customization Body of customization.
	 * @return {Boolean} If added return true.
	 */
    this.AddCustomization = function (customization) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddCustomization", customization);
        return result;
    }

	/**
	 *  Update information in specified customization. 	
	 * @param customization Body of customization.
	 * @return {PrestaShopCustomization} Return updated PrestaShopCustomization.
	 */
    this.EditCustomization = function (customization) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditCustomization", customization);
        return result;
    }

	/**
	 *  Remove customization by identifier. 	
	 * @param id Identifier of customization.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteCustomization = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteCustomization", id);
        return result;
    }

	/**
	 *  Getting customization by identifier. 	
	 * @param id Identifier of customization.
	 * @return {PrestaShopCustomization} Return PrestaShopCustomization.
	 */
    this.GetCustomization = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCustomization", id);
        return result;
    }

	/**
	 *  Getting customizations by rendering options. 	
	 * @param renderingOptions For request specified information about customizations use: display and filter or sort.
	 * @return {PrestaShopCustomization[]} Returns only certain information about Customization in PrestaShopCustomization class.
	 */
    this.GetCustomizationsByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCustomizationsByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting customizations identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopCustomization.
	 */
    this.GetCustomizationsIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCustomizationsIdentifiers");
        return result;
    }

	/**
	 *  Adding new delivery. 	
	 * @param delivery Body of delivery.
	 * @return {Boolean} If added return true.
	 */
    this.AddDelivery = function (delivery) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddDelivery", delivery);
        return result;
    }

	/**
	 *  Update information in specified delivery. 	
	 * @param delivery Body of delivery.
	 * @return {PrestaShopDelivery} Return updated PrestaShopDelivery.
	 */
    this.EditDelivery = function (delivery) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditDelivery", delivery);
        return result;
    }

	/**
	 *  Remove delivery by identifier. 	
	 * @param id Identifier of delivery.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteDelivery = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteDelivery", id);
        return result;
    }

	/**
	 *  Getting delivery by identifier. 	
	 * @param id Identifier of delivery.
	 * @return {PrestaShopDelivery} Return PrestaShopDelivery.
	 */
    this.GetDelivery = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetDelivery", id);
        return result;
    }

	/**
	 *  Getting deliveries by rendering options. 	
	 * @param renderingOptions For request specified information about deliveries use: display and filter or sort.
	 * @return {PrestaShopDelivery[]} Returns only certain information about Delivery in PrestaShopDelivery class.
	 */
    this.GetDeliveriesByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetDeliveriesByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting deliveries identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopDelivery.
	 */
    this.GetDeliveriesIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetDeliveriesIdentifiers");
        return result;
    }

	/**
	 *  Adding new employee. 	
	 * @param employee Body of employee.
	 * @return {Boolean} If added return true.
	 */
    this.AddEmployee = function (employee) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddEmployee", employee);
        return result;
    }

	/**
	 *  Update information in specified employee. 	
	 * @param employee Body of employee.
	 * @return {PrestaShopEmployee} Return updated PrestaShopEmployee.
	 */
    this.EditEmployee = function (employee) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditEmployee", employee);
        return result;
    }

	/**
	 *  Remove employee by identifier. 	
	 * @param id Identifier of employee.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteEmployee = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteEmployee", id);
        return result;
    }

	/**
	 *  Getting employee by identifier. 	
	 * @param id Identifier of employee.
	 * @return {PrestaShopEmployee} Return PrestaShopEmployee.
	 */
    this.GetEmployee = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetEmployee", id);
        return result;
    }

	/**
	 *  Getting employees by rendering options. 	
	 * @param renderingOptions For request specified information about employees use: display and filter or sort.
	 * @return {PrestaShopEmployee[]} Returns only certain information about Employee in PrestaShopEmployee class.
	 */
    this.GetEmployeesByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetEmployeesByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting employees identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopEmployee.
	 */
    this.GetEmployeesIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetEmployeesIdentifiers");
        return result;
    }

	/**
	 *  Adding new group. 	
	 * @param group Body of group.
	 * @return {Boolean} If added return true.
	 */
    this.AddGroup = function (group) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddGroup", group);
        return result;
    }

	/**
	 *  Update information in specified group. 	
	 * @param group Body of group.
	 * @return {PrestaShopGroup} Return updated PrestaShopGroup.
	 */
    this.EditGroup = function (group) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditGroup", group);
        return result;
    }

	/**
	 *  Remove group by identifier. 	
	 * @param id Identifier of group.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteGroup = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteGroup", id);
        return result;
    }

	/**
	 *  Getting group by identifier. 	
	 * @param id Identifier of group.
	 * @return {PrestaShopGroup} Return PrestaShopGroup.
	 */
    this.GetGroup = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetGroup", id);
        return result;
    }

	/**
	 *  Getting groups by rendering options. 	
	 * @param renderingOptions For request specified information about groups use: display and filter or sort.
	 * @return {PrestaShopGroup[]} Returns only certain information about Group in PrestaShopGroup class.
	 */
    this.GetGroupsByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetGroupsByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting groups identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopGroup.
	 */
    this.GetGroupsIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetGroupsIdentifiers");
        return result;
    }

	/**
	 *  Adding new guest. 	
	 * @param guest Body of guest.
	 * @return {Boolean} If added return true.
	 */
    this.AddGuest = function (guest) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddGuest", guest);
        return result;
    }

	/**
	 *  Update information in specified guest. 	
	 * @param guest Body of guest.
	 * @return {PrestaShopGuest} Return updated PrestaShopGuest.
	 */
    this.EditGuest = function (guest) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditGuest", guest);
        return result;
    }

	/**
	 *  Remove guest by identifier. 	
	 * @param id Identifier of guest.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteGuest = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteGuest", id);
        return result;
    }

	/**
	 *  Getting guest by identifier. 	
	 * @param id Identifier of guest.
	 * @return {PrestaShopGuest} Return PrestaShopGuest.
	 */
    this.GetGuest = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetGuest", id);
        return result;
    }

	/**
	 *  Getting guests by rendering options. 	
	 * @param renderingOptions For request specified information about guests use: display and filter or sort.
	 * @return {PrestaShopGuest[]} Returns only certain information about Guest in PrestaShopGuest class.
	 */
    this.GetGuestsByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetGuestsByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting guests identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopGuest.
	 */
    this.GetGuestsIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetGuestsIdentifiers");
        return result;
    }

	/**
	 *  Adding new image type. 	
	 * @param imageType Body of image type.
	 * @return {Boolean} If added return true.
	 */
    this.AddImageType = function (imageType) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddImageType", imageType);
        return result;
    }

	/**
	 *  Update information in specified image type. 	
	 * @param imageType Body of image type.
	 * @return {PrestaShopImageType} Return updated PrestaShopImageType.
	 */
    this.EditImageType = function (imageType) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditImageType", imageType);
        return result;
    }

	/**
	 *  Remove image type by identifier. 	
	 * @param id Identifier of image type.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteImageType = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteImageType", id);
        return result;
    }

	/**
	 *  Getting image type by identifier. 	
	 * @param id Identifier of image type.
	 * @return {PrestaShopImageType} Return PrestaShopImageType.
	 */
    this.GetImageType = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetImageType", id);
        return result;
    }

	/**
	 *  Getting image types by rendering options. 	
	 * @param renderingOptions For request specified information about image types use: display and filter or sort.
	 * @return {PrestaShopImageType[]} Returns only certain information about ImageType in PrestaShopImageType class.
	 */
    this.GetImageTypesByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetImageTypesByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting image types identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopImageType.
	 */
    this.GetImageTypesIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetImageTypesIdentifiers");
        return result;
    }

	/**
	 *  Adding new image. 	
	 * @param image Body of image.
	 * @return {Boolean} If added return true.
	 */
    this.AddImage = function (image) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddImage", image);
        return result;
    }

	/**
	 *  Update information in specified image. 	
	 * @param image Body of image.
	 * @return {PrestaShopImage} Return updated PrestaShopImage.
	 */
    this.EditImage = function (image) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditImage", image);
        return result;
    }

	/**
	 *  Remove image by identifier. 	
	 * @param id Identifier of image.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteImage = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteImage", id);
        return result;
    }

	/**
	 *  Getting image by identifier. 	
	 * @param id Identifier of image.
	 * @return {PrestaShopImage} Return PrestaShopImage.
	 */
    this.GetImage = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetImage", id);
        return result;
    }

	/**
	 *  Getting images by rendering options. 	
	 * @param renderingOptions For request specified information about images use: display and filter or sort.
	 * @return {PrestaShopImage[]} Returns only certain information about Image in PrestaShopImage class.
	 */
    this.GetImagesByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetImagesByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting images identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopImage.
	 */
    this.GetImagesIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetImagesIdentifiers");
        return result;
    }

	/**
	 *  Adding new language. 	
	 * @param language Body of language.
	 * @return {Boolean} If added return true.
	 */
    this.AddLanguage = function (language) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddLanguage", language);
        return result;
    }

	/**
	 *  Update information in specified language. 	
	 * @param language Body of language.
	 * @return {PrestaShopLanguage} Return updated PrestaShopLanguage.
	 */
    this.EditLanguage = function (language) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditLanguage", language);
        return result;
    }

	/**
	 *  Adding new address. 	
	 * @param address Body of address.
	 * @return {Boolean} If added return true.
	 */
    this.AddAddress = function (address) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddAddress", address);
        return result;
    }

	/**
	 *  Update information in specified address. 	
	 * @param address Body of address.
	 * @return {PrestaShopAddress} Return updated PrestaShopAddress.
	 */
    this.EditAddress = function (address) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditAddress", address);
        return result;
    }

	/**
	 *  Remove address by identifier. 	
	 * @param id Identifier of address.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteAddress = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteAddress", id);
        return result;
    }

	/**
	 *  Getting address by identifier. 	
	 * @param id Identifier of address.
	 * @return {PrestaShopAddress} Return PrestaShopAddress.
	 */
    this.GetAddress = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetAddress", id);
        return result;
    }

	/**
	 *  Getting addresses by rendering options. 	
	 * @param renderingOptions For request specified information about addresses use: display and filter or sort.
	 * @return {PrestaShopAddress[]} Returns only certain information about Address in PrestaShopAddress class.
	 */
    this.GetAddressesByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetAddressesByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting addresses identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopAddress.
	 */
    this.GetAddressesIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetAddressesIdentifiers");
        return result;
    }

	/**
	 *  Adding new carrier. 	
	 * @param carrier Body of carrier.
	 * @return {Boolean} If added return true.
	 */
    this.AddCarrier = function (carrier) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddCarrier", carrier);
        return result;
    }

	/**
	 *  Update information in specified carrier. 	
	 * @param carrier Body of carrier.
	 * @return {PrestaShopCarrier} Return updated PrestaShopCarrier.
	 */
    this.EditCarrier = function (carrier) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditCarrier", carrier);
        return result;
    }

	/**
	 *  Remove carrier by identifier. 	
	 * @param id Identifier of carrier.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteCarrier = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteCarrier", id);
        return result;
    }

	/**
	 *  Getting carrier by identifier. 	
	 * @param id Identifier of carrier.
	 * @return {PrestaShopCarrier} Return PrestaShopCarrier.
	 */
    this.GetCarrier = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCarrier", id);
        return result;
    }

	/**
	 *  Getting carriers by rendering options. 	
	 * @param renderingOptions For request specified information about carriers use: display and filter or sort.
	 * @return {PrestaShopCarrier[]} Returns only certain information about Carrier in PrestaShopCarrier class.
	 */
    this.GetCarriersByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCarriersByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting carriers identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopCarrier.
	 */
    this.GetCarriersIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCarriersIdentifiers");
        return result;
    }

	/**
	 *  Adding new cart rule. 	
	 * @param cartRule Body of cart rule.
	 * @return {Boolean} If added return true.
	 */
    this.AddCartRule = function (cartRule) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddCartRule", cartRule);
        return result;
    }

	/**
	 *  Update information in specified cart rule. 	
	 * @param cartRule Body of cart rule.
	 * @return {PrestaShopCartRule} Return updated PrestaShopCartRule.
	 */
    this.EditCartRule = function (cartRule) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditCartRule", cartRule);
        return result;
    }

	/**
	 *  Remove cart rule by identifier. 	
	 * @param id Identifier of cart rule.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteCartRule = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteCartRule", id);
        return result;
    }

	/**
	 *  Getting cart rule by identifier. 	
	 * @param id Identifier of cart rule.
	 * @return {PrestaShopCartRule} Return PrestaShopCartRule.
	 */
    this.GetCartRule = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCartRule", id);
        return result;
    }

	/**
	 *  Getting cart rules by rendering options. 	
	 * @param renderingOptions For request specified information about cart rules use: display and filter or sort.
	 * @return {PrestaShopCartRule[]} Returns only certain information about CartRule in PrestaShopCartRule class.
	 */
    this.GetCartRulesByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCartRulesByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting cart rules identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopCartRule.
	 */
    this.GetCartRulesIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCartRulesIdentifiers");
        return result;
    }

	/**
	 *  Adding new cart. 	
	 * @param cart Body of cart.
	 * @return {Boolean} If added return true.
	 */
    this.AddCart = function (cart) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddCart", cart);
        return result;
    }

	/**
	 *  Update information in specified cart. 	
	 * @param cart Body of cart.
	 * @return {PrestaShopCart} Return updated PrestaShopCart.
	 */
    this.EditCart = function (cart) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditCart", cart);
        return result;
    }

	/**
	 *  Remove cart by identifier. 	
	 * @param id Identifier of cart.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteCart = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteCart", id);
        return result;
    }

	/**
	 *  Getting cart by identifier. 	
	 * @param id Identifier of cart.
	 * @return {PrestaShopCart} Return PrestaShopCart.
	 */
    this.GetCart = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCart", id);
        return result;
    }

	/**
	 *  Getting carts by rendering options. 	
	 * @param renderingOptions For request specified information about carts use: display and filter or sort.
	 * @return {PrestaShopCart[]} Returns only certain information about Cart in PrestaShopCart class.
	 */
    this.GetCartsByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCartsByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting carts identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopCart.
	 */
    this.GetCartsIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCartsIdentifiers");
        return result;
    }

	/**
	 *  Adding new category. 	
	 * @param category Body of category.
	 * @return {Boolean} If added return true.
	 */
    this.AddCategory = function (category) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddCategory", category);
        return result;
    }

	/**
	 *  Update information in specified category. 	
	 * @param category Body of category.
	 * @return {PrestaShopCategory} Return updated PrestaShopCategory.
	 */
    this.EditCategory = function (category) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditCategory", category);
        return result;
    }

	/**
	 *  Remove category by identifier. 	
	 * @param id Identifier of category.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteCategory = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteCategory", id);
        return result;
    }

	/**
	 *  Getting category by identifier. 	
	 * @param id Identifier of category.
	 * @return {PrestaShopCategory} Return PrestaShopCategory.
	 */
    this.GetCategory = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCategory", id);
        return result;
    }

	/**
	 *  Getting categories by rendering options. 	
	 * @param renderingOptions For request specified information about categories use: display and filter or sort.
	 * @return {PrestaShopCategory[]} Returns only certain information about Category in PrestaShopCategory class.
	 */
    this.GetCategoriesByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCategoriesByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting categories identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopCategory.
	 */
    this.GetCategoriesIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCategoriesIdentifiers");
        return result;
    }

	/**
	 *  Adding new combination. 	
	 * @param combination Body of combination.
	 * @return {Boolean} If added return true.
	 */
    this.AddCombination = function (combination) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddCombination", combination);
        return result;
    }

	/**
	 *  Update information in specified combination. 	
	 * @param combination Body of combination.
	 * @return {PrestaShopCombination} Return updated PrestaShopCombination.
	 */
    this.EditCombination = function (combination) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditCombination", combination);
        return result;
    }

	/**
	 *  Remove combination by identifier. 	
	 * @param id Identifier of combination.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteCombination = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteCombination", id);
        return result;
    }

	/**
	 *  Getting combination by identifier. 	
	 * @param id Identifier of combination.
	 * @return {PrestaShopCombination} Return PrestaShopCombination.
	 */
    this.GetCombination = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCombination", id);
        return result;
    }

	/**
	 *  Getting combinations by rendering options. 	
	 * @param renderingOptions For request specified information about combinations use: display and filter or sort.
	 * @return {PrestaShopCombination[]} Returns only certain information about Combination in PrestaShopCombination class.
	 */
    this.GetCombinationsByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCombinationsByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting combinations identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopCombination.
	 */
    this.GetCombinationsIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCombinationsIdentifiers");
        return result;
    }

	/**
	 *  Adding new configuration. 	
	 * @param configuration Body of configuration.
	 * @return {Boolean} If added return true.
	 */
    this.AddConfiguration = function (configuration) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddConfiguration", configuration);
        return result;
    }

	/**
	 *  Update information in specified configuration. 	
	 * @param configuration Body of configuration.
	 * @return {PrestaShopConfiguration} Return updated PrestaShopConfiguration.
	 */
    this.EditConfiguration = function (configuration) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditConfiguration", configuration);
        return result;
    }

	/**
	 *  Remove configuration by identifier. 	
	 * @param id Identifier of configuration.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteConfiguration = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteConfiguration", id);
        return result;
    }

	/**
	 *  Getting configuration by identifier. 	
	 * @param id Identifier of configuration.
	 * @return {PrestaShopConfiguration} Return PrestaShopConfiguration.
	 */
    this.GetConfiguration = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetConfiguration", id);
        return result;
    }

	/**
	 *  Getting configurations by rendering options. 	
	 * @param renderingOptions For request specified information about configurations use: display and filter or sort.
	 * @return {PrestaShopConfiguration[]} Returns only certain information about Configuration in PrestaShopConfiguration class.
	 */
    this.GetConfigurationsByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetConfigurationsByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting configurations identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopConfiguration.
	 */
    this.GetConfigurationsIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetConfigurationsIdentifiers");
        return result;
    }

	/**
	 *  Adding new contact. 	
	 * @param contact Body of contact.
	 * @return {Boolean} If added return true.
	 */
    this.AddContact = function (contact) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddContact", contact);
        return result;
    }

	/**
	 *  Update information in specified contact. 	
	 * @param contact Body of contact.
	 * @return {PrestaShopContact} Return updated PrestaShopContact.
	 */
    this.EditContact = function (contact) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditContact", contact);
        return result;
    }

	/**
	 *  Remove contact by identifier. 	
	 * @param id Identifier of contact.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteContact = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteContact", id);
        return result;
    }

	/**
	 *  Getting contact by identifier. 	
	 * @param id Identifier of contact.
	 * @return {PrestaShopContact} Return PrestaShopContact.
	 */
    this.GetContact = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetContact", id);
        return result;
    }

	/**
	 *  Getting contacts by rendering options. 	
	 * @param renderingOptions For request specified information about contacts use: display and filter or sort.
	 * @return {PrestaShopContact[]} Returns only certain information about Contact in PrestaShopContact class.
	 */
    this.GetContactsByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetContactsByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting contacts identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopContact.
	 */
    this.GetContactsIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetContactsIdentifiers");
        return result;
    }

	/**
	 *  Adding new content management system. 	
	 * @param contentManagementSystem Body of content management system.
	 * @return {Boolean} If added return true.
	 */
    this.AddContentManagementSystem = function (contentManagementSystem) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddContentManagementSystem", contentManagementSystem);
        return result;
    }

	/**
	 *  Update information in specified content management system. 	
	 * @param contentManagementSystem Body of content management system.
	 * @return {PrestaShopContentManagementSystem} Return updated PrestaShopContentManagementSystem.
	 */
    this.EditContentManagementSystem = function (contentManagementSystem) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditContentManagementSystem", contentManagementSystem);
        return result;
    }

	/**
	 *  Remove content management system by identifier. 	
	 * @param id Identifier of content management system.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteContentManagementSystem = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteContentManagementSystem", id);
        return result;
    }

	/**
	 *  Getting content management system by identifier. 	
	 * @param id Identifier of content management system.
	 * @return {PrestaShopContentManagementSystem} Return PrestaShopContentManagementSystem.
	 */
    this.GetContentManagementSystem = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetContentManagementSystem", id);
        return result;
    }

	/**
	 *  Getting content management system by rendering options. 	
	 * @param renderingOptions For request specified information about content management system use: display and filter or sort.
	 * @return {PrestaShopContentManagementSystem[]} Returns only certain information about ContentManagementSystem in PrestaShopContentManagementSystem class.
	 */
    this.GetContentManagementSystemByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetContentManagementSystemByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting content management system identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopContentManagementSystem.
	 */
    this.GetContentManagementSystemIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetContentManagementSystemIdentifiers");
        return result;
    }

	/**
	 *  Adding new country. 	
	 * @param country Body of country.
	 * @return {Boolean} If added return true.
	 */
    this.AddCountry = function (country) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddCountry", country);
        return result;
    }

	/**
	 *  Update information in specified country. 	
	 * @param country Body of country.
	 * @return {PrestaShopCountry} Return updated PrestaShopCountry.
	 */
    this.EditCountry = function (country) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditCountry", country);
        return result;
    }

	/**
	 *  Remove country by identifier. 	
	 * @param id Identifier of country.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteCountry = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteCountry", id);
        return result;
    }

	/**
	 *  Getting country by identifier. 	
	 * @param id Identifier of country.
	 * @return {PrestaShopCountry} Return PrestaShopCountry.
	 */
    this.GetCountry = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCountry", id);
        return result;
    }

	/**
	 *  Getting countries by rendering options. 	
	 * @param renderingOptions For request specified information about countries use: display and filter or sort.
	 * @return {PrestaShopCountry[]} Returns only certain information about Country in PrestaShopCountry class.
	 */
    this.GetCountriesByRenderingOptions = function (renderingOptions) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCountriesByRenderingOptions", renderingOptions);
        return result;
    }

	/**
	 *  Getting countries identifiers. 	
	 * @return {PrestaShopIdentifier[]} Return identifiers of PrestaShopCountry.
	 */
    this.GetCountriesIdentifiers = function () {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCountriesIdentifiers");
        return result;
    }

	/**
	 *  Adding new currency. 	
	 * @param currency Body of currency.
	 * @return {Boolean} If added return true.
	 */
    this.AddCurrency = function (currency) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "AddCurrency", currency);
        return result;
    }

	/**
	 *  Update information in specified currency. 	
	 * @param currency Body of currency.
	 * @return {PrestaShopCurrency} Return updated PrestaShopCurrency.
	 */
    this.EditCurrency = function (currency) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "EditCurrency", currency);
        return result;
    }

	/**
	 *  Remove currency by identifier. 	
	 * @param id Identifier of currency.
	 * @return {Boolean} If removed return true.
	 */
    this.DeleteCurrency = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "DeleteCurrency", id);
        return result;
    }

	/**
	 *  Getting currency by identifier. 	
	 * @param id Identifier of currency.
	 * @return {PrestaShopCurrency} Return PrestaShopCurrency.
	 */
    this.GetCurrency = function (id) {
        var result = _bNesisApi.Call("PrestaShop", this.bNesisToken, "GetCurrency", id);
        return result;
    }
}
 PrestaShopTax = function () { 
	this.id = 0;

	this.rate = new Single();

	this.active = false;

	this.deleted = false;

	this.name = "";

}

/**
 * Implementation for PrestaShop 'filter'. 
 * @typedef {Object} PrestaShopFilter
 */
 PrestaShopFilter = function () { 
	/**
	 * Gets or sets the key.
	 * @type {string}
	 */
	this.Key = "";

	/**
	 * Gets or sets the value.
	 * @type {string}
	 */
	this.Value = "";

}

/**
 * Implementation for PrestaShop rendering options. 
 * @typedef {Object} PrestaShopRenderingOptions
 */
 PrestaShopRenderingOptions = function () { 
	/**
	 * Gets or sets the display.
	 * @type {string}
	 */
	this.Display = "";

	/**
	 * Gets or sets the filter.
	 * @type {PrestaShopFilter[]}
	 */
	this.Filter = new Array();

}

/**
 * Implementation identifier's for PrestaShop elements. 
 * @typedef {Object} PrestaShopIdentifier
 */
 PrestaShopIdentifier = function () { 
	/**
	 * The element identifier.
	 * @type {Int32}
	 */
	this.id = 0;

	/**
	 * The identifier feature value.
	 * @type {Int32}
	 */
	this.id_feature_value = 0;

	/**
	 * The identifier product attribute.
	 * @type {Int32}
	 */
	this.id_product_attribute = 0;

}

 PrestaShopTranslatedConfigurationIn = function () { 
	this.value = "";

	this.date_add = "";

	this.date_upd = "";

	this.name = "";

	this.id_shop_group = "";

	this.id_show = "";

}

 PrestaShopTranslatedConfiguration = function () { 
	this.id = 0;

	this.value = "";

	this.date_add = "";

	this.date_upd = "";

	this.name = "";

	this.id_shop_group = "";

	this.id_show = "";

}

 PrestaShopWarehouseProductLocation = function () { 
	this.id = 0;

	this.id_product = 0;

	this.id_product_attribute = 0;

	this.id_warehouse = 0;

	this.location = "";

}

 PrestaShopWeightRangeIn = function () { 
	this.id_carrier = 0;

	this.delimiter1 = new Single();

	this.delimiter2 = new Single();

}

 PrestaShopWeightRange = function () { 
	this.id = 0;

	this.id_carrier = 0;

	this.delimiter1 = new Single();

	this.delimiter2 = new Single();

}

 PrestaShopZoneIn = function () { 
	this.name = "";

	this.active = false;

}

 PrestaShopZone = function () { 
	this.id = 0;

	this.name = "";

	this.active = false;

}

 PrestaShopSpecificPrice = function () { 
	this.id = 0;

	this.id_shop_group = 0;

	this.id_shop = 0;

	this.id_cart = 0;

	this.id_product = 0;

	this.id_product_attribute = 0;

	this.id_currency = 0;

	this.id_country = 0;

	this.id_group = 0;

	this.id_customer = 0;

	this.id_specific_price_rule = 0;

	this.price = new Single();

	this.from_quantity = 0;

	this.reduction = new Single();

	this.reduction_tax = 0;

	this.reduction_type = "";

	this.from = "";

	this.to = "";

}

 PrestaShopState = function () { 
	this.id = 0;

	this.id_zone = 0;

	this.id_country = 0;

	this.iso_code = "";

	this.name = "";

	this.active = false;

}

 PrestaShopStockMovementReasonIn = function () { 
	this.sign = false;

	this.deleted = false;

	this.date_add = "";

	this.date_upd = "";

	this.name = "";

}

 PrestaShopStockMovementReason = function () { 
	this.id = 0;

	this.sign = false;

	this.deleted = false;

	this.date_add = "";

	this.date_upd = "";

	this.name = "";

}

 PrestaShopStockMovement = function () { 
	this.id = 0;

	this.id_employee = 0;

	this.empoyee_firstname = "";

	this.id_stock = 0;

	this.physical_quantity = 0;

	this.id_stock_mvt_reason = 0;

	this.id_order = 0;

	this.id_supply_order = 0;

	this.sign = 0;

	this.last_wa = new Single();

	this.current_wa = new Single();

	this.price_te = new Single();

	this.referer = 0;

	this.date_add = "";

}

 PrestaShopStock = function () { 
	this.id = 0;

	this.id_warehouse = 0;

	this.id_product = 0;

	this.id_product_attribute = 0;

	this.reference = "";

	this.ean13 = "";

	this.upc = "";

	this.physical_quantity = 0;

	this.usable_quantity = 0;

	this.price_te = new Single();

}

 PrestaShopStoreIn = function () { 
	this.id_country = 0;

	this.id_state = 0;

	this.hours = new Array();

	this.name = "";

	this.address1 = "";

	this.address2 = "";

	this.postcode = "";

	this.city = "";

	this.latitude = new Single();

	this.longitude = new Single();

	this.phone = "";

	this.fax = "";

	this.note = "";

	this.email = "";

	this.active = false;

}

 PrestaShopStore = function () { 
	this.id = 0;

	this.id_country = 0;

	this.id_state = 0;

	this.hours = new Array();

	this.name = "";

	this.address1 = "";

	this.address2 = "";

	this.postcode = "";

	this.city = "";

	this.latitude = new Single();

	this.longitude = new Single();

	this.phone = "";

	this.fax = "";

	this.note = "";

	this.email = "";

	this.active = false;

	this.date_add = "";

	this.date_upd = "";

}

 PrestaShopSupplierIn = function () { 
	this.link_rewrite = "";

	this.name = "";

	this.active = false;

	this.date_add = "";

	this.date_up = "";

	this.description = "";

	this.meta_title = "";

	this.meta_description = "";

	this.meta_keywords = "";

}

 PrestaShopSupplier = function () { 
	this.id = 0;

	this.link_rewrite = "";

	this.name = "";

	this.active = false;

	this.date_add = "";

	this.date_up = "";

	this.description = "";

	this.meta_title = "";

	this.meta_description = "";

	this.meta_keywords = "";

}

 PrestaShopSupplyOrderDetail = function () { 
	this.id = 0;

	this.id_supply_order = 0;

	this.id_product = 0;

	this.id_product_attribute = 0;

	this.reference = "";

	this.supplier_reference = "";

	this.name = 0;

	this.ean13 = 0;

	this.isbn = "";

	this.upc = "";

	this.id_currency = 0;

	this.exchange_rate = new Single();

	this.unit_price_te = new Single();

	this.quantity_expected = 0;

	this.quantity_received = 0;

	this.price_te = new Single();

	this.discount_rate = new Single();

	this.discount_value_te = new Single();

	this.price_with_discount_te = new Single();

	this.tax_rate = 0;

	this.tax_value = new Single();

	this.price_ti = new Single();

	this.tax_value_with_order_discount = new Single();

	this.price_with_order_discount_te = new Single();

}

 PrestaShopSupplyOrderHistory = function () { 
	this.id = 0;

	this.id_supply_order = 0;

	this.id_employee = 0;

	this.employee_firstname = "";

	this.employee_lastname = "";

	this.id_state = 0;

	this.date_add = "";

}

 PrestaShopSupplyOrderReceiptHistory = function () { 
	this.id = 0;

	this.id_supply_order_detail = 0;

	this.id_employee = 0;

	this.employee_firstname = "";

	this.employee_lastname = "";

	this.id_supply_order_state = 0;

	this.quantity = 0;

	this.date_add = "";

}

 PrestaShopSupplyOrderState = function () { 
	this.id = 0;

	this.delivery_note = false;

	this.editable = false;

	this.receipt_state = 0;

	this.pending_receipt = false;

	this.enclosed = false;

	this.color = "";

	this.name = "";

}

 PrestaShopSupplyOrder = function () { 
	this.id = 0;

	this.id_supplier = 0;

	this.supplier_name = "";

	this.id_lang = 0;

	this.id_warehouse = 0;

	this.id_supply_order_state = 0;

	this.id_currency = 0;

	this.id_ref_currency = 0;

	this.reference = "";

	this.date_add = "";

	this.date_upd = "";

	this.date_delivery_expected = "";

	this.total_te = new Single();

	this.total_with_discount_te = new Single();

	this.total_ti = new Single();

	this.total_tax = new Single();

	this.discount_rate = new Single();

	this.discount_value_te = new Single();

	this.is_template = false;

}

 PrestaShopTagIn = function () { 
	this.id_lang = 0;

	this.name = "";

}

 PrestaShopTag = function () { 
	this.id = 0;

	this.id_lang = 0;

	this.name = "";

}

 PrestaShopTaxRuleGroupIn = function () { 
	this.name = "";

	this.active = false;

	this.deleted = false;

	this.date_add = "";

	this.date_upd = "";

}

 PrestaShopTaxRuleGroup = function () { 
	this.id = 0;

	this.name = "";

	this.active = false;

	this.deleted = false;

	this.date_add = "";

	this.date_upd = "";

}

 PrestaShopTaxRuleIn = function () { 
	this.id_tax_rules_group = 0;

	this.id_state = 0;

	this.id_country = 0;

	this.zipcode_from = "";

	this.zipcode_to = "";

	this.id_tax = 0;

	this.behavior = 0;

	this.description = "";

}

 PrestaShopTaxRule = function () { 
	this.id = 0;

	this.id_tax_rules_group = 0;

	this.id_state = 0;

	this.id_country = 0;

	this.zipcode_from = "";

	this.zipcode_to = "";

	this.id_tax = 0;

	this.behavior = 0;

	this.description = "";

}

 PrestaShopTaxIn = function () { 
	this.rate = new Single();

	this.active = false;

	this.deleted = false;

	this.name = "";

}

 PrestaShopProductFeatureValueIn = function () { 
	this.id_feature = 0;

	this.custom = 0;

	this.value = "";

}

 PrestaShopProductFeatureValue = function () { 
	this.id = 0;

	this.id_feature = 0;

	this.custom = 0;

	this.value = "";

}

 PrestaShopProductFeatureIn = function () { 
	this.position = 0;

	this.name = "";

}

 PrestaShopProductFeature = function () { 
	this.id = 0;

	this.position = 0;

	this.name = "";

}

 PrestaShopProductOptionValueIn = function () { 
	this.id_attribute_group = 0;

	this.color = "";

	this.position = 0;

	this.name = "";

}

 PrestaShopProductOptionValue = function () { 
	this.id = 0;

	this.id_attribute_group = 0;

	this.color = "";

	this.position = 0;

	this.name = "";

}

/**
 * Implementation for PrestaShop 'orderRow'. 
 * @typedef {Object} PrestaShopOrderRow
 */
 PrestaShopOrderRow = function () { 
	/**
	 * The order row identifier.
	 * @type {Int32}
	 */
	this.id = 0;

	/**
	 * The product identifier.
	 * @type {Int32}
	 */
	this.product_id = 0;

	/**
	 * The product attribute identifier.
	 * @type {Int32}
	 */
	this.product_attribute_id = 0;

	/**
	 * The product quantity.
	 * @type {Int32}
	 */
	this.product_quantity = 0;

	/**
	 * The name of the product.
	 * @type {string}
	 */
	this.product_name = "";

	/**
	 * The product reference.
	 * @type {string}
	 */
	this.product_reference = "";

	/**
	 * The product ean13.
	 * @type {string}
	 */
	this.product_ean13 = "";

	/**
	 * The product isbn.
	 * @type {string}
	 */
	this.product_isbn = "";

	/**
	 * The product upc.
	 * @type {string}
	 */
	this.product_upc = "";

	/**
	 * The product price.
	 * @type {Single}
	 */
	this.product_price = new Single();

	/**
	 * The unit price tax incl.
	 * @type {Single}
	 */
	this.unit_price_tax_incl = new Single();

	/**
	 * The unit price tax excl.
	 * @type {Single}
	 */
	this.unit_price_tax_excl = new Single();

}

/**
 * Implementation for PrestaShop 'associations'. 
 * @typedef {Object} PrestaShopAssociations
 */
 PrestaShopAssociations = function () { 
	/**
	 * The array of identifier for categories.
	 * @type {PrestaShopIdentifier[]}
	 */
	this.categories = new Array();

	/**
	 * The array of identifier for groups.
	 * @type {PrestaShopIdentifier[]}
	 */
	this.groups = new Array();

	/**
	 * The array of identifier for product option values.
	 * @type {PrestaShopIdentifier[]}
	 */
	this.product_option_values = new Array();

	/**
	 * The array of identifier for images.
	 * @type {PrestaShopIdentifier[]}
	 */
	this.images = new Array();

	/**
	 * The array of identifier for customer messages.
	 * @type {PrestaShopIdentifier[]}
	 */
	this.customer_messages = new Array();

	/**
	 * The array of identifier for addresses.
	 * @type {PrestaShopIdentifier[]}
	 */
	this.addresses = new Array();

	/**
	 * The array of identifier for combinations.
	 * @type {PrestaShopIdentifier[]}
	 */
	this.combinations = new Array();

	/**
	 * The array of identifier for order rows.
	 * @type {PrestaShopOrderRow[]}
	 */
	this.order_rows = new Array();

	/**
	 * The array of identifier for product features.
	 * @type {PrestaShopIdentifier[]}
	 */
	this.product_features = new Array();

	/**
	 * The array of identifier for stock avaibles.
	 * @type {PrestaShopIdentifier[]}
	 */
	this.stock_avaibles = new Array();

}

 PrestaShopProductOptionIn = function () { 
	this.is_color_group = false;

	this.group_type = "";

	this.position = 0;

	this.name = "";

	this.public_name = "";

	this.associations = new PrestaShopAssociations();

}

 PrestaShopProductOption = function () { 
	this.id = 0;

	this.is_color_group = false;

	this.group_type = "";

	this.position = 0;

	this.name = "";

	this.public_name = "";

	this.associations = new PrestaShopAssociations();

}

 PrestaShopProductSupplierIn = function () { 
	this.id_product = 0;

	this.id_product_attribute = 0;

	this.id_supplier = 0;

	this.id_currency = 0;

	this.product_supplier_reference = "";

	this.product_supplier_price_te = new Single();

}

 PrestaShopProductSupplier = function () { 
	this.id = 0;

	this.id_product = 0;

	this.id_product_attribute = 0;

	this.id_supplier = 0;

	this.id_currency = 0;

	this.product_supplier_reference = "";

	this.product_supplier_price_te = new Single();

}

 PrestaShopProductIn = function () { 
	this.id_manufacturer = 0;

	this.id_supplier = 0;

	this.id_category_default = 0;

	this.is_new = false;

	this.cache_default_attribute = 0;

	this.id_default_image = 0;

	this.id_default_combination = 0;

	this.id_tax_rules_group = 0;

	this.position_in_category = 0;

	this.manufacturer_name = "";

	this.quantity = 0;

	this.type = "";

	this.id_shop_default = 0;

	this.reference = "";

	this.supplier_reference = "";

	this.location = "";

	this.width = new Single();

	this.height = new Single();

	this.depth = new Single();

	this.weight = new Single();

	this.quantity_discount = 0;

	this.ean13 = false;

	this.isbn = "";

	this.upc = "";

	this.cache_is_pack = false;

	this.cache_has_attachments = false;

	this.is_virtual = false;

	this.state = 0;

	this.on_sale = false;

	this.online_only = false;

	this.ecotax = new Single();

	this.minimal_quantity = 0;

	this.price = new Single();

	this.wholesale_price = new Single();

	this.unity = "";

	this.unit_price_ratio = new Single();

	this.additional_shipping_cost = new Single();

	this.customizable = false;

	this.text_fields = false;

	this.uploadable_files = false;

	this.active = false;

	this.redirect_type = "";

	this.id_type_redirected = 0;

	this.available_for_order = false;

	this.available_date = "";

	this.show_condition = false;

	this.condition = "";

	this.show_price = false;

	this.indexed = false;

	this.visibility = "";

	this.advanced_stock_management = false;

	this.date_add = "";

	this.date_upd = "";

	this.intpack_stock_type = 0;

	this.meta_description = "";

	this.meta_keywords = "";

	this.meta_title = "";

	this.link_rewrite = "";

	this.name = "";

	this.description = "";

	this.description_short = "";

	this.available_now = "";

	this.available_later = "";

	this.associations = new PrestaShopAssociations();

}

 PrestaShopProduct = function () { 
	this.id = 0;

	this.id_manufacturer = 0;

	this.id_supplier = 0;

	this.id_category_default = 0;

	this.is_new = false;

	this.cache_default_attribute = 0;

	this.id_default_image = 0;

	this.id_default_combination = 0;

	this.id_tax_rules_group = 0;

	this.position_in_category = 0;

	this.manufacturer_name = "";

	this.quantity = 0;

	this.type = "";

	this.id_shop_default = 0;

	this.reference = "";

	this.supplier_reference = "";

	this.location = "";

	this.width = new Single();

	this.height = new Single();

	this.depth = new Single();

	this.weight = new Single();

	this.quantity_discount = 0;

	this.ean13 = false;

	this.isbn = "";

	this.upc = "";

	this.cache_is_pack = false;

	this.cache_has_attachments = false;

	this.is_virtual = false;

	this.state = 0;

	this.on_sale = false;

	this.online_only = false;

	this.ecotax = new Single();

	this.minimal_quantity = 0;

	this.price = new Single();

	this.wholesale_price = new Single();

	this.unity = "";

	this.unit_price_ratio = new Single();

	this.additional_shipping_cost = new Single();

	this.customizable = false;

	this.text_fields = false;

	this.uploadable_files = false;

	this.active = false;

	this.redirect_type = "";

	this.id_type_redirected = 0;

	this.available_for_order = false;

	this.available_date = "";

	this.show_condition = false;

	this.condition = "";

	this.show_price = false;

	this.indexed = false;

	this.visibility = "";

	this.advanced_stock_management = false;

	this.date_add = "";

	this.date_upd = "";

	this.intpack_stock_type = 0;

	this.meta_description = "";

	this.meta_keywords = "";

	this.meta_title = "";

	this.link_rewrite = "";

	this.name = "";

	this.description = "";

	this.description_short = "";

	this.available_now = "";

	this.available_later = "";

	this.associations = new PrestaShopAssociations();

}

 PrestaShopShopGroupIn = function () { 
	this.name = "";

	this.share_customer = false;

	this.share_order = false;

	this.share_stock = false;

	this.active = false;

	this.deleted = false;

}

 PrestaShopShopGroup = function () { 
	this.id = 0;

	this.name = "";

	this.share_customer = false;

	this.share_order = false;

	this.share_stock = false;

	this.active = false;

	this.deleted = false;

}

 PrestaShopShopUrlIn = function () { 
	this.id_shop = 0;

	this.domain = "";

	this.domain_ssl = "";

	this.physical_uri = "";

	this.virtual_uri = "";

	this.main = false;

	this.active = false;

}

 PrestaShopShopUrl = function () { 
	this.id = 0;

	this.id_shop = 0;

	this.domain = "";

	this.domain_ssl = "";

	this.physical_uri = "";

	this.virtual_uri = "";

	this.main = false;

	this.active = false;

}

 PrestaShopShopIn = function () { 
	this.id_shop_group = 0;

	this.id_category = 0;

	this.active = false;

	this.name = "";

	this.theme_name = "";

}

 PrestaShopShop = function () { 
	this.id = 0;

	this.id_shop_group = 0;

	this.id_category = 0;

	this.active = false;

	this.deleted = false;

	this.name = "";

	this.theme_name = "";

}

 PrestaShopSpecificPriceRuleIn = function () { 
	this.id_shop = 0;

	this.id_country = 0;

	this.id_currency = 0;

	this.id_group = 0;

	this.name = "";

	this.from_quantity = 0;

	this.price = new Single();

	this.reduction = new Single();

	this.reduction_tax = 0;

	this.reduction_type = "";

	this.from = "";

	this.to = "";

}

 PrestaShopSpecificPriceRule = function () { 
	this.id = 0;

	this.id_shop = 0;

	this.id_country = 0;

	this.id_currency = 0;

	this.id_group = 0;

	this.name = "";

	this.from_quantity = 0;

	this.price = new Single();

	this.reduction = new Single();

	this.reduction_tax = 0;

	this.reduction_type = "";

	this.from = "";

	this.to = "";

}

 PrestaShopSpecificPriceIn = function () { 
	this.id_shop_group = 0;

	this.id_shop = 0;

	this.id_cart = 0;

	this.id_product = 0;

	this.id_product_attribute = 0;

	this.id_currency = 0;

	this.id_country = 0;

	this.id_group = 0;

	this.id_customer = 0;

	this.id_specific_price_rule = 0;

	this.price = new Single();

	this.from_quantity = 0;

	this.reduction = new Single();

	this.reduction_tax = 0;

	this.reduction_type = "";

	this.from = "";

	this.to = "";

}

 PrestaShopLanguage = function () { 
	this.id = 0;

	this.name = "";

	this.iso_code = "";

	this.locale = "";

	this.language_code = "";

	this.active = false;

	this.is_rtl = false;

	this.date_format_lite = "";

	this.date_format_full = "";

}

 PrestaShopManufacturerIn = function () { 
	this.active = false;

	this.link_rewrite = "";

	this.name = "";

	this.date_add = "";

	this.date_upd = "";

	this.description = "";

	this.short_description = "";

	this.meta_title = "";

	this.meta_description = "";

	this.meta_keywords = "";

	this.associations = new PrestaShopAssociations();

}

 PrestaShopManufacturer = function () { 
	this.id = 0;

	this.active = false;

	this.link_rewrite = "";

	this.name = "";

	this.date_add = "";

	this.date_upd = "";

	this.description = "";

	this.short_description = "";

	this.meta_title = "";

	this.meta_description = "";

	this.meta_keywords = "";

	this.associations = new PrestaShopAssociations();

}

 PrestaShopMessageIn = function () { 
	this.message = "";

	this.id_cart = 0;

	this.id_order = 0;

	this.id_customer = 0;

	this.id_employee = 0;

	this.is_private = false;

	this.date_add = "";

}

 PrestaShopMessage = function () { 
	this.id = 0;

	this.message = "";

	this.id_cart = 0;

	this.id_order = 0;

	this.id_customer = 0;

	this.id_employee = 0;

	this.is_private = false;

	this.date_add = "";

}

 PrestaShopOrderCarrierIn = function () { 
	this.id_order = 0;

	this.id_carrier = 0;

	this.id_order_invoice = 0;

	this.weight = new Single();

	this.shipping_cost_tax_excl = new Single();

	this.shipping_cost_tax_incl = new Single();

	this.tracking_number = "";

	this.date_add = "";

}

 PrestaShopOrderCarrier = function () { 
	this.id = 0;

	this.id_order = 0;

	this.id_carrier = 0;

	this.id_order_invoice = 0;

	this.weight = new Single();

	this.shipping_cost_tax_excl = new Single();

	this.shipping_cost_tax_incl = new Single();

	this.tracking_number = "";

	this.date_add = "";

}

 PrestaShopOrderDetail = function () { 
	this.id = 0;

	this.id_order = 0;

	this.id_order_invoice = 0;

	this.id_warehouse = 0;

	this.id_shop = 0;

	this.id_customization = 0;

	this.id_tax_rules_group = 0;

	this.product_id = 0;

	this.product_attribute_id = 0;

	this.product_quantity_reinjected = 0;

	this.group_reduction = new Single();

	this.discount_quantity_applied = 0;

	this.download_hash = "";

	this.download_deadline = "";

	this.download_nb = 0;

	this.product_name = "";

	this.product_quantity = 0;

	this.product_quantity_in_stock = 0;

	this.product_quantity_return = 0;

	this.product_quantity_refunded = 0;

	this.product_price = new Single();

	this.reduction_percent = new Single();

	this.reduction_amount = new Single();

	this.reduction_amount_tax_incl = new Single();

	this.reduction_amount_tax_excl = new Single();

	this.product_quantity_discount = new Single();

	this.product_ean13 = "";

	this.product_isbn = "";

	this.product_upc = "";

	this.product_reference = "";

	this.product_supplier_reference = "";

	this.product_weight = new Single();

	this.tax_computation_method = 0;

	this.ecotax = new Single();

	this.ecotax_tax_rate = new Single();

	this.unit_price_tax_incl = new Single();

	this.unit_price_tax_excl = new Single();

	this.total_price_tax_incl = new Single();

	this.total_price_tax_excl = new Single();

	this.total_shipping_price_tax_excl = new Single();

	this.total_shipping_price_tax_incl = new Single();

	this.purchase_supplier_price = new Single();

	this.original_product_price = new Single();

	this.original_wholesale_price = new Single();

}

 PrestaShopOrderHistory = function () { 
	this.id = 0;

	this.id_employee = 0;

	this.id_order_state = 0;

	this.id_order = 0;

	this.date_add = "";

}

 PrestaShopOrderInvoiceIn = function () { 
	this.id_order = 0;

	this.number = 0;

	this.delivery_number = 0;

	this.delivery_date = "";

	this.total_discount_tax_excl = new Single();

	this.total_discount_tax_incl = new Single();

	this.total_paid_tax_excl = new Single();

	this.total_paid_tax_incl = new Single();

	this.total_products = new Single();

	this.total_products_wt = new Single();

	this.total_shipping_tax_excl = new Single();

	this.total_shipping_tax_incl = new Single();

	this.shipping_tax_computation_method = new Single();

	this.total_wrapping_tax_excl = new Single();

	this.total_wrapping_tax_incl = new Single();

	this.shop_address = "";

	this.note = "";

	this.date_add = "";

}

 PrestaShopOrderInvoice = function () { 
	this.id = 0;

	this.id_order = 0;

	this.number = 0;

	this.delivery_number = 0;

	this.delivery_date = "";

	this.total_discount_tax_excl = new Single();

	this.total_discount_tax_incl = new Single();

	this.total_paid_tax_excl = new Single();

	this.total_paid_tax_incl = new Single();

	this.total_products = new Single();

	this.total_products_wt = new Single();

	this.total_shipping_tax_excl = new Single();

	this.total_shipping_tax_incl = new Single();

	this.shipping_tax_computation_method = new Single();

	this.total_wrapping_tax_excl = new Single();

	this.total_wrapping_tax_incl = new Single();

	this.shop_address = "";

	this.note = "";

	this.date_add = "";

}

 PrestaShopOrderPaymentIn = function () { 
	this.order_reference = "";

	this.id_currency = 0;

	this.amount = new Single();

	this.payment_method = "";

	this.conversion_rate = new Single();

	this.transaction_id = "";

	this.card_number = "";

	this.card_brand = "";

	this.card_expiration = "";

	this.card_holder = "";

	this.date_add = "";

}

 PrestaShopOrderPayment = function () { 
	this.id = 0;

	this.order_reference = "";

	this.id_currency = 0;

	this.amount = new Single();

	this.payment_method = "";

	this.conversion_rate = new Single();

	this.transaction_id = "";

	this.card_number = "";

	this.card_brand = "";

	this.card_expiration = "";

	this.card_holder = "";

	this.date_add = "";

}

 PrestaShopOrderSlipIn = function () { 
	this.id_customer = 0;

	this.id_order = 0;

	this.conversion_rate = new Single();

	this.total_products_tax_excl = new Single();

	this.total_products_tax_incl = new Single();

	this.total_shipping_tax_excl = new Single();

	this.total_shipping_tax_incl = new Single();

	this.amount = 0;

	this.shipping_cost = 0;

	this.shipping_cost_amount = 0;

	this.partial = 0;

	this.date_add = "";

	this.date_upd = "";

	this.order_slip_type = 0;

}

 PrestaShopOrderSlip = function () { 
	this.id = 0;

	this.id_customer = 0;

	this.id_order = 0;

	this.conversion_rate = new Single();

	this.total_products_tax_excl = new Single();

	this.total_products_tax_incl = new Single();

	this.total_shipping_tax_excl = new Single();

	this.total_shipping_tax_incl = new Single();

	this.amount = 0;

	this.shipping_cost = 0;

	this.shipping_cost_amount = 0;

	this.partial = 0;

	this.date_add = "";

	this.date_upd = "";

	this.order_slip_type = 0;

}

 PrestaShopOrderState = function () { 
	this.id = 0;

	this.unremovable = false;

	this.delivery = false;

	this.hidden = false;

	this.send_email = false;

	this.module_name = "";

	this.invoice = false;

	this.color = "";

	this.logable = false;

	this.shipped = false;

	this.paid = false;

	this.pdf_delivery = false;

	this.pdf_invoice = false;

	this.deleted = false;

	this.name = "";

	this.template = "";

}

 PrestaShopOrder = function () { 
	this.id = 0;

	this.id_address_delivery = 0;

	this.id_address_invoice = 0;

	this.id_cart = 0;

	this.id_currency = 0;

	this.id_lang = 0;

	this.id_customer = 0;

	this.id_carrier = 0;

	this.current_state = 0;

	this.module = "";

	this.invoice_number = 0;

	this.invoice_date = "";

	this.delivery_number = 0;

	this.delivery_date = "";

	this.valid = false;

	this.date_add = "";

	this.date_upd = "";

	this.shipping_number = "";

	this.id_shop_group = 0;

	this.id_shop = 0;

	this.secure_key = "";

	this.payment = "";

	this.recyclable = false;

	this.gift = false;

	this.gift_message = "";

	this.mobile_theme = false;

	this.total_discounts = new Single();

	this.total_discounts_tax_incl = new Single();

	this.total_discounts_tax_excl = new Single();

	this.total_paid = new Single();

	this.total_paid_tax_incl = new Single();

	this.total_paid_tax_excl = new Single();

	this.total_paid_real = new Single();

	this.total_products = new Single();

	this.total_products_wt = new Single();

	this.total_shipping = new Single();

	this.total_shipping_tax_incl = new Single();

	this.total_shipping_tax_excl = new Single();

	this.carrier_tax_rate = new Single();

	this.total_wrapping = new Single();

	this.total_wrapping_tax_incl = new Single();

	this.total_wrapping_tax_excl = new Single();

	this.round_mode = 0;

	this.round_type = 0;

	this.conversion_rate = new Single();

	this.reference = "";

	this.associations = new PrestaShopAssociations();

}

 PrestaShopPriceRangeIn = function () { 
	this.id_carrier = 0;

	this.delimiter1 = new Single();

	this.delimiter2 = new Single();

}

 PrestaShopPriceRange = function () { 
	this.id = 0;

	this.id_carrier = 0;

	this.delimiter1 = new Single();

	this.delimiter2 = new Single();

}

 PrestaShopProductCustomizationFieldIn = function () { 
	this.id = 0;

	this.id_product = 0;

	this.type = 0;

	this.required = false;

	this.is_module = false;

	this.name = "";

}

 PrestaShopProductCustomizationField = function () { 
	this.id = 0;

	this.id_product = 0;

	this.type = 0;

	this.required = false;

	this.is_module = false;

	this.name = "";

}

 PrestaShopCurrency = function () { 
	this.id = 0;

	this.name = "";

	this.iso_code = "";

	this.conversion_rate = new Single();

	this.deleted = false;

	this.active = false;

}

 PrestaShopCustomerMessageIn = function () { 
	this.id_employee = 0;

	this.id_customer_thread = 0;

	this.ip_address = "";

	this.message = "";

	this.file_name = "";

	this.user_agent = "";

	this.is_private = false;

	this.date_add = "";

	this.date_upd = "";

	this.read = false;

}

 PrestaShopCustomerMessage = function () { 
	this.id = 0;

	this.id_employee = 0;

	this.id_customer_thread = 0;

	this.ip_address = "";

	this.message = "";

	this.file_name = "";

	this.user_agent = "";

	this.is_private = false;

	this.date_add = "";

	this.date_upd = "";

	this.read = false;

}

 PrestaShopCustomerThreadIn = function () { 
	this.id_lang = 0;

	this.id_shop = 0;

	this.id_customer = 0;

	this.id_order = 0;

	this.id_product = 0;

	this.id_contact = 0;

	this.email = "";

	this.token = "";

	this.status = "";

	this.date_add = "";

	this.date_upd = "";

}

 PrestaShopCustomerThread = function () { 
	this.id = 0;

	this.id_lang = 0;

	this.id_shop = 0;

	this.id_customer = 0;

	this.id_order = 0;

	this.id_product = 0;

	this.id_contact = 0;

	this.email = "";

	this.token = "";

	this.status = "";

	this.date_add = "";

	this.date_upd = "";

}

 PrestaShopCustomerIn = function () { 
	this.id_default_group = 0;

	this.id_lang = 0;

	this.newsletter_date_add = "";

	this.ip_registration_newsletter = "";

	this.secure_key = "";

	this.passwd = "";

	this.lastname = "";

	this.firstname = "";

	this.email = "";

	this.id_gender = 0;

	this.birthday = "";

	this.newsletter = 0;

	this.optin = 0;

	this.website = "";

	this.company = "";

	this.siret = "";

	this.ape = "";

	this.outstanding_allow_amount = new Double();

	this.show_public_prices = false;

	this.id_risk = 0;

	this.max_payment_days = 0;

	this.active = false;

	this.note = "";

	this.is_guest = false;

	this.id_shop = 0;

	this.reset_password_token = "";

	this.reset_password_validity = "";

	this.PrestaShopAssociations = new PrestaShopAssociations();

}

 PrestaShopCustomer = function () { 
	this.id = 0;

	this.id_default_group = 0;

	this.id_lang = 0;

	this.newsletter_date_add = "";

	this.ip_registration_newsletter = "";

	this.secure_key = "";

	this.deleted = false;

	this.passwd = "";

	this.lastname = "";

	this.firstname = "";

	this.email = "";

	this.id_gender = 0;

	this.birthday = "";

	this.newsletter = 0;

	this.optin = 0;

	this.website = "";

	this.company = "";

	this.siret = "";

	this.ape = "";

	this.outstanding_allow_amount = new Double();

	this.show_public_prices = false;

	this.id_risk = 0;

	this.max_payment_days = 0;

	this.active = false;

	this.note = "";

	this.is_guest = false;

	this.id_shop = 0;

	this.date_add = "";

	this.date_upd = "";

	this.reset_password_token = "";

	this.reset_password_validity = "";

	this.PrestaShopAssociations = new PrestaShopAssociations();

}

 PrestaShopCustomizationIn = function () { 
	this.id_product_attribute = 0;

	this.id_address_delivery = 0;

	this.id_cart = 0;

	this.id_product = 0;

	this.quantity = 0;

	this.quantity_refunded = 0;

	this.quantity_returned = 0;

	this.in_cart = false;

}

 PrestaShopCustomization = function () { 
	this.id = 0;

	this.id_product_attribute = 0;

	this.id_address_delivery = 0;

	this.id_cart = 0;

	this.id_product = 0;

	this.quantity = 0;

	this.quantity_refunded = 0;

	this.quantity_returned = 0;

	this.in_cart = false;

}

 PrestaShopDeliveryIn = function () { 
	this.id_carrier = 0;

	this.id_range_price = 0;

	this.id_range_weight = 0;

	this.id_zone = 0;

	this.id_shop = 0;

	this.id_shop_group = 0;

	this.price = new Single();

}

 PrestaShopDelivery = function () { 
	this.id = 0;

	this.id_carrier = 0;

	this.id_range_price = 0;

	this.id_range_weight = 0;

	this.id_zone = 0;

	this.id_shop = 0;

	this.id_shop_group = 0;

	this.price = new Single();

}

 PrestaShopEmployeeIn = function () { 
	this.id_lang = 0;

	this.last_passwd_gen = "";

	this.stats_date_from = "";

	this.stats_date_to = "";

	this.stats_compare_from = "";

	this.stats_compare_to = "";

	this.passwd = "";

	this.lastname = "";

	this.firstname = "";

	this.email = "";

	this.active = false;

	this.optin = false;

	this.id_profile = 0;

	this.bo_color = "";

	this.default_tab = 0;

	this.bo_theme = "";

	this.bo_css = "";

	this.bo_width = 0;

	this.bo_menu = false;

	this.stats_compare_option = 0;

	this.preselect_date_range = "";

	this.id_last_order = 0;

	this.id_last_customer_message = 0;

	this.id_last_customer = 0;

	this.reset_password_token = "";

	this.reset_password_validity = "";

}

 PrestaShopEmployee = function () { 
	this.id = 0;

	this.id_lang = 0;

	this.last_passwd_gen = "";

	this.stats_date_from = "";

	this.stats_date_to = "";

	this.stats_compare_from = "";

	this.stats_compare_to = "";

	this.passwd = "";

	this.lastname = "";

	this.firstname = "";

	this.email = "";

	this.active = false;

	this.optin = false;

	this.id_profile = 0;

	this.bo_color = "";

	this.default_tab = 0;

	this.bo_theme = "";

	this.bo_css = "";

	this.bo_width = 0;

	this.bo_menu = false;

	this.stats_compare_option = 0;

	this.preselect_date_range = "";

	this.id_last_order = 0;

	this.id_last_customer_message = 0;

	this.id_last_customer = 0;

	this.reset_password_token = "";

	this.reset_password_validity = "";

}

 PrestaShopGroupIn = function () { 
	this.reduction = new Single();

	this.price_display_method = false;

	this.show_prices = false;

	this.date_add = "";

	this.date_upd = "";

	this.name = "";

}

 PrestaShopGroup = function () { 
	this.id = 0;

	this.reduction = new Single();

	this.price_display_method = false;

	this.show_prices = false;

	this.date_add = "";

	this.date_upd = "";

	this.name = "";

}

 PrestaShopGuestIn = function () { 
	this.id_customer = 0;

	this.id_operating_system = 0;

	this.id_web_browser = 0;

	this.javascript = false;

	this.screen_resolution_x = 0;

	this.screen_resolution_y = 0;

	this.screen_color = 0;

	this.sun_java = false;

	this.adobe_flash = false;

	this.adobe_director = false;

	this.apple_quicktime = false;

	this.real_player = false;

	this.windows_media = false;

	this.accept_language = "";

	this.mobile_theme = false;

}

 PrestaShopGuest = function () { 
	this.id = 0;

	this.id_customer = 0;

	this.id_operating_system = 0;

	this.id_web_browser = 0;

	this.javascript = false;

	this.screen_resolution_x = 0;

	this.screen_resolution_y = 0;

	this.screen_color = 0;

	this.sun_java = false;

	this.adobe_flash = false;

	this.adobe_director = false;

	this.apple_quicktime = false;

	this.real_player = false;

	this.windows_media = false;

	this.accept_language = "";

	this.mobile_theme = false;

}

 PrestaShopImageTypeIn = function () { 
	this.name = "";

	this.width = 0;

	this.height = 0;

	this.categories = false;

	this.products = false;

	this.manufacturers = false;

	this.suppliers = false;

	this.stores = false;

}

 PrestaShopImageType = function () { 
	this.id = 0;

	this.name = "";

	this.width = 0;

	this.height = 0;

	this.categories = false;

	this.products = false;

	this.manufacturers = false;

	this.suppliers = false;

	this.stores = false;

}

 PrestaShopImageIn = function () { 
	this.id_product = 0;

	this.position = 0;

	this.cover = false;

	this.legend = "";

}

 PrestaShopImage = function () { 
	this.id = 0;

	this.id_product = 0;

	this.position = 0;

	this.cover = false;

	this.legend = "";

}

 PrestaShopLanguageIn = function () { 
	this.name = "";

	this.iso_code = "";

	this.locale = "";

	this.language_code = "";

	this.active = false;

	this.is_rtl = false;

	this.date_format_lite = "";

	this.date_format_full = "";

}

/**
 * Implementation class for PrestaShop 'addresses'. Can be used when add new address. 
 * @typedef {Object} PrestaShopAddressIn
 */
 PrestaShopAddressIn = function () { 
	/**
	 * The identifier customer wich belongs to.
	 * @type {Int32}
	 */
	this.id_customer = 0;

	/**
	 * The identifier manufacturer wich belongs to.
	 * @type {Int32}
	 */
	this.id_manufacturer = 0;

	/**
	 * The identifier supplier wich belongs to.
	 * @type {Int32}
	 */
	this.id_supplier = 0;

	/**
	 * The identifier warehouse wich belongs to.
	 * @type {Int32}
	 */
	this.id_warehouse = 0;

	/**
	 * The identifier country wich belongs to.
	 * @type {Int32}
	 */
	this.id_country = 0;

	/**
	 * The identifier state wich belongs to.
	 * @type {Int32}
	 */
	this.id_state = 0;

	/**
	 * The alias. (eg. Home, Work...)
	 * @type {string}
	 */
	this.alias = "";

	/**
	 * The company. (Optional)
	 * @type {string}
	 */
	this.company = "";

	/**
	 * The last name.
	 * @type {string}
	 */
	this.lastname = "";

	/**
	 * The first name.
	 * @type {string}
	 */
	this.firstname = "";

	/**
	 * The vat number.
	 * @type {string}
	 */
	this.vat_number = "";

	/**
	 * The first address.
	 * @type {string}
	 */
	this.address1 = "";

	/**
	 * The second address. (Optional)
	 * @type {string}
	 */
	this.address2 = "";

	/**
	 * The postal code.
	 * @type {Int32}
	 */
	this.postcode = 0;

	/**
	 * The city name.
	 * @type {string}
	 */
	this.city = "";

	/**
	 * Other useful information.
	 * @type {string}
	 */
	this.other = "";

	/**
	 * The phone number.
	 * @type {string}
	 */
	this.phone = "";

	/**
	 * The mobile phone number.
	 * @type {string}
	 */
	this.phone_mobile = "";

	/**
	 * The dni number.
	 * @type {string}
	 */
	this.dni = "";

}

/**
 * Implementation class for PrestaShop 'address'. Used when need get information about address. 
 * @typedef {Object} PrestaShopAddress
 */
 PrestaShopAddress = function () { 
	/**
	 * The address identifier.
	 * @type {Int32}
	 */
	this.id = 0;

	/**
	 * The identifier manufacturer wich belongs to.
	 * @type {Int32}
	 */
	this.id_manufacturer = 0;

	/**
	 * The identifier supplier wich belongs to.
	 * @type {Int32}
	 */
	this.id_supplier = 0;

	/**
	 * The identifier warehouse wich belongs to.
	 * @type {Int32}
	 */
	this.id_warehouse = 0;

	/**
	 * The identifier country wich belongs to.
	 * @type {Int32}
	 */
	this.id_country = 0;

	/**
	 * The identifier state wich belongs to.
	 * @type {Int32}
	 */
	this.id_state = 0;

	/**
	 * The alias. (eg. Home, Work...)
	 * @type {string}
	 */
	this.alias = "";

	/**
	 * The company. (Optional)
	 * @type {string}
	 */
	this.company = "";

	/**
	 * The last name.
	 * @type {string}
	 */
	this.lastname = "";

	/**
	 * The first name.
	 * @type {string}
	 */
	this.firstname = "";

	/**
	 * The vat number.
	 * @type {string}
	 */
	this.vat_number = "";

	/**
	 * The first address.
	 * @type {string}
	 */
	this.address1 = "";

	/**
	 * The second address. (Optional)
	 * @type {string}
	 */
	this.address2 = "";

	/**
	 * The postal code.
	 * @type {Int32}
	 */
	this.postcode = 0;

	/**
	 * The city name.
	 * @type {string}
	 */
	this.city = "";

	/**
	 * Other useful information.
	 * @type {string}
	 */
	this.other = "";

	/**
	 * The phone number.
	 * @type {string}
	 */
	this.phone = "";

	/**
	 * The mobile phone number.
	 * @type {string}
	 */
	this.phone_mobile = "";

	/**
	 * The dni number.
	 * @type {string}
	 */
	this.dni = "";

	/**
	 * True if address has been deleted (staying in database as deleted).
	 * @type {Boolean}
	 */
	this.deleted = false;

	/**
	 * When address was added.
	 * @type {string}
	 */
	this.date_add = "";

	/**
	 * When address was updated.
	 * @type {string}
	 */
	this.date_upd = "";

}

/**
 * Implementation for PrestaShop 'carriers'. Can be used when add new carrier. 
 * @typedef {Object} PrestaShopCarrierIn
 */
 PrestaShopCarrierIn = function () { 
	/**
	 * The identifier tax rules group.
	 * @type {Int32}
	 */
	this.id_tax_rules_group = 0;

	/**
	 * The carrier name. (Max: 64 characters)
	 * @type {string}
	 */
	this.name = "";

	/**
	 * Carrier module.
	 * @type {Boolean}
	 */
	this.is_module = false;

	/**
	 * Carrier statuts.
	 * @type {Boolean}
	 */
	this.active = false;

	/**
	 * Free carrier.
	 * @type {Boolean}
	 */
	this.is_free = false;

	/**
	 * URL with a '@'.
	 * @type {string}
	 */
	this.url = "";

	/**
	 * True active the shipping handling
	 * @type {Int32}
	 */
	this.shipping_handling = 0;

	/**
	 * Shipping external.
	 * @type {Int32}
	 */
	this.shipping_external = 0;

	/**
	 * Behavior taken for unknown range.
	 * @type {Int32}
	 */
	this.range_behavior = 0;

	/**
	 * Shipping behavior: 0 - by weight or 1 - by price.
	 * @type {Int32}
	 */
	this.shipping_method = 0;

	/**
	 * The maximum package width managed by the transporter.
	 * @type {Int32}
	 */
	this.max_width = 0;

	/**
	 * The maximum package height managed by the transporter.
	 * @type {Int32}
	 */
	this.max_height = 0;

	/**
	 * The maximum package deep managed by the transporter.
	 * @type {Int32}
	 */
	this.max_depth = 0;

	/**
	 * The maximum package weight managed by the transporter.
	 * @type {Single}
	 */
	this.max_weight = new Single();

	/**
	 * Grade of the shipping delay (0 for longest, 9 for shortest).
	 * @type {Int32}
	 */
	this.grade = 0;

	/**
	 * The name of the external module.
	 * @type {string}
	 */
	this.external_module_name = "";

	/**
	 * Need range.
	 * @type {Int32}
	 */
	this.need_range = 0;

	/**
	 * The position.
	 * @type {Int32}
	 */
	this.position = 0;

	/**
	 * Delay needed to deliver customer. (Max: 512 characters)
	 * @type {string}
	 */
	this.delay = "";

}

/**
 * Implementation for PrestaShop 'carriers'. Used when need get information about carrier. 
 * @typedef {Object} PrestaShopCarrier
 */
 PrestaShopCarrier = function () { 
	/**
	 * The carrier identifier.
	 * @type {Int32}
	 */
	this.id = 0;

	/**
	 * True if carrier has been deleted (staying in database as deleted)
	 * @type {Boolean}
	 */
	this.deleted = false;

	/**
	 * The identifier tax rules group.
	 * @type {Int32}
	 */
	this.id_tax_rules_group = 0;

	/**
	 * Common id for carrier historization.
	 * @type {Int32}
	 */
	this.id_reference = 0;

	/**
	 * The carrier name.
	 * @type {string}
	 */
	this.name = "";

	/**
	 * Carrier module.
	 * @type {Boolean}
	 */
	this.is_module = false;

	/**
	 * Carrier statuts.
	 * @type {Boolean}
	 */
	this.active = false;

	/**
	 * Free carrier.
	 * @type {Boolean}
	 */
	this.is_free = false;

	/**
	 * URL with a '@'.
	 * @type {string}
	 */
	this.url = "";

	/**
	 * Active or not the shipping handling
	 * @type {Int32}
	 */
	this.shipping_handling = 0;

	/**
	 * Shipping external.
	 * @type {Int32}
	 */
	this.shipping_external = 0;

	/**
	 * Behavior taken for unknown range.
	 * @type {Int32}
	 */
	this.range_behavior = 0;

	/**
	 * Shipping behavior: 0 - by weight or 1 - by price.
	 * @type {Int32}
	 */
	this.shipping_method = 0;

	/**
	 * The maximum package width managed by the transporter.
	 * @type {Int32}
	 */
	this.max_width = 0;

	/**
	 * The maximum package height managed by the transporter.
	 * @type {Int32}
	 */
	this.max_height = 0;

	/**
	 * The maximum package deep managed by the transporter.
	 * @type {Int32}
	 */
	this.max_depth = 0;

	/**
	 * The maximum package weight managed by the transporter.
	 * @type {Single}
	 */
	this.max_weight = new Single();

	/**
	 * Grade of the shipping delay (0 for longest, 9 for shortest).
	 * @type {Int32}
	 */
	this.grade = 0;

	/**
	 * The name of the external module.
	 * @type {string}
	 */
	this.external_module_name = "";

	/**
	 * Need range.
	 * @type {Int32}
	 */
	this.need_range = 0;

	/**
	 * The position.
	 * @type {Int32}
	 */
	this.position = 0;

	/**
	 * Delay needed to deliver customer.
	 * @type {string}
	 */
	this.delay = "";

}

/**
 * Implementation class for PrestaShop 'cart rules'. Can be used when add new cart rule (voucher). 
 * @typedef {Object} PrestaShopCartRuleIn
 */
 PrestaShopCartRuleIn = function () { 
	/**
	 * The name of cart rule.
	 * @type {string}
	 */
	this.name = "";

	/**
	 * The customer identifier. (Limit for single customer, set zero if doesn't need.)
	 * @type {Int32}
	 */
	this.id_customer = 0;

	/**
	 * When cart rule is valid from date. (Format: Y-m-d 00:00:00)
	 * @type {string}
	 */
	this.date_from = "";

	/**
	 * When cart rule is valid to date. (Format: Y-m-d 00:00:00)
	 * @type {string}
	 */
	this.date_to = "";

	/**
	 * Description about cart rule. (Max:65534 characters.)
	 * @type {string}
	 */
	this.description = "";

	/**
	 * The count of avaibles voucher for customer.
	 * @type {Int32}
	 */
	this.quantity = 0;

	/**
	 * The count of avaibles voucher for every customer.
	 * @type {Int32}
	 */
	this.quantity_per_user = 0;

	/**
	 * If applied higher number, the voucher will applied after vouchers with lower number.
	 * @type {Int32}
	 */
	this.priority = 0;

	/**
	 * If true voucher can be used once.
	 * @type {Boolean}
	 */
	this.partial_use = false;

	/**
	 * The code for applying the voucher to customers when ordering process. (Max:254 characters.)
	 * @type {string}
	 */
	this.code = "";

	/**
	 * The minimum order amount(with tax included) from which voucher is applicable.
	 * @type {Single}
	 */
	this.minimum_amount = new Single();

	/**
	 * If true, tax will included.
	 * @type {Boolean}
	 */
	this.minimum_amount_tax = false;

	/**
	 * The currency identifier.
	 * @type {Int32}
	 */
	this.minimum_amount_currency = 0;

	/**
	 * If true, the shipping will used.
	 * @type {Boolean}
	 */
	this.minimum_amount_shipping = false;

	/**
	 * If true voucher applicable to customers from a specific country who not restricted.
	 * @type {Boolean}
	 */
	this.country_restriction = false;

	/**
	 * If true voucher applicable for a specific carrier who not restricted.
	 * @type {Boolean}
	 */
	this.carrier_restriction = false;

	/**
	 * If true voucher applicable to customers with a specific group who not restricted.
	 * @type {Boolean}
	 */
	this.group_restriction = false;

	/**
	 * If true voucher applicable for a specific cart rule who not restricted.
	 * @type {Boolean}
	 */
	this.cart_rule_restriction = false;

	/**
	 * If true voucher applicable for a specific product who not restricted.
	 * @type {Boolean}
	 */
	this.product_restriction = false;

	/**
	 * If true voucher applicable for a specific shop who not restricted.
	 * @type {Boolean}
	 */
	this.shop_restriction = false;

	/**
	 * If true, free shipping for benefiting customers.
	 * @type {Boolean}
	 */
	this.free_shipping = false;

	/**
	 * A percentage of the order total.
	 * @type {Single}
	 */
	this.reduction_percent = new Single();

	/**
	 * A monetary discount on the order total.
	 * @type {Single}
	 */
	this.reduction_amount = new Single();

	/**
	 * If true, will tax will included.
	 * @type {Boolean}
	 */
	this.reduction_tax = false;

	/**
	 * The currency identifier.
	 * @type {Int32}
	 */
	this.reduction_currency = 0;

	/**
	 * The product identifier for which apply reduction.
	 * @type {Int32}
	 */
	this.reduction_product = 0;

	/**
	 * If true, exclude special reduction.
	 * @type {Boolean}
	 */
	this.reduction_exclude_special = false;

	/**
	 * The product identifier.
	 * @type {Int32}
	 */
	this.gift_product = 0;

	/**
	 * The product attribute identifier.
	 * @type {Int32}
	 */
	this.gift_product_attribute = 0;

	/**
	 * If true, it will let the user know that a voucher is available.
	 * @type {Boolean}
	 */
	this.highlight = false;

	/**
	 * True activate cart rule.
	 * @type {Boolean}
	 */
	this.active = false;

}

/**
 * Implementation class for PrestaShop 'cart rules'. Used for get information about cart rule (voucher). 
 * @typedef {Object} PrestaShopCartRule
 */
 PrestaShopCartRule = function () { 
	/**
	 * The cart rule identifier.
	 * @type {Int32}
	 */
	this.id = 0;

	/**
	 * The name of cart rule.
	 * @type {string}
	 */
	this.name = "";

	/**
	 * The customer identifier. (Limit for single customer, set zero if doesn't need.)
	 * @type {Int32}
	 */
	this.id_customer = 0;

	/**
	 * When cart rule is valid from date. (Format: Y-m-d 00:00:00)
	 * @type {string}
	 */
	this.date_from = "";

	/**
	 * When cart rule is valid to date. (Format: Y-m-d 00:00:00)
	 * @type {string}
	 */
	this.date_to = "";

	/**
	 * Description about cart rule.
	 * @type {string}
	 */
	this.description = "";

	/**
	 * The count of avaibles voucher for customer.
	 * @type {Int32}
	 */
	this.quantity = 0;

	/**
	 * The count of avaibles voucher for every customer.
	 * @type {Int32}
	 */
	this.quantity_per_user = 0;

	/**
	 * If applied higher number, the voucher will applied after vouchers with lower number.
	 * @type {Int32}
	 */
	this.priority = 0;

	/**
	 * If true voucher can be used once.
	 * @type {Boolean}
	 */
	this.partial_use = false;

	/**
	 * The code for applying the voucher to customers when ordering process.
	 * @type {string}
	 */
	this.code = "";

	/**
	 * The minimum order amount(with tax included) from which voucher is applicable.
	 * @type {Single}
	 */
	this.minimum_amount = new Single();

	/**
	 * If true, tax will included.
	 * @type {Boolean}
	 */
	this.minimum_amount_tax = false;

	/**
	 * The currency identifier.
	 * @type {Int32}
	 */
	this.minimum_amount_currency = 0;

	/**
	 * If true, the shipping will used.
	 * @type {Boolean}
	 */
	this.minimum_amount_shipping = false;

	/**
	 * If true voucher applicable to customers from a specific country who not restricted.
	 * @type {Boolean}
	 */
	this.country_restriction = false;

	/**
	 * If true voucher applicable for a specific carrier who not restricted.
	 * @type {Boolean}
	 */
	this.carrier_restriction = false;

	/**
	 * If true voucher applicable to customers with a specific group who not restricted.
	 * @type {Boolean}
	 */
	this.group_restriction = false;

	/**
	 * If true voucher applicable for a specific cart rule who not restricted.
	 * @type {Boolean}
	 */
	this.cart_rule_restriction = false;

	/**
	 * If true voucher applicable for a specific product who not restricted.
	 * @type {Boolean}
	 */
	this.product_restriction = false;

	/**
	 * If true voucher applicable for a specific shop who not restricted.
	 * @type {Boolean}
	 */
	this.shop_restriction = false;

	/**
	 * If true, free shipping for benefiting customers.
	 * @type {Boolean}
	 */
	this.free_shipping = false;

	/**
	 * A percentage of the order total.
	 * @type {Single}
	 */
	this.reduction_percent = new Single();

	/**
	 * A monetary discount on the order total.
	 * @type {Single}
	 */
	this.reduction_amount = new Single();

	/**
	 * If true, will tax will included.
	 * @type {Boolean}
	 */
	this.reduction_tax = false;

	/**
	 * The currency identifier.
	 * @type {Int32}
	 */
	this.reduction_currency = 0;

	/**
	 * The product identifier for which apply reduction.
	 * @type {Int32}
	 */
	this.reduction_product = 0;

	/**
	 * If true, exclude special reduction.
	 * @type {Boolean}
	 */
	this.reduction_exclude_special = false;

	/**
	 * The product identifier.
	 * @type {Int32}
	 */
	this.gift_product = 0;

	/**
	 * The product attribute identifier.
	 * @type {Int32}
	 */
	this.gift_product_attribute = 0;

	/**
	 * If true, it will let the user know that a voucher is available.
	 * @type {Boolean}
	 */
	this.highlight = false;

	/**
	 * True activate cart rule.
	 * @type {Boolean}
	 */
	this.active = false;

	/**
	 * When added.
	 * @type {string}
	 */
	this.date_add = "";

	/**
	 * When updated.
	 * @type {string}
	 */
	this.date_upd = "";

}

/**
 * Implementation class for PrestaShop 'carts'.  Can be used when add new cart for customer. 
 * @typedef {Object} PrestaShopCartIn
 */
 PrestaShopCartIn = function () { 
	/**
	 * Customer delivery address identifier.
	 * @type {Int32}
	 */
	this.id_address_delivery = 0;

	/**
	 * Customer invoicing address identifier.
	 * @type {Int32}
	 */
	this.id_address_invoice = 0;

	/**
	 * Customer currency identifier.
	 * @type {Int32}
	 */
	this.id_currency = 0;

	/**
	 * Customer identifier.
	 * @type {Int32}
	 */
	this.id_customer = 0;

	/**
	 * Guest identifier.
	 * @type {Int32}
	 */
	this.id_guest = 0;

	/**
	 * Language identifier.
	 * @type {Int32}
	 */
	this.id_lang = 0;

	/**
	 * Carrier identifier.
	 * @type {Int32}
	 */
	this.id_carrier = 0;

	/**
	 * True if the customer wants a recycled package.
	 * @type {Boolean}
	 */
	this.recyclable = false;

	/**
	 * True if the customer wants a gift wrapping.
	 * @type {Boolean}
	 */
	this.gift = false;

	/**
	 * Gift message if specified.
	 * @type {string}
	 */
	this.gift_message = "";

	/**
	 * True if use mobile theme.
	 * @type {Boolean}
	 */
	this.mobile_theme = false;

	/**
	 * The secure key. (Max:32 characters.)
	 * @type {string}
	 */
	this.secure_key = "";

	/**
	 * True if allow seperated package.
	 * @type {Boolean}
	 */
	this.allow_seperated_package = false;

}

/**
 * Implementation class for PrestaShop 'cart'. Used when need get information about customer cart. 
 * @typedef {Object} PrestaShopCart
 */
 PrestaShopCart = function () { 
	/**
	 * Customer delivery address identifier.
	 * @type {Int32}
	 */
	this.id_address_delivery = 0;

	/**
	 * Customer invoicing address identifier.
	 * @type {Int32}
	 */
	this.id_address_invoice = 0;

	/**
	 * Customer currency identifier.
	 * @type {Int32}
	 */
	this.id_currency = 0;

	/**
	 * Customer identifier.
	 * @type {Int32}
	 */
	this.id_customer = 0;

	/**
	 * Guest identifier.
	 * @type {Int32}
	 */
	this.id_guest = 0;

	/**
	 * Language identifier.
	 * @type {Int32}
	 */
	this.id_lang = 0;

	/**
	 * Carrier identifier.
	 * @type {Int32}
	 */
	this.id_carrier = 0;

	/**
	 * The shop group identifier.
	 * @type {Int32}
	 */
	this.id_shop_group = 0;

	/**
	 * The shop identifier.
	 * @type {Int32}
	 */
	this.id_shop = 0;

	/**
	 * True if the customer wants a recycled package.
	 * @type {Boolean}
	 */
	this.recyclable = false;

	/**
	 * True if the customer wants a gift wrapping.
	 * @type {Boolean}
	 */
	this.gift = false;

	/**
	 * Gift message if specified.
	 * @type {string}
	 */
	this.gift_message = "";

	/**
	 * True if use mobile theme.
	 * @type {Boolean}
	 */
	this.mobile_theme = false;

	/**
	 * The secure key. (Max:32 characters.)
	 * @type {string}
	 */
	this.secure_key = "";

	/**
	 * True if allow seperated package.
	 * @type {Boolean}
	 */
	this.allow_seperated_package = false;

	/**
	 * The delivery option.
	 * @type {string}
	 */
	this.delivery_option = "";

	/**
	 * When cart added.
	 * @type {string}
	 */
	this.date_add = "";

	/**
	 * When cart updated.
	 * @type {string}
	 */
	this.date_upd = "";

}

/**
 * Implementation class for PrestaShop 'category'. Can be used when add new category. 
 * @typedef {Object} PrestaShopCategoryIn
 */
 PrestaShopCategoryIn = function () { 
	/**
	 * The category parent identfier. (Set zero if no parent)
	 * @type {Int32}
	 */
	this.id_parent = 0;

	/**
	 * Parents number.
	 * @type {Int32}
	 */
	this.level_depth = 0;

	/**
	 * True display category.
	 * @type {Boolean}
	 */
	this.active = false;

	/**
	 * The identifier default shop.
	 * @type {Int32}
	 */
	this.id_shop_default = 0;

	/**
	 * True set category to root.
	 * @type {Boolean}
	 */
	this.is_root_category = false;

	/**
	 * Category position.
	 * @type {Int32}
	 */
	this.position = 0;

	/**
	 * The name of category. (Max: 128 characters.)
	 * @type {string}
	 */
	this.name = "";

	/**
	 * Used in rewrited URL. (Max: 128 characters.)
	 * @type {string}
	 */
	this.link_rewrite = "";

	/**
	 * The description of category.
	 * @type {string}
	 */
	this.description = "";

	/**
	 * The category meta title. (Max: 128 characters.)
	 * @type {string}
	 */
	this.meta_title = "";

	/**
	 * The category meta description. (Max: 255 characters.)
	 * @type {string}
	 */
	this.meta_description = "";

	/**
	 * The category meta keywords. (Max: 255 characters.)
	 * @type {string}
	 */
	this.meta_keywords = "";

}

/**
 * Implementation class for PrestaShop 'category'. Used when need get information about category. 
 * @typedef {Object} PrestaShopCategory
 */
 PrestaShopCategory = function () { 
	/**
	 * The category identifier.
	 * @type {Int32}
	 */
	this.id = 0;

	/**
	 * The category parent identfier. (Set zero if no parent)
	 * @type {Int32}
	 */
	this.id_parent = 0;

	/**
	 * Parents number.
	 * @type {Int32}
	 */
	this.level_depth = 0;

	/**
	 * True display category.
	 * @type {Boolean}
	 */
	this.active = false;

	/**
	 * The identifier default shop.
	 * @type {Int32}
	 */
	this.id_shop_default = 0;

	/**
	 * True set category to root.
	 * @type {Boolean}
	 */
	this.is_root_category = false;

	/**
	 * Category position.
	 * @type {Int32}
	 */
	this.position = 0;

	/**
	 * The bame of category.
	 * @type {string}
	 */
	this.name = "";

	/**
	 * Used in rewrited URL.
	 * @type {string}
	 */
	this.link_rewrite = "";

	/**
	 * The description of category.
	 * @type {string}
	 */
	this.description = "";

	/**
	 * The category meta title.
	 * @type {string}
	 */
	this.meta_title = "";

	/**
	 * The category meta description.
	 * @type {string}
	 */
	this.meta_description = "";

	/**
	 * The category meta keywords.
	 * @type {string}
	 */
	this.meta_keywords = "";

	/**
	 * When added.
	 * @type {string}
	 */
	this.date_add = "";

	/**
	 * When updated.
	 * @type {string}
	 */
	this.date_upd = "";

}

/**
 * Implementation class for PrestaShop 'combination'. Can be used whe add new combination. 
 * @typedef {Object} PrestaShopCombinationIn
 */
 PrestaShopCombinationIn = function () { 
	/**
	 * The product identifier. (Required)
	 * @type {Int32}
	 */
	this.id_product = 0;

	/**
	 * The location. (Max: 64 characters.)
	 * @type {string}
	 */
	this.location = "";

	/**
	 * The ean13 product code. (Max: 13 characters.)
	 * @type {string}
	 */
	this.ean13 = "";

	/**
	 * The isbn product code. (Max: 32 characters.)
	 * @type {string}
	 */
	this.isbn = "";

	/**
	 * The upc product code. (Max: 12 characters.)
	 * @type {string}
	 */
	this.upc = "";

	/**
	 * The reference to product. (Max: 32 characters.)
	 * @type {string}
	 */
	this.reference = "";

	/**
	 * The reference to supplier. (Max: 32 characters.)
	 * @type {string}
	 */
	this.supplier_reference = "";

	/**
	 * The wholesale price.(Max: 27 characters.)
	 * @type {Single}
	 */
	this.wholesale_price = new Single();

	/**
	 * The product price.(Max: 20 characters.)
	 * @type {Single}
	 */
	this.price = new Single();

	/**
	 * The eco-tax.(Max: 20 characters.)
	 * @type {Single}
	 */
	this.ecotax = new Single();

	/**
	 * Product weight.
	 * @type {Single}
	 */
	this.weight = new Single();

	/**
	 * Unit price impact. (Max: 20 characters.)
	 * @type {Single}
	 */
	this.unit_price_impact = new Single();

	/**
	 * The minimal quantity. (Required)
	 * @type {Int32}
	 */
	this.minimal_quantity = 0;

	/**
	 * True combination default on.
	 * @type {Nullable<Boolean>}
	 */
	this.default_on = false;

	/**
	 * When product avaible. (Format: Y-m-d)
	 * @type {string}
	 */
	this.available_date = "";

	/**
	 * The product which is associated with the category.
	 * @type {PrestaShopAssociations}
	 */
	this.associations = new PrestaShopAssociations();

}

/**
 * Implementation class for PrestaShop 'combination'. Used when get information about combination. 
 * @typedef {Object} PrestaShopCombination
 */
 PrestaShopCombination = function () { 
	/**
	 * The combination identifier.
	 * @type {Int32}
	 */
	this.id = 0;

	/**
	 * The product identifier. (Required)
	 * @type {Int32}
	 */
	this.id_product = 0;

	/**
	 * The location. (Max: 64 characters.)
	 * @type {string}
	 */
	this.location = "";

	/**
	 * The ean13 product code. (Max: 13 characters.)
	 * @type {string}
	 */
	this.ean13 = "";

	/**
	 * The isbn product code. (Max: 32 characters.)
	 * @type {string}
	 */
	this.isbn = "";

	/**
	 * The upc product code. (Max: 12 characters.)
	 * @type {string}
	 */
	this.upc = "";

	/**
	 * The reference to product. (Max: 32 characters.)
	 * @type {string}
	 */
	this.reference = "";

	/**
	 * The reference to supplier. (Max: 32 characters.)
	 * @type {string}
	 */
	this.supplier_reference = "";

	/**
	 * The wholesale price.(Max: 27 characters.)
	 * @type {Single}
	 */
	this.wholesale_price = new Single();

	/**
	 * The product price.(Max: 20 characters.)
	 * @type {Single}
	 */
	this.price = new Single();

	/**
	 * The eco-tax.(Max: 20 characters.)
	 * @type {Single}
	 */
	this.ecotax = new Single();

	/**
	 * Product weight.
	 * @type {Single}
	 */
	this.weight = new Single();

	/**
	 * Unit price impact. (Max: 20 characters.)
	 * @type {Single}
	 */
	this.unit_price_impact = new Single();

	/**
	 * The minimal quantity. (Required)
	 * @type {Int32}
	 */
	this.minimal_quantity = 0;

	/**
	 * True combination default on.
	 * @type {Nullable<Boolean>}
	 */
	this.default_on = false;

	/**
	 * When product avaible. (Format: Y-m-d)
	 * @type {string}
	 */
	this.available_date = "";

	/**
	 * The product which is associated with the category.
	 * @type {PrestaShopAssociations}
	 */
	this.associations = new PrestaShopAssociations();

}

/**
 * Implemention class for PrestaShop 'configuration'. Can be used when add new configuration. 
 * @typedef {Object} PrestaShopConfigurationIn
 */
 PrestaShopConfigurationIn = function () { 
	this.value = "";

	this.name = "";

	this.id_shop_group = 0;

	this.id_shop = 0;

}

 PrestaShopConfiguration = function () { 
	this.id = 0;

	this.value = "";

	this.name = "";

	this.id_shop_group = 0;

	this.id_shop = 0;

	this.date_add = "";

	this.date_upd = "";

}

 PrestaShopContactIn = function () { 
	this.email = "";

	this.customer_service = 0;

	this.name = "";

	this.description = "";

}

 PrestaShopContact = function () { 
	this.id = 0;

	this.email = "";

	this.customer_service = 0;

	this.name = "";

	this.description = "";

}

 PrestaShopContentManagementSystemIn = function () { 
	this.id_cms = 0;

	this.meta_title = "";

	this.meta_description = "";

	this.meta_keywords = "";

	this.content = "";

	this.link_rewrite = "";

	this.id_cms_category = 0;

	this.position = 0;

	this.indexation = false;

	this.active = false;

}

 PrestaShopContentManagementSystem = function () { 
	this.id = 0;

	this.id_cms = 0;

	this.meta_title = "";

	this.meta_description = "";

	this.meta_keywords = "";

	this.content = "";

	this.link_rewrite = "";

	this.id_cms_category = 0;

	this.position = 0;

	this.indexation = false;

	this.active = false;

}

 PrestaShopCountryIn = function () { 
	this.id_zone = 0;

	this.id_currency = 0;

	this.call_prefix = 0;

	this.iso_code = "";

	this.active = false;

	this.contains_states = false;

	this.need_identification_number = false;

	this.need_zip_code = "";

	this.zip_code_format = "";

	this.display_tax_label = false;

	this.name = "";

}

 PrestaShopCountry = function () { 
	this.id = 0;

	this.id_zone = 0;

	this.id_currency = 0;

	this.call_prefix = 0;

	this.iso_code = "";

	this.active = false;

	this.contains_states = false;

	this.need_identification_number = false;

	this.need_zip_code = "";

	this.zip_code_format = "";

	this.display_tax_label = false;

	this.name = "";

}

 PrestaShopCurrencyIn = function () { 
	this.name = "";

	this.iso_code = "";

	this.conversion_rate = new Single();

	this.deleted = false;

	this.active = false;

}

