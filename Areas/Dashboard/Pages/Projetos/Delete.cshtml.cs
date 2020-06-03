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
using AcquaJrApplication.Interfaces;
using AcquaJrApplication.ViewsModels;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Projetos
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IProjetoRepository _projetoRepository;

        public DeleteModel(AcquaJrApplication.Data.ApplicationDbContext context, IProjetoRepository projetoRepository)
        {
            _context = context;
            _projetoRepository = projetoRepository;
        }

        [BindProperty]
        public ProjetoViewModel ProjetoVM { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = await _projetoRepository.ObterPorId(id);

            //Projeto = await _context.Projetos
            //    .Include(p => p.Cliente)
            //    .Include(p => p.Servico).FirstOrDefaultAsync(m => m.Id == id);

            if (projeto == null)
            {
                return NotFound();
            }

            ProjetoVM = new ProjetoViewModel(projeto);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = await _projetoRepository.ObterPorId(id);

            //Projeto = await _context.Projetos.FindAsync(id);

            if (projeto != null)
            {
                _context.Projetos.Remove(projeto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
