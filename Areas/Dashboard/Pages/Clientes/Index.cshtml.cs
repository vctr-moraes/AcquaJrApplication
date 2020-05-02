using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcquaJrApplication.Data;
using AcquaJrApplication.ViewsModels;

namespace AcquaJrApplication.Areas.Dashboard.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        private readonly AcquaJrApplication.Data.ApplicationDbContext _context;

        public IndexModel(AcquaJrApplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ClienteViewModel> ClienteViewModel { get;set; }

        public async Task OnGetAsync()
        {
            ClienteViewModel = await _context.ClienteViewModel.ToListAsync();
        }
    }
}
