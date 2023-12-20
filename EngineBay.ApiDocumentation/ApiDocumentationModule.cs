namespace EngineBay.ApiDocumentation
{
    using EngineBay.Core;
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

                var authenticationType = ApiDocumentationConfiguration.GetAuthenticationMethod();

                // add OpenAPI v3 document
                switch (authenticationType)
                {
                    case AuthenticationTypes.JwtBearer:
                        services.AddOpenApiDocument(options =>
                        {
                            options.Title = "EngineBay API Documentation";
                            options.Description = "EngineBay OpenAPI v3 integration documentation";
                            options.AddSecurity("Bearer", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                            {
                                Type = OpenApiSecuritySchemeType.Http,
                                Scheme = "Bearer",
                                BearerFormat = "JWT",
                                Description = "Type into the textbox: {your JWT token}.",
                            });

                            options.OperationProcessors.Add(
                            new AspNetCoreOperationSecurityScopeProcessor("Bearer"));
                        });
                        break;
                    case AuthenticationTypes.Basic:
                        Console.WriteLine("Warning: no Basic authentication has been configured. The system is insecure.");
                        services.AddOpenApiDocument(options =>
                        {
                            options.Title = "EngineBay API Documentation";
                            options.Description = "EngineBay OpenAPI v3 integration documentation";
                            options.AddSecurity("Basic", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                            {
                                Name = "Authorization",
                                Type = OpenApiSecuritySchemeType.Http,
                                Scheme = "basic",
                                In = OpenApiSecurityApiKeyLocation.Header,
                                Description = "Basic Authorization header using the Bearer scheme.",
                            });
                            options.OperationProcessors.Add(
                            new AspNetCoreOperationSecurityScopeProcessor("Basic"));
                        });
                        break;
                    case AuthenticationTypes.None:
                        Console.WriteLine("Warning: no authentication has been configured. The system is insecure.");
                        break;
                }
            }

            return services;
        }

        public override WebApplication AddMiddleware(WebApplication app)
        {
            // Register the Swagger generator and the Swagger UI middlewares
            if (ApiDocumentationConfiguration.IsApiDocumentationEnabled())
            {
                app.UseOpenApi();
                app.UseSwaggerUi(x =>
                {
                    x.DocumentTitle = "EngineBay API Documentation";
                });
            }

            return app;
        }
    }
}