package bNesis.Api.Common;

import java.io.IOException;

import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.CloseableHttpClient;
import org.apache.http.impl.client.HttpClients;

public class Http {
	
	public HttpResponse Get(String url){
		   CloseableHttpClient httpClient = HttpClients.createDefault();
		   
		   HttpGet httpGet = new HttpGet(url);
		   HttpResponse response = null;
			try {
				response = httpClient.execute(httpGet);				
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			return response;
		}

		public HttpResponse Post(String url, HttpEntity data){
			   CloseableHttpClient httpClient = HttpClients.createDefault();
			   
			   HttpPost httpPost = new HttpPost(url);
			   HttpResponse response = null;
				try {
					httpPost.setEntity(data);
					response = httpClient.execute(httpPost);
				} catch (IOException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
			   return response;
		}

}
