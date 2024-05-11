using BooksWebApi.Models;
using System.Data.SqlClient;

namespace BooksWebApi
{
    public class DBConnection
    {
        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();

            var cmd = GetSqlCommand();

            cmd.CommandText = "SELECT * FROM Books";

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var book = new Book()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Title = reader["Title"].ToString(),
                    Pages = int.Parse(reader["Pages"].ToString()),

                };

                books.Add(book);
            }

            return books;
        }
        private SqlCommand GetSqlCommand()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=BooksDB;Integrated Security=True;TrustServerCertificate=True";
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandType = System.Data.CommandType.Text;

            return cmd;
        }
    }
}
