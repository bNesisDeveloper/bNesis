package bNesis.Sdk.Social.VKontakte;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Data about points used for cropping of profile and preview user photos. 
 * @typedef {Object} VKontakteCropPhoto
 */
public class VKontakteCropPhoto
{
	public VKontakteCropPhoto(){}
	/**
	 * Photo object with user photo used for cropping main profile photo.
	 * @type {VKontaktePhoto}
	 */
	public VKontaktePhoto photo;

	/**
	 * cropped user photo. Contains following fields:
	 *  x(number) — X coordinate for the left upper corner, %;
	 *  y(number) — Y coordinate for the left upper corner, %;
	 *  x2(number) — X coordinate for the right bottom corner, %;
	 *  y2(number) —Y coordinate for the right bottom corner, %.
	 * @type {VKontakteCrop}
	 */
	public VKontakteCrop crop;

	/**
	 * preview square photo cropped from crop photo. Contains the same fields set as crop object.
	 * @type {VKontakteRect}
	 */
	public VKontakteRect rect;

	}

