namespace demoASP.Migrations
{
    using demoASP.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<demoASP.Data.AppDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(demoASP.Data.AppDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            try {
                ICollection<Customer> cs = new List<Customer>();
                cs.Add(new Customer {
                    CustomerId=1,
                    CompanyName = "ลูกค้าทั่วไป", 
                    ContactName="-", 
                    Address="-", 
                    PostalCode="90110", 
                    Country="TH", Phone="-" 
                });
                context.Customers.AddOrUpdate(cs.ToArray());

                ICollection<Employee> e = new List<Employee>();
                e.Add(new Employee { EmployeeID=1 ,Title = "Mr.", FirstName = "Supakit", LastName = "Sriwatcharamethee" });
                context.Employees.AddOrUpdate(e.ToArray());

                ICollection<Shipper> s = new List<Shipper>();
                s.Add(new Shipper { ShipperId = 1 ,CompanyName = "My Company", Phone = "0" });
                context.Shipper.AddOrUpdate(s.ToArray());

                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            
        }
    }
}
