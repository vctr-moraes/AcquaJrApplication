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

namespace AcquaJrApplication.Areas.Dashboard.Pages.Clientes
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IClienteRepository _clienteRepository;

        public IndexModel(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [BindProperty]
        public List<ClienteViewModel> Clientes { get; set; }

        public async Task<ActionResult> OnGetAsync()
        {
            Clientes = _clienteRepository.ObterClientes().Select(cliente => new ClienteViewModel(cliente)).ToList();

            return Page();
        }
    }
}
