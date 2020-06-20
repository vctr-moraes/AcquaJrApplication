using System.Linq;
using System.Collections.Generic;
using AcquaJrApplication.Interfaces;
using AcquaJrApplication.ViewsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public ActionResult OnGet()
        {
            Membros = _membroRepository.ObterMembrosInativos().Select(membro => new MembroViewModel(membro)).ToList();

            return Page();
        }
    }
}
