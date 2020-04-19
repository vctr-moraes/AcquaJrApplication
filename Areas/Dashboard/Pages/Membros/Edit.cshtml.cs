using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AcquaJrApplication.Data;
using AcquaJrApplication.ViewsModels;

namespace AcquaJrApplication
{
    public class EditModel : PageModel
    {
        private readonly AcquaJrApplication.Data.ApplicationDbContext _context;

        public EditModel(AcquaJrApplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MembroViewModel MembroViewModel { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MembroViewModel = await _context.MembroViewModel.FirstOrDefaultAsync(m => m.Id == id);

            if (MembroViewModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MembroViewModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembroViewModelExists(MembroViewModel.Id))
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

        private bool MembroViewModelExists(Guid id)
        {
            return _context.MembroViewModel.Any(e => e.Id == id);
        }
    }
}
