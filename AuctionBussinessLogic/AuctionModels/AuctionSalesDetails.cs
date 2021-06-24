using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AuctionBussinessLogic
{
    public class AuctionSalesDetails
    {
        [Required(ErrorMessage ="Auction Event cannot be empty")]
        public string AuctionEvent { get; set; }
        [Required(ErrorMessage = "SellerItem cannot be empty")]
        public string SellerItem { get; set; }
        
        public int AuctionEventId { get; set; }
        [Range(1, Double.PositiveInfinity,ErrorMessage = "Base price cannot be less than 0")]
        public int BasePrice { get; set; }

        [Range(1, Double.PositiveInfinity, ErrorMessage = "Max bidder count cannot be less than 0")]
        public int MaxBidderCount { get; set; }

        [Range(0, Double.PositiveInfinity, ErrorMessage = "Auto increment limit cannot be empty")]
        public int AutoIncrementLimit { get; set; }

        public string EventStarttime { get; set; }
        public string EventEndtime { get; set; }

        public List<BidDetails> BidDetails { get; set; }
    }
}
