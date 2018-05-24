package bNesis.Api.Services.Clients.Remote.Api;

import java.util.concurrent.TimeoutException;

import org.apache.http.entity.ContentType;
import org.apache.http.entity.mime.HttpMultipartMode;
import org.apache.http.entity.mime.MultipartEntityBuilder;
import org.apache.http.entity.mime.content.FileBody;
import org.apache.http.entity.mime.content.InputStreamBody;
import org.apache.http.entity.mime.content.StringBody;

import bNesis.Common.ExceptionTypes.*;

import bNesis.Api.Common.Http;

import org.apache.http.Header;
import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.HttpStatus;
import org.apache.http.ParseException;

import org.apache.http.util.EntityUtils;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;

public class RemoteApiServiceClient{

	private static final String AuthProviderControllerPath = "api/AuthProvider/";

	public String ServiceId;
	public String bNesisApiUrl;
	public String bNesisToken;

	public Object Call(String methodName, Object... methodParameters) {
		Object result = null;
		//System.out.println("Call entry");
	    try {
			String callUrl = "api/ServiceClient/Call?" +
			              "serviceId=" + URLEncoder.encode(this.ServiceId, "UTF-8") +
			              "&bNesisToken=" + URLEncoder.encode(this.bNesisToken, "UTF-8") +
			              "&methodName=" + URLEncoder.encode(methodName, "UTF-8");
		    String parameterUri = "";
		    
		    
		    Boolean allParametersAreSimple = true;
		    MultipartEntityBuilder entityBuilder = MultipartEntityBuilder.create();
		    entityBuilder.setMode(HttpMultipartMode.BROWSER_COMPATIBLE);
		    entityBuilder.setContentType(ContentType.MULTIPART_FORM_DATA);
		    if(methodParameters != null)
			    for(int i = 0; i< methodParameters.length; i++)
			    {
			    	String parameterName = "p" + i;
			    	if(methodParameters[i] instanceof String)
			    		parameterUri += "&"+ parameterName + "=" + URLEncoder.encode((String)methodParameters[i], "UTF-8");
			    	else 
			    	 if(methodParameters[i] instanceof File){
			    		 allParametersAreSimple = false;
			    		 ContentType contentType = ContentType.APPLICATION_OCTET_STREAM;
			    		 FileBody fileBody = new FileBody((File)methodParameters[i], contentType);
			    		 entityBuilder.addPart(parameterName, fileBody);
			    	}
			    	 else 
			    		 if(methodParameters[i] instanceof InputStream){
			    			 allParametersAreSimple = false;
			    			 ContentType contentType = ContentType.APPLICATION_OCTET_STREAM;			    			 
			    			 InputStreamBody inputStreamBody = new InputStreamBody( (InputStream)methodParameters[i], contentType );
			    			 entityBuilder.addPart(parameterName, inputStreamBody);
			    		 }
			    		 else
		    		 if(methodParameters[i] instanceof OutputStream){
		    			 allParametersAreSimple = false;
		    			 ByteArrayOutputStream baos = (ByteArrayOutputStream)methodParameters[i]; 
		    			 InputStream inputStream = new ByteArrayInputStream(baos.toByteArray());
		    			 ContentType contentType = ContentType.APPLICATION_OCTET_STREAM; 
		    			 InputStreamBody inputStreamBody = new InputStreamBody( inputStream, contentType );
		    			 entityBuilder.addPart(parameterName, inputStreamBody);
		    		 }
		    		 else
		    		 {
		    			 allParametersAreSimple = false;
		    			 ContentType contentType = ContentType.APPLICATION_JSON;
						 ObjectMapper mapper = new ObjectMapper();
		    			 String inputString = mapper.writeValueAsString((Object)methodParameters[i]); 
		    			 StringBody stringBody = new StringBody(inputString, contentType);
		    			 entityBuilder.addPart(parameterName, stringBody);
		    		 }
			    }		
		    HttpEntity httpEntity = entityBuilder.build();
			callUrl += parameterUri;
			//System.out.println("callUrl: " + callUrl);
			Http _httpClient = new Http();
			
			HttpResponse response = null;
			
		    if(allParametersAreSimple) 
		    {		    	
		    	response = _httpClient.Get(this.bNesisApiUrl + callUrl);
		    }
		    else
		    {
		    	response =  _httpClient.Post(callUrl, httpEntity);
		    }
		    if(response.getStatusLine().getStatusCode() == HttpStatus.SC_OK)
		    {
		    	HttpEntity entity = response.getEntity();
		    	Header header = response.getLastHeader("Content-Disposition");
		    	if(header != null) 
		    	{
		    		String contentDisposition =response.getLastHeader("Content-Disposition").getValue();
					if(!contentDisposition.isEmpty() && contentDisposition.equals("attachment"))
					{
							InputStream inStream = entity.getContent();
							ByteArrayOutputStream baoStream = new ByteArrayOutputStream();
							byte[] buffer = new byte[4096];
					        int bytesRead = -1;
					         
					        while ((bytesRead = inStream.read(buffer)) != -1) {
					        	baoStream.write(buffer, 0, bytesRead);
					        }	    
					        inStream.close();
					        return (Object) baoStream;
					}
		    		
		    	}		    	
				
				String resultString = EntityUtils.toString(entity);
				return (Object) resultString;
		     }
			} catch (UnsupportedEncodingException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			} catch (JsonProcessingException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			} catch (ParseException e1) {
				// TODO Auto-generated catch block
				e1.printStackTrace();
			} catch (IOException e1) {
				// TODO Auto-generated catch block
				e1.printStackTrace();
			}
	    
	    	return result;
}
	   
