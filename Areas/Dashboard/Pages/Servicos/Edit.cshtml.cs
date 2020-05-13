using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AcquaJrApplication.Data;
using AcquaJrApplication.Models;
using AcquaJrApplication.Interfaces;
using AcquaJrApplication.ViewsModels;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Servicos
{
    public class EditModel : PageModel
    {
        private readonly IServicoRepository _servicoRepository;

        public EditModel(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        [BindProperty]
        public ServicoViewModel ServicoVM { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servico = await _servicoRepository.ObterPorId(id);

            if (servico == null)
            {
                return NotFound();
            }

            ServicoVM = new ServicoViewModel(servico);

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string nome)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                Servico servico = await _servicoRepository.ObterPorId(ServicoVM.Id);

                servico.Nome = ServicoVM.Nome;
                servico.Descricao = ServicoVM.Descricao;

                await _servicoRepository.Atualizar(servico);

                return await Task.FromResult(RedirectToPage("./Index"));
            }
            catch (DomainException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
        }

        //private bool ServicoExists(Guid id)
        //{
        //    return _context.Servicos.Any(e => e.Id == id);
        //}
    }
}
