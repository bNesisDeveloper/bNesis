package bNesis.Api;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;

import java.io.UnsupportedEncodingException;
import java.awt.Desktop;
import java.net.URI;
import java.net.URISyntaxException;
import java.net.URLEncoder;

import org.json.JSONObject;

import java.nio.charset.StandardCharsets;

import com.fasterxml.jackson.core.JsonParseException;
import com.fasterxml.jackson.databind.JsonMappingException;
import com.fasterxml.jackson.databind.ObjectMapper;

import bNesis.Api.Services.Sessions.Managers.Remote.Api.*;
import bNesis.Api.Services.Clients.Managers.Remote.Api.*;
import bNesis.Api.Services.Auth.Providers.Managers.Remote.Api.*;
import bNesis.Api.Services.Clients.Remote.Api.*;

public class bNesisApi {

	String bNesisApiUrl;

	private String _bNesisToken;

	public RemoteApiServiceSessionsManager SessionsManager;

    /**
     * Checks initialization of the API. All sub objects like SessionsManager,
     * ClientsManager, AuthProvidersManager must be properly initialized.
     * @throws Exception Is not initialized.
	 */
    private void CheckInitialization()  throws Exception
    {
		//System.out.println("bNesisApi CheckInitialization");
        if (SessionsManager.ClientsManager == null || SessionsManager.AuthProvidersManager == null)
        {
			throw new Exception( getClass().getName() + " is not initialized.");
        }
    }

    /**
     * Gets the service client for specified session.
     * @param serviceId The service identifier.
     * @param NesisToken bNesis token.
     * @return <c>IDynamicCallee</c> interface of the client instance.
	 * @throws Exception Can't find client for the session.
	*/
    protected RemoteApiServiceClient GetSessionClient(String serviceId, String bNesisToken) throws Exception
    {
        RemoteApiServiceClient client = SessionsManager.GetSessionClient(bNesisToken, serviceId);
        if (client == null)
        {
            throw new Exception("Can't find client for the session '" + bNesisToken + "'.");
        }

        return client;
    }


    public void InitializeRemote(String bNesisApiUrl)
    {
		//System.out.println("bNesisApi InitializeRemote: " + bNesisApiUrl);
        //bNesisApiUrl = CommonUtils.CleanUrl(bNesisApiUrl);
		this.bNesisApiUrl = bNesisApiUrl;

        SessionsManager = new RemoteApiServiceSessionsManager(bNesisApiUrl);
        //{
            SessionsManager.ClientsManager = new RemoteApiServiceClientsManager(bNesisApiUrl);
            SessionsManager.AuthProvidersManager = new RemoteApiAuthProvidersManager(bNesisApiUrl);
        //};
    }

	public String GetLastError(Exception exception)	
	{
	  return exception.getMessage();
	}

    public String Auth(String providerId, String data, String bNesisDevId,
        String redirectUrl, String clientId, String clientSecret, String[] scopes,
        String login, String password, Boolean isSandbox, String serviceUrl) throws Exception
		{
			//System.out.println("bNesisApi Auth");
			if (!this.SessionsManager.AuthProvidersManager.ProviderExists(providerId))
			{

				throw new Exception("Provider '" + providerId +"' is not supported.");
			}
        String authUrl = "";
		try {
			String _scopes = null;
			if(scopes != null)
				_scopes= String.join(";", scopes);
			else
				_scopes= "";
			String UTF8Name = StandardCharsets.UTF_8.name();
			authUrl = this.bNesisApiUrl + "api/AuthProvider/Auth?" +
					  "providerId=" +  URLEncoder.encode(providerId,  UTF8Name) +
					  "&data=" + URLEncoder.encode(data,  UTF8Name) +
					  "&bNesisDevId=" + URLEncoder.encode(bNesisDevId,  UTF8Name) +
					  "&redirectUrl=" + URLEncoder.encode(redirectUrl,  UTF8Name) +
					  "&clientId=" + URLEncoder.encode(clientId,  UTF8Name) +
					  "&clientSecret=" + URLEncoder.encode(clientSecret,  UTF8Name) +
					  "&scopes=" + URLEncoder.encode(_scopes,  UTF8Name) +
					  "&login=" + URLEncoder.encode(login,  UTF8Name) +
					  "&password=" + URLEncoder.encode(password,  UTF8Name) +
					  "&isSandbox=" + URLEncoder.encode(isSandbox.toString(),  UTF8Name) +
					  "&serviceUrl=" + URLEncoder.encode(serviceUrl,  UTF8Name);
			//authUrl += "&:embed=y&:linktarget=_self";
			//System.out.println("authUrl: " + authUrl);
			Desktop desktop = Desktop.getDesktop();
			URI oURL = new URI(authUrl);			
			desktop.browse(oURL);
		} catch (UnsupportedEncodingException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (URISyntaxException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}        
		  return _bNesisToken;
		}

    /**
     * Calls the specified method of the specified service client.
     * @typeparam T The type of the result.
     * @param serviceId The service identifier (f.e. GoogleDrive).
     * @param bNesisToken The bNesis token.
     * @param methodName Name of the called method.
     * @param methodParameters The called method parameters.
     * @return Result of the method call.
	*/
    public<TResult> TResult Call(Class<?> cls, String serviceId, String bNesisToken, String methodName, Object ...methodParameters) throws Exception
    {
        CheckInitialization();
        
        RemoteApiServiceClient serviceClient = this.SessionsManager.GetSessionClient(bNesisToken, serviceId);
        Object objectResult = null;
        try {
        	objectResult = serviceClient.Call(  methodName, methodParameters);
        }
        catch(Exception e)
        {
        	
        }
        return this.<TResult>ProcessCallResult(cls, objectResult);
    }

    
    @SuppressWarnings("unchecked")
	private<TResult> TResult ProcessCallResult(Class<?> cls, Object objectResult)
    {
    	if(objectResult == null 
			|| (cls.isAssignableFrom(objectResult.getClass()) && !(objectResult instanceof String)) 
			|| objectResult instanceof OutputStream || objectResult instanceof InputStream)    		
    		return (TResult)objectResult;
    	TResult result = null;
    	try {
    		String stringResult = (String)objectResult;
			String firstCh = stringResult.substring(0, 1);
			if(firstCh.equals("{") || firstCh.equals("[")) {
				ObjectMapper mapper = new ObjectMapper();
				result = (TResult) mapper.readValue(stringResult, cls);
			}
			else {
				result = (TResult) JSONObject.stringToValue(stringResult);
			}    		
    	}
    	catch(ClassCastException e)
    	{
			// TODO Auto-generated catch block
			e.printStackTrace();    		
    	} catch (JsonParseException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (JsonMappingException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
    	
    	return result;
    }
    /**
    * The method stops the authorization session with the service and clears the value of bNesisToken
    * @param serviceId The service identifier.
    * @param bNesisToken The bNesis token.
    * @return {Boolean} if token revoked returns true
    */
    public Boolean LogoffService(String serviceId, String bNesisToken)
    {
        try
        {
            CheckInitialization();

            RemoteApiServiceClient client = GetSessionClient(serviceId, bNesisToken);
            client.LogoffService();
            SessionsManager.RemoveSessionLocal(bNesisToken);

            if (_bNesisToken!=null && _bNesisToken != "" &&  _bNesisToken == bNesisToken ) _bNesisToken = null;

        }
        catch(Exception e)
        {
            return false;
        }

        return true;
    }

}
