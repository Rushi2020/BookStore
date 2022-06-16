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

    }
}
