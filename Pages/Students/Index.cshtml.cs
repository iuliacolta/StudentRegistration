using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentRegistration.Data;
using StudentRegistration.Models;

namespace StudentRegistration.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly StudentRegistration.Data.StudentRegistrationContext _context;

        public IndexModel(StudentRegistration.Data.StudentRegistrationContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string StudentGenre { get; set; }

        public async Task OnGetAsync()
        {
            //Student = await _context.Student.ToListAsync();
            var students = from m in _context.Student
                           select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                students = students.Where(s => s.Name.Contains(SearchString));
            }

            Student = await students.ToListAsync();

            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Student
                                            orderby m.Genre
                                            select m.Genre;

            var movies = from m in _context.Student
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(StudentGenre))
            {
                movies = movies.Where(x => x.Genre == StudentGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Student = await movies.ToListAsync();
        }
    }
}
