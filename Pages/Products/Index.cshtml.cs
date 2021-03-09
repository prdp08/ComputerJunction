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
    public class IndexModel : PageModel
    {
        private readonly ComputerJunction.Data.ComputerJunctionContext _context;

        public IndexModel(ComputerJunction.Data.ComputerJunctionContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Product
                .Include(p => p.Brand).ToListAsync();
        }
    }
}
