using Microsoft.AspNetCore.Mvc;
using ProjectAsp.Dtos;
using ProjectAsp.Models;
using ProjectAsp.Services.branch;

namespace ProjectAsp.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class BranchController : ControllerBase
{
    private readonly IBranchServices _branchservices;

    public BranchController(IBranchServices branchServices)
    {
        _branchservices = branchServices;
    }
    [HttpPost]
    public async Task<IActionResult> AddBranchAsync([FromBody]BranchDto dto)
    {
        var branch = new Branch
        {
            Branch_Name = dto.Branch_Name,
            Branch_Location = dto.Branch_Location,
            Type = (Branch.Branch_type)dto.Type,
            Comp_Id = dto.Comp_Id,
            Parent = dto.Parent,
        };
        await _branchservices.Add(branch);
        return Ok(branch);
    }
}