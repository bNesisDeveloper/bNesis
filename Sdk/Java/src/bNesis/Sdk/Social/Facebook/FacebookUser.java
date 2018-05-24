package bNesis.Sdk.Social.Facebook;
import org.apache.http.HttpStatus;
import java.util.List;
import java.util.Date;
import java.net.URI;


/**
 * Information of User
 *     https://developers.facebook.com/docs/graph-api/reference/user/
 *     Permissions
 *     Developers usually request these permissions for this endpoint:
 *     Marketing Apps
 *     No data
 *     Page management Apps
 *     manage_pages
 *     pages_show_list
 *     Other Apps
 *     Permissions are not usually requested. 
 * @typedef {Object} FacebookUser
	 * @property {String}  id - The identifier.
	 * @property {String}  about - The about.
	 * @property {FacebookAgeRange}  age_range - The age range.
	 * @property {String}  birthday - The birthday.
	 * @property {String}  can_review_measurement_request - The can review measurement request.
	 * @property {FacebookEducationExperience[]}  education - The person's education history
	 * @property {FacebookPage}  location - The location.
 */
public class FacebookUser
{
	public FacebookUser(){}
	/**
	 * The id of this person's user account. 
	 * This ID is unique to each app and cannot be used across different apps.
	 * @type {String}
	 */
	public String id;

	/**
	 * Equivalent to the bio field
	 * @type {String}
	 */
	public String about;

	/**
	 * The person's address
	 * @type {FacebookLocation}
	 */
	public FacebookLocation address;

	/**
	 * Gets or sets the age range.
	 * @type {FacebookAgeRange}
	 */
	public FacebookAgeRange age_range;

	/**
	 * The person's birthday. This is a fixed format string, like MM/DD/YYYY.
	 * @type {String}
	 */
	public String birthday;

	/**
	 * Can the person review brand polls
	 * @type {String}
	 */
	public String can_review_measurement_request;

	/**
	 * Social context for a person
	 * @type {FacebookUserContext}
	 */
	public FacebookUserContext context;

	/**
	 * A cover photo for objects in the Graph API. Cover photos are used with Events, Groups, Pages and People.
	 * @type {FacebookCoverPhoto}
	 */
	public FacebookCoverPhoto cover;

	/**
	 * The person's local currency information
	 * @type {FacebookCurrency}
	 */
	public FacebookCurrency currency;

	/**
	 * The list of devices the person is using. This will return only iOS and Android devices
	 * @type {FacebookUserDevices[]}
	 */
	public FacebookUserDevices[] devices;

	/**
	 * The person's education
	 * @type {FacebookEducationExperience[]}
	 */
	public FacebookEducationExperience[] education;

	/**
	 * The person's primary email address listed on their profile. 
	 * This field will not be returned if no valid email address is available
	 * @type {String}
	 */
	public String email;

	/**
	 * Athletes the person likes
	 * @type {FacebookExperience[]}
	 */
	public FacebookExperience[] favorite_athletes;

	/**
	 * Sports teams the person likes
	 * @type {FacebookExperience[]}
	 */
	public FacebookExperience[] favorite_teams;

	/**
	 * The person's first name
	 * @type {String}
	 */
	public String first_name;

	/**
	 * The gender selected by this person, male or female. 
	 * If the gender is set to a custom value, this value will be based off of the preferred pronoun; 
	 * it will be omitted if the preferred preferred pronoun is neutral
	 * @type {String}
	 */
	public String gender;

	/**
	 * The person's hometown
	 * @type {FacebookPage}
	 */
	public FacebookPage hometown;

	/**
	 * The person's inspirational people
	 * @type {FacebookExperience[]}
	 */
	public FacebookExperience[] inspirational_people;

	/**
	 * Install type
	 * @type {String}
	 */
	public String install_type;

	/**
	 * Is the app making the request installed?
	 * @type {String}
	 */
	public String installed;

	/**
	 * Genders the person is interested in
	 * @type {String[]}
	 */
	public String[] interested_in;

	/**
	 * Is this a shared login (e.g. a gray user)
	 * @type {String}
	 */
	public String is_shared_login;

	/**
	 * People with large numbers of followers can have the authenticity of their identity manually verified by Facebook. 
	 * This field indicates whether the person's profile is verified in this way. This is distinct from the verified field
	 * @type {String}
	 */
	public String is_verified;

	/**
	 * A link to the person's Timeline
	 * @type {String}
	 */
	public String link;

	/**
	 * Facebook Pages representing the languages this person knows
	 * @type {FacebookExperience[]}
	 */
	public FacebookExperience[] languages;

	/**
	 * The person's last name
	 * @type {String}
	 */
	public String last_name;

	/**
	 * The person's locale
	 * @type {String}
	 */
	public String locale;

	/**
	 * Location node used with other objects in the Graph API.
	 * @type {FacebookPage}
	 */
	public FacebookPage location;

	/**
	 * What the person is interested in meeting for
	 * @type {String[]}
	 */
	public String[] meeting_for;

