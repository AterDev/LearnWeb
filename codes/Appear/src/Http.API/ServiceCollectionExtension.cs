using Http.API;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Http.API;

public static class ServiceCollectionExtension
{
    /// <summary>
    /// 添加web服务组件，如身份认证/swagger/cors
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddWebComponents(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwagger();
        services.AddJwtAuthentication(configuration);
        services.AddCors();
        return services;
    }

    /// <summary>
    /// 添加 jwt 验证
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(cfg =>
        {
            cfg.SaveToken = true;
            var sign = configuration.GetSection("Authentication")["Jwt:Sign"];
            if (string.IsNullOrEmpty(sign))
            {
                throw new Exception("未找到有效的Jwt配置");
            }
            cfg.TokenValidationParameters = new TokenValidationParameters()
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(sign)),
                ValidIssuer = configuration.GetSection("Authentication")["Jwt:ValidIssuer"],
                ValidAudience = configuration.GetSection("Authentication")["Jwt:ValidAudiences"],
                ValidateIssuer = true,
                ValidateLifetime = true,
                RequireExpirationTime = true,
                ValidateIssuerSigningKey = true
            };
        });
        return services;
    }

    /// <summary>
    /// 添加swagger服务
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
            c.SwaggerDoc("admin", new OpenApiInfo
            {
                Title = "Appear",
                Description = "Admin API 文档. 更新时间:" + DateTime.Now.ToString("yyyy-MM-dd H:mm:ss"),
                Version = "v1"
            });
            c.SwaggerDoc("client", new OpenApiInfo
            {
                Title = "Appear client",
                Description = "Client API 文档. 更新时间:" + DateTime.Now.ToString("yyyy-MM-dd H:mm:ss"),
                Version = "v1"
            });
            var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly);
            foreach (var item in xmlFiles)
            {
                try
                {
                    c.IncludeXmlComments(item, includeControllerXmlComments: true);
                }
                catch (Exception) { }
            }
            c.SupportNonNullableReferenceTypes();
            c.DescribeAllParametersInCamelCase();
            c.CustomOperationIds((z) =>
            {
                var descriptor = (ControllerActionDescriptor)z.ActionDescriptor;
                return $"{descriptor.ControllerName}_{descriptor.ActionName}";
            });
            c.SchemaFilter<EnumSchemaFilter>();
            c.MapType<DateOnly>(() => new OpenApiSchema
            {
                Type = "string",
                Format = "date"
            });
        });
        return services;
    }

    public static IServiceCollection AddCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("default", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });
        });
        return services;
    }
}
