using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
        }
    }
}
