using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionBussinessLogic
{
    public class ConstantInfos
    {
        public const string ErrorMessage = "Something went wrong. Please try again.";
        public const string NoRecordMessage = "No auction sales items found.";
        public const string BidSuccessMessage = "Bid saved successfully.";
        public const string SuccessMessage = "Success";
        public const string BasePriceValidationMessage = "Start bid amount cannot be less than base price.";
        public const string BidderCountValidationMessage = "Bidder count cannot be exceed to no.of maximum bidder count.";
    }
}
