using BALL.ServicesRepository;
using DALL.Models;
using DALL.Repository;
using System.Collections.Generic;
using System.Web.Http;

namespace CARTAPI.Controllers
{
    public class InsertItemsIntoCartController : ApiController
    {
        SendItemsintoCartRepo objdall = new SendItemsintoCartRepo();

        SendingItemsIntoCartRepoServices objball = new SendingItemsIntoCartRepoServices();

        [HttpGet]
        public List<SendItemsIntoCart> GetAllCatItems()
        {
            var res = objdall.GetItemsFromCart();

            return res;
        }

        [HttpGet]
        [Route("api/InsertItemsIntoCart/countcart")]
        public IHttpActionResult  DetTotalCartItems()
        {
            int  res = objball.countcart();

            return Ok(res);
        }
        [HttpGet]
        [Route("api/InsertItemsIntoCart/sum")]
        public IHttpActionResult sumofcarts()
        {
            int res = objball.sum();

            return Ok(res);
        }
        [HttpGet]
        public List<SendItemsIntoCart> GetSingleCartItems(int ID)
        {
            var res = objdall.GetSingleCartItems(ID);

            return res;
        }


        [HttpPut]

        public IHttpActionResult update(int id, SendItemsIntoCart item)
        {

            int i = objball.updatecartitems(id, item);

            if (i == 1)
            {
                return Ok("Updated");
            }
            else
            {
                return Ok("Failed");
            }

        }
    }
}
