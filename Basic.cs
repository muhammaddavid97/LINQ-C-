using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQTutorial
{
    public class Basic
    {
        public static void main() 
        {
            //numbers();
            //persons();
            persons2();
        }
        public static void numbers() 
        {
            int[] nums = { 10, 5, 2, 1 };

            // from => klausa untuk menentukan sumber data yang akan diambil datanya.
            // select => klausa untuk menampilkan data kemudian di tampung ke variable.
            var result = from x in nums
                         where x > 5
                         select x;

            foreach (var item in result) 
            {
                Console.WriteLine(item);
            }
        }
        public static void persons() 
        {
            Person[] peoples = new Person[]
            {
                new Person("ujang", 34),
                new Person("udin", 54),
                new Person("irna", 13),
                new Person("rudi",  21)
            };
            
            List<Person> person = new List<Person>();

            foreach (var item in peoples) 
            {
                person.Add(item);
            }

            var listOfPerson = from item in person
                               select item;

            foreach(var item in listOfPerson) 
            {
                Console.WriteLine($"Nama {item.Name}\nUsia {item.Age}");
            }
        }
        public static void persons2() 
        {
            Dictionary<int, Person> person = new Dictionary<int, Person>();
            Person[] peoples = new Person[]
            {
                new Person("ujang", 34),
                new Person("udin", 54),
                new Person("irna", 13),
                new Person("rudi",  21)
            };

            int count = 1;

            foreach (var item in peoples)
            {
                person.Add(count, item);

                count++;
            }

            // menampilkan data person yang usianya lebih dari 20 tahun

            var tempPerson = from item in person
                                        where item.Value.Age > 20
                                        select item;

            foreach(var item in tempPerson)
            {
                Console.WriteLine($"ID : {item.Key} Name : {item.Value.Name}");
            }
        }
    }

    class Person 
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age) 
        {
            this.Name = name;
            this.Age = age;
        }
    }
}
