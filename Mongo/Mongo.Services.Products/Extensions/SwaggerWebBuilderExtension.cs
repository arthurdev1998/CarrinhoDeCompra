using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace Mongo.Services.Products.Extensions;

public static class SwaggerWebBuilderExtension
{
    public static WebApplicationBuilder AddSwaggerConfigutarion(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(option =>
       {
           option.AddSecurityDefinition(name: JwtBearerDefaults.AuthenticationScheme, securityScheme: new OpenApiSecurityScheme
           {
               Name = "Authorization",
               Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
               In = ParameterLocation.Header,
               Type = SecuritySchemeType.ApiKey,
               Scheme = "Bearer"
           });
           option.AddSecurityRequirement(new OpenApiSecurityRequirement
   {
        {
            new OpenApiSecurityScheme
            {
                Reference= new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id=JwtBearerDefaults.AuthenticationScheme
                }
            }, new string[]{}
        }
   });
       });

        return builder;
    }
}