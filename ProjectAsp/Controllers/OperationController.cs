using Microsoft.AspNetCore.Mvc;
using ProjectAsp.Dtos;
using ProjectAsp.Services.operation;

namespace ProjectAsp.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class OperationController:ControllerBase
{
    private readonly IOperationServices _operationservices;
   
    public OperationController(IOperationServices operationServices)
    {
        _operationservices = operationServices;
    }

    [HttpPost]
    public async Task<IActionResult> AddOperationAsync([FromBody]OperationDto dto)
    {
        if(dto.branch.Type==0)
        { var operation = new Operation
        {
            Date = dto.Date,
            Quantity = dto.Quantity,
            Branch_Id = dto.Branch_Id,
            Prouduct_Id = dto.Prouduct_Id,
        };
        await _operationservices.Add(operation);
        return Ok(operation);    
        }
        else{  
            var operation = new Operation
                    {
                        Date = dto.Date,
                        Quantity = dto.Quantity,
                        Branch_Id = dto.Branch_Id,
                        Prouduct_Id = dto.Prouduct_Id,
                    };
             await _operationservices.Add(operation);
                    return Ok(operation);
        }
       

    }
    
}