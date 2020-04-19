using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcquaJrApplication.Data;
using AcquaJrApplication.ViewsModels;

namespace AcquaJrApplication
{
    public class DetailsModel : PageModel
    {
        private readonly AcquaJrApplication.Data.ApplicationDbContext _context;

        public DetailsModel(AcquaJrApplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
