package bNesis.Api.Services.Clients.Managers.Remote.Api;

import bNesis.Api.Common.*;
import bNesis.Api.Services.Clients.Remote.Api.RemoteApiServiceClient; 

public class RemoteApiServiceClientsManager{
	private String bNesisApiUrl = "";
    private String ServiceClientsManagerContollerPath = "api/ServiceClientsManager/";

	public RemoteApiServiceClientsManager(String bNesisApiUrl){
		this.bNesisApiUrl = bNesisApiUrl;
	}

    /**
     * Gets information about presence of a client with given service ID.
     * @param {string} serviceId - The unique identifier of the client.
     * @returns {boolean} <c>true</c> if the client exists, <c>false</c>
     */
     public Boolean ClientExists(String serviceId) {
        String callUrl = ServiceClientsManagerContollerPath + "ClientExists?serviceId=" + serviceId; //encodeURIComponent(serviceId);
		//WebUtils httpClient = new WebUtils();
		boolean result = false;
		try {
			result = WebUtils.<Boolean>Get(Boolean.class, this.bNesisApiUrl + callUrl);
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
        return result;
    }
     
     /**
      * Creates new instance of RemoteApiServiceClient which will call remote API on a local call.
      * @param {string} serviceId - ID of the service client to which should be created.
      * @returns {IServiceClient} Instance which implements IServiceClient.
      */
      public RemoteApiServiceClient CreateClient(String serviceId) {
    	  RemoteApiServiceClient result = new RemoteApiServiceClient();
         result.ServiceId = serviceId;
         result.bNesisApiUrl = this.bNesisApiUrl;
         return result;
     }
     

}
