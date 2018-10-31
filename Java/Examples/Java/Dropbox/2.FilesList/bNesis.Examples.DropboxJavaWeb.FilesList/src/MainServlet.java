

import java.io.IOException;

import java.io.PrintWriter;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import bNesis.Sdk.ServiceManager;
import bNesis.Sdk.FileStorages.Common.FileStorageItem;

import bNesis.Sdk.FileStorages.Dropbox.Dropbox;

public class MainServlet extends HttpServlet {
	static final long serialVersionUID = 1L;
    private String mymsg;
    public void init() throws ServletException 
    {      
       mymsg = "bNesis Sdk Dropbox Files List Example";   
    }
    public void doGet(HttpServletRequest request, 
        HttpServletResponse response) throws ServletException, 
        IOException 
    {
    	PrintWriter out = response.getWriter();

    	String bNesisToken = request.getParameter("token");
    	    	
    	String bNesisApiUrl = request.getParameter("bNesisApiUrl");
    	try {
	    	ServiceManager manager = new ServiceManager();

	    	int SDKInitializeResult = manager.InitializeThin(bNesisApiUrl);

            //Check if initialize result not equal zero(noError)
            if (SDKInitializeResult != ServiceManager.errorCodeNoError) {
                //Show error message
                out.println("<br/>bNesis SDK initialization problem, code: " + SDKInitializeResult + ", <br/>error message:" + manager.GetLastError());                
                return;
            }
	    	
	    	if(bNesisToken == "" || bNesisToken == null)
	    	{
	    		out.println("<br/>bNesis SDK initialization status: Success<br/>");
	    		
		    	String bNesisDeveloperId = request.getParameter("bNesisDevId");
		    	String DropboxAppKey = request.getParameter("ClientId");
		    	String DropboxAppSecret = request.getParameter("ClientSecret");
		    	String redirectUrl = request.getParameter("redirectUrl");
		    			    	
		    	manager.CreateInstanceDropbox(bNesisDeveloperId, DropboxAppKey, DropboxAppSecret, redirectUrl);

		    	response.setContentType("text/html");
	            // Writing the message on the web page      
	            out.println("<h1>" + mymsg + "</h1>");      
	            out.println("<p>" + "Redirecting to authorization..." + "</p>");
	    	}
	    	else
	    	{
		    	Dropbox dropbox = manager.CreateInstanceDropbox();
	        	dropbox.bNesisToken = bNesisToken;
	        	
	            response.setContentType("text/html");
	            // Writing the message on the web page      
	            out.println("<h1>" + mymsg + "</h1>");      
	            out.println("<p>" + "Authorization success! Dropbox instance created.!" + "</p>");
	            
	        	FileStorageItem[] fileList = (FileStorageItem[])dropbox.GetFiles("\\");
                //Check exiting of files in the root folder. If a case of files exists, output the files list	        	
	        	if(fileList != null && fileList.length > 0)
	        	{
	        		out.println("<br/>A list of files in the root folder:");
	        		for(int i = 0; i< fileList.length; i++)
	        			out.println("<br/>" + (i+1) +  ". " + fileList[i].Name + ", size: " + fileList[i].Size);
	        	}
	        	else
	        	{
	        		//Show error message
	        		out.println("<br/>There is no files in the root folder");
	        	}	            	            
	    	}
    	}
    	catch(Exception e)
    	{
    		System.out.println("Error: " + e.getMessage());
    	}
        // Setting up the content type of web page      
    }
    public void destroy() 
    {      
       // Leaving empty. Use this if you want to perform  
       //something at the end of Servlet life cycle.   
    }
}
