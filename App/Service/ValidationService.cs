using System.Text.RegularExpressions;

namespace Service
{
    public static class ValidationService
    {
        public static bool ValidatePersonName(string input)
        {
            string pattern = @"^[A-Z][A-Za-z]+ [A-Z][A-Za-z]+$";
            return ValidateFromRegex(input, pattern);
        }
        public static bool ValidateCityName(string input)
        {
            string pattern = @"^[A-Za-z \.']+$";
            return ValidateFromRegex(input, pattern);
        }
        private static bool ValidateFromRegex(string input, string pattern)
        {
            Regex rx = new Regex(pattern);
            return rx.IsMatch(input);
        }
        
    }
}