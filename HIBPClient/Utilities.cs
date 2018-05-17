using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HIBPClient
{
    public static class ExtensionMethods
    {
        public static bool IsValidEmail(this String email)
        {
            if (String.IsNullOrEmpty(email) || !Regex.Match(email, @"\b+(?!^.{256})[a-zA-Z0-9\.\-_\+]+@[a-zA-Z0-9\.\-_]+\.[a-zA-Z]+\b").Success)
                return false;
            else
                return true;

        }
    }
}
