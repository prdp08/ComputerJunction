using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ComputerJunction.Data;
using ComputerJunction.Models;

namespace ComputerJunction.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly ComputerJunction.Data.ComputerJunctionContext _context;

        public DetailsModel(ComputerJunction.Data.ComputerJunctionContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product
                .Include(p => p.Brand).FirstOrDefaultAsync(m => m.ID == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
