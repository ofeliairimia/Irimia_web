using Irimia_web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Irimia_web.Pages.Programari
{
    public class IndexModel : PageModel
    {
        private readonly Irimia_web.Data.Irimia_webContext _context;

        public IndexModel(Irimia_web.Data.Irimia_webContext context)
        {
            _context = context;
        }

        public IList<Programare> Programare { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Programare != null)
            {
                Programare = await _context.Programare
                .Include(b => b.Serviciu)
                    .ThenInclude(b => b.Medic)
                .Include(b => b.Pacient).ToListAsync();
            }
        }
    }
}
