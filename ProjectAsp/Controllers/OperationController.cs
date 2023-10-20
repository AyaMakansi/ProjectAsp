using Microsoft.AspNetCore.Mvc;
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
    
}