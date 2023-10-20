
namespace ProjectAsp.Services.product;

public class ProductServices : IProductServices
{
    private readonly ApplicationDBContext _context;

    public ProductServices(ApplicationDBContext context)
    {
        _context = context;
    }
    public async Task<Product> Add(Product product)
    {
        await _context.Products.AddAsync(product);
        _context.SaveChanges();
        return product;
    }
}