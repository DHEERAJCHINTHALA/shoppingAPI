using DALL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace DALL.Repository
{
    public class SendItemsintoCartRepo
    {

        string cs = "server=LAPTOP-0C6MBQ3H;database=GPTEST;uid=sa;pwd=123";

        public int GetTotalQuantity()
        {
            int totalQuantity = 0;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("CARTCRUD", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACTION", "CARTCOUNT");

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    totalQuantity = dr["TotalQuantity"] != DBNull.Value ? Convert.ToInt32(dr["TotalQuantity"]) : 0;
                }
            }

            return totalQuantity;
        }
        public int SumOfCart()
        {
            int sumofcart = 0;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("CARTCRUD", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACTION", "CART_SUM");

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    sumofcart = dr["SUMOFCART"] != DBNull.Value ? Convert.ToInt32(dr["SUMOFCART"]) : 0;
                }
            }

            return sumofcart;
        }

        public List<SendItemsIntoCart> GetItemsFromCart()
        {

            List<SendItemsIntoCart> senditemcart = new List<SendItemsIntoCart>();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("CARTCRUD", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACTION", "SELECT_ALL");
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    SendItemsIntoCart obj = new SendItemsIntoCart
                    {

                        Id = (dr["Id"] as int?).GetValueOrDefault(),
                        Name = dr["Name"].ToString(),
                        Price = (dr["Price"] as int?).GetValueOrDefault(),
                        Image = dr["Image"].ToString(),
                        Quantity = (dr["Quantity"] as int?).GetValueOrDefault(),
                         ItemId= (dr["ItemId"] as int?).GetValueOrDefault()
                    };

                    senditemcart.Add(obj);

                }
                return senditemcart;
            }
        }

        public List<SendItemsIntoCart> GetSingleCartItems(int ID)
        {

            List<SendItemsIntoCart> senditemcart = new List<SendItemsIntoCart>();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("CARTCRUD", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACTION", "SINGLE");
                cmd.Parameters.AddWithValue("@ID", ID);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    SendItemsIntoCart obj = new SendItemsIntoCart
                    {

                        Id = (dr["Id"] as int?).GetValueOrDefault(),
                        Name = dr["Name"].ToString(),
                        Price = (dr["Price"] as int?).GetValueOrDefault(),
                        Image = dr["Image"].ToString(),
                        Quantity = (dr["Quantity"] as int?).GetValueOrDefault(),
                        ItemId = (dr["ItemId"] as int?).GetValueOrDefault()
                    };

                    senditemcart.Add(obj);

                }

                return senditemcart;
            }

          }

        public int UpdateRecord(int ID,SendItemsIntoCart Obj)
        {


            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("CARTCRUD", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACTION", "UPDATE");
                cmd.Parameters.AddWithValue("@ID",ID);
                cmd.Parameters.AddWithValue("@Quantity", Obj.Quantity);
                int i = cmd.ExecuteNonQuery();
                return i;
            }

        }

    }



}
