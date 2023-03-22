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

namespace WebApp.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly Data.Context _context;

        public CreateModel(Data.Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Cars == null || Car == null)
            {
                return Page();
            }

            // Check if the entered registration number already exists in the Cars table
            bool rgNumExists = await _context.Cars.AnyAsync(c => c.RgNum == Car.RgNum);

            if (rgNumExists)
            {
                ModelState.AddModelError("Car.RgNum", "Въведеният регистрационен номер вече съществува!");
                return Page();
            }

            _context.Cars.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
