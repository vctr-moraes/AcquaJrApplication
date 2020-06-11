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

namespace AcquaJrApplication.Areas.Dashboard.Pages.Membros
{
    [Authorize]
    public class InativosModel : PageModel
    {
        private readonly IMembroRepository _membroRepository;

        public InativosModel(IMembroRepository membroRepository)
        {
            _membroRepository = membroRepository;
        }

        [BindProperty]
        public List<MembroViewModel> Membros { get; set; }

        public async Task<ActionResult> OnGetAsync()
        {
            Membros = _membroRepository.ObterMembrosInativos().Select(membro => new MembroViewModel(membro)).ToList();

            return Page();
        }
    }
}
