package bNesis.Common.ExceptionTypes;

//import org.apache.http.HttpResponse;

/**
* bNesis Exception class for handeling user authenticate exceptions and worg bNEsis token exeptions
*/
//[Serializable]
public class NotAuthenticatedSessionException extends Exception
{
	private static final long serialVersionUID = -2413629666163901633L;
	
    /// <see cref="NotAuthenticatedSessionException"/>
    public NotAuthenticatedSessionException() { }

    /**
    * variant with message
    * @param message message discrabled exception
    * <see cref="NotAuthenticatedSessionException"/>
	*/
    public NotAuthenticatedSessionException(String message) { super(message); }

    /**
    * variant with message and InnerException object
    * @param message exception discrable message
    * @param inner inner exception object
    * <see cref="NotAuthenticatedSessionException"/>
	*/
    public NotAuthenticatedSessionException(String message, Exception inner) { super(message, inner); }
}