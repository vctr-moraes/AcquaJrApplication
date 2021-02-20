using Microsoft.AspNetCore.Mvc;
using AcquaJrApplication.ViewsModels;

namespace AcquaJrApplication.Controllers
{
    public class EventoController : Controller
    {
        public IActionResult IncluirDataEvento([Bind("Id, EventoId, Data, HoraInicio, HoraEncerramento")] DataEventoViewModel dataEvento)
        {
            return PartialView("~/Areas/Dashboard/Pages/Eventos/_DataEventoPartialView.cshtml", new DataEventoViewModel()
            {
                Id = dataEvento.Id,
                EventoId = dataEvento.EventoId,
                Data = dataEvento.Data,
                HoraInicio = dataEvento.HoraInicio,
                HoraEncerramento = dataEvento.HoraEncerramento
            });
        }
    }
}
