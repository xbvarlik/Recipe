namespace Recipe.API.Helpers;

public static class ImageHandler
{
    public static string? SaveImageToLocalStorage(byte[]? byteImage, string path)
    {
        if (byteImage == null) return null;
        
        // Converting image to base64 string.
        var base64Image = Convert.ToBase64String(byteImage);
        var base64ImageArray = base64Image.Split(',');
        var imageExtension = base64ImageArray[0].Split('/')[1].Split(';')[0];
        var image = base64ImageArray[1];
        
        // Creating image name.
        var imageName = Guid.NewGuid().ToString() + "." + imageExtension;
        
        // Saving image to local storage.
        var imagePath = Path.Combine(path, imageName);
        var bytes = Convert.FromBase64String(image);
        File.WriteAllBytes(imagePath, bytes);
        
        return imageName;
    }
    
    public static byte[]? ReadImageFromLocalStorage(string? imageName, string path)
    {
        if (imageName == null) return null;

        var imagePath = Path.Combine(path, imageName);
        return File.ReadAllBytes(imagePath);
    }
}