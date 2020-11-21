using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using csVaultSql;

namespace csVaultSql.Pages.Adcp
{
    public class DeleteModel : PageModel
    {
        private readonly csVaultSql.VaultContext _context;

        public DeleteModel(csVaultSql.VaultContext context)
        {
            _context = context;
        }

        [BindProperty]
        public csVaultSql.Models.Adcp Adcp { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Adcp = await _context.Adcps.FirstOrDefaultAsync(m => m.Id == id);

            if (Adcp == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Adcp = await _context.Adcps.FindAsync(id);

            if (Adcp != null)
            {
                _context.Adcps.Remove(Adcp);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
