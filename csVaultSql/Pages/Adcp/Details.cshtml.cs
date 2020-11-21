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
    public class DetailsModel : PageModel
    {
        private readonly csVaultSql.VaultContext _context;

        public DetailsModel(csVaultSql.VaultContext context)
        {
            _context = context;
        }

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
    }
}
