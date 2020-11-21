using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using csVaultSql;

namespace csVaultSql.Pages.Adcp
{
    public class CreateModel : PageModel
    {
        private readonly csVaultSql.VaultContext _context;

        public CreateModel(csVaultSql.VaultContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public csVaultSql.Models.Adcp Adcp { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Adcps.Add(Adcp);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
