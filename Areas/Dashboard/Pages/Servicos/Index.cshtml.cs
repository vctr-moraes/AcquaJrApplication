using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcquaJrApplication.Data;
using AcquaJrApplication.Models;
using AcquaJrApplication.Interfaces;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Servicos
{
    public class IndexModel : PageModel
    {
        private readonly IServicoRepository _servicoRepository;

        public IndexModel(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        public IList<Servico> Servico { get;set; }

        public async Task OnGetAsync()
        {
            Servico = await _servicoRepository.ObterTodosServicos();
        }
    }
}
