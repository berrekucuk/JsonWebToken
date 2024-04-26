using _03.JsonWebToken.Models.DTO.Product;
using _03.JsonWebToken.Models.ORM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _03.JsonWebToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        public ECommerceContext db;

        //Araştırma Konusu : Dependency Injection - Türkçesi : Bağımlılık Enjeksiyonu

        //Dependency Injection Nedir?
        //Dependency Injection, bir sınıfın başka bir sınıfın nesnesine ihtiyaç duyması durumunda, bu ihtiyacı dışarıdan karşılamak için kullanılan bir tasarım desenidir.

        public ProductController(ECommerceContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            List<GetAllProductsResponseDto> responseModel = db.Products.Where(x => x.IsDeleted == false).Select(x => new GetAllProductsResponseDto
            {
                ID = x.ID,
                Name = x.Name,
                Description = x.Description,
                UnitPrice = x.UnitPrice,
                Stock = x.Stock
            }).ToList();

            return Ok(responseModel);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductByID(int id)
        {
            Product product = db.Products.FirstOrDefault(x => x.ID == id && x.IsDeleted == false);

            if (product != null)
            {
                GetProductByIdResponseDto responseModel = new GetProductByIdResponseDto()
                {
                    ID = product.ID,
                    Name = product.Name,
                    Description = product.Description,
                    UnitPrice = product.UnitPrice,
                    Stock = product.Stock
                };

                return Ok(responseModel);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            Product product = db.Products.FirstOrDefault(x => x.ID == id);

            if (product != null)
            {
                product.IsDeleted = true;
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductRequestDto requestModel)
        {
            Product product = new Product();
            product.Name = requestModel.Name;
            product.Description = requestModel.Description;
            product.UnitPrice = requestModel.UnitPrice;
            product.Stock = requestModel.Stock;

            db.Products.Add(product);
            db.SaveChanges();

            CreateProductResponseDto responseModel = new CreateProductResponseDto();
            responseModel.ID = product.ID;
            responseModel.Name = product.Name;
            responseModel.Description = product.Description;
            responseModel.unitPrice = product.UnitPrice;
            responseModel.Stock = product.Stock;
            responseModel.AddDate = product.AddDate;

            return StatusCode(StatusCodes.Status201Created, responseModel);
        }
    }
}
