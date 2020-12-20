using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AcquaJrApplication.Interfaces;
using AcquaJrApplication.ViewsModels;
using Microsoft.AspNetCore.Authorization;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Eventos
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IEventoRepository _eventoRepository;

        public CreateModel(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public EventoViewModel EventoVM { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Eventos.Add(Evento);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
