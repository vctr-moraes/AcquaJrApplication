using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcquaJrApplication.Data;
using AcquaJrApplication.Interfaces;
using AcquaJrApplication.ViewsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Projetos
{
    [Authorize]
    public class ConcluidosModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IProjetoRepository _projetoRepository;

        public ConcluidosModel(ApplicationDbContext context, IProjetoRepository projetoRepository)
        {
            _context = context;
            _projetoRepository = projetoRepository;
        }

        [BindProperty]
        public List<ProjetoViewModel> Projetos { get; set; }

        public async Task<ActionResult> OnGetAsync()
        {
            Projetos = _projetoRepository.ObterProjetosConcluidos()
                .Select(projeto => new ProjetoViewModel(projeto))
                .ToList();

            return Page();
        }
    }
}
