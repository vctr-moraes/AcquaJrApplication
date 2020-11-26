using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using AcquaJrApplication.Data;
using AcquaJrApplication.Models;
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
        private readonly IMembroRepository _membroRepository;

        public CreateModel(ApplicationDbContext context,
            IProjetoRepository projetoRepository,
            IClienteRepository clienteRepository,
            IServicoRepository servicoRepository,
            IMembroRepository membroRepository)
        {
            _context = context;
            _projetoRepository = projetoRepository;
            _clienteRepository = clienteRepository;
            _servicoRepository = servicoRepository;
            _membroRepository = membroRepository;

            ProjetoVM = new ProjetoViewModel();
        }

        [BindProperty]
        public ProjetoViewModel ProjetoVM { get; set; }

        public IActionResult OnGet()
        {
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
                Cliente cliente = await _clienteRepository.ObterPorId(ProjetoVM.ClienteId);
                Servico servico = await _servicoRepository.ObterPorId(ProjetoVM.ServicoId);
                
                Projeto projeto = new Projeto(cliente, servico)
                {
                    ClienteId = ProjetoVM.ClienteId,
                    ServicoId = ProjetoVM.ServicoId,
                    Nome = ProjetoVM.Nome,
                    Descricao = ProjetoVM.Descricao,
                    CustoMaoDeObra = Convert.ToDecimal(ProjetoVM.CustoMaoDeObra),
                    CustoProjeto = Convert.ToDecimal(ProjetoVM.CustoProjeto),
                    CustoInsumos = Convert.ToDecimal(ProjetoVM.CustoInsumos),
                    Orcamento = Convert.ToDecimal(ProjetoVM.Orcamento),
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

                if (ProjetoVM.MembrosId != null)
                {
                    foreach (var item in ProjetoVM.MembrosId ?? Enumerable.Empty<Guid>())
                    {
                        Membro membro = await _membroRepository.ObterPorId(item);
                        projeto.AdicionarMembro(membro);
                    }
                }
                else
                {
                    DomainException.When(ProjetoVM.MembrosId == null, "O projeto precisa conter, ao menos, um membro participante.");
                }

                await _projetoRepository.SalvarProjeto(projeto);
                return RedirectToPage("./Index");
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
