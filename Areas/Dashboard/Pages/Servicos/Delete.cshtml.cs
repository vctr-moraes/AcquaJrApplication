﻿using System;
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

namespace AcquaJrApplication.Areas.Dashboard.Pages.Servicos
{
    public class DeleteModel : PageModel
    {
        private readonly IServicoRepository _servicoRepository;

        public DeleteModel(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        [BindProperty]
        public ServicoViewModel ServicoVM { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servico = await _servicoRepository.ObterPorId(id);

            if (servico == null)
            {
                return NotFound();
            }

            ServicoVM = new ServicoViewModel(servico);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servico = await _servicoRepository.ObterPorId(id);

            if (servico != null)
            {
                await _servicoRepository.Remover(servico.Id);
                return RedirectToPage("./Index");
            }

            return RedirectToPage("./Index");
        }
    }
}
