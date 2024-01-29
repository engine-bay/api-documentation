namespace EngineBay.ApiDocumentation.Tests
{
    using Xunit;

    public class ApiDocumentationConfigurationTests
    {
        [Fact]
        public void IsAuditingEnabledAuditingEnabledEnvironmentVariableSetToTrueReturnsTrue()
        {
            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.APIDOCUMENTATIONENABLED, "true");
            bool actual = ApiDocumentationConfiguration.IsApiDocumentationEnabled();
            Assert.True(actual);
            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.APIDOCUMENTATIONENABLED, null);
        }

        [Theory]
        [InlineData(AuthenticationTypes.JwtBearer)]
        [InlineData(AuthenticationTypes.Basic)]
        [InlineData(AuthenticationTypes.None)]
        public void IsAuditingEnabledAuditingEnabledEnvironmentVariableSetToFalseReturnsFalse(AuthenticationTypes expected)
        {
            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.APIDOCUMENTATIONAUTHENTICATIONMETHOD, expected.ToString());
            var actual = ApiDocumentationConfiguration.GetAuthenticationMethod();
            Assert.Equal(expected, actual);
            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.APIDOCUMENTATIONAUTHENTICATIONMETHOD, null);
        }
    }
}
