using System.Data;
using Irimia_web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Irimia_web.Pages.Servicii
{
    [Authorize(Roles = "Admin")]
    public class EditModel : SpecialitatiServiciuPageModel
    {
        private readonly Irimia_web.Data.Irimia_webContext _context;

        public EditModel(Irimia_web.Data.Irimia_webContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Serviciu Serviciu { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Serviciu == null)
            {
                return NotFound();
            }
            Serviciu = await _context.Serviciu
                     .Include(b => b.Orar)
                     .Include(b => b.SpecialitatiServiciu).ThenInclude(b => b.Specialitate)
                     .AsNoTracking()
                     .FirstOrDefaultAsync(m => m.ID == id);
            var serviciu = await _context.Serviciu.FirstOrDefaultAsync(m => m.ID == id);
            if (serviciu == null)
            {
                return NotFound();
            }
            PopulareDateSpecialitateAtribuite(_context, Serviciu);
            Serviciu = serviciu;
            var medicList = _context.Medic.Select(x => new
            {
                x.ID,
                FullName = x.Prenume + " " + x.Nume
            });
            ViewData["MedicID"] = new SelectList(medicList, "ID", "FullName");
            ViewData["OrarID"] = new SelectList(_context.Set<Orar>(), "ID", "Zi");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] specialitatiSelectate)
        {
            if (id == null)
            {
                return NotFound();
            }
            var serviciuToUpdate = await _context.Serviciu
            .Include(i => i.Orar)
            .Include(i => i.SpecialitatiServiciu)
            .ThenInclude(i => i.Specialitate)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (serviciuToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Serviciu>(
            serviciuToUpdate,
            "Serviciu",
            i => i.Titlu, i => i.Medic,
            i => i.Pret, i => i.Orar))
            {
                UpdateSpecialitatiServiciu(_context, specialitatiSelectate, serviciuToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateSpecialitatiServiciu(_context, specialitatiSelectate, serviciuToUpdate);
            PopulareDateSpecialitateAtribuite(_context, serviciuToUpdate);
            return Page();

        }
        private bool ServiciuExists(int id)
        {
            return _context.Serviciu.Any(e => e.ID == id);
        }
    }
}
