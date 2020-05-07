using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcquaJrApplication.Data;
using AcquaJrApplication.Models;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Servicos
{
    public class DetailsModel : PageModel
    {
        private readonly AcquaJrApplication.Data.ApplicationDbContext _context;

        public DetailsModel(AcquaJrApplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Servico Servico { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Servico = await _context.Servicos.FirstOrDefaultAsync(m => m.Id == id);

            if (Servico == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
