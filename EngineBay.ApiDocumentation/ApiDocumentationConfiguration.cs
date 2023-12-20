namespace EngineBay.ApiDocumentation
{
    public abstract class ApiDocumentationConfiguration
    {
        public static AuthenticationTypes GetAuthenticationMethod()
        {
            var authenticationMethodEnvironmentVariable = Environment.GetEnvironmentVariable(EnvironmentVariableConstants.AUTHENTICATIONMETHOD);

            if (string.IsNullOrEmpty(authenticationMethodEnvironmentVariable))
            {
                Console.WriteLine($"Warning: {EnvironmentVariableConstants.AUTHENTICATIONMETHOD} not configured, using default '{DefaultApiDocumentationConfigurationConstants.DefaultAuthentication}'.");
                return DefaultApiDocumentationConfigurationConstants.DefaultAuthentication;
            }

            var authenticationType = (AuthenticationTypes)Enum.Parse(typeof(AuthenticationTypes), authenticationMethodEnvironmentVariable);

            if (!Enum.IsDefined(typeof(AuthenticationTypes), authenticationType) | authenticationType.ToString().Contains(',', StringComparison.InvariantCulture))
            {
                Console.WriteLine($"Warning: '{authenticationMethodEnvironmentVariable}' is not a valid {EnvironmentVariableConstants.AUTHENTICATIONMETHOD} configuration option. Valid options are: ");
                foreach (string name in Enum.GetNames(typeof(AuthenticationTypes)))
                {
                    Console.Write(name);
                    Console.Write(", ");
                }

                throw new ArgumentException($"Invalid {EnvironmentVariableConstants.AUTHENTICATIONMETHOD} configuration.");
            }

            return authenticationType;
        }

        public static bool IsApiDocumentationEnabled()
        {
            var apiDocumentationEnvironmentVariable = Environment.GetEnvironmentVariable(EnvironmentVariableConstants.APIDOCUMENTATIONENABLED);

            if (string.IsNullOrEmpty(apiDocumentationEnvironmentVariable))
            {
                return false;
            }

            if (apiDocumentationEnvironmentVariable.Equals("true", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Warning: {EnvironmentVariableConstants.APIDOCUMENTATIONENABLED} was set to 'true', this will enable OpenApi 3.0 documentation on /swagger/v1/swagger.json and /swagger/index.html");
                return true;
            }

            Console.WriteLine($"Warning: {EnvironmentVariableConstants.APIDOCUMENTATIONENABLED} was configured with an unrecognized value of '{apiDocumentationEnvironmentVariable}'.");

            return false;
        }
    }
}