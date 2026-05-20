using System.Text.RegularExpressions;
using LibraryManagement.Exceptions;

namespace LibraryManagement.BuisnessLayerLibrary.Validation;

public class YearValidation
{
    //implementation of year validation by using if else condition
    public static void isValidYear(int year)
    {
        if(year<1000 || year>DateTime.Now.Year)
        {
            throw new YearException();
        }
    }
}