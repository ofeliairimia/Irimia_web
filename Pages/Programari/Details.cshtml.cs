using Irimia_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Irimia_web.Pages.Programari
{
    public class DetailsModel : PageModel
    {
        private readonly Irimia_web.Data.Irimia_webContext _context;

        public DetailsModel(Irimia_web.Data.Irimia_webContext context)
        {
            _context = context;
        }

        public Programare Programare { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Programare == null)
            {
                return NotFound();
            }

            var programare = await _context.Programare.Include(b => b.Pacient).Include(b => b.Serviciu).ThenInclude(b => b.Medic).FirstOrDefaultAsync(m => m.ID == id);
            if (programare == null)
            {
                return NotFound();
            }
            else
            {
                Programare = programare;
            }
            return Page();
        }
    }
}
