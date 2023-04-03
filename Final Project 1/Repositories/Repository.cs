using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using Final_Project_1.Repositories.Interfaces;
using static System.Reflection.Metadata.BlobBuilder;
using Final_Project_1.Context;
using Final_Project_1.Models;

namespace Final_Project_1.Repositories
{
    public class BukuRepository : IBukuRepository
    {
        public List<Buku> GetAllBuku()
        {
            List<Buku> books = new List<Buku>();

            // Membuat instance SQL Server Connection
            var connection = MyContext.GetConnection();

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
                    Console.WriteLine("====================");                    
                }
            }
            else
            {
                return null;
            }
            reader.Close();
            connection.Close();
            return books;
        }

        public List<Buku> GetBukuById(int id)
        {
            List<Buku> books = new List<Buku>();

            var connection = MyContext.GetConnection();

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
                    Console.WriteLine("====================");                    
                }
            }
            else
            {
                Console.WriteLine("data not found!");
            }
            reader.Close();
            connection.Close();
            return books;
        }

        public int InsertBuku(Buku buku)
        {
            var result = 0;
            var connection = MyContext.GetConnection();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

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
                connection.Close();
            }
            catch
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception exception)
                {
                    throw;
                }
            }
            return result;
        }

        public int UpdateBuku(Buku buku)
        {
            var result = 0;
            var connection = MyContext.GetConnection();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

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
                connection.Close();
            }
            catch
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception exception)
                {
                    throw;
                }
            }
            return result;
        }

        public int DeleteBuku(int id)
        {
            var result = 0;
            var connection = MyContext.GetConnection();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

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
                connection.Close();
            }
            catch
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception exception)
                {
                    throw;
                }
            }
            return result;
        }
        //static string ConnectionString = "Data Source=DESKTOP-I3RV54S;Initial Catalog=db_perpustakaan;Integrated Security=True;Connect Timeout=30;";

        //static SqlConnection connection;

        // GET ALL 
        //public static void GetAllBuku()
        //{
        //    connection = new SqlConnection(ConnectionString);

        //    //Membuat instance untuk command
        //    SqlCommand command = new SqlCommand();
        //    command.Connection = connection;
        //    command.CommandText = "SELECT * FROM buku";

        //    //Membuka koneksi
        //    connection.Open();

        //    using SqlDataReader reader = command.ExecuteReader();
        //    if (reader.HasRows)
        //    {
        //        while (reader.Read())
        //        {
        //            Console.WriteLine("Id: " + reader[0]);
        //            Console.WriteLine("Judul: " + reader[1]);
        //            Console.WriteLine("Pengarang: " + reader[2]);
        //            Console.WriteLine("Penerbit: " + reader[3]);
        //            Console.WriteLine("Tahun: " + reader[4]);
        //            Console.WriteLine("Tgl input: " + reader[5]);
        //            Console.WriteLine("===========================");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Data not found!");
        //    }
        //    reader.Close();

        //    connection.Close();
        //}

        //public static void GetBukuById(int id)
        //{
        //    connection = new SqlConnection(ConnectionString);

        //    //Membuat instance untuk command
        //    SqlCommand command = new SqlCommand();
        //    command.Connection = connection;
        //    command.CommandText = "SELECT * FROM buku WHERE id = @id"; // perintah sql untuk mengambil satu data region berdasarkan id nya
        //    command.Parameters.Add(new SqlParameter("id", id));

        //    //Membuka koneksi
        //    connection.Open();

        //    using SqlDataReader reader = command.ExecuteReader();
        //    if (reader.HasRows)
        //    {
        //        while (reader.Read())
        //        {
        //            Console.WriteLine("Id: " + reader[0]);
        //            Console.WriteLine("Judul: " + reader[1]);
        //            Console.WriteLine("Pengarang: " + reader[2]);
        //            Console.WriteLine("Penerbit: " + reader[3]);
        //            Console.WriteLine("Tahun: " + reader[4]);
        //            Console.WriteLine("Tgl input: " + reader[5]);
        //            Console.WriteLine("===========================");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Data not found!");
        //    }
        //    reader.Close();
        //    connection.Close();
        //}

        // INSERT 
        //        public static void InsertBuku(string judul, string pengarang, string penerbit, string tahun)
        //        {
        //            connection = new SqlConnection(ConnectionString);
        //            connection.Open();

        //            SqlTransaction transaction = connection.BeginTransaction();
        //            try
        //            {
        //                //Membuat instance untuk command
        //                SqlCommand command = new SqlCommand();
        //                command.Connection = connection;
        //                command.CommandText = "INSERT INTO buku (judul, pengarang, penerbit, tahun) VALUES (@judul, @pengarang, @penerbit, @tahun)"; // perintah sql untuk menambahkan data region baru
        //                command.Transaction = transaction;

        //                //Membuat parameter
        //                SqlParameter pJudul = new SqlParameter();
        //                pJudul.ParameterName = "@judul";
        //                pJudul.Value = judul;
        //                pJudul.SqlDbType = SqlDbType.VarChar;

        //                SqlParameter pPengarang = new SqlParameter();
        //                pPengarang.ParameterName = "@pengarang";
        //                pPengarang.Value = pengarang;
        //                pPengarang.SqlDbType = SqlDbType.VarChar;

        //                SqlParameter pPenerbit = new SqlParameter();
        //                pPenerbit.ParameterName = "@penerbit";
        //                pPenerbit.Value = penerbit;
        //                pPenerbit.SqlDbType = SqlDbType.VarChar;

        //                SqlParameter pTahun = new SqlParameter();
        //                pTahun.ParameterName = "@tahun";
        //                pTahun.Value = tahun;
        //                pTahun.SqlDbType = SqlDbType.VarChar;

        //                //Menambahkan parameter name ke command
        //                command.Parameters.Add(pJudul);
        //                command.Parameters.Add(pPengarang);
        //                command.Parameters.Add(pPenerbit);
        //                command.Parameters.Add(pTahun);

        //                //Menjalankan command
        //                int result = command.ExecuteNonQuery();
        //                transaction.Commit();

        //                if (result > 0)
        //                {
        //                    Console.WriteLine("Data berhasil ditambahkan!");
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Data gagal ditambahkan!");
        //                }

        //                connection.Close();
        //            }
        //            catch (Exception e)
        //            {
        //                Console.WriteLine(e.Message);
        //                try
        //                {
        //                    transaction.Rollback();
        //                }
        //                catch (Exception rollback)
        //                {
        //                    Console.WriteLine(rollback.Message);
        //                }
        //            }

        //        }

        //        // UPDATE 
        //        public static void UpdateBuku(int id, string judul)
        //        {
        //            connection = new SqlConnection(ConnectionString);
        //            connection.Open();

        //            SqlTransaction transaction = connection.BeginTransaction();

        //            try
        //            {
        //                //Membuat instance untuk command
        //                SqlCommand command = new SqlCommand();
        //                command.Connection = connection;
        //                command.CommandText = "UPDATE buku SET judul = @judul WHERE id = @id"; // perintah sql untuk mengubah data name berdasarkan id nya
        //                command.Transaction = transaction;

        //                //Membuat parameter judul & id
        //                SqlParameter pJudul = new SqlParameter();
        //                pJudul.ParameterName = "@judul";
        //                pJudul.Value = judul;
        //                pJudul.SqlDbType = SqlDbType.VarChar; 

        //                SqlParameter pId = new SqlParameter();
        //                pId.ParameterName = "@id";
        //                pId.Value = id;
        //                pId.SqlDbType = SqlDbType.Int; 

        //                //Menambahkan parameter id & judul ke command
        //                command.Parameters.Add(pId);
        //                command.Parameters.Add(pJudul);

        //                //Menjalankan command
        //                int result = command.ExecuteNonQuery();
        //                transaction.Commit();

        //                if (result > 0)
        //                {
        //                    Console.WriteLine("Data berhasil diubah!");
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Data gagal diubah!");
        //                }
        //                connection.Close();

        //            }
        //            catch (Exception e)
        //            {
        //                Console.WriteLine(e.Message);
        //                try
        //                {
        //                    transaction.Rollback();
        //                }
        //                catch (Exception rollback)
        //                {
        //                    Console.WriteLine(rollback.Message);
        //                }
        //            }

        //        }

        //        // DELETE
        //        public static void DeleteBuku(int id)
        //        {
        //            connection = new SqlConnection(ConnectionString);
        //            connection.Open();

        //            SqlTransaction transaction = connection.BeginTransaction();

        //            try
        //            {
        //                //Membuat instance untuk command
        //                SqlCommand command = new SqlCommand();
        //                command.Connection = connection;
        //                command.CommandText = "DELETE FROM buku WHERE id = @id"; // perintah sql untuk menghapus data region berdasarkan id
        //                command.Transaction = transaction;

        //                //Membuat parameter id
        //                SqlParameter pId = new SqlParameter();
        //                pId.ParameterName = "@id";
        //                pId.Value = id;
        //                pId.SqlDbType = SqlDbType.Int; // tipe data id adalah int

        //                //Menambahkan parameter id ke command
        //                command.Parameters.Add(pId);

        //                //Menjalankan command
        //                int result = command.ExecuteNonQuery();
        //                transaction.Commit();

        //                if (result > 0)
        //                {
        //                    Console.WriteLine("Data berhasil dihapus!");
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Data gagal dihapus!");
        //                }
        //                connection.Close();

        //            }
        //            catch (Exception e)
        //            {
        //                Console.WriteLine(e.Message);
        //                try
        //                {
        //                    transaction.Rollback();
        //                }
        //                catch (Exception rollback)
        //                {
        //                    Console.WriteLine(rollback.Message);
        //                }
        //            }
        //        }
        //    }
        //}
    }
}