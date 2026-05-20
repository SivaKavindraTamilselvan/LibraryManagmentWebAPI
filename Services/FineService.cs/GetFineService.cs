using LibraryManagement.DTOs;
using LibraryManagement.Interfaces;
using LibraryManagement.Models;

namespace LibraryManagement.BuisnessLayerLibrary.Services;

public class FineService :IFineService 
{
    protected readonly IFineRepository fineRepository;
    public FineService(IFineRepository fineRepository)
    {
        this.fineRepository = fineRepository;
    }
    // add payments for the fines

    public List<GetFineDTO> GetAllFines()
    {
        var fines = fineRepository.GetAll();
        return fines.OrderBy(f=>f.FineId).Select(fine => new GetFineDTO
        {
            FineId = fine.FineId,
            BorrowingId = fine.BorrowingId,
            FineCategoryId = fine.FineCategoryId,
            FineAmount = fine.FineAmount,
            IsPaidFully = fine.IsPaidFully,
            createdAt = fine.createdAt,
            updatedAt = fine.updatedAt,
        }).ToList();
    }
}