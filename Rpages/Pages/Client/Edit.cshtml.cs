using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rpages.Data;

namespace Rpages.Pages.Client
{
    public class EditModel : PageModel
    {
        private readonly ClientContext _context;

        public EditModel(ClientContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rpages.Models.Client Client { get; set; }

        
        public IActionResult OnGet(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid client ID.");
            }

            Client = _context.Clients.Find(id);

            if (Client == null)
            {
                return NotFound();
            }

            return Page();
        }

     
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); 
            }

            var existingClient = _context.Clients.Find(Client.Id);
            if (existingClient == null)
            {
                return NotFound("Client not found.");
            }

            try
            {
              
                existingClient.Name = Client.Name;
                existingClient.Email = Client.Email;

                _context.SaveChanges(); 
            }
            catch (Exception ex)
            {
               
                ModelState.AddModelError(string.Empty, $"An error occurred while updating the client: {ex.Message}");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
