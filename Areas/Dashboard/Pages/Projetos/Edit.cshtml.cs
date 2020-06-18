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
using Microsoft.AspNetCore.Authorization;
using AcquaJrApplication.Interfaces;
using AcquaJrApplication.ViewsModels;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Projetos
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IProjetoRepository _projetoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IServicoRepository _servicoRepository;

        public EditModel(ApplicationDbContext context, IProjetoRepository projetoRepository, IClienteRepository clienteRepository, IServicoRepository servicoRepository)
        {
            _context = context;
            _projetoRepository = projetoRepository;
            _clienteRepository = clienteRepository;
            _servicoRepository = servicoRepository;

            ProjetoVM = new ProjetoViewModel();
        }

        [BindProperty]
        public ProjetoViewModel ProjetoVM { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Projeto = await _context.Projetos
            //    .Include(p => p.Cliente)
            //    .Include(p => p.Servico).FirstOrDefaultAsync(m => m.Id == id);

            var projeto = await _projetoRepository.ObterPorId(id);

            if (projeto == null)
            {
                return NotFound();
            }

            ProjetoVM = new ProjetoViewModel(projeto);

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
                Projeto projeto = await _projetoRepository.ObterPorId(ProjetoVM.Id);

                projeto.ClienteId = ProjetoVM.ClienteId;
                projeto.ServicoId = ProjetoVM.ServicoId;
                projeto.Nome = ProjetoVM.Nome;
                projeto.Descricao = ProjetoVM.Descricao;
                projeto.CustoMaoDeObra = ProjetoVM.CustoMaoDeObra;
                projeto.CustoProjeto = ProjetoVM.CustoProjeto;
                projeto.CustoInsumos = ProjetoVM.CustoInsumos;
                projeto.Orcamento = ProjetoVM.Orcamento;
                projeto.Logradouro = ProjetoVM.Logradouro;
                projeto.PontoReferencia = ProjetoVM.PontoReferencia;
                projeto.Bairro = ProjetoVM.Bairro;
                projeto.Cidade = ProjetoVM.Cidade;
                projeto.Cep = ProjetoVM.Cep;
                projeto.Estado = ProjetoVM.Estado;
                projeto.DataContrato = ProjetoVM.DataContrato;
                projeto.DataPrevista = ProjetoVM.DataPrevista;
                projeto.DataInicio = ProjetoVM.DataInicio;
                projeto.DataConclusao = ProjetoVM.DataConclusao;

                await _projetoRepository.Atualizar(projeto);
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
