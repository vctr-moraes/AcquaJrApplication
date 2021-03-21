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
using Microsoft.AspNetCore.Authorization;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Eventos
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly AcquaJrApplication.Data.ApplicationDbContext _context;

        public EditModel(AcquaJrApplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Evento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(Evento.Id))
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

        private bool EventoExists(Guid id)
        {
            return _context.Eventos.Any(e => e.Id == id);
        }
    }
}
