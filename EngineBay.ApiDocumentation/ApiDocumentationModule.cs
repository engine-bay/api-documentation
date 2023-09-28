namespace EngineBay.ApiDocumentation
{
    using EngineBay.Core;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using NSwag;
    using NSwag.Generation.Processors.Security;

    public class ApiDocumentationModule : BaseModule
    {
        public override IServiceCollection RegisterModule(IServiceCollection services, IConfiguration configuration)
        {
            if (ApiDocumentationConfiguration.IsApiDocumentationEnabled())
            {
                // Register the Swagger services
                services.AddEndpointsApiExplorer();

                // add OpenAPI v3 document
                services.AddOpenApiDocument(options =>
                {
                    options.Title = "EngineBay API Documentation";
                    options.Description = "EngineBay OpenAPI v3 integration documentation";
                    options.AddSecurity("Bearer", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                    {
                        Type = OpenApiSecuritySchemeType.Http,
                        Scheme = JwtBearerDefaults.AuthenticationScheme,
                        BearerFormat = "JWT",
                        Description = "Type into the textbox: {your JWT token}.",
                    });

                    options.OperationProcessors.Add(
                    new AspNetCoreOperationSecurityScopeProcessor("Bearer"));
                });
            }

            return services;
        }

        public override WebApplication AddMiddleware(WebApplication app)
        {
            // Register the Swagger generator and the Swagger UI middlewares
            if (ApiDocumentationConfiguration.IsApiDocumentationEnabled())
            {
                app.UseOpenApi();
                app.UseSwaggerUi3(x =>
                {
                    x.DocumentTitle = "EngineBay API Documentation";
                });
            }

            return app;
        }
    }
}