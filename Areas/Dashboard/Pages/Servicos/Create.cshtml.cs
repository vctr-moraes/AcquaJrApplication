using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using AcquaJrApplication.Models;
using AcquaJrApplication.Interfaces;
using AcquaJrApplication.ViewsModels;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Servicos
{
    [Authorize]
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
                    Descricao = ServicoVM.Descricao,
                    Status = ServicoVM.Status
                };

                await _servicoRepository.SalvarServico(servico);
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
        }
    }
}
