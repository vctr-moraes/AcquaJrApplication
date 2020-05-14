using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcquaJrApplication.Data;
using AcquaJrApplication.Models;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Membros
{
    public class IndexModel : PageModel
    {
        private readonly AcquaJrApplication.Data.ApplicationDbContext _context;

        public IndexModel(AcquaJrApplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Membro> Membro { get;set; }

        public async Task OnGetAsync()
        {
            Membro = await _context.Membros.ToListAsync();
        }
    }
}
