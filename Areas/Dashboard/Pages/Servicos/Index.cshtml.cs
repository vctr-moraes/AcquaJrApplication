using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using AcquaJrApplication.Interfaces;
using AcquaJrApplication.ViewsModels;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Servicos
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IServicoRepository _servicoRepository;

        public IndexModel(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        [BindProperty]
        public List<ServicoViewModel> Servicos { get; set; }

        public ActionResult OnGet()
        {
            Servicos = _servicoRepository.ObterServicos().Select(servico => new ServicoViewModel(servico)).ToList();
            return Page();
        }
    }
}
