using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data;
using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly Data.Context _context;

        public CreateModel(Data.Context context)
        {
            _context = context;
        }

        public List<Car> Cars { get; set; } = new List<Car>();

        public async Task<IActionResult> OnGetAsync()
        {
            
            Cars = await _context.Cars.Where(c => c.IsRented == false).ToListAsync();

            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Customers == null || Customer == null)
            {
                return Page();
            }

            // Find the car that the customer selected
            var selectedCar = await _context.Cars.FindAsync(Customer.Car);

            if (selectedCar == null)
            {
                return Page();
            }

            // Update the IsRented property of the selected car to true
            selectedCar.IsRented = true;

            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
