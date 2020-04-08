using System;
using System.IO;


namespace TrainingCamp.Shared.Extensions
{
    public static class ExtensionMethods
    {
        public static string GetBase64Prefix(this string base64String, string filename)
        {
            var fileSuffix = Path.GetExtension(filename);
            switch (fileSuffix)
            {
                case ".jpg":
                case ".jpeg":
                case ".jfif":
                    return String.Concat("data:image/jpeg;base64,", base64String);
                case ".png":
                    return String.Concat("data:image/png;base64,", base64String);
                default:
                    return null;
            }
        }
        public static bool IsImage(this string fileName)
        {
            var fileSuffix = Path.GetExtension(fileName);
            return fileSuffix == ".jpg" || fileSuffix == ".jpeg" || fileSuffix == ".jfif" || fileSuffix == ".png";
        }
        public static string ToFirstCapital(this string text)
        {

            return !string.IsNullOrEmpty(text) ? $"{text.Substring(0, 1).ToUpper()}{text.Substring(1).ToLower()}" : text;
        }
      
    }

}
