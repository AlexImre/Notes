# bad price data

- sometimes prices are wrong and need to be overwritten. Get accurate data from traders. In this example, the settle price was incorrect.
- `exec Phoenix..usp_addFuturesPrice 'CRDU25', 'SETTLE', '3 jun 2025', 64.74, 64.90, 64.68, 64.74, '3 jun 2025'`
- clear SettlePrice cache https://otc.amius.com/Admin/Cache/Index

![alt text](images/ohlc.png)

![alt text](images/bad-prices.png)

# energy contracts (oil example)

These follow a different process... https://techdocs.amius.com/Support/Setting-Up-Energy-Deal/

if prices are bad, need to re-run this process (pawel usually does), and then files are available here `\\am1-file01\OTC\Phoenix\ICE\oil`

these then need to be updated in the DB. Use the external symbol override and look up the month to map to the correct values in those files.

| Month      | Month Code |
|------------|------------|
| January    | F          |
| February   | G          |
| March      | H          |
| April      | J          |
| May        | K          |
| June       | M          |
| July       | N          |
| August     | Q          |
| September  | U          |
| October    | V          |
| November   | X          |
| December   | Z          |

https://www.cmegroup.com/month-codes.html

seems like energy prices just use the settle price for each of the `high`, `low`, `settle` and `last` values. 

```
exec Phoenix..usp_addFuturesPrice 'CKPM25', 'SETTLE', '10 jun 2025', 682.10700, 682.10700, 682.10700, 682.10700, '10 jun 2025'
```

then clear the cache, and re-run eod books if needed (ask ops for ids)