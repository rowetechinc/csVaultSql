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
    public class IndexModel : PageModel
    {
        private readonly csVaultSql.VaultContext _context;

        public IndexModel(csVaultSql.VaultContext context)
        {
            _context = context;
        }

        public IList<csVaultSql.Models.Adcp> Adcp { get;set; }

        public async Task OnGetAsync()
        {
            var adcps = from a in _context.Adcps
                         select a;

            adcps = adcps.OrderByDescending(s => s.Created);

            Adcp = await adcps.ToListAsync();

            //Adcp = await _context.Adcps.ToListAsync();
        }
    }
}
