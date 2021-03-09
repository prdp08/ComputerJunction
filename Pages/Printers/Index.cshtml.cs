using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ComputerJunction.Data;
using ComputerJunction.Models;

namespace ComputerJunction.Pages.Printers
{
    public class IndexModel : PageModel
    {
        private readonly ComputerJunction.Data.ComputerJunctionContext _context;

        public IndexModel(ComputerJunction.Data.ComputerJunctionContext context)
        {
            _context = context;
        }

        public IList<Printer> Printer { get;set; }

        public async Task OnGetAsync()
        {
            Printer = await _context.Printer.ToListAsync();
        }
    }
}
