using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rpages.Data;
using Rpages.Models;

namespace Rpages.Pages.Client
{
    public class IndexModel : PageModel
    {
        private readonly ClientContext _context;

        public IndexModel(ClientContext context)
        {
            _context = context;
        }

        public IList<Rpages.Models.Client> Clients { get; set; }

        public async Task OnGetAsync()
        {
            Clients = await _context.Clients.ToListAsync();
        }
    }
}
