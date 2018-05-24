
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.OutputStream;
import java.io.PrintWriter;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import bNesis.Sdk.ServiceManager;
import bNesis.Sdk.FileStorages.Dropbox.Dropbox;

public class MainServlet extends HttpServlet {
	static final long serialVersionUID = 1L;
    private String mymsg;
    public void init() throws ServletException 
    {      
       mymsg = "<h1>bNesis Sdk Dropbox Download File Example</h1>";   
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
            	
            	PrintWriter out = response.getWriter();
            	
                out.println(mymsg);

                //Show error message
                out.println("<br/>bNesis SDK initialization problem, code: " + SDKInitializeResult + ", <br/>error message:" + manager.GetLastError());                
                return;
            }
	    	
	    	if(bNesisToken == "" || bNesisToken == null)
	    	{
	        	PrintWriter out = response.getWriter();
	        	
	            out.println(mymsg);
	    		
	    		out.println("<br/>bNesis SDK initialization status: Success<br/>");
	    		
		    	String bNesisDeveloperId = request.getParameter("bNesisDevId");
		    	String DropboxAppKey = request.getParameter("ClientId");
		    	String DropboxAppSecret = request.getParameter("ClientSecret");
		    	String redirectUrl = request.getParameter("redirectUrl");
		    			    	
		    	manager.CreateInstanceDropbox(bNesisDeveloperId, DropboxAppKey, DropboxAppSecret, redirectUrl);

		    	response.setContentType("text/html");
		    	
	            // Writing the message on the web page            
	            out.println("<p>" + "Redirecting to authorization..." + "</p>");
	    	}
	    	else
	    	{
		    	Dropbox dropbox = manager.CreateInstanceDropbox();
	        	dropbox.bNesisToken = bNesisToken;

	        	String filename = "Getting Started.pdf";
	        	ByteArrayOutputStream stream = (ByteArrayOutputStream)dropbox.DownloadFile(filename);
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
      
	            //out.println("<p>" + "Authorization success! Dropbox instance created.!" + "</p>");   	        	
	    	}
    	}
    	catch(Exception e)
    	{
    		System.out.println("servlet Error: " + e.getMessage());
    	}
        // Setting up the content type of web page      
    }
    public void destroy() 
    {      
       // Leaving empty. Use this if you want to perform  
       //something at the end of Servlet life cycle.   
    }
}
