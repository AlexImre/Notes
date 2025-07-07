# market data overrides

## example for synthetics:

insert Amius..MarketDataSynthetics
select 'RP.EU26', '<AmiusSynthetic type="future" name="RP.EQ25">
  <Parameters>
    <Parameter type="contract" name="RPQ25" />
  </Parameters>
  <Operations>
    <!-- this is a function held inside the plugin directory -->
    <Operation type="defined" parameters="p1" name="Inverse" formula="p1 == 0 ? 0 : 1/p1" />
    <Operation type="passthrough" parameters="pThrough" name="PassThrough" />
  </Operations>
  <Outputs>
    <Output name="bid" parameters="[RPQ25].[ask]" operation="Inverse" />
    <Output name="ask" parameters="[RPQ25].[bid]" operation="Inverse" />
    <Output name="recent" parameters="[RPQ25].[recent]" operation="Inverse" />
    <Output name="prev" parameters="[RPQ25].[prev]" operation="Inverse" />
    <Output name="oldsettle" parameters="[RPQ25].[oldsettle]" operation="Inverse" />
    <Output name="newsettle" parameters="[RPQ25].[newsettle]" operation="Inverse" />
    <Output name="high" parameters="[RPQ25].[high]" operation="Inverse" />
    <Output name="low" parameters="[RPQ25].[low]" operation="Inverse" />
    <Output name="open" parameters="[RPQ25].[open]" operation="Inverse" />
    <Output name="close" parameters="[RPQ25].[close]" operation="Inverse" />
    <Output name="desc" parameters="EURGBP Synthetic" operation="PassThrough" />
    <Output name="time" parameters="[RPQ25].[time]" operation="PassThrough" />
    <Output name="exp" parameters="[RPQ25].[exp]" operation="PassThrough" />
  </Outputs>
</AmiusSynthetic>', 1, 0

## example for spot FX

```
if not exists (select 1 from MarketDataOverrides where underlying = 'TRY.U')
BEGIN
    insert MarketDataOverrides(underlying, granularity, provider, active, overrideSymbol, originalSymbol, underlyingRule) values ('TRY.U', 2, 4, 1, 'USDTRY A0-FX', 'USDTRY A0-FX', 'TRY.U *')
END
GO
```