using LibraryManagement.DTOs;

namespace LibraryManagement.Interfaces;

public interface IFineService
{
    public List<GetFineDTO> GetAllFines();
}