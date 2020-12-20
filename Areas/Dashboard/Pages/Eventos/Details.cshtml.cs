using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcquaJrApplication.Data;
using AcquaJrApplication.Models;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Eventos
{
    public class DetailsModel : PageModel
    {
        private readonly AcquaJrApplication.Data.ApplicationDbContext _context;

        public DetailsModel(AcquaJrApplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Evento Evento { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Evento = await _context.Eventos.FirstOrDefaultAsync(m => m.Id == id);

            if (Evento == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
