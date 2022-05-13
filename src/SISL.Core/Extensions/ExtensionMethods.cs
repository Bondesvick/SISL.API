using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace SISL.Core.Extensions
{
    public static class ExtensionMethods
    {
        public static string Purge(this string value)
        {
            return value?.Replace("'", "").Replace("\"", "");
        }

        public static string ToTitleCase(this string aString)
        {
            return new CultureInfo("en").TextInfo.ToTitleCase(aString?.ToLower()!);
        }

        public static byte[] ConvertBase64ToByte(this string base64String)
        {
            return Convert.FromBase64String(base64String);
        }

        public static void Converting(this string base64String)
        {
            byte[] blob = Convert.FromBase64String(base64String);
            var fileExt = GetFileExtension(base64String);

            var path = @"C:\Picture";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var filePath = string.Format(@"{0}\{1}.{2}", path, "mypicture", fileExt);
            File.WriteAllBytes(filePath, blob);
        }

        public static string GetFileExtension(string base64String)
        {
            var data = base64String.Substring(0, 5);

            switch (data.ToUpper())
            {
                case "IVBOR":
                    return "png";

                case "/9J/4":
                    return "jpg";

                case "AAAAF":
                    return "mp4";

                case "JVBER":
                    return "pdf";

                case "AAABA":
                    return "ico";

                case "UMFYI":
                    return "rar";

                case "E1XYD":
                    return "rtf";

                case "U1PKC":
                    return "txt";

                case "MQOWM":
                case "77U/M":
                    return "srt";

                default:
                    return string.Empty;
            }
        }
    }
}