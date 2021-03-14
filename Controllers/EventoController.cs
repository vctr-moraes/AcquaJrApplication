using Microsoft.AspNetCore.Mvc;
using AcquaJrApplication.ViewsModels;

namespace AcquaJrApplication.Controllers
{
    public class EventoController : Controller
    {
        public IActionResult IncluirData([Bind("Id, Data, HoraInicio, HoraEncerramento")] DataEventoViewModel dataEvento)
        {
            return PartialView("~/Areas/Dashboard/Pages/Eventos/_DataEventoPartialView.cshtml", new DataEventoViewModel()
            {
                Id = dataEvento.Id,
                Data = dataEvento.Data,
                HoraInicio = dataEvento.HoraInicio,
                HoraEncerramento = dataEvento.HoraEncerramento
            });
        }
    }
}
