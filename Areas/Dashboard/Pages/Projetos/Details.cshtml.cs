using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcquaJrApplication.Data;
using AcquaJrApplication.Models;
using Microsoft.AspNetCore.Authorization;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Projetos
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly AcquaJrApplication.Data.ApplicationDbContext _context;

        public DetailsModel(AcquaJrApplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Projeto Projeto { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Projeto = await _context.Projetos
                .Include(p => p.Cliente)
                .Include(p => p.Servico).FirstOrDefaultAsync(m => m.Id == id);

            if (Projeto == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
