using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project_1.Models;

namespace Final_Project_1.Repositories.Interfaces
{
    public interface IBukuRepository
    {
        List<Buku> GetAllBuku();
        Buku GetBukuById(int id);
        int InsertBuku(Buku buku);
        int UpdateBuku(Buku buku);
        int DeleteBuku(int id);
    }
}