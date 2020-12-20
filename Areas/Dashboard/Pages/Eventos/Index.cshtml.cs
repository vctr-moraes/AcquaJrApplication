using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcquaJrApplication.Data;
using AcquaJrApplication.Models;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Eventos
{
    public class IndexModel : PageModel
    {
        private readonly AcquaJrApplication.Data.ApplicationDbContext _context;

        public IndexModel(AcquaJrApplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Evento> Evento { get;set; }

        public async Task OnGetAsync()
        {
            Evento = await _context.Eventos.ToListAsync();
        }
    }
}
