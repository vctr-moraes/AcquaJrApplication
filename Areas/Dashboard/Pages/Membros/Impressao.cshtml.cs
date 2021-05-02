using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using AcquaJrApplication.Interfaces;
using AcquaJrApplication.ViewsModels;
using AcquaJrApplication.Models;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Membros
{
    [Authorize]
    public class ImpressaoModel : PageModel
    {
        private readonly IMembroRepository _membroRepository;

        public ImpressaoModel(IMembroRepository membroRepository)
        {
            _membroRepository = membroRepository;
        }

        [BindProperty]
        public MembroViewModel MembroVM { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Membro membro = await _membroRepository.ObterMembro(id);

            if (membro == null)
            {
                return NotFound();
            }

            MembroVM = new MembroViewModel(membro);
            return Page();
        }
    }
}
