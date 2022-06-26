using DatabaseLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class AddressRL:IAddressRL
    {
        string connetionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public string AddAddress(AddressModel addressModel)
        {
            using (SqlConnection con = new SqlConnection(connetionString))
                try
                {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("AddAddress", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", addressModel.id);
                    cmd.Parameters.AddWithValue("@Address", addressModel.Address);
                    cmd.Parameters.AddWithValue("@City", addressModel.City);
                    cmd.Parameters.AddWithValue("@State", addressModel.State);
                    cmd.Parameters.AddWithValue("@TypeId", addressModel.TypeId);
                    con.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result != 1)
                    {
                        return "Success:- Address added successfully";
                    }
                    else
                    {
                        return "Address is not Added pleace check once...";
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

        public string UpdateAddress(AddressModel addressModel)
        {
            using (SqlConnection con = new SqlConnection(connetionString))
                try
                {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("UpdateAddress", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AddressId", addressModel.AddressId);
                    cmd.Parameters.AddWithValue("@Address", addressModel.Address);
                    cmd.Parameters.AddWithValue("@City", addressModel.City);
                    cmd.Parameters.AddWithValue("@State", addressModel.State);
                    cmd.Parameters.AddWithValue("@TypeId", addressModel.TypeId);
                    con.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result != 1)
                    {
                        return "Success:- Address Updated successfully";
                    }
                    else
                    {
                        return "Address is not Updated pleace check once...";
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

        public string DeleteAddress(int AddressId)
        {
            using (SqlConnection con = new SqlConnection(connetionString))
                try
                {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("DeleteAddress", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AddressId", AddressId);
                    con.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result != 1)
                    {
                        return "Address deleted successfully";
                    }
                    else
                    {
                        return "Address is not deleted check once...";
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

        public List<AddressModel> GetAllAddress()
        {
            using (SqlConnection con = new SqlConnection(connetionString))
                try
                {
                using (con)
                {
                    List<AddressModel> address = new List<AddressModel>();
                    SqlCommand cmd = new SqlCommand("GetAllAddress", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            AddressModel addressModel = new AddressModel();
                            addressModel.AddressId = Convert.ToInt32(dr["AddressId"]);
                            addressModel.id = Convert.ToInt32(dr["id"]);
                            addressModel.Address = dr["Address"].ToString();
                            addressModel.City = dr["City"].ToString();
                            addressModel.State = dr["State"].ToString();
                            addressModel.TypeId = Convert.ToInt32(dr["TypeId"]);
                            address.Add(addressModel);
                        }
                        return address;
                    }
                    else
                    {
                        return null;
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



        public List<AddressModel> GetAddressById(int id)
        {
            using (SqlConnection con = new SqlConnection(connetionString))
                try
                {
                using (con)
                {
                    List<AddressModel> address = new List<AddressModel>();
                    SqlCommand cmd = new SqlCommand("GetAddressById", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            AddressModel addressModel = new AddressModel();
                            addressModel.AddressId = Convert.ToInt32(dr["AddressId"]);
                            addressModel.id = Convert.ToInt32(dr["id"]);
                            addressModel.Address = dr["Address"].ToString();
                            addressModel.City = dr["City"].ToString();
                            addressModel.State = dr["State"].ToString();
                            addressModel.TypeId = Convert.ToInt32(dr["TypeId"]);
                            address.Add(addressModel);
                        }
                        return address;
                    }
                    else
                    {
                        return null;
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

    }
}
