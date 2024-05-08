using SqlServerDatabaseApp.Model;

namespace SqlServerDatabaseApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            dbEmployeeTrackerContext context = new dbEmployeeTrackerContext();
            var areas = context.Areas.ToList();
            foreach(Area a in areas)
            {
                Console.WriteLine(a.Area1+" "+a.Zipcode);
            }
            //var area = areas.SingleOrDefault(a => a.Area1 == "TTTT");
            //area.Zipcode = "00000";
            //context.Areas.Update(area);
            //context.SaveChanges();

            //area = areas.SingleOrDefault(a => a.Area1 == "HYHY");
            //context.Areas.Remove(area);
            //context.SaveChanges();
            //foreach (var a in areas)
            //{
            //    Console.WriteLine(a.Area1 + " " + a.Zipcode);
            //}
        }
    }
}
