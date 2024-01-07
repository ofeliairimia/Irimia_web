using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Irimia_web.Models;

namespace Irimia_web.Pages.Medici
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly Irimia_web.Data.Irimia_webContext _context;

        public DeleteModel(Irimia_web.Data.Irimia_webContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Medic Medic { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Medic == null)
            {
                return NotFound();
            }

            var medic = await _context.Medic.FirstOrDefaultAsync(m => m.ID == id);

            if (medic == null)
            {
                return NotFound();
            }
            else
            {
                Medic = medic;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Medic == null)
            {
                return NotFound();
            }
            var medic = await _context.Medic.FindAsync(id);

            if (medic != null)
            {
                Medic = medic;
                _context.Medic.Remove(Medic);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
