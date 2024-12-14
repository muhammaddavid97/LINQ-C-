using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQTutorial
{
    public class OrderBy
    {
        public static void main()
        {
            Person3[] people =
            {
                new Person3("udin", "sedunia", 45),
                new Person3("joko", "widodo", 74),
                new Person3("reza", "samsudin", 21),
                new Person3("wiwin", "widyawati", 32),
                new Person3("eko", "samuel", 23)
            };

            numbers();
            printName(people);
        }

        public static void numbers() 
        {
            int[] nums = new int[] { 11, 4, 2, 3, 1, 5 };

            // mengurutkan data secara ascending 
            var getNums = from i in nums
                          orderby i ascending
                          select i;

            foreach (int i in getNums) {
                Console.WriteLine(i);
            }
        }

        // menampilkan data terurut berdasarkan nama
        public static void printName(Person3[] people) 
        {
            var getName = from item in people
                          orderby item.FirstName ascending
                          select item.FirstName + " " + item.LastName;

            foreach (var item in getName)
            {
                Console.WriteLine("Nama lengkap : " + item);
            }
        }
    }

    public class Person3
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Person3(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }
    }
}
