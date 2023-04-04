using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project_1.Models;

namespace Final_Project_1.Views
{
    public class VBuku
    {
        public void GetAllBuku(List<Buku> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine("Id: " + book.id);
                Console.WriteLine("Judul: " + book.judul);
                Console.WriteLine("Pengarang: " + book.pengarang);
                Console.WriteLine("Penerbit: " + book.penerbit);
                Console.WriteLine("Tahun: " + book.tahun);
            }
        }

        public void GetBukuById(Buku book)
        {
            Console.WriteLine("Id: " + book.id);
            Console.WriteLine("Judul: " + book.judul);
            Console.WriteLine("Pengarang: " + book.pengarang);
            Console.WriteLine("Penerbit: " + book.penerbit);
            Console.WriteLine("Tahun: " + book.tahun);
        }
    }
}