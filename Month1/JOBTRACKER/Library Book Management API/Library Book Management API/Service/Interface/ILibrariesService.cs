using Library_Book_Management_API.Models;

namespace Library_Book_Management_API.Service.Interface
{
    public interface ILibrariesService
    {

        Library GetLibrary(int libraryId);
        bool DeleteLibrary(int libraryId);
    }
}
