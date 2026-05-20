using LibraryManagement.BuisnessLayerLibrary.Services;
using LibraryManagement.DTOs;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MemberController : ControllerBase
{
    private readonly AdminService adminService;
    public MemberController(AdminService adminService)
    {
        this.adminService = adminService;
    }

    [HttpGet]
    public ActionResult<GetMemberDTO> GetMember(int id)
    {
        try
        {
            var result = adminService.GetMemberById(id);
            return Ok(result);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        } 
    }
}