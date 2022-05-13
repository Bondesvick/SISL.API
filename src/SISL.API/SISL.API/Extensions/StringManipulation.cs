using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SISL.API.Extensions
{
    public static class StringManipulation
    {
        public static string ToTitleCase(string aString)
        {
            return new CultureInfo("en").TextInfo.ToTitleCase(aString.ToLower());
        }
    }
}