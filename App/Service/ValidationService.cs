using System.Text.RegularExpressions;
using System;
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
        public static bool ValidateString(string input){
            return !String.IsNullOrWhiteSpace(input);
        }
        public static bool ValidateAddress(string input){
            string pattern= @"^[#.0-9a-zA-Z\s,-]+$";
            if(ValidateString(input)){
                return ValidateFromRegex(input, pattern);
            }else{
                return false;
            }
            
        }
        private static bool ValidateFromRegex(string input, string pattern)
        {
            Regex rx = new Regex(pattern);
            return rx.IsMatch(input);
        }
        
        
    }
}