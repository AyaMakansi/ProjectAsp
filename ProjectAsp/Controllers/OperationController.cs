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
        if(dto.Branch.Parent==null)
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
        else
        {
            double sum2 = 0;
            double sum1 = 0;
            var parent = dto.Branch.Parent;
            var product_id = dto.Prouduct_Id;
           var operations=await _operationservices.GetAll();
            foreach (var oper in operations)
            {
                if(oper.branch.Parent==parent && oper.Prouduct_Id==product_id)
                sum2 += oper.Quantity;
                else if (oper.branch.Id == parent.Id)
                {
                    sum1 += oper.Quantity;
                }
            }

            if (sum1 - sum2 - dto.Quantity >= 0)
            {
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
            else
            {
                return BadRequest($"can't add operation");
            }
    }
       

    }
  
  
}