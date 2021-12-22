using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SKYSWebDemo1.Models;

namespace SKYSWebDemo1.Pages
{
    public class CategoryModel : PageModel
    {
        private readonly NorthwindContext _context;

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string CategoryName { get; set; }
            public decimal Unitprice { get; set; }
        }
        public List<ProductViewModel> Products { get; set; }

        public CategoryModel(NorthwindContext context)
        {
            _context = context;
        }

        public void OnGet(int id)
        {
            CategoryName = _context.Categories.First(r => r.CategoryId == id).CategoryName;
            Products = _context.Products
                .Include(e => e.Category)
                .OrderByDescending(t => t.ProductId)
                .Where(r=>r.Category.CategoryId == id)
                .Select(r => new ProductViewModel
                {
                    Id = r.ProductId,
                    Name = r.ProductName,
                    CategoryName = r.Category.CategoryName,
                    Unitprice = r.UnitPrice.Value
                }).ToList();


        }

        public string CategoryName { get; set; }
    }
}
