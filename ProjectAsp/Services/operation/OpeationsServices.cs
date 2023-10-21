
namespace ProjectAsp.Services.operation;

public class OpeationsServices:IOperationServices
{
    private readonly ApplicationDBContext _context;

    public OpeationsServices(ApplicationDBContext context)
    {
        _context = context;
    }
    public async Task<Operation> Add(Operation operation)
    {
       await _context.Operations.AddAsync(operation);
        _context.SaveChanges();
        return operation;
    }
}