market-data url uses prod GET query to fetch prices, it basically passes the query through to a provider, like ICE, CME etc.

for fx spot contracts, example feed, mds strips "type=future" from the query
http://10.10.20.171:5004/quote?symbols=USDMYR+A0-FX&&fields=-decimal

for futures,
http://10.10.20.171:5004/quote?symbols=GBPHKD+A0-FX&type=future&&fields=-decimal

for options,
http://am1-dock04l:5004/options?symbols=HSO-CBT&fields=strike,exp,time,recent,impvol,delta,oldsettle,newsettle,prev,symbol,-decimal&datefmt=%d/%m/%y&timefmt=%d/%m/%y%20%H:%M&type=optfut

TT codes
https://tradingtechnologies.com/resources/tradable-products/

ICE codes
https://lookup.esignal.com/