using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AcquaJrApplication.Pages
{
    public class DiretoriaModel : PageModel
    {
        private readonly ILogger<DiretoriaModel> _logger;

        public DiretoriaModel(ILogger<DiretoriaModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
