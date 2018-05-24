package bNesis.Common.ExceptionTypes;

//import org.apache.http.HttpResponse;

/*
* bNesis Core and Services exception type for debuging 
*/
public class UnavailableServerException extends Exception
{
	private static final long serialVersionUID = -2413629666163901633L;
	
    /**
    * this exception raised by bNesis Core if Called service is unavailabel now
    */
    public UnavailableServerException() { }

    /**
    * as UnavailableServerException(), but processing additional debug message
    * @param message information about exception
	*/
    public UnavailableServerException(String message) { super(message); }

    /**
    * as UnavailableServerException(), but processing additional debug message
    * and process innerException (Exception.innerException[Exception]) for debug call stack 
    * @param message information about exception
    * @param innerException inner exception class
	*/
    public UnavailableServerException(String message, Exception innerException)  { super(message, innerException); }
}