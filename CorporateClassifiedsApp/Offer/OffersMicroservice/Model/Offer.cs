using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OffersMicroservice.Model
{
    public class Offer
    {
        [Key,Required]
        public int OfferId { get; set; }
        [Required]
        public string OfferName { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public DateTime OpenedDate { get; set; }
        [Required]
        public DateTime ClosedDate { get; set; }
        
        public DateTime EngagedDate { get; set; }
        [Required]
        public int CategoryId { get; set; }
        
        [Required]
        public int PostedBy { get; set; }

        public int Likes { get; set; }

    }
}
