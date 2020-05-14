using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcquaJrApplication.Data;
using AcquaJrApplication.Models;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Membros
{
    public class DeleteModel : PageModel
    {
        private readonly AcquaJrApplication.Data.ApplicationDbContext _context;

        public DeleteModel(AcquaJrApplication.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Membro = await _context.Membros.FindAsync(id);

            if (Membro != null)
            {
                _context.Membros.Remove(Membro);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
