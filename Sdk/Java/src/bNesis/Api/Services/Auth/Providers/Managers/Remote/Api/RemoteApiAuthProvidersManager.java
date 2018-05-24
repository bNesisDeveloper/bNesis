package bNesis.Api.Services.Auth.Providers.Managers.Remote.Api;

//import java.io.IOException;
//import java.lang.Iterable;
//import java.util.Arrays;
import bNesis.Api.Common.*;

public class RemoteApiAuthProvidersManager{
	
    private String AuthProvidersManagerContollerPath = "api/AuthProvidersManager/";

    /*
     * Gets or sets URL to bNesis API web service (protected)
     */
    protected String _bNesisApiUrl = "";


	public RemoteApiAuthProvidersManager(String bNesisApiUrl){
		this._bNesisApiUrl = bNesisApiUrl;
	}

    /**
     * Enumerates all provider IDs available for the manager.
     * @return Set of string IDs.
	 */
    public String[] GetProviderIds()
    {            
		//System.out.println("RemoteApiAuthProvidersManager GetProviderIds");
    	String callUrl = AuthProvidersManagerContollerPath + "GetProviderIds";
		//WebUtils httpClient = new WebUtils();
        String[] result = null;
		try {
			result = WebUtils.<String[]>Get(String[].class, this._bNesisApiUrl + callUrl);
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
        return result;
    }

    /**
     * Gets information about presence of a provider with given ID.
     * @param {string} providerId - The unique identifier of the provider.
     * @return {boolean} <c>true</c> if the provider exists, <c>false</c> otherwise.
     */
	public boolean ProviderExists(String providerId){
		//System.out.println("RemoteApiAuthProvidersManager ProviderExists: " + providerId);
        String callUrl = AuthProvidersManagerContollerPath + "ProviderExists?providerId=" + providerId;  //encodeURIComponent(providerId);
		//WebUtils httpClient = new WebUtils();
		boolean result = false;
		try {
			result = WebUtils.<Boolean>Get(Boolean.class, this._bNesisApiUrl + callUrl);
		}
		catch(Exception e)
		{
		}
		return result;
	}

}
