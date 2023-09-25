namespace Recipe.API.Helpers;

public static class Constants
{
    public const string RecipeImageFolder = @"D:\Codes\RecipeAppImages";
    public const string SecretKey = "This is my custom Secret key for authentication";
    public static HashSet<string> InvalidatedTokens { get; set; } = new HashSet<string>();

}