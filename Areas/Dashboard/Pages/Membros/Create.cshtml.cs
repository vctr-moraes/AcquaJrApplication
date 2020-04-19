using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AcquaJrApplication.Data;
using AcquaJrApplication.ViewsModels;

namespace AcquaJrApplication
{
    public class CreateModel : PageModel
    {
        private readonly AcquaJrApplication.Data.ApplicationDbContext _context;

        public CreateModel(AcquaJrApplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MembroViewModel MembroViewModel { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MembroViewModel.Add(MembroViewModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
