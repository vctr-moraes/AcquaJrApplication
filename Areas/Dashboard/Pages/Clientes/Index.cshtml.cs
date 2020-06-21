using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
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

        public ActionResult OnGet()
        {
            Clientes = _clienteRepository.ObterClientes().Select(cliente => new ClienteViewModel(cliente)).ToList();
            return Page();
        }
    }
}
