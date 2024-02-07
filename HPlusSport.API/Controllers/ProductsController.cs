using HPlusSport.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HPlusSport.API.Controllers
{
    [Route("api/[controller]")] // this is the root for whole class
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //create the constructor of the Product controller
        private readonly ShopContext _shopContext;

        public ProductsController(ShopContext shopContext)
        {
            _shopContext = shopContext;

            //make sure seeding take place
            _shopContext.Database.EnsureCreated();
        }


        [HttpGet]
        /*public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
           return Ok(_shopContext.Products.ToArray());
        }*/
        public async Task<ActionResult> GetAllProducts()
        {
            return Ok(await _shopContext.Products.ToArrayAsync());
        }


        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Product>> GetProduct(int id)
        {
            var product = _shopContext.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product newProduct)
        {
            /* if(!ModelState.IsValid)
             {
                 return BadRequest();
             }*/
            _shopContext.Products.Add(newProduct);
            await _shopContext.SaveChangesAsync();

            return CreatedAtAction
                ("GetProduct",
                new { id = newProduct.Id },
                newProduct);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            // to modify the product
            _shopContext.Entry(product).State = EntityState.Modified;

            try
            {
                await _shopContext.SaveChangesAsync();
            }
            // for the error handeling
            catch (DbUpdateConcurrencyException)
            {
                if (!_shopContext.Products.Any(p => p.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _shopContext.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _shopContext.Products.Remove(product);

            await _shopContext.SaveChangesAsync();

            return product;

        }

        [HttpPost]
        [Route("Delete")]

        public async Task<ActionResult> DeleteSeveralItem([FromQuery] int[] ids)
        {
            var products = new List<Product>();
            foreach (var id in ids)
            {
                var product = await _shopContext.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound();
                }
                products.Add(product);
            }
            _shopContext.Products.RemoveRange(products);
            await _shopContext.SaveChangesAsync();

            return Ok(products);

        }
    }
        
    }