	/**
	 * The person's middle name
	 * @type {String}
	 */
	public String middle_name;

	/**
	 * The person's full name
	 * @type {String}
	 */
	public String name;

	/**
	 * The person's name formatted to correctly handle Chinese, Japanese, or Korean ordering
	 * @type {String}
	 */
	public String name_format;

	/**
	 * The person's payment pricepoints
	 * @type {FacebookPaymentPricepoints}
	 */
	public FacebookPaymentPricepoints payment_pricepoints;

	/**
	 * The person's political views
	 * @type {String}
	 */
	public String political;

	/**
	 * The person's PGP public key
	 * @type {String}
	 */
	public String public_key;

	/**
	 * The person's favorite quotes
	 * @type {String}
	 */
	public String quotes;

	/**
	 * The person's relationship status
	 * @type {String}
	 */
	public String relationship_status;

	/**
	 * The relationship between user and family member.
	 * @type {String}
	 */
	public String relationship;

	/**
	 * The person's religion
	 * @type {String}
	 */
	public String religion;

	/**
	 * Security settings
	 * @type {FacebookSecuritySettings}
	 */
	public FacebookSecuritySettings security_settings;

	/**
	 * The time that the shared loginneeds to be upgraded to Business Manager by
	 * if date is {01.01.0001 0:00:00} then date is not received from server
	 * @type {Date}
	 */
	public Date shared_login_upgrade_required_by;

	/**
	 * Shortened, locale-aware name for the person
	 * @type {String}
	 */
	public String short_name;

	/**
	 * The person's significant other
	 * @type {FacebookUser}
	 */
	public FacebookUser significant_other;

	/**
	 * Sports played by the person
	 * @type {FacebookExperience}
	 */
	public FacebookExperience sports;

	/**
	 * Platform test group
	 * @type {Integer}
	 */
	public Integer test_group;

	/**
	 * A string containing an anonymous, but unique identifier for the person. You can use this identifier with third parties
	 * @type {String}
	 */
	public String third_party_id;

	/**
	 * The person's current timezone offset from UTC
	 * Type: float (min: -24) (max: 24)
	 * @type {Short}
	 */
	public Short timezone;

	/**
	 * Updated time
	 * if date is {01.01.0001 0:00:00} then date is not received from server
	 * @type {Date}
	 */
	public Date updated_time;

	/**
	 * Latest user ref that matches a given PSID that should be invalidated. 
	 * This should only be used for anonymous messaging PSID migration
	 * @type {String}
	 */
	public String user_ref;

	/**
	 * Indicates whether the account has been verified. This is distinct from the is_verified field.
	 *  Someone is considered verified if they take any of the following actions:
	 * * Register for mobile
	 * * Confirm their account via SMS
	 * * Enter a valid credit card
	 * @type {String}
	 */
	public String verified;

	/**
	 * Video upload limits
	 * @type {FacebookVideoUploadLimits}
	 */
	public FacebookVideoUploadLimits video_upload_limits;

	/**
	 * Can the viewer send a gift to this person?
	 * @type {String}
	 */
	public String viewer_can_send_gift;

	/**
	 * The person's website
	 * @type {String}
	 */
	public String website;

	/**
	 * Details of a person`s work experience
	 * @type {FacebookWorkExperience[]}
	 */
	public FacebookWorkExperience[] work;

	/**
	 * Pages this User has a role on.
	 * @type {FacebookUserAccounts}
	 */
	public FacebookUserAccounts accounts;

	/**
	 * Achievements made in Facebook games
	 * @type {FacebookUserAchievements}
	 */
	public FacebookUserAchievements achievements;

	/**
	 * Ad studies that this person can view
	 * @type {FacebookUserAdStudies}
	 */
	public FacebookUserAdStudies ad_studies;

	/**
	 * The advertising accounts to which this person has access
	 * @type {FacebookUserAdaccounts}
	 */
	public FacebookUserAdaccounts adaccounts;

	/**
	 * Insights data for the person's Audience Network apps.
	 * @type {FacebookUserAdnetworkanalytics}
	 */
	public FacebookUserAdnetworkanalytics adnetworkanalytics;

	/**
	 * The photo albums this person has created
	 * @type {FacebookUserAlbums}
	 */
	public FacebookUserAlbums albums;

	/**
	 * App requests.
	 * @type {FacebookApprequestformerrecipients}
	 */
	public FacebookApprequestformerrecipients apprequestformerrecipients;

	/**
	 * App requests.
	 * @type {FacebookUserApprequests}
	 */
	public FacebookUserApprequests apprequests;

	/**
	 * The 3D assets owned by the user
	 * @type {FacebookUserAsset3ds}
	 */
	public FacebookUserAsset3ds asset3ds;

	/**
	 * The books listed on this person's profile.
	 * @type {FacebookUserBooks}
	 */
	public FacebookUserBooks books;

	/**
	 * Business users corresponding to the user.
	 * @type {FacebookUserBusinessUsers}
	 */
	public FacebookUserBusinessUsers business_users;

