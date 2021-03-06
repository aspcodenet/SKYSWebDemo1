using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SKYSWebDemo1.Models;

namespace SKYSWebDemo1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly NorthwindContext _context;

        public class CategoryViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string CategoryName { get; set; }
            public decimal Unitprice { get; set; }
        }

        public List<ProductViewModel> Products { get; set; }

        public List<CategoryViewModel> Categories { get; set; }

        public IndexModel(ILogger<IndexModel> logger, NorthwindContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            Categories = _context.Categories.Select(r => new CategoryViewModel
            {
                Id = r.CategoryId,
                Name = r.CategoryName
            }).ToList();

            Products = _context.Products
                .Include(e=>e.Category)
                .OrderByDescending(t => t.ProductId)
                .Take(5)
                .Select(r => new ProductViewModel
                {
                    Id = r.ProductId,
                    Name = r.ProductName,
                    CategoryName = r.Category.CategoryName,
                    Unitprice = r.UnitPrice.Value
                }).ToList();

        }
    }
}
