using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AcquaJrApplication.Data;
using AcquaJrApplication.Models;
using AcquaJrApplication.Interfaces;
using AcquaJrApplication.ViewsModels;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Servicos
{
    public class CreateModel : PageModel
    {
        private readonly IServicoRepository _servicoRepository;

        public CreateModel(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
            ServicoVM = new ServicoViewModel();
        }

        [BindProperty]
        public ServicoViewModel ServicoVM { get; set; }

        public IActionResult OnGet()
        {
            ServicoVM = new ServicoViewModel();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                Servico servico = new Servico()
                {
                    Nome = ServicoVM.Nome,
                    Descricao = ServicoVM.Descricao
                };

                await _servicoRepository.Adicionar(servico);
                return RedirectToPage("./Index");
            }
            catch (DomainException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
        }
    }
}
