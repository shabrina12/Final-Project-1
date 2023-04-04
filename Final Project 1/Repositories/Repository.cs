using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Final_Project_1.Repositories.Interfaces;
using Final_Project_1.Models;

namespace Final_Project_1.Repositories
{
    public class BukuRepository : IBukuRepository
    {
        static string ConnectionString = "Data Source=DESKTOP-I3RV54S;Initial Catalog=db_perpustakaan;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        static SqlConnection connection;
        public List<Buku> GetAllBuku()
        {
            List<Buku> books = new List<Buku>();

            connection = new SqlConnection(ConnectionString);       

            // Membuat instance SQL Command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM buku;";

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader[0]);
                    Console.WriteLine("Judul: " + reader[1]);
                    Console.WriteLine("Pengarang: " + reader[2]);
                    Console.WriteLine("Penerbit: " + reader[3]);
                    Console.WriteLine("Tahun: " + reader[4]);
                    Console.WriteLine("================================");                    
                }
            }
            else
            {
                Console.WriteLine("Data buku kosong!");
            }
            reader.Close();
            connection.Close();
            return books;
        }

        public List<Buku> GetBukuById(int id)
        {
            List<Buku> books = new List<Buku>();

            connection = new SqlConnection(ConnectionString);

            // Membuat instance SQL Command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM buku WHERE id = @id";
            command.Parameters.Add(new SqlParameter("id", id));

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader[0]);
                    Console.WriteLine("Judul: " + reader[1]);
                    Console.WriteLine("Pengarang: " + reader[2]);
                    Console.WriteLine("Penerbit: " + reader[3]);
                    Console.WriteLine("Tahun: " + reader[4]);
                    Console.WriteLine("===============================");                    
                }
            }
            else
            {
                Console.WriteLine("Data buku tidak ditemukan!");
            }
            reader.Close();
            connection.Close();
            return books;
        }

        public int InsertBuku(Buku buku)
        {           
            connection = new SqlConnection(ConnectionString);

            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            var result = 0;

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO buku (judul, pengarang, penerbit, tahun) VALUES (@judul, @pengarang, @penerbit, @tahun);";
                command.Transaction = transaction;

                SqlParameter pJudul = new SqlParameter();
                pJudul.ParameterName = "@judul";
                pJudul.Value = buku.judul;
                pJudul.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(pJudul);

                SqlParameter pPengarang = new SqlParameter();
                pPengarang.ParameterName = "@pengarang";
                pPengarang.Value = buku.pengarang;
                pPengarang.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(pPengarang);

                SqlParameter pPenerbit = new SqlParameter();
                pPenerbit.ParameterName = "@penerbit";
                pPenerbit.Value = buku.penerbit;
                pPenerbit.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(pPenerbit);

                SqlParameter pTahun = new SqlParameter();
                pTahun.ParameterName = "@tahun";
                pTahun.Value = buku.tahun;
                pTahun.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(pTahun);

                result = command.ExecuteNonQuery();

                transaction.Commit();

                if (result > 0)
                {
                    Console.WriteLine("Data berhasil ditambahkan!");
                }
                else
                {
                    Console.WriteLine("Data gagal ditambahkan!");
                }
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }
            return result;
        }

        public int UpdateBuku(Buku buku)
        {
            connection = new SqlConnection(ConnectionString);

            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            var result = 0;

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE buku SET judul = @judul, pengarang = @pengarang, penerbit = @penerbit, tahun = @tahun WHERE id = @id";
                command.Transaction = transaction;

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = buku.id;
                pId.SqlDbType = SqlDbType.Int;
                command.Parameters.Add(pId);

                SqlParameter pJudul = new SqlParameter();
                pJudul.ParameterName = "@judul";
                pJudul.Value = buku.judul;
                pJudul.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(pJudul);

                SqlParameter pPengarang = new SqlParameter();
                pPengarang.ParameterName = "@pengarang";
                pPengarang.Value = buku.pengarang;
                pPengarang.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(pPengarang);

                SqlParameter pPenerbit = new SqlParameter();
                pPenerbit.ParameterName = "@penerbit";
                pPenerbit.Value = buku.penerbit;
                pPenerbit.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(pPenerbit);

                SqlParameter pTahun = new SqlParameter();
                pTahun.ParameterName = "@tahun";
                pTahun.Value = buku.tahun;
                pTahun.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(pTahun);

                result = command.ExecuteNonQuery();

                transaction.Commit();
                if (result > 0)
                {
                    Console.WriteLine("Data berhasil diubah!");
                }
                else
                {
                    Console.WriteLine("Data gagal diubah!");
                }
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }
            return result;
        }

        public int DeleteBuku(int id)
        {          
            connection = new SqlConnection(ConnectionString);

            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            var result = 0;

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM buku WHERE id = @id";
                command.Transaction = transaction;

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.Int;
                command.Parameters.Add(pId);

                result = command.ExecuteNonQuery();

                transaction.Commit();

                if (result > 0)
                {
                    Console.WriteLine("Data berhasil dihapus!");
                }
                else
                {
                    Console.WriteLine("Data gagal dihapus!");
                }
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }
            return result;
        }
    }
}