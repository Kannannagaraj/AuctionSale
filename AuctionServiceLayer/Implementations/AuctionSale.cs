using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AuctionBussinessLogic;

namespace AuctionServiceLayer
{
    public class AuctionSale : IAuctionSale
    {

        /// <summary>
        /// get the list auctionsales details
        /// </summary>
        /// <returns></returns>
        public List<AuctionSalesDetails> GetAuctionEventDetails()
        {
            var lstAuctionSales = new List<AuctionSalesDetails>();
            ////lstAuctionSales= get the auctionsales details from database. expecting more than 1 acution sales.
            return lstAuctionSales;
        }


        /// <summary>
        /// save the bid details against the auction
        /// </summary>
        /// <param name="auctionEventId"></param>
        /// <param name="bidDetails"></param>
        /// <returns></returns>
        public BidDetails BidForAuctionEvent(int auctionEventId, BidDetails bidDetails)
        {
            ////make a data layer call to save the bid details.
            return bidDetails;
        }


        /// <summary>
        /// get the winnner bid amount
        /// </summary>
        /// <param name="auctionSalesDetails"></param>
        /// <returns></returns>
        public int GetWinnerBidAmount1(AuctionSalesDetails auctionSalesDetails)
        {

            var auctionWinAmount = 0;
            if (auctionSalesDetails.BidDetails != null && auctionSalesDetails.BidDetails.Count > 0)
            {
                var loopBreak = false;
                var bidDetails = auctionSalesDetails.BidDetails.Where(x => x.IsOutofAuction == false).ToList<BidDetails>();
                while (!loopBreak)
                {
                    //var bidDetails = auctionSalesDetails.BidDetails.Where(x => x.IsOutofAuction == false).ToList<BidDetails>();
                    //// if the count is 1 then auction having one hightest bid amount, then break the loop 
                    if (bidDetails.Count() == 1)
                    {
                        loopBreak = true;
                        //// get the final winning bid amount
                        auctionWinAmount = bidDetails.Max(x => x.StartBidAmount);
                        break;
                    }
                    var maxamt = bidDetails.Max(x => x.StartBidAmount);
                    var bids = (from b in bidDetails
                                where ((maxamt + b.AutoIncrementAmount) <= b.MaxBidAmount)//&& maxamt > b.StartBidAmount
                                select new BidDetails
                                {
                                    BidderName = b.BidderName,
                                    BidId = b.BidId,
                                    MaxBidAmount = b.MaxBidAmount,
                                    StartBidAmount = (maxamt == b.StartBidAmount) ? maxamt : maxamt + b.AutoIncrementAmount,
                                    AutoIncrementAmount = b.AutoIncrementAmount,
                                    IsOutofAuction = b.IsOutofAuction
                                    //(maxamt < b.StartBidAmount) ? b.StartBidAmount :
                                }).ToList<BidDetails>();
                    bidDetails = bids;


                }
            }
            return auctionWinAmount;
        }

        /// <summary>
        /// get the winnner bid amount
        /// </summary>
        /// <param name="auctionSalesDetails"></param>
        /// <returns></returns>
        public int GetWinnerBidAmount2(AuctionSalesDetails auctionSalesDetails)
        {

            var auctionWinAmount = 0;
            if (auctionSalesDetails.BidDetails != null && auctionSalesDetails.BidDetails.Count > 0)
            {
                var loopBreak = false;
               
                while (!loopBreak)
                {
                    var bidDetails = auctionSalesDetails.BidDetails.Where(x => x.IsOutofAuction == false).ToList<BidDetails>();

                    //// if the count is 1 then auction having one hightest bid amount, then break the loop 
                    if (bidDetails.Count() == 1)
                    {
                        loopBreak = true;
                        //// get the final winning bid amount
                        auctionWinAmount = bidDetails.Max(x => x.StartBidAmount);
                        break;
                    }

                    var currentMaxbidAmount = bidDetails.Max(x => x.StartBidAmount);
                    foreach (var bid in bidDetails.OrderBy(x => x.MaxBidAmount))
                    {
                        ////get the current running max bid amount on the fly.

                        bid.SetMaxBidAmount(currentMaxbidAmount);
                    }

                }
            }
            return auctionWinAmount;
        }


    }
}