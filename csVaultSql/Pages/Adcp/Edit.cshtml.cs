﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using csVaultSql;

namespace csVaultSql.Pages.Adcp
{
    public class EditModel : PageModel
    {
        private readonly csVaultSql.VaultContext _context;

        public EditModel(csVaultSql.VaultContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Adcp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdcpExists(Adcp.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AdcpExists(int id)
        {
            return _context.Adcps.Any(e => e.Id == id);
        }
    }
}
