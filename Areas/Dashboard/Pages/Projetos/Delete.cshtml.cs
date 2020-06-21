using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AcquaJrApplication.Models;
using Microsoft.AspNetCore.Authorization;
using AcquaJrApplication.Interfaces;
using AcquaJrApplication.ViewsModels;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Projetos
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly IProjetoRepository _projetoRepository;

        public DeleteModel(IProjetoRepository projetoRepository)
        {
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

            if (projeto != null)
            {
                try
                {
                    await _projetoRepository.ExcluirProjeto(id);
                }
                catch (DomainException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    ProjetoVM = new ProjetoViewModel(projeto);

                    return Page();
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
