using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AcquaJrApplication.Pages
{
    public class ContatoModel : PageModel
    {
        private readonly ILogger<ContatoModel> _logger;

        public ContatoModel(ILogger<ContatoModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
