using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project_1.Models;
using Final_Project_1.Repositories.Interfaces;
using Final_Project_1.Views;


namespace Final_Project_1.Controllers
{
    public class BukuController
    {
        private readonly IBukuRepository _bukuRepository;
        private readonly VBuku _vBuku;

        public BukuController(IBukuRepository bukuRepository, VBuku vBuku)
        {
            _bukuRepository = bukuRepository;
            _vBuku = vBuku;
        }

        // GET ALL
        public void GetAllBuku()
        {
            var books = _bukuRepository.GetAllBuku();
            if (books == null)
            {
                _vBuku.DataNotFound();
            }
            _vBuku.GetAllBuku(books);
        }

        // GET BY ID
        public void GetBukuById(int id)
        {
            var book = _bukuRepository.GetBukuById(id);
            if (book == null)
            {
                _vBuku.DataNotFound();
            }
            _vBuku.GetBukuById(book);
        }

        // INSERT
        public void InsertBuku(Buku buku)
        {
            var result = _bukuRepository.InsertBuku(buku);
            if (result > 0)
            {
                _vBuku.Success("inserted");
            }
            else
            {
                _vBuku.Failure("insert");
            }
        }

        // UPDATE
        public void UpdateBuku(Buku buku)
        {
            var result = _bukuRepository.UpdateBuku(buku);
            if (result > 0)
            {
                _vBuku.Success("updated");
            }
            else
            {
                _vBuku.Failure("update");
            }
        }

        // DELETE
        public void DeleteBuku(int id)
        {
            var result = _bukuRepository.DeleteBuku(id);
            if (result > 0)
            {
                _vBuku.Success("deleted");
            }
            else
            {
                _vBuku.Failure("delete");
            }
        }
    }
}