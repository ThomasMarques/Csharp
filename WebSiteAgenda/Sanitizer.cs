using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace WebSiteAgenda
{
    public static class Sanitizer
    {
        public static string Sanitize(this string stringValue)
        {
            if (stringValue != null)
            {
                stringValue = Regex.Replace(stringValue,"-{2,}", "-"); // transforms multiple --- in - use to comment in sql scripts
                stringValue = Regex.Replace(stringValue, @"[*/]+", string.Empty); // removes / and * used also to comment in sql scripts
                stringValue = Regex.Replace(stringValue, @"(;|\s)(exec|execute|select|insert|update|delete|create|alter|drop|rename|truncate|backup|restore)\s", string.Empty, RegexOptions.IgnoreCase);
            }
            return stringValue;
        }

        public static string CalculateSHA1(string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            SHA1CryptoServiceProvider cryptoTransformSHA1 = new SHA1CryptoServiceProvider();
            return BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "").ToLower();
        }
    }
}