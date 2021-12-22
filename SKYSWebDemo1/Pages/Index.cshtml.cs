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

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public int Age { get; set; }

        public string GreetingMessage { get; set; }

        public List<string> Namn { get; set; } = new List<string>();

        public void OnGet()
        {

            if (DateTime.Now.Hour > 17)
                GreetingMessage = "Good night";
            else
                GreetingMessage = "Good morning";
            Age = 12;
            Namn.Add("Stefan");
            Namn.Add("Oliver");
        }
    }
}
