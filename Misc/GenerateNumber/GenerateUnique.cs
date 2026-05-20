using LibraryManagement.DataAccessLibrary.DBContext;

namespace LibraryManagement.UniqueNumbers;

public class GenerateUnique
{
    // used to generate the unique numbers
    protected readonly LibraryManagementContext libraryManagementContext;
    public GenerateUnique(LibraryManagementContext _libraryManagement)
    {
        libraryManagementContext = _libraryManagement;
    }
    public string GenerateISBN()
    {
        Random random = new Random();

        string isbn;

        do
        {
            isbn = "";

            for (int i = 0; i < 13; i++)
            {
                isbn += random.Next(0, 10);
            }

        } while (libraryManagementContext.BookISBN.Any(b => b.ISBN == isbn));

        return isbn;
    }
    public string GenerateCopy()
    {
        Random random = new Random();

        string copy;

        do
        {
            copy = "";

            for (int i = 0; i < 8; i++)
            {
                copy += random.Next(0, 10);
            }

        } while (libraryManagementContext.BookCopy.Any(b => b.CopyNumber == copy));

        return copy;
    }
}
