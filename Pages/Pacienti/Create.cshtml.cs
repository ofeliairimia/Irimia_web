using Irimia_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Irimia_web.Pages.Pacienti
{
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
        public Pacient Pacient { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Pacient.Add(Pacient);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
