using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AcquaJrApplication.Interfaces;
using AcquaJrApplication.ViewsModels;
using Microsoft.AspNetCore.Authorization;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Eventos
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IEventoRepository _eventoRepository;

        public IndexModel(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        [BindProperty]
        public List<EventoViewModel> Eventos { get;set; }

        public ActionResult OnGet()
        {
            Eventos = _eventoRepository.ObterEventos().Select(evento => new EventoViewModel(evento)).ToList();
            return Page();
        }
    }
}
