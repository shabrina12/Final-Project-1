using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_1.Models
{
    //https://www.c-sharpcorner.com/UploadFile/3d39b4/crud-using-the-repository-pattern-in-mvc/
    public class Buku
    {
        public int id { get; set; }
        public string judul { get; set; }
        public string pengarang { get; set; }
        public string penerbit { get; set; }
        public string tahun { get; set; }
    }
}