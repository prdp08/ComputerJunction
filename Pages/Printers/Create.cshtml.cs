using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ComputerJunction.Data;
using ComputerJunction.Models;

namespace ComputerJunction.Pages.Printers
{
    public class CreateModel : PageModel
    {
        private readonly ComputerJunction.Data.ComputerJunctionContext _context;

        public CreateModel(ComputerJunction.Data.ComputerJunctionContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Printer Printer { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Printer.Add(Printer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
