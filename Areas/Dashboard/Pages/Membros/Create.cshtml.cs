using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using AcquaJrApplication.Data;
using AcquaJrApplication.Models;
using AcquaJrApplication.ViewsModels;
using AcquaJrApplication.Interfaces;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Membros
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IMembroRepository _membroRepository;

        public CreateModel(IMembroRepository membroRepository)
        {
            _membroRepository = membroRepository;
            MembroVM = new MembroViewModel();
        }

        [BindProperty]
        public MembroViewModel MembroVM { get; set; }

        public IActionResult OnGet()
        {
            MembroVM = new MembroViewModel();
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
                Membro membro = new Membro()
                {
                    Nome = MembroVM.Nome,
                    Cpf = MembroVM.Cpf,
                    DataNascimento = MembroVM.DataNascimento,
                    Logradouro = MembroVM.Logradouro,
                    Bairro = MembroVM.Bairro,
                    Cidade = MembroVM.Cidade,
                    Estado = MembroVM.Estado,
                    Email = MembroVM.Email,
                    Telefone = MembroVM.Telefone,
                    TemSeguro = MembroVM.TemSeguro,
                    TemCnh = MembroVM.TemCnh,
                    Curso = MembroVM.Curso,
                    MatriculaAcademica = MembroVM.MatriculaAcademica,
                    Cargo = MembroVM.Cargo,
                    DataEntrada = MembroVM.DataEntrada,
                    DataSaida = MembroVM.DataSaida
                };

                await _membroRepository.Adicionar(membro);
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
