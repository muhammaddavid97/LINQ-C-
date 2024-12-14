using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQTutorial
{
    public class SelectClausa
    {
        public static void main()
        {
            sumNums();
            getCustomers();
        }

        public static void sumNums()
        {
            Random random = new Random();
            List<int> list = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(random.Next(i, 50));
            }

            int isSum = (from item in list
                        select item).Count();

            Console.WriteLine("Sum is " + isSum);
        }

        public static void getCustomers()
        {
            List<Customers> custs = new List<Customers>();
            Customers[] customers =
            {
                new Customers("Akhmad", "Maulana", "022-98712", "Bandung"),
                new Customers("Cindy", "Melany", "021-891221", "Jakarta"),
                new Customers("Dewi", "Ayuandra", "0231-9872113", "Cirebon"),
                new Customers("Pipit", "Ayuhandayani", "065-9821753", "Serang")
            };

            foreach (var item in customers)
            {
                custs.Add(item);
            }

            // menampilkan data customer yang berasal dari jakarta
            var getCust = (from item in custs
                          where item.Location.Equals("Jakarta")
                          select new Customers(item.FirstName, item.LastName, item.PhoneNumber, item.Location)).FirstOrDefault();

            Console.WriteLine($"Nama {getCust.FirstName + " " + getCust.LastName} " +
                $"\nAsal {getCust.Location} " +
                $"\nNomor Telepong : {getCust.PhoneNumber}");
        }
    }

    public class Customers
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
        public Customers(string firstName, string lastName, string phoneNumber, string location)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            this.Location = location;
        }

    }
}
