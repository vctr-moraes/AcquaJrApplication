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
        private readonly ApplicationDbContext _context;
        private readonly IClienteRepository _clienteRepository;

        public IndexModel(ApplicationDbContext context, IClienteRepository clienteRepository)
        {
            _context = context;
            _clienteRepository = clienteRepository;
        }

        [BindProperty]
        public IList<ClienteViewModel> ClienteVM { get; set; }

        public async Task OnGetAsync()
        {
            ClienteVM = await _context.Clientes.Select(cliente => new ClienteViewModel(cliente)).ToListAsync();
        }
    }
}
