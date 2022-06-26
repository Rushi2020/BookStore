using DatabaseLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class BookRL:IBookRL
    {
        string connetionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public string AddBooks(BookModel bookModel)
        {
            using (SqlConnection con = new SqlConnection(connetionString))
                try
                {
                    SqlCommand cmd = new SqlCommand("addBooks", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BookName", bookModel.BookName);
                    cmd.Parameters.AddWithValue("@AuthorName", bookModel.AuthorName);
                    cmd.Parameters.AddWithValue("@DiscountPrice", bookModel.DiscountPrice);
                    cmd.Parameters.AddWithValue("@OriginalPrice", bookModel.OriginalPrice);
                    cmd.Parameters.AddWithValue("@Description", bookModel.Description);
                    cmd.Parameters.AddWithValue("@Rating", bookModel.Rating);
                    cmd.Parameters.AddWithValue("@Image", bookModel.Image);
                    cmd.Parameters.AddWithValue("@ReviewCount", bookModel.ReviewCount);
                    cmd.Parameters.AddWithValue("@BookCount", bookModel.BookCount);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    return "book added successfully";
                }
                catch (Exception ex)
                {
                   throw ex;
                }
           
        }
        public List<BookModel> BookList = new List<BookModel>();
        public List<BookModel> GetAllBookModels()
        {
            using (SqlConnection con = new SqlConnection(connetionString))
            {
                SqlCommand command = new SqlCommand("GetAllBooks", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                //Bind EmpModel generic list using dataRow     
                foreach (DataRow dr in dt.Rows)
                {
                    BookList.Add(
                    new BookModel
                    {
                        BookId = Convert.ToInt32(dr["BookId"]),
                        BookName = Convert.ToString(dr["BookName"]),
                        AuthorName = Convert.ToString(dr["AuthorName"]),
                        DiscountPrice = Convert.ToInt32(dr["DiscountPrice"]),
                        OriginalPrice = Convert.ToInt32(dr["OriginalPrice"]),
                        Description = Convert.ToString(dr["Description"]),
                        Rating = Convert.ToDouble(dr["Rating"]),
                        Image = Convert.ToString(dr["Image"]),
                        ReviewCount = Convert.ToInt32(dr["ReviewCount"]),
                        BookCount = Convert.ToInt32(dr["BookCount"])
                    }
                    );
                }
                return BookList;
            }
        }
        public BookModel GetBookModel(int? id)
        {
            BookModel book = new BookModel();

            using (SqlConnection con = new SqlConnection(connetionString))
            {
                string sqlQuery = "SELECT * FROM BookTable WHERE BookId= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    book.BookId = Convert.ToInt32(rdr["BookId"]);
                    book.BookName = rdr["BookName"].ToString();
                    book.AuthorName = rdr["AuthorName"].ToString();
                    book.DiscountPrice = Convert.ToInt32(rdr["DiscountPrice"]);
                    book.OriginalPrice = Convert.ToInt32(rdr["OriginalPrice"]);
                    book.Description = rdr["Description"].ToString();
                    book.Rating = Convert.ToDouble(rdr["DiscountPrice"]);
                    book.Image = rdr["Image"].ToString();
                    book.ReviewCount = Convert.ToInt32(rdr["ReviewCount"]);
                    book.BookCount = Convert.ToInt32(rdr["BookCount"]);

                }
                con.Close();
            }
            return book;
        }
        public void updateBook(BookModel bookModel)
        {
            using (SqlConnection con = new SqlConnection(connetionString))
            {
                SqlCommand command = new SqlCommand("updateBook", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@BookId", bookModel.BookId);
                command.Parameters.AddWithValue("@BookName", bookModel.BookName);
                command.Parameters.AddWithValue("@AuthorName", bookModel.AuthorName);
                command.Parameters.AddWithValue("@DiscountPrice", bookModel.DiscountPrice);
                command.Parameters.AddWithValue("@OriginalPrice", bookModel.OriginalPrice);
                command.Parameters.AddWithValue("@Description", bookModel.Description);
                command.Parameters.AddWithValue("@Rating", bookModel.Rating);
                command.Parameters.AddWithValue("@Image", bookModel.Image);
                command.Parameters.AddWithValue("@ReviewCount", bookModel.ReviewCount);
                command.Parameters.AddWithValue("@BookCount", bookModel.BookCount);

                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
        }
        public void deleteBook(BookModel bookModel)
        {
            using (SqlConnection con = new SqlConnection(connetionString))
            {
                SqlCommand cmd = new SqlCommand("deleteBook", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BookId", bookModel.BookId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}
