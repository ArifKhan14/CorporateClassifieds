using Microsoft.EntityFrameworkCore;
using OffersMicroservice.DBContexts;
using OffersMicroservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffersMicroservice.Repository
{
    public class OfferRepository : IOfferRepository
    {
        private readonly OfferContext _dbContext;

        public OfferRepository(OfferContext dbContext)
        {
            _dbContext = dbContext;
        }
        //public void DeleteOffer(int OfferId)
        //{
        //    var Offer = _dbContext.Offers.Find(OfferId);
        //    _dbContext.Offers.Remove(Offer);
        //    Save();
        //}

        public Offer GetOfferByID(int OfferId)
        {
            return _dbContext.Offers.Find(OfferId);
        }
        public IEnumerable<Offer> GetOfferByCategory(int category)
        {
            return _dbContext.Offers.Where(s=>s.CategoryId==category).ToList();
        }

        public IEnumerable<Offer> GetOfferByTopLikes()
        {
            return _dbContext.Offers.OrderByDescending(o=>o.Likes).Take(3).ToList();
        }

        public IEnumerable<Offer> GetOfferByPostedDate(DateTime dateTime)
        {
            return _dbContext.Offers.Where((x => DateTime.Compare(x.OpenedDate, dateTime) == 0)).ToList();
        }

        public IEnumerable<Offer> GetOffers()
        {
            return _dbContext.Offers.ToList();
        }

        public void addOffer(Offer Offer)
        {
            _dbContext.Offers.Add(Offer);
            Save();
        }   

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void editOffer(Offer Offer)
        {
            Offer offer = _dbContext.Offers.Find(Offer.OfferId);
            offer = Offer;
            _dbContext.Offers.Update(offer);
            Save();
        }
    }
}
