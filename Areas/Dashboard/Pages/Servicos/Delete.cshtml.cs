using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using AcquaJrApplication.Models;
using AcquaJrApplication.Interfaces;
using AcquaJrApplication.ViewsModels;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Servicos
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly IServicoRepository _servicoRepository;

        public DeleteModel(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        [BindProperty]
        public ServicoViewModel ServicoVM { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servico = await _servicoRepository.ObterPorId(id);

            if (servico == null)
            {
                return NotFound();
            }

            ServicoVM = new ServicoViewModel(servico);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servico = await _servicoRepository.ObterPorId(id);

            if (servico != null)
            {
                try
                {
                    await _servicoRepository.ExcluirServico(id);
                }
                catch(DomainException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    ServicoVM = new ServicoViewModel(servico);

                    return Page();
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
