using DatabaseLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class WishListRL:IWishListRL
    {
        string connetionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public string AddBookToWishlist(WishListModel wishListModel)
        {
            using (SqlConnection con = new SqlConnection(connetionString))
                try
                {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("AddBookToWishlist", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", wishListModel.id);
                    cmd.Parameters.AddWithValue("@BookId", wishListModel.BookId);
                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return "Book added to WishList successfully";
                    }
                    else
                    {
                        return "Book is not added to WishList";
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }

        public string DeleteWishlist(int WishListId)
        {
            using (SqlConnection con = new SqlConnection(connetionString))
                try
                {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("DeleteWishlist", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WishListId", WishListId);
                    con.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result != 1)
                    {
                        return "Book deleted in WishList successfully";
                    }
                    else
                    {
                        return "Book is not deleted in WishList";
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }

        public List<WishListModel>GetWishListData(int id)
        {
            using (SqlConnection con = new SqlConnection(connetionString))
                try
                {
                    List<WishListModel> wishList = new List<WishListModel>();
                    SqlCommand cmd = new SqlCommand("GetWishlist", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            WishListModel wishListModel = new WishListModel();
                            BookModel bookModel = new BookModel();
                            bookModel.BookName = dr["BookName"].ToString();
                            bookModel.AuthorName = dr["AuthorName"].ToString();
                            bookModel.DiscountPrice = Convert.ToInt32(dr["DiscountPrice"]);
                            bookModel.OriginalPrice = Convert.ToInt32(dr["OriginalPrice"]);
                            bookModel.Description = dr["Description"].ToString();
                            bookModel.Rating = Convert.ToDouble(dr["Rating"]);
                            bookModel.Image = dr["Image"].ToString();
                            bookModel.ReviewCount = Convert.ToInt32(dr["ReviewCount"]);
                            bookModel.BookCount = Convert.ToInt32(dr["BookCount"]);
                            wishListModel.WishListId = Convert.ToInt32(dr["WishListId"]);
                            wishListModel.id = Convert.ToInt32(dr["id"]);
                            wishListModel.BookId = Convert.ToInt32(dr["BookId"]);
                            wishListModel.bookModel = bookModel;
                            wishList.Add(wishListModel);
                        }
                        return wishList;
                    }
                    else
                    {
                        return null;
                    }

                }
                
                catch (Exception ex)
                {
                    throw ex;
                }
               

        }

    }
}