        /**
         * Revokes service token and revokes bNesisToken asynchronous.
         * return true if bnesis token and service token revoked
         * @throws Exception 
		 */
        public Object LogoffService() throws Exception  
        {
            Object result = Call("Logoff");

            String url = AuthProviderControllerPath + "Logoff?serviceId=" + URLEncoder.encode(ServiceId, "UTF-8") + " &bNesisToken=" + URLEncoder.encode(bNesisToken, "UTF-8");

            Http _httpClient = new Http();

            HttpResponse response = null;
			
			response = _httpClient.Get(this.bNesisApiUrl + url);
			
            if (response.getStatusLine().getStatusCode() == HttpStatus.SC_OK)
            {
            	String contentDisposition =response.getLastHeader("Content-Disposition").getValue();
                // IMPORTANT! Do not dispose the response with stream - this will dispose the stream which is needed upper.
                //if (response.Content.Headers.ContentDisposition?.DispositionType == "attachment")
            	if( contentDisposition.equals("attachment") )
                {
                    //return await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
            		HttpEntity entity = response.getEntity();
            		OutputStream stream = null;
            		if(entity != null) {
	            		stream = new ByteArrayOutputStream(); 
	            		entity.writeTo(stream);
            		}
            		return stream;
                }

                //using (response)
                {
                	return  EntityUtils.toString(response.getEntity(), "UTF-8");
                }
            }

            //try (response)
            {
            	String content = EntityUtils.toString(response.getEntity());
                switch (response.getStatusLine().getStatusCode())
                {
                    case HttpStatus.SC_METHOD_NOT_ALLOWED:
                        throw new ServiceOperationFailedException(content); //if in service client throw exception
                    case HttpStatus.SC_UNAUTHORIZED:
                        throw new NotAuthenticatedSessionException(content);//if not auth in bNesis server
                    case HttpStatus.SC_SERVICE_UNAVAILABLE:
                        throw new UnavailableServerException("bNesis server unavailable.");
                    case HttpStatus.SC_GATEWAY_TIMEOUT | HttpStatus.SC_REQUEST_TIMEOUT:
                        throw new TimeoutException("bNesis server timeout");
                    default:{
                        throw new Exception( "Remote call error. ReasonPhrase: " + response.getStatusLine().getReasonPhrase() + ". Content: " + content + "."); //else exception
                    }
                }
            }
        }

}

