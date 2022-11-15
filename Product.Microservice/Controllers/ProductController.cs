using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product.Microservice.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Product.Microservice.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private IApplicationDbContext _context;

        public ProductController(IApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _context.Products.ToListAsync();
            if (products == null)
                return NotFound();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _context.Products.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Entities.Product product)
        {
            _context.Products?.Add(product);
            await _context.SaveChanges();
            return Ok(product.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Entities.Product product)
        {
            var productId = _context.Products.Where(a => a.Id == id).FirstOrDefault();
            if (productId == null)
                return NotFound();
            else
            {
                product.Name = product.Name;
                product.Rate = product.Rate;

                await _context.SaveChanges();

                return Ok(product.Id);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (product == null)
                return NotFound();

            _context.Products.Remove(product);

            await _context.SaveChanges();

            return Ok(product.Id);
        }
    }
}

