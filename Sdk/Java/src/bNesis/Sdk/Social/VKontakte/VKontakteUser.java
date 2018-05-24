package bNesis.Sdk.Social.VKontakte;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * object describes a user profile
 *     https://vk.com/dev/objects/user
 *     Object contains information about user. Fields set may vary depending on called method and passed parameters. 
 * @typedef {Object} VKontakteUser
 */
public class VKontakteUser
{
	public VKontakteUser(){}
	/**
	 * "About me"
	 * @type {String}
	 */
	public String about;

	/**
	 * Activities.
	 * @type {String}
	 */
	public String activities;

	/**
	 * user's date of birth.  
	 * Returned as DD.MM.YYYY or DD.MM (if birth year is hidden). If the whole date is hidden, no field is returned.
	 * @type {String}
	 */
	public String bdate;

	/**
	 * Returns 1 if a current user is in the requested user's blacklist.
	 * @type {String}
	 */
	public String blacklisted;

	/**
	 * Returns 1 if a user is in the current user's blacklist.
	 * @type {String}
	 */
	public String blacklisted_by_me;

	/**
	 * Favorite books.
	 * @type {String}
	 */
	public String books;

	/**
	 * Information whether current user can post on the wall: 1 – allowed, 0 — not allowed.
	 * @type {String}
	 */
	public String can_post;

	/**
	 * Information whether current user can see other users' posts on the wall: 1 – allowed, 0 – not allowed.
	 * @type {String}
	 */
	public String can_see_all_posts;

	/**
	 * Information whether current user can see users' audio: 1 – allowed, 0 – not allowed.
	 * @type {String}
	 */
	public String can_see_audio;

	/**
	 * Information whether current user can send friend request to a user: 1 – allowed, 0 – not allowed.
	 * @type {String}
	 */
	public String can_send_friend_request;

	/**
	 * Information whether current user can write private messages to a user: 1 – allowed, 0 – not allowed.
	 * @type {String}
	 */
	public String can_write_private_message;

	/**
	 * information about user's career. Object with following fileds:
	 *  group_id(integer) — community ID(if available, otherwise company);
	 *  company(string) — company name(if available, otherwise group_id);
	 *  country_id(integer) — country ID;
	 *  city_id(integer) — city ID(if available, otherwise city_name);
	 *  city_name(string) — city name(if available, otherwise city_id);
	 *  from(integer) — career beginning year;
	 *  until(integer) — career ending year;
	 *  position(string) — position.
	 * @type {VKontakteCareer[]}
	 */
	public VKontakteCareer[] career;

	/**
	 * City specified on user's page in "Contacts" section. Contains following fields:
	 *  id(integer) — city ID;
	 *  title(string) — city name.
	 * @type {VKontakteCity}
	 */
	public VKontakteCity city;

	/**
	 * Number of common friends with current user.
	 * @type {String}
	 */
	public String common_count;

	/**
	 * Returns specified services such as: skype, facebook, twitter, livejournal, instagram.
	 * @type {String}
	 */
	public String connections;

	/**
	 * Information about user's phone numbers. 
	 * If data are available and not hidden in privacy settings, the following fields are returned:
	 *  mobile_phone(string) — user's mobile phone number (only for standalone applications);
	 *  home_phone(string) — user's additional phone number.
	 * @type {VKontakteContacts}
	 */
	public VKontakteContacts contacts;

	/**
	 * Number of various objects the user has.  Can be used in users.get method only when requesting information about a user.
	 * @type {VKontakteCounters}
	 */
	public VKontakteCounters counters;

	/**
	 * Country specified on user's page in "Contacts" section. Contains following fields:
	 * id(integer) — country ID;
	 * title(string) — country name.
	 * @type {VKontakteCountry}
	 */
	public VKontakteCountry country;

	/**
	 * Data about points used for cropping of profile and preview user photos. Contains following fields:
	 *  photo(object) — Photo object with user photo used for cropping main profile photo.
	 *  crop(object) — cropped user photo.Contains following fields:
	 *  x(number) — X coordinate for the left upper corner, %;
	 *  y(number) — Y coordinate for the left upper corner, %;
	 *  x2(number) — X coordinate for the right bottom corner, %;
	 *  y2(number) —Y coordinate for the right bottom corner, %.
	 *  rect(object) — preview square photo cropped from crop photo.Contains the same fields set as crop object..
	 * @type {VKontakteCropPhoto}
	 */
	public VKontakteCropPhoto crop_photo;

