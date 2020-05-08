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
using System.Globalization;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Clientes
{
    public class EditModel : PageModel
    {
        private readonly IClienteRepository _clienteRepository;

        public EditModel(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [BindProperty]
        public ClienteViewModel ClienteVM { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _clienteRepository.ObterPorId(id);

            if (cliente == null)
            {
                return NotFound();
            }

            ClienteVM = new ClienteViewModel(cliente);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string nome)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                Cliente cliente = await _clienteRepository.ObterPorId(ClienteVM.Id);

                cliente.TipoPessoa = ClienteVM.TipoPessoa;
                cliente.NomeFantasia = ClienteVM.NomeFantasia;
                cliente.RazaoSocial = ClienteVM.RazaoSocial;
                cliente.Cpf = ClienteVM.Cpf;
                cliente.Cnpj = ClienteVM.Cnpj;
                cliente.InscricaoEstadual = ClienteVM.InscricaoEstadual;
                cliente.RgCtps = ClienteVM.RgCtps;
                cliente.Logradouro = ClienteVM.Logradouro;
                cliente.PontoReferencia = ClienteVM.PontoReferencia;
                cliente.Bairro = ClienteVM.Bairro;
                cliente.Cidade = ClienteVM.Cidade;
                cliente.Cep = ClienteVM.Cep;
                cliente.Estado = ClienteVM.Estado;
                cliente.Email = ClienteVM.Email;
                cliente.Telefone1 = ClienteVM.Telefone1;
                cliente.Telefone2 = ClienteVM.Telefone2;
                cliente.Observacoes = ClienteVM.Observacoes;
                cliente.DataCadastro = DateTime.ParseExact(ClienteVM.DataCadastro, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                await _clienteRepository.Adicionar(cliente);

                return await Task.FromResult(RedirectToPage("./Index"));
            }
            catch (DomainException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
        }

        //private bool ClienteExists(Guid id)
        //{
        //    return _context.Clientes.Any(e => e.Id == id);
        //}
    }
}
