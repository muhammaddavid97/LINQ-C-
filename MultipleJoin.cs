using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQTutorial
{
    public class MultipleJoin
    {
        public static void main()
        {
            getMahasiswa();
        }
        public static void getMahasiswa()
        {
            Dosen3[] dosens = new Dosen3[]
            {
                new Dosen3(Guid.NewGuid().ToString(), "Wahyu pambudi"),
                new Dosen3(Guid.NewGuid().ToString(), "Eka prasetyo"),
                new Dosen3(Guid.NewGuid().ToString(), "Ika setyawati"),
                new Dosen3(Guid.NewGuid().ToString(), "Budi dalton")
            };

            MataKuliah3[] mataKuliahs = new MataKuliah3[]
            {
                new MataKuliah3(Guid.NewGuid().ToString(), dosens[0].Id, "Matematika Diskrit", dosens[0].FullName),
                new MataKuliah3(Guid.NewGuid().ToString(), dosens[0].Id, "Kalkulus Dasar", dosens[0].FullName),
                new MataKuliah3(Guid.NewGuid().ToString(), dosens[2].Id, "Jaringan Komputer", dosens[2].FullName),
                new MataKuliah3(Guid.NewGuid().ToString(), dosens[3].Id, "Strategi Algoritma", dosens[3].FullName),
                new MataKuliah3(Guid.NewGuid().ToString(), dosens[2].Id, "Bahasa Inggris",  dosens[2].FullName)
            };

            Mahasiswa3[] mahasiswa3 = new Mahasiswa3[]
            {
                new Mahasiswa3(Guid.NewGuid().ToString(), "Aji Prasetyo", mataKuliahs[0].Id, mataKuliahs[0].NamaMatkul),
                new Mahasiswa3(Guid.NewGuid().ToString(), "Agus Buntung", mataKuliahs[1].Id, mataKuliahs[1].NamaMatkul),
                new Mahasiswa3(Guid.NewGuid().ToString(), "Agus Sedih", mataKuliahs[3].Id, mataKuliahs[3].NamaMatkul),
                new Mahasiswa3(Guid.NewGuid().ToString(), "Miftah Anjing", mataKuliahs[0].Id, mataKuliahs[0].NamaMatkul),
                new Mahasiswa3(Guid.NewGuid().ToString(), "Novi Niawawati", mataKuliahs[2].Id, mataKuliahs[2].NamaMatkul),
            };

            var getDataMahasiswa = from dosen in dosens
                                   join matkul in mataKuliahs
                                   on dosen.Id equals matkul.IdDosen
                                   join mhs in mahasiswa3
                                   on matkul.Id equals mhs.IdMatkul
                                   orderby mhs.FullName ascending
                                   select new Mahasiswa3(mhs.FullName, mhs.MataKuliah);

            foreach(var item in getDataMahasiswa)
            {
                Console.WriteLine($"Nama mahasiswa : {item.FullName}\nMata Kuliah :{item.MataKuliah}");
            }
                                   
        }
    }

    public class Dosen3
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public Dosen3(string id, string fullName)
        {
            Id = id;
            FullName = fullName;
        }
    }

    public class MataKuliah3
    {
        public string Id { get; set; }
        public string IdDosen { get; set; }
        public string NamaMatkul { get; set; }
        public string NamaDosen { get; set; }
        public MataKuliah3(string id, string idDosen, string namaMatkul, string namaDosen)
        {
            this.Id = id;
            this.IdDosen = idDosen;
            this.NamaMatkul = namaMatkul;
            this.NamaDosen = namaDosen;
        }
    }

    class Mahasiswa3
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string IdMatkul { get; set; }
        public string MataKuliah { get; set; }

        public Mahasiswa3(string id, string fullName, string idMatkul, string mataKuliah)
        {
            Id = id;
            FullName = fullName;
            IdMatkul = idMatkul;
            MataKuliah = mataKuliah;
        }

        public Mahasiswa3(string fullName, string mataKuliah) 
        {
            this.FullName = fullName;
            this.MataKuliah = mataKuliah;
        }
    }
}
