using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Recipe.API.Mappings;
using Recipe.API.Services;
using Recipe.Repository;
using Swashbuckle.AspNetCore.Filters;

namespace Recipe.API;

public static class Bootstrapper
{
    public static void AddMapping(this IServiceCollection services)
    {
        services.AddScoped<CategoryMapper>();
        services.AddScoped<FavoriteRecipesMapper>();
        services.AddScoped<IngredientMapper>();
        services.AddScoped<RecipeMapper>();
        services.AddScoped<StepMapper>();
        services.AddScoped<RecipePointsAndCommentsMapper>();
        services.AddScoped<UserMapper>();
        services.AddScoped<UserCredentialsMapper>();
    }
    
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<CategoryService>();
        services.AddScoped<FavoriteRecipesService>();
        services.AddScoped<RecipePointsAndCommentsService>();
        services.AddScoped<IngredientService>();
        services.AddScoped<RecipeService>();
        services.AddScoped<StepService>();
        services.AddScoped<UserService>();
        services.AddScoped<AuthService>();
        services.AddScoped<TokenService>();
    }
    
    public static void AddSqlContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(x =>
        {
            x.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
        });
    }
    
    public static void AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options => 
        {
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
            {
                Description = "Standard Authorization header using the Bearer scheme(\"bearer {token}\")",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
    
            options.OperationFilter<SecurityRequirementsOperationFilter>();
        });
    }

    public static void AddAuthenticationOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => // this is for validation of token
            {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("SecretKey").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
    }
}