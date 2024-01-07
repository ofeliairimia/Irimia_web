using Irimia_web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Irimia_web.Pages.Orare
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly Irimia_web.Data.Irimia_webContext _context;

        public CreateModel(Irimia_web.Data.Irimia_webContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Orar Orar { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Orar.Add(Orar);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
