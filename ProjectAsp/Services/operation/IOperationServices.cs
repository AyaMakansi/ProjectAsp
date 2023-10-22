

namespace ProjectAsp.Services.operation;

public interface IOperationServices
{
   Task<Operation> Add(Operation operation);
   Task<IEnumerable<Operation>> GetAll();
  
}