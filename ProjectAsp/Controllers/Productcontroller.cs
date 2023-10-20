using Microsoft.AspNetCore.Mvc;
using ProjectAsp.Dtos;
using ProjectAsp.Models;
using ProjectAsp.Services.product;

namespace ProjectAsp.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class Productcontroller:ControllerBase
{
   private readonly IProductServices _productServices;
   private readonly IWebHostEnvironment _webHostEnvironment;
     private new List<string> _allowedExtentions = new List<string> { ".png", ".jpg" };
         
     private long _maxAllowedImageSize = 1048576;//1MB

   public Productcontroller(IProductServices productServices,IWebHostEnvironment webHostEnvironment)
   {
      _productServices = productServices;
      _webHostEnvironment = webHostEnvironment;
   }
   [HttpPost]
   public async Task<IActionResult> AddAsync([FromForm] ProductDto dto)
   { var imagepath = Path.Combine("product_images", Guid.NewGuid() + dto.Product_Image.FileName);
                      var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, imagepath);
                      await using var stream = new FileStream(uploadPath, FileMode.Create);
                      await  dto.Product_Image.CopyToAsync(stream);
                 if(!_allowedExtentions.Contains(Path.GetExtension(dto.Product_Image.FileName).ToLower()))
                                return BadRequest("Only .png and .jpg images are allowed!");
                   if(dto.Product_Image!.Length> _maxAllowedImageSize)
                                return BadRequest("max allowed size for image is 1MB!");
            
      var product =new Product
      {
         Product_name = dto.Product_name,
         Product_Type = dto.Product_Type,
         Product_Image =imagepath 
      };
     await  _productServices.Add(product);
       return Ok(product);
   }
  
}