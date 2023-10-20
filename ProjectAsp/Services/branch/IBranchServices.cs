
namespace ProjectAsp.Services.branch;

public interface IBranchServices
{
    Task<Branch> Add(Branch branch);
    
}