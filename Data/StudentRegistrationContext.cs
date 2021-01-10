using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentRegistration.Models;

namespace StudentRegistration.Data
{
    public class StudentRegistrationContext : DbContext
    {
        public StudentRegistrationContext (DbContextOptions<StudentRegistrationContext> options)
            : base(options)
        {
        }

        public DbSet<StudentRegistration.Models.Student> Student { get; set; }
    }
}
