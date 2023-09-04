using ASP_NET_HW_12.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_HW_12.Data {
    public class DataContextInitializer : IDataContextInitializer {
        private readonly DataContext _context;

        public DataContextInitializer(DataContext context) {
            _context = context;
        }

        public void Initialize() {
            _context.Database.Migrate();

            if (_context.Corporations!.Any()) return;

            var corporation = new Corporation {
                Name = "Sample Corporation"
            };
            _context.Corporations!.Add(corporation);

            var company1 = new Company {
                Name = "Company A",
                Corporation = corporation
            };
            _context.Companies!.Add(company1);

            var company2 = new Company {
                Name = "Company B",
                Corporation = corporation
            };
            _context.Companies.Add(company2);

            // Seed countries and cities
            var usa = new Country {
                Name = "United States"
            };
            _context.Countries!.Add(usa);

            var newYork = new City {
                Name = "New York",
                Country = usa
            };
            _context.Cities!.Add(newYork);

            var california = new City {
                Name = "Los Angeles",
                Country = usa
            };
            _context.Cities.Add(california);

            // Seed addresses
            var address1 = new Address {
                StreetName = "123 Main Street",
                BuildingNumber = "A1",
                City = newYork
            };
            _context.Addresses!.Add(address1);

            var address2 = new Address {
                StreetName = "456 Elm Street",
                BuildingNumber = "B2",
                City = california
            };
            _context.Addresses.Add(address2);

            // Seed employees
            var employee1 = new Employee {
                FullName = "John Doe",
                Company = company1,
                Position = "Manager",
                Salary = 75000
            };
            _context.Employees!.Add(employee1);

            var employee2 = new Employee {
                FullName = "Jane Smith",
                Company = company2,
                Position = "Developer",
                Salary = 60000
            };
            _context.Employees.Add(employee2);

            // Seed insurances
            var insurance1 = new Insurance {
                Name = "Health Insurance",
                PayoutAmount = 1000
            };
            _context.Insurances!.Add(insurance1);

            var insurance2 = new Insurance {
                Name = "Life Insurance",
                PayoutAmount = 50000
            };
            _context.Insurances.Add(insurance2);

            // Seed employee insurances
            var employeeInsurance1 = new EmployeeInsurance {
                Employee = employee1,
                Insurance = insurance1,
                ContractStartDate = DateTime.Now
            };
            _context.EmployeeInsurances!.Add(employeeInsurance1);

            var employeeInsurance2 = new EmployeeInsurance {
                Employee = employee1,
                Insurance = insurance2,
                ContractStartDate = DateTime.Now
            };
            _context.EmployeeInsurances.Add(employeeInsurance2);

            var employeeInsurance3 = new EmployeeInsurance {
                Employee = employee2,
                Insurance = insurance1,
                ContractStartDate = DateTime.Now
            };
            _context.EmployeeInsurances.Add(employeeInsurance3);

            _context.SaveChanges();
        }
    }
}