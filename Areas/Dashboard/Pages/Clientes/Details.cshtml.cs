﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using AcquaJrApplication.Interfaces;
using AcquaJrApplication.ViewsModels;
using AcquaJrApplication.Models;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Clientes
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly IClienteRepository _clienteRepository;

        public DetailsModel(IClienteRepository clienteRepository)
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

            Cliente cliente = await _clienteRepository.ObterPorId(id);

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

            Cliente cliente = await _clienteRepository.ObterPorId(id);

            if (cliente == null)
            {
                return NotFound();
            }

            if (cliente != null)
            {
                try
                {
                    await _clienteRepository.ExcluirCliente(id);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    ClienteVM = new ClienteViewModel(cliente);

                    return Page();
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
