using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SKYSWebDemo1.Models;

namespace SKYSWebDemo1.Pages
{
    public class PlayersModel : PageModel
    {
        private readonly NorthwindContext _context;

        public PlayersModel(NorthwindContext context)
        {
            _context = context;
        }
        public class PlayerViewModel
        {
            public int Id { get; set; }
            public string Namn { get; set; }
            public int Jersey { get; set; }
        }

        public List<PlayerViewModel> Players { get; set; } = new List<PlayerViewModel>();
        public void OnGet()
        {
            Players = _context.Suppliers.Select(r => new PlayerViewModel
            {
                Id = r.SupplierId,
                Namn = r.CompanyName,
                Jersey = r.SupplierId
            }).ToList();
        }
    }
}
