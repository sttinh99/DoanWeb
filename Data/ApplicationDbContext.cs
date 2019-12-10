using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestCase.Models;

namespace TestCase.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProductTypes> ProductTypes { get; set; }
        public DbSet<Products> Products { get; set; }
        
        public DbSet<Appointments> Appointments { get; set; }
        public DbSet<ErrorViewModel> ErrorViewModels { get; set; }
        public DbSet<ProductsSelectedForAppointment> ProductsSelectedForAppointments { get; set; }
        public DbSet<UsersGuests> UsersGuests { get; set; }
    }
}
