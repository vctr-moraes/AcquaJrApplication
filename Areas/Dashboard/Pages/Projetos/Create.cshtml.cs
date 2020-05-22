using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AcquaJrApplication.Data;
using AcquaJrApplication.Models;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Projetos
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
        ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Bairro");
        ViewData["ServicoId"] = new SelectList(_context.Servicos, "Id", "Descricao");
            return Page();
        }

        [BindProperty]
        public Projeto Projeto { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Projetos.Add(Projeto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
