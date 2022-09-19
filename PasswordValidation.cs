using System.Text.RegularExpressions;

namespace UserRegistrationWithRegexValidations
{
    public class PasswordValidation
    {
        public Regex MinimumLength8 = new Regex("^(.{0,7})$");
        public Regex OneUpperAndL8 = new Regex("^(.{0,7}|[^A-Z]*)$"); 
        public Regex OneNumbericOneUL8 = new Regex("^(.{0,7}|[^A-Z]*|[^0-9]*)$");
        public Regex ExactlyOneSpecialCharacter = new Regex("^(.{0,7}|[^A-Z]*|[^0-9]*|[^.]*\\W{2,}[^.]*|[^\\W]+)$");

        public void Check(Regex validation, string pass)
        {
            var result = (!validation.IsMatch(pass)) ? " ! Test Passed For : " : " X Test Failed For : ";
            Console.WriteLine("{0} {1}", result, pass);
        }
    }
}