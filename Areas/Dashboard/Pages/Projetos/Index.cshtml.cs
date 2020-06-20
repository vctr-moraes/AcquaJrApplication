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
    public class IndexModel : PageModel
    {
        private readonly IProjetoRepository _projetoRepository;

        public IndexModel(IProjetoRepository projetoRepository)
        {
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
