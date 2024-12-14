using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQTutorial
{

    /*
        - Where berfungsi untuk menyaring sumber data.
     */
    public class WhereClause
    {
        public static void main() 
        {
            Students[] students = {
                new Students("yudi", 21, "cirebon"),
                new Students("eka", 34, "majalengka"),
                new Students("didit", 14, "indramayu"),
                new Students("anggi", 54, "bandung")
            };

            getPerson(students);
            numbers();
        }

        // menampilkan data students dimana usianya lebih dari 20 tahun
        public static void getPerson(Students[] students) 
        {
            var names = from item in students
                        where item.Age > 20
                        select item;

            foreach (var i in names) 
            {
                Console.WriteLine($"Nama : {i.Name}\nUsia : {i.Age}\nAlamat : {i.Address}");
            }
        }

        public static void numbers()
        {
            int[] nums = { 5, 1, 3, 2, 4 };

            int ganjil = (from num in nums
                         where num % 2 != 0 && num > 3
                         select num).FirstOrDefault();

            Console.WriteLine("Nums is " + ganjil);
        }
    }

    public class Students 
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public Students(string name, int age, string address) 
        {
            this.Name = name;
            this.Age = age;
            this.Address = address;
        }


    }
}
