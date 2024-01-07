using Irimia_web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Irimia_web.Pages.Medici
{
    public class IndexModel : PageModel
    {
        private readonly Irimia_web.Data.Irimia_webContext _context;

        public IndexModel(Irimia_web.Data.Irimia_webContext context)
        {
            _context = context;
        }

        public IList<Medic> Medic { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Medic != null)
            {
                Medic = await _context.Medic.ToListAsync();
            }
        }
    }
}
