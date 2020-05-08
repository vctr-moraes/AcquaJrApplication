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
using AcquaJrApplication.ViewsModels;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Clientes
{
    public class DeleteModel : PageModel
    {
        private readonly IClienteRepository _clienteRepository;

        public DeleteModel(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [BindProperty]
        public ClienteViewModel ClienteVM { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _clienteRepository.ObterPorId(id);

            if (cliente == null)
            {
                return NotFound();
            }

            ClienteVM = new ClienteViewModel(cliente);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _clienteRepository.ObterPorId(id);

            if (cliente != null)
            {
                await _clienteRepository.Remover(cliente.Id);

                return RedirectToPage("./Index");
            }

            return RedirectToPage("./Index");
        }
    }
}
