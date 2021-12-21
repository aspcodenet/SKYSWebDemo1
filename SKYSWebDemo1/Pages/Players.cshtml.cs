using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SKYSWebDemo1.Pages
{
    public class PlayersModel : PageModel
    {
        public class PlayerViewModel
        {
            public int Id { get; set; }
            public string Namn { get; set; }
            public int Jersey { get; set; }
        }

        public List<PlayerViewModel> Players { get; set; } = new List<PlayerViewModel>();
        public void OnGet()
        {
            //Fejk - läs från databas in i Players listan - 
            // KOLLA VILKEN ANVÄNDARTE SOM DET GÄLLER  - stefan.holmberg@zaxasdasddas.se 
            Players.Add( new PlayerViewModel{ Id = 1, Jersey=13, Namn="Mats Sundin" });
            Players.Add(new PlayerViewModel { Id = 2, Jersey = 21, Namn = "Peter Forsberg" });
            Players.Add(new PlayerViewModel { Id = 3, Jersey = 2, Namn = "Anders Eldebrink" });
        }
    }
}
