using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using AcquaJrApplication.Data;
using AcquaJrApplication.Models;
using AcquaJrApplication.Interfaces;
using AcquaJrApplication.ViewsModels;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Membros
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly IMembroRepository _membroRepository;

        public DeleteModel(IMembroRepository membroRepository)
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

            var membro = await _membroRepository.ObterPorId(id);

            if (membro == null)
            {
                return NotFound();
            }

            MembroVM = new MembroViewModel(membro);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membro = await _membroRepository.ObterPorId(id);

            if (membro != null)
            {
                await _membroRepository.Remover(membro.Id);
                return RedirectToPage("./Index");
            }

            return RedirectToPage("./Index");
        }
    }
}
