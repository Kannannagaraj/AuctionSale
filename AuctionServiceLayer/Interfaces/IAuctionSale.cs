using System;
using System.Collections.Generic;
using System.Text;
using AuctionBussinessLogic;

namespace AuctionServiceLayer
{
    public interface IAuctionSale
    {
        /// <summary>
        /// Get list of auction event details
        /// </summary>
        /// <returns></returns>
        List<AuctionSalesDetails> GetAuctionEventDetails();

        /// <summary>
        /// make bid for auction based on auction id
        /// </summary>
        /// <param name="bidDetails"></param>
        /// <returns></returns>
        BidDetails BidForAuctionEvent(int auctionEventId, BidDetails bidDetails);

        /// <summary>
        /// Get the winner of the auction sale
        /// </summary>
        /// <param name="auctionSalesDetails"></param>
        /// <returns></returns>
        int GetWinnerBidAmount1(AuctionSalesDetails auctionSalesDetails);

        /// <summary>
        /// Get the winner of the auction sale
        /// </summary>
        /// <param name="auctionSalesDetails"></param>
        /// <returns></returns>
        int GetWinnerBidAmount2(AuctionSalesDetails auctionSalesDetails);

    }
}
