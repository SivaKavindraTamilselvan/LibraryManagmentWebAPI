using System.Text.RegularExpressions;
using LibraryManagement.Exceptions;

namespace LibraryManagement.BuisnessLayerLibrary.Validation;

public class NameValidation
{
    //implementation of name validation by using regex pattern
    public static void isValidName(string name)
    {
        string checkName=name.Trim();

        //regex pattern
        string pattern = @"^[a-zA-Z\s]+$";
        if(!Regex.IsMatch(checkName, pattern, RegexOptions.IgnoreCase)){
            throw new NameException();
        }        
    }
}