using System.Linq;
using System.Collections.Generic;
using AcquaJrApplication.Interfaces;
using AcquaJrApplication.ViewsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Projetos
{
    [Authorize]
    public class ConcluidosModel : PageModel
    {
        private readonly IProjetoRepository _projetoRepository;

        public ConcluidosModel(IProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        [BindProperty]
        public List<ProjetoViewModel> Projetos { get; set; }

        public ActionResult OnGet()
        {
            Projetos = _projetoRepository.ObterProjetosConcluidos().Select(projeto => new ProjetoViewModel(projeto)).ToList();

            return Page();
        }
    }
}
