using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarateTests.Controllers
{
    public class ProductsController : Controller
    {
        [HttpGet]
        [Route("Products/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new ProductDto()
            {
                Id = id,
                Name = $"Name-{id}"
            });
        }

        public class ProductDto
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}
