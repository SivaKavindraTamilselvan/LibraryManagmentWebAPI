using LibraryManagement.BuisnessLayerLibrary.Services;
using LibraryManagement.DTOs;
using LibraryManagement.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MemberController : ControllerBase
{
    private readonly MemberService memberService;
    public MemberController(MemberService memberService)
    {
        this.memberService = memberService;
    }

    [HttpGet]
    public ActionResult<GetMemberDTO> GetMember(int id)
    {
        try
        {
            var result = memberService.GetMemberById(id);
            if (result == null)
            {
                throw new InvalidMemberException("User Not Found");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetOfMemberByRole")]
    public ActionResult<GetMemberDTO> GetListOfMemberByRole(int id)
    {
        try
        {
            var result = memberService.GetMemberByRole(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetMemberByEmail")]
    public ActionResult<GetMemberDTO> GetMemberByEmail(string email)
    {
        try
        {
            var result = memberService.GetMemberByEmail(email);
            if (result == null)
            {
                throw new InvalidMemberException("User Not Found");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetMemberByPhoneNumber")]
    public ActionResult<GetMemberDTO> GetMemberByPhoneNumber(string PhoneNumber)
    {
        try
        {
            var result = memberService.GetMemberByPhoneNumber(PhoneNumber);
            if (result == null)
            {
                throw new InvalidMemberException("User Not Found");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("GetAllMembers")]
    public ActionResult<GetMemberDTO> GetAllMembers()
    {
        try
        {
            var result = memberService.GetAllMembers();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public ActionResult<GetMemberDTO> CreateMember(CreateMemberDTO createMemberDTO)
    {
        try
        {
            var result = memberService.AddMemberService(createMemberDTO);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("Update The Member Type By Member Id")]
    public ActionResult<GetMemberDTO> UpdateTheMemberTypeByMemberId(int id, int MemberTypeId)
    {
        try
        {
            var result = memberService.UpdateTheMemberTypeByMemberId(id, MemberTypeId);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("Update The Member Type By Member Email")]
    public ActionResult<GetMemberDTO> UpdateTheMemberTypeByMemberEmail(string email, int MemberTypeId)
    {
        try
        {
            var result = memberService.UpdateTheMemberTypeByEmail(email, MemberTypeId);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("Update The Member Type By Member Phone Number")]
    public ActionResult<GetMemberDTO> UpdateTheMemberTypeByMemberPhoneNumber(string PhoneNumber, int MemberTypeId)
    {
        try
        {
            var result = memberService.UpdateTheMemberTypeByPhoneNumber(PhoneNumber, MemberTypeId);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("Activate The Member By Email")]
    public ActionResult<GetMemberDTO> ActivateMemberEmail(string Email)
    {
        try
        {
            var result = memberService.ActivateTheMemberByEmail(Email);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("Activate The Member By Member Id")]
    public ActionResult<GetMemberDTO> ActivateMemberMemberId(int memberid)
    {
        try
        {
            var result = memberService.ActivateTheMemberByMemberId(memberid);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("Activate The Member By Phone Number")]
    public ActionResult<GetMemberDTO> ActivateMemberPhoneNumber(string PhoneNumber)
    {
        try
        {
            var result = memberService.ActivateTheMemberByPhoneNumber(PhoneNumber);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("DeActivate The Member By Email")]
    public ActionResult<GetMemberDTO> DeactivateMemberEmail(string Email)
    {
        try
        {
            var result = memberService.DeactivateTheMemberByEmail(Email);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("DeActivate The Member By Member Id")]
    public ActionResult<GetMemberDTO> DeactivateMemberMemberId(int memberid)
    {
        try
        {
            var result = memberService.DeactivateTheMemberByMemberId(memberid);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("DeActivate The Member By Phone Number")]
    public ActionResult<GetMemberDTO> DeactivateMemberPhoneNumber(string PhoneNumber)
    {
        try
        {
            var result = memberService.DeactivateTheMemberByPhoneNumber(PhoneNumber);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}