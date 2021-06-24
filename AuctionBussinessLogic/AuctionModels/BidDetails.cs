using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AuctionBussinessLogic
{
    public class BidDetails
    {
        [Required(ErrorMessage = "Bidder name cannot be empty")]
        public string BidderName { get; set; }
        public int BidId { get; set; }
        [Range(1, Double.PositiveInfinity, ErrorMessage = "Start bid amount cannot be less than 0")]
        public int StartBidAmount { get; set; }
        [Range(1, Double.PositiveInfinity, ErrorMessage = "Max bid amount cannot be less than 0")]
        public int MaxBidAmount { get; set; }
        [Range(0, Double.PositiveInfinity, ErrorMessage = "Auto increment limit cannot be empty")]
        public int AutoIncrementAmount { get; set; }

        public bool IsOutofAuction { get; set; }

        /// <summary>
        /// set the max bit amount for the buyer based on others bit max amount
        /// </summary>
        /// <param name="currentMaxBidAmount"></param>
        /// <returns></returns>
        public void SetMaxBidAmount(int currentMaxBidAmount)
        {
            /// if the start bid amount is greater than current running bid amount, we dont want to bother about the losing auction.
            /// else we need to do auto increment by the AutoIncrementAmount
            if (currentMaxBidAmount > this.StartBidAmount)
            {
                var currentBidAmount = (currentMaxBidAmount + this.AutoIncrementAmount);
                //// current running bid amount should not excced the buy's max bid amount.
                if (currentBidAmount <= this.MaxBidAmount)
                {
                    currentMaxBidAmount = currentBidAmount;
                    //// set the current running max bid amount as start bid amount for bidder.
                    this.StartBidAmount = currentMaxBidAmount;
                }
                else
                {
                    this.IsOutofAuction = true;
                }
               
            }
        }
    }
}