	/**
	 * page screen name.  Returns a string with a page screen name (only subdomain is returned, like andrew). 
	 *  If not set, "id'+uid is returned, e.g. id35828305.
	 * @type {String}
	 */
	public String domain;

	/**
	 * Information about user's higher education institution.
	 * @type {VKontakteEducation}
	 */
	public VKontakteEducation education;

	/**
	 * first name
	 * @type {String}
	 */
	public String first_name;

	/**
	 * Number of followers
	 * @type {String}
	 */
	public String followers_count;

	/**
	 * Friend status with a current user. Possible values:
	 *  0 — not a friend;
	 *  1 — outcome request has been sent;
	 *  2 — incoming request has been sent;,
	 *  3 — friend.
	 * @type {String}
	 */
	public String friend_status;

	/**
	 * Favorite games.
	 * @type {String}
	 */
	public String games;

	/**
	 * Information whether the user's mobile phone number is available.  
	 * Returned values: 1 — available, 0 — not available.  
	 * We recommend you to use it prior to call of secure.sendSMSNotification method. 
	 * flag, can be 1 or 0
	 * @type {String}
	 */
	public String has_mobile;

	/**
	 * Information whether the user has profile photo.
	 * @type {String}
	 */
	public String has_photo;

	/**
	 * User's home town name.
	 * @type {String}
	 */
	public String home_town;

	/**
	 * Interests.
	 * @type {String}
	 */
	public String interests;

	/**
	 * Information whether the user is in faves of current user.
	 * @type {String}
	 */
	public String is_favorite;

	/**
	 * Information whether the user is a friend of current user.
	 * @type {String}
	 */
	public String is_friend;

	/**
	 * Information whether the user is hidden from current user's feed.
	 * @type {String}
	 */
	public String is_hidden_from_feed;

	/**
	 * last name
	 * @type {String}
	 */
	public String last_name;

	/**
	 * last visit date.  Returns last_seen object with the following fields:
	 *  time(integer) — last visit date(in Unixtime). 
	 *  platform(integer) — type of the platform that used for the last authorization.Possible values:
	 *  1 — m.vk.com;
	 *  2 — iPhone app;
	 *  3 — iPad app;
	 *  4 — Android app;
	 *  5 —Windows Phone app;
	 *  6 — Windows 8 app;
	 *  7 — web(vk.com);
	 *  8 — VK Mobile.
	 * @type {VKontakteLastSeen}
	 */
	public VKontakteLastSeen last_seen;

	/**
	 * Comma-separated friend lists IDs the user is included to. Field is available for friends.get method only.
	 * @type {String[]}
	 */
	public String[] lists;

	/**
	 * Maiden name.
	 * @type {String}
	 */
	public String maiden_name;

	/**
	 * Information about user's military service.
	 * @type {VKontakteMilitary[]}
	 */
	public VKontakteMilitary[] military;

	/**
	 * Favorite movies.
	 * @type {String}
	 */
	public String movies;

	/**
	 * Favorite music.
	 * @type {String}
	 */
	public String music;

	/**
	 * User nickname
	 * @type {String}
	 */
	public String nickname;

	/**
	 * User's occupation.
	 * @type {VKontakteOccupation}
	 */
	public VKontakteOccupation occupation;

	/**
	 * Information whether the user is online.  
	 *  Returned values: 1 — online, 0 — offline.  
	 *  If user utilizes a mobile application or site mobile version, it returns online_mobile additional field that includes 1.
	 *  With that, in case of application, online_app additional field is returned with application ID.
	 * @type {String}
	 */
	public String online;

	/**
	 * Information from the "Personal views" section.
	 * @type {VKontaktePersonal}
	 */
	public VKontaktePersonal personal;

	/**
	 * returns URL of square photo of the user with 50 pixels in width.  
	 *  In case user does not have a photo, http://vk.com/images/camera_c.gif is returned.
	 * @type {String}
	 */
	public String photo_50;