	/**
	 * Businesses associated with the user
	 * @type {FacebookUserBusinesses}
	 */
	public FacebookUserBusinesses businesses;

	/**
	 * The curated collections created by this user
	 * @type {FacebookUserCuratedCollections}
	 */
	public FacebookUserCuratedCollections curated_collections;

	/**
	 * Custom labels.
	 * @type {FacebookUserCustomLabels}
	 */
	public FacebookUserCustomLabels custom_labels;

	/**
	 * The domains the user admins
	 * @type {FacebookUserDomains}
	 */
	public FacebookUserDomains domains;

	/**
	 * Events for this person. By default this does not include events the person has declined or not replied to
	 * @type {FacebookUserEvents}
	 */
	public FacebookUserEvents events;

	/**
	 * This person's family relationships.
	 * @type {FacebookUserFamily}
	 */
	public FacebookUserFamily family;

	/**
	 * Developers' favorite requests to the Graph API.
	 * @type {FacebookUserFavoriteRequests}
	 */
	public FacebookUserFavoriteRequests favorite_requests;

	/**
	 * The person's custom friend lists
	 * @type {FacebookUserFriendlists}
	 */
	public FacebookUserFriendlists friendlists;

	/**
	 * A person's friends.
	 * @type {FacebookUserFriends}
	 */
	public FacebookUserFriends friends;

	/**
	 * Games this person likes.
	 * @type {FacebookUserGames}
	 */
	public FacebookUserGames games;

	/**
	 * A list of Facebook Groups of which a person is an admin.
	 * @type {FacebookUserGroups}
	 */
	public FacebookUserGroups groups;

	/**
	 * Businesses can claim ownership of multiple apps using Business Manager. 
	 * This edge returns the list of IDs that this user has in any of those other apps
	 * @type {FacebookUserIDsForBusiness}
	 */
	public FacebookUserIDsForBusiness ids_for_business;

	/**
	 * A list of lead generation forms belonging to Pages that the user has advertiser permissions on
	 * @type {FacebookUserLeadgenForms}
	 */
	public FacebookUserLeadgenForms leadgen_forms;

	/**
	 * All the Pages this person has liked.
	 * @type {FacebookUserLikes}
	 */
	public FacebookUserLikes likes;

	/**
	 * Live encoders owned by this person.
	 * @type {FacebookUserLiveEncoders}
	 */
	public FacebookUserLiveEncoders live_encoders;

	/**
	 * Live videos from this person
	 * @type {FacebookUserLiveVideos}
	 */
	public FacebookUserLiveVideos live_videos;

	/**
	 * Movies this person likes
	 * @type {FacebookUserMovies}
	 */
	public FacebookUserMovies movies;

	/**
	 * Music this person likes
	 * @type {FacebookUserMusic}
	 */
	public FacebookUserMusic music;

	/**
	 * The permissions that the person has granted this app
	 * @type {FacebookUserPermissions}
	 */
	public FacebookUserPermissions permissions;

	/**
	 * Photos the person is tagged in or has uploaded.
	 * @type {FacebookUserPhotos}
	 */
	public FacebookUserPhotos photos;

	/**
	 * The person's profile picture
	 * @type {FacebookUserPicture}
	 */
	public FacebookUserPicture picture;

	/**
	 * Developers' Graph API request history
	 * @type {FacebookUserRequestHistory}
	 */
	public FacebookUserRequestHistory request_history;

	/**
	 * A list of rich media documents belonging to Pages that the user has advertiser permissions on
	 * @type {FacebookUserRichMediaDocuments}
	 */
	public FacebookUserRichMediaDocuments rich_media_documents;

	/**
	 * Any session keys that the app knows the user by
	 * @type {FacebookUserSessionKeys}
	 */
	public FacebookUserSessionKeys session_keys;

	/**
	 * A list of filters that can be applied to the News Feed edge
	 * @type {FacebookUserStreamFilters}
	 */
	public FacebookUserStreamFilters stream_filters;

	/**
	 * Friends that can be tagged in content published via the Graph API
	 * @type {FacebookUserTaggableFriends}
	 */
	public FacebookUserTaggableFriends taggable_friends;

	/**
	 * List of tagged places for this person. It can include tags on videos, posts, statuses or links
	 * @type {FacebookUserTaggedPlaces}
	 */
	public FacebookUserTaggedPlaces tagged_places;

	/**
	 * TV shows this person likes
	 * @type {FacebookUserTelevision}
	 */
	public FacebookUserTelevision television;

	/**
	 * Video broadcasts from this person
	 * @type {FacebookUserVideoBroadcasts}
	 */
	public FacebookUserVideoBroadcasts video_broadcasts;

	/**
	 * Videos the person is tagged in or uploaded
	 * @type {FacebookUserVideos}
	 */
	public FacebookUserVideos videos;

	/**
	 * Gets or sets the feed.
	 * @type {FacebookFeed}
	 */
	public FacebookFeed feed;

	}

