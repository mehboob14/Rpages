using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rpages.Data;

namespace Rpages.Pages.Client
{
    public class CreateModel : PageModel
    {
        private readonly ClientContext _context;

        public CreateModel(ClientContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rpages.Models.Client Client { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            

            _context.Clients.Add(Client); 
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
