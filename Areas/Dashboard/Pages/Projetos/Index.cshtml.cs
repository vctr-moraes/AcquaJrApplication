using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcquaJrApplication.Data;
using AcquaJrApplication.Models;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Projetos
{
    public class IndexModel : PageModel
    {
        private readonly AcquaJrApplication.Data.ApplicationDbContext _context;

        public IndexModel(AcquaJrApplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Projeto> Projeto { get;set; }

        public async Task OnGetAsync()
        {
            Projeto = await _context.Projetos
                .Include(p => p.Cliente)
                .Include(p => p.Servico).ToListAsync();
        }
    }
}
