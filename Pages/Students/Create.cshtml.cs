﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentRegistration.Data;
using StudentRegistration.Models;

namespace StudentRegistration.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly StudentRegistration.Data.StudentRegistrationContext _context;

        public CreateModel(StudentRegistration.Data.StudentRegistrationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
             if (!ModelState.IsValid)
             {
                 return Page();
             }

             _context.Student.Add(Student);
             await _context.SaveChangesAsync();

             return RedirectToPage("./Index");
            
            
        }
    }
}
