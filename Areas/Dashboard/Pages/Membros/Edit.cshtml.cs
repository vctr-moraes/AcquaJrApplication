using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AcquaJrApplication.Data;
using AcquaJrApplication.Models;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Membros
{
    public class EditModel : PageModel
    {
        private readonly AcquaJrApplication.Data.ApplicationDbContext _context;

        public EditModel(AcquaJrApplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Membro Membro { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Membro = await _context.Membros.FirstOrDefaultAsync(m => m.Id == id);

            if (Membro == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Membro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembroExists(Membro.Id))
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

        private bool MembroExists(Guid id)
        {
            return _context.Membros.Any(e => e.Id == id);
        }
    }
}
