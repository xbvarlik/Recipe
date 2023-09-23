using Recipe.API.Mappings;
using Recipe.API.Services;

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
    }
}