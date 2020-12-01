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

        public string CurrentFilter { get; set; }

        /// <summary>
        /// Pagniated List of ADCPs.
        /// </summary>
        public PaginatedList<Models.Adcp> Adcp { get; set; }
       // public IList<csVaultSql.Models.Adcp> Adcp { get;set; }

        public IndexModel(csVaultSql.VaultContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync(string searchString, int? pageIndex)
        {
            // Force the pageIndex to 1 if 
            // Searching is being used
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = CurrentFilter;
            }

            CurrentFilter = searchString;

            var adcps = from a in _context.Adcps
                         select a;

            adcps = adcps.OrderByDescending(s => s.Created);            // Order by Created
            //adcps = adcps.OrderBy(s => s.Serialnumber);                 // Order by ADCP serial number

            // Search for the serial number
            if(!string.IsNullOrEmpty(searchString))
            {
                adcps = adcps.Where(s => s.Serialnumber.Contains(searchString));
            }

            //Adcp = await adcps.ToListAsync();
            //Adcp = await _context.Adcps.ToListAsync();

            // Query using pagination
            int pageSize = 10;
            Adcp = await PaginatedList<Models.Adcp>.CreateAsync(adcps, pageIndex ?? 1, pageSize);
        }
    }
}
