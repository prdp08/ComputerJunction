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
    public class DetailsModel : PageModel
    {
        private readonly ComputerJunction.Data.ComputerJunctionContext _context;

        public DetailsModel(ComputerJunction.Data.ComputerJunctionContext context)
        {
            _context = context;
        }

        public Printer Printer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Printer = await _context.Printer.FirstOrDefaultAsync(m => m.ID == id);

            if (Printer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
