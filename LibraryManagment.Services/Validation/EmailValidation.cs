using System.Text.RegularExpressions;
using LibraryManagement.Exceptions;

namespace LibraryManagement.BuisnessLayerLibrary.Validation;

public class EmailValidation
{
    //implementation of email validation by using regex pattern
    public static void isValidEmail(string email)
    {
        string checkEmail=email.Trim();

        //regex pattern
        string pattern=@"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        if(!Regex.IsMatch(checkEmail, pattern, RegexOptions.IgnoreCase)){
            throw new EmailException();
        }        
    }
}