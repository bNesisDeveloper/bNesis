package bNesis.Sdk.Social.LinkedIn;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Implementation class of Positions 
 * @typedef {Object} LinkedInPositions
 */
public class LinkedInPositions
{
	public LinkedInPositions(){}
	/**
	 * Count values.
	 * @type {Integer}
	 */
	public Integer total;

	/**
	 * Can contains information about companies.
	 * @type {LinkedInCompanyInfo[]}
	 */
	public LinkedInCompanyInfo[] values;

	}

