using Lazy.SecurityLayers.DynamicCorsService.Config;
using Lazy.SecurityLayers.SecureAuth.Config;
using Lazy.SecurityLayers.SecureAuth.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Lazy.SecurityLayers.DependancyInjections
{
    public static class SecureAuthInjection
    {
        public static IServiceCollection AddSecureAuth(this IServiceCollection services, TokenParameters tokenParams)
        {
            services.AddSingleton(tokenParams);

            services.AddScoped<JwtSecurityTokenHandler>();
            services.AddScoped<TokenManager>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Administrator"));
                options.AddPolicy("ModoPolicy", policy => policy.RequireRole("Administrator", "Moderator"));

                options.AddPolicy("ConnectedPolicy", policy => policy.RequireAuthenticatedUser());
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                options => options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateLifetime = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = tokenParams.Issuer,
                    ValidAudience = tokenParams.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenParams.SecretKey))
                });

            services.AddCors(options =>
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins(tokenParams.Issuer)
                          .AllowAnyMethod()
                          .WithHeaders("Authorization")
                          .AllowCredentials();
                }));

            return services;
        }
        public static IServiceCollection AddDynamicCors(this IServiceCollection services, IDictionary<string, CorsParameters> corses)
        {
            foreach (KeyValuePair<string, CorsParameters> cors in corses)
            {
                services.AddCors(options =>
                    options.AddPolicy(cors.Key, policy =>
                    {
                        policy.WithOrigins(cors.Value.AllowedOrigins)
                              .WithMethods(cors.Value.Methods)
                              .WithHeaders(cors.Value.Headers);

                        if (cors.Value.AllowCredentials)
                            policy.AllowCredentials();
                        else
                            policy.DisallowCredentials();

                    }));
            }

            return services;
        }

        public static IApplicationBuilder UseSecureAuth(this IApplicationBuilder app)
        {
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
    }
}
