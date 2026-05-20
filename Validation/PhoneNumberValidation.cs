using System.Text.RegularExpressions;
using LibraryManagement.Exceptions;

namespace LibraryManagement.BuisnessLayerLibrary.Validation;

public class PhoneNumberValidation
{
    //implementation of phone validation by using regex pattern
    public static void isValidPhoneNumber(string phonenumber)
    {
        string checkPhoneNumber = phonenumber.Trim();
        //regex pattern
        string pattern = @"^[0-9]{10}$";
        if(!Regex.IsMatch(checkPhoneNumber,pattern))
        {
            throw new PhoneNumberException();
        }
    }
}