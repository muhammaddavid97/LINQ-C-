using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQTutorial
{
    public class IntoClause
    {
        public static void main()
        {
            getDosen2();
        }

        public static void getDosen2()
        {
            Dosen2[] dosens = new Dosen2[]
            {
                new Dosen2(Guid.NewGuid().ToString(), "Wahyu pambudi"),
                new Dosen2(Guid.NewGuid().ToString(), "Eka prasetyo"),
                new Dosen2(Guid.NewGuid().ToString(), "Ika setyawati"),
                new Dosen2(Guid.NewGuid().ToString(), "Budi dalton")
            };

            MataKuliah2[] mataKuliahs = new MataKuliah2[]
            {
                new MataKuliah2(Guid.NewGuid().ToString(), dosens[0].Id, "Matematika Diskrit", dosens[0].FullName),
                new MataKuliah2(Guid.NewGuid().ToString(), dosens[0].Id, "Kalkulus Dasar", dosens[0].FullName),
                new MataKuliah2(Guid.NewGuid().ToString(), dosens[2].Id, "Jaringan Komputer", dosens[2].FullName),
                new MataKuliah2(Guid.NewGuid().ToString(), dosens[3].Id, "Strategi Algoritma", dosens[3].FullName),
                new MataKuliah2(Guid.NewGuid().ToString(), dosens[2].Id, "Bahasa Inggris",  dosens[2].FullName)
            };

            var getDosen = from dosen in dosens
                           join matkul  in mataKuliahs
                           on dosen.Id equals matkul.IdDosen
                           into temp 
                           select temp;

            foreach(var item in getDosen)
            {
                foreach(var data in item)
                {
                    Console.WriteLine($"Nama Dosen : {data.NamaDosen}\nMata Kuliah : {data.NamaMatkul}");
                }
            }

        }
    }

    public class Dosen2
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public Dosen2(string id, string fullName)
        {
            Id = id;
            FullName = fullName;
        }
    }

    public class MataKuliah2
    {
        public string Id { get; set; }
        public string IdDosen { get; set; }
        public string NamaMatkul { get; set; }
        public string NamaDosen { get; set; }
        public MataKuliah2(string id, string idDosen, string namaMatkul,  string namaDosen)
        {
            this.Id = id;
            this.IdDosen = idDosen;
            this.NamaMatkul = namaMatkul;
            this.NamaDosen = namaDosen;
        }
    }

}
