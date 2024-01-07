using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Irimia_web.Models;

namespace Irimia_web.Pages.Medici
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly Irimia_web.Data.Irimia_webContext _context;

        public EditModel(Irimia_web.Data.Irimia_webContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Medic Medic { get; set; } = default!;

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
            Medic = medic;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Medic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicExists(Medic.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MedicExists(int id)
        {
            return _context.Medic.Any(e => e.ID == id);
        }
    }
}
