﻿using Irimia_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Irimia_web.Pages.Programari
{
    public class DeleteModel : PageModel
    {
        private readonly Irimia_web.Data.Irimia_webContext _context;

        public DeleteModel(Irimia_web.Data.Irimia_webContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Programare == null)
            {
                return NotFound();
            }
            var programare = await _context.Programare.FindAsync(id);

            if (programare != null)
            {
                Programare = programare;
                _context.Programare.Remove(Programare);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
