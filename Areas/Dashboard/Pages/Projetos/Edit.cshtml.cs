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

namespace AcquaJrApplication.Areas.Dashboard.Pages.Projetos
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
           ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Bairro");
           ViewData["ServicoId"] = new SelectList(_context.Servicos, "Id", "Descricao");
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

            _context.Attach(Projeto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjetoExists(Projeto.Id))
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

        private bool ProjetoExists(Guid id)
        {
            return _context.Projetos.Any(e => e.Id == id);
        }
    }
}
