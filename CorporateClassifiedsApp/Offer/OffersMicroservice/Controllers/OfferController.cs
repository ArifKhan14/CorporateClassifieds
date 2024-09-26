using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OffersMicroservice.Model;
using OffersMicroservice.Repository;

namespace OffersMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferRepository _offerRepository;

        public OfferController(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }


        // GET: api/Offer
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Offer/5
        //[Route("api/[controller]/getOfferByID")]
        [HttpGet("/api/Offer/getOfferByID/{id}", Name = "getOfferByID")]
        
        public IActionResult getOfferByID(int id)
        {
            var offer = _offerRepository.GetOfferByID(id);
            return new OkObjectResult(offer);
        }

        
        [HttpGet("/api/Offer/getOfferByCategory/{id}", Name = "getOfferByCategory")]
        public IActionResult getOfferByCategory(int id)
        {
            var offer = _offerRepository.GetOfferByCategory(id);
            return new OkObjectResult(offer);
        }

        [HttpGet("/api/Offer/getOfferByTopLikes", Name = "getOfferByTopLikes")]
        public IActionResult getOfferByTopLikes()
        {
            var offer = _offerRepository.GetOfferByTopLikes();
            return new OkObjectResult(offer);
        }

        [HttpGet("/api/Offer/getOfferByPostedDate/{id}", Name = "getOfferByPostedDate")]
        public IActionResult getOfferByPostedDate(DateTime id)
        {
            //DateTime dateTime = Convert.ToDateTime(datetime);
            var offer = _offerRepository.GetOfferByPostedDate(id);
            return new OkObjectResult(offer);
        }



        // POST: api/Offer
        [HttpPost("/api/Offer/addOffer")]
        public IActionResult AddOffer([FromBody] Offer offer)
        {
            using (var scope = new TransactionScope())
            {
                _offerRepository.addOffer(offer);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = offer.OfferId }, offer);
            }

        }


        [HttpPut("/api/Offer/editOffer")]
        public IActionResult EditOffer([FromBody] Offer _offer)                   // Error Multiple inputs
        {
            Offer offer = _offerRepository.GetOfferByID(_offer.OfferId);

            if (offer != null)
            {        
                    _offerRepository.editOffer(_offer);
                    return new OkResult();
            }
            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}






//Features to perform 
//GET: /getOfferDetails(Input: Offer ID | Output: Offer Details, Likes, Opened Date                       ------- Done

//etc.)

// GET: /getOfferByCategory(Input: Offer ID | Output: Offer Details, Likes, Opened                        -------- Done

//Date etc.)

// GET: /getOfferByTopLikes(Input: Offer ID | Output: Offer Details, Likes, Opened                        -------- Done

//Date etc.)

// GET: /getOfferByPostedDate(Input: Offer ID | Output: Offer Details, Likes, Opened                      -------- 

//Date etc.)

//o POST: /engageOffer(Input: offer ID, Employee ID| Output:Status of Update)

//o POST: /editOffer(Input: offer ID, Employee ID| Output:Status of Update)                      ---------

// POST: /addOffer(Input: Offer details, Employee Details) | Output: Status of Post)                -------