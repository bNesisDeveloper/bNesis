package bNesis.Common.ExceptionTypes;

//import org.apache.http.HttpResponse;

/**
* bNesis Exception class for handeling exception related with service Call fails - bad endpoint, wrong token and so
*/
//[Serializable]
public class ServiceOperationFailedException extends Exception
{
	private static final long serialVersionUID = -2413629666163901633L;
	
    /// <see cref="NotAuthenticatedSessionException"/>
    public ServiceOperationFailedException() { }

    /// <see cref="NotAuthenticatedSessionException"/>
    public ServiceOperationFailedException(String message) { super(message); }

    /// <see cref="NotAuthenticatedSessionException"/>
    public ServiceOperationFailedException(String message, Exception inner) { super(message, inner); }
}