package bNesis.Sdk.Common;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * bNesis unified product item class for services unified API call 
 * @typedef {Object} ProductItem
 */
public class ProductItem
{
	public ProductItem(){}
	public String Title;

	public String BodyHtml;

	public String Vendor;

	public String ProductType;

	public Variants[] Variants;

	}

