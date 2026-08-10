# Extending VisualHFT

VisualHFT supports two kinds of public extensions.

| Extension | Start here | Purpose |
| --- | --- | --- |
| Market connector | [Market Connector Template](../../SDK-MarketConnectorTemplate/README.md) | Connect a venue and publish normalised market data. |
| Study | [Study Plugin Template](../../SDK-StudyTemplate/README.md) | Calculate and publish a market-microstructure metric. |

Both templates compile against the current shared plugin APIs. Follow the linked SDK guide in the matching template before changing the scaffold.

## Loading an extension

VisualHFT discovers plugin DLLs in the directory that contains `VisualHFT.exe`. For a source build, add the extension project as a `ProjectReference` in `VisualHFT.csproj`, then rebuild the solution. No manual registration is required.

## License level

`IPlugin.RequiredLicenseLevel` is checked when VisualHFT loads a plugin. The public base classes default to `eLicenseLevel.COMMUNITY`. Keep that default, or explicitly return it, for a plugin intended for this public repository.

```csharp
public override eLicenseLevel RequiredLicenseLevel => eLicenseLevel.COMMUNITY;
```

See the [architecture overview](../architecture.md) for the data flow and plugin boundary.
