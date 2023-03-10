using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (!_context.Department.Any() ||
                !_context.Seller.Any() ||
                !_context.SalesRecord.Any())
            {

                Department d1 = new Department("Computers");
                Department d2 = new Department("Eletronics");
                Department d3 = new Department("Fashion");
                Department d4 = new Department("Books");

                Seller s1 = new Seller("Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
                Seller s2 = new Seller("Ada Young", "ada@gmail.com", new DateTime(1992, 5, 10), 1300.0, d2);
                Seller s3 = new Seller("Jesse Pinkman", "jesse@gmail.com", new DateTime(1997, 10, 20), 1800.0, d3);
                Seller s4 = new Seller("Walter White", "walt@gmail.com", new DateTime(1972, 2, 5), 1900.0, d4);
                Seller s5 = new Seller("Rebert Richers", "rebert@gmail.com", new DateTime(2004, 10, 20), 1900.0, d2);
                Seller s6 = new Seller("Cristiano Ronaldo", "cr7@gmail.com", new DateTime(1997, 8, 26), 1800.0, d1);

                SalesRecord r1 = new SalesRecord(new DateTime(2022, 09, 02), 11000.0, SaleStatus.Billed, s1);
                SalesRecord r2 = new SalesRecord(new DateTime(2022, 08, 16), 12000.0, SaleStatus.Billed, s2);
                SalesRecord r3 = new SalesRecord(new DateTime(2022, 08, 17), 9000.0, SaleStatus.Billed, s3);
                SalesRecord r4 = new SalesRecord(new DateTime(2022, 08, 20), 8000.0, SaleStatus.Billed, s4);
                SalesRecord r5 = new SalesRecord(new DateTime(2022, 09, 01), 8500.0, SaleStatus.Billed, s5);
                SalesRecord r6 = new SalesRecord(new DateTime(2022, 08, 14), 10000.0, SaleStatus.Billed, s6);
                SalesRecord r7 = new SalesRecord(new DateTime(2022, 08, 29), 12500.0, SaleStatus.Billed, s6);
                SalesRecord r8 = new SalesRecord(new DateTime(2022, 08, 26), 7500.0, SaleStatus.Billed, s3);
                SalesRecord r9 = new SalesRecord(new DateTime(2022, 08, 23), 8700.0, SaleStatus.Billed, s4);
                SalesRecord r10 = new SalesRecord(new DateTime(2022, 08, 29), 18500.0, SaleStatus.Billed, s5);

                _context.Department.AddRange(d1, d2, d3, d4);
                _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);
                _context.SalesRecord.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10);
                _context.SaveChanges();

            }
        }
    }
}
