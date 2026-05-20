using LibraryManagement.DTOs;

namespace LibraryManagement.Interfaces;

public interface IReturnService
{
    public GetBorrowingDTO? AddReturn(CreateReturningDTO createReturningDTO);
    public List<GetBorrowingDTO> PendingReturn();
}