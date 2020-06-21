using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
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

        public ActionResult OnGet()
        {
            Membros = _membroRepository.ObterMembrosAtivos().Select(membro => new MembroViewModel(membro)).ToList();
            return Page();
        }
    }
}
