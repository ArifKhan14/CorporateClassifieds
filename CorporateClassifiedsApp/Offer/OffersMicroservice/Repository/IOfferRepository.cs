using OffersMicroservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffersMicroservice.Repository
{
    public interface IOfferRepository
    {
        public Offer GetOfferByID(int OfferId);

        public IEnumerable<Offer> GetOfferByCategory(int category);

        public IEnumerable<Offer> GetOfferByTopLikes();
        public IEnumerable<Offer> GetOfferByPostedDate(DateTime dateTime);

        IEnumerable<Offer> GetOffers();

        public void addOffer(Offer Offer);

        void editOffer(Offer Offer);
    }
}
