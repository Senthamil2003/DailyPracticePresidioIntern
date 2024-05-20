using SampleLinqApp.Model;

namespace SampleLinqApp
{
    public class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public string City { get; set; }    
    }

    internal class Program
    {
        void SamplePrint(string data)
        {
            pubsContext context = new pubsContext();
            var books = context.Titles
                        .GroupBy(t => t.PubId)
                        .Select(t => new
                        {
                            PublisherId = t.Key,
                            TitleCount = t.Count(),
                            Titles = t.Select(t => new
                            {
                                BookName = t.Title1,
                                BookPrice = t.Price
                            })
                        });

            foreach (var book in books)
            {
                Console.Write(book.PublisherId);
                Console.WriteLine(" - " + book.TitleCount);
                foreach (var title in book.Titles)
                {
                    Console.WriteLine("\t" + title.BookName + " " + title.BookPrice);
                }
            }
        }
        void SalesQuery()
        {
            pubsContext pubsContext = new pubsContext();
            var tittles = pubsContext.Sales.GroupBy(s => s.TitleId).Select(t => new
            {
                tittleId = t.Key,
                count = t.Count(),
                orders = t.Select(t => new
                {
                    OrderId = t.OrdNum,
                    Quantity = t.Qty

                })

            });
            foreach (var tittle in tittles)
            {
                Console.WriteLine("Order Id" + tittle.tittleId + "   " + tittle.count);
                foreach (var order in tittle.orders)
                {
                    Console.WriteLine(order.OrderId + " " + order.Quantity);
                }
                Console.WriteLine("-----------------------------------------");

            }
        }
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>
        {
            new Employee { Name = "Alice", Department = "HR", City = "New York" },
            new Employee { Name = "Bob", Department = "IT", City = "Los Angeles" },
            new Employee { Name = "Charlie", Department = "Dep", City = "New York" },
            new Employee { Name = "David", Department = "Finance", City = "San Francisco" },
            new Employee { Name = "Eve", Department = "IT", City = "Los Angeles" }
        };

            // Group employees by department and city
            var groupedEmployees = employees.GroupBy(e => new { e.Department, e.City });

            // Display the results
            foreach (var group in groupedEmployees)
            {
                Console.WriteLine($"Department: {group.Key.Department}, City: {group.Key.City}");
                foreach (var employee in group)
                {
                    Console.WriteLine($"  {employee.Name}");
                }
            }

        }
    }

}
