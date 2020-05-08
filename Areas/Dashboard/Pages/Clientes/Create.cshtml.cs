using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AcquaJrApplication.Data;
using AcquaJrApplication.Models;
using AcquaJrApplication.ViewsModels;
using AcquaJrApplication.Interfaces;
using System.Globalization;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Clientes
{
    public class CreateModel : PageModel
    {
        private readonly IClienteRepository _clienteRepository;

        public CreateModel(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
            ClienteVM = new ClienteViewModel();
        }

        [BindProperty]
        public ClienteViewModel ClienteVM { get; set; }

        public IActionResult OnGet()
        {
            ClienteVM = new ClienteViewModel();
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
                Cliente cliente = new Cliente()
                {
                    TipoPessoa = ClienteVM.TipoPessoa,
                    NomeFantasia = ClienteVM.NomeFantasia,
                    RazaoSocial = ClienteVM.RazaoSocial,
                    Cpf = ClienteVM.Cpf,
                    Cnpj = ClienteVM.Cnpj,
                    InscricaoEstadual = ClienteVM.InscricaoEstadual,
                    RgCtps = ClienteVM.RgCtps,
                    Logradouro = ClienteVM.Logradouro,
                    PontoReferencia = ClienteVM.PontoReferencia,
                    Bairro = ClienteVM.Bairro,
                    Cidade = ClienteVM.Cidade,
                    Cep = ClienteVM.Cep,
                    Estado = ClienteVM.Estado,
                    Email = ClienteVM.Email,
                    Telefone1 = ClienteVM.Telefone1,
                    Telefone2 = ClienteVM.Telefone2,
                    Observacoes = ClienteVM.Observacoes,
                    DataCadastro = DateTime.ParseExact(ClienteVM.DataCadastro, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                };

                await _clienteRepository.Adicionar(cliente);

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
