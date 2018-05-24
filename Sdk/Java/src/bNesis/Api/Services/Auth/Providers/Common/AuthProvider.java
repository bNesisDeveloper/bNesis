package bNesis.Api.Services.Auth.Providers.Common;

import java.util.List;

/**
 * Base interface for all auth providers.
 */
public class AuthProvider
{
    /**
     * Gets or sets the base URL to the service.
     */
    String ServiceUrl;

    /**
     * Gets unique identifier of the Provider (f.e. "Google").
     */
    String ProviderId;

    /**
     * Gets or sets the bNesis developer identifier.
     */
    String bNesisDevId;

    /**
     * Additional data for auth (f.e. shop name for eCommerce).
     */
    String Data;

    /**
     * Gets or sets URL which will be redirected to by the auth provider or external service.
     */
    String RedirectUrl;

    /**
     * Gets or sets the client identifier of the provider account.
     */
    String ClientId;

    /**
     * Gets or sets the client secret of the provider account.
     */
    String ClientSecret;

    /**
     * Gets or sets the user login for basic auth.
     */
    String Login;

    /**
     * Gets or sets the user password for basic auth.
     */
    String Password;

    /**
     * Gets list of the scopes required for access the provider services.
     */
    List<String> Scopes;

    /**
     * Gets or sets a value indicating whether to use Sandbox mode rather than Live one.
     */
    Boolean IsSandbox;

    /**
     * Gets the parameters for authorization in Service. (If empty it's mean used all auth params)
     * For ApiHelp
     * Syntax parameters: 
     * default;param1,param2,param3;
     * GroupService1;param4;
     * GroupService2;param5
     * <para>or</para>
     * param1,param2,param3
     */
    String Parameters;
}
