using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rpages.Data;

namespace Rpages.Pages.Client
{
    public class DeleteModel : PageModel
    {
        private readonly ClientContext  _context;

        public DeleteModel( ClientContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rpages.Models.Client Client { get; set; }

        public IActionResult OnGet(int id)
        {
            Client = _context.Clients.Find(id);

            if (Client == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            var client = _context.Clients.Find(id);

            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
