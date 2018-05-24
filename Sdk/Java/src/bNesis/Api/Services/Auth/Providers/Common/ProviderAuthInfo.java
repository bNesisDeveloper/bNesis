package bNesis.Api.Services.Auth.Providers.Common;

/**
 * Interface for authentication info obtained after login to a provider.
 */
public class ProviderAuthInfo
{
    /**
     * Gets the base URL to the service.
     */
    String ServiceUrl;

    /**
     * Gets the service access info. All needed data including access token needed for communication with the service.
     */
    String AccessInfo; //toDo I have done full access to Property for test my task - create methods Validation Token, 
                                    //toDo later need set readonly access

    /**
     * Gets the client identifier of the provider account.
     */
    String ClientId; //toDo I have done full access to Property for test my task - create methods Validation Token, 
    //toDo later need set readonly access

    /**
     * Gets the client secret of the provider account.
     */
    String ClientSecret; //toDo I have done full access to Property for test my task - create methods Validation Token, 
    //toDo later need set readonly access

    /**
     * Gets the user login.
     */
    String Login; //toDo I have done full access to Property for test my task - create methods Validation Token, 
    //toDo later need set readonly access

    /**
     * Gets the user password.
     */
    String Password; //toDo I have done full access to Property for test my task - create methods Validation Token, 
    //toDo later need set readonly access

    /**
     * Gets the logged in user ID.
     */
    String UserId; //toDo I have done full access to Property for test my task - create methods Validation Token, 
    //toDo later need set readonly access

    /**
     * Gets a value indicating whether to use Sandbox mode rather than Live one.
     */
    Boolean IsSandbox;

    /**
     * Gets or sets a value some Additional Data.
     */
    String AdditionalData;
}