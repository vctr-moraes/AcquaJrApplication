using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using AcquaJrApplication.Interfaces;
using AcquaJrApplication.ViewsModels;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Servicos
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly IServicoRepository _servicoRepository;

        public DetailsModel(IServicoRepository servicoRepository)
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
    }
}
