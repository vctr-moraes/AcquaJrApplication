﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using AcquaJrApplication.Models;
using AcquaJrApplication.Interfaces;
using AcquaJrApplication.ViewsModels;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Projetos
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IServicoRepository _servicoRepository;
        private readonly IMembroRepository _membroRepository;

        public EditModel(IProjetoRepository projetoRepository,
            IClienteRepository clienteRepository,
            IServicoRepository servicoRepository,
            IMembroRepository membroRepository)
        {
            _projetoRepository = projetoRepository;
            _clienteRepository = clienteRepository;
            _servicoRepository = servicoRepository;
            _membroRepository = membroRepository;

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

            Projeto projeto = await _projetoRepository.ObterMembrosProjeto(id);

            if (projeto == null)
            {
                return NotFound();
            }

            ProjetoVM = new ProjetoViewModel(projeto);

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
                Projeto projeto = await _projetoRepository.ObterProjeto(ProjetoVM.Id);

                projeto.Cliente = await _clienteRepository.ObterCliente(ProjetoVM.ClienteId);
                projeto.ClienteId = ProjetoVM.ClienteId;
                projeto.Servico = await _servicoRepository.ObterServico(ProjetoVM.ServicoId);
                projeto.ServicoId = ProjetoVM.ServicoId;
                projeto.Nome = ProjetoVM.Nome;
                projeto.Descricao = ProjetoVM.Descricao;
                projeto.CustoMaoDeObra = Convert.ToDecimal(ProjetoVM.CustoMaoDeObra);
                projeto.CustoProjeto = Convert.ToDecimal(ProjetoVM.CustoProjeto);
                projeto.CustoInsumos = Convert.ToDecimal(ProjetoVM.CustoInsumos);
                projeto.Orcamento = Convert.ToDecimal(ProjetoVM.Orcamento);
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

                if (ProjetoVM.MembrosId != null)
                {
                    IEnumerable<Membro> membros = _membroRepository.ObterMembrosPorId(ProjetoVM.MembrosId);
                    projeto.AtualizarMembros(membros);
                }
                else
                {
                    DomainException.When(ProjetoVM.MembrosId == null, "O projeto precisa conter, ao menos, um membro participante.");
                }

                await _projetoRepository.AtualizarProjeto(projeto);
                return await Task.FromResult(RedirectToPage("./Index"));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
        }

        private void InicializarProjeto()
        {
            if (ProjetoVM != null)
            {
                ProjetoVM.Membros = _membroRepository.ObterMembrosAtivos()
                    .Select(m => new SelectListItem
                    {
                        Text = m.Nome,
                        Value = m.Id.ToString()
                    });

                ProjetoVM.Clientes = _clienteRepository.ObterClientes()
                    .Select(c => new SelectListItem
                    {
                        Text = c.NomeFantasia,
                        Value = c.Id.ToString()
                    });

                ProjetoVM.Servicos = _servicoRepository.ObterServicosAtivos()
                    .Select(s => new SelectListItem
                    {
                        Text = s.Nome,
                        Value = s.Id.ToString()
                    });
            };
        }

        public override PageResult Page()
        {
            InicializarProjeto();
            return base.Page();
        }
    }
}
