using Irimia_web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Irimia_web.Pages.Pacienti
{
    public class IndexModel : PageModel
    {
        private readonly Irimia_web.Data.Irimia_webContext _context;

        public IndexModel(Irimia_web.Data.Irimia_webContext context)
        {
            _context = context;
        }

        public IList<Pacient> Pacient { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Pacient != null)
            {
                Pacient = await _context.Pacient.ToListAsync();
            }
        }
    }
}
