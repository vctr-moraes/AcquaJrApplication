using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AcquaJrApplication.Pages
{
    public class ServicosModel : PageModel
    {
        private readonly ILogger<ServicosModel> _logger;

        public ServicosModel(ILogger<ServicosModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
