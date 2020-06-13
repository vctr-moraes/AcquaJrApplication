using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AcquaJrApplication.Data;
using AcquaJrApplication.Models;
using Microsoft.AspNetCore.Authorization;
using AcquaJrApplication.ViewsModels;
using AcquaJrApplication.Interfaces;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Projetos
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IProjetoRepository _projetoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IServicoRepository _servicoRepository;

        public CreateModel(ApplicationDbContext context, IProjetoRepository projetoRepository, IClienteRepository clienteRepository, IServicoRepository servicoRepository)
        {
            _context = context;
            _projetoRepository = projetoRepository;
            _clienteRepository = clienteRepository;
            _servicoRepository = servicoRepository;

            ProjetoVM = new ProjetoViewModel();
        }

        [BindProperty]
        public ProjetoViewModel ProjetoVM { get; set; }

        public IActionResult OnGet()
        {
            ProjetoVM = new ProjetoViewModel();
            ViewData["MembroId"] = new SelectList(_context.Membros, "Id", "Nome");
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NomeFantasia");
            ViewData["ServicoId"] = new SelectList(_context.Servicos, "Id", "Nome");
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
                Projeto projeto = new Projeto()
                {
                    ClienteId = ProjetoVM.ClienteId,
                    ServicoId = ProjetoVM.ServicoId,
                    MembroId = ProjetoVM.MembroId,
                    Nome = ProjetoVM.Nome,
                    Descricao = ProjetoVM.Descricao,
                    CustoMaoDeObra = ProjetoVM.CustoMaoDeObra,
                    CustoProjeto = ProjetoVM.CustoProjeto,
                    CustoInsumos = ProjetoVM.CustoInsumos,
                    Orcamento = ProjetoVM.Orcamento,
                    Logradouro = ProjetoVM.Logradouro,
                    PontoReferencia = ProjetoVM.PontoReferencia,
                    Bairro = ProjetoVM.Bairro,
                    Cidade = ProjetoVM.Cidade,
                    Cep = ProjetoVM.Cep,
                    Estado = ProjetoVM.Estado,
                    DataContrato = ProjetoVM.DataContrato,
                    DataPrevista = ProjetoVM.DataPrevista,
                    DataInicio = ProjetoVM.DataInicio,
                    DataConclusao = ProjetoVM.DataConclusao
                };

                await _projetoRepository.Adicionar(projeto);
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
