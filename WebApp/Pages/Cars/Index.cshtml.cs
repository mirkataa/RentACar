using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Model;

namespace WebApp.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly Data.Context _context;

        public IndexModel(Data.Context context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cars != null)
            {
                Car = await _context.Cars.ToListAsync();
                foreach (var car in Car)
                {
                    var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Car == car.Id);
                    if (customer != null && customer.To <= DateTime.Now)
                    {
                        car.IsRented = false;
                        await _context.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
