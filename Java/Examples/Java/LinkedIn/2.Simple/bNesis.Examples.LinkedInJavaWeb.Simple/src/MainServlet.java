
import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import bNesis.Sdk.ServiceManager;
import bNesis.Sdk.Common.ErrorInfo;
import bNesis.Sdk.Social.LinkedIn.LinkedIn;
import bNesis.Sdk.Social.LinkedIn.LinkedInMemberBasicProfile;

public class MainServlet extends HttpServlet {
	static final long serialVersionUID = 1L;
    private String mymsg;
    public void init() throws ServletException 
    {      
       mymsg = "bNesis Sdk LinkedIn Simple Example";   
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
		    	String LinkedInClientId = request.getParameter("ClientId");
		    	String LinkedInClientSecret = request.getParameter("ClientSecret");
		    	String redirectUrl = request.getParameter("redirectUrl");
		    	
		        /**
		         * "r_basicprofile", "r_emailaddress", "rw_company_admin", "w_share"
		         * Your application requests a delimited list of member permissions on behalf of the user.
		         */
		        String[] Scope = {"r_basicprofile"};
		    	
		    	manager.CreateInstanceLinkedIn( bNesisDeveloperId, LinkedInClientId, LinkedInClientSecret, redirectUrl, Scope);

		    	response.setContentType("text/html");
	            // Writing the message on the web page      
	            out.println("<h1>" + mymsg + "</h1>");      
	            out.println("<p>" + "Redirecting to authorization..." + "</p>");
	    	}
	    	else
	    	{
		    	LinkedIn linkedIn = manager.CreateInstanceLinkedIn();
	        	linkedIn.bNesisToken = bNesisToken;
	        		        	
	            response.setContentType("text/html");
	            // Writing the message on the web page      
	            out.println("<h1>" + mymsg + "</h1>");      
	            out.println("<p>" + "Authorization success! LinkedIn instance created.!" + "</p>");
	            
	            out.println("Getting member profile information from LinkedIn...");
                //Get member profile from LinkedIn V1 API 
                LinkedInMemberBasicProfile profile = linkedIn.GetMemberSimpleProfileV1();
                //Getting last error
                ErrorInfo errorInfo = linkedIn.GetLastError();
                //Check if errorInfo code does not equal noError
                if (errorInfo.Code != ServiceManager.errorCodeNoError)
                {
                	out.println("Can't get member profile, error code: " + errorInfo.Code +
                                      "<br/>Reason:" + errorInfo.Description);
                    return;
                }

                out.println("Success! Received information about profile member.");
                out.println("Some information about member:" +
                                  "<br/> ID:" + profile.id +
                                  "<br/> Headline:" + profile.headline +
                                  "<br/> FirstName:" + profile.firstName +
                                  "<br/> LastName:" + profile.lastName);	            
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
