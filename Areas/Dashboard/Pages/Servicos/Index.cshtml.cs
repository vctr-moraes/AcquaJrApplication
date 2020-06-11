using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using AcquaJrApplication.Data;
using AcquaJrApplication.Models;
using AcquaJrApplication.Interfaces;
using AcquaJrApplication.ViewsModels;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Servicos
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IServicoRepository _servicoRepository;

        public IndexModel(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        public List<ServicoViewModel> Servicos { get; set; }

        public async Task<ActionResult> OnGetAsync()
        {
            Servicos = _servicoRepository.ObterServicos().Select(servico => new ServicoViewModel(servico)).ToList();

            return Page();
        }
    }
}
