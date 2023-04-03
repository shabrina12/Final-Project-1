using System;
using System.Data.SqlClient;
using System.Xml.Linq;
using Final_Project_1.Controllers;
using Final_Project_1.Models;
using Final_Project_1.Repositories;
using Final_Project_1.Views;

namespace Final_Project_1;
public class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        BukuController bukuController = new BukuController(new BukuRepository(), new VBuku());

        string confirm;
        int input;

        do
        {
            Console.Clear();
            Console.WriteLine("================= MENU ===================");
            Console.WriteLine("1. Get All Book");
            Console.WriteLine("2. Get Book By Id");
            Console.WriteLine("3. Insert New Book");
            Console.WriteLine("4. Update Book");
            Console.WriteLine("5. Delete Book");
            Console.WriteLine("6. Exit");
            Console.Write("Input (1-6): ");

            input = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (input)
            {
                case 1:
                    Console.WriteLine("================= BOOK INFORMATION ===================");
                    bukuController.GetAllBuku();
                    break;
                case 2:
                    Console.Write("Input id dari buku yang ingin dicari: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("================= BOOK INFORMATION ===================");
                    bukuController.GetBukuById(id);
                    break;
                case 3:
                    Console.Write("Input Judul Buku: ");
                    var judul = Console.ReadLine();
                    Console.Write("Input Nama Pengarang: ");
                    var pengarang = Console.ReadLine();
                    Console.Write("Input Nama Penerbit: ");
                    var penerbit = Console.ReadLine();
                    Console.Write("Input Tahun Rilis: ");
                    var tahun = Console.ReadLine();
                    bukuController.InsertBuku(new Buku
                    {
                        judul = judul,
                        pengarang = pengarang,
                        penerbit = penerbit,
                        tahun = tahun
                    });
                    break;
                case 4:
                    Console.Write("Input Id dari buku yang ingin di update: ");
                    int id1 = int.Parse(Console.ReadLine());
                    Console.Write("Input Judul Baru: ");
                    var judul1 = Console.ReadLine();
                    Console.Write("Input Nama Pengarang Baru: ");
                    var pengarang1 = Console.ReadLine();
                    Console.Write("Input Nama Penerbit Baru: ");
                    var penerbit1 = Console.ReadLine();
                    Console.Write("Input Tahun Rilis Baru: ");
                    var tahun1 = Console.ReadLine();
                    bukuController.UpdateBuku(new Buku
                    {
                        id = id1,
                        judul = judul1,
                        pengarang = pengarang1,
                        penerbit = penerbit1,
                        tahun = tahun1
                    });
                    break;
                case 5:
                    Console.Write("Input Id dari buku yang mau dihapus: ");
                    id = int.Parse(Console.ReadLine());
                    bukuController.DeleteBuku(id);
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input!");                    
                    break;
            }
            Console.Write("Press y or Y to continue: ");
            confirm = Console.ReadLine().ToString();
            Console.Clear();
        } while (confirm == "y" || confirm == "Y");
    }
}