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
        private readonly IMembroRepository _membroRepository;

        public IndexModel(ILogger<IndexModel> logger, IProjetoRepository projetoRepository, IMembroRepository membroRepository)
        {
            _logger = logger;
            _projetoRepository = projetoRepository;
            _membroRepository = membroRepository;
        }

        [BindProperty]
        public DashboardViewModel Dashboard { get; set; }

        public ActionResult OnGet()
        {
            ViewData["ProjetosAtivos"] = _projetoRepository.ObterProjetosAtivos().ToList().Count();
            ViewData["ProjetosAtrasados"] = _projetoRepository.ObterProjetosAtrasados().ToList().Count();
            ViewData["ProjetosConcluidos"] = _projetoRepository.ObterProjetosConcluidos().ToList().Count();

            ViewData["MembrosAtivos"] = _membroRepository.ObterMembrosAtivos().ToList().Count();
            ViewData["MembrosInativos"] = _membroRepository.ObterMembrosInativos().ToList().Count();

            return Page();
        }
    }
}
