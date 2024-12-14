using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQTutorial
{
    /*
        - Variable query adalah variable yang digunakan untuk menampung hasil query.

        - Jenis variable query sebagai berikut :
           - Tipe enumerasi => tipe yang mengembalikan kumpulan data.
           - Tipe skalar => tipe yang mengembalikan nilai tunggal biasanya menggunakan method aggregate
        
        - Jika variable query merupakan enumerasi maka akan mempengaruhi perubahan terhadap 
          perubahan yang terjadi pada sumber data.
        
        - Jika variable query merupakan skalar maka eksekusi query hanya dilakukan sekali sehingga 
          perubahan yang terjadi pada sumber data tidak akan berpengaruh.


        - 
     */
    public class QueryVariable
    {
        public static void main() 
        {
            Person2[] peoples = new Person2[]
            {
                new Person2("ujang", 34),
                new Person2("udin", 54),
                new Person2("irna", 13),
                new Person2("rudi",  21)
            };

            person(peoples);
            Console.WriteLine(getName(peoples));
        }

        public static void person(Person2[] peoples) 
        {

            int size = (from p in peoples
                       select p).Count();

            Console.WriteLine("Jumlah data = " + size);
        }

        // mengambil nama dari data person berdasarkan usia 13 tahun
        public static string getName(Person2[] peoples) 
        {
            var items = from i in  peoples
                        where i.Age.Equals(13)
                        select i;

            string name = items.FirstOrDefault().Name;

            return name;
        }
    }

    public class Person2
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person2(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}
