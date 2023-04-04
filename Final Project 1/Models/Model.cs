using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_1.Models
{
    public class Buku
    {
        public int id { get; set; }
        public string judul { get; set; }
        public string pengarang { get; set; }
        public string penerbit { get; set; }
        public string tahun { get; set; }
    }

    public class Anggota
    {
        public int id { get; set; }
        public string NIK { get; set; }
        public string nama { get; set; }
        public string alamat { get; set; }
        public string jenis_kelamin { get; set; }
        public bool status_anggota { get; set; }
    }

    public class Pinjam
    {
        public int id { get; set; }
        public int id_anggota { get; set; }
        public int id_buku { get; set; }
        public DateTime tgl_pinjam { get; set; }
        public DateOnly tgl_kembali { get; set; }
        public bool status { get; set; }
    }

    public class Kembali
    {
        public int id { get; set; }
        public int id_pinjam { get; set; }
        public int id_buku { get; set; }
        public int denda { get; set; }
        public DateTime tgl_kembali { get; set; }
    }

}