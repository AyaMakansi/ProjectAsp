
namespace ProjectAsp.Services.product;

public interface IProductServices
{
    Task<Product> Add(Product product);
}