
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.OutputStream;
import java.io.PrintWriter;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import bNesis.Sdk.ServiceManager;
import bNesis.Sdk.FileStorages.GoogleDrive.GoogleDrive;

public class MainServlet extends HttpServlet {
	static final long serialVersionUID = 1L;
    private String mymsg;
    public void init() throws ServletException 
    {      
       mymsg = "bNesis Sdk GoogleDrive Download File Example";   
    }
    public void doGet(HttpServletRequest request, 
        HttpServletResponse response) throws ServletException, 
        IOException 
    {
    	
    	String bNesisToken = request.getParameter("token");
    	    	
    	String bNesisApiUrl = request.getParameter("bNesisApiUrl");
    	try {
	    	ServiceManager manager = new ServiceManager();

	    	int SDKInitializeResult = manager.InitializeThin(bNesisApiUrl);

            //Check if initialize result not equal zero(noError)
            if (SDKInitializeResult != ServiceManager.errorCodeNoError) {
                //Show error message
            	PrintWriter out = response.getWriter();
            	
            	out.println("<h1>" + mymsg + "</h1>");
            	
                out.println("<br/>bNesis SDK initialization problem, code: " + SDKInitializeResult + ", <br/>error message:" + manager.GetLastError());                
                return;
            }
	    	
	    	if(bNesisToken == "" || bNesisToken == null)
	    	{
	    		PrintWriter out = response.getWriter();
	    		
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
	        		        						            
	        	String filename = "test1.jpg";
	        	ByteArrayOutputStream stream = (ByteArrayOutputStream)googleDrive.DownloadFile(filename);
	        	//FileOutputStream fStream = new FileOutputStream("c:\\Getting Started.pdf");
	        	OutputStream os = response.getOutputStream();
	            response.setContentType("application/octet-stream");
	            response.setHeader("Content-Disposition",
	                    "attachment;filename=\"" + filename +"\"");
	            int fileSize = stream.size(); 
	            response.setContentLength(fileSize);
	            os.write(stream.toByteArray(),0, fileSize);
	        	os.flush();
	        	os.close();				
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
