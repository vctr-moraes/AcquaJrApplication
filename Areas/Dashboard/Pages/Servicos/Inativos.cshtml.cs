using System.Linq;
using System.Collections.Generic;
using AcquaJrApplication.Interfaces;
using AcquaJrApplication.ViewsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Servicos
{
    [Authorize]
    public class InativosModel : PageModel
    {
        private readonly IServicoRepository _servicoRepository;

        public InativosModel(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        [BindProperty]
        public List<ServicoViewModel> Servicos { get; set; }

        public ActionResult OnGet()
        {
            Servicos = _servicoRepository.ObterServicosInativos().Select(servico => new ServicoViewModel(servico)).ToList();
            return Page();
        }
    }
}
