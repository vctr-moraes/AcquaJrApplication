using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using AcquaJrApplication.Interfaces;
using AcquaJrApplication.ViewsModels;

namespace AcquaJrApplication.Areas.Dashboard.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IProjetoRepository _projetoRepository;

        public IndexModel(ILogger<IndexModel> logger, IProjetoRepository projetoRepository)
        {
            _logger = logger;
            _projetoRepository = projetoRepository;
        }

        [BindProperty]
        public List<ProjetoViewModel> Projetos { get; set; }

        public ActionResult OnGet()
        {
            Projetos = _projetoRepository.ObterProjetosAtivos().Select(projeto => new ProjetoViewModel(projeto)).ToList();
            return Page();
        }
    }
}
