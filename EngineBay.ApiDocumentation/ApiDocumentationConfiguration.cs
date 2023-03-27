namespace EngineBay.ApiDocumentation
{
    public abstract class ApiDocumentationConfiguration
    {
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