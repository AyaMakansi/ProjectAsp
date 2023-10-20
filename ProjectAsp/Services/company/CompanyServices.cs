
namespace ProjectAsp.Services.company;

public class CompanyServices:ICompanyServices
{
    private readonly ApplicationDBContext _context;

    public CompanyServices(ApplicationDBContext context)
    {
        _context = context;
    }
    public async Task<Company> Add(Company company)
    {
        await _context.Companies.AddAsync(company);
        _context.SaveChanges();
        return company;
    }
}