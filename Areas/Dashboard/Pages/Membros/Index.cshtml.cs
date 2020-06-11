using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using AcquaJrApplication.Data;
using AcquaJrApplication.Models;
using AcquaJrApplication.Interfaces;
using AcquaJrApplication.ViewsModels;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Membros
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IMembroRepository _membroRepository;

        public IndexModel(IMembroRepository membroRepository)
        {
            _membroRepository = membroRepository;
        }

        [BindProperty]
        public List<MembroViewModel> Membros { get; set; }

        public async Task<ActionResult> OnGetAsync()
        {
            Membros = _membroRepository.ObterMembrosAtivos().Select(membro => new MembroViewModel(membro)).ToList();

            return Page();
        }
    }
}
