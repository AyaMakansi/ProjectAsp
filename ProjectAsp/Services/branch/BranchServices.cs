

using Microsoft.EntityFrameworkCore;

namespace ProjectAsp.Services.branch;

public class BranchServices:IBranchServices
{
    private readonly ApplicationDBContext _context;

    public BranchServices(ApplicationDBContext context)
    {
        _context = context;
    }
    public async Task<Branch> Add(Branch branch)
    {
      await _context.Branches.AddAsync(branch);
      _context.SaveChanges();
      return branch;
    }

    public async Task<IEnumerable<Branch>> GetAll()
    {
        return  await _context.Branches.ToListAsync();
    }
}