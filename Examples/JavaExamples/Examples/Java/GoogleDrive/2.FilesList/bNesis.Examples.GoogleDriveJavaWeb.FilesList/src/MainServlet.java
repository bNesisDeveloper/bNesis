
import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

//import bNesis.Api.bNesisApi;
import bNesis.Sdk.ServiceManager;
import bNesis.Sdk.FileStorages.Common.FileStorageItem;
//import bNesis.Sdk.FileStorages.Common.FileStorageItem;
import bNesis.Sdk.FileStorages.GoogleDrive.GoogleDrive;

public class MainServlet extends HttpServlet {
	static final long serialVersionUID = 1L;
    private String mymsg;
    public void init() throws ServletException 
    {      
       mymsg = "bNesis Sdk GoogleDrive File List Example";   
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
		    	String GoogleDriveClientId = request.getParameter("ClientId");
		    	String GoogleDriveClientSecret = request.getParameter("ClientSecret");
		    	String redirectUrl = request.getParameter("redirectUrl");
		    	String[] scopes = {"https://www.googleapis.com/auth/drive.readonly"};
		    	manager.CreateInstanceGoogleDrive(bNesisDeveloperId, GoogleDriveClientId, GoogleDriveClientSecret, redirectUrl, scopes);

		    	response.setContentType("text/html");
	            // Writing the message on the web page      
	            out.println("<h1>" + mymsg + "</h1>");      
	            out.println("<p>" + "Redirecting to authorization..." + "</p>");
	    	}
	    	else
	    	{
		    	GoogleDrive googleDrive = manager.CreateInstanceGoogleDrive();
	        	googleDrive.bNesisToken = bNesisToken;
	        		        	
	            response.setContentType("text/html");
	            // Writing the message on the web page      
	            out.println("<h1>" + mymsg + "</h1>");      
	            out.println("<p>" + "Authorization success! GoogleDrive instance created.!" + "</p>");   	        	
					            
	        	FileStorageItem[] fileList = (FileStorageItem[])googleDrive.GetFiles("\\");
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
