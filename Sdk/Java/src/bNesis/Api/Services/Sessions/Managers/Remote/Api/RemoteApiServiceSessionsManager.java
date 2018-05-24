package bNesis.Api.Services.Sessions.Managers.Remote.Api;

import java.lang.Exception;
import java.util.Dictionary;
import java.util.Hashtable;

import bNesis.Api.Services.Auth.Providers.Managers.Remote.Api.*; 
import bNesis.Api.Services.Clients.Managers.Remote.Api.*;
import bNesis.Api.Services.Clients.Remote.Api.*;
import bNesis.Api.Services.Auth.Providers.Common.*; 

public class RemoteApiServiceSessionsManager {

		protected String bNesisApiUrl = "";

		//private Object _sessionLockObject = new Object();

		private Dictionary<String, RemoteApiServiceClient> _sessions; 
		private Dictionary<String, ProviderAuthInfo> _providerAuthInfos;
        private Dictionary<String, AuthProvider> _authProviders;

        /**
         * Gets or sets the auth providers manager for access to auth providers.
         * @value The auth providers manager.
		 */
        public RemoteApiAuthProvidersManager AuthProvidersManager;

        /**
         * Gets or sets clients manager for access to service clients.
         * @value The clients manager.
		 */
        public RemoteApiServiceClientsManager ClientsManager;


        /**
         * Initializes a new instance of the <see cref="RemoteApiServiceSessionsManager{TAuthProvider}"/> class.
         * @param {String} bNesisApiUrl URL to bNesis API web service.
		 */
        public RemoteApiServiceSessionsManager(String bNesisApiUrl)
        {
            if (bNesisApiUrl == "")
            {
                //throw new ArgumentNullException(nameof(bNesisApiUrl));
            }

            this.bNesisApiUrl = bNesisApiUrl;
            _sessions = new Hashtable<String, RemoteApiServiceClient>();
            _providerAuthInfos = new Hashtable<String, ProviderAuthInfo>();
            _authProviders = new Hashtable<String, AuthProvider>();
        }
        
        /**
         * Gets cached session or creates new one for given session key and client ID without checking and assigning ProviderAuthInfo.
         * @param sessionKey - The key of session. Can be anything which defines scope of sessions. Should be unique for a serviceId.
         * @param serviceId - The ID of service client. Needed for client creation.
         * @return RemoteApiServiceClient
         * @throws Exception ClientsManager is not assigned.
         */
        protected RemoteApiServiceClient GetSessionClientWithoutAuth(String sessionKey, String serviceId) throws Exception
        {
            if (ClientsManager == null)
            {
                //throw new Exception($"{nameof(ClientsManager)} is not assigned.");
            	throw new Exception("ClientsManager is not assigned.");
            }

            RemoteApiServiceClient result;
            
            //ock.lock();
            //lock (_sessionLockObject)
            {
            	result = _sessions.get(sessionKey);
                if (result != null)
                {
                    if (result.ServiceId != serviceId)
                    {
                        throw new Exception(
                            "Session " + sessionKey + " contains client to " + result.ServiceId + " when " + serviceId + " is requested.");
                    }

                    return result;
                }

                result = ClientsManager.CreateClient(serviceId);
                if (result == null)
                {
                    throw new Exception("Client for the session " + sessionKey + " is not created.");
                }

                _sessions.put(sessionKey, result);
            }

            return result;
        }
        
        /**
         * Gets cached session or creates new one for given session key and client ID.
         * @param sessionKey - The key of session. Can be anything which defines scope of sessions. Should be unique for a serviceId.
         * @param serviceId - The ID of service client. Needed for client creation.
         * @return RemoteApiServiceClient.
         * @throws Exception ClientsManager is not assigned or Session is not authenticated.
         */
        public RemoteApiServiceClient GetSessionClient(String sessionKey, String serviceId) throws Exception
        {
        	RemoteApiServiceClient result = GetSessionClientWithoutAuth(sessionKey, serviceId);

        	if (result == null)
            {
                //throw new NotSupportedException($"{GetType().Name} supports only {nameof(IRemoteApiServiceClient)} clients.");
        		return null;
            }

            // TODO think how to transfer this without changing of the manager interface.
            result.bNesisToken = sessionKey;
            return result;
        }
        
        /**
        * Removes the bNesis session, Provider Auth Info and Auth Provider.
        * @param bNesisToken bNesisToken.
        * @return if action is done returns true, if not false
		*/
        public Boolean RemoveSessionLocal(String bNesisToken)
        {
            try
            {
                RemoteApiServiceClient client = null;
                
                //lock (_sessionLockObject)
                {
                    //if ( _sessions.get(bNesisToken) == null) client = _sessions[bNesisToken];
					client = _sessions.get(bNesisToken);
                }
                //lock (_authInfoLockObject)
                {
                    _providerAuthInfos.remove(bNesisToken);
                }
                //lock (_sessionLockObject)
                {
                    _sessions.remove(bNesisToken);
                }
                if (client != null)
                //lock (_authProviderLockObject)
                {
                    _authProviders.remove(client.ServiceId);
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

}
