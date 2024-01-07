using Irimia_web.Models.ViewModels;
using Irimia_web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Irimia_web.Pages.Orare
{
    public class IndexModel : PageModel
    {
        private readonly Irimia_web.Data.Irimia_webContext _context;

        public IndexModel(Irimia_web.Data.Irimia_webContext context)
        {
            _context = context;
        }

        public IList<Orar> Orar { get; set; } = default!;
        public OrarIndexData OrarData { get; set; }
        public int OrarID { get; set; }
        public int ServiciuID { get; set; }
        public async Task OnGetAsync(int? id, int? serviciuID)
        {
            OrarData = new OrarIndexData();
            OrarData.Orare = await _context.Orar
            .Include(i => i.Servicii)
            .ThenInclude(c => c.Medic)
            .OrderBy(i => i.Zi)
            .ToListAsync();
            if (id != null)
            {
                OrarID = id.Value;
                Orar orar = OrarData.Orare
                .Where(i => i.ID == id.Value).Single();
                OrarData.Servicii = orar.Servicii;
            }
        }
    }
}
