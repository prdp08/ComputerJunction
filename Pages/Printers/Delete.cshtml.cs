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
    public class DeleteModel : PageModel
    {
        private readonly ComputerJunction.Data.ComputerJunctionContext _context;

        public DeleteModel(ComputerJunction.Data.ComputerJunctionContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Printer = await _context.Printer.FindAsync(id);

            if (Printer != null)
            {
                _context.Printer.Remove(Printer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
