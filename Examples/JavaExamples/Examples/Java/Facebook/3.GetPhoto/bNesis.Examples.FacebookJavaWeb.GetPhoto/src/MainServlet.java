
import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import bNesis.Sdk.ServiceManager;
import bNesis.Sdk.Common.ErrorInfo;
import bNesis.Sdk.Social.Facebook.Facebook;
import bNesis.Sdk.Social.Facebook.FacebookUserPhotos;
//import bNesis.Sdk.Social.Facebook.FacebookUser;
//import bNesis.Sdk.Social.Facebook.FacebookUserFriends;

public class MainServlet extends HttpServlet {
	static final long serialVersionUID = 1L;
    private String mymsg;
    
    /**
     * The user's identifier. It can be "me"
     */
    private String id = "me";
    
    public void init() throws ServletException 
    {      
       mymsg = "bNesis Sdk Facebook GetPhoto Example";   
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
		    	String FacebookClientId = request.getParameter("ClientId");
		    	String FacebookClientSecret = request.getParameter("ClientSecret");
		    	String redirectUrl = request.getParameter("redirectUrl");

		        String[] Scope = { "email", "user_age_range", "user_birthday", "user_friends", "user_gender",
		                "user_hometown", "user_link", "user_location",  "user_likes", "user_photos", "user_posts",
		                "user_tagged_places", "user_videos", "groups_access_member_info", "user_events", "user_managed_groups",
		                "publish_to_groups", "publish_actions", "user_status", "user_tagged_places", "manage_pages",
		                "pages_show_list", "ads_management", "business_management", "user_events", "user_managed_groups" };
		        
		    	manager.CreateInstanceFacebook(bNesisDeveloperId, FacebookClientId, FacebookClientSecret, redirectUrl, Scope);

		    	response.setContentType("text/html");
	            // Writing the message on the web page      
	            out.println("<h1>" + mymsg + "</h1>");      
	            out.println("<p>" + "Redirecting to authorization..." + "</p>");
	    	}
	    	else
	    	{
		    	Facebook facebook = manager.CreateInstanceFacebook();
	        	facebook.bNesisToken = bNesisToken;
	        		        	
	            response.setContentType("text/html");
	            // Writing the message on the web page      
	            out.println("<h1>" + mymsg + "</h1>");      
	            out.println("<p>" + "Authorization success! Facebook instance created.!" + "</p>");
	            
	            //Getting photos
                FacebookUserPhotos photo = facebook.GetUserPhotos(id);

                //Getting last error
                ErrorInfo errorInfo = facebook.GetLastError();
                //Check if an errorInfo code does not equal noError
                if (errorInfo.Code != manager.errorCodeNoError)
                {
                    //Show error message
                	out.println( "<br/>Getting the data of photos is Failed, error code: " + errorInfo.Code +
                                      ",<br/>Reason:" + errorInfo.Description );
                    return;
                }

                out.println( "<br/>Success! The data of photos is received" );

                //Creating the table with photos
                if (photo.data.length > 0)
                {
                    String tablestring = "<table><tr><td><p>#</p></td><td><p align=\"center\">Picture<p></td><td><p align=\"center\">Post date</p></td><td><p align=\"center\">Text of post</p></td></tr>";
                    for(int i=0; i<photo.data.length;i++)
                    {
                        int j = i + 1;

                        tablestring += "<tr><td>" + j + "</td><td><p><img src=" + photo.data[i].picture + "></p></td><td>" + photo.data[i].created_time.toString() + "</td><td>";

                        if (photo.data[i].name != null)
                        {
                            tablestring += photo.data[i].name + "</td></tr>";
                        }
                        else
                        {
                            tablestring += "<p align=\"center\">No text</p></td></tr>";
                        }  
                    }

                    tablestring += "</table>";
                    out.println( tablestring );
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
