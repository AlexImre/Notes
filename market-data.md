market-data url uses prod GET query to fetch prices, it basically passes the query through to a provider, like ICE, CME etc.

for fx spot contracts, example feed, mds strips "type=future" from the query
http://10.10.20.171:5004/quote?symbols=USDMYR+A0-FX&&fields=-decimal

for futures,
http://10.10.20.171:5004/quote?symbols=GBPHKD+A0-FX&type=future&&fields=-decimal

