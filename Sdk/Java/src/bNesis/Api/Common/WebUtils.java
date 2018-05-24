package bNesis.Api.Common;

//import java.io.ByteArrayOutputStream;
import java.io.IOException;
//import java.io.InputStream;
//import java.io.OutputStream;
//import java.lang.reflect.Array;
//import java.lang.reflect.Field;
//import java.util.ArrayList;
//import java.util.List;
//import java.util.List;

import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.HttpStatus;
//import org.apache.http.NameValuePair;
import org.apache.http.ParseException;
//import org.apache.http.client.HttpClient;
//import org.apache.http.client.entity.UrlEncodedFormEntity;
//import org.apache.http.client.methods.HttpGet;
//import org.apache.http.client.methods.HttpPost;
//import org.apache.http.Header;
//import org.apache.http.impl.client.CloseableHttpClient;
//import org.apache.http.impl.client.DefaultHttpClient;
//import org.apache.http.impl.client.HttpClients;
//import org.apache.http.message.BasicNameValuePair;
import org.apache.http.util.EntityUtils;
//import org.json.JSONObject;
//import org.json.JSONArray;
//import org.json.JSONException;
//import org.codehaus.jackson.map.ObjectMapper;
//import com.sun
import com.fasterxml.jackson.databind.ObjectMapper;
import bNesis.Api.Common.Http;

public class WebUtils {

	@SuppressWarnings("unchecked")
	public static <TResult> TResult Get(Class<?> cls, String url) throws Exception
	{
	   TResult result = null;
	   Http _httpClient = new Http();
	   try
	   {
		   HttpResponse response = _httpClient.Get(url);		   
		   HttpEntity entity = response.getEntity();
			String content = EntityUtils.toString(entity);
			if( response.getStatusLine().getStatusCode() == HttpStatus.SC_OK )
			{
				ObjectMapper mapper = new ObjectMapper();
				result = (TResult) mapper.readValue(content, cls);
				return result;
			}
			throw new Exception("Remote call error. ReasonPhrase: " + response.getStatusLine().getReasonPhrase() + ". Content: " + content +" .");
			
		} catch (ParseException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	    finally {
	    	_httpClient = null;
	    }
	   return result;
	}
}
