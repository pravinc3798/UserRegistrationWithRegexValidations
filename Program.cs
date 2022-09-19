using System.Text.RegularExpressions;

namespace UserRegistrationWithRegexValidations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nameNumberEmail = new NameNumberEmailValidations();
            var pass = new PasswordValidation();

            Console.Write("\n 1. Check Name (Start with Caps and has minimum 3 Characters) \n 2. Check Number (91 1234567890)(2 digits space 10 digits) \n 3. Email Check (auto checks the list of emails provided in the document) \n 4. Password Check \n 5. Validate Password Using Lambda Expression \n 6. Exit \n\n >>>> Enter desired input : "); var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    {
                        Console.Write("\n Enter a NAME to check : "); var name = Console.ReadLine();
                        nameNumberEmail.Check(nameNumberEmail.NameValidation, name);
                        Main(args);
                        break;
                    }
                case "2":
                    {
                        Console.Write("\n Enter a NUMBER to check : "); var number = Console.ReadLine();
                        nameNumberEmail.Check(nameNumberEmail.NumberValidation, number);
                        Main(args);
                        break;
                    }
                case "3":
                    {
                        Console.WriteLine();
                        var emails = "abc@yahoo.com,abc-100@yahoo.com,abc.100@yahoo.com,abc111@abc.com,abc-100@abc.net,abc.100@abc.com.au,abc@1.com,abc@gmail.com.com,abc+100@gmail.com";
                        var emailList = emails.Split(',');
                        foreach (var email in emailList)
                            nameNumberEmail.Check(nameNumberEmail.EmailValidation, email);
                        Main(args);
                        break;
                    }
                case "4":
                    {
                        Console.Write("\n 1. Any password with length >8 will be accepted  \n 2. Length>8 and Atleast One Uppercase Character \n 3. Length>8 and Atleast One Uppercase and Atleast One number \n 4. Atmost One special character and Length>8 and Atleast One Uppercase and Atleast One number \n 5. Back \n\n >>>> Enter desired security level : "); var securityLevel = Console.ReadLine();
                        Console.Write("\n >>>>>> Enter password to check : "); var password = Console.ReadLine();

                        switch (securityLevel)
                        {
                            case "1": pass.Check(pass.MinimumLength8, password); Main(args); break;
                            case "2": pass.Check(pass.OneUpperAndL8, password); Main(args); break;
                            case "3": pass.Check(pass.OneNumbericOneUL8, password); Main(args); break;
                            case "4": pass.Check(pass.ExactlyOneSpecialCharacter, password); Main(args); break;
                            case "5": Main(args); break;
                            default: Console.WriteLine("\n !! Invalid Input !! \n"); Main(args); break;
                        }

                        break;
                    }
                case "5":
                    {
                        Console.Write("\n >>>>>> Enter password to check : "); var passwordL = Console.ReadLine();
                        Regex passwordValidation = new Regex("^(.{,7}|[^A-Z]*|[^0-9]*|[^.]*\\W{2,}[^.]*|[^\\W]+)$");

                        Func<Regex, bool> checkPass = e => e.IsMatch(passwordL);

                        if (!checkPass(passwordValidation))
                            Console.WriteLine("Test Passed For : " + passwordL);
                        else
                            Console.WriteLine("Test Failed For : " + passwordL);

                        Main(args);
                        break;
                    }
                case "6":
                    {
                        break;
                    }
                default: Console.WriteLine("\n !! Invalid Input !! \n"); Main(args); break;

            }
        }
    }
}