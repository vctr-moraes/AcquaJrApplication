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

        public IList<Servico> ServicoVM { get;set; }

        public async Task OnGetAsync()
        {
            ServicoVM = await _servicoRepository.ObterTodosServicos();
        }
    }
}
