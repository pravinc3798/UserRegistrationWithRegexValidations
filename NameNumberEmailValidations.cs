using System.Text.RegularExpressions;

namespace UserRegistrationWithRegexValidations
{
    public class NameNumberEmailValidations
    {
        public Regex NameValidation = new Regex("^[A-Z]{1}[a-z A-Z]{2,}$");
        public Regex NumberValidation = new Regex("^[0-9]{2}\\s[0-9]{10}$");
        public Regex EmailValidation = new Regex("^[a-z A-Z 0-9 .+_-]+@[a-z A-Z 0-9 -.]+[.][a-z A-Z 0-9 -]{2,}$");

        public void Check(Regex validation, string name)
        {
            var result = (validation.IsMatch(name)) ? " ! Test Passed For : " : " X Test Failed For : ";
            Console.WriteLine("{0} {1}",result,name);
        }
    }
}