using Irimia_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Irimia_web.Pages.Specialitati
{
    public class DetailsModel : PageModel
    {
        private readonly Irimia_web.Data.Irimia_webContext _context;

        public DetailsModel(Irimia_web.Data.Irimia_webContext context)
        {
            _context = context;
        }

        public Specialitate Specialitate { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Specialitate == null)
            {
                return NotFound();
            }

            var specialitate = await _context.Specialitate.FirstOrDefaultAsync(m => m.ID == id);
            if (specialitate == null)
            {
                return NotFound();
            }
            else
            {
                Specialitate = specialitate;
            }
            return Page();
        }
    }
}
