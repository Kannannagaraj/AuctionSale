# AuctionSale

Consider we are building a new auction application where a seller can offer an item up for sale and people can bid against each other to buy the item. We need to come up with the algorithm to automatically determine the winning bid after all bidders have entered their information on the site. 
The site will allow each bidder to enter three parameters: 
Starting bid - The first and lowest bid the buyer is willing to offer for the item. 
Max bid - This maximum amount the bidder is willing to pay for the item. 
Auto-increment amount - A dollar amount that the computer algorithm will add to the bidder's current bid each time the bidder is in a losing position relative to the other bidders. 
The algorithm should never let the current bid exceed the Max bid. The algorithm should only allow increments of the exact auto-increment amount.