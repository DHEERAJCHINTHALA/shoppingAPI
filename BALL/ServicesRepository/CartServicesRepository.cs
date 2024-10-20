using DALL.Models;
using DALL.Repository;
using System.Collections.Generic;
using System.Linq;


namespace BALL.ServicesRepository
{
    public class CartServicesRepository
    {
        CartRepository objdall = new CartRepository();
        public List<Cart> AllItems()
        {
            return objdall.GetAll().ToList();
        }
        public List<Cart> Single(int ID)
        {
            return objdall.GetSingle(ID).ToList();


        }

        public int InsertRecord(SendItemsIntoCart Obj)
        {
            int i = objdall.Insert(Obj);

            return i;
        }
    }
    }