	/**
	 * returns URL of square photo of the user with 100 pixels in width.  
	 * In case user does not have a photo, http://vk.com/images/camera_b.gif is returned.
	 * @type {String}
	 */
	public String photo_100;

	/**
	 * returns URL of user's photo with 200 pixels in width.  
	 * In case user does not have a photo, http://vk.com/images/camera_a.gif is returned.
	 * @type {String}
	 */
	public String photo_200_orig;

	/**
	 * returns URL of square photo of the user with 200 pixels in width.  
	 * If the photo was uploaded long time ago, there can be no image of such size and in this case the reply will not include this field.
	 * @type {String}
	 */
	public String photo_200;

	/**
	 * returns URL of user's photo with 400 pixels in width.
	 * If user does not have a photo of such size, reply will not include this field.
	 * @type {String}
	 */
	public String photo_400_orig;

	/**
	 * String ID of the main profile photo in format {user_id}_{photo_id}, e.g., 6492_192164258. 
	 * Note that this field can be absent.
	 * @type {String}
	 */
	public String photo_id;

	/**
	 * returns URL of square photo of the user with maximum width. 
	 * Can be returned a photo both 200 and 100 pixels in width.  
	 * In case user does not have a photo, http://vk.com/images/camera_b.gif is returned.
	 * @type {String}
	 */
	public String photo_max;

	/**
	 * returns URL of square photo of the user with maximum width.
	 * Can be returned a photo both 200 and 100 pixels in width.
	 * In case user does not have a photo, http://vk.com/images/camera_b.gif is returned.
	 * @type {String}
	 */
	public String photo_max_orig;

	/**
	 * Favorite quotes.
	 * @type {String}
	 */
	public String quotes;

	/**
	 * Current user's relatives list. 
	 * Returns a list of objects with id and type fields (name instead of id if a relative is not a VK user).
	 * @type {VKontakteRelatives[]}
	 */
	public VKontakteRelatives[] relatives;

	/**
	 * User relationship status. Returned values:
	 *  1 – single;
	 *  2 – in a relationship;
	 *  3 – engaged;
	 *  4 – married;
	 *  5 – it's complicated;
	 *  6 – actively searching;
	 *  7 – in love;
	 *  8 — in a civil union;
	 *  0 — not specified.
	 * @type {String}
	 */
	public String relation;

	/**
	 * List of schools where user studied.
	 * @type {VKontakteSchools[]}
	 */
	public VKontakteSchools[] schools;

	/**
	 * user page's screen name (subdomain).
	 * @type {String}
	 */
	public String screen_name;

	/**
	 * user sex.  One of three values is returned:
	 *  1 — female;
	 *  2 — male;
	 *  0 — not specified.
	 * @type {String}
	 */
	public String sex;

	/**
	 * Returns a website address from a user profile.
	 * @type {String}
	 */
	public String site;

	/**
	 * User status. If the audio broadcast is enabled, contains additional status_audio field with an audio object.
	 * @type {String}
	 */
	public String status;

	/**
	 * user time zone. Retuns only while requesting current user info.
	 * @type {String}
	 */
	public String timezone;

	/**
	 * Information whether the user a "fire" pictogram.
	 * @type {String}
	 */
	public String trending;

	/**
	 * Favorite TV shows.
	 * @type {String}
	 */
	public String tv;

	/**
	 * List of higher education institutions where user studied.
	 * @type {VKontakteUniversities[]}
	 */
	public VKontakteUniversities[] universities;

	/**
	 * Returns 1 if the profile is verified, 0 if not.
	 * @type {String}
	 */
	public String verified;

	/**
	 * Wall comments allowed (1 — allowed, 0 — not allowed).
	 * @type {String}
	 */
	public String wall_comments;

	/**
	 * user ID.
	 * @type {String}
	 */
	public String id;

	/**
	 * skype
	 * @type {String}
	 */
	public String skype;

	/**
	 * university
	 * @type {String}
	 */
	public String university;

	/**
	 * university name
	 * @type {String}
	 */
	public String university_name;

	/**
	 * faculty
	 * @type {String}
	 */
	public String faculty;

	/**
	 * faculty name
	 * @type {String}
	 */
	public String faculty_name;

	/**
	 * graduation
	 * @type {String}
	 */
	public String graduation;

	}

