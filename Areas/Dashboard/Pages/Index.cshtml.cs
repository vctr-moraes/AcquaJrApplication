using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using AcquaJrApplication.Interfaces;
using AcquaJrApplication.ViewsModels;
using AcquaJrApplication.Models;

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

            List<Projeto> projetosAtivos = _projetoRepository.ObterProjetosAtivos().ToList();
            List<Guid> membrosIds = new List<Guid>();

            foreach (var projeto in projetosAtivos)
            {
                foreach (var item in projeto.Membros)
                {
                    membrosIds.Add(item.MembroId);
                }
            }

            var total = membrosIds.Distinct().Count();
            ViewData["MembrosTrabalhando"] = total;

            return Page();
        }
    }
}
