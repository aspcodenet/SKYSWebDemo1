using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SKYSWebDemo1.Models;

namespace SKYSWebDemo1.Pages
{
    public class SuppliersModel : PageModel
    {
        private readonly NorthwindContext _context;

        public class SuppliersViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Country { get; set; }
        }

        public List<SuppliersViewModel> Suppliers { get; set; }


        public SuppliersModel(NorthwindContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Suppliers = _context.Suppliers.Select(r => new SuppliersViewModel
            {
                Country = r.Country,
                Id = r.SupplierId,
                Name = r.CompanyName
            }).ToList();
        }
    }
}
