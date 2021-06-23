using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionBussinessLogic;
using AuctionServiceLayer;
//using System.Web.Http;
using System.Net;

namespace XomeAuctionSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auctionsale : ControllerBase
    {
        private IAuctionSale _auctionSale;
        public Auctionsale(IAuctionSale auctionSale)
        {
            this._auctionSale = auctionSale;
        }

        /// <summary>
        /// Get list of auction event details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAuctionEventDetails")]

        public async Task<IActionResult> GetAuctionEventDetails()
        {
            var lstAuctionDetails = _auctionSale.GetAuctionEventDetails();

            if (lstAuctionDetails.Count > 0)
                return await Task.FromResult(Ok(new { lstAuctionDetails, message = ConstantInfos.SuccessMessage }));
            else
                return await Task.FromResult(Ok(new { message = ConstantInfos.NoRecordMessage }));
        }

        /// <summary>
        /// make bid for auction based on auction id
        /// </summary>
        /// <param name="auctionEventId"></param>
        /// <param name="bidDetails"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("BidForAuctionEvent")]

        public async Task<IActionResult> BidForAuctionEvent(int auctionEventId, BidDetails bidDetails)
        {
            var bid = _auctionSale.BidForAuctionEvent(auctionEventId, bidDetails);
            return await Task.FromResult(Ok(new { bid, message = ConstantInfos.BidSuccessMessage }));

        }


        /// <summary>
        /// Get the winner of the auction sale
        /// </summary>
        /// <param name="auctionSalesDetails"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetAuctionWinningAmount1")]

        public async Task<IActionResult> GetAuctionWinningAmount1(AuctionSalesDetails auctionSalesDetails)
        {
            if(auctionSalesDetails.BidDetails.Count>0)
            {
                var minBidPrice = auctionSalesDetails.BidDetails.Min(x => x.StartBidAmount);
                if(minBidPrice<auctionSalesDetails.BasePrice)
                    return await Task.FromResult(Ok(new { message = ConstantInfos.BasePriceValidationMessage }));
                if(auctionSalesDetails.BidDetails.Count>auctionSalesDetails.MaxBidderCount)
                    return await Task.FromResult(Ok(new {  message = ConstantInfos.BidderCountValidationMessage }));
            }
            var bidWinningAmount = _auctionSale.GetWinnerBidAmount1(auctionSalesDetails);
            return await Task.FromResult(Ok(new { bidWinningAmount, message = ConstantInfos.SuccessMessage }));

        }
        /// <summary>
        /// Get the winner of the auction sale
        /// </summary>
        /// <param name="auctionSalesDetails"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetAuctionWinningAmount2")]

        public async Task<IActionResult> GetAuctionWinningAmount2(AuctionSalesDetails auctionSalesDetails)
        {
            if (auctionSalesDetails.BidDetails.Count > 0)
            {
                var minBidPrice = auctionSalesDetails.BidDetails.Min(x => x.StartBidAmount);
                if (minBidPrice < auctionSalesDetails.BasePrice)
                    return await Task.FromResult(Ok(new { message = ConstantInfos.BasePriceValidationMessage }));
                if (auctionSalesDetails.BidDetails.Count > auctionSalesDetails.MaxBidderCount)
                    return await Task.FromResult(Ok(new { message = ConstantInfos.BidderCountValidationMessage }));
            }
            var bidWinningAmount = _auctionSale.GetWinnerBidAmount2(auctionSalesDetails);
            return await Task.FromResult(Ok(new { bidWinningAmount, message = ConstantInfos.SuccessMessage }));

        }
    }
}
