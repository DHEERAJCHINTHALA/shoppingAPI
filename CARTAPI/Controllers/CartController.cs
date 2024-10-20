using BALL.ServicesRepository;
using DALL.Models;
using DALL.Repository;
using System.Linq;
using System.Web.Http;

namespace CARTAPI.Controllers
{
    public class CartController : ApiController
    {
        CartRepository objdall = new CartRepository();
        CartServicesRepository objball = new CartServicesRepository();

        [HttpGet]
        public IHttpActionResult GET()
        {

            var res = objball.AllItems().ToList();

            return Ok(res);

        }
        [HttpGet]
        public IHttpActionResult SINGLEGET(int ID)
        {

            var res = objball.Single(ID).ToList();

            return Ok(res);


        }

        [HttpPost]
        public IHttpActionResult INSERT(SendItemsIntoCart Obj)
        {
            var res = objball.InsertRecord(Obj);

            return Ok(res);
        }
      }
    }
