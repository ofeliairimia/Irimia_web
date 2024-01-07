using Irimia_web.Models.ViewModels;
using Irimia_web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Irimia_web.Pages.Specialitati
{
    public class IndexModel : PageModel
    {
        private readonly Irimia_web.Data.Irimia_webContext _context;

        public IndexModel(Irimia_web.Data.Irimia_webContext context)
        {
            _context = context;
        }

        public IList<Specialitate> Specialitate { get; set; } = default!;
        public SpecialitateIndexData SpecialitateData { get; set; }
        public int SpecialitateID { get; set; }
        public int ServiciuID { get; set; }
        public async Task OnGetAsync(int? id, int? serviciuID)
        {
            SpecialitateData = new SpecialitateIndexData();
            SpecialitateData.Specialitati = await _context.Specialitate
            .Include(i => i.SpecialitatiServiciu)
            .ThenInclude(i => i.Serviciu)
            .ThenInclude(i => i.Medic)
            .OrderBy(i => i.NumeSpecialitate)
            .ToListAsync();
            if (id != null)
            {
                SpecialitateID = id.Value;
                Specialitate specialitate = SpecialitateData.Specialitati
                .Where(i => i.ID == id.Value).Single();
                SpecialitateData.SpecialitatiServiciu = specialitate.SpecialitatiServiciu;
            }
        }
    }
}
