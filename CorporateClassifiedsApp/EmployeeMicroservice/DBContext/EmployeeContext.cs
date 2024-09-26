using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeMicroservice.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeMicroservice.DBContext
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
            .Property(b => b.EmpId)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Employee>()
           .Property(s => s.Points)
           .HasDefaultValueSql("0");//.HasColumnType("int");

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmpId = 1,
                    Name = "Electronics",
                    Points = 0,
                    MobileNum = 7788998877,
                    Email = "abc@xyz.com",
                    DOB = Convert.ToDateTime("14/11/1997"),
                    //DOB = "14-11-1997",
                }
                );
        }

    }
}
