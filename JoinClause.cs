using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQTutorial
{

    // join berfungsi untuk menampilkan data yang berasal dari dua buah objek berdasarkan data tertentu
    // yang bertindak sebagai relasi.
    public class JoinClause
    {
        public static void main()
        {
            getDataDosen();
        }

        public static void getDataDosen()
        {
            Dosen[] dosens = new Dosen[]
            {
                new Dosen(Guid.NewGuid().ToString(), "Wahyu pambudi"),
                new Dosen(Guid.NewGuid().ToString(), "Eka prasetyo"),
                new Dosen(Guid.NewGuid().ToString(), "Ika setyawati"),
                new Dosen(Guid.NewGuid().ToString(), "Budi dalton")
            };

            MataKuliah[] mataKuliahs = new MataKuliah[]
            {
                new MataKuliah(Guid.NewGuid().ToString(), dosens[0].Id, "Matematika Diskrit"),
                new MataKuliah(Guid.NewGuid().ToString(), dosens[0].Id, "Kalkulus Dasar"),
                new MataKuliah(Guid.NewGuid().ToString(), dosens[2].Id, "Jaringan Komputer"),
                new MataKuliah(Guid.NewGuid().ToString(), dosens[3].Id, "Strategi Algoritma"),
                new MataKuliah(Guid.NewGuid().ToString(), dosens[2].Id, "Bahasa Inggris")
            };

            var getDosen = from dosen in dosens
                           join matkul in mataKuliahs
                           on dosen.Id equals matkul.IdDosen
                           orderby dosen.FullName ascending
                           select new View(dosen.FullName, matkul.NamaMatkul);

            foreach(var dosen in getDosen)
            {
                Console.WriteLine($"Nama Dosen : {dosen.NamaDosen} \nMata Kuliah : {dosen.MataKuliah}");
            }
        }
    }

    public class Dosen
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public Dosen(string id, string fullName)
        {
            Id = id;
            FullName = fullName;
        }
    }

    public class MataKuliah
    {
        public string Id { get; set; }
        public string IdDosen { get; set; }
        public string NamaMatkul {  get; set; }
        public MataKuliah(string id, string idDosen, string namaMatkul) 
        {
            this.Id = id;
            this.IdDosen = idDosen;
            this.NamaMatkul = namaMatkul;
        }
    }
    
    public class View
    {
        public string NamaDosen { get; set; }
        public string MataKuliah { get; set; }

        public View(string namaDosen, string mataKuliah)
        {
            NamaDosen = namaDosen;
            MataKuliah = mataKuliah;
        }
    }
}
