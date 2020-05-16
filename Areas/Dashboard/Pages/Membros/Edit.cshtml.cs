using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AcquaJrApplication.Data;
using AcquaJrApplication.Models;
using AcquaJrApplication.Interfaces;
using AcquaJrApplication.ViewsModels;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Membros
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly IMembroRepository _membroRepository;

        public EditModel(IMembroRepository membroRepository)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                Membro membro = await _membroRepository.ObterPorId(MembroVM.Id);

                membro.Nome = MembroVM.Nome;
                membro.Cpf = MembroVM.Cpf;
                membro.DataNascimento = MembroVM.DataNascimento;
                membro.Logradouro = MembroVM.Logradouro;
                membro.Bairro = MembroVM.Bairro;
                membro.Cidade = MembroVM.Cidade;
                membro.Estado = MembroVM.Estado;
                membro.Email = MembroVM.Email;
                membro.Telefone = MembroVM.Telefone;
                membro.TemSeguro = MembroVM.TemSeguro;
                membro.TemCnh = MembroVM.TemCnh;
                membro.Curso = MembroVM.Curso;
                membro.MatriculaAcademica = MembroVM.MatriculaAcademica;
                membro.Cargo = MembroVM.Cargo;
                membro.DataEntrada = MembroVM.DataEntrada;
                membro.DataSaida = MembroVM.DataSaida;
                membro.Status = MembroVM.Status;

                await _membroRepository.Atualizar(membro);
                return await Task.FromResult(RedirectToPage("./Index"));
            }
            catch (DomainException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
        }
    }
}
