using DALL.Models;
using DALL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BALL.ServicesRepository
{
    public class SendingItemsIntoCartRepoServices
    {
        SendItemsintoCartRepo objdall = new SendItemsintoCartRepo();
        public List<SendItemsIntoCart> GettingItemsintoCart()
        {
            var res = objdall.GetItemsFromCart().ToList();
            return res;
        }

        public List<SendItemsIntoCart> GetSingleCartItems(int ID)
        {
            var res = objdall.GetSingleCartItems(ID).ToList();
            return res;

        }

        public int updatecartitems(int ID , SendItemsIntoCart obj)
        {
             int i = objdall.UpdateRecord(ID, obj);
            return i;
        }
        public int countcart()
        {
            int i = objdall.GetTotalQuantity();
            return i;
        }
        public int sum()
        {
            int i = objdall.SumOfCart();
            return i;
        }
    }
    }
