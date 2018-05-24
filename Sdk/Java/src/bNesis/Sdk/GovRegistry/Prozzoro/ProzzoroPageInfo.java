package bNesis.Sdk.GovRegistry.Prozzoro;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of PageInfo. 
 * @typedef {Object} ProzzoroPageInfo
 */
public class ProzzoroPageInfo
{
	public ProzzoroPageInfo(){}
	/**
	 * Information about next page.
	 * @type {ProzzoroNextPage}
	 */
	public ProzzoroNextPage next_page;

	/**
	 * Data information.
	 * @type {ProzzoroData[]}
	 */
	public ProzzoroData[] data;

	}

