using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using DALL.Models;

namespace DALL.Repository
{
    public class CartRepository
    {
        string cs = "server=LAPTOP-0C6MBQ3H;database=GPTEST;uid=sa;pwd=123";
        public List<Cart> GetAll()
        {

            List<Cart> cart = new List<Cart>();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("ITEMSCRUD", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACTION", "SELECT_ALL");
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Cart obj = new Cart
                    {

                        Id = (dr["Id"] as int?).GetValueOrDefault(),
                        Name = dr["Name"].ToString(),
                        Price = (dr["Price"] as int?).GetValueOrDefault(),
                        Image = dr["Image"].ToString()

                    };

                    cart.Add(obj);

                }

                return cart;
            }

        }

        public List<Cart> GetSingle(int ID)
        {

            List<Cart> cart = new List<Cart>();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("ITEMSCRUD", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACTION", "SINGLE");
                cmd.Parameters.AddWithValue("@Id", ID);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Cart obj = new Cart
                    {

                        Id = (dr["Id"] as int?).GetValueOrDefault(),
                        Name = dr["Name"].ToString(),
                        Price = (dr["Price"] as int?).GetValueOrDefault(),
                        Image = dr["Image"].ToString()

                    };

                    cart.Add(obj);

                }

                return cart;
            }

        }
        public int Insert(SendItemsIntoCart Obj)
        {

 
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("ITEMSCRUD", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ACTION", "INSERT");
                cmd.Parameters.AddWithValue("@Name",Obj.Name);
                cmd.Parameters.AddWithValue("@Price", Obj.Price);
                cmd.Parameters.AddWithValue("@Image",Obj.Image);
                cmd.Parameters.AddWithValue("@Quantity", Obj.Quantity);
                int i = cmd.ExecuteNonQuery();
                return i;
            }

        }

    }
}
