﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
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
                    Cep = MembroVM.Cep,
                    Estado = MembroVM.Estado,
                    Email = MembroVM.Email,
                    Telefone = MembroVM.Telefone,
                    TemSeguro = MembroVM.TemSeguro,
                    TemCnh = MembroVM.TemCnh,
                    Curso = MembroVM.Curso,
                    MatriculaAcademica = MembroVM.MatriculaAcademica,
                    Cargo = MembroVM.Cargo,
                    DataEntrada = MembroVM.DataEntrada,
                    DataSaida = MembroVM.DataSaida,
                    Status = MembroVM.Status
                };

                await _membroRepository.SalvarMembro(membro);
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
