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
        if(dto.Parent==null)
       { var branch = new Branch
        {
            Branch_Name = dto.Branch_Name,
            Branch_Location = dto.Branch_Location,
            Type = 0,
            Comp_Id = dto.Comp_Id,
            Parent=dto.Parent,
        };
        await _branchservices.Add(branch);
        return Ok(branch);
        }else
        {
            var branches =await _branchservices.GetAll();
            foreach (var b in branches)
            {
                if (dto.Parent.Id==b.Id && b.Type==0)
                {
                    var branch = new Branch
                    {
                        Branch_Name = dto.Branch_Name,
                        Branch_Location = dto.Branch_Location,
                        Type = Branch.Branch_type.Secondary,
                        Comp_Id = dto.Comp_Id,
                        Parent=dto.Parent,    
                    };
                    await _branchservices.Add(branch);
                    return Ok(branch);
                } 
            }
            
        
        }

        return BadRequest($"not found");
    }
}