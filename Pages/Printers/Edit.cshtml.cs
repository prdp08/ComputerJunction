using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComputerJunction.Data;
using ComputerJunction.Models;

namespace ComputerJunction.Pages.Printers
{
    public class EditModel : PageModel
    {
        private readonly ComputerJunction.Data.ComputerJunctionContext _context;

        public EditModel(ComputerJunction.Data.ComputerJunctionContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Printer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrinterExists(Printer.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PrinterExists(int id)
        {
            return _context.Printer.Any(e => e.ID == id);
        }
    }
}
